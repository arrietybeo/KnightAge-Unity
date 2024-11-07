public class WeaponInfo
{
	public mImage img;

	public sbyte[][][] mPos;

	public sbyte[][] mRegion;

	public int himg;

	public WeaponInfo()
	{
		mPos = mSystem.new_M_Byte(4, 3, 2);
		mRegion = mSystem.new_M_Byte(4, 2);
	}
}
