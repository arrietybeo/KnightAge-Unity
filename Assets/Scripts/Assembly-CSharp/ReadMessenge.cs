using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Tilemaps;

public class ReadMessenge : AvMain
{

    public short idDialog;

    public sbyte typeDialog;

    private sbyte getClass;

    public const sbyte UPDATE_ALL = 0;

    public const sbyte ADD_REPLACE = 1;

    public const sbyte DELETE = 2;

    public const sbyte UPDATE_SIZECHEST = 3;

    public static sbyte SHOP_ITEM_EVENT = 100;

    public static sbyte SHOP_POTION;

    public static sbyte SHOP_ITEM = 1;

    public static sbyte SHOP_HAIR = 2;

    public static sbyte CHEST = 3;

    public static sbyte SHOP_MATERIAL = 4;

    public static sbyte REBUILD = 5;

    public static sbyte SHOP_ICONCLAN_FREE = 6;

    public static sbyte SHOP_ICONCLAN_VIP = 7;

    public static sbyte SHOP_POTION_CLAN = 8;

    public static sbyte REPLACE = 9;

    public static sbyte WING = 10;

    public static sbyte PET_KEEPER = 11;

    public static sbyte TAB_HOP_NGUYEN_LIEU = 12;

    public static sbyte SHOP_VANTIEU = 13;

    public static sbyte SHOP_KHAM_NGOC = 14;

    public static sbyte SHOP_GHEP_NGOC = 15;

    public static sbyte SHOP_DUC_LO = 16;

    public static sbyte SHOP_OTHER_PLAYER = 17;

    public static sbyte SHOP_ANY_NGUYEN_LIEU = 18;

    public static sbyte SHOP_HOP_AN = 19;

    public static sbyte SHOP_NANG_CAP_MEDAL = 20;

    private string nameParty = string.Empty;

    private string nameBuySell = string.Empty;

    public override void commandPointer(int index, int subIndex)
    {
        switch (index)
        {
            case 0:
                GlobalService.gI().Buy_Sell(1, nameBuySell, 0, 0, 0);
                GameCanvas.end_Dialog();
                break;
            case 1:
                GlobalService.gI().Party(2, nameParty);
                GameCanvas.end_Dialog();
                break;
            case 2:
                GameCanvas.end_Dialog();
                if (subIndex >= 0)
                {
                    GlobalService.gI().dialog_Server(idDialog, typeDialog, (sbyte)subIndex);
                }
                break;
            case 3:
                {
                    MainObject.StepHelpServer++;
                    if (MainObject.StepHelpServer >= MainObject.strHelpNPC.Length - 1)
                    {
                        GameCanvas.menu2.startAt_NPC(null, MainObject.strHelpNPC[MainObject.strHelpNPC.Length - 1], subIndex, 2, isQuest: false, 2);
                        break;
                    }
                    mVector mVector3 = new mVector("ReadMessenge menu");
                    iCommand o = new iCommand(T.next, 3, subIndex, this);
                    mVector3.addElement(o);
                    GameCanvas.menu2.startAt_NPC(mVector3, MainObject.strHelpNPC[MainObject.StepHelpServer], subIndex, 2, isQuest: false, 2);
                    break;
                }
            case 4:
                GameCanvas.menu2.doCloseMenu();
                GlobalService.gI().Replace_Item(2, 0);
                GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
                break;
        }
    }

    public void khamNgoc(Message msg)
    {
        try
        {
            GameCanvas.end_Dialog();
            TabRebuildItem.isBeginEff = 1;
            TabRebuildItem.isNextRebuild = msg.reader().readByte();
            TabRebuildItem.contentShow = msg.reader().readUTF();
            TabRebuildItem.vecGem.removeAllElements();
            short num = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            if (num != -1 && b == 7)
            {
                MainItem material = Item.getMaterial(num);
                if (material != null)
                {
                    TabRebuildItem.itemRe = material;
                    return;
                }
                TabRebuildItem.itemRe = new MainItem();
                TabRebuildItem.itemRe.Id = num;
                TabRebuildItem.itemRe.ItemCatagory = 7;
            }
        }
        catch (Exception)
        {
        }
    }

    public void mainCharInfo(Message msg)
    {// sendPlayerInfo
        try
        {
            short iD = msg.reader().readShort();
            string text = msg.reader().readUTF();
            text = text.ToLower();
            int hp = msg.reader().readInt();
            int num = msg.reader().readInt();
            int mp = msg.reader().readInt();
            int maxMp = msg.reader().readInt();
            sbyte b = msg.reader().readByte(); //int head, , 
            sbyte clazz = msg.reader().readByte();// class
            sbyte b2 = msg.reader().readByte();// int eye
            sbyte b3 = msg.reader().readByte();// int hair
            if (GameScreen.player == null)
            {
                GameScreen.player = new Player(iD, 0, text.ToLower(), 50, 50);
            }
            GameScreen.player.setInfo(b, b2, b3);

            sbyte b4 = msg.reader().readByte();//  dos.writeByte(options.size());
            MainInfoItem[] array = new MainInfoItem[b4];
            int num2 = 0;
            for (int i = 0; i < GameScreen.player.mKhangChar.Length; i++)
            {
                GameScreen.player.mKhangChar[i] = "0";
            }

            for (int j = 0; j < b4; j++)
            {
                if (GameMidlet.version.Equals("1.1.0"))
                {
                    array[j] = new MainInfoItem(
                        msg.reader().readUnsignedByte(),
                        msg.reader().readUnsignedShort()
                    );
                }
                else
                {
                    array[j] = new MainInfoItem(
                        msg.reader().readUnsignedByte(),
                        msg.reader().readInt()
                    );
                }
                if (array[j].id >= 16 && array[j].id <= 20)
                {
                    GameScreen.player.mKhangChar[array[j].id - 16] = MainItem.getNopercent(array[j].value);
                }
                if (array[j].id >= 23 && array[j].id <= 26)
                {
                    num2++;
                }
            }
            if (num2 == 0)
            {
                GameScreen.player.mInfoChar = array;
            }
            else
            {
                GameScreen.player.mInfoChar = new MainInfoItem[b4 - num2];
                num2 = 0;
                for (int k = 0; k < array.Length; k++)
                {
                    if (array[k].id < 23 || array[k].id > 26)
                    {
                        GameScreen.player.mInfoChar[num2] = new MainInfoItem(array[k].id, array[k].value);
                        num2++;
                    }
                }
            }
            GameScreen.player.Lv = msg.reader().readShort();
            GameScreen.player.phantramLv = msg.reader().readShort();
            Player.diemTiemNang = msg.reader().readShort();

            Player.diemKyNang = msg.reader().readShort();
            //Debug.LogError("level: " + GameScreen.player.Lv + "\nphantranglv: " + GameScreen.player.phantramLv + "\ndiemTiemNang: " + Player.diemTiemNang + "\ndiemKyNang: " + Player.diemKyNang);

            for (int l = 0; l < Player.mTiemnang[0].Length; l++)
            {
                Player.mTiemnang[0][l] = msg.reader().readShort();
            }
            Debug.LogError("Player.mTiemnang[0].Length: " + Player.mTiemnang[0].Length);

            for (int m = 0; m < Player.mTiemnang[0].Length; m++)
            {
                Player.mTiemnang[1][m] = msg.reader().readShort();
                Player.mTiemnang[1][m] = 1906;
            }
            Debug.LogError("Player.mTiemnang[0].Length: " + Player.mTiemnang[0].Length);

            Player.mCurentLvSkill = new int[Player.MaxSkill];
            for (int n = 0; n < Player.MaxSkill; n++)
            {
                Player.mCurentLvSkill[n] = msg.reader().readByte();
            }
            for (int num3 = 0; num3 < Player.MaxSkill; num3++)
            {
                Player.mPlusLvSkill[num3] = msg.reader().readByte();
            }
            for (int num4 = 0; num4 < Player.MaxSkill; num4++)
            {
                int num5 = -1;
                bool flag = true;
                if (Player.mCurentLvSkill[num4] > 0)
                {
                    if (num4 < 9)
                    {
                        for (int num6 = 0; num6 < 3; num6++)
                        {
                            HotKey hotKey = Player.mhotkey[Player.levelTab][num6];
                            if (hotKey == null)
                            {
                                continue;
                            }
                            if (num5 == -1)
                            {
                                if (hotKey.type == HotKey.NULL)
                                {
                                    num5 = num6;
                                    flag = false;
                                }
                            }
                            else if (hotKey.type == HotKey.SKILL && hotKey.id == num4)
                            {
                                num5 = -1;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    flag = false;
                }
                if (num5 != -1)
                {
                    Player.mhotkey[Player.levelTab][num5].setHotKey(num4, HotKey.SKILL, 0);
                }
                if (flag)
                {
                    break;
                }
            }
            GameScreen.player.typePk = msg.reader().readByte();
            GameScreen.player.pointPk = msg.reader().readShort();
            Player.maxInven = msg.reader().readByte();
            TabShopNew.maxTab = (sbyte)(Player.maxInven / 42);
            short num7 = msg.reader().readShort();
            if (num7 >= 0)
            {
                int idClan = msg.reader().readInt();
                GameScreen.player.myClan = new MainClan(idClan, num7, msg.reader().readUTF(), msg.reader().readByte());
            }
            GameScreen.nameSpecialRegion = msg.reader().readUTF();
            GameScreen.timeSpRegion = msg.reader().readLong();
            Skill.resetContent();
            GameScreen.player.typeObject = 0;
            GameScreen.player.name = text.ToLower();
            GameScreen.player.ID = iD;
            GameScreen.player.hp = hp;
            if (GameScreen.player.hp > 0 && GameScreen.player.Action == 4)
            {
                GameScreen.player.resetAction();
                GameScreen.player.weapon_frame = 0;
                GameScreen.player.Action = 0;
                GameScreen.player.vecBuff.removeAllElements();
                GlobalService.gI().player_move((short)GameScreen.player.x, (short)GameScreen.player.y);
            }
            GameScreen.player.maxHp = num;
            GameScreen.player.hpEffect = num / 10;
            GameScreen.player.mp = mp;
            GameScreen.player.maxMp = maxMp;
            GameScreen.player.clazz = clazz;
            GameScreen.player.weapon_frame = 0;
            if (!Player.isNewPlayer)
            {
                EventScreen.vecListEvent.removeAllElements();
                EventScreen.vecEventShow.removeAllElements();
                if (!GameScreen.Vecplayers.Equals(GameScreen.player))
                {
                    GameScreen.addPlayer(GameScreen.player);
                }
                GameScreen.player.init();
                Player.isNewPlayer = true;
                MsgChat.vecChatTab.removeAllElements();
                GameCanvas.msgchat.addNewChat(T.tinden, string.Empty, T.thongbaotuserver, ChatDetail.TYPE_SERVER, isFocus: false);
                Player.vecPlayerPk = new short[0];
                MainRMS.RequietRMS();
                GlobalService.gI().send_cmd_server(59);
                PaintInfoGameScreen.numMess = 0;
                GameScreen.VecInfoServer.removeAllElements();
                GameScreen.VecInfoChar.removeAllElements();
                GameScreen.infoGame.strInfoServer = null;
                GameScreen.infoGame.strInfoCharCline = null;
                GameScreen.infoGame.strInfoCharServer = null;
                Player.typeX2 = 0;
                if (GameScreen.player.Lv == 1)
                {
                    Player.isAutoFire = -1;
                }
                GlobalService.gI().Save_RMS_Server(1, 4, null);
                GlobalService.gI().Save_RMS_Server(1, 3, null);
                TemMidlet.submitPurchase();
            }
            MainTabNew.timePaintInfo = 0;
            sbyte b5 = msg.reader().readByte();
            short[] array2 = new short[b5];
            for (int num8 = 0; num8 < b5; num8++)
            {
                array2[num8] = -1;
                array2[num8] = msg.reader().readShort();
            }
            GameScreen.player.idPartFashion = array2;
            GameCanvas.naptien = msg.reader().readByte();
            short num9 = -1;
            try
            {
                num9 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num9 = -1;
            }
            GameScreen.player.idMatna = num9;
            try
            {
                sbyte b6 = msg.reader().readByte();
                if (b6 == 1)
                {
                    GameScreen.player.paintMatnaTruocNon = true;
                }
                else
                {
                    GameScreen.player.paintMatnaTruocNon = false;
                }
            }
            catch (Exception)
            {
            }
            short num10 = -1;
            try
            {
                num10 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num10 = -1;
            }
            GameScreen.player.idPhiPhong = num10;
            short num11 = -1;
            try
            {
                num11 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num11 = -1;
            }
            GameScreen.player.idWeaPon = num11;
            short num12 = -1;
            try
            {
                num12 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num12 = -1;
            }
            GameScreen.player.idHorse = num12;
            short num13 = -1;
            try
            {
                num13 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num13 = -1;
            }
            GameScreen.player.idHair = num13;
            short idWing = -1;
            try
            {
                idWing = msg.reader().readShort();
            }
            catch (Exception)
            {
                num13 = -1;
            }
            GameScreen.player.idWing = idWing;
            short num14 = -1;
            try
            {
                num14 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num14 = -1;
            }
            GameScreen.player.idName = num14;
            short idBody = -1;
            try
            {
                idBody = msg.reader().readShort();
            }
            catch (Exception)
            {
            }
            GameScreen.player.idBody = idBody;
            short idLeg = -1;
            try
            {
                idLeg = msg.reader().readShort();
            }
            catch (Exception)
            {
            }
            GameScreen.player.idLeg = idLeg;
            short idBienhinh = -1;
            try
            {
                idBienhinh = msg.reader().readShort();
            }
            catch (Exception)
            {
            }
            GameScreen.player.idBienhinh = idBienhinh;
        }
        catch (Exception ex12)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex12.ToString());
        }
    }

    public void objectMove(Message msg)
    {
        try
        {
            while (msg.reader().available() > 0)
            {
                sbyte b = msg.reader().readByte();
                short typeMonster = msg.reader().readShort();
                short num = msg.reader().readShort();
                short num2 = msg.reader().readShort();
                short num3 = msg.reader().readShort();
                sbyte b2 = msg.reader().readByte();
                //Debug.LogError("player id:" + num + " x: " + num2 + "- y: " + num3);
                if (!LoadMapScreen.isNextMap)
                {
                    continue;
                }
                if (b2 != sbyte.MaxValue)
                {
                    MainObject mainObject = MainObject.get_Object(num, b);
                    if (mainObject == null)
                    {
                        if (b == 1)
                        {
                            MainMonster.createMonster(num, num2, num3, typeMonster);
                            GlobalService.gI().monster_info(num);
                        }
                        else if (b == 0)
                        {
                            Other_Players other_Players = new Other_Players(num, b, string.Empty, num2, num3);
                            other_Players.Direction = CRes.random(4);
                            other_Players.setWearingListChar(null);
                            GameScreen.addPlayer(other_Players);
                            GlobalService.gI().char_info(num);
                            other_Players.timeRePlayerInfo = GameCanvas.timeNow;
                        }
                        else if (b == 2)
                        {
                            Other_Players other_Players2 = new Other_Players(num, b, string.Empty, num2, num3);
                            other_Players2.isObject = true;
                            GameScreen.addPlayer(other_Players2);
                            GlobalService.gI().new_npc_info(num);
                        }
                        continue;
                    }
                    if (mainObject.isRemove)
                    {
                        break;
                    }
                    if (mainObject == GameScreen.player)
                    {
                        if (CRes.abs(GameScreen.player.x - num2) > 24 || CRes.abs(GameScreen.player.y - num3) > 24)
                        {
                            Player.isLockKey = true;
                            Player.isSendMove = false;
                            GameScreen.player.toX = GameScreen.player.x;
                            GameScreen.player.toY = GameScreen.player.y;
                            GameScreen.player.xStopMove = num2;
                            GameScreen.player.yStopMove = num3;
                            try
                            {
                                GameScreen.player.posTransRoad = GameCanvas.game.updateFindRoad(num2 / LoadMap.wTile, num3 / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 20);
                            }
                            catch (Exception)
                            {
                                mainObject.x = num2;
                                mainObject.y = num3;
                                GameScreen.player.posTransRoad = null;
                                Player.isLockKey = false;
                                Player.isSendMove = true;
                            }
                        }
                        if (GameScreen.player.posTransRoad == null || GameScreen.player.posTransRoad.Length >= 20)
                        {
                            mainObject.x = num2;
                            mainObject.y = num3;
                            GameScreen.player.posTransRoad = null;
                            Player.isLockKey = false;
                            Player.isSendMove = true;
                        }
                    }
                    else if (mainObject.typeObject == 1)
                    {
                        mainObject.toX = num2;
                        mainObject.toY = num3;
                        mainObject.isMove = true;
                        if (b2 == 126)
                        {
                            if (mainObject.StepMovebocap != 1)
                            {
                                GameScreen.addEffectEndKill(54, mainObject.x, mainObject.y - 20);
                            }
                            mainObject.x = mainObject.toX;
                            mainObject.y = mainObject.toY;
                            mainObject.isMove = false;
                            mainObject.StepMovebocap = -1;
                        }
                        else if (b2 == 125)
                        {
                            mainObject.StepMovebocap = 0;
                        }
                    }
                    else if (mainObject.Action != 2 && mainObject.Action != 4 && mainObject.KillFire == -1)
                    {
                        mainObject.toX = num2;
                        mainObject.toY = num3;
                        mainObject.countCharStand = 0;
                        if (Player.party != null)
                        {
                            Player.party.setPos(mainObject.name, num2, num3, mainObject.hp, mainObject.maxHp);
                        }
                    }
                }
                else
                {
                    if (b2 != sbyte.MaxValue)
                    {
                        continue;
                    }
                    MainObject mainObject2 = MainObject.get_Object(num, b);
                    if (mainObject2 != null)
                    {
                        if (mainObject2.isRemove)
                        {
                            break;
                        }
                        mainObject2.isMoveOut = true;
                        mainObject2.xMoveOut = num2;
                        mainObject2.yMoveOut = num3;
                    }
                    else if (b == 0)
                    {
                        Other_Players other_Players3 = new Other_Players(num, b, string.Empty, num2, num3);
                        other_Players3.Direction = CRes.random(4);
                        other_Players3.setWearingListChar(null);
                        GameScreen.addPlayer(other_Players3);
                        GlobalService.gI().char_info(num);
                        other_Players3.timeRePlayerInfo = GameCanvas.timeNow;
                        mainObject2.isMoveOut = true;
                        mainObject2.xMoveOut = num2;
                        mainObject2.yMoveOut = num3;
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void newNPCInfo(Message msg)
    {
        try
        {
            short iD = msg.reader().readShort();
            string name = msg.reader().readUTF();
            int num = msg.reader().readInt();
            int hp = msg.reader().readInt();
            short lv = msg.reader().readShort();
            short num2 = msg.reader().readShort();
            short num3 = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            sbyte b2 = msg.reader().readByte();
            string text = msg.reader().readUTF();
            short num4 = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(iD, 2);
            if (mainObject == null || mainObject.isRemove)
            {
                mSystem.outz("New npc is null");
                return;
            }
            mainObject.name = name;
            mainObject.x = num2;
            mainObject.y = num3;
            mainObject.toX = num2;
            mainObject.toY = num3;
            mainObject.Lv = lv;
            mainObject.maxHp = num;
            mainObject.hp = hp;
            mainObject.hpEffect = num / 10;
            mainObject.imageId = num4;
            mainObject.typeObject = 2;
            if (num4 == -1)
            {
                sbyte b3 = msg.reader().readByte();
                sbyte b4 = msg.reader().readByte();
                sbyte b5 = msg.reader().readByte();
                mainObject.setInfo(b3, b4, b5);
                sbyte[] array = new sbyte[12];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = -1;
                }
                sbyte b6 = msg.reader().readByte();
                for (int j = 0; j < b6; j++)
                {
                    sbyte b7 = msg.reader().readByte();
                    sbyte b8 = msg.reader().readByte();
                    array[b7] = b8;
                }
                mainObject.setWearingListChar(array);
                short num5 = msg.reader().readShort();
                if (num5 != -1)
                {
                    int idClan = msg.reader().readInt();
                    string shortname = msg.reader().readUTF();
                    sbyte chucvu = msg.reader().readByte();
                    mainObject.myClan = new MainClan(idClan, num5, shortname, chucvu);
                }
                else
                {
                    mainObject.myClan = null;
                }
            }
            else
            {
                sbyte numFrame = msg.reader().readByte();
                short idBigAvatar = msg.reader().readShort();
                mainObject.numFrame = numFrame;
                mainObject.IdBigAvatar = idBigAvatar;
            }
        }
        catch (Exception)
        {
        }
    }

    public void charInfo(Message msg)
    {
        try
        {
            short iD = msg.reader().readShort();
            string text = msg.reader().readUTF();
            text = text.ToLower();
            short num = msg.reader().readShort();
            short num2 = msg.reader().readShort();
            sbyte clazz = msg.reader().readByte();
            sbyte b = msg.reader().readByte();
            sbyte b2 = msg.reader().readByte();
            sbyte b3 = msg.reader().readByte();
            sbyte b4 = msg.reader().readByte();
            short lv = msg.reader().readShort();
            int hp = msg.reader().readInt();
            int num3 = msg.reader().readInt();
            sbyte typePk = msg.reader().readByte();
            short pointPk = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(iD, 0);
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            if (b == -126 && text.EndsWith(","))
            {
                mainObject.iscuop = true;
                text = text.Substring(0, text.Length - 1);
            }
            mainObject.name = text;
            mainObject.toX = num;
            mainObject.toY = num2;
            mainObject.clazz = clazz;
            mainObject.weapon_frame = 0;
            mainObject.Lv = lv;
            mainObject.maxHp = num3;
            mainObject.hp = hp;
            mainObject.typePk = typePk;
            mainObject.hpEffect = num3 / 10;
            mainObject.pointPk = pointPk;
            mainObject.isBot = b;
            if (mainObject.isNPC())
            {
                mainObject.nameGiaotiep = mainObject.name;
                mainObject.infoObject = T.tuchoi;
                MiniMap.addNPCMini(new NPCMini(mainObject.isBot, num, num2));
            }
            if (b == -126)
            {
                mainObject.typeSpec = 1;
            }
            mainObject.setInfo(b2, b3, b4);
            if (Player.party != null)
            {
                Player.party.setObjParty(mainObject);
            }
            if (mainObject.hp <= 0)
            {
                mainObject.hp = 0;
                mainObject.mp = 0;
                mainObject.resetAction();
                mainObject.Action = 4;
                mainObject.timedie = GameCanvas.timeNow;
            }
            sbyte[] array = new sbyte[12];
            short[][] array2 = new short[12][];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = new short[3];
            }
            for (int j = 0; j < array2.Length; j++)
            {
                for (int k = 0; k < array2[j].Length; k++)
                {
                    array2[j][k] = -1;
                }
            }
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = -1;
            }
            sbyte b5 = msg.reader().readByte();
            mainObject.removeAllEffCharWearing();
            mSystem.outz(b5 + "  size ");
            for (int m = 0; m < b5; m++)
            {
                sbyte b6 = msg.reader().readByte();
                sbyte b7 = msg.reader().readByte();
                array[b6] = b7;
                sbyte b8 = msg.reader().readByte();
                for (int n = 0; n < b8; n++)
                {
                    array2[b6][n] = msg.reader().readShort();
                }
                short num4 = msg.reader().readShort();
                if (num4 != -1)
                {
                    if (b6 == 0)
                    {
                        mainObject.addEffectCharWearing(1, num4);
                    }
                    else if (b6 == 2)
                    {
                        mainObject.addEffectCharWearing(0, num4);
                    }
                    else if (b6 == 1)
                    {
                        mainObject.addEffectCharWearing(2, num4);
                    }
                }
            }
            mainObject.setWearingListChar(array);
            mainObject.setArrayGemKham(array2);
            short num5 = msg.reader().readShort();
            if (num5 >= 0)
            {
                int idClan = msg.reader().readInt();
                mainObject.myClan = new MainClan(idClan, num5, msg.reader().readUTF(), msg.reader().readByte());
            }
            else
            {
                mainObject.myClan = null;
            }
            sbyte b9 = msg.reader().readByte();
            if (b9 >= 0)
            {
                sbyte imageId = msg.reader().readByte();
                sbyte nFrame = msg.reader().readByte();
                MainObject mainObject2 = GameScreen.findOwner(mainObject);
                if (mainObject2 != null)
                {
                    GameScreen.Vecplayers.removeElement(mainObject2);
                }
                Pet pet = Pet.createPet(mainObject, b9, nFrame, imageId);
                if (pet != null)
                {
                    GameScreen.addPlayer(pet);
                }
            }
            sbyte b10 = msg.reader().readByte();
            short[] array3 = new short[b10];
            for (int num6 = 0; num6 < b10; num6++)
            {
                array3[num6] = -1;
                array3[num6] = msg.reader().readShort();
            }
            mainObject.idPartFashion = array3;
            try
            {
                mainObject.idImageHenshin = msg.reader().readShort();
            }
            catch (Exception)
            {
            }
            sbyte typeMount = msg.reader().readByte();
            bool isFootSnow = msg.reader().readBool();
            mainObject.isFootSnow = isFootSnow;
            mainObject.typeMount = typeMount;
            sbyte typefocus = msg.reader().readByte();
            sbyte typefire = msg.reader().readByte();
            mainObject.typefocus = typefocus;
            mainObject.typefire = typefire;
            short num7 = -1;
            try
            {
                num7 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num7 = -1;
            }
            mainObject.idMatna = num7;
            try
            {
                sbyte b11 = msg.reader().readByte();
                if (b11 == 1)
                {
                    mainObject.paintMatnaTruocNon = true;
                }
                else
                {
                    mainObject.paintMatnaTruocNon = false;
                }
            }
            catch (Exception)
            {
            }
            short num8 = -1;
            try
            {
                num8 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num8 = -1;
            }
            mainObject.idPhiPhong = num8;
            short num9 = -1;
            try
            {
                num9 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num9 = -1;
            }
            mainObject.idWeaPon = num9;
            short num10 = -1;
            try
            {
                num10 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num10 = -1;
            }
            mainObject.idHorse = num10;
            short num11 = -1;
            try
            {
                num11 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num11 = -1;
            }
            mainObject.idHair = num11;
            short num12 = -1;
            try
            {
                num12 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num12 = -1;
            }
            mainObject.idWing = num12;
            short num13 = -1;
            try
            {
                num13 = msg.reader().readShort();
            }
            catch (Exception)
            {
                num13 = -1;
            }
            mainObject.idName = num13;
            short idBody = -1;
            try
            {
                idBody = msg.reader().readShort();
            }
            catch (Exception)
            {
            }
            mainObject.idBody = idBody;
            short idLeg = -1;
            try
            {
                idLeg = msg.reader().readShort();
            }
            catch (Exception)
            {
            }
            mainObject.idLeg = idLeg;
            short idBienhinh = -1;
            try
            {
                idBienhinh = msg.reader().readShort();
            }
            catch (Exception)
            {
            }
            mainObject.idBienhinh = idBienhinh;
        }
        catch (Exception)
        {
        }
    }

    public void monsterInfo(Message msg)
    {
        try
        {
            short iD = msg.reader().readShort();
            short num = msg.reader().readUnsignedByte();
            short toX = msg.reader().readShort();
            short toY = msg.reader().readShort();
            int hp = msg.reader().readInt();
            int maxHp = msg.reader().readInt();
            sbyte id = msg.reader().readByte();
            int num2 = msg.reader().readInt();
            MainMonster mainMonster = (MainMonster)MainObject.get_Object(iD, 1);
            if (mainMonster == null || mainMonster.isRemove)
            {
                return;
            }
            mainMonster.Lv = num;
            mainMonster.toX = toX;
            mainMonster.toY = toY;
            mainMonster.hp = hp;
            mainMonster.maxHp = maxHp;
            mainMonster.isInfo = true;
            mainMonster.setLvmonster(num);
            mainMonster.timeReveice = num2;
            if (num2 == -2)
            {
                mainMonster.typeBoss = 1;
            }
            if (num2 == -3)
            {
                string text = msg.reader().readUTF();
                mSystem.outz("capchar day");
                mainMonster.typeBoss = 2;
                MainObject.vecCapchar.removeAllElements();
                MainObject.strCapchar = string.Empty;
                GameScreen.ObjFocus = mainMonster;
                GameCanvas.addInfoChar(T.helpCapchar);
            }
            if (num2 == -4)
            {
                mainMonster.typeBoss = 3;
                mainMonster.xPhoBang = msg.reader().readShort();
                mainMonster.yPhoBang = msg.reader().readShort();
            }
            if (num2 == -5)
            {
                mainMonster.typeBoss = 4;
                mainMonster.xPhoBang = msg.reader().readShort();
                mainMonster.yPhoBang = msg.reader().readShort();
            }
            short num3 = msg.reader().readShort();
            if (num3 >= 0)
            {
                int idClan = msg.reader().readInt();
                mainMonster.myClan = new MainClan(idClan, num3, msg.reader().readUTF(), msg.reader().readByte());
            }
            else
            {
                mainMonster.myClan = null;
            }
            mainMonster.skillDefault = new Monster_Skill(id);
            if (mainMonster.hp <= 0)
            {
                mainMonster.hp = 0;
                mainMonster.mp = 0;
                if (mainMonster.Action != 4)
                {
                    MainObject.startDeadFly(mainMonster, GameScreen.player.ID, CRes.random(3));
                }
            }
            if (mainMonster.typeMonster == 7)
            {
                MiniMap.addMonMini(mainMonster.ID, 1);
                mainMonster.name = msg.reader().readUTF();
            }
            sbyte b = msg.reader().readByte();
            sbyte b2 = msg.reader().readByte();
            sbyte b3 = msg.reader().readByte();
            mainMonster.isServerControl = b == 1;
            mainMonster.vMax = b2;
            mainMonster.Direction = b3;
            if (!(mainMonster.nameowner = msg.reader().readUTF()).Equals(string.Empty) || mainMonster.isMiNuong())
            {
                mainMonster.setspeedVantieu(b2);
            }
            long timelive = msg.reader().readLong();
            mainMonster.colorName = msg.reader().readByte();
            mainMonster.setTimelive(timelive);
            EffectMonster.addEffectMonster(mainMonster);
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void playerExit(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            if (num == GameScreen.player.ID)
            {
                return;
            }
            MainObject mainObject = MainObject.get_Object(num, 0);
            if (mainObject != null && !mainObject.isRemove)
            {
                Pet pet = (Pet)MainObject.get_Object(mainObject.ID, 9);
                if (pet != null)
                {
                    GameScreen.addEffectEndKill(35, pet.x, pet.y - 20);
                    pet.isStop = true;
                }
                GameScreen.addEffectEndKill(35, mainObject.x, mainObject.y - 20);
                mainObject.isStop = true;
            }
            MainObject mainObject2 = MainObject.get_Object(num, 1);
            if (mainObject2 != null && !mainObject2.isRemove)
            {
                GameScreen.addEffectEndKill(35, mainObject2.x, mainObject2.y - 20);
                mainObject2.isStop = true;
            }
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void changeMap(Message msg)
    {


        bool flag = false;
        try
        {
            GameCanvas.game.wRec = 0;
            GameCanvas.game.isFullScreen = false;
            GameScreen.infoGame.idCharLoiDai1 = -1;
            GameScreen.infoGame.idCharLoiDai2 = -1;
            if (Main.isWindowsPhone)
            {
                MiniMap.isStartMiniMap = false;
            }
            LoadMapScreen.isNextMap = false;
            if (Player.isAutoFire > -1)
            {
                Player.setCurAutoFire();
            }
            if (GameCanvas.currentScreen != GameCanvas.load)
            {
                GameCanvas.load.Show();
            }
            GameScreen.Remove_ChangeMap();
            GameScreen.RemoveLoadMap();
            GameCanvas.loadmap.idMap = msg.reader().readShort();
            GameCanvas.worldmap.setPosPlayer(GameCanvas.loadmap.idMap);
            GameScreen.infoGame.setCountTimeHS(GameCanvas.loadmap.idMap, mSystem.currentTimeMillis(), 30);
            GameScreen.player.x = msg.reader().readShort() * 24;
            GameScreen.player.y = msg.reader().readShort() * 24;
            GameScreen.player.xStand = GameScreen.player.x;
            GameScreen.player.yStand = GameScreen.player.y;
            GameScreen.player.resetMove();
            GameScreen.player.posTransRoad = null;
            GameScreen.player.resetAction();
            if (GameScreen.pet != null)
            {
                GameScreen.pet.x = GameScreen.player.x;
                GameScreen.pet.y = GameScreen.player.y;
                GameScreen.pet.clearWayPoints();
            }
            GameCanvas.loadmap.idMapMini = msg.reader().readShort();
            GameCanvas.loadmap.nameMap = msg.reader().readUTF();

            //UpdateMapVisitCount(GameCanvas.loadmap.nameMap);

            short num = msg.reader().readShort();
            Debug.LogError("size data map: " + num);
            sbyte[] data = null;
            if (num > 0)
            {
                data = new sbyte[num];
                msg.reader().read(ref data);
            }
            GameCanvas.loadmap.loadmap(GameCanvas.loadmap.idMap, data);
            sbyte b = msg.reader().readByte();
            short height_background = 0;
            if (b >= 0)
            {
                short h = msg.reader().readShort();
                GameCanvas.mapBack = new MapBackGround();
                GameCanvas.mapBack.setBackGround(b, h);
                height_background = h;
            }
            else
            {
                GameCanvas.mapBack = null;
            }
            short num2 = msg.reader().readShort();
            Debug.LogError("size data item: " + num2);
            GameCanvas.load.mItemMap = null;
            if (num2 > 0)
            {
                GameCanvas.load.mItemMap = new sbyte[num2];
                msg.reader().read(ref GameCanvas.load.mItemMap);
                GameCanvas.loadmap.load_ItemMap(GameCanvas.loadmap.idMap, GameCanvas.load.mItemMap);
            }
            GameScreen.player.useShip = false;
            if (GameCanvas.loadmap.idMap == 19)
            {
                GameScreen.infoGame.eff = new EffectAuto(50, 1080, 96, 0, 0, 1, 0);
            }
            else if (GameCanvas.loadmap.idMap == 67)
            {
                GameScreen.infoGame.eff = new EffectAuto(50, 360, 672, 0, 0, 1, 0);
            }
            if (Main.isWindowsPhone)
            {
                MiniMap.isStartMiniMap = true;
            }
            LoadMap.me.idMap = GameCanvas.loadmap.idMap;
            LoadMap.vecPointChange.removeAllElements();
            sbyte b2 = msg.reader().readByte();
            for (int i = 0; i < b2; i++)
            {
                Point point = new Point();
                point.x = msg.reader().readShort();
                point.y = msg.reader().readShort();
                point.name = msg.reader().readUTF();

                string filex = $"G://LOG_SQL//map_waypoints.sql";
                string sqlx = $"INSERT INTO map_waypoints (x, y, name) " +
                    $"VALUES ({point.x}, {point.y}, '{point.name}');\n";
                File.AppendAllText(filex, sqlx);
                int num3 = 100;
                if (point.x < num3)
                {
                    point.dis = 0;
                    point.x2 = point.x - 8;
                    point.y2 = point.y - 18;
                    point.f = 0;
                    point.vx = -1;
                }
                else if (point.x > GameCanvas.loadmap.mapW * LoadMap.wTile - num3)
                {
                    point.dis = 1;
                    point.f = 1;
                    point.x2 = point.x + 8;
                    point.y2 = point.y - 18;
                    point.vx = 1;
                }
                else if (point.y < GameCanvas.loadmap.mapW * LoadMap.wTile / 2)
                {
                    point.y -= 10;
                    point.dis = 2;
                    point.f = 2;
                    point.x2 = point.x;
                    point.y2 = point.y + 10;
                    point.vy = -1;
                }
                else
                {
                    point.dis = 3;
                    point.f = 2;
                    point.x2 = point.x;
                    point.y2 = point.y - 20;
                    point.vy = 1;
                }
                LoadMap.vecPointChange.addElement(point);
            }
            try
            {
                GameCanvas.minimap.setSize();
            }
            catch (Exception ex)
            {
                mSystem.println("----loi readmess minimap.setSize:" + ex.ToString());
            }
            sbyte b3 = msg.reader().readByte();
            LoadMap.Area = msg.reader().readByte();
            GameCanvas.end_Dialog();
            GameCanvas.clearKeyHold();
            GameCanvas.load.isTele = false;
            if (b3 == 1)
            {
                GameCanvas.load.isTele = true;
            }
            LoadMap.typeMap = msg.reader().readByte();
            if (LoadMap.typeMap == LoadMap.MAP_PET_CONTAINER)
            {
                GameScreen.isInPetArea = true;
            }
            else
            {
                GameScreen.isInPetArea = false;
            }
            LoadMapScreen.isNextMap = true;
            GameCanvas.timenextLogin = 0L;
            GameCanvas.countLogin = 0L;
            try
            {
                GameScreen.isMapLang = msg.reader().readBool();
                GameScreen.isShowHoiSinh = msg.reader().readBool();

                //string file = $"G://LOG_SQL//map_template.sql";
                //string sql = $"INSERT INTO map_template (id, mini_map, name, type, area, village, challengeable) " +
                //$"VALUES ({GameCanvas.loadmap.idMap}, {GameCanvas.loadmap.idMapMini}, '{GameCanvas.loadmap.nameMap}', {LoadMap.typeMap}, {LoadMap.Area}, {GameScreen.isMapLang}, {GameScreen.isShowHoiSinh});\n";
                //File.AppendAllText(file, sql);

                string file = $"G://LOG_SQL//map_template.sql";
                string sql = $"UPDATE map_template " +
                             $"SET mini_map = {GameCanvas.loadmap.idMapMini}, " +
                             $"name = '{GameCanvas.loadmap.nameMap}', " +
                             $"background = {b}," +
                             $"height_background = {height_background}," +
                             $"type = {LoadMap.typeMap}, " +
                             $"area = {LoadMap.Area}, " +
                             $"village = {GameScreen.isMapLang}, " +
                             $"challengeable = {GameScreen.isShowHoiSinh} " +
                             $"WHERE id = {GameCanvas.loadmap.idMap};\n";
                File.AppendAllText(file, sql);


            }
            catch (Exception)
            {
                GameScreen.isShowHoiSinh = false;
                GameScreen.isMapLang = false;
            }
        }
        catch (Exception ex3)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex3.ToString());
            if (flag)
            {
                LoadMapScreen.isNextMap = true;
            }
        }
    }

    private void UpdateMapVisitCount(string mapName)
    {
        if (GlobalService.mapVisitCount.ContainsKey(mapName))
        {
            GlobalService.mapVisitCount[mapName]++;
        }
        else
        {
            GlobalService.mapVisitCount[mapName] = 1;
        }

        Debug.Log($"Map '{mapName}' đã được vào {GlobalService.mapVisitCount[mapName]} lần.");
    }


    public void fireMonster(Message msg)
    {
        try
        {
            Fire_Object(msg, 0, 1);
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void charWearing(Message msg)
    {
        MainObject mainObject = null;
        try
        {
            short iD = msg.reader().readShort();
            mainObject = MainObject.get_Object(iD, 0);
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            sbyte b = msg.reader().readByte();
            sbyte[] array = new sbyte[b];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }
            if (mainObject == GameScreen.player)
            {
                Item.VecEquipPlayer.clear();
                if (GameScreen.pet != null)
                {
                    GameScreen.Vecplayers.removeElement(GameScreen.pet);
                }
                for (int j = 0; j < mainObject.slotGem.Length; j++)
                {
                    mainObject.slotGem[j] = -1;
                }
            }
            bool isFootSnow = false;
            mainObject.removeAllEffCharWearing();
            for (int k = 0; k < b; k++)
            {
                sbyte b2 = msg.reader().readByte();
                if (b2 > -1)
                {
                    string itemName = msg.reader().readUTF();
                    sbyte b3 = msg.reader().readByte();
                    sbyte b4 = msg.reader().readByte();
                    short imageId = msg.reader().readShort();
                    sbyte b5 = msg.reader().readByte();
                    sbyte plusItem = msg.reader().readByte();
                    short lvItem = msg.reader().readShort();
                    sbyte b6 = msg.reader().readByte();
                    array[k] = b5;
                    sbyte b7 = msg.reader().readByte();
                    MainInfoItem[] array2 = new MainInfoItem[b7];
                    for (int l = 0; l < b7; l++)
                    {
                        int num = msg.reader().readUnsignedByte();
                        array2[l] = new MainInfoItem(num, msg.reader().readInt());
                        if (b2 == 8 && num == 67)
                        {
                            isFootSnow = true;
                        }
                    }
                    sbyte isLock = msg.reader().readByte();
                    MainItem mainItem = MainItem.MainItem_Item(b2, itemName, imageId, plusItem, b6, b3, 3, array2, b4, isTem: false, -1, 0L, lvItem, 0, 0, 0, 0, isLock);
                    if (mainObject != GameScreen.player)
                    {
                        continue;
                    }
                    Item.VecEquipPlayer.put(string.Empty + b2, mainItem);
                    if (mainItem.moreContenGem.size() > 0)
                    {
                        for (int m = 0; m < mainItem.moreContenGem.size(); m++)
                        {
                            InfocontenNew infocontenNew = (InfocontenNew)mainItem.moreContenGem.elementAt(m);
                            if (infocontenNew.idimage >= 23 && infocontenNew.idimage <= 27)
                            {
                                mainObject.slotGem[m] = 0;
                            }
                            else if (infocontenNew.idimage >= 28 && infocontenNew.idimage <= 32)
                            {
                                mainObject.slotGem[m] = 1;
                            }
                            else if (infocontenNew.idimage == -1)
                            {
                                mainObject.slotGem[m] = -1;
                            }
                        }
                    }
                    if (b4 == 1)
                    {
                        foreach (MainInfoItem mainInfoItem in array2)
                        {
                            if (mainInfoItem.id == 71)
                            {
                                mainObject.addEffectCharWearing(2, mainInfoItem.value);
                            }
                        }
                    }
                    if (b4 == 0)
                    {
                        foreach (MainInfoItem mainInfoItem2 in array2)
                        {
                            if (mainInfoItem2.id == 71)
                            {
                                mainObject.addEffectCharWearing(1, mainInfoItem2.value);
                            }
                        }
                    }
                    if (b4 != 2)
                    {
                        continue;
                    }
                    foreach (MainInfoItem mainInfoItem3 in array2)
                    {
                        if (mainInfoItem3.id == 71)
                        {
                            mainObject.addEffectCharWearing(0, mainInfoItem3.value);
                        }
                    }
                }
                else
                {
                    array[k] = -1;
                }
            }
            mainObject.isFootSnow = isFootSnow;
            int catagory = 9;
            sbyte b8 = 14;
            sbyte b9 = msg.reader().readByte();
            sbyte imageId2 = 0;
            sbyte nFrame = 6;
            if (b9 > -1)
            {
                string itemName2 = msg.reader().readUTF();
                sbyte b10 = msg.reader().readByte();
                short level = msg.reader().readShort();
                short experience = msg.reader().readShort();
                sbyte b11 = msg.reader().readByte();
                sbyte b12 = msg.reader().readByte();
                imageId2 = b12;
                sbyte b13 = msg.reader().readByte();
                nFrame = b13;
                sbyte b14 = msg.reader().readByte();
                int age = msg.reader().readInt();
                short growPoint = msg.reader().readShort();
                short maxgrow = msg.reader().readShort();
                short str = msg.reader().readShort();
                short agi = msg.reader().readShort();
                short hea = msg.reader().readShort();
                short spi = msg.reader().readShort();
                short maxtiemnang = msg.reader().readShort();
                sbyte b15 = msg.reader().readByte();
                MainInfoItem[] array3 = new MainInfoItem[b15];
                for (int num4 = 0; num4 < b15; num4++)
                {
                    int id = msg.reader().readUnsignedByte();
                    int value = msg.reader().readInt();
                    int maxDam = msg.reader().readInt();
                    array3[num4] = new MainInfoItem(id, value, maxDam);
                }
                PetItem petItem = new PetItem(b9, itemName2, b11, b14, b10, catagory, array3, b8, level, b11, b13, b12);
                petItem.setInfoPet(age, growPoint, str, agi, hea, spi, maxgrow, maxtiemnang, experience);
                sbyte b16 = msg.reader().readByte();
                if (b16 == 1)
                {
                    int timeDefault = msg.reader().readInt();
                    string s = msg.reader().readUTF();
                    petItem.setTimeUser(timeDefault, long.Parse(s));
                }
                if (mainObject == GameScreen.player)
                {
                    Item.VecEquipPlayer.put(string.Empty + b9, petItem);
                }
                array[5] = b11;
                if (GameCanvas.subDialog != null && GameCanvas.subDialog.type == 14 && MsgDialog.isInven_Equip == MsgDialog.EQUIP)
                {
                    MsgDialog.pet = petItem;
                }
            }
            mainObject.setWearingEquip(array);
            if (mainObject.Equals(GameScreen.player))
            {
                Pet pet = null;
                if (GameScreen.player.pet != -1)
                {
                    pet = Pet.createPet(GameScreen.player, (short)GameScreen.player.pet, nFrame, imageId2);
                }
                GameScreen.pet = pet;
                if (GameScreen.pet != null)
                {
                    GameScreen.addPlayer(GameScreen.pet);
                }
            }
            sbyte b17 = msg.reader().readByte();
            short[] array4 = new short[b17];
            for (int num5 = 0; num5 < b17; num5++)
            {
                array4[num5] = -1;
                array4[num5] = msg.reader().readShort();
            }
            mainObject.idPartFashion = array4;
        }
        catch (Exception)
        {
            mSystem.outloi(" wearing ");
            if (GameScreen.player == null)
            {
                return;
            }
            if (mainObject == GameScreen.player)
            {
                Session_ME.gI().close();
                mVector mVector3 = new mVector("ReadMessenge vec2");
                if (SelectCharScreen.isSelectOk && GameCanvas.currentScreen != GameCanvas.login)
                {
                    mVector3.addElement(new iCommand(T.again, 0));
                }
                mVector3.addElement(new iCommand(T.exit, 6));
                GameCanvas.start_Select_Dialog(T.disconnect, mVector3);
                Debug.LogError("Disconnect");
                if (GameScreen.player != null)
                {
                    GameScreen.player.resetAction();
                }
            }
            else
            {
                mainObject.isRemove = true;
            }
        }
    }

    public void dieMonster(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            short num2 = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(num2, 1);
            if (GameScreen.help.setStep_Next(1, 2) && num == GameScreen.player.ID)
            {
                GameScreen.help.Next++;
                GameScreen.help.setNext();
                Player.isAutoFire = -1;
            }
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            if (mainObject.hp != 0)
            {
                mainObject.hp = 0;
            }
            mainObject.coutEff = 100;
            if (mainObject.Action == 4 || mainObject.isDie)
            {
                if (mainObject.typeBoss != 0)
                {
                    mainObject.isRemove = true;
                    if (mainObject.typeBoss == 2)
                    {
                        MainObject.imgCapchar = null;
                    }
                }
                mainObject.timedie = GameCanvas.timeNow;
                return;
            }
            mainObject.hp = 0;
            if (mainObject.typeBoss != 0)
            {
                mainObject.isRemove = true;
                if (mainObject.typeBoss == 2)
                {
                    MainObject.imgCapchar = null;
                }
            }
            else
            {
                MainObject.startDeadFly((MainMonster)mainObject, num, CRes.random(3));
            }
            if (num == GameScreen.player.ID && mainObject.timeReveice >= 0)
            {
                MainQuest.updateQuestKillMonster(num2);
            }
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void petAttack(Message msg)
    {
        try
        {
            sbyte skillId = msg.reader().readByte();
            short iD = msg.reader().readShort();
            sbyte tem = msg.reader().readByte();
            sbyte b = msg.reader().readByte();
            mVector mVector3 = new mVector("ReadMessenge vecObjectBeAttacked");
            for (int i = 0; i < b; i++)
            {
                short num = msg.reader().readShort();
                int hpShow = msg.reader().readInt();
                int hpLast = msg.reader().readInt();
                Monster_Skill skill = new Monster_Skill(14);
                Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill(num, tem, skill);
                object_Effect_Skill.setHP(hpShow, hpLast);
                MainObject mainObject = MainObject.get_Object(num, tem);
                if (mainObject != null && !mainObject.isRemove)
                {
                    mVector3.addElement(object_Effect_Skill);
                }
            }
            Pet pet = (Pet)MainObject.get_Object(iD, 9);
            MainObject mainObject2 = MainObject.get_Object(iD, 0);
            int hp = msg.reader().readInt();
            int mp = msg.reader().readInt();
            if (mainObject2 != null)
            {
                mainObject2.hp = hp;
                mainObject2.mp = mp;
            }
            if (pet != null)
            {
                pet.vecObjskill = mVector3;
                pet.setState(2);
                pet.initAttackState(skillId);
            }
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void monsterFire(Message msg)
    {
        sbyte b = -1;
        sbyte b2 = -1;
        try
        {
            b = msg.reader().readByte();
            short iD = msg.reader().readShort();
            MainMonster mainMonster = (MainMonster)MainObject.get_Object(iD, 1);
            if (mainMonster == null || mainMonster.isRemove)
            {
                return;
            }
            bool flag = mainMonster.isBossNew();
            if (mainMonster.Action == 4)
            {
                if (mainMonster.timeReveice < 0)
                {
                    return;
                }
                mainMonster.Reveive();
            }
            mainMonster.isMove = false;
            mainMonster.vx = 0;
            mainMonster.vy = 0;
            if (b == 1)
            {
                int hp = msg.reader().readInt();
                sbyte tem = msg.reader().readByte();
                b2 = msg.reader().readByte();
                mainMonster.hp = hp;
                if (b2 <= 0)
                {
                    return;
                }
                if (mainMonster.vecObjskill != null && mainMonster.vecObjskill.size() > 0)
                {
                    Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)mainMonster.vecObjskill.elementAt(0);
                    mainMonster.IDAttack = object_Effect_Skill.ID;
                    if (mainMonster.skillDefault == null)
                    {
                        mainMonster.skillDefault = new Monster_Skill(14);
                    }
                    if (!flag)
                    {
                        object_Effect_Skill.skillMonster = mainMonster.skillDefault;
                    }
                    mainMonster.beginFire();
                    mainMonster.beginSkill();
                }
                mVector mVector3 = new mVector("ReadMessenge vecBe");
                bool flag2 = false;
                mVector mVector4 = new mVector("ReadMessenge allPlayerDie");
                for (int i = 0; i < b2; i++)
                {
                    short num = msg.reader().readShort();
                    int hpShow = msg.reader().readInt();
                    int num2 = msg.reader().readInt();
                    sbyte id = msg.reader().readByte();
                    Monster_Skill skill = new Monster_Skill(id);
                    Object_Effect_Skill object_Effect_Skill2 = new Object_Effect_Skill(num, tem, skill);
                    object_Effect_Skill2.setHP(hpShow, num2);
                    sbyte b3 = msg.reader().readByte();
                    object_Effect_Skill2.mEffTypePlus = new int[b3];
                    object_Effect_Skill2.mEff_HP_Plus = new int[b3];
                    for (int j = 0; j < b3; j++)
                    {
                        object_Effect_Skill2.mEffTypePlus[j] = msg.reader().readByte();
                        object_Effect_Skill2.mEff_HP_Plus[j] = msg.reader().readInt();
                    }
                    MainObject mainObject = MainObject.get_Object(num, tem);
                    if (mainObject != null && !mainObject.isRemove)
                    {
                        mVector3.addElement(object_Effect_Skill2);
                        if (mainObject.hp > 0)
                        {
                            mainObject.hp = num2;
                        }
                        if (mainObject.ID == GameScreen.player.ID)
                        {
                            int maxHp = GameScreen.player.maxHp;
                            int num3 = num2 / maxHp * 100;
                            GameScreen.player.setPainthit(4, num3 > 20);
                        }
                        if (mainObject.hp <= 0)
                        {
                            flag2 = true;
                            mVector4.addElement(mainObject);
                        }
                    }
                }
                mainMonster.vecObjskill = mVector3;
                mainMonster.hp = hp;
                mainMonster.isRunAttack = true;
                mainMonster.timeMaxMoveAttack = 3000;
                mainMonster.timeBeginMoveAttack = GameCanvas.timeNow;
                if (flag2 || mainMonster.typeBoss == 1 || mainMonster.typeBoss == 2)
                {
                    Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)mainMonster.vecObjskill.elementAt(0);
                    mainMonster.IDAttack = object_Effect_Skill3.ID;
                    if (mainMonster.skillDefault == null)
                    {
                        mainMonster.skillDefault = new Monster_Skill(14);
                    }
                    if (!flag)
                    {
                        object_Effect_Skill3.skillMonster = mainMonster.skillDefault;
                    }
                    mainMonster.beginFire();
                    mainMonster.beginSkill();
                }
                for (int k = 0; k < mVector4.size(); k++)
                {
                    MainObject mainObject2 = (MainObject)mVector4.elementAt(k);
                    mainObject2.resetAction();
                    mainObject2.Action = 4;
                    mainObject2.timedie = GameCanvas.timeNow;
                    mainObject2.f = 0;
                    GameScreen.addEffectEndKill(11, mainObject2.x, mainObject2.y);
                }
            }
            else
            {
                if (b != 0)
                {
                    return;
                }
                if (mainMonster.vecObjskill != null && mainMonster.vecObjskill.size() > 0)
                {
                    Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)mainMonster.vecObjskill.elementAt(0);
                    mainMonster.IDAttack = object_Effect_Skill4.ID;
                    if (mainMonster.skillDefault == null)
                    {
                        mainMonster.skillDefault = new Monster_Skill(14);
                    }
                    if (!flag)
                    {
                        object_Effect_Skill4.skillMonster = mainMonster.skillDefault;
                    }
                    mainMonster.beginFire();
                    mainMonster.beginSkill();
                }
                mainMonster.isRunAttack = false;
                mainMonster.posTransRoad = null;
            }
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void loadImage(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            string path = string.Empty + num;
            sbyte[] data = new sbyte[msg.reader().available()];
            msg.reader().read(ref data);
            if (num == 9999)
            {
                MainObject.imgCapchar = mImage.createImage(data, 0, data.Length, path);
                return;
            }
            if (ObjectData.setIdOK(num))
            {
                SaveImageRMS.vecSaveImage.addElement(new idSaveImage(num, data));
            }
            mImage im = mImage.createImage(data, 0, data.Length, path);

            if (num >= 13000)
            {
                Item.HashImageItem.put(string.Empty + (num - 2000), new MainImage(im));
            }
            else if (num >= 10700)
            {
                Item.HashImageMount.put(string.Empty + (num - 10700), new MainImage(im));
            }
            else if (num >= 10200)
            {
                Pet.HashImagePet.put(string.Empty + (num - 10200), new MainImage(im));
            }
            else if (num >= 10000)
            {
                Item.HashImagePetIcon.put(string.Empty + (num - 10000), new MainImage(im));
            }
            else if (num >= 9500)
            {
                Item.HashImageIconArcheClan.put(string.Empty + (num - 9500), new MainImage(im));
            }
            else if (num >= 7000)
            {
                Item.HashImageIconClan.put(string.Empty + (num - 7000), new MainImage(im));
            }
            else if (num >= 6000)
            {
                Skill.hashImageSkill.put(string.Empty + (num - 6000), new MainImage(im));
            }
            else if (num >= 5500)
            {
                Item.HashImageMaterial.put(string.Empty + (num - 5500), new MainImage(im));
            }
            else if (num >= 5000)
            {
                Item.HashImageQuestItem.put(string.Empty + (num - 5000), new MainImage(im));
            }
            else if (num >= 4000)
            {
                Item.HashImagePotion.put(string.Empty + (num - 4000), new MainImage(im));
            }
            else if (num >= 3000)
            {
                GameScreen.HashImageNPC.put(string.Empty + (num - 3000), new MainImage(im));
            }
            else if (num >= 2000)
            {
                Item.HashImageItem.put(string.Empty + (num - 2000), new MainImage(im));
            }
            else if (num >= 1000)
            {
                MainMonster.HashImageMonster.put(string.Empty + (num - 1000), new MainImage(im));
            }
            else
            {
                GameScreen.HashImageItemMap.put(string.Empty + num, new MainImage(im));
            }
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void charInventory(Message msg)
    {
        update_InVen_Or_Chest(msg, Item.VecInvetoryPlayer, MainTabNew.INVENTORY);
    }

    public static sbyte getColorNum(short id, int num)
    {
        for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
        {
            Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
            if (item != null && item.ItemCatagory == 7 && item.Id == id && item.numPotion >= num)
            {
                return 1;
            }
        }
        return 0;
    }

    public static string getInfoNum(short id, int num)
    {
        for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
        {
            Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
            if (item != null && item.ItemCatagory == 7 && item.Id == id)
            {
                return item.numPotion + "/" + num;
            }
        }
        return 0 + "/" + num;
    }

    public void npcInfo(Message msg)
    {
        try
        {
            string filePath = @"G://LOG_SQL//shop_items.sql";
            sbyte typeShop = MainTabNew.SHOP;
            string nameCmd = string.Empty;
            bool isShop_Other_Player = false;
            string text = msg.reader().readUTF();// name 
            sbyte b = msg.reader().readByte();// type 
            TabShopNew.isTabHopNL = false;
            if (b < 0)
            {
                MainObject mainObject = MainObject.get_Object(b, 2);
                if (mainObject != null && !mainObject.isRemove)
                {
                    mainObject.strChatPopup = text;
                }
                return;
            }
            GameCanvas.start_Ok_Dialog(T.danglaydulieu);
            short num = msg.reader().readShort();
            mVector mVector3 = new mVector("ReadMessenge vectorInfoNPC");
            sbyte isTypeShop = TabShopNew.NORMAL;
            sbyte isTypeShop2 = TabShopNew.NORMAL;
            if (b == SHOP_OTHER_PLAYER)
            {
                isShop_Other_Player = true;
                isTypeShop2 = TabShopNew.SHOP_STORE_OTHER_PLAYER;
                for (int i = 0; i < num; i++)
                {
                    sbyte b2 = msg.reader().readByte();
                    if (b2 == 3)
                    {
                        short num2 = msg.reader().readShort();
                        string itemName = msg.reader().readUTF();
                        sbyte b3 = msg.reader().readByte();
                        sbyte b4 = msg.reader().readByte();
                        short imageId = msg.reader().readShort();
                        sbyte plusItem = msg.reader().readByte();
                        short lvItem = msg.reader().readShort();
                        sbyte b5 = msg.reader().readByte();
                        sbyte b6 = msg.reader().readByte();
                        MainInfoItem[] array = new MainInfoItem[b6];
                        for (int j = 0; j < b6; j++)
                        {
                            int id = msg.reader().readUnsignedByte();
                            int value = msg.reader().readInt();
                            array[j] = new MainInfoItem(id, value);
                        }
                        sbyte typeMoney = msg.reader().readByte();
                        MainItem o = MainItem.MainItem_Item(num2, itemName, imageId, plusItem, b5, b3, 3, array, b4, isTem: false, num2, 0L, lvItem, 0, 0, 0, typeMoney, 0);
                        mVector3.addElement(o);
                    }
                    if (b2 == 7)
                    {
                        short num3 = msg.reader().readShort();
                        short num4 = msg.reader().readShort();
                        sbyte b7 = msg.reader().readByte();
                        sbyte b8 = msg.reader().readByte();
                        long num5 = msg.reader().readLong();
                        MainItem material = Item.getMaterial(num3);
                        if (material != null)
                        {
                            MainItem o2 = MainItem.MainItem_Material(num3, material.itemName, material.imageId, 7, num5, 0, material.content, material.value, material.typeMaterial, num4, b7, b8);
                            mVector3.addElement(o2);
                        }
                        else
                        {
                            MainItem mainItem = new MainItem();
                            mainItem.Id = num3;
                            mainItem.numPotion = num4;
                            mainItem.canSell = b7;
                            mainItem.canTrade = b8;
                            mainItem.priceItem = num5;
                            mainItem.priceType = 0;
                            mainItem.ItemCatagory = 7;
                            Item.put_Material(num3);
                            mVector3.addElement(mainItem);
                        }
                    }
                    if (b2 == 4)
                    {
                        short id2 = msg.reader().readShort();
                        short numPotion = msg.reader().readShort();
                        long price = msg.reader().readLong();
                        MainTemplateItem potionTem = MainTemplateItem.getPotionTem(id2);
                        if (potionTem != null)
                        {
                            MainItem o3 = new MainItem(potionTem.ID, potionTem.IconId, potionTem.name, potionTem.contentPotion, numPotion, 4, price, potionTem.typePotion, 0, 0, 0);
                            mVector3.addElement(o3);
                        }
                    }
                }
                short idSeller = msg.reader().readShort();
                TabShopNew.idSeller = idSeller;
            }
            else if (b == SHOP_VANTIEU)
            {
                isTypeShop2 = TabShopNew.SHOP_VANTIEU;
                for (int k = 0; k < num; k++)
                {
                    short num6 = msg.reader().readShort();
                    string itemName2 = msg.reader().readUTF();
                    sbyte b9 = msg.reader().readByte();
                    sbyte b10 = msg.reader().readByte();
                    short imageId2 = msg.reader().readShort();
                    long price2 = msg.reader().readLong();
                    short lvItem2 = msg.reader().readShort();
                    sbyte b11 = msg.reader().readByte();
                    sbyte b12 = msg.reader().readByte();
                    MainInfoItem[] array2 = new MainInfoItem[b12];
                    for (int l = 0; l < b12; l++)
                    {
                        int id3 = msg.reader().readUnsignedByte();
                        int value2 = msg.reader().readInt();
                        array2[l] = new MainInfoItem(id3, value2);
                    }
                    sbyte typeMoney2 = msg.reader().readByte();
                    MainItem o4 = MainItem.MainItem_Item(num6, itemName2, imageId2, 0, b11, b9, 3, array2, b10, isTem: false, num6, price2, lvItem2, 0, 0, 0, typeMoney2, 0);
                    mVector3.addElement(o4);
                }
            }
            else if (b == SHOP_POTION)
            {
                for (int m = 0; m < num; m++)
                {
                    short id4 = msg.reader().readShort();
                    MainTemplateItem potionTem2 = MainTemplateItem.getPotionTem(id4);
                    if (potionTem2 != null)
                    {
                        MainItem o5 = new MainItem(potionTem2.ID, potionTem2.IconId, potionTem2.name, potionTem2.contentPotion, 1, 4, potionTem2.PricePoition, potionTem2.typePotion, potionTem2.moneyType, 0, 0);
                        mVector3.addElement(o5);
                    }
                }
            }
            else if (b == SHOP_ITEM || b == WING || b == SHOP_ITEM_EVENT)
            {
                if (b == WING)
                {
                    isTypeShop2 = TabShopNew.WING;
                }
                for (int n = 0; n < num; n++)
                {
                    short num7 = msg.reader().readShort();
                    string itemName3 = msg.reader().readUTF();
                    sbyte b13 = msg.reader().readByte();
                    sbyte b14 = msg.reader().readByte();
                    short imageId3 = msg.reader().readShort();
                    long price3 = msg.reader().readLong();
                    short lvItem3 = msg.reader().readShort();
                    sbyte b15 = msg.reader().readByte();
                    sbyte b16 = msg.reader().readByte();
                    MainInfoItem[] array3 = new MainInfoItem[b16];
                    for (int num8 = 0; num8 < b16; num8++)
                    {
                        int id5 = msg.reader().readUnsignedByte();
                        int value3 = msg.reader().readInt();
                        array3[num8] = new MainInfoItem(id5, value3);
                    }
                    sbyte typeMoney3 = msg.reader().readByte();
                    MainItem mainItem2 = MainItem.MainItem_Item(num7, itemName3, imageId3, 0, b15, b13, 3, array3, b14, isTem: false, num7, price3, lvItem3, 0, 0, 0, typeMoney3, 0);

                    string sql = $"INSERT INTO shop_items (item_id, shop_type_id, item_name, image_id, base_price, price_type, level, description, character_class) VALUES " +
                                      $"({num7}, {b}, '{itemName3}', {imageId3}, {price3},  {typeMoney3}, {lvItem3}, '{text}', {getClass});\n";


                    //(int ID, string itemName, int imageId, sbyte plusItem, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short LvItem, sbyte issell, sbyte istrade, int timeUse, sbyte typeMoney, sbyte isLock)


                    File.AppendAllText(filePath, sql);

                    if (b == SHOP_ITEM_EVENT)
                    {
                        mainItem2.diaHoiEvent = msg.reader().readUTF();
                    }
                    mVector3.addElement(mainItem2);
                }
                if (b == SHOP_ITEM_EVENT)
                {
                    nameCmd = msg.reader().readUTF();
                }
            }
            else if (b == SHOP_HAIR)
            {

                isTypeShop2 = TabShopNew.TOC;
                for (int num9 = 0; num9 < num; num9++)
                {
                    short num10 = msg.reader().readShort();
                    string itemName4 = msg.reader().readUTF();
                    short imageId4 = msg.reader().readShort();
                    long price4 = msg.reader().readLong();
                    sbyte priceType = msg.reader().readByte();
                    sbyte b17 = msg.reader().readByte();
                    MainInfoItem[] array4 = new MainInfoItem[b17];
                    string dataArray = "";
                    try
                    {
                        for (int num11 = 0; num11 < b17; num11++)
                        {
                            int id6 = msg.reader().readUnsignedByte();
                            int value4 = msg.reader().readInt();

                            array4[num11] = new MainInfoItem(id6, value4);

                            dataArray += $"[{id6 + "," + value4}]";
                        }
                        MainItem o6 = MainItem.MainItem_Toc(num10, itemName4, imageId4, 0, 6, array4, isTem: false, num10, price4, priceType, 0, 0);



                        string sql = $"INSERT INTO shop_items (item_id, shop_type_id, item_name, image_id, base_price, price_type, level, description, character_class) VALUES " +
                                          $"({num10}, {b}, '{itemName4}', {imageId4}, {price4},  {priceType}, {0}, '{text}', {getClass});\n";
                        File.AppendAllText(filePath, sql);

                        mVector3.addElement(o6);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError(ex);
                    }

                }

            }
            else if (b == CHEST)
            {
                isTypeShop = TabShopNew.INVEN_AND_CHEST;
                typeShop = MainTabNew.CHEST;
                if (Item.VecChestPlayer.size() == 0)
                {
                    GlobalService.gI().Update_Char_Chest(-1, 0, 0, 0);
                }
                mVector3 = Item.VecChestPlayer;
            }
            else if (b == PET_KEEPER)
            {
                isTypeShop = TabShopNew.INVEN_AND_PET_KEEPER;
                typeShop = MainTabNew.PET_KEEPER;
                isTypeShop2 = TabShopNew.INVEN_AND_PET_KEEPER;
            }
            else if (b == SHOP_MATERIAL)
            {
                typeShop = MainTabNew.SHOP;
                for (int num12 = 0; num12 < num; num12++)
                {
                    short num13 = msg.reader().readShort();
                    MainItem material2 = Item.getMaterial(num13);
                    if (material2 != null)
                    {
                        MainItem o7 = MainItem.MainItem_Material(num13, material2.itemName, material2.imageId, 7, material2.priceItem, material2.priceType, material2.content, (short)material2.value, material2.typeMaterial, 1, material2.canSell, material2.canTrade);
                        mVector3.addElement(o7);
                        continue;
                    }
                    MainItem mainItem3 = new MainItem();
                    mainItem3.Id = num13;
                    mainItem3.ItemCatagory = 7;
                    mVector3.addElement(mainItem3);
                }
            }
            else if (b == REBUILD || b == TAB_HOP_NGUYEN_LIEU)
            {
                isTypeShop = TabShopNew.INVEN_AND_REBUILD;
                typeShop = MainTabNew.REBUILD;
                if (b == TAB_HOP_NGUYEN_LIEU)
                {
                    TabShopNew.isTabHopNL = true;
                }
            }
            else if (b == SHOP_HOP_AN)
            {
                isTypeShop = TabShopNew.SHOP_HOP_AN;
                typeShop = MainTabNew.REBUILD;
            }
            else if (b == SHOP_NANG_CAP_MEDAL)
            {
                isTypeShop = TabShopNew.SHOP_NANG_CAP_MEDEL;
                typeShop = MainTabNew.REBUILD;
            }
            else if (b == SHOP_ANY_NGUYEN_LIEU)
            {
                isTypeShop = TabShopNew.SHOP_ANY_NGUYEN_LIEU;
                typeShop = MainTabNew.REBUILD;
            }
            else if (b == SHOP_GHEP_NGOC)
            {
                isTypeShop = TabShopNew.SHOP_GHEP_NGOC;
                typeShop = MainTabNew.REBUILD;
            }
            else if (b == SHOP_DUC_LO)
            {
                isTypeShop = TabShopNew.SHOP_DUC_LO;
                typeShop = MainTabNew.REBUILD;
            }
            else if (b == SHOP_KHAM_NGOC)
            {
                isTypeShop = TabShopNew.SHOP_KHAM_NGOC;
                typeShop = MainTabNew.REBUILD;
            }
            else if (b == SHOP_ICONCLAN_FREE || b == SHOP_ICONCLAN_VIP)
            {
                typeShop = MainTabNew.SHOP;
                isTypeShop2 = TabShopNew.SHOP_BANG;
                for (int num14 = 0; num14 < num; num14++)
                {
                    short num15 = 0;
                    if (b == SHOP_ICONCLAN_VIP)
                    {
                        num15 = TabShopNew.PriceIconClan;
                    }
                    MainItem o8 = new MainItem(msg.reader().readShort(), num15);
                    mVector3.addElement(o8);
                }
            }
            else if (b == SHOP_POTION_CLAN)
            {
                typeShop = MainTabNew.SHOP;
                isTypeShop2 = TabShopNew.NORMAL;
                for (int num16 = 0; num16 < num; num16++)
                {
                    short id7 = msg.reader().readShort();
                    MainTemplateItem potionTem3 = MainTemplateItem.getPotionTem(id7);
                    if (potionTem3 != null)
                    {
                        MainItem o9 = new MainItem(potionTem3.ID, potionTem3.IconId, potionTem3.name, potionTem3.contentPotion, 1, 4, potionTem3.PricePoition, potionTem3.typePotion, potionTem3.moneyType, 0, 0);
                        mVector3.addElement(o9);
                    }
                }
            }
            else if (b == REPLACE)
            {
                isTypeShop = TabShopNew.INVEN_AND_REPLACE;
                typeShop = MainTabNew.REBUILD;
            }
            mVector mVector4 = new mVector("ReadMessenge vec11");
            if (b != SHOP_ICONCLAN_FREE && b != SHOP_ICONCLAN_VIP && b != SHOP_POTION_CLAN)
            {
                TabShopNew tabShopNew = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.tabhanhtrang, -1, isTypeShop);
                tabShopNew.isShop_Other_Player = isShop_Other_Player;
                mVector4.addElement(tabShopNew);
            }
            MainTabNew mainTabNew = null;
            if (b == REBUILD || b == TAB_HOP_NGUYEN_LIEU)
            {
                mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_REBUILD);
                mainTabNew.isTabHopNguyenLieu = b == TAB_HOP_NGUYEN_LIEU;
                if (b == TAB_HOP_NGUYEN_LIEU)
                {
                    TabShopNew.isTabHopNL = true;
                }
                TabRebuildItem.itemRe = null;
                TabRebuildItem.itemPlus = null;
                TabRebuildItem.itemFree = null;
                for (int num17 = 0; num17 < TabRebuildItem.idMaterial.Length; num17++)
                {
                    MainItem material3 = Item.getMaterial(TabRebuildItem.idMaterial[num17]);
                    int num18 = 0;
                    if (material3 != null)
                    {
                        Item itemInventory = Item.getItemInventory(material3.ItemCatagory, (short)material3.Id);
                        if (itemInventory != null)
                        {
                            num18 = itemInventory.numPotion;
                        }
                    }
                    TabRebuildItem.numMaterialInven[num17] = num18;
                }
            }
            else if (b == SHOP_KHAM_NGOC)
            {
                mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_KHAM_NGOC);
                TabRebuildItem.vecGem.removeAllElements();
                TabRebuildItem.itemRe = null;
                TabRebuildItem.itemPlus = null;
                TabRebuildItem.itemFree = null;
                for (int num19 = 0; num19 < TabRebuildItem.idMaterial.Length; num19++)
                {
                    MainItem material4 = Item.getMaterial(TabRebuildItem.idMaterial[num19]);
                    int num20 = 0;
                    if (material4 != null)
                    {
                        Item itemInventory2 = Item.getItemInventory(material4.ItemCatagory, (short)material4.Id);
                        if (itemInventory2 != null)
                        {
                            num20 = itemInventory2.numPotion;
                        }
                    }
                    TabRebuildItem.numMaterialInven[num19] = num20;
                }
            }
            else if (b == SHOP_DUC_LO)
            {
                mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_DUC_LO);
                TabRebuildItem.vecGem.removeAllElements();
                TabRebuildItem.itemRe = null;
                TabRebuildItem.itemPlus = null;
                TabRebuildItem.itemFree = null;
                for (int num21 = 0; num21 < TabRebuildItem.idMaterial.Length; num21++)
                {
                    MainItem material5 = Item.getMaterial(TabRebuildItem.idMaterial[num21]);
                    int num22 = 0;
                    if (material5 != null)
                    {
                        Item itemInventory3 = Item.getItemInventory(material5.ItemCatagory, (short)material5.Id);
                        if (itemInventory3 != null)
                        {
                            num22 = itemInventory3.numPotion;
                        }
                    }
                    TabRebuildItem.numMaterialInven[num21] = num22;
                }
            }
            else if (b == SHOP_HOP_AN)
            {
                mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_ANY);
                mainTabNew.isCreate_medal = true;
                TabRebuildItem.vecGem.removeAllElements();
                TabRebuildItem.itemRe = null;
                TabRebuildItem.itemPlus = null;
                TabRebuildItem.itemFree = null;
                for (int num23 = 0; num23 < TabRebuildItem.idMaterial.Length; num23++)
                {
                    MainItem material6 = Item.getMaterial(TabRebuildItem.idMaterial[num23]);
                    int num24 = 0;
                    if (material6 != null)
                    {
                        Item itemInventory4 = Item.getItemInventory(material6.ItemCatagory, (short)material6.Id);
                        if (itemInventory4 != null)
                        {
                            num24 = itemInventory4.numPotion;
                        }
                    }
                    TabRebuildItem.numMaterialInven[num23] = num24;
                }
                int num25 = msg.reader().readByte();
                TabRebuildItem.vecGem.removeAllElements();
                for (int num26 = 0; num26 < num25; num26++)
                {
                    short num27 = msg.reader().readShort();
                    short num28 = msg.reader().readShort();
                    sbyte b18 = 7;
                    if (num27 != -1 && b18 == 7)
                    {
                        TabRebuildItem.numColor[num26] = getColorNum(num27, num28);
                        TabRebuildItem.numofGem[num26] = getInfoNum(num27, num28);
                        MainItem material7 = Item.getMaterial(num27);
                        if (material7 != null)
                        {
                            TabRebuildItem.vecGem.addElement(material7);
                        }
                        if (material7 == null)
                        {
                            MainItem mainItem4 = new MainItem();
                            mainItem4.Id = num27;
                            mainItem4.ItemCatagory = 7;
                            TabRebuildItem.vecGem.addElement(mainItem4);
                        }
                    }
                }
            }
            else if (b == SHOP_NANG_CAP_MEDAL)
            {
                mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_ANY);
                mainTabNew.isUPgradeMedal = true;
                TabRebuildItem.vecGem.removeAllElements();
                TabRebuildItem.itemRe = null;
                TabRebuildItem.itemPlus = null;
                TabRebuildItem.itemFree = null;
                for (int num29 = 0; num29 < TabRebuildItem.idMaterial.Length; num29++)
                {
                    MainItem material8 = Item.getMaterial(TabRebuildItem.idMaterial[num29]);
                    int num30 = 0;
                    if (material8 != null)
                    {
                        Item itemInventory5 = Item.getItemInventory(material8.ItemCatagory, (short)material8.Id);
                        if (itemInventory5 != null)
                        {
                            num30 = itemInventory5.numPotion;
                        }
                    }
                    TabRebuildItem.numMaterialInven[num29] = num30;
                }
            }
            else if (b == SHOP_ANY_NGUYEN_LIEU)
            {
                mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_ANY);
                TabRebuildItem.vecGem.removeAllElements();
                TabRebuildItem.itemRe = null;
                TabRebuildItem.itemPlus = null;
                TabRebuildItem.itemFree = null;
                for (int num31 = 0; num31 < TabRebuildItem.idMaterial.Length; num31++)
                {
                    MainItem material9 = Item.getMaterial(TabRebuildItem.idMaterial[num31]);
                    int num32 = 0;
                    if (material9 != null)
                    {
                        Item itemInventory6 = Item.getItemInventory(material9.ItemCatagory, (short)material9.Id);
                        if (itemInventory6 != null)
                        {
                            num32 = itemInventory6.numPotion;
                        }
                    }
                    TabRebuildItem.numMaterialInven[num31] = num32;
                }
            }
            else if (b == SHOP_GHEP_NGOC)
            {
                mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_GHEP_NGOC);
                TabRebuildItem.vecGem.removeAllElements();
                TabRebuildItem.itemRe = null;
                TabRebuildItem.itemPlus = null;
                TabRebuildItem.itemFree = null;
                for (int num33 = 0; num33 < TabRebuildItem.idMaterial.Length; num33++)
                {
                    MainItem material10 = Item.getMaterial(TabRebuildItem.idMaterial[num33]);
                    int num34 = 0;
                    if (material10 != null)
                    {
                        Item itemInventory7 = Item.getItemInventory(material10.ItemCatagory, (short)material10.Id);
                        if (itemInventory7 != null)
                        {
                            num34 = itemInventory7.numPotion;
                        }
                    }
                    TabRebuildItem.numMaterialInven[num33] = num34;
                }
            }
            else if (b == REPLACE)
            {
                mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_REPLACE_PLUS);
                TabRebuildItem.itemRe = null;
                TabRebuildItem.itemPlus = null;
                TabRebuildItem.itemFree = null;
            }
            else
            {
                mainTabNew = new TabShopNew(mVector3, typeShop, text, b, isTypeShop2);
                if (b == SHOP_ITEM_EVENT)
                {
                    mainTabNew.setNameCmd(nameCmd);
                }
            }
            mVector4.addElement(mainTabNew);
            GameCanvas.shopNpc = new TabScreenNew();
            if (b != SHOP_ICONCLAN_FREE && b != SHOP_ICONCLAN_VIP && b != SHOP_POTION_CLAN)
            {
                GameCanvas.shopNpc.selectTab = 1;
            }
            else
            {
                GameCanvas.shopNpc.selectTab = 0;
            }
            GameCanvas.shopNpc.addMoreTab(mVector4);
            GameCanvas.shopNpc.Show(GameScreen.gI());
            GameCanvas.end_Dialog();
            if (b == REBUILD || b == REPLACE || b == TAB_HOP_NGUYEN_LIEU)
            {
                mainTabNew.init();
            }
        }
        catch (Exception)
        {
            mSystem.outloi("hay loi day ah");
        }
    }

    public void itemTemplate(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            for (int i = 0; i < num; i++)
            {
                short num2 = msg.reader().readShort();
                short iconId = msg.reader().readShort();
                long price = msg.reader().readLong();
                string name = msg.reader().readUTF();
                string content = msg.reader().readUTF();
                sbyte typepotion = msg.reader().readByte();
                sbyte moneytype = msg.reader().readByte();
                sbyte sell = msg.reader().readByte();
                short value = msg.reader().readShort();
                bool canTrade = msg.reader().readBoolean();
                MainTemplateItem v = new MainTemplateItem(num2, iconId, price, name, content, typepotion, moneytype, sell, value, canTrade);
                MainTemplateItem.hashPotionTem.put(string.Empty + num2, v);
            }
            int num3 = msg.reader().readUnsignedByte();
            Item.nameInfoItem = new string[num3];
            Item.colorInfoItem = new sbyte[num3];
            Item.isPercentInfoItem = new sbyte[num3];
            for (int j = 0; j < num3; j++)
            {
                Item.nameInfoItem[j] = msg.reader().readUTF();
                Item.colorInfoItem[j] = msg.reader().readByte();
                Item.isPercentInfoItem[j] = msg.reader().readByte();
            }
            short num4 = msg.reader().readShort();
            for (int k = 0; k < num4; k++)
            {
                short num5 = msg.reader().readShort();
                short imageId = msg.reader().readShort();
                long price2 = msg.reader().readLong();
                string itemName = msg.reader().readUTF();
                string content2 = msg.reader().readUTF();
                sbyte typeitem = msg.reader().readByte();
                sbyte priceType = msg.reader().readByte();
                sbyte sell2 = msg.reader().readByte();
                short value2 = msg.reader().readShort();
                sbyte trade = msg.reader().readByte();
                sbyte b = msg.reader().readByte();
                MainItem mainItem = MainItem.MainItem_Material(num5, itemName, imageId, 7, price2, priceType, content2, value2, typeitem, 1, sell2, trade);
                mainItem.setColorName(b);
                MainTemplateItem.hashMaterialTem.put(string.Empty + num5, mainItem);
            }
            TabShopNew.priceSellPotion = msg.reader().readShort();
            TabShopNew.priceSellItem = msg.reader().readShort();
            TabShopNew.hesoLv = msg.reader().readShort();
            TabShopNew.hesoColor = msg.reader().readShort();
            TabShopNew.priceSellQuest = msg.reader().readShort();
            TabShopNew.maxPriceItem = msg.reader().readShort();
            TabShopNew.PriceIconClan = msg.reader().readShort();
            TabShopNew.PriceChatWorld = msg.reader().readByte();
            LoginScreen.indexInfoLogin = 0;
            sbyte b2 = msg.reader().readByte();
            mSystem.outz("size pet template = " + b2);
            for (int l = 0; l < b2; l++)
            {
                short num6 = msg.reader().readShort();
                sbyte b3 = msg.reader().readByte();
                MainTemplateItem.hashPetTem.put(string.Empty + num6, b3);
            }
            try
            {
                sbyte b4 = msg.reader().readByte();
                MainObject.idMaterialHopNguyenLieu = new short[b4];
                for (int m = 0; m < b4; m++)
                {
                    MainObject.idMaterialHopNguyenLieu[m] = msg.reader().readShort();
                }
            }
            catch (Exception)
            {
                mSystem.println("----Err Readmess:-- itemTemplate");
            }
            sbyte b5 = 0;
            try
            {
                b5 = msg.reader().readByte();
                PaintInfoGameScreen.paint18plush = b5;
            }
            catch (Exception)
            {
                PaintInfoGameScreen.paint18plush = 0;
            }
            try
            {
                sbyte b6 = msg.reader().readByte();
                GameScreen.idmap18 = new short[b6];
                for (int n = 0; n < b6; n++)
                {
                    GameScreen.idmap18[n] = msg.reader().readUnsignedByte();
                }
            }
            catch (Exception)
            {
                GameScreen.idmap18 = new short[0];
            }
        }
        catch (Exception)
        {
            Session_ME.gI().close();
            mVector mVector3 = new mVector("ReadMessenge vec7");
            if (SelectCharScreen.isSelectOk && GameCanvas.currentScreen != GameCanvas.login)
            {
                mVector3.addElement(new iCommand(T.again, 0));
            }
            mVector3.addElement(new iCommand(T.exit, 6));
            GameCanvas.start_Select_Dialog(T.disconnect, mVector3);

            // Log bug
            Debug.LogError("Disconnect");

        }
    }

    public void catalogyMonster(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            for (int i = 0; i < num; i++)
            {
                short id = msg.reader().readShort();
                string name = msg.reader().readUTF();
                short lv = msg.reader().readUnsignedByte();
                int maxHp = msg.reader().readInt();
                sbyte b = msg.reader().readByte();
                CatalogyMonster o = new CatalogyMonster(id, lv, maxHp, b, name);
                MainMonster.VecCatalogyMonSter.addElement(o);
            }
            sbyte b2 = msg.reader().readByte();
            MountTemplate.FRAME_VE_TRUOC = new sbyte[b2][];
            for (int j = 0; j < b2; j++)
            {
                int num2 = msg.reader().readByte();
                MountTemplate.FRAME_VE_TRUOC[j] = new sbyte[num2];
                for (int k = 0; k < num2; k++)
                {
                    MountTemplate.FRAME_VE_TRUOC[j][k] = msg.reader().readByte();
                }
            }
            b2 = msg.reader().readByte();
            MountTemplate.DY_CHAR_STAND = new sbyte[b2][];
            for (int l = 0; l < b2; l++)
            {
                int num3 = msg.reader().readByte();
                MountTemplate.DY_CHAR_STAND[l] = new sbyte[num3];
                for (int m = 0; m < num3; m++)
                {
                    MountTemplate.DY_CHAR_STAND[l][m] = msg.reader().readByte();
                }
            }
            b2 = msg.reader().readByte();
            MountTemplate.DY_CHAR_MOVE = new sbyte[b2][];
            for (int n = 0; n < b2; n++)
            {
                int num4 = msg.reader().readByte();
                MountTemplate.DY_CHAR_MOVE[n] = new sbyte[num4];
                for (int num5 = 0; num5 < num4; num5++)
                {
                    MountTemplate.DY_CHAR_MOVE[n][num5] = msg.reader().readByte();
                }
            }
            b2 = msg.reader().readByte();
            MountTemplate.dx = new sbyte[b2][];
            for (int num6 = 0; num6 < b2; num6++)
            {
                int num7 = msg.reader().readByte();
                MountTemplate.dx[num6] = new sbyte[num7];
                for (int num8 = 0; num8 < num7; num8++)
                {
                    MountTemplate.dx[num6][num8] = msg.reader().readByte();
                }
            }
            b2 = msg.reader().readByte();
            MountTemplate.dy = new sbyte[b2][];
            for (int num9 = 0; num9 < b2; num9++)
            {
                int num10 = msg.reader().readByte();
                MountTemplate.dy[num9] = new sbyte[num10];
                for (int num11 = 0; num11 < num10; num11++)
                {
                    MountTemplate.dy[num9][num11] = msg.reader().readByte();
                }
            }
            b2 = msg.reader().readByte();
            MountTemplate.FRAME_MOVE_LR = new sbyte[b2][];
            for (int num12 = 0; num12 < b2; num12++)
            {
                int num13 = msg.reader().readByte();
                MountTemplate.FRAME_MOVE_LR[num12] = new sbyte[num13];
                for (int num14 = 0; num14 < num13; num14++)
                {
                    MountTemplate.FRAME_MOVE_LR[num12][num14] = msg.reader().readByte();
                }
            }
            b2 = msg.reader().readByte();
            MountTemplate.FRAME_MOVE_DOWN = new sbyte[b2][];
            for (int num15 = 0; num15 < b2; num15++)
            {
                int num16 = msg.reader().readByte();
                MountTemplate.FRAME_MOVE_DOWN[num15] = new sbyte[num16];
                for (int num17 = 0; num17 < num16; num17++)
                {
                    MountTemplate.FRAME_MOVE_DOWN[num15][num17] = msg.reader().readByte();
                }
            }
            b2 = msg.reader().readByte();
            MountTemplate.FRAME_MOVE_UP = new sbyte[b2][];
            for (int num18 = 0; num18 < b2; num18++)
            {
                int num19 = msg.reader().readByte();
                MountTemplate.FRAME_MOVE_UP[num18] = new sbyte[num19];
                for (int num20 = 0; num20 < num19; num20++)
                {
                    MountTemplate.FRAME_MOVE_UP[num18][num20] = msg.reader().readByte();
                }
            }
            b2 = msg.reader().readByte();
            MountTemplate.speed = new sbyte[b2];
            for (int num21 = 0; num21 < b2; num21++)
            {
                MountTemplate.speed[num21] = msg.reader().readByte();
            }
            sbyte b3 = msg.reader().readByte();
            Item.ATB_Can_Not_Paint = new sbyte[b3];
            for (int num22 = 0; num22 < b3; num22++)
            {
                Item.ATB_Can_Not_Paint[num22] = msg.reader().readByte();
            }
            try
            {
                sbyte b4 = msg.reader().readByte();
                Pet.mTypemove = new sbyte[b4];
                for (int num23 = 0; num23 < b4; num23++)
                {
                    Pet.mTypemove[num23] = msg.reader().readByte();
                }
                if (Pet.mTypemove == null || Pet.mTypemove.Length == 0 || b4 == 0)
                {
                    Pet.mTypemove = new sbyte[6] { 2, 1, 0, 2, 0, 1 };
                }
            }
            catch (Exception)
            {
                Pet.mTypemove = new sbyte[6] { 2, 1, 0, 2, 0, 1 };
            }
            try
            {
                sbyte b5 = msg.reader().readByte();
                MainTemplateItem.mItem_Equip_Tem = new int[b5];
                for (int num24 = 0; num24 < b5; num24++)
                {
                    MainTemplateItem.mItem_Equip_Tem[num24] = msg.reader().readByte();
                }
                if (MainTemplateItem.mItem_Equip_Tem == null || MainTemplateItem.mItem_Equip_Tem.Length == 0 || b5 == 0)
                {
                    MainTemplateItem.mItem_Equip_Tem = new int[25]
                    {
                        -1, 0, 3, 4, 5, 12, 2, 1, 6, 4,
                        7, -2, -2, -2, -2, -2, -2, -2, -2, -2,
                        -2, -2, -2, -2, -2
                    };
                }
            }
            catch (Exception)
            {
                MainTemplateItem.mItem_Equip_Tem = new int[25]
                {
                    -1, 0, 3, 4, 5, 12, 2, 1, 6, 4,
                    7, -2, -2, -2, -2, -2, -2, -2, -2, -2,
                    -2, -2, -2, -2, -2
                };
            }
            try
            {
                sbyte b6 = msg.reader().readByte();
                MainTemplateItem.mItem_Rotate_Tem_Equip = new int[b6];
                for (int num25 = 0; num25 < b6; num25++)
                {
                    MainTemplateItem.mItem_Rotate_Tem_Equip[num25] = msg.reader().readByte();
                }
                if (MainTemplateItem.mItem_Rotate_Tem_Equip == null || MainTemplateItem.mItem_Rotate_Tem_Equip.Length == 0 || b6 == 0)
                {
                    MainTemplateItem.mItem_Rotate_Tem_Equip = new int[13]
                    {
                        1, 7, 6, 2, -1, 4, 8, 10, 0, 0,
                        0, 0, 5
                    };
                }
            }
            catch (Exception)
            {
                MainTemplateItem.mItem_Rotate_Tem_Equip = new int[13]
                {
                    1, 7, 6, 2, -1, 4, 8, 10, 0, 0,
                    0, 0, 5
                };
            }
            try
            {
                sbyte b7 = msg.reader().readByte();
                MainMonster.idBossNew = new short[b7];
                for (int num26 = 0; num26 < b7; num26++)
                {
                    MainMonster.idBossNew[num26] = msg.reader().readShort();
                }
                if (MainMonster.idBossNew == null || MainMonster.idBossNew.Length == 0 || b7 == 0)
                {
                    MainMonster.idBossNew = new short[5] { 104, 103, 105, 106, 135 };
                }
            }
            catch (Exception)
            {
                MainTemplateItem.mItem_Rotate_Tem_Equip = new int[13]
                {
                    1, 7, 6, 2, -1, 4, 8, 10, 0, 0,
                    0, 0, 5
                };
            }
            try
            {
                int num27 = msg.reader().readByte();
                Player.ID_HAIR_NO_HAT = new sbyte[num27];
                for (int num28 = 0; num28 < num27; num28++)
                {
                    Player.ID_HAIR_NO_HAT[num28] = msg.reader().readByte();
                }
            }
            catch (Exception)
            {
                Player.ID_HAIR_NO_HAT = null;
            }
            try
            {
                sbyte b8 = msg.reader().readByte();
                for (int num29 = 0; num29 < b8; num29++)
                {
                    sbyte b9 = msg.reader().readByte();
                    short num30 = msg.reader().readShort();
                    if (num30 > 0)
                    {
                        sbyte[] array = new sbyte[num30];
                        for (int num31 = 0; num31 < num30; num31++)
                        {
                            array[num31] = msg.reader().readByte();
                        }
                        mVector mVector3 = new mVector();
                        DataEffect o2 = new DataEffect(array, b9, isMonster: true);
                        mVector3.addElement(o2);
                        Pet.PET_DATA.put(string.Empty + b9, mVector3);
                    }
                }
            }
            catch (Exception)
            {
            }
            sbyte[][] array2;
            try
            {
                short num32 = msg.reader().readShort();
                array2 = new sbyte[num32][];
                for (int num33 = 0; num33 < num32; num33++)
                {
                    sbyte b10 = msg.reader().readByte();
                    array2[num33] = new sbyte[b10];
                    for (int num34 = 0; num34 < b10; num34++)
                    {
                        array2[num33][num34] = msg.reader().readByte();
                    }
                }
            }
            catch (Exception)
            {
                array2 = null;
            }
            if (array2 != null)
            {
                EffectSkill.arrInfoEff = array2;
            }
            sbyte b11 = 0;
            sbyte[] array3;
            try
            {
                b11 = msg.reader().readByte();
                array3 = new sbyte[b11];
                for (int num35 = 0; num35 < b11; num35++)
                {
                    array3[num35] = msg.reader().readByte();
                }
            }
            catch (Exception)
            {
                array3 = null;
            }
            if (array3 != null)
            {
                MountTemplate.Arr_Fly = array3;
                b11 = 0;
            }
        }
        catch (Exception ex9)
        {
            Debug.LogWarning((object)"vao cho nay ne ");
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex9.ToString());
        }
    }

    public void listChar(Message msg)
    {
        try
        {
            LoginScreen.saveUser_Pass();
            LoginScreen.saveversionGame();
            LoginScreen.saveIndexServer();
            GameScreen.player = new Player(0, 0, "unname", 0, 0);
            Item.VecInvetoryPlayer.removeAllElements();
            Item.VecChestPlayer.removeAllElements();
            SelectCharScreen.VecSelectChar.removeAllElements();
            sbyte b = msg.reader().readByte();
            mVector mVector3 = new mVector("ReadMessenge vList");
            int num = (GameCanvas.w - 150) / 4;
            int num2 = num;
            for (int i = 0; i < b; i++)
            {
                int num3 = GameCanvas.hh - 25 - 20 * ((i + 1) % 2);
                int iD = msg.reader().readInt();
                string name = msg.reader().readUTF();
                sbyte b2 = msg.reader().readByte();
                sbyte b3 = msg.reader().readByte();
                sbyte b4 = msg.reader().readByte();
                sbyte b5 = msg.reader().readByte();
                sbyte[] array = new sbyte[12];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = -1;
                }
                for (int k = 0; k < b5; k++)
                {
                    sbyte b6 = msg.reader().readByte();
                    sbyte b7 = msg.reader().readByte();
                    array[b6] = b7;
                }
                short lv = msg.reader().readShort();
                sbyte clazz = msg.reader().readByte();
                msg.reader().readByte();
                msg.reader().readByte();
                Other_Players other_Players = new Other_Players(iD, 0, name, 0, 0);
                short num4 = msg.reader().readShort();
                if (num4 >= 0)
                {
                    other_Players.myClan = new MainClan(0, num4, msg.reader().readUTF(), msg.reader().readByte());
                }
                other_Players.clazz = clazz;
                this.getClass = clazz;
                other_Players.setInfo(b2, b4, b3);
                other_Players.setWearingListChar(array);
                other_Players.Lv = lv;
                other_Players.x = num2 + 25;
                other_Players.y = num3 + 50;
                num2 += 50 + num;
                mVector3.addElement(other_Players);
            }
            GameCanvas.selectChar.setPosPaint(mVector3);
            if (b == 0)
            {
                GameCanvas.createChar = new CreateChar();
                GameCanvas.createChar.Show(0);
            }
            else
            {
                GameCanvas.selectChar.Show();
            }
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void npcBig(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();// size list npc
            for (int i = 0; i < b; i++)
            {
                string name = msg.reader().readUTF();// ten npc
                string text = msg.reader().readUTF();// caption
                sbyte b2 = msg.reader().readByte();// id npc
                sbyte b3 = msg.reader().readByte();// IDImage
                short num = msg.reader().readShort();
                short num2 = msg.reader().readShort();
                sbyte wBlock = msg.reader().readByte();
                sbyte hBlock = msg.reader().readByte();
                sbyte nFrame = msg.reader().readByte();
                MainObject mainObject = MainObject.get_Object(b2, 2);
                bool flag = true;
                if (mainObject == null)
                {
                    mainObject = new NPC(name, text, b2, b3, num, num2, wBlock, hBlock, nFrame);
                }
                else
                {
                    flag = false;
                    mainObject.name = name;
                    mainObject.nameGiaotiep = text;
                    mainObject.imageId = b3;
                    mainObject.x = num;
                    mainObject.y = num2;
                }

                mainObject.isRemove = false;
                mainObject.IdBigAvatar = msg.reader().readByte() + 500;
                mainObject.infoObject = msg.reader().readUTF();
                mainObject.isPerson = msg.reader().readByte();
                mainObject.isShowHP = msg.reader().readByte() == 1;

                string filePath = $"G://LOG_SQL//npc_template.sql";

                string sql = $"INSERT INTO npc_template (id_map ,name, caption, id_npc, image_id, x, y, wBlock, hBlock, nFrame, avatar_id, communication, is_person, show_hp) VALUES (" +
                    $"{GameCanvas.loadmap.idMap}, '{name}', '{text}', {b2}, {b3}, {num}, {num2}, {wBlock}, {hBlock}, {nFrame}, {mainObject.IdBigAvatar}, '{mainObject.infoObject}', {mainObject.isPerson}, {mainObject.isShowHP});\n";

                System.IO.File.AppendAllText(filePath, sql);

                string fileupdate = $"G://LOG_SQL//npc_template_update.sql";
                string sqlupdate = $"UPDATE npc_template SET id_map = {GameCanvas.loadmap.idMap}, name = '{name}', caption = '{text}', image_id = {b3}, x = {num}, y = {num2}, wBlock = {wBlock}, hBlock = {hBlock}, nFrame = {nFrame}, avatar_id = {mainObject.IdBigAvatar}, communication = '{mainObject.infoObject}', is_person = {mainObject.isPerson}, show_hp = {mainObject.isShowHP} WHERE id_npc = {b2};\n";
                System.IO.File.AppendAllText(fileupdate, sqlupdate);

                mainObject.typeObject = 2;
                GameScreen.addPlayer(mainObject);
                MiniMap.addNPCMini(new NPCMini(b2, num, num2));
                if (b2 == -52)
                {
                    Mount mount = new Mount(0, 2, num + 48, num2 + 10);
                    if (!GameScreen.Vecplayers.contains(mount))
                    {
                        GameScreen.addPlayer(mount);
                    }
                    mount = null;
                    mount = new Mount(2, 0, num + 43, num2 - 4);
                    if (!GameScreen.Vecplayers.contains(mount))
                    {
                        GameScreen.addPlayer(mount);
                    }
                    mount = null;
                    mount = new Mount(3, 3, num - 18, num2 + 7);
                    if (!GameScreen.Vecplayers.contains(mount))
                    {
                        GameScreen.addPlayer(mount);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void onReceiveInfoQuest(Message m)
    {
        try
        {
            sbyte b = m.reader().readByte();
            if (b < 3)
            {
                sbyte b2 = m.reader().readByte();
                short num = 0;
                bool flag = false;
                sbyte b3 = 0;
                sbyte b4 = 0;
                string empty = string.Empty;
                MainQuest mainQuest = null;
                if (b == 0)
                {
                    MainQuest.vecQuestList.removeAllElements();
                }
                else if (b == 1)
                {
                    MainQuest.vecQuestFinish.removeAllElements();
                }
                else if (b == 2)
                {
                    MainQuest.vecQuestDoing_Main.removeAllElements();
                    MainQuest.vecQuestDoing_Sub.removeAllElements();
                }
                for (sbyte b5 = 0; b5 < b2; b5++)
                {
                    num = m.reader().readShort();
                    flag = m.reader().readBoolean();
                    empty = m.reader().readUTF();
                    switch (b)
                    {
                        case 0:
                            {
                                sbyte b10 = m.reader().readByte();
                                string strDetailTalk2 = m.reader().readUTF();
                                b3 = m.reader().readByte();
                                string strDetailHelp3 = m.reader().readUTF();
                                mainQuest = new MainQuest(num, flag, empty, b10, strDetailTalk2, b3, strDetailHelp3);
                                MainQuest.vecQuestList.addElement(mainQuest);
                                break;
                            }
                        case 1:
                            {
                                b4 = m.reader().readByte();
                                string strDetailTalk = m.reader().readUTF();
                                string strDetailHelp2 = m.reader().readUTF();
                                mainQuest = new MainQuest(num, flag, empty, b4, strDetailTalk, strDetailHelp2);
                                MainQuest.vecQuestFinish.addElement(mainQuest);
                                break;
                            }
                        case 2:
                            {
                                b3 = m.reader().readByte();
                                string strShortDetail = m.reader().readUTF();
                                string strDetailHelp = m.reader().readUTF();
                                b4 = m.reader().readByte();
                                if (b3 == 0)
                                {
                                    sbyte b6 = m.reader().readByte();
                                    short[] array = new short[b6];
                                    short[] array2 = new short[b6];
                                    short[] array3 = new short[b6];
                                    for (sbyte b7 = 0; b7 < b6; b7++)
                                    {
                                        array[b7] = m.reader().readShort();
                                        array3[b7] = m.reader().readShort();
                                        array2[b7] = m.reader().readShort();
                                    }
                                    mainQuest = new MainQuest(num, flag, empty, strDetailHelp, b3, strShortDetail, b4, array, array2, array3, 0);
                                }
                                else if (b3 == 1)
                                {
                                    sbyte b8 = m.reader().readByte();
                                    short[] array4 = new short[b8];
                                    short[] array5 = new short[b8];
                                    short[] array6 = new short[b8];
                                    for (sbyte b9 = 0; b9 < b8; b9++)
                                    {
                                        array4[b9] = m.reader().readShort();
                                        array6[b9] = m.reader().readShort();
                                        array5[b9] = m.reader().readShort();
                                    }
                                    mainQuest = new MainQuest(num, flag, empty, strDetailHelp, b3, strShortDetail, b4, array4, array5, array6, 1);
                                }
                                else if (b3 == 2)
                                {
                                    b4 = m.reader().readByte();
                                    string strShortDetail2 = m.reader().readUTF();
                                    mainQuest = new MainQuest(num, flag, empty, strDetailHelp, b4, strShortDetail2);
                                }
                                if (mainQuest != null)
                                {
                                    if (flag)
                                    {
                                        MainQuest.vecQuestDoing_Main.addElement(mainQuest);
                                    }
                                    else
                                    {
                                        MainQuest.vecQuestDoing_Sub.addElement(mainQuest);
                                    }
                                }
                                break;
                            }
                    }
                }
                if (b != 0 && (b == 1 || b == 2))
                {
                    ((MainTabNew)GameCanvas.AllInfo.VecTabScreen.elementAt(MainTabNew.QUEST)).init();
                }
            }
            else
            {
                sbyte b11 = m.reader().readByte();
                sbyte b12 = m.reader().readByte();
            }
            for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
            {
                MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
                if (mainObject.typeObject != 2)
                {
                    continue;
                }
                if (b == 0)
                {
                    if (mainObject.typeNPC == 1)
                    {
                        mainObject.typeNPC = 0;
                    }
                }
                else if (b == 1)
                {
                    if (mainObject.typeNPC == 3)
                    {
                        mainObject.typeNPC = 0;
                    }
                }
                else if (b == 2 && mainObject.typeNPC == 2)
                {
                    mainObject.typeNPC = 0;
                }
                for (int j = 0; j < MainQuest.vecQuestList.size(); j++)
                {
                    MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestList.elementAt(j);
                    if (mainQuest2.idNPC_From == mainObject.ID && mainObject.typeNPC != 3)
                    {
                        mainObject.typeNPC = 1;
                    }
                }
                for (int k = 0; k < MainQuest.vecQuestFinish.size(); k++)
                {
                    MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestFinish.elementAt(k);
                    if (mainQuest3.idNPC_To == mainObject.ID)
                    {
                        mainObject.typeNPC = 3;
                    }
                }
                for (int l = 0; l < MainQuest.vecQuestDoing_Main.size(); l++)
                {
                    MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(l);
                    if (mainQuest4.idNPC_To == mainObject.ID && mainObject.typeNPC == 0)
                    {
                        mainObject.typeNPC = 2;
                    }
                }
                for (int n = 0; n < MainQuest.vecQuestDoing_Sub.size(); n++)
                {
                    MainQuest mainQuest5 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(n);
                    if (mainQuest5.idNPC_To == mainObject.ID && mainObject.typeNPC == 0)
                    {
                        mainObject.typeNPC = 2;
                    }
                }
            }
            for (int num2 = 0; num2 < MiniMap.vecNPC_Map.size(); num2++)
            {
                NPCMini nPCMini = (NPCMini)MiniMap.vecNPC_Map.elementAt(num2);
                if (b == 0)
                {
                    if (nPCMini.type == 1)
                    {
                        nPCMini.type = 0;
                    }
                }
                else if (b == 1)
                {
                    if (nPCMini.type == 3)
                    {
                        nPCMini.type = 0;
                    }
                }
                else if (b == 2 && nPCMini.type == 2)
                {
                    nPCMini.type = 0;
                }
                MainObject mainObject2 = MainObject.get_Object(nPCMini.ID, 2);
                if (mainObject2 != null && !mainObject2.isRemove)
                {
                    nPCMini.type = mainObject2.typeNPC;
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void Dynamic_Menu(Message msg)
    {
        try
        {
            short idnpc = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            sbyte b2 = msg.reader().readByte();
            mVector mVector3 = new mVector("ReadMessenge cmd");
            for (int i = 0; i < b2; i++)
            {
                iCommand o = new iCommand(msg.reader().readUTF(), null);
                mVector3.addElement(o);
            }
            string name = msg.reader().readUTF();
            GameCanvas.menu2.setinfoDynamic(mVector3, 2, b, idnpc, name);
        }
        catch (Exception)
        {
        }
    }

    public void Item_More_Info(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            TabMySeftNew.mItemInfo = new MainInfoItem[b];
            TabMySeftNew.mItemInfoShow = new MainInfoItem[b];
            for (int i = 0; i < b; i++)
            {
                int id = msg.reader().readUnsignedByte();
                int value = msg.reader().readInt();
                MainInfoItem mainInfoItem = new MainInfoItem(id, value);
                if (mainInfoItem.id >= 16 && mainInfoItem.id <= 20)
                {
                    TabMySeftNew.meffskill[mainInfoItem.id - 16] = MainItem.getNopercent(mainInfoItem.value);
                }
                TabMySeftNew.mItemInfo[i] = mainInfoItem;
                TabMySeftNew.mItemInfoShow[i] = mainInfoItem;
            }
        }
        catch (Exception)
        {
        }
    }

    public void Set_XP(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(num, 0);
            if (mainObject != null && !mainObject.isRemove)
            {
                mainObject.phantramLv = msg.reader().readShort();
                int num2 = msg.reader().readInt();
                if (!GameCanvas.lowGraphic || mainObject == GameScreen.player)
                {
                    GameScreen.addEffectNum(num2 + "xp", mainObject.x, mainObject.y - mainObject.hOne, 1, num);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void Level_Up(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(num, 0);
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            mainObject.Lv = msg.reader().readByte();
            GameScreen.addEffectKill(42, num, 0, num, 0, 0, 0);
            if (mainObject == GameScreen.player && GameScreen.help.setStep_Next(5, 8))
            {
                GameScreen.help.NextStep();
                GameScreen.help.setNext();
                if (Player.isAutoFire == -1)
                {
                    Player.isAutoFire = 0;
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void Login_Ok(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            sbyte[] array = new sbyte[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = msg.reader().readsbyte();
            }
            LoadMap.load_Table_Map(array);
            GameScreen.vecTimecountDown.removeAllElements();
            PaintInfoGameScreen.idicon = -1;
        }
        catch (Exception)
        {
        }
    }

    public void ItemDrop(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            short iD = msg.reader().readShort();
            short idIcon = msg.reader().readShort();
            short iD2 = msg.reader().readShort();
            string name = msg.reader().readUTF();
            sbyte b2 = 0;
            if (b == 3 || b == 4 || b == 7)
            {
                b2 = msg.reader().readByte();
            }
            short iD3 = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(iD, 1);
            if (mainObject != null && !mainObject.isRemove)
            {
                int x = mainObject.x;
                int y = mainObject.y;
                Item_Drop obj = new Item_Drop(iD2, b, name, x, y, idIcon, b2);
                GameScreen.addPlayer(obj);
                return;
            }
            MainObject mainObject2 = MainObject.get_Object(iD3, 0);
            if (mainObject2 != null)
            {
                int x = mainObject2.x;
                int y = mainObject2.y;
                Item_Drop obj2 = new Item_Drop(iD2, b, name, x, y, idIcon, b2);
                GameScreen.addPlayer(obj2);
            }
            else
            {
                mSystem.outz(" obj nay da null");
            }
        }
        catch (Exception)
        {
        }
    }

    public void GetItemMap(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            short iD = msg.reader().readShort();
            short num = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Item_Object(iD, b);
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            if (b == 5 && num == GameScreen.player.ID)
            {
                MainQuest.updateQuestGetItem(mainObject.imageId, mainObject.name);
            }
            MainObject mainObject2 = MainObject.get_Object(num, 0);
            if (mainObject2 != null && !mainObject2.isRemove)
            {
                if (!GameCanvas.lowGraphic || mainObject == GameScreen.player)
                {
                    if (mainObject.typeObject == 3 && mainObject.colorName > 0)
                    {
                        GameScreen.addEffectNum(mainObject.name, mainObject2.x, mainObject2.y - mainObject2.hOne / 2, -mainObject.colorName, num);
                    }
                    else
                    {
                        GameScreen.addEffectNum(mainObject.name, mainObject2.x, mainObject2.y - mainObject2.hOne / 2, 5, num);
                    }
                }
                mainObject.setVx_Vy_Item(mainObject2.x, mainObject2.y - mainObject2.hOne / 2);
                mainObject.isRunAttack = true;
            }
            else
            {
                mainObject.isRemove = true;
            }
        }
        catch (Exception)
        {
        }
    }

    public void get_Item_Tem(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            string name = msg.reader().readUTF();
            sbyte typeItem = msg.reader().readByte();
            sbyte idPartItem = msg.reader().readByte();
            sbyte classitem = msg.reader().readByte();
            short iconId = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            int[] array = new int[b];
            sbyte[] array2 = new sbyte[b];
            for (int i = 0; i < b; i++)
            {
                array2[i] = msg.reader().readByte();
                array[i] = msg.reader().readInt();
            }
            MainTemplateItem v = new MainTemplateItem(num, name, typeItem, idPartItem, classitem, iconId, array, array2);
            MainTemplateItem.hashItemTem.put(string.Empty + num, v);
        }
        catch (Exception)
        {
        }
    }

    public void Skill_List(Message msg)
    {
        try
        {

            MsgDialog.MaxSkillBuff = 0;
            mVector mVector3 = new mVector("ReadMessenge vec14");
            sbyte b = msg.reader().readByte();// size skill
            for (int i = 0; i < b; i++)
            {
                Skill skill = new Skill();
                skill.Id = msg.reader().readByte();
                skill.iconId = msg.reader().readByte();
                skill.name = msg.reader().readUTF();
                skill.typeSkill = msg.reader().readByte();
                if (skill.typeSkill == 1)
                {
                    MsgDialog.MaxSkillBuff++;
                }
                skill.range = msg.reader().readShort();
                skill.detail = msg.reader().readUTF();
                skill.typeBuff = msg.reader().readByte();
                skill.subEff = msg.reader().readByte();
                sbyte b2 = msg.reader().readByte();
                skill.mLvSkill = new LvSkill[b2];
                for (int j = 0; j < b2; j++)
                {
                    mSystem.outz("Lvskill=" + j);
                    skill.mLvSkill[j] = new LvSkill();
                    skill.mLvSkill[j].mpLost = msg.reader().readShort();
                    skill.mLvSkill[j].LvRe = msg.reader().readShort();
                    if (j == 0)
                    {
                        skill.lvMin = skill.mLvSkill[j].LvRe;
                    }
                    skill.mLvSkill[j].delay = msg.reader().readInt();
                    skill.mLvSkill[j].timeBuff = msg.reader().readInt();
                    skill.mLvSkill[j].per_Sub_Eff = msg.reader().readByte();
                    skill.mLvSkill[j].time_Sub_Eff = msg.reader().readShort();
                    skill.mLvSkill[j].plus_Hp = msg.reader().readShort();
                    skill.mLvSkill[j].plus_Mp = msg.reader().readShort();
                    sbyte b3 = msg.reader().readByte();
                    skill.mLvSkill[j].minfo = new MainInfoItem[b3];
                    for (int k = 0; k < b3; k++)
                    {
                        byte id = msg.reader().readUnsignedByte();
                        int param = msg.reader().readInt();


                        skill.mLvSkill[j].minfo[k] = new MainInfoItem(id, param);

                        string filec = $"G://LOG_SQL//skill_eff.sql";
                        string effectSql = $"INSERT INTO skill_effect_info (skill_level_id, effect_type, effect_value) " +
                         $"VALUES ({j + 1}, {id}, {param});";

                        File.AppendAllText(filec, effectSql);


                    }
                    skill.mLvSkill[j].nTarget = msg.reader().readByte();
                    skill.mLvSkill[j].range_lan = msg.reader().readShort();

                    string file = $"G://LOG_SQL//skill_level.sql";
                    string skillLevelInsert = $"INSERT INTO skill_level (skill_id, level, mp_lost, " +
                                             $"lv_required, delay, time_buff, per_sub_eff, time_sub_eff, " +
                                             $"plus_hp, plus_mp, num_target, range_lan) VALUES " +
                                             $"({skill.Id}, {j + 1}, {skill.mLvSkill[j].mpLost}, " +
                                             $"{skill.mLvSkill[j].LvRe}, {skill.mLvSkill[j].delay}, " +
                                             $"{skill.mLvSkill[j].timeBuff}, {skill.mLvSkill[j].per_Sub_Eff}, " +
                                             $"{skill.mLvSkill[j].time_Sub_Eff}, {skill.mLvSkill[j].plus_Hp}, " +
                                             $"{skill.mLvSkill[j].plus_Mp}, {skill.mLvSkill[j].nTarget}, " +
                                             $"{skill.mLvSkill[j].range_lan});";


                    File.AppendAllText(file, skillLevelInsert);


                }
                skill.performDur = msg.reader().readShort();
                skill.typePaint = msg.reader().readByte();
                mVector3.addElement(skill);
                string filePathc = $"G://LOG_SQL//skill_template.sql";
                string sql = $"INSERT INTO skill_template (id, icon_id, name_skill, type_skill, range_skill, detail, " +
                       $"type_buff, sub_eff, perform_dur, type_paint) VALUES " +
                       $"({skill.Id}, {skill.iconId}, '{skill.name}', {skill.typeSkill}, " +
                       $"{skill.range}, '{skill.detail}', {skill.typeBuff}, {skill.subEff}, {skill.performDur}, {skill.typePaint});";

                File.AppendAllText(filePathc, sql);
            }
            mVector3 = CRes.selectionSortIDSkill(mVector3);
            TabSkillsNew.vecPaintSkill = CRes.selectionSortSkill(mVector3);
            MainListSkill.setKill(GameScreen.player.clazz);
            GameScreen.player.tabskills.setXYSkill(TabSkillsNew.vecPaintSkill);
            GameCanvas.load.isLoadSkill = true;
            MsgDialog.Autobuff = mSystem.new_M_Int(MsgDialog.MaxSkillBuff, 3);
            int num = 0;
            for (int l = 0; l < TabSkillsNew.vecPaintSkill.size(); l++)
            {
                Skill skill2 = (Skill)TabSkillsNew.vecPaintSkill.elementAt(l);
                if (skill2.typeSkill == 1)
                {
                    MsgDialog.Autobuff[num][0] = skill2.Id;
                    MsgDialog.Autobuff[num][1] = 0;
                    MsgDialog.Autobuff[num][2] = l;
                    num++;
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void use_Potion(Message msg)
    {
        try
        {
            TabScreenNew.timeRepaint = 5;
            sbyte b = msg.reader().readByte();
            short num = msg.reader().readShort();
            short num2 = msg.reader().readShort();
            Item item = null;
            MainObject mainObject = MainObject.get_Object(num, b);
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            if (num2 != -1 && mainObject == GameScreen.player)
            {
                item = Item.getItemInventory(4, num2);
                if (item != null)
                {
                    item.numPotion--;
                    if (item.numPotion <= 0)
                    {
                        Item.VecInvetoryPlayer.removeElement(item);
                    }
                }
            }
            sbyte b2 = msg.reader().readByte();
            if (b2 == 0)
            {
                mainObject.maxHp = msg.reader().readInt();
                mainObject.hp = msg.reader().readInt();
                int num3 = msg.reader().readInt();
                if (mainObject.hp > 0)
                {
                    if (mainObject.Action == 4)
                    {
                        mainObject.resetAction();
                        mainObject.Action = 0;
                        mainObject.vecBuff.removeAllElements();
                        if (mainObject == GameScreen.player)
                        {
                            GlobalService.gI().player_move((short)GameScreen.player.x, (short)GameScreen.player.y);
                        }
                    }
                }
                else
                {
                    mainObject.hp = 0;
                    mainObject.mp = 0;
                    if (mainObject.Action != 4)
                    {
                        if (b == 1)
                        {
                            MainObject.startDeadFly((MainMonster)mainObject, GameScreen.player.ID, CRes.random(3));
                        }
                        else
                        {
                            mainObject.resetAction();
                            mainObject.Action = 4;
                            mainObject.timedie = GameCanvas.timeNow;
                            mainObject.f = 0;
                            GameScreen.addEffectEndKill(11, mainObject.x, mainObject.y);
                        }
                    }
                }
                if (!GameCanvas.lowGraphic || mainObject == GameScreen.player)
                {
                    if (num3 > 0)
                    {
                        GameScreen.addEffectNum("+" + num3, mainObject.x, mainObject.y - mainObject.hOne / 2, 3, num);
                    }
                    else if (num3 < 0)
                    {
                        GameScreen.addEffectNum(string.Empty + num3, mainObject.x, mainObject.y - mainObject.hOne / 2, 3, num);
                    }
                }
            }
            else if (b2 == 1)
            {
                mainObject.maxMp = msg.reader().readInt();
                mainObject.mp = msg.reader().readInt();
                int num4 = msg.reader().readInt();
                if (!GameCanvas.lowGraphic || mainObject == GameScreen.player)
                {
                    if (num4 > 0)
                    {
                        GameScreen.addEffectNum("+" + num4, mainObject.x, mainObject.y - mainObject.hOne / 2, 4, num);
                    }
                    else if (num4 < 0)
                    {
                        GameScreen.addEffectNum(string.Empty + num4, mainObject.x, mainObject.y - mainObject.hOne / 2, 3, num);
                    }
                }
            }
            else if (b2 == 2)
            {
                mainObject.maxHp = msg.reader().readInt();
                mainObject.hp = msg.reader().readInt();
                int num5 = msg.reader().readInt();
                if (!GameCanvas.lowGraphic)
                {
                    if (num5 > 0)
                    {
                        mSystem.outz("dzo day ---");
                        GameScreen.addEffectNum("+" + num5, mainObject.x, mainObject.y - mainObject.hOne / 2, 3, num);
                    }
                    else if (num5 < 0)
                    {
                        mSystem.outz("hoac dzo day ---");
                        GameScreen.addEffectNum(string.Empty + num5, mainObject.x, mainObject.y - mainObject.hOne / 2, 6, num);
                    }
                }
            }
            else if (b2 == 3)
            {
                mainObject.hp = msg.reader().readInt();
                int num6 = msg.reader().readInt();
                GameScreen.addEffectNum(string.Empty + num6, mainObject.x, mainObject.y - mainObject.hOne / 2, 9, num);
                GameScreen.addEffectEndKill(0, mainObject.x, mainObject.y + mainObject.vy * 2 / 1000 - 5);
                GameScreen.addEffectEndKill(9, mainObject.x, mainObject.y + mainObject.vy * 2 / 1000 + 5);
                GameScreen.addEffectEndKill(4, mainObject.x, mainObject.y);
            }
            if (Player.party != null)
            {
                Player.party.setPos(mainObject.name, mainObject.x, mainObject.y, mainObject.hp, mainObject.maxHp);
            }
        }
        catch (Exception)
        {
        }
    }

    public void chatPopup(Message msg)
    {
        try
        {
            short iD = msg.reader().readShort();
            sbyte tem = msg.reader().readByte();
            MainObject mainObject = MainObject.get_Object(iD, tem);
            if (mainObject != null && !mainObject.isRemove)
            {
                string text = msg.reader().readUTF();
                if (text != null && text.Trim().Length != 0)
                {
                    mainObject.strChatPopup = text;
                    GameCanvas.msgchat.addNewChat(T.tinden, mainObject.name + ": ", text, ChatDetail.TYPE_SERVER, isFocus: false);
                }
            }
        }
        catch (Exception ex)
        {
            Cout.println("loi chat popup" + ex.ToString());
        }
    }

    public void chatTab(Message msg)
    {
        try
        {
            string text = msg.reader().readUTF();
            string text2 = msg.reader().readUTF();
            if (text2 != null && text2.Trim().Length != 0)
            {
                if (text.CompareTo(T.tinden) == 0)
                {
                    GameCanvas.msgchat.addNewChat(text, T.thongbao + ": ", text2, ChatDetail.TYPE_SERVER, isFocus: false);
                }
                else if (text.CompareTo(T.tabThuLinh) == 0)
                {
                    GameCanvas.msgchat.addNewChat(text, string.Empty, text2, ChatDetail.TYPE_SERVER, isFocus: false);
                }
                else if (text.CompareTo(T.tabBangHoi) == 0)
                {
                    GameCanvas.msgchat.addNewChat(text, string.Empty, text2, ChatDetail.TYPE_CHAT, isFocus: false);
                }
                else if (text.CompareTo(T.party) == 0)
                {
                    GameCanvas.msgchat.addNewChat(text, string.Empty, text2, ChatDetail.TYPE_CHAT, isFocus: false);
                }
                else
                {
                    GameCanvas.msgchat.addNewChat(text, text + ": ", text2, ChatDetail.TYPE_CHAT, isFocus: false);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void Friend(Message msg)
    {
        try
        {
            string nameList = T.listFriend;
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                string namecheck = msg.reader().readUTF();
                GameCanvas.mevent.addEvent(namecheck, 1, T.loimoikb, 0);
            }
            else
            {
                if (b != 4 && b != 1)
                {
                    return;
                }
                sbyte b2 = -1;
                if (b == 4)
                {
                    nameList = msg.reader().readUTF();
                    b2 = msg.reader().readByte();
                }
                int num = 1;
                if (b == 4)
                {
                    num = msg.reader().readUnsignedByte();
                }
                mVector mVector3 = new mVector("ReadMessenge vec6");
                for (int i = 0; i < num; i++)
                {
                    string name = msg.reader().readUTF();
                    sbyte b3 = msg.reader().readByte();
                    sbyte b4 = msg.reader().readByte();
                    sbyte b5 = msg.reader().readByte();
                    short num2 = msg.reader().readShort();
                    sbyte b6 = msg.reader().readByte();
                    sbyte[] array = new sbyte[12];
                    for (int j = 0; j < array.Length; j++)
                    {
                        array[j] = -1;
                    }
                    for (int k = 0; k < b6; k++)
                    {
                        sbyte b7 = msg.reader().readByte();
                        sbyte b8 = msg.reader().readByte();
                        array[b8] = b7;
                    }
                    sbyte typeOnline = msg.reader().readByte();
                    MainObject mainObject = new MainObject(0, 0, name, 0, 0);
                    short num3 = msg.reader().readShort();
                    if (num3 >= 0)
                    {
                        mainObject.myClan = new MainClan(0, num3, msg.reader().readUTF(), msg.reader().readByte());
                    }
                    mainObject.setInfo(b3, b4, b5);
                    mainObject.typeOnline = typeOnline;
                    mainObject.Lv = num2;
                    mainObject.setWearingListChar(array);
                    mainObject.infoObject = T.level + num2;
                    if (b == 1)
                    {
                        GameCanvas.addInfoChar(mainObject.name + T.chapnhanketban);
                        List_Server.vecMyFriend.addElement(mainObject);
                        if (List_Server.gI().typeList == 0)
                        {
                            List_Server.gI().setMinMax();
                            List_Server.gI().setXmove();
                            List_Server.gI().setCmd();
                        }
                    }
                    else
                    {
                        mVector3.addElement(mainObject);
                    }
                }
                if (b == 4)
                {
                    List_Server.vecMyFriend.removeAllElements();
                    List_Server.gI().typeList = 0;
                    List_Server.vecMyFriend = mVector3;
                    List_Server.gI().vecListServer = mVector3;
                    List_Server.gI().setSize(0);
                    List_Server.gI().updateList();
                    List_Server.gI().setMinMax();
                    List_Server.gI().setXmove();
                    List_Server.gI().setCmd();
                    List_Server.gI().nameList = nameList;
                    List_Server.gI().page = 99;
                    List_Server.isLoadFriend = true;
                    if (GameCanvas.currentScreen != List_Server.gI())
                    {
                        if (GameCanvas.currentScreen.lastScreen != List_Server.gI())
                        {
                            List_Server.gI().Show(GameCanvas.currentScreen);
                        }
                        else
                        {
                            List_Server.gI().Show(GameCanvas.game);
                        }
                    }
                    else
                    {
                        GameCanvas.end_Dialog();
                    }
                }
                GameCanvas.end_Dialog();
            }
        }
        catch (Exception)
        {
        }
    }

    public void lastlogout(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            GameCanvas.timenextLogin = (GameCanvas.timenextLogin = mSystem.currentTimeMillis() + b * 1000);
            GameScreen.player.resetAction();
            Session_ME.gI().close();
            GameScreen.player = new Player(0, 0, "unname", 0, 0);
        }
        catch (Exception)
        {
        }
    }

    public void Login_Fail(Message msg)
    {
        try
        {
            string str = msg.reader().readUTF();
            GameCanvas.start_Ok_Dialog(str);
            sbyte b = 0;
            try
            {
                b = msg.reader().readByte();
            }
            catch (Exception)
            {
                b = 0;
            }
            if (b == 0)
            {
                GlobalLogicHandler.isMelogin = false;
            }
            if (b == 1)
            {
                GlobalLogicHandler.isMelogin = true;
            }
        }
        catch (Exception)
        {
        }
    }

    public void Register(Message msg)
    {
        try
        {
            bool flag = msg.reader().readBoolean();
            string str = msg.reader().readUTF();
            if (flag)
            {
                GameCanvas.login.section = 0;
                GameCanvas.login.setScreen();
            }
            GameCanvas.start_Ok_Dialog(str);
        }
        catch (Exception)
        {
        }
    }

    public void Party(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                Player.party = new MainParty(GameScreen.player.name, GameScreen.player.Lv, GameCanvas.loadmap.idMap, LoadMap.getAreaPaint());
                GameCanvas.start_Ok_Dialog(T.vuataonhom);
            }
            else if (b == 1)
            {
                nameParty = msg.reader().readUTF();
                GameCanvas.mevent.addEvent(nameParty, 2, T.moivaoParty, 0);
            }
            else if (b == 2)
            {
                MainParty mainParty = null;
                sbyte b2 = msg.reader().readByte();
                for (int i = 0; i < b2; i++)
                {
                    if (i == 0)
                    {
                        mainParty = new MainParty(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readUnsignedByte(), msg.reader().readByte());
                    }
                    else
                    {
                        mainParty.addObjParty(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readUnsignedByte(), msg.reader().readByte());
                    }
                }
                Player.party = mainParty;
                MsgDialog.maxSizeParty = -1;
            }
            else if (b == 3)
            {
                GameCanvas.start_Ok_Dialog(T.moikhoinhom);
                Player.party = null;
            }
            else if (b == 4)
            {
                GameCanvas.start_Ok_Dialog(T.giaitannhom);
                Player.party = null;
            }
            else if (b == 5)
            {
                GameCanvas.start_Ok_Dialog(T.roikhoinhom);
                Player.party = null;
            }
            if (Player.party != null)
            {
                Player.party.setIsParty();
            }
        }
        catch (Exception)
        {
        }
    }

    public void Buy_Sell(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                nameBuySell = msg.reader().readUTF();
                GameCanvas.mevent.addEvent(nameBuySell, 3, T.loimoigiaodich, 0);
            }
            else if (b == 1)
            {
                string name = msg.reader().readUTF();
                GameCanvas.buy_sell = new Buy_Sell_Screen();
                GameCanvas.buy_sell.setinfoBuySell(name);
                GameCanvas.buy_sell.Show(GameCanvas.currentScreen);
            }
            else if (b == 2 || b == 3)
            {
                sbyte index = msg.reader().readByte();
                sbyte b2 = msg.reader().readByte();
                short num = msg.reader().readShort();
                short idIcon = msg.reader().readShort();
                short numPo = 1;
                sbyte colorname = 0;
                sbyte charclass = 0;
                short lvMin = 0;
                sbyte lvup = 0;
                string name2 = string.Empty;
                string contentPotion = null;
                MainInfoItem[] array = null;
                if (b2 == 4)
                {
                    numPo = msg.reader().readShort();
                    MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num);
                    contentPotion = mainTemplateItem.contentPotion;
                    name2 = mainTemplateItem.name;
                }
                else if (b2 == 3)
                {
                    name2 = msg.reader().readUTF();
                    colorname = msg.reader().readByte();
                    charclass = msg.reader().readByte();
                    lvMin = msg.reader().readShort();
                    lvup = msg.reader().readByte();
                    sbyte b3 = msg.reader().readByte();
                    array = new MainInfoItem[b3];
                    for (int i = 0; i < b3; i++)
                    {
                        int id = msg.reader().readUnsignedByte();
                        int value = msg.reader().readInt();
                        array[i] = new MainInfoItem(id, value);
                    }
                }
                else if (b2 == 7)
                {
                    numPo = msg.reader().readShort();
                    MainItem material = Item.getMaterial(num);
                    if (material != null)
                    {
                        contentPotion = material.content;
                        name2 = material.itemName;
                    }
                    else
                    {
                        contentPotion = string.Empty;
                        name2 = string.Empty;
                    }
                }
                MainItem item = new MainItem(num, name2, numPo, idIcon, b2, contentPotion, array, colorname, charclass, lvMin, lvup, 0, 0);
                Buy_Sell_Screen.setmItemOther(item, b, index);
            }
            else if (b == 4)
            {
                GameCanvas.buy_sell.typeLock = msg.reader().readByte();
                if (GameCanvas.buy_sell.typeLock == 1)
                {
                    GameCanvas.buy_sell.center = null;
                    GameCanvas.buy_sell.left = null;
                }
                if (GameCanvas.buy_sell.typeLock == 2)
                {
                    GameCanvas.buy_sell.center = null;
                    GameCanvas.buy_sell.left = GameCanvas.buy_sell.cmdGiaodich;
                    GameCanvas.buy_sell.setPosCmd();
                }
            }
            else if (b == 5)
            {
                sbyte b4 = msg.reader().readByte();
                if (b4 == 0)
                {
                    GameCanvas.buy_sell.left = null;
                    GameCanvas.buy_sell.right = null;
                    GameCanvas.buy_sell.center = new iCommand(T.cancel, 8);
                    GameCanvas.buy_sell.setPosCmd();
                    GameCanvas.buy_sell.typeActionBuySell = 0;
                    GameCanvas.start_Ok_Dialog(T.xinchogiaodich + GameCanvas.buy_sell.nameBuy + T.xacnhangiaodich);
                }
                else if (b4 == 1)
                {
                    GameCanvas.buy_sell.typeActionBuySell = 1;
                }
                else if (b4 == 2)
                {
                    if (GameCanvas.buy_sell.lastScreen.lastScreen != null)
                    {
                        GameCanvas.buy_sell.lastScreen.Show(GameCanvas.buy_sell.lastScreen.lastScreen);
                    }
                    else
                    {
                        GameCanvas.buy_sell.lastScreen.Show();
                    }
                    GameCanvas.buy_sell = null;
                    GameCanvas.start_Ok_Dialog(T.giaodichthanhcong);
                }
            }
            else if (b == 6)
            {
                if (GameCanvas.buy_sell.lastScreen.lastScreen != null)
                {
                    GameCanvas.buy_sell.lastScreen.Show(GameCanvas.buy_sell.lastScreen.lastScreen);
                }
                else
                {
                    GameCanvas.buy_sell.lastScreen.Show();
                }
                GameCanvas.buy_sell = null;
                GameCanvas.start_Ok_Dialog(T.huygiaodich);
            }
            else if (b == 7)
            {
                GameCanvas.buy_sell.moneyBuySell[1] = msg.reader().readInt();
            }
            else if (b == 8)
            {
                GameCanvas.buy_sell.moneyBuySell[0] = msg.reader().readInt();
            }
            else if (b == 9)
            {
                string text = msg.reader().readUTF();
                GameCanvas.buy_sell.strchat[1] = text;
            }
        }
        catch (Exception)
        {
        }
    }

    public void Buff(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            sbyte b2 = msg.reader().readByte();
            short iD = msg.reader().readShort();
            sbyte b3 = msg.reader().readByte();
            int time = msg.reader().readInt();
            short iD2 = msg.reader().readShort();
            sbyte tem = msg.reader().readByte();
            MainObject mainObject = null;
            mainObject = ((b2 == 6) ? MainObject.get_Object(iD, 9) : ((b2 != 4) ? MainObject.get_Object(iD, 0) : MainObject.get_Object(iD, 1)));
            MainObject mainObject2 = MainObject.get_Object(iD2, tem);
            if (mainObject != null && !mainObject.isRemove && mainObject != GameScreen.player && b == 0 && mainObject.Action != 4 && mainObject.Action != 2)
            {
                if (mainObject2 != null)
                {
                    if (b2 == 4 && mainObject2 == mainObject && !mainObject2.isRemove)
                    {
                        GameScreen.addEffectKillSubTime(MainListSkill.mSkillAllClasses[b2][b3], mainObject.ID, mainObject.typeObject, mainObject.ID, mainObject.typeObject, 0, mainObject.hp, (sbyte)MainListSkill.mBuffAllClasses[b2][b3], 850);
                    }
                }
                else
                {
                    mVector mVector3 = new mVector("ReadMessenge vec");
                    Object_Effect_Skill o = new Object_Effect_Skill((short)mainObject.ID, mainObject.typeObject);
                    mVector3.addElement(o);
                    if (b2 == 6)
                    {
                        Pet pet = (Pet)mainObject;
                        pet.setState(2);
                    }
                    mainObject.ListKillNow.setFireSkill(mainObject, mVector3, b3, b2);
                }
            }
            if (mainObject2 == null || mainObject2.isRemove)
            {
                return;
            }
            mainObject2.addBuff(MainListSkill.mBuffAllClasses[b2][b3], time, 0);
            if (mainObject2 != GameScreen.player)
            {
                return;
            }
            MainBuff buff = MainBuff.getBuff(MainListSkill.mBuffAllClasses[b2][b3], 0);
            if (buff != null)
            {
                buff.idIcon = msg.reader().readByte();
                sbyte b4 = msg.reader().readByte();
                buff.minfotam = new MainInfoItem[b4];
                MainInfoItem[] array = new MainInfoItem[b4];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = new MainInfoItem(msg.reader().readUnsignedByte(), msg.reader().readInt());
                }
                buff.minfotam = array;
            }
        }
        catch (Exception)
        {
        }
    }

    public void firePK(Message msg)
    {
        try
        {
            Fire_Object(msg, 0, 0);
        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void diePlayer(Message msg)
    {
        try
        {
            short iD = msg.reader().readShort();
            short iD2 = msg.reader().readShort();
            short pointPk = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            MainObject mainObject = MainObject.get_Object(iD, 0);
            MainObject mainObject2 = MainObject.get_Object(iD2, b);
            if (mainObject2 != null && !mainObject2.isRemove && b == 0)
            {
                mainObject2.pointPk = pointPk;
            }
            if (mainObject == null || mainObject.isRemove || mainObject.Action == 4)
            {
                return;
            }
            mainObject.hp = 0;
            mainObject.resetAction();
            mainObject.Action = 4;
            mainObject.timedie = GameCanvas.timeNow;
            GameScreen.addEffectEndKill(11, mainObject.x, mainObject.y);
            if (GameScreen.player == mainObject && !GameScreen.infoGame.isMapChienTruong(GameCanvas.loadmap.idMap))
            {
                if (LoadMap.typeMap == LoadMap.MAP_THACH_DAU)
                {
                    GameScreen.gI().center = Player.cmdVeLang;
                    Player.cmdVeLang.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdVeLang.caption);
                }
                else if (LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
                {
                    GameScreen.gI().center = Player.cmdRevice;
                    Player.cmdRevice.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdRevice.caption);
                }
                else if (!GameScreen.infoGame.isMapThachdau())
                {
                    GameScreen.gI().left = Player.cmdRevice;
                    GameScreen.gI().right = Player.cmdVeLang;
                    Player.cmdRevice.setPos(iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdRevice.caption);
                    Player.cmdVeLang.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdVeLang.caption);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void pk(Message msg)
    {
        try
        {
            short iD = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            MainObject mainObject = MainObject.get_Object(iD, 0);
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            mainObject.typePk = b;
            if (mainObject == GameScreen.player)
            {
                GameScreen.player.pointPk = msg.reader().readShort();
                string caption = T.off + " " + T.dosat;
                if (GameScreen.player.typePk != 0)
                {
                    caption = T.on + " " + T.dosat;
                }
                GameScreen.gI().cmdSetDoSat.caption = caption;
                if (b > 0)
                {
                    GlobalService.gI().Thach_Dau(2, string.Empty);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void Fire_Object(Message msg, sbyte temFrom, sbyte temTo)
    {
        try
        {
            if (!LoadMapScreen.isNextMap)
            {
                return;
            }
            short num = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(num, temFrom);
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            sbyte b = msg.reader().readByte();
            sbyte b2 = msg.reader().readByte();
            if (b2 <= 0)
            {
                return;
            }
            mVector mVector3 = new mVector("ReadMessenge vec6");
            for (int i = 0; i < b2; i++)
            {
                short num2 = msg.reader().readShort();
                Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill(num2, temTo);
                int num3 = msg.reader().readInt();
                int hpLast = msg.reader().readInt();
                object_Effect_Skill.setHP(num3, hpLast);
                if (num2 == GameScreen.player.ID)
                {
                    int maxHp = GameScreen.player.maxHp;
                    int num4 = num3 / maxHp * 100;
                    GameScreen.player.setPainthit(4, num4 > 20);
                }
                sbyte b3 = msg.reader().readByte();
                object_Effect_Skill.mEffTypePlus = new int[b3];
                object_Effect_Skill.mEff_HP_Plus = new int[b3];
                for (int j = 0; j < b3; j++)
                {
                    object_Effect_Skill.mEffTypePlus[j] = msg.reader().readByte();
                    object_Effect_Skill.mEff_HP_Plus[j] = msg.reader().readInt();
                }
                MainObject mainObject2 = MainObject.get_Object(object_Effect_Skill.ID, temTo);
                if (mainObject2 != null && !mainObject2.isRemove)
                {
                    mVector3.addElement(object_Effect_Skill);
                }
            }
            int hp = msg.reader().readInt();
            int mp = msg.reader().readInt();
            sbyte b4 = msg.reader().readByte();
            int num5 = msg.reader().readInt();
            if (num == GameScreen.player.ID)
            {
                for (int k = 0; k < mVector3.size(); k++)
                {
                    Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)mVector3.elementAt(k);
                    MainObject mainObject3 = MainObject.get_Object(object_Effect_Skill2.ID, temTo);
                    if (mainObject3 == null || mainObject3.isRemove)
                    {
                        continue;
                    }
                    int typeColor = 2;
                    if (mainObject != null && !mainObject.isRemove)
                    {
                        int num6 = EffectSkill.setAddEffKillPlus(object_Effect_Skill2.mEffTypePlus, mainObject, mainObject3, object_Effect_Skill2.mEff_HP_Plus);
                        if (num6 != -1)
                        {
                            typeColor = num6;
                        }
                    }
                    if (mainObject3.ID != GameScreen.player.ID)
                    {
                        if (object_Effect_Skill2.hpShow == 0)
                        {
                            typeColor = 6;
                            GameScreen.addEffectNum(T.hut, mainObject3.x, mainObject3.y - mainObject3.hOne, typeColor, mainObject3.ID);
                        }
                        else
                        {
                            GameScreen.addEffectNum("-" + object_Effect_Skill2.hpShow, mainObject3.x, mainObject3.y - mainObject3.hOne, typeColor, mainObject3.ID);
                        }
                        if (num5 > 0)
                        {
                            GameScreen.addEffectNum("-" + num5, mainObject3.x, mainObject3.y - mainObject3.hOne, b4, mainObject3.ID);
                        }
                    }
                    mainObject3.hp = object_Effect_Skill2.hpLast;
                    if (mainObject3.typeObject == 1 && mainObject3.hp <= 0)
                    {
                        MainObject.startDeadFly((MainMonster)mainObject3, num, CRes.random(3));
                        if (mainObject3.timeReveice >= 0)
                        {
                            MainQuest.updateQuestKillMonster(mainObject3.ID);
                        }
                    }
                }
            }
            else if (mainObject != null && !mainObject.isRemove && mVector3.size() > 0)
            {
                mainObject.posTransRoad = null;
                mainObject.vecObjFocusSkill = mVector3;
                mainObject.ListKillNow.setFireSkill(mainObject, mVector3, b, -1);
            }
            if (mainObject != null && !mainObject.isRemove)
            {
                mainObject.hp = hp;
                mainObject.mp = mp;
            }
        }
        catch (Exception)
        {
        }
    }

    public void other_player_info(Message msg)
    {
        try
        {
            MainObject mainObject = new MainObject();
            mainObject.ID = msg.reader().readShort();
            mainObject.name = msg.reader().readUTF();
            mainObject.clazz = msg.reader().readByte();
            mainObject.head = msg.reader().readByte();
            mainObject.eye = msg.reader().readByte();
            mainObject.hair = msg.reader().readByte();
            mainObject.Lv = msg.reader().readShort();
            mainObject.hp = msg.reader().readInt();
            mainObject.maxHp = msg.reader().readInt();
            mainObject.typePk = msg.reader().readByte();
            mainObject.pointPk = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            sbyte[] array = new sbyte[b];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }
            Info_Other_Player.vecEquipShow.clear();
            for (int j = 0; j < b; j++)
            {
                sbyte b2 = msg.reader().readByte();
                if (b2 > -1)
                {
                    string itemName = msg.reader().readUTF();
                    sbyte b3 = msg.reader().readByte();
                    sbyte b4 = msg.reader().readByte();
                    short imageId = msg.reader().readShort();
                    sbyte b5 = msg.reader().readByte();
                    sbyte plusItem = msg.reader().readByte();
                    short lvItem = msg.reader().readShort();
                    sbyte b6 = msg.reader().readByte();
                    array[j] = b5;
                    sbyte b7 = msg.reader().readByte();
                    MainInfoItem[] array2 = new MainInfoItem[b7];
                    for (int k = 0; k < b7; k++)
                    {
                        int id = msg.reader().readUnsignedByte();
                        int value = msg.reader().readInt();
                        array2[k] = new MainInfoItem(id, value);
                    }
                    sbyte can_Sell = msg.reader().readByte();
                    MainItem mainItem = MainItem.MainItem_Item(b2, itemName, imageId, plusItem, b6, b3, 3, array2, b4, isTem: false, -1, 0L, lvItem, 0, 0, 0, 0, 0);
                    mainItem.set_can_Sell(can_Sell);
                    Info_Other_Player.vecEquipShow.put(string.Empty + b2, mainItem);
                }
                else
                {
                    array[j] = -1;
                }
            }
            mainObject.setWearingEquip(array);
            short num = msg.reader().readShort();
            if (num >= 0)
            {
                mainObject.myClan = new MainClan(0, num, msg.reader().readUTF(), msg.reader().readByte());
                mainObject.myClan.name = msg.reader().readUTF();
            }
            sbyte b8 = msg.reader().readByte();
            if (b8 > -1)
            {
                string itemName2 = msg.reader().readUTF();
                sbyte b9 = msg.reader().readByte();
                short level = msg.reader().readShort();
                short experience = msg.reader().readShort();
                sbyte b10 = msg.reader().readByte();
                sbyte petImageId = msg.reader().readByte();
                sbyte frameNumberImg = msg.reader().readByte();
                sbyte b11 = msg.reader().readByte();
                int age = msg.reader().readInt();
                short growPoint = msg.reader().readShort();
                short maxgrow = msg.reader().readShort();
                short str = msg.reader().readShort();
                short agi = msg.reader().readShort();
                short hea = msg.reader().readShort();
                short spi = msg.reader().readShort();
                short maxtiemnang = msg.reader().readShort();
                sbyte b12 = msg.reader().readByte();
                MainInfoItem[] array3 = new MainInfoItem[b12];
                for (int l = 0; l < b12; l++)
                {
                    int id2 = msg.reader().readUnsignedByte();
                    int value2 = msg.reader().readInt();
                    int maxDam = msg.reader().readInt();
                    array3[l] = new MainInfoItem(id2, value2, maxDam);
                }
                PetItem petItem = new PetItem(b8, itemName2, b10, b11, b9, 9, array3, 14, level, b10, frameNumberImg, petImageId);
                petItem.setInfoPet(age, growPoint, str, agi, hea, spi, maxgrow, maxtiemnang, experience);
                Info_Other_Player.vecEquipShow.put(string.Empty + b8, petItem);
                array[5] = b10;
                Info_Other_Player.showPet = petItem;
            }
            else
            {
                Info_Other_Player.showPet = null;
            }
            Info_Other_Player.showObject = mainObject;
            sbyte type = msg.reader().readByte();
            if (GameCanvas.info_other_player == null)
            {
                GameCanvas.info_other_player = new Info_Other_Player();
            }
            GameCanvas.info_other_player.init(type);
            GameCanvas.info_other_player.Show(GameCanvas.currentScreen);
        }
        catch (Exception)
        {
        }
    }

    public void eff_plus_time(Message msg)
    {
        try
        {
            sbyte tem = msg.reader().readByte();
            short iD = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(iD, tem);
            if (mainObject != null && !mainObject.isRemove)
            {
                sbyte b = msg.reader().readByte();
                sbyte b2 = msg.reader().readByte();
                MainBuff.setEffHead(b, b2, mainObject);
            }
        }
        catch (Exception)
        {
        }
    }

    public void changeArea(Message msg)
    {
        try
        {
            LoadMapScreen.isNextMap = false;
            if (GameCanvas.currentScreen != GameCanvas.load)
            {
                GameCanvas.load.Show();
            }
            GameScreen.RemoveLoadMap();
            LoadMapScreen.isNextMap = true;
            LoadMap.Area = msg.reader().readByte();
            GameScreen.player.x = msg.reader().readShort() * 24;
            GameScreen.player.y = msg.reader().readShort() * 24;
            GameScreen.player.resetMove();
            GameScreen.player.posTransRoad = null;
            GameScreen.player.resetAction();
            if (GameScreen.pet != null)
            {
                GameScreen.pet.x = GameScreen.player.x;
                GameScreen.pet.y = GameScreen.player.y;
                GameScreen.pet.clearWayPoints();
            }
            GameCanvas.end_Dialog();
            GameCanvas.clearKeyHold();
            GameCanvas.load.isTele = false;
        }
        catch (Exception)
        {
            Cout.LogError2(" loi gi day ");
        }
    }

    public void update_Status_Area(Message msg)
    {
        try
        {
            LoadMap.MaxArea = msg.reader().readByte();
            LoadMap.mStatusArea = new int[LoadMap.MaxArea];
            string[] array = new string[LoadMap.MaxArea];
            for (int i = 0; i < LoadMap.MaxArea; i++)
            {
                LoadMap.mStatusArea[i] = msg.reader().readByte();
                int num = msg.reader().readByte();
                if (num != 0)
                {
                    LoadMap.mStatusArea[i] = num;
                }
            }
            for (int j = 0; j < LoadMap.MaxArea; j++)
            {
                array[j] = msg.reader().readUTF();
            }
            GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
            GameScreen.isReArea = false;
            mVector mVector3 = new mVector("ReadMessenge menu4");
            for (int k = 0; k < LoadMap.MaxArea; k++)
            {
                iCommand iCommand2 = new iCommand(array[k], 13, k, GameScreen.gI());
                iCommand2.setFraCaption(PaintInfoGameScreen.fraStatusArea, 1, LoadMap.mStatusArea[k]);
                mVector3.addElement(iCommand2);
            }
            GameCanvas.menu2.startAt(mVector3, 2, T.khuvuc, isFocus: false, null);
            GameCanvas.end_Dialog();
        }
        catch (Exception)
        {
        }
    }

    public void remove_Actor(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            short num = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Item_Object(num, b);
            if (mainObject == null || mainObject.isRemove)
            {
                return;
            }
            if (b == 1)
            {
                if (mainObject.typeBoss == 4)
                {
                    sbyte b2 = msg.reader().readByte();
                    if (b2 == 0)
                    {
                        mainObject.isMonPhoBangDie = true;
                        mainObject.vMax = 6;
                    }
                    else
                    {
                        mainObject.isStop = true;
                    }
                }
                else if (mainObject.typeBoss == 3)
                {
                    sbyte b3 = msg.reader().readByte();
                    if (b3 == 0)
                    {
                        mainObject.isMonPhoBangDie = true;
                        mainObject.vMax = 6;
                    }
                    else
                    {
                        mainObject.isStop = true;
                    }
                }
                else if (mainObject.typeBoss == 2)
                {
                    sbyte b4 = msg.reader().readByte();
                    if (b4 == 1)
                    {
                        GameScreen.addEffectKill(80, mainObject.x, mainObject.y - 70, 200, num, 1);
                        mainObject.isStop = true;
                    }
                    else
                    {
                        mainObject.isStop = true;
                        MainObject.imgCapchar = null;
                    }
                }
                else
                {
                    mainObject.isStop = true;
                }
            }
            else if (b == 2)
            {
                sbyte b5 = msg.reader().readByte();
                if (b5 == 1)
                {
                    mainObject.isMonPhoBangDie = true;
                    LoadMap.isShowEffAuto = LoadMap.EFF_PHOBANG_END;
                }
                else
                {
                    GameScreen.addEffectEndKill(35, mainObject.x, mainObject.y - 20);
                    mainObject.isStop = true;
                }
            }
            else
            {
                if (b == 0)
                {
                    GameScreen.addEffectEndKill(35, mainObject.x, mainObject.y - 20);
                }
                mainObject.isStop = true;
            }
        }
        catch (Exception)
        {
        }
    }

    public void Save_RMS_Server(Message msg)
    {
        try
        {
            string file = $"G:/save_rms_server.txt";

            sbyte id = msg.reader().readByte();
            short num = msg.reader().readShort();
            sbyte[] array = null;
            if (num > 0)
            {
                array = new sbyte[num];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = msg.reader().readByte();
                }
            }
            MainRMS.setLoadRMS(id, array);

            string sql = $"INSERT INTO save_rms (id, num, data) VALUES ({id}, {num}, '{JsonConvert.SerializeObject((object)array)}'\n)";
            File.AppendAllText(file, sql);

        }
        catch (Exception ex)
        {
            Cout.println("LOI TAI CMD  " + msg.command + " >> " + ex.ToString());
        }
    }

    public void List_Pk(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            Player.vecPlayerPk = new short[b];
            for (int i = 0; i < b; i++)
            {
                Player.vecPlayerPk[i] = msg.reader().readShort();
            }
        }
        catch (Exception)
        {
        }
    }

    public void List_Serverz(Message msg)
    {
        try
        {
            mSystem.outz("danh sach day000000000000000");
            string text = "List";
            sbyte b = msg.reader().readByte();
            text = msg.reader().readUTF();
            sbyte page = msg.reader().readByte();
            int num = msg.reader().readInt();
            int num2 = msg.reader().readUnsignedByte();
            mVector mVector3 = new mVector("ReadMessenge vec8");
            if (b == 3)
            {
                for (int i = 0; i < num2; i++)
                {
                    string name = msg.reader().readUTF();
                    int idClan = msg.reader().readInt();
                    short idicon = msg.reader().readShort();
                    string shortname = msg.reader().readUTF();
                    string slogan = msg.reader().readUTF();
                    MainClan mainClan = new MainClan(idClan, idicon, shortname, 122);
                    mainClan.name = name;
                    mainClan.slogan = slogan;
                    if (num > num2 && i == num2 - 1)
                    {
                        mainClan.hang = num;
                    }
                    else
                    {
                        mainClan.hang = i;
                    }
                    mVector3.addElement(mainClan);
                }
            }
            else
            {
                for (int j = 0; j < num2; j++)
                {
                    string name2 = msg.reader().readUTF();
                    sbyte b2 = msg.reader().readByte();
                    sbyte b3 = msg.reader().readByte();
                    sbyte b4 = msg.reader().readByte();
                    short lv = msg.reader().readShort();
                    sbyte b5 = msg.reader().readByte();
                    sbyte[] array = new sbyte[12];
                    for (int k = 0; k < array.Length; k++)
                    {
                        array[k] = -1;
                    }
                    for (int l = 0; l < b5; l++)
                    {
                        sbyte b6 = msg.reader().readByte();
                        sbyte b7 = msg.reader().readByte();
                        array[b7] = b6;
                    }
                    sbyte typeOnline = msg.reader().readByte();
                    string infoObject = msg.reader().readUTF();
                    MainObject mainObject = new MainObject(0, 0, name2, 0, 0);
                    short num3 = msg.reader().readShort();
                    if (num3 >= 0)
                    {
                        mainObject.myClan = new MainClan(0, num3, msg.reader().readUTF(), msg.reader().readByte());
                    }
                    mainObject.setInfo(b2, b3, b4);
                    mainObject.typeOnline = typeOnline;
                    mainObject.Lv = lv;
                    mainObject.setWearingListChar(array);
                    mainObject.infoObject = infoObject;
                    if (num > num2 && j == num2 - 1)
                    {
                        mainObject.hang = num;
                    }
                    else
                    {
                        mainObject.hang = j;
                    }
                    mVector3.addElement(mainObject);
                }
            }
            if (mVector3.size() == 0)
            {
                return;
            }
            if (b == 1)
            {
                if (num > num2)
                {
                    MainObject mainObject2 = new MainObject(0, 0, "...", 0, 0);
                    mainObject2.hang = -1;
                    mVector3.insertElementAt(mainObject2, num2 - 1);
                }
            }
            else if (b == 3)
            {
                mSystem.outz("hang=" + num);
                if (num > num2)
                {
                    MainClan mainClan2 = new MainClan(0, -1, "...", 122);
                    mainClan2.hang = -1;
                    mVector3.insertElementAt(mainClan2, num2 - 1);
                }
            }
            else if (b == 6 && num > num2)
            {
                MainObject mainObject3 = new MainObject(0, 0, "...", 0, 0);
                mainObject3.hang = -1;
                mVector3.insertElementAt(mainObject3, num2 - 1);
            }
            List_Server.gI().vecListServer = mVector3;
            List_Server.gI().setSize(b);
            List_Server.gI().updateList();
            List_Server.gI().setMinMax();
            List_Server.gI().setXmove();
            List_Server.gI().setCmd();
            List_Server.gI().nameList = text;
            List_Server.gI().page = page;
            if (GameCanvas.currentScreen != List_Server.gI())
            {
                if (GameCanvas.currentScreen.lastScreen != List_Server.gI())
                {
                    List_Server.gI().Show(GameCanvas.currentScreen);
                }
                else
                {
                    List_Server.gI().Show(GameCanvas.game);
                }
            }
            else
            {
                GameCanvas.end_Dialog();
            }
        }
        catch (Exception ex)
        {
            Debug.Log((object)ex.GetBaseException());
        }
    }

    public void suckhoe(Message msg)
    {
        try
        {
            Player.PointSucKhoe = msg.reader().readInt();
            Player.PointArena = msg.reader().readInt();
        }
        catch (Exception)
        {
        }
    }

    public void chat_npc(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            MainObject mainObject = MainObject.get_Object(b, 2);
            if (mainObject != null && !mainObject.isRemove)
            {
                mainObject.strChatPopup = msg.reader().readUTF();
            }
        }
        catch (Exception)
        {
        }
    }

    public void InfoServer_Download(Message msg)
    {
        try
        {
            string str = msg.reader().readUTF();
            string text = msg.reader().readUTF();
            sbyte b = msg.reader().readByte();
            if (GameScreen.player != null && GameScreen.player.Action != 2 && GameScreen.player.Action != 4)
            {
                GameScreen.player.resetAction();
                GameScreen.player.posTransRoad = null;
            }
            if (b == 15)
            {
                GameCanvas.start_Ok_Dialog(str, b);
            }
            else if (text.Length == 0)
            {
                GameCanvas.start_Ok_Dialog(str);
            }
            else
            {
                GameCanvas.start_Download_Dialog(str, text);
            }
        }
        catch (Exception)
        {
        }
    }

    public void name_server(Message msg)
    {
        try
        {
            int num = msg.reader().readUnsignedByte();
            string[] array = new string[num];
            string filex = $"G://LOG_SQL//map_template.sql";

            for (int i = 0; i < num; i++)
            {
                array[i] = msg.reader().readUTF();

                //string sqlx = $"INSERT INTO map_template (id, name) " +
                //    $"VALUES ({i}, '{array[i]}');\n";
                //File.AppendAllText(filex, sqlx);
            }
            WorldMapScreen.namePos = array;

            string file = $"G://LOG_SQL//quest_item.sql";
            string createTable = $"CREATE TABLE quest_item (id INT, Name NVARCHAR(100));\n";
            File.AppendAllText(file, createTable);
            sbyte b = msg.reader().readByte();
            string[] array2 = new string[b];
            for (int j = 0; j < b; j++)
            {
                array2[j] = msg.reader().readUTF();

                string sql = $"INSERT INTO quest_item (id, name) " +
                   $"VALUES ({j},'{array2[j]}');\n";
                File.AppendAllText(file, sql);
            }
            TabQuest.nameItemQuest = array2;

            sbyte b2 = msg.reader().readByte();
            TabRebuildItem.mNameMaterial = new string[b2];
            TabRebuildItem.idMaterial = new short[b2];
            TabRebuildItem.numMaterialInven = new int[b2];
            for (int k = 0; k < b2; k++)
            {
                TabRebuildItem.idMaterial[k] = msg.reader().readShort();
                MainItem material = Item.getMaterial(TabRebuildItem.idMaterial[k]);
                if (material != null)
                {
                    TabRebuildItem.mNameMaterial[k] = material.itemName;
                }
            }

            string filec = $"G://LOG_SQL//rebuild_item.sql";
            string createTablec = $"CREATE TABLE rebuild_item (id INT, name NVARCHAR(100), level INT, coint INT, gold INT, valueWing INT);\n";
            File.AppendAllText(file, createTablec);
            sbyte b3 = msg.reader().readByte();
            TabRebuildItem.dataRebuild = new DataRebuildItem[b3];
            for (int l = 0; l < b3; l++)
            {
                TabRebuildItem.dataRebuild[l] = new DataRebuildItem();
                TabRebuildItem.dataRebuild[l].lv = msg.reader().readByte();
                TabRebuildItem.dataRebuild[l].priceCoin = msg.reader().readInt();
                mSystem.outz("vang=" + TabRebuildItem.dataRebuild[l].priceCoin);
                TabRebuildItem.dataRebuild[l].priceGold = msg.reader().readShort();
                TabRebuildItem.dataRebuild[l].mValue = new sbyte[4];
                string dataValueWing = "";
                for (int m = 0; m < 4; m++)
                {
                    TabRebuildItem.dataRebuild[l].mValue[m] = msg.reader().readByte();
                    dataValueWing = "[" + TabRebuildItem.dataRebuild[l].mValue[m] + "]";
                }

                string sql = $"INSERT INTO rebuild_item (id, name, level, coint, gold, valueWing) VALUES (" +
                    $"{l},'{""}', {TabRebuildItem.dataRebuild[l].lv}, {TabRebuildItem.dataRebuild[l].priceCoin}, {TabRebuildItem.dataRebuild[l].priceGold}, {dataValueWing});\n";
                File.AppendAllText(filec, sql);

            }
        }
        catch (Exception)
        {
        }
    }

    public void x2_Xp(Message msg)
    {
        try
        {
            sbyte typeX = msg.reader().readByte();
            Player.typeX2 = typeX;
            Player.timeSetX2 = GameCanvas.timeNow;
            Player.timeX2 = msg.reader().readShort();
        }
        catch (Exception)
        {
        }
    }

    public void loadImageDataCharPart(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            short num = msg.reader().readShort();
            string path = string.Empty + num;
            int num2 = msg.reader().readInt();
            sbyte[] data = new sbyte[num2];
            msg.reader().read(ref data);
            int num3 = 0;
            if (msg.reader().available() > 0)
            {
                num3 = msg.reader().available();
            }
            sbyte[] data2 = new sbyte[1];
            if (num3 > 0)
            {
                data2 = new sbyte[num3];
                msg.reader().read(ref data2);
            }
            if (TemMidlet.DIVICE > 0)
            {
                MainImageDataPartChar o = new MainImageDataPartChar(data, data2, b, num, (short)data.Length);
                SaveImageRMS.vecSaveCharPart.addElement(o);
            }
            switch (b)
            {
                case 110://110_effect
                    ImageEffect imageEffect = (ImageEffect)ImageEffect.hashImageEff.get(string.Empty + num);
                    if (imageEffect != null)
                    {
                        imageEffect.timeRemove = GameCanvas.timeNow;
                        imageEffect.img = mImage.createImage(data, 0, 0, path);
                    }
                    break;
                case 111://111_effect_auto
                    ImageEffectAuto imageEffectAuto = (ImageEffectAuto)ImageEffectAuto.hashImageEffAuto.get(string.Empty + num);
                    if (imageEffectAuto != null)
                    {
                        imageEffectAuto.timeRemove = GameCanvas.timeNow;
                        imageEffectAuto.img = mImage.createImage(data, 0, 0, path);
                    }
                    DataEffAuto dataEffAuto = (DataEffAuto)EffectAuto.ALL_DATA_EFF_AUTO.get(string.Empty + num);
                    if (dataEffAuto != null)
                    {
                        CRes.saveRMS("data_eff" + num, data2);
                        dataEffAuto.timeremove = GameCanvas.timeNow;
                        dataEffAuto.setdata(data2);
                    }
                    break;
                case 112://112_skill_effect
                    ImageIcon imageIcon = (ImageIcon)GameData.listImgIcon.get(string.Empty + (num + GameData.ID_START_SKILL));
                    if (imageIcon != null)
                    {
                        imageIcon.timeRemove = GameCanvas.timeNow;
                        imageIcon.img = mImage.createImage(data, 0, 0, path);
                    }
                    EffectData effectData = (EffectData)DataSkillEff.ALL_DATA_EFFECT.get(string.Empty + (num + GameData.ID_START_SKILL));
                    if (effectData != null)
                    {
                        effectData.timeRemove = GameCanvas.timeNow;
                        effectData.setdata(data2);
                    }
                    break;
                case 113://113_fashion
                    ImageIcon imageIcon2 = (ImageIcon)GameData.listImgIcon.get(string.Empty + (num + GameData.ID_START_SKILL));
                    if (imageIcon2 != null)
                    {
                        imageIcon2.timeRemove = GameCanvas.timeNow;
                        imageIcon2.img = mImage.createImage(data, 0, 0, path);
                    }
                    MainObject.getEffMatNa(num)?.loadData(data2);
                    break;
            }
            MsgDialog.curupdate++;
        }
        catch (Exception)
        {
        }
    }

    public void loadImageDataAutoEff(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b != 100)
            {
                if (b == 4)
                {
                    short num = msg.reader().readShort();
                    sbyte[] array = new sbyte[num];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = msg.reader().readByte();
                    }
                    short id = msg.reader().readShort();
                    sbyte b2 = msg.reader().readByte();
                    for (int j = 0; j < b2; j++)
                    {
                        short id2 = msg.reader().readShort();
                        sbyte cat = msg.reader().readByte();
                        MainObject mainObject = GameScreen.findObjByteCat(id2, cat);
                        if (mainObject != null)
                        {
                            EffectAuto o = new EffectAuto(id, mainObject.x, mainObject.y, array);
                            GameScreen.vecHightEffAuto.addElement(o);
                        }
                    }
                    return;
                }
                if (b == 3)
                {
                    short iD = msg.reader().readShort();
                    sbyte tem = msg.reader().readByte();
                    int id3 = msg.reader().readUnsignedByte();
                    MainObject.get_Object(iD, tem)?.removeDataSkillEff(id3);
                    return;
                }
                if (b == 101)
                {
                    short num2 = msg.reader().readShort();
                    for (int k = 0; k < LoadMap.mItemMap.size(); k++)
                    {
                        MainItemMap mainItemMap = (MainItemMap)LoadMap.mItemMap.elementAt(k);
                        if (mainItemMap != null && mainItemMap.idActor == num2)
                        {
                            LoadMap.mItemMap.removeElement(mainItemMap);
                        }
                    }
                    return;
                }
                int num3 = msg.reader().readShort();
                sbyte[] array2 = new sbyte[num3];
                for (int l = 0; l < array2.Length; l++)
                {
                    array2[l] = msg.reader().readByte();
                }
                sbyte b3 = msg.reader().readByte();
                sbyte b4 = msg.reader().readByte();
                int num4 = msg.reader().readUnsignedByte();
                switch (b)
                {
                    case 0:
                        {
                            short iD3 = msg.reader().readShort();
                            sbyte tem3 = msg.reader().readByte();
                            sbyte lvpaint = msg.reader().readByte();
                            short num6 = msg.reader().readShort();
                            sbyte canmove = msg.reader().readByte();
                            long time = num6 * 1000 + mSystem.currentTimeMillis();
                            MainObject mainObject3 = MainObject.get_Object(iD3, tem3);
                            mainObject3?.addEffAutoFromsv(num4, mainObject3.x, mainObject3.y, 0, 0, 0, 0, array2, lvpaint, time, canmove, b3, b4);
                            break;
                        }
                    case 1:
                        {
                            short x = msg.reader().readShort();
                            short y = msg.reader().readShort();
                            sbyte b6 = msg.reader().readByte();
                            sbyte b7 = msg.reader().readByte();
                            short num7 = msg.reader().readShort();
                            short loop = msg.reader().readShort();
                            sbyte b8 = msg.reader().readByte();
                            if (b7 != 0 && num7 != 0)
                            {
                                MainObject mainObject4 = MainObject.get_Object(num7, b8);
                                if (mainObject4 != null)
                                {
                                    mainObject4.hOne = b7;
                                }
                            }
                            if (b6 == 3)
                            {
                                EffectAuto o2 = new EffectAuto(num4, x, y, 0, 0, b6, 5, array2, loop);
                                GameScreen.vecHightEffAuto.addElement(o2);
                            }
                            else if (b8 == 1)
                            {
                                for (int m = 0; m < LoadMap.mItemMap.size(); m++)
                                {
                                    MainItemMap mainItemMap2 = (MainItemMap)LoadMap.mItemMap.elementAt(m);
                                    if (mainItemMap2 != null && mainItemMap2.idActor == num7)
                                    {
                                        return;
                                    }
                                }
                                EffectAuto effectAuto = new EffectAuto(num4, x, y, 0, 0, b6, 0, array2);
                                effectAuto.setidActor(num7);
                                LoadMap.mItemMap.addElement(effectAuto);
                                GameCanvas.loadmap.setBlockNPC(x, y, b3, b4);
                                CRes.quickSort1(LoadMap.mItemMap);
                            }
                            else
                            {
                                EffectAuto effectAuto2 = new EffectAuto(num4, x, y, 0, 0, b6, 0, array2);
                                effectAuto2.setidActor(num7);
                                LoadMap.mItemMap.addElement(effectAuto2);
                                GameCanvas.loadmap.setBlockNPC(x, y, b3, b4);
                                CRes.quickSort1(LoadMap.mItemMap);
                            }
                            break;
                        }
                    case 2:
                        {
                            short iD2 = msg.reader().readShort();
                            sbyte tem2 = msg.reader().readByte();
                            sbyte b5 = msg.reader().readByte();
                            int num5 = msg.reader().readInt();
                            if (b5 == 17)
                            {
                                if (num5 < 0)
                                {
                                    GameScreen.player.addDataEff(num4, array2, b3, b4);
                                }
                                else if (num5 > 0)
                                {
                                    long timelive = num5 + mSystem.currentTimeMillis();
                                    GameScreen.player.addDataEff(num4, array2, b3, b4, timelive, b5);
                                }
                                break;
                            }
                            MainObject mainObject2 = MainObject.get_Object(iD2, tem2);
                            if (mainObject2 != null)
                            {
                                if (num5 < 0)
                                {
                                    mainObject2.addDataEff(num4, array2, b3, b4);
                                }
                                else if (num5 > 0)
                                {
                                    long timelive2 = num5 + mSystem.currentTimeMillis();
                                    mainObject2.addDataEff(num4, array2, b3, b4, timelive2, b5);
                                }
                                else
                                {
                                    mainObject2.addDataEff2(num4, array2, b3, b4, 0L, b5);
                                }
                            }
                            break;
                        }
                }
            }
            else
            {
                if (b != 100)
                {
                    return;
                }
                short iD4 = msg.reader().readShort();
                int num8 = msg.reader().readUnsignedByte();
                sbyte b9 = msg.reader().readByte();
                sbyte b10 = msg.reader().readByte();
                if (b9 != 0 && b9 != 1)
                {
                    return;
                }
                MainObject mainObject5 = MainObject.get_Object(iD4, b9);
                if (mainObject5 == null)
                {
                    return;
                }
                if (b10 == 0)
                {
                    for (int n = 0; n < mainObject5.vecEffauto.size(); n++)
                    {
                        EffectAuto effectAuto3 = (EffectAuto)mainObject5.vecEffauto.elementAt(n);
                        if (effectAuto3 != null && effectAuto3.IDImage == num8)
                        {
                            mainObject5.vecEffauto.removeElement(effectAuto3);
                        }
                    }
                }
                else
                {
                    if (b10 != 1)
                    {
                        return;
                    }
                    for (int num9 = 0; num9 < mainObject5.veclowEffauto.size(); num9++)
                    {
                        EffectAuto effectAuto4 = (EffectAuto)mainObject5.veclowEffauto.elementAt(num9);
                        if (effectAuto4 != null && effectAuto4.IDImage == num8)
                        {
                            mainObject5.veclowEffauto.removeElement(effectAuto4);
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            mSystem.println("loadImageDataAutoEff loi  ");
        }
    }

    public void nap_tien(Message msg)
    {
        try
        {
            GameCanvas.end_Dialog();
            short type = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            string[] array = new string[b];
            for (int i = 0; i < b; i++)
            {
                array[i] = msg.reader().readUTF();
            }
            string caption = msg.reader().readUTF();
            string name = msg.reader().readUTF();
            GameCanvas.start_More_Input_Dialog(array, new iCommand(caption, 0), type, -1, name);
        }
        catch (Exception)
        {
        }
    }

    public void delete_rms(Message msg)
    {
        try
        {
            if (GameCanvas.IndexRes != -1)
            {
                TemMidlet.delRMS();
            }
            sbyte b = msg.reader().readByte();
            sbyte[] data = new sbyte[1] { b };
            CRes.saveRMS("isIndexRes", data);
        }
        catch (Exception)
        {
        }
    }

    public void CharChest(Message msg)
    {
        mSystem.outz("oiiiiiiiiiiiiiiiiiiiiii");
        update_InVen_Or_Chest(msg, Item.VecChestPlayer, MainTabNew.CHEST);
    }

    private PetItem createPetItemFromMessage(Message msg)
    {
        try
        {
            int catagory = 9;
            sbyte b = 14;
            string itemName = msg.reader().readUTF();
            sbyte b2 = msg.reader().readByte();
            short iD = msg.reader().readShort();
            short level = msg.reader().readShort();
            short experience = msg.reader().readShort();
            sbyte b3 = msg.reader().readByte();
            sbyte petImageId = msg.reader().readByte();
            sbyte frameNumberImg = msg.reader().readByte();
            sbyte b4 = msg.reader().readByte();
            int age = msg.reader().readInt();
            short growPoint = msg.reader().readShort();
            short maxgrow = msg.reader().readShort();
            short str = msg.reader().readShort();
            short agi = msg.reader().readShort();
            short hea = msg.reader().readShort();
            short spi = msg.reader().readShort();
            short maxtiemnang = msg.reader().readShort();
            sbyte b5 = msg.reader().readByte();
            MainInfoItem[] array = new MainInfoItem[b5];
            for (int i = 0; i < b5; i++)
            {
                int id = msg.reader().readUnsignedByte();
                int value = msg.reader().readInt();
                int maxDam = msg.reader().readInt();
                array[i] = new MainInfoItem(id, value, maxDam);
            }
            PetItem petItem = new PetItem(iD, itemName, b3, b4, b2, catagory, array, b, level, b3, frameNumberImg, petImageId);
            petItem.setInfoPet(age, growPoint, str, agi, hea, spi, maxgrow, maxtiemnang, experience);
            return petItem;
        }
        catch (Exception)
        {
        }
        return null;
    }

    private MainItem createItemFromMessage(Message msg)
    {
        try
        {
            int typeMain = 3;
            string itemName = msg.reader().readUTF();
            sbyte b = msg.reader().readByte();
            short iD = msg.reader().readShort();
            sbyte b2 = msg.reader().readByte();
            short imageId = msg.reader().readShort();
            sbyte tier = msg.reader().readByte();
            short level = msg.reader().readShort();
            sbyte b3 = msg.reader().readByte();
            sbyte canSell = msg.reader().readByte();
            sbyte canTrade = msg.reader().readByte();
            sbyte b4 = msg.reader().readByte();
            MainInfoItem[] array = new MainInfoItem[b4];
            for (int i = 0; i < b4; i++)
            {
                sbyte b5 = msg.reader().readByte();
                int value = msg.reader().readInt();
                array[i] = new MainInfoItem(b5, value);
            }
            int timeUse = msg.reader().readInt();
            sbyte isLock = msg.reader().readByte();
            return new MainItem(iD, itemName, imageId, tier, b3, b, typeMain, array, b2, isTem: false, -1, 0L, level, canSell, canTrade, timeUse, 0, isLock);
        }
        catch (Exception)
        {
        }
        return null;
    }

    public void UpdatePetContainer(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            sbyte b2 = msg.reader().readByte();
            sbyte b3 = msg.reader().readByte();
            sbyte b4 = 0;
            mVector vecPetContainer = Item.VecPetContainer;
            if (b2 == 0)
            {
                MainTemplateItem.removeUpdateItemVec(b3, vecPetContainer);
                if (b3 == 3)
                {
                    b4 = msg.reader().readByte();
                    sbyte b5 = msg.reader().readByte();
                    for (int i = 0; i < b5; i++)
                    {
                        MainItem o = createItemFromMessage(msg);
                        vecPetContainer.addElement(o);
                    }
                }
                else
                {
                    if (b3 != 9)
                    {
                        return;
                    }
                    b4 = msg.reader().readByte();
                    sbyte b6 = msg.reader().readByte();
                    for (int j = 0; j < b6; j++)
                    {
                        PetItem o2 = createPetItemFromMessage(msg);
                        vecPetContainer.addElement(o2);
                    }
                    if (!GameScreen.isInPetArea)
                    {
                        return;
                    }
                    for (int k = 0; k < Item.VecPetContainer.size(); k++)
                    {
                        PetItem petItem = (PetItem)vecPetContainer.elementAt(k);
                        mSystem.outz("pet type " + petItem.type);
                        Pet pet = (Pet)MainObject.get_Object(petItem.Id, 9);
                        if (GameCanvas.subDialog != null && GameCanvas.subDialog.type == 14 && MsgDialog.isInven_Equip == MsgDialog.INVEN)
                        {
                            mSystem.outz(" Id item pet in MsgDialog = " + MsgDialog.pet.Id);
                            if (MsgDialog.pet.Id == petItem.Id)
                            {
                                MsgDialog.pet = petItem;
                            }
                        }
                        if (pet == null)
                        {
                            Pet obj = Pet.createPet((short)petItem.type, petItem.Id, petItem.nFrameImgPet, petItem.petImageId);
                            GameScreen.addPlayer(obj);
                        }
                    }
                }
            }
            else if (b2 == 1)
            {
                if (b3 == 3)
                {
                    b4 = msg.reader().readByte();
                    MainItem mainItem = createItemFromMessage(msg);
                    Item itemVec = Item.getItemVec(b4, (short)mainItem.Id, vecPetContainer);
                    if (itemVec == null)
                    {
                        vecPetContainer.addElement(mainItem);
                    }
                    else
                    {
                        vecPetContainer.setElementAt(mainItem, vecPetContainer.indexOf(itemVec));
                    }
                }
                else if (b3 == 9)
                {
                    b4 = msg.reader().readByte();
                    PetItem petItem2 = createPetItemFromMessage(msg);
                    Item itemVec2 = Item.getItemVec(b4, (short)petItem2.Id, vecPetContainer);
                    if (itemVec2 == null)
                    {
                        vecPetContainer.addElement(petItem2);
                    }
                    else
                    {
                        vecPetContainer.setElementAt(petItem2, vecPetContainer.indexOf(itemVec2));
                    }
                    if (GameScreen.isInPetArea)
                    {
                        Pet obj2 = Pet.createPet((short)petItem2.type, petItem2.Id, petItem2.nFrameImgPet, petItem2.petImageId);
                        GameScreen.addPlayer(obj2);
                    }
                }
            }
            else
            {
                if (b2 != 2)
                {
                    return;
                }
                b4 = msg.reader().readByte();
                short iD = msg.reader().readShort();
                Item itemVec3 = Item.getItemVec(b4, iD, vecPetContainer);
                if (itemVec3 != null)
                {
                    vecPetContainer.removeElement(itemVec3);
                }
                PetItem petItem3 = (PetItem)itemVec3;
                if (petItem3 != null && petItem3.type >= 0)
                {
                    Pet pet2 = (Pet)MainObject.get_Item_Object(petItem3.Id, 9);
                    if (pet2 != null)
                    {
                        GameScreen.Vecplayers.removeElement(pet2);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void Dialog_server(Message msg)
    {
        try
        {
            GameCanvas.end_Dialog();
            idDialog = msg.reader().readShort();
            typeDialog = msg.reader().readByte();
            string str = msg.reader().readUTF();
            mVector mVector3 = new mVector("ReadMessenge vec4");
            mVector3.addElement(new iCommand("Ok", 2, 1, this));
            mVector3.addElement(new iCommand(T.cancel, 2, 0, this));
            GameCanvas.start_Select_Dialog(str, mVector3);
        }
        catch (Exception)
        {
        }
    }

    public void update_InVen_Or_Chest(Message msg, mVector vec, sbyte act)
    {
        try
        {
            MainTemplateItem.isload = false;
            if (act == MainTabNew.CHEST)
            {
                Player.maxChest = msg.reader().readByte();
                mSystem.outz("size chest=" + Player.maxChest);
            }
            sbyte b = msg.reader().readByte();
            sbyte b2 = msg.reader().readByte();
            if (act == MainTabNew.INVENTORY)
            {
                long coin = msg.reader().readLong();
                int num = msg.reader().readInt();
                GameScreen.player.coin = coin;
                GameScreen.player.gold = num;
            }
            sbyte b3 = 0;
            if (b == 0)
            {
                MainTemplateItem.removeUpdateItemVec(b2, vec);
                if (b2 == 4)
                {
                    b3 = msg.reader().readByte();
                    sbyte b4 = msg.reader().readByte();
                    for (int i = 0; i < b4; i++)
                    {
                        short num2 = msg.reader().readShort();
                        short numPotion = msg.reader().readShort();
                        sbyte issell = msg.reader().readByte();
                        sbyte istrade = msg.reader().readByte();
                        MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num2);
                        MainItem o = new MainItem(num2, mainTemplateItem.IconId, mainTemplateItem.name, mainTemplateItem.contentPotion, numPotion, b3, mainTemplateItem.PricePoition, mainTemplateItem.typePotion, mainTemplateItem.moneyType, issell, istrade);
                        vec.addElement(o);
                    }
                    if (act == MainTabNew.INVENTORY)
                    {
                        MainItem.setAddHotKey(1, isStop: false);
                        MainItem.setAddHotKey(0, isStop: false);
                    }
                }
                else if (b2 == 3)
                {
                    b3 = msg.reader().readByte();
                    sbyte b5 = msg.reader().readByte();
                    for (int j = 0; j < b5; j++)
                    {
                        string text = msg.reader().readUTF();
                        sbyte b6 = msg.reader().readByte();
                        short iD = msg.reader().readShort();
                        sbyte b7 = msg.reader().readByte();
                        short imageId = msg.reader().readShort();
                        sbyte tier = msg.reader().readByte();
                        short level = msg.reader().readShort();
                        sbyte b8 = msg.reader().readByte();
                        sbyte canSell = msg.reader().readByte();
                        sbyte canTrade = msg.reader().readByte();
                        sbyte b9 = msg.reader().readByte();
                        MainInfoItem[] array = new MainInfoItem[b9];
                        for (int k = 0; k < b9; k++)
                        {
                            int id = msg.reader().readUnsignedByte();
                            int value = msg.reader().readInt();
                            array[k] = new MainInfoItem(id, value);
                            mSystem.outz("name=" + text + "id=" + array[k].id + "   value=" + array[k].value);
                        }
                        int timeUse = msg.reader().readInt();
                        sbyte isLock = msg.reader().readByte();
                        sbyte b10 = msg.reader().readByte();
                        int timeDefault = -1;
                        string s = "-1";
                        if (b10 == 1)
                        {
                            timeDefault = msg.reader().readInt();
                            s = msg.reader().readUTF();
                        }
                        sbyte canShell_notCanTrade = msg.reader().readByte();
                        MainItem mainItem = null;
                        mainItem = new MainItem(iD, text, imageId, tier, b8, b6, b3, array, b7, isTem: false, -1, 0L, level, canSell, canTrade, timeUse, 0, isLock, timeDefault, long.Parse(s));
                        mainItem.setCanShell_notCanTrade(canShell_notCanTrade);
                        vec.addElement(mainItem);
                    }
                }
                else if (b2 == 5)
                {
                    b3 = msg.reader().readByte();
                    sbyte b11 = msg.reader().readByte();
                    for (int l = 0; l < b11; l++)
                    {
                        short iD2 = msg.reader().readShort();
                        string name = msg.reader().readUTF();
                        short numQItem = msg.reader().readShort();
                        string questitem = T.questitem;
                        sbyte issell2 = msg.reader().readByte();
                        sbyte istrade2 = msg.reader().readByte();
                        MainItem o2 = new MainItem(iD2, name, numQItem, questitem, issell2, istrade2);
                        vec.addElement(o2);
                    }
                }
                else if (b2 == 7)
                {
                    b3 = msg.reader().readByte();
                    sbyte b12 = msg.reader().readByte();
                    for (int m = 0; m < b12; m++)
                    {
                        short num3 = msg.reader().readShort();
                        short num4 = msg.reader().readShort();
                        sbyte b13 = msg.reader().readByte();
                        sbyte b14 = msg.reader().readByte();
                        MainItem material = Item.getMaterial(num3);
                        if (material != null)
                        {
                            MainItem o3 = MainItem.MainItem_Material(num3, material.itemName, material.imageId, 7, material.priceItem, material.priceType, material.content, material.value, material.typeMaterial, num4, b13, b14);
                            vec.addElement(o3);
                            continue;
                        }
                        MainItem mainItem2 = new MainItem();
                        mainItem2.Id = num3;
                        mainItem2.numPotion = num4;
                        mainItem2.canSell = b13;
                        mainItem2.canTrade = b14;
                        mainItem2.ItemCatagory = 7;
                        Item.put_Material(num3);
                        vec.addElement(mainItem2);
                    }
                }
                if (act == MainTabNew.INVENTORY && b2 != 3)
                {
                    TabShopNew.isSortInven = true;
                }
            }
            else if (b == 1)
            {
                if (b2 == 4)
                {
                    b3 = msg.reader().readByte();
                    short num5 = msg.reader().readShort();
                    short numPotion2 = msg.reader().readShort();
                    sbyte b15 = msg.reader().readByte();
                    sbyte b16 = msg.reader().readByte();
                    Item itemVec = Item.getItemVec(b3, num5, vec);
                    if (itemVec != null)
                    {
                        itemVec.numPotion = numPotion2;
                        itemVec.canSell = b15;
                        itemVec.canTrade = b16;
                    }
                    else
                    {
                        MainTemplateItem mainTemplateItem2 = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num5);
                        MainItem o4 = new MainItem(num5, mainTemplateItem2.IconId, mainTemplateItem2.name, mainTemplateItem2.contentPotion, numPotion2, b3, mainTemplateItem2.PricePoition, mainTemplateItem2.typePotion, mainTemplateItem2.moneyType, b15, b16);
                        vec.addElement(o4);
                    }
                    if (act == MainTabNew.INVENTORY)
                    {
                        MainItem.setAddHotKey(1, isStop: false);
                        MainItem.setAddHotKey(0, isStop: false);
                        if (GameScreen.help.setStep_Next(1, 5))
                        {
                            GameScreen.help.Next++;
                            GameScreen.help.setNext();
                        }
                    }
                }
                else if (b2 == 3)
                {
                    b3 = msg.reader().readByte();
                    string itemName = msg.reader().readUTF();
                    sbyte b17 = msg.reader().readByte();
                    short iD3 = msg.reader().readShort();
                    Item itemVec2 = Item.getItemVec(b3, iD3, vec);
                    sbyte b18 = msg.reader().readByte();
                    short imageId2 = msg.reader().readShort();
                    sbyte plusItem = msg.reader().readByte();
                    short lvItem = msg.reader().readShort();
                    sbyte b19 = msg.reader().readByte();
                    sbyte issell3 = msg.reader().readByte();
                    sbyte istrade3 = msg.reader().readByte();
                    sbyte b20 = msg.reader().readByte();
                    MainInfoItem[] array2 = new MainInfoItem[b20];
                    for (int n = 0; n < b20; n++)
                    {
                        array2[n] = new MainInfoItem(msg.reader().readUnsignedByte(), msg.reader().readInt());
                    }
                    int timeUse2 = msg.reader().readInt();
                    sbyte isLock2 = msg.reader().readByte();
                    sbyte b21 = msg.reader().readByte();
                    int timeDefault2 = -1;
                    string s2 = "-1";
                    if (b21 == 1)
                    {
                        timeDefault2 = msg.reader().readInt();
                        s2 = msg.reader().readUTF();
                    }
                    sbyte canShell_notCanTrade2 = msg.reader().readByte();
                    MainItem mainItem3 = MainItem.MainItem_Item(iD3, itemName, imageId2, plusItem, b19, b17, b3, array2, b18, isTem: false, -1, 0L, lvItem, issell3, istrade3, timeUse2, 0, isLock2, timeDefault2, long.Parse(s2));
                    mainItem3.setCanShell_notCanTrade(canShell_notCanTrade2);
                    if (itemVec2 == null)
                    {
                        vec.addElement(mainItem3);
                    }
                    else
                    {
                        vec.setElementAt(mainItem3, vec.indexOf(itemVec2));
                    }
                }
                else if (b2 == 9)
                {
                    b3 = msg.reader().readByte();
                    PetItem petItem = createPetItemFromMessage(msg);
                    Item itemVec3 = Item.getItemVec(b3, (short)petItem.Id, vec);
                    if (itemVec3 == null)
                    {
                        vec.addElement(petItem);
                    }
                    else
                    {
                        mSystem.outz("replace pet");
                        vec.setElementAt(petItem, vec.indexOf(itemVec3));
                    }
                }
                else if (b2 == 5)
                {
                    b3 = msg.reader().readByte();
                    short iD4 = msg.reader().readShort();
                    string name2 = msg.reader().readUTF();
                    short num6 = msg.reader().readShort();
                    string questitem2 = T.questitem;
                    sbyte b22 = msg.reader().readByte();
                    sbyte b23 = msg.reader().readByte();
                    Item itemVec4 = Item.getItemVec(b3, iD4, vec);
                    if (itemVec4 == null)
                    {
                        MainItem o5 = new MainItem(iD4, name2, num6, questitem2, b22, b23);
                        vec.addElement(o5);
                    }
                    else
                    {
                        itemVec4.numPotion = num6;
                        itemVec4.canSell = b22;
                        itemVec4.canTrade = b23;
                    }
                }
                else if (b2 == 7)
                {
                    b3 = msg.reader().readByte();
                    short num7 = msg.reader().readShort();
                    short num8 = msg.reader().readShort();
                    sbyte b24 = msg.reader().readByte();
                    sbyte b25 = msg.reader().readByte();
                    Item itemVec5 = Item.getItemVec(b3, num7, vec);
                    if (itemVec5 != null)
                    {
                        itemVec5.numPotion = num8;
                        itemVec5.canSell = b24;
                        itemVec5.canTrade = b25;
                    }
                    else
                    {
                        MainItem material2 = Item.getMaterial(num7);
                        if (material2 != null)
                        {
                            itemVec5 = MainItem.MainItem_Material(num7, material2.itemName, material2.imageId, 7, material2.priceItem, material2.priceType, material2.content, material2.canTrade, material2.typeMaterial, num8, b24, b25);
                            vec.addElement(itemVec5);
                        }
                        else
                        {
                            MainItem mainItem4 = new MainItem();
                            mainItem4.Id = num7;
                            mainItem4.numPotion = num8;
                            mainItem4.canSell = b24;
                            mainItem4.canTrade = b25;
                            mainItem4.ItemCatagory = 7;
                            Item.put_Material(num7);
                            vec.addElement(mainItem4);
                        }
                    }
                    if (act == MainTabNew.INVENTORY)
                    {
                        for (int num9 = 0; num9 < TabRebuildItem.idMaterial.Length; num9++)
                        {
                            MainItem material3 = Item.getMaterial(TabRebuildItem.idMaterial[num9]);
                            int num10 = 0;
                            if (material3 != null)
                            {
                                Item itemInventory = Item.getItemInventory(material3.ItemCatagory, (short)material3.Id);
                                if (itemInventory != null)
                                {
                                    num10 = itemInventory.numPotion;
                                }
                            }
                            TabRebuildItem.numMaterialInven[num9] = num10;
                        }
                    }
                }
                if (act == MainTabNew.INVENTORY)
                {
                    if (GameScreen.help.Step == 1 && GameScreen.help.Next == 5)
                    {
                        GameScreen.help.Next++;
                        GameScreen.help.setNext();
                    }
                    if (b2 != 3)
                    {
                        TabShopNew.isSortInven = true;
                    }
                }
            }
            else if (b == 2)
            {
                b3 = msg.reader().readByte();
                short iD5 = msg.reader().readShort();
                Item itemVec6 = Item.getItemVec(b3, iD5, vec);
                if (itemVec6 != null)
                {
                    vec.removeElement(itemVec6);
                }
                if (act == MainTabNew.INVENTORY)
                {
                    if (b2 == 4)
                    {
                        MainItem.setAddHotKey(1, isStop: false);
                        MainItem.setAddHotKey(0, isStop: false);
                    }
                    else if (b2 == 7 && act == MainTabNew.INVENTORY)
                    {
                        for (int num11 = 0; num11 < TabRebuildItem.idMaterial.Length; num11++)
                        {
                            MainItem mainItem5 = (MainItem)MainTemplateItem.hashMaterialTem.get(string.Empty + TabRebuildItem.idMaterial[num11]);
                            int num12 = 0;
                            if (mainItem5 != null)
                            {
                                Item itemInventory2 = Item.getItemInventory(mainItem5.ItemCatagory, (short)mainItem5.Id);
                                if (itemInventory2 != null)
                                {
                                    num12 = itemInventory2.numPotion;
                                }
                            }
                            TabRebuildItem.numMaterialInven[num11] = num12;
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        MainTemplateItem.isload = true;
        MainTabNew.timePaintInfo = 0;
    }

    public void Rebuild_Item(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                short iD = msg.reader().readShort();
                sbyte b2 = msg.reader().readByte();
                if (b2 == 3)
                {
                    Item itemInventory = Item.getItemInventory(b2, iD);
                    if (itemInventory != null && TabRebuildItem.isBeginEff == 0)
                    {
                        TabRebuildItem.itemRe = MainItem.MainItem_Item(iD, itemInventory.itemNameExcludeLv, itemInventory.imageId, itemInventory.tier, itemInventory.colorNameItem, itemInventory.classcharItem, b2, itemInventory.mInfo, itemInventory.type_Only_Item, isTem: false, itemInventory.IdTem, itemInventory.priceItem, (short)itemInventory.LvItem, itemInventory.canSell, itemInventory.canTrade, 0, 0, 0);
                    }
                }
                else
                {
                    TabRebuildItem.isLucky = true;
                }
                if (TabRebuildItem.isBeginEff == 0)
                {
                    TabRebuildItem.tilemayman = msg.reader().readUTF();
                    TabRebuildItem.tilemaymanafter = TabRebuildItem.tilemayman;
                }
                else
                {
                    TabRebuildItem.tilemaymanafter = msg.reader().readUTF();
                }
            }
            else if (b == 1)
            {
                sbyte b3 = msg.reader().readByte();
                if (b3 == 3)
                {
                    TabRebuildItem.itemRe = null;
                }
                else
                {
                    TabRebuildItem.isLucky = false;
                }
                if (TabRebuildItem.isBeginEff == 0)
                {
                    TabRebuildItem.tilemayman = msg.reader().readUTF();
                    TabRebuildItem.tilemaymanafter = TabRebuildItem.tilemayman;
                }
                else
                {
                    TabRebuildItem.tilemaymanafter = msg.reader().readUTF();
                }
            }
            else if (b == 2)
            {
                GameCanvas.end_Dialog();
                TabRebuildItem.isBeginEff = 1;
                TabRebuildItem.isNextRebuild = msg.reader().readByte();
                TabRebuildItem.contentShow = msg.reader().readUTF();
                mSystem.outloi("thanh cong hay that bai=" + TabRebuildItem.isNextRebuild);
            }
            else if (b == 3)
            {
                GameCanvas.end_Dialog();
                string name = msg.reader().readUTF();
                GameCanvas.menu2.startAt_NPC(null, name, Menu2.IdNPCLast, 2, isQuest: false, 0);
            }
            else if (b == 4)
            {
                short iD2 = msg.reader().readShort();
                short num = msg.reader().readShort();
                string original = msg.reader().readUTF();
                sbyte b4 = msg.reader().readByte();
                Item itemInventory2 = Item.getItemInventory(b4, iD2);
                if (itemInventory2 == null)
                {
                    return;
                }
                TabRebuildItem.itemRe = MainItem.MainItem_Item(iD2, itemInventory2.itemNameExcludeLv, itemInventory2.imageId, itemInventory2.tier, itemInventory2.colorNameItem, itemInventory2.classcharItem, b4, itemInventory2.mInfo, itemInventory2.type_Only_Item, isTem: false, itemInventory2.IdTem, itemInventory2.priceItem, (short)itemInventory2.LvItem, itemInventory2.canSell, itemInventory2.canTrade, 0, 0, 0);
                TabRebuildItem.itemRe.itemClone = null;
                TabRebuildItem.itemRe.infoHop = mSystem.split(original, "|");
                MainItem material = Item.getMaterial(TabRebuildItem.itemRe.Id);
                if (material != null)
                {
                    TabRebuildItem.itemRe.itemName = material.itemName;
                }
                int id = num;
                MainItem material2 = Item.getMaterial(id);
                if (material2 != null)
                {
                    if (material2.isMaterialHopNguyenLieu())
                    {
                        TabRebuildItem.itemRe.itemClone = material2.clone();
                    }
                }
                else
                {
                    MainItem mainItem = new MainItem();
                    mainItem.Id = id;
                    mainItem.ItemCatagory = 7;
                    TabRebuildItem.itemRe.itemClone = mainItem;
                }
            }
            else if (b == 5)
            {
                GameCanvas.end_Dialog();
                TabRebuildItem.isBeginEff = 1;
                TabRebuildItem.isNextRebuild = msg.reader().readByte();
                TabRebuildItem.contentShow = msg.reader().readUTF();
            }
            else if (b == 6)
            {
                TabRebuildItem.itemRe = null;
            }
        }
        catch (Exception)
        {
        }
    }

    public void ReplacePlusItem(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                short iD = msg.reader().readShort();
                sbyte b2 = msg.reader().readByte();
                Item itemInventory = Item.getItemInventory(3, iD);
                if (itemInventory != null)
                {
                    if (b2 == 1)
                    {
                        TabRebuildItem.itemPlus = MainItem.MainItem_Item(iD, itemInventory.itemNameExcludeLv, itemInventory.imageId, itemInventory.tier, itemInventory.colorNameItem, itemInventory.classcharItem, 3, itemInventory.mInfo, itemInventory.type_Only_Item, isTem: false, itemInventory.IdTem, itemInventory.priceItem, (short)itemInventory.LvItem, itemInventory.canSell, itemInventory.canTrade, 0, 0, 0);
                    }
                    else if (b2 == 0)
                    {
                        TabRebuildItem.itemFree = MainItem.MainItem_Item(iD, itemInventory.itemNameExcludeLv, itemInventory.imageId, itemInventory.tier, itemInventory.colorNameItem, itemInventory.classcharItem, 3, itemInventory.mInfo, itemInventory.type_Only_Item, isTem: false, itemInventory.IdTem, itemInventory.priceItem, (short)itemInventory.LvItem, itemInventory.canSell, itemInventory.canTrade, 0, 0, 0);
                    }
                }
                else
                {
                    mSystem.outz("k le no null=");
                }
            }
            else if (b == 1)
            {
                GameCanvas.end_Dialog();
                short num = msg.reader().readShort();
                if (TabRebuildItem.itemPlus != null && TabRebuildItem.itemFree != null)
                {
                    mVector mVector3 = new mVector("ReadMessenge menu3");
                    mVector3.addElement(new iCommand(T.replace, 4, this));
                    GameCanvas.menu2.startAt_NPC(mVector3, T.hoichuyendo + TabRebuildItem.itemPlus.itemName + T.qua + TabRebuildItem.itemFree.itemName + "? " + T.phi + ": " + num + " " + T.gem + ".", Menu2.IdNPCLast, 2, isQuest: false, 0);
                }
            }
            else if (b == 2)
            {
                GameCanvas.end_Dialog();
                TabRebuildItem.contentShow = msg.reader().readUTF();
                TabRebuildItem.isBeginEff = 1;
            }
            else if (b == 3)
            {
                GameCanvas.end_Dialog();
                string name = msg.reader().readUTF();
                GameCanvas.menu2.startAt_NPC(null, name, Menu2.IdNPCLast, 2, isQuest: false, 0);
            }
        }
        catch (Exception)
        {
        }
    }

    public void Thach_Dau(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                string namecheck = msg.reader().readUTF();
                short numThachdau = msg.reader().readShort();
                GameCanvas.mevent.addEvent(namecheck, 4, T.loimoithachdau, numThachdau);
            }
        }
        catch (Exception)
        {
        }
    }

    public void Help_From_Server(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            MainObject mainObject = MainObject.get_Object(b, 2);
            if (mainObject != null && !mainObject.isRemove)
            {
                string original = msg.reader().readUTF();
                MainObject.strHelpNPC = mFont.split(original, "\b");
                MainObject.StepHelpServer = 0;
                mVector mVector3 = new mVector("ReadMessenge menu2");
                iCommand o = new iCommand(T.next, 3, b, this);
                mVector3.addElement(o);
                GameCanvas.menu2.startAt_NPC(mVector3, MainObject.strHelpNPC[0], b, 2, isQuest: false, 2);
            }
        }
        catch (Exception)
        {
        }
    }

    public void Clan(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            mSystem.outz("nhan mess bang=" + b);
            string empty = string.Empty;
            string text = string.Empty;
            long num = 0L;
            int num2 = 0;
            sbyte chucvu = 122;
            short num3 = 0;
            switch (b)
            {
                case 10:
                    empty = msg.reader().readUTF();
                    GameCanvas.mevent.addEvent(empty, 5, T.loimoivaoclan, 0);
                    break;
                case 14:
                    {
                        empty = msg.reader().readUTF();
                        short num10 = msg.reader().readShort();
                        chucvu = msg.reader().readByte();
                        num = msg.reader().readLong();
                        num2 = msg.reader().readInt();
                        GameCanvas.start_Ok_Dialog(T.thanhvien + ": " + empty + " " + T.level + num10 + "\n" + T.chucvu + MainClan.getNameChucVu(chucvu) + "\n" + T.gop + T.coin + ": " + num + "\n" + T.gop + T.gem + ": " + num2);
                        break;
                    }
                case 15:
                    {
                        sbyte b2 = msg.reader().readByte();
                        sbyte b3 = msg.reader().readByte();
                        if (b3 == 0)
                        {
                            int idClan = msg.reader().readInt();
                            num3 = msg.reader().readShort();
                            text = msg.reader().readUTF();
                            empty = msg.reader().readUTF();
                            short lv = msg.reader().readShort();
                            short ptlv = msg.reader().readShort();
                            short hang = msg.reader().readShort();
                            short numMem = msg.reader().readShort();
                            short maxMem = msg.reader().readShort();
                            string nameBoss = msg.reader().readUTF();
                            string slogan = msg.reader().readUTF();
                            string noiquy = msg.reader().readUTF();
                            num = msg.reader().readLong();
                            num2 = msg.reader().readInt();
                            sbyte b4 = msg.reader().readByte();
                            MainThanhTichClan[] array = null;
                            if (b4 > 0)
                            {
                                array = new MainThanhTichClan[b4];
                                for (int i = 0; i < array.Length; i++)
                                {
                                    array[i] = new MainThanhTichClan(msg.reader().readByte(), msg.reader().readByte(), msg.reader().readUTF());
                                }
                            }
                            if (b2 == 0)
                            {
                                if (GameScreen.player.myClan == null)
                                {
                                    GameScreen.player.myClan = new MainClan(idClan, num3, text, 122);
                                }
                                GameScreen.player.myClan.setInfoClan(empty, lv, ptlv, hang, numMem, maxMem, slogan, noiquy, nameBoss, num, num2, array);
                                if (GameCanvas.clan == null)
                                {
                                    GameCanvas.clan = new Clan_Screen();
                                }
                                GameCanvas.clan.setInfoClan(GameScreen.player.myClan, b2);
                                GameCanvas.clan.Show(GameCanvas.currentScreen);
                            }
                            else
                            {
                                MainClan mainClan = new MainClan(idClan, num3, text, 122);
                                mainClan.setInfoClan(empty, lv, ptlv, hang, numMem, maxMem, slogan, noiquy, nameBoss, num, num2, array);
                                if (GameCanvas.clan == null)
                                {
                                    GameCanvas.clan = new Clan_Screen();
                                }
                                GameCanvas.clan.setInfoClan(mainClan, b2);
                                GameCanvas.clan.Show(GameCanvas.currentScreen);
                            }
                            GameCanvas.end_Dialog();
                        }
                        else if (b3 == 1)
                        {
                            if (GameScreen.player.myClan != null)
                            {
                                GameScreen.player.myClan.coin = msg.reader().readLong();
                                GameScreen.player.myClan.gold = msg.reader().readInt();
                            }
                        }
                        else if (b3 == 2)
                        {
                            if (GameScreen.player.myClan != null)
                            {
                                GameScreen.player.myClan.noiquy = msg.reader().readUTF();
                                Clan_Screen.isUpdateThongTin = true;
                            }
                        }
                        else if (b3 == 3 && GameScreen.player.myClan != null)
                        {
                            GameScreen.player.myClan.slogan = msg.reader().readUTF();
                            Clan_Screen.isUpdateThongTin = true;
                        }
                        break;
                    }
                case 19:
                    {
                        short num8 = msg.reader().readShort();
                        string strB = msg.reader().readUTF();
                        int num9 = msg.reader().readInt();
                        if (num9 != -1)
                        {
                            empty = msg.reader().readUTF();
                            text = msg.reader().readUTF();
                            num3 = msg.reader().readShort();
                            chucvu = msg.reader().readByte();
                        }
                        MainObject mainObject = null;
                        if (num8 != 32000)
                        {
                            mainObject = MainObject.get_Object(num8, 0);
                            if (mainObject != null)
                            {
                                if (num9 == -1)
                                {
                                    if (mainObject.myClan != null)
                                    {
                                        mainObject.myClan.isRemove = true;
                                    }
                                }
                                else if (mainObject.myClan == null)
                                {
                                    mainObject.myClan = new MainClan(num9, num3, text, chucvu);
                                }
                                else
                                {
                                    mainObject.myClan.IdClan = num9;
                                    mainObject.myClan.IdIcon = num3;
                                    mainObject.myClan.shortName = text.ToUpper();
                                    mainObject.myClan.chucvu = chucvu;
                                }
                            }
                        }
                        if (GameCanvas.currentScreen != List_Server.gI() || List_Server.gI().typeList != 4)
                        {
                            break;
                        }
                        for (int k = 0; k < List_Server.gI().vecListServer.size(); k++)
                        {
                            MainObject mainObject2 = (MainObject)List_Server.gI().vecListServer.elementAt(k);
                            if (mainObject2.name.CompareTo(strB) != 0)
                            {
                                continue;
                            }
                            if (mainObject2.myClan != null)
                            {
                                if (num9 == -1)
                                {
                                    mainObject2.myClan.chucvu = 121;
                                }
                                else
                                {
                                    mainObject2.myClan.chucvu = chucvu;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case 20:
                    {
                        string str = msg.reader().readUTF();
                        GameCanvas.start_Ok_Dialog(str);
                        break;
                    }
                case 21:
                    {
                        sbyte b5 = msg.reader().readByte();
                        mSystem.outz("typeinven=" + b5);
                        if (b5 == 3)
                        {
                            Item.VecClanInvetory.removeAllElements();
                            short num4 = msg.reader().readShort();
                            for (int j = 0; j < num4; j++)
                            {
                                short num5 = msg.reader().readShort();
                                short numPotion = msg.reader().readShort();
                                MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num5);
                                MainItem o = new MainItem(num5, mainTemplateItem.IconId, mainTemplateItem.name, mainTemplateItem.contentPotion, numPotion, 4, mainTemplateItem.PricePoition, mainTemplateItem.typePotion, mainTemplateItem.moneyType, 0, 0);
                                Item.VecClanInvetory.addElement(o);
                            }
                            mVector mVector3 = new mVector("ReadMessenge vec3");
                            TabShopNew o2 = new TabShopNew(Item.VecClanInvetory, MainTabNew.CLAN_INVENTORY, T.tabBangHoi, -1, TabShopNew.NORMAL);
                            mVector3.addElement(o2);
                            GameCanvas.shopNpc = new TabScreenNew();
                            GameCanvas.shopNpc.selectTab = 0;
                            GameCanvas.shopNpc.addMoreTab(mVector3);
                            GameCanvas.shopNpc.Show(GameScreen.gI());
                            GameCanvas.end_Dialog();
                        }
                        else if (b5 == 2)
                        {
                            short iD = msg.reader().readShort();
                            Item itemVec = Item.getItemVec(4, iD, Item.VecClanInvetory);
                            if (itemVec != null)
                            {
                                Item.VecClanInvetory.removeElement(itemVec);
                            }
                        }
                        else if (b5 == 0)
                        {
                            short num6 = msg.reader().readShort();
                            short num7 = msg.reader().readShort();
                            Item itemVec2 = Item.getItemVec(4, num6, Item.VecClanInvetory);
                            if (itemVec2 != null)
                            {
                                itemVec2.numPotion = num7;
                                mSystem.outz("num=" + num7);
                            }
                            else
                            {
                                MainTemplateItem mainTemplateItem2 = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num6);
                                MainItem o3 = new MainItem(num6, mainTemplateItem2.IconId, mainTemplateItem2.name, mainTemplateItem2.contentPotion, num7, 4, mainTemplateItem2.PricePoition, mainTemplateItem2.typePotion, mainTemplateItem2.moneyType, 0, 0);
                                Item.VecClanInvetory.addElement(o3);
                            }
                        }
                        break;
                    }
                case 22:
                    if (GameScreen.player.myClan != null)
                    {
                        GameScreen.player.myClan.typeX2 = msg.reader().readByte();
                        GameScreen.player.myClan.timeX2 = msg.reader().readShort();
                        mSystem.outz("type=" + GameScreen.player.myClan.typeX2 + "time=" + GameScreen.player.myClan.timeX2);
                    }
                    break;
                case 11:
                case 12:
                case 13:
                case 16:
                case 17:
                case 18:
                    break;
            }
        }
        catch (Exception)
        {
        }
    }

    public void updateHpNPC(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            short hp = msg.reader().readShort();
            short maxHp = msg.reader().readShort();
            sbyte b2 = msg.reader().readByte();
            MainObject mainObject = MainObject.get_Object(b2, 2);
            if (mainObject != null && !mainObject.isRemove)
            {
                mainObject.hp = hp;
                mainObject.maxHp = maxHp;
            }
        }
        catch (Exception)
        {
        }
    }

    public void Dialog_More_server(Message msg)
    {
        try
        {
            GameCanvas.end_Dialog();
            idDialog = msg.reader().readShort();
            typeDialog = msg.reader().readByte();
            string name = msg.reader().readUTF();
            sbyte b = msg.reader().readByte();
            string[] array = new string[b];
            string[] array2 = new string[b];
            sbyte typemo = 1;
            sbyte[] array3 = new sbyte[b];
            for (int i = 0; i < b; i++)
            {
                array[i] = msg.reader().readUTF();
                array3[i] = msg.reader().readByte();
                array2[i] = string.Empty;
            }
            try
            {
                for (int j = 0; j < b; j++)
                {
                    array2[j] = msg.reader().readUTF();
                }
                typemo = msg.reader().readByte();
            }
            catch (Exception)
            {
            }
            GameCanvas.start_More_Input_Dialog(array, new iCommand("OK", 1), typeDialog, idDialog, name, array2, typemo);
        }
        catch (Exception)
        {
        }
    }

    public void InfoEasyFromServer(Message msg)
    {
        try
        {
            string str = msg.reader().readUTF();
            sbyte b = msg.reader().readByte();
            Debug.LogError("thongbao: " + str + " type: " + b);

            if (b == 0)
            {
                GameCanvas.addInfoChar(str);
            }
            else if (b == 1)
            {
                GameCanvas.addInfoCharServer(str);
            }
        }
        catch (Exception)
        {
        }
    }

    public void EffFormServer(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            sbyte tem = msg.reader().readByte();
            short num = msg.reader().readShort();
            short num2 = msg.reader().readShort();
            sbyte b2 = msg.reader().readByte();
            short idFrom = msg.reader().readShort();
            MainObject mainObject = MainObject.get_Object(num, tem);
            if (b < 0 || mainObject == null || mainObject.isRemove)
            {
                return;
            }
            switch (b)
            {
                case 0:
                    GameScreen.addEffectEndKill(38, mainObject.x, mainObject.y - 20);
                    break;
                case 1:
                    {
                        mSystem.outz("time=" + num2 + " 00000000000000 =" + mainObject.name);
                        for (int j = 0; j < EffectManager.hiEffects.size(); j++)
                        {
                            MainEffect mainEffect2 = (MainEffect)EffectManager.hiEffects.elementAt(j);
                            if (mainEffect2.typeEffect == 85 && mainEffect2.objBeKillMain != null && mainEffect2.objBeKillMain.ID == num)
                            {
                                if (num2 == 0)
                                {
                                    mainEffect2.isStop = true;
                                }
                                return;
                            }
                        }
                        GameScreen.addEffectKill(85, mainObject.x, mainObject.y, num2, num, tem);
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < EffectManager.hiEffects.size(); i++)
                        {
                            MainEffect mainEffect = (MainEffect)EffectManager.hiEffects.elementAt(i);
                            if (mainEffect.typeEffect == 87 && mainEffect.objBeKillMain != null && mainEffect.objBeKillMain.ID == num && num2 == 0)
                            {
                                mainEffect.isStop = true;
                                return;
                            }
                        }
                        GameScreen.addEffectKill(87, mainObject.x, mainObject.y, num2, num, tem);
                        break;
                    }
                case 3:
                    GameScreen.addEffectEndKill(43, mainObject.x, mainObject.y);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 4:
                    GameScreen.checkAddEff(94, mainObject.x, mainObject.y, num2, num, tem, idFrom, 1, addLow: false);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 5:
                    GameScreen.checkAddEff(100, mainObject.x, mainObject.y, num2, num, tem, idFrom, 1, addLow: false);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 6:
                    GameScreen.checkAddEff(101, mainObject.x, mainObject.y, num2, num, tem, idFrom, 1, addLow: false);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 7:
                    GameScreen.checkAddEff(102, mainObject.x, mainObject.y, num2, num, tem, idFrom, 1, addLow: false);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 8:
                    GameScreen.checkAddEff(107, mainObject.x, mainObject.y, num2, num, tem, idFrom, 1, addLow: false);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 9:
                    mainObject.beginFire();
                    GameScreen.checkAddEff(103, mainObject.x, mainObject.y, num2, num, tem, idFrom, 1, addLow: false);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 10:
                    mainObject.addnewBuff(12, num2);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 11:
                    mainObject.addnewBuff(13, num2);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 12:
                    mainObject.addnewBuff(11, num2);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
                case 13:
                    mainObject.addnewBuff(14, num2);
                    if (b2 > 0)
                    {
                        LoadMap.timeVibrateScreen = b2;
                    }
                    break;
            }
        }
        catch (Exception)
        {
        }
    }

    public void EffWeather(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == -1)
            {
                for (int i = 0; i < GameScreen.vecWeather.size(); i++)
                {
                    AnimateEffect animateEffect = (AnimateEffect)GameScreen.vecWeather.elementAt(i);
                    if (animateEffect.type == 0 || animateEffect.type == 2 || animateEffect.type == 1 || animateEffect.type == 4)
                    {
                        animateEffect.stop();
                    }
                }
                return;
            }
            short num = msg.reader().readShort();
            short num2 = msg.reader().readShort();
            mSystem.outz("okiiiiiiiiiiiiiiiiiii888888888888888=" + num2);
            if (num2 == 0)
            {
                for (int j = 0; j < GameScreen.vecWeather.size(); j++)
                {
                    AnimateEffect animateEffect2 = (AnimateEffect)GameScreen.vecWeather.elementAt(j);
                    if (animateEffect2.type == b)
                    {
                        mSystem.outz("okiiiiiiiiiiiiiiiiiii888888888888888huy mua");
                        animateEffect2.isStop = true;
                        break;
                    }
                }
            }
            else
            {
                if (b != 0 && b != 2 && b != 1 && b != 4)
                {
                    return;
                }
                mSystem.outz("okiiiiiiiiiiiiiiiiiii888888888888888=" + b + "    num=" + num);
                for (int k = 0; k < GameScreen.vecWeather.size(); k++)
                {
                    AnimateEffect animateEffect3 = (AnimateEffect)GameScreen.vecWeather.elementAt(k);
                    if (animateEffect3.type == b)
                    {
                        animateEffect3.isStop = true;
                        break;
                    }
                }
                GameScreen.AddEffWeather(b, isSt: true, num, num2);
            }
        }
        catch (Exception)
        {
        }
    }

    public void Num_Eff(Message msg)
    {
        try
        {
            sbyte tem = msg.reader().readByte();
            short iD = msg.reader().readShort();
            string content = msg.reader().readUTF();
            sbyte b = msg.reader().readByte();
            MainObject mainObject = MainObject.get_Object(iD, tem);
            if (mainObject != null && !mainObject.isRemove)
            {
                GameScreen.addEffectNum(content, mainObject.x, mainObject.y - mainObject.hOne / 2, 8, b);
            }
        }
        catch (Exception)
        {
        }
    }

    public void Rebuild_Wing(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                TabRebuildItem.isChetao = msg.reader().readInt();
                TabRebuildItem.nameWing = msg.reader().readUTF();
                TabRebuildItem.priceWing = msg.reader().readInt();
                TabRebuildItem.lvReWing = msg.reader().readShort();
                TabRebuildItem.timeUseWing = msg.reader().readInt();
                sbyte b2 = msg.reader().readByte();
                TabRebuildItem.dataWing = new DataRebuildItem[b2];
                for (int i = 0; i < b2; i++)
                {
                    short id = msg.reader().readShort();
                    short valueWing = msg.reader().readShort();
                    TabRebuildItem.dataWing[i] = new DataRebuildItem(id, valueWing);
                }
                TabRebuildItem.numWingMaterialInven = new int[b2];
                for (int j = 0; j < TabRebuildItem.dataWing.Length; j++)
                {
                    MainItem material = Item.getMaterial(TabRebuildItem.dataWing[j].id);
                    int num = 0;
                    if (material != null)
                    {
                        Item itemInventory = Item.getItemInventory(material.ItemCatagory, (short)material.Id);
                        if (itemInventory != null)
                        {
                            num = itemInventory.numPotion;
                        }
                    }
                    TabRebuildItem.numWingMaterialInven[j] = num;
                }
            }
            else if (b == 1)
            {
                string name = msg.reader().readUTF();
                TabRebuildItem.itemWing = null;
                mVector mVector3 = new mVector("ReadMessenge vec12");
                TabShopNew o = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.tabhanhtrang, -1, TabShopNew.INVEN_AND_WING);
                mVector3.addElement(o);
                MainTabNew mainTabNew = null;
                mainTabNew = new TabRebuildItem(name, TabRebuildItem.TYPE_REBUILD_WING);
                mVector3.addElement(mainTabNew);
                GameCanvas.shopNpc = new TabScreenNew();
                GameCanvas.shopNpc.selectTab = 1;
                GameCanvas.shopNpc.addMoreTab(mVector3);
                GameCanvas.shopNpc.Show(GameScreen.gI());
                GameCanvas.end_Dialog();
                mainTabNew.init();
            }
            else if (b == 2)
            {
                short num2 = msg.reader().readShort();
                if (num2 == -1)
                {
                    TabRebuildItem.itemWing = null;
                    return;
                }
                Item itemInventory2 = Item.getItemInventory(3, num2);
                if (itemInventory2 != null && TabRebuildItem.isBeginEff == 0)
                {
                    TabRebuildItem.itemWing = MainItem.MainItem_Item(num2, itemInventory2.itemNameExcludeLv, itemInventory2.imageId, itemInventory2.tier, itemInventory2.colorNameItem, itemInventory2.classcharItem, 3, itemInventory2.mInfo, itemInventory2.type_Only_Item, isTem: false, itemInventory2.IdTem, itemInventory2.priceItem, (short)itemInventory2.LvItem, itemInventory2.canSell, itemInventory2.canTrade, 0, 0, 0);
                }
            }
            else if (b == 5)
            {
                GameCanvas.end_Dialog();
                TabRebuildItem.contentShow = msg.reader().readUTF();
                TabRebuildItem.idWingOk = msg.reader().readShort();
                TabRebuildItem.isBeginEff = 1;
            }
            else if (b == 4)
            {
                GameCanvas.end_Dialog();
                string name2 = msg.reader().readUTF();
                GameCanvas.menu2.startAt_NPC(null, name2, Menu2.IdNPCLast, 2, isQuest: false, 0);
            }
            else if (b == 6)
            {
                TabRebuildItem.itemWing = null;
                TabRebuildItem.dataWing = null;
                TabRebuildItem.priceWing = 0;
                TabRebuildItem.timeUseWing = 0;
                TabRebuildItem.nameWing = string.Empty;
                TabRebuildItem.isChetao = 0;
                TabRebuildItem.lvReWing = 0;
                TabRebuildItem.idWingOk = 0;
            }
        }
        catch (Exception)
        {
        }
    }

    public void Open_Box(Message msg)
    {
        try
        {
            string name = msg.reader().readUTF();
            int num = msg.reader().readByte();
            MainItem[] array = new MainItem[num];
            for (int i = 0; i < num; i++)
            {
                string name2 = msg.reader().readUTF();
                short idIcon = msg.reader().readShort();
                int numPo = msg.reader().readInt();
                sbyte item_potion = msg.reader().readByte();
                sbyte lvup = msg.reader().readByte();
                sbyte b = msg.reader().readByte();
                mSystem.outz("color=" + b);
                array[i] = new MainItem(name2, idIcon, numPo, item_potion, lvup, b);
            }
            string info = msg.reader().readUTF();
            sbyte typeOpen = msg.reader().readByte();
            sbyte isLottery = msg.reader().readByte();
            if (num != 0)
            {
                GameCanvas.start_Open_Box(name, info, array, typeOpen, isLottery);
            }
        }
        catch (Exception)
        {
        }
    }

    public void UpdateDataAndroid(Message msg)
    {
        try
        {
            GameCanvas.IndexCharPar = msg.reader().readShort();
            short maxupdate = msg.reader().readShort();
            GameCanvas.start_Update_Data();
            MsgDialog.curupdate = 0;
            MsgDialog.maxupdate = maxupdate;
        }
        catch (Exception)
        {
        }
    }

    public void SoSanhDataAndroid(Message msg)
    {
        try
        {
            GameCanvas.IndexCharPar = msg.reader().readShort();
            short num = msg.reader().readShort();
            int num2 = 0;
            for (int i = 0; i < num; i++)
            {
                sbyte b = msg.reader().readByte();
                short num3 = msg.reader().readShort();
                int num4 = msg.reader().readInt();
                sbyte[] array = null;
                try
                {
                    bool flag = false;
                    array = CRes.loadRMS("img_data_char_" + b + "_" + num3);
                    if (array == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        DataInputStream dataInputStream = new DataInputStream(array);
                        short num5 = dataInputStream.readShort();
                        if (num4 != num5)
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        GlobalService.gI().load_image_data_part_char(b, num3);
                        num2++;
                    }
                }
                catch (Exception)
                {
                }
            }
            if (num2 > 0)
            {
                GameCanvas.start_Update_Data();
                MsgDialog.curupdate = 0;
                MsgDialog.maxupdate = num2;
            }
            mSystem.outz("==========" + GameCanvas.IndexCharPar);
        }
        catch (Exception)
        {
        }
    }

    public void useMount(Message msg)
    {
        try
        {
            switch (msg.reader().readByte())
            {
                case 0:
                    {
                        sbyte typeMount = msg.reader().readByte();
                        short iD2 = msg.reader().readShort();
                        MainObject mainObject = MainObject.get_Object(iD2, 0);
                        if (mainObject != null)
                        {
                            mainObject.typeMount = typeMount;
                        }
                        break;
                    }
                case 1:
                    {
                        sbyte b = msg.reader().readByte();
                        sbyte b2 = msg.reader().readByte();
                        short iD = msg.reader().readShort();
                        short r = msg.reader().readShort();
                        MainObject.get_Object(iD, 1)?.setEffectauto(b2, r, b);
                        break;
                    }
            }
        }
        catch (Exception)
        {
        }
    }

    public void monsterSkillInfo(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            mSystem.outz("size = " + b);
            for (int i = 0; i < b; i++)
            {
                sbyte b2 = msg.reader().readByte();
                sbyte b3 = msg.reader().readByte();
                short num = msg.reader().readShort();
                Monster_Skill.hashMonsterSkillInfo.put(string.Empty + b2, num);
            }
        }
        catch (Exception)
        {
        }
    }

    public void monsterDetonate(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            sbyte tem = msg.reader().readByte();
            short num = msg.reader().readShort();
            short num2 = msg.reader().readShort();
            short num3 = msg.reader().readShort();
            sbyte b2 = msg.reader().readByte();
            sbyte b3 = msg.reader().readByte();
            sbyte b4 = msg.reader().readByte();
            sbyte b5 = msg.reader().readByte();
            sbyte b6 = msg.reader().readByte();
            sbyte b7 = msg.reader().readByte();
            MainMonster mainMonster = (MainMonster)MainObject.get_Object(num, tem);
            switch (b)
            {
                case 0:
                    mainMonster.vMax = 8;
                    mainMonster.toX = num2;
                    mainMonster.toY = num3;
                    mainMonster.isDetonateInDest = true;
                    break;
                case 1:
                    switch (b2)
                    {
                        case 0:
                            GameScreen.addEffectEndKill(38, mainMonster.x, mainMonster.y - 20);
                            break;
                        case 1:
                            GameScreen.addEffectKill(85, mainMonster.x, mainMonster.y, b3, num, tem);
                            break;
                        case 2:
                            GameScreen.addEffectKill(87, mainMonster.x, mainMonster.y, b3, num, tem);
                            break;
                        case 3:
                            GameScreen.addEffectEndKill(36, mainMonster.x, mainMonster.y);
                            break;
                    }
                    mainMonster.x = num2;
                    mainMonster.y = num3;
                    switch (b4)
                    {
                        case 0:
                            GameScreen.addEffectEndKill(38, mainMonster.x, mainMonster.y - 20);
                            break;
                        case 1:
                            GameScreen.addEffectKill(85, mainMonster.x, mainMonster.y, b5, num, tem);
                            break;
                        case 2:
                            GameScreen.addEffectKill(87, mainMonster.x, mainMonster.y, b5, num, tem);
                            break;
                        case 3:
                            mainMonster.isDetonateInDest = true;
                            break;
                    }
                    break;
            }
        }
        catch (Exception)
        {
        }
    }

    public void petGainXP(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            short num2 = msg.reader().readShort();
            short num3 = msg.reader().readShort();
            int num4 = msg.reader().readInt();
        }
        catch (Exception)
        {
        }
    }

    public void receiveLotteryReward(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                Item.VecLotteryReward.removeAllElements();
                sbyte b2 = msg.reader().readByte();
                for (int i = 0; i < b2; i++)
                {
                    sbyte b3 = msg.reader().readByte();
                    if (b3 == 3)
                    {
                        string itemName = msg.reader().readUTF();
                        sbyte b4 = msg.reader().readByte();
                        short iD = msg.reader().readShort();
                        sbyte b5 = msg.reader().readByte();
                        short imageId = msg.reader().readShort();
                        sbyte tier = msg.reader().readByte();
                        short level = msg.reader().readShort();
                        sbyte b6 = msg.reader().readByte();
                        sbyte b7 = msg.reader().readByte();
                        MainInfoItem[] array = new MainInfoItem[b7];
                        for (int j = 0; j < b7; j++)
                        {
                            sbyte b8 = msg.reader().readByte();
                            int value = msg.reader().readInt();
                            array[j] = new MainInfoItem(b8, value);
                        }
                        MainItem o = new MainItem(iD, itemName, imageId, tier, b6, b4, b3, array, b5, isTem: false, -1, 0L, level, 0, 0, -1, 0, 0);
                        Item.VecLotteryReward.addElement(o);
                    }
                    else if (b3 == 4)
                    {
                        short num = msg.reader().readShort();
                        short numPotion = msg.reader().readShort();
                        MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num);
                        MainItem o2 = new MainItem(num, mainTemplateItem.IconId, mainTemplateItem.name, mainTemplateItem.contentPotion, numPotion, 4, mainTemplateItem.PricePoition, mainTemplateItem.typePotion, mainTemplateItem.moneyType, 0, 0);
                        Item.VecLotteryReward.addElement(o2);
                    }
                    else if (b3 == 7)
                    {
                        short num2 = msg.reader().readShort();
                        short num3 = msg.reader().readShort();
                        MainItem material = Item.getMaterial(num2);
                        if (material != null)
                        {
                            MainItem o3 = MainItem.MainItem_Material(num2, material.itemName, material.imageId, 7, material.priceItem, material.priceType, material.content, material.value, material.typeMaterial, num3, 0, 0);
                            Item.VecLotteryReward.addElement(o3);
                            continue;
                        }
                        MainItem mainItem = new MainItem();
                        mainItem.Id = num2;
                        mainItem.ItemCatagory = 7;
                        mainItem.numPotion = num3;
                        Item.VecLotteryReward.addElement(mainItem);
                    }
                }
                mVector mVector3 = new mVector("ReadMessenge vec13");
                MainTabNew o4 = new TabLottery(T.moly, Item.VecLotteryReward, 0);
                mVector3.addElement(o4);
                GameCanvas.shopNpc = new TabScreenNew();
                GameCanvas.shopNpc.selectTab = 0;
                GameCanvas.shopNpc.addMoreTab(mVector3);
                GameCanvas.shopNpc.Show(GameScreen.gI());
                GameCanvas.end_Dialog();
            }
            else if (b == 1)
            {
                sbyte b9 = msg.reader().readByte();
                sbyte b10 = msg.reader().readByte();
                TabLottery.changeSection(1);
                TabLottery.setLuckyNumber(b10);
                TabLottery.isReady = false;
                mSystem.outz("itemIndex = " + b9);
                mSystem.outz("posIndex = " + b10);
            }
            else if (b == 2)
            {
                sbyte b11 = msg.reader().readByte();
                if (b11 == 1)
                {
                    mSystem.outz("Trung ------------");
                    sbyte b12 = msg.reader().readByte();
                    sbyte luckyNumber = msg.reader().readByte();
                    TabLottery.setLuckyNumber(luckyNumber);
                    TabLottery.isWin = true;
                }
                else
                {
                    mSystem.outz("Ko Trung ------------");
                    sbyte b13 = msg.reader().readByte();
                    mSystem.outz("luckyNumber ------------ " + b13);
                    sbyte b14 = msg.reader().readByte();
                    TabLottery.setLuckyNumber(b13);
                    TabLottery.isWin = false;
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void writeUserAccountInfoToRMS(Message msg)
    {
        try
        {
            string text = msg.reader().readUTF();
            string text2 = msg.reader().readUTF();
            DataOutputStream dataOutputStream = new DataOutputStream();
            dataOutputStream.writeUTF(text);
            dataOutputStream.writeUTF(text2);
            CRes.saveRMS("user_pass", dataOutputStream.toByteArray());
            dataOutputStream.close();
            LoginScreen.userSv = text;
            LoginScreen.tfusername.setText(text);
            LoginScreen.tfpassword.setText(text2);
            LoginScreen.username = text;
            LoginScreen.password = text2;
        }
        catch (Exception)
        {
        }
    }

    public void UpdateInfoArena(Message msg)
    {
        try
        {
            sbyte type = msg.reader().readByte();
            sbyte totalHouse = msg.reader().readByte();
            short totalPlayer = msg.reader().readShort();
            sbyte b = msg.reader().readByte();
            GameScreen.infoGame.setSttArena(type, totalHouse, totalPlayer);
            if (b == 0)
            {
                long timeArena = msg.reader().readLong();
                GameScreen.timeArena = timeArena;
            }
        }
        catch (Exception)
        {
        }
    }

    public void updateMarkKiller(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                short iD = msg.reader().readShort();
                short markKiller = msg.reader().readShort();
                MainObject mainObject = MainObject.get_Object(iD, 0);
                if (mainObject != null)
                {
                    mainObject.markKiller = markKiller;
                }
            }
            else if (b == 1)
            {
                ItemMap.isPaintDieHouseArena = true;
            }
            else if (b == 2)
            {
                short iD2 = msg.reader().readShort();
                sbyte b2 = msg.reader().readByte();
                MainObject mainObject2 = MainObject.get_Object(iD2, 1);
                if (mainObject2 != null && b2 != 0)
                {
                    mainObject2.addeffAuto(b2, mainObject2.x, mainObject2.y, 0, 0, (b2 == 57) ? 2 : 0, 0);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void useItemArena(Message msg)
    {
        try
        {
            switch (msg.reader().readByte())
            {
                case 0:
                    {
                        sbyte b2 = msg.reader().readByte();
                        if (b2 == 1)
                        {
                            EffectMonster.buffDame = true;
                        }
                        else
                        {
                            EffectMonster.buffDame = false;
                        }
                        break;
                    }
                case 1:
                    {
                        short idImageHenshin = msg.reader().readShort();
                        short iD2 = msg.reader().readShort();
                        MainObject mainObject2 = MainObject.get_Object(iD2, 0);
                        if (mainObject2 != null)
                        {
                            mainObject2.idImageHenshin = idImageHenshin;
                        }
                        break;
                    }
                case 2:
                    {
                        sbyte b = msg.reader().readByte();
                        short iD = msg.reader().readShort();
                        MainObject mainObject = MainObject.get_Object(iD, 0);
                        if (mainObject != null)
                        {
                            if (b == 1)
                            {
                                mainObject.isPaint_No = true;
                            }
                            else
                            {
                                mainObject.isPaint_No = false;
                            }
                        }
                        break;
                    }
            }
        }
        catch (Exception)
        {
        }
    }

    public void npcServer(Message msg)
    {
        try
        {
            short xNPC = msg.reader().readShort();
            short yNPC = msg.reader().readShort();
            short xBlockNPC = msg.reader().readShort();
            short yBlockNPC = msg.reader().readShort();
            sbyte wBlockNPC = msg.reader().readByte();
            sbyte hBlockNPC = msg.reader().readByte();
            sbyte dxNPC = msg.reader().readByte();
            sbyte dyNPC = msg.reader().readByte();
            sbyte nFrameNPC = msg.reader().readByte();
            string nameGiaoTiep = msg.reader().readUTF();
            string nameNPC = msg.reader().readUTF();
            sbyte idNPC = msg.reader().readByte();
            sbyte b = msg.reader().readByte();
            sbyte[] array = new sbyte[b];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (sbyte)msg.reader().readShort();
            }
            short num = msg.reader().readShort();
            sbyte[] array2 = new sbyte[num];
            for (int j = 0; j < array2.Length; j++)
            {
                array2[j] = msg.reader().readByte();
            }
            sbyte b2 = msg.reader().readByte();
            sbyte[] array3 = new sbyte[b2];
            for (int k = 0; k < array3.Length; k++)
            {
                array3[k] = msg.reader().readByte();
            }
            sbyte b3 = msg.reader().readByte();
            for (int l = 0; l < GameScreen.Vecplayers.size(); l++)
            {
                MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(l);
                if (mainObject.isNPC_server() && mainObject.ID == b3)
                {
                    mainObject.setInfo(idNPC, xNPC, yNPC, dxNPC, dyNPC, nFrameNPC, nameGiaoTiep, nameNPC, xBlockNPC, yBlockNPC, wBlockNPC, hBlockNPC, array, array2, array3);
                    return;
                }
            }
            NPCserver nPCserver = new NPCserver(idNPC, xNPC, yNPC, dxNPC, dyNPC, nFrameNPC, nameGiaoTiep, nameNPC, xBlockNPC, yBlockNPC, wBlockNPC, hBlockNPC, array, array2, array3);
            nPCserver.ID = b3;
            GameScreen.Vecplayers.addElement(nPCserver);
        }
        catch (Exception)
        {
        }
    }

    public void useShip(Message msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            short shipScr = msg.reader().readShort();
            GameScreen.player.useShip = true;
            if (b == 0)
            {
                GameScreen.infoGame.isShipMove = true;
                ShipScr.gI().setShipScr(shipScr);
            }
            else if (b == 2)
            {
                ShipScr.gI().isSpeed = true;
            }
        }
        catch (Exception)
        {
        }
    }

    public void ThachDau(Message msg)
    {
        try
        {
            switch (msg.reader().readByte())
            {
                case 0:
                    {
                        short iD = msg.reader().readShort();
                        int mp = msg.reader().readInt();
                        int maxMp = msg.reader().readInt();
                        MainObject mainObject = MainObject.get_Object(iD, 0);
                        if (mainObject != null)
                        {
                            mainObject.mp = mp;
                            mainObject.maxMp = maxMp;
                        }
                        break;
                    }
                case 1:
                    {
                        sbyte b = msg.reader().readByte();
                        PaintInfoGameScreen.timeThachdau = mSystem.currentTimeMillis() / 1000 + b;
                        break;
                    }
            }
        }
        catch (Exception)
        {
        }
    }

    public void StoreInfo(Message msg)
    {
        try
        {
            switch (msg.reader().readByte())
            {
                case 1:
                    {
                        short id2 = msg.reader().readShort();
                        string nameStore = msg.reader().readUTF();
                        GameScreen.findChar(id2)?.setNameStore(nameStore);
                        break;
                    }
                case 2:
                    {
                        short num6 = msg.reader().readShort();
                        MainObject mainObject = GameScreen.findChar(num6);
                        if (GameScreen.player != null && num6 == GameScreen.player.ID)
                        {
                            Item.VecItem_Sell_in_store.removeAllElements();
                            Item.VecItemSell.removeAllElements();
                        }
                        mainObject?.removeNameStore();
                        break;
                    }
                case 3:
                    {
                        Item.VecItemSell.removeAllElements();
                        sbyte b = msg.reader().readByte();
                        for (int i = 0; i < b; i++)
                        {
                            sbyte b2 = msg.reader().readByte();
                            if (b2 == 3)
                            {
                                short num = msg.reader().readShort();
                                string itemName = msg.reader().readUTF();
                                sbyte b3 = msg.reader().readByte();
                                sbyte b4 = msg.reader().readByte();
                                short imageId = msg.reader().readShort();
                                sbyte plusItem = msg.reader().readByte();
                                short lvItem = msg.reader().readShort();
                                sbyte b5 = msg.reader().readByte();
                                sbyte b6 = msg.reader().readByte();
                                MainInfoItem[] array = new MainInfoItem[b6];
                                for (int j = 0; j < b6; j++)
                                {
                                    sbyte b7 = msg.reader().readByte();
                                    int value = msg.reader().readInt();
                                    array[j] = new MainInfoItem(b7, value);
                                }
                                sbyte typeMoney = msg.reader().readByte();
                                MainItem mainItem = MainItem.MainItem_Item(num, itemName, imageId, plusItem, b5, b3, 3, array, b4, isTem: false, num, 0L, lvItem, 0, 0, 0, typeMoney, 0);
                                mainItem.isSell = true;
                                Item.VecItemSell.addElement(mainItem);
                            }
                            if (b2 == 7)
                            {
                                short num2 = msg.reader().readShort();
                                short num3 = msg.reader().readShort();
                                sbyte b8 = msg.reader().readByte();
                                sbyte b9 = msg.reader().readByte();
                                long num4 = msg.reader().readLong();
                                MainItem material = Item.getMaterial(num2);
                                if (material != null)
                                {
                                    MainItem mainItem2 = MainItem.MainItem_Material(num2, material.itemName, material.imageId, 7, num4, 0, material.content, material.value, material.typeMaterial, num3, b8, b9);
                                    mainItem2.isSell = true;
                                    Item.VecItemSell.addElement(mainItem2);
                                }
                                else
                                {
                                    MainItem mainItem3 = new MainItem();
                                    mainItem3.Id = num2;
                                    mainItem3.numPotion = num3;
                                    mainItem3.canSell = b8;
                                    mainItem3.canTrade = b9;
                                    mainItem3.priceItem = num4;
                                    mainItem3.priceType = 0;
                                    mainItem3.isSell = true;
                                    mainItem3.ItemCatagory = 7;
                                    Item.put_Material(num2);
                                    Item.VecItemSell.addElement(mainItem3);
                                }
                            }
                            if (b2 == 4)
                            {
                                short id = msg.reader().readShort();
                                short numPotion = msg.reader().readShort();
                                long num5 = msg.reader().readInt();
                                MainTemplateItem potionTem = MainTemplateItem.getPotionTem(id);
                                if (potionTem != null)
                                {
                                    MainItem o = new MainItem(potionTem.ID, potionTem.IconId, potionTem.name, potionTem.contentPotion + ". " + T.price + " " + MainItem.getDotNumber(num5) + " " + T.coin, numPotion, 4, num5, potionTem.typePotion, potionTem.moneyType, 0, 0);
                                    Item.VecItemSell.addElement(o);
                                }
                            }
                        }
                        break;
                    }
            }
        }
        catch (Exception)
        {
        }
    }

    public void MiNuongInfo(Message msg)
    {
        try
        {
            switch (msg.reader().readByte())
            {
                case 0:
                    {
                        short id3 = msg.reader().readShort();
                        string name = msg.reader().readUTF();
                        GameScreen.findMonster(id3)?.SetnameOwner(name);
                        break;
                    }
                case 1:
                    {
                        short idCharLoiDai = msg.reader().readShort();
                        short idCharLoiDai2 = msg.reader().readShort();
                        GameScreen.infoGame.idCharLoiDai1 = idCharLoiDai;
                        GameScreen.infoGame.idCharLoiDai2 = idCharLoiDai2;
                        break;
                    }
                case 2:
                    {
                        short id = msg.reader().readShort();
                        short effect = msg.reader().readShort();
                        short effTail = msg.reader().readShort();
                        short effEnd = msg.reader().readShort();
                        sbyte b = msg.reader().readByte();
                        MainObject mainObject = GameScreen.findObj(id);
                        if (mainObject == null)
                        {
                            break;
                        }
                        for (int i = 0; i < b; i++)
                        {
                            short id2 = msg.reader().readShort();
                            int power = msg.reader().readInt();
                            MainObject mainObject2 = GameScreen.findObj(id2);
                            if (mainObject2 != null)
                            {
                                GameScreen.startNewMagicBeam(15, mainObject, mainObject2, mainObject.x, mainObject.y, power, effect, effTail, effEnd);
                            }
                        }
                        break;
                    }
            }
        }
        catch (Exception)
        {
        }
    }

    public void infoclanChiemthanh(Message msg)
    {
        try
        {
            switch (msg.reader().readByte())
            {
                case 0:
                    {
                        int idicon = msg.reader().readInt();
                        string nameclan = msg.reader().readUTF();
                        PaintInfoGameScreen.idicon = idicon;
                        PaintInfoGameScreen.nameclan = nameclan;
                        break;
                    }
                case 1:
                    {
                        GameScreen.vecTimecountDown.removeAllElements();
                        sbyte b = msg.reader().readByte();
                        for (int j = 0; j < b; j++)
                        {
                            short num2 = msg.reader().readShort();
                            string tile = msg.reader().readUTF();
                            if (num2 > 0)
                            {
                                TimecountDown o = new TimecountDown(num2, tile, GameCanvas.w / 2, GameCanvas.hText + 10 + j * GameCanvas.hText);
                                GameScreen.vecTimecountDown.addElement(o);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        int num = msg.reader().readByte();
                        if (num > 0)
                        {
                            GameScreen.textServer = new string[num];
                            for (int i = 0; i < num; i++)
                            {
                                GameScreen.textServer[i] = msg.reader().readUTF();
                            }
                        }
                        else
                        {
                            GameScreen.textServer = null;
                        }
                        break;
                    }
            }
        }
        catch (Exception)
        {
        }
    }

    public void onHopRac(Message msg)
    {
        try
        {
            switch (msg.reader().readByte())
            {
                case 0:
                    {
                        TabRebuildItem.vecGem.removeAllElements();
                        sbyte b10 = msg.reader().readByte();
                        short id = msg.reader().readShort();
                        for (int k = 0; k < b10; k++)
                        {
                            MainItem material3 = Item.getMaterial(id);
                            if (material3 != null)
                            {
                                TabRebuildItem.vecGem.addElement(material3);
                                continue;
                            }
                            MainItem mainItem3 = new MainItem();
                            mainItem3.Id = id;
                            TabRebuildItem.itemRe.ItemCatagory = 7;
                            TabRebuildItem.vecGem.addElement(mainItem3);
                        }
                        break;
                    }
                case 1:
                    TabRebuildItem.vecGem.removeAllElements();
                    break;
                case 2:
                    {
                        GameCanvas.end_Dialog();
                        TabRebuildItem.isBeginEff = 1;
                        TabRebuildItem.isNextRebuild = msg.reader().readByte();
                        TabRebuildItem.contentShow = msg.reader().readUTF();
                        TabRebuildItem.vecGem.removeAllElements();
                        short num4 = msg.reader().readShort();
                        sbyte b2 = msg.reader().readByte();
                        if (num4 != -1 && b2 == 7)
                        {
                            MainItem material2 = Item.getMaterial(num4);
                            if (material2 != null)
                            {
                                TabRebuildItem.itemRe = material2;
                                break;
                            }
                            TabRebuildItem.itemRe = new MainItem();
                            TabRebuildItem.itemRe.Id = num4;
                            TabRebuildItem.itemRe.ItemCatagory = 7;
                        }
                        break;
                    }
                case 3:
                    GameCanvas.end_Dialog();
                    TabRebuildItem.isBeginEff = 1;
                    TabRebuildItem.itemRe = null;
                    TabRebuildItem.isNextRebuild = msg.reader().readByte();
                    TabRebuildItem.contentShow = msg.reader().readUTF();
                    TabRebuildItem.vecGem.removeAllElements();
                    if (TabRebuildItem.isNextRebuild == 3)
                    {
                        sbyte b3 = msg.reader().readByte();
                        string itemName = msg.reader().readUTF();
                        sbyte b4 = msg.reader().readByte();
                        short iD2 = msg.reader().readShort();
                        sbyte b5 = msg.reader().readByte();
                        short imageId = msg.reader().readShort();
                        sbyte tier = msg.reader().readByte();
                        short level = msg.reader().readShort();
                        sbyte b6 = msg.reader().readByte();
                        sbyte canSell = msg.reader().readByte();
                        sbyte canTrade = msg.reader().readByte();
                        sbyte b7 = msg.reader().readByte();
                        MainInfoItem[] array = new MainInfoItem[b7];
                        for (int j = 0; j < b7; j++)
                        {
                            sbyte b8 = msg.reader().readByte();
                            int value = msg.reader().readInt();
                            array[j] = new MainInfoItem(b8, value);
                        }
                        int timeUse = msg.reader().readInt();
                        sbyte isLock = msg.reader().readByte();
                        sbyte b9 = msg.reader().readByte();
                        int timeDefault = -1;
                        string s = "-1";
                        if (b9 == 1)
                        {
                            timeDefault = msg.reader().readInt();
                            s = msg.reader().readUTF();
                        }
                        sbyte canShell_notCanTrade = msg.reader().readByte();
                        MainItem mainItem2 = null;
                        mainItem2 = new MainItem(iD2, itemName, imageId, tier, b6, b4, b3, array, b5, isTem: false, -1, 0L, level, canSell, canTrade, timeUse, 0, isLock, timeDefault, long.Parse(s));
                        mainItem2.setCanShell_notCanTrade(canShell_notCanTrade);
                        TabRebuildItem.itemRe = mainItem2;
                    }
                    break;
                case 4:
                    {
                        int num = msg.reader().readByte();
                        TabRebuildItem.vecGem.removeAllElements();
                        for (int i = 0; i < num; i++)
                        {
                            short num2 = msg.reader().readShort();
                            short num3 = msg.reader().readShort();
                            sbyte b = 7;
                            if (num2 != -1 && b == 7)
                            {
                                TabRebuildItem.numColor[i] = getColorNum(num2, num3);
                                TabRebuildItem.numofGem[i] = getInfoNum(num2, num3);
                                MainItem material = Item.getMaterial(num2);
                                if (material != null)
                                {
                                    TabRebuildItem.vecGem.addElement(material);
                                    continue;
                                }
                                MainItem mainItem = new MainItem();
                                mainItem.Id = num2;
                                mainItem.ItemCatagory = 7;
                                TabRebuildItem.vecGem.addElement(mainItem);
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        GameCanvas.end_Dialog();
                        TabRebuildItem.isBeginEff = 1;
                        TabRebuildItem.itemRe = null;
                        TabRebuildItem.isNextRebuild = msg.reader().readByte();
                        TabRebuildItem.contentShow = msg.reader().readUTF();
                        TabRebuildItem.vecGem.removeAllElements();
                        short iD = msg.reader().readShort();
                        Item itemInventory = Item.getItemInventory(3, iD);
                        if (itemInventory != null)
                        {
                            TabRebuildItem.itemRe = MainItem.MainItem_Item(iD, itemInventory.itemNameExcludeLv, itemInventory.imageId, itemInventory.tier, itemInventory.colorNameItem, itemInventory.classcharItem, 3, itemInventory.mInfo, itemInventory.type_Only_Item, isTem: false, itemInventory.IdTem, itemInventory.priceItem, (short)itemInventory.LvItem, itemInventory.canSell, itemInventory.canTrade, 0, 0, 0);
                        }
                        break;
                    }
            }
        }
        catch (Exception)
        {
        }
    }

    public void Material_Template(Message msg)
    {
        try
        {
            short num = msg.reader().readShort();
            short imageId = msg.reader().readShort();
            long price = msg.reader().readLong();
            string itemName = msg.reader().readUTF();
            string content = msg.reader().readUTF();
            sbyte typeitem = msg.reader().readByte();
            sbyte priceType = msg.reader().readByte();
            sbyte sell = msg.reader().readByte();
            short value = msg.reader().readShort();
            sbyte trade = msg.reader().readByte();
            sbyte b = msg.reader().readByte();
            MainItem mainItem = (MainItem)MainTemplateItem.hashMaterialTem.get(num + string.Empty);
            if (mainItem != null)
            {
                mainItem.setinfo(num, itemName, imageId, 7, price, priceType, content, value, typeitem, 1, sell, trade);
                mainItem.setColorName(b);
            }
            for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
            {
                MainItem mainItem2 = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
                if (mainItem2 != null && mainItem2.ItemCatagory == 7 && mainItem2.Id == num)
                {
                    mainItem2.setinfo(num, itemName, imageId, 7, price, priceType, content, value, typeitem, 1, sell, trade);
                    mainItem2.setColorName(b);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void onFillRec_Time(Message msg)
    {
        GlobalService.isChanger = true;

        try
        {
            // case 2 : item drop || case 3 : combo || case 4 : time combo || case 5 : continue fire || case 7 : eff || case 8 : eff || case 6 : eff
            sbyte type = msg.reader().readByte();
            Debug.LogError("onFillRec_Time type : " + type);
            switch (type)
            {
                case 0:
                    GameCanvas.game.isFullScreen = false;
                    GameCanvas.game.colorRec = msg.reader().readInt();
                    GameCanvas.game.xRec = msg.reader().readShort();
                    GameCanvas.game.yRec = msg.reader().readShort();
                    GameCanvas.game.wRec = msg.reader().readShort();
                    GameCanvas.game.hRec = msg.reader().readShort();
                    break;
                case 1:
                    GameCanvas.game.colorRec = msg.reader().readInt();
                    GameCanvas.game.isFullScreen = true;
                    break;
                case 2:
                    {
                        sbyte b2 = msg.reader().readByte();
                        short idIcon = msg.reader().readShort();
                        short iD = msg.reader().readShort();
                        string name = msg.reader().readUTF();
                        sbyte b3 = 0;
                        if (b2 == 3 || b2 == 4 || b2 == 7)
                        {
                            b3 = msg.reader().readByte();
                        }
                        short x = msg.reader().readShort();
                        short y = msg.reader().readShort();
                        Item_Drop obj = new Item_Drop(iD, b2, name, x, y, idIcon, b3);
                        GameScreen.addPlayer(obj);
                        break;
                    }
                case 3:
                    {
                        int num = msg.reader().readInt();
                        Debug.LogError("num : " + num);
                        GameCanvas.game.imgCombo = null;
                        if (num > 0)
                        {
                            sbyte[] array = new sbyte[num];
                            if (num > 0)
                            {
                                for (int i = 0; i < num; i++)
                                {
                                    array[i] = msg.reader().readByte();
                                }
                                GameCanvas.game.imgCombo = mImage.createImage(array, 0, array.Length, string.Empty);
                                GameCanvas.game.isCombo = true;
                            }
                        }
                        else
                        {
                            GameCanvas.game.imgCombo = null;
                            GameScreen.player.timeCombo = -1;
                        }
                        break;
                    }
                case 4:
                    GameScreen.player.resetCoolDown();
                    GameScreen.player.timeCombo = msg.reader().readInt();
                    break;
                case 5:
                    {
                        sbyte b4 = msg.reader().readByte();
                        if (b4 == 1)
                        {
                            onContinueFire();
                        }
                        break;
                    }
                case 7:
                    {
                        short ideff2 = msg.reader().readShort();
                        short x2 = msg.reader().readShort();
                        short y2 = msg.reader().readShort();
                        DataSkillEff o3 = new DataSkillEff(ideff2, x2, y2, null);
                        GameScreen.vecDataeff.addElement(o3);
                        break;
                    }
                case 8:
                    {
                        short ideff = msg.reader().readShort();
                        sbyte b = msg.reader().readByte();
                        short id = msg.reader().readShort();
                        if (b == 0)
                        {
                            MainObject mainObject = GameScreen.findChar(id);
                            if (mainObject != null)
                            {
                                DataSkillEff o = new DataSkillEff(ideff, mainObject.x, mainObject.y, null);
                                GameScreen.vecDataeff.addElement(o);
                            }
                        }
                        else
                        {
                            MainObject mainObject2 = GameScreen.findMonster(id);
                            if (mainObject2 != null)
                            {
                                DataSkillEff o2 = new DataSkillEff(ideff, mainObject2.x, mainObject2.y, null);
                                GameScreen.vecDataeff.addElement(o2);
                            }
                        }
                        break;
                    }
                case 6:
                    break;
            }
        }
        catch (Exception)
        {
        }
    }

    public void onUpSkill(Message msg)
    {
        try
        {
        }
        catch (Exception)
        {
        }
    }

    public void onContinueFire()
    {
        try
        {
            GameScreen.ObjFocus = null;
            GameScreen.player.nextMonster();
            GameScreen.player.dofire_();
        }
        catch (Exception)
        {
        }
    }
}
