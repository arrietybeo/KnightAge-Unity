using System;

public class MainHelp : AvMain
{
	public const sbyte FRIST = 0;

	public const sbyte LAST = 1;

	public const sbyte POINT_FRAME = 0;

	public const sbyte POPUP_HAND = 1;

	public const sbyte POS_NULL = -1;

	public const sbyte POS_LEFT = 0;

	public const sbyte POS_RIGHT = 1;

	public const sbyte POS_CENTER = 2;

	public const sbyte POS_TOP_LEFT = 3;

	public const sbyte POS_TOP_RIGHT = 4;

	public const sbyte POS_TOP_CENTER = 5;

	public const sbyte POS_TOP_NULL = 6;

	public const sbyte POS_LEFT_CENTER = 7;

	public const sbyte POS_RIGHT_CENTER = 8;

	public int Step = -1;

	public int Next = -5;

	public int idTabHelp = -2;

	public int tickBegin;

	public int timeReset;

	private iCommand cmdNext;

	public Point p;

	public FrameImage fra;

	public string[] strpopup;

	public new static int[] color = new int[2] { 3349556, 16760428 };

	private bool isStepp5;

	public MainHelp()
	{
		cmdNext = new iCommand(T.next, 0, this);
	}

	public void setCaptionCmd()
	{
		cmdNext.caption = T.next;
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			Next++;
			setNext();
			break;
		case 1:
			GameCanvas.end_Dialog_Help();
			p = null;
			Step = -1;
			Next = 0;
			setNext();
			SaveStep();
			break;
		}
	}

	public void loadBeginGame(sbyte[] bData)
	{
		if (bData == null)
		{
			Step = 0;
			Next = -5;
		}
	}

	public void LoadStep(sbyte[] bData)
	{
		p = null;
		if (bData == null)
		{
			Step = 0;
			Next = -5;
			return;
		}
		DataInputStream dataInputStream = new DataInputStream(bData);
		try
		{
			Step = dataInputStream.readByte();
			Next = dataInputStream.readByte();
		}
		catch (Exception)
		{
			Step = -1;
			Next = 0;
		}
		mSystem.outz("next=" + Next + "  step=" + Step);
		if (GameCanvas.currentScreen != GameCanvas.load)
		{
			setNext();
		}
	}

	public void SaveStep()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(Step);
			dataOutputStream.writeByte(Next);
			CRes.saveRMSName(1, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public void SaveStep(sbyte step, sbyte next)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(step);
			dataOutputStream.writeByte(next);
			CRes.saveRMSName(1, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public void SaveBegin()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(0);
			CRes.saveRMSName(2, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public void NextStep()
	{
		Step++;
		Next = 0;
	}

	public void setNext()
	{
		if (GameCanvas.loadmap.idMap != 0 || GameScreen.isFinishHelp)
		{
			return;
		}
		cmdNext.caption = T.next;
		idTabHelp = -2;
		if (isSave())
		{
			SaveStep();
		}
		if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
		{
			if (Step == 0 && Next == 1)
			{
				Step = 0;
				Next = 2;
				SaveStep();
			}
			if (Step == 1 && Next == 8)
			{
				Step = 1;
				Next = 9;
				SaveStep();
			}
			if (Step == 2 && Next == 6)
			{
				Step = 2;
				Next = 7;
				SaveStep();
			}
			if (Step == 2 && Next == 11)
			{
				Step = 4;
				Next = 9;
				SaveStep();
			}
			if (Step == 7 && Next == 1)
			{
				Step = 8;
				Next = 0;
				SaveStep();
			}
			if (Step == 6 && Next == 1)
			{
				Step = 6;
				Next = 2;
				SaveStep();
			}
		}
		string[][] str = T.mHelp;
		if (GameCanvas.isTouch)
		{
			switch (Step)
			{
			case 0:
				if (Next == 2)
				{
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog9 = new MsgDialog();
						if (Main.isPC)
						{
							msgDialog9.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, GameCanvas.hw - 45, PaintInfoGameScreen.yPointMove - PaintInfoGameScreen.wArrowMove - 5, 6, false, 90);
						}
						else
						{
							msgDialog9.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, PaintInfoGameScreen.xPointMove - 45, PaintInfoGameScreen.yPointMove - PaintInfoGameScreen.wArrowMove - 5, 2, false, 90);
						}
						GameCanvas.currentDialog = msgDialog9;
					}
					return;
				}
				if (Next == 3)
				{
					str = T.mHelpPoint;
				}
				break;
			case 1:
				if (Next == 0)
				{
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog7 = new MsgDialog();
						if (Main.isPC)
						{
							msgDialog7.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, GameCanvas.hw - 40, PaintInfoGameScreen.yPointKill - 40, -1, false, 80);
						}
						else
						{
							msgDialog7.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, PaintInfoGameScreen.xPointKill - 40, PaintInfoGameScreen.yPointKill - 40, 2, false, 80);
						}
						GameCanvas.currentDialog = msgDialog7;
					}
					return;
				}
				if (Next == 8)
				{
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog8 = new MsgDialog();
						msgDialog8.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, PaintInfoGameScreen.mPosOther[0][0], PaintInfoGameScreen.mPosOther[0][1] + 22, 3, false, 90);
						GameCanvas.currentDialog = msgDialog8;
					}
					return;
				}
				if (Next == 9)
				{
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						p = new Point();
						p.x = PaintInfoGameScreen.mPosOther[0][0];
						p.w = 80;
						strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[Step][Next], p.w);
						p.h = strpopup.Length * GameCanvas.hText;
						p.y = PaintInfoGameScreen.mPosOther[0][1] + 22 + p.h;
						p.fRe = 3;
						p.dis = 1;
						p.frame = 1;
					}
					return;
				}
				break;
			case 2:
				switch (Next)
				{
				case 2:
				case 3:
				case 7:
					str = T.mHelpPoint;
					break;
				case 4:
				case 9:
				case 10:
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						p = new Point();
						p.x = MainTabNew.gI().xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 4;
						p.w = 80;
						strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[Step][Next], p.w);
						p.h = strpopup.Length * GameCanvas.hText;
						p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + p.h;
						p.fRe = 3;
						p.dis = 1;
						p.frame = 1;
					}
					idTabHelp = MainTabNew.INVENTORY;
					return;
				}
				break;
			case 3:
				switch (Next)
				{
				case 4:
					if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
					{
						GameCanvas.end_Dialog_Help();
						int num = 3;
						for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
						{
							MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
							if (mainItem.ItemCatagory == 3)
							{
								num = i + 1;
								break;
							}
						}
						mSystem.println("index " + num);
						if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
						{
							p = new Point();
							p.x = MainTabNew.gI().xTab + MainTabNew.wOneItem * num - 40 + MainTabNew.wOne5 * 4;
							p.w = 80;
							strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[Step][Next], p.w);
							p.h = strpopup.Length * GameCanvas.hText;
							p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + p.h;
							p.fRe = 5;
							p.dis = 1;
							p.frame = 1;
						}
						idTabHelp = MainTabNew.INVENTORY;
					}
					else
					{
						GameCanvas.end_Dialog_Help();
						if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
						{
							p = new Point();
							p.x = MainTabNew.gI().xTab + MainTabNew.wOneItem * 3 - 40 + MainTabNew.wOne5 * 4;
							p.w = 80;
							strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[Step][Next], p.w);
							p.h = strpopup.Length * GameCanvas.hText;
							p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + p.h;
							p.fRe = 5;
							p.dis = 1;
							p.frame = 1;
						}
						idTabHelp = MainTabNew.INVENTORY;
					}
					return;
				case 8:
					str = T.mHelpPoint;
					break;
				}
				break;
			case 4:
				if (Next == 9)
				{
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						p = new Point();
						p.x = TabScreenNew.xback;
						p.y = TabScreenNew.yback - iCommand.hButtonCmd;
						p.w = 80;
						strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[Step][Next], p.w);
						p.h = strpopup.Length * GameCanvas.hText;
						p.fRe = 0;
						p.dis = 1;
						p.frame = 1;
					}
					idTabHelp = -1;
					return;
				}
				break;
			case 5:
				switch (Next)
				{
				case 1:
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog6 = new MsgDialog();
						msgDialog6.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, GameCanvas.w - 96, GameCanvas.minimap.maxY * MiniMap.wMini + 16, 5, false, 90);
						GameCanvas.currentDialog = msgDialog6;
					}
					return;
				case 2:
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog5 = new MsgDialog();
						msgDialog5.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, GameCanvas.w - 96, GameCanvas.minimap.maxY * MiniMap.wMini + 16, 6, false, 90);
						GameCanvas.currentDialog = msgDialog5;
					}
					GameCanvas.minimap.setPoint(51, 2, GameCanvas.loadmap.idMap);
					return;
				case 4:
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog3 = new MsgDialog();
						msgDialog3.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini - 96, 45, 4, false, 90);
						GameCanvas.currentDialog = msgDialog3;
					}
					return;
				case 5:
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog2 = new MsgDialog();
						msgDialog2.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, (!Main.isPC) ? (PaintInfoGameScreen.mPosOther[3][0] - 96 + 25) : (GameCanvas.hw - 45), PaintInfoGameScreen.mPosOther[3][1] - 10, (!Main.isPC) ? 1 : (-1), false, 90);
						GameCanvas.currentDialog = msgDialog2;
					}
					return;
				case 6:
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog4 = new MsgDialog();
						msgDialog4.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, PaintInfoGameScreen.mPosOther[2][0] - 96 + 25, PaintInfoGameScreen.mPosOther[2][1] - 10, 1, false, 90);
						GameCanvas.currentDialog = msgDialog4;
					}
					return;
				case 7:
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						MsgDialog msgDialog = new MsgDialog();
						msgDialog.setDiaHelp(T.mHelpPoint[Step][Next], cmdNext, PaintInfoGameScreen.mPosOther[1][0], PaintInfoGameScreen.mPosOther[1][1] + 45, 3, false, 90);
						GameCanvas.currentDialog = msgDialog;
					}
					return;
				}
				break;
			case 6:
				if (Next == 2)
				{
					GameCanvas.end_Dialog_Help();
					if (Next < T.mHelpPoint[Step].Length && T.mHelpPoint[Step][Next].Length > 0)
					{
						p = new Point();
						p.x = PaintInfoGameScreen.mPosOther[0][0];
						p.w = 80;
						strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[Step][Next], p.w);
						p.h = strpopup.Length * GameCanvas.hText;
						p.y = PaintInfoGameScreen.mPosOther[0][1] + p.h + 22;
						p.fRe = 3;
						p.dis = 1;
						p.frame = 1;
					}
					return;
				}
				break;
			case 7:
				switch (Next)
				{
				case 6:
				case 9:
					str = T.mHelpPoint;
					break;
				}
				break;
			case 8:
				if (Next == 7)
				{
					str = T.mHelpPoint;
				}
				break;
			case 9:
				if (Next == 1 || Next == 5)
				{
					str = T.mHelpPoint;
				}
				break;
			}
		}
		switch (Step)
		{
		case 0:
			Step0(str);
			break;
		case 1:
			Step1(str);
			break;
		case 2:
			Step2(str);
			break;
		case 3:
			Step3(str);
			break;
		case 4:
			Step4(str);
			break;
		case 5:
			Step5(str);
			break;
		case 6:
			Step6(str);
			break;
		case 7:
			Step7(str);
			break;
		case 8:
			Step8(str);
			break;
		case 9:
			Step9(str);
			break;
		}
	}

	public bool isSave()
	{
		switch (Step)
		{
		case 0:
			if (Next == 0)
			{
				return true;
			}
			break;
		case 1:
			if (Next == 1 || Next == 9)
			{
				return true;
			}
			break;
		case 2:
			if (Next == 4 || Next == 9)
			{
				return true;
			}
			break;
		case 3:
			if (Next == 4 || Next == 8)
			{
				return true;
			}
			break;
		case 5:
			if (Next == 0 || Next == 8)
			{
				return true;
			}
			break;
		case 6:
			if (Next == 2 || Next == 0)
			{
				return true;
			}
			break;
		case 7:
			if (Next == 6 || Next == 9)
			{
				return true;
			}
			break;
		case 8:
			if (Next == 7 || Next == 10)
			{
				return true;
			}
			break;
		case 9:
			if (Next == 1 || Next == 7)
			{
				return true;
			}
			break;
		}
		return false;
	}

	public bool setStep_Next(int s, int n)
	{
		if (Step == s && Next == n)
		{
			return true;
		}
		return false;
	}

	public void updateHelp()
	{
		if (Step < 0)
		{
			return;
		}
		if (timeReset > 0)
		{
			timeReset--;
			if (timeReset == 1)
			{
				if (GameCanvas.currentDialog == null && GameCanvas.subDialog == null)
				{
					mSystem.outz("Step=" + Step + "  Next=" + Next);
					setNext();
				}
				else
				{
					timeReset = 20;
				}
			}
		}
		switch (Step)
		{
		case 0:
			if (Next == -4 || Next == -2)
			{
				tickBegin++;
				if (GameCanvas.currentDialog != null)
				{
					GameCanvas.end_Dialog_Help();
					timeReset = -1;
				}
				if (GameScreen.player.posTransRoad == null && tickBegin > 10)
				{
					Next++;
					setNext();
				}
			}
			if (Next == -3)
			{
				if (GameCanvas.currentDialog != null)
				{
					GameCanvas.end_Dialog_Help();
				}
				tickBegin++;
				if (tickBegin > 60)
				{
					Next++;
					setNext();
					tickBegin = 0;
				}
			}
			if (Next == 5 && p != null && CRes.abs(GameScreen.player.x - p.x) < 10 && CRes.abs(GameScreen.player.y - p.y) < 10)
			{
				p = null;
				NextStep();
				setNext();
			}
			break;
		case 2:
			if (!GameCanvas.menu2.isShowMenu && Next == 10)
			{
				Next = 9;
			}
			break;
		case 5:
			if (Next == 0)
			{
				tickBegin++;
				if (tickBegin >= 20)
				{
					Next++;
					setNext();
				}
			}
			break;
		case 1:
		case 3:
		case 4:
			break;
		}
	}

	public void paintHelpFrist(mGraphics g)
	{
		if (Step != 2 && Step != 3 && Step != 4 && Step != 7 && Step != 8 && (Step != 9 || Next == 0) && p != null && p.dis == 0 && fra != null)
		{
			fra.drawFrame(GameCanvas.gameTick / 2 % fra.nFrame, p.x, p.y, 0, 3, g);
		}
	}

	public void paintHelpLast(mGraphics g)
	{
		if (Step == 2 || Step == 3 || Step == 4 || Step == 7 || Step == 8 || (Step == 9 && Next != 0) || p == null || p.dis != 1)
		{
			return;
		}
		if (p.frame == 0)
		{
			if (fra != null)
			{
				fra.drawFrame(GameCanvas.gameTick / 2 % fra.nFrame, p.x, p.y, 0, 3, g);
			}
		}
		else if (p.frame == 1)
		{
			paintPopup(g, p.x, p.y, p.w, p.h, p.fRe, strpopup);
		}
	}

	public int itemMenuHelp()
	{
		switch (Step)
		{
		case 1:
			if (Next == 9)
			{
				return 0;
			}
			break;
		case 2:
			if (Next == 4)
			{
				return 0;
			}
			if (Next == 9)
			{
				return 1;
			}
			if (Next == 10)
			{
				return 4;
			}
			break;
		case 3:
			if (Next == 4)
			{
				return 0;
			}
			break;
		case 6:
			if (Next == 2)
			{
				return 0;
			}
			break;
		}
		return -1;
	}

	public void itemTabHelp(mGraphics g, Item item, sbyte id)
	{
		if (idTabHelp != id && idTabHelp != -1)
		{
			return;
		}
		switch (Step)
		{
		case 2:
			if ((GameCanvas.isVN_Eng || IndoServer.isIndoSv || (Next != 4 && Next != 9)) && (Next == 4 || Next == 9) && item != null && item.ItemCatagory == 4 && item.typePotion == 0 && p != null)
			{
				GameCanvas.resetTrans(g);
				paintPopup(g, p.x, p.y, p.w, p.h, p.fRe, strpopup);
			}
			break;
		case 3:
			if (Next == 4 && item != null && item.ItemCatagory == 3 && item.type_Only_Item == 6 && p != null)
			{
				GameCanvas.resetTrans(g);
				paintPopup(g, p.x, p.y, p.w, p.h, p.fRe, strpopup);
			}
			if (Next == 8 && p != null)
			{
				GameCanvas.resetTrans(g);
				paintPopup(g, p.x, p.y, p.w, p.h, p.fRe, strpopup);
			}
			break;
		case 4:
			if (Next == 9 && p != null)
			{
				GameCanvas.resetTrans(g);
				paintPopup(g, p.x, p.y, p.w, p.h, p.fRe, strpopup);
			}
			break;
		case 7:
			if ((Next == 6 || Next == 9) && p != null)
			{
				GameCanvas.resetTrans(g);
				paintPopup(g, p.x, p.y, p.w, p.h, p.fRe, strpopup);
			}
			break;
		case 8:
			if (Next == 7 && p != null)
			{
				GameCanvas.resetTrans(g);
				paintPopup(g, p.x, p.y, p.w, p.h, p.fRe, strpopup);
			}
			break;
		case 9:
			if (Next == 1 && p != null)
			{
				GameCanvas.resetTrans(g);
				paintPopup(g, p.x, p.y, p.w, p.h, p.fRe, strpopup);
			}
			break;
		case 5:
		case 6:
			break;
		}
	}

	public static void paintPopup(mGraphics g, int x, int y, int w, int h, int archor, string[] str)
	{
		int num = y - h;
		g.setColor(color[0]);
		g.fillRect(x - 3, num, w + 6, h, mGraphics.isFalse);
		g.fillRect(x, num - 3, w, h + 6, mGraphics.isFalse);
		g.setColor(color[1]);
		g.fillRect(x - 2, num - 2, w + 4, h + 4, mGraphics.isFalse);
		g.drawRegion(PopupChat.mPopup[0], 0, 0, 3, 3, 0, x - 3, num - 3, 0, mGraphics.isFalse);
		g.drawRegion(PopupChat.mPopup[0], 0, 3, 3, 3, 0, x + w, num - 3, 0, mGraphics.isFalse);
		g.drawRegion(PopupChat.mPopup[0], 0, 9, 3, 3, 0, x - 3, num + h, 0, mGraphics.isFalse);
		g.drawRegion(PopupChat.mPopup[0], 0, 6, 3, 3, 0, x + w, num + h, 0, mGraphics.isFalse);
		for (int i = 0; i < str.Length; i++)
		{
			mFont.tahoma_7_black.drawString(g, str[i], x + w / 2, num + 1 + i * GameCanvas.hText, 2, mGraphics.isFalse);
		}
		switch (archor)
		{
		case 0:
			g.drawImage(AvMain.imgSelect, x, y + 2 + GameCanvas.gameTick / 2 % 4, 0, mGraphics.isFalse);
			break;
		case 1:
			g.drawImage(AvMain.imgSelect, x + w, y + 2 + GameCanvas.gameTick / 2 % 4, mGraphics.TOP | mGraphics.RIGHT, mGraphics.isFalse);
			break;
		case 2:
			if (GameCanvas.isVN_Eng || IndoServer.isIndoSv || GameScreen.help.Step != 8 || (GameScreen.help.Next != 3 && GameScreen.help.Next != 2))
			{
				g.drawImage(AvMain.imgSelect, x + w / 2, y + 2 + GameCanvas.gameTick / 2 % 4, mGraphics.TOP | mGraphics.HCENTER, mGraphics.isFalse);
			}
			break;
		case 3:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 1, x, y - h - 20 + 2 + GameCanvas.gameTick / 2 % 4, 0, mGraphics.isFalse);
			break;
		case 4:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 1, x + w, y - h - 20 + 2 + GameCanvas.gameTick / 2 % 4, mGraphics.TOP | mGraphics.RIGHT, mGraphics.isFalse);
			break;
		case 5:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 1, x + w / 2, y - h - 20 + 2 + GameCanvas.gameTick / 2 % 4, mGraphics.TOP | mGraphics.HCENTER, mGraphics.isFalse);
			break;
		case 7:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 5, x + GameCanvas.gameTick / 2 % 4, y - h / 2, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isFalse);
			break;
		case 8:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, x + w + 1 + GameCanvas.gameTick / 2 % 4, y - h / 2, mGraphics.VCENTER | mGraphics.LEFT, mGraphics.isFalse);
			break;
		case 6:
			break;
		}
	}

	public void Step0(string[][] str)
	{
		switch (Next)
		{
		case -5:
			break;
		case -4:
			tickBegin = 0;
			SaveBegin();
			Player.isLockKey = true;
			GameScreen.player.posTransRoad = null;
			GameScreen.player.resetAction();
			GameScreen.player.toX = GameScreen.player.x;
			GameScreen.player.toY = GameScreen.player.y;
			GameScreen.player.xStopMove = 0;
			GameScreen.player.yStopMove = 0;
			GameScreen.player.posTransRoad = GameCanvas.game.updateFindRoad(10, 16, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 40);
			break;
		case -3:
			Player.isLockKey = true;
			GameScreen.player.posTransRoad = null;
			GameScreen.player.resetAction();
			GameScreen.player.Direction = 2;
			GameScreen.player.strChatPopup = "...";
			tickBegin = 0;
			break;
		case -2:
			tickBegin = 0;
			Player.isLockKey = true;
			GameScreen.player.resetAction();
			GameScreen.player.toX = GameScreen.player.x;
			GameScreen.player.toY = GameScreen.player.y;
			GameScreen.player.xStopMove = 0;
			GameScreen.player.yStopMove = 0;
			GameScreen.player.posTransRoad = GameCanvas.game.updateFindRoad(24 + CRes.random_Am_0(3), 21 + CRes.random_Am_0(3), GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 40);
			break;
		case -1:
		{
			mVector mVector3 = new mVector("MainHelp menu");
			mVector3.addElement(cmdNext);
			iCommand o = new iCommand(T.cancel, 1, this);
			mVector3.addElement(o);
			GameCanvas.start_Select_Dialog(T.hoihelp, mVector3);
			break;
		}
		case 4:
		{
			if (Player.isLockKey)
			{
				Player.isLockKey = false;
			}
			if (!Player.isSendMove)
			{
				Player.isSendMove = true;
			}
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				int num = GameCanvas.w - 30;
				if (num > 200)
				{
					num = 200;
				}
				int x = GameCanvas.hw - num / 2;
				int y = GameCanvas.h - GameCanvas.hCommand * 2;
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[Step][Next], cmdNext, x, y, -1, false, num);
				GameCanvas.currentDialog = msgDialog;
			}
			int num2 = 80;
			int num3 = 0;
			bool flag = false;
			do
			{
				num3++;
				int num4 = GameScreen.player.x + CRes.random_Am(40, num2);
				int num5 = GameScreen.player.y + CRes.random_Am(40, num2);
				int tile = GameCanvas.loadmap.getTile(num4, num5);
				if (GameScreen.setIsInScreen(num4, num5) && tile != -1 && tile != 1)
				{
					flag = true;
					p = new Point();
					p.x = num4;
					p.y = num5;
					p.dis = 0;
					p.frame = 0;
					fra = PaintInfoGameScreen.fraFocusIngame;
				}
				if (num3 > 10)
				{
					num2 += 10;
					num3 = 0;
				}
			}
			while (!flag);
			break;
		}
		case 5:
			GameCanvas.end_Dialog_Help();
			break;
		default:
			GameCanvas.end_Dialog_Help();
			dialogCenter(str);
			break;
		}
	}

	public void Step1(string[][] str)
	{
		switch (Next)
		{
		case 2:
			GameCanvas.end_Dialog_Help();
			return;
		case 5:
			GameCanvas.end_Dialog_Help();
			return;
		case 9:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = 3;
				p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.fRe = 2;
				p.dis = 1;
				p.frame = 1;
			}
			return;
		}
		if (Next < str[Step].Length && str[Step][Next].Length > 0)
		{
			int num = GameCanvas.w - 30;
			if (num > 200)
			{
				num = 200;
			}
			int x = GameCanvas.hw - num / 2;
			int y = GameCanvas.h - GameCanvas.hCommand * 2;
			MsgDialog msgDialog = new MsgDialog();
			msgDialog.setDiaHelp(str[Step][Next], cmdNext, x, y, -1, false, num);
			GameCanvas.currentDialog = msgDialog;
		}
	}

	private void Step2(string[][] str)
	{
		switch (Next)
		{
		case 0:
			GameCanvas.end_Dialog_Help();
			leftTab(0, str);
			break;
		case 1:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 5, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 2:
		case 3:
		case 7:
		case 8:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog4 = new MsgDialog();
				msgDialog4.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 4, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 3, false, 90);
				GameCanvas.currentDialog = msgDialog4;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = GameCanvas.hw - 40;
				p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.fRe = 2;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = MainTabNew.INVENTORY;
			break;
		case 5:
		case 6:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 9:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = GameCanvas.hw - 40;
				p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.fRe = 2;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = MainTabNew.INVENTORY;
			break;
		case 10:
			idTabHelp = MainTabNew.INVENTORY;
			break;
		case 11:
		case 12:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOneItem * 2 + MainTabNew.wOne5 * 4, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 3, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 13:
			NextStep();
			setNext();
			break;
		}
	}

	public void Step3(string[][] str)
	{
		switch (Next)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOneItem * 3 - 40 + MainTabNew.wOne5 * 4, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 5, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = GameCanvas.hw - 40;
				p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.fRe = 2;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = MainTabNew.INVENTORY;
			break;
		case 5:
		case 6:
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 7:
			GameCanvas.end_Dialog_Help();
			leftTab(1, str);
			break;
		case 8:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wOne5 / 2;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 16 + p.h;
				p.fRe = 3;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = -1;
			break;
		}
	}

	public void Step4(string[][] str)
	{
		switch (Next)
		{
		case 0:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 1:
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3 + MainTabNew.wblack / 5 * 2 + TabMySeftNew.delta + 16, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + MainTabNew.hblack / 12 * 8 / 2, 7, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 2:
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3 + MainTabNew.wblack / 5 * 2 + TabMySeftNew.delta - 16, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + MainTabNew.hblack / 12 * 8 / 2, 8, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 3:
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog4 = new MsgDialog();
				msgDialog4.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wblack / 2, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + MainTabNew.hblack - MainTabNew.wOneItem * 2 - MainTabNew.wOne5 - 20, 2, false, 90);
				GameCanvas.currentDialog = msgDialog4;
			}
			break;
		case 9:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = GameCanvas.w - 83;
				p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.fRe = 2;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = -1;
			break;
		}
	}

	public void Step5(string[][] str)
	{
		switch (Next)
		{
		case 0:
			if (GameCanvas.isVN_Eng || IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				p = null;
				GameScreen.player.strChatPopup = T.timduongtoilang;
				tickBegin = 0;
			}
			break;
		case 1:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.w - 96, GameCanvas.h - 23 - GameCanvas.minimap.maxY * MiniMap.wMini - 16, 2, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 2:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog6 = new MsgDialog();
				msgDialog6.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.w - 96, GameCanvas.h - 23 - GameCanvas.minimap.maxY * MiniMap.wMini - 16, -1, false, 90);
				GameCanvas.currentDialog = msgDialog6;
			}
			GameCanvas.minimap.setPoint(51, 2, GameCanvas.loadmap.idMap);
			break;
		case 3:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[Step][Next], cmdNext, 3, 60, 5, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.w - 93, 45, 5, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 5:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog4 = new MsgDialog();
				msgDialog4.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.w - 93, GameCanvas.h - GameCanvas.hCommand, 2, false, 90);
				GameCanvas.currentDialog = msgDialog4;
			}
			break;
		case 6:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog5 = new MsgDialog();
				msgDialog5.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, GameCanvas.h - GameCanvas.hCommand - 14 - 25, 2, false, 90);
				GameCanvas.currentDialog = msgDialog5;
			}
			break;
		case 7:
			GameCanvas.end_Dialog_Help();
			dialogCenter(str);
			break;
		case 8:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				if (!isStepp5)
				{
					GameCanvas.end_Dialog_Help();
					p = null;
					GameScreen.player.strChatPopup = T.timduongtoilang;
					tickBegin = 0;
					GameCanvas.end_Dialog_Help();
					isStepp5 = true;
				}
			}
			else
			{
				GameCanvas.end_Dialog_Help();
			}
			break;
		}
	}

	public void Step6(string[][] str)
	{
		switch (Next)
		{
		case 0:
		case 1:
			dialogCenter(str);
			break;
		case 2:
			GameCanvas.end_Dialog_Help();
			PopupLeft(str);
			break;
		}
	}

	public void Step7(string[][] str)
	{
		switch (Next)
		{
		case 0:
			GameCanvas.end_Dialog_Help();
			leftTab(2, str);
			break;
		case 1:
		case 2:
		case 3:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				int num = 20;
				if (GameCanvas.isTouch)
				{
					num = 24;
				}
				msgDialog.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wblack / 2, num * T.mKyNang.Length + MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + 20, 5, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				int num2 = 20;
				if (GameCanvas.isTouch)
				{
					num2 = 24;
				}
				msgDialog2.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wblack / 2, num2 * T.mKyNang.Length + MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem, 2, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 5:
		case 7:
		case 8:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 6:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				int x = MainTabNew.gI().xTab + MainTabNew.wblack / 4 + 30;
				int y = MainTabNew.gI().yTab + GameCanvas.hText + GameCanvas.h / 5 + 4 + (GameCanvas.isTouch ? 4 : 0);
				p = new Point();
				p.x = x;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.y = y;
				p.fRe = 2;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = MainTabNew.MY_INFO;
			break;
		case 9:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wOne5 / 2;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + MainTabNew.wOneItem * 3 + 16 + p.h;
				p.fRe = 3;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = -1;
			break;
		}
	}

	private void Step8(string[][] str)
	{
		switch (Next)
		{
		case 0:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				leftTab(3, str);
				GameCanvas.AllInfo.selectTab = 3;
				break;
			}
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog6 = new MsgDialog();
				msgDialog6.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog6;
			}
			break;
		case 4:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				Step = -1;
				Next = 0;
				SaveStep();
				break;
			}
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 5:
		case 6:
		case 8:
		case 9:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 1:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				leftTab(4, str);
				GameCanvas.AllInfo.selectTab = 4;
				break;
			}
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wblack / 2 + MainTabNew.wblack / 8, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + MainTabNew.hblack / 2, 7, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 2:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				if (Next < str[Step].Length && str[Step][Next].Length > 0)
				{
					MsgDialog msgDialog7 = new MsgDialog();
					msgDialog7.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wblack / 2 + MainTabNew.wblack / 8, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + MainTabNew.hblack / 2, 2, false, 90);
					GameCanvas.currentDialog = msgDialog7;
				}
			}
			else
			{
				GameCanvas.end_Dialog_Help();
				if (Next < str[Step].Length && str[Step][Next].Length > 0)
				{
					MsgDialog msgDialog8 = new MsgDialog();
					msgDialog8.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wblack / 2 + MainTabNew.wblack / 8, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + MainTabNew.hblack / 2, 7, false, 90);
					GameCanvas.currentDialog = msgDialog8;
				}
			}
			break;
		case 3:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				if (Next < str[Step].Length && str[Step][Next].Length > 0)
				{
					MsgDialog msgDialog4 = new MsgDialog();
					msgDialog4.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wblack / 4 * 3, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + MainTabNew.hblack / 2, 2, false, 90);
					GameCanvas.currentDialog = msgDialog4;
				}
			}
			else
			{
				GameCanvas.end_Dialog_Help();
				if (Next < str[Step].Length && str[Step][Next].Length > 0)
				{
					MsgDialog msgDialog5 = new MsgDialog();
					msgDialog5.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wblack / 4 * 3, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + MainTabNew.hblack / 2, 8, false, 90);
					GameCanvas.currentDialog = msgDialog5;
				}
			}
			break;
		case 7:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wOne5 / 2 + MainTabNew.wblack / 8 * 3;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
				p.fRe = -1;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = MainTabNew.SKILLS;
			break;
		case 10:
			GameCanvas.end_Dialog_Help();
			break;
		}
	}

	public void Step9(string[][] str)
	{
		switch (Next)
		{
		case 0:
			GameCanvas.end_Dialog_Help();
			dialogCenter(str);
			break;
		case 1:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				p = new Point();
				p.x = MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wOne5 / 2;
				p.w = 80;
				strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
				p.h = strpopup.Length * GameCanvas.hText;
				p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 5 + 16 + p.h;
				p.fRe = 3;
				p.dis = 1;
				p.frame = 1;
			}
			idTabHelp = -1;
			break;
		case 2:
		case 5:
		case 6:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[Step][Next], cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 3:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOneItem + MainTabNew.wblack / 4 - 45, MainTabNew.gI().yTab + MainTabNew.wOneItem + GameCanvas.h / 5 + 22, 5, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (Next < str[Step].Length && str[Step][Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOneItem + MainTabNew.wblack / 4 * 3 - 45, MainTabNew.gI().yTab + MainTabNew.wOneItem + GameCanvas.h / 5 + 22, 5, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 7:
			GameCanvas.end_Dialog_Help();
			Step = -1;
			Next = 0;
			SaveStep();
			break;
		}
	}

	public void PopupLeft(string[][] str)
	{
		if (Next < str[Step].Length && str[Step][Next].Length > 0)
		{
			p = new Point();
			p.x = 3;
			p.y = GameCanvas.h - GameCanvas.hCommand - 14;
			p.w = 80;
			strpopup = mFont.tahoma_7_black.splitFontArray(str[Step][Next], p.w);
			p.h = strpopup.Length * GameCanvas.hText;
			p.fRe = 2;
			p.dis = 1;
			p.frame = 1;
		}
	}

	public void dialogCenter(string[][] str)
	{
		if (Next < str[Step].Length && str[Step][Next].Length > 0)
		{
			int num = GameCanvas.w - 30;
			if (num > 200)
			{
				num = 200;
			}
			int x = GameCanvas.hw - num / 2;
			int y = GameCanvas.h - GameCanvas.hCommand * 2;
			MsgDialog msgDialog = new MsgDialog();
			msgDialog.setDiaHelp(str[Step][Next], cmdNext, x, y, -1, false, num);
			GameCanvas.currentDialog = msgDialog;
		}
	}

	public void leftTab(int index, string[][] str)
	{
		GameCanvas.end_Dialog_Help();
		if (Next < str[Step].Length && str[Step][Next].Length > 0)
		{
			MsgDialog msgDialog = new MsgDialog();
			msgDialog.setDiaHelp(str[Step][Next], cmdNext, MainTabNew.gI().xTab + MainTabNew.wOne5 + MainTabNew.wOne5 / 2, MainTabNew.gI().yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + 16 + index * MainTabNew.wOneItem, 3, false, 90);
			GameCanvas.currentDialog = msgDialog;
		}
	}
}
