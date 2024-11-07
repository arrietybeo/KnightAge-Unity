public class EventScreen : MainScreen
{
	public int hItem;

	public int wDia;

	public int maxSizeList;

	public int hbutton;

	public int hDia;

	public int min;

	public int max;

	public int xDia;

	public int yDia;

	public int numw;

	public int numh;

	public int idSelect;

	public int idCommand;

	private iCommand cmdSeL;

	private iCommand cmdDel;

	public static mVector vecListEvent = new mVector("EventScreen vecListEvent");

	public static mVector vecEventShow = new mVector("EventScreen vecEventShow");

	public static mVector cmdList = new mVector("EventScreen cmdList");

	private Camera cameraDia = new Camera();

	private ListNew list;

	private int xBegin;

	private int w2cmd;

	public EventScreen()
	{
		cmdSeL = new iCommand(T.view, 2, 0, this);
		cmdDel = new iCommand(T.delMess, 2, 1, this);
		hItem = GameCanvas.hCommand + 5;
		wDia = GameCanvas.w / 4 * 3;
		if (wDia > 180)
		{
			wDia = 180;
		}
	}

	public void setCaptionCmd()
	{
		cmdSeL.caption = T.view;
		cmdDel.caption = T.delMess;
	}

	public override void Show(MainScreen screen)
	{
		base.Show(screen);
		PaintInfoGameScreen.numMess = 0;
	}

	public void init()
	{
		for (int i = 0; i < vecListEvent.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)vecListEvent.elementAt(i);
			if (mainEvent.isRemove)
			{
				vecListEvent.removeElement(mainEvent);
				i--;
			}
		}
		hbutton = iCommand.hButtonCmd * 3 / 2;
		if (GameCanvas.isTouch)
		{
			hbutton = 0;
		}
		maxSizeList = (GameCanvas.h / 4 * 3 - (10 + GameCanvas.hCommand)) / hItem + 1;
		hDia = hItem * maxSizeList + 10 + GameCanvas.hCommand;
		maxSizeList += 2;
		min = 0;
		max = maxSizeList;
		if (max > vecListEvent.size())
		{
			max = vecListEvent.size();
		}
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - hDia / 2 - GameCanvas.hCommand / 2;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		updateList();
	}

	private void updateList()
	{
		cmdList.removeAllElements();
		iCommand iCommand2 = new iCommand(T.close, -1, this);
		if (GameCanvas.isTouch)
		{
			iCommand2.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			cmdList.addElement(iCommand2);
		}
		else
		{
			if (vecListEvent.size() > 0)
			{
				iCommand o = new iCommand(T.menu, 1, this);
				cmdList.addElement(o);
			}
			cmdList.addElement(iCommand2);
			setPosCmdNew(0);
		}
		cameraDia.setAll(0, hItem * vecListEvent.size() - (hDia - GameCanvas.hCommand - hbutton), 0, 0);
		list = new ListNew(xDia, yDia, wDia, hDia, 0, 0, cameraDia.yLimit);
		if (idSelect >= vecListEvent.size())
		{
			if (GameCanvas.isTouch)
			{
				idSelect = -1;
			}
			else
			{
				idSelect = 0;
			}
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
			w2cmd = 20;
			xBegin = xDia + wDia / 2 - w2cmd / 2 - iCommand.wButtonCmd / 2;
			break;
		default:
			w2cmd = 20;
			xBegin = xDia + wDia / 2 - w2cmd / 2 - iCommand.wButtonCmd / 2;
			break;
		}
		for (int i = 0; i < num; i++)
		{
			iCommand iCommand2 = (iCommand)cmdList.elementAt(i);
			iCommand2.isSelect = false;
			if (num == 3 && i == 2)
			{
				iCommand2.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 + i / 2 * (iCommand.hButtonCmd + 5) + yplus, null, iCommand2.caption);
			}
			else
			{
				iCommand2.setPos(xBegin + i % 2 * (iCommand.wButtonCmd + w2cmd), yDia + hDia - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 + i / 2 * (iCommand.hButtonCmd + 5) + yplus, null, iCommand2.caption);
			}
			if (i == 0)
			{
				iCommand2.isSelect = true;
			}
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			lastScreen.Show(lastScreen.lastScreen);
			break;
		case 1:
			if (idSelect >= 0 && idSelect < vecListEvent.size())
			{
				if (idSelect > 0)
				{
					mVector mVector3 = new mVector("EventScreen vec");
					mVector3.addElement(cmdSeL);
					mVector3.addElement(cmdDel);
					GameCanvas.menu2.startAt(mVector3, 2, T.mevent, isFocus: false, null);
				}
				else
				{
					cmdSeL.perform();
				}
			}
			break;
		case 2:
			if (idSelect >= 0 && idSelect < vecListEvent.size())
			{
				bool isre = false;
				if (subIndex == 1)
				{
					isre = true;
				}
				MainEvent mevent = (MainEvent)vecListEvent.elementAt(idSelect);
				doEvent(isre, mevent);
			}
			break;
		case 0:
			break;
		}
	}

	public override void paint(mGraphics g)
	{
		if (lastScreen != null)
		{
			lastScreen.paint(g);
		}
		if (GameCanvas.currentScreen != this)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		paintFormList(g, xDia, yDia, wDia, hDia, T.mevent);
		int num = yDia + GameCanvas.hCommand + 3;
		if (vecListEvent.size() > 0)
		{
			g.setClip(xDia + 4, num, wDia - 8, hDia - GameCanvas.hCommand - hbutton - 6);
			g.translate(0, -cameraDia.yCam);
			if (idSelect >= 0)
			{
				g.setColor(11904141);
				g.fillRect(xDia + 4, num - 2 + idSelect * hItem, wDia - 8, hItem - 1, mGraphics.isTrue);
			}
			num += hItem * min;
			for (int i = min; i < max; i++)
			{
				if (i >= 0 || i < vecListEvent.size())
				{
					MainEvent mainEvent = (MainEvent)vecListEvent.elementAt(i);
					int num2 = 0;
					if (mainEvent.isNew == 1 && GameCanvas.gameTick % 20 > 9)
					{
						num2 = 1;
					}
					PaintInfoGameScreen.fraEvent.drawFrame(mainEvent.IDCmd * 2 + 1 - num2, xDia + 20, num + hItem / 2 - 2, 0, 3, g);
					if (GameCanvas.isTouch && i > 0)
					{
						PaintInfoGameScreen.fraClose.drawFrame(0, xDia + wDia - 20, num + hItem / 2 - 2, 0, 3, g);
					}
					mFont.tahoma_7b_white.drawString(g, mainEvent.nameEvent, xDia + 35, num + 1, 0, mGraphics.isTrue);
					mFont.tahoma_7_white.drawString(g, mainEvent.contentEvent, xDia + 42, num + 13, 0, mGraphics.isTrue);
					num += hItem;
					if (i < vecListEvent.size() - 1)
					{
						g.setColor(AvMain.color[4]);
						g.fillRect(xDia + 6, num - 3, wDia - 12, 1, mGraphics.isTrue);
					}
				}
			}
		}
		else
		{
			mFont.tahoma_7_white.drawString(g, T.noEvent, xDia + wDia / 2, num + 3, 2, mGraphics.isTrue);
		}
		GameCanvas.resetTrans(g);
		if (cmdList != null)
		{
			for (int j = 0; j < cmdList.size(); j++)
			{
				iCommand iCommand2 = (iCommand)cmdList.elementAt(j);
				iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
			}
		}
	}

	public override void update()
	{
		if (GameCanvas.currentScreen == this)
		{
			lastScreen.update();
		}
		int yCam = cameraDia.yCam;
		if (GameCanvas.isTouch)
		{
			list.moveCamera();
		}
		else
		{
			cameraDia.UpdateCamera();
		}
		base.update();
		int num = vecListEvent.size();
		for (int i = 0; i < vecListEvent.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)vecListEvent.elementAt(i);
			if (mainEvent.isRemove)
			{
				vecListEvent.removeElement(mainEvent);
				i--;
			}
		}
		if (idSelect < 0 || idSelect >= vecListEvent.size())
		{
			if (GameCanvas.isTouch)
			{
				idSelect = -1;
			}
			else
			{
				idSelect = 0;
			}
		}
		if (cameraDia.yCam != yCam || num != vecListEvent.size())
		{
			min = cameraDia.yCam / hItem;
			max = min + maxSizeList;
			if (max > vecListEvent.size())
			{
				max = vecListEvent.size();
				min = max - maxSizeList;
			}
			if (min < 0)
			{
				min = 0;
			}
		}
	}

	public override void updatekey()
	{
		if (vecListEvent.size() > 0)
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
			idSelect = resetSelect(idSelect, vecListEvent.size() - 1, isreset: true);
			cameraDia.moveCamera(0, idSelect * hItem - (hDia / 2 - GameCanvas.hCommand - hbutton));
		}
		else if (cmdList.size() > 1)
		{
			cmdList.removeAllElements();
			cmdList.addElement(new iCommand(T.close, -1, this));
			setPosCmdNew(0);
			idSelect = 0;
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
				if (num2 != idCommand)
				{
					for (int i = 0; i < num; i++)
					{
						iCommand iCommand2 = (iCommand)cmdList.elementAt(i);
						if (i == idCommand)
						{
							iCommand2.isSelect = true;
						}
						else
						{
							iCommand2.isSelect = false;
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
	}

	public override void updatePointer()
	{
		if (GameCanvas.isTouch)
		{
			list.update_Pos_UP_DOWN();
			cameraDia.yCam = list.cmx;
		}
		if (vecListEvent.size() > 0 && GameCanvas.isPointSelect(xDia, yDia + GameCanvas.hCommand, wDia, hDia - GameCanvas.hCommand))
		{
			int num = (GameCanvas.py - (yDia + GameCanvas.hCommand)) / hItem;
			if (num >= 0 && num <= vecListEvent.size() - 1)
			{
				idSelect = num;
				idSelect = resetSelect(idSelect, vecListEvent.size() - 1, isreset: false);
				bool isre = false;
				if (GameCanvas.isPointSelect(xDia + wDia - 30, yDia + GameCanvas.hCommand, 30, hDia - GameCanvas.hCommand) && idSelect > 0)
				{
					isre = true;
				}
				MainEvent mevent = (MainEvent)vecListEvent.elementAt(idSelect);
				doEvent(isre, mevent);
				GameCanvas.isPointerSelect = false;
			}
		}
		if (cmdList != null)
		{
			for (int i = 0; i < cmdList.size(); i++)
			{
				iCommand iCommand2 = (iCommand)cmdList.elementAt(i);
				iCommand2.updatePointer();
			}
		}
	}

	public void doEvent(bool isre, MainEvent mevent)
	{
		if (isre)
		{
			mevent.isRemove = true;
			return;
		}
		mVector mVector3 = null;
		if (PaintInfoGameScreen.numMess > 0)
		{
			PaintInfoGameScreen.numMess--;
		}
		switch (mevent.IDCmd)
		{
		case 0:
			MsgChat.setIndexFocus(mevent.nameEvent);
			GameCanvas.start_Chat_Dialog();
			mevent.isNew = 0;
			break;
		case 1:
			mVector3 = new mVector("EventScreen vec2");
			mVector3.addElement(new iCommand(T.chapnhan, 1, 1, mevent));
			mVector3.addElement(new iCommand(T.tuchoi, 1, 2, mevent));
			mVector3.addElement(new iCommand(T.close, -1));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.yeucauketban, mVector3);
			mevent.isNew = 0;
			break;
		case 2:
			mVector3 = new mVector("EventScreen vec3");
			mVector3.addElement(new iCommand(T.chapnhan, 2, 1, mevent));
			mVector3.addElement(new iCommand(T.tuchoi, 2, 0, mevent));
			mVector3.addElement(new iCommand(T.close, -1));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.loimoiParty, mVector3);
			mevent.isNew = 0;
			break;
		case 3:
			mVector3 = new mVector("EventScreen vec4");
			mVector3.addElement(new iCommand(T.chapnhan, 3, 1, mevent));
			mVector3.addElement(new iCommand(T.tuchoi, 3, 0, mevent));
			mVector3.addElement(new iCommand(T.close, -1));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.hoigiaodich, mVector3);
			mevent.isNew = 0;
			break;
		case 4:
			mVector3 = new mVector("EventScreen vec5");
			mVector3.addElement(new iCommand(T.chapnhan, 4, 1, mevent));
			mVector3.addElement(new iCommand(T.info, 4, 2, mevent));
			mVector3.addElement(new iCommand(T.cancel, 4, 0, mevent));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.hoithachdau + mevent.numThachDau + " " + T.coin + ".", mVector3);
			mevent.isNew = 0;
			break;
		case 5:
			mVector3 = new mVector("EventScreen vec6");
			mVector3.addElement(new iCommand(T.chapnhan, 5, 1, mevent));
			mVector3.addElement(new iCommand(T.close, -1));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.moivaoclan, mVector3);
			mevent.isNew = 0;
			break;
		}
	}

	public static MainEvent setEvent(string name, sbyte type)
	{
		for (int i = 0; i < vecListEvent.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)vecListEvent.elementAt(i);
			if (mainEvent.isRemove)
			{
				vecListEvent.removeElement(mainEvent);
				i--;
			}
			else if (mainEvent.IDCmd == type && mainEvent.nameEvent.CompareTo(name) == 0)
			{
				return mainEvent;
			}
		}
		return null;
	}

	public static MainEvent setEventShow(string name, sbyte type)
	{
		for (int i = 0; i < vecEventShow.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)vecEventShow.elementAt(i);
			if (mainEvent.IDCmd == type && mainEvent.nameEvent.CompareTo(name) == 0)
			{
				return mainEvent;
			}
		}
		return null;
	}

	public static int setIndexEvent(string name, sbyte type)
	{
		for (int i = 0; i < vecListEvent.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)vecListEvent.elementAt(i);
			if (mainEvent.IDCmd == type && mainEvent.nameEvent.CompareTo(name) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public void addEvent(string namecheck, sbyte type, string content, int numThachdau)
	{
		MainEvent mainEvent = setEvent(namecheck, type);
		if (mainEvent == null)
		{
			mainEvent = new MainEvent(0, type, namecheck, content);
			vecListEvent.addElement(mainEvent);
			updateList();
			min = cameraDia.yCam / hItem;
			max = min + maxSizeList;
			if (max > vecListEvent.size())
			{
				max = vecListEvent.size();
				min = max - maxSizeList;
			}
			if (min < 0)
			{
				min = 0;
			}
		}
		else if (type == 0)
		{
			mainEvent.contentEvent = content;
		}
		if (namecheck.CompareTo(T.tinden) == 0)
		{
			return;
		}
		PaintInfoGameScreen.numMess++;
		mainEvent.isNew = 1;
		mainEvent.numThachDau = numThachdau;
		if (type != 0 || (namecheck.CompareTo(T.tabBangHoi) != 0 && namecheck.CompareTo(T.tabThuLinh) != 0))
		{
			MainEvent mainEvent2 = setEventShow(namecheck, type);
			if (mainEvent2 == null)
			{
				MainEvent o = new MainEvent(mainEvent.IDObj, mainEvent.IDCmd, mainEvent.nameEvent, mainEvent.contentEvent);
				vecEventShow.addElement(o);
			}
			else if (type == 0)
			{
				mainEvent2.contentEvent = mainEvent.contentEvent;
			}
		}
	}
}
