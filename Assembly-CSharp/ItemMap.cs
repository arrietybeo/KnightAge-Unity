public class ItemMap : MainItemMap
{
	public static bool isPaintDieHouseArena = false;

	public static FrameImage[] img_HouseArena_Die;

	public static int[] dx_imgDie = new int[4] { 420, 376, 290, 310 };

	public static int[] dy_imgDie = new int[4] { 188, 447, 426, 105 };

	public ItemMap(short IDItem, short IDImage, int dx, int dy, int[][] Block)
		: base(IDItem, IDImage, dx, dy, Block)
	{
		TypeItem = 0;
	}

	public void setInfoItem(int x, int y)
	{
		base.x = x;
		base.y = y;
	}

	public override void paint(mGraphics g)
	{
		MainImage imagePartItemMap = ObjectData.getImagePartItemMap(IDImage);
		if (imagePartItemMap.img != null)
		{
			g.drawImage(imagePartItemMap.img, x + dx, y + dy, 0, mGraphics.isFalse);
		}
	}

	public static void paintDieHouseArena(mGraphics g)
	{
		if (isPaintDieHouseArena)
		{
			if (GameCanvas.loadmap.idMap == 58)
			{
				img_HouseArena_Die[0].drawFrame(0, dx_imgDie[0], dy_imgDie[0], 0, g);
			}
			else if (GameCanvas.loadmap.idMap == 56)
			{
				img_HouseArena_Die[1].drawFrame(0, dx_imgDie[1], dy_imgDie[1], 0, g);
			}
			else if (GameCanvas.loadmap.idMap == 54)
			{
				img_HouseArena_Die[2].drawFrame(0, dx_imgDie[2], dy_imgDie[2], 0, g);
			}
			else if (GameCanvas.loadmap.idMap == 60)
			{
				img_HouseArena_Die[3].drawFrame(0, dx_imgDie[3], dy_imgDie[3], 0, g);
			}
		}
	}
}
