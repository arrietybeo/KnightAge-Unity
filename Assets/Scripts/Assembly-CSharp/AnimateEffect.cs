public class AnimateEffect : MainEffect
{
	public const sbyte RAIN = 0;

	public const sbyte FALLING_LEAVES = 1;

	public const sbyte SNOW = 2;

	public const sbyte FALLING_FLOWER = 3;

	public const sbyte THIEN_THACH = 4;

	public const sbyte CLOUD = 5;

	public sbyte type;

	public int number;

	public int timeLimit;

	public int curTime;

	public int numClound;

	public mVector list = new mVector("AnimateEffect list");

	public new bool isStop;

	private static int wind = 5;

	private static int countWind;

	private static int dirWind = CRes.random_Am_0(2);

	public mImage imgEffect;

	public mImage[] imgEffectCloud;

	private int wimg;

	private int himg;

	private new int vx;

	private new int vy;

	public AnimateEffect(sbyte type, bool isStart, int number, int timeLimit)
	{
		this.timeLimit = timeLimit;
		curTime = (int)(GameCanvas.timeNow / 1000);
		this.type = type;
		int num = 1;
		switch (type)
		{
		case 1:
			num = 3;
			imgEffect = mImage.createImage("/efleaf.img");
			break;
		case 2:
			num = 2;
			imgEffect = mImage.createImage("/efsnow.img");
			break;
		case 3:
			imgEffect = mImage.createImage("/efhoa.img");
			break;
		case 4:
			num = 12;
			break;
		case 5:
			isStop = true;
			return;
		}
		if (number > 0)
		{
			this.number = number;
		}
		else
		{
			switch (number)
			{
			case -1:
				this.number = GameCanvas.w * GameCanvas.h / (8 * num * 200);
				break;
			case -2:
				this.number = GameCanvas.w * GameCanvas.h / (6 * num * 200);
				break;
			case -3:
				this.number = GameCanvas.w * GameCanvas.h / (3 * num * 200);
				break;
			case -4:
				this.number = GameCanvas.w * GameCanvas.h / (2 * num * 200);
				break;
			default:
				this.number = 10;
				break;
			}
		}
		if (type == 4)
		{
			return;
		}
		for (int i = 0; i < this.number; i++)
		{
			Point point = null;
			if (isStart)
			{
				point = new Point((MainScreen.cameraMain.xCam - GameCanvas.hw + CRes.random(GameCanvas.w * 2)) * 10, (MainScreen.cameraMain.yCam - GameCanvas.h * 2 + CRes.random(GameCanvas.h * 2)) * 10);
			}
			else
			{
				point = new Point();
				rndPos(point);
			}
			if (type == 2 || this.type == 3)
			{
				point.h = CRes.random(3);
			}
			else
			{
				point.h = CRes.random(4);
			}
			if (type == 5)
			{
				point.vx = CRes.random(2, 8);
				point.vy = CRes.random(2, 12);
			}
			point.limitY = 16 + CRes.random(3) * 4;
			point.v = CRes.random(-1, 1);
			point.color = CRes.random(point.limitY);
			point.frame = CRes.random(2);
			if (type == 2)
			{
				point.dis = (sbyte)CRes.random(6);
			}
			else if (type == 1)
			{
				point.dis = (sbyte)CRes.random(4);
			}
			else
			{
				point.dis = (sbyte)CRes.random(20);
			}
			list.addElement(point);
		}
	}

	public void close()
	{
	}

	public void stop()
	{
		isStop = true;
	}

	public new void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.translate(-MainScreen.cameraMain.xCam, -MainScreen.cameraMain.yCam);
		switch (type)
		{
		case 0:
			paintRain(g);
			break;
		case 1:
			paintFallingLeaves(g);
			break;
		case 3:
			paintFallingFlower(g);
			break;
		case 2:
			paintSnow(g);
			break;
		case 5:
			paintCloud(g);
			break;
		case 4:
			break;
		}
	}

	private void paintCloud(mGraphics g)
	{
		if (imgEffectCloud == null)
		{
			return;
		}
		for (int i = 0; i < list.size(); i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point.x / 10 > MainScreen.cameraMain.xCam - wimg / 2 && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w + wimg / 2 && point.y / 10 > MainScreen.cameraMain.yCam - himg / 2)
			{
				g.drawImage(imgEffectCloud[point.frame], point.x / 10, point.y / 10, 3, mGraphics.isFalse);
			}
		}
	}

	private void paintSnow(mGraphics g)
	{
		if (imgEffect == null)
		{
			return;
		}
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point.x / 10 > MainScreen.cameraMain.xCam && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w && point.y / 10 > MainScreen.cameraMain.yCam)
			{
				g.drawRegion(imgEffect, 0, 7 * point.dis, 7, 7, 0, point.x / 10, point.y / 10, 3, mGraphics.isFalse);
			}
		}
	}

	private void paintFallingFlower(mGraphics g)
	{
		int num = 0;
		if (imgEffect == null)
		{
			return;
		}
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point.x / 10 > MainScreen.cameraMain.xCam && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w && point.y / 10 > MainScreen.cameraMain.yCam)
			{
				num = 2 - point.h + 1;
				if (num < 2)
				{
					num = point.dis / 10;
				}
				g.drawRegion(imgEffect, 0, num * 10, 10, 10, 0, point.x / 10, point.y / 10, 3, mGraphics.isFalse);
				point.dis++;
				if (point.dis >= 20)
				{
					point.dis = 0;
				}
			}
		}
	}

	private void paintFallingLeaves(mGraphics g)
	{
		if (imgEffect == null)
		{
			return;
		}
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point.x / 10 > MainScreen.cameraMain.xCam && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w && point.y / 10 > MainScreen.cameraMain.yCam)
			{
				if (CRes.random(6) == 0)
				{
					point.dis = (byte)CRes.random(4);
				}
				g.drawRegion(imgEffect, 0, point.dis * 10, 16, 10, 0, point.x / 10, point.y / 10, 3, mGraphics.isFalse);
			}
		}
	}

	private void paintRain(mGraphics g)
	{
		g.setColor(14540253);
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point.x / 10 > MainScreen.cameraMain.xCam && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w && point.y / 10 > MainScreen.cameraMain.yCam)
			{
				g.fillRect(point.x / 10, point.y / 10, 1, point.h + 2, mGraphics.isFalse);
			}
		}
	}

	public static void updateWind()
	{
		int num = 1;
		if (GameCanvas.gameTick % 6 == 3)
		{
			num = CRes.random(15);
		}
		if (num == 0 && wind == 5)
		{
			wind = 5 + CRes.random(20);
			countWind = 50 + CRes.random(100);
		}
		if (countWind > 0)
		{
			countWind--;
		}
		if (countWind == 0 && wind > 5 && GameCanvas.gameTick % 4 == 2)
		{
			wind--;
		}
	}

	public new void update()
	{
		if (timeLimit > 0 && GameCanvas.timeNow / 1000 - curTime > timeLimit)
		{
			isStop = true;
		}
		switch (type)
		{
		case 0:
			updateRain();
			break;
		case 1:
			updateFallingLeaves();
			break;
		case 3:
			updateFlower();
			break;
		case 2:
			updateSnow();
			break;
		case 4:
			updateThienThach();
			break;
		case 5:
			updateCloud();
			break;
		}
	}

	private void updateCloud()
	{
		for (int i = 0; i < list.size(); i++)
		{
			Point point = (Point)list.elementAt(i);
			point.y += point.vy;
			point.x += point.vx * dirWind;
			if (point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw)
			{
				list.removeElement(point);
				i--;
			}
		}
		if (timeLimit > 0 && GameCanvas.timeNow / 1000 - curTime > timeLimit)
		{
			mSystem.outz("ooooooooooooooooooooooooooooo");
		}
		else if (!isStop && CRes.random(350) < numClound)
		{
			Point point2 = null;
			point2 = new Point();
			rndPos(point2);
			point2.h = CRes.random(4);
			point2.limitY = 16 + CRes.random(3) * 4;
			point2.v = CRes.random(-1, 1);
			point2.color = CRes.random(point2.limitY);
			point2.frame = CRes.random(2);
			point2.dis = (byte)CRes.random(20);
			point2.vx = CRes.random(2, 8);
			point2.vy = CRes.random(2, 12);
			list.addElement(point2);
		}
	}

	private void updateThienThach()
	{
		if (CRes.random(250) < number)
		{
			int num = CRes.random(1, 3);
			GameScreen.addEffectKill(86, 0, 0, 0, 0, (sbyte)num);
		}
	}

	private void updateSnow()
	{
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			point.y += (point.h + 4) * 3;
			point.x += (point.h + 1) * 2 + wind * dirWind;
			if ((point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) - (4 - point.h) * 50 || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw) && CRes.random(40) == 0)
			{
				rndPos(point);
			}
		}
	}

	private void updateFlower()
	{
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			point.y += (point.h + 2) * 5;
			point.x += (point.h + 1) * 2 + wind * dirWind;
			if (point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) - (4 - point.h) * 50 || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw)
			{
				rndPos(point);
			}
		}
	}

	private void updateFallingLeaves()
	{
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			point.y += 15;
			point.x += point.v * 10 + wind * dirWind;
			point.color++;
			if (point.color >= point.limitY)
			{
				point.color = 0;
			}
			if (point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) - (4 - point.h) * 50 || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw)
			{
				rndPos(point);
			}
		}
	}

	private void updateRain()
	{
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			point.y += (point.h + 1) * 15 + (3 - point.h) * 3;
			point.g++;
			point.x += (3 - point.h + 1) * 2 + wind * dirWind;
			if (point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) - (4 - point.h) * 50 || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw)
			{
				rndPos(point);
			}
		}
	}

	private void rndPos(Point pos)
	{
		if (isStop)
		{
			list.removeElement(pos);
			number = list.size();
			if (list.size() == 0)
			{
				close();
			}
			return;
		}
		if (type == 5)
		{
			pos.y = (MainScreen.cameraMain.yCam - GameCanvas.hh + CRes.random(GameCanvas.h / 2)) * 10;
			if (dirWind > 0)
			{
				pos.x = (MainScreen.cameraMain.xCam - GameCanvas.hw + CRes.random(GameCanvas.w)) * 10;
			}
			else
			{
				pos.x = (MainScreen.cameraMain.xCam + GameCanvas.hw + CRes.random(GameCanvas.w)) * 10;
			}
			pos.frame = CRes.random(2);
			pos.vx = CRes.random(2, 8);
			pos.vy = CRes.random(2, 12);
		}
		else
		{
			pos.y = (MainScreen.cameraMain.yCam - GameCanvas.hh + CRes.random(GameCanvas.h * 2)) * 10;
			pos.x = (MainScreen.cameraMain.xCam - GameCanvas.hw + CRes.random(GameCanvas.w * 2)) * 10;
		}
		if (type == 2 || type == 3)
		{
			pos.h = CRes.random(3);
		}
		else if (type == 0)
		{
			pos.h = CRes.random(1, 5);
		}
		else
		{
			pos.h = CRes.random(4);
		}
	}
}
