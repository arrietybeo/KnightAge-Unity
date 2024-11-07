using System;
using System.Collections;

public class ImageEffect
{
	public static mHashTable hashImageEff = new mHashTable();

	public static long lastTime = 0L;

	public long timeRemove;

	public int imageId;

	public mImage img;

	public ImageEffect(int Id)
	{
		imageId = Id;
		img = mImage.createImage("/eff/g" + Id + ".png");
		if (img == null || img.image == null)
		{
			img = getEffectImgFromRMS(Id);
		}
		timeRemove = GameCanvas.timeNow;
	}

	public ImageEffect()
	{
	}

	public ImageEffect(int Id, mImage image)
	{
		imageId = Id;
		img = image;
		timeRemove = GameCanvas.timeNow;
	}

	public static mImage getEffectImgFromRMS(int id)
	{
		mImage result = new mImage();
		lastTime = GameCanvas.timeNow;
		GlobalService.gI().load_image_data_part_char(110, (short)id);
		return result;
	}

	public static mImage setImage(int Id)
	{
		ImageEffect imageEffect = (ImageEffect)hashImageEff.get(string.Empty + Id);
		if (imageEffect == null)
		{
			imageEffect = new ImageEffect(Id);
			hashImageEff.put(string.Empty + Id, imageEffect);
		}
		else
		{
			imageEffect.timeRemove = GameCanvas.timeNow;
		}
		return imageEffect.img;
	}

	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = hashImageEff.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				ImageEffect imageEffect = (ImageEffect)hashImageEff.get(k);
				if ((GameCanvas.timeNow - imageEffect.timeRemove) / 1000 > ((TemMidlet.DIVICE != 0) ? 300 : 60))
				{
					hashImageEff.remove(k);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void SetRemoveAll()
	{
		hashImageEff.clear();
	}
}
