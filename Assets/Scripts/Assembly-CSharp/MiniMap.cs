using System;
using System.Globalization;
using UnityEngine;

public class MiniMap
{
    public int maxX;

    public int maxY;

    public static int wMini = 3;

    public Camera miniCamera = new Camera();

    public static mImage imgMiniMap;

    public static mVector vecNPC_Map = new mVector("MiniMap vecNPC_Map");

    public static Point pHelp;

    public static MiniMap me;

    public static bool isStartMiniMap = false;

    public static mHashTable totalSmallImage = new mHashTable();

    public static bool isLoadMiniMapOk;

    public static Color[][][] colorMiniMap = new Color[17][][];

    public static int[] totalTile = new int[17]
    {
        72, 60, 57, 64, 47, 43, 66, 61, 52, 51,
        61, 62, 67, 69, 59, 99, 99
    };

    public static string loi = "loi";

    public static bool isAtMiniMap;

    private int[] color = new int[4] { 1045997, 16115463, 12237219, 15603253 };

    public int fWait { get; set; }

    public static MiniMap gI()
    {
        return (me != null) ? me : (me = new MiniMap());
    }

    public void setSize()
    {
        if (GameCanvas.w > 300 && GameCanvas.h > 300)
        {
            wMini = 3;
        }
        else if (GameCanvas.w > 200 && GameCanvas.h > 200)
        {
            wMini = 2;
        }
        maxX = 25;
        maxY = 20;
        if (maxX > GameCanvas.loadmap.mapW)
        {
            maxX = GameCanvas.loadmap.mapW;
        }
        if (maxY > GameCanvas.loadmap.mapH)
        {
            maxY = GameCanvas.loadmap.mapH;
        }
        if (GameCanvas.isTouch)
        {
            PaintInfoGameScreen.xFocus = GameCanvas.w - GameCanvas.minimap.maxX * wMini - 55;
        }
        miniCamera.setAll((GameCanvas.loadmap.mapW - maxX) * wMini, (GameCanvas.loadmap.mapH - maxY) * wMini, (GameScreen.player.x / LoadMap.wTile - maxX / 2) * wMini, (GameScreen.player.y / LoadMap.wTile - maxY / 2) * wMini);
        if (imgMiniMap != null && imgMiniMap.image != null)
        {
            imgMiniMap.image.texture = null;
            imgMiniMap.image = null;
            mSystem.gcc();
        }
        isLoadMiniMapOk = false;
        isAtMiniMap = true;
        CreateMiniMap(wMini, (sbyte)(Main.isWindowsPhone ? 1 : 0));
    }

    public static void loadColorMiniMap(int tileId)
    {
        if (colorMiniMap[tileId] == null)
        {
            mImage[] array = new mImage[totalTile[tileId]];
            colorMiniMap[tileId] = new Color[totalTile[tileId]][];
            for (int i = 0; i < totalTile[tileId]; i++)
            {
                string text = ((i >= 9) ? ("tile_small" + tileId + "_") : ("tile_small" + tileId + "_0"));
                array[i] = mImage.createImage("/Tile/tile_small" + tileId + "/" + text + (i + 1) + ".png");
                colorMiniMap[tileId][i] = array[i].image.texture.GetPixels();
                array[i].image.texture = null;
                array[i] = null;
            }
            mSystem.gcc();
        }
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

    public mImage loadMiniMapWinDowsPhone(int s)
    {
        mImage mImage2 = null;
        try
        {
            isLoadMiniMapOk = false;
            loadColorMiniMap(LoadMap.idTile);
            string text = "x" + mGraphics.zoomLevel + "minimap" + LoadMap.me.idMap;
            sbyte[] array = Rms.loadRMS(text);
            if (array != null)
            {
                mImage2.image = Image.createImage(array, 0, array.Length, text);
            }
            else
            {
                try
                {
                    for (int i = 0; i < GameCanvas.loadmap.mapW; i++)
                    {
                        for (int j = 0; j < GameCanvas.loadmap.mapH; j++)
                        {
                            int num = GameCanvas.loadmap.mapPaint[j * GameCanvas.loadmap.mapW + i] - 1;
                            if (num > -1 && num < colorMiniMap[LoadMap.idTile].Length)
                            {
                                mImage2.image.texture.SetPixels(i * s * mGraphics.zoomLevel, (GameCanvas.loadmap.mapH - 1 - j) * s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, colorMiniMap[LoadMap.idTile][num]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.Log((object)ex.ToString());
                    loi = "11111   " + ex.ToString();
                }
                mImage2.image.texture.Apply();
                byte[] byteArray = getByteArray(mImage2.image);
                Rms.saveRMS(text, ArrayCast.cast(byteArray));
            }
            isLoadMiniMapOk = true;
        }
        catch (Exception ex2)
        {
            loi = ex2.ToString();
        }
        return mImage2;
    }

    public static ImageData getImgData(short idSmall, short add, bool isThread)
    {
        short num = idSmall;
        ImageData imageData = (ImageData)totalSmallImage.get(num + add + string.Empty);
        if (GameCanvas.loadmap.mapW == 1 && GameCanvas.loadmap.mapH == 1)
        {
            return null;
        }
        if (imageData == null)
        {
            imageData = new ImageData();
            imageData.id = num;
            string text = "xcreatminimap_" + (num + add);
            sbyte[] array = Rms.loadRMS(text);
            if (array != null)
            {
                imageData.img = mImage.createImage(array, 0, array.Length, text);
                isLoadMiniMapOk = true;
            }
            else if (isThread)
            {
                imageData.img = LoadAnhMiniMap(text, num, add, GameCanvas.loadmap.mapW, GameCanvas.loadmap.mapH, Main.sizeMiniMap);
            }
            else
            {
                isLoadMiniMapOk = false;
            }
            imageData.timeRemove = (int)(mSystem.currentTimeMillis() / 1000);
            isLoadMiniMapOk = true;
            imageData.timeGetBack = (int)(mSystem.currentTimeMillis() / 1000);
            totalSmallImage.put(string.Empty + (num + add), imageData);
        }
        else
        {
            if (imageData.img == null)
            {
                isLoadMiniMapOk = false;
                string text2 = "xcreatminimap_" + (num + add);
                sbyte[] array2 = Rms.loadRMS(text2);
                if (array2 != null)
                {
                    imageData.img = mImage.createImage(array2, 0, array2.Length, text2);
                    isLoadMiniMapOk = true;
                }
                else if (isThread)
                {
                    imageData.img = LoadAnhMiniMap(text2, num, add, GameCanvas.loadmap.mapW, GameCanvas.loadmap.mapH, Main.sizeMiniMap);
                    isLoadMiniMapOk = true;
                }
                else
                {
                    isLoadMiniMapOk = false;
                }
            }
            else
            {
                isLoadMiniMapOk = true;
            }
            imageData.timeRemove = (int)(mSystem.currentTimeMillis() / 1000);
        }
        return imageData;
    }

    public static mImage LoadAnhMiniMap(string pathRSM, int id, int add, int w, int h, int sizeMiniMap)
    {
        //IL_00f8: Unknown result type (might be due to invalid IL or missing references)
        //IL_00fa: Unknown result type (might be due to invalid IL or missing references)
        try
        {
            mImage mImage2 = mImage.createImage(w * sizeMiniMap, h * sizeMiniMap);
            isLoadMiniMapOk = false;
            loadColorMiniMap(LoadMap.idTile);
            Color[] array = null;
            if (GameCanvas.mapBack != null)
            {
                string text = GameCanvas.mapBack.colorMini;
                if (text.IndexOf('x') != -1)
                {
                    text = text.Replace("0x", string.Empty);
                }
                float num = 0f;
                float num2 = 0f;
                float num3 = 0f;
                if (text.Length == 6)
                {
                    num = int.Parse(text.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                    num2 = int.Parse(text.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                    num3 = int.Parse(text.Substring(4, 2), NumberStyles.AllowHexSpecifier);
                }

                Color color = new Color(num / 255f, num2 / 255f, num3 / 255f);

                array = (Color[])(object)new Color[sizeMiniMap * mGraphics.zoomLevel * sizeMiniMap * mGraphics.zoomLevel];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = color;
                }
            }
            try
            {
                for (int j = 0; j < w; j++)
                {
                    for (int k = 0; k < h; k++)
                    {
                        int num4 = GameCanvas.loadmap.mapPaint[k * w + j] - 1;
                        if (num4 <= -1 && array != null)
                        {
                            mImage2.image.texture.SetPixels(j * sizeMiniMap * mGraphics.zoomLevel, (GameCanvas.loadmap.mapH - 1 - k) * sizeMiniMap * mGraphics.zoomLevel, sizeMiniMap * mGraphics.zoomLevel, sizeMiniMap * mGraphics.zoomLevel, array);
                        }
                        if (num4 > -1 && num4 < colorMiniMap[LoadMap.idTile].Length)
                        {
                            if (!isStartMiniMap || id != GameCanvas.loadmap.idMap)
                            {
                                isLoadMiniMapOk = false;
                                isStartMiniMap = true;
                                return null;
                            }
                            mImage2.image.texture.SetPixels(j * sizeMiniMap * mGraphics.zoomLevel, (h - 1 - k) * sizeMiniMap * mGraphics.zoomLevel, sizeMiniMap * mGraphics.zoomLevel, sizeMiniMap * mGraphics.zoomLevel, colorMiniMap[LoadMap.idTile][num4]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log((object)("Loi LoadAnhMiniMap:  " + ex.ToString()));
            }
            mImage2.image.texture.Apply();
            if (!isStartMiniMap || id != GameCanvas.loadmap.idMap)
            {
                isLoadMiniMapOk = false;
                isStartMiniMap = true;
                return null;
            }
            byte[] byteArray = getByteArray(mImage2.image);
            Rms.saveRMS(pathRSM, ArrayCast.cast(byteArray));
            return mImage2;
        }
        catch (Exception)
        {
        }
        return null;
    }

    public static sbyte[] get_Byte_Array(Image img)
    {
        int[] array = new int[img.getWidth() * img.getHeight()];
        sbyte[] result = null;
        try
        {
            img.getRGB(array, 0, img.getWidth(), 0, 0, img.getWidth(), img.getHeight());
        }
        catch (Exception)
        {
        }
        DataOutputStream dataOutputStream = new DataOutputStream();
        try
        {
            for (int i = 0; i < array.Length; i++)
            {
                dataOutputStream.writeInt(array[i]);
            }
            result = dataOutputStream.toByteArray();
            dataOutputStream.close();
            dataOutputStream.close();
        }
        catch (Exception)
        {
        }
        return result;
    }

    public static void CreateMiniMap(int s, sbyte type)
    {
        isLoadMiniMapOk = false;
        mImage mImage2 = mImage.createImage(GameCanvas.loadmap.mapW * s, GameCanvas.loadmap.mapH * s);
        if (type == 1)
        {
            Main.sizeMiniMap = s;
            Main.isLoad = true;
            Main.main.creatMiniMap();
            return;
        }
        loadColorMiniMap(LoadMap.idTile);
        Color[] array = null;
        if (GameCanvas.mapBack != null)
        {
            string text = GameCanvas.mapBack.colorMini;
            if (text.IndexOf('x') != -1)
            {
                text = text.Replace("0x", string.Empty);
            }
            float num = 0f;
            float num2 = 0f;
            float num3 = 0f;
            if (text.Length == 6)
            {
                num = int.Parse(text.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                num2 = int.Parse(text.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                num3 = int.Parse(text.Substring(4, 2), NumberStyles.AllowHexSpecifier);
            }
            Color color = new Color(num / 255f, num2 / 255f, num3 / 255f);
            array = new Color[s * mGraphics.zoomLevel * s * mGraphics.zoomLevel];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = color;
            }
        }
        try
        {
            for (int j = 0; j < GameCanvas.loadmap.mapW; j++)
            {
                for (int k = 0; k < GameCanvas.loadmap.mapH; k++)
                {
                    int num4 = GameCanvas.loadmap.mapPaint[k * GameCanvas.loadmap.mapW + j] - 1;
                    if (num4 <= -1 && array != null)
                    {
                        mImage2.image.texture.SetPixels(j * s * mGraphics.zoomLevel, (GameCanvas.loadmap.mapH - 1 - k) * s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, array);
                    }
                    if (num4 > -1 && num4 < colorMiniMap[LoadMap.idTile].Length)
                    {
                        mImage2.image.texture.SetPixels(j * s * mGraphics.zoomLevel, (GameCanvas.loadmap.mapH - 1 - k) * s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, colorMiniMap[LoadMap.idTile][num4]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString() + colorMiniMap[LoadMap.idTile].Length);
        }
        mImage2.image.texture.Apply();
        if (isAtMiniMap)
        {
            imgMiniMap = mImage2;
        }
        else
        {
            MiniMapFull_Screen.gI().imgtest = mImage2;
        }
        isLoadMiniMapOk = true;
    }

    public void paint(mGraphics g)
    {
        if (GameScreen.infoGame.isMapThachdau() || GameScreen.infoGame.isMapchienthanh())
        {
            return;
        }
        g.setColor(7612434);
        g.fillRect(-3, -3 + mGraphics.addYWhenOpenKeyBoard, maxX * wMini + 6, maxY * wMini + 6, mGraphics.isFalse);
        g.setColor(16307052);
        g.fillRect(-2, -2 + mGraphics.addYWhenOpenKeyBoard, maxX * wMini + 4, maxY * wMini + 4, mGraphics.isFalse);
        g.setColor(isLoadMiniMapOk ? 4724752 : 0);
        g.fillRect(-1, -1 + mGraphics.addYWhenOpenKeyBoard, maxX * wMini + 2, maxY * wMini + 2, mGraphics.isFalse);
        g.setClip(0, 0 + mGraphics.addYWhenOpenKeyBoard, maxX * wMini, maxY * wMini);
        if (!isLoadMiniMapOk)
        {
            fWait++;
            MsgDialog.fraWaiting.drawFrame(fWait % MsgDialog.fraWaiting.nFrame, (maxX * wMini + 2) / 2, (maxY * wMini + 4) / 2 - 5, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
        }
        g.translate(-miniCamera.xCam, -miniCamera.yCam);
        if (isLoadMiniMapOk && isAtMiniMap)
        {
            if (Main.isWindowsPhone)
            {
                ImageData imgData = getImgData((short)GameCanvas.loadmap.idMap, (short)GameCanvas.loadmap.idMap, isThread: false);
                if (imgData != null && !imgData.isLoad && imgData.img != null)
                {
                    g.drawImage(imgData.img, 0, 0 + mGraphics.addYWhenOpenKeyBoard, 0, mGraphics.isTrue);
                }
            }
            else if (imgMiniMap != null)
            {
                g.drawImage(imgMiniMap, 0, 0 + mGraphics.addYWhenOpenKeyBoard, 0, mGraphics.isTrue);
            }
            int num = wMini;
            for (int i = 0; i < LoadMap.vecPointChange.size(); i++)
            {
                Point point = (Point)LoadMap.vecPointChange.elementAt(i);
                g.setColor(6156031);
                switch (point.f)
                {
                    case 0:
                        g.fillRect(point.x * num / LoadMap.wTile - num, point.y * num / LoadMap.wTile - 2 * num, num, num * 4, mGraphics.isTrue);
                        break;
                    case 1:
                        g.fillRect(point.x * num / LoadMap.wTile, point.y * num / LoadMap.wTile - 2 * num, num, num * 4, mGraphics.isTrue);
                        break;
                    case 2:
                        g.fillRect(point.x * num / LoadMap.wTile - 2 * num, point.y * num / LoadMap.wTile, 4 * num, num, mGraphics.isTrue);
                        break;
                    case 3:
                        g.fillRect(point.x * num / LoadMap.wTile - 2 * num, point.y * num / LoadMap.wTile, 4 * num, num, mGraphics.isTrue);
                        break;
                }
            }
        }
        if (LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
        {
            for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
            {
                MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(j);
                if (mainObject.typeObject == 1)
                {
                    AvMain.fraObjMiniMap.drawFrame(11, mainObject.x / LoadMap.wTile * wMini, mainObject.y / LoadMap.wTile * wMini, 0, 3, g);
                }
            }
        }
        if (isLoadMiniMapOk)
        {
            for (int k = 0; k < vecNPC_Map.size(); k++)
            {
                NPCMini nPCMini = (NPCMini)vecNPC_Map.elementAt(k);
                AvMain.fraObjMiniMap.drawFrame(nPCMini.type + 4, nPCMini.x / LoadMap.wTile * wMini, nPCMini.y / LoadMap.wTile * wMini + mGraphics.addYWhenOpenKeyBoard, 0, 3, g);
            }
        }
        if (isLoadMiniMapOk)
        {
            AvMain.fraObjMiniMap.drawFrame((GameScreen.player.Action != 4) ? GameScreen.player.Direction : 9, GameScreen.player.x / LoadMap.wTile * wMini, GameScreen.player.y / LoadMap.wTile * wMini + mGraphics.addYWhenOpenKeyBoard, 0, 3, g);
        }
        if (!isLoadMiniMapOk)
        {
            return;
        }
        if (LoadMap.idTile == 9)
        {
            g.setColor(367554);
        }
        else
        {
            g.setColor(255);
        }
        if (Player.party != null)
        {
            for (int l = 0; l < Player.party.vecPartys.size(); l++)
            {
                ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(l);
                if (objectParty.name.CompareTo(GameScreen.player.name) != 0 && objectParty.idMap == GameCanvas.loadmap.idMap)
                {
                    AvMain.fraObjMiniMap.drawFrame(10, objectParty.x / LoadMap.wTile * wMini, objectParty.y / LoadMap.wTile * wMini + mGraphics.addYWhenOpenKeyBoard, 0, 3, g);
                }
            }
        }
        if (pHelp != null && pHelp.frame == GameCanvas.loadmap.idMap)
        {
            int num2 = pHelp.x;
            int num3 = pHelp.y;
            if (num2 < miniCamera.xCam + 3)
            {
                num2 = miniCamera.xCam + 3;
            }
            if (num2 > miniCamera.xCam + maxX * wMini - 3)
            {
                num2 = miniCamera.xCam + maxX * wMini - 3;
            }
            if (num3 < miniCamera.yCam + 3)
            {
                num3 = miniCamera.yCam + 3;
            }
            if (num3 > miniCamera.yCam + maxY * wMini - 3)
            {
                num3 = miniCamera.yCam + maxY * wMini - 3;
            }
            WorldMapScreen.fraMyPos.drawFrame(GameCanvas.gameTick / 2 % WorldMapScreen.fraMyPos.nFrame, num2, num3 + mGraphics.addYWhenOpenKeyBoard, 0, 3, g);
        }
    }

    public static void addNPCMini(NPCMini npc)
    {
        MainObject mainObject = MainObject.get_Object(npc.ID, 2);
        if (mainObject != null)
        {
            SetTypeNPC(mainObject);
            npc.type = mainObject.typeNPC;
            vecNPC_Map.addElement(npc);
        }
    }

    public static void addMonMini(int id, sbyte tem)
    {
        MainObject mainObject = MainObject.get_Object(id, tem);
        if (mainObject == null)
        {
            return;
        }
        NPCMini nPCMini = new NPCMini(id, mainObject.x, mainObject.y);
        nPCMini.type = 8;
        for (int i = 0; i < vecNPC_Map.size(); i++)
        {
            NPCMini nPCMini2 = (NPCMini)vecNPC_Map.elementAt(i);
            if (nPCMini2.ID == id && nPCMini2.type == nPCMini.type)
            {
                nPCMini2.x = nPCMini.x;
                nPCMini2.y = nPCMini.y;
                return;
            }
        }
        vecNPC_Map.addElement(nPCMini);
    }

    public static void SetTypeNPC(MainObject obj)
    {
        for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
        {
            MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
            if (mainQuest.idNPC_From == obj.ID && (obj.typeNPC == 0 || obj.typeNPC == 2))
            {
                obj.typeNPC = 1;
            }
        }
        for (int j = 0; j < MainQuest.vecQuestFinish.size(); j++)
        {
            MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(j);
            if (mainQuest2.idNPC_To == obj.ID)
            {
                obj.typeNPC = 3;
            }
        }
        for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
        {
            MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
            if (mainQuest3.idNPC_To == obj.ID && obj.typeNPC == 0)
            {
                obj.typeNPC = 2;
            }
        }
        for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
        {
            MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
            if (mainQuest4.idNPC_To == obj.ID && obj.typeNPC == 0)
            {
                obj.typeNPC = 2;
            }
        }
    }

    public void setPoint(int x, int y, int idMap)
    {
        if (pHelp == null)
        {
            pHelp = new Point();
        }
        pHelp.x = x * wMini - wMini / 2;
        pHelp.y = y * wMini - wMini / 2;
        pHelp.frame = idMap;
    }

    public void updatePoint()
    {
    }
}
