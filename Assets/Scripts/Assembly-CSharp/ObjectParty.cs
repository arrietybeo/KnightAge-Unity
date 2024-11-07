public class ObjectParty
{
	public short Lv;

	public string name;

	public sbyte idArea;

	public int x;

	public int y;

	public int idMap;

	public int hp;

	public int maxhp;

	public bool isRemove;

	public bool ischeck = true;

	public ObjectParty(string name, short Lv, int idMap, sbyte idarea)
	{
		idArea = idarea;
		this.idMap = idMap;
		this.name = name;
		this.Lv = Lv;
	}
}
