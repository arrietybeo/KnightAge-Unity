using System;
using System.IO;
public class Cmd_Message
{
	public const sbyte MINI_GAME = -91;

	public const sbyte NOKIA_PURCHASE_MESSAGE = -76;

	public const sbyte GOOGLE_PURCHASE_MESSAGE = -75;

	public const sbyte UPDATE_DATA = -57;

	public const sbyte NAP_DIAMOND = -56;

	public const sbyte CHECK_UPDATE_DATA = -54;

	public const sbyte NAP_TIEN = -53;

	public const sbyte LOAD_IMAGE_DATA_PART_CHAR = -52;

	public const sbyte LOAD_IMAGE = -51;

	public const sbyte NPC_BIG = -50;

	public const sbyte LOAD_IMAGE_DATA_AUTO_EFF = -49;

	public const sbyte NEW_NPC_INFO = -44;

	public const sbyte DIALOG_MORE_OPTION_SERVER = -31;

	public const sbyte DIALOG_SERVER = -32;

	public const sbyte DYNAMIC_MENU = -30;

	public const sbyte MONSTER_CAPCHAR = -28;

	public const sbyte LOGIN = 1;

	public const sbyte LOGIN_FAIL = 2;

	public const sbyte MAIN_CHAR_INFO = 3;

	public const sbyte OBJECT_MOVE = 4;

	public const sbyte CHAR_INFO = 5;

	public const sbyte FIRE_PK = 6;

	public const sbyte MONSTER_INFO = 7;

	public const sbyte PLAYER_EXIT = 8;

	public const sbyte FIRE_MONSTER = 9;

	public const sbyte MONSTER_FIRE = 10;

	public const sbyte USE_ITEM = 11;

	public const sbyte CHANGE_MAP = 12;

	public const sbyte LIST_CHAR = 13;

	public const sbyte SELECT_CHAR = 13;

	public const sbyte CREATE_CHAR = 14;

	public const sbyte CHAR_WEARING = 15;

	public const sbyte CHAR_INVENTORY = 16;

	public const sbyte DIE_MONSTER = 17;

	public const sbyte DEL_ITEM = 18;

	public const sbyte ITEM_DROP = 19;

	public const sbyte GET_ITEM_MAP = 20;

	public const sbyte ITEM_MORE_INFO = 21;

	public const sbyte ADD_BASE_SKILL_POINT = 22;

	public const sbyte NPC_INFO = 23;

	public const sbyte BUY_ITEM = 24;

	public const sbyte ITEM_TEMPLATE = 25;

	public const sbyte CATALORY_MONSTER = 26;

	public const sbyte CHAT_POPUP = 27;

	public const sbyte GET_ITEM_TEM = 28;

	public const sbyte LIST_SKILL = 29;

	public const sbyte SET_EXP = 30;

	public const sbyte GO_HOME = 31;

	public const sbyte USE_POTION = 32;

	public const sbyte LEVEL_UP = 33;

	public const sbyte CHAT_TAB = 34;

	public const sbyte FRIEND = 35;

	public const sbyte BUY_SELL = 36;

	public const sbyte INFO_FROM_SERVER = 37;

	public const sbyte REGISTER = 39;

	public const sbyte BUFF = 40;

	public const sbyte DIE_PLAYER = 41;

	public const sbyte PK = 42;

	public const sbyte UPDATE_PET_CONTAINER = 44;

	public const sbyte PET_EAT = 45;

	public const sbyte PARTY = 48;

	public const sbyte OTHER_PLAYER_INFO = 49;

	public const sbyte EFF_PLUS_TIME = 50;

	public const sbyte CHANGE_AREA = 51;

	public const sbyte QUEST = 52;

	public const sbyte INFO_EASY_SERVER = 53;

	public const sbyte UPDATE_STATUS_AREA = 54;

	public const sbyte SAVE_RMS = 55;

	public const sbyte LIST_SERVER = 56;

	public const sbyte LIST_PLAYER_PK = 57;

	public const sbyte PLAYER_SUCKHOE = 59;

	public const sbyte CHAT_NPC = 60;

	public const sbyte NAME_SERVER = 61;

	public const sbyte X2_XP = 62;

	public const sbyte DELETE_RMS = 63;

	public const sbyte HELP_FROM_SERVER = 64;

	public const sbyte UPDATE_CHAR_CHEST = 65;

	public const sbyte REBUILD_ITEM = 67;

	public const sbyte THACH_DAU = 68;

	public const sbyte CLAN = 69;

	public const sbyte UPDATE_HP_NPC = 70;

	public const sbyte CHAT_WORLD = 71;

	public const sbyte REPLACE_PLUS_ITEM = 73;

	public const sbyte SHOW_NUM_EFF = 74;

	public const sbyte EFF_SERVER = 75;

	public const sbyte EFF_WEATHER = 76;

	public const sbyte REBUILD_WING = 77;

	public const sbyte OPEN_BOX = 78;

	public const sbyte PET_ATTACK = 84;

	public const sbyte MONSTER_DETONATE = 85;

	public const sbyte MONSTER_SKILL_INFO = 86;

	public const sbyte PET_GAIN_XP = 87;

	public const sbyte REMOVE_ACTOR = 90;

	public const sbyte IN_APP_PURCHASE = -93;

	public const sbyte USE_ITEM_ARENA = -92;

	public const sbyte STATUS_ARENA = -94;

	public const sbyte MARKKILLER = -95;

	public const sbyte SERVER_ADD_NPC = -96;

	public const sbyte USE_MOUNT = -97;

	public const sbyte USE_SHIP = -98;

	public const sbyte LAST_LOGIN = -99;

	public const sbyte KHAM_NGOC = -100;

	public const sbyte COMPETITION = -101;

	public const sbyte MUA_BAN = -102;

	public const sbyte INFO_MI_NUONG = -103;

	public const sbyte UPDATE_INFO_CLAN_HOLD = -104;

	public const sbyte HOP_RAC = -105;

	public const sbyte GET_MATERITAL_TEMPLATE = -106;

	public const sbyte USE_MATERIAL = -107;

	public const sbyte FILL_REC_UPDATE_TIME = -108;

	public const sbyte GET_NAP_STORE_APPLE = -109;

	public ISession session = Session_ME.gI();

	public Message m;

	protected void writeInt(int in0)
	{
		try
		{
			m.writer().writeInt(in0);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	protected void writeByte(int by)
	{
		try
		{
			m.writer().writeByte(by);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	protected void writeShort(int by)
	{
		try
		{
			m.writer().writeShort(by);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	public void writeUTF(string str)
	{
		try
		{
			m.writer().writeUTF(str);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	protected void writeBoolean(bool boo)
	{
		try
		{
			m.writer().writeBoolean(boo);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	public void setSession(ISession gi)
	{
		session = null;
		session = gi;
	}

	public void send()
	{
		session.sendMessage(m);
		m.cleanup();
	}

	public void init(sbyte cmd)
	{
		string filePath = "G://KnightAge//msg.txt";
		using (StreamWriter writer = new StreamWriter(filePath, true))
		{
			writer.WriteLine("init msg: [" + cmd + "]");
		}
		m = new Message(cmd);
	}
}
