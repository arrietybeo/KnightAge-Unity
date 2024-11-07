public class DataEffAuto
{
	public sbyte[] data;

	public short id;

	public long timeremove;

	public DataEffAuto(int id)
	{
		this.id = (short)id;
	}

	public void setdata(sbyte[] mdata)
	{
		data = mdata;
	}
}
