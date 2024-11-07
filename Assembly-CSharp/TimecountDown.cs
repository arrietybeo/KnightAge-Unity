public class TimecountDown
{
	private short mysecond;

	private string tile;

	private long currT;

	private long lastT;

	public bool wantdestroy;

	private int x;

	private int y;

	public TimecountDown(int second, string tile, int x, int y)
	{
		mysecond = (short)second;
		this.tile = tile;
		this.x = x;
		this.y = y;
		currT = mSystem.currentTimeMillis();
		lastT = mSystem.currentTimeMillis();
	}

	public void paint(mGraphics g)
	{
		g.drawImage(AvMain.imgBackInfo, x, y + GameCanvas.hText / 2, 3, mGraphics.isFalse);
		mFont.tahoma_7b_white.drawString(g, tile + " : " + LoadMap.converSecon2hours(mysecond), x, y, 2, mGraphics.isFalse);
	}

	public void update()
	{
		currT = mSystem.currentTimeMillis();
		if (currT - lastT >= 1000)
		{
			lastT = mSystem.currentTimeMillis();
			mysecond--;
		}
		if (mysecond <= 0)
		{
			wantdestroy = true;
		}
	}
}
