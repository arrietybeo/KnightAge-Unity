public class Mount : MainObject
{
	public static sbyte[][] Dir = new sbyte[4][]
	{
		new sbyte[12]
		{
			5, 5, 5, 5, 5, 5, 6, 6, 6, 6,
			6, 6
		},
		new sbyte[12]
		{
			0, 0, 0, 0, 0, 0, 1, 1, 1, 1,
			1, 1
		},
		new sbyte[12]
		{
			0, 0, 0, 0, 0, 0, 1, 1, 1, 1,
			1, 1
		},
		new sbyte[12]
		{
			0, 0, 0, 0, 0, 0, 1, 1, 1, 1,
			1, 1
		}
	};

	public Mount(sbyte type, sbyte dir, int x, int y)
	{
		typeMount = type;
		base.x = x;
		base.y = y;
		Direction = dir;
		Action = 0;
		typeObject = 10;
	}

	public new void updateMount()
	{
		frameMount++;
		if (frameMount > Dir[Direction].Length - 1)
		{
			frameMount = 0;
		}
	}

	public override void paint(mGraphics g)
	{
		if (typeMount != -1)
		{
			FrameImage frameImageMount = FrameImage.getFrameImageMount(typeMount, 3, 5, 0);
			if (frameImageMount != null)
			{
				g.drawImage(MainObject.shadow, x, y - 8, 3, mGraphics.isFalse);
				frameImageMount.drawFrameNew(Dir[Direction][frameMount], x + xMount, y - ysai - dy + yMount, (Direction > 2) ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
		}
	}
}
