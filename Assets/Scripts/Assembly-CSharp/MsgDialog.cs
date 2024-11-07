using System;

public class MsgDialog : MainDialog
{
	public const sbyte NORMAL = 0;

	public const sbyte QUEST = 1;

	public const sbyte PARTY = 2;

	public const sbyte LIST_PARTY = 3;

	public const sbyte AUTO_HP_MP = 4;

	public const sbyte HELP = 5;

	public const sbyte SHOW = 6;

	public const sbyte AUTO_GET_ITEM = 7;

	public const sbyte AUTO_BUFF = 8;

	public const sbyte DIA_TIME = 9;

	public const sbyte SHOW_CHANGE_ITEM = 10;

	public const sbyte SHOW_OPEN_BOX = 11;

	public const sbyte UPDATE_DATA = 12;

	public const sbyte SET_VOLUME = 13;

	public const sbyte PET_INFO = 14;

	public const sbyte Info_arena = 15;

	public const sbyte OPEN_BOX = 0;

	public const sbyte BOX_QUEST = 1;

	private MsgDialog LastDia;

	private string status;

	private string link = string.Empty;

	private string nameShow;

	private int wStatus;

	public static int maxSizeParty;

	public int maxSizeList;

	private int fWait;

	private int IdQuest;

	private int typeQuest;

	private int idSelect;

	private int idSelectBuy;

	private int idCommand;

	private int sizeParty;

	private sbyte main_sub_quest;

	private bool isWaiting;

	private bool isSpec;

	public static sbyte MaxSkillBuff = 0;

	private mVector cmdList = new mVector("MsgChat cmdList");

	private iCommand cmdClose = new iCommand(T.close, -1, me);

	private iCommand cmdCancleQuest = new iCommand(T.cancel, 10, me);

	private iCommand cmdchucnang;

	private iCommand cmdHelp;

	private iCommand cmdPet;

	public static FrameImage fraWaiting;

	private Camera cameraDia = new Camera();

	private ListNew list;

	private int hItem;

	private int hWait;

	private int hSpe;

	public static int hPlus = 52;

	public static int timePaintParty = 0;

	private MainQuest quest;

	public static int isUutien = 0;

	public static int[] mHPMP = new int[2] { 50, 50 };

	private int archor = -1;

	private sbyte[] mvalueItem = new sbyte[3];

	public static sbyte[] mvalueVolume = null;

	public static mVector vecListEvent = new mVector("MsgDiaLog vecListEvent");

	private int min;

	private int max;

	private int hbutton;

	private int wbuff;

	public static int[][] Autobuff;

	private mFont fontDia = mFont.tahoma_7_white;

	public static MsgDialog me;

	private sbyte isLottery;

	private int sizeButtonQuest = 1;

	private short timeDia;

	private long timeset;

	private MainItem[] datanguyenlieu;

	private MainItem sanpham;

	private int StepShow;

	private int timeShow;

	private int[][] posItemNguyenlieu;

	private MainItem[] itemsanpham;

	private int wsizeBox;

	private int indexShow1;

	private int indexShow2;

	private sbyte isFullEff;

	public static int maxupdate;

	public static int curupdate;

	public static int wUpdate;

	public static int hUpdate;

	public static PetItem pet;

	public static sbyte isInven_Equip = 0;

	public static sbyte INVEN = 0;

	public static sbyte EQUIP = 1;

	private int xBegin;

	private int w2cmd;

	private bool isTran;

	private int yCamBegin;

	public static bool isAutologin = false;

	public MsgDialog()
	{
		GameCanvas.closeKeyBoard();
		me = this;
	}

	public override void commandTab(int index, int subIndex)
	{
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		switch (index)
		{
		case -1:
		case 7:
			closeDialog();
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			GlobalLogicHandler.isMelogin = false;
			isAutologin = false;
			break;
		case 6:
			GameScreen.player.resetPlayer();
			GameCanvas.login.Show();
			closeDialog();
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			isAutologin = false;
			GlobalLogicHandler.isMelogin = false;
			break;
		case 0:
			if (GameCanvas.currentScreen != GameCanvas.login && GameCanvas.currentScreen != GameCanvas.load)
			{
				if (SelectCharScreen.isSelectOk)
				{
					GameCanvas.login.Show();
					sbyte[] array = CRes.loadRMS("user_pass");
					if (array != null)
					{
						try
						{
							LoginScreen.loadUser_Pass();
						}
						catch (Exception)
						{
						}
						GameCanvas.connect();
						GlobalService.gI().login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText(), GameMidlet.version, "0", "0", "0", SelectCharScreen.IDCHAR, LoadMap.Area);
						GameScreen.player.resetPlayer();
						if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
						{
							GlobalService.gI().send_cmd_server(61);
						}
						closeDialog();
					}
					else
					{
						GameCanvas.login.Show();
						closeDialog();
					}
				}
			}
			else
			{
				if (GameCanvas.currentScreen != GameCanvas.login)
				{
					GameCanvas.login.Show();
				}
				closeDialog();
			}
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			isAutologin = false;
			GlobalLogicHandler.isMelogin = false;
			break;
		case 2:
			GlobalService.gI().quest((short)IdQuest, main_sub_quest, (sbyte)typeQuest);
			closeDialog();
			break;
		case 1:
			closeDialog();
			break;
		case 3:
			GameCanvas.worldmap.Show(GameCanvas.game);
			closeDialog();
			break;
		case 4:
			setMenuParty();
			break;
		case 5:
			Player.isAutoHPMP = true;
			Player.mhotkey[Player.levelTab][4].type = HotKey.NULL;
			Player.mhotkey[Player.levelTab][3].type = HotKey.NULL;
			MainItem.setAddHotKey(1, (isUutien != 0) ? true : false);
			MainItem.setAddHotKey(0, (isUutien != 0) ? true : false);
			MainRMS.setSaveAuto();
			TabSkillsNew.saveSkill();
			closeDialog();
			break;
		case 8:
			if (Player.party != null)
			{
				if (GameScreen.player.name.CompareTo(Player.party.nameMain) == 0)
				{
					setChucNangParty();
					break;
				}
				mVector mVector3 = new mVector("MsgChat menu");
				iCommand o = new iCommand(T.leave, 8, this);
				mVector3.addElement(o);
				iCommand o2 = new iCommand(T.chatParty, 15, this);
				mVector3.addElement(o2);
				GameCanvas.menu2.startAt(mVector3, 2, T.chucnang, isFocus: false, null);
			}
			break;
		case 9:
		{
			int num = -1;
			if (mvalueItem[0] < (sbyte)(T.mValueAutoItem[0].Length - 1))
			{
				num = mvalueItem[0];
			}
			Player.autoItem = new AutoGetItem((sbyte)num, mvalueItem[1], mvalueItem[2]);
			MainRMS.setSaveAuto();
			closeDialog();
			break;
		}
		case 10:
			if (idSelect >= 0 && idSelect < MaxSkillBuff)
			{
				setAutoBuff(idSelect);
			}
			break;
		case 11:
			setMusic();
			closeDialog();
			break;
		case 15:
			closeDialog();
			GlobalService.gI().arena((sbyte)index);
			break;
		case 16:
			closeDialog();
			GameScreen.player.resetAction();
			Session_ME.gI().close();
			GameCanvas.login.Show();
			GameScreen.player = new Player(0, 0, "unname", 0, 0);
			SelectCharScreen.reSelect = false;
			SelectCharScreen.Canselect = false;
			break;
		default:
			closeDialog();
			break;
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		ObjectParty objectParty = null;
		switch (index)
		{
		case -1:
			closeDialog();
			break;
		case 6:
			if (Player.party != null)
			{
				objectParty = (ObjectParty)Player.party.vecPartys.elementAt(idSelect);
				GlobalService.gI().Party(3, objectParty.name);
			}
			break;
		case 7:
			closeDialog();
			GlobalService.gI().Party(4, string.Empty);
			break;
		case 8:
			closeDialog();
			GlobalService.gI().Party(5, string.Empty);
			break;
		case 9:
			if (Player.party != null)
			{
				objectParty = (ObjectParty)Player.party.vecPartys.elementAt(idSelect);
				GlobalService.gI().Friend(0, objectParty.name);
			}
			break;
		case 2:
			if (Player.party != null && idSelect >= 0 && idSelect < Player.party.vecPartys.size())
			{
				objectParty = (ObjectParty)Player.party.vecPartys.elementAt(idSelect);
				GameCanvas.start_Left_Dialog(T.hoivaonhom + objectParty.name + "?", new iCommand(T.gianhap, 0, this));
			}
			break;
		case 3:
			if (Player.party != null && idSelect >= 0 && idSelect < Player.party.vecPartys.size())
			{
				GameCanvas.start_Left_Dialog(T.hoilapnhom, new iCommand(T.gianhap, 1, this));
			}
			break;
		case 10:
			if (quest != null)
			{
				GameCanvas.start_Left_Dialog(T.hoihuyQuest + quest.name, new iCommand(T.cancel, 11, this));
			}
			break;
		case 11:
			if (quest != null)
			{
				GlobalService.gI().quest((short)quest.ID, (!quest.isMain) ? ((sbyte)1) : ((sbyte)0), 2);
				TabQuest.me.resetTab(isResetCmy: true);
				if (!GameScreen.help.setStep_Next(9, 0))
				{
					closeDialog();
					closeDialog();
				}
			}
			break;
		case 12:
			if (link.Length > 0)
			{
				TemMidlet.openUrl(link);
			}
			break;
		case 14:
			if (Player.party != null)
			{
				objectParty = (ObjectParty)Player.party.vecPartys.elementAt(idSelect);
				GameCanvas.msgchat.addNewChat(objectParty.name, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, isFocus: true);
				GameCanvas.start_Chat_Dialog();
			}
			break;
		case 15:
			GameCanvas.msgchat.addNewChat(T.party, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, isFocus: true);
			GameCanvas.start_Chat_Dialog();
			break;
		case 16:
		{
			mVector mVector3 = new mVector("MsgChat vec");
			TabShopNew tabShopNew = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.choan, -1, TabShopNew.INVEN_FOOD_PET);
			tabShopNew.petCur = pet;
			mVector3.addElement(tabShopNew);
			GameCanvas.foodPet = new TabScreenNew();
			GameCanvas.foodPet.selectTab = 0;
			GameCanvas.foodPet.addMoreTab(mVector3);
			GameCanvas.foodPet.Show(GameCanvas.currentScreen);
			break;
		}
		case 0:
		case 1:
		case 4:
		case 5:
		case 13:
			break;
		}
	}

	public void beginDia()
	{
		GameScreen.player.resetVx_vy();
		left = null;
		right = null;
		center = null;
		cmdList.removeAllElements();
	}

	public void setinfo(string info, iCommand cmd, bool isOnlyCenter)
	{
		beginDia();
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		isWaiting = false;
		isSpec = false;
		type = 0;
		wDia = GameCanvas.w - 30;
		if (wDia > 200)
		{
			wDia = 200;
		}
		cmdList = new mVector("MsgChat cmdlist2");
		cmdList.addElement(cmd);
		if (!isOnlyCenter)
		{
			cmdList.addElement(cmdClose);
		}
		int num = cmdList.size();
		if (wDia < num * iCommand.wButtonCmd + (num - 1) * 10 + 10)
		{
			wDia = num * iCommand.wButtonCmd + (num - 1) * 10 + 10;
		}
		if (wDia > GameCanvas.w)
		{
			wDia = GameCanvas.w;
		}
		strinfo = fontDia.splitFontArray(info, wDia - 20);
		hDia = 15 * strinfo.Length + hPlus;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia - 5;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		setPosCmdNew(0);
	}

	public void setinfoDownload(string info, string link, bool isOnlyCenter)
	{
		beginDia();
		this.link = link;
		isWaiting = false;
		isSpec = false;
		type = 0;
		wDia = GameCanvas.w - 30;
		if (wDia > 200)
		{
			wDia = 200;
		}
		cmdList = new mVector("MsgChat cmdlist3");
		iCommand o = new iCommand(T.yes, 12, this);
		cmdList.addElement(o);
		cmdList.addElement(cmdClose);
		int num = cmdList.size();
		if (wDia < num * iCommand.wButtonCmd + (num - 1) * 10 + 10)
		{
			wDia = num * iCommand.wButtonCmd + (num - 1) * 10 + 10;
		}
		if (wDia > GameCanvas.w)
		{
			wDia = GameCanvas.w;
		}
		strinfo = fontDia.splitFontArray(info, wDia - 20);
		hDia = 15 * strinfo.Length + hPlus;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia - 5;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		setPosCmdNew(0);
	}

	public void setinfoWait(string info, iCommand cmd)
	{
		beginDia();
		isWaiting = true;
		isSpec = false;
		type = 0;
		wDia = GameCanvas.w - 30;
		if (wDia > 200)
		{
			wDia = 200;
		}
		cmdList = new mVector("MsgChat cmdlist7");
		hWait = 0;
		if (cmd != null)
		{
			cmdList.addElement(cmd);
			hWait = iCommand.hButtonCmd;
		}
		strinfo = fontDia.splitFontArray(info, wDia - 20);
		hDia = 15 * strinfo.Length + hPlus + hWait;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia - 5;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		setPosCmdNew(0);
	}

	public void setinfo(string info, mVector cmd)
	{
		beginDia();
		if (cmd == null || cmd.size() <= 0)
		{
			GameCanvas.currentDialog = null;
		}
		isWaiting = false;
		isSpec = false;
		type = 0;
		cmdList = cmd;
		wDia = GameCanvas.w - 30;
		if (wDia > 200)
		{
			wDia = 200;
		}
		int num = cmdList.size();
		if (wDia < 2 * iCommand.wButtonCmd + 10)
		{
			wDia = 2 * iCommand.wButtonCmd + 10;
		}
		if (wDia > GameCanvas.w)
		{
			wDia = GameCanvas.w;
		}
		int num2 = 0;
		if (cmdList.size() > 2)
		{
			num2 = iCommand.hButtonCmd;
		}
		strinfo = fontDia.splitFontArray(info, wDia - 20);
		hDia = 15 * strinfo.Length + hPlus + num2;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia - 5 + ((num > 2) ? (iCommand.hButtonCmd + 5) : 0);
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		setPosCmdNew(0);
	}

	public void setinfoQuest(string info, string status, int IDQuest, int typeQuest, sbyte mainsub)
	{
		beginDia();
		hSpe = 2;
		IdQuest = IDQuest;
		this.typeQuest = typeQuest;
		main_sub_quest = mainsub;
		isSpec = true;
		iCommand iCommand2 = new iCommand(T.nhan, 2);
		if (typeQuest == 1)
		{
			iCommand2.caption = T.tra;
			cmdList.addElement(iCommand2);
		}
		else
		{
			cmdList.addElement(iCommand2);
			iCommand o = new iCommand(T.close, 1);
			if (mainsub == 1)
			{
				cmdList.addElement(o);
			}
		}
		this.status = status;
		wStatus = mFont.tahoma_7b_white.getWidth(status) + 20;
		isWaiting = false;
		type = 1;
		sizeButtonQuest = 1;
		wDia = GameCanvas.w / 5 * 4;
		if (wDia > 200)
		{
			wDia = 200;
		}
		strinfo = mFont.tahoma_7_white.splitFontArray(info, wDia - 20);
		hDia = GameCanvas.hText * (strinfo.Length + 1) + hPlus + 20 + ((cmdList.size() > 2) ? (iCommand.hButtonCmd + 5) : 0);
		if (hDia > GameCanvas.h / 2 + 10)
		{
			hDia = GameCanvas.h / 2 + 10;
		}
		cameraDia.setAll(0, GameCanvas.hText * (strinfo.Length + 1) + 30 - hDia, 0, 0);
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - GameCanvas.hCommand - hDia / 2;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		setPosCmdNew(0);
	}

	public void setinfoQuestRead(MainQuest quest)
	{
		beginDia();
		hSpe = 2;
		status = quest.name;
		this.quest = quest;
		isSpec = true;
		wStatus = mFont.tahoma_7b_white.getWidth(status) + 20;
		isWaiting = false;
		type = 1;
		sizeButtonQuest = 2;
		wDia = GameCanvas.w / 5 * 4;
		if (wDia > 200)
		{
			wDia = 200;
		}
		iCommand o = new iCommand(T.viewMap, 3);
		cmdList.addElement(o);
		cmdList.addElement(cmdCancleQuest);
		cmdList.addElement(cmdClose);
		strinfo = mFont.tahoma_7_white.splitFontArray(quest.strShowDialog, wDia - 20);
		hDia = GameCanvas.hText * (strinfo.Length + 1) + hPlus + 15 + ((cmdList.size() > 2) ? (iCommand.hButtonCmd + 5) : 0);
		if (!GameCanvas.isTouch && hDia > GameCanvas.h * 6 / 7)
		{
			hDia = GameCanvas.h * 6 / 7;
		}
		cameraDia.setAll(0, GameCanvas.hText * (strinfo.Length + 1) + 45 - hDia + iCommand.hButtonCmd * sizeButtonQuest, 0, 0);
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - hDia / 2;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		setPosCmdNew(4);
	}

	public void setinfoParty()
	{
		beginDia();
		timePaintParty = 0;
		isWaiting = false;
		isSpec = true;
		type = 2;
		hItem = GameCanvas.hCommand + 5;
		wDia = GameCanvas.w / 4 * 3;
		if (wDia > 180)
		{
			wDia = 180;
		}
		if (Player.party != null)
		{
			maxSizeParty = Player.party.vecPartys.size();
		}
		else
		{
			maxSizeParty = 0;
		}
		hDia = hItem * maxSizeParty + hPlus - 10 + GameCanvas.hCommand;
		iCommand o = new iCommand(T.giaotiep, 4);
		cmdchucnang = new iCommand(T.chucnang, 8);
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - GameCanvas.hCommand - hDia / 2 + (GameCanvas.isTouch ? GameCanvas.hCommand : 0);
		iCommand iCommand2 = cmdClose;
		if (GameCanvas.isTouch)
		{
			cmdList.addElement(cmdchucnang);
			setPosCmdNew(4);
			iCommand2.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			cmdList.addElement(iCommand2);
		}
		else
		{
			cmdList.addElement(cmdchucnang);
			cmdList.addElement(o);
			setPosCmdNew(0);
			right = iCommand2;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
	}

	public void setinfoAutoHP_MP()
	{
		beginDia();
		timePaintParty = 0;
		isWaiting = false;
		isSpec = false;
		type = 4;
		hItem = GameCanvas.hCommand;
		wDia = GameCanvas.w;
		if (wDia > 220)
		{
			wDia = 220;
		}
		hDia = hItem * 3 + hPlus + GameCanvas.hCommand - 5;
		if (!GameCanvas.isTouch)
		{
			hDia -= iCommand.hButtonCmd;
		}
		iCommand iCommand2 = new iCommand("Ok", 5);
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - GameCanvas.hCommand - hDia / 2;
		iCommand iCommand3 = cmdClose;
		if (GameCanvas.isTouch)
		{
			iCommand3.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			cmdList.addElement(iCommand3);
			iCommand2.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd + 7 - hSpe, null, iCommand2.caption);
			cmdList.addElement(iCommand2);
		}
		else
		{
			right = iCommand3;
			left = iCommand2;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
	}

	public void setinfoAutoGetItem()
	{
		beginDia();
		timePaintParty = 0;
		isWaiting = false;
		isSpec = false;
		type = 7;
		hItem = GameCanvas.hCommand;
		wDia = GameCanvas.w;
		if (wDia > 220)
		{
			wDia = 220;
		}
		hDia = hItem * 3 + hPlus - 5 + GameCanvas.hCommand;
		if (!GameCanvas.isTouch)
		{
			hDia -= iCommand.hButtonCmd;
		}
		iCommand iCommand2 = new iCommand("Ok", 9);
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - GameCanvas.hCommand - hDia / 2;
		iCommand iCommand3 = cmdClose;
		if (GameCanvas.isTouch)
		{
			iCommand3.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			cmdList.addElement(iCommand3);
			iCommand2.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd + 7 - hSpe, null, iCommand2.caption);
			cmdList.addElement(iCommand2);
		}
		else
		{
			right = iCommand3;
			left = iCommand2;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
	}

	public void setinfoVolume()
	{
		beginDia();
		timePaintParty = 0;
		isWaiting = false;
		isSpec = false;
		type = 13;
		hItem = GameCanvas.hCommand;
		wDia = GameCanvas.w;
		if (wDia > 180)
		{
			wDia = 180;
		}
		hDia = hItem * 2 + hPlus - 5 + GameCanvas.hCommand;
		if (!GameCanvas.isTouch)
		{
			hDia -= iCommand.hButtonCmd;
		}
		iCommand iCommand2 = new iCommand("Ok", 11);
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - hDia / 2;
		iCommand iCommand3 = cmdClose;
		if (GameCanvas.isTouch)
		{
			iCommand3.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			cmdList.addElement(iCommand3);
			iCommand2.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd + 7 - hSpe, null, iCommand2.caption);
			cmdList.addElement(iCommand2);
		}
		else
		{
			right = iCommand3;
			left = iCommand2;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
	}

	public void setDiaHelp(string info, iCommand cmd, int x, int y, int archor, bool isCamera, int w)
	{
		beginDia();
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		isWaiting = false;
		isSpec = false;
		type = 5;
		wDia = w;
		cmdHelp = cmd;
		cmdList = new mVector("MsgChat cmdlist");
		cmdHelp.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2, null, cmdHelp.caption);
		cmdList.addElement(cmdHelp);
		strinfo = mFont.tahoma_7_white.splitFontArray(info, wDia - 4);
		hDia = GameCanvas.hText * strinfo.Length;
		xDia = x;
		yDia = y;
		if (archor == 5 || archor == 3 || archor == 4 || archor == 6)
		{
			yDia += hDia;
		}
		if (archor == 8)
		{
			xDia -= wDia;
		}
		this.archor = archor;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
	}

	public void setinfoSHOW(string info, iCommand cmd, bool isOnlyCenter, string nameShow)
	{
		beginDia();
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.nameShow = nameShow;
		isWaiting = false;
		isSpec = false;
		type = 6;
		wDia = GameCanvas.w - 30;
		if (wDia > 200)
		{
			wDia = 200;
		}
		cmdList = new mVector("MsgChat cmdlist4");
		cmdList.addElement(cmd);
		if (!isOnlyCenter)
		{
			cmdList.addElement(cmdClose);
		}
		int num = cmdList.size();
		if (wDia < num * iCommand.wButtonCmd + (num - 1) * 10 + 10)
		{
			wDia = num * iCommand.wButtonCmd + (num - 1) * 10 + 10;
		}
		if (wDia > GameCanvas.w)
		{
			wDia = GameCanvas.w;
		}
		strinfo = mFont.tahoma_7_white.splitFontArray(info, wDia - 20);
		hDia = GameCanvas.hText * (strinfo.Length + 1) + iCommand.hButtonCmd + 20;
		if (hDia > GameCanvas.h - GameCanvas.hCommand)
		{
			hDia = GameCanvas.h - GameCanvas.hCommand;
			xDia = GameCanvas.hw - wDia / 2;
			yDia = GameCanvas.hh - hDia / 2;
			list = new ListNew(xDia, yDia, wDia, hDia, 0, 0, GameCanvas.hText * (strinfo.Length + 1) + iCommand.hButtonCmd + 20 - hDia);
		}
		else
		{
			xDia = GameCanvas.hw - wDia / 2;
			yDia = GameCanvas.hh - hDia / 2;
			list = new ListNew(xDia, yDia, wDia, hDia, 0, 0, 0);
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		setPosCmdNew(GameCanvas.isTouch ? 4 : 0);
	}

	public void setInfoAutoBuff()
	{
		beginDia();
		timePaintParty = 0;
		isWaiting = false;
		isSpec = false;
		type = 8;
		hItem = GameCanvas.hCommand;
		wDia = MaxSkillBuff * 60;
		if (wDia > 220)
		{
			wDia = 220;
		}
		wbuff = wDia / MaxSkillBuff;
		hDia = hItem * 2 + GameCanvas.hCommand;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - GameCanvas.hCommand - hDia / 2;
		if (GameCanvas.isTouch)
		{
			cmdClose.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			cmdList.addElement(cmdClose);
		}
		else
		{
			iCommand iCommand2 = new iCommand(T.select, 10);
			left = iCommand2;
			right = cmdClose;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
	}

	public void setInfoTime(string info, short time)
	{
		beginDia();
		isWaiting = false;
		isSpec = false;
		type = 9;
		timeDia = time;
		timeset = GameCanvas.timeNow;
		wDia = GameCanvas.w - 30;
		if (wDia > 200)
		{
			wDia = 200;
		}
		cmdList = new mVector("MsgChat cmdlist5");
		cmdList.addElement(cmdClose);
		strinfo = fontDia.splitFontArray(info, wDia - 20);
		hDia = 15 * strinfo.Length + hPlus + hWait;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia - 5;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		setPosCmdNew(0);
	}

	public void setShowChangeItem(string nameDia, string info, MainItem[] datanguyenlieu, MainItem sanpham)
	{
		TabRebuildItem.vecEffRe.removeAllElements();
		beginDia();
		isWaiting = false;
		isSpec = false;
		nameShow = nameDia;
		this.datanguyenlieu = datanguyenlieu;
		this.sanpham = sanpham;
		StepShow = 0;
		timeShow = 0;
		type = 10;
		wDia = GameCanvas.w - 30;
		if (wDia > 240)
		{
			wDia = 240;
		}
		cmdList = new mVector("MsgDiaLog cmdList2");
		strinfo = fontDia.splitFontArray(info, wDia - 20);
		hDia = 15 * strinfo.Length + hPlus + 50;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - hDia / 2;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		posItemNguyenlieu = mSystem.new_M_Int(datanguyenlieu.Length + 1, 2);
		int num = 0;
		if (datanguyenlieu.Length > 4)
		{
			num = 30;
		}
		else if (datanguyenlieu.Length > 2)
		{
			num = 15;
		}
		for (int i = 0; i < posItemNguyenlieu.Length; i++)
		{
			if (i == posItemNguyenlieu.Length - 1)
			{
				posItemNguyenlieu[i][0] = xDia + wDia / 2;
				posItemNguyenlieu[i][1] = yDia + hDia - GameCanvas.hCommand - 35;
			}
			else
			{
				posItemNguyenlieu[i][0] = xDia + wDia / 6 + i % 2 * (wDia / 3) * 2;
				posItemNguyenlieu[i][1] = yDia + hDia - GameCanvas.hCommand - 35 + num - i / 2 * 30;
				TabRebuildItem.addEffectEnd_ReBuild_ss(34, posItemNguyenlieu[i][0], posItemNguyenlieu[i][1]);
			}
		}
	}

	public void setShowOpenBox(string nameDia, MainItem[] itemsanpham, string info, sbyte isFullEff, sbyte isLottery)
	{
		TabRebuildItem.vecEffRe.removeAllElements();
		beginDia();
		isWaiting = false;
		isSpec = false;
		this.isLottery = isLottery;
		this.isFullEff = isFullEff;
		nameShow = nameDia;
		this.itemsanpham = itemsanpham;
		StepShow = 0;
		timeShow = 0;
		indexShow1 = 0;
		indexShow2 = 0;
		type = 11;
		wDia = GameCanvas.w - 30;
		if (wDia > 240)
		{
			wDia = 240;
		}
		if (info != null)
		{
			strinfo = fontDia.splitFontArray(info, wDia - 20);
		}
		else
		{
			strinfo = null;
		}
		cmdList = new mVector("MsgDiaLog cmdList3");
		hDia = hPlus + 60;
		if (strinfo != null)
		{
			hDia += strinfo.Length * GameCanvas.hText;
		}
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - hDia / 2;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		wsizeBox = 55;
		if (wsizeBox * (itemsanpham.Length - 1) > wDia - 30)
		{
			wsizeBox = 30;
		}
		int num = 0;
		if (itemsanpham.Length % 2 == 0)
		{
			num = wsizeBox / 2;
		}
		num += (itemsanpham.Length - 1) / 2 * wsizeBox;
		posItemNguyenlieu = new int[this.itemsanpham.Length][];
		for (int i = 0; i < posItemNguyenlieu.Length; i++)
		{
			posItemNguyenlieu[i] = new int[2];
		}
		for (int j = 0; j < posItemNguyenlieu.Length; j++)
		{
			posItemNguyenlieu[j][0] = xDia + wDia / 2 - num + j * wsizeBox;
			posItemNguyenlieu[j][1] = yDia + hDia - GameCanvas.hCommand - 45;
		}
	}

	public void setUpdateData()
	{
		nameShow = T.update;
		curupdate = 0;
		maxupdate = 20;
		beginDia();
		isWaiting = false;
		isSpec = false;
		type = 12;
		wDia = GameCanvas.w - 30;
		if (wDia > 240)
		{
			wDia = 240;
		}
		wUpdate = wDia / 4 * 3;
		hUpdate = 16;
		cmdList = new mVector("MsgDiaLog cmdList4");
		strinfo = fontDia.splitFontArray(T.updateData, wDia - 20);
		hDia = 30 + hPlus;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - hDia / 2;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
	}

	public void setPetInfo(PetItem pet, sbyte typeInven_Equip)
	{
		if (typeInven_Equip != -1)
		{
			isInven_Equip = typeInven_Equip;
		}
		MsgDialog.pet = pet;
		nameShow = pet.itemName;
		hItem = GameCanvas.hText;
		beginDia();
		isWaiting = false;
		isSpec = false;
		type = 14;
		wDia = GameCanvas.w - 30;
		hUpdate = 8;
		if (wDia > 200)
		{
			wDia = 200;
		}
		wUpdate = wDia / 2;
		cmdPet = new iCommand(T.choan, 16, this);
		cmdList = new mVector("MsgDiaLog cmdList");
		cmdList.addElement(cmdPet);
		int num = (7 + pet.mcontent.Length) * GameCanvas.hText + hPlus + 10;
		if (num > GameCanvas.h - GameCanvas.hCommand * 2)
		{
			hDia = GameCanvas.h - GameCanvas.hCommand * 2;
			xDia = GameCanvas.hw - wDia / 2;
			yDia = GameCanvas.hh - hDia / 2;
			list = new ListNew(xDia, yDia, wDia, hDia, 0, 0, num - hDia);
		}
		else
		{
			hDia = num;
			xDia = GameCanvas.hw - wDia / 2;
			yDia = GameCanvas.hh - hDia / 2;
			list = new ListNew(xDia, yDia, wDia, hDia, 0, 0, 0);
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		if (GameCanvas.isTouch)
		{
			setPosCmdNew(4);
		}
		cmdList.addElement(cmdClose);
		if (GameCanvas.isTouch)
		{
			cmdClose.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
		else
		{
			setPosCmdNew(0);
		}
	}

	public void setPosCmdNew(int yplus)
	{
		idCommand = 0;
		if (cmdList.size() <= 0)
		{
			return;
		}
		int num = cmdList.size();
		switch (num)
		{
		case 1:
			xBegin = xDia + wDia / 2;
			w2cmd = 0;
			break;
		case 2:
			w2cmd = 10;
			xBegin = xDia + wDia / 2 - w2cmd / 2 - iCommand.wButtonCmd / 2;
			break;
		default:
			w2cmd = 10;
			xBegin = xDia + wDia / 2 - w2cmd / 2 - iCommand.wButtonCmd / 2;
			break;
		}
		for (int i = 0; i < num; i++)
		{
			iCommand iCommand2 = (iCommand)cmdList.elementAt(i);
			iCommand2.isSelect = false;
			if (num == 3 && i == 2)
			{
				iCommand2.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 - hSpe + i / 2 * (iCommand.hButtonCmd + 5) - (isSpec ? 4 : 0) + yplus, null, iCommand2.caption);
			}
			else
			{
				iCommand2.setPos(xBegin + i % 2 * (iCommand.wButtonCmd + w2cmd), yDia + hDia - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 - hSpe + i / 2 * (iCommand.hButtonCmd + 5) - (isSpec ? 4 : 0) + yplus, null, iCommand2.caption);
			}
			if (i == 0)
			{
				iCommand2.isSelect = true;
			}
		}
	}

	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		switch (type)
		{
		case 0:
		{
			AvMain.paintDialog(g, xDia, yDia, wDia, hDia, 12);
			for (int l = 0; l < strinfo.Length; l++)
			{
				fontDia.drawString(g, strinfo[l], GameCanvas.w / 2, yDia + 12 + l * 15, 2, mGraphics.isTrue);
			}
			if (isWaiting)
			{
				fraWaiting.drawFrame(fWait % fraWaiting.nFrame, GameCanvas.hw, yDia + 25 + strinfo.Length * 15, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			break;
		}
		case 1:
		{
			AvMain.paintTabNew(g, xDia, yDia, wDia, hDia, ismore: true, 0);
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, GameCanvas.hw - 32, yDia + 11, 64, 14, 2);
			}
			else
			{
				for (int num21 = 0; num21 < 2; num21++)
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 32, 14, 0, GameCanvas.hw - 32 + num21 * 32, yDia + 11, 0, mGraphics.isTrue);
				}
			}
			mFont.tahoma_7b_white.drawString(g, T.quest, GameCanvas.hw, yDia + 12, 2, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, status, xDia + 10, yDia + 27, 0, mGraphics.isTrue);
			g.setClip(xDia + 3, yDia + 39, wDia - 6, hDia - 55 - iCommand.hButtonCmd * sizeButtonQuest);
			g.translate(0, -cameraDia.yCam);
			for (int num22 = 0; num22 < strinfo.Length; num22++)
			{
				mFont.tahoma_7_black.drawString(g, strinfo[num22], xDia + 11, yDia + 27 + (num22 + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
			}
			break;
		}
		case 2:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, T.party);
			int num7 = yDia + GameCanvas.hCommand + 3;
			int num26 = 2;
			if (Player.party != null)
			{
				if (!GameCanvas.isTouch || timePaintParty > 0)
				{
					g.setColor(11904141);
					g.fillRect(xDia + 9, num7 - 2 + idSelect * hItem, wDia - 17, hItem - 1, mGraphics.isTrue);
				}
				if (Player.party != null)
				{
					for (int num27 = 0; num27 < Player.party.vecPartys.size(); num27++)
					{
						ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(num27);
						if (objectParty.name.CompareTo(Player.party.nameMain) == 0)
						{
							AvMain.Font3dColorAndColor(g, objectParty.name + " " + T.Lv + objectParty.Lv, xDia + 11, num7, 0, 7, 0);
						}
						else
						{
							mFont.tahoma_7b_white.drawString(g, objectParty.name + " " + T.Lv + objectParty.Lv, xDia + 11, num7, 0, mGraphics.isTrue);
						}
						if (objectParty.name.CompareTo(GameScreen.player.name) == 0)
						{
							objectParty.hp = GameScreen.player.hp;
							objectParty.maxhp = GameScreen.player.maxHp;
						}
						g.setColor(0);
						g.fillRect(xDia + 11, num7 + 14 - num26, 42, 4, mGraphics.isTrue);
						g.setColor(8062494);
						g.fillRect(xDia + 12, num7 + 15 - num26, 40, 2, mGraphics.isTrue);
						g.setColor(16197705);
						g.fillRect(xDia + 12, num7 + 15 - num26, 40 * objectParty.hp / objectParty.maxhp, 2, mGraphics.isTrue);
						string text = "map";
						if (WorldMapScreen.namePos != null && objectParty.idMap < WorldMapScreen.namePos.Length)
						{
							text = WorldMapScreen.namePos[objectParty.idMap];
						}
						mFont.tahoma_7_white.drawString(g, text + " - " + T.Area + (objectParty.idArea + 1), xDia + 11, num7 + 20 - num26 * 2, 0, mGraphics.isTrue);
						num7 += hItem;
						if (num27 < Player.party.vecPartys.size() - 1)
						{
							g.setColor(AvMain.color[4]);
							g.fillRect(xDia + 12, num7 - 3, wDia - 24, 1, mGraphics.isTrue);
						}
					}
				}
			}
			else
			{
				mFont.tahoma_7_black.drawString(g, T.noParty, xDia + wDia / 2, num7, 2, mGraphics.isTrue);
			}
			base.paint(g);
			break;
		}
		case 4:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, T.auto);
			int num23 = yDia + hItem + 11;
			int num24 = xDia + 30 - (GameCanvas.isTouch ? 10 : 0);
			g.setColor(MainTabNew.color[0]);
			for (int num25 = 0; num25 < T.mAuto.Length; num25++)
			{
				mFont.tahoma_7_white.drawString(g, T.mAuto[num25], num24, num23, 0, mGraphics.isTrue);
				int width3 = mFont.tahoma_7_black.getWidth(T.mAuto[0]);
				g.fillRect(num24 + width3, num23 - 3, 35, 18, mGraphics.isTrue);
				mFont.tahoma_7_white.drawString(g, "   " + mHPMP[num25] + "     %", num24 + 3 + width3, num23, 0, mGraphics.isTrue);
				num23 += hItem;
			}
			mFont.tahoma_7_white.drawString(g, T.mUtien[isUutien], num24, num23, 0, mGraphics.isTrue);
			if (!GameCanvas.isTouch)
			{
				g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num24 - 4 + GameCanvas.gameTick % 3, yDia + hItem + 17 + idSelect * hItem, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isTrue);
			}
			GameCanvas.resetTrans(g);
			paintCmd(g);
			break;
		}
		case 5:
			MainHelp.paintPopup(g, xDia, yDia, wDia, hDia, archor, strinfo);
			break;
		case 6:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, nameShow);
			g.setClip(xDia, yDia + GameCanvas.hCommand + 2, wDia, hDia - GameCanvas.hCommand - iCommand.hButtonCmd - 8);
			g.translate(0, -list.cmx);
			for (int m = 0; m < strinfo.Length; m++)
			{
				mFont.tahoma_7_white.drawString(g, strinfo[m], xDia + 8, yDia + GameCanvas.hCommand + 2 + m * GameCanvas.hText, 0, mGraphics.isTrue);
			}
			break;
		}
		case 7:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, T.auto);
			int num11 = yDia + hItem + 11;
			int num12 = xDia + 30 - (GameCanvas.isTouch ? 10 : 0);
			g.setColor(MainTabNew.color[3]);
			for (int n = 0; n < T.mAutoItem.Length; n++)
			{
				mFont.tahoma_7b_white.drawString(g, T.mAutoItem[n], num12, num11, 0, mGraphics.isTrue);
				int width = mFont.tahoma_7b_white.getWidth(T.mAutoItem[n]);
				mFont.tahoma_7_white.drawString(g, "< " + T.mValueAutoItem[n][mvalueItem[n]] + " >", num12 + 3 + width, num11, 0, mGraphics.isTrue);
				num11 += hItem;
			}
			if (!GameCanvas.isTouch)
			{
				g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num12 - 4 + GameCanvas.gameTick % 3, yDia + hItem + 17 + idSelect * hItem, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isTrue);
			}
			GameCanvas.resetTrans(g);
			paintCmd(g);
			break;
		}
		case 8:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, T.auto);
			int num28 = yDia + GameCanvas.hCommand + hItem;
			int num29 = xDia + wbuff / 2;
			if (!GameCanvas.isTouch)
			{
				g.setColor(15722248);
				g.fillRect(num29 - 12 + idSelect * wbuff, num28 - 12, 24, 24, mGraphics.isTrue);
			}
			for (int num30 = 0; num30 < MaxSkillBuff; num30++)
			{
				Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(Autobuff[num30][2]);
				skill.paint(g, num29, num28, 3);
				if (Autobuff[num30][1] == 0)
				{
					g.drawRegion(AvMain.imgDelaySkill, 0, 0, 20, 20, 0, num29, num28, 3, mGraphics.isTrue);
				}
				num29 += wbuff;
			}
			GameCanvas.resetTrans(g);
			paintCmd(g);
			break;
		}
		case 9:
		{
			AvMain.paintDialog(g, xDia, yDia, wDia, hDia, 12);
			for (int num31 = 0; num31 < strinfo.Length; num31++)
			{
				if (num31 == strinfo.Length - 1)
				{
					fontDia.drawString(g, strinfo[num31] + " " + timeDia + "'.", GameCanvas.w / 2, yDia + 12 + num31 * 15, 2, mGraphics.isTrue);
				}
				else
				{
					fontDia.drawString(g, strinfo[num31], GameCanvas.w / 2, yDia + 12 + num31 * 15, 2, mGraphics.isTrue);
				}
			}
			break;
		}
		case 10:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, nameShow);
			if (StepShow < 2)
			{
				for (int num16 = 0; num16 < posItemNguyenlieu.Length; num16++)
				{
					g.drawImage(AvMain.imgHotKey, posItemNguyenlieu[num16][0], posItemNguyenlieu[num16][1], 3, mGraphics.isTrue);
				}
				if (StepShow == 0)
				{
					for (int num17 = 0; num17 < datanguyenlieu.Length; num17++)
					{
						if (timeShow >= 4 && datanguyenlieu[num17] != null)
						{
							datanguyenlieu[num17].paintItem(g, posItemNguyenlieu[num17][0], posItemNguyenlieu[num17][1], 21, 1, 0);
						}
					}
				}
			}
			else if (StepShow == 2)
			{
				for (int num18 = 0; num18 < strinfo.Length; num18++)
				{
					mFont.tahoma_7_white.drawString(g, strinfo[num18], xDia + 8, yDia + GameCanvas.hCommand + 2 + num18 * GameCanvas.hText, 0, mGraphics.isTrue);
				}
				int num19 = posItemNguyenlieu.Length - 1;
				if (sanpham != null)
				{
					sanpham.paintItem(g, posItemNguyenlieu[num19][0], posItemNguyenlieu[num19][1], 21, 1, 0);
				}
				g.drawImage(AvMain.imgHotKey, posItemNguyenlieu[num19][0], posItemNguyenlieu[num19][1], 3, mGraphics.isTrue);
			}
			for (int num20 = 0; num20 < TabRebuildItem.vecEffRe.size(); num20++)
			{
				MainEffect mainEffect = (MainEffect)TabRebuildItem.vecEffRe.elementAt(num20);
				mainEffect.paint(g);
			}
			break;
		}
		case 11:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, nameShow);
			if (strinfo != null)
			{
				for (int num32 = 0; num32 < strinfo.Length; num32++)
				{
					mFont.tahoma_7_white.drawString(g, strinfo[num32], xDia + 8, yDia + GameCanvas.hCommand + 2 + num32 * GameCanvas.hText, 0, mGraphics.isTrue);
				}
			}
			for (int num33 = 0; num33 < posItemNguyenlieu.Length; num33++)
			{
				if (indexShow1 == -1 || num33 <= indexShow1)
				{
					g.drawImage(AvMain.imgHotKey, posItemNguyenlieu[num33][0], posItemNguyenlieu[num33][1], 3, mGraphics.isTrue);
				}
			}
			for (int num34 = 0; num34 < itemsanpham.Length; num34++)
			{
				if (itemsanpham[num34].canSell != 0)
				{
					itemsanpham[num34].paintItem(g, posItemNguyenlieu[num34][0], posItemNguyenlieu[num34][1], 21, 1, 0);
					if (itemsanpham[num34].ItemCatagory == 3)
					{
						MainTabNew.setTextColorName(itemsanpham[num34].colorNameItem).drawString(g, itemsanpham[num34].itemName, posItemNguyenlieu[num34][0], posItemNguyenlieu[num34][1] + 14, 2, mGraphics.isTrue);
					}
				}
			}
			for (int num35 = 0; num35 < TabRebuildItem.vecEffRe.size(); num35++)
			{
				MainEffect mainEffect2 = (MainEffect)TabRebuildItem.vecEffRe.elementAt(num35);
				mainEffect2.paint(g);
			}
			break;
		}
		case 12:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, nameShow);
			for (int k = 0; k < strinfo.Length; k++)
			{
				mFont.tahoma_7_white.drawString(g, strinfo[k], xDia + 8, yDia + GameCanvas.hCommand + 4 + k * GameCanvas.hText, 0, mGraphics.isTrue);
			}
			int num5 = xDia + wDia / 2 - wUpdate / 2;
			int num6 = hUpdate - 10;
			int num7 = yDia + hDia - num6 - 25;
			int num8 = num7 - 5;
			g.setColor(2698542);
			g.fillRect(num5 - 4, num8 + 15, wUpdate + 2, num6, mGraphics.isTrue);
			g.fillRect(num5 - 4 + 1, num8 + 14, wUpdate, 1, mGraphics.isTrue);
			g.fillRect(num5 - 4 + 1, num8 + 15 + num6, wUpdate, 1, mGraphics.isTrue);
			g.setColor(3027507);
			g.fillRect(num5 - 4 + 1, num8 + 15, wUpdate, num6, mGraphics.isTrue);
			int num9 = 0;
			if (maxupdate > 0 && curupdate > 0)
			{
				num9 = curupdate * wUpdate / maxupdate;
				if (num9 <= 0)
				{
					num9 = 1;
				}
				else if (num9 > wUpdate)
				{
					num9 = wUpdate;
				}
				g.setColor(10339648);
				g.fillRect(num5 - 4 + 1, num8 + 15, num9, num6, mGraphics.isTrue);
			}
			int num10 = curupdate * 100 / maxupdate;
			mFont.tahoma_7b_white.drawString(g, num10 + "%", xDia + wDia / 2, num8, 2, mGraphics.isTrue);
			break;
		}
		case 13:
		{
			paintFormList(g, xDia, yDia, wDia, hDia, T.SetMusic);
			int num13 = yDia + hItem + 11;
			int num14 = xDia + 30 - (GameCanvas.isTouch ? 10 : 0);
			g.setColor(MainTabNew.color[3]);
			for (int num15 = 0; num15 < T.mVolume.Length; num15++)
			{
				mFont.tahoma_7b_white.drawString(g, T.mVolume[num15], num14, num13, 0, mGraphics.isTrue);
				int width2 = mFont.tahoma_7b_white.getWidth(T.mVolume[num15]);
				mFont.tahoma_7_white.drawString(g, "< " + ((mvalueVolume[num15] != 0) ? T.off : T.on) + " >", num14 + 3 + width2, num13, 0, mGraphics.isTrue);
				num13 += hItem;
			}
			if (!GameCanvas.isTouch)
			{
				g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num14 - 4 + GameCanvas.gameTick % 3, yDia + hItem + 17 + idSelect * hItem, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isTrue);
			}
			GameCanvas.resetTrans(g);
			paintCmd(g);
			break;
		}
		case 14:
		{
			if (pet == null)
			{
				return;
			}
			paintFormList(g, xDia, yDia, wDia, hDia, nameShow);
			int num = yDia + hItem * 2;
			int num2 = xDia + 10;
			g.setClip(xDia, yDia + GameCanvas.hCommand + 2, wDia, hDia - GameCanvas.hCommand - iCommand.hButtonCmd - 8);
			g.translate(0, -list.cmx);
			pet.paintShowPet(g, num2 + MainTabNew.wOneItem / 2, num + MainTabNew.wOneItem / 2 + MainTabNew.wOneItem / 4, MainTabNew.wOneItem, MainTabNew.wOneItem / 2, 0, 1);
			mFont.tahoma_7_white.drawString(g, T.level + pet.LvItem + " + " + pet.experience / 10 + "," + pet.experience % 10 + "%", num2 + 40, num, 0, mGraphics.isTrue);
			num += GameCanvas.hText;
			int num3 = pet.age / 24;
			int num4 = pet.age % 24;
			mFont.tahoma_7_white.drawString(g, T.tuoi + num3 + "d " + num4 + "h", num2 + 40, num, 0, mGraphics.isTrue);
			num += GameCanvas.hText;
			MainTabNew.setTextColor(Item.colorInfoItem[pet.petAttack.id]).drawString(g, Item.nameInfoItem[pet.petAttack.id] + ": " + pet.petAttack.value + "-" + pet.petAttack.maxDam, num2 + 40, num, 0, mGraphics.isTrue);
			num += hItem;
			mFont.tahoma_7_white.drawString(g, T.choan, num2 + 8, num, 0, mGraphics.isTrue);
			paintStatus(g, pet.growpoint, num2 + 65, num + 1, pet.maxgrow);
			num += hItem;
			for (int i = 0; i < T.mKynangPet.Length; i++)
			{
				mFont.tahoma_7_white.drawString(g, T.mKynangPet[i], num2 + 8, num, 0, mGraphics.isTrue);
				paintStatus(g, pet.mvaluetiemnang[i], num2 + 65, num + 1, pet.maxtiemnang);
				num += hItem;
			}
			for (int j = 0; j < pet.mInfo.Length; j++)
			{
				if (pet.mInfo[j].id > 6)
				{
					string st = Item.nameInfoItem[pet.mInfo[j].id] + ": " + Item.getPercent(Item.isPercentInfoItem[pet.mInfo[j].id], pet.mInfo[j].value);
					MainTabNew.setTextColor(Item.colorInfoItem[pet.mInfo[j].id]).drawString(g, st, num2 + 8, num, 0, mGraphics.isTrue);
					num += hItem;
				}
			}
			GameCanvas.resetTrans(g);
			paintCmd(g);
			break;
		}
		}
		GameCanvas.resetTrans(g);
		if (cmdList != null)
		{
			for (int num36 = 0; num36 < cmdList.size(); num36++)
			{
				iCommand iCommand2 = (iCommand)cmdList.elementAt(num36);
				iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
			}
		}
	}

	public void paintStatus(mGraphics g, int cur, int xp, int yp, int max)
	{
		g.setColor(2698542);
		g.fillRect(xp - 4, yp + 1, wUpdate + 2, hUpdate, mGraphics.isTrue);
		g.fillRect(xp - 4 + 1, yp, wUpdate, 1, mGraphics.isTrue);
		g.fillRect(xp - 4 + 1, yp + 1 + hUpdate, wUpdate, 1, mGraphics.isTrue);
		g.setColor(3027507);
		g.fillRect(xp - 4 + 1, yp + 1, wUpdate, hUpdate, mGraphics.isTrue);
		int num = 0;
		if (cur * 100 / max > 0)
		{
			num = cur * 100 / max * wUpdate / 100;
			if (num <= 0)
			{
				num = 1;
			}
			else if (num > wUpdate)
			{
				num = wUpdate;
			}
			g.setColor(10339648);
			g.fillRect(xp - 4 + 1, yp + 1, num, hUpdate, mGraphics.isTrue);
		}
		mFont.tahoma_7b_white.drawString(g, cur + string.Empty, xp + wUpdate / 2, yp, 2, mGraphics.isTrue);
	}

	public void paintCommand()
	{
	}

	public override void update()
	{
		if (isWaiting)
		{
			fWait++;
			if (fWait > 1200)
			{
				if (Session_ME.gI().isConnected() && GameCanvas.currentScreen != GameCanvas.login && GameCanvas.currentScreen != GameCanvas.load)
				{
					GameCanvas.start_Ok_Dialog(T.thulai);
				}
				else
				{
					mVector mVector3 = new mVector("MsgDiaLog vec");
					if (SelectCharScreen.isSelectOk && GameCanvas.currentScreen != GameCanvas.login)
					{
						mVector3.addElement(new iCommand(T.again, 0));
					}
					mVector3.addElement(new iCommand(T.exit, 6));
					GameCanvas.start_Select_Dialog(T.disconnect, mVector3);
					GlobalLogicHandler.isDisConect = true;
					GlobalLogicHandler.timeReconnect = mSystem.currentTimeMillis() + 30000;
				}
			}
		}
		if (type == 6 || type == 14)
		{
			list.moveCamera();
		}
		if (GlobalLogicHandler.isDisConect && GlobalLogicHandler.timeReconnect - mSystem.currentTimeMillis() <= 0)
		{
			relogin();
		}
		updatekey();
		updatePointer();
		if (type == 2)
		{
			if (Player.party != null)
			{
				if (Player.party.vecPartys.size() != maxSizeParty || maxSizeParty == -1)
				{
					maxSizeParty = Player.party.vecPartys.size();
					hDia = hItem * maxSizeParty + hPlus - 10 + GameCanvas.hCommand;
					yDia = GameCanvas.hh - GameCanvas.hCommand - hDia / 2 + (GameCanvas.isTouch ? GameCanvas.hCommand : 0);
					numh = (hDia - 6) / 32;
					cmdList.removeAllElements();
					iCommand o = new iCommand(T.giaotiep, 4);
					cmdchucnang = new iCommand(T.leave, 8);
					if (GameScreen.player.name.CompareTo(Player.party.nameMain) == 0)
					{
						cmdchucnang.caption = T.chucnang;
					}
					iCommand iCommand2 = cmdClose;
					if (GameCanvas.isTouch)
					{
						cmdList.addElement(cmdchucnang);
						setPosCmdNew(4);
						iCommand2.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
						cmdList.addElement(iCommand2);
					}
					else
					{
						cmdList.addElement(cmdchucnang);
						cmdList.addElement(o);
						setPosCmdNew(4);
						right = iCommand2;
					}
				}
				if (timePaintParty > 0)
				{
					timePaintParty--;
				}
			}
			else
			{
				cmdList.removeAllElements();
				iCommand iCommand3 = cmdClose;
				if (GameCanvas.isTouch)
				{
					iCommand3.setPos(xDia + wDia - 6, yDia + 4, PaintInfoGameScreen.fraCloseMenu, string.Empty);
					cmdList.addElement(iCommand3);
				}
				else
				{
					right = iCommand3;
				}
			}
		}
		else if (type == 3 || type == 6 || type == 14)
		{
			cameraDia.UpdateCamera();
		}
		else if (type == 9)
		{
			if ((GameCanvas.timeNow - timeset) / 1000 > 1)
			{
				timeset += 1000L;
				timeDia--;
				if (timeDia <= 0)
				{
					cmdClose.perform();
				}
			}
		}
		else if (type == 10)
		{
			timeShow++;
			if (StepShow == 0)
			{
				if (timeShow == 30)
				{
					timeShow = 0;
					StepShow = 1;
				}
			}
			else if (StepShow == 1)
			{
				if (timeShow == 1)
				{
					mSound.playSound(29, mSound.volumeSound);
					for (int i = 0; i < posItemNguyenlieu.Length - 1; i++)
					{
						TabRebuildItem.addEffectEndRebuild(41, posItemNguyenlieu[i][0], posItemNguyenlieu[i][1], posItemNguyenlieu[posItemNguyenlieu.Length - 1][0], posItemNguyenlieu[posItemNguyenlieu.Length - 1][1], 1);
					}
				}
				if (timeShow >= 16)
				{
					mSound.playSound(26, mSound.volumeSound);
					StepShow = 2;
					timeShow = 0;
					cmdList.addElement(cmdClose);
					setPosCmdNew(0);
					TabRebuildItem.addEffectEnd_ReBuild_ss(33, posItemNguyenlieu[posItemNguyenlieu.Length - 1][0], posItemNguyenlieu[posItemNguyenlieu.Length - 1][1]);
					TabRebuildItem.addEffectEnd_ReBuild_ss(34, posItemNguyenlieu[posItemNguyenlieu.Length - 1][0], posItemNguyenlieu[posItemNguyenlieu.Length - 1][1]);
				}
			}
			else if (StepShow != 2)
			{
			}
			for (int j = 0; j < TabRebuildItem.vecEffRe.size(); j++)
			{
				MainEffect mainEffect = (MainEffect)TabRebuildItem.vecEffRe.elementAt(j);
				mainEffect.update();
				if (mainEffect.isStop)
				{
					TabRebuildItem.vecEffRe.removeElement(mainEffect);
				}
			}
		}
		else if (type == 11)
		{
			timeShow++;
			if (StepShow == 0)
			{
				if (indexShow1 >= 0 && timeShow % 5 == 1)
				{
					TabRebuildItem.addEffectEnd_ReBuild_ss(34, posItemNguyenlieu[indexShow1][0], posItemNguyenlieu[indexShow1][1]);
					if (indexShow1 < itemsanpham.Length - 1)
					{
						indexShow1++;
					}
					else
					{
						indexShow1 = -1;
					}
				}
				if (timeShow > 5 && timeShow % 5 == 1)
				{
					if (isFullEff == 0)
					{
						TabRebuildItem.addEffectEnd_ReBuild_ss(33, posItemNguyenlieu[indexShow2][0], posItemNguyenlieu[indexShow2][1]);
					}
					itemsanpham[indexShow2].canSell = 1;
					if (indexShow2 < itemsanpham.Length - 1)
					{
						indexShow2++;
						mSound.playSound(29, mSound.volumeSound);
					}
					else
					{
						mSound.playSound(29, mSound.volumeSound);
						indexShow2 = -1;
						indexShow1 = -1;
						timeShow = 0;
						StepShow = 1;
						cmdList.addElement(cmdClose);
						setPosCmdNew(0);
					}
				}
			}
			for (int k = 0; k < TabRebuildItem.vecEffRe.size(); k++)
			{
				MainEffect mainEffect2 = (MainEffect)TabRebuildItem.vecEffRe.elementAt(k);
				mainEffect2.update();
				if (mainEffect2.isStop)
				{
					TabRebuildItem.vecEffRe.removeElement(mainEffect2);
				}
			}
		}
		else
		{
			if (type != 12)
			{
				return;
			}
			if (Session_ME.gI().isConnected())
			{
				if (curupdate >= maxupdate && GameCanvas.gameTick % 40 == 20)
				{
					GameCanvas.start_Ok_Dialog(T.updateok);
				}
			}
			else
			{
				GameCanvas.start_Center_Dialog_Only(T.disconnect, new iCommand(T.exit, -1));
			}
		}
	}

	public override void updatekey()
	{
		if (type == 1)
		{
			cameraDia.UpdateCamera();
			if (GameCanvas.keyMyHold[2])
			{
				cameraDia.yTo -= GameCanvas.hText;
				if (cameraDia.yTo < 0)
				{
					cameraDia.yTo = 0;
				}
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				cameraDia.yTo += GameCanvas.hText;
				if (cameraDia.yTo > cameraDia.yLimit)
				{
					cameraDia.yTo = cameraDia.yLimit;
				}
				GameCanvas.clearKeyHold(8);
			}
		}
		else if (type == 2)
		{
			if (Player.party != null)
			{
				if (GameCanvas.keyMyHold[2])
				{
					idSelect--;
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					idSelect++;
					GameCanvas.clearKeyHold(8);
				}
				idSelect = resetSelect(idSelect, Player.party.vecPartys.size() - 1, isreset: true);
			}
			else
			{
				left = null;
			}
		}
		else if (type == 6 || type == 14)
		{
			if (GameCanvas.keyMyHold[2])
			{
				list.cmtoX -= GameCanvas.hText;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				list.cmtoX += GameCanvas.hText;
				GameCanvas.clearKeyHold(8);
			}
			if (list.cmtoX > list.cmxLim)
			{
				list.cmtoX = list.cmxLim;
			}
			if (list.cmtoX < 0)
			{
				list.cmtoX = 0;
			}
		}
		else if (type == 4)
		{
			if (GameCanvas.keyMyHold[2])
			{
				idSelect--;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				idSelect++;
				GameCanvas.clearKeyHold(8);
			}
			idSelect = resetSelect(idSelect, 2, isreset: true);
			if (GameCanvas.keyMyHold[4])
			{
				switch (idSelect)
				{
				case 0:
					if (mHPMP[0] > 10)
					{
						mHPMP[0] -= 10;
					}
					break;
				case 1:
					if (mHPMP[1] > 10)
					{
						mHPMP[1] -= 10;
					}
					break;
				case 2:
					if (isUutien == 1)
					{
						isUutien = 0;
					}
					break;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				switch (idSelect)
				{
				case 0:
					if (mHPMP[0] < 90)
					{
						mHPMP[0] += 10;
					}
					break;
				case 1:
					if (mHPMP[1] < 90)
					{
						mHPMP[1] += 10;
					}
					break;
				case 2:
					if (isUutien == 0)
					{
						isUutien = 1;
					}
					break;
				}
				GameCanvas.clearKeyHold(6);
			}
		}
		else if (type == 7)
		{
			if (GameCanvas.keyMyHold[2])
			{
				idSelect--;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				idSelect++;
				GameCanvas.clearKeyHold(8);
			}
			idSelect = resetSelect(idSelect, 2, isreset: true);
			if (GameCanvas.keyMyHold[4])
			{
				if (mvalueItem[idSelect] == 0)
				{
					mvalueItem[idSelect] = (sbyte)(T.mValueAutoItem[idSelect].Length - 1);
				}
				else
				{
					mvalueItem[idSelect]--;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				if (mvalueItem[idSelect] == (sbyte)(T.mValueAutoItem[idSelect].Length - 1))
				{
					mvalueItem[idSelect] = 0;
				}
				else
				{
					mvalueItem[idSelect]++;
				}
				GameCanvas.clearKeyHold(6);
			}
		}
		else if (type == 13)
		{
			if (GameCanvas.keyMyHold[2])
			{
				idSelect--;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				idSelect++;
				GameCanvas.clearKeyHold(8);
			}
			idSelect = resetSelect(idSelect, 1, isreset: true);
			if (GameCanvas.keyMyHold[4])
			{
				if (mvalueItem[idSelect] == 0)
				{
					mvalueItem[idSelect] = 1;
				}
				else
				{
					mvalueItem[idSelect]--;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				if (mvalueItem[idSelect] == 1)
				{
					mvalueItem[idSelect] = 0;
				}
				else
				{
					mvalueItem[idSelect]++;
				}
				GameCanvas.clearKeyHold(6);
			}
		}
		else if (type == 8)
		{
			if (GameCanvas.keyMyHold[4])
			{
				idSelect--;
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				idSelect++;
				GameCanvas.clearKeyHold(6);
			}
			idSelect = resetSelect(idSelect, MaxSkillBuff - 1, isreset: true);
		}
		if (cmdList != null)
		{
			int num = cmdList.size();
			if (!GameCanvas.isTouch && num > 0)
			{
				int num2 = idCommand;
				if (GameCanvas.keyMyHold[4])
				{
					idCommand--;
					GameCanvas.clearKeyHold(4);
				}
				else if (GameCanvas.keyMyHold[6])
				{
					idCommand++;
					GameCanvas.clearKeyHold(6);
				}
				idCommand = resetSelect(idCommand, num - 1, isreset: false);
				if (typeQuest == 2)
				{
					iCommand iCommand2 = (iCommand)cmdList.elementAt(idCommand);
					if (iCommand2 == cmdClose)
					{
						idCommand = 0;
					}
				}
				if (num2 != idCommand)
				{
					for (int i = 0; i < num; i++)
					{
						iCommand iCommand3 = (iCommand)cmdList.elementAt(i);
						if (i == idCommand)
						{
							iCommand3.isSelect = true;
						}
						else
						{
							iCommand3.isSelect = false;
						}
					}
				}
			}
		}
		if (GameCanvas.keyMyHold[5])
		{
			GameCanvas.clearKeyHold(5);
			if (cmdList != null && idCommand < cmdList.size())
			{
				((iCommand)cmdList.elementAt(idCommand)).perform();
			}
		}
		base.updatekey();
	}

	public override void updatePointer()
	{
		if (type == 2)
		{
			if (Player.party != null && GameCanvas.isPointSelect(xDia, yDia + GameCanvas.hCommand, wDia, hDia - GameCanvas.hCommand))
			{
				int num = (GameCanvas.py - (yDia + GameCanvas.hCommand)) / hItem;
				if (num >= 0 && num <= Player.party.vecPartys.size() - 1)
				{
					mSound.playSound(42, mSound.volumeSound);
					idSelect = num;
					idSelect = resetSelect(idSelect, Player.party.vecPartys.size() - 1, isreset: false);
					timePaintParty = 3;
					setMenuParty();
					GameCanvas.isPointerSelect = false;
				}
			}
		}
		else if (type == 4)
		{
			int num2 = yDia + hItem + 11;
			int x = xDia + 30 - (GameCanvas.isTouch ? 10 : 0) + mFont.tahoma_7_black.getWidth(T.mAuto[0]);
			if (GameCanvas.isPointSelect(x, num2 - 5, 40, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (mHPMP[0] < 90)
				{
					mHPMP[0] += 10;
				}
				else
				{
					mHPMP[0] = 10;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(x, num2 + hItem - 5, 40, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (mHPMP[1] < 90)
				{
					mHPMP[1] += 10;
				}
				else
				{
					mHPMP[1] = 10;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(xDia + 30 - (GameCanvas.isTouch ? 10 : 0), num2 + hItem * 2, 120, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (isUutien == 0)
				{
					isUutien = 1;
				}
				else
				{
					isUutien = 0;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		else if (type == 7)
		{
			int num3 = yDia + hItem + 11;
			int x2 = xDia;
			if (GameCanvas.isPointSelect(x2, num3 - 4, wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (mvalueItem[0] == (sbyte)(T.mValueAutoItem[0].Length - 1))
				{
					mvalueItem[0] = 0;
				}
				else
				{
					mvalueItem[0]++;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(x2, num3 + hItem - 4, wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (mvalueItem[1] == (sbyte)(T.mValueAutoItem[1].Length - 1))
				{
					mvalueItem[1] = 0;
				}
				else
				{
					mvalueItem[1]++;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(x2, num3 + hItem * 2, wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (mvalueItem[2] == (sbyte)(T.mValueAutoItem[2].Length - 1))
				{
					mvalueItem[2] = 0;
				}
				else
				{
					mvalueItem[2]++;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		else if (type == 13)
		{
			int num4 = yDia + hItem + 11;
			int x3 = xDia;
			if (GameCanvas.isPointSelect(x3, num4 - 4, wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (mvalueVolume[0] == 1)
				{
					mvalueVolume[0] = 0;
				}
				else
				{
					mvalueVolume[0]++;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(x3, num4 + hItem - 4, wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (mvalueVolume[1] == 1)
				{
					mvalueVolume[1] = 0;
				}
				else
				{
					mvalueVolume[1]++;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		else if (type == 6 || type == 14)
		{
			list.update_Pos_UP_DOWN();
		}
		else if (type == 8)
		{
			int num5 = yDia + GameCanvas.hCommand + hItem;
			int num6 = xDia + wbuff / 2;
			for (int i = 0; i < MaxSkillBuff; i++)
			{
				if (GameCanvas.isPointSelect(num6 + i * wbuff - 20, num5 - 20, 40, 40))
				{
					mSound.playSound(42, mSound.volumeSound);
					GameCanvas.isPointerSelect = false;
					setAutoBuff(i);
					break;
				}
			}
		}
		else if (type == 5 && GameCanvas.isPointSelect(0, 0, GameCanvas.w, GameCanvas.h))
		{
			cmdHelp.perform();
			GameCanvas.isPointerSelect = false;
		}
		if (cmdList != null)
		{
			for (int j = 0; j < cmdList.size(); j++)
			{
				iCommand iCommand2 = (iCommand)cmdList.elementAt(j);
				iCommand2.updatePointer();
			}
		}
	}

	public void setMenuParty()
	{
		if (Player.party == null)
		{
			return;
		}
		ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(idSelect);
		if (objectParty.name.CompareTo(GameScreen.player.name) == 0)
		{
			return;
		}
		mVector mVector3 = new mVector("MsgDiaLog menu");
		iCommand o = new iCommand(T.addFriend, 9, this);
		mVector3.addElement(o);
		iCommand o2 = new iCommand(T.trochuyen, 14, this);
		mVector3.addElement(o2);
		if (GameScreen.player.name.CompareTo(Player.party.nameMain) == 0)
		{
			string text = objectParty.name;
			if (text.Length > 8)
			{
				text = mSystem.substring(text, 0, 7) + "...";
			}
			iCommand o3 = new iCommand(T.yeucau + text + " " + T.leave, 6, this);
			mVector3.addElement(o3);
		}
		GameCanvas.menu2.startAt(mVector3, 2, objectParty.name, isFocus: false, null);
	}

	private void setChucNangParty()
	{
		if (Player.party == null)
		{
			return;
		}
		ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(idSelect);
		mVector mVector3 = new mVector("MsgDiaLog menu2");
		if (objectParty.name.CompareTo(GameScreen.player.name) != 0)
		{
			string text = objectParty.name;
			if (text.Length > 8)
			{
				text = mSystem.substring(text, 0, 7) + "...";
			}
			iCommand o = new iCommand(T.yeucau + " " + text + " " + T.leave, 6, this);
			mVector3.addElement(o);
		}
		iCommand o2 = new iCommand(T.leave, 8, this);
		mVector3.addElement(o2);
		iCommand o3 = new iCommand(T.mainCancle, 7, this);
		mVector3.addElement(o3);
		iCommand o4 = new iCommand(T.chatParty, 15, this);
		mVector3.addElement(o4);
		GameCanvas.menu2.startAt(mVector3, 2, T.chucnang, isFocus: false, null);
	}

	public void closeDialog()
	{
		if (GameCanvas.currentDialog != null)
		{
			GameCanvas.currentDialog = null;
		}
		else
		{
			GameCanvas.subDialog = null;
		}
	}

	public void setAutoBuff(int index)
	{
		if (Autobuff[index][1] == 0)
		{
			if (Player.mCurentLvSkill[Autobuff[index][0]] > 0)
			{
				Autobuff[index][1] = 1;
				Player.isAutoBuff = 1;
			}
			else
			{
				GameCanvas.start_Ok_Dialog(T.chuahoc);
			}
		}
		else
		{
			Autobuff[index][1] = 0;
			Player.isAutoBuff = 0;
			for (int i = 0; i < Autobuff.Length; i++)
			{
				if (Autobuff[i][1] == 1)
				{
					Player.isAutoBuff = 1;
					break;
				}
			}
		}
		MainRMS.setSaveAuto();
	}

	public void relogin()
	{
		GlobalLogicHandler.isDisConect = true;
		GlobalLogicHandler.timeReconnect = mSystem.currentTimeMillis() + 30000;
		if (GameCanvas.currentScreen.isGameScr())
		{
			if (SelectCharScreen.isSelectOk)
			{
				GameCanvas.login.Show();
				sbyte[] array = CRes.loadRMS("user_pass");
				if (array != null)
				{
					try
					{
						LoginScreen.loadUser_Pass();
					}
					catch (Exception)
					{
					}
					GameCanvas.connect();
					GlobalService.gI().login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText(), GameMidlet.version, "0", "0", "0", SelectCharScreen.IDCHAR, LoadMap.Area);
					isAutologin = true;
					GameScreen.player.resetPlayer();
					if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
					{
						GlobalService.gI().send_cmd_server(61);
					}
					closeDialog();
				}
				else
				{
					GameCanvas.login.Show();
					closeDialog();
				}
			}
		}
		else
		{
			sbyte[] array2 = CRes.loadRMS("user_pass");
			if (array2 != null)
			{
				try
				{
					LoginScreen.loadUser_Pass();
				}
				catch (Exception)
				{
				}
				GameCanvas.connect();
				GlobalService.gI().login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText(), GameMidlet.version, "0", "0", "0", SelectCharScreen.IDCHAR, LoadMap.Area);
				isAutologin = true;
				GameScreen.player.resetPlayer();
				if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
				{
					GlobalService.gI().send_cmd_server(61);
				}
				closeDialog();
			}
			else
			{
				GameCanvas.login.Show();
				closeDialog();
			}
		}
		GameCanvas.start_Wait_Dialog(T.dangdangnhap, new iCommand(T.close, 7));
		GameCanvas.countLogin = mSystem.currentTimeMillis();
	}

	public static void setMusic()
	{
		if (mvalueVolume != null)
		{
			mSound.isMusic = mvalueVolume[0] == 0;
			mSound.isSound = mvalueVolume[1] == 0;
			if (!mSound.isMusic)
			{
				mSound.pauseCurMusic();
			}
			else if (LoginScreen.MusicRandom == 0)
			{
				mSound.playMus(0, mSound.volumeMusic, loop: true);
			}
			else
			{
				mSound.playMus(1, mSound.volumeMusic, loop: true);
			}
			DataOutputStream dataOutputStream = new DataOutputStream();
			try
			{
				dataOutputStream.writeByte(mvalueVolume[0]);
				dataOutputStream.writeByte(mvalueVolume[1]);
				CRes.saveRMS("isVolume", dataOutputStream.toByteArray());
				dataOutputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}
}
