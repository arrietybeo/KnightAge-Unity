using System;

public class MainEffectAuto
{
	public static mHashTable hashTemEffAuto = new mHashTable();

	public mHashTable hashImage = new mHashTable();

	public MainFrameEff[] mFrame;

	public short[] mRunFrame;

	public MainEffectAuto(int id, sbyte[] datasv)
	{
		setEffAuto(id, datasv);
	}

	public void setEffAuto(int id, sbyte[] datasv)
	{
		try
		{
			DataInputStream dataInputStream = null;
			dataInputStream = ((datasv == null) ? mImage.openFile("/eff_" + id) : new DataInputStream(datasv));
			int num = dataInputStream.readUnsignedByte();
			for (int i = 0; i < num; i++)
			{
				MainPartImage mainPartImage = new MainPartImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
				hashImage.put(string.Empty + mainPartImage.ID, mainPartImage);
			}
			short num2 = dataInputStream.readShort();
			mFrame = new MainFrameEff[num2];
			for (int j = 0; j < num2; j++)
			{
				sbyte b = dataInputStream.readByte();
				mFrame[j] = new MainFrameEff();
				mFrame[j].mpart = new Part[b];
				for (int k = 0; k < b; k++)
				{
					mFrame[j].mpart[k] = new Part();
					mFrame[j].mpart[k].x = dataInputStream.readShort();
					mFrame[j].mpart[k].y = dataInputStream.readShort();
					mFrame[j].mpart[k].idPartImage = dataInputStream.readByte();
				}
			}
			short num3 = dataInputStream.readShort();
			mRunFrame = new short[num3];
			for (int l = 0; l < num3; l++)
			{
				mRunFrame[l] = dataInputStream.readShort();
			}
			dataInputStream.readByte();
			dataInputStream.readByte();
		}
		catch (Exception)
		{
		}
	}
}
