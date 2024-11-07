public class AutoGetItem
{
	public sbyte valueColorItem;

	public sbyte isGetMoney;

	public sbyte isGetPotion;

	public static sbyte POI_NHAT_HET;

	public static sbyte POI_NHAT_MAU = 1;

	public static sbyte POI_NHAT_NANG_LUONG = 2;

	public static sbyte POI_KHONG_NHAT = 3;

	public bool isremove;

	public AutoGetItem(sbyte valuecolor, sbyte potion, sbyte money)
	{
		valueColorItem = valuecolor;
		isGetMoney = money;
		isGetPotion = potion;
	}
}
