public class TabMySeftNew : MainTabNew
{
	public class infoItem
	{
		private short index;

		private MainInfoItem[] mInfo;

		public infoItem(MainInfoItem[] mItemInfo, short index)
		{
			mInfo = mItemInfo;
			this.index = index;
		}
	}

	public int numW;

	public int numH;

	public static int maxSize = 12;

	private int h12;

	private int w5;

	public static int delta = 0;

	private sbyte idSelect;

	private int xStart;

	private int yStart;

	public static MainInfoItem[] mItemInfo;

	public static MainInfoItem[] mItemInfoShow;

	private int[] mColorInfo;

	private mVector vecItemMenu = new mVector("TabMySeftNew vecItemMenu");

	public static string[] meffskill = new string[5];

	private bool isList;

	private int maxList;

	private int selectList;

	private int xList;

	private int yList;

	private int timeUpdateInfo;

	private bool isShowInfo;

	private mVector vecListCmd = new mVector("vec List cmd");

	private sbyte indexTab;

	private iCommand cmdChange;

	private iCommand cmdChangeEquip;

	private iCommand cmdCloseChange;

	private iCommand cmdPetInfo;

	private iCommand cmdPetFeed;

	private iCommand cmdNexTab;

	private iCommand cmdReturn;

	private ListNew list;

	private int wsize;

	public TabMySeftNew(string nametab)
	{
		wsize = MainTabNew.wOneItem;
		typeTab = MainTabNew.EQUIP;
		if (GameCanvas.isSmallScreen)
		{
			delta = 10;
		}
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
		h12 = MainTabNew.hblack / 12;
		w5 = MainTabNew.wblack / 5;
		numW = MainTabNew.wblack / MainTabNew.wOneItem;
		if (numW > 6)
		{
			numW = 6;
		}
		xStart = xBegin + MainTabNew.wblack / 2 - numW * MainTabNew.wOneItem / 2 + ((!GameCanvas.isSmallScreen) ? (numW / 2) : 0);
		yStart = yBegin + h12 * 10 - MainTabNew.wOneItem;
		numH = maxSize / numW;
		nameTab = nametab;
		if (nametab == null || nametab.Length == 0)
		{
			nameTab = "Name Tab";
		}
		cmdCloseChange = new iCommand(T.close, -2, this);
		cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			cmdBack.caption = T.close;
		}
		cmdChange = new iCommand(T.change, 0, this);
		cmdChangeEquip = new iCommand(T.equip, 1, this);
		cmdPetInfo = new iCommand(T.info, 2, this);
		cmdPetFeed = new iCommand(T.choan, 3, this);
		cmdNexTab = new iCommand(T.trangbi2, 4, this);
		cmdReturn = new iCommand(T.trangbi1, 5, this);
		if (!GameCanvas.isTouch)
		{
			left = cmdNexTab;
		}
		indexTab = 0;
	}

	public override void init()
	{
		if (GameCanvas.isTouch)
		{
			idSelect = -1;
		}
		else
		{
			idSelect = 0;
		}
		isList = false;
		listContent = null;
		if (!GameCanvas.isTouch)
		{
			right = cmdBack;
			center = cmdChange;
		}
		MainTabNew.timePaintInfo = 0;
		base.init();
	}

	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		if (GameCanvas.isTouch)
		{
			idSelect = -1;
		}
		else
		{
			idSelect = 0;
		}
		base.backTab();
	}

	public override void commandPointer(int index, int subIndex)
	{
		if (idSelect == -1 && index != -1)
		{
			return;
		}
		switch (index)
		{
		case -1:
			backTab();
			break;
		case 0:
		{
			int num = 0;
			num = MainTemplateItem.mItem_Equip_Tem[idSelect + indexTab];
			Item item = (Item)Item.VecEquipPlayer.get(string.Empty + (idSelect + indexTab));
			if (item == null)
			{
				switch (num)
				{
				case -2:
					return;
				case -1:
					num = ((GameScreen.player.clazz != 2) ? ((GameScreen.player.clazz != 3) ? (8 + GameScreen.player.clazz) : 10) : 11);
					break;
				}
			}
			else
			{
				num = item.type_Only_Item;
			}
			if (num == 14)
			{
				if (item != null)
				{
					GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.EQUIP);
				}
				return;
			}
			listItemMenu(num);
			if (vecItemMenu != null && vecItemMenu.size() > 0)
			{
				TabScreenNew.timeRepaint = 10;
				maxList = vecItemMenu.size();
				if (maxList > numW)
				{
					maxList = numW;
				}
				int num2 = xStart + idSelect % numW * wsize - maxList * wsize / 2 + MainTabNew.wOneItem / 2;
				int num3 = yStart + idSelect / numW * wsize + MainTabNew.wOneItem + MainTabNew.wOne5;
				if (num2 < xBegin + MainTabNew.wOne5 * 2)
				{
					num2 = xBegin + MainTabNew.wOne5 * 2;
				}
				else if (num2 + maxList * wsize + MainTabNew.wOne5 > xBegin + MainTabNew.wblack - MainTabNew.wOne5)
				{
					num2 = xBegin + MainTabNew.wblack - MainTabNew.wOne5 - (maxList * wsize + MainTabNew.wOne5);
				}
				if (num3 + MainTabNew.wOneItem + MainTabNew.wOne5 * 2 > GameCanvas.h - GameCanvas.hCommand / 2)
				{
					num3 = GameCanvas.h - GameCanvas.hCommand / 2 - MainTabNew.wOneItem - MainTabNew.wOne5 * 2;
				}
				xList = num2;
				yList = num3;
				MainScreen.cameraSub.setAllTo((vecItemMenu.size() - maxList) * wsize, 0, 0, 0);
				list = new ListNew(xList, yList, maxList * wsize, wsize, 0, 0, (vecItemMenu.size() - maxList) * wsize);
				isList = true;
				mItemInfo = null;
				mItemInfoShow = null;
				if (!GameCanvas.isTouch)
				{
					center = cmdChangeEquip;
					if (!GameCanvas.isTouch)
					{
						right = cmdCloseChange;
					}
					else
					{
						right = null;
					}
				}
				MainTabNew.timePaintInfo = 0;
			}
			else
			{
				if (!GameCanvas.isTouch)
				{
					right = cmdBack;
					center = cmdChange;
				}
				isList = false;
				GameCanvas.start_Ok_Dialog(T.khongcovatphanphuhop);
			}
			break;
		}
		case 1:
		{
			Item item = (Item)vecItemMenu.elementAt(selectList);
			if (item.setNameNull())
			{
				return;
			}
			GlobalService.gI().Use_Item((sbyte)item.Id, idSelect);
			MainTabNew.timePaintInfo = 0;
			TabScreenNew.timeRepaint = 10;
			if (!GameCanvas.isTouch)
			{
				right = cmdBack;
				center = cmdChange;
			}
			isList = false;
			vecItemMenu.removeAllElements();
			selectList = 0;
			break;
		}
		case -2:
			MainTabNew.timePaintInfo = 0;
			TabScreenNew.timeRepaint = 10;
			if (!GameCanvas.isTouch)
			{
				right = cmdBack;
				center = cmdChange;
			}
			isList = false;
			vecItemMenu.removeAllElements();
			selectList = 0;
			break;
		case 2:
		{
			Item item = (Item)Item.VecEquipPlayer.get(string.Empty + idSelect);
			if (item != null && item.ItemCatagory == 9)
			{
				GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.EQUIP);
			}
			break;
		}
		case 3:
		{
			Item item = (Item)Item.VecEquipPlayer.get(string.Empty + idSelect);
			if (item != null && item.ItemCatagory == 9)
			{
				GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.EQUIP);
			}
			mVector mVector3 = new mVector("TabMySeftNew vecItemMenu");
			TabShopNew tabShopNew = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.choan, -1, TabShopNew.INVEN_FOOD_PET);
			tabShopNew.petCur = MsgDialog.pet;
			mVector3.addElement(tabShopNew);
			GameCanvas.foodPet = new TabScreenNew();
			GameCanvas.foodPet.selectTab = 0;
			GameCanvas.foodPet.addMoreTab(mVector3);
			GameCanvas.foodPet.Show(GameCanvas.currentScreen);
			break;
		}
		case 4:
			indexTab = 12;
			if (GameCanvas.isTouch)
			{
				vecListCmd = doMenu(null);
				setPosCmd(vecListCmd);
			}
			if (!GameCanvas.isTouch || (mSystem.isj2me && GameCanvas.isTouch))
			{
				left = cmdReturn;
			}
			break;
		case 5:
			indexTab = 0;
			if (GameCanvas.isTouch)
			{
				vecListCmd = doMenu(null);
				setPosCmd(vecListCmd);
			}
			if (!GameCanvas.isTouch || (mSystem.isj2me && GameCanvas.isTouch))
			{
				left = cmdNexTab;
			}
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public override void paint(mGraphics g)
	{
		GameScreen.player.paintShowPlayer(g, xBegin + w5 + delta / 2, yBegin + h12 * 5 / 2 + 15, 0);
		g.setColor(MainTabNew.color[1]);
		if (!GameCanvas.isSmallScreen)
		{
			g.fillRect(xBegin + w5 / 4, yBegin + h12 * 6 - h12 / 2, w5 * 2 - w5 / 2 + delta, 1, mGraphics.isFalse);
			g.fillRect(xBegin + w5 * 2 + delta + w5 / 4, yBegin + h12 * 6 - h12 / 2, w5 * 2 + delta + w5 / 2, 1, mGraphics.isFalse);
		}
		g.fillRect(xBegin + w5 * 2 + delta, yBegin + h12 / 4, 1, h12 * 8 - h12 / 2, mGraphics.isFalse);
		mFont.tahoma_7_orange.drawString(g, string.Empty + GameScreen.player.pointPk, xBegin + 15, yBegin + h12 * 6 - h12 / 2 + 4 - (GameCanvas.isSmallScreen ? 8 : 0), 0, mGraphics.isFalse);
		mFont.tahoma_7_orange.drawString(g, string.Empty + Player.PointSucKhoe, xBegin + 15, yBegin + h12 * 6 - h12 / 2 + GameCanvas.hText + 4 - (GameCanvas.isSmallScreen ? 12 : 0), 0, mGraphics.isFalse);
		g.drawImage(MainTabNew.img_pkIcn, xBegin + 4, yBegin + h12 * 6 - h12 / 2 + 4 - (GameCanvas.isSmallScreen ? 8 : 0), 0, mGraphics.isFalse);
		g.drawImage(MainTabNew.img_skIcn, xBegin + 4, yBegin + h12 * 6 - h12 / 2 + GameCanvas.hText + 4 - (GameCanvas.isSmallScreen ? 12 : 0), 0, mGraphics.isFalse);
		if (!GameCanvas.isSmallScreen)
		{
			for (int i = 0; i < 5; i++)
			{
				g.drawRegion(MainTabNew.imgTab[5], 0, i * 10, 10, 10, 0, xBegin + w5 * 2 + delta + 10 + i % 3 * w5 + 3, yBegin + h12 * 6 - h12 / 2 + 9 + i / 3 * h12, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isFalse);
				string st = string.Empty;
				if (isList)
				{
					if (mItemInfoShow != null)
					{
						st = meffskill[i] + string.Empty;
					}
				}
				else
				{
					st = GameScreen.player.mKhangChar[i];
				}
				mFont.tahoma_7_white.drawString(g, st, xBegin + w5 * 2 + delta + 14 + i % 3 * w5, yBegin + h12 * 6 - h12 / 2 + 3 + i / 3 * h12, 0, mGraphics.isFalse);
			}
		}
		paintArenaPoint(g);
		g.setColor(MainTabNew.color[4]);
		for (byte b = 0; b < maxSize; b++)
		{
			int num = xStart + b % numW * wsize;
			int num2 = yStart + b / numW * wsize;
			Item item = (Item)Item.VecEquipPlayer.get(string.Empty + (b + indexTab));
			if (item != null)
			{
				if (item.Id > -1)
				{
					item.paintItem(g, num + MainTabNew.wOneItem / 2, num2 + MainTabNew.wOneItem / 2, MainTabNew.wOneItem, 0, 0);
				}
				else if (indexTab <= 0)
				{
					g.drawRegion(MainTabNew.imgTab[6], 0, b * 20, 20, 20, 0, num + MainTabNew.wOneItem / 2, num2 + MainTabNew.wOneItem / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			else if (indexTab <= 0)
			{
				g.drawRegion(MainTabNew.imgTab[6], 0, b * 20, 20, 20, 0, num + MainTabNew.wOneItem / 2, num2 + MainTabNew.wOneItem / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			}
			g.setColor(MainTabNew.color[4]);
			g.drawRect(num, num2, wsize, wsize, mGraphics.isFalse);
		}
		g.setColor(MainTabNew.color[3]);
		if (MainTabNew.Focus == MainTabNew.INFO && idSelect >= 0)
		{
			int num3 = xStart + idSelect % numW * wsize;
			int num4 = yStart + idSelect / numW * wsize;
			g.drawRect(num3, num4, wsize, wsize, mGraphics.isFalse);
			g.setColor(MainTabNew.color[2]);
			g.drawRect(num3 + 1, num4 + 1, wsize - 2, wsize - 2, mGraphics.isFalse);
		}
		if (isList)
		{
			if (mItemInfoShow != null)
			{
				paintInfoPlayer(g, xBegin + w5 * 2 + 4 + delta, yBegin + 4, mItemInfoShow, isShowInfo);
			}
			else
			{
				mFont.tahoma_7_white.drawString(g, T.danglaydulieu, xBegin + w5 * 2 + 4 + delta, yBegin + 4, 0, mGraphics.isFalse);
			}
		}
		else
		{
			paintInfoPlayer(g, xBegin + w5 * 2 + 4 + delta, yBegin + 4, GameScreen.player.mInfoChar, isNew: true);
		}
		if (MainTabNew.Focus == MainTabNew.INFO)
		{
			if ((MainTabNew.timePaintInfo > MainTabNew.timeRequest || (isList && MainTabNew.timePaintInfo > 5)) && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null)
			{
				paintPopupContent(g, MainTabNew.longwidth <= 0 && isList);
			}
			if (isList)
			{
				paintList(g);
			}
		}
		if (vecListCmd != null)
		{
			for (int j = 0; j < vecListCmd.size(); j++)
			{
				iCommand iCommand2 = (iCommand)vecListCmd.elementAt(j);
				iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
			}
		}
	}

	public void paintList(mGraphics g)
	{
		int num = vecItemMenu.size();
		int num2 = MainTabNew.wOneItem + MainTabNew.wOne5 * 2;
		if (num2 < 32)
		{
			num2 = 32;
		}
		AvMain.paintDialog(g, xList - maxList / 2 - MainTabNew.wOne5, yList - MainTabNew.wOne5, maxList * MainTabNew.wOneItem + MainTabNew.wOne5 * 2, num2, 12);
		g.setClip(xList + ((num == 1) ? 1 : 0), yList, maxList * wsize + 2, MainTabNew.wOneItem + MainTabNew.wOne5 * 2);
		g.translate(-MainScreen.cameraSub.xCam, 0);
		for (int i = 0; i < num; i++)
		{
			Item item = (Item)vecItemMenu.elementAt(i);
			item.paintItem(g, xList + i * wsize + MainTabNew.wOneItem / 2 + ((num == 1) ? 1 : 0), yList + MainTabNew.wOneItem / 2, MainTabNew.wOneItem, 0, 0);
		}
		if (num > 0)
		{
			g.setColor(MainTabNew.color[2]);
			g.drawRect(xList + selectList * wsize + ((num == 1) ? 1 : 0), yList + 1, wsize, wsize, mGraphics.isFalse);
		}
		GameCanvas.resetTrans(g);
	}

	public void paintInfoPlayer(mGraphics g, int x, int y, MainInfoItem[] mItemInfo, bool isNew)
	{
		if (mItemInfo == null)
		{
			return;
		}
		foreach (MainInfoItem mainInfoItem in mItemInfo)
		{
			if (mainInfoItem == null || (mainInfoItem.id > 4 && mainInfoItem.id != 40 && mainInfoItem.id != 14) || mainInfoItem.value == 0)
			{
				continue;
			}
			mFont tahoma_7_white = mFont.tahoma_7_white;
			tahoma_7_white = (isNew ? MainTabNew.setTextColor(Item.colorInfoItem[mainInfoItem.id]) : mFont.tahoma_7_black);
			string st = Item.nameInfoItem[mainInfoItem.id] + ": " + Item.getPercent(Item.isPercentInfoItem[mainInfoItem.id], mainInfoItem.value);
			tahoma_7_white.drawString(g, st, x, y, 0, mGraphics.isTrue);
			int num = 0;
			if (GameScreen.player.vecBuff != null && !GameCanvas.isSmallScreen)
			{
				for (int j = 0; j < GameScreen.player.vecBuff.size(); j++)
				{
					MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuff.elementAt(j);
					if (mainBuff.minfo == null)
					{
						continue;
					}
					for (int k = 0; k < mainBuff.minfo.Length; k++)
					{
						if (mainInfoItem.id == mainBuff.minfo[k].id)
						{
							num += mainBuff.minfo[k].value;
						}
					}
				}
			}
			if (num != 0)
			{
				string empty = string.Empty;
				mFont mFont2 = mFont.tahoma_7_green;
				if (num > 0)
				{
					empty = " +" + Item.getPercent(Item.isPercentInfoItem[mainInfoItem.id], num);
				}
				else
				{
					empty = " " + Item.getPercent(Item.isPercentInfoItem[mainInfoItem.id], num);
					mFont2 = mFont.tahoma_7_red;
				}
				int width = mFont.tahoma_7_white.getWidth(st);
				mFont2.drawString(g, " " + empty, x + width, y, 0, mGraphics.isTrue);
			}
			y += GameCanvas.hText;
		}
	}

	public override void update()
	{
		if (MainTabNew.Focus == MainTabNew.INFO)
		{
			if (listContent != null)
			{
				listContent.moveCamera();
			}
			if (isList)
			{
				if (GameCanvas.isTouch)
				{
					list.moveCamera();
				}
				else
				{
					MainScreen.cameraSub.UpdateCamera();
				}
			}
			updateContent();
		}
		else
		{
			MainTabNew.timePaintInfo = 0;
		}
		GameScreen.player.updateEye();
	}

	public void updateContent()
	{
		if (idSelect == -1)
		{
			return;
		}
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (isList)
			{
				if (MainTabNew.timePaintInfo == 5)
				{
					setPaintInfo();
				}
			}
			else if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				setPaintInfo();
			}
		}
		else
		{
			if (!isList || isShowInfo)
			{
				return;
			}
			if (mItemInfo == null)
			{
				timeUpdateInfo++;
				if (timeUpdateInfo % 100 == 3)
				{
					MainItem mainItem = (MainItem)vecItemMenu.elementAt(selectList);
					if (mainItem != null)
					{
						GlobalService.gI().Item_More_Info(idSelect, (sbyte)mainItem.Id);
					}
				}
				return;
			}
			mColorInfo = new int[mItemInfo.Length];
			for (int i = 0; i < mItemInfo.Length; i++)
			{
				MainInfoItem mainInfoItem = mItemInfo[i];
				mColorInfo[i] = 0;
				for (int j = 0; j < GameScreen.player.mInfoChar.Length; j++)
				{
					MainInfoItem mainInfoItem2 = GameScreen.player.mInfoChar[i];
					if (mainInfoItem.id == mainInfoItem2.id)
					{
						if (mainInfoItem.value > mainInfoItem2.value)
						{
							mColorInfo[i] = 2;
						}
						else if (mainInfoItem.value < mainInfoItem2.value)
						{
							mColorInfo[i] = 3;
						}
						break;
					}
				}
			}
			isShowInfo = true;
		}
	}

	public override void updatekey()
	{
		if (MainTabNew.Focus == MainTabNew.INFO)
		{
			if (isList)
			{
				if (listContent != null)
				{
					if (GameCanvas.keyMyHold[2])
					{
						if (listContent.cmtoX > 0)
						{
							listContent.cmtoX -= GameCanvas.hText;
						}
						else
						{
							listContent.cmtoX = 0;
						}
						GameCanvas.clearKeyHold(2);
					}
					else if (GameCanvas.keyMyHold[8])
					{
						if (listContent.cmtoX < listContent.cmxLim)
						{
							listContent.cmtoX += GameCanvas.hText;
						}
						else
						{
							listContent.cmtoX = listContent.cmxLim;
						}
						GameCanvas.clearKeyHold(8);
					}
				}
				int num = selectList;
				if (GameCanvas.keyMyHold[4])
				{
					selectList--;
					GameCanvas.clearKeyHold(4);
				}
				else if (GameCanvas.keyMyHold[6])
				{
					selectList++;
					GameCanvas.clearKeyHold(6);
				}
				selectList = resetSelect(selectList, vecItemMenu.size() - 1, isreset: true);
				if (num != selectList)
				{
					MainScreen.cameraSub.moveCamera(selectList * wsize - maxList * wsize / 2, 0);
					MainTabNew.timePaintInfo = 0;
				}
			}
			else
			{
				int num2 = idSelect;
				if (listContent != null)
				{
					if (GameCanvas.keyMyHold[2])
					{
						if (listContent.cmtoX > 0)
						{
							listContent.cmtoX -= GameCanvas.hText;
						}
						else
						{
							listContent.cmtoX = 0;
						}
						GameCanvas.clearKeyHold(2);
					}
					else if (GameCanvas.keyMyHold[8])
					{
						if (listContent.cmtoX < listContent.cmxLim)
						{
							listContent.cmtoX += GameCanvas.hText;
						}
						else
						{
							listContent.cmtoX = listContent.cmxLim;
						}
						GameCanvas.clearKeyHold(8);
					}
				}
				else if (GameCanvas.keyMyHold[2])
				{
					if (idSelect >= numW)
					{
						idSelect -= (sbyte)numW;
					}
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					if (idSelect < maxSize - numW)
					{
						idSelect += (sbyte)numW;
					}
					GameCanvas.clearKeyHold(8);
				}
				if (GameCanvas.keyMyHold[4])
				{
					if (idSelect % numW == 0)
					{
						MainTabNew.Focus = MainTabNew.TAB;
					}
					else
					{
						idSelect--;
					}
					GameCanvas.clearKeyHold(4);
				}
				else if (GameCanvas.keyMyHold[6])
				{
					idSelect++;
					GameCanvas.clearKeyHold(6);
				}
				if (idSelect >= 0)
				{
					idSelect = (sbyte)resetSelect(idSelect, maxSize - 1, isreset: false);
				}
				else
				{
					idSelect = -1;
					vecListCmd = null;
				}
				if (num2 != idSelect)
				{
					MainTabNew.timePaintInfo = 0;
					listContent = null;
				}
			}
		}
		base.updatekey();
	}

	public override void setPaintInfo()
	{
		if (idSelect == -1 && !isList)
		{
			return;
		}
		Item item = null;
		item = ((!isList) ? ((Item)Item.VecEquipPlayer.get(string.Empty + (idSelect + indexTab))) : ((Item)vecItemMenu.elementAt(selectList)));
		if (item == null)
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		if (item.setNameNull())
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		if (item.ItemCatagory == 9)
		{
			MsgDialog.pet = (PetItem)item;
			isPet = true;
		}
		else
		{
			isPet = false;
		}
		int num = 0;
		mContent = item.mcontent;
		moreInfoconten = item.moreContenGem;
		mPlusContent = item.mPlusContent;
		mPlusColor = item.mPlusColor;
		mcolor = item.mColor;
		name = item.itemName;
		colorName = item.colorNameItem;
		if (isList)
		{
			mItemInfo = null;
			timeUpdateInfo = 0;
			isShowInfo = false;
			int num2 = mFont.tahoma_7b_white.getWidth(item.itemName) + 8;
			if (num2 < 40)
			{
				num2 = 40;
			}
			wContent = num2;
		}
		listContent = null;
		if (MainTabNew.longwidth > 0)
		{
			num = ((mContent != null) ? (num + mContent.Length) : (num + 1));
			if (mPlusContent != null)
			{
				num += mPlusContent.Length;
			}
			if (num * GameCanvas.hText > MainTabNew.hMaxContent)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - MainTabNew.hMaxContent + 4 * GameCanvas.hText);
			}
			else if (GameCanvas.isTouch)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, 4 * GameCanvas.hText);
			}
			return;
		}
		num = ((mContent != null) ? (num + mContent.Length) : (num + 1));
		if (mPlusContent != null)
		{
			num += mPlusContent.Length;
		}
		if (isList)
		{
			yCon = yList - GameCanvas.hText * 2 + MainTabNew.wOne5 / 2;
			mSubContent = null;
			mContent = null;
			mPlusContent = null;
			xCon = xList + maxList * MainTabNew.wOneItem / 2 - wContent / 2;
		}
		else
		{
			yCon = yStart + idSelect / numW * MainTabNew.wOneItem - 9 - (num + 1) * GameCanvas.hText;
			wContent = item.sizeW;
			if (idSelect % numW < 2)
			{
				xCon = xStart + MainTabNew.wOneItem / 2 + idSelect % numW * MainTabNew.wOneItem;
			}
			else if (idSelect % numW < 4)
			{
				xCon = xStart + MainTabNew.wOneItem / 2 + idSelect % numW * MainTabNew.wOneItem - 45;
			}
			else
			{
				xCon = xStart + MainTabNew.wOneItem / 2 + idSelect % numW * MainTabNew.wOneItem - 90;
			}
		}
		if (yCon + MainScreen.cameraSub.yCam < 2)
		{
			yCon = 2 - MainScreen.cameraSub.yCam;
		}
		if ((num + 1) * GameCanvas.hText > MainTabNew.hMaxContent)
		{
			listContent = new ListNew(xCon, yCon, wContent, MainTabNew.hMaxContent, 0, 0, (num + 1) * GameCanvas.hText - MainTabNew.hMaxContent);
		}
	}

	public void listItemMenu(int type)
	{
		vecItemMenu.removeAllElements();
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
			if (item.ItemCatagory == 3 && item.type_Only_Item == type && (item.classcharItem == GameScreen.player.clazz || item.classcharItem > 3))
			{
				vecItemMenu.addElement(item);
			}
		}
	}

	public override void updatePointer()
	{
		bool flag = false;
		if (isList)
		{
			if (listContent != null && GameCanvas.isPoint(listContent.x, listContent.y, listContent.maxW, listContent.maxH))
			{
				listContent.update_Pos_UP_DOWN();
				flag = true;
			}
			if (GameCanvas.isTouch && !flag)
			{
				list.updatePos_LEFT_RIGHT();
				MainScreen.cameraSub.xCam = list.cmx;
			}
			if (GameCanvas.isPointerSelect && !flag)
			{
				if (GameCanvas.isPoint(xList, yList, wsize * maxList, MainTabNew.wOneItem))
				{
					sbyte b = (sbyte)((MainScreen.cameraSub.xCam + GameCanvas.px - xList) / wsize);
					if (b >= 0 && b < vecItemMenu.size())
					{
						if (b == selectList)
						{
							cmdChangeEquip.perform();
						}
						else
						{
							selectList = b;
							MainTabNew.timePaintInfo = 0;
						}
						listContent = null;
						mSystem.outz("nullllllllllllll00000000000");
					}
					GameCanvas.isPointerSelect = false;
				}
				else if (!GameCanvas.isPoint(0, GameCanvas.h - GameCanvas.hCommand, GameCanvas.w, GameCanvas.hCommand))
				{
					cmdCloseChange.perform();
					GameCanvas.isPointerSelect = false;
				}
			}
		}
		else
		{
			if (listContent != null && GameCanvas.isPoint(listContent.x, listContent.y, listContent.maxW, listContent.maxH))
			{
				listContent.update_Pos_UP_DOWN();
				flag = true;
			}
			if (GameCanvas.isPointSelect(xStart, yStart, wsize * numW, wsize * numH) && !flag)
			{
				GameCanvas.isPointerSelect = false;
				sbyte b2 = (sbyte)((GameCanvas.px - xStart) / wsize + (GameCanvas.py - yStart) / wsize * numW);
				if (b2 >= 0 && b2 < maxSize)
				{
					if (b2 == idSelect)
					{
						cmdChange.perform();
					}
					else
					{
						idSelect = b2;
						MainTabNew.timePaintInfo = 0;
						if (idSelect >= 0)
						{
							Item item = (Item)Item.VecEquipPlayer.get(string.Empty + (idSelect + indexTab));
							if (item != null)
							{
								if (MainTabNew.longwidth > 0)
								{
									vecListCmd = doMenu(item);
									setPosCmd(vecListCmd);
								}
							}
							else if (indexTab > 0)
							{
								vecListCmd = doMenu(item);
								setPosCmd(vecListCmd);
							}
						}
					}
					listContent = null;
					mSystem.outz("nullllllllllllll00000000000");
					if (MainTabNew.Focus != MainTabNew.INFO)
					{
						MainTabNew.Focus = MainTabNew.INFO;
					}
				}
			}
		}
		if (vecListCmd != null)
		{
			for (int i = 0; i < vecListCmd.size(); i++)
			{
				((iCommand)vecListCmd.elementAt(i))?.updatePointer();
			}
		}
		base.updatePointer();
	}

	public mVector doMenu(Item item)
	{
		mVector mVector3 = new mVector("TabMySeftNew menu");
		if (indexTab <= 0)
		{
			mVector3.addElement(cmdNexTab);
		}
		else if (indexTab > 0)
		{
			mVector3.addElement(cmdReturn);
		}
		if (item != null && item.type_Only_Item == 14)
		{
			mVector3.addElement(cmdPetFeed);
		}
		return mVector3;
	}

	public void paintArenaPoint(mGraphics g)
	{
		if (!GameCanvas.isSmallScreen)
		{
			int num = 5;
			g.drawRegion(MainTabNew.img_arenaIcn, 0, 0, 10, 9, 0, xBegin + w5 * 2 + delta + 10 + num % 3 * w5 + 3, yBegin + h12 * 6 - h12 / 2 + 9 + num / 3 * h12, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isFalse);
			mFont.tahoma_7_orange.drawString(g, string.Empty + Player.PointArena, xBegin + w5 * 2 + delta + 14 + num % 3 * w5, yBegin + h12 * 6 - h12 / 2 + 3 + num / 3 * h12, 0, mGraphics.isFalse);
		}
		else
		{
			mFont.tahoma_7_orange.drawString(g, string.Empty + Player.PointArena, xBegin + 15, yBegin + h12 * 6 - h12 / 2 + 2 * GameCanvas.hText + 3 - (GameCanvas.isSmallScreen ? 16 : 0), 0, mGraphics.isFalse);
			g.drawImage(MainTabNew.img_arenaIcn, xBegin + 4, yBegin + h12 * 6 - h12 / 2 + 2 * GameCanvas.hText + 4 - (GameCanvas.isSmallScreen ? 16 : 0), 0, mGraphics.isFalse);
		}
	}
}
