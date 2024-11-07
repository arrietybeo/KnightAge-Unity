using System;
using System.Text;
using UnityEngine;

public class mSystem
{
	public static mVector totalImageMap = new mVector();

	public static bool isMaHoa = false;

	public static bool isIP_GDX = false;

	public static bool isIP_TrucTiep = false;

	public static bool isj2me = false;

	public static int dyCharStep = 0;

	public static bool isImgLocal = false;

	public static sbyte INDEX_SV_GLOBAL = 2;

	public static bool isIphone = false;

	public static bool isWinphone = false;

	public static bool isHideNaptien()
	{
		return false;
	}

	public static void mDebug(string s)
	{
		Debug.LogWarning(s);
	}

	public static string getLong()
	{
		return string.Empty;
	}

	public static string getLat()
	{
		return string.Empty;
	}

	public static void doChangeMenuNapapple()
	{
	}

	public static void println(string str)
	{
	}

	public static void arraycopy(sbyte[] scr, int scrPos, sbyte[] dest, int destPos, int lenght)
	{
		Array.Copy(scr, scrPos, dest, destPos, lenght);
	}

	public static void arrayReplace(sbyte[] scr, int scrPos, ref sbyte[] dest, int destPos, int lenght)
	{
		if (scr != null && dest != null && scrPos + lenght <= scr.Length)
		{
			sbyte[] array = new sbyte[dest.Length + lenght];
			for (int i = 0; i < destPos; i++)
			{
				array[i] = dest[i];
			}
			for (int j = destPos; j < destPos + lenght; j++)
			{
				array[j] = scr[scrPos + j - destPos];
			}
			for (int k = destPos + lenght; k < array.Length; k++)
			{
				array[k] = dest[destPos + k - lenght];
			}
		}
	}

	public static long currentTimeMillis()
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		return (DateTime.UtcNow.Ticks - dateTime.Ticks) / 10000;
	}

	public static void freeData()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	public static sbyte[] convertToSbyte(byte[] scr)
	{
		sbyte[] array = new sbyte[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			array[i] = (sbyte)scr[i];
		}
		return array;
	}

	public static sbyte[] convertToSbyte(string scr)
	{
		ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
		byte[] bytes = aSCIIEncoding.GetBytes(scr);
		return convertToSbyte(bytes);
	}

	public static byte[] convetToByte(sbyte[] scr)
	{
		byte[] array = new byte[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			if (scr[i] > 0)
			{
				array[i] = (byte)scr[i];
			}
			else
			{
				array[i] = (byte)(scr[i] + 256);
			}
		}
		return array;
	}

	public static char[] ToCharArray(sbyte[] scr)
	{
		char[] array = new char[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			array[i] = (char)scr[i];
		}
		return array;
	}

	public static int currentHour()
	{
		return DateTime.Now.Hour;
	}

	public static void gcc()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	public static void outloi(string str)
	{
		Cout.Log(str);
	}

	public static void outz(string str)
	{
		Cout.Log(str);
	}

	public static void setDataArrInt(ref int[][] data, int Length)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new int[Length];
		}
	}

	public static void setDataArrInt(ref int[][][] data, int Length1, int Length2)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new int[Length1][];
			for (int j = 0; j < data[i].Length; j++)
			{
				data[i][j] = new int[Length2];
			}
		}
	}

	public static void setDataArrByte(ref sbyte[][] data, int Length)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new sbyte[Length];
		}
	}

	public static void setDataArrByte(ref sbyte[][][] data, int Length1, int Length2)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new sbyte[Length1][];
			for (int j = 0; j < data[i].Length; j++)
			{
				data[i][j] = new sbyte[Length2];
			}
		}
	}

	public static void setDataArrShort(ref short[][] data, int Length)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new short[Length];
		}
	}

	public static void setDataArrShort(ref short[][][] data, int Length1, int Length2)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new short[Length1][];
			for (int j = 0; j < data[i].Length; j++)
			{
				data[i][j] = new short[Length2];
			}
		}
	}

	public static void my_Gc()
	{
		gcc();
	}

	public static int[][] new_M_Int(int value1, int value2)
	{
		int[][] array = new int[value1][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new int[value2];
		}
		return array;
	}

	public static string[][] new_M_String(int value1, int value2)
	{
		string[][] array = new string[value1][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new string[value2];
		}
		return array;
	}

	public static sbyte[][] new_M_Byte(int value1, int value2)
	{
		sbyte[][] array = new sbyte[value1][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new sbyte[value2];
		}
		return array;
	}

	public static sbyte[][][] new_M_Byte(int value1, int value2, int value3)
	{
		sbyte[][][] array = new sbyte[value1][][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new sbyte[value2][];
			for (int j = 0; j < value2; j++)
			{
				array[i][j] = new sbyte[value3];
			}
		}
		return array;
	}

	public static string substring(string scr, int startIndex, int lenght)
	{
		try
		{
			if (scr == null)
			{
				return string.Empty;
			}
			return scr.Substring(startIndex, lenght - startIndex);
		}
		catch (Exception)
		{
			return scr.Substring(startIndex, 0);
		}
	}

	public static int getTotalColumOrRow(int wh)
	{
		int num = 256 * mGraphics.zoomLevel;
		if (wh <= num)
		{
			return 1;
		}
		int num2 = wh / num;
		int num3 = wh % num;
		if (num3 == 0)
		{
			return num2;
		}
		if (num3 != 0)
		{
			return num2 + 1;
		}
		return 0;
	}

	public static mImage loadImageByPNG(string path, ref int timeRemove, ref bool isLoadOK)
	{
		try
		{
			Cout.LogError2(" LOAD IMAGE --------------------");
			Texture2D texture2D = Resources.Load<Texture2D>(path);
			mImage mImage2 = new mImage();
			mImage2.image.texture = texture2D;
			mImage2.image.w = texture2D.width;
			mImage2.image.h = texture2D.height;
			timeRemove = (int)(currentTimeMillis() / 1000);
			isLoadOK = true;
			return mImage2;
		}
		catch (Exception ex)
		{
			Cout.LogError2(" Loi load imgSprite " + ex.ToString() + " !! " + path);
			return null;
		}
	}

	public static void loadImageMap(int w, int h, int idMap)
	{
		Cout.LogError2(" LOAD MAP-----------------------BEGIN " + idMap);
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
		for (int i = 0; i < totalImageMap.size(); i++)
		{
			ItemMapSprite itemMapSprite = (ItemMapSprite)totalImageMap.elementAt(i);
			if (itemMapSprite != null && itemMapSprite.img != null)
			{
				if (itemMapSprite.img.image != null)
				{
					itemMapSprite.img.image.texture = null;
					itemMapSprite.img.image = null;
				}
				itemMapSprite = null;
			}
		}
		totalImageMap.removeAllElements();
		gcc();
		int totalColumOrRow = getTotalColumOrRow(w);
		int totalColumOrRow2 = getTotalColumOrRow(h);
		int num = totalColumOrRow * totalColumOrRow2;
		for (int j = 0; j < num; j++)
		{
			ItemMapSprite itemMapSprite2 = new ItemMapSprite();
			string text = ((j >= 9) ? "/m_" : "/m_0");
			itemMapSprite2.path = "ImageMap/x" + mGraphics.zoomLevel + "/map" + idMap + text + (j + 1);
			int num2 = 256 * mGraphics.zoomLevel;
			if (j % totalColumOrRow * num2 <= w - num2)
			{
				itemMapSprite2.wimg = num2;
			}
			else
			{
				itemMapSprite2.wimg = w - num2 * (j % totalColumOrRow);
			}
			if (j / totalColumOrRow * num2 <= h - num2)
			{
				itemMapSprite2.himg = num2;
			}
			else
			{
				itemMapSprite2.himg = h - num2 * (j / totalColumOrRow);
			}
			itemMapSprite2.x = j % totalColumOrRow * 256;
			itemMapSprite2.y = j / totalColumOrRow * 256;
			totalImageMap.addElement(itemMapSprite2);
		}
		Cout.LogError2(" LOAD MAP-----------------------END");
	}

	public static byte[] getByteArray(Image img)
	{
		try
		{
			return img.texture.EncodeToPNG();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static string[] split(string original, string separator)
	{
		mVector mVector3 = new mVector();
		for (int num = original.IndexOf(separator); num >= 0; num = original.IndexOf(separator))
		{
			mVector3.addElement(original.Substring(0, num));
			original = original.Substring(num + separator.Length);
		}
		mVector3.addElement(original);
		string[] array = new string[mVector3.size()];
		if (mVector3.size() > 0)
		{
			for (int i = 0; i < mVector3.size(); i++)
			{
				array[i] = (string)mVector3.elementAt(i);
			}
		}
		return array;
	}

	public static string getPackageName()
	{
		return string.Empty;
	}

	public static void doSetWpLinkIp()
	{
	}
}
