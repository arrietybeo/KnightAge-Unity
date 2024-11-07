using System.Diagnostics;
using System.IO;
public class GlobalMessageHandler : Cmd_Message, IMessageHandler
{
    public GlobalLogicHandler globalLogicHandler = new GlobalLogicHandler();

    public static GlobalMessageHandler me;

    public IMiniGameMsgHandler miniGameMessageHandler;

    public static GlobalMessageHandler gI()
    {
        if (me == null)
        {
            me = new GlobalMessageHandler();
        }
        return me;
    }

    public void setGameLogicHandler(GlobalLogicHandler gI)
    {
        globalLogicHandler = gI;
    }

    public void onConnectOK()
    {
        globalLogicHandler.onConnectOK();
    }

    public void onConnectionFail()
    {
        globalLogicHandler.onConnectFail();
    }

    public void onDisconnected()
    {
        GlobalLogicHandler.onDisconnect();
    }

    public void onMessage(Message msg)
    {
        //string filePath = "G://KnightAge//msg.txt";
        //using (StreamWriter writer = new StreamWriter(filePath, true))
        //{
        //    writer.WriteLine("onMessage msg: [" + msg.command + "]");
        //}

        switch (msg.command)
        {
            case -96:
                GameCanvas.readMessenge.npcServer(msg);
                break;
            case -92:
                GameCanvas.readMessenge.useItemArena(msg);
                break;
            case -95:
                GameCanvas.readMessenge.updateMarkKiller(msg);
                break;
            case -94:
                GameCanvas.readMessenge.UpdateInfoArena(msg);
                break;
            case -93:
                Main.main.ClearTransaction();
                break;
            case -91:
                GameCanvas.readMessenge.receiveLotteryReward(msg);
                break;
            case -76:
                TemMidlet.handleMessage(msg);
                break;
            case -75:
                TemMidlet.handleMessage(msg);
                break;
            case -57:
                GameCanvas.readMessenge.UpdateDataAndroid(msg);
                break;
            case -54:
                GameCanvas.readMessenge.SoSanhDataAndroid(msg);
                break;
            case -53:
                GameCanvas.readMessenge.nap_tien(msg);
                break;
            case -52:
                GameCanvas.readMessenge.loadImageDataCharPart(msg);
                break;
            case -51:
                GameCanvas.readMessenge.loadImage(msg);
                break;
            case -49:
                GameCanvas.readMessenge.loadImageDataAutoEff(msg);
                break;
            case -44:
                GameCanvas.readMessenge.newNPCInfo(msg);
                break;
            case -100:
                GameCanvas.readMessenge.khamNgoc(msg);
                break;
            case 1:
                GameCanvas.readMessenge.Login_Ok(msg);
                break;
            case -99:
                GameCanvas.readMessenge.lastlogout(msg);
                break;
            case 2:
                GameCanvas.readMessenge.Login_Fail(msg);
                break;
            case 3:
                GameCanvas.readMessenge.mainCharInfo(msg);
                break;
            case 4:
                GameCanvas.readMessenge.objectMove(msg);
                break;
            case 5:
                GameCanvas.readMessenge.charInfo(msg);
                break;
            case 7:
                GameCanvas.readMessenge.monsterInfo(msg);
                break;
            case 8:
                GameCanvas.readMessenge.playerExit(msg);
                break;
            case 12:
                GameCanvas.readMessenge.changeMap(msg);
                break;
            case 37:
                GameCanvas.readMessenge.InfoServer_Download(msg);
                break;
            case 9:
                GameCanvas.readMessenge.fireMonster(msg);
                break;
            case 15:
                GameCanvas.readMessenge.charWearing(msg);
                break;
            case 17:
                GameCanvas.readMessenge.dieMonster(msg);
                break;
            case 10:
                GameCanvas.readMessenge.monsterFire(msg);
                break;
            case 16:
                GameCanvas.readMessenge.charInventory(msg);
                break;
            case 19:
                GameCanvas.readMessenge.ItemDrop(msg);
                break;
            case 20:
                GameCanvas.readMessenge.GetItemMap(msg);
                break;
            case 23:
                GameCanvas.readMessenge.npcInfo(msg);
                break;
            case 25:
                GameCanvas.readMessenge.itemTemplate(msg);
                break;
            case 26:
                GameCanvas.readMessenge.catalogyMonster(msg);
                break;
            case 13:
                GameCanvas.readMessenge.listChar(msg);
                break;
            case -50:
                GameCanvas.readMessenge.npcBig(msg);
                break;
            case 52:
                GameCanvas.readMessenge.onReceiveInfoQuest(msg);
                break;
            case -31:
                GameCanvas.readMessenge.Dialog_More_server(msg);
                break;
            case -32:
                GameCanvas.readMessenge.Dialog_server(msg);
                break;
            case -30:
                GameCanvas.readMessenge.Dynamic_Menu(msg);
                break;
            case 21:
                GameCanvas.readMessenge.Item_More_Info(msg);
                break;
            case 28:
                GameCanvas.readMessenge.get_Item_Tem(msg);
                break;
            case 29:
                GameCanvas.readMessenge.Skill_List(msg);
                break;
            case 30:
                GameCanvas.readMessenge.Set_XP(msg);
                break;
            case 31:
                GameCanvas.readMessenge.writeUserAccountInfoToRMS(msg);
                break;
            case 33:
                GameCanvas.readMessenge.Level_Up(msg);
                break;
            case 32:
                GameCanvas.readMessenge.use_Potion(msg);
                break;
            case 27:
                GameCanvas.readMessenge.chatPopup(msg);
                break;
            case 34:
                GameCanvas.readMessenge.chatTab(msg);
                break;
            case 35:
                GameCanvas.readMessenge.Friend(msg);
                break;
            case 39:
                GameCanvas.readMessenge.Register(msg);
                break;
            case 48:
                GameCanvas.readMessenge.Party(msg);
                break;
            case 36:
                GameCanvas.readMessenge.Buy_Sell(msg);
                break;
            case 40:
                GameCanvas.readMessenge.Buff(msg);
                break;
            case 6:
                GameCanvas.readMessenge.firePK(msg);
                break;
            case 41:
                GameCanvas.readMessenge.diePlayer(msg);
                break;
            case 42:
                GameCanvas.readMessenge.pk(msg);
                break;
            case 49:
                GameCanvas.readMessenge.other_player_info(msg);
                break;
            case 50:
                GameCanvas.readMessenge.eff_plus_time(msg);
                break;
            case 51:
                GameCanvas.readMessenge.changeArea(msg);
                break;
            case 53:
                GameCanvas.readMessenge.InfoEasyFromServer(msg);
                break;
            case 54:
                GameCanvas.readMessenge.update_Status_Area(msg);
                break;
            case 55:
                GameCanvas.readMessenge.Save_RMS_Server(msg);
                break;
            case 56:
                GameCanvas.readMessenge.List_Serverz(msg);
                break;
            case 57:
                GameCanvas.readMessenge.List_Pk(msg);
                break;
            case 59:
                GameCanvas.readMessenge.suckhoe(msg);
                break;
            case 60:
                GameCanvas.readMessenge.chat_npc(msg);
                break;
            case 61:
                GameCanvas.readMessenge.name_server(msg);
                break;
            case 62:
                GameCanvas.readMessenge.x2_Xp(msg);
                break;
            case 63:
                GameCanvas.readMessenge.delete_rms(msg);
                break;
            case 64:
                GameCanvas.readMessenge.Help_From_Server(msg);
                break;
            case 65:
                GameCanvas.readMessenge.CharChest(msg);
                break;
            case 67:
                GameCanvas.readMessenge.Rebuild_Item(msg);
                break;
            case 73:
                GameCanvas.readMessenge.ReplacePlusItem(msg);
                break;
            case 68:
                GameCanvas.readMessenge.Thach_Dau(msg);
                break;
            case 69:
                GameCanvas.readMessenge.Clan(msg);
                break;
            case 70:
                GameCanvas.readMessenge.updateHpNPC(msg);
                break;
            case 74:
                GameCanvas.readMessenge.Num_Eff(msg);
                break;
            case 75:
                GameCanvas.readMessenge.EffFormServer(msg);
                break;
            case 76:
                GameCanvas.readMessenge.EffWeather(msg);
                break;
            case 77:
                GameCanvas.readMessenge.Rebuild_Wing(msg);
                break;
            case 78:
                GameCanvas.readMessenge.Open_Box(msg);
                break;
            case -90:
            case 90:
                GameCanvas.readMessenge.remove_Actor(msg);
                break;
            case 44:
                GameCanvas.readMessenge.UpdatePetContainer(msg);
                break;
            case 84:
                GameCanvas.readMessenge.petAttack(msg);
                break;
            case 85:
                GameCanvas.readMessenge.monsterDetonate(msg);
                break;
            case 86:
                GameCanvas.readMessenge.monsterSkillInfo(msg);
                break;
            case -97:
                GameCanvas.readMessenge.useMount(msg);
                break;
            case -98:
                GameCanvas.readMessenge.useShip(msg);
                break;
            case -101:
                GameCanvas.readMessenge.ThachDau(msg);
                break;
            case -102:
                GameCanvas.readMessenge.StoreInfo(msg);
                break;
            case -103:
                GameCanvas.readMessenge.MiNuongInfo(msg);
                break;
            case -104:
                GameCanvas.readMessenge.infoclanChiemthanh(msg);
                break;
            case -105:
                GameCanvas.readMessenge.onHopRac(msg);
                break;
            case -106:
                GameCanvas.readMessenge.Material_Template(msg);
                break;
            case -108:
                GameCanvas.readMessenge.onFillRec_Time(msg);
                break;
            case 22:
                GameCanvas.readMessenge.onUpSkill(msg);
                break;
            case -107:
            case -89:
            case -88:
            case -87:
            case -86:
            case -85:
            case -84:
            case -83:
            case -82:
            case -81:
            case -80:
            case -79:
            case -78:
            case -77:
            case -74:
            case -73:
            case -72:
            case -71:
            case -70:
            case -69:
            case -68:
            case -67:
            case -66:
            case -65:
            case -64:
            case -63:
            case -62:
            case -61:
            case -60:
            case -59:
            case -58:
            case -56:
            case -55:
            case -48:
            case -47:
            case -46:
            case -45:
            case -43:
            case -42:
            case -41:
            case -40:
            case -39:
            case -38:
            case -37:
            case -36:
            case -35:
            case -34:
            case -33:
            case -29:
            case -28:
            case -27:
            case -26:
            case -25:
            case -24:
            case -23:
            case -22:
            case -21:
            case -20:
            case -19:
            case -18:
            case -17:
            case -16:
            case -15:
            case -14:
            case -13:
            case -12:
            case -11:
            case -10:
            case -9:
            case -8:
            case -7:
            case -6:
            case -5:
            case -4:
            case -3:
            case -2:
            case -1:
            case 0:
            case 11:
            case 14:
            case 18:
            case 24:
            case 38:
            case 43:
            case 45:
            case 46:
            case 47:
            case 58:
            case 66:
            case 71:
            case 72:
            case 79:
            case 80:
            case 81:
            case 82:
            case 83:
            case 87:
            case 88:
            case 89:
                break;
        }
    }
}
