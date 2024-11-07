public class MsgChat : MainDialog
{
	private int wMainTab;

	private int maxTab;

	private int min;

	private int max;

	private int xdich;

	private sbyte maxText = 5;

	private static int idSelect = 0;

	private int xselect;

	public static mVector vecChatTab = new mVector("MsgChat vecChatTab");

	private static string[] strName;

	public static ChatDetail curentfocus;

	public static iCommand cmdChat;

	public static iCommand cmdDelete;

	public static iCommand cmdClose;

	public static iCommand cmdMenu;

	public static iCommand cmdOkAdd;

	public static iCommand cmdCancelAdd;

	private bool isLeft;

	private bool isRight;

	private Scroll scroll = new Scroll();

	private ListNew list;

	private Camera cam = new Camera();

	public int wOneItem;

	public int wOne5;

	private int minchat;

	private int maxchat;

	private int hchat;

	private iCommand cmdChat2;

	public MsgChat()
	{
		wOneItem = MainTabNew.wOneItem;
		wOne5 = MainTabNew.wOne5;
		wDia = GameCanvas.w / 4 * 3;
		if (wDia < 160)
		{
			wDia = 160;
		}
		else if (wDia > 240)
		{
			wDia = 240;
		}
		hDia = GameCanvas.h - iCommand.hButtonCmd * 2 - 16;
		if (hDia > 240)
		{
			hDia = 240;
		}
		hchat = (hDia - 3 * wOneItem) / GameCanvas.hText + 5;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - hDia / 2;
		cam.setAll(0, 0, 0, 0);
		wMainTab = wOneItem * 3;
		if (wMainTab > 70)
		{
			wMainTab = 70;
		}
		if (wOneItem < 20)
		{
			maxText = 4;
		}
		maxTab = (wDia - wMainTab - 20) / (wOneItem - 1) + 1;
		min = idSelect - maxTab / 2;
		if (min < 0)
		{
			min = 0;
		}
		max = min + maxTab;
		if (max > vecChatTab.size())
		{
			max = vecChatTab.size();
		}
		xdich = (wDia - (maxTab - 1) * (wOneItem - 1) - wMainTab) / 2;
		cmdChat = new iCommand(T.chat, 0, this);
		cmdDelete = new iCommand(T.delTabChat, 1, this);
		cmdClose = new iCommand(T.trora, -1, this);
		cmdMenu = new iCommand(T.menu, 2, this);
		cmdOkAdd = new iCommand(T.chapnhan, 3, this);
		cmdCancelAdd = new iCommand(T.tuchoi, 4, this);
		list = new ListNew(xDia, yDia + wOneItem, wDia, hDia - 3 * wOneItem, 0, 0, 0);
		scroll.setInfo(xDia + wDia - 6, yDia + wOneItem + 10, hDia - wOneItem - TField.getHeight() - 25, MainTabNew.color[9]);
		cmdChat2 = new iCommand();
		cmdChat2.actionChat = delegate(string str)
		{
			curentfocus.tfchat.setText(str);
			cmdChat.perform();
			curentfocus.tfchat.setText(string.Empty);
			curentfocus.tfchat.clearKb();
			TField.isOpenTextBox = false;
			curentfocus.tfchat.isFocus = false;
		};
		init();
	}

	public void setCaptionCmd()
	{
		cmdChat.caption = T.chat;
		cmdDelete.caption = T.delTabChat;
		cmdClose.caption = T.trora;
		cmdMenu.caption = T.menu;
		cmdOkAdd.caption = T.chapnhan;
		cmdCancelAdd.caption = T.tuchoi;
	}

	public void init()
	{
		if (vecChatTab.size() == 0)
		{
			right = cmdClose;
			return;
		}
		if (curentfocus == null && vecChatTab.size() > 0)
		{
			if (idSelect < 0 || idSelect >= vecChatTab.size())
			{
				idSelect = 0;
			}
			curentfocus = (ChatDetail)vecChatTab.elementAt(idSelect);
			newinput.input.text = string.Empty;
			updateSelect();
		}
		if (curentfocus != null)
		{
			updateSelect();
		}
		if (GameCanvas.isTouch)
		{
			cmdMenu.setPos(xDia + wDia - 12, yDia - 14, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
		left = cmdMenu;
	}

	public void openKeyIphone()
	{
		if (!Main.isPC)
		{
			ipKeyboard.openKeyBoard("Chat", ipKeyboard.TEXT, string.Empty, cmdChat2);
			curentfocus.tfchat.setFocusWithKb(isFocus: true);
		}
	}

	public void backTab()
	{
		idSelect = 0;
		cam.setAll(0, 0, 0, 0);
		list = new ListNew(xDia, yDia + wOneItem, wMainTab, hDia - 3 * wOneItem, 0, 0, 0);
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			GameCanvas.end_Dialog();
			newinput.TYPE_INPUT = -1;
			break;
		case 0:
			curentfocus.addStartChat(GameScreen.player.name);
			newinput.input.text = string.Empty;
			break;
		case 1:
		{
			if (idSelect < 0 || idSelect >= vecChatTab.size())
			{
				return;
			}
			ChatDetail chatDetail = (ChatDetail)vecChatTab.elementAt(idSelect);
			if (chatDetail != null)
			{
				MainEvent mainEvent = EventScreen.setEvent(chatDetail.name, 0);
				if (mainEvent != null)
				{
					mainEvent.isRemove = true;
				}
				vecChatTab.removeElementAt(idSelect);
				if (idSelect > 0)
				{
					idSelect--;
				}
				if (vecChatTab.size() == 0)
				{
					curentfocus = null;
					left = null;
					center = null;
					right = cmdClose;
				}
				else
				{
					updateSelect();
				}
			}
			break;
		}
		case 2:
		{
			if (GameCanvas.isTouch && vecChatTab.size() == 1)
			{
				GameCanvas.end_Dialog();
				return;
			}
			mVector mVector3 = new mVector("MsgChat menu");
			if (idSelect > 0)
			{
				mVector3.addElement(cmdDelete);
			}
			mVector3.addElement(cmdClose);
			GameCanvas.menu2.startAt(mVector3, 2, T.trochuyen, isFocus: false, null);
			break;
		}
		case 3:
			GlobalService.gI().Friend(1, curentfocus.friend);
			cmdDelete.perform();
			break;
		case 4:
			GlobalService.gI().Friend(2, curentfocus.friend);
			cmdDelete.perform();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		AvMain.paintDialogNew(g, xDia - 10, yDia - GameCanvas.hCommand - 6, wDia + 20, hDia + GameCanvas.hCommand + 12, 0);
		paintBack(g);
		AvMain.FontBorderColor(g, T.trochuyen, xDia + wDia / 2, yDia - GameCanvas.hCommand + GameCanvas.hCommand / 4, 2, 0);
		int num = xDia + xdich;
		int num2 = yDia + wOne5;
		if (vecChatTab.size() > 0 && curentfocus != null)
		{
			if (min > 0)
			{
				g.drawRegion(MainTabNew.imgTab[13], 0, (isLeft && GameCanvas.gameTick % 6 < 3) ? 16 : 0, 13, 8, 6, num - 6, num2 + wOne5 * 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isTrue);
			}
			g.setColor(MainTabNew.color[7]);
			for (int i = min; i < idSelect; i++)
			{
				ChatDetail chatDetail = (ChatDetail)vecChatTab.elementAt(i);
				paintRectNew(g, num, num2, wOneItem, wOneItem, chatDetail.isNew, chatDetail.timeNew);
				mFont.tahoma_7_black.drawString(g, strName[i], num + wOneItem / 2, num2 + wOneItem / 2 - 7, 2, mGraphics.isTrue);
				num += wOneItem - 1;
			}
			xselect = num;
			num += wMainTab - 1;
			for (int j = idSelect + 1; j < max; j++)
			{
				ChatDetail chatDetail2 = (ChatDetail)vecChatTab.elementAt(j);
				paintRectNew(g, num, num2, wOneItem, wOneItem, chatDetail2.isNew, chatDetail2.timeNew);
				mFont.tahoma_7_black.drawString(g, strName[j], num + wOneItem / 2, num2 + wOneItem / 2 - 7, 2, mGraphics.isTrue);
				num += wOneItem - 1;
			}
			if (max < vecChatTab.size())
			{
				g.drawRegion(MainTabNew.imgTab[13], 0, (!isRight || GameCanvas.gameTick % 6 >= 3) ? 8 : 24, 13, 8, 6, num + 7, num2 + wOne5 * 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isTrue);
			}
			paintTabFocus(g, xselect, num2 - 1, wMainTab);
			string empty = string.Empty;
			empty = ((mFont.tahoma_7b_white.getWidth(curentfocus.name) >= wMainTab - 4) ? (mSystem.substring(curentfocus.name, 0, (maxText - 1) * 2) + "..") : curentfocus.name);
			mFont tahoma_7b_white = mFont.tahoma_7b_white;
			tahoma_7b_white.drawString(g, empty, xselect + wMainTab / 2, num2 + wOneItem / 2 - 7, 2, mGraphics.isTrue);
			num2 += wOneItem;
			g.setClip(xDia, num2, wDia, hDia - wOneItem - 7 - ((curentfocus.typeChat == ChatDetail.TYPE_CHAT) ? 17 : 0));
			g.translate(0, -cam.yCam);
			minchat = cam.yCam / GameCanvas.hText - 2;
			if (minchat < 0)
			{
				minchat = 0;
			}
			maxchat = minchat + hchat;
			for (int k = minchat; k <= maxchat; k++)
			{
				if (k < curentfocus.vecDetail.size() && k >= 0)
				{
					MainTextChat mainTextChat = (MainTextChat)curentfocus.vecDetail.elementAt(k);
					MainTabNew.setTextColor(mainTextChat.color).drawString(g, mainTextChat.text, xDia + wOne5, num2 + 2 + k * GameCanvas.hText, 0, mGraphics.isTrue);
				}
			}
			GameCanvas.resetTrans(g);
			if (cam.yLimit > 0)
			{
				scroll.paint(g);
			}
			if (curentfocus.typeChat == ChatDetail.TYPE_CHAT)
			{
				curentfocus.tfchat.paint(g);
			}
		}
		else
		{
			num2 += wOneItem;
			mFont.tahoma_7_white.drawString(g, T.noMessage, xDia + wDia / 2, num2 + 2, 2, mGraphics.isTrue);
		}
		base.paint(g);
	}

	public override void updatekey()
	{
		if (vecChatTab.size() > 0 && curentfocus != null)
		{
			int num = idSelect;
			if (GameCanvas.keyMyHold[(!Main.isPC) ? 4 : 33])
			{
				if (idSelect != 0)
				{
					idSelect--;
				}
				GameCanvas.clearKeyHold((!Main.isPC) ? 4 : 33);
			}
			else if (GameCanvas.keyMyHold[(!Main.isPC) ? 6 : 34])
			{
				idSelect++;
				GameCanvas.clearKeyHold((!Main.isPC) ? 6 : 34);
			}
			idSelect = resetSelect(idSelect, vecChatTab.size() - 1, isreset: true);
			if (GameCanvas.keyMyHold[(!Main.isPC) ? 2 : 31])
			{
				cam.yTo -= GameCanvas.hText;
				if (cam.yTo < 0)
				{
					cam.yTo = 0;
				}
				GameCanvas.clearKeyHold((!Main.isPC) ? 2 : 31);
			}
			else if (GameCanvas.keyMyHold[(!Main.isPC) ? 8 : 32])
			{
				cam.yTo += GameCanvas.hText;
				if (cam.yTo > cam.yLimit)
				{
					cam.yTo = cam.yLimit;
				}
				GameCanvas.clearKeyHold((!Main.isPC) ? 8 : 32);
			}
			if (num != idSelect)
			{
				updateSelect();
			}
		}
		base.updatekey();
	}

	public override void update()
	{
		if (GameCanvas.isTouch)
		{
			list.update_Pos_UP_DOWN();
			cam.yCam = list.cmx;
		}
		if (curentfocus != null && curentfocus.tfchat != null && curentfocus.tfchat.isFocus)
		{
			newinput.TYPE_INPUT = 1;
			curentfocus.tfchat.isnewTF = true;
		}
		isLeft = false;
		isRight = false;
		if (vecChatTab.size() > 0 && curentfocus != null)
		{
			for (int i = 0; i < vecChatTab.size(); i++)
			{
				if (i >= min && i < max)
				{
					continue;
				}
				ChatDetail chatDetail = (ChatDetail)vecChatTab.elementAt(i);
				if (chatDetail.isNew)
				{
					if (i < min)
					{
						isLeft = true;
					}
					else
					{
						isRight = true;
					}
				}
			}
			if (vecChatTab.size() == 0)
			{
				idSelect = 0;
			}
			if (cam.yLimit > 0)
			{
				scroll.setYScrool(cam.yCam, cam.yLimit);
			}
			if (GameCanvas.isTouch)
			{
				list.moveCamera();
			}
			else
			{
				cam.UpdateCamera();
				cam.UpdateCamera();
			}
			if (curentfocus.typeChat == ChatDetail.TYPE_CHAT)
			{
				curentfocus.tfchat.update();
			}
		}
		else if (curentfocus == null && vecChatTab.size() > 0)
		{
			idSelect = 0;
			curentfocus = (ChatDetail)vecChatTab.elementAt(idSelect);
			updateSelect();
		}
		updatekey();
		updatePointer();
		base.update();
	}

	public override void keypress(int keyCode)
	{
		if (vecChatTab.size() > 0 && curentfocus != null && curentfocus.typeChat == ChatDetail.TYPE_CHAT)
		{
			curentfocus.tfchat.keyPressed(keyCode);
		}
		base.keypress(keyCode);
	}

	public static void getStrName()
	{
		strName = new string[vecChatTab.size()];
		for (int i = 0; i < strName.Length; i++)
		{
			ChatDetail chatDetail = (ChatDetail)vecChatTab.elementAt(i);
			if (chatDetail.name.Length <= 4)
			{
				strName[i] = chatDetail.name;
			}
			else
			{
				strName[i] = mSystem.substring(chatDetail.name, 0, 4);
			}
		}
	}

	public void updateCameraNew(int size)
	{
		if (GameCanvas.isTouch)
		{
			list.cmxLim = curentfocus.limY;
			if (list.cmx + hDia / 4 > list.cmxLim && list.cmxLim > 0)
			{
				list.cmtoX += GameCanvas.hText * size;
			}
		}
		else
		{
			cam.yLimit = curentfocus.limY;
			if (cam.yCam + hDia / 4 > cam.yLimit)
			{
				cam.yTo += GameCanvas.hText * size;
			}
		}
	}

	public void updateSelect()
	{
		curentfocus = (ChatDetail)vecChatTab.elementAt(idSelect);
		if (left == null)
		{
			left = cmdMenu;
		}
		if (curentfocus.typeChat == ChatDetail.TYPE_CHAT)
		{
			curentfocus.tfchat.setText(string.Empty);
			if (Main.isPC)
			{
				curentfocus.tfchat.setFocus(isFocus: true);
				center = cmdChat;
				right = curentfocus.tfchat.setCmdClear();
			}
		}
		else if (curentfocus.typeChat == ChatDetail.TYPE_ADDFRIEND)
		{
			center = cmdOkAdd;
			right = cmdCancelAdd;
		}
		else
		{
			center = null;
			right = null;
		}
		if (curentfocus.timeNew > 0)
		{
			curentfocus.timeNew = -1;
			curentfocus.isNew = false;
		}
		if (curentfocus.limY > 0)
		{
			int num = curentfocus.limY - hDia / 4;
			if (num < 0)
			{
				num = 0;
			}
			if (GameCanvas.isTouch)
			{
				list.cmxLim = curentfocus.limY;
				list.cmtoX = curentfocus.limY;
			}
			else
			{
				cam.setAll(0, curentfocus.limY, 0, num);
				cam.yTo = curentfocus.limY;
			}
		}
		else if (!GameCanvas.isTouch)
		{
			cam.setAll(0, 0, 0, 0);
		}
		else
		{
			list.cmxLim = 0;
			list.cmtoX = 0;
		}
		min = idSelect - maxTab / 2;
		if (min < 0)
		{
			min = 0;
		}
		max = min + maxTab;
		if (max > vecChatTab.size())
		{
			max = vecChatTab.size();
			min = max - maxTab;
			if (min < 0)
			{
				min = 0;
			}
		}
		getStrName();
		TabScreenNew.timeRepaint = 10;
	}

	public override void updatePointer()
	{
		if (vecChatTab.size() > 0 && curentfocus != null)
		{
			if (curentfocus.typeChat == ChatDetail.TYPE_CHAT)
			{
				curentfocus.tfchat.updatePoiter();
			}
			if (GameCanvas.isPointerSelect)
			{
				int num = xDia;
				int y = yDia;
				int num2 = num + xdich;
				int num3 = num2 + (maxTab - 1) * (wOneItem - 1) + wMainTab;
				int select = idSelect;
				if (GameCanvas.isPoint(xDia, y, wDia, wOneItem))
				{
					if (GameCanvas.px < xselect && GameCanvas.px > num2)
					{
						select = idSelect + (GameCanvas.px - xselect) / (wOneItem - 1) - 1;
						TabScreenNew.timeRepaint = 10;
					}
					else if (GameCanvas.px > xselect + wMainTab && GameCanvas.px < num3)
					{
						select = idSelect + (GameCanvas.px - xselect - wMainTab) / (wOneItem - 1) + 1;
					}
					else if (GameCanvas.px < num2)
					{
						select = idSelect - maxTab;
					}
					else if (GameCanvas.px > num3)
					{
						select = idSelect + maxTab;
					}
				}
				select = resetSelect(select, vecChatTab.size() - 1, isreset: false);
				if (select != idSelect)
				{
					idSelect = select;
					updateSelect();
					GameCanvas.isPointerSelect = false;
					TabScreenNew.timeRepaint = 10;
				}
			}
		}
		base.updatePointer();
	}

	public void addNewChat(string name, string FristContent, string content, sbyte type, bool isFocus)
	{
		for (int i = 0; i < vecChatTab.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)vecChatTab.elementAt(i);
			if (chatDetail.name.CompareTo(name) == 0)
			{
				if (isFocus)
				{
					idSelect = i;
				}
				if (content.Length > 0)
				{
					chatDetail.addString(FristContent + content, name);
					string[] array = mFont.tahoma_7_white.splitFontArray(content, GameCanvas.mevent.wDia / 5 * 2);
					GameCanvas.mevent.addEvent(name, 0, array[0], 0);
				}
				return;
			}
		}
		ChatDetail chatDetail2 = new ChatDetail(name, type);
		if (type == ChatDetail.TYPE_CHAT)
		{
			chatDetail2.addString(T.beginChat + name, name);
		}
		if (content.Length > 0)
		{
			chatDetail2.addString(FristContent + content, name);
			string[] array2 = mFont.tahoma_7_white.splitFontArray(content, GameCanvas.mevent.wDia / 2);
			GameCanvas.mevent.addEvent(name, 0, array2[0], 0);
		}
		vecChatTab.addElement(chatDetail2);
		set_text_min_max();
		if (isFocus)
		{
			idSelect = vecChatTab.size() - 1;
		}
	}

	public void set_text_min_max()
	{
		getStrName();
		min = idSelect - maxTab / 2;
		if (min < 0)
		{
			min = 0;
		}
		max = min + maxTab;
		if (max > vecChatTab.size())
		{
			max = vecChatTab.size();
			min = max - maxTab;
			if (min < 0)
			{
				min = 0;
			}
		}
	}

	public void paintRectNew(mGraphics g, int x, int y, int w, int h, bool isNew, int time)
	{
		if (isNew && (time + GameCanvas.gameTick) % 8 < 4)
		{
			TabScreenNew.timeRepaint = 10;
			g.drawRegion(MainTabNew.imgTab[10], 0, 0, w - 2, h - wOne5 - 1, 0, x + 1, y + 1, 0, mGraphics.isTrue);
		}
		g.fillRect(x, y + 1, 1, h - 1, mGraphics.isTrue);
		g.fillRect(x + 1, y, w - 2, 1, mGraphics.isTrue);
		g.fillRect(x + w - 1, y + 1, 1, h - 1, mGraphics.isTrue);
	}

	public void paintTabFocus(mGraphics g, int x, int y, int wMainTab)
	{
		for (int i = 0; i <= wMainTab / 32; i++)
		{
			if (i == 0)
			{
				g.drawImage(MainTabNew.imgTab[9], x, y, 0, mGraphics.isTrue);
			}
			else if (i == wMainTab / 32)
			{
				g.drawRegion(MainTabNew.imgTab[9], 0, 0, 32, 32, 2, x + wMainTab - 32, y, 0, mGraphics.isTrue);
			}
			else
			{
				g.drawImage(MainTabNew.imgTab[2], x + i * 32, y, 0, mGraphics.isTrue);
			}
		}
	}

	public void paintBack(mGraphics g)
	{
		int num = hDia - wOneItem;
		int num2 = wDia / 32;
		int num3 = num / 32;
		for (int i = 0; i <= num2; i++)
		{
			for (int j = 0; j <= num3; j++)
			{
				if (i == num2)
				{
					if (j == num3)
					{
						g.drawImage(MainTabNew.imgTab[2], xDia + wDia - 32, yDia + hDia - 32, 0, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[2], xDia + wDia - 32, yDia + wOneItem + j * 32, 0, mGraphics.isTrue);
					}
				}
				else if (j == num3)
				{
					g.drawImage(MainTabNew.imgTab[2], xDia + i * 32, yDia + hDia - 32, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[2], xDia + i * 32, yDia + wOneItem + j * 32, 0, mGraphics.isTrue);
				}
			}
		}
	}

	public bool setAddFriend(string name)
	{
		for (int i = 0; i < vecChatTab.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)vecChatTab.elementAt(i);
			if (chatDetail.typeChat == ChatDetail.TYPE_ADDFRIEND && chatDetail.friend.CompareTo(name) == 0)
			{
				return false;
			}
		}
		return true;
	}

	public static void setFocus(int index)
	{
		if (GameCanvas.subDialog != GameCanvas.msgchat && vecChatTab != null && index >= 0 && index < vecChatTab.size())
		{
			idSelect = index;
		}
	}

	public static void setIndexFocus(string name)
	{
		for (int i = 0; i < vecChatTab.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)vecChatTab.elementAt(i);
			if (chatDetail.name.CompareTo(name) == 0)
			{
				idSelect = i;
				break;
			}
		}
	}

	public void checkRemoveText()
	{
		for (int i = 0; i < vecChatTab.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)vecChatTab.elementAt(i);
			int num = chatDetail.vecDetail.size();
			if (num > 80)
			{
				for (int j = 0; j < num - 80; j++)
				{
					chatDetail.vecDetail.removeElementAt(i);
				}
				chatDetail.setLim();
			}
		}
	}
}
