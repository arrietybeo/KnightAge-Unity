using UnityEngine;
public class TemCanvas
{
	public static TemCanvas instance;

	public static GameCanvas gamecanvas;

	public static TemGraphics tem = new TemGraphics();

	public static int wMain;

	public static int hMain;

	public static mVector listPoint;

	public TemCanvas()
	{
		instance = this;
		hMain = getHeight();
		wMain = getWidth();
		checkZoomLevel(wMain, hMain);
		GameCanvas.isTouch = true;
		gamecanvas = new GameCanvas();
	}

	private int getWidth()
	{
		return (int)ScaleGUI.WIDTH;
	}

	private int getHeight()
	{
		return (int)ScaleGUI.HEIGHT;
	}

	private void checkZoomLevel(int w, int h)
	{
		Debug.LogError("w: " + w + "h: " + h);
		if (Main.isWindowsPhone)
		{
			mGraphics.zoomLevel = 2;
			if (w * h >= 2073600)
			{
				mGraphics.zoomLevel = 4;
			}
			else if (w * h > 384000)
			{
				mGraphics.zoomLevel = 3;
			}
		}
		else if (!Main.isPC)
		{
			if (w * h >= 2073600)
			{
				mGraphics.zoomLevel = 4;
			}
			else if (w * h >= 691200)
			{
				mGraphics.zoomLevel = 3;
			}
			else if (w * h > 153600)
			{
				mGraphics.zoomLevel = 3;
			}
		}
		else
		{
			mGraphics.zoomLevel = 2;
			if (w * h < 480000)
			{
				mGraphics.zoomLevel = 1;
			}
			Main.main.doClearRMS();
		}
		wMain = (wMain + mGraphics.zoomLevel - 1) / mGraphics.zoomLevel;
		hMain = (hMain + mGraphics.zoomLevel - 1) / mGraphics.zoomLevel;
	}

	public void start()
	{
	}

	public void paint(mGraphics gx)
	{
		if (tem.g == null)
		{
			tem.g = gx;
		}
		gamecanvas.paint(tem);
	}

	public void update()
	{
		gamecanvas.update();
		GameCanvas.timeNow = mSystem.currentTimeMillis();
	}

	public void keyPressed(int keyCode)
	{
		gamecanvas.keyPressed(keyCode);
	}

	public void keyReleased(int keyCode)
	{
		gamecanvas.keyReleased(keyCode);
	}

	public void pointerDragged(int x, int y)
	{
		gamecanvas.pointerDragged(x, y);
	}

	public void pointerPressed(int x, int y)
	{
		gamecanvas.pointerPressed(x, y);
	}

	public void pointerReleased(int x, int y)
	{
		gamecanvas.pointerReleased(x, y);
	}

	public int getWidthz()
	{
		int width = getWidth();
		return width / mGraphics.zoomLevel + width % mGraphics.zoomLevel;
	}

	public int getHeightz()
	{
		int height = getHeight();
		return height / mGraphics.zoomLevel + height % mGraphics.zoomLevel;
	}
}
