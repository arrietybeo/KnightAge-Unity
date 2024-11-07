public class MainTemplateItem
{
	public const sbyte TYPE_AO = 0;

	public const sbyte TYPE_QUAN = 1;

	public const sbyte TYPE_NON = 2;

	public const sbyte TYPE_GANGTAY = 3;

	public const sbyte TYPE_NHAN = 4;

	public const sbyte TYPE_DAYCHUYEN = 5;

	public const sbyte TYPE_GIAY = 6;

	public const sbyte TYPE_CANH = 7;

	public const sbyte TYPE_VUKHI1 = 8;

	public const sbyte TYPE_VUKHI2 = 9;

	public const sbyte TYPE_VUKHI3 = 10;

	public const sbyte TYPE_VUKHI4 = 11;

	public const sbyte TYPE_PET = 14;

	public const sbyte I_VUKHI = 0;

	public const sbyte I_AO = 1;

	public const sbyte I_GANGTAY = 2;

	public const sbyte I_NHAN1 = 3;

	public const sbyte I_DAYCHUYEN = 4;

	public const sbyte I_PET = 5;

	public const sbyte I_NON = 6;

	public const sbyte I_QUAN = 7;

	public const sbyte I_GIAY = 8;

	public const sbyte I_NHAN2 = 9;

	public const sbyte I_CANH = 10;

	public const sbyte I_HEAD = 12;

	public const sbyte I_EYE = 13;

	public const sbyte I_HAIR = 14;

	public int ID;

	public int IconId;

	public string name;

	private int timenull;

	public static bool isload = true;

	public int typeItem;

	public int idPartItem;

	public int classItem;

	public int[] mValueItem;

	public sbyte[] mValueName;

	public int sellPotion;

	public int valuePotion;

	public long PricePoition;

	public sbyte moneyType;

	public sbyte typePotion;

	public string contentPotion;

	public sbyte typeSell;

	public sbyte typeTrade;

	private bool canTrade;

	public static int[] mItem_Equip_Tem = new int[25]
	{
		-1, 0, 3, 4, 5, 12, 2, 1, 6, 4,
		7, -2, -2, -2, -2, -2, -2, -2, -2, -2,
		-2, -2, -2, -2, -2
	};

	public static int[] mItem_Rotate_Tem_Equip = new int[13]
	{
		1, 7, 6, 2, -1, 4, 8, 10, 0, 0,
		0, 0, 5
	};

	public static mHashTable hashPotionTem = new mHashTable();

	public static mHashTable hashMaterialTem = new mHashTable();

	public static mHashTable hashMaterialTem2 = new mHashTable();

	public static mHashTable hashItemTem = new mHashTable();

	public static mHashTable hashPetTem = new mHashTable();

	public MainTemplateItem()
	{
	}

	public MainTemplateItem(short ID, string name, sbyte typeItem, sbyte idPartItem, sbyte classitem, short iconId, int[] mvalue, sbyte[] mvaluename)
	{
		this.ID = ID;
		IconId = iconId;
		this.name = name;
		this.typeItem = typeItem;
		this.idPartItem = idPartItem;
		classItem = classitem;
		mValueItem = mvalue;
		mValueName = mvaluename;
	}

	public MainTemplateItem(short ID, short IconId, long price, string name, string content, sbyte typepotion, sbyte moneytype, sbyte sell, short value, bool canTrade)
	{
		this.ID = ID;
		this.IconId = IconId;
		PricePoition = price;
		this.name = name;
		contentPotion = content;
		typePotion = typepotion;
		moneyType = moneytype;
		sellPotion = sell;
		valuePotion = value;
		this.canTrade = canTrade;
	}

	public static void removeUpdateItemInventory(int type)
	{
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
			if (item.ItemCatagory == type)
			{
				Item.VecInvetoryPlayer.removeElement(item);
				i--;
			}
		}
	}

	public static void removeUpdateItemChest(int type)
	{
		for (int i = 0; i < Item.VecChestPlayer.size(); i++)
		{
			Item item = (Item)Item.VecChestPlayer.elementAt(i);
			if (item.ItemCatagory == type)
			{
				Item.VecInvetoryPlayer.removeElement(item);
				i--;
			}
		}
	}

	public static void removeUpdateItemVec(int type, mVector vec)
	{
		for (int i = 0; i < vec.size(); i++)
		{
			Item item = (Item)vec.elementAt(i);
			if (item.ItemCatagory == type)
			{
				vec.removeElement(item);
				i--;
			}
		}
	}

	public static MainTemplateItem getItemTem(short id)
	{
		MainTemplateItem mainTemplateItem = (MainTemplateItem)hashItemTem.get(string.Empty + id);
		if (mainTemplateItem == null)
		{
			mainTemplateItem = new MainTemplateItem();
			hashItemTem.put(string.Empty + id, mainTemplateItem);
			GlobalService.gI().getItemTem(id);
		}
		if (mainTemplateItem.name == null)
		{
			mainTemplateItem.timenull++;
			if (mainTemplateItem.timenull >= 200)
			{
				GlobalService.gI().getItemTem(id);
				mainTemplateItem.timenull = 0;
			}
		}
		return mainTemplateItem;
	}

	public static MainTemplateItem getPotionTem(short id)
	{
		return (MainTemplateItem)hashPotionTem.get(string.Empty + id);
	}
}
