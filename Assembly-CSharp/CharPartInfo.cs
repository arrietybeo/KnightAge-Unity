using System;

public class CharPartInfo
{
	public static mHashTable hashImagePartChar = new mHashTable();

	public sbyte type;

	public short id;

	public long timeRemove;

	public long timeRe;

	public int[][] x;

	public int[][] y;

	public int[][] w;

	public int[][] h;

	public int[][] dx;

	public int[][] dy;

	public sbyte[] arrData;

	public mImage image;

	private int avxf;

	private int avyf;

	private int avx0;

	private int avy0;

	private int avw0;

	private int avh0;

	public static sbyte[][] PART_OF_FRAME = new sbyte[7][]
	{
		new sbyte[6] { 0, 0, 1, 2, 3, 4 },
		new sbyte[6] { 0, 0, 1, 2, 3, 4 },
		new sbyte[6],
		new sbyte[6],
		new sbyte[6],
		new sbyte[6],
		new sbyte[6] { 0, 1, 0, 1, 0, 1 }
	};

	public CharPartInfo(sbyte type, short id)
	{
		this.type = type;
		this.id = id;
		dx = mSystem.new_M_Int(4, 6);
		dy = mSystem.new_M_Int(4, 6);
		int value = 0;
		switch (type)
		{
		case 0:
		case 1:
			value = 5;
			break;
		case 2:
		case 3:
		case 4:
		case 5:
			value = 1;
			break;
		case 6:
			value = 2;
			break;
		}
		x = mSystem.new_M_Int(4, value);
		y = mSystem.new_M_Int(4, value);
		w = mSystem.new_M_Int(4, value);
		h = mSystem.new_M_Int(4, value);
		loadNew(type, id);
	}

	public void load(sbyte[] arr, int type, int Id)
	{
		FilePack.initByArray(arr);
		image = FilePack.getImg(Id + string.Empty);
		DataInputStream dataInputStream = new DataInputStream(FilePack.instance.loadData(Id + ".d"));
		FilePack.reset();
		avx0 = CRes.readSignByte(dataInputStream);
		avy0 = CRes.readSignByte(dataInputStream);
		avw0 = CRes.readSignByte(dataInputStream);
		avh0 = CRes.readSignByte(dataInputStream);
		avxf = CRes.readSignByte(dataInputStream);
		avyf = CRes.readSignByte(dataInputStream);
		try
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < x[i].Length; j++)
				{
					x[i][j] = dataInputStream.read();
					y[i][j] = dataInputStream.read();
					w[i][j] = dataInputStream.read();
					h[i][j] = dataInputStream.read();
				}
				for (int k = 0; k < 6; k++)
				{
					dx[i][k] = CRes.readSignByte(dataInputStream);
					dy[i][k] = CRes.readSignByte(dataInputStream);
				}
			}
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
			mSystem.outloi("loi CharPart 1");
		}
	}

	public void loadNew(sbyte type, short id)
	{
		if (mSystem.isImgLocal && timeRe == 0L)
		{
			timeRe = GameCanvas.timeNow;
			mImage mImage2 = null;
			try
			{
				mImage2 = mImage.createImage("/c/" + FilePack.charAvatar[type] + "/b" + id + "_" + FilePack.charAvatar[type] + ".png");
			}
			catch (Exception)
			{
				mImage2 = null;
			}
			if (mImage2 != null && mImage2.image != null)
			{
				DataInputStream dataInputStream = null;
				try
				{
					dataInputStream = mImage.openFile("/c/" + FilePack.charAvatar[type] + "/b" + id + "_" + FilePack.charAvatar[type] + "_data");
				}
				catch (Exception)
				{
				}
				if (dataInputStream != null)
				{
					image = mImage2;
					FilePack.reset();
					try
					{
						for (int i = 0; i < 3; i++)
						{
							for (int j = 0; j < x[i].Length; j++)
							{
								x[i][j] = dataInputStream.read();
								y[i][j] = dataInputStream.read();
								w[i][j] = dataInputStream.read();
								h[i][j] = dataInputStream.read();
							}
						}
						for (int k = 0; k < 4; k++)
						{
							for (int l = 0; l < 6; l++)
							{
								dx[k][l] = CRes.readSignByte(dataInputStream);
								dy[k][l] = CRes.readSignByte(dataInputStream);
							}
						}
						return;
					}
					catch (Exception)
					{
						return;
					}
				}
			}
		}
		MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)hashImagePartChar.get(type + "_" + id);
		if (mainImageDataPartChar == null)
		{
			timeRemove = GameCanvas.timeNow;
			mainImageDataPartChar = new MainImageDataPartChar();
			hashImagePartChar.put(type + "_" + id, mainImageDataPartChar);
			getFromRms(type, id);
		}
		else if (mainImageDataPartChar.img != null)
		{
			image = mainImageDataPartChar.img;
			DataInputStream dataInputStream2 = new DataInputStream(mainImageDataPartChar.isData);
			FilePack.reset();
			try
			{
				for (int m = 0; m < 3; m++)
				{
					for (int n = 0; n < x[m].Length; n++)
					{
						x[m][n] = dataInputStream2.read();
						y[m][n] = dataInputStream2.read();
						w[m][n] = dataInputStream2.read();
						h[m][n] = dataInputStream2.read();
					}
				}
				for (int num = 0; num < 4; num++)
				{
					for (int num2 = 0; num2 < 6; num2++)
					{
						dx[num][num2] = CRes.readSignByte(dataInputStream2);
						dy[num][num2] = CRes.readSignByte(dataInputStream2);
					}
				}
			}
			catch (Exception)
			{
				mSystem.outloi("loi CharPart 3");
			}
			hashImagePartChar.remove(mainImageDataPartChar);
		}
		else if ((GameCanvas.timeNow - timeRemove) / 1000 >= 15)
		{
			getFromRms(type, id);
		}
	}

	public void paint(mGraphics g, int xp, int yp, int dir, int frame)
	{
		try
		{
			if (type < 0)
			{
				return;
			}
			int num = dir;
			if (num > 2)
			{
				num = 2;
			}
			if (image != null && image.image != null)
			{
				int num2 = dx[dir][frame];
				int num3 = dy[dir][frame];
				if (dir > 2)
				{
					num2 = -dx[num][frame] - w[num][PART_OF_FRAME[type][frame]];
					num3 = dy[num][frame];
				}
				g.drawRegion(image, x[num][PART_OF_FRAME[type][frame]], y[num][PART_OF_FRAME[type][frame]], w[num][PART_OF_FRAME[type][frame]], h[num][PART_OF_FRAME[type][frame]], (dir > 2) ? 2 : 0, xp + num2, yp + num3, 0, mGraphics.isTrue);
				timeRemove = GameCanvas.timeNow;
			}
			else
			{
				loadNew(type, id);
			}
		}
		catch (Exception)
		{
			mSystem.println("loi paint CharPartInfo: " + id);
		}
	}

	public void paintShow(mGraphics g, int xp, int yp, int dir, int frame)
	{
		if (type >= 0)
		{
			int num = dir;
			if (num > 2)
			{
				num = 2;
			}
			if (image != null && image.image != null)
			{
				g.drawRegion(image, x[num][PART_OF_FRAME[type][frame]], y[num][PART_OF_FRAME[type][frame]], w[num][PART_OF_FRAME[type][frame]], h[num][PART_OF_FRAME[type][frame]], (dir > 2) ? 2 : 0, xp + dx[dir][frame], yp - h[num][PART_OF_FRAME[type][frame]] / 2, 0, mGraphics.isTrue);
				timeRemove = GameCanvas.timeNow;
			}
			else
			{
				loadNew(type, id);
				g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, xp, yp, 3, mGraphics.isTrue);
			}
		}
	}

	public void paintAvatar(mGraphics g, short xp, short yp, int frame)
	{
		if (image != null && image.image != null)
		{
			g.drawRegion(image, avx0, avy0, avw0, avh0, 0, xp + avxf, yp + avyf, 0, mGraphics.isTrue);
		}
	}

	public void getFromRms(sbyte type, short id)
	{
		if (TemMidlet.DIVICE == 0)
		{
			timeRemove = GameCanvas.timeNow;
			GlobalService.gI().load_image_data_part_char(type, id);
			return;
		}
		string text = "img_data_char_" + type + "_" + id;
		sbyte[] array = CRes.loadRMS(text);
		if (array == null)
		{
			timeRemove = GameCanvas.timeNow;
			GlobalService.gI().load_image_data_part_char(type, id);
			return;
		}
		sbyte[] data;
		sbyte[] data2;
		try
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			dataInputStream.readShort();
			int num = dataInputStream.readInt();
			data = new sbyte[num];
			dataInputStream.read(ref data);
			short num2 = dataInputStream.readShort();
			data2 = new sbyte[num2];
			dataInputStream.read(ref data2);
		}
		catch (Exception)
		{
			return;
		}
		mImage img = mImage.createImage(data, 0, 0, text);
		MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)hashImagePartChar.get(type + "_" + id);
		if (mainImageDataPartChar == null)
		{
			mainImageDataPartChar = new MainImageDataPartChar(img, data2);
			hashImagePartChar.put(type + "_" + id, mainImageDataPartChar);
		}
		else
		{
			mainImageDataPartChar.img = img;
			mainImageDataPartChar.isData = data2;
		}
	}
}
