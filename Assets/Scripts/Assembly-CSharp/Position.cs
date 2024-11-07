public class Position
{
	public int x;

	public int y;

	public int anchor;

	public sbyte depth;

	public short index = -1;

	public Position()
	{
		x = 0;
		y = 0;
	}

	public Position(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public Position(int x, int y, int anchor)
	{
		this.x = x;
		this.y = y;
		this.anchor = anchor;
	}

	public bool setDetectX(int xx, int num)
	{
		if (CRes.abs(xx - x) <= num)
		{
			return true;
		}
		return false;
	}

	public bool setDetectY(int yy, int num)
	{
		if (CRes.abs(yy - y) <= num)
		{
			return true;
		}
		return false;
	}
}
