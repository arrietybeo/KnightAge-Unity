public class Point_Focus
{
	public bool isSpeedUp;

	public int x;

	public int y;

	public int dis;

	public int fRe;

	public int f;

	public int frame;

	public int vx;

	public int vy;

	public int toX;

	public int toY;

	public int maxdis;

	private int goc;

	public Point_Focus(int x, int y, int toX, int toY, int maxdis)
	{
		this.x = x;
		this.y = y;
		this.toX = toX;
		this.toY = toY;
		this.maxdis = maxdis;
	}

	public Point_Focus()
	{
	}

	public void createNormal()
	{
		vx = CRes.random_Am(0, 5);
		vy = CRes.random_Am(0, 5);
	}

	public bool update()
	{
		if (x < toX)
		{
			if (vx < 4)
			{
				vx++;
			}
		}
		else if (vx > -4)
		{
			vx--;
		}
		if (y < toY)
		{
			if (vy < 4)
			{
				vy++;
			}
		}
		else if (vy > -4)
		{
			vy--;
		}
		int a = toX - x;
		int a2 = toY - y;
		if (CRes.abs(a) < maxdis && CRes.abs(a2) < maxdis)
		{
			vx = 0;
			vy = 0;
			return true;
		}
		x += vx;
		y += vy;
		return false;
	}

	public void update_Vx_Vy()
	{
		f++;
		x += vx;
		y += vy;
	}
}
