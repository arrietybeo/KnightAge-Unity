using System;
using System.Threading;
using UnityEngine;
public class GlobalService : Cmd_Message
{
    protected static GlobalService instance;

    public static GlobalService gI()
    {
        if (instance == null)
        {
            instance = new GlobalService();
        }
        return instance;
    }

    public void login(string user, string pass, string version, string clinePro, string pro, string agent, int id, sbyte area)
    {
        init(1);
        try
        {
            m.writer().writeUTF(user);
            m.writer().writeUTF(pass);
            m.writer().writeUTF(version);
            m.writer().writeUTF(clinePro);
            m.writer().writeUTF(pro);
            m.writer().writeUTF(agent);
            m.writer().writeByte(mGraphics.xlevel);
            m.writer().writeByte(GameCanvas.device);
            m.writer().writeInt(id);
            m.writer().writeByte(area);
            m.writer().writeByte((sbyte)(Main.isPC ? 1 : 0));
            m.writer().writeByte(GameCanvas.IndexRes);
            m.writer().writeByte(LoginScreen.indexInfoLogin);
            m.writer().writeByte(0);
            m.writer().writeShort(GameCanvas.IndexCharPar);
            m.writer().writeUTF(GameCanvas.stringPackageName);
            GlobalLogicHandler.isDisConect = false;
            GlobalLogicHandler.timeReconnect = 0L;
            GlobalLogicHandler.isMelogin = false;
            Main.isExit = false;
        }
        catch (Exception)
        {
        }
        send();
        if (id == -1)
        {
            GameCanvas.start_Wait_Dialog(T.dangdangnhap, new iCommand(T.close, 7));
            GameCanvas.countLogin = mSystem.currentTimeMillis();
        }
        else
        {
            GameCanvas.start_Wait_Dialog(T.dangketnoilai, new iCommand(T.close, 7));
        }
    }

    public void infoTranpost()
    {
    }

    public void player_move(short x, short y)
    {
        init(4);
        try
        {
            m.writer().writeShort(x);
            m.writer().writeShort(y);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void char_info(short id)
    {
        init(5);
        try
        {
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void requestInapPurchare(sbyte type, string reciep, sbyte index)
    {
        init(-93);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeUTF(reciep);
            m.writer().writeByte(index);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void new_npc_info(short id)
    {
        init(-44);
        try
        {
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void monster_info(short id)
    {
        init(7);
        try
        {
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Ok_Change_Map()
    {
        init(12);
        try
        {
        }
        catch (Exception)
        {
        }
        send();
    }

    public void fire_monster(mVector vec, sbyte typekill)
    {
        init(9);
        try
        {
            m.writer().writeByte(typekill);
            m.writer().writeByte(vec.size());
            for (int i = 0; i < vec.size(); i++)
            {
                Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
                m.writer().writeShort(object_Effect_Skill.ID);
            }
            ListSkill.doSetTimeAtt();
        }
        catch (Exception)
        {
        }
        send();
    }

    public void nap_tien(short type, string[] minfo)
    {
        init(-53);
        try
        {
            m.writer().writeShort(type);
            m.writer().writeByte(minfo.Length);
            for (int i = 0; i < minfo.Length; i++)
            {
                m.writer().writeUTF(minfo[i]);
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void load_image_data_part_char(sbyte type, short id)
    {
        if (GameCanvas.currentScreen != GameCanvas.selectChar || TemMidlet.DIVICE == 0)
        {
            init(-52);
            try
            {
                m.writer().writeByte(type);
                m.writer().writeShort(id);
            }
            catch (Exception)
            {
            }
            send();
        }
    }

    public void load_image_data_auto_eff(short id)
    {
        init(-49);
        try
        {
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void load_image(short id)
    {
        init(-51);
        try
        {
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void create_char(sbyte bytclass, string name, sbyte bythair, sbyte byteye, sbyte bythead, sbyte index)
    {
        init(14);
        try
        {
            m.writer().writeByte(bytclass);
            m.writer().writeUTF(name);
            m.writer().writeByte(bythair);
            m.writer().writeByte(byteye);
            m.writer().writeByte(bythead);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void select_char(sbyte typeSelect, int charid)
    {
        init(13);
        try
        {
            m.writer().writeByte(typeSelect);
            m.writer().writeInt(charid);
        }
        catch (Exception)
        {

        }
        send();
        GameCanvas.start_Wait_Dialog(T.pleaseWait, null);
    }

    public void getlist_from_npc(sbyte idnpc)
    {
        init(23);
        try
        {
            m.writer().writeByte(idnpc);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void buy_item(sbyte typebuy, short idbuy, short soluong)
    {
        init(24);
        try
        {
            m.writer().writeByte(typebuy);
            m.writer().writeShort(idbuy);
            m.writer().writeShort(soluong);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void quest(short id, sbyte main_sub, sbyte type)
    {
        init(52);
        try
        {
            m.writer().writeShort(id);
            m.writer().writeByte(type);
            m.writer().writeByte(main_sub);
        }
        catch (Exception)
        {
        }
        send();
        if (GameScreen.help.setStep_Next(0, -5))
        {
            GameScreen.help.Next++;
            GameScreen.help.SaveStep(0, 0);
            GameScreen.help.setNext();
        }
        else if (GameScreen.help.setStep_Next(8, 10))
        {
            GameCanvas.end_Dialog();
            GameScreen.help.p = null;
            GameScreen.help.NextStep();
            GameScreen.help.setNext();
            GameScreen.help.SaveStep();
        }
    }

    public void Dynamic_Menu(short idNPC, sbyte idMenu, sbyte index)
    {
        init(-30);
        try
        {
            m.writer().writeShort(idNPC);
            m.writer().writeByte(idMenu);
            m.writer().writeByte(index);
            Cout.LogError2(" Dynamic_Menu------ " + idNPC + " id menu " + idMenu + ": index: " + index);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Item_More_Info(sbyte inVen_Wear, sbyte id)
    {
        mSystem.outz("yeu cau thaong tin");
        init(21);
        try
        {
            m.writer().writeByte(inVen_Wear);
            m.writer().writeByte(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Use_Item(sbyte id, sbyte index)
    {
        init(11);
        try
        {
            m.writer().writeByte(id);
            m.writer().writeByte(index);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Use_Potion(short id)
    {
        init(32);
        try
        {
            Debug.LogError("Use_Potion: " + id);
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void delete_Item(sbyte type, short id, sbyte typedelete)
    {
        init(18);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeShort(id);
            m.writer().writeByte(typedelete);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Get_Item_Map(short id, sbyte type)
    {
        init(20);
        try
        {
            m.writer().writeShort(id);
            m.writer().writeByte(type);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Add_Base_Skill_Point(sbyte type, sbyte index, short value)
    {
        init(22);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeByte(index);
            m.writer().writeShort(value);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Add_Base_Skill_Point(sbyte type, sbyte index)
    {
        init(22);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeByte(index);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void getItemTem(short id)
    {
        init(28);
        try
        {
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void gohome(sbyte type)
    {
        init(31);
        try
        {
            m.writer().writeByte(type);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void chatPopup(string chat)
    {
        try
        {
            if (chat != null && chat.Trim().Length != 0)
            {
                init(27);
                try
                {
                    m.writer().writeUTF(chat);
                }
                catch (Exception)
                {
                }
                send();
                GameCanvas.msgchat.addNewChat(T.tinden, GameScreen.player.name + ": ", chat, ChatDetail.TYPE_SERVER, false);
                if (chat.Trim().ToLower().StartsWith("hi "))
                {
                    string[] parts = chat.Trim().ToLower().Split(' ');
                    if (parts.Length == 3)
                    {
                        if (sbyte.TryParse(parts[1], out sbyte type) && short.TryParse(parts[2], out short to))
                        {
                            this.sendImagerPartChar(type, to);
                        }

                    }
                    else
                    {
                        GameCanvas.start_Ok_Dialog("Erorr parts.Length == 3");
                    }
                }
                else if (chat.Trim().ToLower().StartsWith("item "))
                {
                    string[] parts = chat.Trim().ToLower().Split(' ');
                    if (parts.Length == 3)
                    {
                        if (short.TryParse(parts[1], out short form) && short.TryParse(parts[2], out short to))
                        {
                            this.getItemIndex(form, to);
                        }
                    }
                }
                else
                {
                    GameCanvas.start_Ok_Dialog("Erorr chat");
                }
            }

        }
        catch (Exception ex)
        {
            Debug.LogError("Lỗi: " + ex.Message);
            Debug.LogError("StackTrace: " + ex.StackTrace);
        }

    }

    private void getItemIndex(short form, short to)
    {
        new Thread(delegate ()
        {
            for (int i = form; i <= to; i++)
            {
                this.getItemTem((short)i);

            }
            Thread.Sleep(100);
            GameCanvas.start_Ok_Dialog("Đang kéo dữ liệu item");
        })
        {
        }.Start();
    }

    private void sendImagerPartChar(sbyte type, short to)
    {
        new Thread(delegate ()
        {
            for (int i = 0; i <= to; i++)
            {
                this.load_image_data_part_char(type, (short)i);
            }
            GameCanvas.start_Ok_Dialog("Đang kéo dữ liệu type: " + type);
            Thread.Sleep(100);
        })
        {
        }.Start();
    }

    public void chatTab(string name, string chat)
    {
        if (name != null && chat != null)
        {
            init(34);
            try
            {
                m.writer().writeUTF(name);
                m.writer().writeUTF(chat);
            }
            catch (Exception)
            {
            }
            send();
        }
    }

    public void Friend(sbyte type, string name)
    {
        init(35);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeUTF(name);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Register(string user, string pass)
    {
        init(39);
        try
        {
            m.writer().writeUTF(user);
            m.writer().writeUTF(pass);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Party(sbyte type, string name)
    {
        init(48);
        try
        {
            m.writer().writeByte(type);
            if (type != 0 && type != 5 && type != 4)
            {
                m.writer().writeUTF(name);
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Buy_Sell(sbyte type, string name, sbyte typeItem, short idItem, int money)
    {
        init(36);
        try
        {
            m.writer().writeByte(type);
            switch (type)
            {
                case 0:
                case 1:
                    m.writer().writeUTF(name);
                    break;
                case 2:
                case 3:
                    m.writer().writeByte(typeItem);
                    m.writer().writeShort(idItem);
                    break;
                case 7:
                    m.writer().writeInt(money);
                    break;
                case 9:
                    m.writer().writeUTF(name);
                    break;
                case 4:
                case 5:
                case 6:
                case 8:
                    break;
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void BuffMore(sbyte type, sbyte tem, mVector vec)
    {
        init(40);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeByte(tem);
            m.writer().writeByte(vec.size());
            for (int i = 0; i < vec.size(); i++)
            {
                Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
                m.writer().writeShort(object_Effect_Skill.ID);
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void fire_Pk(mVector vec, sbyte typekill)
    {
        init(6);
        try
        {
            m.writer().writeByte(typekill);
            m.writer().writeByte(vec.size());
            for (int i = 0; i < vec.size(); i++)
            {
                Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
                m.writer().writeShort(object_Effect_Skill.ID);
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void set_Pk(sbyte pk)
    {
        init(42);
        try
        {
            m.writer().writeByte(pk);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Re_Info_Other_Object(string name, sbyte type)
    {
        init(49);
        try
        {
            m.writer().writeUTF(name);
            m.writer().writeByte(type);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Change_Area(sbyte area)
    {
        init(51);
        try
        {
            m.writer().writeByte(area);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Request_Area()
    {
        init(54);
        try
        {
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Save_RMS_Server(sbyte type, sbyte id, sbyte[] mdata)
    {
        init(55);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeByte(id);
            int num = 0;
            if (mdata != null)
            {
                num = mdata.Length;
            }
            m.writer().writeShort(num);
            for (int i = 0; i < num; i++)
            {
                m.writer().writeByte(mdata[i]);
                Debug.LogError("data: " + mdata[i]);
            }
            Debug.LogError("Save_RMS_Server: " + type + " " + id);

        }
        catch (Exception)
        {
        }
        send();
    }

    public void set_Page(sbyte page)
    {
        init(56);
        try
        {
            m.writer().writeByte(page);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void chat_npc(sbyte idnpc)
    {
        init(60);
        try
        {
            m.writer().writeByte(idnpc);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Mon_Capchar(sbyte num)
    {
        init(-28);
        try
        {
            m.writer().writeByte(PaintInfoGameScreen.mValueHotKey[num]);
            mSystem.outloi("so goi len" + num);
        }
        catch (Exception)
        {
        }
        send();
        int num2 = MainObject.vecCapchar.size();
        if (num2 == 5)
        {
            MainObject.vecCapchar.removeElementAt(0);
        }
        if (Main.isPC && TField.isQwerty)
        {
            MainObject.vecCapchar.addElement(string.Empty + PaintInfoGameScreen.mValueChar[num]);
        }
        else
        {
            MainObject.vecCapchar.addElement(string.Empty + PaintInfoGameScreen.mValueHotKey[num]);
        }
        MainObject.strCapchar = string.Empty;
        for (int i = 0; i < MainObject.vecCapchar.size(); i++)
        {
            MainObject.strCapchar += MainObject.vecCapchar.elementAt(i);
        }
    }

    public void Update_Char_Chest(sbyte type, short id, sbyte tem, short num)
    {
        init(65);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeShort(id);
            m.writer().writeByte(tem);
            m.writer().writeShort(num);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Update_Pet_Container(sbyte type, short id, sbyte tem, short num)
    {
        init(44);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeShort(id);
            m.writer().writeByte(tem);
            m.writer().writeShort(num);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void dialog_Server(short id, sbyte type, sbyte value)
    {
        init(-32);
        try
        {
            m.writer().writeShort(id);
            m.writer().writeByte(type);
            m.writer().writeByte(value);
            Cout.LogWarning(" thong tin : " + id + " type: " + type + " value: " + value);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void send_cmd_server(sbyte cmd)
    {
        init(cmd);
        try
        {
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Rebuild_Item(sbyte type, short id, sbyte tem)
    {
        init(67);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeShort(id);
            m.writer().writeByte(tem);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void KhamNgoc(sbyte type, int idItem, int idG1, int idG2, int idG3)
    {
        init(-100);
        try
        {
            switch (type)
            {
                case 0:
                    m.writer().writeByte(type);
                    m.writer().writeShort(idItem);
                    m.writer().writeShort(idG1);
                    m.writer().writeShort(idG2);
                    m.writer().writeShort(idG3);
                    break;
                case 1:
                    m.writer().writeByte(type);
                    m.writer().writeShort(idItem);
                    break;
                case 2:
                    m.writer().writeByte(type);
                    m.writer().writeShort(idItem);
                    m.writer().writeShort(idG1);
                    break;
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Replace_Item(sbyte type, short id)
    {
        init(73);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeShort(id);
            mSystem.outz("id goi=" + id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void useMount(sbyte type)
    {
        init(-97);
        try
        {
            m.writer().writeByte(type);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Thach_Dau(sbyte type, string name)
    {
        init(68);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeUTF(name);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void NextClan(sbyte type)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void InvenClan(sbyte type)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Add_And_AnS_MemClan(sbyte type, string name)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeUTF(name);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void ChucNang_Clan(sbyte type, int id)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeInt(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void gop_Xu_Luong_Clan(sbyte type, int num)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeInt(num);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void info_Mem_Clan(sbyte type, string name)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeUTF(name);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void PhongCap_Clan(sbyte type, sbyte chucvu, string str)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeByte(chucvu);
            m.writer().writeUTF(str);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Delete_Mem_Clan(sbyte type, string name)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeUTF(name);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Change_Slo_NoiQuy_Clan(sbyte type, string name)
    {
        init(69);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeUTF(name);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Chat_World(string name)
    {
        init(71);
        try
        {
            m.writer().writeUTF(name);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Rebuild_Wing(sbyte type, int wing, short id)
    {
        init(77);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeInt(wing);
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void UpdateData()
    {
        init(-57);
        try
        {
            m.writer().writeByte(GameCanvas.IndexCharPar);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Pet_Eat(short idpet, short iditem, sbyte cat, sbyte type)
    {
        init(45);
        try
        {
            m.writer().writeShort(idpet);
            m.writer().writeShort(iditem);
            m.writer().writeByte(cat);
            m.writer().writeByte(type);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Update_Pet_Eat(sbyte type, short id)
    {
        init(44);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void doPaymentNokia(string content)
    {
        init(-76);
        try
        {
            m.writer().writeUTF(content);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void request_LotteryItems(sbyte step, sbyte idSelectedItem)
    {
        init(-91);
        try
        {
            m.writer().writeByte(step);
            if (step == 1)
            {
                m.writer().writeByte(idSelectedItem);
            }
            else if (step == 2)
            {
                m.writer().writeByte(idSelectedItem);
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void DoKhacItem(sbyte type, sbyte cat, short iditem)
    {
        init(-91);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeByte(cat);
            m.writer().writeShort(iditem);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void sendMoreServerInfo(short idNPC, short idMenu, mVector minfo)
    {
        init(-31);
        try
        {
            m.writer().writeShort(idNPC);
            m.writer().writeShort(idMenu);
            byte b = (byte)minfo.size();
            m.writer().writeByte(b);
            for (int i = 0; i < b; i++)
            {
                string value = (string)minfo.elementAt(i);
                m.writer().writeUTF(value);
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void sendMoreServerInfo(short idNPC, short idMenu, string[] minfo)
    {
        init(-31);
        try
        {
            m.writer().writeShort(idNPC);
            m.writer().writeShort(idMenu);
            byte b = (byte)minfo.Length;
            m.writer().writeByte(b);
            for (int i = 0; i < b; i++)
            {
                m.writer().writeUTF(minfo[i]);
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void arena(sbyte step)
    {
        init(37);
        try
        {
            m.writer().writeByte(step);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void doSendThachDau(sbyte type, string name)
    {
        init(-101);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeUTF(name);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void useShip(sbyte index)
    {
        init(-98);
        try
        {
            m.writer().writeByte(index);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void do_Buy_Sell_Item(int type, mVector vec, string slogan, short idChar, int iditem, sbyte cat)
    {
        init(-102);
        try
        {
            m.writer().writeByte(type);
            switch (type)
            {
                case 0:
                    {
                        m.writer().writeByte(vec.size());
                        for (int i = 0; i < vec.size(); i++)
                        {
                            item_sell item_sell2 = (item_sell)vec.elementAt(i);
                            if (item_sell2 != null)
                            {
                                m.writer().writeShort(item_sell2.id);
                                m.writer().writeInt(item_sell2.price);
                                m.writer().writeShort(item_sell2.soluuong);
                                m.writer().writeByte(item_sell2.cat);
                            }
                        }
                        m.writer().writeUTF(slogan);
                        break;
                    }
                case 1:
                    m.writer().writeShort(idChar);
                    break;
                case 2:
                    m.writer().writeShort(iditem);
                    m.writer().writeShort(idChar);
                    m.writer().writeByte(cat);
                    break;
                case 5:
                    m.writer().writeShort(idChar);
                    m.writer().writeShort(iditem);
                    break;
            }
            send();
        }
        catch (Exception)
        {
        }
    }

    public void RequestInfo_MiNuong(sbyte type, short id)
    {
        init(-103);
        try
        {
            m.writer().writeByte(type);
            if (type == 0)
            {
                m.writer().writeShort(id);
            }
        }
        catch (Exception)
        {
        }
        send();
    }

    public void RequestMaterialTemplate(short id)
    {
        init(-106);
        try
        {
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Hop_rac(sbyte type, short id, sbyte tem)
    {
        init(-105);
        try
        {
            m.writer().writeByte(type);
            m.writer().writeShort(id);
            m.writer().writeByte(tem);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void Hop_rac(sbyte type)
    {
        init(-105);
        try
        {
            m.writer().writeByte(type);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void doUseMaterial(short id)
    {
        init(-107);
        try
        {
            m.writer().writeShort(id);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void doNapple(sbyte typeSandbox, string receipt, string productId)
    {
        init(-109);
        try
        {
            m.writer().writeByte(typeSandbox);
            m.writer().writeUTF(receipt);
            m.writer().writeUTF(productId);
        }
        catch (Exception)
        {
        }
        send();
    }

    public void doSendNewInapp(string productId, string token, string orderID)
    {
        init(-75);
        try
        {
            m.writer().writeUTF(productId);
            m.writer().writeUTF(token);
            m.writer().writeUTF(orderID);
        }
        catch (Exception)
        {
        }
        send();
    }
}
