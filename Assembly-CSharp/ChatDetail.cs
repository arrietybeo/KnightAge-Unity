public class ChatDetail
{
	public const sbyte TYPE_TROCHUYEN = 0;

	public const sbyte TYPE_BANGHOI_NHOM = 1;

	public mVector vecDetail = new mVector("ChatDetail vecDetail");

	public string name;

	public string friend;

	public sbyte timeNew = -1;

	public bool isNew;

	public TField tfchat;

	public sbyte typeChat;

	public static sbyte TYPE_CHAT;

	public static sbyte TYPE_SERVER = 1;

	public static sbyte TYPE_ADDFRIEND = 2;

	public int limY;

	private int indexColor;

	private sbyte typeColorChat;

	public ChatDetail(string name, sbyte type)
	{
		this.name = name;
		typeChat = type;
		if (typeChat == TYPE_CHAT)
		{
			tfchat = new TField(GameCanvas.msgchat.xDia + 5, GameCanvas.msgchat.yDia + GameCanvas.msgchat.hDia - (TField.getHeight() + 5), GameCanvas.msgchat.wDia - 10);
			tfchat.isCloseKey = false;
		}
		else if (typeChat == TYPE_ADDFRIEND)
		{
			friend = name;
			this.name = T.addFriend;
		}
		if (name.CompareTo(T.tabBangHoi) == 0 || name.CompareTo(T.tinden) == 0 || name.CompareTo(T.tabThuLinh) == 0)
		{
			typeColorChat = 1;
		}
		else
		{
			typeColorChat = 0;
		}
	}

	public void addString(string str, string nametext)
	{
		if (str.Length <= 0)
		{
			return;
		}
		string[] array = mFont.tahoma_7_white.splitFontArray(str, GameCanvas.msgchat.wDia - GameCanvas.msgchat.wOne5 * 2 - 8);
		MainTextChat[] array2 = addChatNew(array, setColorText(nametext));
		if (array2 != null)
		{
			for (int i = 0; i < array2.Length; i++)
			{
				vecDetail.addElement(array2[i]);
			}
		}
		setLim();
		if (limY > 0 && GameCanvas.subDialog != null && GameCanvas.subDialog == GameCanvas.msgchat && MsgChat.curentfocus != null && MsgChat.curentfocus == this)
		{
			GameCanvas.msgchat.updateCameraNew(array.Length);
		}
		if (MsgChat.curentfocus != null && MsgChat.curentfocus != this && name.CompareTo(T.tinden) != 0)
		{
			isNew = true;
			timeNew = (sbyte)CRes.random(1, 11);
		}
	}

	public void addStartChat(string nametext)
	{
		string text = string.Empty;
		if (tfchat != null)
		{
			text = newinput.input.text;
		}
		if (text.Length > 0)
		{
			string[] array = mFont.tahoma_7_white.splitFontArray(GameScreen.player.name + ": " + text, GameCanvas.msgchat.wDia - GameCanvas.msgchat.wOne5 * 2 - 8);
			MainTextChat[] array2 = addChatNew(array, setColorText(nametext));
			if (array2 != null)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					vecDetail.addElement(array2[i]);
				}
			}
			setLim();
			if (MsgChat.curentfocus != null && MsgChat.curentfocus == this)
			{
				GameCanvas.msgchat.updateCameraNew(array.Length);
			}
			GlobalService.gI().chatTab(name, text);
		}
		if (tfchat != null)
		{
			tfchat.setText(string.Empty);
		}
	}

	public void setLim()
	{
		limY = vecDetail.size() * GameCanvas.hText - (GameCanvas.msgchat.hDia - MainTabNew.wOneItem - 10 - ((typeChat == TYPE_CHAT) ? (TField.getHeight() + 2) : 0));
		if (limY < 0)
		{
			limY = 0;
		}
	}

	public MainTextChat[] addChatNew(string[] mstr, sbyte color)
	{
		if (mstr == null || mstr.Length == 0)
		{
			return null;
		}
		MainTextChat[] array = new MainTextChat[mstr.Length];
		for (int i = 0; i < mstr.Length; i++)
		{
			array[i] = new MainTextChat(mstr[i], color);
		}
		return array;
	}

	private sbyte setColorText(string name)
	{
		sbyte b = 0;
		if (typeColorChat != 1)
		{
			b = (sbyte)((name.CompareTo(GameScreen.player.name) == 0) ? 5 : 0);
		}
		else
		{
			b = (sbyte)((indexColor % 2 != 0) ? 5 : 0);
			indexColor++;
		}
		return b;
	}
}
