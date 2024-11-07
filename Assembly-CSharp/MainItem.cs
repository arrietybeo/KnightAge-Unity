public class MainItem : Item
{
	public const int FOOT = 8;

	public const int ATB_FOOT_SNOW = 67;

	public MainItem(int ID, int IconId, string name, string content, int numPotion, int typeMainItem, long price, sbyte typePotion, sbyte moneytype, sbyte issell, sbyte istrade)
	{
		Id = ID;
		imageId = IconId;
		itemName = name;
		base.typePotion = typePotion;
		base.numPotion = numPotion;
		ItemCatagory = typeMainItem;
		priceItem = price;
		priceType = moneytype;
		canSell = issell;
		canTrade = istrade;
		mMoreContent(content);
		IndexSort = 0;
	}

	public MainItem()
	{
	}

	public MainItem(int ID, string itemName, int imageId, sbyte tier, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short level, sbyte canSell, sbyte canTrade, int timeUse, sbyte priceType, sbyte isLock, int timeDefault, long currentTime)
	{
		itemNameExcludeLv = itemName;
		base.itemName = itemName;
		base.imageId = imageId;
		Id = ID;
		base.tier = tier;
		if (base.tier > 0)
		{
			base.itemName = base.itemName + " +" + base.tier;
		}
		base.colorNameItem = colorNameItem;
		classcharItem = charclass;
		ItemCatagory = typeMain;
		mInfo = minfo;
		type_Only_Item = typeOnly;
		IdTem = idTem;
		priceItem = price;
		LvItem = level;
		base.canSell = canSell;
		base.canTrade = canTrade;
		base.timeUse = timeUse;
		base.isLock = isLock;
		timeDefaultItemFashion = timeDefault;
		currentTimeItemFashion = currentTime;
		if (timeUse > 0)
		{
			timeDem = GameCanvas.timeNow;
		}
		else
		{
			timeDem = 0L;
		}
		base.priceType = priceType;
		if ((mInfo != null && mInfo.Length > 0) || priceItem > 0 || timeDem > 0)
		{
			if (mInfo != null && mInfo.Length > 0)
			{
				minfo = CRes.selectionSort(minfo);
			}
			if (!isTem)
			{
				setContentItem();
			}
			else
			{
				setContentTem();
			}
		}
		IndexSort = 10;
	}

	public MainItem(int ID, string itemName, int imageId, sbyte tier, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short level, sbyte canSell, sbyte canTrade, int timeUse, sbyte typeMoney, sbyte isLock)
	{
		itemNameExcludeLv = itemName;
		base.itemName = itemName;
		base.imageId = imageId;
		Id = ID;
		base.tier = tier;
		if (tier > 0)
		{
			base.itemName = base.itemName + " +" + base.tier;
		}
		base.colorNameItem = colorNameItem;
		classcharItem = charclass;
		ItemCatagory = typeMain;
		mInfo = minfo;
		type_Only_Item = typeOnly;
		IdTem = idTem;
		priceItem = price;
		LvItem = level;
		base.canSell = canSell;
		base.canTrade = canTrade;
		base.timeUse = timeUse;
		base.isLock = isLock;
		if (timeUse > 0)
		{
			timeDem = GameCanvas.timeNow;
		}
		else
		{
			timeDem = 0L;
		}
		priceType = typeMoney;
		if ((mInfo != null && mInfo.Length > 0) || priceItem > 0 || timeDem > 0)
		{
			if (mInfo != null && mInfo.Length > 0)
			{
				minfo = CRes.selectionSort(minfo);
			}
			if (!isTem)
			{
				setContentItem();
			}
			else
			{
				setContentTem();
			}
		}
		IndexSort = 10;
		infoHop = new string[2]
		{
			string.Empty,
			string.Empty
		};
	}

	public MainItem(int ID, string itemName, int imageId, sbyte plusItem, int typeMain, MainInfoItem[] minfo, bool isTem, short idTem, long price, sbyte priceType, sbyte issell, sbyte istrade)
	{
		base.itemName = itemName;
		base.imageId = imageId;
		Id = ID;
		tier = plusItem;
		ItemCatagory = typeMain;
		mInfo = minfo;
		IdTem = idTem;
		priceItem = price;
		base.priceType = priceType;
		canSell = issell;
		canTrade = istrade;
		if (mInfo != null)
		{
			minfo = CRes.selectionSort(minfo);
			setContentHair();
		}
		IndexSort = 1;
	}

	public MainItem(int ID, long price)
	{
		Id = ID;
		priceItem = price;
		priceType = 1;
		ItemCatagory = 8;
		itemName = T.iconclan;
		mMoreContent(T.contentclan);
		IndexSort = 1;
	}

	public MainItem(int ID, string itemName, int imageId, int typeMain, long price, sbyte priceType, string content, int value, sbyte typeItem, short num, sbyte sell, sbyte trade)
	{
		base.itemName = itemName;
		base.imageId = imageId;
		Id = ID;
		ItemCatagory = typeMain;
		priceItem = price;
		base.priceType = priceType;
		base.value = value;
		numPotion = num;
		canSell = sell;
		canTrade = trade;
		base.content = content;
		typeMaterial = typeItem;
		if (content != null)
		{
			mMoreContent(content);
		}
		IndexSort = 2;
	}

	public MainItem(int ID, string name, int numQItem, string content, sbyte issell, sbyte istrade)
	{
		Id = ID;
		imageId = ID;
		itemName = name;
		numPotion = numQItem;
		ItemCatagory = 5;
		canSell = issell;
		canTrade = istrade;
		mMoreContent(content);
		IndexSort = 3;
	}

	public MainItem(int ID, string name, int numPo, int idIcon, sbyte item_potion, string contentPotion, MainInfoItem[] minfo, sbyte colorname, sbyte charclass, short lvMin, sbyte lvup, sbyte issell, sbyte istrade)
	{
		Id = ID;
		itemName = name;
		numPotion = numPo;
		imageId = idIcon;
		ItemCatagory = item_potion;
		colorNameItem = colorname;
		mInfo = minfo;
		classcharItem = charclass;
		LvItem = lvMin;
		canSell = issell;
		canTrade = istrade;
		tier = lvup;
		if (tier > 0)
		{
			itemName = itemName + " +" + tier;
		}
		if (contentPotion != null)
		{
			mMoreContent(contentPotion);
		}
		else
		{
			setContentItem();
		}
		IndexSort = 4;
	}

	public MainItem(string name, int idIcon, int numPo, sbyte item_potion, sbyte lvup, sbyte color)
	{
		colorNameItem = color;
		itemName = name;
		numPotion = numPo;
		imageId = idIcon;
		ItemCatagory = item_potion;
		tier = lvup;
		if (tier > 0)
		{
			itemName = itemName + " +" + tier;
		}
	}

	public MainItem clonePotion()
	{
		MainItem mainItem = new MainItem();
		mainItem.Id = Id;
		mainItem.imageId = imageId;
		mainItem.itemName = itemName;
		mainItem.typePotion = typePotion;
		mainItem.numPotion = numPotion;
		mainItem.ItemCatagory = ItemCatagory;
		mainItem.priceItem = priceItem;
		mainItem.priceType = priceType;
		mainItem.canSell = priceType;
		mainItem.canTrade = priceType;
		if (content != null)
		{
			mainItem.mMoreContent(content);
		}
		mainItem.mcontent = mcontent;
		IndexSort = 0;
		return mainItem;
	}

	public override void mMoreContent(string str)
	{
		base.mMoreContent(str);
	}

	public static MainItem MainItem_Item(int ID, string itemName, int imageId, sbyte plusItem, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short LvItem, sbyte issell, sbyte istrade, int timeUse, sbyte typeMoney, sbyte isLock)
	{
		return new MainItem(ID, itemName, imageId, plusItem, colorNameItem, charclass, typeMain, minfo, typeOnly, isTem, idTem, price, LvItem, issell, istrade, timeUse, typeMoney, isLock);
	}

	public MainItem clone()
	{
		MainItem mainItem = new MainItem();
		mainItem.itemNameExcludeLv = itemNameExcludeLv;
		mainItem.itemName = itemName;
		mainItem.imageId = imageId;
		mainItem.Id = Id;
		mainItem.tier = tier;
		mainItem.colorNameItem = colorNameItem;
		mainItem.classcharItem = classcharItem;
		mainItem.ItemCatagory = ItemCatagory;
		mainItem.mInfo = mInfo;
		mainItem.type_Only_Item = type_Only_Item;
		mainItem.IdTem = IdTem;
		mainItem.priceItem = priceItem;
		mainItem.LvItem = LvItem;
		mainItem.canSell = canSell;
		mainItem.canTrade = canTrade;
		mainItem.timeUse = timeUse;
		mainItem.isLock = isLock;
		mainItem.timeDem = timeDem;
		mainItem.numPotion = numPotion;
		mainItem.priceType = priceType;
		mainItem.mInfo = mInfo;
		mainItem.IndexSort = IndexSort;
		mainItem.infoHop = new string[2]
		{
			string.Empty,
			string.Empty
		};
		return mainItem;
	}

	public static MainItem MainItem_Item(int ID, string itemName, int imageId, sbyte plusItem, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short LvItem, sbyte issell, sbyte istrade, int timeUse, sbyte priceType, sbyte isLock, int timeDefault, long currentTime)
	{
		return new MainItem(ID, itemName, imageId, plusItem, colorNameItem, charclass, typeMain, minfo, typeOnly, isTem, idTem, price, LvItem, issell, istrade, timeUse, priceType, isLock, timeDefault, currentTime);
	}

	public static MainItem MainItem_Toc(int ID, string itemName, int imageId, sbyte plusItem, int typeMain, MainInfoItem[] minfo, bool isTem, short idTem, long price, sbyte priceType, sbyte issell, sbyte istrade)
	{
		return new MainItem(ID, itemName, imageId, plusItem, typeMain, minfo, isTem, idTem, price, priceType, issell, istrade);
	}

	public static MainItem MainItem_Material(int ID, string itemName, int imageId, int typeMain, long price, sbyte priceType, string content, int value, sbyte typeitem, short num, sbyte Sell, sbyte Trade)
	{
		return new MainItem(ID, itemName, imageId, typeMain, price, priceType, content, value, typeitem, num, Sell, Trade);
	}

	public MainItem cloneNguyenLieu()
	{
		MainItem mainItem = new MainItem();
		mainItem.itemName = itemName;
		mainItem.imageId = imageId;
		mainItem.Id = Id;
		mainItem.ItemCatagory = ItemCatagory;
		mainItem.priceItem = priceItem;
		mainItem.priceType = priceType;
		mainItem.value = value;
		mainItem.canSell = canSell;
		mainItem.canTrade = canTrade;
		mainItem.content = content;
		mainItem.typeMaterial = typeMaterial;
		if (content != null)
		{
			mainItem.mMoreContent(content);
		}
		mainItem.IndexSort = 2;
		return mainItem;
	}

	public override void paintItem_notnum(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		base.paintItem_notnum(g, x, y, w, lech, numlech);
	}

	public void setContentHair()
	{
		if (itemName == null)
		{
			itemName = null;
			return;
		}
		int num = mInfo.Length;
		mcontent = new string[num];
		mColor = new int[num];
		int width = mFont.tahoma_7b_white.getWidth(itemName);
		if (width > sizeW - 10)
		{
			sizeW = width + 10;
		}
		for (int i = 0; i < num; i++)
		{
			MainInfoItem mainInfoItem = mInfo[i];
			mcontent[i] = Item.nameInfoItem[mainInfoItem.id] + ": " + Item.getPercent(Item.isPercentInfoItem[mainInfoItem.id], mainInfoItem.value);
			mColor[i] = Item.colorInfoItem[mainInfoItem.id];
			width = mFont.tahoma_7_black.getWidth(mcontent[i]);
			if (width > sizeW - 10)
			{
				sizeW = width + 10;
			}
		}
		int num2 = 0;
		num2++;
		if (num2 > 0)
		{
			mPlusContent = new string[num2];
			mPlusColor = new int[num2];
			num2 = 0;
			if (priceItem > 0)
			{
				mPlusContent[num2] = T.price + ": " + priceItem + getPriceType();
				mPlusColor[num2] = 2;
				num2++;
			}
			else
			{
				mPlusContent[num2] = T.dasohuu;
				mPlusColor[num2] = 2;
				num2++;
			}
		}
		else
		{
			mPlusContent = null;
			mPlusColor = null;
		}
	}

	public static string getDotNumber(long m)
	{
		string text = string.Empty;
		long num = m / 1000 + 1;
		for (int i = 0; i < num; i++)
		{
			if (m >= 1000)
			{
				long num2 = m % 1000;
				text = ((num2 != 0L) ? ((num2 >= 10) ? ((num2 >= 100) ? ("." + num2 + text) : (".0" + num2 + text)) : (".00" + num2 + text)) : (".000" + text));
				m /= 1000;
				continue;
			}
			text = m + text;
			break;
		}
		return text;
	}

	public static string getNopercent(int value)
	{
		if (value % 100 == 0)
		{
			return value / 100 + string.Empty;
		}
		if (value % 10 == 0)
		{
			return value / 100 + "." + value % 100 / 10;
		}
		return value / 100 + "." + value % 100 / 10 + string.Empty + value % 10;
	}

	public void paint(mGraphics g)
	{
	}

	public void paintColorItem(mGraphics g, int x, int y, int w)
	{
	}

	public new void paintItem(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		base.paintItem(g, x, y, w, lech, numlech);
	}

	public new void paintItemNew(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		base.paintItemNew(g, x, y, w, lech, numlech);
	}

	public static void setAddHotKey(sbyte typePo, bool isStop)
	{
		HotKey hotKey = null;
		if (typePo == 0)
		{
			hotKey = Player.mhotkey[Player.levelTab][4];
		}
		else if (typePo == 1)
		{
			hotKey = Player.mhotkey[Player.levelTab][3];
		}
		if (hotKey == null || hotKey.type != HotKey.NULL)
		{
			hotKey = new HotKey();
			hotKey.type = HotKey.NULL;
		}
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
			if (mainItem.ItemCatagory == 4 && mainItem.typePotion == typePo && ((hotKey.id < mainItem.Id && isStop) || (hotKey.id > mainItem.Id && !isStop) || hotKey.type == HotKey.NULL))
			{
				hotKey.setHotKey(mainItem.Id, HotKey.POTION, typePo);
			}
		}
	}

	public void set_can_Sell(sbyte can_sell_for_other_player)
	{
		base.can_sell_for_other_player = can_sell_for_other_player;
	}

	public void setCanShell_notCanTrade(sbyte type)
	{
		CanShell_CanNotTrade = type;
	}

	public override bool isMaterialHopNguyenLieu()
	{
		if (ItemCatagory == 7 && MainObject.isMaHopNguyenLieu(Id))
		{
			return true;
		}
		return false;
	}
}
