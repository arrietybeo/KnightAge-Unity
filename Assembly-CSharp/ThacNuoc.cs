public class ThacNuoc
{
	public sbyte idImgThac;

	private int x;

	private int y;

	public static mImage[] allImgThac;

	private int indexTile;

	public ThacNuoc()
	{
	}

	public ThacNuoc(int idtile, int x, int y)
	{
		this.x = x;
		this.y = y;
		idImgThac = (sbyte)idtile;
		if (allImgThac == null)
		{
			allImgThac = new mImage[9];
			for (int i = 0; i < allImgThac.Length; i++)
			{
				allImgThac[i] = mImage.createImage("/tilethac" + i + ".png");
			}
		}
	}

	public void paint(mGraphics g)
	{
		if (allImgThac != null && idImgThac < allImgThac.Length && allImgThac[idImgThac] != null)
		{
			g.drawRegion(allImgThac[idImgThac], 0, indexTile * 24, 24, 24, (idImgThac <= 4) ? 0 : 0, x, y, 0, mGraphics.isFalse);
		}
	}

	public void update()
	{
		if (GameCanvas.gameTick % 4 == 0)
		{
			indexTile = (indexTile + 1) % 4;
		}
	}

	public bool isThacNuoc()
	{
		return true;
	}
}
