public class TabQuest : MainTabNew
{
	private int idSelect;

	private int maxSize;

	private int hmax;

	private Scroll scr = new Scroll();

	public static TabQuest me;

	private int xdich;

	private int wMainTab;

	private int xselect;

	private int HQuest;

	private int tabSelect;

	private iCommand cmdView;

	private iCommand cmdRead;

	private new iCommand cmdBack;

	private iCommand cmdCancle;

	private int xMap;

	private int yMap;

	public static string[] nameItemQuest;

	private mVector vecListCmd = new mVector("TabQuest vecListCmd");

	private MainQuest questCurrent;

	private bool isTran;

	private int yCambegin;

	public TabQuest(string name)
	{
		typeTab = MainTabNew.QUEST;
		me = this;
		nameTab = string.Empty;
		HQuest = GameCanvas.hText;
		if (GameCanvas.isTouch)
		{
			HQuest = GameCanvas.hCommand;
		}
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
		init();
		cmdView = new iCommand(T.view, 0, this);
		cmdRead = new iCommand(T.read, 1, this);
		cmdBack = new iCommand(T.back, -1, this);
		cmdCancle = new iCommand(T.cancel, 2, this);
		int num = MainTabNew.ylongwidth + hSmall;
		int num2 = MainTabNew.xlongwidth;
		cmdCancle.setPos(num2 + MainTabNew.longwidth / 2, num - 15, null, cmdCancle.caption);
		if (MainTabNew.is320)
		{
			cmdCancle.setPos(cmdCancle.xCmd, num - 10, PaintInfoGameScreen.fraButton2, cmdCancle.caption);
		}
		if (GameCanvas.isTouch)
		{
			cmdBack.caption = T.close;
		}
	}

	public override void init()
	{
		resetTab(true);
		xdich = (MainTabNew.wblack - wMainTab * 2) / 2;
		if (!GameCanvas.isTouch)
		{
			right = cmdBack;
		}
		name = null;
		mContent = null;
		mPlusContent = null;
		questCurrent = null;
		listContent = null;
		base.init();
	}

	public override void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		idSelect = 0;
		base.backTab();
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			MapScr.gI().Show();
			break;
		case 1:
		{
			MainQuest mainQuest = QuestSelect();
			if (mainQuest != null)
			{
				GameCanvas.start_Quest_DialogRead(mainQuest);
			}
			break;
		}
		case -1:
			backTab();
			break;
		case 2:
			if (questCurrent == null)
			{
				return;
			}
			GameCanvas.start_Left_Dialog(T.hoihuyQuest + questCurrent.name, new iCommand(T.cancel, 3, this));
			break;
		case 3:
			if (questCurrent == null)
			{
				return;
			}
			GlobalService.gI().quest((short)questCurrent.ID, (!questCurrent.isMain) ? ((sbyte)1) : ((sbyte)0), 2);
			resetTab(true);
			GameCanvas.end_Dialog();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public MainQuest QuestSelect()
	{
		MainQuest mainQuest = null;
		int num = MainQuest.vecQuestDoing_Main.size();
		if (idSelect < 0 || idSelect >= num + MainQuest.vecQuestDoing_Sub.size())
		{
			return null;
		}
		if (idSelect < num)
		{
			mainQuest = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(idSelect);
			mainQuest.strShowDialog = mainQuest.strShortDetail;
			if (mainQuest.typeQuest == 0 || mainQuest.typeQuest == 1)
			{
				MainQuest mainQuest2 = mainQuest;
				mainQuest2.strShowDialog = mainQuest2.strShowDialog + "\n " + T.mucdohoanthanh;
				for (int i = 0; i < mainQuest.mIdQuest.Length; i++)
				{
					string text = string.Empty;
					if (mainQuest.typeQuest == 1)
					{
						CatalogyMonster catalogyMonster = MainMonster.getCatalogyMonster(mainQuest.mIdQuest[i]);
						if (catalogyMonster != null)
						{
							text = catalogyMonster.name;
						}
					}
					else if (nameItemQuest != null)
					{
						text = nameItemQuest[mainQuest.mIdQuest[i]];
					}
					MainQuest mainQuest3 = mainQuest;
					string strShowDialog = mainQuest3.strShowDialog;
					mainQuest3.strShowDialog = strShowDialog + "\n " + text + ((!text.Equals(string.Empty)) ? ": " : string.Empty) + mainQuest.mQuestGot[i] + "/" + mainQuest.mtotalQuest[i];
				}
			}
		}
		else
		{
			mainQuest = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(idSelect - num);
			mainQuest.strShowDialog = mainQuest.strShortDetail;
			if (mainQuest.typeQuest == 0 || mainQuest.typeQuest == 1)
			{
				MainQuest mainQuest4 = mainQuest;
				mainQuest4.strShowDialog = mainQuest4.strShowDialog + "\n " + T.mucdohoanthanh;
				for (int j = 0; j < mainQuest.mIdQuest.Length; j++)
				{
					string empty = string.Empty;
					if (mainQuest.typeQuest == 1)
					{
						empty = string.Empty;
						if (MainMonster.getCatalogyMonster(mainQuest.mIdQuest[j]) != null)
						{
							CatalogyMonster catalogyMonster2 = MainMonster.getCatalogyMonster(mainQuest.mIdQuest[j]);
							if (catalogyMonster2 != null)
							{
								empty = catalogyMonster2.name;
							}
						}
					}
					else
					{
						empty = nameItemQuest[mainQuest.mIdQuest[j]];
					}
					MainQuest mainQuest5 = mainQuest;
					string strShowDialog = mainQuest5.strShowDialog;
					mainQuest5.strShowDialog = strShowDialog + "\n " + empty + ((!empty.Equals(string.Empty)) ? ": " : string.Empty) + mainQuest.mQuestGot[j] + "/" + mainQuest.mtotalQuest[j];
				}
			}
		}
		return mainQuest;
	}

	public void setPaint()
	{
		if (MainTabNew.longwidth == 0)
		{
			return;
		}
		vecListCmd.removeAllElements();
		questCurrent = QuestSelect();
		if (questCurrent != null)
		{
			name = questCurrent.name;
			mContent = mFont.tahoma_7_white.splitFontArray(questCurrent.strShowDialog, MainTabNew.longwidth - 8);
			int num = questCurrent.strShowDialog.Length * GameCanvas.hText - (MainTabNew.hMaxContent - iCommand.hButtonCmd * 2);
			if (num < 0)
			{
				num = 0;
			}
			listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num);
			if (GameCanvas.isTouch)
			{
				vecListCmd.addElement(cmdCancle);
			}
			mPlusContent = null;
		}
		else
		{
			name = null;
			mContent = null;
			mPlusContent = null;
			questCurrent = null;
		}
	}

	public override void paint(mGraphics g)
	{
		int num = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3 + xdich;
		int num2 = yTab + GameCanvas.h / 5 + MainTabNew.wOne5;
		if (tabSelect == 0)
		{
			paintTabBig(g, num + wMainTab, num2 - 1, wMainTab);
			mFont.tahoma_7_white.drawString(g, T.mQuest[1], num + wMainTab + wMainTab / 2, num2 + MainTabNew.wOneItem / 2 - 7, 2, mGraphics.isFalse);
		}
		else
		{
			paintTabBig(g, num, num2 - 1, wMainTab);
			mFont.tahoma_7_white.drawString(g, T.mQuest[0], num + wMainTab / 2, num2 + MainTabNew.wOneItem / 2 - 7, 2, mGraphics.isFalse);
			num += wMainTab;
		}
		xselect = num;
		paintTabFocus(g, xselect, num2 - 1, wMainTab);
		mFont mFont2 = mFont.tahoma_7b_white;
		if (MainTabNew.Focus == MainTabNew.TAB)
		{
			mFont2 = mFont.tahoma_7_white;
		}
		mFont2.drawString(g, T.mQuest[tabSelect], xselect + wMainTab / 2, num2 + MainTabNew.wOneItem / 2 - 7, 2, mGraphics.isFalse);
		g.setClip(xBegin, yBegin, MainTabNew.wblack, MainTabNew.hblack);
		g.translate(0, -MainScreen.cameraSub.yCam);
		num2 = yBegin + 4;
		num = xBegin + 4;
		int num3 = 0;
		if (maxSize == 0)
		{
			paintRong(g, num + MainTabNew.wblack / 2 - 4, num2 + MainTabNew.wOne5);
			num2 += HQuest;
		}
		else if (tabSelect == 1)
		{
			for (int i = 0; i < MainQuest.vecQuestFinish.size(); i++)
			{
				if (MainTabNew.Focus == MainTabNew.INFO && idSelect == i)
				{
					g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num - GameCanvas.gameTick % 3, num2, 0, mGraphics.isTrue);
				}
				MainQuest mainQuest = (MainQuest)MainQuest.vecQuestFinish.elementAt(i);
				mFont.tahoma_7b_white.drawString(g, mainQuest.name, num + 18, num2, 0, mGraphics.isTrue);
				if (MainTabNew.Focus == MainTabNew.INFO && idSelect == i)
				{
					for (int j = 0; j < mainQuest.mstrHelp.Length; j++)
					{
						num2 += GameCanvas.hText;
						mFont.tahoma_7_white.drawString(g, mainQuest.mstrHelp[j], num + 25, num2, 0, mGraphics.isTrue);
					}
				}
				num2 += HQuest;
				num3++;
			}
		}
		else
		{
			if (MainQuest.vecQuestDoing_Main.size() > 0)
			{
				AvMain.Font3dWhite(g, T.mainQuest, num, num2, 0);
				num2 += HQuest;
				for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
				{
					if (MainTabNew.Focus == MainTabNew.INFO && idSelect == num3)
					{
						g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num - GameCanvas.gameTick % 3, num2, 0, mGraphics.isFalse);
					}
					MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
					mFont.tahoma_7b_white.drawString(g, mainQuest2.name, num + 18, num2, 0, mGraphics.isFalse);
					num2 += HQuest;
					num3++;
				}
			}
			if (MainQuest.vecQuestDoing_Sub.size() > 0)
			{
				AvMain.Font3dWhite(g, T.subQuest, num, num2, 0);
				num2 += HQuest;
				for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
				{
					MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
					if (MainTabNew.Focus == MainTabNew.INFO && idSelect == num3)
					{
						g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num - GameCanvas.gameTick % 3, num2, 0, mGraphics.isFalse);
					}
					mFont.tahoma_7b_white.drawString(g, mainQuest3.name, num + 18, num2, 0, mGraphics.isFalse);
					num2 += HQuest;
					num3++;
				}
			}
		}
		num2 += HQuest / 2;
		if (MainTabNew.Focus == MainTabNew.INFO && idSelect == num3)
		{
			g.setColor(MainTabNew.color[3]);
			g.fillRect(xBegin + MainTabNew.wblack / 2 - 49, num2 - 1, 98, 18, mGraphics.isFalse);
		}
		xMap = xBegin + MainTabNew.wblack / 2 - 48;
		yMap = num2;
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, xMap, yMap, 96, 16, 4);
		}
		else
		{
			for (int m = 0; m < 4; m++)
			{
				g.drawRegion(MainTabNew.imgTab[8], 0, 0, 24, 16, 0, xMap + 24 * m, yMap, 0, mGraphics.isFalse);
			}
		}
		mFont.tahoma_7_white.drawString(g, T.viewMap, xBegin + MainTabNew.wblack / 2, num2 + 2, 2, mGraphics.isFalse);
		if (MainTabNew.longwidth <= 0 || MainTabNew.Focus != MainTabNew.INFO || name == null)
		{
			return;
		}
		paintInfoQuest(g);
		if (vecListCmd != null)
		{
			for (int n = 0; n < vecListCmd.size(); n++)
			{
				iCommand iCommand2 = (iCommand)vecListCmd.elementAt(n);
				iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
			}
		}
	}

	public void paintInfoQuest(mGraphics g)
	{
		int num = 4;
		TabScreenNew.timeRepaint = 10;
		GameCanvas.resetTrans(g);
		int num2 = MainTabNew.xlongwidth;
		int num3 = MainTabNew.ylongwidth;
		int num4 = num3;
		g.setClip(num2 + 1, num4 + 1, MainTabNew.longwidth - 2, hSmall - 2);
		MainTabNew.paintNameItem(g, num2 + MainTabNew.longwidth / 2, num4 + MainTabNew.wOneItem / 2 - 5, MainTabNew.longwidth, name, colorName);
		num4 += MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
		GameCanvas.resetTrans(g);
		scr.setStyle(mContent.Length + 2, GameCanvas.hText + 2, num2, num4 + MainTabNew.wOneItem + 2 - GameCanvas.hText * 2, MainTabNew.longwidth, MainTabNew.hMaxContent + GameCanvas.hText, true, 1);
		scr.setClip(g, num2, num4 + MainTabNew.wOneItem + 2 - GameCanvas.hText, MainTabNew.longwidth, MainTabNew.hMaxContent - MainTabNew.wOneItem - 2 - iCommand.hButtonCmd / 2);
		if (mContent != null)
		{
			for (int i = 0; i < mContent.Length; i++)
			{
				if (mContent[i] != null)
				{
					mFont mFont2 = null;
					mFont2 = ((mcolor == null) ? mFont.tahoma_7_white : MainTabNew.setTextColor(mcolor[i]));
					mFont2.drawString(g, mContent[i], num2 + num, num4 + 2 + (i + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
					if (mSubContent != null)
					{
						int num5 = mFont2.getWidth(mContent[i]) + 5;
						mFont2 = MainTabNew.setTextColor(mSubColor[i]);
						mFont2.drawString(g, mSubContent[i], num2 + num5 + num, num4 + 2 + (i + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
					}
				}
			}
		}
		g.endClip();
		GameCanvas.resetTrans(g);
	}

	public void paintTabFocus(mGraphics g, int x, int y, int wMainTab)
	{
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, x, y, wMainTab, 32, 2);
			return;
		}
		for (int i = 0; i <= wMainTab / 32; i++)
		{
			if (i == 0)
			{
				g.drawImage(MainTabNew.imgTab[9], x, y, 0, mGraphics.isFalse);
			}
			else if (i == wMainTab / 32)
			{
				g.drawRegion(MainTabNew.imgTab[9], 0, 0, 32, 32, 2, x + wMainTab - 32, y, 0, mGraphics.isFalse);
			}
			else
			{
				g.drawImage(MainTabNew.imgTab[2], x + i * 32, y, 0, mGraphics.isFalse);
			}
		}
	}

	public void paintTabBig(mGraphics g, int x, int y, int wMainTab)
	{
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, x, y, wMainTab, MainTabNew.wOneItem - MainTabNew.wOne5 + 1, 3);
			return;
		}
		for (int i = 0; i <= wMainTab / 32; i++)
		{
			if (i == 0)
			{
				g.drawRegion(MainTabNew.imgTab[11], 0, 0, 32, MainTabNew.wOneItem - MainTabNew.wOne5 + 1, 0, x, y, 0, mGraphics.isFalse);
			}
			else if (i == wMainTab / 32)
			{
				g.drawRegion(MainTabNew.imgTab[11], 0, 0, 32, MainTabNew.wOneItem - MainTabNew.wOne5 + 1, 2, x + wMainTab - 32, y, 0, mGraphics.isFalse);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[10], 0, 0, 32, MainTabNew.wOneItem - MainTabNew.wOne5 + 1, 0, x + i * 32, y, 0, mGraphics.isFalse);
			}
		}
	}

	public override void update()
	{
		ScrollResult scrollResult = scr.updateKey();
		if (scrollResult.isDowning || scrollResult.isFinish)
		{
		}
		if (scrollResult.isFinish || GameCanvas.isKeyPressed(5))
		{
		}
		scr.updatecm();
		MainScreen.cameraSub.UpdateCamera();
		base.update();
	}

	public override void updatekey()
	{
		if (MainTabNew.Focus == MainTabNew.INFO)
		{
			int num = idSelect;
			if (GameCanvas.keyMyHold[2])
			{
				idSelect--;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				idSelect++;
				GameCanvas.clearKeyHold(8);
			}
			if (GameCanvas.keyMyHold[4])
			{
				if (tabSelect == 0)
				{
					MainTabNew.Focus = MainTabNew.TAB;
					idSelect = 0;
				}
				else
				{
					tabSelect = 0;
					resetTab(true);
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				if (tabSelect == 1)
				{
					tabSelect = 0;
					resetTab(true);
				}
				else
				{
					tabSelect = 1;
					resetTab(true);
				}
				GameCanvas.clearKeyHold(6);
			}
			if (maxSize > 0)
			{
				idSelect = resetSelect(idSelect, maxSize, true);
			}
			else
			{
				idSelect = 0;
			}
			setPaint();
			if (tabSelect == 1)
			{
				if (!GameCanvas.isTouch)
				{
					if (idSelect < maxSize)
					{
						if (center != null)
						{
							center = null;
						}
					}
					else if (center != cmdView)
					{
						center = cmdView;
						TabScreenNew.timeRepaint = 10;
					}
					if (left != null)
					{
						left = null;
					}
				}
				if (num != idSelect)
				{
					resetTab(false);
					if (idSelect == maxSize)
					{
						MainScreen.cameraSub.moveCamera(0, MainScreen.cameraSub.yLimit);
					}
					else
					{
						MainQuest mainQuest = (MainQuest)MainQuest.vecQuestFinish.elementAt(idSelect);
						MainScreen.cameraSub.moveCamera(0, idSelect * HQuest + mainQuest.mstrHelp.Length * GameCanvas.hText - MainTabNew.hblack / 2);
					}
				}
			}
			else if (idSelect < maxSize)
			{
				if (!GameCanvas.isTouch)
				{
					if (center != cmdRead)
					{
						center = cmdRead;
						TabScreenNew.timeRepaint = 10;
					}
					if (num != idSelect)
					{
						MainScreen.cameraSub.moveCamera(0, (idSelect + 2) * HQuest - MainTabNew.hblack / 2);
					}
				}
			}
			else if (center != cmdView && !GameCanvas.isTouch)
			{
				center = cmdView;
				TabScreenNew.timeRepaint = 10;
				if (num != idSelect)
				{
					MainScreen.cameraSub.moveCamera(0, MainScreen.cameraSub.yLimit);
				}
				if (left != null)
				{
					left = null;
				}
			}
		}
		base.updatekey();
	}

	public void resetTab(bool isResetCmy)
	{
		TabScreenNew.timeRepaint = 10;
		int num = 0;
		if (tabSelect == 0)
		{
			maxSize = MainQuest.vecQuestDoing_Main.size() + MainQuest.vecQuestDoing_Sub.size();
			num = maxSize + ((MainQuest.vecQuestDoing_Main.size() > 0) ? 1 : 0) + ((MainQuest.vecQuestDoing_Sub.size() > 0) ? 1 : 0) + 2;
		}
		else
		{
			maxSize = MainQuest.vecQuestFinish.size();
			if (idSelect < maxSize)
			{
				MainQuest mainQuest = (MainQuest)MainQuest.vecQuestFinish.elementAt(idSelect);
				num = maxSize + 2 + mainQuest.mstrHelp.Length;
			}
			else
			{
				num = maxSize + 2;
			}
		}
		hmax = num * HQuest - MainTabNew.hblack + 5;
		if (hmax < 0)
		{
			hmax = 0;
		}
		wMainTab = MainTabNew.wOneItem * 3;
		if (isResetCmy)
		{
			MainScreen.cameraSub.setAll(0, hmax, 0, 0);
		}
		else
		{
			MainScreen.cameraSub.yLimit = hmax;
		}
	}

	private void paintRong(mGraphics g, int xp, int yp)
	{
		mFont.tahoma_7_white.drawString(g, T.khongconhiemvu, xp, yp, 2, mGraphics.isFalse);
	}

	public override void updatePointer()
	{
		if (GameCanvas.isPointerSelect)
		{
			int num = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3 + xdich;
			int y = yTab + GameCanvas.h / 5 + MainTabNew.wOne5;
			if (GameCanvas.isPoint(num, y, wMainTab, MainTabNew.wOneItem - MainTabNew.wOne5 + 1))
			{
				if (tabSelect != 0)
				{
					tabSelect = 0;
					resetTab(true);
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPoint(num + wMainTab, y, wMainTab, MainTabNew.wOneItem - MainTabNew.wOne5 + 1))
			{
				if (tabSelect != 1)
				{
					tabSelect = 1;
					resetTab(true);
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		if (GameCanvas.isPointerSelect && GameCanvas.isPoint(xMap, yMap - MainScreen.cameraSub.yCam - 4, 96, 24))
		{
			GameCanvas.isPointerSelect = false;
			cmdView.perform();
		}
		if (maxSize > 0)
		{
			if (GameCanvas.isPointSelect(xBegin, yBegin, MainTabNew.wblack, MainTabNew.hblack))
			{
				if (tabSelect == 0)
				{
					int num2 = yBegin + 4 + HQuest;
					int num3 = (GameCanvas.py - num2 + MainScreen.cameraSub.yCam) / HQuest;
					if (MainQuest.vecQuestDoing_Main.size() > 0 && MainQuest.vecQuestDoing_Sub.size() > 0)
					{
						if (num3 == MainQuest.vecQuestDoing_Main.size())
						{
							num3 = -1;
						}
						else if (num3 > MainQuest.vecQuestDoing_Main.size())
						{
							num3--;
						}
					}
					if (num3 > -1 && num3 <= maxSize)
					{
						if (num3 == idSelect)
						{
							if (MainTabNew.longwidth == 0 && idSelect < maxSize)
							{
								cmdRead.perform();
							}
						}
						else
						{
							idSelect = num3;
							idSelect = resetSelect(idSelect, maxSize, false);
						}
						GameCanvas.isPointerSelect = false;
					}
					setPaint();
				}
				else
				{
					int num4 = (GameCanvas.py - yBegin + MainScreen.cameraSub.yCam) / HQuest;
					if (num4 < idSelect)
					{
						idSelect = num4;
					}
					else if (idSelect < maxSize)
					{
						MainQuest mainQuest = (MainQuest)MainQuest.vecQuestFinish.elementAt(idSelect);
						int num5 = yBegin + idSelect * HQuest + mainQuest.mstrHelp.Length * GameCanvas.hText;
						if (num5 < GameCanvas.py + MainScreen.cameraSub.yCam)
						{
							num4 = (GameCanvas.py + MainScreen.cameraSub.yCam - num5) / HQuest + idSelect;
							idSelect = num4;
							idSelect = resetSelect(idSelect, maxSize, false);
							GameCanvas.isPointerSelect = false;
						}
					}
					setPaint();
				}
			}
			if (GameCanvas.isPointerMove)
			{
				if (hmax > 0 && GameCanvas.pxLast > xBegin && GameCanvas.pxLast < xBegin + MainTabNew.wblack && GameCanvas.pyLast > yBegin && GameCanvas.pyLast < yBegin + MainTabNew.hblack)
				{
					if (!isTran)
					{
						isTran = true;
						yCambegin = MainScreen.cameraSub.yCam;
					}
					else
					{
						MainScreen.cameraSub.yTo = yCambegin + GameCanvas.pyLast - GameCanvas.py;
						if (MainScreen.cameraSub.yTo > MainScreen.cameraSub.yLimit)
						{
							MainScreen.cameraSub.yTo = MainScreen.cameraSub.yLimit;
						}
						if (MainScreen.cameraSub.yTo < 0)
						{
							MainScreen.cameraSub.yTo = 0;
						}
						TabScreenNew.timeRepaint = 10;
					}
				}
			}
			else
			{
				isTran = false;
				yCambegin = 0;
			}
			if (vecListCmd != null && MainTabNew.Focus == MainTabNew.INFO && name != null)
			{
				for (int i = 0; i < vecListCmd.size(); i++)
				{
					iCommand iCommand2 = (iCommand)vecListCmd.elementAt(i);
					iCommand2.updatePointer();
				}
			}
		}
		base.updatePointer();
	}
}
