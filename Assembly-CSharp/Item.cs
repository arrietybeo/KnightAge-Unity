public class Item
{
	public const sbyte HP = 0;

	public const sbyte MP = 1;

	public const sbyte COIN = 2;

	public const sbyte GOLD = 6;

	public static sbyte TYPE_NGOC_KHAM = 49;

	public static sbyte TYPE_BUA_HUYEN_BI = 50;

	public static int ID_TEM_VE_MUA_BAN = 51;

	public static string[] nameInfoItem;

	public static sbyte[] colorInfoItem;

	public static sbyte[] isPercentInfoItem;

	public string itemName;

	public string content;

	public string itemNameExcludeLv;

	public MainInfoItem[] mInfo;

	public string[] mcontent;

	public string[] mPlusContent;

	public int[] mColor;

	public int[] mPlusColor;

	public int timeupdateMore;

	public int timeUse;

	public long priceItem;

	public bool isSell;

	public static Effect_UpLv_Item eff_UpLv = new Effect_UpLv_Item();

	public int sizeW = 60;

	public int imageId;

	public int ItemCatagory;

	public short IdTem;

	public static FrameImage fraeffitemdrop;

	private int wImage = 16;

	public sbyte canSell;

	public sbyte canTrade;

	public sbyte tier;

	public sbyte typeMaterial;

	public sbyte isLock;

	public sbyte IndexSort;

	public long timeDem;

	public sbyte can_sell_for_other_player;

	public sbyte Selling;

	public int timeDefaultItemFashion = -1;

	public long currentTimeItemFashion = -1L;

	public sbyte CanShell_CanNotTrade;

	public string[] infoHop = new string[2]
	{
		string.Empty,
		string.Empty
	};

	public static mHashTable VecEquipPlayer = new mHashTable();

	public static mVector VecInvetoryPlayer = new mVector("Item VecInvetoryPlayer");

	public static mVector VecChestPlayer = new mVector("Item VecChestPlayer");

	public static mVector VecPetContainer = new mVector("Item VecPetContainer");

	public static mVector VecClanInvetory = new mVector("Item VecClanInvetory");

	public static mVector VecLotteryReward = new mVector("Item VecLotteryReward");

	public static mVector VecItemSell = new mVector("Item Sell");

	public static mVector VecItem_Sell_in_store = new mVector("Item Sell in store");

	public static mHashTable HashImageItem = new mHashTable();

	public static mHashTable HashImagePotion = new mHashTable();

	public static mHashTable HashImageQuestItem = new mHashTable();

	public static mHashTable HashImageMaterial = new mHashTable();

	public static mHashTable HashImageIconClan = new mHashTable();

	public static mHashTable HashImageIconArcheClan = new mHashTable();

	public static mHashTable HashImagePetIcon = new mHashTable();

	public static mHashTable HashImageMount = new mHashTable();

	public mVector moreContenGem = new mVector("EffectSkill moreContenGem");

	public int numPotion;

	public sbyte typePotion;

	public int classcharItem;

	public int colorNameItem;

	public int Id;

	public int idTab;

	public int sell;

	public int value;

	public sbyte priceType;

	public int idPart;

	public int type_Only_Item;

	public int LvItem;

	public string diaHoiEvent = string.Empty;

	public static byte[] frameicon = new byte[4] { 0, 1, 2, 1 };

	public byte frame;

	public Item itemClone;

	public static sbyte[] ATB_Can_Not_Paint;

	public bool isOutTime()
	{
		if (mSystem.currentTimeMillis() / 1000 - currentTimeItemFashion > timeDefaultItemFashion)
		{
			return true;
		}
		return false;
	}

	public bool isFashionItem()
	{
		return timeDefaultItemFashion != -1;
	}

	public long getTimeItemFashion()
	{
		return mSystem.currentTimeMillis() - currentTimeItemFashion;
	}

	public static bool isWeapone(int type)
	{
		return type >= 8 && type <= 11;
	}

	public void addhole(short[] typehole)
	{
	}

	public static bool isMaterial_Light_Drak(int typeMaterial)
	{
		return typeMaterial > 22 && typeMaterial < 33;
	}

	public void paintItem(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		MainImage mainImage = null;
		if (itemName == null)
		{
			if (setNameNull())
			{
				return;
			}
		}
		else
		{
			if (colorNameItem > 0)
			{
				int num = colorNameItem;
				if (colorNameItem >= 20 && colorNameItem < 30)
				{
					num = 6;
				}
				else if (colorNameItem >= 30 && colorNameItem < 40)
				{
					num = 7;
				}
				else if (colorNameItem >= 40 && colorNameItem < 50)
				{
					num = 8;
				}
				g.drawRegion(AvMain.imgColorItem, 0, (num - 1) * 32, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
			}
			if (ItemCatagory == 6)
			{
				if (priceItem <= 0)
				{
					g.drawRegion(AvMain.imgColorItem, 0, 0, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
				}
				CRes.getCharPartInfo(5, imageId).paintShow(g, x, y, 0, 0);
				return;
			}
			if (ItemCatagory == 5)
			{
				mainImage = ObjectData.getImageQuestItem((short)imageId);
			}
			else if (ItemCatagory == 4)
			{
				mainImage = ObjectData.getImagePotion((short)imageId);
			}
			else if (ItemCatagory == 3)
			{
				mainImage = ObjectData.getImageItem((short)imageId);
			}
			else if (ItemCatagory == 7)
			{
				mainImage = ObjectData.getImageMaterial((short)imageId);
			}
			else if (ItemCatagory == 8)
			{
				mainImage = ObjectData.getImageIconClan((short)Id);
			}
			else if (ItemCatagory == 9)
			{
				mainImage = ObjectData.getImageIconPet((short)imageId);
			}
			if (ItemCatagory != 6)
			{
				if (mainImage != null && mainImage.img != null)
				{
					if (mImage.getImageHeight(mainImage.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num2 = frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							frame = (byte)((frame + 1) % num2);
						}
						g.drawRegion(mainImage.img, 0, frameicon[frame] * 18, 18, 18, 0, x, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(mainImage.img, x, y, 3, mGraphics.isTrue);
					}
				}
				else
				{
					g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, 3, mGraphics.isTrue);
				}
			}
			if (ItemCatagory == 3 && tier > 0)
			{
				int upgrade = tier;
				if (type_Only_Item == 7)
				{
					upgrade = tier / 2;
				}
				eff_UpLv.paintUpgradeEffect(x, y, upgrade, w - 4, g, lech);
			}
		}
		if (numPotion > 1)
		{
			mFont.number_Yellow_Small.drawString(g, numPotion + string.Empty, x + w / 2 - 1 - numlech, y + w / 2 - 9 - numlech, 1, mGraphics.isTrue);
		}
		if (isLock > 0)
		{
			g.drawImage(AvMain.imgLock, x + 4, y + 3, 0, mGraphics.isTrue);
		}
		if (ItemCatagory == 3)
		{
			if (timeUse > 0)
			{
				updateTime();
			}
			if (isFashionItem())
			{
				updateFashion();
			}
		}
	}

	public virtual void paintItem_notnum(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		MainImage mainImage = null;
		if (itemName == null)
		{
			if (setNameNull())
			{
				return;
			}
		}
		else
		{
			if (colorNameItem > 0)
			{
				int num = colorNameItem;
				if (colorNameItem >= 20 && colorNameItem < 30)
				{
					num = 6;
				}
				else if (colorNameItem >= 30 && colorNameItem < 40)
				{
					num = 7;
				}
				else if (colorNameItem >= 40 && colorNameItem < 50)
				{
					num = 8;
				}
				g.drawRegion(AvMain.imgColorItem, 0, (num - 1) * 32, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
			}
			if (ItemCatagory == 6)
			{
				if (priceItem <= 0)
				{
					g.drawRegion(AvMain.imgColorItem, 0, 0, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
				}
				CRes.getCharPartInfo(5, imageId).paintShow(g, x, y, 0, 0);
				return;
			}
			if (ItemCatagory == 5)
			{
				mainImage = ObjectData.getImageQuestItem((short)imageId);
			}
			else if (ItemCatagory == 4)
			{
				mainImage = ObjectData.getImagePotion((short)imageId);
			}
			else if (ItemCatagory == 3)
			{
				mainImage = ObjectData.getImageItem((short)imageId);
			}
			else if (ItemCatagory == 7)
			{
				mainImage = ObjectData.getImageMaterial((short)imageId);
			}
			else if (ItemCatagory == 8)
			{
				mainImage = ObjectData.getImageIconClan((short)Id);
			}
			else if (ItemCatagory == 9)
			{
				mainImage = ObjectData.getImageIconPet((short)imageId);
			}
			if (ItemCatagory != 6)
			{
				if (mainImage != null && mainImage.img != null)
				{
					if (mImage.getImageHeight(mainImage.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num2 = frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							frame = (byte)((frame + 1) % num2);
						}
						g.drawRegion(mainImage.img, 0, frameicon[frame] * 18, 18, 18, 0, x, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(mainImage.img, x, y, 3, mGraphics.isTrue);
					}
				}
				else
				{
					g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, 3, mGraphics.isTrue);
				}
			}
			if (ItemCatagory == 3 && tier > 0)
			{
				int upgrade = tier;
				if (type_Only_Item == 7)
				{
					upgrade = tier / 2;
				}
				eff_UpLv.paintUpgradeEffect(x, y, upgrade, w - 4, g, lech);
			}
		}
		if (isLock > 0)
		{
			g.drawImage(AvMain.imgLock, x + 4, y + 3, 0, mGraphics.isTrue);
		}
		if (ItemCatagory == 3)
		{
			if (timeUse > 0)
			{
				updateTime();
			}
			if (isFashionItem())
			{
				updateFashion();
			}
		}
	}

	public void paintItemNew(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		MainImage mainImage = null;
		if (itemName == null)
		{
			if (setNameNull())
			{
				return;
			}
		}
		else
		{
			if (colorNameItem > 0)
			{
				int num = colorNameItem;
				if (colorNameItem >= 20 && colorNameItem < 30)
				{
					num = 6;
				}
				else if (colorNameItem >= 30 && colorNameItem < 40)
				{
					num = 7;
				}
				else if (colorNameItem >= 40 && colorNameItem < 50)
				{
					num = 8;
				}
				g.drawRegion(AvMain.imgColorItem, 0, (num - 1) * 32, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
			}
			if (ItemCatagory == 6)
			{
				if (priceItem <= 0)
				{
					g.drawRegion(AvMain.imgColorItem, 0, 0, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
				}
				CRes.getCharPartInfo(5, imageId).paintShow(g, x, y, 0, 0);
				return;
			}
			if (ItemCatagory == 5)
			{
				mainImage = ObjectData.getImageQuestItem((short)imageId);
			}
			else if (ItemCatagory == 4)
			{
				mainImage = ObjectData.getImagePotion((short)imageId);
			}
			else if (ItemCatagory == 3)
			{
				mainImage = ObjectData.getImageItem((short)imageId);
			}
			else if (ItemCatagory == 7)
			{
				mainImage = ObjectData.getImageMaterial((short)imageId);
			}
			else if (ItemCatagory == 8)
			{
				mainImage = ObjectData.getImageIconClan((short)Id);
			}
			else if (ItemCatagory == 9)
			{
				mainImage = ObjectData.getImageIconPet((short)imageId);
			}
			if (ItemCatagory != 6)
			{
				if (mainImage != null && mainImage.img != null)
				{
					if (mImage.getImageHeight(mainImage.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 10 == 0)
						{
							int num2 = frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							frame = (byte)((frame + 1) % num2);
						}
						g.drawRegion(mainImage.img, 0, frameicon[frame] * 18, 18, 18, 0, x, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(mainImage.img, x, y, 3, mGraphics.isTrue);
					}
				}
				else
				{
					g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, 3, mGraphics.isTrue);
				}
			}
			if (ItemCatagory == 3 && tier > 0)
			{
				int upgrade = tier;
				if (type_Only_Item == 7)
				{
					upgrade = tier / 2;
				}
				eff_UpLv.paintUpgradeEffect(x, y, upgrade, w - 4, g, lech);
			}
		}
		if (isLock > 0)
		{
			g.drawImage(AvMain.imgLock, x + 4, y + 3, 0, mGraphics.isTrue);
		}
		if (ItemCatagory == 3)
		{
			if (timeUse > 0)
			{
				updateTime();
			}
			if (isFashionItem())
			{
				updateFashion();
			}
		}
	}

	public void updateTime()
	{
		if ((GameCanvas.timeNow - timeDem) / 1000 < 60 || isFashionItem())
		{
			return;
		}
		timeDem += 60000L;
		timeUse--;
		if (mPlusContent == null)
		{
			return;
		}
		if (timeUse > 0)
		{
			if (type_Only_Item == 14)
			{
				mPlusContent[0] = T.thoigianaptrung + PaintInfoGameScreen.getStringTime(timeUse);
			}
			else
			{
				mPlusContent[0] = T.thoigianconlai + PaintInfoGameScreen.getStringTime(timeUse);
			}
		}
		else
		{
			mPlusContent[0] = string.Empty;
		}
	}

	public void updateFashion()
	{
		if ((GameCanvas.timeNow - timeDem) / 1000 < 60)
		{
			return;
		}
		timeDem += 60000L;
		int num = (int)(timeDefaultItemFashion - getTimeItemFashion() / 60000);
		if (mPlusContent == null)
		{
			return;
		}
		if (num > 0)
		{
			if (type_Only_Item == 14)
			{
				mPlusContent[0] = T.thoigianaptrung + PaintInfoGameScreen.getStringTime(num);
			}
			else
			{
				mPlusContent[0] = T.thoigianconlai + PaintInfoGameScreen.getStringTime(num);
			}
		}
		else
		{
			mPlusContent[0] = string.Empty;
		}
	}

	public bool setNameNull()
	{
		if (itemName == null)
		{
			MainTemplateItem itemTem = MainTemplateItem.getItemTem(IdTem);
			if (itemTem.name != null)
			{
				setValueItem(itemTem);
				return false;
			}
			MainTemplateItem.getItemTem(IdTem);
			return true;
		}
		return false;
	}

	public void setValueItem(MainTemplateItem item)
	{
		itemName = item.name;
		imageId = item.IconId;
		type_Only_Item = item.typeItem;
		if (mInfo == null)
		{
			MainInfoItem[] array = new MainInfoItem[item.mValueItem.Length];
			for (int i = 0; i < item.mValueItem.Length; i++)
			{
				array[i] = new MainInfoItem(i, item.mValueItem[i]);
			}
			mInfo = array;
			setContentTem();
		}
	}

	public void setContentTem()
	{
		int num = 0;
		for (int i = 0; i < mInfo.Length; i++)
		{
			MainInfoItem mainInfoItem = mInfo[i];
			if (mainInfoItem.value > 0)
			{
				num++;
			}
		}
		mcontent = new string[num];
		mColor = new int[num];
		num = 0;
		int width = mFont.tahoma_7b_white.getWidth(itemName);
		if (width > sizeW - 10)
		{
			sizeW = width + 10;
		}
		for (int j = 0; j < mInfo.Length; j++)
		{
			MainInfoItem mainInfoItem2 = mInfo[j];
			if (mainInfoItem2.value > 0)
			{
				mcontent[num] = nameInfoItem[j] + ": " + mainInfoItem2.value;
				if (isPercentInfoItem[j] == 1)
				{
					mcontent[num] += "%";
				}
				mColor[num] = colorInfoItem[j];
				width = mFont.tahoma_7_black.getWidth(mcontent[num]);
				if (width > sizeW - 10)
				{
					sizeW = width + 10;
				}
				num++;
			}
		}
		if (sizeW > 200 && GameCanvas.isTouch)
		{
			sizeW = 130;
		}
		setSliptConten();
	}

	public void setContentItem()
	{
		if (itemName == null)
		{
			itemName = null;
			return;
		}
		int num = mInfo.Length;
		mVector mVector3 = new mVector("EffectSkill tem");
		for (int i = 0; i < mInfo.Length; i++)
		{
			MainInfoItem mainInfoItem = mInfo[i];
			if (isPercentInfoItem[mainInfoItem.id] == 4)
			{
				InfocontenNew o = new InfocontenNew(mainInfoItem.value, i);
				moreContenGem.addElement(o);
			}
			else if (isATB_Can_paint(isPercentInfoItem[mainInfoItem.id]))
			{
				mVector3.addElement(mainInfoItem);
			}
		}
		num = mVector3.size();
		mcontent = new string[num];
		mColor = new int[num];
		int width = mFont.tahoma_7b_white.getWidth(itemName);
		if (width > sizeW - 10)
		{
			sizeW = width + 10;
		}
		for (int j = 0; j < num; j++)
		{
			MainInfoItem mainInfoItem2 = (MainInfoItem)mVector3.elementAt(j);
			if (mainInfoItem2.value == 0)
			{
				mcontent[j] = nameInfoItem[mainInfoItem2.id];
			}
			else if (type_Only_Item == 14)
			{
				if (mainInfoItem2.maxDam > 0)
				{
					mcontent[j] = nameInfoItem[mainInfoItem2.id] + ": " + getPercent(isPercentInfoItem[mainInfoItem2.id], mainInfoItem2.value) + "-" + mainInfoItem2.maxDam;
				}
				else
				{
					mcontent[j] = nameInfoItem[mainInfoItem2.id] + ": " + getPercent(isPercentInfoItem[mainInfoItem2.id], mainInfoItem2.value);
				}
			}
			else
			{
				mcontent[j] = nameInfoItem[mainInfoItem2.id] + ": " + ((mainInfoItem2.id != 70) ? getPercent(isPercentInfoItem[mainInfoItem2.id], mainInfoItem2.value) : MainItem.getDotNumber(mainInfoItem2.value));
				if (mainInfoItem2.id == 70)
				{
					Selling = 1;
				}
			}
			mColor[j] = colorInfoItem[mainInfoItem2.id];
			width = mFont.tahoma_7_black.getWidth(mcontent[j]);
			if (width > sizeW - 10)
			{
				sizeW = width + 10;
			}
		}
		int num2 = 0;
		if (timeUse > 0)
		{
			num2++;
		}
		bool flag = isFashionItem();
		int num3 = (int)(timeDefaultItemFashion - getTimeItemFashion() / 60000);
		if (num3 <= 0)
		{
			flag = false;
		}
		if (flag)
		{
			num2++;
		}
		if (priceItem > 0)
		{
			num2++;
		}
		if (ItemCatagory == 3 && classcharItem < 4 && classcharItem > -1)
		{
			num2++;
		}
		if (type_Only_Item != 14 && LvItem > 0)
		{
			num2++;
		}
		if (num2 > 0)
		{
			mPlusContent = new string[num2];
			mPlusColor = new int[num2];
			num2 = 0;
			if (timeUse > 0)
			{
				mPlusColor[num2] = 6;
				if (type_Only_Item == 14)
				{
					mPlusContent[num2] = T.thoigianaptrung + PaintInfoGameScreen.getStringTime(timeUse);
				}
				else
				{
					mPlusContent[num2] = T.thoigianconlai + PaintInfoGameScreen.getStringTime(timeUse);
				}
				width = mFont.tahoma_7_black.getWidth(mPlusContent[num2]);
				if (width > sizeW - 10)
				{
					sizeW = width + 10;
				}
				num2++;
			}
			if (flag)
			{
				mPlusColor[num2] = 6;
				mPlusContent[num2] = T.thoigianconlai + PaintInfoGameScreen.getStringTime(num3);
				num2++;
			}
			if (ItemCatagory == 3 && classcharItem < 4 && classcharItem > -1)
			{
				mPlusContent[num2] = "[" + T.mClass[classcharItem] + "]";
				if (classcharItem == GameScreen.player.clazz)
				{
					mPlusColor[num2] = 0;
				}
				else
				{
					mPlusColor[num2] = 6;
				}
				num2++;
			}
			if (priceItem > 0)
			{
				mPlusContent[num2] = T.price + ": " + priceItem + getPriceType();
				mPlusColor[num2] = 2;
				num2++;
			}
			if (type_Only_Item != 14 && LvItem > 0)
			{
				mPlusContent[num2] = T.LVyeucau + LvItem;
				mPlusColor[num2] = 0;
				width = mFont.tahoma_7_black.getWidth(mPlusContent[num2]);
				if (width > sizeW - 10)
				{
					sizeW = width + 10;
				}
			}
		}
		else
		{
			mPlusContent = null;
			mPlusColor = null;
		}
		if (sizeW > 200 && GameCanvas.isTouch)
		{
			sizeW = 130;
		}
		setSliptConten();
	}

	public void setSliptConten()
	{
		if (mcontent == null || (mcontent != null && mcontent.Length == 1) || mcontent.Length == 0 || ItemCatagory != 3)
		{
			return;
		}
		int lineWidth = sizeW;
		mVector mVector3 = new mVector();
		string text = mcontent[0];
		sbyte b = (sbyte)mColor[0];
		for (int i = 1; i < mcontent.Length; i++)
		{
			string[] array = mFont.tahoma_7_black.splitFontArray(mcontent[i], lineWidth);
			for (int j = 0; j < array.Length; j++)
			{
				Atb_info o = new Atb_info(array[j], mColor[i]);
				mVector3.addElement(o);
			}
		}
		mcontent = new string[mVector3.size() + 1];
		mColor = new int[mVector3.size() + 1];
		mcontent[0] = text;
		mColor[0] = b;
		for (int k = 0; k < mVector3.size(); k++)
		{
			Atb_info atb_info = (Atb_info)mVector3.elementAt(k);
			mcontent[k + 1] = atb_info.info;
			mColor[k + 1] = atb_info.id_color;
		}
	}

	public static string getPercent(int t, int value)
	{
		switch (t)
		{
		case 1:
			if (value % 100 == 0)
			{
				return value / 100 + "%";
			}
			if (value % 10 == 0)
			{
				return value / 100 + "." + value % 100 / 10 + "%";
			}
			return value / 100 + "." + value % 100 / 10 + string.Empty + value % 10 + "%";
		case 2:
			return value / 1000 + "," + value % 1000 / 100 + "s";
		case 3:
			return value + "$";
		case 4:
			return " ";
		case 6:
			return value + " " + T.coin;
		case 7:
			return string.Empty;
		default:
			return string.Empty + value;
		}
	}

	public string getPriceType()
	{
		string result = " " + T.coin;
		if (priceType == 1)
		{
			result = " " + T.gem;
		}
		return result;
	}

	public static Item getItemVec(int type, short ID, mVector vec)
	{
		for (int i = 0; i < vec.size(); i++)
		{
			Item item = (Item)vec.elementAt(i);
			if (item.Id == ID && item.ItemCatagory == type)
			{
				return item;
			}
		}
		return null;
	}

	public static Item getItemInventory(int type, short ID)
	{
		for (int i = 0; i < VecInvetoryPlayer.size(); i++)
		{
			Item item = (Item)VecInvetoryPlayer.elementAt(i);
			if (item.Id == ID && item.ItemCatagory == type)
			{
				return item;
			}
		}
		return null;
	}

	public static Item getItemChest(int type, short ID)
	{
		for (int i = 0; i < VecChestPlayer.size(); i++)
		{
			Item item = (Item)VecChestPlayer.elementAt(i);
			if (item.Id == ID && item.ItemCatagory == type)
			{
				return item;
			}
		}
		return null;
	}

	public static MainItem getMaterial(int id)
	{
		MainItem mainItem = null;
		return (MainItem)MainTemplateItem.hashMaterialTem.get(id + string.Empty);
	}

	public static void put_Material(int id)
	{
		MainItem v = new MainItem();
		MainTemplateItem.hashMaterialTem.put(string.Empty + id, v);
		GlobalService.gI().RequestMaterialTemplate((short)id);
	}

	public virtual bool isMaterialHopNguyenLieu()
	{
		return false;
	}

	public static bool isATB_Can_paint(int id)
	{
		for (int i = 0; i < ATB_Can_Not_Paint.Length; i++)
		{
			if (id == ATB_Can_Not_Paint[i])
			{
				return false;
			}
		}
		return true;
	}

	public void setinfo(int ID, string itemName, int imageId, int typeMain, long price, sbyte priceType, string content, int value, sbyte typeitem, short num, sbyte Sell, sbyte Trade)
	{
		this.itemName = itemName;
		this.imageId = imageId;
		Id = ID;
		ItemCatagory = typeMain;
		priceItem = price;
		this.priceType = priceType;
		this.value = value;
		canSell = Sell;
		canTrade = Trade;
		this.content = content;
		typeMaterial = typeitem;
		if (content != null)
		{
			mMoreContent(content);
		}
		IndexSort = 2;
	}

	public void setinfo(string itemName, int imageId, int typeMain, long price, sbyte priceType, string content, int value, sbyte typeitem, short num, sbyte Sell, sbyte Trade)
	{
		this.itemName = itemName;
		this.imageId = imageId;
		ItemCatagory = typeMain;
		priceItem = price;
		this.priceType = priceType;
		this.value = value;
		canSell = Sell;
		canTrade = Trade;
		this.content = content;
		typeMaterial = typeitem;
		if (content != null)
		{
			mMoreContent(content);
		}
		IndexSort = 2;
	}

	public virtual void mMoreContent(string str)
	{
		sizeW = 86;
		if (MainTabNew.longwidth > 0)
		{
			sizeW = MainTabNew.longwidth - 5;
		}
		mcontent = mFont.tahoma_7_black.splitFontArray(str, sizeW - 5);
		if (MainTabNew.longwidth == 0 && ((mcontent.Length + 1) * GameCanvas.hText > GameCanvas.h / 4 * 3 || mFont.tahoma_7b_black.getWidth(itemName) > 70))
		{
			sizeW = 120;
			mcontent = mFont.tahoma_7_black.splitFontArray(str, sizeW - 5);
		}
		mColor = new int[mcontent.Length];
		for (int i = 0; i < mColor.Length; i++)
		{
			mColor[i] = 0;
		}
		int num = 0;
		if (priceItem > 0)
		{
			num++;
		}
		if (num > 0)
		{
			mPlusContent = new string[num];
			mPlusColor = new int[num];
			if (priceItem > 0)
			{
				mPlusContent[num - 1] = T.price + ": " + MainItem.getDotNumber(priceItem) + getPriceType();
				mPlusColor[num - 1] = 2;
			}
		}
		else
		{
			mPlusContent = null;
			mPlusColor = null;
		}
	}

	public void setColorName(int colorNameItem)
	{
		this.colorNameItem = colorNameItem;
	}
}
