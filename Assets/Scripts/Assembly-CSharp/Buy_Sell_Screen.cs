using System;

public class Buy_Sell_Screen : MainScreen
{
	public const sbyte TYPE_BUY_MOI = 0;

	public const sbyte TYPE_BUY_CHAPNHAN = 1;

	public const sbyte TYPE_BUY_GOIITEM = 2;

	public const sbyte TYPE_BUY_LAYITEM = 3;

	public const sbyte TYPE_BUY_KHOA = 4;

	public const sbyte TYPE_BUY_GIAODICH = 5;

	private int wDia;

	private int idSelect;

	private int idSelectBuy;

	private int maxSize;

	private int hDia;

	private int xDia;

	private int yDia;

	private int numw;

	private int numh;

	public string nameBuy = string.Empty;

	public static int[] mRedSell;

	public int typeActionBuySell = -1;

	public int[] moneyBuySell = new int[2];

	public static MainItem[][] mItemOther;

	public sbyte typeLock = -1;

	private bool isINVEN_BUY;

	public MainTabNew maintab;

	private int hItem;

	private Camera cameraDia = new Camera();

	public iCommand cmdGiaodich;

	public iCommand cmdLock;

	public iCommand cmdChuyentien;

	public iCommand cmdchat;

	private InputDialog input;

	private InputDialog inputChat;

	private ListNew list;

	public PopupChat[] mchat = new PopupChat[2];

	public string[] strchat = new string[2];

	private bool isSmall;

	private bool isTran;

	private int yCamBegin;

	public override void Show()
	{
		mSystem.outloi("goi ham show kia");
		Show(GameCanvas.currentScreen);
	}

	public override void Show(MainScreen screen)
	{
		lastScreen = screen;
		base.Show(screen.lastScreen);
		maintab.listContent = null;
	}

	public override void commandTab(int index, int subIndex)
	{
		switch (index)
		{
		case 6:
			GameCanvas.start_Left_Dialog(T.banmuongiaodich, new iCommand(T.buySell, 1, this));
			break;
		case 7:
			setItemBuySell();
			break;
		case 8:
			GlobalService.gI().Buy_Sell(6, string.Empty, 0, 0, 0);
			break;
		case 9:
			doMenu();
			break;
		}
		GameCanvas.clearKeyHold();
		base.commandTab(index, subIndex);
	}

	public override void commandMenu(int index, int sub)
	{
		switch (index)
		{
		case 0:
			if (typeLock == -1)
			{
				typeLock = 1;
				left = null;
				center = null;
			}
			else if (typeLock == 0)
			{
				typeLock = 2;
				left = null;
				center = null;
			}
			GlobalService.gI().Buy_Sell(4, string.Empty, 0, 0, 0);
			MainTabNew.timePaintInfo = 0;
			break;
		case 1:
			input.setinfo(T.nhapsotien, new iCommand(T.xacnhan, 0, this), isNum: true, T.buySell);
			GameCanvas.currentDialog = input;
			break;
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			int num = 0;
			try
			{
				num = int.Parse(input.tfInput.getText());
			}
			catch (Exception)
			{
				num = 0;
			}
			if (num >= 0)
			{
				if (num <= GameScreen.player.coin)
				{
					moneyBuySell[0] = num;
					GlobalService.gI().Buy_Sell(7, string.Empty, 0, 0, num);
					GameCanvas.end_Dialog();
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.giatrinhapsai);
				}
			}
			break;
		}
		case 1:
			GlobalService.gI().Buy_Sell(5, string.Empty, 0, 0, 0);
			GameCanvas.end_Dialog();
			break;
		case 2:
		{
			string text = inputChat.tfInput.getText();
			if (text != null && text.Length != 0)
			{
				GlobalService.gI().Buy_Sell(9, text, 0, 0, 0);
				strchat[0] = text;
				inputChat.tfInput.setText(string.Empty);
			}
			break;
		}
		case 3:
			inputChat.setinfo(T.trochuyenvoi + nameBuy, new iCommand(T.chat, 2, this), isNum: false, T.buySell);
			GameCanvas.currentDialog = inputChat;
			break;
		}
	}

	public void setinfoBuySell(string name)
	{
		GameScreen.player.resetVx_vy();
		cmdGiaodich = new iCommand(T.buySell, 6);
		cmdLock = new iCommand(T.khoa, 0);
		cmdChuyentien = new iCommand(T.chuyentien, 1);
		cmdchat = new iCommand(T.chat, 3, this);
		if (!GameCanvas.isTouch)
		{
			center = new iCommand(T.select, 7);
		}
		left = new iCommand(T.menu, 9);
		right = new iCommand(T.cancel, 8);
		wDia = MainTabNew.wOneItem * 8;
		mRedSell = new int[9];
		for (int i = 0; i < mRedSell.Length; i++)
		{
			mRedSell[i] = -1;
		}
		mItemOther = new MainItem[2][];
		for (int j = 0; j < mItemOther.Length; j++)
		{
			mItemOther[j] = new MainItem[9];
		}
		moneyBuySell[0] = 0;
		moneyBuySell[1] = 0;
		input = new InputDialog();
		inputChat = new InputDialog();
		mchat[0] = null;
		mchat[1] = null;
		setmIdBuy(null);
		setmItemOther(null, 0, 0);
		nameBuy = name;
		idSelect = 0;
		idSelectBuy = 0;
		maxSize = Item.VecInvetoryPlayer.size();
		hDia = MainTabNew.wOneItem * 9 + GameCanvas.hCommand / 2 + 2;
		xDia = GameCanvas.hw - wDia / 2;
		yDia = GameCanvas.hh - GameCanvas.hCommand / 2 - hDia / 2 + 2;
		if (yDia < 0)
		{
			hDia = MainTabNew.wOneItem * 8 + 6;
			int num = iCommand.hButtonCmd;
			if (GameCanvas.isTouch)
			{
				num = 20;
			}
			yDia = GameCanvas.hh - hDia / 2 - num / 2;
			isSmall = true;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		cameraDia.setAll(0, ((maxSize - 1) / 3 - 6 + 1) * MainTabNew.wOneItem, 0, 0);
		list = new ListNew(xDia + MainTabNew.wOneItem * 4 - MainTabNew.wOneItem / 2, yDia + GameCanvas.hCommand + MainTabNew.wOneItem - MainTabNew.wOneItem / 2, MainTabNew.wOneItem * 4, MainTabNew.wOneItem * 6, 0, 0, cameraDia.yLimit);
		if (maxSize < 18)
		{
			maxSize = 18;
		}
		typeLock = -1;
		maintab = new MainTabNew();
		MainTabNew.timePaintInfo = 0;
		setPosCmd();
		if (GameCanvas.isTouch)
		{
			FrameImage fra = new FrameImage(PaintInfoGameScreen.imgOther[1], 25, 25);
			if (isSmall)
			{
				cmdchat.setPos(xDia + 15, yDia + GameCanvas.hCommand / 2 + 1, fra, string.Empty);
			}
			else
			{
				cmdchat.setPos(xDia + wDia - 25, yDia + 20, fra, string.Empty);
			}
		}
	}

	public void setPosCmd()
	{
		if (!GameCanvas.isTouch)
		{
			return;
		}
		if (isSmall)
		{
			if (left != null && center != null && right != null)
			{
				center.setPos(GameCanvas.hw, yDia + hDia + 10, PaintInfoGameScreen.fraButton2, center.caption);
				left.setPos(GameCanvas.hw - 66, yDia + hDia + 10, PaintInfoGameScreen.fraButton2, left.caption);
				right.setPos(GameCanvas.hw + 66, yDia + hDia + 10, PaintInfoGameScreen.fraButton2, right.caption);
				return;
			}
			if (left != null)
			{
				left.setPos(GameCanvas.hw - wDia / 4, yDia + hDia + 10, PaintInfoGameScreen.fraButton2, left.caption);
			}
			if (center != null)
			{
				center.setPos(GameCanvas.hw, yDia + hDia + 10, PaintInfoGameScreen.fraButton2, center.caption);
			}
			if (right != null)
			{
				right.setPos(GameCanvas.hw + wDia / 4, yDia + hDia + 10, PaintInfoGameScreen.fraButton2, right.caption);
			}
		}
		else if (left != null && center != null && right != null)
		{
			center.setPos(GameCanvas.hw, yDia + hDia, null, center.caption);
			left.setPos(GameCanvas.hw - 80, yDia + hDia, null, left.caption);
			right.setPos(GameCanvas.hw + 80, yDia + hDia, null, right.caption);
		}
		else
		{
			if (left != null)
			{
				left.setPos(GameCanvas.hw - 50, yDia + hDia, null, left.caption);
			}
			if (center != null)
			{
				center.setPos(GameCanvas.hw, yDia + hDia, null, center.caption);
			}
			if (right != null)
			{
				right.setPos(GameCanvas.hw + 50, yDia + hDia, null, right.caption);
			}
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
		int num = yDia;
		int xp = xDia + MainTabNew.wOneItem;
		AvMain.paintDialogNew(g, xDia, yDia, wDia, hDia, 0);
		if (!isSmall)
		{
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, GameCanvas.hw - 32, num + 8, 64, 14, 2);
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 32, 14, 0, GameCanvas.hw - 32 + i * 32, num + 8, 0, mGraphics.isTrue);
				}
			}
			mFont.tahoma_7b_white.drawString(g, T.buySell, GameCanvas.hw, num + 9, 2, mGraphics.isTrue);
			num = yDia + GameCanvas.hCommand;
		}
		if (GameCanvas.isTouch && typeLock != 2)
		{
			cmdchat.paint(g, cmdchat.xCmd, cmdchat.yCmd);
		}
		paintBuySell(g, xp, num);
		GameCanvas.resetTrans(g);
		for (int j = 0; j < mchat.Length; j++)
		{
			if (mchat[j] != null)
			{
				mchat[j].paint(g);
			}
		}
		base.paint(g);
	}

	public void paintBuySell(mGraphics g, int xp, int yp)
	{
		g.setColor(12298905);
		AvMain.paintRectNice(g, xp + MainTabNew.wOneItem * 3, yp + MainTabNew.wOneItem, MainTabNew.wOneItem * 3, MainTabNew.wOneItem * 6, 2);
		AvMain.paintRectNice(g, xp, yp + MainTabNew.wOneItem, MainTabNew.wOneItem * 3, MainTabNew.wOneItem * 6, 1);
		g.drawRect(xp, yp + MainTabNew.wOneItem, MainTabNew.wOneItem * 6, MainTabNew.wOneItem * 6, mGraphics.isTrue);
		g.setColor(12298905);
		int num = 0;
		if (GameCanvas.isSmallScreen)
		{
			num = 2;
		}
		mFont.tahoma_7b_black.drawString(g, GameScreen.player.name, xp + (isSmall ? 5 : 0), yp + MainTabNew.wOneItem / 4, 0, mGraphics.isTrue);
		if (typeActionBuySell == 0)
		{
			mFont.tahoma_7b_red.drawString(g, "- Ok -", xp + MainTabNew.wOneItem * 3, yp + MainTabNew.wOneItem / 4, 2, mGraphics.isTrue);
		}
		mFont.tahoma_7b_black.drawString(g, nameBuy, xp, yp + MainTabNew.wOneItem / 4 + MainTabNew.wOneItem * 7 - num, 0, mGraphics.isTrue);
		if (typeActionBuySell == 1)
		{
			mFont.tahoma_7b_red.drawString(g, "- Ok -", xp + MainTabNew.wOneItem * 3, yp + MainTabNew.wOneItem / 4 + MainTabNew.wOneItem * 7 - num, 2, mGraphics.isTrue);
		}
		if (moneyBuySell[0] > 0)
		{
			mFont.tahoma_7_black.drawString(g, moneyBuySell[0] + " $", xp + MainTabNew.wOneItem * 6, yp + MainTabNew.wOneItem / 4, 1, mGraphics.isTrue);
		}
		if (moneyBuySell[1] > 0)
		{
			mFont.tahoma_7_black.drawString(g, moneyBuySell[1] + " $", xp + MainTabNew.wOneItem * 6, yp + MainTabNew.wOneItem / 4 + MainTabNew.wOneItem * 7 - num, 1, mGraphics.isTrue);
		}
		g.setClip(xp, yp + MainTabNew.wOneItem, MainTabNew.wOneItem * 6, MainTabNew.wOneItem * 6);
		g.translate(0, -cameraDia.yCam);
		if (typeLock == -1 || typeLock == 0)
		{
			for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
			{
				MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
				if (mainItem.ItemCatagory == 7)
				{
					MainItem material = Item.getMaterial(mainItem.Id);
					if (material != null)
					{
						material.paintItem(g, xp + MainTabNew.wOneItem * 3 + MainTabNew.wOneItem / 2 + i % 3 * MainTabNew.wOneItem, yp + MainTabNew.wOneItem + MainTabNew.wOneItem / 2 + i / 3 * MainTabNew.wOneItem, MainTabNew.wOneItem, 0, 0);
					}
					else
					{
						Item.put_Material(mainItem.Id);
					}
				}
				else
				{
					mainItem.paintItem(g, xp + MainTabNew.wOneItem * 3 + MainTabNew.wOneItem / 2 + i % 3 * MainTabNew.wOneItem, yp + MainTabNew.wOneItem + MainTabNew.wOneItem / 2 + i / 3 * MainTabNew.wOneItem, MainTabNew.wOneItem, 0, 0);
				}
				if (mainItem.canTrade == 0)
				{
					g.drawRegion(AvMain.imgDelaySkill, 0, 0, MainTabNew.wOneItem - 1, MainTabNew.wOneItem - 1, 0, xp + MainTabNew.wOneItem * 3 + MainTabNew.wOneItem / 2 + i % 3 * MainTabNew.wOneItem, yp + MainTabNew.wOneItem + MainTabNew.wOneItem / 2 + i / 3 * MainTabNew.wOneItem, 3, mGraphics.isTrue);
				}
			}
			g.setColor(14040109);
			for (int j = 0; j < mRedSell.Length; j++)
			{
				if (mRedSell[j] >= 0)
				{
					g.drawRect(xp + MainTabNew.wOneItem * 3 + mRedSell[j] % 3 * MainTabNew.wOneItem + 3, yp + MainTabNew.wOneItem + mRedSell[j] / 3 * MainTabNew.wOneItem + 3, MainTabNew.wOneItem - 6, MainTabNew.wOneItem - 6, mGraphics.isTrue);
				}
			}
		}
		g.setColor(12298905);
		g.drawRect(xp + MainTabNew.wOneItem * 4, yp + MainTabNew.wOneItem, MainTabNew.wOneItem, MainTabNew.wOneItem * (maxSize / 3), mGraphics.isTrue);
		for (int k = 0; k < maxSize / 3 + 1; k++)
		{
			g.fillRect(xp + MainTabNew.wOneItem * 3, yp + MainTabNew.wOneItem + MainTabNew.wOneItem * k, MainTabNew.wOneItem * 3, 1, mGraphics.isTrue);
		}
		g.setColor(16777215);
		if (!isINVEN_BUY && typeLock < 1 && idSelect >= 0)
		{
			g.drawRect(xp + MainTabNew.wOneItem * (3 + idSelect % 3) + 1, yp + MainTabNew.wOneItem * (idSelect / 3 + 1) + 1, MainTabNew.wOneItem - 2, MainTabNew.wOneItem - 2, mGraphics.isTrue);
		}
		GameCanvas.resetTrans(g);
		for (int l = 0; l < mItemOther[0].Length; l++)
		{
			int num2 = xp + MainTabNew.wOneItem / 2 + l % 3 * MainTabNew.wOneItem;
			int num3 = yp + MainTabNew.wOneItem + MainTabNew.wOneItem / 2 + l / 3 * MainTabNew.wOneItem;
			if (mItemOther[0][l] != null)
			{
				if (mItemOther[0][l].ItemCatagory == 7)
				{
					MainItem material2 = Item.getMaterial(mItemOther[0][l].Id);
					if (material2 != null)
					{
						if (mItemOther[0][l].content == null)
						{
							mItemOther[0][l].itemName = material2.itemName;
							mItemOther[0][l].mMoreContent(material2.content);
							mItemOther[0][l].content = material2.content;
						}
					}
					else
					{
						Item.put_Material(mItemOther[0][l].Id);
					}
					mItemOther[0][l].paintItem(g, num2, num3, MainTabNew.wOneItem, 0, 0);
				}
				else
				{
					mItemOther[0][l].paintItem(g, num2, num3, MainTabNew.wOneItem, 0, 0);
				}
			}
			if (typeLock > 0)
			{
				g.setColor(14040109);
				g.drawRect(num2 - MainTabNew.wOneItem / 2 + 1, num3 - MainTabNew.wOneItem / 2 + 1, MainTabNew.wOneItem - 2, MainTabNew.wOneItem - 2, mGraphics.isTrue);
			}
			num2 = xp + MainTabNew.wOneItem / 2 + l % 3 * MainTabNew.wOneItem;
			num3 = yp + MainTabNew.wOneItem * 4 + MainTabNew.wOneItem / 2 + l / 3 * MainTabNew.wOneItem;
			if (mItemOther[1][l] != null)
			{
				if (mItemOther[1][l].ItemCatagory == 7)
				{
					MainItem material3 = Item.getMaterial(mItemOther[1][l].Id);
					if (material3 != null)
					{
						if (mItemOther[1][l].content == null)
						{
							mItemOther[1][l].itemName = material3.itemName;
							mItemOther[1][l].content = material3.content;
							mItemOther[1][l].mMoreContent(material3.content);
						}
					}
					else
					{
						Item.put_Material(mItemOther[1][l].Id);
					}
					mItemOther[1][l].paintItem(g, num2, num3, MainTabNew.wOneItem, 0, 0);
				}
				else
				{
					mItemOther[1][l].paintItem(g, num2, num3, MainTabNew.wOneItem, 0, 0);
				}
			}
			if (typeLock == 0 || typeLock == 2)
			{
				g.setColor(14040109);
				g.drawRect(num2 - MainTabNew.wOneItem / 2 + 1, num3 - MainTabNew.wOneItem / 2 + 1, MainTabNew.wOneItem - 2, MainTabNew.wOneItem - 2, mGraphics.isTrue);
			}
		}
		g.setColor(12298905);
		for (int m = 0; m < 3; m++)
		{
			g.drawRect(xp, yp + MainTabNew.wOneItem + MainTabNew.wOneItem * 2 * m, MainTabNew.wOneItem * (3 + ((m == 3) ? 3 : 0)), MainTabNew.wOneItem, mGraphics.isTrue);
		}
		g.drawRect(xp + MainTabNew.wOneItem, yp + MainTabNew.wOneItem, MainTabNew.wOneItem, MainTabNew.wOneItem * 6, mGraphics.isTrue);
		g.setColor(0);
		g.fillRect(xp + MainTabNew.wOneItem * 3, yp + MainTabNew.wOneItem + 1, 1, MainTabNew.wOneItem * 6 - 1, mGraphics.isTrue);
		g.fillRect(xp + 1, yp + MainTabNew.wOneItem * 4, MainTabNew.wOneItem * 3, 1, mGraphics.isTrue);
		g.setColor(16777215);
		if (isINVEN_BUY && idSelectBuy >= 0)
		{
			g.drawRect(xp + MainTabNew.wOneItem * (idSelectBuy % 3) + 1, yp + MainTabNew.wOneItem * (idSelectBuy / 3 + 4) + 1, MainTabNew.wOneItem - 2, MainTabNew.wOneItem - 2, mGraphics.isTrue);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			g.translate(0, -cameraDia.yCam);
			maintab.paintContent(g, isOnlyName: false);
		}
		GameCanvas.resetTrans(g);
	}

	public void doMenu()
	{
		mVector mVector3 = new mVector("Buy_sell_scr menu");
		mVector3.addElement(cmdChuyentien);
		mVector3.addElement(cmdLock);
		if (!GameCanvas.isTouch)
		{
			mVector3.addElement(cmdchat);
		}
		GameCanvas.menu2.startAt(mVector3, 2, T.select, isFocus: false, null);
	}

	public void setmIdBuy(MainItem item)
	{
		if (item == null)
		{
			for (int i = 0; i < mItemOther[0].Length; i++)
			{
				mItemOther[0][i] = null;
			}
			return;
		}
		for (int j = 0; j < mItemOther[0].Length; j++)
		{
			if (mItemOther[0][j] != null && mItemOther[0][j].ItemCatagory == item.ItemCatagory && mItemOther[0][j].Id == item.Id)
			{
				GlobalService.gI().Buy_Sell(3, string.Empty, (sbyte)item.ItemCatagory, (short)item.Id, 0);
				mItemOther[0][j] = null;
				mRedSell[j] = -1;
				return;
			}
		}
		for (int k = 0; k < mItemOther[0].Length; k++)
		{
			if (mItemOther[0][k] == null)
			{
				mItemOther[0][k] = item;
				GlobalService.gI().Buy_Sell(2, string.Empty, (sbyte)item.ItemCatagory, (short)item.Id, 0);
				mRedSell[k] = idSelect;
				break;
			}
		}
	}

	public override void update()
	{
		lastScreen.update();
		if (maintab.listContent != null)
		{
			maintab.listContent.moveCamera();
		}
		if (GameCanvas.isTouch)
		{
			list.moveCamera();
		}
		else
		{
			cameraDia.UpdateCamera();
		}
		for (int i = 0; i < mchat.Length; i++)
		{
			if (mchat[i] != null && mchat[i].setOff())
			{
				mchat[i] = null;
			}
		}
		for (int j = 0; j < strchat.Length; j++)
		{
			if (strchat[j] != null)
			{
				ChatBuySell((sbyte)j, strchat[j]);
				strchat[j] = null;
			}
		}
	}

	public override void updatekey()
	{
		if (typeLock >= 1)
		{
			isINVEN_BUY = true;
		}
		if (isINVEN_BUY)
		{
			int num = idSelectBuy;
			if (maintab.listContent != null)
			{
				if (GameCanvas.keyMyHold[2])
				{
					if (maintab.listContent.cmtoX > 0)
					{
						maintab.listContent.cmtoX -= GameCanvas.hText;
					}
					else
					{
						maintab.listContent.cmtoX = 0;
					}
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					if (maintab.listContent.cmtoX < maintab.listContent.cmxLim)
					{
						maintab.listContent.cmtoX += GameCanvas.hText;
					}
					else
					{
						maintab.listContent.cmtoX = maintab.listContent.cmxLim;
					}
					GameCanvas.clearKeyHold(8);
				}
			}
			else if (GameCanvas.keyMyHold[2])
			{
				idSelectBuy -= 3;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				idSelectBuy += 3;
				GameCanvas.clearKeyHold(8);
			}
			if (GameCanvas.keyMyHold[4])
			{
				idSelectBuy--;
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				if (idSelectBuy % 3 == 2 && typeLock < 1)
				{
					isINVEN_BUY = false;
					MainTabNew.timePaintInfo = 0;
				}
				else
				{
					idSelectBuy++;
				}
				GameCanvas.clearKeyHold(6);
			}
			idSelectBuy = resetSelect(idSelectBuy, 8, isreset: false);
			if (idSelectBuy != num)
			{
				MainTabNew.timePaintInfo = 0;
				maintab.listContent = null;
			}
		}
		else
		{
			int num2 = idSelect;
			if (maintab.listContent != null)
			{
				if (GameCanvas.keyMyHold[2])
				{
					if (maintab.listContent.cmtoX > 0)
					{
						maintab.listContent.cmtoX -= GameCanvas.hText;
					}
					else
					{
						maintab.listContent.cmtoX = 0;
					}
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					if (maintab.listContent.cmtoX < maintab.listContent.cmxLim)
					{
						maintab.listContent.cmtoX += GameCanvas.hText;
					}
					else
					{
						maintab.listContent.cmtoX = maintab.listContent.cmxLim;
					}
					GameCanvas.clearKeyHold(8);
				}
			}
			else if (GameCanvas.keyMyHold[2])
			{
				idSelect -= 3;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				idSelect += 3;
				GameCanvas.clearKeyHold(8);
			}
			if (GameCanvas.keyMyHold[4])
			{
				if (idSelect % 3 == 0)
				{
					isINVEN_BUY = true;
					MainTabNew.timePaintInfo = 0;
				}
				else
				{
					idSelect--;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				idSelect++;
				GameCanvas.clearKeyHold(6);
			}
			if (!GameCanvas.isTouch)
			{
				idSelect = resetSelect(idSelect, Item.VecInvetoryPlayer.size() - 1, isreset: false);
			}
			if (idSelect < -1)
			{
				idSelect = -1;
			}
			else if (idSelect > Item.VecInvetoryPlayer.size() - 1)
			{
				idSelect = Item.VecInvetoryPlayer.size();
			}
			if (idSelect != num2 && idSelect >= 0)
			{
				cameraDia.moveCamera(0, (idSelect / 3 - 3) * MainTabNew.wOneItem);
				MainTabNew.timePaintInfo = 0;
			}
		}
		int num3 = idSelect;
		if (isINVEN_BUY)
		{
			num3 = idSelectBuy;
		}
		MainItem item = (isINVEN_BUY ? mItemOther[1][num3] : ((MainItem)Item.VecInvetoryPlayer.elementAt(num3)));
		updateContent(item);
		base.updatekey();
	}

	public override void updatePointer()
	{
		int num = xDia + MainTabNew.wOneItem;
		int num2 = yDia + MainTabNew.wOneItem;
		if (!isSmall)
		{
			num2 += GameCanvas.hCommand;
		}
		bool flag = false;
		if (maintab.listContent != null && GameCanvas.isPoint(maintab.listContent.x, maintab.listContent.y, maintab.listContent.maxW, maintab.listContent.maxH))
		{
			maintab.listContent.update_Pos_UP_DOWN();
			flag = true;
		}
		if (!flag)
		{
			if (GameCanvas.isPointerMove)
			{
				MainTabNew.timePaintInfo = 0;
			}
			if (GameCanvas.isTouch)
			{
				list.update_Pos_UP_DOWN();
				cameraDia.yCam = list.cmx;
			}
			if (typeLock < 1 && GameCanvas.isPointSelect(num + 3 * MainTabNew.wOneItem, num2, 3 * MainTabNew.wOneItem, 6 * MainTabNew.wOneItem))
			{
				int num3 = (GameCanvas.px - (num + 3 * MainTabNew.wOneItem)) / MainTabNew.wOneItem + (cameraDia.yCam + GameCanvas.py - num2) / MainTabNew.wOneItem * 3;
				int num4 = 0;
				num4 = Item.VecInvetoryPlayer.size();
				if (isINVEN_BUY)
				{
					idSelect = -1;
				}
				isINVEN_BUY = false;
				if (num3 >= 0 && num3 < num4)
				{
					GameCanvas.isPointerSelect = false;
					if (num3 == idSelect)
					{
						setItemBuySell();
					}
					else
					{
						idSelect = num3;
						MainTabNew.timePaintInfo = 0;
						maintab.listContent = null;
					}
				}
				else
				{
					idSelect = -1;
					MainTabNew.timePaintInfo = 0;
					maintab.listContent = null;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(num, num2 + 3 * MainTabNew.wOneItem, 3 * MainTabNew.wOneItem, 3 * MainTabNew.wOneItem))
			{
				int num5 = (GameCanvas.px - num) / MainTabNew.wOneItem + (GameCanvas.py - (num2 + 3 * MainTabNew.wOneItem)) / MainTabNew.wOneItem * 3;
				int num6 = 0;
				num6 = 9;
				if (!isINVEN_BUY)
				{
					MainTabNew.timePaintInfo = 0;
				}
				isINVEN_BUY = true;
				if (num5 >= 0 && num5 < num6)
				{
					GameCanvas.isPointerSelect = false;
					if (num5 != idSelectBuy)
					{
						idSelectBuy = num5;
						MainTabNew.timePaintInfo = 0;
					}
				}
				else
				{
					idSelectBuy = -1;
					MainTabNew.timePaintInfo = 0;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		if (GameCanvas.isTouch && typeLock != 2)
		{
			cmdchat.updatePointer();
		}
		base.updatePointer();
	}

	public static void setmItemOther(MainItem item, sbyte type, sbyte index)
	{
		if (item == null)
		{
			for (int i = 0; i < mItemOther.Length; i++)
			{
				mItemOther[1][i] = null;
			}
		}
		else if (type == 3)
		{
			for (int j = 0; j < mItemOther[index].Length; j++)
			{
				if (mItemOther[index][j] != null && mItemOther[index][j].ItemCatagory == item.ItemCatagory && mItemOther[index][j].Id == item.Id)
				{
					mItemOther[index][j] = null;
					if (index == 0)
					{
						mRedSell[j] = -1;
					}
					break;
				}
			}
		}
		else
		{
			if (type != 2)
			{
				return;
			}
			for (int k = 0; k < mItemOther[index].Length; k++)
			{
				if (mItemOther[index][k] == null)
				{
					mItemOther[index][k] = item;
					break;
				}
			}
		}
	}

	public void updateContent(MainItem item)
	{
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				setPaintInfo(item);
			}
		}
		if (maintab.mContent != null || item == null || item.ItemCatagory == 5)
		{
			return;
		}
		if (item.mcontent == null)
		{
			if (item.timeupdateMore % 100 == 3)
			{
				if (maintab.typeTab == MainTabNew.INVENTORY)
				{
					GlobalService.gI().Item_More_Info(0, (sbyte)item.Id);
				}
				item.timeupdateMore++;
			}
			else
			{
				item.timeupdateMore++;
			}
		}
		else
		{
			maintab.mContent = item.mcontent;
			maintab.mcolor = item.mColor;
			setYCon(item);
		}
	}

	public void setPaintInfo(MainItem item)
	{
		maintab.mContent = null;
		maintab.mSubContent = null;
		maintab.mPlusContent = null;
		if (item == null)
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		if (item.setNameNull())
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		maintab.wContent = item.sizeW;
		if (isINVEN_BUY)
		{
			maintab.xCon = xDia + MainTabNew.wOneItem * 4 + 3;
			if (maintab.xCon + maintab.wContent > GameCanvas.w - 3)
			{
				maintab.xCon = GameCanvas.w - 3 - maintab.wContent;
			}
		}
		else
		{
			maintab.xCon = xDia + MainTabNew.wOneItem * 4 - maintab.wContent - 3;
			if (maintab.xCon < 3)
			{
				maintab.xCon = 3;
			}
		}
		setYCon(item);
		maintab.name = item.itemName;
		maintab.mPlusContent = item.mPlusContent;
		maintab.mPlusColor = item.mPlusColor;
		maintab.colorName = item.colorNameItem;
	}

	public void setYCon(MainItem item)
	{
		int num = 1;
		maintab.mContent = item.mcontent;
		maintab.mcolor = item.mColor;
		if (item.mcontent != null)
		{
			num += maintab.mContent.Length;
		}
		if (item.mPlusContent != null)
		{
			num += item.mPlusContent.Length;
		}
		int num2 = idSelect;
		int num3 = 0;
		if (isINVEN_BUY)
		{
			num2 = idSelectBuy + 9;
			num3 = cameraDia.yCam;
		}
		maintab.yCon = (num2 / 3 + 1) * MainTabNew.wOneItem - num * GameCanvas.hText + yDia + GameCanvas.hCommand + num3;
		if (maintab.yCon - cameraDia.yCam < 3)
		{
			maintab.yCon = 3 + cameraDia.yCam;
		}
		maintab.listContent = null;
		if ((num + 1) * GameCanvas.hText > MainTabNew.hMaxContent)
		{
			maintab.listContent = new ListNew(maintab.xCon, maintab.yCon, maintab.wContent, MainTabNew.hMaxContent, 0, 0, (num + 1) * GameCanvas.hText - MainTabNew.hMaxContent);
		}
	}

	public void setItemBuySell()
	{
		MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
		if (mainItem.canTrade == 0)
		{
			GameCanvas.start_Ok_Dialog(T.khongthetraodoi);
		}
		else
		{
			setmIdBuy(mainItem);
		}
	}

	public int tinhThue(int value)
	{
		int result = 0;
		if (value > 5000000)
		{
			result = (value - 5000000) * 30 / 100 + 1250000;
		}
		else if (value > 5000000)
		{
			result = (value - 5000000) * 30 / 100 + 1250000;
		}
		return result;
	}

	public void ChatBuySell(sbyte index, string str)
	{
		if (str != null && str.Length != 0)
		{
			if (mchat[index] == null)
			{
				mchat[index] = new PopupChat();
			}
			mchat[index].setChat(str, isStop: true);
			int num = yDia;
			if (!isSmall)
			{
				num = yDia + GameCanvas.hCommand;
			}
			int num2 = xDia + MainTabNew.wOneItem;
			if (index == 0)
			{
				mchat[index].indexpaint = 1;
				mchat[index].updatePos(num2 + MainTabNew.wOneItem, num + MainTabNew.wOneItem + mchat[index].h);
			}
			else
			{
				mchat[index].updatePos(num2 + MainTabNew.wOneItem, num + MainTabNew.wOneItem * 7);
			}
		}
	}
}
