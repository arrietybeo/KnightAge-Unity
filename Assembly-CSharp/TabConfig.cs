public class TabConfig : MainTabNew
{
	public static TabConfig me;

	private mVector vecConfig = new mVector("TabConfig vecConfig");

	private int w2;

	private int wFocus;

	private int idSelect;

	private int hItem;

	private iCommand cmdSelect;

	private iCommand cmdlogout;

	private iCommand cmdSetAuto;

	private iCommand cmdHelp;

	private iCommand cmdSetting;

	private iCommand cmdChucNang;

	private iCommand cmdShowFullMini;

	private iCommand cmdChatWorld;

	private iCommand cmdDiamond;

	private iCommand cmdDiamondIOS;

	private iCommand cmdDiamondIOSVND;

	private iCommand cmdSoundSetting;

	private iCommand cmdVongquay;

	private iCommand cmdkhac;

	private iCommand cmdHieuUng;

	public static iCommand cmdEvent;

	public static iCommand cmdKeypad;

	public static iCommand cmdShowClan;

	public static iCommand cmdXuongNgua;

	public static iCommand cmdChangeScreen;

	private MainList list;

	private InputDialog inputWorld;

	public string[][] itemID = new string[2][]
	{
		new string[6] { "pack_24_gems", "pack_84_gems", "pack_150_gems", "pack_350_gems", "pack_1000_gems", "pack_2500_gems" },
		new string[6] { "Buy 24 Gem ($0.99)", "Buy 84 Gem ($2.99)", "Buy 150 Gem ($4.99)", "Buy 350 Gem ($9.99)", "Buy 1.000 Gem ($24.99)", "Buy 2.500 Gem ($49.99)" }
	};

	private string textWorld = string.Empty;

	public TabConfig(string name, mVector vec, sbyte type)
	{
		typeTab = type;
		nameTab = name;
		vecConfig = vec;
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
		w2 = MainTabNew.wblack / 2;
		wFocus = MainTabNew.wblack - MainTabNew.wOne5 * 2;
		if (wFocus > 130)
		{
			wFocus = 130;
		}
		hItem = GameCanvas.hCommand;
		if (GameCanvas.isTouch)
		{
			hItem = 28;
		}
		cmdBack = new iCommand(T.back, -1, this);
		cmdSelect = new iCommand(T.select, 0, this);
		cmdlogout = new iCommand(T.logout, 4, this);
		cmdKeypad = new iCommand(T.chuyensang, 7, this);
		cmdHelp = new iCommand(T.help, 10, this);
		cmdSetting = new iCommand(T.auto, 11, this);
		cmdChucNang = new iCommand(T.chucnang, 12, this);
		cmdEvent = new iCommand(T.mevent, 13, this);
		cmdShowClan = new iCommand(T.clan, 14, this);
		if (Main.isPC)
		{
			cmdChangeScreen = new iCommand(T.changeScrennSmall, 20, this);
			if (Main.level == 1)
			{
				cmdChangeScreen.caption = T.normalScreen;
			}
			else
			{
				cmdChangeScreen.caption = ((mGraphics.zoomLevel != 1) ? T.changeScrennSmall : T.normalScreen);
			}
		}
		cmdShowFullMini = new iCommand(T.minimap, 15, this);
		cmdChatWorld = new iCommand(T.textkenhthegioi, 16, this);
		cmdDiamond = new iCommand(T.naptien + " " + T.gem + (Main.IphoneVersionApp ? " (Buy gem)" : string.Empty), 19, this);
		cmdDiamondIOSVND = new iCommand(T.naptien + " card", 22, this);
		cmdDiamondIOS = new iCommand("Buy on the App Store", 23, this);
		cmdXuongNgua = new iCommand(T.textXuongNgua + string.Empty, 37, this);
		if (mSound.isEnableSound)
		{
			cmdSoundSetting = new iCommand(T.SetMusic, 36, this);
		}
		cmdVongquay = new iCommand(T.annguoichoi, 40, this);
		cmdkhac = new iCommand(T.khac, 45, this);
		cmdHieuUng = new iCommand(T.tathieuung, 46, this);
		init();
		me = this;
	}

	public void exit()
	{
		GameCanvas.start_Left_Dialog(T.hoithoat, new iCommand(T.yes, 6, this));
	}

	public override void init()
	{
		mVector mVector3 = new mVector("TabConfig mcmdTest");
		if (GameCanvas.isTouch)
		{
			if (GameScreen.help.Step >= 0)
			{
				mVector3.addElement(GameScreen.gI().cmdEndHelp);
			}
			mVector3.addElement(cmdHelp);
			if (GameScreen.player.myClan != null)
			{
				mVector3.addElement(cmdShowClan);
			}
			if (Player.party != null)
			{
				mVector3.addElement(GameScreen.gI().cmdParty);
			}
			mVector3.addElement(cmdChatWorld);
			if (mSound.isEnableSound)
			{
				mVector3.addElement(cmdSoundSetting);
			}
			if (Main.isPC)
			{
				mVector3.addElement(cmdChangeScreen);
			}
			if (GameScreen.player.typeMount != -1)
			{
				mVector3.addElement(cmdXuongNgua);
			}
		}
		else if (typeTab == MainTabNew.CONFIG)
		{
			string caption = T.off + " " + T.dosat;
			if (GameScreen.player.typePk != 0)
			{
				caption = T.on + " " + T.dosat;
			}
			GameScreen.gI().cmdSetDoSat.caption = caption;
			mVector3.addElement(GameScreen.gI().cmdSetPk);
			mVector3.addElement(GameScreen.gI().cmdSetDoSat);
			mVector3.addElement(cmdSetting);
			if (GameScreen.help.Step >= 0)
			{
				mVector3.addElement(GameScreen.gI().cmdEndHelp);
			}
			mVector3.addElement(cmdHelp);
			if (GameScreen.player.Lv >= 10)
			{
				mVector3.addElement(cmdDiamond);
			}
			mVector3.addElement(cmdlogout);
			if (Main.isPC)
			{
				mVector3.addElement(cmdChangeScreen);
			}
		}
		else if (typeTab == MainTabNew.FUNCTION)
		{
			mVector3.addElement(GameScreen.gI().cmdListFriend);
			cmdEvent.caption = T.mevent;
			if (PaintInfoGameScreen.numMess > 0)
			{
				cmdEvent.caption = T.mevent + "*";
			}
			mVector3.addElement(cmdEvent);
			if (GameScreen.player.myClan != null)
			{
				mVector3.addElement(cmdShowClan);
			}
			if (Player.party != null)
			{
				mVector3.addElement(GameScreen.gI().cmdParty);
			}
			mVector3.addElement(GameScreen.gI().cmdChangeMap);
			mVector3.addElement(cmdShowFullMini);
			mVector3.addElement(cmdChatWorld);
			if (GameScreen.player.typeMount != -1)
			{
				mVector3.addElement(cmdXuongNgua);
			}
		}
		mVector3.addElement(cmdVongquay);
		mVector3.addElement(cmdkhac);
		mVector3.addElement(cmdHieuUng);
		vecConfig = mVector3;
		int num = vecConfig.size() * hItem - MainTabNew.hblack;
		if (num < 0)
		{
			num = 0;
		}
		idSelect = 0;
		if (!GameCanvas.isTouch)
		{
			right = cmdBack;
			left = cmdSelect;
		}
		else
		{
			idSelect = -1;
		}
		list = new MainList(xBegin, yBegin, MainTabNew.wblack, MainTabNew.hblack, hItem, vecConfig.size(), num, idSelect, vecConfig);
		MainScreen.cameraSub.setAll(0, num, 0, 0);
		base.init();
	}

	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		idSelect = 0;
		base.backTab();
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			backTab();
			break;
		case 0:
		{
			if (idSelect <= -1)
			{
				break;
			}
			iCommand iCommand2 = (iCommand)vecConfig.elementAt(idSelect);
			if (iCommand2 != null)
			{
				if (iCommand2.action != null)
				{
					iCommand2.action.perform();
				}
				else if (iCommand2.Pointer != null)
				{
					iCommand2.Pointer.commandPointer(iCommand2.indexMenu, iCommand2.subIndex);
				}
				else
				{
					GameCanvas.currentScreen.commandMenu(iCommand2.indexMenu, iCommand2.subIndex);
				}
			}
			break;
		}
		case 4:
			Main.isExit = true;
			GameScreen.player.resetAction();
			Session_ME.gI().close();
			GameCanvas.login.Show();
			GameScreen.player = new Player(0, 0, "unname", 0, 0);
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			MsgDialog.isAutologin = false;
			break;
		case 6:
			GameMidlet.destroy();
			break;
		case 7:
			PaintInfoGameScreen.isLevelPoint = !PaintInfoGameScreen.isLevelPoint;
			if (Main.isPC)
			{
				PaintInfoGameScreen.isLevelPoint = true;
			}
			MainRMS.setSaveTouch();
			if (PaintInfoGameScreen.isLevelPoint)
			{
				cmdKeypad.caption = T.chuyensang + T.keypad;
			}
			else
			{
				cmdKeypad.caption = T.chuyensang + T.touch;
			}
			GameCanvas.isPointerSelect = false;
			PaintInfoGameScreen.setPosTouch();
			break;
		case 9:
			GlobalService.gI().set_Pk((sbyte)subIndex);
			break;
		case 10:
			GameCanvas.start_Show_Dialog(T.strhelp, T.help);
			break;
		case 11:
			GameScreen.gI().doMenuAuto();
			break;
		case 13:
			GameCanvas.mevent.init();
			GameCanvas.mevent.Show(GameCanvas.currentScreen);
			break;
		case 14:
			if (GameScreen.player.myClan != null)
			{
				GlobalService.gI().ChucNang_Clan(15, GameScreen.player.myClan.IdClan);
				GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			}
			break;
		case 15:
			MiniMapFull_Screen.gI().Show();
			break;
		case 16:
			inputWorld = new InputDialog();
			inputWorld.setinfo(T.nhapnoidung, new iCommand(T.chat, 17, this), false, T.textkenhthegioi);
			inputWorld.tfInput.isnewTF = true;
			newinput.TYPE_INPUT = 2;
			newinput.input.Select();
			newinput.input.ActivateInputField();
			GameCanvas.currentDialog = inputWorld;
			break;
		case 17:
			textWorld = newinput.input.text;
			if (textWorld != null && textWorld.Length > 0)
			{
				GameCanvas.start_Left_Dialog(T.kenhthegioi + " (" + T.phi + TabShopNew.PriceChatWorld + " " + T.gem + ")" + T.noidungnhusau + "\n" + textWorld, new iCommand(T.chat, 18, this));
			}
			break;
		case 18:
			GlobalService.gI().Chat_World(textWorld);
			newinput.input.text = string.Empty;
			newinput.TYPE_INPUT = -1;
			newinput.input.DeactivateInputField();
			GameCanvas.end_Dialog();
			break;
		case 19:
		{
			if (!Main.IphoneVersionApp)
			{
				GlobalService.gI().send_cmd_server(-56);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
				break;
			}
			mVector mVector7 = new mVector("TabConfig menu");
			mVector7.addElement(cmdDiamondIOSVND);
			mVector7.addElement(cmdDiamondIOS);
			GameCanvas.menu2.startAt(mVector7, 2, "Kiểu nạp tiền", false, null);
			break;
		}
		case 20:
			GameCanvas.start_Left_Dialog(T.changeSizeScreen, new iCommand(T.select, 21, this));
			break;
		case 21:
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
		case 22:
			GlobalService.gI().send_cmd_server(-56);
			GameCanvas.start_Ok_Dialog(T.pleaseWait);
			break;
		case 23:
		{
			mVector mVector6 = new mVector("TabConfig menuItem");
			for (int i = 0; i < itemID[1].Length; i++)
			{
				iCommand o5 = new iCommand(itemID[1][i], 24 + i, this);
				mVector6.addElement(o5);
			}
			GameCanvas.menu2.startAt(mVector6, 2, T.buy + " item", false, null);
			break;
		}
		case 24:
			GameCanvas.start_Left_Dialog(itemID[1][0], new iCommand(T.buy, 24 + itemID[0].Length, this));
			break;
		case 25:
			GameCanvas.start_Left_Dialog(itemID[1][1], new iCommand(T.buy, 25 + itemID[0].Length, this));
			break;
		case 26:
			GameCanvas.start_Left_Dialog(itemID[1][2], new iCommand(T.buy, 26 + itemID[0].Length, this));
			break;
		case 27:
			GameCanvas.start_Left_Dialog(itemID[1][3], new iCommand(T.buy, 27 + itemID[0].Length, this));
			break;
		case 28:
			GameCanvas.start_Left_Dialog(itemID[1][4], new iCommand(T.buy, 28 + itemID[0].Length, this));
			break;
		case 29:
			GameCanvas.start_Left_Dialog(itemID[1][5], new iCommand(T.buy, 29 + itemID[0].Length, this));
			break;
		case 30:
			break;
		case 31:
			break;
		case 32:
			break;
		case 33:
			break;
		case 34:
			break;
		case 35:
			break;
		case 36:
			GameCanvas.start_Volume_Dialog();
			break;
		case 37:
		{
			mVector mVector5 = new mVector("TabConfig vec3");
			mVector5.addElement(new iCommand(T.yes, 38, this));
			mVector5.addElement(new iCommand(T.cancel, 39, this));
			GameCanvas.start_Select_Dialog(T.textHoiXuongNgua, mVector5);
			break;
		}
		case 38:
			GlobalService.gI().useMount(-1);
			closeDialog();
			break;
		case 39:
			closeDialog();
			break;
		case 40:
			if (!GameScreen.isHideOderPlayer)
			{
				mVector mVector3 = new mVector();
				iCommand o = new iCommand(T.yes, 41, this);
				iCommand o2 = new iCommand(T.no, 42, this);
				mVector3.addElement(o);
				mVector3.addElement(o2);
				GameCanvas.start_Select_Dialog(T.hoiannguoichoi, mVector3);
			}
			else
			{
				mVector mVector4 = new mVector();
				iCommand o3 = new iCommand(T.yes, 43, this);
				iCommand o4 = new iCommand(T.no, 42, this);
				mVector4.addElement(o3);
				mVector4.addElement(o4);
				GameCanvas.start_Select_Dialog(T.hoihienguoichoi, mVector4);
			}
			break;
		case 41:
			GameScreen.isHideOderPlayer = true;
			cmdVongquay.caption = T.hiennguoichoi;
			GameCanvas.end_Dialog();
			break;
		case 42:
			GameCanvas.end_Dialog();
			break;
		case 43:
			GameScreen.isHideOderPlayer = false;
			cmdVongquay.caption = T.annguoichoi;
			GameCanvas.end_Dialog();
			break;
		case 45:
			GlobalService.gI().request_LotteryItems(5, 0);
			break;
		case 46:
			if (MainObject.hideEff == 0)
			{
				MainObject.hideEff = 1;
				cmdHieuUng.caption = T.bathieuung;
			}
			else
			{
				MainObject.hideEff = 0;
				cmdHieuUng.caption = T.tathieuung;
			}
			break;
		case 1:
		case 2:
		case 3:
		case 5:
		case 8:
		case 12:
		case 44:
			break;
		}
	}

	public void closeDialog()
	{
		if (GameCanvas.currentDialog != null)
		{
			GameCanvas.currentDialog = null;
		}
		else
		{
			GameCanvas.subDialog = null;
		}
	}

	public override void paint(mGraphics g)
	{
		g.setClip(xBegin, yBegin, MainTabNew.wblack, MainTabNew.hblack);
		g.translate(0, -list.cmx);
		if (MainTabNew.Focus == MainTabNew.INFO && idSelect > -1)
		{
			paintFocus(g);
		}
		for (int i = 0; i < vecConfig.size(); i++)
		{
			iCommand iCommand2 = (iCommand)vecConfig.elementAt(i);
			mFont.tahoma_7b_white.drawString(g, iCommand2.caption, xBegin + w2, yBegin + hItem / 2 + i * hItem - 6, 2, mGraphics.isTrue);
			if (i < vecConfig.size() - 1)
			{
				g.setColor(MainTabNew.color[4]);
				g.fillRect(xBegin + 8, yBegin + (i + 1) * hItem - 1, MainTabNew.wblack - 16, 1, mGraphics.isTrue);
			}
		}
	}

	public void paintFocus(mGraphics g)
	{
		g.setColor(MainTabNew.color[5]);
		g.fillRect(xBegin + w2 - wFocus / 2 - 1, yBegin + idSelect * hItem + hItem / 2 - 11, wFocus + 2, 22, mGraphics.isFalse);
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, xBegin + w2 - wFocus / 2, yBegin + idSelect * hItem + hItem / 2 - 10, wFocus, 20, 4);
			return;
		}
		for (int i = 0; i <= wFocus / 24; i++)
		{
			int x = xBegin + w2 - wFocus / 2 + 24 * i;
			if (i == wFocus / 24)
			{
				x = xBegin + w2 + wFocus / 2 - 24;
			}
			g.drawRegion(MainTabNew.imgTab[8], 0, 0, 24, 20, 0, x, yBegin + idSelect * hItem + hItem / 2 - 10, 0, mGraphics.isFalse);
		}
	}

	public override void update()
	{
		MainScreen.cameraSub.UpdateCamera();
		if (MainTabNew.Focus == MainTabNew.INFO && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.AllInfo)
		{
			list.updateMenu();
			idSelect = list.value;
			if (idSelect >= vecConfig.size())
			{
				idSelect = -1;
				list.value = -1;
			}
		}
	}

	public override void updatekey()
	{
		if (MainTabNew.Focus == MainTabNew.INFO && (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6]))
		{
			MainTabNew.Focus = MainTabNew.TAB;
			idSelect = 0;
			GameCanvas.clearKeyHold(4);
			GameCanvas.clearKeyHold(6);
		}
		base.updatekey();
	}
}
