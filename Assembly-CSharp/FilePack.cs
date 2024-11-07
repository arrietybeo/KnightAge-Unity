using System;

public class FilePack
{
	public const string wps = "/wps/";

	public const string weapon = "/weapon/";

	public static FilePack instance;

	public string[] fname;

	private int[] fpos;

	private int[] flen;

	private sbyte[] fullData;

	private int nFile;

	private string name;

	private sbyte[] code = new sbyte[13]
	{
		78, 103, 117, 121, 101, 110, 86, 97, 110, 77,
		105, 110, 104
	};

	private int codeLen;

	public static string[] charAvatar = new string[7] { "leg", "body", "head", "hat", "eye", "hair", "wing" };

	private DataInputStream file;

	public FilePack()
	{
		codeLen = code.Length;
	}

	public FilePack(string name, sbyte[] array)
	{
		int num = 0;
		int num2 = 0;
		this.name = name;
		if (array == null)
		{
			open();
		}
		else
		{
			openbyArray(array);
		}
		if (file == null)
		{
			instance = null;
			return;
		}
		try
		{
			nFile = encode(file.readUnsignedByte());
			fname = new string[nFile];
			fpos = new int[nFile];
			flen = new int[nFile];
			for (int i = 0; i < nFile; i++)
			{
				int num3 = encode(file.readByte());
				sbyte[] data = new sbyte[num3];
				file.read(ref data);
				encode(data);
				fname[i] = new string(mSystem.ToCharArray(data));
				fpos[i] = num;
				flen[i] = encode(file.readUnsignedShort());
				num += flen[i];
				num2 += flen[i];
			}
			fullData = new sbyte[num2];
			file.readFully(ref fullData);
			encode(fullData);
		}
		catch (Exception)
		{
			mSystem.outloi("loi FilePack 1");
		}
		close();
	}

	public static void reset()
	{
		if (instance != null)
		{
			instance.close();
		}
		instance = null;
		mSystem.gcc();
	}

	public static mImage getImg(string path)
	{
		return instance.loadImage(path + ".png");
	}

	public static void init(string path)
	{
		instance = new FilePack(path, null);
	}

	public static void initByArray(sbyte[] array)
	{
		instance = new FilePack(string.Empty, array);
	}

	private int encode(int i)
	{
		return i;
	}

	private void encode(sbyte[] bytes)
	{
		int num = bytes.Length;
		for (int i = 0; i < num; i++)
		{
			bytes[i] ^= code[i % codeLen];
		}
	}

	private void open()
	{
		file = new DataInputStream(name);
	}

	private void openbyArray(sbyte[] array)
	{
		file = new DataInputStream(array);
	}

	public void close()
	{
		try
		{
			if (file != null)
			{
				file.close();
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi FilePack 1");
		}
	}

	public sbyte[] loadFile(string fileName)
	{
		try
		{
			for (int i = 0; i < nFile; i++)
			{
				if (fname[i].CompareTo(fileName) == 0)
				{
					sbyte[] array = new sbyte[flen[i]];
					Array.Copy(fullData, fpos[i], array, 0, flen[i]);
					return array;
				}
			}
		}
		catch (Exception)
		{
			Cout.Log("File '" + fileName + "' not found!");
		}
		return null;
	}

	public mImage loadImage(string fileName)
	{
		for (int i = 0; i < nFile; i++)
		{
			if (fname[i].CompareTo(fileName) == 0)
			{
				return mImage.createImage(fullData, fpos[i], flen[i], fileName);
			}
		}
		return null;
	}

	public sbyte[] loadData(string name)
	{
		for (int i = 0; i < nFile; i++)
		{
			if (fname[i].CompareTo(name) == 0)
			{
				sbyte[] array = new sbyte[flen[i]];
				Array.Copy(fullData, fpos[i], array, 0, flen[i]);
				return array;
			}
		}
		return null;
	}

	public sbyte[] getBinaryFile(string name)
	{
		for (int i = 0; i < nFile; i++)
		{
			if (fname[i].CompareTo(name) == 0)
			{
				sbyte[] array = new sbyte[flen[i]];
				Array.Copy(fullData, fpos[i], array, 0, flen[i]);
				return array;
			}
		}
		mSystem.outloi("File '" + name + "' not found!");
		return null;
	}
}
