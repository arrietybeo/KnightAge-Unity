using UnityEngine;

public class MapBackGround
{
	private sbyte typeMap;

	private sbyte[] mList3;

	private int w1;

	private int w2;

	private int w3;

	private int size1;

	private int size2;

	private int size3;

	private int h1;

	private int h2;

	private int h3;

	private int sizeScreen;

	private int hBack;

	private int hLimit;

	private int valueRandom;

	private int sizeScreen2;

	private int nX;

	private Point[] PosCloud;

	private mImage[] mImg;

	private mImage[] mImgCloud;

	public int color;

	public string colorMini;

	public void setBackGround(sbyte type, short h)
	{
		Debug.LogWarning("load back ground " + type);
		typeMap = type;
		hBack = h;
		if (GameCanvas.lowGraphic)
		{
			color = 6992343;
			colorMini = "0x6ab1d7";
			return;
		}
		switch (typeMap)
		{
		case 1:
			w1 = 256;
			size1 = GameCanvas.loadmap.mapW * LoadMap.wTile / w1 + 1;
			color = 8051685;
			colorMini = 8051685 + string.Empty;
			h1 = 92;
			h2 = 85;
			h3 = 110;
			hLimit = hBack - (h1 + h2 + h3);
			sizeScreen = GameCanvas.w / w1 + 1;
			mImg = new mImage[3];
			mImg[0] = mImage.createImage("/bg/bg1_0.img");
			mImg[1] = mImage.createImage("/bg/bg1_1.img");
			mImg[2] = mImage.createImage("/bg/bg1_2.img");
			valueRandom = (hLimit + 30) / 2;
			break;
		case 2:
		{
			w1 = 120;
			size1 = GameCanvas.loadmap.mapW * LoadMap.wTile / w1 + 1;
			color = 5940735;
			colorMini = "0x4c8f98";
			h1 = 72;
			h2 = 28;
			h3 = 77;
			hLimit = hBack - (h1 + h2 + h3);
			sizeScreen = GameCanvas.w / w1 + 1;
			mImg = new mImage[5];
			mImg[0] = mImage.createImage("/bg/bg2_0.img");
			mImg[1] = mImage.createImage("/bg/bg2_1.img");
			mImg[2] = mImage.createImage("/bg/bg2_20.img");
			mImg[3] = mImage.createImage("/bg/bg2_21.img");
			mImg[4] = mImage.createImage("/bg/bg2_22.img");
			mList3 = new sbyte[size1];
			for (int i = 0; i < size1; i++)
			{
				mList3[i] = (sbyte)CRes.random(3);
			}
			valueRandom = 25;
			break;
		}
		case 3:
			w1 = 253;
			w2 = 96;
			size1 = GameCanvas.loadmap.mapW * LoadMap.wTile / w1 + 1;
			size2 = GameCanvas.loadmap.mapW * LoadMap.wTile / w2 + 1;
			color = 6992343;
			colorMini = "0x6ab1d7";
			h1 = 108;
			h2 = 72;
			nX = (hBack - 120) / h2;
			if (nX > 5)
			{
				nX = 5;
			}
			hLimit = hBack - (h1 + h2 * nX);
			sizeScreen = GameCanvas.w / w1 + 1;
			sizeScreen2 = GameCanvas.w / w2 + 1;
			mImg = new mImage[2];
			mImg[0] = mImage.createImage("/bg/bg3_0.img");
			mImg[1] = mImage.createImage("/bg/bg3_1.img");
			valueRandom = (hLimit + 30) / 2;
			break;
		}
		PosCloud = new Point[GameCanvas.loadmap.mapW * LoadMap.wTile / 250 + 1];
		for (int j = 0; j < PosCloud.Length; j++)
		{
			PosCloud[j] = new Point();
			PosCloud[j].x = 125 + CRes.random_Am_0(125) + j * 250;
			PosCloud[j].y = valueRandom + CRes.random_Am_0(valueRandom);
			PosCloud[j].vx = -CRes.random(1, 3);
			PosCloud[j].frame = CRes.random(0, 2);
		}
		mImgCloud = new mImage[2];
		mImgCloud[0] = mImage.createImage("/bg/may0.img");
		mImgCloud[1] = mImage.createImage("/bg/may1.img");
	}

	public void paint(mGraphics g)
	{
		if (GameCanvas.lowGraphic)
		{
			if (MainScreen.cameraMain.yCam <= hBack)
			{
				g.setColor(color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
			}
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		switch (typeMap)
		{
		case 1:
		{
			num = MainScreen.cameraMain.xCam / w1;
			num3 = num + sizeScreen + 1;
			if (num3 > size1)
			{
				num3 = size1;
			}
			if (MainScreen.cameraMain.yCam <= hLimit)
			{
				g.setColor(color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, hLimit, mGraphics.isFalse);
			}
			for (int m = num; m < num3; m++)
			{
				if (MainScreen.cameraMain.yCam <= h1 + hLimit)
				{
					g.drawImage(mImg[0], m * w1, hLimit, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraMain.yCam <= h2 + h1 + hLimit)
				{
					g.drawImage(mImg[1], m * w1, h1 + hLimit, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraMain.yCam <= h2 + h1 + h3 + hLimit)
				{
					g.drawImage(mImg[2], m * w1, h1 + h2 + hLimit, 0, mGraphics.isFalse);
				}
			}
			break;
		}
		case 2:
		{
			num = MainScreen.cameraMain.xCam / w1;
			if (num < 0)
			{
				num = 0;
			}
			num3 = num + sizeScreen + 1;
			if (num3 > size1)
			{
				num3 = size1;
			}
			if (MainScreen.cameraMain.yCam <= hLimit)
			{
				g.setColor(color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, hLimit, mGraphics.isFalse);
			}
			for (int l = num; l < num3; l++)
			{
				if (MainScreen.cameraMain.yCam <= h1 + hLimit)
				{
					g.drawImage(mImg[0], l * w1, hLimit, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraMain.yCam <= h2 + h1 + hLimit)
				{
					g.drawImage(mImg[1], l * w1, h1 + hLimit, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraMain.yCam <= h2 + h1 + h3 + hLimit)
				{
					g.drawImage(mImg[2 + mList3[l]], l * w1, h1 + h2 + hLimit, 0, mGraphics.isFalse);
				}
			}
			break;
		}
		case 3:
		{
			if (MainScreen.cameraMain.yCam <= hLimit)
			{
				g.setColor(color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, hLimit, mGraphics.isFalse);
			}
			num2 = MainScreen.cameraMain.xCam / w2;
			if (num2 < 0)
			{
				num2 = 0;
			}
			num4 = num2 + sizeScreen2 + 1;
			if (num4 > size2)
			{
				num4 = size2;
			}
			for (int i = num2; i < num4; i++)
			{
				for (int j = 0; j < nX; j++)
				{
					g.drawImage(mImg[1], i * w2, hLimit + h1 + j * h2, 0, mGraphics.isFalse);
				}
			}
			num = MainScreen.cameraMain.xCam / w1;
			if (num < 0)
			{
				num = 0;
			}
			num3 = num + sizeScreen + 1;
			if (num3 > size1)
			{
				num3 = size1;
			}
			for (int k = num; k < num3; k++)
			{
				if (MainScreen.cameraMain.yCam <= h1 + hLimit)
				{
					g.drawImage(mImg[0], k * w1, hLimit, 0, mGraphics.isFalse);
				}
			}
			break;
		}
		}
		for (int n = 0; n < PosCloud.Length; n++)
		{
			if (MainScreen.cameraMain.yCam - 10 <= PosCloud[n].y)
			{
				g.drawImage(mImgCloud[PosCloud[n].frame], PosCloud[n].x, PosCloud[n].y, mGraphics.VCENTER | mGraphics.LEFT, mGraphics.isFalse);
			}
		}
	}

	public void updateCloud()
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		for (int i = 0; i < PosCloud.Length; i++)
		{
			PosCloud[i].x += PosCloud[i].vx;
			if (PosCloud[i].x < -80)
			{
				PosCloud[i].x = GameCanvas.loadmap.mapW * LoadMap.wTile + CRes.random_Am_0(125);
				PosCloud[i].y = valueRandom + CRes.random_Am_0(valueRandom);
				PosCloud[i].vx = -CRes.random(1, 3);
				PosCloud[i].frame = CRes.random(0, 2);
			}
		}
	}
}
