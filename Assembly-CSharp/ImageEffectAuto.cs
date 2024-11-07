using System;
using System.Collections;

public class ImageEffectAuto
{
	public static mHashTable hashImageEffAuto = new mHashTable();

	public long timeRemove;

	private int imageId;

	public mImage img;

	public ImageEffectAuto(int Id)
	{
		imageId = Id;
		img = mImage.createImage("/effauto/eff_" + Id + ".png");
		if (Id == 8 && img.image.getRealImageHeight() == 0 && img.image.getRealImageWidth() == 0)
		{
			img = null;
		}
		timeRemove = GameCanvas.timeNow;
	}

	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = hashImageEffAuto.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				ImageEffectAuto imageEffectAuto = (ImageEffectAuto)hashImageEffAuto.get(k);
				if ((GameCanvas.timeNow - imageEffectAuto.timeRemove) / 1000 > ((TemMidlet.DIVICE != 0) ? 300 : 60))
				{
					hashImageEffAuto.remove(k);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static mImage setImage(int Id)
	{
		ImageEffectAuto imageEffectAuto = (ImageEffectAuto)hashImageEffAuto.get(string.Empty + Id);
		if (imageEffectAuto == null)
		{
			imageEffectAuto = new ImageEffectAuto(Id);
			hashImageEffAuto.put(string.Empty + Id, imageEffectAuto);
			if (imageEffectAuto == null || imageEffectAuto.img == null)
			{
				GlobalService.gI().load_image_data_part_char(111, (short)Id);
			}
		}
		else
		{
			imageEffectAuto.timeRemove = GameCanvas.timeNow;
		}
		return imageEffectAuto.img;
	}

	public static mImage setImageMatna(int Id)
	{
		ImageEffectAuto imageEffectAuto = (ImageEffectAuto)hashImageEffAuto.get(string.Empty + Id);
		if (imageEffectAuto == null)
		{
			imageEffectAuto = new ImageEffectAuto(Id);
			hashImageEffAuto.put(string.Empty + Id, imageEffectAuto);
			if (imageEffectAuto == null || imageEffectAuto.img == null)
			{
				GlobalService.gI().load_image_data_part_char(7, (short)Id);
			}
		}
		else
		{
			imageEffectAuto.timeRemove = GameCanvas.timeNow;
		}
		return imageEffectAuto.img;
	}

	public static void SetRemoveAll()
	{
		hashImageEffAuto.clear();
	}
}
