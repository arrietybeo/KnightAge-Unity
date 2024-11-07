public class EffectData
{
	public sbyte[] data;

	public long timeRemove;

	public short id;

	public EffectData()
	{
	}

	public EffectData(short idImg)
	{
		id = idImg;
	}

	public void setdata(sbyte[] data)
	{
		this.data = data;
	}
}
