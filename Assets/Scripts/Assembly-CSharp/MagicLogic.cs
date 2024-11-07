public class MagicLogic
{
	public int angle;

	public int vx;

	public int vy;

	public short va;

	public int x;

	public int y;

	public int z;

	public int index;

	public MainObject target;

	private int life;

	public bool isSpeedUp;

	public int headArrowFrame;

	public int headTransform;

	public static short[] SPEED = new short[8] { 1, 60, 8, 1, 1, 16, 60, 18 };

	public bool isEnd;

	public void setAngle(int angle)
	{
		this.angle = angle;
		vx = va * CRes.cos(angle) >> 10;
		vy = va * CRes.sin(angle) >> 10;
	}

	public void set(int type, int x, int y, int dir, MainObject target)
	{
		this.x = x;
		this.y = y;
		this.target = target;
		switch (dir)
		{
		case 0:
			angle = 90;
			break;
		case 1:
			angle = 270;
			break;
		case 2:
			angle = 180;
			break;
		case 3:
			angle = 0;
			break;
		}
		if (type == 20)
		{
			type = 2;
		}
		va = 15360;
		z = 0;
		life = 0;
		vx = va * CRes.cos(angle) >> 10;
		vy = va * CRes.sin(angle) >> 10;
	}

	public void updateAngle()
	{
		if (target == null)
		{
			isEnd = true;
			return;
		}
		int num = target.x - x;
		int num2 = target.y - (target.hOne >> 1) - y;
		life++;
		if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || life > 60)
		{
			isEnd = true;
			return;
		}
		int num3 = CRes.angle(num, num2);
		if (Math.abs(num3 - angle) < 90 || num * num + num2 * num2 > 4096)
		{
			if (Math.abs(num3 - angle) < 15)
			{
				angle = num3;
			}
			else if ((num3 - angle >= 0 && num3 - angle < 180) || num3 - angle < -180)
			{
				angle = CRes.fixangle(angle + 15);
			}
			else
			{
				angle = CRes.fixangle(angle - 15);
			}
		}
		if (!isSpeedUp && va < 8192)
		{
			va += 1024;
		}
		vx = va * CRes.cos(angle) >> 10;
		vy = va * CRes.sin(angle) >> 10;
		num += vx;
		int num4 = num >> 10;
		x += num4;
		num &= 0x3FF;
		num2 += vy;
		int num5 = num2 >> 10;
		y += num5;
		num2 &= 0x3FF;
		index = Arrow.findDirIndexFromAngle(CRes.angle(num4, -num5));
		headArrowFrame = Arrow.FRAME[index];
		headTransform = Arrow.TRANSFORM[index];
	}
}
