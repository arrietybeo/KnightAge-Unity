public class MountTemplate
{
	public const sbyte NGUA_NAU = 0;

	public const sbyte NGUA_TRANG = 1;

	public const sbyte NGUA_CHIENGIAP = 2;

	public const sbyte NGUA_DO = 3;

	public const sbyte NGUA_DEN = 4;

	public short idTemplate;

	public short idImage;

	public short lv;

	public sbyte typemove;

	public string name = string.Empty;

	public static MountTemplate me;

	public static sbyte[] Arr_Fly;

	public static sbyte[] speed;

	public static sbyte[][] FRAME_VE_TRUOC;

	public static sbyte[][] DY_CHAR_STAND;

	public static sbyte[][] DY_CHAR_MOVE;

	public static sbyte[][] dx;

	public static sbyte[][] dy;

	public static sbyte[][] FRAME_MOVE_LR;

	public static sbyte[][] FRAME_MOVE_DOWN;

	public static sbyte[][] FRAME_MOVE_UP;

	public static MountTemplate gI()
	{
		return (me != null) ? me : (me = new MountTemplate());
	}
}
