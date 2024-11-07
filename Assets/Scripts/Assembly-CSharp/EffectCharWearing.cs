public class EffectCharWearing
{
	public const sbyte TYPE_HAT_WEARING = 0;

	public const sbyte TYPE_ARMOR_WEARING = 1;

	public const sbyte TYPE_TROUSERS_WEARING = 2;

	private sbyte f;

	private sbyte f1;

	private sbyte FrameEffect;

	private sbyte FrameEffect1;

	public int idImage;

	public sbyte type;

	private int frameWidth;

	private int frameHeight;

	private long timepaint;

	private int timerepaint;

	private int dx;

	private int dy;

	public static sbyte[][] Frame = new sbyte[3][]
	{
		new sbyte[29]
		{
			0, 1, 2, 3, 4, 3, 2, 1, 0, 1,
			2, 3, 4, 3, 2, 1, 0, 1, 2, 3,
			4, 3, 2, 1, 0, 1, 2, 3, 4
		},
		new sbyte[24]
		{
			0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
			3, 3, 0, 0, 0, 1, 1, 1, 2, 2,
			2, 3, 3, 3
		},
		new sbyte[20]
		{
			0, 0, 1, 1, 2, 2, 1, 3, 3, 3,
			0, 0, 1, 1, 2, 2, 1, 3, 3, 3
		}
	};

	private int pospaint;

	public EffectCharWearing(sbyte type, int idimage)
	{
		this.type = type;
		idImage = idimage;
		timepaint = mSystem.currentTimeMillis();
		switch (this.type)
		{
		case 0:
			dx = 5;
			dy = -25;
			timerepaint = 1;
			break;
		case 1:
			dx = 0;
			dy = -12;
			timerepaint = 2;
			break;
		case 2:
			dx = 5;
			dy = 0;
			timerepaint = 3;
			break;
		}
	}

	public void paint(mGraphics g, int x, int y)
	{
		mImage mImage2 = ImageEffect.setImage(idImage);
		if (mImage2 == null || mImage2.image == null)
		{
			return;
		}
		if (frameWidth == 0 || frameHeight == 0)
		{
			frameWidth = EffectSkill.arrInfoEff[idImage][0];
			frameHeight = EffectSkill.arrInfoEff[idImage][1];
		}
		if (timepaint - mSystem.currentTimeMillis() >= 0)
		{
			return;
		}
		switch (type)
		{
		case 0:
			if (pospaint == 0)
			{
				g.drawRegion(mImage2, 0, FrameEffect * frameHeight, frameWidth, frameHeight, 0, x + dx, y + dy, 3, useClip: false);
			}
			else
			{
				g.drawRegion(mImage2, 0, FrameEffect1 * frameHeight, frameWidth, frameHeight, 0, x - dx, y + dy, 3, useClip: false);
			}
			break;
		case 1:
			g.drawRegion(mImage2, 0, FrameEffect * frameHeight, frameWidth, frameHeight, 0, x + dx, y + dy, 3, useClip: false);
			break;
		case 2:
			g.drawRegion(mImage2, 0, FrameEffect * frameHeight, frameWidth, frameHeight, 0, x + dx, y + dy, 3, useClip: false);
			g.drawRegion(mImage2, 0, FrameEffect1 * frameHeight, frameWidth, frameHeight, 0, x - dx, y + dy, 3, useClip: false);
			break;
		}
	}

	public void update()
	{
		if (timepaint - mSystem.currentTimeMillis() >= 0)
		{
			return;
		}
		switch (type)
		{
		case 0:
			if (GameCanvas.gameTick % 2 == 0)
			{
				f++;
			}
			if (f > Frame[type].Length - 1)
			{
				f = 0;
				timerepaint = CRes.random(10);
				timepaint = timerepaint * 1000 + mSystem.currentTimeMillis();
				if (timerepaint % 2 == 0)
				{
					pospaint = 0;
				}
				else
				{
					pospaint = 1;
				}
			}
			FrameEffect = Frame[type][f];
			if (GameCanvas.gameTick % 4 == 0)
			{
				f1++;
			}
			if (f1 > Frame[type].Length - 1)
			{
				f1 = 0;
			}
			FrameEffect1 = Frame[type][f1];
			break;
		case 1:
			f++;
			if (f > Frame[type].Length - 1)
			{
				f = 0;
				timerepaint = CRes.random(10);
				timepaint = timerepaint * 1000 + mSystem.currentTimeMillis();
			}
			FrameEffect = Frame[type][f];
			break;
		case 2:
			if (GameCanvas.gameTick % 2 == 0)
			{
				f++;
			}
			if (f > Frame[type].Length - 1)
			{
				f = 0;
				timerepaint = CRes.random(10);
				timepaint = timerepaint * 1000 + mSystem.currentTimeMillis();
			}
			FrameEffect = Frame[type][f];
			if (GameCanvas.gameTick % 3 == 0)
			{
				f1++;
			}
			if (f1 > Frame[type].Length - 1)
			{
				f1 = 0;
			}
			FrameEffect1 = Frame[type][f1];
			break;
		}
	}
}
