public class Scroll
{
	private int x;

	private int y;

	private int h;

	private int color;

	private int yScroll;

	private int hScroll;

	public int cmtoX;

	public int cmtoY;

	public int cmx;

	public int cmy;

	public int cmvx;

	public int cmvy;

	public int cmdx;

	public int cmdy;

	public int xPos;

	public int yPos;

	public int width;

	public int height;

	public int cmxLim;

	public int cmyLim;

	public static Scroll me;

	private int pointerDownTime;

	private int pointerDownFirstX;

	public int[] pointerDownLastX = new int[3];

	public bool pointerIsDowning;

	public bool isDownWhenRunning;

	private int cmRun;

	public int selectedItem;

	public int ITEM_SIZE;

	public int nITEM;

	public int ITEM_PER_LINE;

	public bool styleUPDOWN = true;

	public bool FocusNew;

	public void clear()
	{
		cmtoX = 0;
		cmtoY = 0;
		cmx = 0;
		cmy = 0;
		cmvx = 0;
		cmvy = 0;
		cmdx = 0;
		cmdy = 0;
		cmxLim = 0;
		cmyLim = 0;
		width = 0;
		height = 0;
	}

	public void setClip(mGraphics g, int x, int y, int w, int h)
	{
		g.setClip(x, y, w, h - 1);
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.translate(-cmx, -cmy);
	}

	public void setClip(mGraphics g)
	{
		g.setClip(xPos + 1, yPos + 1, width - 2, height - 2);
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.translate(-cmx, -cmy);
	}

	public ScrollResult updateKey()
	{
		if (styleUPDOWN)
		{
			return updateKeyScrollUpDown();
		}
		return updateKeyScrollLeftRight();
	}

	private ScrollResult updateKeyScrollUpDown()
	{
		int num = xPos;
		int num2 = yPos;
		int w = width;
		int num3 = height;
		if (GameCanvas.isPointerDown)
		{
			if (!pointerIsDowning && GameCanvas.isPointer(num, num2, w, num3))
			{
				for (int i = 0; i < pointerDownLastX.Length; i++)
				{
					pointerDownLastX[0] = GameCanvas.py;
				}
				pointerDownFirstX = GameCanvas.py;
				pointerIsDowning = true;
				selectedItem = -1;
				isDownWhenRunning = cmRun != 0;
				cmRun = 0;
			}
			else if (pointerIsDowning)
			{
				pointerDownTime++;
				if (pointerDownTime > 5 && pointerDownFirstX == GameCanvas.py && !isDownWhenRunning)
				{
					pointerDownFirstX = -1000;
					if (ITEM_PER_LINE > 1)
					{
						int num4 = (cmtoY + GameCanvas.py - num2) / ITEM_SIZE;
						int num5 = (cmtoX + GameCanvas.px - num) / ITEM_SIZE;
						selectedItem = num4 * ITEM_PER_LINE + num5;
					}
					else
					{
						selectedItem = (cmtoY + GameCanvas.py - num2) / ITEM_SIZE;
					}
				}
				int num6 = GameCanvas.py - pointerDownLastX[0];
				if (num6 != 0 && selectedItem != -1)
				{
					selectedItem = -1;
				}
				for (int num7 = pointerDownLastX.Length - 1; num7 > 0; num7--)
				{
					pointerDownLastX[num7] = pointerDownLastX[num7 - 1];
				}
				pointerDownLastX[0] = GameCanvas.py;
				cmtoY -= num6;
				if (cmtoY < 0)
				{
					cmtoY = 0;
				}
				if (cmtoY > cmyLim)
				{
					cmtoY = cmyLim;
				}
				if (cmy < 0 || cmy > cmyLim)
				{
					num6 /= 2;
				}
				cmy -= num6;
			}
		}
		bool isFinish = false;
		if (GameCanvas.isPointerRelease && pointerIsDowning)
		{
			int i2 = GameCanvas.py - pointerDownLastX[0];
			GameCanvas.isPointerRelease = false;
			if (Math.abs(i2) < 20 && Math.abs(GameCanvas.py - pointerDownFirstX) < 20 && !isDownWhenRunning)
			{
				cmRun = 0;
				cmtoY = cmy;
				pointerDownFirstX = -1000;
				if (ITEM_PER_LINE > 1)
				{
					int num8 = (cmtoY + GameCanvas.py - num2) / ITEM_SIZE;
					int num9 = (cmtoX + GameCanvas.px - num) / ITEM_SIZE;
					selectedItem = num8 * ITEM_PER_LINE + num9;
				}
				else
				{
					selectedItem = (cmtoY + GameCanvas.py - num2) / ITEM_SIZE;
				}
				pointerDownTime = 0;
				isFinish = true;
			}
			else if (selectedItem != -1 && pointerDownTime > 5)
			{
				pointerDownTime = 0;
				isFinish = true;
			}
			else if (selectedItem == -1 && !isDownWhenRunning)
			{
				if (cmy < 0)
				{
					cmtoY = 0;
				}
				else if (cmy > cmyLim)
				{
					cmtoY = cmyLim;
				}
				else
				{
					int num10 = GameCanvas.py - pointerDownLastX[0] + (pointerDownLastX[0] - pointerDownLastX[1]) + (pointerDownLastX[1] - pointerDownLastX[2]);
					num10 = ((num10 > 10) ? 10 : ((num10 < -10) ? (-10) : 0));
					cmRun = -num10 * 100;
				}
			}
			pointerIsDowning = false;
			pointerDownTime = 0;
			GameCanvas.isPointerRelease = false;
		}
		ScrollResult scrollResult = new ScrollResult();
		scrollResult.selected = selectedItem;
		scrollResult.isFinish = isFinish;
		scrollResult.isDowning = pointerIsDowning;
		return scrollResult;
	}

	private ScrollResult updateKeyScrollLeftRight()
	{
		int num = xPos;
		int num2 = yPos;
		int w = width;
		int num3 = height;
		if (GameCanvas.isPointerDown)
		{
			if (!pointerIsDowning && GameCanvas.isPointer(num, num2, w, num3))
			{
				for (int i = 0; i < pointerDownLastX.Length; i++)
				{
					pointerDownLastX[0] = GameCanvas.px;
				}
				pointerDownFirstX = GameCanvas.px;
				pointerIsDowning = true;
				selectedItem = -1;
				isDownWhenRunning = cmRun != 0;
				cmRun = 0;
			}
			else if (pointerIsDowning)
			{
				pointerDownTime++;
				if (pointerDownTime > 5 && pointerDownFirstX == GameCanvas.px && !isDownWhenRunning)
				{
					pointerDownFirstX = -1000;
					selectedItem = (cmtoX + GameCanvas.px - num) / ITEM_SIZE;
				}
				int num4 = GameCanvas.px - pointerDownLastX[0];
				if (num4 != 0 && selectedItem != -1)
				{
					selectedItem = -1;
				}
				for (int num5 = pointerDownLastX.Length - 1; num5 > 0; num5--)
				{
					pointerDownLastX[num5] = pointerDownLastX[num5 - 1];
				}
				pointerDownLastX[0] = GameCanvas.px;
				cmtoX -= num4;
				if (cmtoX < 0)
				{
					cmtoX = 0;
				}
				if (cmtoX > cmxLim)
				{
					cmtoX = cmxLim;
				}
				if (cmx < 0 || cmx > cmxLim)
				{
					num4 /= 2;
				}
				cmx -= num4;
			}
		}
		bool isFinish = false;
		if (GameCanvas.isPointerRelease && pointerIsDowning)
		{
			int i2 = GameCanvas.px - pointerDownLastX[0];
			GameCanvas.isPointerRelease = false;
			if (Math.abs(i2) < 20 && Math.abs(GameCanvas.px - pointerDownFirstX) < 20 && !isDownWhenRunning)
			{
				cmRun = 0;
				cmtoX = cmx;
				pointerDownFirstX = -1000;
				selectedItem = (cmtoX + GameCanvas.px - num) / ITEM_SIZE;
				pointerDownTime = 0;
				isFinish = true;
			}
			else if (selectedItem != -1 && pointerDownTime > 5)
			{
				pointerDownTime = 0;
				isFinish = true;
			}
			else if (selectedItem == -1 && !isDownWhenRunning)
			{
				if (cmx < 0)
				{
					cmtoX = 0;
				}
				else if (cmx > cmxLim)
				{
					cmtoX = cmxLim;
				}
				else
				{
					int num6 = GameCanvas.px - pointerDownLastX[0] + (pointerDownLastX[0] - pointerDownLastX[1]) + (pointerDownLastX[1] - pointerDownLastX[2]);
					num6 = ((num6 > 10) ? 10 : ((num6 < -10) ? (-10) : 0));
					cmRun = -num6 * 100;
				}
			}
			pointerIsDowning = false;
			pointerDownTime = 0;
			GameCanvas.isPointerRelease = false;
		}
		ScrollResult scrollResult = new ScrollResult();
		scrollResult.selected = selectedItem;
		scrollResult.isFinish = isFinish;
		scrollResult.isDowning = pointerIsDowning;
		return scrollResult;
	}

	public void updatecm()
	{
		int num = xPos;
		int num2 = yPos;
		int w = width;
		int num3 = height;
		if (GameCanvas.isPointer(num, num2, w, num3) && GameCanvas.isTouch && !FocusNew)
		{
			FocusNew = true;
		}
		if (cmRun != 0 && !pointerIsDowning)
		{
			if (styleUPDOWN)
			{
				cmtoY += cmRun / 100;
				if (cmtoY < 0)
				{
					cmtoY = 0;
				}
				else if (cmtoY > cmyLim)
				{
					cmtoY = cmyLim;
				}
				else
				{
					cmy = cmtoY;
				}
			}
			else
			{
				cmtoX += cmRun / 100;
				if (cmtoX < 0)
				{
					cmtoX = 0;
				}
				else if (cmtoX > cmxLim)
				{
					cmtoX = cmxLim;
				}
				else
				{
					cmx = cmtoX;
				}
			}
			cmRun = cmRun * 9 / 10;
			if (cmRun < 100 && cmRun > -100)
			{
				cmRun = 0;
			}
		}
		if (cmx != cmtoX && !pointerIsDowning)
		{
			cmvx = cmtoX - cmx << 2;
			cmdx += cmvx;
			cmx += cmdx >> 4;
			cmdx &= 15;
		}
		if (cmy != cmtoY && !pointerIsDowning)
		{
			cmvy = cmtoY - cmy << 2;
			cmdy += cmvy;
			cmy += cmdy >> 4;
			cmdy &= 15;
		}
	}

	public void setStyle(int nItem, int ITEM_SIZE, int xPos, int yPos, int width, int height, bool styleUPDOWN, int ITEM_PER_LINE)
	{
		this.xPos = xPos;
		this.yPos = yPos;
		this.ITEM_SIZE = ITEM_SIZE;
		nITEM = nItem;
		this.width = width;
		this.height = height;
		this.styleUPDOWN = styleUPDOWN;
		this.ITEM_PER_LINE = ITEM_PER_LINE;
		if (styleUPDOWN)
		{
			cmyLim = nItem * ITEM_SIZE - height;
		}
		else
		{
			cmxLim = nItem * ITEM_SIZE - width;
		}
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
		if (cmxLim < 0)
		{
			cmxLim = 0;
		}
	}

	public void moveTo(int to)
	{
		if (styleUPDOWN)
		{
			to -= (height - ITEM_SIZE * 2) / 2;
			cmtoY = to;
			if (cmtoY < 0)
			{
				cmtoY = 0;
			}
			if (cmtoY > cmyLim)
			{
				cmtoY = cmyLim;
			}
		}
		else
		{
			to -= (width - ITEM_SIZE) / 2;
			cmtoX = to;
			if (cmtoX < 0)
			{
				cmtoX = 0;
			}
			if (cmtoX > cmxLim)
			{
				cmtoX = cmxLim;
			}
		}
	}

	public void moveCmrTo(int to)
	{
		if (to > 0)
		{
			cmtoY += ITEM_SIZE;
		}
		else if (to < 0)
		{
			cmtoY -= 20;
		}
		if (cmtoY < 0)
		{
			cmtoY = 0;
		}
		if (cmtoY > cmyLim)
		{
			cmtoY = cmyLim;
		}
	}

	public static Scroll gI()
	{
		if (me == null)
		{
			me = new Scroll();
		}
		return me;
	}

	public void setInfo(int x, int y, int h, int color)
	{
		this.x = x;
		this.y = y;
		this.h = h;
		this.color = color;
		hScroll = h - MainTabNew.wOneItem;
	}

	public void paint(mGraphics g)
	{
		g.setColor(color);
		g.fillRect(x - 2, y - 1, 3, 1, mGraphics.isTrue);
		g.fillRect(x - 3, y, 1, h - 1, mGraphics.isTrue);
		g.fillRect(x + 1, y, 1, h - 1, mGraphics.isTrue);
		g.fillRect(x - 2, y + h - 1, 3, 1, mGraphics.isTrue);
		g.fillRect(x - 2, y + yScroll, 3, MainTabNew.wOneItem, mGraphics.isTrue);
	}

	public void setYScrool(int yS, int yMax)
	{
		yScroll = yS * hScroll / yMax;
	}
}
