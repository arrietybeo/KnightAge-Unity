using System;

public class GameCanvas
{
	public static int naptien;

	public static bool isPlaySound = true;

	private TemCanvas mainCanvas;

	public static MainScreen currentScreen;

	public static LogoScreen logo;

	public static LoginScreen login;

	public static GameScreen game;

	public static LoadMapScreen load;

	public static WorldMapScreen worldmap;

	public static StoryScreen story;

	public static MsgChat msgchat;

	public static EventScreen mevent;

	public static SelectCharScreen selectChar;

	public static CreateChar createChar;

	public static List_Ip_Server_Screen listIp;

	public static Info_Other_Player info_other_player;

	public static Clan_Screen clan;

	public static MiniMapFull_Screen fullMiniMap;

	public static T t = new T();

	private mGraphics g = new mGraphics();

	public static Menu2 menu2 = new Menu2();

	public static LoadMap loadmap;

	public static MiniMap minimap;

	public static GameCanvas instance;

	public static MainDialog currentDialog;

	public static MainDialog subDialog;

	public static ReadMessenge readMessenge;

	public static MainTabNew maintab;

	public static TabScreenNew AllInfo;

	public static TabScreenNew shopNpc;

	public static TabScreenNew foodPet;

	public static Buy_Sell_Screen buy_sell;

	public static MapBackGround mapBack;

	public static SaveImageRMS saveImage;

	public static bool isTouch = true;

	public static bool lowGraphic = false;

	public static bool isSmallScreen = false;

	public static bool isVN_Eng = true;

	public static sbyte device = 0;

	public static string stringPackageName = string.Empty;

	public static sbyte IndexRes = -1;

	public static sbyte IndexServer = 4;

	public static short IndexCharPar = -1;

	public static long timenextLogin;

	public static string[,] listServer = new string[7, 2]
	{
		{ "Chiến Thần", "112.213.85.108" },
		{ "Rồng Lửa", "27.0.12.133" },
		{ "Global Server", "hsglobal.teamobi.com" },
		{ "Phượng Hoàng", "112.213.85.75" },
		{ "Nhân Mã", "27.0.14.90" },
		{ "Kì Lân (New)", "127.0.0.1" },
		{ "Thách Đấu", "112.213.84.17" }
	};

	public static int[] portServer = new int[7] { 19129, 19129, 19129, 19129, 19129, 19129, 19129 };

	public static int[] langServer = new int[7] { 0, 0, 1, 0, 0, 0, 0 };

	public static long countLogin = 0L;

	public static string linkIP = "http://knightageonline.com/srvip/";

	public static bool isBB = false;

	public static bool isPointerDown = false;

	public static bool isPointerRelease = false;

	public static bool isPointerSelect = false;

	public static bool isPointerMove = false;

	public static bool isPointerClick = false;

	public static bool isPointerEnd = false;

	public static int w;

	public static int h;

	public static int hw;

	public static int hh;

	public static int hCommand = 25;

	public static int hText = 14;

	public static int hFontBorder;

	public static int hFontF;

	public static int hNormal;

	public static int wCommand;

	public static int hLoad = 0;

	public static int px;

	public static int py;

	public static int pxLast;

	public static int pyLast;

	public static int gameTick;

	public static long timeNow = 0L;

	public static bool[] keyMyPressed = new bool[41];

	public static bool[] keyMyReleased = new bool[41];

	public static bool[] keyMyHold = new bool[41];

	public static bool isMoto;

	public static int coutPaintSplash = 30;

	public static int timeOpenKeyBoard;

	public static int keyAsciiPress;

	public static mVector listPoint;

	public static long countTips = 0L;

	public static int iTips = 0;

	public GameCanvas()
	{
		instance = this;
		mainCanvas = TemMidlet.temCanvas;
		device = TemMidlet.DIVICE;
		stringPackageName = mSystem.getPackageName();
		getSize();
		mSystem.doSetWpLinkIp();
		mFont.loadmFont();
		IndoServer.setLinkIp();
		Usa_Server.setLinkIp();
		if (w < 200 || h < 200)
		{
			isSmallScreen = true;
			if (LoginScreen.indexInfoLogin == 1)
			{
				LoginScreen.indexInfoLogin = 2;
			}
			iCommand.wButtonCmd = 56;
		}
		wCommand = 36;
		PaintInfoGameScreen.isLevelPoint = false;
		if (isTouch)
		{
			wCommand = 40;
			listPoint = new mVector("GameCanvas listPoint");
			iCommand.hButtonCmd = 30;
			iCommand.wButtonCmd = 80;
			MsgDialog.hPlus = 58;
		}
		else if (isSmallScreen)
		{
			wCommand = 30;
		}
		saveImage = new SaveImageRMS();
		if (CRes.loadRMS("isQty") != null)
		{
			TField.isQwerty = true;
		}
		try
		{
			sbyte[] array = CRes.loadRMS("isLowDevice");
			if (array != null)
			{
				DataInputStream dataInputStream = new DataInputStream(array);
				int num = dataInputStream.readByte();
				if (num == 1)
				{
					lowGraphic = true;
				}
				else
				{
					lowGraphic = false;
				}
			}
		}
		catch (Exception)
		{
		}
		try
		{
			sbyte[] array2 = CRes.loadRMS("isIndexRes");
			if (array2 != null)
			{
				DataInputStream dataInputStream2 = new DataInputStream(array2);
				IndexRes = dataInputStream2.readByte();
			}
		}
		catch (Exception)
		{
		}
		try
		{
			if (TemMidlet.DIVICE > 0)
			{
				sbyte[] array3 = CRes.loadRMS("isIndexPart");
				if (array3 != null)
				{
					DataInputStream dataInputStream3 = new DataInputStream(array3);
					IndexCharPar = dataInputStream3.readShort();
				}
			}
			else
			{
				IndexCharPar = 0;
			}
		}
		catch (Exception)
		{
		}
		IndexServer = 5;
		try
		{
			sbyte[] array4 = CRes.loadRMS("isIndexServer");
			if (array4 != null)
			{
				IndexServer = array4[0];
			}
		}
		catch (Exception)
		{
		}
		try
		{
			if (TemMidlet.DIVICE > 0)
			{
				MsgDialog.mvalueVolume = new sbyte[2];
				MsgDialog.mvalueVolume[0] = 0;
				MsgDialog.mvalueVolume[1] = 0;
				sbyte[] array5 = CRes.loadRMS("isVolume");
				if (array5 != null)
				{
					DataInputStream dataInputStream4 = new DataInputStream(array5);
					MsgDialog.mvalueVolume[0] = dataInputStream4.readByte();
					MsgDialog.mvalueVolume[1] = dataInputStream4.readByte();
				}
				MsgDialog.setMusic();
			}
		}
		catch (Exception)
		{
		}
		if (IndoServer.isIndoSv)
		{
			IndexServer = 1;
			try
			{
				sbyte[] array6 = CRes.loadRMS("isIndexServer");
				if (array6 != null)
				{
					IndexServer = array6[0];
				}
			}
			catch (Exception)
			{
			}
		}
		if (Usa_Server.isUsa_server)
		{
			IndexServer = 0;
		}
		CreateImageStatic.LoadImage();
		MainScreen.cameraMain = new Camera();
		MainScreen.cameraSub = new Camera();
		loadmap = new LoadMap();
		minimap = new MiniMap();
		login = new LoginScreen();
		game = new GameScreen();
		load = new LoadMapScreen();
		worldmap = new WorldMapScreen();
		readMessenge = new ReadMessenge();
		maintab = new MainTabNew();
		AllInfo = new TabScreenNew();
		msgchat = new MsgChat();
		selectChar = new SelectCharScreen();
		mevent = new EventScreen();
		MainListSkill.loadIndexEffKill();
		logo = new LogoScreen();
		logo.Show();
		int[] musicID = new int[9];
		int[] sID = new int[59];
		mSound.volumeSound = 1;
		mSound.volumeMusic = 1;
		mSound.init(musicID, sID);
		StoryScreen.setTypeStory();
	}

	public static void loadCaptionCmd()
	{
		login.setCaptionCmd();
		game.setCaptionCmd();
		AllInfo.setCaptionCmd();
		msgchat.setCaptionCmd();
		selectChar.setCaptionCmd();
		mevent.setCaptionCmd();
	}

	public void paint(TemGraphics gx)
	{
		g = gx.g;
		currentScreen.paint(g);
		if (setShowEvent())
		{
			GameScreen.infoGame.paintShowEvent(g);
			GameScreen.infoGame.paintInfoChar(g);
		}
		if (subDialog != null)
		{
			subDialog.paint(g);
		}
		if (currentDialog != null)
		{
			currentDialog.paint(g);
		}
		else if (menu2.isShowMenu)
		{
			menu2.paintMenu(g);
		}
		else if (ChatTextField.isShow)
		{
			ChatTextField.gI().paint(g);
		}
		resetTrans(g);
		if (hLoad > 0)
		{
			g.setColor(0);
			g.fillRect(0, 0, w, h, mGraphics.isFalse);
		}
	}

	public static void closeKeyBoard()
	{
		mGraphics.addYWhenOpenKeyBoard = 0;
		timeOpenKeyBoard = 0;
		Main.closeKeyBoard();
	}

	public static void Translate()
	{
		if (TouchScreenKeyboard.visible)
		{
			timeOpenKeyBoard++;
			if (timeOpenKeyBoard > ((!Main.isWindowsPhone) ? 10 : 5))
			{
				if (currentScreen == login)
				{
					mGraphics.addYWhenOpenKeyBoard = ((mGraphics.zoomLevel != 1) ? 50 : 55);
				}
				else if (ChatTextField.isShow)
				{
					mGraphics.addYWhenOpenKeyBoard = 45;
				}
			}
		}
		else
		{
			mGraphics.addYWhenOpenKeyBoard = 0;
			timeOpenKeyBoard = 0;
		}
	}

	public bool setShowEvent()
	{
		if (currentScreen == game || currentScreen == AllInfo || currentScreen == shopNpc || currentScreen == foodPet || currentScreen == worldmap || currentScreen == buy_sell || currentScreen == info_other_player || currentScreen == mevent || currentScreen == clan || currentScreen == MiniMapFull_Screen.gI() || currentScreen == List_Server.gI())
		{
			return true;
		}
		return false;
	}

	public void update()
	{
		if ((mGraphics.zoomLevel == 1 || Main.isIpod || Main.isIphone4) && !Main.isPC)
		{
			lowGraphic = true;
		}
		Translate();
		if (loadmap != null)
		{
			loadmap.update();
		}
		gameTick++;
		if (gameTick > 10000)
		{
			gameTick = 0;
		}
		if (gameTick % 5 == 0)
		{
			timeNow = mSystem.currentTimeMillis();
		}
		if (hLoad > 0)
		{
			hLoad -= h / 10;
		}
		if (setShowEvent())
		{
			GameScreen.infoGame.updateEvent();
			GameScreen.infoGame.updateInfoServer();
			GameScreen.infoGame.updateInfoChar();
			GameScreen.infoGame.updateInfoCharServer();
		}
		if (currentDialog != null)
		{
			currentDialog.update();
		}
		else if (menu2.isShowMenu)
		{
			menu2.updateMenu();
			menu2.updateMenuKey();
		}
		else if (subDialog != null)
		{
			subDialog.update();
		}
		else if (ChatTextField.isShow)
		{
			ChatTextField.gI().updatekey();
			ChatTextField.gI().updatePointer();
		}
		else
		{
			currentScreen.updatekey();
			currentScreen.updatePointer();
		}
		currentScreen.update();
		isPointerClick = false;
		if (GameScreen.timeResetCam > 0)
		{
			GameScreen.timeResetCam--;
			if (GameScreen.timeResetCam == 0)
			{
				GameScreen.isMoveCamera = false;
			}
		}
		if (GlobalLogicHandler.isDisconnect)
		{
			GlobalLogicHandler.isDisconnect = false;
			mSystem.outz("mat ket noi");
			mVector mVector3 = new mVector();
			if (SelectCharScreen.isSelectOk && currentScreen != login && currentScreen != load)
			{
				mVector3.addElement(new iCommand(T.again, 0));
			}
			mVector3.addElement(new iCommand(T.exit, 6));
			if (!Main.isExit)
			{
				start_Select_Dialog(T.disconnect, mVector3);
			}
			if (GameScreen.player != null)
			{
				GameScreen.player.resetAction();
				if (Player.isAutoFire == 1)
				{
					Player.setCurAutoFire();
				}
			}
		}
		coutPaintSplash--;
		updateCountTick();
	}

	public void reSume()
	{
		if (currentScreen != login && currentScreen != load)
		{
			if (!SelectCharScreen.isSelectOk)
			{
				return;
			}
			login.Show();
			sbyte[] array = CRes.loadRMS("user_pass");
			if (array != null)
			{
				try
				{
					LoginScreen.loadUser_Pass();
				}
				catch (Exception)
				{
				}
				connect();
				GlobalService.gI().login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText(), GameMidlet.version, "0", "0", "0", SelectCharScreen.IDCHAR, LoadMap.Area);
				GameScreen.player.resetPlayer();
				if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
				{
					GlobalService.gI().send_cmd_server(61);
				}
			}
			else
			{
				login.Show();
			}
		}
		else if (currentScreen != login)
		{
			login.Show();
		}
	}

	public static void resetTrans(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.translate(0, 0);
		g.setClip(-200, -200, w + 400, h + 400);
	}

	public static void start_Ok_Dialog(string str)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, new iCommand("Ok", -1), true);
		currentDialog = msgDialog;
	}

	public static void start_Ok_Dialog(string str, sbyte t)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, new iCommand("Ok", t), true);
		currentDialog = msgDialog;
	}

	public static void start_Download_Dialog(string str, string link)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoDownload(str, link, false);
		currentDialog = msgDialog;
	}

	public static void start_Show_Dialog(string str, string name)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoSHOW(str, new iCommand(T.close, -1), true, name);
		currentDialog = msgDialog;
	}

	public static void start_Wait_Dialog(string str, iCommand cmd)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoWait(str, cmd);
		currentDialog = msgDialog;
	}

	public static void start_Select_Dialog(string str, mVector cmd)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, cmd);
		currentDialog = msgDialog;
	}

	public static void start_Center_Dialog_Only(string str, iCommand cmd)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, cmd, true);
		currentDialog = msgDialog;
	}

	public static void start_Left_Dialog(string str, iCommand cmd)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, cmd, false);
		currentDialog = msgDialog;
	}

	public static void start_Quest_Dialog(string str, string status, int ID, int type, sbyte mainsub)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoQuest(str, status, ID, type, mainsub);
		Cout.println(mainsub);
		subDialog = msgDialog;
	}

	public static void start_Quest_DialogRead(MainQuest quest)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoQuestRead(quest);
		subDialog = msgDialog;
	}

	public static void start_Party_Dialog()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoParty();
		subDialog = msgDialog;
	}

	public static void start_Auto_HPMP_Dialog()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoAutoHP_MP();
		currentDialog = msgDialog;
	}

	public static void start_Volume_Dialog()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoVolume();
		currentDialog = msgDialog;
	}

	public static void start_Auto_Item_Dialog()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoAutoGetItem();
		currentDialog = msgDialog;
	}

	public static void start_Auto_Buff()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setInfoAutoBuff();
		subDialog = msgDialog;
	}

	public static void start_Chat_Dialog()
	{
		msgchat.checkRemoveText();
		msgchat.init();
		subDialog = msgchat;
	}

	public static void start_More_Input_Dialog(string[] str, iCommand cmd, short type, short idNPC, string name, string[] infomacdinh, sbyte typemo)
	{
		end_Dialog();
		InputDialog inputDialog = new InputDialog();
		inputDialog.setinfo(str, cmd, type, idNPC, name, infomacdinh, typemo);
		subDialog = inputDialog;
	}

	public static void start_More_Input_Dialog(string[] str, iCommand cmd, short type, short idNPC, string name)
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.setinfo(str, cmd, type, idNPC, name);
		subDialog = inputDialog;
	}

	public static void start_Time_Dialog(string info, short time)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setInfoTime(info, time);
		subDialog = msgDialog;
	}

	public static void start_Change_Item(string name, string info, MainItem[] datanguyenlieu, MainItem sanpham)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setShowChangeItem(name, info, datanguyenlieu, sanpham);
		currentDialog = msgDialog;
	}

	public static void start_Open_Box(string name, string info, MainItem[] data, sbyte typeOpen, sbyte isLottery)
	{
		if (info != null && info.Trim().Length == 0)
		{
			info = null;
		}
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setShowOpenBox(name, data, info, typeOpen, isLottery);
		currentDialog = msgDialog;
	}

	public static void start_Update_Data()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setUpdateData();
		currentDialog = msgDialog;
	}

	public static void start_Pet_Info(PetItem pet, sbyte type)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setPetInfo(pet, type);
		subDialog = msgDialog;
		if (pet != null)
		{
			GlobalService.gI().Update_Pet_Eat(TabShopNew.UPDATE_PET_EAT, (short)pet.Id);
		}
	}

	public static void end_Dialog()
	{
		currentDialog = null;
		subDialog = null;
		clearKeyHold();
		clearKeyPressed();
		if (GameScreen.help.Step >= 0)
		{
			GameScreen.help.timeReset = 20;
		}
	}

	public static void end_Dialog_Help()
	{
		currentDialog = null;
	}

	public static void addInfoCharServer(string str)
	{
		resetTip();
		if (str != null && str.Length > 0)
		{
			GameScreen.VecInfoServer.addElement(str);
		}
	}

	public static void addInfoChar(string str)
	{
		if (str != null && str.Length > 0)
		{
			if (mFont.tahoma_7_black.getWidth(str) > 140)
			{
				addInfoCharCline(str);
				return;
			}
			GameScreen.infoGame.strInfoCharCline = str;
			GameScreen.infoGame.ydInfoChar = 10;
			GameScreen.infoGame.timeInfoCharCline = 0;
		}
	}

	public static void addInfoCharCline(string str)
	{
		if (str != null && str.Length > 0)
		{
			GameScreen.VecInfoChar.addElement(str);
		}
	}

	public void mapKeyPress(int keyCode)
	{
		PaintInfoGameScreen.timeDoNotClick = timeNow;
		PaintInfoGameScreen.isShowInGame = true;
		if (currentDialog != null)
		{
			currentDialog.keypress(keyCode);
		}
		else if (subDialog != null)
		{
			subDialog.keypress(keyCode);
		}
		else if (ChatTextField.isShow)
		{
			ChatTextField.gI().keyPressed(keyCode);
		}
		else
		{
			currentScreen.keyPress(keyCode);
		}
		if (TField.isQwerty)
		{
			if (keyAsciiPress == 114 || keyAsciiPress == 82)
			{
				keyMyHold[21] = true;
				keyMyPressed[21] = true;
			}
			else if (keyAsciiPress == 116 || keyAsciiPress == 84)
			{
				keyMyHold[23] = true;
				keyMyPressed[23] = true;
			}
			else if (keyAsciiPress == 121 || keyAsciiPress == 89)
			{
				keyMyHold[25] = true;
				keyMyPressed[25] = true;
			}
			else if (keyAsciiPress == 117 || keyAsciiPress == 85)
			{
				keyMyHold[27] = true;
				keyMyPressed[27] = true;
			}
			else if (keyAsciiPress == 105 || keyAsciiPress == 73)
			{
				keyMyHold[29] = true;
				keyMyPressed[29] = true;
			}
		}
		switch (keyCode)
		{
			case 100:
				keyMyHold[40] = true;
				keyMyPressed[40] = true;
				break;
			case 97:
				keyMyHold[39] = true;
				keyMyPressed[39] = true;
				break;
			case 115:
				keyMyHold[38] = true;
				keyMyPressed[38] = true;
				break;
			case 99:
				keyMyHold[37] = true;
				keyMyPressed[37] = true;
				break;
			case -1:
				keyMyHold[31] = true;
				keyMyPressed[31] = true;
				break;
			case -2:
				keyMyHold[32] = true;
				keyMyPressed[32] = true;
				break;
			case -3:
				keyMyHold[33] = true;
				keyMyPressed[33] = true;
				break;
			case -4:
				keyMyHold[34] = true;
				keyMyPressed[34] = true;
				break;
			case -5:
				keyMyHold[36] = true;
				keyMyPressed[36] = true;
				break;
			case 10:
				keyMyHold[5] = true;
				keyMyPressed[5] = true;
				break;
			case 48:
				keyMyHold[0] = true;
				keyMyPressed[0] = true;
				break;
			case 49:
				keyMyHold[1] = true;
				keyMyPressed[1] = true;
				break;
			case 50:
				keyMyHold[2] = true;
				keyMyPressed[2] = true;
				break;
			case 51:
				keyMyHold[3] = true;
				keyMyPressed[3] = true;
				break;
			case 52:
				keyMyHold[4] = true;
				keyMyPressed[4] = true;
				break;
			case 53:
				if (currentScreen == GameScreen.gI() && !ChatTextField.isShow)
				{
					keyMyHold[5] = true;
					keyMyPressed[5] = true;
				}
				break;
			case 54:
				keyMyHold[6] = true;
				keyMyPressed[6] = true;
				break;
			case 55:
			case 56:
			case 57:
				keyMyHold[keyCode - 28] = true;
				keyMyPressed[keyCode - 28] = true;
				break;
			case 42:
				keyMyHold[10] = true;
				keyMyPressed[10] = true;
				break;
			case 35:
				keyMyHold[11] = true;
				keyMyPressed[11] = true;
				break;
			case -21:
			case -6:
				keyMyHold[12] = true;
				keyMyPressed[12] = true;
				break;
			case -22:
			case -7:
				keyMyHold[13] = true;
				keyMyPressed[13] = true;
				break;
			case 119:
				keyMyHold[30] = true;
				keyMyPressed[30] = true;
				break;
		}
	}

	public void mapKeyRelease(int keyCode)
	{
		switch (keyCode)
		{
			case 100:
				keyMyHold[40] = false;
				break;
			case 97:
				keyMyHold[39] = false;
				break;
			case 115:
				keyMyHold[38] = false;
				break;
			case 71:
				keyMyHold[37] = false;
				break;
			case -1:
				keyMyHold[31] = false;
				break;
			case -2:
				keyMyHold[32] = false;
				break;
			case -3:
				keyMyHold[33] = false;
				break;
			case -4:
				keyMyHold[34] = false;
				break;
			case -5:
				keyMyHold[36] = false;
				break;
			case 10:
				keyMyHold[5] = false;
				keyMyPressed[5] = false;
				break;
			case 48:
				keyMyHold[0] = false;
				break;
			case 49:
				keyMyHold[1] = false;
				break;
			case 50:
				keyMyHold[2] = false;
				break;
			case 51:
				keyMyHold[3] = false;
				keyMyPressed[3] = true;
				break;
			case 4:
				keyMyHold[36] = false;
				break;
			case 52:
				keyMyHold[4] = true;
				break;
			case 53:
				keyMyHold[5] = false;
				break;
			case 54:
				keyMyHold[6] = false;
				break;
			case 55:
			case 56:
			case 57:
				keyMyHold[keyCode - 28] = false;
				break;
			case 42:
				keyMyHold[10] = false;
				break;
			case 35:
				keyMyHold[11] = false;
				break;
			case -21:
			case -6:
				keyMyHold[12] = false;
				break;
			case -22:
			case -7:
				keyMyHold[13] = false;
				break;
			case 119:
				keyMyHold[30] = false;
				break;
		}
	}

	public void keyPressed(int keyCode)
	{
		if (TField.isQwerty && ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 122) || keyCode == 10 || keyCode == 8 || keyCode == 13 || keyCode == 32))
		{
			keyAsciiPress = keyCode;
		}
		mapKeyPress(keyCode);
	}

	public void keyReleased(int keyCode)
	{
		if (TField.isQwerty)
		{
			keyAsciiPress = 0;
		}
		mapKeyRelease(keyCode);
	}

	public static bool isKeyPressed(int index)
	{
		if (keyMyPressed[index])
		{
			return true;
		}
		return false;
	}

	public void pointerDragged(int x, int y)
	{
		px = x / mGraphics.zoomLevel;
		py = y / mGraphics.zoomLevel;
		if (isPointerMove)
		{
			listPoint.addElement(new Position(x, y));
		}
		else if (CRes.abs(px - pxLast) >= 15 || CRes.abs(py - pyLast) >= 15)
		{
			isPointerMove = true;
		}
	}

	public void pointerPressed(int x, int y)
	{
		PaintInfoGameScreen.timeDoNotClick = timeNow;
		PaintInfoGameScreen.isShowInGame = true;
		isPointerDown = true;
		isPointerMove = false;
		isPointerSelect = false;
		isPointerRelease = false;
		isPointerEnd = false;
		if (currentScreen == MapScr.gI())
		{
			isPointerClick = true;
		}
		pxLast = x / mGraphics.zoomLevel;
		pyLast = y / mGraphics.zoomLevel;
		px = x / mGraphics.zoomLevel;
		py = y / mGraphics.zoomLevel;
	}

	public void pointerReleased(int x, int y)
	{
		if (!isPointerMove && !isPointerEnd && Math.abs(px - pxLast) <= 5 && Math.abs(py - pyLast) <= 5)
		{
			isPointerSelect = true;
		}
		clearKeyHold();
		clearKeyPressed();
		isPointerDown = false;
		isPointerRelease = true;
		isPointerMove = false;
		isPointerClick = true;
		isPointerEnd = false;
		px = x / mGraphics.zoomLevel;
		py = y / mGraphics.zoomLevel;
	}

	public static void clearKeyPressed()
	{
		isPointerRelease = false;
		isPointerDown = false;
		for (int i = 0; i < keyMyPressed.Length; i++)
		{
			keyMyPressed[i] = false;
		}
	}

	public static void clearKeyPressed(int keycode)
	{
		isPointerRelease = false;
		isPointerDown = false;
		keyMyPressed[keycode] = false;
	}

	public static void clearKeyHold()
	{
		isPointerRelease = false;
		isPointerDown = false;
		for (int i = 0; i < keyMyHold.Length; i++)
		{
			keyMyHold[i] = false;
		}
	}

	public static void clearKeyHold(int keycode)
	{
		isPointerRelease = false;
		isPointerDown = false;
		keyMyHold[keycode] = false;
	}

	public static void clearKeyReleased()
	{
		isPointerDown = false;
		isPointerRelease = false;
		for (int i = 0; i < keyMyReleased.Length; i++)
		{
			keyMyReleased[i] = false;
		}
	}

	public static void clearAll()
	{
		clearKeyHold();
		clearKeyPressed();
		clearKeyReleased();
		isPointerSelect = false;
		isPointerMove = false;
		isPointerClick = false;
		isPointerDown = false;
	}

	public static void connect()
	{
		if (Session_ME.gI().isConnected())
		{
			return;
		}
		if (LoginScreen.ip != null)
		{
			Session_ME.gI().connect(LoginScreen.ip, 19129);
			return;
		}
		string host = listServer[IndexServer, 1];
		int port = portServer[IndexServer];
		if (IndoServer.isIndoSv && IndexServer == 1)
		{
			port = 19130;
		}
		Session_ME.gI().connect(host, port);
	}

	public void getSize()
	{
		w = TemCanvas.wMain;
		h = TemCanvas.hMain;
		hw = w / 2;
		hh = h / 2;
	}

	public static int getSecond()
	{
		return (int)(mSystem.currentTimeMillis() / 1000);
	}

	public static bool isPointer(int x, int y, int w, int h)
	{
		if (!isPointerDown && !isPointerRelease)
		{
			return false;
		}
		return isPoint(x, y, w, h);
	}

	public static bool isPointSelect(int x, int y, int w, int h)
	{
		if (!isPointerSelect)
		{
			return false;
		}
		return isPoint(x, y, w, h);
	}

	public static bool isPoint(int x, int y, int w, int h)
	{
		if (px >= x && px <= x + w && py >= y && py <= y + h)
		{
			return true;
		}
		return false;
	}

	public static bool isPointLast(int x, int y, int w, int h)
	{
		if (pxLast >= x && pxLast <= x + w && pyLast >= y && pyLast <= y + h)
		{
			return true;
		}
		return false;
	}

	public static bool keyMove(int Dir)
	{
		if (Main.isPC)
		{
			if (keyMyHold[Dir])
			{
				return true;
			}
		}
		else
		{
			switch (Dir)
			{
				case 1:
					if (keyMyHold[30] || keyMyHold[2] || keyMyHold[22])
					{
						return true;
					}
					break;
				case 0:
					if (keyMyHold[38] || keyMyHold[8] || keyMyHold[28])
					{
						return true;
					}
					break;
				case 2:
					if (keyMyHold[39] || keyMyHold[4] || keyMyHold[24])
					{
						return true;
					}
					break;
				case 3:
					if (keyMyHold[40] || keyMyHold[6] || keyMyHold[26])
					{
						return true;
					}
					break;
			}
		}
		return false;
	}

	public void clearKeyMove(int Dir)
	{
		if (Main.isPC)
		{
			keyMyHold[Dir] = false;
			return;
		}
		switch (Dir)
		{
			case 1:
				keyMyHold[30] = false;
				keyMyHold[2] = false;
				keyMyHold[22] = false;
				break;
			case 0:
				keyMyHold[38] = false;
				keyMyHold[8] = false;
				keyMyHold[28] = false;
				break;
			case 2:
				keyMyHold[40] = false;
				keyMyHold[4] = false;
				keyMyHold[24] = false;
				break;
			case 3:
				keyMyHold[39] = false;
				keyMyHold[6] = false;
				keyMyHold[26] = false;
				break;
		}
	}

	public static bool isKeyUp()
	{
		return keyMyHold[31];
	}

	public static bool isKeyDown()
	{
		return keyMyHold[32];
	}

	public static void releaseKeyUp()
	{
		keyMyHold[31] = false;
	}

	public static void releaseKeyDown()
	{
		keyMyHold[32] = false;
	}

	public void updateCountTick()
	{
		if (countTips != 0L && mSystem.currentTimeMillis() - countTips >= 600000)
		{
			iTips = CRes.random(T.mTips.Length);
			addInfoCharServer(T.Tips + T.mTips[iTips]);
		}
	}

	public static void resetTip()
	{
		countTips = mSystem.currentTimeMillis();
		iTips = 0;
	}
}
