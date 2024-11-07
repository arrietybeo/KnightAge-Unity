public class MainQuest : AvMain
{
	public const int Q_NHAT_ITEM = 0;

	public const int Q_KILL_MONSTER = 1;

	public const int Q_CHUYEN_DO = 2;

	public const int Q_TALK = 3;

	public const int TYPE_ITEM = 0;

	public const int TYPE_MONSTER = 1;

	public const int NHAN = 0;

	public const int TRA = 1;

	public static mVector vecQuestList = new mVector("MainQuest vecQuestList");

	public static mVector vecQuestFinish = new mVector("MainQuest vecQuestFinish");

	public static mVector vecQuestDoing_Main = new mVector("MainQuest vecQuestDoing_Main");

	public static mVector vecQuestDoing_Sub = new mVector("MainQuest vecQuestDoing_Sub");

	public sbyte typeQuest;

	public int ID;

	public int idNPC_To;

	public int idNPC_From;

	public int idNPCChat;

	public int nhantra;

	public bool isComplete;

	public bool isMain;

	public string name;

	public string strDetail;

	public string strShortDetail;

	public string[] mDetail;

	public string[] mstrTalk;

	public string[] mstrHelp;

	public string strDetailTalk;

	public string strDetailHelp;

	public string strShowDialog;

	public short[] mIdQuest;

	public short[] mtotalQuest;

	public short[] mQuestGot;

	private int step;

	public MainQuest(int ID, bool isMain, string name, int idNpcFrom, string strDetailTalk, sbyte typeQuest, string strDetailHelp)
	{
		this.ID = ID;
		this.isMain = isMain;
		idNPC_From = idNpcFrom;
		idNPCChat = idNpcFrom;
		this.name = name;
		this.strDetailTalk = strDetailTalk;
		this.strDetailHelp = strDetailHelp;
		this.typeQuest = typeQuest;
		nhantra = 0;
		mstrTalk = mFont.split(strDetailTalk, ">");
	}

	public MainQuest(int ID, bool isMain, string name, int idNpcTo, string strDetailTalk, string strDetailHelp)
	{
		this.ID = ID;
		this.isMain = isMain;
		idNPC_To = idNpcTo;
		idNPCChat = idNpcTo;
		this.name = name;
		this.strDetailTalk = strDetailTalk;
		this.strDetailHelp = strDetailHelp;
		mstrHelp = mFont.tahoma_7_white.splitFontArray(strDetailHelp, MainTabNew.wblack - 35);
		nhantra = 1;
		mstrTalk = mFont.split(strDetailTalk, ">");
	}

	public MainQuest(int ID, bool isMain, string name, string strDetailHelp, sbyte typeQuest, string strShortDetail, int idNpcTo, short[] mid, short[] mtotal, short[] mget, int typeItem_Monster)
	{
		this.ID = ID;
		this.isMain = isMain;
		idNPC_To = idNpcTo;
		idNPCChat = idNpcTo;
		this.name = name;
		this.typeQuest = typeQuest;
		this.strShortDetail = strShortDetail;
		this.strDetailHelp = strDetailHelp;
		mIdQuest = mid;
		mtotalQuest = mtotal;
		mQuestGot = mget;
	}

	public MainQuest(int ID, bool isMain, string name, string strDetailHelp, int idNpcTo, string strShortDetail)
	{
		this.ID = ID;
		this.isMain = isMain;
		this.name = name;
		this.strShortDetail = strShortDetail;
		this.strDetailHelp = strDetailHelp;
		idNPC_To = idNpcTo;
		idNPCChat = idNpcTo;
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			if (GameCanvas.menu2.runText == null || GameCanvas.menu2.runText.nextDlgStep())
			{
				nextStep();
			}
			break;
		case 1:
			if (GameCanvas.menu2.runText == null || GameCanvas.menu2.runText.nextDlgStep())
			{
				MainObject mainObject = MainObject.get_Object(idNPCChat, 2);
				if (mainObject != null)
				{
					mainObject.chat = null;
				}
				string text = strDetailHelp;
				if (text == null)
				{
					text = "sai roi";
				}
				GameScreen.player.chat = null;
				if (typeQuest == 3)
				{
					GlobalService.gI().quest((short)ID, (!isMain) ? ((sbyte)1) : ((sbyte)0), 1);
				}
				else
				{
					GameCanvas.start_Quest_Dialog(text, name, ID, nhantra, (!isMain) ? ((sbyte)1) : ((sbyte)0));
				}
				GameScreen.player.currentQuest = null;
				GameScreen.gI().center = null;
				GameCanvas.clearKeyHold();
				GameCanvas.isPointerSelect = false;
			}
			break;
		}
	}

	public void beginQuest()
	{
		step = 0;
		GameScreen.player.currentQuest = this;
		nextStep();
	}

	public void show_Info_Quest_Doing()
	{
		if (strShortDetail != null && MainObject.get_Object(idNPCChat, 2) != null)
		{
			MainObject.get_Object(idNPCChat, 2).strChatPopup = strDetailHelp;
		}
	}

	public iCommand setCmd()
	{
		iCommand iCommand2 = null;
		if (step < mstrTalk.Length - 1)
		{
			return new iCommand(T.next, 0, this);
		}
		return new iCommand(T.next, 1, this);
	}

	public void nextStep()
	{
		if (MainObject.get_Object(idNPCChat, 2) == null)
		{
			GameScreen.player.currentQuest = null;
			return;
		}
		if (mstrTalk[step].Trim().StartsWith("0"))
		{
			MainObject.get_Object(idNPCChat, 2).chat = null;
			mVector mVector3 = new mVector("MainQuest menu");
			iCommand o = setCmd();
			mVector3.addElement(o);
			GameCanvas.menu2.startAt_NPC(mVector3, mSystem.substring(mstrTalk[step], 1, mstrTalk[step].Length), GameScreen.player.ID, 0, isQuest: true, 0);
		}
		else
		{
			GameScreen.player.chat = null;
			mVector mVector4 = new mVector("MainQuest menu2");
			iCommand o2 = setCmd();
			mVector4.addElement(o2);
			GameCanvas.menu2.startAt_NPC(mVector4, mSystem.substring(mstrTalk[step], 1, mstrTalk[step].Length), idNPCChat, 2, isQuest: true, 0);
		}
		step++;
	}

	public static void updateQuestKillMonster(int idMonster)
	{
		MainMonster mainMonster = (MainMonster)MainObject.get_Object(idMonster, 1);
		if (mainMonster == null)
		{
			return;
		}
		string text = string.Empty;
		for (int i = 0; i < vecQuestDoing_Main.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)vecQuestDoing_Main.elementAt(i);
			if (mainQuest.typeQuest != 1)
			{
				continue;
			}
			for (int j = 0; j < mainQuest.mIdQuest.Length; j++)
			{
				if (mainQuest.mIdQuest[j] == mainMonster.catalogyMonster && mainQuest.mQuestGot[j] < mainQuest.mtotalQuest[j])
				{
					mainQuest.mQuestGot[j]++;
					if (text.Length > 0)
					{
						text += " , ";
					}
					string text2 = text;
					text = text2 + mainQuest.mQuestGot[j] + "/" + mainQuest.mtotalQuest[j];
				}
			}
		}
		for (int k = 0; k < vecQuestDoing_Sub.size(); k++)
		{
			MainQuest mainQuest2 = (MainQuest)vecQuestDoing_Sub.elementAt(k);
			if (mainQuest2.typeQuest != 1)
			{
				continue;
			}
			for (int l = 0; l < mainQuest2.mIdQuest.Length; l++)
			{
				if (mainQuest2.mIdQuest[l] == mainMonster.catalogyMonster && mainQuest2.mQuestGot[l] < mainQuest2.mtotalQuest[l])
				{
					mainQuest2.mQuestGot[l]++;
					if (text.Length > 0)
					{
						text += " , ";
					}
					string text2 = text;
					text = text2 + mainQuest2.mQuestGot[l] + "/" + mainQuest2.mtotalQuest[l];
				}
			}
		}
		if (text.Length > 0)
		{
			text = T.giet + mainMonster.name + ": " + text;
			GameCanvas.addInfoChar(text);
		}
	}

	public static void updateQuestGetItem(int idItem, string name)
	{
		string text = string.Empty;
		for (int i = 0; i < vecQuestDoing_Main.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)vecQuestDoing_Main.elementAt(i);
			if (mainQuest.typeQuest != 0)
			{
				continue;
			}
			for (int j = 0; j < mainQuest.mIdQuest.Length; j++)
			{
				if (mainQuest.mIdQuest[j] == idItem && mainQuest.mQuestGot[j] < mainQuest.mtotalQuest[j])
				{
					mainQuest.mQuestGot[j]++;
					if (text.Length > 0)
					{
						text += " , ";
					}
					string text2 = text;
					text = text2 + mainQuest.mQuestGot[j] + "/" + mainQuest.mtotalQuest[j];
				}
			}
		}
		for (int k = 0; k < vecQuestDoing_Sub.size(); k++)
		{
			MainQuest mainQuest2 = (MainQuest)vecQuestDoing_Sub.elementAt(k);
			if (mainQuest2.typeQuest != 0)
			{
				continue;
			}
			for (int l = 0; l < mainQuest2.mIdQuest.Length; l++)
			{
				if (mainQuest2.mIdQuest[l] == idItem && mainQuest2.mQuestGot[l] < mainQuest2.mtotalQuest[l])
				{
					mainQuest2.mQuestGot[l]++;
					if (text.Length > 0)
					{
						text += " , ";
					}
					string text2 = text;
					text = text2 + mainQuest2.mQuestGot[l] + "/" + mainQuest2.mtotalQuest[l];
				}
			}
		}
		if (text.Length > 0)
		{
			text = T.nhat + name + ": " + text;
			GameCanvas.addInfoChar(text);
		}
	}
}
