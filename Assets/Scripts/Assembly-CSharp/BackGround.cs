public class BackGround
{
	public const int CLOUD_POS_OFFSET_Y = 10;

	public static mImage mImgSky = new mImage();

	public static mImage mImgSea = new mImage();

	public static mImage[] mImgCloud = new mImage[3];

	public static mImage mImgBoat = new mImage();

	public static mImage mImgFloating = new mImage();

	public static FrameImage mImgSeaAuto;

	public static mVector2[] cloudPos = new mVector2[7];

	public static mVector2[] intingPos = new mVector2[3];

	public static int[] cloudType = new int[7];

	public static int[] cloudVelo = new int[7];

	public static int fillSkyH = 70;

	private static int numSkyDraw;

	private static int skyWidth;

	private static int skyHeight;

	private static int numSeaDrawW;

	private static int numSeaDrawH;

	private static int seaWidth;

	private static int seaHeight;

	private static int numCloudDraw;

	private static int cloudWidth;

	private static int cloudHeight;

	public static int[] staticCloudPos = new int[3];

	public static void init()
	{
		LoadBackGround();
		skyWidth = mImage.getImageWidth(mImgSky.image);
		skyHeight = mImage.getImageHeight(mImgSky.image);
		numSkyDraw = GameCanvas.w / skyWidth;
		seaWidth = mImage.getImageWidth(mImgSea.image);
		seaHeight = mImage.getImageHeight(mImgSea.image);
		numSeaDrawW = GameCanvas.w / seaWidth;
		numSeaDrawH = (GameCanvas.h - (fillSkyH + skyHeight)) / seaHeight;
		cloudWidth = mImage.getImageWidth(mImgCloud[0].image);
		cloudHeight = mImage.getImageHeight(mImgCloud[0].image);
		numCloudDraw = GameCanvas.w / cloudWidth;
		for (int i = 0; i < cloudPos.Length; i++)
		{
			cloudPos[i] = new mVector2();
			cloudPos[i].x = CRes.random(0, GameCanvas.w);
			cloudPos[i].y = CRes.random(6) * 10;
			cloudType[i] = CRes.random(1, 3);
			cloudVelo[i] = CRes.random(0, 2);
		}
		for (int j = 0; j < intingPos.Length; j++)
		{
			intingPos[j] = new mVector2();
			intingPos[j].x = GameCanvas.hw - 80 + j * 80;
			intingPos[j].y = GameCanvas.h - 50 - j % 2 * 25;
		}
		staticCloudPos = new int[numCloudDraw + 2];
		for (int k = 0; k < staticCloudPos.Length; k++)
		{
			staticCloudPos[k] = k * cloudWidth - mImage.getImageWidth(mImgCloud[0].image);
		}
	}

	public static void paint(mGraphics g)
	{
		g.setColor(16746751);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, useClip: true);
		if (mImgSky == null || mImgSea == null || mImgFloating == null)
		{
			LoadBackGround();
		}
		else
		{
			paint_Sky(g);
			paint_Boat(g);
			paint_Sea(g);
			paint_Cloud(g);
		}
		g.translate(GameCanvas.hw - GameCanvas.loadmap.mapWLogin * LoadMap.wTile / 2, GameCanvas.h - GameCanvas.loadmap.mapHLogin * LoadMap.wTile);
		GameCanvas.resetTrans(g);
	}

	public static void paintLight(mGraphics g)
	{
	}

	public static void paint_Boat(mGraphics g)
	{
		g.drawImage(mImgBoat, 10, fillSkyH + skyHeight / 2, 0, mGraphics.isFalse);
	}

	public static void paint_Sky(mGraphics g)
	{
		g.setColor(4941460);
		g.fillRect(0, 0, GameCanvas.w, fillSkyH, mGraphics.isFalse);
		for (int i = 0; i < numSkyDraw + 1; i++)
		{
			g.drawImage(mImgSky, i * skyWidth, fillSkyH, 0, mGraphics.isFalse);
		}
	}

	public static void paint_Sea(mGraphics g)
	{
		int num = fillSkyH + skyHeight;
		for (int i = 0; i < numSeaDrawW + 1; i++)
		{
			for (int j = 0; j < numSeaDrawH + 1; j++)
			{
				g.drawImage(mImgSea, i * seaWidth, j * seaHeight + num, 0, mGraphics.isFalse);
			}
		}
	}

	public static void paint_Cloud(mGraphics g)
	{
		for (int i = 0; i < 4; i++)
		{
			g.drawImage(mImgCloud[cloudType[i]], (int)cloudPos[i].x, (int)cloudPos[i].y, 0, mGraphics.isFalse);
		}
	}

	public static void paint_StaticCloud(mGraphics g)
	{
		int y = GameCanvas.h - cloudHeight;
		for (int i = 0; i < staticCloudPos.Length; i++)
		{
			g.drawImage(mImgCloud[0], staticCloudPos[i], y, 0, mGraphics.isFalse);
		}
	}

	public static void paint_CloudOnLogo(mGraphics g)
	{
		for (int i = 4; i < cloudPos.Length; i++)
		{
			g.drawImage(mImgCloud[cloudType[i]], (int)cloudPos[i].x, (int)cloudPos[i].y, 0, mGraphics.isFalse);
		}
	}

	public static void paint_FloatingPlatform(mGraphics g)
	{
		for (int i = 0; i < intingPos.Length; i++)
		{
			g.drawImage(mImgFloating, (int)intingPos[i].x, (int)intingPos[i].y, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
		}
	}

	public static void updateSky()
	{
		for (int i = 0; i < cloudPos.Length; i++)
		{
			cloudVelo[i] = 1;
			cloudPos[i].x += cloudVelo[i];
			if (cloudPos[i].x > (float)GameCanvas.w)
			{
				cloudPos[i].x = -mImage.getImageWidth(mImgCloud[1].image);
				cloudPos[i].y = CRes.random(6) * 10;
				cloudType[i] = CRes.random(1, 3);
				cloudVelo[i] = CRes.random(1, 2);
			}
		}
		int num = -1;
		int num2 = -1;
		for (int j = 0; j < staticCloudPos.Length; j++)
		{
			staticCloudPos[j] += 2;
			if (staticCloudPos[j] > GameCanvas.w)
			{
				int num3 = j + 1;
				if (num3 > staticCloudPos.Length - 1)
				{
					num3 = 0;
				}
				if (num == -1)
				{
					num = j;
					num2 = num3;
				}
			}
		}
		if (num != -1 && num2 != -1)
		{
			staticCloudPos[num] = staticCloudPos[num2] - cloudWidth;
			num = -1;
			num2 = -1;
		}
	}

	public static void LoadBackGround()
	{
		mImgSky = mImage.createImage("/bg/sky.img");
		mImgSea = mImage.createImage("/bg/sea.img");
		for (int i = 0; i < mImgCloud.Length; i++)
		{
			mImgCloud[i] = mImage.createImage("/bg/cloud" + i + ".img");
		}
		mImgBoat = mImage.createImage("/bg/boat.img");
		mImgFloating = mImage.createImage("/bg/floating.img");
		if (mImgSeaAuto == null)
		{
			mImgSeaAuto = new FrameImage(mImage.createImage("/bg/seabg.png"), 24, 24);
		}
	}

	public static void LoadImgCloud()
	{
		for (int i = 0; i < mImgCloud.Length; i++)
		{
			if (mImgCloud[i] == null)
			{
				mImgCloud[i] = mImage.createImage("/bg/cloud" + i + ".img");
			}
		}
	}

	public static void paint_SeaCloud(mGraphics g)
	{
		for (int i = 0; i < 4; i++)
		{
			g.drawImage(mImgCloud[cloudType[i]], (int)cloudPos[i].x, (int)cloudPos[i].y + GameCanvas.h / 2, 0, mGraphics.isFalse);
		}
	}

	public static void paint_SeaAuto(mGraphics g)
	{
		for (int i = 0; i < GameCanvas.w / 24 + 1; i++)
		{
			for (int j = 0; j < GameCanvas.h / 24 + 1; j++)
			{
				mImgSeaAuto.drawFrame((GameCanvas.gameTick % 14 < 7) ? 1 : 0, i * 24, j * 24, 0, g);
			}
		}
	}
}
