public class Info_Other_Player : MainScreen
{
	public static PetItem showPet = new PetItem();

	public static MainObject showObject = new MainObject();

	public static mHashTable vecEquipShow = new mHashTable();

	private int xbegin;

	private int ybegin;

	private int wScreen;

	private int numW;

	private int numH;

	private int hitem;

	private int idSelect;

	private int xEquip;

	private int yEquip;

	private iCommand cmdClose;

	private iCommand cmdMenu;

	private iCommand cmdChat;

	private iCommand cmdAddF;

	private iCommand cmdParty;

	private iCommand cmdBuy_Sell;

	private iCommand cmdOkThachDau;

	private iCommand cmdThachDau;

	private iCommand cmdBuyFastionItem;

	private iCommand cmdback;

	private iCommand cmdnext;

	private MainTabNew maintab;

	public static sbyte VIEW = 0;

	public static sbyte THACH_DAU = 1;

	public static sbyte THACH_DAU_INFO = 100;

	private sbyte type;

	private int wsize;

	private int indexTab;

	private Item itemSelect;

	public Info_Other_Player()
	{
		maintab = new MainTabNew();
		wScreen = 180;
		wsize = MainTabNew.wOneItem;
		if (GameCanvas.isSmallScreen)
		{
			wScreen = 160;
		}
		hitem = 12;
		numW = 6;
		numH = 2;
		xbegin = GameCanvas.hw - wScreen / 2;
		ybegin = GameCanvas.hh - wScreen / 2;
		if (!GameCanvas.isTouch)
		{
			ybegin -= iCommand.hButtonCmd / 2;
		}
		xEquip = xbegin + wScreen / 2 - numW * wsize / 2;
		yEquip = ybegin + wScreen / 3 * 2;
		cmdClose = new iCommand(T.close, -1);
		cmdMenu = new iCommand(T.menu, 0);
		cmdChat = new iCommand(T.trochuyen, 0);
		cmdAddF = new iCommand(T.addFriend, 1);
		cmdParty = new iCommand(T.moiParty, 2);
		cmdBuy_Sell = new iCommand(T.buySell, 3);
		cmdThachDau = new iCommand(T.thachdau, 4);
		cmdOkThachDau = new iCommand(T.chapnhan, 1);
		if (GameCanvas.isTouch)
		{
			cmdOkThachDau.setPos(xbegin + wScreen / 2, ybegin + wScreen + iCommand.hButtonCmd / 2, null, cmdOkThachDau.caption);
			cmdClose.setPos(xbegin + wScreen - 12, ybegin + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
		cmdBuyFastionItem = new iCommand(T.buy, 0, this);
		cmdnext = new iCommand(T.trangbi2, 1, this);
		cmdback = new iCommand(T.trangbi1, 2, this);
		if (GameCanvas.isTouch)
		{
			cmdnext.setPos(xbegin + iCommand.wButtonCmd / 2, yEquip - iCommand.hButtonCmd / 2, PaintInfoGameScreen.fraButton2, cmdnext.caption);
			cmdback.setPos(xbegin + iCommand.wButtonCmd / 2, yEquip - iCommand.hButtonCmd / 2, PaintInfoGameScreen.fraButton2, cmdback.caption);
		}
		if (!GameCanvas.isTouch)
		{
			center = cmdnext;
		}
	}

	public override void Show(MainScreen screen)
	{
		base.Show(screen);
		if (!GameCanvas.isTouch)
		{
			idSelect = 0;
			itemSelect = (Item)vecEquipShow.get(string.Empty + (idSelect + indexTab));
		}
		else
		{
			idSelect = -1;
		}
		maintab.listContent = null;
		itemSelect = null;
	}

	public override void commandPointer(int index, int subIndex)
	{
		Item item = (Item)vecEquipShow.get(string.Empty + idSelect);
		switch (index)
		{
		case 0:
			if (item != null)
			{
				GlobalService.gI().do_Buy_Sell_Item(5, null, string.Empty, (short)showObject.ID, item.Id, 0);
			}
			break;
		case 1:
			indexTab = 12;
			if (!GameCanvas.isTouch)
			{
				center = cmdback;
			}
			break;
		case 2:
			indexTab = 0;
			if (!GameCanvas.isTouch)
			{
				center = cmdnext;
			}
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public override void commandTab(int index, int sub)
	{
		switch (index)
		{
		case -1:
			if (lastScreen.lastScreen != null)
			{
				lastScreen.Show(lastScreen.lastScreen);
			}
			else
			{
				lastScreen.Show();
			}
			break;
		case 0:
			doMenu();
			break;
		case 1:
			GlobalService.gI().Thach_Dau(1, showObject.name);
			break;
		}
		base.commandTab(index, sub);
	}

	public override void commandMenu(int index, int sub)
	{
		switch (index)
		{
		case 1:
			GlobalService.gI().Friend(0, showObject.name);
			break;
		case 0:
			GameCanvas.msgchat.addNewChat(showObject.name, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, isFocus: true);
			GameCanvas.start_Chat_Dialog();
			break;
		case 2:
			GlobalService.gI().Party(1, showObject.name);
			break;
		case 3:
			GlobalService.gI().Buy_Sell(0, showObject.name, 0, 0, 0);
			break;
		case 4:
			GlobalService.gI().Thach_Dau(0, showObject.name);
			break;
		}
		base.commandMenu(index, sub);
	}

	public void init(sbyte type)
	{
		center = null;
		this.type = type;
		if (type == THACH_DAU)
		{
			if (!GameCanvas.isTouch)
			{
				right = cmdClose;
				center = cmdOkThachDau;
				left = cmdMenu;
			}
			else
			{
				center = cmdOkThachDau;
				right = cmdClose;
			}
		}
		else
		{
			this.type = VIEW;
			if (!GameCanvas.isTouch)
			{
				right = cmdClose;
				left = cmdMenu;
			}
			else
			{
				right = cmdClose;
			}
		}
	}

	private void doMenu()
	{
		mVector mVector3 = new mVector("Info_Other_Player menu");
		mVector3.addElement(cmdChat);
		mVector3.addElement(cmdAddF);
		if (Player.party == null || Player.party.vecPartys.size() < 5)
		{
			mVector3.addElement(cmdParty);
		}
		mVector3.addElement(cmdBuy_Sell);
		if (type == VIEW && LoadMap.typeMap != LoadMap.MAP_THACH_DAU)
		{
			mVector3.addElement(cmdThachDau);
		}
		GameCanvas.menu2.startAt(mVector3, 2, T.giaotiep, isFocus: false, null);
	}

	public override void paint(mGraphics g)
	{
		lastScreen.paint(g);
		if (GameCanvas.currentScreen != this)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		int num = ybegin;
		int num2 = xbegin;
		paintFormList(g, num2, num, wScreen, wScreen, showObject.name);
		num2 += 10;
		num += GameCanvas.hCommand + 2;
		if (showObject.myClan != null)
		{
			showObject.paintIconClan(g, num2 - 10 + wScreen / 2, num + 7, -2);
			num += hitem;
		}
		mFont.tahoma_7_white.drawString(g, T.level + showObject.Lv, num2, num, 0, mGraphics.isFalse);
		num += hitem;
		mFont.tahoma_7_white.drawString(g, "HP: " + showObject.hp + "/" + showObject.maxHp, num2, num, 0, mGraphics.isFalse);
		num += hitem;
		if (showPet != null)
		{
			showPet.paintShowPet(g, xbegin + wScreen / 2 + 30, ybegin + 90 - MainTabNew.wOneItem / 2 + 5, MainTabNew.wOneItem, MainTabNew.wOneItem / 2, 0, 0);
		}
		showObject.paintShowPlayer(g, xbegin + wScreen / 2, ybegin + 90, 0);
		for (sbyte b = 0; b < TabMySeftNew.maxSize; b++)
		{
			int num3 = xEquip + b % numW * wsize;
			int num4 = yEquip + b / numW * wsize;
			Item item = (Item)vecEquipShow.get(string.Empty + (b + indexTab));
			if (item != null)
			{
				if (item.Id > -1)
				{
					item.paintItem(g, num3 + MainTabNew.wOneItem / 2, num4 + MainTabNew.wOneItem / 2, MainTabNew.wOneItem, 0, 0);
				}
				else if (indexTab < 12)
				{
					g.drawRegion(MainTabNew.imgTab[6], 0, b * 20, 20, 20, 0, num3 + MainTabNew.wOneItem / 2, num4 + MainTabNew.wOneItem / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			else if (indexTab < 12)
			{
				g.drawRegion(MainTabNew.imgTab[6], 0, b * 20, 20, 20, 0, num3 + MainTabNew.wOneItem / 2, num4 + MainTabNew.wOneItem / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			}
			if (GameCanvas.isTouch)
			{
				if (indexTab < 12)
				{
					cmdnext.paint(g, xbegin + iCommand.wButtonCmd / 2, yEquip - iCommand.hButtonCmd / 2);
				}
				else
				{
					cmdback.paint(g, xbegin + iCommand.wButtonCmd / 2, yEquip - iCommand.hButtonCmd / 2);
				}
			}
			g.setColor(MainTabNew.color[4]);
			g.drawRect(num3, num4, wsize, wsize, mGraphics.isFalse);
		}
		g.setColor(MainTabNew.color[3]);
		if (idSelect >= 0)
		{
			int num5 = xEquip + idSelect % numW * wsize;
			int num6 = yEquip + idSelect / numW * wsize;
			g.drawRect(num5, num6, wsize, wsize, mGraphics.isFalse);
			g.setColor(MainTabNew.color[2]);
			g.drawRect(num5 + 1, num6 + 1, wsize - 2, wsize - 2, mGraphics.isFalse);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			maintab.paintContent(g, isOnlyName: false);
		}
		base.paint(g);
	}

	public override void update()
	{
		if (GameCanvas.isTouch)
		{
			if (indexTab < 12)
			{
				cmdnext.updatePointer();
			}
			else
			{
				cmdback.updatePointer();
			}
		}
		if (showObject == null)
		{
			cmdClose.perform();
		}
		lastScreen.update();
		if (maintab.listContent != null)
		{
			maintab.listContent.moveCamera();
		}
		if (itemSelect != null)
		{
			updateContent(itemSelect);
		}
		if (maintab != null)
		{
			maintab.update();
		}
	}

	public void updateContent(Item item)
	{
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				setPaintInfo(item);
			}
		}
		if (maintab.mContent != null || item == null || item.ItemCatagory == 5)
		{
			return;
		}
		if (item.mcontent == null)
		{
			if (item.timeupdateMore % 100 == 3)
			{
				if (maintab.typeTab == MainTabNew.INVENTORY)
				{
					GlobalService.gI().Item_More_Info(0, (sbyte)item.Id);
				}
				item.timeupdateMore++;
			}
			else
			{
				item.timeupdateMore++;
			}
		}
		else
		{
			maintab.moreInfoconten = item.moreContenGem;
			maintab.mContent = item.mcontent;
			maintab.mcolor = item.mColor;
			setYCon(item);
		}
	}

	public override void updatekey()
	{
		int num = idSelect;
		if (maintab.listContent != null)
		{
			if (GameCanvas.keyMyHold[2])
			{
				if (maintab.listContent.cmtoX > 0)
				{
					maintab.listContent.cmtoX -= GameCanvas.hText;
				}
				else
				{
					maintab.listContent.cmtoX = 0;
				}
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				if (maintab.listContent.cmtoX < maintab.listContent.cmxLim)
				{
					maintab.listContent.cmtoX += GameCanvas.hText;
				}
				else
				{
					maintab.listContent.cmtoX = maintab.listContent.cmxLim;
				}
				GameCanvas.clearKeyHold(8);
			}
		}
		else if (GameCanvas.keyMyHold[2])
		{
			if (idSelect >= numW)
			{
				idSelect -= numW;
			}
			GameCanvas.clearKeyHold(2);
		}
		else if (GameCanvas.keyMyHold[8])
		{
			if (idSelect < TabMySeftNew.maxSize - numW)
			{
				idSelect += numW;
			}
			GameCanvas.clearKeyHold(8);
		}
		if (GameCanvas.keyMyHold[4])
		{
			idSelect--;
			GameCanvas.clearKeyHold(4);
		}
		else if (GameCanvas.keyMyHold[6])
		{
			idSelect++;
			GameCanvas.clearKeyHold(6);
		}
		if (num != idSelect)
		{
			if (idSelect >= 0)
			{
				idSelect = (sbyte)resetSelect(idSelect, TabMySeftNew.maxSize - 1, isreset: false);
				MainTabNew.timePaintInfo = 0;
				itemSelect = (Item)vecEquipShow.get(string.Empty + (idSelect + indexTab));
			}
			else
			{
				idSelect = -1;
			}
			maintab.listContent = null;
		}
		base.updatekey();
	}

	public void setPaintInfo(Item item)
	{
		if (idSelect < 0)
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		maintab.mContent = null;
		maintab.mSubContent = null;
		maintab.mPlusContent = null;
		int num = idSelect;
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
		maintab.wContent = item.sizeW;
		maintab.xCon = xEquip + num % numW * wsize + MainTabNew.wOneItem / 2 - maintab.wContent / 2;
		if (maintab.xCon < 0)
		{
			maintab.xCon = 0;
		}
		if (maintab.xCon + maintab.wContent > GameCanvas.w)
		{
			maintab.xCon = GameCanvas.w - maintab.wContent;
		}
		setYCon(item);
		maintab.name = item.itemName;
		maintab.mPlusContent = item.mPlusContent;
		maintab.mPlusColor = item.mPlusColor;
		maintab.colorName = item.colorNameItem;
		maintab.moreInfoconten = item.moreContenGem;
	}

	public void setYCon(Item item)
	{
		int num = 2;
		maintab.mContent = item.mcontent;
		maintab.moreInfoconten = item.moreContenGem;
		maintab.mcolor = item.mColor;
		if (item.mcontent != null)
		{
			num += item.mcontent.Length;
		}
		if (item.mPlusContent != null)
		{
			num += item.mPlusContent.Length;
		}
		int num2 = idSelect;
		maintab.yCon = yEquip + (num2 / numW + 1) * wsize;
		if (GameCanvas.isTouch)
		{
			if (maintab.yCon + num * GameCanvas.hText > GameCanvas.h)
			{
				maintab.yCon = GameCanvas.h - num * GameCanvas.hText;
			}
		}
		else if (maintab.yCon + num * GameCanvas.hText > GameCanvas.h - iCommand.hButtonCmd)
		{
			maintab.yCon = GameCanvas.h - iCommand.hButtonCmd - num * GameCanvas.hText;
		}
		if (type == THACH_DAU && GameCanvas.isTouch && maintab.yCon + num * GameCanvas.hText > ybegin + wScreen)
		{
			maintab.yCon = ybegin + wScreen - num * GameCanvas.hText;
		}
		maintab.listContent = null;
		if ((num + 1) * GameCanvas.hText > MainTabNew.hMaxContent)
		{
			maintab.listContent = new ListNew(maintab.xCon, maintab.yCon, maintab.wContent, MainTabNew.hMaxContent, 0, 0, (num + 1) * GameCanvas.hText - MainTabNew.hMaxContent);
		}
		if (item.can_sell_for_other_player == 1)
		{
			maintab.wContent += iCommand.wButtonCmd / 2;
			maintab.cmd = cmdBuyFastionItem;
		}
		else
		{
			maintab.cmd = null;
			maintab.xpos_cmd = 0;
			maintab.ypos_cmd = 0;
		}
	}

	public override void updatePointer()
	{
		bool flag = false;
		if (maintab.listContent != null && GameCanvas.isPoint(maintab.listContent.x, maintab.listContent.y, maintab.listContent.maxW, maintab.listContent.maxH))
		{
			maintab.listContent.update_Pos_UP_DOWN();
		}
		if (!flag)
		{
			if (GameCanvas.isPointSelect(xEquip, yEquip, wsize * numW, wsize * numH))
			{
				GameCanvas.isPointerSelect = false;
				sbyte b = (sbyte)((GameCanvas.px - xEquip) / wsize + (GameCanvas.py - yEquip) / wsize * numW);
				if (b >= 0 && b < TabMySeftNew.maxSize && b != idSelect)
				{
					idSelect = b;
					MainTabNew.timePaintInfo = 0;
					itemSelect = (Item)vecEquipShow.get(string.Empty + (idSelect + indexTab));
					maintab.listContent = null;
				}
			}
			if (GameCanvas.isPointerSelect && GameCanvas.isPoint(xbegin + wScreen / 2 - 25, ybegin + 90 - 60, 50, 70))
			{
				cmdMenu.perform();
				GameCanvas.isPointerSelect = false;
			}
		}
		base.updatePointer();
	}
}
