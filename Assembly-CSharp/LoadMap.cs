using Newtonsoft.Json.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;

public class LoadMap
{
	public const int T_MAP_NULL = -1;

	public const int T_MAP_NORMAL = 0;

	public const int T_MAP_STAND = 1;

	public const int T_MAP_SLOW = 2;

	public static int MAP_NORMAL = 0;

	public static int MAP_THACH_DAU = 1;

	public static int MAP_PHO_BANG = 2;

	public static int MAP_PET_CONTAINER = 3;

	public static mVector vecMapItem = new mVector("LoadMap vecMapItem");

	public static mVector vecPointChange = new mVector("LoadMap vecPointChange");

	public static mVector mItemMap = new mVector("LoadMap mItemMap");

	public static int[] mTranPointChangeMap = new int[4] { 5, 4, 1, 0 };

	public int idMap;

	public int idMapMini;

	public int mapW;

	public int mapH;

	public int limitW;

	public int limitH;

	public int limitMap;

	public int maxX;

	public int maxY;

	public int maxWMap;

	public int maxHMap;

	public static sbyte isShowEffAuto = 0;

	public static sbyte EFF_NORMAL = 0;

	public static sbyte EFF_PHOBANG_END = 1;

	public static int idTile = -1;

	public string nameMap = string.Empty;

	public static int wTile = 24;

	public int[] mapPaint;

	public int[] mapType;

	public static int[] mStatusArea;

	public sbyte[][] mapFind;

	public static mImage imgTileWater;

	public static int timeVibrateScreen = 0;

	public static sbyte Area = 0;

	public static sbyte MaxArea = 10;

	public static sbyte typeMap = 0;

	public mImage itemLogin0;

	public mImage itemLogin1;

	public mImage itemLogin2;

	public static LoadMap me;

	private int fStand;

	private int fWater;

	private int fStartWater;

	private int fEndWater;

	public static mImage[] imgTileMap = new mImage[80];

	private float currentX;

	private float currentY;

	public static mVector Thacnuoc = new mVector("LoadMap Thacnuoc");

	public static Color[][][] colorMap = new Color[9][][];

	public static int[] totalTile = new int[17]
	{
		72, 60, 57, 64, 47, 43, 66, 61, 52, 51,
		61, 62, 67, 69, 59, 99, 99
	};

	public static MainItemMap[] mItemMapLogin = new MainItemMap[0];

	public int mapWLogin;

	public int mapHLogin;

	public int[] mapPaintLogin;

	public static int[] mapPaintLoginOld;

	public LoadMap()
	{
		maxX = GameCanvas.w / wTile + 1;
		maxY = GameCanvas.h / wTile + 1;
		load_Table_Map();
		me = this;
	}

	public static LoadMap get_Item()
	{
		return (me != null) ? me : (me = new LoadMap());
	}

	public bool mapLang()
	{
		return GameScreen.isMapLang;
	}

	public void load_Table_Map()
	{
		try
		{
			DataInputStream dataInputStream = mImage.openFile("/table_item");
			short num = dataInputStream.readShort();
			for (short num2 = 0; num2 < num; num2++)
			{
				short iDImage = dataInputStream.readShort();
				dataInputStream.readByte();
				short dx = dataInputStream.readShort();
				short dy = dataInputStream.readShort();
				sbyte b = dataInputStream.readByte();
				int[][] array = mSystem.new_M_Int(b, 2);
				for (int i = 0; i < b; i++)
				{
					array[i][0] = dataInputStream.readByte();
					array[i][1] = dataInputStream.readByte();
				}
				vecMapItem.addElement(new MainItemMap(num2, iDImage, dx, dy, array));
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi load map 1");
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	public static void load_Table_Map(sbyte[] tableItem)
	{
		try
		{
			vecMapItem.removeAllElements();
			DataInputStream dataInputStream = new DataInputStream(tableItem);
			short num = dataInputStream.readShort();
			for (short num2 = 0; num2 < num; num2++)
			{
				short iDImage = dataInputStream.readShort();
				dataInputStream.readByte();
				short dx = dataInputStream.readShort();
				short dy = dataInputStream.readShort();
				sbyte b = dataInputStream.readByte();
				int[][] array = mSystem.new_M_Int(b, 2);
				for (int i = 0; i < b; i++)
				{
					array[i][0] = dataInputStream.readByte();
					array[i][1] = dataInputStream.readByte();
				}
				vecMapItem.addElement(new MainItemMap(num2, iDImage, dx, dy, array));
               

				
            }
        }
        catch (Exception ex)
        {
            mSystem.outloi("loi load map 1");
            Cout.Log(" Loi Tai !!! : " + ex.ToString());
        }
    }

	public static void loadTileBig(int id, bool isLogin)
	{
		if ((isTileMoi() || !Main.isSprite || isLogin) && id >= 0)
		{
			resetDataImgTileBig();
			if (id <= 10)
			{
				imgTileMap = new mImage[MiniMap.totalTile[id]];
			}
			else
			{
				imgTileMap = new mImage[80];
			}
			if (id == 15)
			{
				imgTileMap = new mImage[100];
			}
			if (id == 16)
			{
				imgTileMap = new mImage[100];
			}
			for (int i = 0; i < imgTileMap.Length; i++)
			{
				string text = ((i >= 9) ? ("tile" + id + "_") : ("tile" + id + "_0"));
				mImage mImage2 = mImage.createImage("/Tile/tile" + id + "/" + text + (i + 1) + ".png");
				imgTileMap[i] = mImage2;
			}
			if (id == 1 || id == 9 || id == 10)
			{
				loadMapLoginPc(id);
			}
		}
	}

	public static void loadMapLoginPc(int id)
	{
		if (Main.imgTileMapLogin == null)
		{
			Main.imgTileMapLogin = new mImage[80];
		}
		for (int i = 0; i < imgTileMap.Length; i++)
		{
			string text = ((i >= 9) ? ("tile" + id + "_") : ("tile" + id + "_0"));
			if (Main.imgTileMapLogin[i] == null)
			{
				Main.imgTileMapLogin[i] = mImage.createImage("/Tile/tile" + id + "/" + text + (i + 1) + ".png");
			}
		}
	}

	public static void resetDataImgTileBig()
	{
		for (int i = 0; i < imgTileMap.Length; i++)
		{
			if (imgTileMap[i] != null && imgTileMap[i].image != null)
			{
				imgTileMap[i].image.texture = null;
				imgTileMap[i].image = null;
			}
		}
		mSystem.gcc();
	}

	public void loadmap(sbyte[] mbyte)
	{
		try
		{
			Thacnuoc.removeAllElements();
			DataInputStream dataInputStream = new DataInputStream(mbyte);
			mapW = dataInputStream.readByte();
			mapH = dataInputStream.readByte();
			int num = dataInputStream.readByte();
			if (idTile != num)
			{
				idTile = num;
				loadTileBig(num, false);
				imgTileWater = mImage.createImage("/tilewater" + idTile + ".png");
				DataInputStream dataInputStream2 = mImage.openFile("/tile_map_info_" + idTile);
				fWater = dataInputStream2.read();
				fStand = dataInputStream2.read();
				if (isTileMoi())
				{
					if (idTile == 9)
					{
						fWater = 127;
						fStand = 19;
						fStartWater = 19;
						fEndWater = 26;
					}
					else if (idTile == 10)
					{
						fWater = 127;
						fStand = 5;
						fStartWater = 4;
						fEndWater = 25;
					}
					else if (idTile == 11)
					{
						fWater = 127;
						fStand = 21;
						fStartWater = 20;
						fEndWater = 37;
					}
					else if (idTile == 12)
					{
						fWater = 127;
						fStand = 34;
						fStartWater = 35;
						fEndWater = 44;
					}
					else if (idTile == 13)
					{
						fWater = 0;
						fStand = 47;
						fStartWater = 0;
						fEndWater = 0;
					}
					else if (idTile == 14)
					{
						fWater = 0;
						fStand = 26;
						fStartWater = 0;
						fEndWater = 0;
					}
					else if (idTile == 15)
					{
						fWater = 0;
						fStand = 9;
						fStartWater = 0;
						fEndWater = 0;
					}
					else if (idTile == 16)
					{
						fWater = 0;
						fStand = 42;
						fStartWater = 0;
						fEndWater = 0;
					}
				}
			}
			maxWMap = mapW * wTile;
			maxHMap = mapH * wTile;
			limitW = maxWMap - GameCanvas.w;
			limitH = maxHMap - GameCanvas.h;
			MainScreen.cameraMain.setAll(limitW, limitH, GameScreen.player.x - GameCanvas.hw, GameScreen.player.y - GameCanvas.hh);
			mapPaint = new int[mapW * mapH];
			mapType = new int[mapW * mapH];
			mapFind = new sbyte[mapW][];
			mSystem.setDataArrByte(ref mapFind, mapH);
			limitMap = mapW * mapH;
			for (int i = 0; i < mapW * mapH; i++)
			{
				sbyte b = dataInputStream.readByte();
				mapPaint[i] = b;
				if (!isTileMoi())
				{
					if (b >= fStand || b == 0)
					{
						mapType[i] = 1;
					}
					else if (b >= fWater)
					{
						mapType[i] = 2;
					}
					else
					{
						mapType[i] = 0;
					}
					continue;
				}
				if (idTile == 9)
				{
					if (b == 27 || b == 28 || b == 29 || b == 30 || b == 31)
					{
						ThacNuoc o = new ThacNuoc(b - 27, i % mapW * 24, i / mapW * 24);
						Thacnuoc.addElement(o);
					}
				}
				else if (idTile == 10)
				{
					if (b == 18 || b == 19)
					{
						ThacNuoc o2 = new ThacNuoc(b - 18 + 5, i % mapW * 24, i / mapW * 24);
						Thacnuoc.addElement(o2);
					}
				}
				else if (idTile == 11)
				{
					if (b == 38 || b == 39)
					{
						ThacNuoc o3 = new ThacNuoc(b - 38 + 7, i % mapW * 24, i / mapW * 24);
						Thacnuoc.addElement(o3);
					}
				}
				else if (idTile != 12 && idTile != 13 && idTile != 14 && idTile != 15 && idTile != 16)
				{
				}
				if (b >= fStand || b == 0)
				{
					mapType[i] = 1;
				}
				else
				{
					mapType[i] = 0;
				}
			}
			isShowEffAuto = EFF_NORMAL;
			if (!isTileMoi())
			{
				if (Main.isSprite)
				{
					mSystem.loadImageMap(GameCanvas.loadmap.mapW * wTile, GameCanvas.loadmap.mapH * wTile, idMap);
				}
			}
			else
			{
				mSystem.loadImageMap(GameCanvas.loadmap.mapW * wTile, GameCanvas.loadmap.mapH * wTile, idMap);
			}
		}
		catch (Exception ex)
		{
			Cout.LogError2("loi load map 2" + ex.ToString());
		}
	}

	public static void loadColorMap(int tileId)
	{
		if (colorMap[tileId] == null)
		{
			mImage[] array = new mImage[totalTile[tileId]];
			colorMap[tileId] = new Color[totalTile[tileId]][];
			for (int i = 0; i < totalTile[tileId]; i++)
			{
				string text = ((i >= 9) ? ("tile" + tileId + "_") : ("tile" + tileId + "_0"));
				array[i] = mImage.createImage("/Tile/tile" + tileId + "/" + text + (i + 1) + ".png");
				colorMap[tileId][i] = array[i].image.texture.GetPixels();
				array[i].image.texture = null;
				array[i] = null;
			}
			mSystem.gcc();
		}
	}

	public mImage loadImageMap(ItemMapSprite scr, ref int timeRemove, ref bool isLoadOK)
	{
		loadColorMap(idTile);
		try
		{
			int num = wTile;
			mImage mImage2 = mImage.createImage(scr.wimg, scr.himg);
			int num2 = scr.x / 24;
			int num3 = scr.y / 24;
			int num4 = scr.wimg / 24;
			int num5 = scr.himg / 24;
			for (int i = 0; i < num4; i++)
			{
				for (int j = 0; j < num5; j++)
				{
					int num6 = GameCanvas.loadmap.mapPaint[(j + num3) * GameCanvas.loadmap.mapW + (i + num2)] - 1;
					if (num6 > -1)
					{
						mImage2.image.texture.SetPixels(i * num * mGraphics.zoomLevel, (num5 - 1 - j) * num * mGraphics.zoomLevel, num * mGraphics.zoomLevel, num * mGraphics.zoomLevel, colorMap[idTile][num6]);
					}
				}
			}
			mImage2.image.texture.Apply();
			timeRemove = (int)(mSystem.currentTimeMillis() / 1000);
			isLoadOK = true;
			return mImage2;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString() + " LOI--------");
			return null;
		}
	}

	public void load_ItemMap(sbyte[] mbyte)
	{
		try
		{
			DataInputStream dataInputStream = new DataInputStream(mbyte);
			mItemMap.removeAllElements();
			short num = dataInputStream.readShort();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				short id = dataInputStream.readShort();
				MainItemMap mainItemMap = get_Item(id);
				if (mainItemMap == null)
				{
					id = 85;
					mainItemMap = get_Item(id);
				}
				ItemMap itemMap = new ItemMap(mainItemMap.IDItem, mainItemMap.IDImage, mainItemMap.dx, mainItemMap.dy, mainItemMap.Block);
				short num3 = dataInputStream.readShort();
				short num4 = dataInputStream.readShort();
				if (!GameCanvas.lowGraphic || mainItemMap.Block.Length > 0)
				{
					Block_TileMap_Item(num3, num4, mainItemMap.Block);
					itemMap.setInfoItem(num3 * wTile, num4 * wTile);
					mItemMap.addElement(itemMap);
					num2++;
				}
			}
			if (dataInputStream.available() > 0 && !GameCanvas.lowGraphic)
			{
				short num5 = dataInputStream.readShort();
				mSystem.outz("size=" + num5);
				for (int j = 0; j < num5; j++)
				{
					int num6 = dataInputStream.readByte();
					string text = string.Empty;
					for (int k = 0; k < num6; k++)
					{
						text += (char)dataInputStream.readByte();
					}
					num6 = dataInputStream.readByte();
					string text2 = string.Empty;
					for (int l = 0; l < num6; l++)
					{
						text2 += (char)dataInputStream.readByte();
					}
					mItemMap.addElement(GameScreen.addEffectAuto(text, text2));
				}
			}
			CRes.quickSort1(mItemMap);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	public void paint(mGraphics g)
	{
		try
		{
			int num = MainScreen.cameraMain.xCam / wTile - 1;
			int num2 = MainScreen.cameraMain.yCam / wTile - 1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			int num3 = num + maxX + 2;
			int num4 = num2 + maxY + 2;
			if (num3 > mapW)
			{
				num3 = mapW;
			}
			if (num4 > mapH)
			{
				num4 = mapH;
			}
			for (int i = num; i < num3; i++)
			{
				for (int j = num2; j < num4; j++)
				{
					if (!LoadMapScreen.isNextMap)
					{
						break;
					}
					int num5 = mapPaint[j * mapW + i] - 1;
					if (!isTileMoi())
					{
						if (num5 >= fWater - 1 && num5 < fStand - 1 && ((GameCanvas.gameTick % 14 < 7 && i % 2 == 0) || (GameCanvas.gameTick % 14 > 7 && i % 2 != 0)))
						{
							g.drawRegionNotSetClip(imgTileWater, (num5 - (fWater - 1)) / 10 * wTile, (num5 - (fWater - 1)) % 10 * wTile, wTile, wTile, 0, i * wTile, j * wTile, 0);
						}
						else if (num5 > -1)
						{
							int num6 = num5 % 10;
							int num7 = num5 / 10;
							if (imgTileMap[num5] != null && !Main.isSprite)
							{
								g.drawImage(imgTileMap[num5], i * wTile, j * wTile, 0, mGraphics.isFalse);
							}
						}
					}
					else if (num5 >= fStartWater - 1 && num5 < fEndWater && ((GameCanvas.gameTick % 14 < 7 && i % 2 == 0) || (GameCanvas.gameTick % 14 > 7 && i % 2 != 0)))
					{
						g.drawRegionNotSetClip(imgTileWater, (num5 - (fStartWater - 1)) / 10 * wTile, (num5 - (fStartWater - 1)) % 10 * wTile, wTile, wTile, 0, i * wTile, j * wTile, 0);
					}
					else if (num5 > -1)
					{
						int num8 = num5 % 10;
						int num9 = num5 / 10;
						if (imgTileMap[num5] != null && !Main.isSprite)
						{
							g.drawImage(imgTileMap[num5], i * wTile, j * wTile, 0, mGraphics.isFalse);
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void update()
	{
		if (!isTileMoi())
		{
			if (!Main.isSprite)
			{
				return;
			}
			for (int i = 0; i < mSystem.totalImageMap.size(); i++)
			{
				ItemMapSprite itemMapSprite = (ItemMapSprite)mSystem.totalImageMap.elementAt(i);
				if (itemMapSprite != null)
				{
					itemMapSprite.update();
				}
			}
			return;
		}
		for (int j = 0; j < mSystem.totalImageMap.size(); j++)
		{
			ItemMapSprite itemMapSprite2 = (ItemMapSprite)mSystem.totalImageMap.elementAt(j);
			if (itemMapSprite2 != null)
			{
				itemMapSprite2.update();
			}
		}
	}

	public int getTile(int xset, int yset)
	{
		int num = yset / wTile * mapW + xset / wTile;
		if (num > limitMap || xset < 0 || xset >= limitW + GameCanvas.w || yset < 0 || yset >= limitH + GameCanvas.h)
		{
			return 1;
		}
		return mapType[num];
	}

	public int getIndex(int xset, int yset)
	{
		return yset / wTile * mapW + xset / wTile;
	}

	public MainItemMap get_Item(int id)
	{
		for (int i = 0; i < vecMapItem.size(); i++)
		{
			MainItemMap mainItemMap = (MainItemMap)vecMapItem.elementAt(i);
			if (mainItemMap.IDItem == id)
			{
				return mainItemMap;
			}
		}
		return null;
	}

	public void Block_TileMap_Item(int indexW, int indexH, int[][] mb)
	{
		try
		{
			for (int i = 0; i < mb.Length; i++)
			{
				if (indexW + mb[i][0] >= 0 && indexW + mb[i][0] < mapW && indexH + mb[i][1] >= 0 && indexH + mb[i][1] < mapH)
				{
					mapType[(indexH + mb[i][1]) * mapW + (indexW + mb[i][0])] = 1;
				}
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi load map 4");
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	public void setBlockNPC(int x, int y, int w, int h)
	{
		if (mapW == 0)
		{
			mapW = 1;
		}
		int index = getIndex(x, y);
		for (int i = 0; i < w; i++)
		{
			for (int j = 0; j < h; j++)
			{
				if (index % mapW - w / 2 + i >= 0 && index % mapW - w / 2 + i < mapW && index / mapW - h / 2 + j >= 0 && index / mapW - h / 2 < mapH)
				{
					mapType[(index / mapW - h / 2 + j) * mapW + (index % mapW - w / 2 + i)] = 1;
				}
			}
		}
	}

	public void setBlockNPC_Server(int x, int y, int w, int h)
	{
		if (mapW == 0)
		{
			mapW = 1;
		}
		int index = getIndex(x, y);
		for (int i = 0; i < w; i++)
		{
			for (int j = 0; j < h; j++)
			{
				if (index % mapW - w / 2 + i >= 0 && index % mapW - w / 2 + i < mapW && index / mapW - h / 2 + j >= 0 && index / mapW - h / 2 < mapH)
				{
					mapType[(index / mapW - h / 2 + j) * mapW + (index % mapW + i)] = 1;
				}
			}
		}
	}

	public static sbyte getAreaPaint()
	{
		return (sbyte)(Area + 1);
	}

	public static string getTimeSpecialRegion()
	{
		string empty = string.Empty;
		long num = (GameScreen.timeSpRegion - mSystem.currentTimeMillis()) / 1000;
		if (num <= 0)
		{
			return string.Empty;
		}
		long num2 = num / 3600;
		long num3 = num / 60;
		long num4 = num;
		return string.Concat(str2: (num2 > 0) ? (num2 + "h" + num % 3600 / 60 + "'") : ((num3 <= 0) ? (num4 + "s") : (num3 + "p" + num % 60 + "s")), str0: GameScreen.nameSpecialRegion, str1: string.Empty);
	}

	public static bool isTileMoi()
	{
		if (idTile < 9)
		{
			return false;
		}
		return true;
	}

	public static string getTimeArena(long timeStart)
	{
		string empty = string.Empty;
		long num = (timeStart + 3600000 - mSystem.currentTimeMillis()) / 1000;
		if (num <= 0)
		{
			return string.Empty;
		}
		long num2 = num / 60;
		long num3 = num;
		if (num2 > 0)
		{
			if (num2 < 10)
			{
				if (num % 60 >= 0 && num % 60 < 10)
				{
					return "0" + num2 + ":0" + num % 60;
				}
				return "0" + num2 + ":" + num % 60;
			}
			if (num % 60 >= 0 && num % 60 < 10)
			{
				return num2 + ":0" + num % 60;
			}
			return num2 + ":" + num % 60;
		}
		return (num3 >= 10) ? (num3 + "s") : ("0" + num3 + "s");
	}

	public static string convertSecondsToHMmSs(long now)
	{
		int num = (int)(now / 1000) % 60;
		int num2 = (int)(now / 60000 % 60);
		int num3 = (int)(now / 3600000 % 24);
		if (num <= 0 && num3 <= 0 && num2 <= 0)
		{
			return 0 + "h: " + 0 + "': " + 0;
		}
		return num3 + "h: " + num2 + "': " + num;
	}

	public static string getTimeCountDown(long timeStart, int secondCount)
	{
		string empty = string.Empty;
		long num = (timeStart + secondCount * 1000 - mSystem.currentTimeMillis()) / 1000;
		if (num <= 0)
		{
			return string.Empty;
		}
		long num2 = num / 60;
		long num3 = num;
		if (num2 > 0)
		{
			if (num2 < 10)
			{
				if (num % 60 >= 0 && num % 60 < 10)
				{
					return "0" + num2 + ":0" + num % 60;
				}
				return "0" + num2 + ":" + num % 60;
			}
			if (num % 60 >= 0 && num % 60 < 10)
			{
				return num2 + ":0" + num % 60;
			}
			return num2 + ":" + num % 60;
		}
		return (num3 >= 10) ? (num3 + "s") : ("0" + num3 + "s");
	}

	public static string converSecon2hours(int totalSeconds)
	{
		int num = totalSeconds % 60;
		int num2 = totalSeconds / 60;
		int num3 = num2 % 60;
		int num4 = num2 / 60;
		if (num4 > 0)
		{
			return num4 + ":" + num3;
		}
		if (num3 > 0)
		{
			return num3 + ":" + num;
		}
		if (num < 10)
		{
			return "0:" + num;
		}
		return num + string.Empty;
	}
}
