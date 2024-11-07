public class Arrow : IArrow
{
	public static int[] ARROWINDEX = new int[18]
	{
		0, 15, 37, 52, 75, 105, 127, 142, 165, 195,
		217, 232, 255, 285, 307, 322, 345, 370
	};

	public int power;

	public int effect;

	public int typeEffEnd = -1;

	private MainObject target;

	private int[] xw;

	private int[] yw;

	private int frame;

	private int transform;

	private int pos;

	private FrameImage img;

	public static int[] TRANSFORM = new int[16]
	{
		0, 0, 0, 7, 6, 6, 6, 2, 2, 3,
		3, 4, 5, 5, 5, 1
	};

	public static sbyte[] FRAME = new sbyte[25]
	{
		0, 1, 2, 1, 0, 1, 2, 1, 0, 1,
		2, 1, 0, 1, 2, 1, 0, 1, 2, 1,
		0, 1, 2, 1, 0
	};

	private short endeff;

	public Arrow(int imgIndex)
	{
	}

	public Arrow()
	{
	}

	public override void setAngle(int angle)
	{
	}

	public override void onArrowTouchTarget()
	{
		wantDestroy = true;
	}

	public override void paint(mGraphics g)
	{
		if (img != null)
		{
			img.drawFrameEffectSkill(frame, xw[pos], yw[pos], transform, 3, g);
		}
	}

	public override void set(int type, int x, int y, int power, short effect, MainObject owner, MainObject target)
	{
	}

	public void set(int type, int x, int y, int power, short effect, MainObject owner, MainObject target, int idend)
	{
		this.effect = idend;
		this.effect = effect;
		this.target = target;
		this.power = power;
		int num = 0;
		int num2 = 0;
		num = target.x - x;
		num2 = target.y + target.getDy() - y;
		switch (type)
		{
		case 7:
			num = target.x + 10 - x;
			num2 = target.y + target.getDy() - y;
			break;
		case 8:
			num = target.x - 10 - x;
			num2 = target.y - 10 + target.getDy() - y;
			break;
		}
		int num3 = (Math.abs(num) + Math.abs(num2)) / 20;
		if (num3 < 2)
		{
			num3 = 2;
		}
		xw = new int[num3];
		yw = new int[num3];
		for (int i = 1; i < num3; i++)
		{
			xw[i] = x + i * num / num3;
			yw[i] = y + i * num2 / num3;
		}
		int num4 = findDirIndexFromAngle(CRes.angle(num, -num2));
		frame = FRAME[num4];
		transform = TRANSFORM[num4];
	}

	public static int findDirIndexFromAngle(int angle)
	{
		for (int i = 0; i < ARROWINDEX.Length - 1; i++)
		{
			if (angle >= ARROWINDEX[i] && angle <= ARROWINDEX[i + 1])
			{
				if (i >= 16)
				{
					return 0;
				}
				return i;
			}
		}
		return 0;
	}

	public override void update()
	{
		pos++;
		if (pos >= xw.Length)
		{
			pos = xw.Length;
		}
		if (pos == xw.Length)
		{
			onArrowTouchTarget();
		}
	}

	public override void SetEffFollow(int id)
	{
	}
}
