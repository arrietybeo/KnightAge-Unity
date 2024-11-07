public class AvMain
{
	public iCommand left;

	public iCommand right;

	public iCommand center;

	public static mImage[] tab = new mImage[4];

	public static int wimg;

	public static mImage[] imghitScr = new mImage[3];

	public static mImage imgtextfield;

	public static mImage imgInfo;

	public static mImage imghpmp;

	public static mImage imgcolorhpmp;

	public static mImage imgPopup;

	public static mImage imgBackInfo;

	public static mImage imgWorldMap;

	public static mImage imgSelect;

	public static mImage imgFocusMap;

	public static mImage imgDelaySkill;

	public static mImage imgLoadImg;

	public static mImage imgEyeDie;

	public static mImage imgHotKey;

	public static mImage imgHotKey2;

	public static mImage imgMess;

	public static mImage imgColorItem;

	public static mImage imgicongt;

	public static mImage imgGlass;

	public static mImage imgLock;

	public static mImage imgRect;

	public static mImage imgSelect_1;

	public static mImage imgcolorhpmp_back;

	public static mImage imgcolorhpSmall_back;

	public static mImage imgcolorhpSmall;

	public static mImage img18Plus;

	public static FrameImage fraPlayerDie;

	public static FrameImage fraObjMiniMap;

	public static FrameImage fraPk;

	public static FrameImage fraStar;

	public static FrameImage fraQuest;

	public static FrameImage fraMonSample;

	public static FrameImage fraDiamond;

	public static FrameImage fraPlayerNo;

	public static FrameImage imgStun;

	public static FrameImage imgSleep;

	public static FrameImage fraFogetPass;

	public static mImage[] textf = new mImage[2];

	public static int SELECTED_COLOR = 10259575;

	public static FrameImage[] fraPkArr;

	public static int[] color = new int[5] { 4724752, 16300104, 9998456, 14733496, 10127472 };

	private static int[] colorDia = new int[5] { 7875090, 16316584, 5309952, 16300104, 16300104 };

	public virtual void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		if (GameCanvas.currentDialog == null && !GameCanvas.menu2.isShowMenu)
		{
			paintCmd(g);
		}
	}

	public virtual void update()
	{
	}

	public virtual void keypress(int keyCode)
	{
	}

	public virtual void commandPointer(int index, object obj)
	{
	}

	public void paintCmd(mGraphics g)
	{
		if (GameCanvas.isSmallScreen)
		{
			paintCmdSmall(g);
			return;
		}
		if (left != null)
		{
			left.paint(g, GameCanvas.wCommand, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
		if (right != null)
		{
			right.paint(g, GameCanvas.w - GameCanvas.wCommand, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
		if (center != null)
		{
			center.paint(g, GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
	}

	public void paintCmd_OnlyText(mGraphics g)
	{
		if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		if (GameCanvas.isSmallScreen)
		{
			paintCmd_OnlyText_Small(g);
			return;
		}
		if (left != null)
		{
			Font3dWhite(g, left.caption, 30, GameCanvas.h - GameCanvas.hCommand / 2 - 4, 2);
		}
		if (right != null)
		{
			Font3dWhite(g, right.caption, GameCanvas.w - 30, GameCanvas.h - GameCanvas.hCommand / 2 - 4, 2);
		}
		if (center != null)
		{
			Font3dWhite(g, center.caption, GameCanvas.hw, GameCanvas.h - GameCanvas.hCommand / 2 - 4, 2);
		}
	}

	public void paintCmdSmall(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		if (left != null)
		{
			left.paint(g, GameCanvas.wCommand, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
		if (right != null)
		{
			right.paint(g, GameCanvas.w - GameCanvas.wCommand, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
		if (center != null)
		{
			center.paint(g, GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
	}

	public void paintCmd_OnlyText_Small(mGraphics g)
	{
		if (left != null)
		{
			mFont.tahoma_7b_white.drawString(g, left.caption, 27, GameCanvas.h - GameCanvas.hCommand / 2 + 1, 2, mGraphics.isFalse);
		}
		if (right != null)
		{
			mFont.tahoma_7b_white.drawString(g, right.caption, GameCanvas.w - 27, GameCanvas.h - GameCanvas.hCommand / 2 + 1, 2, mGraphics.isFalse);
		}
		if (center != null)
		{
			mFont.tahoma_7b_white.drawString(g, center.caption, GameCanvas.hw, GameCanvas.h - GameCanvas.hCommand / 2 + 1, 2, mGraphics.isFalse);
		}
	}

	public virtual void commandTab(int index, int subIndex)
	{
	}

	public virtual void commandMenu(int index, int subIndex)
	{
	}

	public virtual void commandPointer(int index, int subIndex)
	{
	}

	public void paintRect(mGraphics g, int x, int y, int w, int h, bool isSelect)
	{
		g.setColor(0);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
		g.setColor(1073997);
		if (isSelect)
		{
			g.setColor(16777215);
		}
		g.fillRect(x + 2, y + 2, w - 4, h - 4, mGraphics.isFalse);
	}

	public void paintRect(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(0);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
		g.setColor(1073997);
		g.fillRect(x + 2, y + 2, w - 4, h - 4, mGraphics.isFalse);
	}

	public void paintRect(mGraphics g, int x, int y, int w, int h, int color, int color2)
	{
		g.setColor(color);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
		g.setColor(color2);
		g.fillRect(x + 2, y + 2, w - 4, h - 4, mGraphics.isFalse);
	}

	public static void paintDialog(mGraphics g, int xDia, int yDia, int wDia, int hDia, int Indexcolor)
	{
		if (wDia < 35)
		{
			wDia = 35;
		}
		int num = (wDia - 6) / 32;
		int num2 = (hDia - 6) / 32;
		if (hDia % 2 != 0)
		{
			hDia++;
		}
		if (hDia < 32)
		{
			for (int i = 0; i <= num; i++)
			{
				for (int j = 0; j <= num2; j++)
				{
					if (i == num)
					{
						if (j == num2)
						{
							g.drawRegion(MainTabNew.imgTab[Indexcolor], 0, 0, 32, hDia, 0, xDia - 3 + wDia - 32, yDia, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawRegion(MainTabNew.imgTab[Indexcolor], 0, 0, 32, hDia, 0, xDia - 3 + wDia - 32, yDia + 3 + 32 * j, 0, mGraphics.isFalse);
						}
					}
					else if (j == num2)
					{
						g.drawRegion(MainTabNew.imgTab[Indexcolor], 0, 0, 32, hDia, 0, xDia + 3 + i * 32, yDia, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawRegion(MainTabNew.imgTab[Indexcolor], 0, 0, 32, hDia, 0, xDia + 3 + i * 32, yDia + 3 + 32 * j, 0, mGraphics.isFalse);
					}
				}
			}
		}
		else
		{
			for (int k = 0; k <= num; k++)
			{
				for (int l = 0; l <= num2; l++)
				{
					if (k == num)
					{
						if (l == num2)
						{
							g.drawImage(MainTabNew.imgTab[Indexcolor], xDia - 3 + wDia - 32, yDia - 3 + hDia - 32, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawImage(MainTabNew.imgTab[Indexcolor], xDia - 3 + wDia - 32, yDia + 3 + 32 * l, 0, mGraphics.isFalse);
						}
					}
					else if (l == num2)
					{
						g.drawImage(MainTabNew.imgTab[Indexcolor], xDia + 3 + k * 32, yDia - 3 + hDia - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[Indexcolor], xDia + 3 + k * 32, yDia + 3 + 32 * l, 0, mGraphics.isFalse);
					}
				}
			}
		}
		g.drawRegion(imgPopup, 0, 0, 5, 5, 0, xDia, yDia, 0, mGraphics.isFalse);
		g.drawRegion(imgPopup, 0, 5, 5, 5, 0, xDia + wDia - 5, yDia, 0, mGraphics.isFalse);
		g.drawRegion(imgPopup, 0, 15, 5, 5, 0, xDia, yDia + hDia - 5, 0, mGraphics.isFalse);
		g.drawRegion(imgPopup, 0, 10, 5, 5, 0, xDia + wDia - 5, yDia + hDia - 5, 0, mGraphics.isFalse);
		g.setColor(colorDia[0]);
		g.fillRect(xDia + 3, yDia, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[1]);
		g.fillRect(xDia + 3, yDia + 1, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + 1, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[2]);
		g.fillRect(xDia + 3, yDia + 2, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + 2, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[2]);
		g.fillRect(xDia + 3, yDia + hDia - 1, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 1, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[4]);
		g.fillRect(xDia + 3, yDia + hDia - 2, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 2, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[0]);
		g.fillRect(xDia + 3, yDia + hDia - 3, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 3, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
	}

	public static void paintDialogNew(mGraphics g, int xDia, int yDia, int wDia, int hDia, int Indexcolor)
	{
		if (GameCanvas.lowGraphic)
		{
			paintDialog(g, xDia, yDia, wDia, hDia, Indexcolor);
			return;
		}
		int num = (wDia - 6) / 32;
		int num2 = (hDia - 6) / 32;
		if (hDia % 2 != 0)
		{
			hDia++;
		}
		for (int i = 0; i <= num; i++)
		{
			for (int j = 0; j <= num2; j++)
			{
				if (j > 1 && j < num2 - 1 && i != 0 && i != num)
				{
					continue;
				}
				if (i == num)
				{
					if (j == num2)
					{
						g.drawImage(MainTabNew.imgTab[Indexcolor], xDia - 3 + wDia - 32, yDia - 3 + hDia - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[Indexcolor], xDia - 3 + wDia - 32, yDia + 3 + 32 * j, 0, mGraphics.isFalse);
					}
				}
				else if (j == num2)
				{
					g.drawImage(MainTabNew.imgTab[Indexcolor], xDia + 3 + i * 32, yDia - 3 + hDia - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[Indexcolor], xDia + 3 + i * 32, yDia + 3 + 32 * j, 0, mGraphics.isFalse);
				}
			}
		}
		g.drawRegion(imgPopup, 0, 0, 5, 5, 0, xDia, yDia, 0, mGraphics.isFalse);
		g.drawRegion(imgPopup, 0, 5, 5, 5, 0, xDia + wDia - 5, yDia, 0, mGraphics.isFalse);
		g.drawRegion(imgPopup, 0, 15, 5, 5, 0, xDia, yDia + hDia - 5, 0, mGraphics.isFalse);
		g.drawRegion(imgPopup, 0, 10, 5, 5, 0, xDia + wDia - 5, yDia + hDia - 5, 0, mGraphics.isFalse);
		g.setColor(colorDia[0]);
		g.fillRect(xDia + 3, yDia, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[1]);
		g.fillRect(xDia + 3, yDia + 1, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + 1, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[2]);
		g.fillRect(xDia + 3, yDia + 2, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + 2, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[2]);
		g.fillRect(xDia + 3, yDia + hDia - 1, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 1, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[4]);
		g.fillRect(xDia + 3, yDia + hDia - 2, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 2, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(colorDia[0]);
		g.fillRect(xDia + 3, yDia + hDia - 3, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 3, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
	}

	public static void paintTabNew(mGraphics g, int xTab, int yTab, int wTab, int hTab, bool ismore, sbyte colorBack)
	{
		if (hTab < 32)
		{
			hTab = 32;
		}
		g.setColor(color[0]);
		g.fillRect(xTab + wimg - 2, yTab + 3, wTab - 2 * wimg + 4, hTab - 5, mGraphics.isFalse);
		g.fillRect(xTab + 4, yTab + wimg - 2, wTab - 8, hTab - 2 * wimg + 4, mGraphics.isFalse);
		g.setColor(color[1]);
		g.fillRect(xTab + wimg - 2, yTab + 4, wTab - 2 * wimg + 4, hTab - 7, mGraphics.isFalse);
		g.fillRect(xTab + 5, yTab + wimg - 2, wTab - 10, hTab - 2 * wimg + 4, mGraphics.isFalse);
		g.setColor(color[0]);
		g.fillRect(xTab + wimg - 2, yTab + 5, wTab - 2 * wimg + 4, hTab - 9, mGraphics.isFalse);
		g.fillRect(xTab + 6, yTab + wimg - 2, wTab - 12, hTab - 2 * wimg + 4, mGraphics.isFalse);
		g.setColor(color[2]);
		g.fillRect(xTab + 7, yTab + 6, wTab - 14, hTab - 12, mGraphics.isFalse);
		for (int i = 0; i <= (wTab - 15) / 32; i++)
		{
			for (int j = 0; j <= (hTab - 11) / 32; j++)
			{
				if (i == (wTab - 15) / 32)
				{
					if (j == (hTab - 11) / 32)
					{
						g.drawImage(MainTabNew.imgTab[colorBack], xTab + wTab - 39, yTab + hTab - 37, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[colorBack], xTab + wTab - 39, yTab + 7 + j * 32, 0, mGraphics.isFalse);
					}
				}
				else if (j == (hTab - 11) / 32)
				{
					g.drawImage(MainTabNew.imgTab[colorBack], xTab + 8 + i * 32, yTab + hTab - 37, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[colorBack], xTab + 8 + i * 32, yTab + 7 + j * 32, 0, mGraphics.isFalse);
				}
			}
		}
		g.drawImage(tab[0], xTab, yTab, 0, mGraphics.isFalse);
		g.drawRegion(tab[0], 0, 0, wimg, wimg, 2, xTab + wTab - wimg, yTab, 0, mGraphics.isFalse);
		g.drawImage(tab[1], xTab + 2, yTab + hTab - wimg, 0, mGraphics.isFalse);
		g.drawRegion(tab[1], 0, 0, 30, 30, 2, xTab + wTab - 32, yTab + hTab - wimg, 0, mGraphics.isFalse);
		if (ismore)
		{
			g.drawImage(tab[2], xTab + wTab / 2, yTab + 2, 3, mGraphics.isFalse);
		}
	}

	public static void paintRectNice(mGraphics g, int xTab, int yTab, int wTab, int hTab, sbyte colorBack)
	{
		for (int i = 0; i <= wTab / 32; i++)
		{
			for (int j = 0; j <= hTab / 32; j++)
			{
				if (i == wTab / 32)
				{
					if (j == hTab / 32)
					{
						g.drawImage(MainTabNew.imgTab[colorBack], xTab + wTab - 32, yTab + hTab - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[colorBack], xTab + wTab - 32, yTab + j * 32, 0, mGraphics.isFalse);
					}
				}
				else if (j == hTab / 32)
				{
					g.drawImage(MainTabNew.imgTab[colorBack], xTab + i * 32, yTab + hTab - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[colorBack], xTab + i * 32, yTab + j * 32, 0, mGraphics.isFalse);
				}
			}
		}
	}

	public static void fill(int x, int y, int w, int h, int color, mGraphics g)
	{
		g.setColor(color);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
	}

	public static void paintRectText(mGraphics g, int xText, int yText, int wText, int hText, bool isFocus)
	{
		g.setColor(12621920);
		if (isFocus)
		{
			g.setColor(16644568);
		}
		g.drawRegion(imgtextfield, 0, isFocus ? 30 : 0, 4, 15, 0, xText, yText, 0, mGraphics.isTrue);
		g.drawRegion(imgtextfield, 0, (isFocus ? 30 : 0) + 15, 4, 15, 0, xText + wText - 4, yText + hText - 15, 0, mGraphics.isTrue);
		g.drawRegion(imgtextfield, 0, (isFocus ? 30 : 0) + 11, 4, 4, 0, xText, yText + hText - 4, 0, mGraphics.isTrue);
		g.drawRegion(imgtextfield, 0, (isFocus ? 30 : 0) + 15, 4, 4, 0, xText + wText - 4, yText, 0, mGraphics.isTrue);
		g.fillRect(xText + 4, yText, wText - 8, hText, mGraphics.isTrue);
		g.fillRect(xText, yText + 4, wText, hText - 8, mGraphics.isTrue);
	}

	public void paintSelect(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(SELECTED_COLOR);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
	}

	public void paintFormList(mGraphics g, int x, int y, int w, int h, string name)
	{
		paintDialogNew(g, x - 6, y - 6, w + 12, h + 12, 0);
		paintRectNice(g, x, y + GameCanvas.hCommand, w, h - GameCanvas.hCommand, 2);
		MainTabNew.paintNameItem(g, x + w / 2, y + GameCanvas.hCommand / 4, w, name, 7);
	}

	public int resetSelect(int select, int max, bool isreset)
	{
		if (select < 0)
		{
			select = (isreset ? max : 0);
		}
		else if (select > max)
		{
			select = ((!isreset) ? max : 0);
		}
		return select;
	}

	public virtual void updatekey()
	{
		if (GameCanvas.keyMyHold[(!Main.isPC) ? 5 : 36] || GameCanvas.keyMyHold[36])
		{
			if (center != null)
			{
				GameCanvas.clearKeyPressed(5);
				GameCanvas.clearKeyHold(5);
				GameCanvas.clearKeyPressed(36);
				GameCanvas.clearKeyHold(36);
				Cout.LogError2(" No ");
				center.perform();
			}
		}
		else if (GameCanvas.keyMyHold[12])
		{
			if (left != null)
			{
				Cout.LogError2(" 222222222222222222 ");
				GameCanvas.clearKeyPressed(12);
				GameCanvas.clearKeyHold(12);
				left.perform();
			}
		}
		else if (GameCanvas.keyMyHold[13] && right != null)
		{
			GameCanvas.clearKeyPressed(13);
			GameCanvas.clearKeyHold(13);
			right.perform();
		}
	}

	public virtual void updatePointer()
	{
		if (!GameCanvas.isTouch)
		{
			return;
		}
		if (left != null)
		{
			if (left.isPosCmd())
			{
				left.updatePointer();
			}
			else if (!left.isNotShowTab && GameCanvas.isPointSelect(0, GameCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10))
			{
				left.perform();
			}
		}
		if (right != null)
		{
			if (right.isPosCmd())
			{
				right.updatePointer();
			}
			else if (GameCanvas.isPointSelect(GameCanvas.w - GameCanvas.wCommand * 2, GameCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10))
			{
				right.perform();
			}
		}
		if (center != null)
		{
			if (center.isPosCmd())
			{
				center.updatePointer();
			}
			else if (GameCanvas.isPointSelect(GameCanvas.hw - GameCanvas.wCommand, GameCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10))
			{
				center.perform();
			}
		}
	}

	public static void Font3dWhite(mGraphics g, string str, int x, int y, int ar)
	{
		mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
		mFont.tahoma_7b_white.drawString(g, str, x, y, ar, mGraphics.isTrue);
	}

	public static void Font3dColor(mGraphics g, string str, int x, int y, int ar, sbyte color)
	{
		mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
		MainTabNew.setTextColorName(color).drawString(g, str, x, y, ar, mGraphics.isTrue);
	}

	public static void Font3dColorAndColor(mGraphics g, string str, int x, int y, int ar, sbyte color, sbyte color2)
	{
		MainTabNew.setTextColorName(color).drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
		MainTabNew.setTextColorName(color2).drawString(g, str, x, y, ar, mGraphics.isTrue);
	}

	public static void FontBorderColor(mGraphics g, string str, int x, int y, int ar, int color)
	{
		if (color == 2)
		{
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
		}
		else
		{
			mFont.tahoma_7b_black.drawString(g, str, x - 1, y - 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x - 1, y + 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y - 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x - 1, y, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x, y - 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x, y + 1, ar, mGraphics.isTrue);
		}
		MainTabNew.setTextColorName(color).drawString(g, str, x, y, ar, mGraphics.isTrue);
	}

	public virtual void loadBegin()
	{
	}
}
