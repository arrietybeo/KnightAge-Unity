public class HotKey
{
	public short id;

	public short idIconPotion;

	public sbyte type;

	public sbyte typePotion;

	public static sbyte NULL = -1;

	public static sbyte SKILL;

	public static sbyte POTION = 1;

	public void setHotKey(int id, int type, sbyte typePotion)
	{
		this.id = (short)id;
		this.type = (sbyte)type;
		this.typePotion = typePotion;
	}

	public void setIdIcon(short id)
	{
		idIconPotion = id;
	}
}
