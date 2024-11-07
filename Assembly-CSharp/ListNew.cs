public class ListNew
{
	public int maxW;

	public int itemH;

	public int maxH;

	public int maxSize;

	public int x;

	public int y;

	public int value;

	public int cmtoX;

	public int cmx;

	public int cmdy;

	public int cmvy;

	public int cmxLim;

	private int pointerDownTime;

	private int pointerDownFirstX;

	private int[] pointerDownLastX = new int[3];

	private bool pointerIsDowning;

	private bool isDownWhenRunning;

	private int cmRun;

	private mVector vecCmd;

	private iCommand cmdCenter;

	public int w;

	private int pa;

	private bool trans;

	private int cmvx;

	private int cmdx;

	public ListNew(int x, int y, int maxW, int maxH, int itemH, int maxSize, int limX)
	{
		this.x = x;
		this.y = y;
		this.maxW = maxW;
		this.maxH = maxH;
		this.itemH = itemH;
		this.maxSize = maxSize;
		cmxLim = limX;
	}

	public void updateMenuKey()
	{
		bool flag = false;
		if (GameCanvas.keyMyPressed[2])
		{
			flag = true;
			value--;
			if (value < 0)
			{
				value = maxSize - 1;
			}
			GameCanvas.clearKeyPressed(2);
			GameCanvas.clearKeyPressed(4);
		}
		else if (GameCanvas.keyMyPressed[8])
		{
			flag = true;
			value++;
			if (value > maxSize - 1)
			{
				value = maxSize - 1;
			}
			GameCanvas.clearKeyPressed(6);
			GameCanvas.clearKeyPressed(8);
		}
		if (flag)
		{
			cmtoX = (value + 1) * itemH - maxH / 2;
			if (cmtoX > cmxLim)
			{
				cmtoX = cmxLim;
			}
			if (cmtoX < 0)
			{
				cmtoX = 0;
			}
			if (value == maxSize - 1 || value == 0)
			{
				cmx = cmtoX;
			}
		}
		update_Pos_UP_DOWN();
	}

	public void update_Pos_UP_DOWN()
	{
		if (GameCanvas.isPointerDown)
		{
			if (!pointerIsDowning && GameCanvas.isPointer(x, y, maxW, maxH))
			{
				for (int i = 0; i < pointerDownLastX.Length; i++)
				{
					pointerDownLastX[0] = GameCanvas.py;
				}
				pointerDownFirstX = GameCanvas.py;
				pointerIsDowning = true;
				isDownWhenRunning = cmRun != 0;
				cmRun = 0;
			}
			else if (pointerIsDowning)
			{
				pointerDownTime++;
				if (pointerDownTime > 5 && pointerDownFirstX == GameCanvas.py && !isDownWhenRunning)
				{
					pointerDownFirstX = -1000;
				}
				int num = GameCanvas.py - pointerDownLastX[0];
				if (num != 0 && value != -1)
				{
					value = -1;
				}
				for (int num2 = pointerDownLastX.Length - 1; num2 > 0; num2--)
				{
					pointerDownLastX[num2] = pointerDownLastX[num2 - 1];
				}
				pointerDownLastX[0] = GameCanvas.py;
				cmtoX -= num;
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
					num /= 2;
				}
				cmx -= num;
			}
		}
		if (!GameCanvas.isPointerClick || !pointerIsDowning)
		{
			return;
		}
		int a = GameCanvas.py - pointerDownLastX[0];
		GameCanvas.isPointerClick = false;
		if (CRes.abs(a) < 20 && CRes.abs(GameCanvas.py - pointerDownFirstX) < 20 && !isDownWhenRunning)
		{
			cmRun = 0;
			cmtoX = cmx;
			pointerDownFirstX = -1000;
			pointerDownTime = 0;
		}
		else if (value != -1 && pointerDownTime > 5)
		{
			pointerDownTime = 0;
		}
		else if (value == -1 && !isDownWhenRunning)
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
				int num3 = GameCanvas.py - pointerDownLastX[0] + (pointerDownLastX[0] - pointerDownLastX[1]) + (pointerDownLastX[1] - pointerDownLastX[2]);
				num3 = ((num3 > 10) ? 10 : ((num3 < -10) ? (-10) : 0));
				cmRun = -num3 * 100;
			}
		}
		pointerIsDowning = false;
		pointerDownTime = 0;
		GameCanvas.isPointerClick = false;
	}

	public void updatePos_LEFT_RIGHT()
	{
		if (GameCanvas.isPointerDown)
		{
			if (!pointerIsDowning && GameCanvas.isPointer(x, y, maxW, maxH))
			{
				for (int i = 0; i < pointerDownLastX.Length; i++)
				{
					pointerDownLastX[0] = GameCanvas.px;
				}
				pointerDownFirstX = GameCanvas.px;
				pointerIsDowning = true;
				isDownWhenRunning = cmRun != 0;
				cmRun = 0;
			}
			else if (pointerIsDowning)
			{
				pointerDownTime++;
				if (pointerDownTime > 5 && pointerDownFirstX == GameCanvas.px && !isDownWhenRunning)
				{
					pointerDownFirstX = -1000;
				}
				int num = GameCanvas.px - pointerDownLastX[0];
				if (num != 0 && value != -1)
				{
					value = -1;
				}
				for (int num2 = pointerDownLastX.Length - 1; num2 > 0; num2--)
				{
					pointerDownLastX[num2] = pointerDownLastX[num2 - 1];
				}
				pointerDownLastX[0] = GameCanvas.px;
				cmtoX -= num;
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
					num /= 2;
				}
				cmx -= num;
			}
		}
		if (!GameCanvas.isPointerClick || !pointerIsDowning)
		{
			return;
		}
		int a = GameCanvas.px - pointerDownLastX[0];
		GameCanvas.isPointerClick = false;
		if (CRes.abs(a) < 20 && CRes.abs(GameCanvas.px - pointerDownFirstX) < 20 && !isDownWhenRunning)
		{
			cmRun = 0;
			cmtoX = cmx;
			pointerDownFirstX = -1000;
			pointerDownTime = 0;
		}
		else if (value != -1 && pointerDownTime > 5)
		{
			pointerDownTime = 0;
		}
		else if (value == -1 && !isDownWhenRunning)
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
				int num3 = GameCanvas.px - pointerDownLastX[0] + (pointerDownLastX[0] - pointerDownLastX[1]) + (pointerDownLastX[1] - pointerDownLastX[2]);
				num3 = ((num3 > 10) ? 10 : ((num3 < -10) ? (-10) : 0));
				cmRun = -num3 * 100;
			}
		}
		pointerIsDowning = false;
		pointerDownTime = 0;
		GameCanvas.isPointerClick = false;
	}

	public void moveCamera()
	{
		if (cmRun != 0 && !pointerIsDowning)
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
	}

	public void updateMenu()
	{
		moveCamera();
		updateMenuKey();
	}
}
