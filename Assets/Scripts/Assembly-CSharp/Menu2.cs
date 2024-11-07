public class Menu2 : AvMain
{
	public const sbyte NORMAL = 0;

	public const sbyte NPC_MENU = 1;

	public const sbyte QUICK_MENU = 2;

	public bool isShowMenu;

	public mVector menuItems;

	public int menuSelectedItem;

	public int SelectFocus;

	public int menuX;

	public int menuY;

	public int menuW;

	public int menuH;

	public int menuTemY;

	public int hPlus;

	public static int cmtoX;

	public static int cmx;

	public static int cmdy;

	public static int cmvy;

	public static int cmxLim;

	public static int xc;

	private int pos;

	private int sizeMenu;

	private string nameMenu = string.Empty;

	private string[] mStrTalk;

	public RunWord runText;

	public static bool isHelp;

	public static bool isGiaotiep;

	public static bool isPaint = true;

	public static bool isLoadData = true;

	public static sbyte isNPCMenu;

	private mVector vecFocus;

	public static MainObject objSelect;

	private int IdMenu;

	private int IdNpc;

	public static int IdNPCLast;

	private sbyte typeO;

	private int waitToPerform;

	private int cmRun;

	private sbyte timeShow;

	private int hShow;

	private int maxShow;

	private bool disableClose;

	public int w;

	private int pa;

	private bool trans;

	private int pointerDownTime;

	private int pointerDownFirstX;

	private int[] pointerDownLastX = new int[3];

	private bool pointerIsDowning;

	private bool isDownWhenRunning;

	private int archorRunText;

	private bool isPosPoint;

	private iCommand cmdChangeScreen;

	private iCommand cmdTouch;

	public iCommand cmdNgua;

	private int xBegin;

	private int w2cmd;

	private int cmvx;

	private int cmdx;

	public bool isNgua(short id)
	{
		return id == 62 || id == 63 || id == 64 || id == 65 || id == 66;
	}

	public void startAt(mVector menuItems, int pos, string name, bool isFocus, mVector mfocus)
	{
		isLoadData = false;
		waitToPerform = 0;
		runText = null;
		right = null;
		isNPCMenu = 0;
		isGiaotiep = isFocus;
		vecFocus = mfocus;
		SelectFocus = 0;
		if (isGiaotiep && (vecFocus == null || vecFocus.size() == 0))
		{
			return;
		}
		nameMenu = name;
		isHelp = false;
		disableClose = false;
		menuSelectedItem = 0;
		this.pos = pos;
		if (menuItems == null || menuItems.size() == 0)
		{
			return;
		}
		this.menuItems = menuItems;
		isShowMenu = true;
		if (pos == -1)
		{
			this.menuItems.addElement(new iCommand(T.close, 1, this));
			hPlus = 0;
			menuW = 60;
			menuH = 60;
			for (int i = 0; i < menuItems.size(); i++)
			{
				iCommand iCommand2 = (iCommand)menuItems.elementAt(i);
				int width = mFont.tahoma_7_yellow.getWidth(iCommand2.caption);
				if (width > menuW - 8)
				{
					iCommand2.subCaption = mFont.tahoma_7b_yellow.splitFontArray(iCommand2.caption, menuW - 8);
				}
			}
			w = menuItems.size() * menuW - 1;
			if (w > GameCanvas.w - 2)
			{
				w = GameCanvas.w - 2;
			}
			menuX = GameCanvas.hw - w / 2;
			if (menuX < 1)
			{
				menuX = 1;
			}
			menuY = GameCanvas.h - menuH - (GameCanvas.hCommand + 1);
			if (GameCanvas.isTouch)
			{
				menuY -= 3;
			}
			menuY += 27;
			menuTemY = menuY;
			cmxLim = this.menuItems.size() * menuW - GameCanvas.w;
			if (cmxLim < 0)
			{
				cmxLim = 0;
			}
			cmtoX = 0;
			cmx = 0;
			xc = 50;
		}
		else
		{
			if (isGiaotiep)
			{
				objSelect = (MainObject)vecFocus.elementAt(0);
			}
			menuW = GameCanvas.hCommand;
			if (GameCanvas.isTouch)
			{
				menuW = 32;
			}
			sizeMenu = GameCanvas.h / 4 * 3 / menuW - ((!isFocus) ? 1 : 2);
			if (GameCanvas.isTouch)
			{
				sizeMenu++;
			}
			w = GameCanvas.w / 3;
			if (w < mFont.tahoma_7b_white.getWidth(name) + 30)
			{
				w = mFont.tahoma_7b_white.getWidth(name) + 30;
			}
			hPlus = GameCanvas.hCommand;
			if (isFocus)
			{
				hPlus += menuW;
			}
			int num = 120;
			int num2 = 30;
			if (isFocus)
			{
				num2 = 50;
			}
			for (int j = 0; j < menuItems.size(); j++)
			{
				iCommand iCommand3 = (iCommand)menuItems.elementAt(j);
				int num3 = mFont.tahoma_7b_white.getWidth(iCommand3.caption) + num2;
				if (num3 > num)
				{
					num = num3;
				}
			}
			if (w < num)
			{
				w = num;
			}
			if (w > GameCanvas.w)
			{
				w = GameCanvas.w;
			}
			cmtoX = 0;
			cmx = 0;
			iCommand iCommand4 = null;
			if (GameCanvas.isTouch)
			{
				iCommand4 = new iCommand(T.close, 1, this);
			}
			else
			{
				this.menuItems.addElement(new iCommand(T.close, 1, this));
			}
			if (menuItems.size() > sizeMenu)
			{
				menuH = sizeMenu * menuW + 8;
				cmxLim = (menuItems.size() - sizeMenu) * menuW;
			}
			else
			{
				menuH = menuItems.size() * menuW + 8;
				cmxLim = 0;
			}
			setPos();
			menuTemY = menuY;
			if (iCommand4 != null)
			{
				iCommand4.setPos(menuX + w - 11, menuY - hPlus + GameCanvas.hCommand / 2 - 2, PaintInfoGameScreen.fraCloseMenu, string.Empty);
				right = iCommand4;
			}
		}
		if (GameCanvas.isTouch)
		{
			menuSelectedItem = -1;
		}
		isLoadData = true;
		resetBegin();
	}

	public void setinfoDynamic(mVector menulist, int pos, int idmenu, int idnpc, string name)
	{
		isLoadData = false;
		waitToPerform = 0;
		right = null;
		runText = null;
		isGiaotiep = false;
		vecFocus = null;
		if (menulist == null)
		{
			return;
		}
		nameMenu = name;
		isHelp = false;
		isNPCMenu = 0;
		menuSelectedItem = 0;
		IdMenu = idmenu;
		IdNpc = idnpc;
		this.pos = pos;
		disableClose = false;
		isShowMenu = true;
		menuItems = new mVector("Menu2 menuItem2");
		menuW = GameCanvas.hCommand;
		if (GameCanvas.isTouch)
		{
			menuW = 32;
		}
		sizeMenu = GameCanvas.h / 4 * 3 / menuW - 1;
		if (GameCanvas.isTouch)
		{
			sizeMenu++;
		}
		w = GameCanvas.w / 3;
		hPlus = menuW;
		int num = 120;
		if (num < mFont.tahoma_7b_white.getWidth(name) + 30)
		{
			num = mFont.tahoma_7b_white.getWidth(name) + 30;
		}
		for (int i = 0; i < menulist.size(); i++)
		{
			iCommand iCommand2 = (iCommand)menulist.elementAt(i);
			iCommand o = new iCommand(iCommand2.caption, 2, this);
			int num2 = mFont.tahoma_7b_white.getWidth(iCommand2.caption) + 20;
			if (num2 > num)
			{
				num = num2;
			}
			menuItems.addElement(o);
		}
		iCommand iCommand3 = null;
		if (GameCanvas.isTouch)
		{
			iCommand3 = new iCommand(T.close, 1, this);
		}
		else
		{
			menuItems.addElement(new iCommand(T.close, 1, this));
		}
		w = num;
		if (w > GameCanvas.w)
		{
			w = GameCanvas.w;
		}
		if (menuItems.size() > sizeMenu)
		{
			menuH = sizeMenu * menuW + 8;
			cmxLim = (menuItems.size() - sizeMenu) * menuW;
		}
		else
		{
			menuH = menuItems.size() * menuW + 8;
			cmxLim = 0;
		}
		cmtoX = 0;
		cmx = 0;
		setPos();
		menuTemY = menuY;
		if (iCommand3 != null)
		{
			iCommand3.setPos(menuX + w - 11, menuY - hPlus + GameCanvas.hCommand / 2 - 2, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			right = iCommand3;
		}
		if (GameCanvas.isTouch)
		{
			menuSelectedItem = -1;
		}
		isLoadData = true;
		resetBegin();
	}

	public void startAt_NPC(mVector menuItems, string name, int idNPC, sbyte typeO, bool isQuest, int archor)
	{
		isLoadData = false;
		waitToPerform = 0;
		right = null;
		isNPCMenu = 1;
		SelectFocus = 0;
		nameMenu = name;
		isHelp = false;
		disableClose = false;
		isGiaotiep = false;
		IdNpc = idNPC;
		IdNPCLast = idNPC;
		this.typeO = typeO;
		archorRunText = archor;
		menuSelectedItem = 0;
		if (menuItems == null || menuItems.size() == 0)
		{
			this.menuItems = new mVector("Menu2 menuItem3");
		}
		else
		{
			this.menuItems = menuItems;
		}
		isShowMenu = true;
		menuW = GameCanvas.hCommand;
		if (GameCanvas.isTouch)
		{
			menuW = 32;
		}
		sizeMenu = 0;
		w = GameCanvas.w - 10;
		if (w > 300)
		{
			w = 300;
		}
		mStrTalk = mFont.tahoma_7_black.splitFontArray(name, w - 20);
		hPlus = GameCanvas.hCommand;
		cmtoX = 0;
		cmx = 0;
		int num = mStrTalk.Length;
		if (!isQuest)
		{
			this.menuItems.addElement(new iCommand(T.close, 1, this));
		}
		else if (num == 1)
		{
			num = 2;
		}
		menuH = (num + 2) * GameCanvas.hText + ((this.menuItems.size() - 1) / 2 + 1) * (iCommand.hButtonCmd + 5) + 5;
		cmxLim = 0;
		menuX = GameCanvas.hw - w / 2;
		menuY = GameCanvas.h - menuH - 10;
		menuTemY = menuY;
		runText = new RunWord();
		runText.startDialogChain(name, 0, menuX + 10, menuY + 10 + GameCanvas.hText, w - 20, mFont.tahoma_7_white);
		setPosNPC();
		if (GameCanvas.isTouch)
		{
			menuSelectedItem = -1;
		}
		isLoadData = true;
		resetBegin();
	}

	public void setAt_Quick()
	{
		isPosPoint = PaintInfoGameScreen.isLevelPoint;
		timeShow = 1;
		isLoadData = false;
		waitToPerform = 0;
		right = null;
		isNPCMenu = 2;
		SelectFocus = 0;
		nameMenu = string.Empty;
		isHelp = false;
		disableClose = false;
		isGiaotiep = false;
		menuSelectedItem = 0;
		w = GameCanvas.w - 40;
		isShowMenu = true;
		menuW = 40;
		cmtoX = 0;
		cmx = 0;
		hShow = 0;
		menuH = 40;
		maxShow = (sbyte)(w / menuH);
		menuItems = new mVector("Menu2 menuItems");
		iCommand o = new iCommand(T.auto, 3, 2, this);
		iCommand o2 = new iCommand(T.dosat, 4, 4, this);
		iCommand o3 = new iCommand(T.setPk, 5, 3, this);
		iCommand o4 = new iCommand(T.mevent, 6, 0, this);
		iCommand o5 = new iCommand(T.listFriend, 7, 1, this);
		cmdNgua = new iCommand(T.TuseNgua, 14, 10, this);
		if (Main.isPC)
		{
			cmdChangeScreen = new iCommand(T.changeScrennSmall, 8, 5, this);
			if (Main.level == 1)
			{
				cmdChangeScreen.caption = T.normalScreen;
			}
			else
			{
				cmdChangeScreen.caption = ((mGraphics.zoomLevel != 1) ? T.changeScrennSmall : T.normalScreen);
			}
		}
		else
		{
			cmdTouch = new iCommand(T.touch + "/" + T.keypad, 8, 5, this);
		}
		iCommand o6 = new iCommand(T.naptien, 11, 9, this);
		iCommand o7 = new iCommand(T.logout, 12, 8, this);
		menuItems.addElement(cmdNgua);
		menuItems.addElement(o4);
		menuItems.addElement(o5);
		if (GameScreen.player.myClan != null)
		{
			iCommand o8 = new iCommand(T.clan, 9, 6, this);
			menuItems.addElement(o8);
		}
		if (Player.party != null)
		{
			iCommand o9 = new iCommand(T.party, 10, 7, this);
			menuItems.addElement(o9);
		}
		menuItems.addElement(o);
		menuItems.addElement(o3);
		if (!mSystem.isHideNaptien())
		{
			menuItems.addElement(o6);
		}
		menuItems.addElement(o2);
		if (Main.isPC)
		{
			menuItems.addElement(cmdChangeScreen);
		}
		else
		{
			menuItems.addElement(cmdTouch);
		}
		menuItems.addElement(o7);
		if (maxShow > menuItems.size())
		{
			maxShow = menuItems.size();
		}
		w = maxShow * menuH;
		cmxLim = 0;
		if (!isPosPoint)
		{
			menuX = GameCanvas.hw - w / 2;
		}
		else
		{
			menuX = 20;
		}
		menuY = GameCanvas.h - 40;
		menuTemY = menuY;
		if (GameCanvas.isTouch)
		{
			menuSelectedItem = -1;
		}
		isLoadData = true;
		for (int i = 0; i < menuItems.size(); i++)
		{
			iCommand iCommand2 = (iCommand)menuItems.elementAt(i);
			iCommand2.setPos_ShowName(menuX + menuH / 2 + i * menuH, menuY + menuH / 2, PaintInfoGameScreen.mfraIconQuick[iCommand2.subIndex], iCommand2.caption, 0, -32);
		}
		cmxLim = (menuItems.size() - maxShow) * menuH;
		menuSelectedItem = -1;
		resetBegin();
	}

	public void resetBegin()
	{
		for (int i = 0; i < pointerDownLastX.Length; i++)
		{
			pointerDownLastX[i] = 0;
		}
		pointerDownTime = 0;
		pointerDownFirstX = 0;
		pointerIsDowning = false;
		isDownWhenRunning = false;
		waitToPerform = 0;
		cmRun = 0;
	}

	public void setPosNPC()
	{
		int num = menuItems.size();
		switch (num)
		{
		case 1:
			xBegin = menuX + w / 2;
			w2cmd = 0;
			break;
		case 2:
			w2cmd = 20;
			xBegin = menuX + w / 2 - w2cmd / 2 - iCommand.wButtonCmd / 2;
			break;
		default:
			w2cmd = 20;
			xBegin = menuX + w / 2 - w2cmd / 2 - iCommand.wButtonCmd / 2;
			break;
		}
		for (int i = 0; i < num; i++)
		{
			iCommand iCommand2 = (iCommand)menuItems.elementAt(i);
			if (num == 3 && i == 2)
			{
				iCommand2.setPos(menuX + w / 2, menuY + menuH - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 + i / 2 * (iCommand.hButtonCmd + 5), null, iCommand2.caption);
			}
			else
			{
				iCommand2.setPos(xBegin + i % 2 * (iCommand.wButtonCmd + w2cmd), menuY + menuH - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 + i / 2 * (iCommand.hButtonCmd + 5), null, iCommand2.caption);
			}
			if (i == 0)
			{
				iCommand2.isSelect = true;
			}
		}
	}

	public void setPos()
	{
		switch (pos)
		{
		case 0:
			menuX = 2;
			menuY = GameCanvas.h - GameCanvas.hCommand - menuH - 2;
			if (GameCanvas.isTouch)
			{
				menuY += GameCanvas.hCommand;
			}
			break;
		case 1:
			menuX = GameCanvas.w - w - 2;
			menuY = GameCanvas.h - GameCanvas.hCommand - menuH - 2;
			if (GameCanvas.isTouch)
			{
				menuY += GameCanvas.hCommand;
			}
			break;
		case 2:
		case 4:
			menuX = GameCanvas.hw - w / 2;
			menuY = GameCanvas.h / 2 - menuH / 2 - 2 + menuW / 2 + 6;
			break;
		case 3:
			menuX = 2;
			menuY = 2;
			break;
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		mVector vecInvetoryPlayer = Item.VecInvetoryPlayer;
		switch (index)
		{
		case 0:
		{
			isShowMenu = false;
			iCommand cmd = (iCommand)menuItems.elementAt(menuSelectedItem);
			perform(cmd);
			break;
		}
		case 2:
			GlobalService.gI().Dynamic_Menu((short)IdNpc, (sbyte)IdMenu, (sbyte)menuSelectedItem);
			isShowMenu = false;
			GameCanvas.isPointerSelect = false;
			break;
		case 3:
			isShowMenu = false;
			GameScreen.gI().doMenuAuto();
			break;
		case 4:
			isShowMenu = false;
			GameScreen.gI().cmdSetDoSat.perform();
			break;
		case 5:
			isShowMenu = false;
			GameScreen.gI().cmdSetPk.perform();
			break;
		case 6:
			isShowMenu = false;
			TabConfig.cmdEvent.perform();
			break;
		case 7:
			GameScreen.gI().cmdListFriend.perform();
			break;
		case 8:
			if (Main.isPC)
			{
				GameCanvas.start_Left_Dialog(T.changeSizeScreen, new iCommand(T.select, 13, this));
			}
			else
			{
				TabConfig.cmdKeypad.perform();
			}
			break;
		case 9:
			TabConfig.cmdShowClan.perform();
			break;
		case 10:
			GameScreen.gI().cmdParty.perform();
			break;
		case 11:
			if (Main.isWP8)
			{
				Main.naptienWP8();
			}
			else if (Main.IphoneVersionApp)
			{
				GlobalService.gI().send_cmd_server(-56);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			else
			{
				GlobalService.gI().send_cmd_server(-56);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			break;
		case 12:
			Main.exit2();
			break;
		case 1:
			doCloseMenu();
			break;
		case 13:
			if (mGraphics.zoomLevel > 1)
			{
				Rms.saveRMSInt("levelScreenKN", 1);
			}
			else
			{
				Rms.saveRMSInt("levelScreenKN", 0);
			}
			Main.exit();
			break;
		case 14:
		{
			mVector mVector3 = new mVector("Menu2 vecngua");
			isShowMenu = false;
			if (GameScreen.player.typeMount != -1)
			{
				TabConfig.cmdXuongNgua.perform();
				break;
			}
			for (int i = 0; i < vecInvetoryPlayer.size(); i++)
			{
				MainItem mainItem = (MainItem)vecInvetoryPlayer.elementAt(i);
				if (mainItem != null && mainItem.ItemCatagory == 4 && isNgua((short)mainItem.Id))
				{
					mVector3.addElement(mainItem);
				}
			}
			if (mVector3.size() > 0)
			{
				GameScreen.gI().doMenuUseNgua(mVector3);
			}
			else
			{
				GameCanvas.start_Ok_Dialog(T.khongcongua);
			}
			break;
		}
		case 20:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][0], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 21:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][1], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 22:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][2], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 23:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][3], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 24:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][4], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 25:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][5], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public void updateMenuKey()
	{
		if (!isPaint || !isShowMenu)
		{
			return;
		}
		bool flag = false;
		if (isGiaotiep)
		{
			if (GameCanvas.keyMyPressed[2])
			{
				flag = true;
				menuSelectedItem--;
				if (menuSelectedItem < 0)
				{
					menuSelectedItem = menuItems.size() - 1;
				}
				GameCanvas.clearKeyPressed(2);
			}
			else if (GameCanvas.keyMyPressed[8])
			{
				flag = true;
				menuSelectedItem++;
				if (menuSelectedItem > menuItems.size() - 1)
				{
					menuSelectedItem = 0;
				}
				GameCanvas.clearKeyPressed(8);
			}
			int selectFocus = SelectFocus;
			if (GameCanvas.keyMyPressed[4])
			{
				SelectFocus--;
				GameCanvas.clearKeyPressed(4);
			}
			if (GameCanvas.keyMyPressed[6])
			{
				SelectFocus++;
				GameCanvas.clearKeyPressed(6);
			}
			SelectFocus = resetSelect(SelectFocus, vecFocus.size() - 1, isreset: true);
			if (SelectFocus != selectFocus)
			{
				objSelect = (MainObject)vecFocus.elementAt(SelectFocus);
			}
		}
		else if (isNPCMenu == 1)
		{
			int num = menuSelectedItem;
			if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[2])
			{
				menuSelectedItem--;
				GameCanvas.clearKeyHold(4);
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[6] || GameCanvas.keyMyHold[8])
			{
				menuSelectedItem++;
				GameCanvas.clearKeyHold(6);
				GameCanvas.clearKeyHold(8);
			}
			menuSelectedItem = resetSelect(menuSelectedItem, menuItems.size() - 1, isreset: false);
			if (num != menuSelectedItem)
			{
				for (int i = 0; i < menuItems.size(); i++)
				{
					iCommand iCommand2 = (iCommand)menuItems.elementAt(i);
					if (i == menuSelectedItem)
					{
						iCommand2.isSelect = true;
					}
					else
					{
						iCommand2.isSelect = false;
					}
				}
			}
			if (GameCanvas.keyMyHold[5])
			{
				GameCanvas.clearKeyHold(5);
				if (menuSelectedItem < menuItems.size() && menuSelectedItem >= 0)
				{
					((iCommand)menuItems.elementAt(menuSelectedItem)).perform();
				}
			}
		}
		else if (isNPCMenu == 0)
		{
			if (GameCanvas.keyMyPressed[2] || GameCanvas.keyMyPressed[4])
			{
				flag = true;
				menuSelectedItem--;
				if (menuSelectedItem < 0)
				{
					menuSelectedItem = menuItems.size() - 1;
				}
				GameCanvas.clearKeyPressed(2);
				GameCanvas.clearKeyPressed(4);
			}
			else if (GameCanvas.keyMyPressed[8] || GameCanvas.keyMyPressed[6])
			{
				flag = true;
				menuSelectedItem++;
				if (menuSelectedItem > menuItems.size() - 1)
				{
					menuSelectedItem = 0;
				}
				GameCanvas.clearKeyPressed(6);
				GameCanvas.clearKeyPressed(8);
			}
		}
		if (flag)
		{
			if (pos == -1)
			{
				cmtoX = menuSelectedItem * menuW + menuW - GameCanvas.w / 2;
			}
			else
			{
				cmtoX = (menuSelectedItem + 1) * menuW - menuH / 2;
			}
			if (cmtoX > cmxLim)
			{
				cmtoX = cmxLim;
			}
			if (cmtoX < 0)
			{
				cmtoX = 0;
			}
			if (menuSelectedItem == menuItems.size() - 1 || menuSelectedItem == 0)
			{
				cmx = cmtoX;
			}
		}
		if (isNPCMenu == 0)
		{
			if (pos == -1)
			{
				updatePos_LEFT_RIGHT();
			}
			else
			{
				update_Pos_UP_DOWN();
			}
			if (GameCanvas.isPointerSelect && !GameCanvas.isPoint(menuX - 5, menuTemY - 5 - hPlus, w + 10, menuH + 10 + hPlus))
			{
				doCloseMenu();
			}
		}
		else if (isNPCMenu == 2)
		{
			updatePos_LEFT_RIGHT();
			if (GameCanvas.isPointerSelect && !GameCanvas.isPoint(menuX - 5, menuY - 5, w + 10, menuH + 10))
			{
				timeShow = -1;
			}
		}
		base.updatekey();
	}

	public void updatePos_LEFT_RIGHT()
	{
		if (GameCanvas.isPointerDown)
		{
			if (!pointerIsDowning && GameCanvas.isPointer(menuX, menuY, w, menuH))
			{
				for (int i = 0; i < pointerDownLastX.Length; i++)
				{
					pointerDownLastX[0] = GameCanvas.px;
				}
				pointerDownFirstX = GameCanvas.px;
				pointerIsDowning = true;
				isDownWhenRunning = cmRun != 0;
				cmRun = 0;
			}
			else if (pointerIsDowning)
			{
				pointerDownTime++;
				if (pointerDownTime > 5 && pointerDownFirstX == GameCanvas.px && !isDownWhenRunning)
				{
					pointerDownFirstX = -1000;
					menuSelectedItem = (cmtoX + GameCanvas.px - menuX) / menuW;
				}
				int num = GameCanvas.px - pointerDownLastX[0];
				if (num != 0 && menuSelectedItem != -1)
				{
					menuSelectedItem = -1;
				}
				for (int num2 = pointerDownLastX.Length - 1; num2 > 0; num2--)
				{
					pointerDownLastX[num2] = pointerDownLastX[num2 - 1];
				}
				pointerDownLastX[0] = GameCanvas.px;
				cmtoX -= num;
				if (cmtoX < 0)
				{
					cmtoX = 0;
				}
				if (cmtoX > cmxLim)
				{
					cmtoX = cmxLim;
				}
				if (cmx < 0 || cmx > cmxLim)
				{
					num /= 2;
				}
				cmx -= num;
			}
		}
		if (GameCanvas.isPointerClick && pointerIsDowning)
		{
			int a = GameCanvas.px - pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			if (CRes.abs(a) < 20 && CRes.abs(GameCanvas.px - pointerDownFirstX) < 20 && !isDownWhenRunning)
			{
				cmRun = 0;
				cmtoX = cmx;
				pointerDownFirstX = -1000;
				menuSelectedItem = (cmtoX + GameCanvas.px - menuX) / menuW;
				pointerDownTime = 0;
				waitToPerform = 1;
			}
			else if (menuSelectedItem != -1 && pointerDownTime > 5)
			{
				pointerDownTime = 0;
				waitToPerform = 1;
			}
			else if (menuSelectedItem == -1 && !isDownWhenRunning)
			{
				if (cmx < 0)
				{
					cmtoX = 0;
				}
				else if (cmx > cmxLim)
				{
					cmtoX = cmxLim;
				}
				else
				{
					int num3 = GameCanvas.px - pointerDownLastX[0] + (pointerDownLastX[0] - pointerDownLastX[1]) + (pointerDownLastX[1] - pointerDownLastX[2]);
					num3 = ((num3 > 10) ? 10 : ((num3 < -10) ? (-10) : 0));
					cmRun = -num3 * 100;
				}
			}
			pointerIsDowning = false;
			pointerDownTime = 0;
			GameCanvas.isPointerClick = false;
		}
		if (GameCanvas.isPointerRelease && pointerIsDowning)
		{
			pointerIsDowning = false;
		}
	}

	private void update_Pos_UP_DOWN()
	{
		if (GameCanvas.keyMyPressed[5])
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			doCloseMenu();
			iCommand cmd = (iCommand)menuItems.elementAt(menuSelectedItem);
			perform(cmd);
		}
		else if (GameCanvas.keyMyPressed[12])
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			doCloseMenu();
			iCommand cmd2 = (iCommand)menuItems.elementAt(menuSelectedItem);
			perform(cmd2);
		}
		if (GameCanvas.isPointerSelect && isGiaotiep)
		{
			int selectFocus = SelectFocus;
			if (GameCanvas.isPoint(menuX + 13 - 14, menuTemY - hPlus + GameCanvas.hCommand + menuW / 2 - 14, 28, 28))
			{
				SelectFocus--;
				GameCanvas.isPointerSelect = false;
			}
			if (GameCanvas.isPoint(menuX + w - 13 - 14, menuTemY - hPlus + GameCanvas.hCommand + menuW / 2 - 14, 28, 28))
			{
				SelectFocus++;
				GameCanvas.isPointerSelect = false;
			}
			SelectFocus = resetSelect(SelectFocus, vecFocus.size() - 1, isreset: true);
			if (SelectFocus != selectFocus)
			{
				objSelect = (MainObject)vecFocus.elementAt(SelectFocus);
			}
		}
		if (GameCanvas.isPointerDown)
		{
			if (!pointerIsDowning && GameCanvas.isPointer(menuX, menuY, w, menuH))
			{
				for (int i = 0; i < pointerDownLastX.Length; i++)
				{
					pointerDownLastX[0] = GameCanvas.py;
				}
				pointerDownFirstX = GameCanvas.py;
				pointerIsDowning = true;
				isDownWhenRunning = cmRun != 0;
				cmRun = 0;
			}
			else if (pointerIsDowning)
			{
				pointerDownTime++;
				if (pointerDownTime > 5 && pointerDownFirstX == GameCanvas.py && !isDownWhenRunning)
				{
					pointerDownFirstX = -1000;
					menuSelectedItem = (cmtoX + GameCanvas.py - menuY) / menuW;
				}
				int num = GameCanvas.py - pointerDownLastX[0];
				if (num != 0 && menuSelectedItem != -1)
				{
					menuSelectedItem = -1;
				}
				for (int num2 = pointerDownLastX.Length - 1; num2 > 0; num2--)
				{
					pointerDownLastX[num2] = pointerDownLastX[num2 - 1];
				}
				pointerDownLastX[0] = GameCanvas.py;
				cmtoX -= num;
				if (cmtoX < 0)
				{
					cmtoX = 0;
				}
				if (cmtoX > cmxLim)
				{
					cmtoX = cmxLim;
				}
				if (cmx < 0 || cmx > cmxLim)
				{
					num /= 2;
				}
				cmx -= num;
			}
		}
		if (GameCanvas.isPointerClick && pointerIsDowning)
		{
			int a = GameCanvas.py - pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			if (CRes.abs(a) < 20 && CRes.abs(GameCanvas.py - pointerDownFirstX) < 20 && !isDownWhenRunning && GameCanvas.isPointerSelect)
			{
				cmRun = 0;
				cmtoX = cmx;
				pointerDownFirstX = -1000;
				menuSelectedItem = (cmtoX + GameCanvas.py - menuY) / menuW;
				pointerDownTime = 0;
				waitToPerform = 1;
			}
			else if (menuSelectedItem != -1 && pointerDownTime > 5)
			{
				pointerDownTime = 0;
				waitToPerform = 1;
			}
			else if (menuSelectedItem == -1 && !isDownWhenRunning)
			{
				if (cmx < 0)
				{
					cmtoX = 0;
				}
				else if (cmx > cmxLim)
				{
					cmtoX = cmxLim;
				}
				else
				{
					int num3 = GameCanvas.py - pointerDownLastX[0] + (pointerDownLastX[0] - pointerDownLastX[1]) + (pointerDownLastX[1] - pointerDownLastX[2]);
					num3 = ((num3 > 10) ? 10 : ((num3 < -10) ? (-10) : 0));
					cmRun = -num3 * 100;
				}
			}
			pointerIsDowning = false;
			pointerDownTime = 0;
			GameCanvas.isPointerClick = false;
		}
		if (GameCanvas.isPointerRelease && pointerIsDowning)
		{
			pointerIsDowning = false;
		}
	}

	public void moveCamera()
	{
		if (cmRun != 0 && !pointerIsDowning)
		{
			cmtoX += cmRun / 100;
			if (cmtoX < 0)
			{
				cmtoX = 0;
			}
			else if (cmtoX > cmxLim)
			{
				cmtoX = cmxLim;
			}
			else
			{
				cmx = cmtoX;
			}
			cmRun = cmRun * 9 / 10;
			if (cmRun < 100 && cmRun > -100)
			{
				cmRun = 0;
			}
		}
		if (cmx != cmtoX && !pointerIsDowning)
		{
			cmvx = cmtoX - cmx << 2;
			cmdx += cmvx;
			cmx += cmdx >> 4;
			cmdx &= 15;
		}
	}

	public void paintMenu(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		if (!isLoadData)
		{
			return;
		}
		if (isNPCMenu == 1)
		{
			paint_NPC_MENU(g);
		}
		else if (isNPCMenu == 0)
		{
			AvMain.paintDialog(g, menuX - 6, menuTemY - hPlus - 6, w + 12, menuH + hPlus + 12, 0);
			AvMain.paintRectNice(g, menuX, menuTemY, w, menuH, 2);
			mFont.tahoma_7b_black.drawString(g, nameMenu, menuX + w / 2, menuTemY - hPlus + GameCanvas.hCommand / 4, 2, mGraphics.isTrue);
			if (isGiaotiep)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, menuX, menuY - hPlus + GameCanvas.hCommand + 2, w, menuW - 4, 1);
				}
				else
				{
					for (int i = 0; i <= w / 32; i++)
					{
						if (i < w / 32)
						{
							g.drawRegion(MainTabNew.imgTab[1], 0, 0, 32, menuW - 4, 0, menuX + i * 32, menuTemY - hPlus + GameCanvas.hCommand + 2, 0, mGraphics.isTrue);
						}
						else
						{
							g.drawRegion(MainTabNew.imgTab[1], 0, 0, 32, menuW - 4, 0, menuX + w - 32, menuTemY - hPlus + GameCanvas.hCommand + 2, 0, mGraphics.isTrue);
						}
					}
				}
				if (vecFocus.size() > 1)
				{
					g.drawRegion(MainTabNew.imgTab[7], 0, 16, 13, 8, 6, menuX + 8 - GameCanvas.gameTick % 3, menuTemY - hPlus + GameCanvas.hCommand + menuW / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isTrue);
					g.drawRegion(MainTabNew.imgTab[7], 0, 24, 13, 8, 6, menuX + w - 8 + GameCanvas.gameTick % 3, menuTemY - hPlus + GameCanvas.hCommand + menuW / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isTrue);
				}
				AvMain.FontBorderColor(g, objSelect.name, menuX + w / 2 + 13, menuTemY - hPlus + GameCanvas.hCommand + menuW / 4 + 3, 2, 2);
				int num = mFont.tahoma_7b_black.getWidth(objSelect.name) / 2 + 1;
				objSelect.paintAvatarFocus(g, menuX + w / 2 - num - 2, menuTemY - hPlus + GameCanvas.hCommand + menuW / 4 + 8);
			}
			if (!isPaint)
			{
				return;
			}
			if (pos == -1)
			{
				g.setClip(menuX + 2, menuTemY + 2, w - 4, menuH - 4);
				g.translate(-cmx, 0);
				for (int j = 0; j < menuItems.size(); j++)
				{
					if (j == menuSelectedItem)
					{
						g.setColor(AvMain.color[3]);
						g.fillRoundRect(menuX + j * menuW + 3, menuTemY + 3, menuW - 8, menuH - 6, 6, 6, mGraphics.isTrue);
					}
					string[] array = ((iCommand)menuItems.elementAt(j)).subCaption;
					if (array == null)
					{
						array = new string[1] { ((iCommand)menuItems.elementAt(j)).caption };
					}
					int num2 = menuTemY + (menuH - array.Length * 14) / 2 + 1;
					for (int k = 0; k < array.Length; k++)
					{
						if (j == menuSelectedItem)
						{
							mFont.tahoma_7b_white.drawString(g, array[k], menuX + j * menuW + menuW / 2 - 1, num2 + k * 14, 2, mGraphics.isTrue);
						}
						else
						{
							mFont.tahoma_7b_black.drawString(g, array[k], menuX + j * menuW + menuW / 2 - 1, num2 + k * 14, 2, mGraphics.isTrue);
						}
					}
				}
				return;
			}
			g.setClip(menuX + 3, menuY + 3, w - 6, menuH - 6);
			g.translate(0, -cmx);
			g.setColor(AvMain.color[4]);
			if (pos == 2 || pos == 4)
			{
				for (int l = 0; l < menuItems.size() - 1; l++)
				{
					g.setColor(AvMain.color[4]);
					g.fillRect(menuX + 8, menuY + 3 + menuW + l * menuW, w - 16, 1, mGraphics.isTrue);
				}
			}
			int num3 = cmx / menuW - 1;
			if (num3 < 0)
			{
				num3 = 0;
			}
			int num4 = num3 + sizeMenu + 2;
			if (num4 > menuItems.size())
			{
				num4 = menuItems.size();
				num3 = num4 - sizeMenu - 2;
				if (num3 < 0)
				{
					num3 = 0;
				}
			}
			if (menuSelectedItem > -1)
			{
				paintSelect(g, menuX + 3, menuY + 3 + menuSelectedItem * menuW, w - 6, menuW + 1);
			}
			for (int m = num3; m < num4; m++)
			{
				iCommand iCommand2 = (iCommand)menuItems.elementAt(m);
				if (pos == 2)
				{
					iCommand2.paintCaptionImageMenu(g, menuX + w / 2, menuY + 6 + menuW / 4 + m * menuW, 2);
				}
				else if (pos == 0 || pos == 3)
				{
					iCommand2.paintCaptionImageMenu(g, menuX + 6, menuY + 6 + menuW / 4 + m * menuW, 0);
				}
				else if (pos == 1)
				{
					iCommand2.paintCaptionImageMenu(g, menuX + w - 6, menuY + 6 + menuW / 4 + m * menuW, 1);
				}
				else if (pos == 4)
				{
					iCommand2.paintCaptionImageMenu(g, menuX + 10, menuY + 6 + menuW / 4 + m * menuW, 0);
				}
			}
			GameCanvas.resetTrans(g);
			if (GameScreen.help.Step >= 0 && isHelp)
			{
				int num5 = GameScreen.help.itemMenuHelp();
				if (num5 >= 0)
				{
					MainHelp.paintPopup(g, menuX - 6 - 70, menuY + 16 + num5 * menuW - GameCanvas.hText, 70, GameCanvas.hText, -1, T.helpMenu);
					g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, menuX + 4 + GameCanvas.gameTick / 2 % 4, menuY + 14 + num5 * menuW, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isTrue);
				}
			}
			paintCmd(g);
		}
		else
		{
			if (isNPCMenu != 2)
			{
				return;
			}
			if (isPosPoint)
			{
				g.drawRegion(PaintInfoGameScreen.imgOther[4], 0, 0, 20, 16, 0, menuX - 20, menuY + menuH - 16, 0, mGraphics.isTrue);
				g.drawRegion(PaintInfoGameScreen.imgOther[4], 20, 0, 20, 16, 0, menuX + hShow, menuY + menuH - 16, 0, mGraphics.isTrue);
				if (hShow == menuH)
				{
					g.drawRegion(PaintInfoGameScreen.imgBackQuick, 20, 0, 20, 40, 2, menuX, menuY, 0, mGraphics.isTrue);
					g.drawRegion(PaintInfoGameScreen.imgBackQuick, 20, 0, 20, 40, 0, menuX + 20, menuY, 0, mGraphics.isTrue);
				}
				else
				{
					for (int n = 0; n < hShow; n += menuH)
					{
						if (n == 0)
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 0, 40, 40, 2, menuX, menuY, 0, mGraphics.isTrue);
						}
						else if (n + menuH >= hShow)
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 0, 40, 40, 0, menuX + n, menuY, 0, mGraphics.isTrue);
						}
						else
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 20, 40, 40, 0, menuX + n, menuY, 0, mGraphics.isTrue);
						}
					}
				}
				g.setClip(menuX + 5, menuY - 20, hShow - 10, menuH + 20);
			}
			else
			{
				g.drawRegion(PaintInfoGameScreen.imgOther[4], 0, 0, 20, 16, 0, menuX + w / 2 - hShow / 2 - 20, menuY + menuH - 16, 0, mGraphics.isTrue);
				g.drawRegion(PaintInfoGameScreen.imgOther[4], 20, 0, 20, 16, 0, menuX + w / 2 + hShow / 2, menuY + menuH - 16, 0, mGraphics.isTrue);
				if (hShow == menuH)
				{
					g.drawRegion(PaintInfoGameScreen.imgBackQuick, 20, 0, 20, 40, 2, menuX + w / 2 - 20, menuY, 0, mGraphics.isTrue);
					g.drawRegion(PaintInfoGameScreen.imgBackQuick, 20, 0, 20, 40, 0, menuX + w / 2, menuY, 0, mGraphics.isTrue);
				}
				else
				{
					for (int num6 = 0; num6 < hShow; num6 += menuH)
					{
						if (num6 == 0)
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 0, 40, 40, 2, menuX + w / 2 - hShow / 2 + num6, menuY, 0, mGraphics.isTrue);
						}
						else if (num6 + menuH >= hShow)
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 0, 40, 40, 0, menuX + w / 2 - hShow / 2 + num6, menuY, 0, mGraphics.isTrue);
						}
						else
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 20, 40, 40, 0, menuX + w / 2 - hShow / 2 + num6, menuY, 0, mGraphics.isTrue);
						}
					}
				}
				g.setClip(menuX + w / 2 - hShow / 2 + 5, menuY - 20, hShow - 10, menuH + 20);
			}
			g.translate(-cmx, 0);
			for (int num7 = 0; num7 < menuItems.size(); num7++)
			{
				iCommand iCommand3 = (iCommand)menuItems.elementAt(num7);
				iCommand3.paint(g, iCommand3.xCmd, iCommand3.yCmd);
			}
			GameCanvas.resetTrans(g);
			g.translate(-cmx, 0);
			for (int num8 = 0; num8 < menuItems.size(); num8++)
			{
				iCommand iCommand4 = (iCommand)menuItems.elementAt(num8);
				iCommand4.paintClickCaption(g, iCommand4.xCmd, iCommand4.yCmd, 2);
			}
		}
	}

	private void paint_NPC_MENU(mGraphics g)
	{
		int num = menuX + 6;
		int y = menuY + 8;
		AvMain.paintDialog(g, menuX, menuTemY, w, menuH, 12);
		MainObject mainObject = MainObject.get_Object(IdNpc, typeO);
		if (mainObject != null)
		{
			mainObject.paintBigAvatar(g, menuX + w - 10, menuY);
			AvMain.Font3dWhite(g, mainObject.name, num + 10, y, 0);
			if (runText != null)
			{
				runText.paintText(g, archorRunText);
			}
			GameCanvas.resetTrans(g);
			for (int i = 0; i < menuItems.size(); i++)
			{
				iCommand iCommand2 = (iCommand)menuItems.elementAt(i);
				iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
			}
		}
	}

	public void doCloseMenu()
	{
		isShowMenu = false;
		GameCanvas.isPointerSelect = false;
		GameCanvas.isPointerClick = false;
		GameCanvas.isPointerEnd = true;
	}

	public void updateMenu()
	{
		if (timeShow > 0)
		{
			timeShow++;
			if (hShow < w)
			{
				hShow += menuH;
				if (hShow >= w)
				{
					hShow = w;
					timeShow = 0;
				}
			}
		}
		else if (timeShow < 0)
		{
			timeShow--;
			if (hShow > 0)
			{
				hShow -= menuH;
				if (hShow <= 0)
				{
					hShow = 0;
					timeShow = 0;
					doCloseMenu();
				}
			}
		}
		if (!isLoadData)
		{
			return;
		}
		moveCamera();
		if (isNPCMenu == 1)
		{
			if (runText != null)
			{
				runText.updateDlg();
			}
			for (int i = 0; i < menuItems.size(); i++)
			{
				iCommand iCommand2 = (iCommand)menuItems.elementAt(i);
				iCommand2.updatePointer();
			}
		}
		else if (isNPCMenu == 2 && !GameCanvas.isPointerMove && timeShow == 0)
		{
			for (int j = 0; j < menuItems.size(); j++)
			{
				iCommand iCommand3 = (iCommand)menuItems.elementAt(j);
				iCommand3.updatePointerShow(cmx, 0);
			}
		}
		if (menuTemY > menuY)
		{
			int num = menuTemY - menuY >> 1;
			if (num < 1)
			{
				num = 1;
			}
			menuTemY -= num;
		}
		if (xc != 0)
		{
			xc >>= 1;
			if (xc < 0)
			{
				xc = 0;
			}
		}
		if (waitToPerform > 0)
		{
			waitToPerform--;
			if (waitToPerform == 0)
			{
				isShowMenu = false;
				if (menuSelectedItem >= 0)
				{
					iCommand cmd = (iCommand)menuItems.elementAt(menuSelectedItem);
					perform(cmd);
					GameCanvas.clearKeyHold();
					GameCanvas.clearKeyPressed();
					GameCanvas.isPointerEnd = true;
					GameCanvas.isPointerSelect = false;
				}
			}
		}
		base.updatePointer();
	}

	public void perform(iCommand cmd)
	{
		if (cmd != null)
		{
			if (cmd.action != null)
			{
				cmd.action.perform();
			}
			else if (cmd.Pointer != null)
			{
				cmd.Pointer.commandPointer(cmd.indexMenu, cmd.subIndex);
			}
			else
			{
				GameCanvas.currentScreen.commandMenu(cmd.indexMenu, cmd.subIndex);
			}
			GameCanvas.isPointerSelect = false;
			mSound.playSound(42, mSound.volumeSound);
		}
	}
}
