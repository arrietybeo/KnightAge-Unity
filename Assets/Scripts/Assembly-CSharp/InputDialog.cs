using System;
using UnityEngine.UI;

public class InputDialog : MainDialog
{
	public TField tfInput;

	private iCommand cmdClose;

	public TField[] mtfInput;

	private bool isMore;

	private bool iscroll;

	private bool isNew;

	private long price;

	private string name;

	private string info;

	private string xuluong;

	private new short type;

	private short idNPC = -1;

	public static int hTouch;

	public static int istouchMore;

	public static int hitem;

	private mFont fontInput = mFont.tahoma_7_white;

	public bool isnew;

	private ListNew list;

	private string strtam;

	private int idSelect;

	public InputDialog()
	{
		cmdClose = new iCommand(T.close, -1);
		istouchMore = 15;
		if (GameCanvas.isTouch)
		{
			hTouch = iCommand.hButtonCmd + 5;
		}
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

	public override void commandTab(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			closeDialog();
			break;
		case 0:
		{
			string[] array = new string[mtfInput.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = string.Empty;
				if (mtfInput[j].getText().Length > 0)
				{
					array[j] = mtfInput[j].getText();
				}
			}
			GlobalService.gI().nap_tien(type, array);
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			break;
		}
		case 1:
		{
			mVector mVector3 = new mVector();
			bool flag = idNPC == GameScreen.ID_DLG_BUY_KC;
			for (int i = 0; i < mtfInput.Length; i++)
			{
				string o = string.Empty;
				if (mtfInput[i].getText().Length > 0)
				{
					o = mtfInput[i].getText();
				}
				mVector3.addElement(o);
			}
			if (flag)
			{
				mVector3.addElement(mSystem.getLong());
				mVector3.addElement(mSystem.getLat());
			}
			GlobalService.gI().sendMoreServerInfo(idNPC, type, mVector3);
			closeDialog();
			break;
		}
		}
		base.commandTab(index, subIndex);
	}

	public void setinfo(string[] info, iCommand cmd, short type, short idNPC, string name, string[] texmacdinh, sbyte typepaint)
	{
		isMore = true;
		isNew = false;
		left = null;
		right = null;
		center = null;
		mtfInput = null;
		hitem = 50;
		this.type = type;
		this.idNPC = idNPC;
		if (cmd == null)
		{
			GameCanvas.subDialog = null;
		}
		wDia = GameCanvas.w - 30;
		if (wDia > 140)
		{
			wDia = 140;
		}
		mtfInput = new TField[info.Length];
		strinfo = info;
		this.name = name;
		if (mtfInput.Length > 3)
		{
			iscroll = true;
		}
		if (iscroll)
		{
			wDia = GameCanvas.w / 4 * 3;
			hDia = GameCanvas.h / 5 * 4;
			wDia = GameCanvas.w - 30;
			if (wDia > 140)
			{
				wDia = 140;
			}
			if (hDia < 210)
			{
				hDia = 210;
			}
			else if (hDia > 280)
			{
				hDia = 280;
			}
			if (hDia < 210)
			{
				hDia = 210;
			}
			else if (hDia > 280)
			{
				hDia = 280;
			}
			xDia = GameCanvas.hw - wDia / 2;
			yDia = GameCanvas.hh - hDia / 2;
			if (yDia < 20)
			{
				yDia = 20;
			}
			if (GameCanvas.isSmallScreen)
			{
				yDia = 0;
			}
		}
		else
		{
			hDia = (TField.getHeight() + 18) * strinfo.Length + 6 + GameCanvas.hCommand;
			hDia += hTouch + istouchMore;
			xDia = GameCanvas.hw - wDia / 2;
			yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia + 15;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		for (int i = 0; i < mtfInput.Length; i++)
		{
			mtfInput[i] = new TField(xDia + 10, yDia + 8 + (TField.getHeight() + 18) * i + istouchMore + GameCanvas.hCommand, wDia - 20);
			mtfInput[i].setText(string.Empty);
		}
		if (GameCanvas.isTouch)
		{
			cmd.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			cmdClose.setPos(xDia + wDia - 13, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			if (GameCanvas.currentScreen != GameCanvas.createChar)
			{
				right = cmdClose;
			}
			left = cmd;
		}
		else
		{
			center = cmd;
			left = cmdClose;
		}
		if (!GameCanvas.isTouch)
		{
			mtfInput[0].setFocus(isFocus: true);
			right = mtfInput[0].cmdClear;
		}
		if (iscroll)
		{
			MainScreen.cameraSub.setAll(0, mtfInput.Length * hitem - hDia + GameCanvas.hCommand + 30, 0, 0);
			list = new ListNew(xDia, yDia, wDia, hDia, hitem, 0, MainScreen.cameraSub.yLimit);
		}
		if (typepaint == 0)
		{
			for (int j = 0; j < mtfInput.Length; j++)
			{
				mtfInput[j].setStringNull(info[j]);
			}
		}
		for (int k = 0; k < mtfInput.Length; k++)
		{
			mtfInput[k].setText(texmacdinh[k]);
		}
	}

	public void setinfo(string info, iCommand cmd, bool isNum, string nameInput)
	{
		isMore = false;
		isNew = false;
		left = null;
		right = null;
		center = null;
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		wDia = GameCanvas.w - 30;
		if (wDia > 200)
		{
			wDia = 200;
		}
		strinfo = fontInput.splitFontArray(info, wDia - 20);
		name = nameInput;
		hDia = 15 * strinfo.Length + 10 + TField.getHeight() + GameCanvas.hCommand;
		hDia += hTouch + istouchMore;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia + 15;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		tfInput = new TField(xDia + 10, yDia + hDia - hTouch - (TField.getHeight() + 8), wDia - 20);
		tfInput.isNotUseChangeTextBox = true;
		tfInput.setMaxTextLenght(100);
		if (isNum)
		{
			tfInput.setIputType(TField.INPUT_TYPE_NUMERIC);
		}
		tfInput.setText(string.Empty);
		if (!Main.isPC)
		{
			cmd.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			cmdClose.setPos(xDia + wDia - 13, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			right = cmdClose;
			left = cmd;
			tfInput.title = info;
		}
		else
		{
			cmd.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			center = cmd;
			left = cmdClose;
			tfInput.setFocus(isFocus: true);
			right = tfInput.cmdClear;
		}
	}

	public void setinfo(string[] info, iCommand cmd, short type, short idNPC, string name)
	{
		isMore = true;
		isNew = false;
		left = null;
		right = null;
		center = null;
		mtfInput = null;
		hitem = 50;
		this.type = type;
		this.idNPC = idNPC;
		if (cmd == null)
		{
			GameCanvas.subDialog = null;
		}
		wDia = GameCanvas.w - 30;
		if (wDia > 140)
		{
			wDia = 140;
		}
		mtfInput = new TField[info.Length];
		strinfo = info;
		this.name = name;
		if (mtfInput.Length > 3)
		{
			iscroll = true;
		}
		if (iscroll)
		{
			wDia = GameCanvas.w / 4 * 3;
			hDia = GameCanvas.h / 5 * 4;
			wDia = GameCanvas.w - 30;
			if (wDia > 140)
			{
				wDia = 140;
			}
			if (hDia < 210)
			{
				hDia = 210;
			}
			else if (hDia > 280)
			{
				hDia = 280;
			}
			if (hDia < 210)
			{
				hDia = 210;
			}
			else if (hDia > 280)
			{
				hDia = 280;
			}
			xDia = GameCanvas.hw - wDia / 2;
			yDia = GameCanvas.hh - hDia / 2;
			if (yDia < 20)
			{
				yDia = 20;
			}
			if (GameCanvas.isSmallScreen)
			{
				yDia = 0;
			}
		}
		else
		{
			hDia = (TField.getHeight() + 18) * strinfo.Length + 6 + GameCanvas.hCommand;
			hDia += hTouch + istouchMore;
			xDia = GameCanvas.hw - wDia / 2;
			yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia + 15;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		for (int i = 0; i < mtfInput.Length; i++)
		{
			mtfInput[i] = new TField(xDia + 10, yDia + 8 + (TField.getHeight() + 18) * i + istouchMore + GameCanvas.hCommand, wDia - 20);
			mtfInput[i].setText(string.Empty);
		}
		if (GameCanvas.isTouch)
		{
			cmd.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			cmdClose.setPos(xDia + wDia - 13, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			right = cmdClose;
			left = cmd;
		}
		else
		{
			center = cmd;
			left = cmdClose;
		}
		if (!GameCanvas.isTouch)
		{
			mtfInput[0].setFocus(isFocus: true);
			right = mtfInput[0].cmdClear;
		}
		if (iscroll)
		{
			MainScreen.cameraSub.setAll(0, mtfInput.Length * hitem - hDia + GameCanvas.hCommand + 30, 0, 0);
			list = new ListNew(xDia, yDia, wDia, hDia, hitem, 0, MainScreen.cameraSub.yLimit);
		}
	}

	public void setinfoSmallNew(string info, iCommand cmd, bool isNum, int defValue, long price, string xuluong)
	{
		isMore = false;
		isNew = true;
		left = null;
		right = null;
		center = null;
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.price = price;
		this.info = info;
		name = string.Empty;
		this.xuluong = xuluong;
		wDia = GameCanvas.w / 3 * 2;
		if (wDia > 160)
		{
			wDia = 160;
		}
		string empty = string.Empty;
		strinfo = fontInput.splitFontArray(info + " " + empty, wDia - 20);
		hDia = 15 * strinfo.Length + 10 + TField.getHeight() + GameCanvas.hCommand;
		hDia += hTouch + istouchMore;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia + 15;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		int num = wDia - 100;
		if (num < 40)
		{
			num = 40;
		}
		tfInput = new TField(xDia + wDia / 2 - num / 2, yDia + hDia - hTouch - (TField.getHeight() + 8), num);
		if (isNum)
		{
			tfInput.setIputType(TField.INPUT_TYPE_NUMERIC);
		}
		if (defValue >= 0)
		{
			tfInput.setText(string.Empty + defValue);
		}
		strtam = tfInput.getText();
		if (GameCanvas.isTouch)
		{
			cmd.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			cmdClose.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			right = cmdClose;
			left = cmd;
		}
		else
		{
			center = cmd;
			left = cmdClose;
			tfInput.setFocus(isFocus: true);
			right = tfInput.cmdClear;
		}
	}

	public void setinfoSmallNew(string info, iCommand cmd, bool isNum, int defValue, long price, string name, string xuluong)
	{
		isMore = false;
		isNew = true;
		left = null;
		right = null;
		center = null;
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.price = price;
		this.info = info;
		this.name = name;
		this.xuluong = xuluong;
		wDia = GameCanvas.w / 3 * 2;
		if (wDia > 160)
		{
			wDia = 160;
		}
		string text = "\n" + T.price + " " + price + " " + xuluong;
		strinfo = fontInput.splitFontArray(info + " " + text, wDia - 20);
		hDia = 15 * strinfo.Length + 10 + TField.getHeight() + GameCanvas.hCommand;
		hDia += hTouch + istouchMore;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia + 15;
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		int num = wDia - 100;
		if (num < 40)
		{
			num = 40;
		}
		tfInput = new TField(xDia + wDia / 2 - num / 2, yDia + hDia - hTouch - (TField.getHeight() + 8), num);
		tfInput.isNotUseChangeTextBox = true;
		if (isNum)
		{
			tfInput.setIputType(TField.INPUT_TYPE_NUMERIC);
		}
		if (defValue >= 0)
		{
			tfInput.setText(string.Empty + defValue);
		}
		strtam = tfInput.getText();
		if (!Main.isPC)
		{
			cmd.setPos(xDia + wDia / 2, yDia + hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			cmdClose.setPos(xDia + wDia - 12, yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			right = cmdClose;
			left = cmd;
		}
		else
		{
			center = cmd;
			left = cmdClose;
			tfInput.setFocus(isFocus: true);
			right = tfInput.cmdClear;
		}
	}

	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		paintFormList(g, xDia, yDia, wDia, hDia, name);
		if (iscroll)
		{
			g.setClip(xDia + 10, yDia + GameCanvas.hCommand, wDia, hDia - hitem - 10);
			g.translate(0, -MainScreen.cameraSub.yCam);
		}
		int num = yDia + istouchMore + GameCanvas.hCommand;
		if (isMore)
		{
			for (int i = 0; i < mtfInput.Length; i++)
			{
				fontInput.drawString(g, strinfo[i], GameCanvas.w / 2, num - 5 + i * (TField.getHeight() + 18), 2, mGraphics.isTrue);
				mtfInput[i].paintByList(g);
			}
		}
		else
		{
			for (int j = 0; j < strinfo.Length; j++)
			{
				fontInput.drawString(g, strinfo[j], GameCanvas.w / 2, num + j * 15 - 5, 2, mGraphics.isTrue);
			}
			tfInput.paintByList(g);
		}
		GameCanvas.resetTrans(g);
		paintCmd(g);
	}

	public override void keypress(int keyCode)
	{
		if (isMore)
		{
			for (int i = 0; i < mtfInput.Length; i++)
			{
				if (mtfInput[i].isFocusedz())
				{
					mtfInput[i].keyPressed(keyCode);
					return;
				}
			}
		}
		else
		{
			tfInput.keyPressed(keyCode);
		}
		base.keypress(keyCode);
	}

	public override void update()
	{
		updatekey();
		updatePointer();
		if (isMore)
		{
			for (int i = 0; i < mtfInput.Length; i++)
			{
				mtfInput[i].update();
			}
		}
		else if (tfInput != null)
		{
			if (tfInput.isnewTF && tfInput.isFocus && !newinput.input.isFocused)
			{
				((Selectable)newinput.input).Select();
				newinput.input.ActivateInputField();
			}
			tfInput.update();
			if (Main.isPC && right != tfInput.cmdClear)
			{
				right = tfInput.cmdClear;
			}
			if (isNew && tfInput.getText().CompareTo(strtam) != 0)
			{
				strtam = tfInput.getText();
				int num = 0;
				try
				{
					num = int.Parse(strtam);
				}
				catch (Exception)
				{
					num = 0;
				}
				string text = "\n" + T.price + " " + price * num + " " + xuluong;
				strinfo = fontInput.splitFontArray(info + " " + text, wDia - 20);
				hDia = 15 * strinfo.Length + 10 + TField.getHeight() + hTouch + istouchMore + GameCanvas.hCommand;
				int num2 = wDia - 100;
				if (num2 < 40)
				{
					num2 = 40;
				}
				xDia = GameCanvas.hw - wDia / 2;
				yDia = GameCanvas.h - GameCanvas.hCommand * 2 - hDia + 15;
				numw = (wDia - 6) / 32;
				numh = (hDia - 6) / 32;
				tfInput.x = xDia + wDia / 2 - num2 / 2;
				tfInput.y = yDia + hDia - (TField.getHeight() + 8) - hTouch;
			}
		}
		base.update();
	}

	public override void updatekey()
	{
		if (isMore)
		{
			int num = idSelect;
			if (GameCanvas.keyMyHold[8])
			{
				for (int i = 0; i < mtfInput.Length; i++)
				{
					if (!mtfInput[i].isFocusedz())
					{
						continue;
					}
					mtfInput[i].setFocus(isFocus: false);
					if (i < mtfInput.Length - 1)
					{
						mtfInput[i + 1].setFocus(isFocus: true);
						idSelect = i + 1;
						if (Main.isPC)
						{
							right = mtfInput[i + 1].cmdClear;
						}
					}
					else
					{
						mtfInput[0].setFocus(isFocus: true);
						idSelect = 0;
						if (Main.isPC)
						{
							right = mtfInput[0].cmdClear;
						}
					}
					break;
				}
				GameCanvas.clearKeyHold(8);
			}
			else if (GameCanvas.keyMyHold[2] && !Main.isPC)
			{
				for (int j = 0; j < mtfInput.Length; j++)
				{
					if (mtfInput[j].isFocusedz())
					{
						mtfInput[j].setFocus(isFocus: false);
						if (j > 0)
						{
							mtfInput[j - 1].setFocus(isFocus: true);
							idSelect = j - 1;
						}
						else
						{
							mtfInput[mtfInput.Length - 1].setFocus(isFocus: true);
							idSelect = mtfInput.Length - 1;
						}
						break;
					}
				}
				GameCanvas.clearKeyHold(2);
			}
			idSelect = resetSelect(idSelect, mtfInput.Length - 1, isreset: false);
			if (num != idSelect && !Main.isPC)
			{
				MainScreen.cameraSub.moveCamera(0, idSelect * 40 - hDia / 2 + 40 + GameCanvas.hCommand);
			}
		}
		base.updatekey();
	}

	public string[] getarrayText()
	{
		string[] array = new string[mtfInput.Length];
		for (int i = 0; i < mtfInput.Length; i++)
		{
			array[i] = mtfInput[i].getText();
		}
		return array;
	}

	public override void updatePointer()
	{
		base.updatePointer();
		if (isMore)
		{
			if (iscroll)
			{
				if (GameCanvas.isTouch && list != null)
				{
					list.moveCamera();
					list.update_Pos_UP_DOWN();
					MainScreen.cameraSub.yCam = list.cmx;
				}
				else
				{
					MainScreen.cameraSub.UpdateCamera();
				}
				if (!GameCanvas.isPointSelect(xDia, yDia + GameCanvas.hCommand, wDia, hDia - GameCanvas.hCommand))
				{
					return;
				}
				for (int i = 0; i < mtfInput.Length; i++)
				{
					mtfInput[i].isFocus = false;
				}
				int num = (MainScreen.cameraSub.yCam + GameCanvas.py - yDia - GameCanvas.hCommand) / hitem;
				if (num >= 0 && num < mtfInput.Length)
				{
					if (GameCanvas.isTouch)
					{
						mtfInput[num].updatepointerByList();
					}
					else
					{
						mtfInput[num].update();
					}
				}
				GameCanvas.isPointerSelect = false;
			}
			else
			{
				for (int j = 0; j < mtfInput.Length; j++)
				{
					mtfInput[j].updatePoiter();
				}
			}
		}
		else if (tfInput != null)
		{
			tfInput.updatePoiter();
		}
	}
}
