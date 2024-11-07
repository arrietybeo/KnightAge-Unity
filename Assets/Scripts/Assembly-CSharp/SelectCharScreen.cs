public class SelectCharScreen : MainScreen
{
	private int wRectChar = 50;

	private int hRectChar = 80;

	private int selectChar;

	private int wCenter;

	private int frame;

	public static mVector VecSelectChar = new mVector("PaintInfoGameScr VecSelectChar");

	private int[][] mShadow = mSystem.new_M_Int(3, 2);

	private bool isSelect;

	private bool isSend;

	public static int IDCHAR = -1;

	public static bool isSelectOk = false;

	public static bool reSelect = false;

	public static bool Canselect = false;

	private int[] mplash = new int[0];

	public iCommand cmdExit;

	private int direction;

	public sbyte[] frameicon = new sbyte[4] { 0, 1, 2, 1 };

	public sbyte frameClan;

	private Other_Players objSelect;

	private int timeSelect;

	public SelectCharScreen()
	{
		wCenter = (GameCanvas.w - wRectChar * 3) / 4;
		init();
	}

	public override void Show()
	{
		mSound.stopSoundAll();
		if (LoginScreen.MusicRandom == 0)
		{
			mSound.playMus(0, mSound.volumeMusic, loop: true);
		}
		else
		{
			mSound.playMus(1, mSound.volumeMusic, loop: true);
		}
		timeSelect = 0;
		objSelect = null;
		isSelect = false;
		isSend = false;
		Player.isNewPlayer = false;
		GameScreen.Vecplayers.removeAllElements();
		base.Show();
		isSelectOk = false;
		GameCanvas.saveImage.start();
		GameScreen.infoGame.setNameServer(GameCanvas.listServer[GameCanvas.IndexServer, 0]);
		GameCanvas.countLogin = 0L;
	}

	public override void commandTab(int index, int sub)
	{
		switch (index)
		{
		case 0:
			doSelect();
			break;
		case 1:
			Main.isExit = true;
			GameCanvas.login.Show();
			Session_ME.gI().close();
			GameScreen.player = new Player(0, 0, "unname", 0, 0);
			break;
		}
		base.commandTab(index, sub);
	}

	public void init()
	{
		if (!GameCanvas.isTouch)
		{
			center = new iCommand(T.select, 0);
		}
		cmdExit = new iCommand(T.exit, 1);
		if (GameCanvas.isTouch)
		{
			cmdExit.setPos(PaintInfoGameScreen.fraBack.frameWidth / 2, GameCanvas.h - PaintInfoGameScreen.fraBack.frameHeight / 2, PaintInfoGameScreen.fraBack, cmdExit.caption);
		}
		left = cmdExit;
	}

	public void setCaptionCmd()
	{
		cmdExit.caption = T.exit;
	}

	public override void paint(mGraphics g)
	{
		BackGround.paint(g);
		if (LoginScreen.logo != null)
		{
			g.drawImage(LoginScreen.logo, GameCanvas.hw, GameCanvas.hh - 60, 3, mGraphics.isFalse);
		}
		BackGround.paint_CloudOnLogo(g);
		GameScreen.infoGame.paintNameServer(g, GameCanvas.listServer[GameCanvas.IndexServer, 0]);
		BackGround.paint_FloatingPlatform(g);
		BackGround.paint_StaticCloud(g);
		for (int i = 0; i < 3; i++)
		{
			if (i < VecSelectChar.size())
			{
				Other_Players other_Players = (Other_Players)VecSelectChar.elementAt(i);
				other_Players.paintPlayer(g, -1);
				mFont.tahoma_7b_black.drawString(g, T.level + other_Players.Lv, other_Players.x, other_Players.y - other_Players.hOne - 10, 2, mGraphics.isFalse);
				paintName(g, other_Players.name, other_Players.x, other_Players.y - other_Players.hOne, i, other_Players.myClan);
			}
			else
			{
				paintName(g, T.createChar, mShadow[i][0], mShadow[i][1], i, null);
			}
		}
		BackGround.paintLight(g);
		base.paint(g);
		if (reSelect)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
			if (LoginScreen.logo != null)
			{
				g.drawImage(LoginScreen.logo, GameCanvas.hw, GameCanvas.hh - 16, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, GameCanvas.hw, GameCanvas.hh + mImage.getImageHeight(LoginScreen.logo.image) / 2 - 9, 3, mGraphics.isFalse);
			}
		}
		if (PaintInfoGameScreen.paint18plush == 0)
		{
			g.drawImage(AvMain.img18Plus, 0, 0, 0, mGraphics.isFalse);
		}
		else if (PaintInfoGameScreen.paint18plush == 1)
		{
			PaintInfoGameScreen.paintinfo18plush(g);
		}
		if (LoginScreen.isPaintHotLine)
		{
			mFont.tahoma_7_yellow.drawString(g, T.HotLine, GameCanvas.w, 0, 1, mGraphics.isFalse);
			g.setColor(16514362);
			g.fillRect(GameCanvas.w - LoginScreen.wLine + (mSystem.isIphone ? 14 : 0), 10, LoginScreen.wLine, 1, mGraphics.isFalse);
		}
	}

	public override void update()
	{
		GameScreen.infoGame.updateInfoChar();
		if (LoginScreen.hShowServer < 20)
		{
			LoginScreen.hShowServer += 4;
			if (LoginScreen.hShowServer > 20)
			{
				LoginScreen.hShowServer = 20;
			}
		}
		if (timeSelect > 0)
		{
			timeSelect++;
			if (timeSelect == 18)
			{
				objSelect.f = 0;
				objSelect.Action = 1;
			}
		}
		if (!GameCanvas.isTouch)
		{
			if (selectChar > VecSelectChar.size() - 1)
			{
				center.caption = T.create;
			}
			else
			{
				center.caption = T.select;
			}
		}
		if (MsgDialog.isAutologin)
		{
			autoSelect();
		}
		for (int i = 0; i < VecSelectChar.size(); i++)
		{
			Other_Players other_Players = (Other_Players)VecSelectChar.elementAt(i);
			if (other_Players.Action == 2)
			{
				other_Players.PlashNow.update(other_Players);
			}
			else if (other_Players.Action == 1)
			{
				other_Players.f++;
				if (other_Players.f > other_Players.A_Move.Length - 1)
				{
					other_Players.f = 0;
				}
				other_Players.frame = other_Players.A_Move[other_Players.f];
				if (isSelect && !isSend)
				{
					Other_Players other_Players2 = (Other_Players)VecSelectChar.elementAt(selectChar);
					MainRMS.isLoadShowAuto = true;
					IDCHAR = other_Players2.ID;
					GlobalService.gI().select_char(0, IDCHAR);
					LoadMapScreen.isNextMap = false;
					GameCanvas.load.Show();
					isSend = true;
					GameScreen.help.Step = -1;
					GlobalService.gI().Save_RMS_Server(1, 2, null);
					GlobalService.gI().Save_RMS_Server(1, 1, null);
					Main.main.processPurchaseRMS();
					reSelect = false;
					GlobalLogicHandler.timeReconnect = 0L;
					GlobalLogicHandler.isDisConect = false;
					GlobalLogicHandler.isMelogin = false;
					MsgDialog.isAutologin = false;
				}
				other_Players.y += other_Players.vy;
			}
			else
			{
				other_Players.updateActionPerson();
			}
			other_Players.updateEye();
		}
		BackGround.updateSky();
		if (reSelect && Canselect)
		{
			doSelect();
			Canselect = false;
		}
	}

	public override void updatekey()
	{
		if (!reSelect && !isSelect)
		{
			if (GameCanvas.keyMyHold[4])
			{
				selectChar--;
				GameCanvas.clearKeyHold();
			}
			else if (GameCanvas.keyMyHold[6])
			{
				selectChar++;
				GameCanvas.clearKeyHold();
			}
			selectChar = resetSelect(selectChar, 2, isreset: true);
			base.updatekey();
		}
	}

	public void setPosPaint(mVector vList)
	{
		VecSelectChar.removeAllElements();
		if (vList != null)
		{
			VecSelectChar = vList;
		}
		for (int i = 0; i < 3; i++)
		{
			int num = GameCanvas.hw - 80 + i * 80;
			int num2 = GameCanvas.h - 60 - i % 2 * 25;
			if (i < VecSelectChar.size())
			{
				Other_Players other_Players = (Other_Players)VecSelectChar.elementAt(i);
				int x = GameCanvas.hw - 80 + i * 80;
				int y = GameCanvas.h - 60 - i % 2 * 25;
				other_Players.x = x;
				other_Players.y = y;
			}
			mShadow[i][0] = num;
			mShadow[i][1] = num2;
		}
	}

	private void paintName(mGraphics g, string name, int xp, int yp, int index, MainClan clan)
	{
		mFont.tahoma_7b_black.drawString(g, name, xp - 1, yp - 25, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp + 1, yp - 25, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp - 1, yp - 24, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp + 1, yp - 24, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp - 1, yp - 23, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp + 1, yp - 23, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp, yp - 25, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp, yp - 23, 2, mGraphics.isFalse);
		mFont.tahoma_7b_white.drawString(g, name, xp, yp - 24, 2, mGraphics.isFalse);
		if (clan != null)
		{
			MainImage imageIconClan = ObjectData.getImageIconClan(clan.IdIcon);
			if (imageIconClan.img != null)
			{
				int num = (mFont.tahoma_7b_white.getWidth(clan.shortName) + 11) / 2;
				if (imageIconClan.img != null)
				{
					if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num2 = frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							frameClan = (sbyte)((frameClan + 1) % num2);
						}
						g.drawRegion(imageIconClan.img, 0, frameicon[frameClan] * 18, 18, 18, 0, xp - num + 6, yp - 32, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(imageIconClan.img, xp - num + 6, yp - 32, 3, mGraphics.isFalse);
					}
					Item.eff_UpLv.paintUpgradeEffect(xp - num + 6, yp - 32 - 1, clan.getEffChucVu(), 14, g, 0);
				}
				mFont.tahoma_7b_white.drawString(g, clan.shortName, xp - num + 15, yp - 32 - 6, 0, mGraphics.isFalse);
				yp -= 18;
			}
		}
		if (index == selectChar && !isSelect && !GameCanvas.isTouch)
		{
			g.drawImage(AvMain.imgSelect, xp, yp - 35 + GameCanvas.gameTick % 5, 3, mGraphics.isFalse);
		}
	}

	public override void updatePointer()
	{
		if (reSelect)
		{
			return;
		}
		if (GameCanvas.isPointerSelect && !isSelect)
		{
			for (int i = 0; i < mShadow.Length; i++)
			{
				if (GameCanvas.isPoint(mShadow[i][0] - 5, mShadow[i][1] - 65, 50, 90))
				{
					selectChar = i;
					doSelect();
					selectChar = resetSelect(selectChar, 2, isreset: true);
					GameCanvas.isPointerSelect = false;
					break;
				}
			}
		}
		base.updatePointer();
	}

	public void autoSelect()
	{
		Other_Players other_Players = (Other_Players)VecSelectChar.elementAt(selectChar);
		MainRMS.isLoadShowAuto = true;
		IDCHAR = other_Players.ID;
		GlobalService.gI().select_char(0, IDCHAR);
		LoadMapScreen.isNextMap = false;
		GameCanvas.load.Show();
		isSend = true;
		mSystem.println("vao ham chon char ne " + IDCHAR);
		GameScreen.help.Step = -1;
		GlobalService.gI().Save_RMS_Server(1, 2, null);
		GlobalService.gI().Save_RMS_Server(1, 1, null);
		reSelect = false;
		MsgDialog.isAutologin = false;
	}

	public void doSelect()
	{
		if (selectChar > VecSelectChar.size() - 1)
		{
			mSound.playSound(41, mSound.volumeSound);
			GameCanvas.createChar = new CreateChar();
			GameCanvas.createChar.Show((sbyte)selectChar);
			return;
		}
		isSelect = true;
		timeSelect = 1;
		objSelect = (Other_Players)VecSelectChar.elementAt(selectChar);
		objSelect.Action = 2;
		objSelect.f = 0;
		objSelect.beginFire();
		objSelect.PlashNow.setPlash((objSelect.clazz != 3) ? 1 : 16);
		objSelect.Direction = 0;
		if (objSelect.clazz == 2 || objSelect.clazz == 3)
		{
			mSound.playSound(16, mSound.volumeSound);
		}
		else
		{
			mSound.playSound(6, mSound.volumeSound);
		}
	}

	public override void keyBack()
	{
		cmdExit.perform();
	}
}
