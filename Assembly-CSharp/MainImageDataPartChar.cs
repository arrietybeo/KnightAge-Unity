using System;
using System.IO;
public class MainImageDataPartChar
{
	public mImage img;

	public int count = -1;

	public sbyte type;

	public short id;

	public short version;

	public long timeImageNull;

	public sbyte[] isData;

	public sbyte[] isDataImg;

	public MainImageDataPartChar()
	{
	}

	public MainImageDataPartChar(sbyte[] issImg, sbyte[] iss, sbyte type, short id, short version)
	{
		isDataImg = issImg;
		count = 0;
		isData = iss;
		this.type = type;
		this.id = id;
		this.version = version;
		//if (issImg != null)
		//{
		//	using (FileStream fileStream = new FileStream(string.Concat(new object[]
		//	{
		//			"G://KnightAge//log//data//x", mGraphics.xlevel ,"//part//Img//", type + "_" +  this.GetPathName(type) + "//", type + "_" + id, ".png"
		//	}), FileMode.OpenOrCreate, FileAccess.ReadWrite))
		//	{
		//		int num78;
		//		for (int num77 = 0; num77 < issImg.Length; num77 = num78 + 1)
		//		{
		//			fileStream.WriteByte((byte)issImg[num77]);
		//			num78 = num77;
		//		}
		//	}
		//}
		//if (iss != null)
		//{
		//	String filePath = "G://KnightAge//log//data//x" + mGraphics.xlevel + "//part//Data//" + type + "_" + this.GetPathName(type) + "//" + type + "_" + id;
		//	//Debug.LogError(filePath);
		//	File.WriteAllBytes(filePath, Array.ConvertAll(iss, (sbyte a) => (byte)a));
		//}
	}


	public string GetPathName(sbyte type)
	{
		return type switch
		{
			0 => "leg",
			1 => "body",
			2 => "head",
			3 => "hat",
			4 => "eye",
			5 => "hair",
			6 => "wing",
			50 => "sword",
			51 => "dual_sword",
			52 => "mage_stick",
			53 => "gun",
			100 => "tile",
			101 => "tile_small",
			102 => "tile_water",
			110 => "effect",
			111 => "effect_auto",
			112 => "skill_effect",
			113 => "fashion",
			_ => "default"
		};
	}

	public MainImageDataPartChar(mImage img, sbyte[] iss)
	{
		this.img = img;
		count = 0;
		isData = iss;
	}

	public DataOutputStream getSaveData()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeShort(version);
			dataOutputStream.writeInt(isDataImg.Length);
			dataOutputStream.write(isDataImg);
			dataOutputStream.writeShort(isData.Length);
			dataOutputStream.write(isData);
		}
		catch (Exception)
		{
		}
		return dataOutputStream;
	}
}
