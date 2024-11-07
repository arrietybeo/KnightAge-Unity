using System;
using System.IO;

public class LoginScreen : MainScreen
{
	public const sbyte LOGIN = 0;

	public const sbyte USER_INFO = 1;

	public const sbyte SERVER_INFO = 2;

	public int hpaint;

	public int section;

	public int hitem = 10;

	private int hBorder;

	private int wBorder;

	private int yBorder;

	public static bool isAutoLogin = true;

	public static bool isPaintHotLine = true;

	public static sbyte isServer = 0;

	public static TField tfusername;

	public static TField tfpassword;

	public static string username = string.Empty;

	public static string password = string.Empty;

	public static int hShowServer = 0;

	public static sbyte indexInfoLogin = 1;

	private static string[] server = new string[3] { "anh Trí", "ku Ngân", "Server" };

	public static mImage logo;

	public static string userSv;

	private string[] strhelpregister;

	public static string ip = null;

	private InputDialog input;

	public static int MusicRandom = 0;

	public static int wLine;

	private iCommand cmdLogin;

	private iCommand cmdThoat;

	private iCommand cmdChooseServer;

	private iCommand cmdQuickPlay;

	private iCommand cmdNewPlay;

	private iCommand cmdPlay;

	private iCommand cmdUserAccount;

	private iCommand cmdOK;

	private iCommand cmdSubMenu;

	private iCommand cmdChangePassword;

	private iCommand cmdGraphicsSetting;

	private iCommand cmdSoundSetting;

	private iCommand cmdNokiaInfo;

	private iCommand cmdHotLine;

	private int t;

	public static string strip;

	private int yLoginBox;

	private int wBoxText;

	private int hBoxText;

	private bool isPaintLogo = true;

	public LoginScreen()
	{
		init();
	}

	public new void Show()
	{
		try
		{
			BackGround.init();
			mSound.stopSoundAll();
			MusicRandom = CRes.random(2);
			if (MusicRandom == 0)
			{
				mSound.playMus(0, mSound.volumeMusic, true);
			}
			else
			{
				mSound.playMus(1, mSound.volumeMusic, true);
			}
			base.Show();
			if (isAutoLogin)
			{
				sbyte[] array = CRes.loadRMS("local_server");
				if (array != null)
				{
					DataInputStream dataInputStream = new DataInputStream(array);
					try
					{
						isServer = dataInputStream.readByte();
					}
					catch (Exception)
					{
					}
				}
				sbyte[] array2 = CRes.loadRMS("user_pass");
				if (array2 != null)
				{
					try
					{
						loadUser_Pass();
					}
					catch (Exception)
					{
					}
					GameCanvas.connect();
					if (username.Length > 0)
					{
						login(username, password);
					}
					else if (tfusername.getText().Length > 0)
					{
						login(tfusername.getText(), tfpassword.getText());
					}
				}
			}
			else
			{
				sbyte[] array3 = CRes.loadRMS("user_pass");
				if (array3 != null)
				{
					try
					{
						loadUser_Pass();
					}
					catch (Exception)
					{
					}
				}
			}
			isAutoLogin = false;
			section = 0;
			setScreen();
		}
		catch (Exception)
		{
		}
	}

	private void login(string name, string pass)
	{
		if (tfusername.getText().CompareTo("doiip") == 0 && tfpassword.getText().Equals("master"))
		{
			GameCanvas.linkIP = "http://knightageonline.com/srvip2/";
			GameCanvas.start_Ok_Dialog("Da doi ip thanh cong");
			return;
		}
		GlobalService.gI().login(name, pass, GameMidlet.version, "0", "0", "0", -1, -1);
		if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
		{
			GlobalService.gI().send_cmd_server(61);
		}
	}

	public string catUsername(string url)
	{
		if (url.Contains("ip"))
		{
			url = url.Substring(2);
		}
		return url;
	}

	public void init()
	{
		if (GameCanvas.h < 240)
		{
			hpaint = 10;
		}
		yBorder = GameCanvas.hh - 30 + hpaint;
		if (GameCanvas.h - yBorder < 160)
		{
			yBorder = GameCanvas.h - 160 + hpaint + 20;
		}
		if (GameCanvas.isTouch)
		{
			wBorder = GameCanvas.hw + 40;
			hitem = 10;
			yLoginBox = GameCanvas.hh - 50;
		}
		else
		{
			wBorder = GameCanvas.w / 2;
		}
		wLine = mFont.tahoma_7_yellow.getWidth(T.HotLine);
		if (IndoServer.isIndoSv || Usa_Server.isUsa_server)
		{
			isPaintHotLine = false;
		}
		if (GameCanvas.langServer[GameCanvas.IndexServer] != 0)
		{
			isPaintHotLine = false;
		}
		if (wBorder < 130)
		{
			wBorder = 130 + GameCanvas.hw / 2;
		}
		if (GameCanvas.isTouch)
		{
			tfusername = new TField(GameCanvas.hw - wBorder / 2 + 15, yLoginBox + hitem + hitem / 2, wBorder - 30);
			tfpassword = new TField(GameCanvas.hw - wBorder / 2 + 15, yLoginBox + hitem * 2 + hitem / 2 + tfusername.height, wBorder - 30, 30);
			tfpassword.showSubTextField = false;
			tfusername.showSubTextField = false;
		}
		else
		{
			tfusername = new TField(GameCanvas.hw - wBorder / 2 + 15, yBorder + hitem + hitem / 2, wBorder - 30);
			tfpassword = new TField(GameCanvas.hw - wBorder / 2 + 15, yBorder + hitem * 2 + hitem / 2 + tfusername.height, wBorder - 30);
		}
		tfusername.setStringNull(T.username);
		tfpassword.setStringNull(T.password);
		tfpassword.setIputType(TField.INPUT_TYPE_PASSWORD);
		bool flag = true;
		if (GameCanvas.isTouch && !Main.isPC)
		{
			flag = false;
		}
		if (flag)
		{
			tfusername.setFocus(true);
		}
		cmdLogin = new iCommand(T.choi_daco_TK, 0);
		cmdQuickPlay = new iCommand(T.choimoi, 1);
		cmdNewPlay = new iCommand(T.choimoi, 1);
		cmdOK = new iCommand("OK", 2);
		cmdSubMenu = new iCommand(T.menu, 3);
		cmdPlay = new iCommand(T.choi_daco_TK, 4);
		cmdUserAccount = new iCommand(T.daco_TK, 5, this);
		cmdChooseServer = new iCommand(T.maychu + ": " + GameCanvas.listServer[GameCanvas.IndexServer, 0], 6, this);
		cmdChangePassword = new iCommand(T.quenpass, 7, this);
		cmdGraphicsSetting = new iCommand(T.cauhinhthap, 8, this);
		cmdSoundSetting = new iCommand(T.SetMusic, 9, this);
		cmdHotLine = new iCommand(T.HotLine, 23, this);
		if (TemMidlet.currentIAPStore == TemMidlet.NOKIA_STORE)
		{
			cmdNokiaInfo = new iCommand(T.about, 21, this);
		}
		cmdThoat = new iCommand(T.exit + " Game", -1, this);
		if (GameCanvas.h < 240)
		{
			hpaint = -15;
		}
		strhelpregister = mFont.tahoma_7_black.splitFontArray(T.texthelpRegister, wBorder - 20);
		setHeightBorder(false);
	}

	public void setCaptionCmd()
	{
		tfusername.setStringNull(T.username);
		tfpassword.setStringNull(T.password);
		tfusername.cmdClear.caption = T.del;
		tfpassword.cmdClear.caption = T.del;
		cmdLogin.caption = T.choi_daco_TK;
		cmdQuickPlay.caption = T.choimoi;
		cmdNewPlay.caption = T.choimoi;
		cmdPlay.caption = T.choi_daco_TK;
		cmdOK.caption = "OK";
		if (!GameCanvas.isTouch)
		{
			cmdSubMenu.caption = T.menu;
		}
		cmdThoat.caption = T.exit;
		cmdChangePassword.caption = T.quenpass;
		cmdGraphicsSetting.caption = T.cauhinhthap;
		cmdSoundSetting.caption = T.SetMusic;
		setCmdCap();
		if (TemMidlet.currentIAPStore == TemMidlet.NOKIA_STORE)
		{
			cmdNokiaInfo.caption = T.about;
		}
		strhelpregister = mFont.tahoma_7_black.splitFontArray(T.texthelpRegister, wBorder - 20);
	}

	public void setPosCmd()
	{
		int num = yBorder + hBorder - iCommand.hButtonCmd / 2 - hitem;
		if (num + iCommand.hButtonCmd / 2 > GameCanvas.h)
		{
			num = GameCanvas.h - iCommand.hButtonCmd / 2;
		}
		int num2 = yLoginBox + hBorder - iCommand.hButtonCmd / 2 - hitem;
		if (num2 + iCommand.hButtonCmd / 2 > GameCanvas.h)
		{
			num2 = GameCanvas.h - iCommand.hButtonCmd / 2;
		}
		wBoxText = 160;
		hBoxText = 25;
		if (GameCanvas.isTouch)
		{
			cmdOK.setPos(GameCanvas.hw - iCommand.wButtonCmd / 2 - 5, num2, null, cmdOK.caption);
			int x = tfpassword.x + tfpassword.width - AvMain.fraFogetPass.frameWidth / 2 - 10;
			cmdChangePassword.setPos(x, num2 - 37, AvMain.fraFogetPass, cmdChangePassword.caption);
			cmdChangePassword.setFraCaption(AvMain.fraFogetPass, 2, 0);
			cmdNewPlay.setPos(GameCanvas.hw + iCommand.wButtonCmd / 2 + 5, num2, null, cmdNewPlay.caption);
			cmdPlay.setPos_BoxText(GameCanvas.hw - wBoxText / 2, num - 80, null, cmdPlay.caption, wBoxText, hBoxText);
			cmdLogin.setPos_BoxText(GameCanvas.hw - wBoxText / 2, num - 80, null, cmdLogin.caption, wBoxText, hBoxText);
			cmdQuickPlay.setPos_BoxText(GameCanvas.hw - wBoxText / 2, num - 80, null, cmdQuickPlay.caption, wBoxText, hBoxText);
			cmdUserAccount.setPos_BoxText(GameCanvas.hw - wBoxText / 2, num - 45, null, cmdUserAccount.caption, wBoxText, hBoxText);
			cmdChooseServer.setPos_BoxText(GameCanvas.hw - wBoxText / 2, num - 10, null, cmdChooseServer.caption, wBoxText, hBoxText);
		}
		else
		{
			wBoxText = 140;
			cmdUserAccount.setPos_BoxText(GameCanvas.hw - wBoxText / 2, num - 60, null, cmdUserAccount.caption, wBoxText, hBoxText);
			cmdChooseServer.setPos_BoxText(GameCanvas.hw - wBoxText / 2, num - 20, null, cmdChooseServer.caption, wBoxText, hBoxText);
		}
	}

	public override void paint(mGraphics g)
	{
		BackGround.paint(g);
		BackGround.paint_StaticCloud(g);
		if (isPaintLogo)
		{
			if (section != 1 && logo != null)
			{
				if (GameCanvas.isTouch)
				{
					g.drawImage(logo, GameCanvas.hw, GameCanvas.hh - GameCanvas.hh / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(logo, GameCanvas.hw, GameCanvas.hh - 60 - GameCanvas.hh / 8, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			BackGround.paint_CloudOnLogo(g);
			BackGround.paintLight(g);
			switch (section)
			{
			case 0:
				cmdUserAccount.paintbutton(g, cmdUserAccount.xCmd, cmdUserAccount.yCmd);
				cmdChooseServer.paintbutton(g, cmdChooseServer.xCmd, cmdChooseServer.yCmd);
				cmdUserAccount.paintCaptionImage(g, cmdUserAccount.xCmd, cmdUserAccount.yCmd - 6, 2);
				cmdChooseServer.paintCaptionImage(g, cmdChooseServer.xCmd, cmdChooseServer.yCmd - 6, 2);
				break;
			case 1:
				if (GameCanvas.isTouch)
				{
					AvMain.paintTabNew(g, GameCanvas.hw - wBorder / 2, yLoginBox - 5, wBorder, hBorder + 5, true, 14);
				}
				else
				{
					AvMain.paintTabNew(g, GameCanvas.hw - wBorder / 2, yBorder - 5, wBorder, hBorder + 5, true, 14);
				}
				tfusername.paint(g);
				tfpassword.paint(g);
				cmdChangePassword.paintImage(g, cmdChangePassword.xCmd, cmdChangePassword.yCmd - 6, 3, 1);
				break;
			}
		}
		GameCanvas.resetTrans(g);
		if (!mSystem.isIP_TrucTiep)
		{
			mFont.tahoma_7_yellow.drawString(g, "version: " + GameMidlet.version, GameCanvas.w - 2, 2, 1, mGraphics.isFalse);
		}
		else
		{
			mFont.tahoma_7_yellow.drawString(g, "in-house test version: " + GameMidlet.version, GameCanvas.w - 2, 2, 1, mGraphics.isFalse);
		}
		if (PaintInfoGameScreen.paint18plush == 0)
		{
			g.drawImage(AvMain.img18Plus, 0, 0, 0, mGraphics.isFalse);
		}
		else if (PaintInfoGameScreen.paint18plush == 1)
		{
			PaintInfoGameScreen.paintinfo18plush(g);
		}
		if (isPaintHotLine)
		{
			mFont.tahoma_7_yellow.drawString(g, T.HotLine, GameCanvas.w, 15, 1, mGraphics.isFalse);
			g.setColor(16514362);
			g.fillRect(GameCanvas.w - wLine + (mSystem.isIphone ? 14 : 0), 25, wLine, 1, mGraphics.isFalse);
		}
		base.paint(g);
	}

	public override void update()
	{
		if (hShowServer < 20)
		{
			hShowServer += 4;
			if (hShowServer > 20)
			{
				hShowServer = 20;
			}
		}
		if (section != 0)
		{
			tfusername.update();
			tfpassword.update();
		}
		else
		{
			setCmdCap();
		}
		if (GameCanvas.menu2.isShowMenu)
		{
			isPaintLogo = false;
		}
		else
		{
			isPaintLogo = true;
		}
		BackGround.updateSky();
	}

	public override void updatekey()
	{
		if (GameCanvas.isKeyDown())
		{
			if (tfusername.isFocusedz())
			{
				tfusername.setFocus(false);
				bool flag = true;
				if (GameCanvas.isTouch && !Main.isPC)
				{
					flag = false;
				}
				if (flag)
				{
					tfpassword.setFocus(true);
				}
			}
			else if (tfpassword.isFocusedz())
			{
				bool flag2 = true;
				if (GameCanvas.isTouch && !Main.isPC)
				{
					flag2 = false;
				}
				if (flag2)
				{
					tfusername.setFocus(true);
				}
				tfpassword.setFocus(false);
			}
			GameCanvas.releaseKeyDown();
			GameCanvas.clearKeyHold(8);
		}
		else if (GameCanvas.isKeyUp())
		{
			if (tfusername.isFocusedz())
			{
				tfusername.setFocus(false);
				tfpassword.setFocus(true);
			}
			else if (tfpassword.isFocusedz())
			{
				tfusername.setFocus(true);
				tfpassword.setFocus(false);
			}
			GameCanvas.releaseKeyUp();
			GameCanvas.clearKeyHold(2);
		}
		if (!GameCanvas.isTouch)
		{
			if (tfusername.isFocusedz())
			{
				right = tfusername.setCmdClear();
			}
			else if (tfpassword.isFocusedz())
			{
				right = tfpassword.setCmdClear();
			}
			else
			{
				right = null;
			}
		}
		base.updatekey();
	}

	public override void updatePointer()
	{
		if (section != 0)
		{
			tfusername.updatePoiter();
			tfpassword.updatePoiter();
		}
		if (section == 1)
		{
			cmdChangePassword.updatePointer();
		}
		else if (section == 0)
		{
			cmdChooseServer.updatePointer();
			cmdUserAccount.updatePointer();
		}
		else if (section != 2)
		{
		}
		base.updatePointer();
	}

	public override void keyPress(int keyCode)
	{
		if (tfusername.isFocusedz())
		{
			tfusername.keyPressed(keyCode);
		}
		else if (tfpassword.isFocusedz())
		{
			tfpassword.keyPressed(keyCode);
		}
		base.keyPress(keyCode);
	}

	public static void saveUser_Pass()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(tfusername.getText());
			dataOutputStream.writeUTF(tfpassword.getText());
			CRes.saveRMS("user_pass", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public static void saveIndexServer()
	{
		try
		{
			sbyte[] data = new sbyte[1] { GameCanvas.IndexServer };
			CRes.saveRMS("isIndexServer", data);
		}
		catch (Exception)
		{
		}
	}

	public static void loadUser_Pass()
	{
		sbyte[] array = CRes.loadRMS("user_pass");
		if (array != null)
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			tfusername.setText(dataInputStream.readUTF());
			tfpassword.setText(dataInputStream.readUTF());
			string text = tfusername.getText();
			if (text.Length >= 10)
			{
				text = text.Substring(0, 10);
			}
			if (text.CompareTo("knightauto") == 0)
			{
				username = tfusername.getText();
				password = tfpassword.getText();
				tfusername.setText(string.Empty);
				tfpassword.setText(string.Empty);
			}
		}
	}

	public void doMenu()
	{
		mVector mVector3 = new mVector("LoginScreen menu");
		if (section == 0)
		{
			if (!GameCanvas.isTouch)
			{
				mVector3.addElement(cmdUserAccount);
				mVector3.addElement(cmdChooseServer);
				mVector3.addElement(cmdChangePassword);
				mVector3.addElement(cmdHotLine);
			}
			if (GameCanvas.lowGraphic)
			{
				cmdGraphicsSetting.caption = T.off + T.cauhinhthap;
			}
			else
			{
				cmdGraphicsSetting.caption = T.on + T.cauhinhthap;
			}
			if (TemMidlet.DIVICE == 0)
			{
				mVector3.addElement(cmdGraphicsSetting);
			}
			else
			{
				mVector3.addElement(cmdSoundSetting);
			}
			if (TemMidlet.currentIAPStore == TemMidlet.NOKIA_STORE)
			{
				mVector3.addElement(cmdNokiaInfo);
			}
		}
		else if (section != 1 && section != 2)
		{
		}
		mVector3.addElement(cmdThoat);
		GameCanvas.menu2.startAt(mVector3, 2, T.menuChinh, false, null);
	}

	public void setScreen()
	{
		switch (section)
		{
		case 0:
			if (GameCanvas.h < 240)
			{
				hpaint = 10;
			}
			tfusername.setFocus(Main.isPC ? true : false);
			tfpassword.setFocus(false);
			if (!GameCanvas.isTouch)
			{
				left = cmdSubMenu;
			}
			else
			{
				left = null;
			}
			if (tfusername.getText().Length > 0)
			{
				center = cmdLogin;
			}
			else if (username.Length > 0)
			{
				center = cmdPlay;
			}
			else
			{
				center = cmdQuickPlay;
			}
			break;
		case 1:
			if (!GameCanvas.isTouch)
			{
				tfusername.setFocus(true);
				tfpassword.setFocus(false);
			}
			left = cmdNewPlay;
			center = cmdOK;
			setHeightBorder(false);
			if (GameCanvas.h < 240)
			{
				hpaint = 10;
			}
			hShowServer = 0;
			break;
		case 2:
			left = null;
			center = null;
			break;
		}
	}

	public void setHeightBorder(bool istext)
	{
		hBorder = tfusername.height * 2 + hitem * 4;
		if (GameCanvas.isTouch)
		{
			hBorder += iCommand.hButtonCmd + 3;
		}
		else
		{
			hBorder += GameCanvas.hh / 8;
		}
		if (istext)
		{
			hBorder += strhelpregister.Length * GameCanvas.hText;
		}
		setPosCmd();
	}

	protected void doRegister()
	{
		mSystem.outz("Dzo day doi mat khau");
		if (tfusername.getText().Equals(string.Empty))
		{
			GameCanvas.start_Ok_Dialog(T.chuanhapsdt);
			return;
		}
		if (tfpassword.getText().Equals(string.Empty))
		{
			GameCanvas.start_Ok_Dialog(T.chuanhapmk);
			return;
		}
		if (tfusername.getText().Length < 5)
		{
			GameCanvas.start_Ok_Dialog(T.nameMin6char);
			return;
		}
		int num = 0;
		string text = null;
		try
		{
			long num2 = long.Parse(tfusername.getText());
			if (tfusername.getText().Length < 8 || tfusername.getText().Length > 12 || (!tfusername.getText().StartsWith("0") && tfusername.getText().StartsWith("84")))
			{
				text = T.sdtkhople;
			}
			num = 1;
		}
		catch (Exception)
		{
			if (tfusername.getText().IndexOf("@") == -1 || tfusername.getText().IndexOf(".") == -1)
			{
				text = T.emailkhople;
			}
			num = 0;
		}
		if (text != null)
		{
			GameCanvas.start_Ok_Dialog(text);
		}
	}

	public new void keyBack()
	{
		cmdThoat.perform();
	}

	public override void commandTab(int index, int sub)
	{
		switch (index)
		{
		case 0:
			GameCanvas.connect();
			login(tfusername.getText(), tfpassword.getText());
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isMelogin = false;
			GlobalLogicHandler.isDisConect = false;
			MsgDialog.isAutologin = false;
			break;
		case 1:
			GameCanvas.connect();
			login("1", "1");
			break;
		case 2:
			section = 0;
			setScreen();
			break;
		case 3:
			doMenu();
			break;
		case 4:
			GameCanvas.connect();
			login(username, password);
			break;
		}
	}

	public override void commandMenu(int index, int sub)
	{
		base.commandMenu(index, sub);
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			GameCanvas.start_Left_Dialog(T.hoithoat, new iCommand(T.exit, 10, this));
			break;
		case 5:
			section = 1;
			setScreen();
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			GlobalLogicHandler.isMelogin = false;
			MsgDialog.isAutologin = false;
			break;
		case 6:
			GameCanvas.listIp = new List_Ip_Server_Screen();
			GameCanvas.listIp.Show();
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isMelogin = false;
			GlobalLogicHandler.isDisConect = false;
			MsgDialog.isAutologin = false;
			break;
		case 7:
		{
			string empty = string.Empty;
			GameCanvas.start_Download_Dialog(link: IndoServer.isIndoSv ? "http://ksatriaonline.indonaga.com/forum/app/index.php?for=event&do=changepass" : ((GameCanvas.IndexServer != mSystem.INDEX_SV_GLOBAL) ? "http://forum.knightageonline.com/app/index.php?for=event&do=resetpass&lang=store" : "http://forum.knightageonline.com/app/index.php?for=event&do=resetpass&lang=en"), str: T.lienhe);
			break;
		}
		case 8:
		{
			GameCanvas.lowGraphic = !GameCanvas.lowGraphic;
			sbyte b = (sbyte)(GameCanvas.lowGraphic ? 1 : 0);
			sbyte[] data = new sbyte[1] { b };
			try
			{
				CRes.saveRMS("isLowDevice", data);
			}
			catch (Exception)
			{
			}
			break;
		}
		case 9:
			GameCanvas.start_Volume_Dialog();
			break;
		case 10:
			GameMidlet.destroy();
			break;
		case 21:
			GameCanvas.start_Left_Dialog(T.textabout1 + GameMidlet.version + "\n" + T.textabout2, new iCommand(T.nokiaprivacy, 22, this));
			break;
		case 22:
			TemMidlet.openUrl("http://teamobi.com/terms.htm");
			break;
		case 23:
			TemMidlet.instance.call(T.numberHotLine);
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public static void loadVersionGame()
	{
		sbyte[] array = CRes.loadRMS("versionGame");
		if (array != null)
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			string text = dataInputStream.readUTF();
			if (!text.Equals(GameMidlet.version))
			{
				Rms.deleteAllRecord();
			}
		}
	}

	public static void saveversionGame()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(GameMidlet.version);
			CRes.saveRMS("versionGame", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai  save versionGame!!! : " + ex.ToString());
		}
	}

	private void setCmdCap()
	{
		if (cmdChooseServer.caption != T.maychu + ": " + GameCanvas.listServer[GameCanvas.IndexServer, 0])
		{
			cmdChooseServer.caption = T.maychu + ": " + GameCanvas.listServer[GameCanvas.IndexServer, 0];
		}
		if (GameCanvas.isTouch)
		{
			if (tfusername.getText().Length > 0)
			{
				if (cmdUserAccount.caption != T.doi_TK_khac)
				{
					cmdUserAccount.caption = T.doi_TK_khac;
				}
				if (tfusername.getText().Length > 13)
				{
					string empty = string.Empty;
					empty = (tfusername.getText().Equals(userSv) ? T.choimoi : (T.choi_daco_TK + ": " + tfusername.getText().Substring(0, 12) + "..."));
					if (cmdLogin.caption != empty)
					{
						cmdLogin.caption = empty;
					}
					if (cmdPlay.caption != empty)
					{
						cmdPlay.caption = empty;
					}
				}
				else if (cmdLogin.caption != T.choi_daco_TK + ": " + tfusername.getText())
				{
					cmdLogin.caption = T.choi_daco_TK + ": " + tfusername.getText();
					cmdPlay.caption = T.choi_daco_TK + ": " + tfusername.getText();
				}
			}
			else if (username.Length > 0)
			{
				if (cmdUserAccount.caption != T.doi_TK_khac)
				{
					cmdUserAccount.caption = T.doi_TK_khac;
				}
			}
			else if (cmdUserAccount.caption != T.daco_TK)
			{
				cmdUserAccount.caption = T.daco_TK;
			}
		}
		else if (tfusername.getText().Length > 0)
		{
			if (tfusername.getText().Length > 8)
			{
				string text = T.username + ": " + tfusername.getText().Substring(0, 8) + "...";
				if (cmdUserAccount.caption != text)
				{
					cmdUserAccount.caption = text;
				}
			}
			else if (cmdUserAccount.caption != T.username + ": " + tfusername.getText())
			{
				cmdUserAccount.caption = T.username + ": " + tfusername.getText();
			}
		}
		else if (username.Length > 0)
		{
			if (cmdUserAccount.caption != T.doi_TK_khac)
			{
				cmdUserAccount.caption = T.doi_TK_khac;
			}
		}
		else if (cmdUserAccount.caption != T.daco_TK)
		{
			cmdUserAccount.caption = T.daco_TK;
		}
	}

	public void checkLoginAgain(sbyte indexSv)
	{
		try
		{
			username = tfusername.getText();
			password = tfpassword.getText();
			if (username.Length > 0)
			{
				center = cmdPlay;
			}
			else
			{
				center = cmdQuickPlay;
			}
			sbyte[] array = CRes.loadRMS("isIndexServer");
			sbyte b = indexSv;
			if (array != null)
			{
				b = array[0];
			}
			if (b != indexSv)
			{
				return;
			}
			sbyte[] array2 = CRes.loadRMS("user_pass");
			if (array2 != null)
			{
				try
				{
					loadUser_Pass();
				}
				catch (IOException)
				{
				}
				GameCanvas.connect();
				if (username.Length > 0)
				{
					login(username, password);
				}
				else if (tfusername.getText().Length > 0)
				{
					login(tfusername.getText(), tfpassword.getText());
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
