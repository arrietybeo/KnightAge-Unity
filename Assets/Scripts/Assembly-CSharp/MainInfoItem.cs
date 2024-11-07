public class MainInfoItem
{
	public int id;

	public int value;

	public int maxDam;

	public MainInfoItem(int id, int value)
	{
		this.id = id;
		this.value = value;
	}

	public MainInfoItem(int id, int value, int maxDam)
	{
		this.id = id;
		this.value = value;
		this.maxDam = maxDam;
	}
}
