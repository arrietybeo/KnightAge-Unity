public class MapScr : MainScreen
{
	private static MapScr instance;

	private bool modeCurrentMap;

	public static mImage imgMap = null;

	public static int mapW;

	public static int mapH;

	public static int mfx;

	public static int mfy;

	public static int mpoint;

	public static int tick3;

	public static int mcmtoX;

	public static int mcmtoY;

	public static int mcmvx;

	public static int mcmvy;

	public static int mcmdx;

	public static int mcmdy;

	public static int mcmx;

	public static int mcmy;

	public static int mcmxLim;

	public static int mcmyLim;

	public static int taskmapId;

	private static int dx = 0;

	private static int dy = 0;

	public static int cmdH = 22;

	public static int TOP_CENTER = mGraphics.TOP | mGraphics.HCENTER;

	public static int TOP_LEFT = mGraphics.TOP | mGraphics.LEFT;

	public static int TOP_RIGHT = mGraphics.TOP | mGraphics.RIGHT;

	public static int BOTTOM_HCENTER = mGraphics.BOTTOM | mGraphics.HCENTER;

	public static int BOTTOM_LEFT = mGraphics.BOTTOM | mGraphics.LEFT;

	public static int BOTTOM_RIGHT = mGraphics.BOTTOM | mGraphics.RIGHT;

	public static int VCENTER_HCENTER = mGraphics.VCENTER | mGraphics.HCENTER;

	public static int VCENTER_LEFT = mGraphics.VCENTER | mGraphics.LEFT;

	public static int[] x = new int[123]
	{
		108, 111, 131, 93, 76, 58, 39, 102, 83, 66,
		49, 121, 135, 154, 160, 100, 94, 80, 128, 73,
		100, 88, 53, 83, 73, 127, 109, 89, 72, 171,
		172, 185, 202, 134, 117, 157, 135, 99, 102, 122,
		139, 156, 47, 44, 28, 23, 0, 47, 87, 0,
		133, 159, 23, 207, 207, 239, 226, 207, 207, 168,
		182, 217, 23, 71, 24, 88, 25, 66, 99, 40,
		47, 28, 64, 47, 47, 67, 83, 98, 111, 128,
		0, 0, 117, 219, 191, 219, 241, 218, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1
	};

	public static int[] y = new int[128]
	{
		247, 233, 220, 235, 236, 238, 237, 216, 212, 216,
		205, 210, 204, 203, 182, 196, 180, 172, 183, 117,
		144, 130, 134, 146, 134, 162, 160, 160, 160, 141,
		125, 114, 116, 145, 144, 147, 128, 118, 98, 96,
		88, 75, 149, 165, 165, 181, 0, 118, 224, 0,
		235, 59, 200, 201, 187, 162, 167, 129, 143, 171,
		171, 166, 217, 57, 62, 60, 83, 92, 72, 92,
		69, 43, 42, 35, 18, 14, 8, 14, 28, 27,
		0, 0, 132, 116, 96, 71, 94, 94, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1
	};

	public static string[] mapNames;

	private int maxPX;

	private int maxPY;

	private int xM;

	private int yM;

	private bool trans;

	private int lastX;

	private int lastY;

	public MapScr()
	{
		center = new iCommand(T.close, 0, this);
	}

	protected void resetCMLim()
	{
		int num = GameCanvas.loadmap.idMap;
		if (num > x.Length)
		{
			num = x.Length - 1;
		}
		int num2 = 0;
		int num3 = 0;
		if (!mSystem.isWinphone)
		{
			num2 = mImage.getImageWidth(MiniMap.imgMiniMap.image);
			num3 = mImage.getImageHeight(MiniMap.imgMiniMap.image);
		}
		xM = (GameCanvas.w - num2) / 2;
		yM = (GameCanvas.h - 20 - num3) / 2;
		if (xM < 0)
		{
			xM = 0;
		}
		if (yM < 0)
		{
			yM = 0;
		}
		if (modeCurrentMap)
		{
			mcmxLim = num2 + 20 - GameCanvas.w;
			mcmyLim = mImage.getImageHeight(MiniMap.imgMiniMap.image) + 40 - GameCanvas.h;
			maxPX = num2 + 20;
			maxPY = num2 + 40;
			if (maxPY < GameCanvas.h - 26)
			{
				maxPY = GameCanvas.h - 26;
			}
			if (maxPX < GameCanvas.w)
			{
				maxPX = GameCanvas.w;
			}
			mfx = xM + GameScreen.player.x / 12;
			mfy = yM + GameScreen.player.y / 12;
		}
		else
		{
			mcmxLim = 340 - GameCanvas.w;
			mcmyLim = 340 - GameCanvas.h;
			mfx = x[num] + dx;
			mfy = y[num] + dy;
			maxPX = 330 + dx;
			maxPY = 310 + dy;
		}
		maxPX -= 10;
		maxPY -= 10;
		if (mcmxLim < 0)
		{
			mcmxLim = 0;
		}
		if (mcmyLim < 0)
		{
			mcmyLim = 0;
		}
		mcmx = (mcmy = 0);
		mcmtoX = (mcmtoY = 0);
		mcmtoX = mfx - GameCanvas.hw;
		mcmtoY = mfy - GameCanvas.hh;
	}

	public static MapScr gI()
	{
		if (instance == null)
		{
			instance = new MapScr();
		}
		return instance;
	}

	public override void Show()
	{
		base.Show();
		center = new iCommand(T.close, 0, this);
		if (imgMap == null)
		{
			imgMap = mImage.createImage("/wm.png");
			mapW = mImage.getImageWidth(imgMap.image);
			mapH = mImage.getImageWidth(imgMap.image);
		}
		if (GameCanvas.w > mapW)
		{
			dx = GameCanvas.w / 2 - mapW / 2;
		}
		if (GameCanvas.h > mapH)
		{
			dy = GameCanvas.h / 2 - mapH / 2;
		}
		resetCMLim();
		findMapNearestPoint();
		mapNames = T.mapName;
	}

	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		g.translate(10, 10);
		g.translate(-mcmx, -mcmy);
		if (GameCanvas.w > mapW && GameCanvas.h > mapH)
		{
			g.drawImage(imgMap, GameCanvas.hw, GameCanvas.hh, VCENTER_HCENTER, mGraphics.isFalse);
		}
		else if (GameCanvas.w > mapW)
		{
			g.drawImage(imgMap, GameCanvas.hw, 0, TOP_CENTER, mGraphics.isFalse);
		}
		else if (GameCanvas.h > mapH)
		{
			g.drawImage(imgMap, 0, GameCanvas.hh, VCENTER_LEFT, mGraphics.isFalse);
		}
		else
		{
			g.drawImage(imgMap, 0, 0, 0, mGraphics.isFalse);
		}
		if (GameCanvas.loadmap.idMap < mapNames.Length && GameCanvas.loadmap.idMap >= 0)
		{
			int align = 0;
			if (x[GameCanvas.loadmap.idMap] != 1 || y[GameCanvas.loadmap.idMap] != 1)
			{
				align = ((x[GameCanvas.loadmap.idMap] >= 100) ? ((x[GameCanvas.loadmap.idMap] > 200) ? 1 : 2) : 0);
				g.drawRegion(AvMain.imgFocusMap, 0, GameCanvas.gameTick % 3 * 10, 10, 10, 0, x[GameCanvas.loadmap.idMap] + dx, y[GameCanvas.loadmap.idMap] + dy, 3, mGraphics.isFalse);
			}
			int num = 0;
			if (x[GameCanvas.loadmap.idMap] != 1 || y[GameCanvas.loadmap.idMap] != 1)
			{
				num = y[GameCanvas.loadmap.idMap] - 20;
				mFont.tahoma_7b_black.drawString(g, mapNames[GameCanvas.loadmap.idMap], x[GameCanvas.loadmap.idMap] + dx + 1, y[GameCanvas.loadmap.idMap] + dy - 20 + 1, align, mGraphics.isFalse);
				mFont.tahoma_7b_yellow.drawString(g, mapNames[GameCanvas.loadmap.idMap], x[GameCanvas.loadmap.idMap] + dx, y[GameCanvas.loadmap.idMap] + dy - 20, align, mGraphics.isFalse);
			}
			if (mpoint >= 0 && ((taskmapId < 0 && GameCanvas.loadmap.idMap != mpoint) || (taskmapId >= 0 && mpoint != taskmapId)))
			{
				align = ((x[mpoint] >= 100) ? ((x[mpoint] > 200) ? 1 : 2) : 0);
				int num2 = x[mpoint];
				int num3 = y[mpoint] - 20;
				if (num3 > num && num3 - num < 30)
				{
					num3 += 40;
				}
				if (num3 < num && num - num3 < 20)
				{
					num3 -= 5;
				}
				mFont.tahoma_7b_black.drawString(g, mapNames[mpoint], num2 + dx + 1, num3 + dy + 1, align, mGraphics.isFalse);
				mFont.tahoma_7b_yellow.drawString(g, mapNames[mpoint], num2 + dx, num3 + dy, align, mGraphics.isFalse);
			}
		}
		if (!GameCanvas.isTouch)
		{
			g.drawRegion(MainTabNew.imgTab[5], 0, 0, 10, 10, 0, mfx - 2, mfy, 0, mGraphics.isFalse);
		}
		else if (mpoint >= 0)
		{
			int num4 = x[mpoint] - 9;
			int num5 = y[mpoint];
			g.drawRegion(MainTabNew.imgTab[5], 0, 0, 10, 10, 0, num4 + dx, num5 + dy, 0, mGraphics.isFalse);
		}
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		base.paint(g);
	}

	public override void updatekey()
	{
		base.updatekey();
		tick3++;
		if (tick3 > 10000)
		{
			tick3 = 0;
		}
		if (mcmx != mcmtoX || mcmy != mcmtoY)
		{
			mcmvx = mcmtoX - mcmx << 1;
			mcmvy = mcmtoY - mcmy << 1;
			mcmdx += mcmvx;
			mcmx += mcmdx >> 4;
			mcmdx &= 15;
			mcmdy += mcmvy;
			mcmy += mcmdy >> 4;
			mcmdy &= 15;
			if (mcmx < 0)
			{
				mcmx = 0;
			}
			if (mcmx > mcmxLim)
			{
				mcmx = mcmxLim;
			}
			if (mcmy < 0)
			{
				mcmy = 0;
			}
			if (mcmy > mcmyLim)
			{
				mcmy = mcmyLim;
			}
		}
		bool flag = false;
		if (GameCanvas.keyMyHold[2])
		{
			mfy -= 4;
			if (mfy < dy - 10)
			{
				mfy = dy - 10;
			}
			flag = true;
		}
		if (GameCanvas.keyMyHold[8])
		{
			mfy += 4;
			if (mfy > maxPY)
			{
				mfy = maxPY;
			}
			flag = true;
		}
		if (GameCanvas.keyMyHold[4])
		{
			mfx -= 4;
			if (mfx < dx - 10)
			{
				mfx = dx - 10;
			}
			flag = true;
		}
		if (GameCanvas.keyMyHold[6])
		{
			mfx += 4;
			if (mfx > maxPX)
			{
				mfx = maxPX;
			}
			flag = true;
		}
		if (flag)
		{
			mcmtoX = mfx - GameCanvas.hw;
			mcmtoY = mfy - GameCanvas.hh;
			findMapNearestPoint();
		}
		if (GameCanvas.isPointerClick && GameCanvas.py < GameCanvas.h - cmdH)
		{
			GameCanvas.isPointerClick = false;
			trans = true;
			lastX = GameCanvas.px;
			lastY = GameCanvas.py;
		}
		else if (GameCanvas.isPointerDown && trans)
		{
			mcmtoX -= GameCanvas.px - lastX;
			mcmtoY -= GameCanvas.py - lastY;
			if (mcmtoX < 0)
			{
				mcmtoX = 0;
			}
			if (mcmtoY < 0)
			{
				mcmtoY = 0;
			}
			if (mcmtoX > mcmxLim)
			{
				mcmtoX = mcmxLim;
			}
			if (mcmtoY > mcmyLim)
			{
				mcmtoY = mcmyLim;
			}
			mcmx = mcmtoX;
			mcmy = mcmtoY;
			lastX = GameCanvas.px;
			lastY = GameCanvas.py;
		}
		if (GameCanvas.isPointerRelease)
		{
			int num = GameCanvas.pxLast - GameCanvas.px;
			int num2 = GameCanvas.pyLast - GameCanvas.py;
			if (num < 10 && num2 < 10)
			{
				mfx = mcmx + GameCanvas.pxLast - 8;
				mfy = mcmy + GameCanvas.pyLast - 8;
				findMapNearestPoint();
			}
			trans = false;
			GameCanvas.isPointerRelease = false;
		}
		if (GameCanvas.isTouch && GameCanvas.w >= 320)
		{
			center.xCmd = GameCanvas.w / 2 - 35;
		}
	}

	private static void findMapNearestPoint()
	{
		mpoint = -1;
		int num = 10;
		if (!GameCanvas.isTouch)
		{
			num = 13;
		}
		for (int i = 0; i < x.Length; i++)
		{
			if (CRes.abs(mfx - (x[i] + dx)) < num && CRes.abs(mfy - (y[i] + dy)) < num)
			{
				mpoint = i;
				break;
			}
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			imgMap = null;
			GameScreen.gI().Show();
			break;
		case 1:
			modeCurrentMap = !modeCurrentMap;
			resetCMLim();
			break;
		}
	}
}
