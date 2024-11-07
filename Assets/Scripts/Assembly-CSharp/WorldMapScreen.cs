public class WorldMapScreen : MainScreen
{
	private int x;

	private int y;

	private int dy;

	private int timeSetPos;

	public static byte idMyPos = 5;

	public int xPoint;

	public int yPoint;

	public int idPoint;

	public int xplayer;

	public int yplayer;

	private int[][] mPosPoint = new int[19][]
	{
		new int[2] { 222, 263 },
		new int[2] { 266, 213 },
		new int[2] { 266, 213 },
		new int[2] { 238, 205 },
		new int[2] { 225, 197 },
		new int[2] { 201, 195 },
		new int[2] { 201, 195 },
		new int[2] { 329, 182 },
		new int[2] { 317, 161 },
		new int[2] { 305, 151 },
		new int[2] { 305, 151 },
		new int[2] { 362, 189 },
		new int[2] { 387, 195 },
		new int[2] { 415, 191 },
		new int[2] { 415, 191 },
		new int[2] { 372, 165 },
		new int[2] { 386, 148 },
		new int[2] { 390, 134 },
		new int[2] { 345, 161 }
	};

	public static string[] namePos;

	public static FrameImage fraMyPos;

	private Camera cam = new Camera();

	private int beginx;

	private int beginy;

	private int xafter;

	private int yafter;

	private bool ismove;

	public WorldMapScreen()
	{
		x = (GameCanvas.w - 480) / 2;
		y = (GameCanvas.h - 320) / 2;
		if (x < 0)
		{
			x = 0;
		}
		if (y < 0)
		{
			y = 0;
		}
		cam.setAll(480 - GameCanvas.w, 320 - GameCanvas.h, 0, 0);
		xPoint = mPosPoint[1][0];
		yPoint = mPosPoint[1][1];
		cam.xCam = xPoint - GameCanvas.hw;
		cam.yCam = yPoint - GameCanvas.hh;
		if (cam.xCam < 0)
		{
			cam.xCam = 0;
		}
		if (cam.xCam > cam.xLimit)
		{
			cam.xCam = cam.xLimit;
		}
		if (cam.yCam < 0)
		{
			cam.yCam = 0;
		}
		if (cam.yCam > cam.yLimit)
		{
			cam.yCam = cam.yLimit;
		}
		cam.xTo = cam.xCam;
		cam.yTo = cam.yCam;
		iCommand iCommand2 = new iCommand(T.close, -1);
		if (!GameCanvas.isTouch)
		{
			left = new iCommand(T.select, 0);
		}
		else
		{
			iCommand2.setPos(PaintInfoGameScreen.fraBack.frameWidth / 2, GameCanvas.h - PaintInfoGameScreen.fraBack.frameHeight / 2, PaintInfoGameScreen.fraBack, iCommand2.caption);
		}
		right = iCommand2;
	}

	public override void Show(MainScreen scr)
	{
		GameCanvas.start_Ok_Dialog(T.lockMap);
	}

	public override void Show()
	{
		mSystem.outloi("goi ham show kia");
		Show(GameCanvas.currentScreen);
	}

	public void setPosPlayer(int index)
	{
	}

	public override void commandTab(int index, int sub)
	{
		switch (index)
		{
		case -1:
			if (lastScreen == GameCanvas.AllInfo)
			{
				lastScreen.Show(lastScreen.lastScreen);
			}
			else
			{
				lastScreen.Show();
			}
			break;
		}
		base.commandTab(index, sub);
	}

	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
		}
		base.commandPointer(index, subIndex);
	}

	public override void paint(mGraphics g)
	{
		g.setColor(5595238);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		g.translate(-cam.xCam, -cam.yCam);
		g.drawImage(AvMain.imgWorldMap, x, y, 0, mGraphics.isFalse);
		if (timeSetPos == -1 && (!GameCanvas.isTouch || GameCanvas.isPointerDown || GameCanvas.isPointerMove))
		{
			mFont.tahoma_7b_black.drawString(g, namePos[idPoint], cam.xCam + GameCanvas.w - 5, cam.yCam + 4, 1, mGraphics.isFalse);
			mFont.tahoma_7b_white.drawString(g, namePos[idPoint], cam.xCam + GameCanvas.w - 4, cam.yCam + 5, 1, mGraphics.isFalse);
		}
		fraMyPos.drawFrame(GameCanvas.gameTick / 2 % fraMyPos.nFrame, x + xplayer - 1, y + yplayer - 1, 0, 3, g);
		if (!GameCanvas.isTouch)
		{
			g.drawImage(AvMain.imgSelect, x + xPoint, y + yPoint - dy, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null)
		{
			if (GameCanvas.isTouch)
			{
				base.paint(g);
			}
			else
			{
				paintCmd_OnlyText(g);
			}
		}
	}

	public override void update()
	{
		updateKey();
		if (timeSetPos > 0)
		{
			timeSetPos--;
			if (timeSetPos == 1)
			{
				for (int i = 0; i < mPosPoint.Length; i++)
				{
					if (CRes.abs(mPosPoint[i][0] - xPoint) <= 6 && CRes.abs(mPosPoint[i][1] - yPoint) <= 6)
					{
						xPoint = mPosPoint[i][0];
						yPoint = mPosPoint[i][1];
						idPoint = i;
						timeSetPos = -1;
						break;
					}
				}
			}
		}
		if (timeSetPos < 0)
		{
			dy = GameCanvas.gameTick % 4;
		}
		else
		{
			dy = 0;
		}
		cam.UpdateCamera();
	}

	public void updateKey()
	{
		if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[24])
		{
			if (xPoint > 10)
			{
				xPoint -= 5;
			}
			else
			{
				xPoint = 5;
			}
			timeSetPos = 3;
			if (cam.xLimit > 0)
			{
				cam.xTo -= 5;
			}
		}
		else if (GameCanvas.keyMyHold[6] || GameCanvas.keyMyHold[26])
		{
			if (xPoint < 470)
			{
				xPoint += 5;
			}
			else
			{
				xPoint = 475;
			}
			timeSetPos = 3;
			if (cam.xLimit > 0)
			{
				cam.xTo += 5;
			}
		}
		else if (GameCanvas.keyMyHold[2] || GameCanvas.keyMyHold[22])
		{
			if (yPoint > 10)
			{
				yPoint -= 5;
			}
			else
			{
				yPoint = 5;
			}
			timeSetPos = 3;
			if (cam.yLimit > 0)
			{
				cam.yTo -= 5;
			}
		}
		else if (GameCanvas.keyMyHold[8] || GameCanvas.keyMyHold[28])
		{
			if (yPoint < 315)
			{
				yPoint += 5;
			}
			else
			{
				yPoint = 320;
			}
			timeSetPos = 3;
			if (cam.yLimit > 0)
			{
				cam.yTo += 5;
			}
		}
		base.updatekey();
	}

	public override void updatePointer()
	{
		base.updatePointer();
		if (GameCanvas.isPointerMove)
		{
			if (!ismove)
			{
				beginx = GameCanvas.px;
				beginy = GameCanvas.py;
				xafter = cam.xCam;
				yafter = cam.yCam;
				ismove = true;
			}
			else
			{
				cam.xCam = xafter - (GameCanvas.px - beginx);
				cam.yCam = yafter - (GameCanvas.py - beginy);
				if (cam.xCam < 0)
				{
					cam.xCam = 0;
				}
				if (cam.xCam > cam.xLimit)
				{
					cam.xCam = cam.xLimit;
				}
				if (cam.yCam < 0)
				{
					cam.yCam = 0;
				}
				if (cam.yCam > cam.yLimit)
				{
					cam.yCam = cam.yLimit;
				}
				cam.xTo = cam.xCam;
				cam.yTo = cam.yCam;
			}
		}
		if (GameCanvas.isPointerRelease || !GameCanvas.isPointerMove)
		{
			ismove = false;
			beginx = 0;
			beginy = 0;
		}
		if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
		{
			xPoint = GameCanvas.px + cam.xCam - x;
			yPoint = GameCanvas.py + cam.yCam - y;
		}
		for (int i = 0; i < mPosPoint.Length; i++)
		{
			if (CRes.abs(mPosPoint[i][0] - xPoint) <= 8 && CRes.abs(mPosPoint[i][1] - yPoint) <= 8)
			{
				idPoint = i;
				timeSetPos = -1;
				return;
			}
		}
		timeSetPos = 3;
	}
}
