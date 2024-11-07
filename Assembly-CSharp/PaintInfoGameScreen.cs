public class PaintInfoGameScreen
{
	public short idCharLoiDai1 = -1;

	public short idCharLoiDai2 = -1;

	private int xPaintInfo;

	private int xPaintInfoChar;

	private int xmaxInfo;

	private int xmaxInfoChar;

	private int speedInfo = 2;

	private int speedInfoChar = 2;

	private int timepaintServer;

	private int timePaintInfoChar;

	public int timeInfoCharCline;

	public int maxtimeChar;

	public int ydInfoChar;

	public int hImgInfo = 22;

	private bool vipInfoChar;

	public static int xPointMove = 55;

	public static int yPointMove = GameCanvas.h - 55;

	public static int xMess;

	public static int yMess;

	public static int numMess;

	public static int yBeginInfo;

	public static int wInfoServer;

	public static int winfo18plus;

	public static int wArrowMove = 30;

	public static int wPointArrow = 38;

	public static mImage[] imgMove;

	public static mImage[] imgFire;

	public static mImage[] imgOther;

	public static mImage imgInfoFocus;

	public static mImage imgauto;

	public static mImage imgxp;

	public static mImage imgmove;

	public static mImage imgBackQuick;

	public static FrameImage fraClose;

	public static FrameImage fraFocusIngame;

	public static FrameImage fraBack;

	public static FrameImage fraMenu;

	public static FrameImage fraButton;

	public static FrameImage fraStatusArea;

	public static FrameImage fraCloseMenu;

	public static FrameImage fralevelup;

	public static FrameImage fraButton2;

	public static FrameImage fraContact;

	public static FrameImage fraEvent;

	public static FrameImage[] mfraIconQuick;

	private int[] mRotateMove = new int[4] { 2, 0, 3, 1 };

	private int[] mKeyMove = new int[4] { 4, 6, 2, 8 };

	public static int[] mKeySkill = new int[4] { 1, 3, 7, 9 };

	public static int[] mValueHotKey = new int[5] { 1, 3, 5, 7, 9 };

	public static string[] mValueChar = new string[5] { "R", "T", "Y", "U", "I" };

	private int[] mKeyOther = new int[4] { 100, 101, 102, 103 };

	public static int[][] mPosKill = mSystem.new_M_Int(4, 2);

	public static int[][] mPosMove = mSystem.new_M_Int(4, 2);

	public static int[][] mPosOther = mSystem.new_M_Int(5, 2);

	public static int[][] mSizeImgOther = mSystem.new_M_Int(5, 2);

	public static int timePointer = 0;

	public static int keyPoint;

	public static int timeChange;

	public static int timeNameMap;

	public static int wNameMap;

	public static int vyNameMap;

	public static int yNameMap;

	public static string namemap = string.Empty;

	public static int xPointKill = GameCanvas.w - 35;

	public static int yPointKill = GameCanvas.h - 50;

	public static int wSkill = 24;

	public static int wMainSkill = 50;

	private static int gocBegin = 285;

	private static int lSkill = 50;

	private static int xPaintSkill = GameCanvas.hw - 60;

	private static int yPaintSkill = GameCanvas.h - GameCanvas.hCommand - 14;

	public string strInfoServer;

	public string strInfoCharCline;

	public string strInfoCharServer;

	private int indexTab;

	public static bool isLevelPoint = false;

	public static bool isShowInfoAuto = true;

	public static bool isPaintInfoFocus = false;

	public static int hShowInGame = 0;

	public static bool isShowInGame = true;

	public static long timeDoNotClick = 0L;

	public static int xFocus;

	private static int yFocus;

	private static int xParty;

	private static int yParty;

	public static int delta;

	public static int[] imgHitWidth = new int[3];

	public static int[] imgHitHeight = new int[3];

	public static long timeThachdau;

	public static int WBlackclolor;

	public static int WRedclor;

	private int timeEvent;

	private int indexEvent;

	private int hShowEvent;

	public static int wShowEvent;

	private MainEvent eventShow;

	private long timeDownChat = -1L;

	private int hClip;

	public short[] posTam;

	private int timeMove;

	private int xlast;

	private int ylast;

	private bool isTouchFocus = true;

	public static mVector vecfocus = new mVector("PaintInfoGameScr vecfocus");

	public static int timeHS;

	public static int curTimeHS;

	public static bool isCountTime;

	private sbyte[] totalHouse = new sbyte[4];

	private short[] totalPlayer = new short[4];

	private short totalPoint;

	private sbyte[] typePK = new sbyte[5] { 1, 4, 5, 2, 0 };

	public static FrameImage imgArenaIcon;

	private sbyte[] typePaint = new sbyte[5] { 3, 2, 0, 1, 4 };

	public bool isShipMove;

	public EffectAuto eff;

	private int xPos_minimap;

	private int yPos_minimap;

	public static sbyte paint18plush = 0;

	public static int idicon = -1;

	public static string nameclan;

	public static void init()
	{
		xPointKill = GameCanvas.w - 35;
		yPointKill = GameCanvas.h - 45;
		xPaintSkill = GameCanvas.hw - 50;
		yPaintSkill = GameCanvas.h - GameCanvas.hCommand - 14;
		xPaintSkill = GameCanvas.hw - 50;
		yPaintSkill = GameCanvas.h - GameCanvas.hCommand - 14;
		xPointMove = 50;
		yPointMove = GameCanvas.h - 50;
	}

	public static void loadPaintInfo()
	{
		init();
		wInfoServer = GameCanvas.w * 2 / 3;
		winfo18plus = GameCanvas.hw - GameCanvas.hw / 3;
		yBeginInfo = GameCanvas.h / 4 - 30;
		xFocus = GameCanvas.w - 52;
		yFocus = 0;
		xParty = 2;
		yParty = 60;
		xMess = 70;
		yMess = 45;
		if (GameCanvas.isTouch)
		{
			loadImagePointer();
			xFocus = GameCanvas.hw;
		}
		wShowEvent = 130;
	}

	public static void loadImagePointer()
	{
		wSkill = 32;
		int num = gocBegin;
		for (int i = 0; i < mPosKill.Length; i++)
		{
			mPosKill[i][0] = xPointKill + CRes.cos(CRes.fixangle(num)) * lSkill / 1000;
			mPosKill[i][1] = yPointKill + CRes.sin(CRes.fixangle(num)) * lSkill / 1000;
			num -= 45;
		}
		xPaintSkill = GameCanvas.w - wSkill * 6;
		yPaintSkill = GameCanvas.h - 24;
		mPosOther[0][0] = 8;
		mPosOther[0][1] = 43;
		mPosOther[1][0] = 8;
		mPosOther[1][1] = 73;
		mPosOther[2][0] = GameCanvas.w - 27;
		mPosOther[2][1] = GameCanvas.h - 145;
		if (Main.isPC)
		{
			mPosOther[2][1] = GameCanvas.h - 31;
		}
		mPosOther[3][0] = GameCanvas.w - 27;
		mPosOther[3][1] = GameCanvas.h - 175;
		if (mSystem.isIP_GDX)
		{
			mPosOther[3][0] = GameCanvas.w - 60;
			mPosOther[3][1] = GameCanvas.h - 146;
		}
		mPosOther[4][0] = GameCanvas.hw - 20;
		mPosOther[4][1] = GameCanvas.h - 16;
		setPosTouch();
		if (!Main.isPC)
		{
			mPosOther[3][0] = GameCanvas.w - 62;
			mPosOther[3][1] = GameCanvas.h - 151;
		}
		xMess = 45;
		yMess = 45;
		imgOther = new mImage[5];
		for (int j = 0; j < imgOther.Length; j++)
		{
			imgOther[j] = mImage.createImage("/point/other_" + j + ".png");
			mSizeImgOther[j][0] = mImage.getImageWidth(imgOther[j].image);
			mSizeImgOther[j][1] = mImage.getImageHeight(imgOther[j].image) / 2;
		}
		imgMove = new mImage[3];
		for (int k = 0; k < imgMove.Length; k++)
		{
			if (k != 1)
			{
				imgMove[k] = mImage.createImage("/point/move_" + k + ".png");
			}
		}
		for (int l = 0; l < mPosMove.Length; l++)
		{
			mPosMove[l][0] = xPointMove + ((l < 2) ? (-wArrowMove + wArrowMove * 2 * (l % 2)) : 0);
			mPosMove[l][1] = yPointMove + ((l > 1) ? (-wArrowMove + wArrowMove * 2 * (l % 2)) : 0);
		}
		imgFire = new mImage[2];
		for (int m = 0; m < imgFire.Length; m++)
		{
			imgFire[m] = mImage.createImage("/point/fire_" + m + ".png");
		}
		fraClose = new FrameImage(mImage.createImage("/point/close.png"), 14, 14);
		fraCloseMenu = new FrameImage(mImage.createImage("/point/closemenu.png"), 21, 21);
		fraBack = new FrameImage(mImage.createImage("/point/buttonback.png"), 57, 30);
		fraMenu = new FrameImage(mImage.createImage("/point/buttonmenu.png"), 32, 32);
		fraButton = new FrameImage(mImage.createImage("/point/button.png"), 80, 30);
		fraButton2 = new FrameImage(mImage.createImage("/point/button2.png"), 60, 19);
		fraContact = new FrameImage(mImage.createImage("/point/contact.png"), 26, 26);
		mfraIconQuick = new FrameImage[11];
		for (int n = 0; n < mfraIconQuick.Length; n++)
		{
			mfraIconQuick[n] = new FrameImage(mImage.createImage("/point/quick_" + n + ".png"), 30, 30);
		}
		imgBackQuick = mImage.createImage("/point/backquick.png");
		imgmove = mImage.createImage("/interface/move.png");
	}

	public static void paintHitscr(mGraphics g, bool isMaxdame)
	{
		if (isMaxdame)
		{
			delta = 0;
		}
		else
		{
			delta = 10;
		}
		g.drawRegion(AvMain.imghitScr[0], 0, 0, imgHitWidth[0], imgHitHeight[0], 0, GameCanvas.w - imgHitWidth[0] + delta, -delta, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imghitScr[0], 0, 0, imgHitWidth[0], imgHitHeight[0], 1, GameCanvas.w - imgHitWidth[0] + delta, GameCanvas.h - imgHitHeight[0] + delta, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imghitScr[0], 0, 0, imgHitWidth[0], imgHitHeight[0], 2, -delta, -delta, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imghitScr[0], 0, 0, imgHitWidth[0], imgHitHeight[0], 4, -delta, GameCanvas.h - imgHitHeight[0] + delta, 0, mGraphics.isFalse);
		int num = (GameCanvas.w + delta - 2 * imgHitWidth[0]) / imgHitWidth[1] + 1;
		for (int i = 0; i < num; i++)
		{
			g.drawRegion(AvMain.imghitScr[1], 0, 0, imgHitWidth[1], imgHitHeight[1], 0, imgHitWidth[0] + imgHitWidth[1] * i - delta, -delta, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imghitScr[1], 0, 0, imgHitWidth[1], imgHitHeight[1], 1, imgHitWidth[0] + imgHitWidth[1] * i - delta, GameCanvas.h - imgHitHeight[1] + delta, 0, mGraphics.isFalse);
		}
		int num2 = (GameCanvas.w + delta - 2 * imgHitHeight[0]) / imgHitHeight[2] + 1;
		for (int j = 0; j < num2; j++)
		{
			g.drawRegion(AvMain.imghitScr[2], 0, 0, imgHitWidth[2], imgHitHeight[2], 0, -delta, imgHitHeight[0] + imgHitHeight[2] * j - delta, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imghitScr[2], 0, 0, imgHitWidth[2], imgHitHeight[2], 2, GameCanvas.w - imgHitWidth[2] + delta, imgHitHeight[0] + imgHitHeight[2] * j - delta, 0, mGraphics.isFalse);
		}
	}

	public void paintKillPlayer(mGraphics g)
	{
		if (timeChange == 0)
		{
			int num = yPaintSkill + hShowInGame;
			if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeBoss == 2)
			{
				for (int i = 0; i < 5; i++)
				{
					g.drawImage(AvMain.imgHotKey, xPaintSkill + i * wSkill, num - 5, 0, mGraphics.isFalse);
					if (Main.isPC && TField.isQwerty)
					{
						AvMain.Font3dWhite(g, mValueChar[i] + string.Empty, xPaintSkill + i * wSkill + 11, num, 2);
					}
					else
					{
						AvMain.Font3dWhite(g, mValueHotKey[i] + string.Empty, xPaintSkill + i * wSkill + 11, num, 2);
					}
				}
				return;
			}
			num = 5 - hShowInGame;
			for (int j = 0; j < Player.mhotkey[0].Length; j++)
			{
				g.drawImage(AvMain.imgHotKey, xPaintSkill + j * wSkill, yPaintSkill - num, 0, mGraphics.isFalse);
				HotKey hotKey = Player.mhotkey[Player.levelTab][j];
				DelaySkill delaySkill = null;
				if (hotKey.type == HotKey.SKILL)
				{
					Skill skillFormId = MainListSkill.getSkillFormId(hotKey.id);
					if (skillFormId != null)
					{
						skillFormId.paint(g, xPaintSkill + j * wSkill + 11, yPaintSkill - num + 11, 3);
					}
					delaySkill = Player.timeDelaySkill[hotKey.id];
				}
				else if (hotKey.type == HotKey.POTION && MainTemplateItem.isload)
				{
					Item itemInventory = Item.getItemInventory(4, hotKey.id);
					if (itemInventory != null && itemInventory.typePotion < 2)
					{
						itemInventory.paintItem(g, xPaintSkill + j * wSkill + 11, yPaintSkill + 11 - num, MainTabNew.wOneItem, 0, 3);
						delaySkill = Player.timeDelayPotion[itemInventory.typePotion];
					}
					else
					{
						hotKey.setHotKey(0, HotKey.NULL, 0);
						MainItem.setAddHotKey(1, false);
						MainItem.setAddHotKey(0, false);
					}
				}
				if (hotKey.type != HotKey.NULL && delaySkill != null && delaySkill.limit > 0)
				{
					if (delaySkill.value > 0)
					{
						int num2 = delaySkill.value * 20 / delaySkill.limit;
						if (num2 < 1)
						{
							num2 = 1;
						}
						g.drawRegion(AvMain.imgDelaySkill, 0, 0, 20, num2, 0, xPaintSkill + j * wSkill + 1, yPaintSkill + 1 - num, 0, mGraphics.isFalse);
						int num3 = delaySkill.value / 1000;
						string empty = string.Empty;
						empty = ((num3 != 0) ? (string.Empty + num3) : ("0." + delaySkill.value % 1000 / 100));
						mFont.tahoma_7b_white.drawString(g, empty, xPaintSkill + j * wSkill + 11, yPaintSkill + 5 - num, 2, mGraphics.isFalse);
					}
					else if (delaySkill.value > -150)
					{
						g.setColor(15658700);
						g.fillRoundRect(xPaintSkill + j * wSkill + 1, yPaintSkill - num + 1, 20, 20, 4, 4, mGraphics.isFalse);
					}
				}
				if (!GameCanvas.isTouch)
				{
					if (TField.isQwerty)
					{
						mFont.tahoma_7b_white.drawString(g, mValueChar[j] + string.Empty, xPaintSkill + j * wSkill + 12, yPaintSkill - num - 11, 2, mGraphics.isFalse);
					}
					else
					{
						mFont.tahoma_7b_white.drawString(g, mValueHotKey[j] + string.Empty, xPaintSkill + j * wSkill + 12, yPaintSkill - num - 11, 2, mGraphics.isFalse);
					}
				}
			}
		}
		else
		{
			paintChangeSkill(g);
		}
		int num4 = 4;
		if (Main.isPC)
		{
			for (int k = 0; k < 6; k++)
			{
				mFont.tahoma_7_black.drawString(g, k + 1 + string.Empty, xPaintSkill + k * wSkill + 12, yPaintSkill - num4 - 10, 2, mGraphics.isFalse);
				mFont.tahoma_7_white.drawString(g, k + 1 + string.Empty, xPaintSkill + k * wSkill + 12, yPaintSkill - num4 - 11, 2, mGraphics.isFalse);
			}
		}
	}

	public void paintBuffPlayer(mGraphics g)
	{
		for (int i = 0; i < GameScreen.player.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuff.elementAt(i);
		}
	}

	private void paintChangeSkill(mGraphics g)
	{
		for (int i = 0; i < 10; i++)
		{
			int num = -5;
			int num2 = Player.levelTab;
			if (i < 5)
			{
				num = timeChange * 8;
			}
			else
			{
				num = 64 - timeChange * 8;
				num2 = ((Player.levelTab == 0) ? 1 : 0);
			}
			g.drawImage(AvMain.imgHotKey, xPaintSkill + i % 5 * wSkill - 1, num + yPaintSkill - 1, 0, mGraphics.isFalse);
			HotKey hotKey = Player.mhotkey[num2][i % 5];
			if (hotKey.type == HotKey.SKILL)
			{
				Skill skillFormId = MainListSkill.getSkillFormId(hotKey.id);
				skillFormId.paint(g, xPaintSkill + i % 5 * wSkill + 11, num + yPaintSkill + 11, 3);
			}
			else if (hotKey.type == HotKey.POTION)
			{
				Item itemInventory = Item.getItemInventory(4, hotKey.id);
				if (itemInventory != null)
				{
					itemInventory.paintItem(g, xPaintSkill + i % 5 * wSkill + 11, num + yPaintSkill + 11, MainTabNew.wOneItem, 0, 3);
				}
			}
		}
	}

	public void paintInfoThachDau(mGraphics g, int x, int y)
	{
		if (!isMapThachdau())
		{
			return;
		}
		GameCanvas.resetTrans(g);
		if (idCharLoiDai1 != -1)
		{
			MainObject mainObject = GameScreen.findObjByteCat(idCharLoiDai1, 0);
			if (mainObject == null)
			{
				return;
			}
			int num = GameCanvas.w / 2 - 20;
			int num2 = num / (WBlackclolor / 2);
			if (num2 < 0)
			{
				num2 = 1;
			}
			if (num2 == 1)
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, WBlackclolor, 9, 0, x, y + 3, 0, mGraphics.isFalse);
			}
			else
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, WBlackclolor - 2, 9, 0, x, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 2, 0, WBlackclolor - 2, 9, 0, x + num - (WBlackclolor - 2) + 2, y + 3, 0, mGraphics.isTrue);
				int num3 = (num - (WBlackclolor - 2) * 2) / 5;
				if (num3 <= 0)
				{
					num3 = 1;
				}
				for (int i = 0; i < num3 + 1; i++)
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 10, 0, 15, 9, 0, x + WBlackclolor - 4 + i * 5, y + 3, 0, mGraphics.isTrue);
				}
			}
			if (mainObject.hp > 0)
			{
				long num4 = mainObject.maxHp;
				long num5 = mainObject.hp;
				long num6 = num;
				long num7 = num5 * num6;
				int num8 = (int)(num7 / num4);
				int num9 = num + 1;
				g.setClip(x, y + 4, num9 - (num - num8), 7);
				int num10 = num / (WRedclor / 2);
				if (num10 < 0)
				{
					num10 = 1;
				}
				if (num10 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, WRedclor, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, WRedclor - 2, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp, 2, 0, WRedclor - 2, 7, 0, x + 1 + num - (WRedclor - 2), y + 4, 0, mGraphics.isTrue);
					int num11 = (num - (WRedclor - 2) * 2) / 5;
					if (num11 <= 0)
					{
						num11 = 1;
					}
					for (int j = 0; j < num11 + 1; j++)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 10, 0, 15, 7, 0, x + WRedclor - 2 + j * 5, y + 4, 0, mGraphics.isTrue);
					}
				}
			}
			if (mainObject.mp > 0)
			{
			}
			g.endClip();
			GameCanvas.resetTrans(g);
			AvMain.Font3dColor(g, mainObject.name.ToUpper() + " Lv: " + mainObject.Lv, x + 2, y + 24 - 10, 0, 0);
			if (!mainObject.overHP)
			{
				mFont.tahoma_7_white.drawString(g, mainObject.hp + "/" + mainObject.maxHp, num / 2, y + 2, 2, mGraphics.isTrue);
			}
			else
			{
				mFont mFont2 = mFont.tahoma_7_white;
				if (MainObject.countmp > 5)
				{
					mFont2 = mFont.tahoma_7_red;
				}
				mFont2.drawString(g, mainObject.hp + "/" + mainObject.maxHp, num / 2, y + 2, 2, mGraphics.isTrue);
			}
			if (timeThachdau - mSystem.currentTimeMillis() / 1000 > 0)
			{
				long num12 = timeThachdau - mSystem.currentTimeMillis() / 1000;
				g.drawRegion(AvMain.imgBackInfo, 0, 0, 140, 20, 0, GameCanvas.w / 2, y + 35, 3, mGraphics.isFalse);
				mFont.tahoma_7_white.drawString(g, T.TimeThachDau + num12, GameCanvas.w / 2, y + 30, 2, mGraphics.isFalse);
			}
			return;
		}
		int num13 = GameCanvas.w / 2 - 20;
		int num14 = num13 / (WBlackclolor / 2);
		if (num14 < 0)
		{
			num14 = 1;
		}
		if (num14 == 1)
		{
			g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, WBlackclolor, 9, 0, x, y + 3, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, WBlackclolor, 9, 0, x, y + 15, 0, mGraphics.isFalse);
		}
		else
		{
			g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, WBlackclolor - 2, 9, 0, x, y + 3, 0, mGraphics.isTrue);
			g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, WBlackclolor - 2, 9, 0, x, y + 15, 0, mGraphics.isTrue);
			g.drawRegion(AvMain.imgcolorhpmp_back, 2, 0, WBlackclolor - 2, 9, 0, x + num13 - (WBlackclolor - 2) + 2, y + 3, 0, mGraphics.isTrue);
			g.drawRegion(AvMain.imgcolorhpmp_back, 2, 9, WBlackclolor - 2, 9, 0, x + num13 - (WBlackclolor - 2) + 2, y + 15, 0, mGraphics.isTrue);
			int num15 = (num13 - (WBlackclolor - 2) * 2) / 5;
			if (num15 <= 0)
			{
				num15 = 1;
			}
			for (int k = 0; k < num15 + 1; k++)
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 10, 0, 15, 9, 0, x + WBlackclolor - 2 + k * 5, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 10, 9, 15, 9, 0, x + WBlackclolor - 2 + k * 5, y + 15, 0, mGraphics.isTrue);
			}
		}
		if (GameScreen.player.hp > 0)
		{
			long num16 = GameScreen.player.maxHp;
			long num17 = GameScreen.player.hp;
			long num18 = num13;
			long num19 = num17 * num18;
			int num20 = (int)(num19 / num16);
			int num21 = num13 + 1;
			g.setClip(x, y + 4, num21 - (num13 - num20), 7);
			int num22 = num13 / (WRedclor / 2);
			if (num22 < 0)
			{
				num22 = 1;
			}
			if (num22 == 1)
			{
				g.drawRegion(AvMain.imgcolorhpmp, 0, 0, WRedclor, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
			}
			else
			{
				g.drawRegion(AvMain.imgcolorhpmp, 0, 0, WRedclor - 2, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp, 2, 0, WRedclor - 2, 7, 0, x + 1 + num13 - (WRedclor - 2), y + 4, 0, mGraphics.isTrue);
				int num23 = (num13 - (WRedclor - 2) * 2) / 5;
				if (num23 <= 0)
				{
					num23 = 1;
				}
				for (int l = 0; l < num23 + 1; l++)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 10, 0, 15, 7, 0, x + WRedclor - 2 + l * 5, y + 4, 0, mGraphics.isTrue);
				}
			}
		}
		if (GameScreen.player.mp > 0)
		{
			long num24 = GameScreen.player.maxMp;
			long num25 = GameScreen.player.mp;
			long num26 = num13;
			long num27 = num25 * num26;
			int num28 = num13 + 2;
			int num29 = (int)(num27 / num24);
			g.setClip(x, y + 16, num28 - (num13 - num29), 7);
			int num30 = num13 / (WRedclor / 2);
			if (num30 < 0)
			{
				num30 = 1;
			}
			if (num30 == 1)
			{
				g.drawRegion(AvMain.imgcolorhpmp, 0, 7, WRedclor, 7, 0, x + 1, y + 16, 0, mGraphics.isTrue);
			}
			else
			{
				g.drawRegion(AvMain.imgcolorhpmp, 0, 7, WRedclor - 2, 7, 0, x + 1, y + 16, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp, 2, 7, WRedclor - 2, 7, 0, x + 1 + num13 - (WRedclor - 2), y + 16, 0, mGraphics.isTrue);
				int num31 = (num13 - (WRedclor - 2) * 2) / 5;
				if (num31 <= 0)
				{
					num31 = 1;
				}
				for (int m = 0; m < num31 + 1; m++)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 10, 7, 15, 7, 0, x + WRedclor - 2 + m * 5, y + 16, 0, mGraphics.isTrue);
				}
			}
		}
		g.endClip();
		GameCanvas.resetTrans(g);
		AvMain.Font3dColor(g, GameScreen.player.name.ToUpper() + " Lv: " + GameScreen.player.Lv, x + 2, y + 24, 0, 0);
		if (!GameScreen.player.overHP)
		{
			mFont.tahoma_7_white.drawString(g, GameScreen.player.hp + "/" + GameScreen.player.maxHp, num13 / 2, y + 2, 2, mGraphics.isTrue);
		}
		else
		{
			mFont mFont3 = mFont.tahoma_7_white;
			if (MainObject.countmp > 5)
			{
				mFont3 = mFont.tahoma_7_red;
			}
			mFont3.drawString(g, GameScreen.player.hp + "/" + GameScreen.player.maxHp, num13 / 2, y + 2, 2, mGraphics.isTrue);
		}
		if (!GameScreen.player.overMP)
		{
			mFont.tahoma_7_white.drawString(g, GameScreen.player.mp + "/" + GameScreen.player.maxMp, num13 / 2, y + 14, 2, mGraphics.isFalse);
		}
		else
		{
			mFont mFont4 = mFont.tahoma_7_white;
			if (MainObject.countmp > 5)
			{
				mFont4 = mFont.tahoma_7_blue;
			}
			mFont4.drawString(g, GameScreen.player.mp + "/" + GameScreen.player.maxMp, num13 / 2, y + 14, 2, mGraphics.isTrue);
		}
		if (timeThachdau - mSystem.currentTimeMillis() / 1000 > 0)
		{
			long num32 = timeThachdau - mSystem.currentTimeMillis() / 1000;
			g.drawRegion(AvMain.imgBackInfo, 0, 0, 140, 20, 0, GameCanvas.w / 2, y + 35, 3, mGraphics.isFalse);
			mFont.tahoma_7_white.drawString(g, T.TimeThachDau + num32, GameCanvas.w / 2, y + 30, 2, mGraphics.isFalse);
		}
	}

	public void paintInfoThachDauOtherPlayer(mGraphics g, int x, int y)
	{
		if (!isMapThachdau())
		{
			return;
		}
		if (idCharLoiDai2 != -1)
		{
			MainObject mainObject = GameScreen.findObjByteCat(idCharLoiDai2, 0);
			if (mainObject == null)
			{
				return;
			}
			GameCanvas.resetTrans(g);
			int num = GameCanvas.w / 2 - 20;
			int num2 = num / (WBlackclolor / 2);
			if (num2 < 0)
			{
				num2 = 1;
			}
			if (num2 == 1)
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, WBlackclolor, 9, 0, x, y + 3, 0, mGraphics.isTrue);
			}
			else
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, WBlackclolor - 2, 9, 0, x, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 2, 0, WBlackclolor - 2, 9, 0, GameCanvas.w - WBlackclolor, y + 3, 0, mGraphics.isTrue);
				int num3 = (num - (WBlackclolor - 2) * 2) / 5;
				if (num3 <= 0)
				{
					num3 = 1;
				}
				for (int i = 0; i < num3 + 1; i++)
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 10, 0, 15, 9, 0, x + WBlackclolor - 4 + i * 5, y + 3, 0, mGraphics.isTrue);
				}
			}
			if (mainObject.hp > 0)
			{
				long num4 = mainObject.maxHp;
				long num5 = mainObject.hp;
				long num6 = num;
				long num7 = num5 * num6;
				int num8 = (int)(num7 / num4);
				g.setClip(x + (num - num8), y + 4, GameCanvas.w / 2 - (num - num8), 7);
				int num9 = num / (WRedclor / 2);
				if (num9 < 0)
				{
					num9 = 1;
				}
				if (num9 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, WRedclor, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, WRedclor - 2, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp, 2, 0, WRedclor - 2, 7, 0, GameCanvas.w - WBlackclolor, y + 4, 0, mGraphics.isTrue);
					int num10 = (num - (WRedclor - 2) * 2) / 5;
					if (num10 <= 0)
					{
						num10 = 1;
					}
					for (int j = 0; j < num10 + 1; j++)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 10, 0, 15, 7, 0, x + WRedclor - 2 + j * 5, y + 4, 0, mGraphics.isTrue);
					}
				}
			}
			if (mainObject.mp <= 0 || mainObject.maxMp > 0)
			{
			}
			g.endClip();
			GameCanvas.resetTrans(g);
			AvMain.Font3dColor(g, mainObject.name.ToUpper() + " Lv: " + mainObject.Lv, x + num - 2, y + 24 - 10, 1, 0);
			if (!mainObject.overHP)
			{
				mFont.tahoma_7_white.drawString(g, mainObject.hp + "/" + mainObject.maxHp, x + num / 2, y + 2, 2, mGraphics.isTrue);
				return;
			}
			mFont mFont2 = mFont.tahoma_7_white;
			if (MainObject.countmp > 5)
			{
				mFont2 = mFont.tahoma_7_red;
			}
			mFont2.drawString(g, mainObject.hp + "/" + mainObject.maxHp, x + num / 2, y + 2, 2, mGraphics.isTrue);
		}
		else
		{
			if (GameScreen.ObjFocus == null || (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeObject != 0))
			{
				return;
			}
			GameCanvas.resetTrans(g);
			int num11 = GameCanvas.w / 2 - 20;
			int num12 = num11 / (WBlackclolor / 2);
			if (num12 < 0)
			{
				num12 = 1;
			}
			if (num12 == 1)
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, WBlackclolor, 9, 0, x, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, WBlackclolor, 9, 0, x, y + 15, 0, mGraphics.isFalse);
			}
			else
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, WBlackclolor - 2, 9, 0, x, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, WBlackclolor - 2, 9, 0, x, y + 15, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 2, 0, WBlackclolor - 2, 9, 0, GameCanvas.w - WBlackclolor, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 2, 9, WBlackclolor - 2, 9, 0, GameCanvas.w - WBlackclolor, y + 15, 0, mGraphics.isTrue);
				int num13 = (num11 - (WBlackclolor - 2) * 2) / 5;
				if (num13 <= 0)
				{
					num13 = 1;
				}
				for (int k = 0; k < num13 + 1; k++)
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 10, 0, 15, 9, 0, x + WBlackclolor - 2 + k * 5, y + 3, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp_back, 10, 9, 15, 9, 0, x + WBlackclolor - 2 + k * 5, y + 15, 0, mGraphics.isTrue);
				}
			}
			if (GameScreen.ObjFocus.hp > 0)
			{
				long num14 = GameScreen.ObjFocus.maxHp;
				long num15 = GameScreen.ObjFocus.hp;
				long num16 = num11;
				long num17 = num15 * num16;
				int num18 = (int)(num17 / num14);
				g.setClip(x + (num11 - num18), y + 4, GameCanvas.w / 2 - (num11 - num18), 7);
				int num19 = num11 / (WRedclor / 2);
				if (num19 < 0)
				{
					num19 = 1;
				}
				if (num19 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, WRedclor, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, WRedclor - 2, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp, 2, 0, WRedclor - 2, 7, 0, GameCanvas.w - WBlackclolor, y + 4, 0, mGraphics.isTrue);
					int num20 = (num11 - (WRedclor - 2) * 2) / 5;
					if (num20 <= 0)
					{
						num20 = 1;
					}
					for (int l = 0; l < num20 + 1; l++)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 10, 0, 15, 7, 0, x + WRedclor - 2 + l * 5, y + 4, 0, mGraphics.isTrue);
					}
				}
			}
			if (GameScreen.ObjFocus.mp > 0 && GameScreen.ObjFocus.maxMp > 0)
			{
				long num21 = GameScreen.ObjFocus.maxMp;
				long num22 = GameScreen.ObjFocus.mp;
				long num23 = num11;
				long num24 = num22 * num23;
				int num25 = (int)(num24 / num21);
				g.setClip(x + (num11 - num25), y + 16, GameCanvas.w / 2 - (num11 - num25), 7);
				int num26 = num11 / (WRedclor / 2);
				if (num26 < 0)
				{
					num26 = 1;
				}
				if (num26 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 7, WRedclor, 7, 0, x + 1, y + 16, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 7, WRedclor - 2, 7, 0, x + 1, y + 16, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp, 2, 7, WRedclor - 2, 7, 0, GameCanvas.w - WBlackclolor, y + 16, 0, mGraphics.isTrue);
					int num27 = (num11 - (WRedclor - 2) * 2) / 5;
					if (num27 <= 0)
					{
						num27 = 1;
					}
					for (int m = 0; m < num27 + 1; m++)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 10, 7, 15, 7, 0, x + WRedclor - 2 + m * 5, y + 16, 0, mGraphics.isTrue);
					}
				}
			}
			g.endClip();
			GameCanvas.resetTrans(g);
			AvMain.Font3dColor(g, GameScreen.ObjFocus.name.ToUpper() + " Lv: " + GameScreen.ObjFocus.Lv, x + num11 - 2, y + 24, 1, 0);
			if (!GameScreen.ObjFocus.overHP)
			{
				mFont.tahoma_7_white.drawString(g, GameScreen.ObjFocus.hp + "/" + GameScreen.ObjFocus.maxHp, x + num11 / 2, y + 2, 2, mGraphics.isTrue);
			}
			else
			{
				mFont mFont3 = mFont.tahoma_7_white;
				if (MainObject.countmp > 5)
				{
					mFont3 = mFont.tahoma_7_red;
				}
				mFont3.drawString(g, GameScreen.ObjFocus.hp + "/" + GameScreen.ObjFocus.maxHp, x + num11 / 2, y + 2, 2, mGraphics.isTrue);
			}
			if (!GameScreen.ObjFocus.overMP)
			{
				mFont.tahoma_7_white.drawString(g, GameScreen.ObjFocus.mp + "/" + GameScreen.ObjFocus.maxMp, x + num11 / 2, y + 14, 2, mGraphics.isFalse);
				return;
			}
			mFont mFont4 = mFont.tahoma_7_white;
			if (MainObject.countmp > 5)
			{
				mFont4 = mFont.tahoma_7_blue;
			}
			mFont4.drawString(g, GameScreen.ObjFocus.mp + "/" + GameScreen.ObjFocus.maxMp, x + num11 / 2, y + 14, 2, mGraphics.isTrue);
		}
	}

	public void paintInfoPlayer(mGraphics g, int x, int y, bool isborder, mFont fontLv)
	{
		if (isMapThachdau())
		{
			return;
		}
		y += mGraphics.addYWhenOpenKeyBoard;
		if (isborder)
		{
			g.drawRegion(AvMain.imgInfo, 0, 0, 16, 42, 0, x + 1, y + 2, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imgInfo, 0, 84, 16, 42, 0, x + 96, y + 2, mGraphics.TOP | mGraphics.RIGHT, mGraphics.isFalse);
			for (int i = 0; i < 4; i++)
			{
				g.drawRegion(AvMain.imgInfo, 0, 42, 16, 42, 0, x + 17 + 16 * i, y + 2, 0, mGraphics.isFalse);
			}
			x += 8;
			y += 4;
		}
		g.drawImage(AvMain.imghpmp, x + 2, y + 3, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, 62, 9, 0, x + 19, y + 3, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, 62, 9, 0, x + 19, y + 15, 0, mGraphics.isFalse);
		int num = 0;
		int num2 = 0;
		if (GameScreen.player.hp > 0)
		{
			num = GameScreen.player.hp * 60 / GameScreen.player.maxHp;
			if (num <= 0)
			{
				num = 1;
			}
			else if (num > 60)
			{
				num = 60;
			}
			g.drawRegion(AvMain.imgcolorhpmp, 0, 0, num, 7, 0, x + 20, y + 4, 0, mGraphics.isFalse);
		}
		if (GameScreen.player.mp > 0)
		{
			num2 = GameScreen.player.mp * 60 / GameScreen.player.maxMp;
			if (num2 <= 0)
			{
				num2 = 1;
			}
			else if (num2 > 60)
			{
				num2 = 60;
			}
			g.drawRegion(AvMain.imgcolorhpmp, 0, 7, num2, 7, 0, x + 20, y + 16, 0, mGraphics.isFalse);
		}
		fontLv.drawString(g, "Lv." + GameScreen.player.Lv + " + " + GameScreen.player.phantramLv / 10 + "," + GameScreen.player.phantramLv % 10 + "%", x + 3, y + 24, 0, mGraphics.isFalse);
		int num3 = 0;
		if (GameScreen.player.phantramLv > 0)
		{
			num3 = GameScreen.player.phantramLv / 10 * 77 / 100;
			g.setColor(3514158);
			g.fillRect(x + 3, y + 35, num3, 2, mGraphics.isFalse);
		}
		if (!GameScreen.player.overHP)
		{
			mFont.tahoma_7_white.drawString(g, GameScreen.player.hp + "/" + GameScreen.player.maxHp, x + 50, y + 2, 2, mGraphics.isFalse);
		}
		else
		{
			mFont mFont2 = mFont.tahoma_7_white;
			if (MainObject.countmp > 5)
			{
				mFont2 = mFont.tahoma_7_red;
			}
			mFont2.drawString(g, GameScreen.player.hp + "/" + GameScreen.player.maxHp, x + 50, y + 2, 2, mGraphics.isFalse);
		}
		if (!GameScreen.player.overMP)
		{
			mFont.tahoma_7_white.drawString(g, GameScreen.player.mp + "/" + GameScreen.player.maxMp, x + 50, y + 14, 2, mGraphics.isFalse);
			return;
		}
		mFont mFont3 = mFont.tahoma_7_white;
		if (MainObject.countmp > 5)
		{
			mFont3 = mFont.tahoma_7_blue;
		}
		mFont3.drawString(g, GameScreen.player.mp + "/" + GameScreen.player.maxMp, x + 50, y + 14, 2, mGraphics.isFalse);
	}

	public void paintInfoChar(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = yBeginInfo;
		if (strInfoServer != null)
		{
			g.setClip(GameCanvas.hw - wInfoServer / 2, num, wInfoServer, 20);
			for (int i = 0; i < wInfoServer / 140 + 1; i++)
			{
				if (i == wInfoServer / 140)
				{
					g.drawRegion(AvMain.imgBackInfo, 0, 0, wInfoServer % 140, 20, 0, GameCanvas.hw - wInfoServer / 2 + i * 140, num, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(AvMain.imgBackInfo, GameCanvas.hw - wInfoServer / 2 + i * 140, num, 0, mGraphics.isFalse);
				}
			}
			mFont.tahoma_7_yellow.drawString(g, strInfoServer, GameCanvas.hw + wInfoServer / 2 - xPaintInfo, num + 4, 0, mGraphics.isTrue);
			num += hImgInfo;
		}
		if (strInfoCharServer != null)
		{
			g.setClip(GameCanvas.hw - wInfoServer / 2, num, wInfoServer, 20);
			for (int j = 0; j < wInfoServer / 140 + 1; j++)
			{
				if (j == wInfoServer / 140)
				{
					g.drawRegion(AvMain.imgBackInfo, 0, 0, wInfoServer % 140, 20, 0, GameCanvas.hw - wInfoServer / 2 + j * 140, num, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(AvMain.imgBackInfo, GameCanvas.hw - wInfoServer / 2 + j * 140, num, 0, mGraphics.isFalse);
				}
			}
			mFont.tahoma_7b_white.drawString(g, strInfoCharServer, GameCanvas.hw + wInfoServer / 2 - xPaintInfoChar, num + 4, 0, mGraphics.isTrue);
			num += hImgInfo;
		}
		if (strInfoCharCline != null)
		{
			g.setClip(GameCanvas.hw - 70, num, 140, 20);
			g.drawImage(AvMain.imgBackInfo, GameCanvas.hw - 70, num + ydInfoChar, 0, mGraphics.isFalse);
			mFont.tahoma_7_white.drawString(g, strInfoCharCline, GameCanvas.hw, num + 4 + ydInfoChar, 2, mGraphics.isTrue);
		}
		GameCanvas.resetTrans(g);
	}

	public void PaintIconPlayer(mGraphics g)
	{
		int num = 102;
		int num2 = 8 - hShowInGame;
		if (GameCanvas.isSmallScreen)
		{
			num = 90;
			num2 = 7 - hShowInGame;
		}
		if (Player.diemTiemNang > 0 && !isMapThachdau())
		{
			fralevelup.drawFrame(GameCanvas.gameTick / 4 % 2, num, num2, 0, 3, g);
		}
		if (Player.diemKyNang > 0 && !isMapThachdau())
		{
			fralevelup.drawFrame(2 + GameCanvas.gameTick / 4 % 2, num, num2 + 14, 0, 3, g);
		}
		if (Player.isAutoFire > -1)
		{
			g.drawImage(imgauto, num + 1, num2 + 28, 3, mGraphics.isFalse);
		}
		if (Player.typeX2 == 1)
		{
			if (GameCanvas.gameTick % 200 < 100)
			{
				g.drawImage(imgxp, num + 1, num2 + 42, 3, mGraphics.isFalse);
			}
			else
			{
				mFont.tahoma_7_green.drawString(g, getTimex2(), num - 7, num2 + 36, 0, mGraphics.isFalse);
			}
		}
	}

	public string getTimex2()
	{
		if (Player.timeX2 > 0 && (GameCanvas.timeNow - Player.timeSetX2) / 1000 > 60)
		{
			Player.timeSetX2 += 60000L;
			Player.timeX2--;
		}
		return getStringTime(Player.timeX2);
	}

	public static string getStringTime(int time)
	{
		if (time >= 60)
		{
			return time / 60 + "h" + time % 60 + "'";
		}
		return time + "'";
	}

	public static string getStringTime2(int time)
	{
		return time / 60 + "'";
	}

	public void updateInfoServer()
	{
		if (GameScreen.VecInfoServer.size() <= 0)
		{
			return;
		}
		if (strInfoServer == null)
		{
			strInfoServer = (string)GameScreen.VecInfoServer.elementAt(0);
			if (strInfoServer != null && strInfoServer.Trim().Length > 0)
			{
				GameCanvas.msgchat.addNewChat(T.tinden, T.text2kenhthegioi, strInfoServer, ChatDetail.TYPE_SERVER, false);
			}
			int num = GameScreen.VecInfoServer.size();
			if (num < 2)
			{
				speedInfo = 2;
			}
			else if (num < 5)
			{
				speedInfo = 3;
			}
			else
			{
				speedInfo = 4;
			}
			xPaintInfo = 0;
			xmaxInfo = mFont.tahoma_7_white.getWidth(strInfoServer) + wInfoServer;
			if (xmaxInfo < wInfoServer)
			{
				xmaxInfo = wInfoServer;
			}
		}
		else
		{
			if (xPaintInfo >= xmaxInfo)
			{
				timepaintServer++;
				timepaintServer = 0;
				strInfoServer = null;
				GameScreen.VecInfoServer.removeElementAt(0);
			}
			xPaintInfo += speedInfo;
		}
	}

	public void updateInfoCharServer()
	{
		if (GameScreen.VecInfoChar.size() <= 0)
		{
			return;
		}
		if (strInfoCharServer == null)
		{
			strInfoCharServer = (string)GameScreen.VecInfoChar.elementAt(0);
			int num = GameScreen.VecInfoChar.size();
			if (num < 2)
			{
				speedInfoChar = 2;
			}
			else if (num < 5)
			{
				speedInfoChar = 3;
			}
			else
			{
				speedInfoChar = 4;
			}
			xPaintInfoChar = 0;
			xmaxInfoChar = mFont.tahoma_7b_white.getWidth(strInfoCharServer) + wInfoServer;
			if (xmaxInfoChar < wInfoServer)
			{
				xmaxInfoChar = wInfoServer;
			}
		}
		else
		{
			if (xPaintInfoChar >= xmaxInfoChar)
			{
				timePaintInfoChar = 0;
				strInfoCharServer = null;
				GameScreen.VecInfoChar.removeElementAt(0);
			}
			xPaintInfoChar += speedInfoChar;
		}
	}

	public void paintInfoFocus(mGraphics g)
	{
		if (isMapThachdau() || (!isPaintInfoFocus && !Main.isPC && isLevelPoint) || GameScreen.ObjFocus == null)
		{
			return;
		}
		int num = 0;
		int num2 = yFocus - hShowInGame + 2;
		num = xFocus;
		if (isMapchienthanh())
		{
			num = GameCanvas.w - 62;
			num2 = yFocus - hShowInGame + 2 + GameCanvas.hText;
		}
		MainObject objFocus = GameScreen.ObjFocus;
		if (objFocus.typeObject == 3)
		{
			AvMain.Font3dColor(g, objFocus.name, num + 48, num2 + 2, 1, objFocus.colorName);
		}
		else if (objFocus.typeObject == 0 || objFocus.typeObject == 1)
		{
			if (objFocus.myClan != null && objFocus.typeSpec == 0)
			{
				int num3 = mFont.tahoma_7b_white.getWidth(objFocus.name) + 1;
				objFocus.paintIconClan(g, num + 48 - num3 / 2, num2 + 7, 2);
				num2 += 12;
			}
			if (objFocus.typeObject == 1)
			{
				sbyte colorName = objFocus.colorName;
				AvMain.Font3dColorAndColor(g, objFocus.name, num + 48, num2 + 2, 1, 7, colorName);
			}
			else
			{
				AvMain.Font3dWhite(g, objFocus.name, num + 48, num2 + 2, 1);
			}
			num2 += 10;
			AvMain.Font3dColorAndColor(g, T.Lv + objFocus.Lv, num + 48, num2 + 2, 1, 7, objFocus.colorName);
		}
		else
		{
			AvMain.Font3dWhite(g, objFocus.name, num + 48, num2 + 2, 1);
		}
		if (objFocus.typeObject != 0 && objFocus.typeObject != 1 && objFocus.typeObject != 2)
		{
			return;
		}
		g.drawImage(AvMain.imgcolorhpSmall_back, num - 4, num2 + 14, 0, mGraphics.isFalse);
		int num4 = 0;
		if (objFocus.maxHp > 0 && objFocus.hp > 0)
		{
			long num5 = 50L;
			long num6 = objFocus.hp;
			long num7 = num5 * num6;
			num4 = (int)(num7 / objFocus.maxHp);
			if (num4 <= 0)
			{
				num4 = 1;
			}
			else if (num4 > 50)
			{
				num4 = 50;
			}
			g.drawRegion(AvMain.imgcolorhpSmall, 0, 0, num4 + 1, 7, 0, num - 4, num2 + 14, 0, mGraphics.isFalse);
		}
		mFont.tahoma_7_white.drawString(g, objFocus.hp + "/" + objFocus.maxHp, num - 4 + 26, num2 + 20, 2, mGraphics.isFalse);
	}

	public void updateInfoChar()
	{
		if (strInfoCharCline != null)
		{
			timeInfoCharCline++;
			if (timeInfoCharCline >= 120)
			{
				timeInfoCharCline = 0;
				strInfoCharCline = null;
			}
			if (ydInfoChar > 0)
			{
				ydInfoChar -= 2;
			}
		}
		if (!GameCanvas.isTouch && timeChange > 0)
		{
			timeChange++;
			if (timeChange > 8)
			{
				timeChange = 0;
				Player.levelTab++;
				if (Player.levelTab > 2)
				{
					Player.levelTab = 0;
				}
			}
		}
		if (timeNameMap > 0)
		{
			if (timeNameMap == 20)
			{
				vyNameMap = 10;
			}
			else if (timeNameMap < 20 && vyNameMap > -20)
			{
				vyNameMap -= 4;
			}
			if (yNameMap > -30)
			{
				yNameMap += vyNameMap;
			}
			else
			{
				timeNameMap = 0;
			}
		}
	}

	public void updateEvent()
	{
		if (EventScreen.vecEventShow.size() > 0)
		{
			if (eventShow == null)
			{
				eventShow = (MainEvent)EventScreen.vecEventShow.elementAt(0);
				timeEvent = 100;
				hShowEvent = 0;
			}
			else
			{
				timeEvent--;
				if (timeEvent <= 0)
				{
					eventShow = null;
					EventScreen.vecEventShow.removeElementAt(0);
				}
				if (hShowEvent < 35)
				{
					hShowEvent += 10;
				}
				if (hShowEvent > 35)
				{
					hShowEvent = 35;
				}
			}
			if (GameCanvas.isPointSelect(GameCanvas.hw - wShowEvent / 2, 0, wShowEvent, 35))
			{
				MainEvent mainEvent = EventScreen.setEvent(eventShow.nameEvent, (sbyte)eventShow.IDCmd);
				if (mainEvent != null)
				{
					GameCanvas.mevent.doEvent(false, mainEvent);
				}
				if (timeEvent > 40)
				{
					timeEvent = 40;
				}
				GameCanvas.isPointerSelect = false;
			}
			if (GameCanvas.keyMyHold[11])
			{
				GameCanvas.clearKeyHold(11);
				int num = EventScreen.setIndexEvent(eventShow.nameEvent, (sbyte)eventShow.IDCmd);
				if (num >= 0)
				{
					GameCanvas.mevent.idSelect = num;
				}
				GameCanvas.mevent.init();
				GameCanvas.mevent.Show(GameCanvas.currentScreen);
			}
		}
		else if (hShowEvent > 0)
		{
			hShowEvent -= 20;
		}
	}

	public void paintShowEvent(mGraphics g)
	{
		if (eventShow != null || hShowEvent > 0)
		{
			GameCanvas.resetTrans(g);
			int num = GameCanvas.hw - wShowEvent / 2;
			int indexcolor = 2;
			if (GameCanvas.gameTick % 16 > 7)
			{
				indexcolor = 12;
			}
			AvMain.paintDialogNew(g, num, -5, wShowEvent, hShowEvent + 5, indexcolor);
			if (eventShow != null)
			{
				fraEvent.drawFrame(eventShow.IDCmd * 2, num + 20, -35 + hShowEvent + 17 + 3, 0, 3, g);
				mFont.tahoma_7b_white.drawString(g, eventShow.nameEvent, num + 35, -35 + hShowEvent + 5, 0, mGraphics.isTrue);
				mFont.tahoma_7_white.drawString(g, eventShow.contentEvent, num + 42, -35 + hShowEvent + 18, 0, mGraphics.isTrue);
			}
		}
	}

	public void paintPoiterAll(mGraphics g)
	{
		if (!GameCanvas.isTouch)
		{
			return;
		}
		for (int i = 0; i < mPosOther.Length; i++)
		{
			if (i == 3 && isLevelPoint)
			{
				continue;
			}
			int num = 0;
			if (timePointer > 0 && keyPoint == 100 + i)
			{
				num = 1;
			}
			if (GameScreen.player.Action == 4)
			{
				continue;
			}
			int num2 = mPosOther[i][0];
			int num3 = mPosOther[i][1];
			switch (i)
			{
			case 0:
				num3 -= hShowInGame;
				break;
			case 1:
				num2 -= hShowInGame;
				break;
			case 4:
				num3 += hShowInGame;
				break;
			default:
				num2 += hShowInGame;
				break;
			}
			bool flag = true;
			if (i == 0 && GameScreen.player.Lv > 10)
			{
				flag = false;
			}
			if (!flag)
			{
				continue;
			}
			if (i != 1)
			{
				g.drawRegion(imgOther[i], 0, num * mSizeImgOther[i][1], mSizeImgOther[i][0], mSizeImgOther[i][1], 0, num2, num3, 0, mGraphics.isFalse);
				continue;
			}
			g.drawRegion(imgOther[i], 0, 0, mSizeImgOther[i][0], mSizeImgOther[i][1], 0, num2, num3, 0, mGraphics.isTrue);
			if (timeDownChat != -1 && mSystem.currentTimeMillis() - timeDownChat >= 100)
			{
				if (GameCanvas.gameTick % 2 == 0)
				{
					hClip++;
				}
				if (hClip >= mSizeImgOther[i][1])
				{
					hClip = mSizeImgOther[i][1];
				}
			}
			g.setClip(num2, num3, mSizeImgOther[i][0], hClip);
			g.drawRegion(imgOther[i], 0, mSizeImgOther[i][1], mSizeImgOther[i][0], mSizeImgOther[i][1], 0, num2, num3, 0, mGraphics.isTrue);
			GameCanvas.resetTrans(g);
		}
		if (GameScreen.player.Action == 4)
		{
			return;
		}
		if (isLevelPoint)
		{
			paintKillPlayer(g);
			return;
		}
		g.drawImage(imgMove[0], xPointMove - hShowInGame, yPointMove, 3, mGraphics.isFalse);
		for (int j = 0; j < 4; j++)
		{
			if (timePointer > 0 && mKeyMove[j] == keyPoint)
			{
				g.drawRegion(imgMove[2], 0, 0, 32, 56, mRotateMove[j] + ((j > 1) ? 4 : 0), mPosMove[j][0] - hShowInGame, mPosMove[j][1], 3, mGraphics.isFalse);
			}
		}
		int num4 = 0;
		if (timePointer > 0 && keyPoint == 5)
		{
			num4 = 1;
		}
		g.drawImage(AvMain.imgHotKey, xPointKill + hShowInGame, yPointKill, 3, mGraphics.isFalse);
		if (timeChange == 0)
		{
			if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeBoss == 2)
			{
				for (int k = 0; k < 5; k++)
				{
					int y = 0;
					if (timePointer > 0 && keyPoint == mValueHotKey[k])
					{
						y = 1;
					}
					int num5 = 0;
					int num6 = 0;
					if (k == 2)
					{
						num5 = xPointKill + hShowInGame;
						num6 = yPointKill;
					}
					else
					{
						num5 = mPosKill[k - ((k > 2) ? 1 : 0)][0] + hShowInGame;
						num6 = mPosKill[k - ((k > 2) ? 1 : 0)][1];
					}
					g.drawRegion(imgFire[1], 0, y, 50, 50, 0, num5, num6, 3, mGraphics.isFalse);
					g.drawImage(AvMain.imgHotKey, num5, num6, 3, mGraphics.isFalse);
					AvMain.Font3dWhite(g, mValueHotKey[k] + string.Empty, num5, num6 - 5, 2);
				}
				return;
			}
			HotKey hotKey = Player.mhotkey[Player.levelTab][2];
			if (GameScreen.player.checkGiaoTiep())
			{
				g.drawImage(AvMain.imgicongt, xPointKill + hShowInGame, yPointKill, 3, mGraphics.isFalse);
			}
			else if (hotKey != null && hotKey.type == HotKey.SKILL)
			{
				Skill skillFormId = MainListSkill.getSkillFormId(hotKey.id);
				if (skillFormId != null)
				{
					skillFormId.paint(g, xPointKill + hShowInGame, yPointKill, 3);
				}
			}
			else if (hotKey != null && hotKey.type == HotKey.POTION)
			{
				Item itemInventory = Item.getItemInventory(4, hotKey.id);
				if (itemInventory != null)
				{
					itemInventory.paintItem(g, xPointKill + hShowInGame, yPointKill, MainTabNew.wOneItem, 0, 3);
				}
			}
			for (int l = 0; l < mPosKill.Length; l++)
			{
				int num7 = 0;
				if (timePointer > 0 && keyPoint == mKeySkill[l])
				{
					num7 = 1;
				}
				g.drawRegion(imgFire[1], 0, num7 * 50, 50, 50, 0, mPosKill[l][0] + hShowInGame, mPosKill[l][1], 3, mGraphics.isFalse);
				g.drawImage(AvMain.imgHotKey, mPosKill[l][0] + hShowInGame, mPosKill[l][1], 3, mGraphics.isFalse);
				hotKey = Player.mhotkey[Player.levelTab][l + ((l > 1) ? 1 : 0)];
				if (hotKey != null && hotKey.type == HotKey.SKILL)
				{
					Skill skillFormId2 = MainListSkill.getSkillFormId(hotKey.id);
					if (skillFormId2 != null)
					{
						skillFormId2.paint(g, mPosKill[l][0] + hShowInGame, mPosKill[l][1], 3);
					}
				}
				else
				{
					if (hotKey == null || hotKey.type != HotKey.POTION || !MainTemplateItem.isload)
					{
						continue;
					}
					Item itemInventory2 = Item.getItemInventory(4, hotKey.id);
					if (itemInventory2 != null)
					{
						if (MainTemplateItem.isload)
						{
							itemInventory2.paintItem(g, mPosKill[l][0] + hShowInGame, mPosKill[l][1], MainTabNew.wOneItem, 0, 3);
						}
					}
					else
					{
						hotKey.setHotKey(0, HotKey.NULL, 0);
						MainItem.setAddHotKey(1, false);
						MainItem.setAddHotKey(0, false);
					}
				}
			}
			for (int m = 0; m < 5; m++)
			{
				HotKey hotKey2 = Player.mhotkey[Player.levelTab][m];
				if (hotKey2 == null || hotKey2.type == HotKey.NULL)
				{
					continue;
				}
				int num8 = 0;
				int num9 = 0;
				if (m == 2)
				{
					num8 = xPointKill + hShowInGame;
					num9 = yPointKill;
				}
				else
				{
					num8 = mPosKill[m - ((m > 2) ? 1 : 0)][0] + hShowInGame;
					num9 = mPosKill[m - ((m > 2) ? 1 : 0)][1];
				}
				DelaySkill delaySkill = null;
				if (hotKey2 != null && hotKey2.type == HotKey.SKILL)
				{
					delaySkill = Player.timeDelaySkill[hotKey2.id];
				}
				else if (hotKey2 != null && hotKey2.type == HotKey.POTION && MainTemplateItem.isload)
				{
					Item itemInventory3 = Item.getItemInventory(4, hotKey2.id);
					if (itemInventory3 != null && itemInventory3.typePotion < 2)
					{
						delaySkill = Player.timeDelayPotion[itemInventory3.typePotion];
					}
				}
				if (delaySkill == null || delaySkill.limit <= 0)
				{
					continue;
				}
				if (delaySkill.value > 0)
				{
					int num10 = delaySkill.value * 20 / delaySkill.limit;
					if (num10 < 1)
					{
						num10 = 1;
					}
					g.drawRegion(AvMain.imgDelaySkill, 0, 0, 20, num10, 0, num8 - 10, num9 - 10, 0, mGraphics.isFalse);
					int num11 = delaySkill.value / 1000;
					string empty = string.Empty;
					empty = ((num11 != 0) ? (string.Empty + num11) : ("0." + delaySkill.value % 1000 / 100));
					mFont.tahoma_7b_white.drawString(g, empty, num8, num9 - 5, 2, mGraphics.isFalse);
				}
				else if (delaySkill.value > -150)
				{
					g.setColor(15658700);
					g.fillRoundRect(num8 - 10, num9 - 10, 20, 20, 4, 4, mGraphics.isFalse);
				}
			}
		}
		else
		{
			paintChangeTab(g);
		}
		g.drawRegion(imgFire[0], 0, num4 * 50, 50, 50, 0, xPointKill + hShowInGame, yPointKill, 3, mGraphics.isFalse);
	}

	public void updatePoiterAll()
	{
		if (timePointer > 0)
		{
			timePointer--;
		}
		if (timeChange > 0)
		{
			timeChange++;
			if (timeChange > 6)
			{
				timeChange = 0;
				Player.levelTab++;
				if (Player.levelTab > 2)
				{
					Player.levelTab = 0;
				}
			}
		}
		if (LoadMap.isShowEffAuto == LoadMap.EFF_PHOBANG_END)
		{
			return;
		}
		bool flag = true;
		if (GameCanvas.isPointerSelect)
		{
			if (isLevelPoint)
			{
				if (GameCanvas.isPoint(xPaintSkill + 11 - wSkill / 2, yPaintSkill + 11 - wSkill / 2, 5 * wSkill, wSkill))
				{
					int num = (GameCanvas.px - xPaintSkill + 11) / wSkill;
					GameCanvas.isPointerSelect = false;
					if (num >= 0 && num < Player.mhotkey[Player.levelTab].Length)
					{
						HotKey hotKey = Player.mhotkey[Player.levelTab][num];
						if (isLevelPoint)
						{
							if (hotKey.type == HotKey.SKILL)
							{
								if (GameScreen.ObjFocus != null)
								{
									GameScreen.player.setActionHotKey(num, false);
								}
							}
							else
							{
								if (num == 2)
								{
									keyPoint = 5;
								}
								else
								{
									keyPoint = mKeySkill[(num <= 1) ? num : (num - 1)];
								}
								int num2 = 20 + keyPoint;
								if (Main.isPC && !Player.isCapCha())
								{
									switch (num2)
									{
									case 27:
										num2 = 4;
										break;
									case 29:
										num2 = 5;
										break;
									}
									switch (num2)
									{
									case 21:
										num2 = 1;
										break;
									case 23:
										num2 = 2;
										break;
									case 25:
										num2 = 3;
										break;
									}
								}
								GameCanvas.keyMyPressed[num2] = true;
							}
						}
						timePointer = 3;
						flag = false;
					}
				}
			}
			else if (GameCanvas.isPoint(xPointKill - wMainSkill / 2, yPointKill - wMainSkill / 2, wMainSkill, wMainSkill))
			{
				GameCanvas.isPointerSelect = false;
				keyPoint = 5;
				timePointer = 3;
				GameCanvas.keyMyPressed[25] = true;
				GameCanvas.keyMyPressed[5] = true;
				flag = false;
			}
			else
			{
				for (int i = 0; i < mPosKill.Length; i++)
				{
					if (GameCanvas.isPoint(mPosKill[i][0] - wSkill / 2, mPosKill[i][1] - wSkill / 2, wSkill, wSkill))
					{
						GameCanvas.isPointerSelect = false;
						keyPoint = mKeySkill[i];
						GameCanvas.keyMyPressed[20 + keyPoint] = true;
						timePointer = 3;
						flag = false;
						break;
					}
				}
			}
			if (GameCanvas.isPointerSelect)
			{
				for (int j = 0; j < mPosOther.Length; j++)
				{
					if ((j != 3 || !isLevelPoint) && GameCanvas.isPoint(mPosOther[j][0] - 2, mPosOther[j][1] - 2, mSizeImgOther[j][0] + 4, mSizeImgOther[j][1] + 4))
					{
						GameCanvas.isPointerSelect = false;
						if (j == 1 && timeDownChat == -1)
						{
							timeDownChat = mSystem.currentTimeMillis();
						}
						selectPointer(j);
						flag = false;
						break;
					}
				}
				if (GameCanvas.isPoint(MainTabNew.gI().xChar, MainTabNew.gI().yChar, 90, 35))
				{
					GameCanvas.isPointerSelect = false;
					selectPointer(0);
					flag = false;
					return;
				}
				if (GameCanvas.isPoint(xMess - 4, yMess - 4, 24, 20))
				{
					GameCanvas.isPointerSelect = false;
					selectPointer(-1);
				}
				if (GameCanvas.isPoint(GameCanvas.w - 50, GameCanvas.minimap.maxY * MiniMap.wMini - 8, 50, 30))
				{
					GameCanvas.isPointerSelect = false;
					selectPointer(-2);
				}
				else if (GameCanvas.isPoint(GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini, 0, GameCanvas.minimap.maxX * MiniMap.wMini, GameCanvas.minimap.maxY * MiniMap.wMini) && !isMapThachdau())
				{
					GameCanvas.isPointerSelect = false;
					selectPointer(-4);
				}
				if (GameCanvas.isPoint(95, 0, 24, 40))
				{
					GameCanvas.isPointerSelect = false;
					selectPointer(-3);
				}
				for (int k = 0; k < LoadMap.vecPointChange.size(); k++)
				{
					Point point = (Point)LoadMap.vecPointChange.elementAt(k);
					int num3 = point.x - MainScreen.cameraMain.xCam;
					int num4 = point.y - MainScreen.cameraMain.yCam;
					if (GameCanvas.isPoint(num3 - 12, num4 - 12, 24, 24))
					{
						GameScreen.player.toX = GameScreen.player.x;
						GameScreen.player.toY = GameScreen.player.y;
						posTam = GameCanvas.game.updateFindRoad(point.x / LoadMap.wTile, point.y / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 16);
						if (posTam != null && posTam.Length > 16)
						{
							posTam = null;
						}
						GameScreen.player.posTransRoad = posTam;
						Player.xFocus = point.x;
						Player.yFocus = point.y;
						Player.timeFocus = 9;
						GameCanvas.isPointerSelect = false;
						if (Player.isAutoFire == 1)
						{
							Player.setCurAutoFire();
						}
						break;
					}
				}
			}
		}
		else if (!isLevelPoint)
		{
			if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
			{
				for (int l = 0; l < mPosOther.Length; l++)
				{
					if (GameCanvas.isPoint(mPosOther[l][0] - 4, mPosOther[l][1] - 4, mSizeImgOther[l][0] + 8, mSizeImgOther[l][1] + 8))
					{
						if (l == 1 && timeDownChat == -1)
						{
							timeDownChat = mSystem.currentTimeMillis();
						}
						keyPoint = 100 + l;
						timePointer = 3;
						break;
					}
				}
				if (GameCanvas.isPointLast(xPointMove - 2 * wArrowMove, yPointMove - 2 * wArrowMove, wArrowMove * 4, wArrowMove * 4))
				{
					int num5 = CRes.angle(GameCanvas.px - xPointMove, GameCanvas.py - yPointMove);
					int num6 = 0;
					num6 = ((num5 > 45 && num5 <= 135) ? 3 : ((num5 <= 135 || num5 > 225) ? ((num5 <= 225 || num5 > 315) ? 1 : 2) : 0));
					GameCanvas.clearKeyHold();
					GameCanvas.isPointerDown = true;
					GameCanvas.isPointerSelect = false;
					keyPoint = mKeyMove[num6];
					GameCanvas.keyMyHold[keyPoint] = true;
					timePointer = 3;
					flag = false;
					if (Player.isAutoFire == 1)
					{
						Player.setCurAutoFire();
					}
				}
			}
		}
		else if (isLevelPoint && (GameCanvas.isPointerDown || GameCanvas.isPointerMove))
		{
			for (int m = 0; m < mPosOther.Length; m++)
			{
				if (GameCanvas.isPoint(mPosOther[m][0] - 4, mPosOther[m][1] - 4, mSizeImgOther[m][0] + 8, mSizeImgOther[m][1] + 8))
				{
					if (m == 1 && timeDownChat == -1)
					{
						timeDownChat = mSystem.currentTimeMillis();
					}
					keyPoint = 100 + m;
					timePointer = 3;
					break;
				}
			}
		}
		if (flag)
		{
			updatePointMoveIngame();
		}
		if (!isLevelPoint || GameCanvas.currentScreen != GameCanvas.game)
		{
			return;
		}
		if (GameCanvas.isPointerMove)
		{
			if (!GameScreen.isMoveCamera && (CRes.abs(GameCanvas.px - GameCanvas.pxLast) > 36 || CRes.abs(GameCanvas.py - GameCanvas.pyLast) > 36))
			{
				GameScreen.isMoveCamera = true;
			}
			GameScreen.xMoveCam = GameCanvas.px - GameCanvas.pxLast;
			GameScreen.yMoveCam = GameCanvas.py - GameCanvas.pyLast;
			GameScreen.timeResetCam = 40;
		}
		else if (GameCanvas.isPointerDown)
		{
			GameScreen.xCur = MainScreen.cameraMain.xCam;
			GameScreen.yCur = MainScreen.cameraMain.yCam;
			GameScreen.xMoveCam = 0;
			GameScreen.yMoveCam = 0;
		}
	}

	public void updatePointMoveIngame()
	{
		if (GameCanvas.isPointerSelect)
		{
			if (!isLevelPoint && (GameCanvas.isPoint(xPointKill - lSkill - 25, yPointKill - lSkill - 25, lSkill * 2 + 50, lSkill * 2 + 50) || GameCanvas.isPoint(xPointMove - wArrowMove - 30, yPointMove - wArrowMove - 30, wArrowMove * 2 + 60, wArrowMove * 2 + 60)) && GameScreen.player.Action != 4)
			{
				GameCanvas.isPointerSelect = false;
				GameCanvas.isPointerDown = false;
				return;
			}
			int num = GameCanvas.px + MainScreen.cameraMain.xCam;
			int num2 = GameCanvas.py + MainScreen.cameraMain.yCam;
			MainObject mainObject = null;
			if ((GameScreen.ObjFocus == null || GameScreen.ObjFocus.typeBoss != 2) && (MainObject.getDistance(num, num2, GameScreen.player.x, GameScreen.player.y) <= GameScreen.player.wFocus - 15 || GameScreen.player.Action == 4))
			{
				mainObject = setObjectNear(num, num2);
				if (mainObject != null && mainObject.typeObject != 1 && Player.isAutoFire == 1)
				{
					Player.setCurAutoFire();
				}
			}
			if (isTouchFocus && GameCanvas.isTouch)
			{
				if (mainObject != null)
				{
					if (!mainObject.canFocus() || (isMarket(GameCanvas.loadmap.idMap) && !mainObject.isSelling() && mainObject.typeObject == 0))
					{
						return;
					}
					mainObject.timeStand = 5;
					GameScreen.ObjFocus = mainObject;
					GameCanvas.isPointerSelect = false;
					if (MainObject.getDistance(mainObject.x, mainObject.y, GameScreen.player.x, GameScreen.player.y) <= GameScreen.player.wFocus)
					{
						GameScreen.player.setPointFocus();
						isPaintInfoFocus = true;
						GameScreen.addEffectKill(68, GameScreen.player.ID, 0, GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject, 0, GameScreen.ObjFocus.hp, (sbyte)((GameScreen.ObjFocus.typeObject != 1) ? 1 : 0));
						posTam = null;
					}
					if (GameCanvas.isPointerSelect)
					{
						int tile = GameCanvas.loadmap.getTile(num, num2);
						if (tile != -1 && tile != 1)
						{
							GameScreen.player.toX = GameScreen.player.x;
							GameScreen.player.toY = GameScreen.player.y;
							posTam = GameCanvas.game.updateFindRoad(num / LoadMap.wTile, num2 / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 100);
							if (posTam != null && posTam.Length > 100)
							{
								posTam = null;
							}
							timeMove = 3;
							GameCanvas.isPointerSelect = false;
							Player.xFocus = num;
							Player.yFocus = num2;
						}
						else
						{
							posTam = null;
						}
					}
				}
				else
				{
					if (GameScreen.player.Action == 4)
					{
						return;
					}
					int tile2 = GameCanvas.loadmap.getTile(num, num2);
					if (tile2 != -1 && tile2 != 1)
					{
						GameScreen.player.toX = GameScreen.player.x;
						GameScreen.player.toY = GameScreen.player.y;
						posTam = GameCanvas.game.updateFindRoad(num / LoadMap.wTile, num2 / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 100);
						if (posTam != null && posTam.Length > 100)
						{
							posTam = null;
						}
						if (GameScreen.player.posTransRoad != null)
						{
							timeMove = 1;
						}
						else
						{
							timeMove = 3;
						}
						GameCanvas.isPointerSelect = false;
						Player.xFocus = num;
						Player.yFocus = num2;
					}
					else
					{
						posTam = null;
						GameCanvas.isPointerSelect = false;
					}
				}
			}
			else if (!isLevelPoint && mainObject != null && mainObject.typeObject != 9 && mainObject.typeObject != 10 && !mainObject.isLuaThieng() && !mainObject.isDongBang)
			{
				vecfocus.removeAllElements();
				if (GameScreen.ObjFocus == mainObject)
				{
					if (Player.mhotkey[Player.levelTab][2].type == HotKey.SKILL)
					{
						GameCanvas.keyMyPressed[25] = true;
						GameCanvas.keyMyPressed[5] = true;
					}
					timeMove = 0;
					posTam = null;
				}
				else
				{
					if (!mainObject.canFocus())
					{
						return;
					}
					mainObject.timeStand = 5;
					GameScreen.ObjFocus = mainObject;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		if (!isLevelPoint || timeMove <= 0)
		{
			return;
		}
		if (timeMove == 1 && posTam != null && GameScreen.player.Action != 4 && GameScreen.player.Action != 2 && GameScreen.player.currentQuest == null)
		{
			GameScreen.player.xStopMove = 0;
			GameScreen.player.yStopMove = 0;
			if (GameScreen.player.posTransRoad != null)
			{
				GameScreen.player.countAutoMove = 1;
			}
			GameScreen.player.resetMove();
			GameScreen.player.posTransRoad = posTam;
			posTam = null;
			Player.timeFocus = 9;
			if (Player.timeResetAuto <= 0 && Player.isAutoFire == 1)
			{
				Player.setCurAutoFire();
			}
		}
		timeMove--;
	}

	public MainObject setObjectNear(int x, int y)
	{
		MainObject mainObject = null;
		MainObject mainObject2 = null;
		int num = 40;
		bool flag = false;
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject3 = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
			{
				if ((mainObject3.typePk == GameScreen.player.typePk || mainObject3 == null || mainObject3 == GameScreen.player || mainObject3.typeObject == 9 || mainObject3.isLuaThieng() || mainObject3.typeObject == 10 || mainObject3.isDongBang) && mainObject3.typeObject != 2)
				{
					continue;
				}
			}
			else if (mainObject3 == null || mainObject3 == GameScreen.player || mainObject3.typeObject == 9 || mainObject3.isDongBang || mainObject3.typeObject == 10 || mainObject3.isThacNuoc() || mainObject3.isLuaThieng())
			{
				continue;
			}
			if (mainObject3.Action == 4 && mainObject3.typeObject == 1)
			{
				continue;
			}
			int distance = MainObject.getDistance(x, y, mainObject3.x, mainObject3.y - mainObject3.hOne / 4);
			if (distance >= num && (!GameCanvas.loadmap.mapLang() || mainObject3.typeObject != 2 || distance >= 40 || !Player.isFocusNPC))
			{
				continue;
			}
			if (!flag)
			{
				flag = true;
				mainObject2 = mainObject3;
			}
			bool flag2 = true;
			for (int j = 0; j < vecfocus.size(); j++)
			{
				MainObject mainObject4 = (MainObject)vecfocus.elementAt(j);
				if (mainObject4 != null && mainObject4 != null && mainObject3.ID == mainObject4.ID)
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				mainObject = mainObject3;
				num = distance;
			}
			if (mainObject3.typeObject == 2 && Player.isFocusNPC)
			{
				vecfocus.addElement(mainObject);
				Player.isFocusNPC = false;
				Player.timeFocusNPC = 0;
				return mainObject;
			}
		}
		if (flag && mainObject == null)
		{
			vecfocus.removeAllElements();
			mainObject = mainObject2;
		}
		if (mainObject != null)
		{
			vecfocus.addElement(mainObject);
		}
		else
		{
			vecfocus.removeAllElements();
		}
		return mainObject;
	}

	public void paintChangeTab(mGraphics g)
	{
		int num = gocBegin;
		if (timeChange > 0)
		{
			num -= timeChange * 30;
		}
		for (int i = 0; i < 8; i++)
		{
			int x = xPointKill + CRes.cos(CRes.fixangle(num)) * lSkill / 1000 + hShowInGame;
			int y = yPointKill + CRes.sin(CRes.fixangle(num)) * lSkill / 1000;
			g.drawImage(AvMain.imgHotKey, x, y, 3, mGraphics.isFalse);
			int num2 = Player.levelTab;
			if (i > 3)
			{
				num2 = ((Player.levelTab == 0) ? 1 : 0);
			}
			HotKey hotKey = Player.mhotkey[num2][i % 4 + ((i % 4 > 1) ? 1 : 0)];
			if (hotKey != null && hotKey.type == HotKey.SKILL)
			{
				Skill skillFormId = MainListSkill.getSkillFormId(hotKey.id);
				skillFormId.paint(g, x, y, 3);
			}
			else if (hotKey != null && hotKey.type == HotKey.POTION)
			{
				Item itemInventory = Item.getItemInventory(4, hotKey.id);
				if (itemInventory != null)
				{
					itemInventory.paintItem(g, x, y, MainTabNew.wOneItem, 0, 3);
				}
			}
			num -= 45;
		}
	}

	public void selectPointer(int select)
	{
		switch (select)
		{
		case -4:
			if (!isMapchienthanh())
			{
				MiniMapFull_Screen.gI().Show();
				mSound.playSound(41, mSound.volumeSound);
			}
			break;
		case -3:
			if (Player.diemTiemNang > 0)
			{
				mSound.playSound(41, mSound.volumeSound);
				GameCanvas.AllInfo.Show(GameCanvas.currentScreen);
				GameCanvas.AllInfo.selectTab = 2;
			}
			else if (Player.diemKyNang > 0)
			{
				mSound.playSound(41, mSound.volumeSound);
				GameCanvas.AllInfo.Show(GameCanvas.currentScreen);
				GameCanvas.AllInfo.selectTab = 3;
			}
			break;
		case -2:
			break;
		case -1:
			if (numMess > 0)
			{
				mSound.playSound(41, mSound.volumeSound);
				GameCanvas.mevent.init();
				GameCanvas.mevent.Show(GameCanvas.currentScreen);
			}
			break;
		case 0:
			if (GameScreen.isMoveCamera)
			{
				GameScreen.isMoveCamera = false;
			}
			else
			{
				GameScreen.gI().cmdMenu.perform();
			}
			break;
		case 1:
			mSound.playSound(41, mSound.volumeSound);
			if (mSystem.currentTimeMillis() - timeDownChat <= 500)
			{
				ChatTextField.gI().setChat();
				timeDownChat = -1L;
				hClip = 0;
				newinput.TYPE_INPUT = 0;
			}
			else
			{
				GameScreen.gI().cmdQuickChat.perform();
				timeDownChat = -1L;
				hClip = 0;
			}
			break;
		case 2:
			if ((GameScreen.ObjFocus == null || GameScreen.ObjFocus.typeBoss != 2) && timeChange == 0)
			{
				mSound.playSound(41, mSound.volumeSound);
				timeChange = 1;
			}
			break;
		case 3:
			if (GameScreen.ObjFocus != null)
			{
				Player.cmdNextFocus.perform();
			}
			break;
		case 4:
			if (!ChatTextField.isShow)
			{
				GameCanvas.menu2.setAt_Quick();
			}
			break;
		}
	}

	public void paintParty(mGraphics g)
	{
		if (Player.party == null)
		{
			return;
		}
		for (int i = 0; i < Player.party.vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(i);
			if (objectParty.name.CompareTo(GameScreen.player.name) == 0 || objectParty.isRemove)
			{
			}
		}
	}

	public void paintNameMap(mGraphics g)
	{
		if (timeNameMap > 0)
		{
			timeNameMap--;
			AvMain.paintDialog(g, GameCanvas.hw - wNameMap / 2 - 10, yNameMap, wNameMap + 20, 35, 12);
			mFont.tahoma_7b_white.drawString(g, namemap, GameCanvas.hw, yNameMap + 7, 2, mGraphics.isFalse);
			mFont.tahoma_7_white.drawString(g, "- " + T.Area + LoadMap.getAreaPaint() + " -", GameCanvas.hw, yNameMap + 20, 2, mGraphics.isFalse);
		}
	}

	public void paintNameServer(mGraphics g, string servername)
	{
		if (timeNameMap > 0)
		{
			timeNameMap--;
			AvMain.paintDialog(g, GameCanvas.hw - wNameMap / 2 - 10, yNameMap, wNameMap + 20, 20, 12);
			mFont.tahoma_7b_white.drawString(g, servername, GameCanvas.hw, yNameMap + 4, 2, mGraphics.isFalse);
		}
	}

	public void setNameServer(string servername)
	{
		timeNameMap = 80;
		wNameMap = mFont.tahoma_7b_white.getWidth(servername);
		yNameMap = GameCanvas.h / 8;
		vyNameMap = 0;
		if (wNameMap < 80)
		{
			wNameMap = 80;
		}
	}

	public static void setNameMap()
	{
		timeNameMap = 80;
		namemap = "map";
		if (WorldMapScreen.namePos != null && GameCanvas.loadmap.idMap < WorldMapScreen.namePos.Length)
		{
			namemap = WorldMapScreen.namePos[GameCanvas.loadmap.idMap];
		}
		wNameMap = mFont.tahoma_7b_white.getWidth(namemap);
		yNameMap = GameCanvas.h / 8;
		vyNameMap = 0;
		if (wNameMap < 80)
		{
			wNameMap = 80;
		}
	}

	public void updateShowIngame()
	{
		if (isShowInGame)
		{
			if (GameCanvas.isSmallScreen)
			{
				if ((GameCanvas.timeNow - timeDoNotClick) / 1000 > 15)
				{
					isShowInGame = false;
				}
			}
			else if ((GameCanvas.timeNow - timeDoNotClick) / 1000 > 2)
			{
				isShowInGame = false;
			}
			if (hShowInGame > 0)
			{
				hShowInGame -= 20;
				if (hShowInGame < 0)
				{
					hShowInGame = 0;
				}
			}
		}
		else if (hShowInGame < 100)
		{
			hShowInGame += 10;
		}
	}

	public static void setPosTouch()
	{
		if (Main.isPC)
		{
			isLevelPoint = true;
		}
		if (isLevelPoint)
		{
			mPosOther[2][1] = GameCanvas.h - 31;
			mPosOther[4][0] = 0;
		}
		else
		{
			mPosOther[2][1] = GameCanvas.h - 151;
			mPosOther[4][0] = GameCanvas.hw - 20;
		}
	}

	public bool isMapCountTime(int idMap)
	{
		if (idMap == 59 || idMap == 57 || idMap == 55 || idMap == 53)
		{
			return true;
		}
		return false;
	}

	public bool isMapChienTruong(int idMap)
	{
		if (idMap == 61 || idMap == 60 || idMap == 58 || idMap == 56 || idMap == 54)
		{
			return true;
		}
		return false;
	}

	public bool isMapThachdau()
	{
		return GameScreen.isShowHoiSinh;
	}

	public bool isMapchienthanh()
	{
		return GameCanvas.loadmap.idMap == 83 || GameCanvas.loadmap.idMap == 84 || GameCanvas.loadmap.idMap == 85 || GameCanvas.loadmap.idMap == 86 || GameCanvas.loadmap.idMap == 87;
	}

	public bool ismapHouse(int idMap)
	{
		if (idMap == 60 || idMap == 58 || idMap == 56 || idMap == 54)
		{
			return true;
		}
		return false;
	}

	public bool isMapPetcage(int idmap)
	{
		return idmap == 50;
	}

	public bool isMapLight(int mapId)
	{
		return mapId == 51 || (mapId >= 37 && mapId <= 41);
	}

	public bool isMapDark(int mapId)
	{
		return mapId == 52 || mapId == 62 || (mapId >= 42 && mapId <= 45);
	}

	public bool isMapArena(int idMap)
	{
		return isMapChienTruong(idMap) || isMapCountTime(idMap);
	}

	public void setCountTimeHS(int idMap, long curtime, int timeCount)
	{
		if (isMapCountTime(idMap))
		{
			isCountTime = true;
			curTimeHS = (int)(curtime / 1000 + timeCount);
		}
		else
		{
			isCountTime = false;
			timeHS = 0;
		}
	}

	public void countTimeHS()
	{
		if (isCountTime)
		{
			if (timeHS >= 0)
			{
				timeHS = (int)(curTimeHS - mSystem.currentTimeMillis() / 1000);
				return;
			}
			isCountTime = false;
			timeHS = 0;
		}
	}

	public void paintTimeHS(mGraphics g)
	{
		if (isCountTime && timeHS >= 0)
		{
			AvMain.Font3dWhite(g, T.backBattlefield + timeHS + "s", 70 - GameCanvas.w, mPosOther[0][1] + 15, 0);
		}
	}

	public void setSttArena(sbyte type, sbyte totalHouse, short totalPlayer)
	{
		if (type != -1)
		{
			sbyte b = 0;
			b = (sbyte)((type == 4) ? 1 : ((type == 5) ? 2 : ((type == 2) ? 3 : 0)));
			if (totalHouse != -1)
			{
				this.totalHouse[b] = totalHouse;
			}
			if (totalPlayer != -1)
			{
				this.totalPlayer[b] = totalPlayer;
			}
		}
	}

	public void paintSttArena(mGraphics g, int xSttArena, int ySttArena, int wSttArena, int hSttArena)
	{
		AvMain.Font3dWhite(g, T.infoArena, xSttArena - 5, ySttArena - 2 * hSttArena, 0);
		imgArenaIcon.drawFrame(typePaint[4], xSttArena, ySttArena - hSttArena, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
		AvMain.Font3dWhite(g, string.Empty + GameScreen.player.markKiller, xSttArena + wSttArena, ySttArena - hSttArena - 3, 0);
		for (int i = 0; i < totalHouse.Length; i++)
		{
			if (totalHouse[i] > 0)
			{
				AvMain.fraPk.drawFrame(typePK[i] * 3 + GameCanvas.gameTick / 3 % 3, xSttArena, ySttArena + i * hSttArena + 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			else
			{
				AvMain.fraPk.drawFrame(typePK[4] * 3 + GameCanvas.gameTick / 3 % 3, xSttArena, ySttArena + i * hSttArena, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			imgArenaIcon.drawFrame(typePaint[i], xSttArena + wSttArena, ySttArena + i * hSttArena - 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			AvMain.Font3dWhite(g, string.Empty + totalHouse[i], xSttArena + wSttArena + 10, ySttArena + i * hSttArena - 3, 0);
			g.drawRegion(MainTabNew.imgTab[3], 0, 32, 16, 16, 0, xSttArena + 3 * wSttArena, ySttArena + i * hSttArena, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			AvMain.Font3dWhite(g, string.Empty + totalPlayer[i], xSttArena + 3 * wSttArena + 10, ySttArena + i * hSttArena - 3, 0);
		}
	}

	public void resetShip()
	{
		eff = null;
		isShipMove = false;
	}

	public void paintShip(mGraphics g)
	{
		if (GameCanvas.loadmap.idMap == 19)
		{
			if (eff == null)
			{
				eff = new EffectAuto(50, 1080, 96, 0, 0, 1, 0);
				return;
			}
			eff.update();
			if (!isShipMove)
			{
				eff.paint(g);
				return;
			}
			eff.x += 2;
			eff.paint(g);
			GameScreen.player.dyWater = 0;
			GameScreen.player.Action = 0;
			GameScreen.player.Direction = 3;
			GameScreen.player.x = eff.x + 30;
			GameScreen.player.y = eff.y - 40;
			GameScreen.player.updateActionPerson();
			GameScreen.player.paintPlayer(g, -1);
			if (eff.x > 1200)
			{
				ShipScr.gI().typeMap = 1;
				ShipScr.gI().Show();
			}
		}
		else
		{
			if (GameCanvas.loadmap.idMap != 67)
			{
				return;
			}
			if (eff == null)
			{
				eff = new EffectAuto(50, 360, 672, 0, 0, 1, 0);
				return;
			}
			eff.update();
			if (!isShipMove)
			{
				eff.paint(g);
				return;
			}
			eff.x += 2;
			eff.paint(g);
			GameScreen.player.dyWater = 0;
			GameScreen.player.Action = 0;
			GameScreen.player.Direction = 3;
			GameScreen.player.x = eff.x + 30;
			GameScreen.player.y = eff.y - 40;
			GameScreen.player.updateActionPerson();
			GameScreen.player.paintPlayer(g, -1);
			if (eff.x > 480)
			{
				ShipScr.gI().typeMap = 3;
				ShipScr.gI().Show();
			}
		}
	}

	public void paintPos_minimap(mGraphics g, int x, int y)
	{
		if (!isMapThachdau())
		{
			xPos_minimap = GameScreen.player.x / LoadMap.wTile;
			yPos_minimap = GameScreen.player.y / LoadMap.wTile;
			mFont.tahoma_7_yellow.drawString(g, xPos_minimap + ":" + yPos_minimap, x, y, 1, mGraphics.isFalse);
		}
	}

	public static void paintinfo18plush(mGraphics g)
	{
		if (paint18plush != 0)
		{
			GameCanvas.resetTrans(g);
			int x = 110;
			if (GameCanvas.currentScreen != GameCanvas.game)
			{
				x = 0;
			}
			int width = mFont.tahoma_7_white.getWidth("18+ Chơi quá 180 phút mỗi ngày sẽ hại sức khỏe.");
			g.setColor(0, 0.6f);
			g.fillRect(x, 0, width, 12, false);
			mFont.tahoma_7_white.drawString(g, "18+ Chơi quá 180 phút mỗi ngày sẽ hại sức khỏe.", x, 0, 0, false);
		}
	}

	public static bool isMarket(int idmap)
	{
		return idmap == 82;
	}

	public void paintIconClan(mGraphics g)
	{
		if (isMapchienthanh() && idicon != -1)
		{
			MainImage imageIconClan = ObjectData.getImageIconClan((short)idicon);
			if (imageIconClan.img != null)
			{
				AvMain.Font3dColor(g, nameclan.ToUpper(), GameCanvas.w / 2, 5, 2, 0);
				g.drawImage(imageIconClan.img, GameCanvas.w / 2 + mFont.tahoma_7_black.getWidth(nameclan) / 2, 10, 3, mGraphics.isFalse);
			}
		}
	}
}
