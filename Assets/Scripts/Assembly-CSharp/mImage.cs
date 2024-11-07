using System;

public class mImage
{
	public Image image = new Image();

	public static string getLink(string str)
	{
		str = Main.res + str;
		return str;
	}

	public static mImage createImage(string url)
	{
		bool flag = false;
		mImage mImage2 = new mImage();
		string empty = string.Empty;
		try
		{
			empty = Main.res + cutPng("/x" + mGraphics.zoomLevel + url);
			mImage2.image = Image.createImage(empty);
		}
		catch (Exception)
		{
			flag = true;
		}
		if (mImage2.image == null || flag)
		{
			return null;
		}
		return mImage2;
	}

	public static string cutPng(string str)
	{
		string result = str;
		if (str.Contains(".png"))
		{
			result = str.Replace(".png", string.Empty);
		}
		else if (str.Contains(".img"))
		{
			result = str.Replace(".img", string.Empty);
		}
		return result;
	}

	public static DataInputStream openFile(string path)
	{
		DataInputStream dataInputStream = null;
		return DataInputStream.getResourceAsStream(getLink(path));
	}

	public static mImage createImage(int w, int h)
	{
		mImage mImage2 = new mImage();
		mImage2.image = Image.createImage(w * mGraphics.zoomLevel, h * mGraphics.zoomLevel);
		return mImage2;
	}

	public static mImage createImage(sbyte[] data, int w, int h, string path)
	{
		mImage mImage2 = new mImage();
		mImage2.image = Image.createImage(data, 0, data.Length, path);
		return mImage2;
	}

	public TemGraphics getGraphics()
	{
		return new TemGraphics();
	}

	public static int getImageWidth(Image image)
	{
		return image.getWidth();
	}

	public static int getImageHeight(Image image)
	{
		return image.getHeight();
	}

	public void getRGB(int[] rgbData, int offset, int scanlength, int x, int y, int width, int height)
	{
	}

	public static mImage createRGBImage(int[] rgb, int width, int height, bool processAlpha)
	{
		mImage mImage2 = new mImage();
		mImage2.image = Image.createRGBImage(rgb, width, height, processAlpha);
		return mImage2;
	}

	public static mImage loadImageRMS(string path)
	{
		mImage mImage2 = null;
		Image image = null;
		try
		{
			sbyte[] array = Rms.loadRMS(path);
			if (array != null)
			{
				image = Image.createImage(array, 0, array.Length, path);
				array = null;
				mImage2 = new mImage();
				mImage2.image = image;
			}
		}
		catch (Exception)
		{
			return null;
		}
		return mImage2;
	}
}
