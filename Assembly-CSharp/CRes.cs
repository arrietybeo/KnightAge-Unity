using System;

public class CRes
{
	public const int LEG = 0;

	public const int BODY = 1;

	public const int HEAD = 2;

	public const int HAT = 3;

	public const int EYE = 4;

	public const int HAIR = 5;

	public const int WING = 6;

	private static short[] sinz = new short[91]
	{
		0, 18, 36, 54, 71, 89, 107, 125, 143, 160,
		178, 195, 213, 230, 248, 265, 282, 299, 316, 333,
		350, 367, 384, 400, 416, 433, 449, 465, 481, 496,
		512, 527, 543, 558, 573, 587, 602, 616, 630, 644,
		658, 672, 685, 698, 711, 724, 737, 749, 761, 773,
		784, 796, 807, 818, 828, 839, 849, 859, 868, 878,
		887, 896, 904, 912, 920, 928, 935, 943, 949, 956,
		962, 968, 974, 979, 984, 989, 994, 998, 1002, 1005,
		1008, 1011, 1014, 1016, 1018, 1020, 1022, 1023, 1023, 1024,
		1024
	};

	public static mHashTable hashWeapon = new mHashTable();

	private static short[] cosz;

	private static int[] tanz;

	private static int value = 1;

	public static MyRandom r = new MyRandom();

	public static mVector quanao = new mVector();

	public static CharPartInfo[][] charPartInfo = new CharPartInfo[7][];

	public static WPSplashInfo[][][] wpSplashInfos = new WPSplashInfo[4][][];

	public static LoadData load = new LoadData();

	public static void init()
	{
		cosz = new short[91];
		tanz = new int[91];
		for (int i = 0; i <= 90; i++)
		{
			cosz[i] = sinz[90 - i];
			if (cosz[i] == 0)
			{
				tanz[i] = int.MaxValue;
			}
			else
			{
				tanz[i] = (sinz[i] << 10) / cosz[i];
			}
		}
		for (int j = 0; j < charPartInfo.Length; j++)
		{
			charPartInfo[j] = new CharPartInfo[256];
		}
		for (int k = 0; k < wpSplashInfos.Length; k++)
		{
			wpSplashInfos[k] = new WPSplashInfo[5][];
			for (int l = 0; l < wpSplashInfos[k].Length; l++)
			{
				wpSplashInfos[k][l] = new WPSplashInfo[3];
			}
		}
	}

	public static int sin(int a)
	{
		if (a >= 0 && a < 90)
		{
			return sinz[a];
		}
		if (a >= 90 && a < 180)
		{
			return sinz[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return -sinz[a - 180];
		}
		return -sinz[360 - a];
	}

	public static int cos(int a)
	{
		if (a >= 0 && a < 90)
		{
			return cosz[a];
		}
		if (a >= 90 && a < 180)
		{
			return -cosz[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return -cosz[a - 180];
		}
		return cosz[360 - a];
	}

	public static int tan(int a)
	{
		if (a >= 0 && a < 90)
		{
			return tanz[a];
		}
		if (a >= 90 && a < 180)
		{
			return -tanz[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return tanz[a - 180];
		}
		return -tanz[360 - a];
	}

	public static int atan(int a)
	{
		for (int i = 0; i <= 90; i++)
		{
			if (tanz[i] >= a)
			{
				return i;
			}
		}
		return 0;
	}

	public static int angle(int dx, int dy)
	{
		int num;
		if (dx != 0)
		{
			int a = Math.abs((dy << 10) / dx);
			num = atan(a);
			if (dy >= 0 && dx < 0)
			{
				num = 180 - num;
			}
			if (dy < 0 && dx < 0)
			{
				num = 180 + num;
			}
			if (dy < 0 && dx >= 0)
			{
				num = 360 - num;
			}
		}
		else
		{
			num = ((dy <= 0) ? 270 : 90);
		}
		return num;
	}

	public static int fixangle(int angle)
	{
		if (angle >= 360)
		{
			angle %= 360;
		}
		if (angle < 0)
		{
			angle = 360 + angle % 360;
		}
		return angle;
	}

	public static int subangle(int a1, int a2)
	{
		int num = a2 - a1;
		if (num < -180)
		{
			return num + 360;
		}
		if (num > 180)
		{
			return num - 360;
		}
		return num;
	}

	public static int abs(int a)
	{
		if (a < 0)
		{
			return -a;
		}
		return a;
	}

	public static int random(int a)
	{
		return r.nextInt(a);
	}

	public static int random_Am_0(int a)
	{
		int num = 0;
		return ((r.nextInt(2) == 0) ? 1 : (-1)) * r.nextInt(a) + 1;
	}

	public static int random_Am(int a, int b)
	{
		int num = a + r.nextInt(b - a);
		if (random(2) == 0)
		{
			num = -num;
		}
		return num;
	}

	public static int random(int a, int b)
	{
		return a + r.nextInt(b - a);
	}

	public static int sqrt(int a)
	{
		if (a <= 0)
		{
			return 0;
		}
		int num = (a + 1) / 2;
		int num2;
		do
		{
			num2 = num;
			num = num / 2 + a / (2 * num);
		}
		while (Math.abs(num2 - num) > 1);
		return num;
	}

	public static float sqrt(float a)
	{
		if (a <= 0f)
		{
			return 0f;
		}
		float num = (a + 1f) / 2f;
		float num2;
		do
		{
			num2 = num;
			num = num / 2f + a / (2f * num);
		}
		while (Math.abs(num2 - num) > 1f);
		return num;
	}

	public static int setDis(int x1, int y1, int x2, int y2)
	{
		return abs(x1 - x2) + abs(y1 - y2);
	}

	public static void quickSort(mVector actors)
	{
		recQuickSort(actors, 0, actors.size() - 1);
	}

	private static void recQuickSort(mVector actors, int left, int right)
	{
		try
		{
			if (right - left > 0)
			{
				MainObject mainObject = (MainObject)actors.elementAt(right);
				int ySort = mainObject.ySort;
				int num = partitionIt(actors, left, right, ySort);
				recQuickSort(actors, left, num - 1);
				recQuickSort(actors, num + 1, right);
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 1");
		}
	}

	private static int partitionIt(mVector actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		try
		{
			while (true)
			{
				if (((MainObject)actors.elementAt(++num)).ySort >= pivot)
				{
					while (num2 > 0 && ((MainObject)actors.elementAt(--num2)).ySort > pivot)
					{
					}
					if (num >= num2)
					{
						break;
					}
					swap(actors, num, num2);
				}
			}
			swap(actors, num, right);
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 2");
		}
		return num;
	}

	private static void swap(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		if (((MainObject)actors.elementAt(dex2)).ySort != ((MainObject)actors.elementAt(dex1)).ySort)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	public static void quickSort1(mVector actors)
	{
		recQuickSort1(actors, 0, actors.size() - 1);
	}

	private static void recQuickSort1(mVector actors, int left, int right)
	{
		try
		{
			if (right - left > 0)
			{
				MainItemMap mainItemMap = (MainItemMap)actors.elementAt(right);
				int y = mainItemMap.y;
				int num = partitionIt1(actors, left, right, y);
				recQuickSort1(actors, left, num - 1);
				recQuickSort1(actors, num + 1, right);
			}
		}
		catch (Exception)
		{
			mSystem.println("loi Cres 1");
		}
	}

	private static int partitionIt1(mVector actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		try
		{
			while (true)
			{
				if (((MainItemMap)actors.elementAt(++num)).y >= pivot)
				{
					while (num2 > 0 && ((MainItemMap)actors.elementAt(--num2)).y > pivot)
					{
					}
					if (num >= num2)
					{
						break;
					}
					swap1(actors, num, num2);
				}
			}
			swap1(actors, num, right);
		}
		catch (Exception)
		{
			mSystem.println("loi Cres 2");
		}
		return num;
	}

	private static void swap1(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		if (((MainItemMap)actors.elementAt(dex2)).y != ((MainItemMap)actors.elementAt(dex1)).y)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	public static void quickSort(MainItemMap[] actors)
	{
		recQuickSort(actors, 0, actors.Length - 1);
	}

	private static void recQuickSort(MainItemMap[] actors, int left, int right)
	{
		try
		{
			if (right - left > 0)
			{
				int y = actors[right].y;
				int num = partitionIt(actors, left, right, y);
				recQuickSort(actors, left, num - 1);
				recQuickSort(actors, num + 1, right);
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 3");
		}
	}

	private static int partitionIt(MainItemMap[] actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		try
		{
			while (true)
			{
				if (actors[++num].y >= pivot)
				{
					while (num2 > 0 && actors[--num2].y > pivot)
					{
					}
					if (num >= num2)
					{
						break;
					}
					swap(actors, num, num2);
				}
			}
			swap(actors, num, right);
		}
		catch (Exception)
		{
			mSystem.outloi("LOI PAINT partitionIt TRONG UTIL");
		}
		return num;
	}

	private static void swap(MainItemMap[] actors, int dex1, int dex2)
	{
		MainItemMap mainItemMap = actors[dex2];
		if (actors[dex2].y != actors[dex1].y)
		{
			actors[dex2] = actors[dex1];
			actors[dex1] = mainItemMap;
		}
	}

	public static MainInfoItem[] selectionSort(MainInfoItem[] arr)
	{
		int num = arr.Length;
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if (arr[j].id < arr[num2].id)
				{
					num2 = j;
				}
			}
			if (num2 != i)
			{
				MainInfoItem mainInfoItem = arr[i];
				arr[i] = arr[num2];
				arr[num2] = mainInfoItem;
			}
		}
		return arr;
	}

	public static mVector selectionSortIDSkill(mVector arr)
	{
		int num = arr.size();
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if (((Skill)arr.elementAt(j)).Id < ((Skill)arr.elementAt(num2)).Id)
				{
					num2 = j;
				}
			}
			if (num2 != i)
			{
				swapSkill(arr, i, num2);
			}
		}
		return arr;
	}

	public static mVector selectionSortSkill(mVector arr)
	{
		int num = arr.size();
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if (((Skill)arr.elementAt(j)).lvMin < ((Skill)arr.elementAt(num2)).lvMin)
				{
					num2 = j;
				}
			}
			if (num2 != i)
			{
				swapSkill(arr, i, num2);
			}
		}
		return arr;
	}

	private static void swapSkill(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		if (((Skill)actors.elementAt(dex2)).lvMin != ((Skill)actors.elementAt(dex1)).lvMin)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	public static mVector selectionSortInven(mVector arr)
	{
		int num = arr.size();
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if (((MainItem)arr.elementAt(j)).IndexSort < ((MainItem)arr.elementAt(num2)).IndexSort)
				{
					num2 = j;
				}
			}
			if (num2 != i)
			{
				swapItem(arr, i, num2);
			}
		}
		return arr;
	}

	private static void swapItem(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		actors.setElementAt(actors.elementAt(dex1), dex2);
		actors.setElementAt(obj, dex1);
	}

	public static int readSignByte(DataInputStream iss)
	{
		sbyte[] data = new sbyte[1];
		try
		{
			iss.r.read(ref data, 0, 1);
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 5");
		}
		return data[0];
	}

	public static void setRemoveCharPartInfo()
	{
		if (charPartInfo == null)
		{
			return;
		}
		for (int i = 0; i < charPartInfo.Length; i++)
		{
			for (int j = 0; j < charPartInfo[i].Length; j++)
			{
				if (charPartInfo[i][j] != null && (GameCanvas.timeNow - charPartInfo[i][j].timeRemove) / 1000 > ((TemMidlet.DIVICE != 0) ? 300 : 60))
				{
					charPartInfo[i][j] = null;
				}
			}
		}
	}

	public static CharPartInfo getCharPartInfo(int type, int id)
	{
		if (charPartInfo[type][id] == null)
		{
			charPartInfo[type][id] = new CharPartInfo((sbyte)type, (short)id);
		}
		return charPartInfo[type][id];
	}

	public static void getImgWeaPone(int claz, int i, int j)
	{
		try
		{
			MainObject.imgWeapone[claz][i][j] = new WeaponInfo();
			if (mSystem.isImgLocal)
			{
				string[] array = new string[4] { "kiem/", "songkiem/", "phapsu/", "sung/" };
				mImage mImage2 = null;
				try
				{
					mImage2 = mImage.createImage("/weapon/" + array[claz] + i + ".img");
				}
				catch (Exception)
				{
				}
				if (mImage2 != null && mImage2.image != null)
				{
					DataInputStream dataInputStream = null;
					try
					{
						dataInputStream = mImage.openFile("/weapon/" + array[claz] + i + "_data");
					}
					catch (Exception)
					{
					}
					if (dataInputStream != null)
					{
						MainObject.imgWeapone[claz][i][j].img = mImage2;
						for (int k = 0; k < 4; k++)
						{
							for (int l = 0; l < 3; l++)
							{
								MainObject.imgWeapone[claz][i][j].mPos[k][l][0] = (sbyte)dataInputStream.read();
								MainObject.imgWeapone[claz][i][j].mPos[k][l][1] = (sbyte)dataInputStream.read();
							}
							MainObject.imgWeapone[claz][i][j].mRegion[k][0] = (sbyte)dataInputStream.read();
							MainObject.imgWeapone[claz][i][j].mRegion[k][1] = (sbyte)dataInputStream.read();
						}
						MainObject.imgWeapone[claz][i][j].himg = mImage.getImageHeight(MainObject.imgWeapone[claz][i][j].img.image);
						return;
					}
				}
			}
			MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)hashWeapon.get(claz + "_" + i);
			if (mainImageDataPartChar == null)
			{
				mainImageDataPartChar = new MainImageDataPartChar();
				hashWeapon.put(claz + "_" + i, mainImageDataPartChar);
				mainImageDataPartChar.timeImageNull = GameCanvas.timeNow;
				getFromRms((sbyte)claz, (short)i);
				MainObject.imgWeapone[claz][i][j] = null;
			}
			else if (mainImageDataPartChar.img != null)
			{
				MainObject.imgWeapone[claz][i][j].img = mainImageDataPartChar.img;
				DataInputStream dataInputStream2 = new DataInputStream(mainImageDataPartChar.isData);
				FilePack.reset();
				try
				{
					for (int m = 0; m < 4; m++)
					{
						for (int n = 0; n < 3; n++)
						{
							MainObject.imgWeapone[claz][i][j].mPos[m][n][0] = (sbyte)dataInputStream2.read();
							MainObject.imgWeapone[claz][i][j].mPos[m][n][1] = (sbyte)dataInputStream2.read();
						}
						MainObject.imgWeapone[claz][i][j].mRegion[m][0] = (sbyte)dataInputStream2.read();
						MainObject.imgWeapone[claz][i][j].mRegion[m][1] = (sbyte)dataInputStream2.read();
					}
					MainObject.imgWeapone[claz][i][j].himg = mImage.getImageHeight(MainObject.imgWeapone[claz][i][j].img.image);
				}
				catch (Exception)
				{
				}
				hashWeapon.remove(mainImageDataPartChar);
			}
			else if ((GameCanvas.timeNow - mainImageDataPartChar.timeImageNull) / 1000 >= 15)
			{
				getFromRms((sbyte)claz, (short)i);
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 7");
		}
		FilePack.reset();
	}

	public static void getFromRms(sbyte type, short id)
	{
		MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)hashWeapon.get(type + "_" + id);
		if (TemMidlet.DIVICE == 0)
		{
			if (mainImageDataPartChar != null)
			{
				mainImageDataPartChar.timeImageNull = GameCanvas.timeNow;
			}
			GlobalService.gI().load_image_data_part_char((sbyte)(type + 50), id);
			return;
		}
		string text = "img_data_char_" + (type + 50) + "_" + id;
		sbyte[] array = loadRMS(text);
		if (array == null)
		{
			if (mainImageDataPartChar != null)
			{
				mainImageDataPartChar.timeImageNull = GameCanvas.timeNow;
			}
			GlobalService.gI().load_image_data_part_char((sbyte)(type + 50), id);
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
		if (mainImageDataPartChar == null)
		{
			mainImageDataPartChar = new MainImageDataPartChar(img, data2);
			hashWeapon.put(type + "_" + id, mainImageDataPartChar);
		}
		else
		{
			mainImageDataPartChar.img = img;
			mainImageDataPartChar.isData = data2;
		}
	}

	public static WPSplashInfo GetWPSplashInfo(int claz, int i, int j)
	{
		try
		{
			string[] array = new string[4] { "kiem/", "songkiem/", "phapsu/", "sung/" };
			wpSplashInfos[claz][i][j] = new WPSplashInfo();
			wpSplashInfos[claz][i][j].image = mImage.createImage("/wps/" + array[claz] + i + ".img");
			DataInputStream dataInputStream = mImage.openFile("/wps/" + array[claz] + i + "_data");
			if (dataInputStream != null)
			{
				for (int k = 0; k < 4; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						wpSplashInfos[claz][i][j].P0_X[k][l] = dataInputStream.read();
						wpSplashInfos[claz][i][j].P0_Y[k][l] = dataInputStream.read();
						wpSplashInfos[claz][i][j].PF_X[k][l] = readSignByte(dataInputStream);
						wpSplashInfos[claz][i][j].PF_Y[k][l] = readSignByte(dataInputStream);
						wpSplashInfos[claz][i][j].PF_W[k][l] = dataInputStream.read();
						wpSplashInfos[claz][i][j].PF_H[k][l] = dataInputStream.read();
					}
				}
			}
			FilePack.reset();
		}
		catch (Exception)
		{
			wpSplashInfos[claz][i][j] = null;
			mSystem.outloi("loi Cres 8");
		}
		return wpSplashInfos[claz][i][j];
	}

	public static WeaponInfo loadImgWeaPone(int i, int j, int index)
	{
		if (MainObject.imgWeapone[i][j][index] == null)
		{
			load.loadImgWeaPone(i, j, index);
		}
		return MainObject.imgWeapone[i][j][index];
	}

	public static WPSplashInfo loadWpsPlash(int claz, int i, int j)
	{
		if (wpSplashInfos[i][j] == null)
		{
			load.loadWpsPlash(i, j);
		}
		return wpSplashInfos[claz][i][j];
	}

	public static byte[] encoding(byte[] array)
	{
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(~array[i]);
			}
		}
		return array;
	}

	public static void saveRMS(string name, sbyte[] data)
	{
		TemMidlet.saveRMS(name, data);
	}

	public static sbyte[] loadRMS(string name)
	{
		return TemMidlet.loadRMS(name);
	}

	public static bool CheckDelRMS(string str)
	{
		if (str.CompareTo("isLowDevice") == 0 || str.CompareTo("isQty") == 0 || str.CompareTo("user_pass") == 0 || (TemMidlet.DIVICE > 0 && str.Length >= 13 && str.Substring(0, 13).CompareTo("img_data_char") == 0) || str.CompareTo("isIndexPart") == 0 || str.CompareTo("isIndexServer") == 0)
		{
			return false;
		}
		return true;
	}

	public static void saveRMSName(sbyte ID, sbyte[] data)
	{
		GlobalService.gI().Save_RMS_Server(0, ID, data);
	}

	public static bool ktvc(int x1, int xw1, int x2, int xw2, int y1, int yh1, int y2, int yh2)
	{
		if (x1 > xw2 || xw1 < x2 || y1 > yh2 || yh1 < y2)
		{
			return false;
		}
		return true;
	}
}
