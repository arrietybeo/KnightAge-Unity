using System;
using System.Collections;

public class ObjectData
{
	public const short ITEMMAP = 0;

	public const short MONSTER = 1000;

	public const short ITEM = 2000;

	public const short NPC = 3000;

	public const short POTION = 4000;

	public const short QUEST_ITEM = 5000;

	public const short MATERIAL = 5500;

	public const short SKILL = 6000;

	public const short ICON_CLAN = 7000;

	public const short ICON_ARCHE_CLAN = 9500;

	public const short CAPCHAR = 9999;

	public const short ICON_PET = 10000;

	public const short IMAGE_PET = 10200;

	public const short IMAGE_TILE = 10400;

	public const short IMAGE_TILE_WATER = 10500;

	public const short IMAGE_TILE_SMALL = 10600;

	public const short IMAGE_MOUNT = 10700;

	public const short ITEM_2 = 13000;

	public static mVector vecSaveImage = new mVector("ObjectData vecSaveImage");

	public static MainImage getImagePartNPC(short id)
	{
		MainImage mainImage = (MainImage)GameScreen.HashImageNPC.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			GameScreen.HashImageNPC.put(string.Empty + id, mainImage);
			string url = "/resLocal/npc/" + id + ".png";
			if (id >= 500)
			{
				int num = id - 500;
				url = "/resLocal/npc/icon/" + num + ".png";
			}
			mImage mImage2 = mImage.createImage(url);
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 3000));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 3000));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImagePartItemMap(short id)
	{
		MainImage mainImage = (MainImage)GameScreen.HashImageItemMap.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			GameScreen.HashImageItemMap.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/tree/" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms(id);
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		else if (!GameCanvas.isTouch)
		{
			mainImage.count = (int)(GameCanvas.timeNow / 1000);
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImagePartMonster(short id)
	{
		MainImage mainImage = (MainImage)MainMonster.HashImageMonster.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			MainMonster.HashImageMonster.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/mons/" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 1000));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		else if (!GameCanvas.isTouch)
		{
			mainImage.count = (int)(GameCanvas.timeNow / 1000);
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 1000));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImageItem(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageItem.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageItem.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/icon/icon_" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 2000));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 2000));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImagePotion(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImagePotion.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImagePotion.put(string.Empty + id, mainImage);
			string url = "/resLocal/potion/potionIcon_" + ((id + 1 < 10) ? ("0" + (id + 1)) : (id + 1 + string.Empty)) + ".png";
			mImage mImage2 = mImage.createImage(url);
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 4000));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 4000));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImageQuestItem(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageQuestItem.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageQuestItem.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/iconq/" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 5000));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 5000));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImageMaterial(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageMaterial.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageMaterial.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/material/" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 5500));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 5500));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImageSkill(short id)
	{
		MainImage mainImage = (MainImage)Skill.hashImageSkill.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Skill.hashImageSkill.put(string.Empty + id, mainImage);
			string url = ((id >= 10) ? ("/resLocal/skill/iconSkill_" + id + ".png") : ("/resLocal/skill/iconSkill_0" + id + ".png"));
			mImage mImage2 = mImage.createImage(url);
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 6000));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 6000));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImageIconClan(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageIconClan.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageIconClan.put(string.Empty + id, mainImage);
			string url = "/resLocal/iconclan/" + id + ".png";
			if (id >= 500)
			{
				int num = id - 500;
				url = "/resLocal/iconclan/shop/" + num + ".png";
			}
			mImage mImage2 = mImage.createImage(url);
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 7000));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		else if (!GameCanvas.isTouch)
		{
			mainImage.count = (int)(GameCanvas.timeNow / 1000);
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 7000));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImageIconArCheClan(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageIconArcheClan.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageIconArcheClan.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/iconclan/huyhieu/" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 9500));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 9500));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static MainImage getImageIconPet(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImagePetIcon.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImagePetIcon.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/pet/icon/icon_pet_" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 10000));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		return mainImage;
	}

	public static MainImage getImagePet(short id)
	{
		MainImage mainImage = (MainImage)Pet.HashImagePet.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Pet.HashImagePet.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/pet/" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 10200));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 10200));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	public static mImage getFromRms(short id)
	{
		mImage result = null;
		sbyte[] array = null;
		string text = "image" + id;
		if (setIdOK(id))
		{
			array = CRes.loadRMS(text);
		}
		if (array == null)
		{
			GlobalService.gI().load_image(id);
			return result;
		}
		try
		{
			return mImage.createImage(array, 0, array.Length, text);
		}
		catch (Exception)
		{
			GlobalService.gI().load_image(id);
			return null;
		}
	}

	public static bool setIdOK(short id)
	{
		if (TemMidlet.DIVICE != 0 || (id >= 4000 && id < 5000) || (id >= 3000 && id < 3500) || (id >= 6000 && id < 7000))
		{
			return true;
		}
		return false;
	}

	public static void setToRms(sbyte[] mimg, short id)
	{
		try
		{
			CRes.saveRMS("image" + id, mimg);
		}
		catch (Exception)
		{
		}
	}

	public static void checkDelHash(mHashTable hash)
	{
		IDictionaryEnumerator enumerator = hash.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string k = enumerator.Key.ToString();
			MainImage mainImage = (MainImage)hash.get(k);
			if (GameCanvas.timeNow / 1000 - mainImage.count > 300)
			{
				hash.remove(k);
			}
		}
	}

	public static MainImage getImageMount(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageMount.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageMount.put(string.Empty + id, mainImage);
			mImage mImage2 = mImage.createImage("/resLocal/mount/" + id + ".png");
			if (mImage2 == null)
			{
				mainImage.img = getFromRms((short)(id + 10700));
			}
			else
			{
				mainImage.img = mImage2;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image((short)(id + 10700));
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}
}
