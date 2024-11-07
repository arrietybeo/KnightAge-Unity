public class MainItemMap
{
	public const sbyte ITEM_MAP = 0;

	public const sbyte EFF_MAP = 1;

	public const sbyte EFF_FROM_SV = 2;

	public const sbyte EFF_SKILL_FROM_SV = 3;

	public const sbyte EFF_MAT_NA = 4;

	public sbyte TypeItem;

	public short IDItem;

	public short IDImage;

	public int dx;

	public int dy;

	public int x;

	public int y;

	public int wOne;

	public int hOne;

	public int[][] Block;

	public short idActor;

	private mImage img;

	public MainItemMap()
	{
	}

	public MainItemMap(short IDItem, short IDImage, int dx, int dy, int[][] Block)
	{
		this.IDItem = IDItem;
		this.IDImage = IDImage;
		this.dx = dx;
		this.dy = dy;
		this.Block = Block;
	}

	public virtual void setDataEff(sbyte[] datasv)
	{
	}

	public virtual void paint(mGraphics g)
	{
	}

	public virtual void update()
	{
	}

	public bool isInScreen()
	{
		if (hOne == 0 || wOne == 0)
		{
			MainImage imagePartItemMap = ObjectData.getImagePartItemMap(IDItem);
			if (imagePartItemMap.img != null)
			{
				wOne = mImage.getImageWidth(imagePartItemMap.img.image);
				hOne = mImage.getImageHeight(imagePartItemMap.img.image);
			}
		}
		if (x + dx + wOne < MainScreen.cameraMain.xCam || x + dx - wOne > MainScreen.cameraMain.xCam + GameCanvas.w || y + dy + hOne < MainScreen.cameraMain.yCam || y + dy - hOne > MainScreen.cameraMain.yCam + GameCanvas.h)
		{
			return false;
		}
		return true;
	}
}
