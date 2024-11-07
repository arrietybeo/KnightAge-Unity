public class MainTabNew : AvMain
{
	public const sbyte COLOR_WHITE = 0;

	public const sbyte COLOR_BLUE = 1;

	public const sbyte COLOR_YELLOW = 2;

	public const sbyte COLOR_VIOLET = 3;

	public const sbyte COLOR_ORANGE = 4;

	public const sbyte COLOR_GREEN = 5;

	public const sbyte COLOR_RED = 6;

	public const sbyte COLOR_BLACK = 7;

	public const sbyte COLOR_GREY = 8;

	public sbyte typeTab;

	public static sbyte maxTypeTab = 13;

	public static sbyte INVENTORY = 0;

	public static sbyte EQUIP = 1;

	public static sbyte MY_INFO = 2;

	public static sbyte SKILLS = 3;

	public static sbyte QUEST = 4;

	public static sbyte CHAT = 5;

	public static sbyte GOLD = 6;

	public static sbyte CONFIG = 7;

	public static sbyte SHOP = 8;

	public static sbyte CHEST = 9;

	public static sbyte REBUILD = 10;

	public static sbyte FUNCTION = 11;

	public static sbyte CLAN_INVENTORY = 12;

	public static sbyte PET_KEEPER = 13;

	public static sbyte IMFO_VANTIEU = 14;

	public static sbyte SELLITEM = 15;

	public static sbyte INVEN_AND_STORE = 16;

	public static sbyte OTHER_PLAYER_STORE = 17;

	public int xTab;

	public int yTab;

	public int wSmall;

	public int hSmall;

	public int numWSmall;

	public int numHSmall;

	public int xMoney;

	public int yMoney;

	public int xChar;

	public int yChar;

	public int sizeFocus;

	public int numWBlack;

	public int numHBlack;

	public static int wbackground;

	public static int hbackground;

	public bool isClan;

	public bool isPet;

	public static int wblack;

	public static int hblack;

	public static int hMaxContent;

	public int xBegin;

	public int yBegin;

	public string nameTab = string.Empty;

	public static sbyte wOneItem = 20;

	public static sbyte wOne5;

	public static sbyte Focus = 0;

	public static sbyte TAB = 0;

	public static sbyte INFO = 1;

	public static mImage[] imgTab = new mImage[15];

	public static mImage img_skIcn;

	public static mImage img_pkIcn;

	public static mImage img_arenaIcn;

	public static MainTabNew instance;

	public iCommand cmdBack;

	public static int longwidth = 0;

	public static int xlongwidth;

	public static int ylongwidth;

	public static int timeRequest = 15;

	public ListNew listContent;

	public static bool is320 = false;

	public mImage imgStarRebuild;

	public bool isTabHopNguyenLieu;

	public iCommand cmd;

	public bool isCreate_medal;

	public bool isUPgradeMedal;

	public static int[] colorLow = new int[5] { 14075822, 10259575, 7365460, 8944231, 4932409 };

	public new static int[] color = new int[11]
	{
		11049346, 12233362, 16300104, 15461355, 10917760, 13088156, 11969934, 7365460, 14931390, 11509641,
		16316584
	};

	public int xpos_cmd;

	public int ypos_cmd;

	private static string nameCur = string.Empty;

	private static string[] namePaint = new string[2];

	public static int timePaintInfo;

	public string[] mContent;

	public string[] mSubContent;

	public string[] mPlusContent;

	public int[] mcolor;

	public int[] mSubColor;

	public int[] mPlusColor;

	public string name;

	public int wContent;

	public int colorName;

	public int xCon;

	public int yCon;

	public mVector moreInfoconten = new mVector("MainTabNew moreInfoconten");

	public MainTabNew()
	{
		if (GameCanvas.isTouch)
		{
			wOneItem = 26;
		}
		else if (GameCanvas.w >= 240)
		{
			wOneItem = 24;
		}
		if (GameCanvas.h < 240 && wOneItem > 24)
		{
			wOneItem = 24;
		}
		hMaxContent = GameCanvas.h - GameCanvas.hCommand * 2;
		wOne5 = (sbyte)(wOneItem / 5);
		wbackground = GameCanvas.w / 32 + 1;
		hbackground = GameCanvas.h / 32 + 1;
		int num = GameCanvas.w / wOneItem;
		if (num > 9)
		{
			num = 9;
		}
		int num2 = GameCanvas.h / 5 * 4 - GameCanvas.hCommand / 2;
		if (GameCanvas.isTouch)
		{
			num2 += GameCanvas.hCommand / 2;
		}
		int num3 = num2 / wOneItem;
		if (num3 > 8)
		{
			num3 = 8;
		}
		wSmall = (num - 1) * wOneItem - wOne5 * 3 + (GameCanvas.isSmallScreen ? wOne5 : 0);
		hSmall = num3 * wOneItem + wOne5;
		if (hSmall % 2 != 0)
		{
			hSmall--;
		}
		if (GameCanvas.isTouch)
		{
			if (GameCanvas.w >= 380)
			{
				longwidth = 170;
				timeRequest = 5;
				hMaxContent = hSmall - wOneItem - wOne5;
				xTab = (GameCanvas.w - num * wOneItem - longwidth) / 2;
				xlongwidth = GameCanvas.w - xTab - longwidth;
				ylongwidth = yTab + GameCanvas.h / 5;
			}
			else if (GameCanvas.w > 315)
			{
				is320 = true;
				if (LoginScreen.indexInfoLogin == 1)
				{
					LoginScreen.indexInfoLogin = 2;
				}
				num = 8;
				wSmall = (num - 1) * wOneItem - wOne5 * 3;
				longwidth = 130;
				timeRequest = 5;
				hMaxContent = hSmall - wOneItem - wOne5;
				xlongwidth = GameCanvas.w - xTab - longwidth + 5;
				ylongwidth = yTab + GameCanvas.h / 5;
			}
		}
		if (is320)
		{
			xTab = -5;
			xlongwidth = xTab + wSmall + wOneItem + wOne5 * 2;
			longwidth = GameCanvas.w - xlongwidth;
		}
		else
		{
			xTab = (GameCanvas.w - num * wOneItem - longwidth) / 2;
		}
		yTab = 0;
		numWSmall = wSmall / 32;
		numHSmall = hSmall / 32;
		wblack = wSmall / wOneItem * wOneItem;
		hblack = (hSmall / wOneItem - 1) * wOneItem;
		numWBlack = wblack / 32;
		numHBlack = hblack / 32;
		xMoney = GameCanvas.w - (xTab - 9) - 72;
		if (GameCanvas.isTouch && xMoney > GameCanvas.w - 112)
		{
			xMoney = GameCanvas.w - 112;
		}
		yMoney = 5;
		if (GameCanvas.isSmallScreen)
		{
			yMoney = 2;
		}
		xChar = 0;
		yChar = GameCanvas.h / 10 - 21;
		if (GameCanvas.isSmallScreen)
		{
			yChar += 4;
		}
		sizeFocus = wOne5 + wOneItem;
		if (sizeFocus > 32)
		{
			sizeFocus = 32;
		}
	}

	public static MainTabNew gI()
	{
		if (instance == null)
		{
			instance = new MainTabNew();
		}
		return instance;
	}

	public static void paintRectLowGraphic(mGraphics g, int x, int y, int w, int h, int indexColor)
	{
		g.setColor(colorLow[indexColor]);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
	}

	public virtual void init()
	{
	}

	public virtual void setNameCmd(string name)
	{
	}

	public virtual void backTab()
	{
		MainScreen.cameraSub.setAll(0, 0, 0, 0);
		if (!GameCanvas.isTouch)
		{
			return;
		}
		if (GameCanvas.currentScreen == GameCanvas.AllInfo)
		{
			if (GameCanvas.AllInfo.lastScreen != null && GameCanvas.AllInfo.lastScreen != GameCanvas.AllInfo && GameCanvas.AllInfo.lastScreen != GameCanvas.shopNpc)
			{
				GameCanvas.AllInfo.lastScreen.Show();
			}
			else
			{
				GameCanvas.game.Show();
			}
		}
		else if (GameCanvas.currentScreen == GameCanvas.shopNpc)
		{
			if (GameCanvas.AllInfo.lastScreen != null && GameCanvas.AllInfo.lastScreen != GameCanvas.AllInfo && GameCanvas.AllInfo.lastScreen != GameCanvas.shopNpc)
			{
				GameCanvas.shopNpc.lastScreen.Show();
			}
			else
			{
				GameCanvas.game.Show();
			}
		}
		else if (GameCanvas.currentScreen == GameCanvas.foodPet)
		{
			if (GameCanvas.foodPet.lastScreen != null)
			{
				GameCanvas.foodPet.lastScreen.Show();
			}
			else
			{
				GameCanvas.game.Show();
			}
		}
	}

	public override void keypress(int keyCode)
	{
	}

	public void paintHairShop(mGraphics g, int hair)
	{
		GameCanvas.resetTrans(g);
		GameScreen.player.paintShowHairPlayer(g, GameCanvas.hw, GameCanvas.h / 10 + 15, hair);
	}

	public void paintTab(mGraphics g, string nameTab, int idSelect, mVector vec, bool isClan)
	{
		int num = vec.size();
		if (!Main.isPC && !Main.isIpad)
		{
			g.setColor(14602424);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		}
		for (int i = 0; i < 3; i++)
		{
			g.drawImage(imgTab[1], xMoney + 22 * i, yMoney, 0, mGraphics.isFalse);
		}
		if (Main.isPC || Main.isIpad)
		{
			for (int j = 0; j <= numWSmall; j++)
			{
				for (int k = 0; k <= numHSmall; k++)
				{
					if (j == numWSmall)
					{
						if (k == numHSmall)
						{
							g.drawImage(imgTab[0], xTab + wOne5 * 2 + wSmall - 64, yTab + GameCanvas.h / 5 + hSmall - 32, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawImage(imgTab[0], xTab + wOne5 * 2 + wSmall - 64, yTab + k * 32 + GameCanvas.h / 5, 0, mGraphics.isFalse);
						}
					}
					else if (k == numHSmall)
					{
						g.drawImage(imgTab[0], xTab + wOne5 * 2 + j * 32 - 5, yTab + GameCanvas.h / 5 + hSmall - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(imgTab[0], xTab + wOne5 * 2 + j * 32 - 5, yTab + k * 32 + GameCanvas.h / 5, 0, mGraphics.isFalse);
					}
				}
			}
		}
		for (int l = 0; l <= numWSmall; l++)
		{
			for (int m = 0; m <= numHSmall; m++)
			{
				if (l != 0 && l != numWSmall && m != numHSmall && m != 0)
				{
					continue;
				}
				if (l == numWSmall)
				{
					if (m == numHSmall)
					{
						g.drawImage(imgTab[1], xTab + wOneItem + wOne5 * 2 + wSmall - 32, yTab + GameCanvas.h / 5 + hSmall - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(imgTab[1], xTab + wOneItem + wOne5 * 2 + wSmall - 32, yTab + m * 32 + GameCanvas.h / 5, 0, mGraphics.isFalse);
					}
				}
				else if (m == numHSmall)
				{
					g.drawImage(imgTab[1], xTab + wOneItem + wOne5 * 2 + l * 32, yTab + GameCanvas.h / 5 + hSmall - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(imgTab[1], xTab + wOneItem + wOne5 * 2 + l * 32, yTab + m * 32 + GameCanvas.h / 5, 0, mGraphics.isFalse);
				}
			}
		}
		AvMain.Font3dWhite(g, nameTab, xTab + wOneItem + wOne5 * 2 + wSmall / 2, yTab + GameCanvas.h / 5 + wOneItem / 2 - 6, 2);
		GameScreen.infoGame.paintInfoPlayer(g, 0, 0, !GameCanvas.isSmallScreen, (!GameCanvas.isSmallScreen) ? mFont.tahoma_7_white : mFont.tahoma_7_black);
		g.drawRegion(imgTab[4], 0, 0, 14, 14, 0, xMoney + 4, yMoney + 2, 0, mGraphics.isFalse);
		g.drawRegion(imgTab[4], 0, 14, 14, 14, 0, xMoney + 4, yMoney + 17, 0, mGraphics.isFalse);
		if (isClan)
		{
			PaintInfoGameScreen.fraEvent.drawFrame(10, xMoney - 12, yMoney + 10, 0, 3, g);
			if (GameScreen.player.myClan != null)
			{
				mFont.tahoma_7_white.drawString(g, MainItem.getDotNumber(GameScreen.player.myClan.coin), xMoney + 19, yMoney + 3, 0, mGraphics.isFalse);
				mFont.tahoma_7_white.drawString(g, MainItem.getDotNumber(GameScreen.player.myClan.gold), xMoney + 19, yMoney + 18, 0, mGraphics.isFalse);
			}
		}
		else
		{
			mFont.tahoma_7_white.drawString(g, MainItem.getDotNumber(GameScreen.player.coin), xMoney + 19, yMoney + 3, 0, mGraphics.isFalse);
			mFont.tahoma_7_white.drawString(g, MainItem.getDotNumber(GameScreen.player.gold), xMoney + 19, yMoney + 18, 0, mGraphics.isFalse);
		}
		if (GameCanvas.lowGraphic)
		{
			paintRectLowGraphic(g, xTab + wOne5, yTab + GameCanvas.h / 5 + wOneItem * idSelect, wOne5 + wOneItem, wOneItem, 1);
		}
		else if (wOne5 + wOneItem > 32)
		{
			g.drawRegion(imgTab[1], 0, 0, wOneItem, wOneItem, 0, xTab + wOne5, yTab + GameCanvas.h / 5 + wOneItem * idSelect, 0, mGraphics.isFalse);
			g.drawRegion(imgTab[1], 0, 0, wOne5, wOneItem, 0, xTab + wOne5 + wOneItem, yTab + GameCanvas.h / 5 + wOneItem * idSelect, 0, mGraphics.isFalse);
		}
		else
		{
			g.drawRegion(imgTab[1], 0, 0, wOne5 + wOneItem, wOneItem, 0, xTab + wOne5, yTab + GameCanvas.h / 5 + wOneItem * idSelect, 0, mGraphics.isFalse);
		}
		g.setColor(color[0]);
		for (int n = 0; n < num; n++)
		{
			MainTabNew mainTabNew = (MainTabNew)vec.elementAt(n);
			int num2 = 0;
			if (n != idSelect)
			{
				g.drawRect(xTab + wOne5, yTab + GameCanvas.h / 5 + wOneItem * n, wOne5 + wOneItem, wOneItem, mGraphics.isFalse);
			}
			else if (Focus == TAB || GameCanvas.isTouch)
			{
				num2 = -1 + GameCanvas.gameTick / 2 % 3;
			}
			int num3 = mainTabNew.typeTab;
			if (num3 > maxTypeTab)
			{
				num3 = typeTab;
			}
			g.drawRegion(imgTab[3], 0, num3 * 16, 16, 16, 0, xTab + wOne5 + wOne5 / 2 + wOneItem / 2 + num2, yTab + GameCanvas.h / 5 + wOneItem / 2 + wOneItem * n, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			if (mainTabNew.typeTab == MY_INFO && Player.diemTiemNang > 0)
			{
				PaintInfoGameScreen.fralevelup.drawFrame(GameCanvas.gameTick / 4 % 2, xTab + wOne5 + wOne5 / 2 + wOneItem + num2 - 4, yTab + GameCanvas.h / 5 + wOneItem + wOneItem * n - 6, 0, 3, g);
			}
			else if (mainTabNew.typeTab == SKILLS && Player.diemKyNang > 0)
			{
				PaintInfoGameScreen.fralevelup.drawFrame(2 + GameCanvas.gameTick / 4 % 2, xTab + wOne5 + wOne5 / 2 + wOneItem + num2 - 4, yTab + GameCanvas.h / 5 + wOneItem + wOneItem * n - 6, 0, 3, g);
			}
		}
		for (int num4 = 0; num4 <= numWBlack; num4++)
		{
			for (int num5 = 0; num5 <= numHBlack; num5++)
			{
				if (num4 == numWBlack)
				{
					if (num5 == numHBlack)
					{
						g.drawImage(imgTab[2], xTab + wOneItem + wOne5 * 3 + wblack - 32, yTab + GameCanvas.h / 5 + wOneItem + hblack - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(imgTab[2], xTab + wOneItem + wOne5 * 3 + wblack - 32, yTab + GameCanvas.h / 5 + wOneItem + num5 * 32, 0, mGraphics.isFalse);
					}
				}
				else if (num5 == numHBlack)
				{
					g.drawImage(imgTab[2], xTab + wOneItem + wOne5 * 3 + num4 * 32, yTab + GameCanvas.h / 5 + wOneItem + hblack - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(imgTab[2], xTab + wOneItem + wOne5 * 3 + num4 * 32, yTab + GameCanvas.h / 5 + wOneItem + num5 * 32, 0, mGraphics.isFalse);
				}
			}
		}
		if (longwidth <= 0)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		int num6 = (longwidth - 10) / 32;
		int num7 = hSmall / 32;
		int num8 = GameCanvas.w - xTab - (longwidth - 10);
		int num9 = yTab + GameCanvas.h / 5;
		int num10 = 12;
		int num11 = longwidth / 32;
		int num12 = hSmall / 32;
		for (int num13 = 0; num13 <= num11; num13++)
		{
			for (int num14 = 0; num14 <= num7; num14++)
			{
				num10 = 12;
				if (num14 == 0)
				{
					num10 = 12;
				}
				if (num13 == num11)
				{
					if (num14 == num12)
					{
						g.drawImage(imgTab[num10], xlongwidth + longwidth - 32, ylongwidth + hSmall - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(imgTab[num10], xlongwidth + longwidth - 32, ylongwidth + num14 * 32, 0, mGraphics.isFalse);
					}
				}
				else if (num14 == num12)
				{
					g.drawImage(imgTab[num10], xlongwidth + num13 * 32, ylongwidth + hSmall - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(imgTab[num10], xlongwidth + num13 * 32, ylongwidth + num14 * 32, 0, mGraphics.isFalse);
				}
			}
		}
		for (int num15 = xlongwidth; num15 < xlongwidth + longwidth; num15 += 6)
		{
			g.fillRect(num15, ylongwidth + wOneItem, 4, 1, mGraphics.isFalse);
		}
	}

	public void paintPopupContent(mGraphics g, bool isOnlyName)
	{
		if (longwidth > 0)
		{
			paintContentNew(g, isOnlyName);
		}
		else
		{
			paintContent(g, isOnlyName);
		}
	}

	public void paintContent(mGraphics g, bool isOnlyName)
	{
		int num = 4;
		TabScreenNew.timeRepaint = 10;
		g.setClip(-g.getTranslateX(), -g.getTranslateY(), GameCanvas.w, GameCanvas.h);
		int num2 = 1;
		if (mContent != null)
		{
			num2 = mContent.Length;
		}
		if (mPlusContent != null)
		{
			num2 += mPlusContent.Length;
		}
		int num3 = (num2 + 1) * GameCanvas.hText + 8;
		if (num3 > hMaxContent)
		{
			num3 = hMaxContent;
		}
		if (xCon + wContent > GameCanvas.w)
		{
			xCon = GameCanvas.w / 2 - wContent / 2;
		}
		int num4 = yCon;
		g.setColor(color[10]);
		g.fillRect(xCon - 1, num4 - 1, wContent + 2, num3 + 2, mGraphics.isTrue);
		g.setColor(color[2]);
		g.fillRect(xCon, num4, wContent + 1, num3 + 1, mGraphics.isTrue);
		int num5 = wContent / 32;
		int num6 = num3 / 32;
		for (int i = 0; i <= num5; i++)
		{
			for (int j = 0; j <= num6; j++)
			{
				if (i == num5)
				{
					if (j == num6)
					{
						g.drawImage(imgTab[12], xCon + wContent - 32, num4 + num3 - 32, 0, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(imgTab[12], xCon + wContent - 32, num4 + j * 32, 0, mGraphics.isTrue);
					}
				}
				else if (j == num6)
				{
					g.drawImage(imgTab[12], xCon + i * 32, num4 + num3 - 32, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(imgTab[12], xCon + i * 32, num4 + j * 32, 0, mGraphics.isTrue);
				}
			}
		}
		g.setClip(xCon + 1, num4 + 1, wContent - 2, num3 - 2);
		if (!isOnlyName)
		{
			if (name != null)
			{
				paintNameItem(g, xCon + wContent / 2, num4 + 2, wContent, name, colorName);
			}
			if (listContent != null)
			{
				g.setClip(xCon, num4 + GameCanvas.hText, wContent, hMaxContent - GameCanvas.hText);
				g.translate(0, -listContent.cmx);
			}
		}
		if (mPlusContent != null)
		{
			for (int k = 0; k < mPlusContent.Length; k++)
			{
				num4 += GameCanvas.hText;
				setTextColor(mPlusColor[k]).drawString(g, mPlusContent[k], xCon + num, num4 + 2, 0, mGraphics.isTrue);
			}
		}
		if (mPlusContent == null && moreInfoconten.size() > 0)
		{
			num4 += GameCanvas.hText;
		}
		for (int l = 0; l < moreInfoconten.size(); l++)
		{
			InfocontenNew infocontenNew = (InfocontenNew)moreInfoconten.elementAt(l);
			if (infocontenNew == null)
			{
				continue;
			}
			if (mPlusContent != null)
			{
				Item.eff_UpLv.paintUpgradeEffect(xCon + num + mPlusContent[0].Length * 5 + 3 + 15 * l, num4 - GameCanvas.hText / 2 + ((mPlusContent.Length == 1) ? GameCanvas.hText : 0), 13, 13, g, 0);
			}
			else
			{
				Item.eff_UpLv.paintUpgradeEffect(xCon + num + 16 + 15 * l, num4 - GameCanvas.hText / 2, 13, 13, g, 0);
			}
			if (infocontenNew.idimage == -1)
			{
				continue;
			}
			MainItem material = Item.getMaterial(infocontenNew.idimage);
			if (material != null)
			{
				if (mPlusContent != null && mPlusContent[0] != null)
				{
					material.paintItem_notnum(g, xCon + num + mPlusContent[0].Length * 5 + 3 + 15 * l + 1, num4 - GameCanvas.hText / 2 + 1 + ((mPlusContent.Length == 1) ? GameCanvas.hText : 0), 21, 1, 0);
				}
				else
				{
					material.paintItem_notnum(g, xCon + num + 16 + 15 * l, num4 - GameCanvas.hText / 2 + 1, 21, 1, 0);
				}
			}
			else
			{
				Item.put_Material(infocontenNew.idimage);
			}
		}
		if (mContent != null)
		{
			for (int m = 0; m < mContent.Length; m++)
			{
				if (mContent[m] != null)
				{
					mFont mFont2 = null;
					mFont2 = ((mcolor == null) ? mFont.tahoma_7_white : setTextColor(mcolor[m]));
					mFont2.drawString(g, mContent[m], xCon + num, num4 + 2 + (m + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
					if (mSubContent != null)
					{
						int num7 = mFont2.getWidth(mContent[m]) + 5;
						mFont2 = setTextColor(mSubColor[m]);
						mFont2.drawString(g, mSubContent[m], xCon + num7 + num, num4 + 2 + (m + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
					}
				}
			}
		}
		else if (!isOnlyName)
		{
			if (name != null)
			{
				paintNameItem(g, xCon + wContent / 2, num4 + 2, wContent, name, colorName);
			}
		}
		else if (name != null)
		{
			paintNameItem(g, xCon + wContent / 2, num4 + GameCanvas.hText / 4, wContent, name, colorName);
		}
		if (cmd != null)
		{
			cmd.paint(g, xCon + wContent - iCommand.wButtonCmd / 2, num4 + num3 - iCommand.hButtonCmd);
			if (xpos_cmd == 0 || ypos_cmd == 0)
			{
				xpos_cmd = xCon + wContent - iCommand.wButtonCmd / 2;
				ypos_cmd = num4 + num3 - iCommand.hButtonCmd;
			}
		}
		GameCanvas.resetTrans(g);
	}

	public void updateCMD()
	{
		if (cmd != null)
		{
			if (xpos_cmd != 0 && ypos_cmd != 0)
			{
				cmd.setPos(xpos_cmd, ypos_cmd, PaintInfoGameScreen.fraButton, cmd.caption);
			}
			if (GameCanvas.isTouch)
			{
				cmd.updatePointer();
			}
			else if (GameCanvas.keyMyPressed[5])
			{
				GameCanvas.keyMyPressed[5] = false;
				cmd.perform();
			}
		}
	}

	public override void update()
	{
		updateCMD();
	}

	public void paintContentNew(mGraphics g, bool isOnlyName)
	{
		int num = 4;
		TabScreenNew.timeRepaint = 10;
		GameCanvas.resetTrans(g);
		int num2 = xlongwidth;
		int num3 = ylongwidth;
		int num4 = num3;
		g.setClip(num2 + 1, num4 + 1, longwidth - 2, hSmall - 2);
		if (!isOnlyName)
		{
			paintNameItem(g, num2 + longwidth / 2, num4 + wOneItem / 2 - 5, longwidth, name, colorName);
			if (listContent != null)
			{
				g.setClip(num2, num4 + wOneItem + 2, longwidth, hMaxContent - wOneItem - 2);
				g.translate(0, -listContent.cmx);
			}
			num4 += wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
		}
		if (mPlusContent != null)
		{
			for (int i = 0; i < mPlusContent.Length; i++)
			{
				num4 += GameCanvas.hText;
				setTextColor(mPlusColor[i]).drawString(g, mPlusContent[i], num2 + num, num4 + 2, 0, mGraphics.isTrue);
			}
		}
		if (mPlusContent == null && moreInfoconten.size() > 0)
		{
			num4 += GameCanvas.hText;
		}
		for (int j = 0; j < moreInfoconten.size(); j++)
		{
			InfocontenNew infocontenNew = (InfocontenNew)moreInfoconten.elementAt(j);
			if (infocontenNew == null)
			{
				continue;
			}
			if (mPlusColor != null)
			{
				Item.eff_UpLv.paintUpgradeEffect(num2 + num + mPlusContent[0].Length * 5 + 3 + 15 * j, num4 - GameCanvas.hText / 2 + ((mPlusContent.Length == 1) ? GameCanvas.hText : 0), 13, 13, g, 0);
			}
			else
			{
				Item.eff_UpLv.paintUpgradeEffect(num2 + num + 16 + 15 * j, num4 - GameCanvas.hText / 2 + GameCanvas.hText, 13, 13, g, 0);
			}
			if (infocontenNew.idimage == -1)
			{
				continue;
			}
			MainItem material = Item.getMaterial(infocontenNew.idimage);
			if (material != null)
			{
				if (mPlusContent != null && mPlusContent[0] != null)
				{
					material.paintItem_notnum(g, num2 + num + mPlusContent[0].Length * 5 + 3 + 15 * j + 1, num4 - GameCanvas.hText / 2 + 1 + ((mPlusContent.Length == 1) ? GameCanvas.hText : 0), 21, 1, 0);
				}
				else
				{
					material.paintItem_notnum(g, num2 + num + 16 + 15 * j, num4 - GameCanvas.hText / 2 + GameCanvas.hText + 1, 21, 1, 0);
				}
			}
			else
			{
				Item.put_Material(infocontenNew.idimage);
			}
		}
		if (mContent != null)
		{
			PetItem pet = MsgDialog.pet;
			if (isPet && pet != null)
			{
				num4 += GameCanvas.hText;
				mFont.tahoma_7_white.drawString(g, T.level + pet.LvItem + " + " + pet.experience / 10 + "," + pet.experience % 10 + "%", num2 + num, num4 + 2, 0, mGraphics.isTrue);
				num4 += GameCanvas.hText;
				int num5 = pet.age / 24;
				int num6 = pet.age % 24;
				int num7 = (int)(pet.timeDefaultItemFashion - pet.getTimeItemFashion() / 60000);
				if (num7 > 0)
				{
					mFont.tahoma_7_red.drawString(g, T.sudungsau + " " + PaintInfoGameScreen.getStringTime(num7), num2 + num, num4 + 2, 0, mGraphics.isTrue);
					num4 += GameCanvas.hText;
				}
				mFont.tahoma_7_white.drawString(g, T.tuoi + num5 + "d " + num6 + "h", num2 + num, num4 + 2, 0, mGraphics.isTrue);
				num4 += GameCanvas.hText;
				if (pet.petAttack != null)
				{
					setTextColor(Item.colorInfoItem[pet.petAttack.id]).drawString(g, Item.nameInfoItem[pet.petAttack.id] + ": " + pet.petAttack.value + "-" + pet.petAttack.maxDam, num2 + num, num4 + 2, 0, mGraphics.isTrue);
				}
				num4 += GameCanvas.hText;
				mFont.tahoma_7_white.drawString(g, T.choan + ": " + pet.growpoint + "/" + pet.maxgrow, num2 + num, num4 + 2, 0, mGraphics.isTrue);
				num4 += GameCanvas.hText;
				for (int k = 0; k < T.mKynangPet.Length; k++)
				{
					mFont.tahoma_7_white.drawString(g, T.mKynangPet[k] + ": " + pet.mvaluetiemnang[k] + "/" + pet.maxtiemnang, num2 + num, num4 + 2, 0, mGraphics.isTrue);
					num4 += GameCanvas.hText;
				}
				for (int l = 0; l < pet.mInfo.Length; l++)
				{
					if (pet.mInfo[l].id > 6)
					{
						string st = Item.nameInfoItem[pet.mInfo[l].id] + ": " + Item.getPercent(Item.isPercentInfoItem[pet.mInfo[l].id], pet.mInfo[l].value);
						setTextColor(Item.colorInfoItem[pet.mInfo[l].id]).drawString(g, st, num2 + num, num4 + 2, 0, mGraphics.isTrue);
						num4 += GameCanvas.hText;
					}
				}
			}
			else
			{
				for (int m = 0; m < mContent.Length; m++)
				{
					if (mContent[m] != null)
					{
						mFont mFont2 = null;
						mFont2 = ((mcolor == null) ? mFont.tahoma_7_white : setTextColor(mcolor[m]));
						mFont2.drawString(g, mContent[m], num2 + num, num4 + 2 + (m + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
						if (mSubContent != null)
						{
							int num8 = mFont2.getWidth(mContent[m]) + 5;
							mFont2 = setTextColor(mSubColor[m]);
							mFont2.drawString(g, mSubContent[m], num2 + num8 + num, num4 + 2 + (m + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
						}
					}
				}
			}
		}
		else if (isOnlyName)
		{
			mFont.tahoma_7b_white.drawString(g, name, num2 + longwidth / 2, num4 + wOneItem / 2 - 5, 2, mGraphics.isTrue);
		}
		GameCanvas.resetTrans(g);
	}

	public static void paintNameItem(mGraphics g, int x, int y, int w, string name, int colorName)
	{
		if (mFont.tahoma_7b_black.getWidth(name) <= w)
		{
			mFont mFont2 = setTextColorName(colorName);
			mFont2.drawString(g, name, x, y, 2, mGraphics.isTrue);
			return;
		}
		if (nameCur.CompareTo(name.Trim()) != 0)
		{
			getTextName(name);
		}
		mFont mFont3 = setTextColor(colorName);
		mFont3.drawString(g, namePaint[0], x, y - 6, 2, mGraphics.isTrue);
		mFont3.drawString(g, namePaint[1], x, y + 6, 2, mGraphics.isTrue);
	}

	public static void getTextName(string name)
	{
		nameCur = name.Trim();
		namePaint = new string[2];
		for (int i = 0; i < namePaint.Length; i++)
		{
			namePaint[i] = string.Empty;
		}
		string[] array = mFont.split(nameCur, " ");
		for (int j = 0; j < array.Length; j++)
		{
			if (j <= array.Length / 2)
			{
				namePaint[0] += array[j];
				if (j < array.Length / 2)
				{
					namePaint[0] += " ";
				}
			}
			else
			{
				namePaint[1] += array[j];
				if (j < array.Length - 1)
				{
					namePaint[1] += " ";
				}
			}
		}
	}

	public static mFont setTextColor(int id)
	{
		int num = id;
		if (id >= 20 && id < 30)
		{
			num = id - 20;
		}
		else if (id >= 30 && id < 40)
		{
			num = id - 30;
		}
		else if (id >= 40 && id < 50)
		{
			num = id - 40;
		}
		return num switch
		{
			0 => mFont.tahoma_7_white, 
			1 => mFont.tahoma_7_blue, 
			2 => mFont.tahoma_7_yellow, 
			3 => mFont.tahoma_7_violet, 
			4 => mFont.tahoma_7_orange, 
			5 => mFont.tahoma_7_green, 
			6 => mFont.tahoma_7_red, 
			7 => mFont.tahoma_7_black, 
			8 => mFont.tahoma_7_gray, 
			_ => mFont.tahoma_7_white, 
		};
	}

	public static mFont setTextColorName(int id)
	{
		int num = id;
		if (id >= 20 && id < 30)
		{
			num = id - 20;
		}
		else if (id >= 30 && id < 40)
		{
			num = id - 30;
		}
		else if (id >= 40 && id < 50)
		{
			num = id - 40;
		}
		return num switch
		{
			0 => mFont.tahoma_7b_white, 
			1 => mFont.tahoma_7b_blue, 
			2 => mFont.tahoma_7b_yellow, 
			3 => mFont.tahoma_7b_violet, 
			4 => mFont.tahoma_7b_orange, 
			5 => mFont.tahoma_7b_green, 
			7 => mFont.tahoma_7b_black, 
			8 => mFont.tahoma_7_gray, 
			_ => mFont.tahoma_7b_white, 
		};
	}

	public virtual void setPaintInfo()
	{
	}

	public virtual void setYCon(Item item)
	{
	}

	public void setinfoContennew(int id, int index)
	{
		InfocontenNew o = new InfocontenNew(id, index);
		moreInfoconten.addElement(o);
	}

	public void setPosCmd(mVector vecListCmd)
	{
		if (vecListCmd == null)
		{
			return;
		}
		int num = vecListCmd.size();
		if (num == 0)
		{
			return;
		}
		int num2 = ylongwidth + hSmall;
		int num3 = xlongwidth;
		switch (num)
		{
		case 1:
		{
			iCommand iCommand2 = (iCommand)vecListCmd.elementAt(0);
			if (is320)
			{
				iCommand2.setPos(num3 + longwidth / 2, num2 - 10, PaintInfoGameScreen.fraButton2, iCommand2.caption);
			}
			else
			{
				iCommand2.setPos(num3 + longwidth / 2, num2 - 15, null, iCommand2.caption);
			}
			return;
		}
		case 2:
		{
			iCommand iCommand3 = (iCommand)vecListCmd.elementAt(0);
			if (is320)
			{
				iCommand3.setPos(num3 + longwidth / 4, num2 - 10, PaintInfoGameScreen.fraButton2, iCommand3.caption);
			}
			else
			{
				iCommand3.setPos(num3 + longwidth / 4, num2 - 15, null, iCommand3.caption);
			}
			iCommand iCommand4 = (iCommand)vecListCmd.elementAt(1);
			if (is320)
			{
				iCommand4.setPos(num3 + longwidth / 4 * 3 + 2, num2 - 10, PaintInfoGameScreen.fraButton2, iCommand4.caption);
			}
			else
			{
				iCommand4.setPos(num3 + longwidth / 4 * 3 + 2, num2 - 15, null, iCommand4.caption);
			}
			return;
		}
		}
		for (int i = 0; i < num; i++)
		{
			iCommand iCommand5 = (iCommand)vecListCmd.elementAt(i);
			if (i == num - 1 && num % 2 == 1)
			{
				if (is320)
				{
					iCommand5.setPos(num3 + longwidth / 2, num2 - 10, PaintInfoGameScreen.fraButton2, iCommand5.caption);
				}
				else
				{
					iCommand5.setPos(num3 + longwidth / 2, num2 - 15 - (num - 1) / 2 * 30 + i / 2 * 30, null, iCommand5.caption);
				}
			}
			else if (is320)
			{
				iCommand5.setPos(num3 + longwidth / 4 + i % 2 * (longwidth / 2 + 2), num2 - 10 - (num - 1) / 2 * 22 + i / 2 * 22, PaintInfoGameScreen.fraButton2, iCommand5.caption);
			}
			else
			{
				iCommand5.setPos(num3 + longwidth / 4 + i % 2 * (longwidth / 2 + 2), num2 - 15 - (num - 1) / 2 * 30 + i / 2 * 30, null, iCommand5.caption);
			}
		}
	}
}
