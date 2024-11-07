public class MainEffect
{
	public bool isPaint = true;

	public int typeEffect;

	public int valueEffect;

	public int timeRemove;

	public int x;

	public int y;

	public int toX;

	public int toY;

	public int f;

	public int frame;

	public int ysai;

	public int Direction;

	public int vMax;

	public int vx;

	public int vy;

	public int hOne;

	public int subf;

	public int fRemove;

	public int levelPaint;

	private long timeBegin;

	public MainObject objBeKillMain;

	public sbyte[] nFrame;

	public sbyte[] nSubFrame;

	public FrameImage fraImgEff;

	public FrameImage fraImgSubEff;

	public FrameImage fraImgSub2Eff;

	public FrameImage fraImgSub3Eff;

	public bool isRemove;

	public bool isStop;

	public virtual void paint(mGraphics g)
	{
	}

	public virtual void update()
	{
		x += vx;
		y += vy;
	}

	public void setPosition(int x, int y, int xto, int yto)
	{
		this.x = x;
		this.y = y;
		toX = xto;
		toY = yto;
	}

	public static bool isInScreen(int x, int y, int w, int h)
	{
		if (x < MainScreen.cameraMain.xCam - w || x > MainScreen.cameraMain.xCam + GameCanvas.w + w || y < MainScreen.cameraMain.yCam - h || y > MainScreen.cameraMain.yCam + GameCanvas.h + h)
		{
			return false;
		}
		return true;
	}

	public virtual void setObjFrom(short id, sbyte tem)
	{
	}

	public virtual void setTimeRemove(short time)
	{
	}
}
