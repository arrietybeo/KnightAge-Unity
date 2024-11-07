using System;

public class LoadMapScreen : MainScreen
{
	public bool isLoadSkill;

	public bool isTele;

	public bool isLoadHelp;

	public static bool isNextMap = false;

	private long time;

	private long timeWait;

	public sbyte[] mItemMap;

	public sbyte[] mEffMap;

	public sbyte[] mNPCMap;

	public static bool isInLoadMapScreen = false;

	public static byte[] mMusic = new byte[54]
	{
		2, 0, 3, 2, 3, 2, 6, 2, 2, 2,
		6, 5, 5, 5, 6, 4, 4, 3, 6, 8,
		8, 8, 8, 8, 8, 4, 4, 4, 6, 3,
		3, 3, 6, 1, 1, 1, 5, 5, 5, 5,
		5, 5, 8, 8, 8, 8, 5, 6, 5, 5,
		5, 2, 5, 0
	};

	public override void Show()
	{
		base.Show();
		time = GameCanvas.timeNow;
		GameCanvas.saveImage.start();
		PaintInfoGameScreen.timeChange = 0;
	}

	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		if (LoginScreen.logo != null)
		{
			g.drawImage(LoginScreen.logo, GameCanvas.hw, GameCanvas.hh - 16, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, GameCanvas.hw, GameCanvas.hh + mImage.getImageHeight(LoginScreen.logo.image) / 2 - 9, 3, mGraphics.isFalse);
			if (timeWait > 0)
			{
				mFont.tahoma_7_white.drawString(g, timeWait + string.Empty, GameCanvas.hw, GameCanvas.hh + mImage.getImageHeight(LoginScreen.logo.image) / 2 - 15, 3, mGraphics.isFalse);
			}
		}
	}

	public override void update()
	{
		if ((GameCanvas.timeNow - time) / 1000 > 180 && GameCanvas.currentDialog != null)
		{
			GameCanvas.start_Center_Dialog_Only(T.disconnect, new iCommand(T.exit, 0));
			if (GameScreen.player != null)
			{
				GameScreen.player.resetAction();
			}
		}
		else if (GameCanvas.currentDialog != null)
		{
		}
		if (isNextMap && isLoadSkill && MainRMS.isLoadBegin && (!Main.isWindowsPhone || MiniMap.isLoadMiniMapOk) && (SaveImageRMS.vecSaveImage.size() <= 5 || (GameCanvas.timeNow - time) / 1000 > 45))
		{
			if (GameScreen.help.setStep_Next(0, -5))
			{
				GameCanvas.story = new StoryScreen();
				GameCanvas.story.setContent();
				GameCanvas.story.Show();
			}
			else
			{
				GameScreen.player.resetMove();
				GameScreen.player.posTransRoad = null;
				GameScreen.player.resetAction();
				GameCanvas.game.Show();
				GameCanvas.game.checkRemoveImage();
				if (MainRMS.showAuto.Length > 0 && MainRMS.isLoadShowAuto)
				{
					MainRMS.isLoadShowAuto = false;
					GameCanvas.start_Show_Dialog(T.autoFire + "\n" + MainRMS.showAuto, T.auto);
				}
				GameCanvas.hLoad = GameCanvas.h / 4 * 3;
				PaintInfoGameScreen.setNameMap();
				if (isTele)
				{
					GameScreen.addEffectKill(58, GameScreen.player.ID, GameScreen.player.typeObject, GameScreen.player.ID, GameScreen.player.typeObject, 0, GameScreen.player.hp);
					GameScreen.player.isTanHinh = true;
				}
				if (GameCanvas.loadmap.idMap == 0 && GameScreen.help.setStep_Next(5, 8) && (GameCanvas.isVN_Eng || IndoServer.isIndoSv))
				{
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
				}
			}
			if (isLoadHelp)
			{
				GameScreen.help.setNext();
				isLoadHelp = false;
			}
			SelectCharScreen.isSelectOk = true;
			GlobalService.gI().Ok_Change_Map();
			GlobalService.gI().send_cmd_server(59);
			EffectMonster.listEffectMonster.removeAllElements();
			PlayMusicLang();
		}
		bool flag = false;
		if (GameCanvas.timenextLogin - mSystem.currentTimeMillis() > 0)
		{
			timeWait = (GameCanvas.timenextLogin - mSystem.currentTimeMillis()) / 1000;
		}
		if (GameCanvas.timenextLogin - mSystem.currentTimeMillis() <= 0 && GameCanvas.timenextLogin > 0)
		{
			flag = true;
		}
		if (flag)
		{
			timeWait = 0L;
			GameCanvas.timenextLogin = 0L;
			GameCanvas.login.checkLoginAgain(GameCanvas.IndexServer);
			SelectCharScreen.reSelect = true;
			SelectCharScreen.Canselect = true;
		}
		if (GameCanvas.countLogin > 0 && (mSystem.currentTimeMillis() - GameCanvas.countLogin) / 1000 > 15)
		{
			GameCanvas.countLogin = 0L;
			GameCanvas.start_Wait_Dialog(T.Logifail, new iCommand(T.close, 16));
		}
	}

	private void PlayMusicLang()
	{
		mSound.stopSoundAll();
		if (GameCanvas.loadmap.idMap >= mMusic.Length - 1 || mMusic[GameCanvas.loadmap.idMap] < 0)
		{
			mSound.playMus(0, mSound.volumeMusic, loop: true);
		}
		else
		{
			mSound.playMus(mMusic[GameCanvas.loadmap.idMap], mSound.volumeMusic, loop: true);
		}
	}

	public static void NPCBig(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < b; i++)
			{
				string text = msg.reader().readUTF();
				string namegt = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				sbyte iDImage = msg.reader().readByte();
				short x = msg.reader().readShort();
				short y = msg.reader().readShort();
				sbyte wBlock = msg.reader().readByte();
				sbyte hBlock = msg.reader().readByte();
				sbyte nFrame = msg.reader().readByte();
				NPC nPC = new NPC(text, namegt, b2, iDImage, x, y, wBlock, hBlock, nFrame);
				nPC.IdBigAvatar = msg.reader().readByte() + 500;
				nPC.infoObject = msg.reader().readUTF();
				nPC.isPerson = msg.reader().readByte();
				nPC.typeObject = 2;
				GameScreen.addPlayer(nPC);
				MiniMap.addNPCMini(new NPCMini(b2, x, y));
			}
		}
		catch (Exception)
		{
		}
	}
}
