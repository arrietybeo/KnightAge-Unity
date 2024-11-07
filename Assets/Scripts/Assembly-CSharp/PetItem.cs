using System;

public class PetItem : Item
{
	public sbyte petImageId;

	public sbyte nFrameImgPet;

	public int type;

	public short experience;

	public int age;

	public new int frame;

	public short growpoint;

	public short maxgrow;

	public short spirit;

	public short health;

	public short agility;

	public short strength;

	public short maxtiemnang;

	public MainInfoItem petAttack;

	public short[] mvaluetiemnang;

	public bool isPetTool;

	public PetItem()
	{
	}

	public PetItem(int ID, string itemName, int iconId, int itemNameColor, int classTypeEquipment, int catagory, MainInfoItem[] mainInfo, int type, short level, int petType, sbyte frameNumberImg, sbyte petImageId)
	{
		itemNameExcludeLv = itemName;
		base.itemName = itemName;
		imageId = iconId;
		Id = ID;
		tier = 0;
		if (tier > 0)
		{
			base.itemName = base.itemName + " +" + tier;
		}
		colorNameItem = itemNameColor;
		classcharItem = classTypeEquipment;
		ItemCatagory = catagory;
		mInfo = mainInfo;
		type_Only_Item = type;
		IdTem = -1;
		priceItem = 0L;
		LvItem = level;
		canSell = 0;
		canTrade = 0;
		timeUse = 0;
		if (timeUse > 0)
		{
			timeDem = GameCanvas.timeNow;
		}
		else
		{
			timeDem = 0L;
		}
		priceType = 0;
		this.type = petType;
		if ((mVector)Pet.PET_DATA.get(string.Empty + petImageId) != null)
		{
			isPetTool = true;
		}
		nFrameImgPet = frameNumberImg;
		this.petImageId = petImageId;
		if ((mInfo != null && mInfo.Length > 0) || priceItem > 0 || timeDem > 0)
		{
			if (mInfo != null && mInfo.Length > 0)
			{
				mainInfo = CRes.selectionSort(mainInfo);
			}
			setContentItem();
		}
		IndexSort = 10;
		if (mInfo == null || mInfo.Length <= 0)
		{
			return;
		}
		for (int i = 0; i < mInfo.Length; i++)
		{
			MainInfoItem mainInfoItem = mInfo[i];
			if (mainInfoItem.id <= 6 && mainInfoItem.value > 0)
			{
				petAttack = mainInfoItem;
			}
		}
	}

	public void setTimeUser(int timeDefault, long currentTime)
	{
		timeDefaultItemFashion = timeDefault;
		currentTimeItemFashion = currentTime;
	}

	public void setInfoPetOld(int ID, string itemName, int iconId, int itemNameColor, int classTypeEquipment, int catagory, MainInfoItem[] mainInfo, int type, short level, int petType, sbyte frameNumberImg, sbyte petImageId)
	{
		itemNameExcludeLv = itemName;
		base.itemName = itemName;
		imageId = iconId;
		Id = ID;
		tier = 0;
		if (tier > 0)
		{
			base.itemName = base.itemName + " +" + tier;
		}
		colorNameItem = itemNameColor;
		classcharItem = classTypeEquipment;
		ItemCatagory = catagory;
		mInfo = mainInfo;
		type_Only_Item = type;
		IdTem = -1;
		priceItem = 0L;
		LvItem = level;
		canSell = 0;
		canTrade = 0;
		timeUse = 0;
		if (timeUse > 0)
		{
			timeDem = GameCanvas.timeNow;
		}
		else
		{
			timeDem = 0L;
		}
		priceType = 0;
		this.type = petType;
		nFrameImgPet = frameNumberImg;
		this.petImageId = petImageId;
		if ((mInfo != null && mInfo.Length > 0) || priceItem > 0 || timeDem > 0)
		{
			if (mInfo != null && mInfo.Length > 0)
			{
				mainInfo = CRes.selectionSort(mainInfo);
			}
			setContentItem();
		}
		IndexSort = 10;
		if (mInfo == null || mInfo.Length <= 0)
		{
			return;
		}
		for (int i = 0; i < mInfo.Length; i++)
		{
			MainInfoItem mainInfoItem = mInfo[i];
			if (mainInfoItem.id <= 6 && mainInfoItem.value > 0)
			{
				petAttack = mainInfoItem;
			}
		}
	}

	public void setInfoPet(int age, short growPoint, short str, short agi, short hea, short spi, short maxgrow, short maxtiemnang, short experience)
	{
		this.age = age;
		growpoint = growPoint;
		this.maxgrow = maxgrow;
		strength = str;
		agility = agi;
		health = hea;
		spirit = spi;
		this.maxtiemnang = maxtiemnang;
		this.experience = experience;
		mvaluetiemnang = new short[4];
		mvaluetiemnang[0] = strength;
		mvaluetiemnang[1] = agility;
		mvaluetiemnang[2] = health;
		mvaluetiemnang[3] = spirit;
	}

	public new void paintItem(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		base.paintItem(g, x, y, w, lech, numlech);
	}

	public void paintShowPet(mGraphics g, int x, int y, int w, int lech, int numlech, int animIdx)
	{
		MainImage imagePet = ObjectData.getImagePet(petImageId);
		if (isPetTool)
		{
			if (imagePet.img != null)
			{
				int num = 0;
				if (isFly())
				{
					num = 15;
				}
				g.drawImage(MainObject.shadow, x, y + 10, 3, mGraphics.isTrue);
				paintPetTool(g, imagePet, x, y + num);
				doChangeFrmaeBoss();
			}
		}
		else
		{
			if (type != 2)
			{
				g.drawImage(MainObject.shadow, x, y + 10, 3, mGraphics.isTrue);
				y -= 10;
			}
			if (imagePet.img != null)
			{
				int num2 = mImage.getImageHeight(imagePet.img.image) / nFrameImgPet;
				int num3 = mImage.getImageWidth(imagePet.img.image) / 2;
				g.drawRegion(imagePet.img, num3 * (getframe(animIdx) / 3), num2 * (getframe(animIdx) % 3), num3, num2, 0, x, y + lech, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isTrue);
			}
		}
	}

	public void doChangeFrmaeBoss()
	{
		mVector mVector3 = new mVector();
		mVector mVector4 = (mVector)Pet.PET_DATA.get(string.Empty + petImageId);
		if (mVector4 != null)
		{
			mVector3 = mVector4;
		}
		DataEffect dataEffect = null;
		if (mVector3.size() > 0)
		{
			dataEffect = (DataEffect)mVector3.elementAt(0);
			int action = 0;
			frame = (byte)((frame + 1) % dataEffect.getAnim(action, 0).frame.Length);
		}
	}

	public void paintPetTool(mGraphics g, MainImage img, int x, int y)
	{
		mVector mVector3 = new mVector();
		mVector mVector4 = (mVector)Pet.PET_DATA.get(string.Empty + petImageId);
		if (mVector4 != null)
		{
			mVector3 = mVector4;
		}
		if (mVector3.size() == 0)
		{
			return;
		}
		try
		{
			DataEffect dataEffect = (DataEffect)mVector3.elementAt(0);
			if (dataEffect != null)
			{
				int action = 0;
				int num = 0;
				mVector mVector5 = (mVector)Pet.PET_DATA.get(string.Empty + petImageId);
				if (mVector5 != null && img != null && img.img != null)
				{
					dataEffect.paintPet(g, dataEffect.getFrame(frame, action, 0), x, y - num, 0, img.img);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public int getframe(int animIdx)
	{
		return type switch
		{
			0 => Pet.mOwl[animIdx][0][GameCanvas.gameTick % Pet.mOwl[animIdx][0].Length], 
			1 => Pet.mBat[animIdx][0][GameCanvas.gameTick % Pet.mBat[animIdx][0].Length], 
			2 => Pet.mWoftAnimFrame[animIdx][0][GameCanvas.gameTick % Pet.mWoftAnimFrame[animIdx][0].Length], 
			3 => Pet.mEagle[animIdx][0][GameCanvas.gameTick % Pet.mEagle[animIdx][0].Length], 
			_ => Pet.mElfAnimFrame[animIdx][0][GameCanvas.gameTick % Pet.mElfAnimFrame[animIdx][0].Length], 
		};
	}

	public bool isFly()
	{
		mVector mVector3 = new mVector();
		mVector mVector4 = (mVector)Pet.PET_DATA.get(string.Empty + petImageId);
		if (mVector4 != null)
		{
			mVector3 = mVector4;
		}
		DataEffect dataEffect = (DataEffect)mVector3.elementAt(0);
		if (dataEffect != null && dataEffect.isFly <= -5)
		{
			return true;
		}
		return false;
	}
}
