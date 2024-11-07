using System;
using System.Collections;

public class GameData
{
	public static int ID_START_SKILL = 0;

	private static GameData me;

	public static FrameImage imgSkillIcon;

	public static mVector imgHorse = new mVector();

	public static mHashTable listImgIcon = new mHashTable();

	private bool loadData;

	private static sbyte idWait = 0;

	public static GameData gI()
	{
		return (me != null) ? me : (me = new GameData());
	}

	public void getImage()
	{
		if (!loadData)
		{
			loadImgPotion();
			loadImgGemItem();
			loadData = true;
		}
	}

	public static void loadImgPotion()
	{
	}

	private static void createImgHorse(sbyte[] data, sbyte[][] header)
	{
	}

	public static void saveImgSkill(int ver, sbyte[] array)
	{
	}

	public static void saveImgGem(sbyte ver, sbyte[] array)
	{
	}

	public static void loadImgGemItem()
	{
	}

	public static void setIndexWait()
	{
	}

	public static ImageIcon getImgIcon(short id, int typeGet)
	{
		ImageIcon imageIcon = (ImageIcon)listImgIcon.get(id + string.Empty);
		int num = id - ID_START_SKILL;
		if (imageIcon == null)
		{
			imageIcon = new ImageIcon();
			imageIcon.id = id;
			imageIcon.isLoad = true;
			listImgIcon.put(id + string.Empty, imageIcon);
			if (imageIcon.img == null && id >= ID_START_SKILL)
			{
				try
				{
					imageIcon.img = mImage.createImage("/imgDataEff/" + num + ".png");
				}
				catch (Exception)
				{
				}
			}
			if (imageIcon.img == null && mSystem.currentTimeMillis() / 1000 - imageIcon.timeGetBack > 30)
			{
				GlobalService.gI().load_image_data_part_char((sbyte)typeGet, (short)num);
			}
		}
		else
		{
			imageIcon.timeRemove = GameCanvas.timeNow;
		}
		return imageIcon;
	}

	public static void RequestImgandData(short id, int typeGet)
	{
		ImageIcon imageIcon = (ImageIcon)listImgIcon.get(id + string.Empty);
		int num = id - ID_START_SKILL;
		if (imageIcon != null)
		{
			return;
		}
		imageIcon = new ImageIcon();
		imageIcon.id = id;
		imageIcon.isLoad = true;
		listImgIcon.put(id + string.Empty, imageIcon);
		if (imageIcon.img == null && id >= ID_START_SKILL)
		{
			try
			{
				imageIcon.img = mImage.createImage("/imgDataEff/" + num + ".png");
			}
			catch (Exception)
			{
			}
		}
		if (imageIcon.img == null && mSystem.currentTimeMillis() / 1000 - imageIcon.timeGetBack > 30)
		{
			GlobalService.gI().load_image_data_part_char((sbyte)typeGet, (short)num);
		}
		imageIcon.timeRemove = (int)(mSystem.currentTimeMillis() / 1000);
	}

	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = listImgIcon.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				ImageIcon imageIcon = (ImageIcon)listImgIcon.get(k);
				if ((GameCanvas.timeNow - imageIcon.timeRemove) / 1000 > ((TemMidlet.DIVICE != 0) ? 300 : 60))
				{
					listImgIcon.remove(k);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
