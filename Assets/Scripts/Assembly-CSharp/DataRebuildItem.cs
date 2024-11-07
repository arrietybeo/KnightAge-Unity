public class DataRebuildItem
{
	public short id;

	public short valueWing;

	public sbyte lv;

	public sbyte cat;

	public int priceCoin;

	public int priceGold;

	public sbyte[] mValue;

	public DataRebuildItem()
	{
	}

	public DataRebuildItem(sbyte lv, int coin, int gold, sbyte[] mvalue)
	{
		this.lv = lv;
		priceCoin = coin;
		priceGold = gold;
		mValue = mvalue;
	}

	public DataRebuildItem(short id, short valueWing)
	{
		this.id = id;
		this.valueWing = valueWing;
	}

	public DataRebuildItem(short id, sbyte cat)
	{
		this.id = id;
		this.cat = cat;
	}
}
