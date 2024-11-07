public class Camera
{
	public static Camera instance;

	public int xCam;

	public int yCam;

	public int xTo;

	public int yTo;

	public int xLimit;

	public int yLimit;

	public long timeDelay;

	private int cmvx;

	private int cmdx;

	private int cmvy;

	private int cmdy;

	public void setAll(int xLimit, int yLimit, int xCam, int yCam)
	{
		this.xLimit = xLimit;
		this.yLimit = yLimit;
		if (this.yLimit < 0)
		{
			this.yLimit = 0;
		}
		if (this.xLimit < 0)
		{
			this.xLimit = 0;
		}
		if (xCam > xLimit)
		{
			xCam = xLimit;
		}
		if (xCam < 0)
		{
			xCam = 0;
		}
		if (yCam > yLimit)
		{
			yCam = yLimit;
		}
		if (yCam < 0)
		{
			yCam = 0;
		}
		this.xCam = xCam;
		this.yCam = yCam;
		xTo = xCam;
		yTo = yCam;
	}

	public void setAllTo(int xLimit, int yLimit, int xCam, int yCam)
	{
		this.xLimit = xLimit;
		this.yLimit = yLimit;
		if (this.yLimit < 0)
		{
			this.yLimit = 0;
		}
		if (this.xLimit < 0)
		{
			this.xLimit = 0;
		}
		xTo = xCam;
		yTo = yCam;
	}

	public void setCamera(int xCam, int yCam)
	{
		this.xCam = xCam;
		this.yCam = yCam;
		xTo = xCam;
		yTo = yCam;
	}

	public void setCameraWithLim(int xCam, int yCam)
	{
		if (xCam < 0)
		{
			xCam = 0;
		}
		if (xCam > xLimit)
		{
			xCam = xLimit;
		}
		if (yCam < 0)
		{
			yCam = 0;
		}
		if (yCam > yLimit)
		{
			yCam = yLimit;
		}
		this.xCam = xCam;
		this.yCam = yCam;
		xTo = xCam;
		yTo = yCam;
	}

	public void moveCamera(int xTo, int yTo)
	{
		this.xTo = xTo;
		this.yTo = yTo;
	}

	public void UpdateCamera()
	{
		if (GameScreen.player.useShip)
		{
			if (GameCanvas.loadmap.idMap != 19 || yCam == 0)
			{
				return;
			}
			yTo = 0;
		}
		if (xCam != xTo)
		{
			cmvx = xTo - xCam << 1;
			cmdx += cmvx;
			xCam += cmdx >> 4;
			cmdx &= 15;
			if (xCam < 0)
			{
				xCam = 0;
			}
			if (xCam > xLimit)
			{
				xCam = xLimit;
			}
		}
		if (yCam != yTo)
		{
			cmvy = yTo - yCam << 1;
			cmdy += cmvy;
			yCam += cmdy >> 4;
			cmdy &= 15;
			if (yCam < 0)
			{
				yCam = 0;
			}
			if (yCam > yLimit)
			{
				yCam = yLimit;
			}
		}
	}

	public void UpdateCameraCreate()
	{
		if (xCam != xTo)
		{
			cmvx = xTo - xCam << 1;
			cmdx += cmvx;
			xCam += cmdx >> 4;
			cmdx &= 15;
		}
		if (yCam != yTo)
		{
			cmvy = yTo - yCam << 1;
			cmdy += cmvy;
			yCam += cmdy >> 4;
			cmdy &= 15;
			if (yCam < 0)
			{
				yCam = 0;
			}
			if (yCam > yLimit)
			{
				yCam = yLimit;
			}
		}
	}
}
