public class List_Server : MainScreen
{
	public const sbyte FRIEND = 0;

	public const sbyte LIST_TOP = 1;

	public const sbyte LIST_ARCHE = 2;

	public const sbyte LIST_CLAN = 3;

	public const sbyte LIST_MEM_CLAN = 4;

	public const sbyte LIST_MEM_OTHER_CLAN = 5;

	public const sbyte LIST_THI_DAU = 6;

	public static List_Server me;

	public mVector vecListServer = new mVector("List_server vecListServer");

	public static mVector vecMyFriend = new mVector("List_server vecMyFriend");

	public static mVector vecArche = new mVector("List_server vecMyFriend");

	public static bool isLoadFriend = false;

	private int idSelect;

	private int xMove;

	private int limitMove;

	private int hItem = 50;

	private int maxpaint;

	private int min;

	private int max;

	private int x;

	private int y;

	private int w;

	private int h;

	private iCommand cmdchat;

	private iCommand cmdMenuPoiter;

	private iCommand cmdInfo;

	private iCommand cmdClose;

	private iCommand nextPage;

	private iCommand prePage;

	private iCommand cmddelete;

	private iCommand cmdhoidelete;

	private iCommand cmdPhongchuc;

	private iCommand cmdDuoiMem;

	private iCommand cmdInfoCLan;

	private iCommand cmdListMemClan;

	private iCommand cmdDongGopClan;

	private iCommand cmdUpdateFriendList;

	private iCommand cmdThidau;

	private ListNew list;

	public string nameList;

	public sbyte page;

	public sbyte typeList;

	private int[][] mPosStar = new int[5][]
	{
		new int[2] { 6, 20 },
		new int[2] { 22, 18 },
		new int[2] { 38, 20 },
		new int[2] { 14, 8 },
		new int[2] { 30, 8 }
	};

	public sbyte[] frameicon = new sbyte[4] { 0, 1, 2, 1 };

	public sbyte frameClan;

	private bool isTran;

	private int yCamBegin;

	public List_Server()
	{
		cmdClose = new iCommand(T.close, -1);
		cmdchat = new iCommand(T.trochuyen, 1, this);
		cmdMenuPoiter = new iCommand(T.menu, 3, this);
		cmdInfo = new iCommand(T.info, 4, this);
		prePage = new iCommand(T.vetruoc, 5, this);
		nextPage = new iCommand(T.toitruoc, 6, this);
		cmddelete = new iCommand(T.del, 0, this);
		cmdhoidelete = new iCommand(T.del, 2, this);
		cmdPhongchuc = new iCommand(T.phonghacap, 7, this);
		cmdDuoiMem = new iCommand(T.moiroiclan, 8, this);
		cmdInfoCLan = new iCommand(T.info, 10, this);
		cmdListMemClan = new iCommand(T.xemdanhsach, 11, this);
		cmdDongGopClan = new iCommand(T.donggopclan, 12, this);
		cmdUpdateFriendList = new iCommand(T.update, 13, this);
		cmdThidau = new iCommand(T.thachdau, 14, this);
	}

	public static List_Server gI()
	{
		if (me == null)
		{
			return me = new List_Server();
		}
		return me;
	}

	public void doSetCaption()
	{
		cmdClose.caption = T.close;
		cmdchat.caption = T.trochuyen;
		cmdMenuPoiter.caption = T.menu;
		cmdInfo.caption = T.info;
		prePage.caption = T.vetruoc;
		nextPage.caption = T.toitruoc;
		cmddelete.caption = T.del;
		cmdhoidelete.caption = T.del;
		cmdPhongchuc.caption = T.phonghacap;
		cmdDuoiMem.caption = T.moiroiclan;
		cmdInfoCLan.caption = T.info;
		cmdListMemClan.caption = T.xemdanhsach;
		cmdDongGopClan.caption = T.donggopclan;
		cmdUpdateFriendList.caption = T.update;
		cmdThidau.caption = T.thachdau;
	}

	public override void Show()
	{
		mSystem.outloi("goi ham show kia");
		Show(GameCanvas.currentScreen);
	}

	public void setSize(sbyte type)
	{
		typeList = type;
		hItem = 50;
		if (typeList == 2)
		{
			hItem = 70;
		}
		w = GameCanvas.w / 4 * 3;
		h = GameCanvas.h / 5 * 4;
		if (w < 160)
		{
			w = 160;
		}
		else if (w > 280)
		{
			w = 280;
		}
		if (h < 210)
		{
			h = 210;
		}
		else if (h > 280)
		{
			h = 280;
		}
		x = GameCanvas.hw - w / 2;
		y = GameCanvas.hh - h / 2;
		idSelect = 0;
		maxpaint = (h - GameCanvas.hCommand) / hItem + 3;
		if (vecListServer.size() > 0)
		{
			setXmove();
			MainScreen.cameraSub.setAll(0, vecListServer.size() * hItem - h + GameCanvas.hCommand + 10, 0, 0);
			list = new ListNew(x, y, w, h, hItem, 0, MainScreen.cameraSub.yLimit);
			min = 0;
			max = maxpaint;
			if (max > vecListServer.size())
			{
				max = vecListServer.size();
			}
			setCmd();
		}
		if (GameCanvas.isTouch)
		{
			cmdClose.setPos(x + w - 12, y + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
		right = cmdClose;
	}

	private void doMenuPhongChuc()
	{
		if (idSelect < 0 || idSelect >= vecListServer.size())
		{
			return;
		}
		MainObject mainObject = (MainObject)vecListServer.elementAt(idSelect);
		if (mainObject != null)
		{
			mVector mVector3 = new mVector("List_server menu4");
			if (GameScreen.player.myClan.chucvu == sbyte.MaxValue)
			{
				mVector3.addElement(new iCommand(T.mChucVuClan[1], 9, 126, this));
			}
			if (GameScreen.player.myClan.chucvu >= 126)
			{
				mVector3.addElement(new iCommand(T.mChucVuClan[2], 9, 125, this));
			}
			if (GameScreen.player.myClan.chucvu >= 125)
			{
				mVector3.addElement(new iCommand(T.mChucVuClan[3], 9, 124, this));
				mVector3.addElement(new iCommand(T.mChucVuClan[4], 9, 123, this));
				mVector3.addElement(new iCommand(T.mChucVuClan[5], 9, 122, this));
			}
			GameCanvas.menu2.startAt(mVector3, 2, mainObject.name, isFocus: false, null);
		}
	}

	private void doMenuListClan()
	{
		if (idSelect >= 0 && idSelect < vecListServer.size())
		{
			MainClan mainClan = (MainClan)vecListServer.elementAt(idSelect);
			if (mainClan.hang != -1)
			{
				mVector mVector3 = new mVector("List_server menu2");
				mVector3.addElement(cmdInfoCLan);
				mVector3.addElement(cmdListMemClan);
				GameCanvas.menu2.startAt(mVector3, 2, T.clan, isFocus: false, null);
			}
		}
	}

	private void doMenuListTop()
	{
		if (idSelect < 0 || idSelect >= vecListServer.size())
		{
			return;
		}
		MainObject mainObject = (MainObject)vecListServer.elementAt(idSelect);
		if (mainObject.name.CompareTo(GameScreen.player.name) == 0)
		{
			return;
		}
		mVector mVector3 = new mVector("List_server menu3");
		if (typeList == 4)
		{
			if (GameScreen.player.myClan.chucvu >= 125)
			{
				mVector3.addElement(cmdPhongchuc);
				if (GameScreen.player.myClan.chucvu >= 126)
				{
					mVector3.addElement(cmdDuoiMem);
				}
			}
			mVector3.addElement(cmdDongGopClan);
		}
		if (mainObject != null && mainObject.typeOnline == 1 && mainObject.hang != -1 && mainObject.name.CompareTo(GameScreen.player.name) != 0)
		{
			mVector3.addElement(cmdInfo);
			mVector3.addElement(cmdchat);
		}
		GameCanvas.menu2.startAt(mVector3, 2, T.chucnang, isFocus: false, null);
	}

	public void doMenu()
	{
		mVector mVector3 = new mVector("List_server menu");
		if (typeList == 0)
		{
			mVector3.addElement(cmdchat);
			mVector3.addElement(cmdhoidelete);
			mVector3.addElement(cmdUpdateFriendList);
		}
		if (typeList != 6 && idSelect >= 0 && idSelect < vecListServer.size())
		{
			MainObject mainObject = (MainObject)vecListServer.elementAt(idSelect);
			if (mainObject != null && mainObject.typeOnline == 1 && mainObject.hang != -1 && mainObject.name.CompareTo(GameScreen.player.name) != 0)
			{
				mVector3.addElement(cmdInfo);
			}
		}
		if (typeList == 6)
		{
			MainObject mainObject2 = (MainObject)vecListServer.elementAt(idSelect);
			if (mainObject2 != null && mainObject2.hang != -1 && mainObject2.name.CompareTo(GameScreen.player.name) != 0)
			{
				mVector3.addElement(cmdInfo);
				mVector3.addElement(cmdThidau);
			}
		}
		if (page != 99)
		{
			if (page != 0)
			{
				prePage.caption = T.vetruoc + CRes.abs(page);
				mVector3.addElement(prePage);
			}
			if (page >= 0)
			{
				nextPage.caption = T.toitruoc + (page + 2);
				mVector3.addElement(nextPage);
			}
		}
		GameCanvas.menu2.startAt(mVector3, 2, T.friend, isFocus: false, null);
	}

	public override void commandTab(int index, int sub)
	{
		if (index == -1)
		{
			if (lastScreen == GameCanvas.AllInfo)
			{
				lastScreen.Show(lastScreen.lastScreen);
			}
			else
			{
				lastScreen.Show();
			}
		}
		base.commandTab(index, sub);
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			MainObject mainObject5 = (MainObject)vecMyFriend.elementAt(idSelect);
			GlobalService.gI().Friend(3, mainObject5.name);
			vecMyFriend.removeElementAt(idSelect);
			if (idSelect > 0)
			{
				idSelect--;
			}
			if (vecMyFriend.size() == 0)
			{
				left = null;
				center = null;
			}
			GameCanvas.end_Dialog();
			break;
		}
		case 2:
			GameCanvas.start_Left_Dialog(T.deleteFriend, cmddelete);
			break;
		case 1:
		{
			MainObject mainObject2 = (MainObject)vecListServer.elementAt(idSelect);
			if (mainObject2 != null && mainObject2.hang != -1)
			{
				GameCanvas.msgchat.addNewChat(mainObject2.name, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, isFocus: true);
				GameCanvas.start_Chat_Dialog();
			}
			break;
		}
		case 3:
			if (typeList == 1 || typeList == 0 || typeList == 6)
			{
				doMenu();
			}
			else if (typeList == 5 || typeList == 4)
			{
				doMenuListTop();
			}
			else if (typeList == 3)
			{
				doMenuListClan();
			}
			break;
		case 4:
		{
			if (idSelect < 0 || idSelect >= vecListServer.size())
			{
				return;
			}
			MainObject mainObject4 = (MainObject)vecListServer.elementAt(idSelect);
			if (mainObject4 != null && mainObject4.hang != -1)
			{
				if (typeList == 6)
				{
					GlobalService.gI().Re_Info_Other_Object(mainObject4.name, Info_Other_Player.THACH_DAU_INFO);
				}
				else
				{
					GlobalService.gI().Re_Info_Other_Object(mainObject4.name, Info_Other_Player.VIEW);
				}
			}
			break;
		}
		case 5:
			GlobalService.gI().set_Page((sbyte)(CRes.abs(page) - 1));
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.cancel, -1));
			break;
		case 6:
			GlobalService.gI().set_Page((sbyte)CRes.abs(page + 1));
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.cancel, -1));
			break;
		case 7:
			doMenuPhongChuc();
			break;
		case 8:
		{
			MainObject mainObject3 = (MainObject)vecListServer.elementAt(idSelect);
			if (mainObject3 != null)
			{
				GlobalService.gI().Delete_Mem_Clan(18, mainObject3.name);
			}
			break;
		}
		case 9:
		{
			MainObject mainObject3 = (MainObject)vecListServer.elementAt(idSelect);
			if (mainObject3 != null)
			{
				GlobalService.gI().PhongCap_Clan(4, (sbyte)subIndex, mainObject3.name);
			}
			GameCanvas.start_Ok_Dialog(T.pleaseWait);
			break;
		}
		case 10:
		{
			MainClan mainClan2 = (MainClan)vecListServer.elementAt(idSelect);
			if (mainClan2 != null && mainClan2.hang != -1)
			{
				GlobalService.gI().ChucNang_Clan(15, mainClan2.IdClan);
				GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			}
			break;
		}
		case 11:
		{
			MainClan mainClan = (MainClan)vecListServer.elementAt(idSelect);
			if (mainClan != null && mainClan.hang != -1)
			{
				GlobalService.gI().ChucNang_Clan(13, mainClan.IdClan);
				GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			}
			break;
		}
		case 12:
		{
			MainObject mainObject3 = (MainObject)vecListServer.elementAt(idSelect);
			if (mainObject3 != null)
			{
				GlobalService.gI().info_Mem_Clan(14, mainObject3.name);
				GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			}
			break;
		}
		case 13:
			GlobalService.gI().Friend(4, string.Empty);
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.cancel, -1));
			break;
		case 14:
		{
			if (idSelect < 0 || idSelect >= vecListServer.size())
			{
				return;
			}
			MainObject mainObject = (MainObject)vecListServer.elementAt(idSelect);
			if (mainObject != null && mainObject.hang != -1)
			{
				GlobalService.gI().doSendThachDau(0, mainObject.name);
			}
			break;
		}
		}
		base.commandPointer(index, subIndex);
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
		paintFormList(g, x, y, w, h, nameList);
		g.translate(x, y + GameCanvas.hCommand);
		g.setClip(3, 0, w, h - GameCanvas.hCommand);
		int ybegin = 5;
		if (vecListServer == null)
		{
			return;
		}
		if (vecListServer.size() > 0)
		{
			if (typeList == 3)
			{
				paintTopClan(g, ybegin);
			}
			else
			{
				paintTopNormal(g, ybegin);
			}
		}
		else if (typeList == 0)
		{
			mFont.tahoma_7_white.drawString(g, T.nullFriend, w / 2, ybegin, 2, mGraphics.isTrue);
		}
		else
		{
			mFont.tahoma_7_white.drawString(g, T.listnull, w / 2, ybegin, 2, mGraphics.isTrue);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.currentScreen == this && !ChatTextField.isShow && GameCanvas.subDialog == null)
		{
			base.paint(g);
		}
	}

	private void paintTopClan(mGraphics g, int ybegin)
	{
		g.setColor(10259575);
		g.fillRect(3, -MainScreen.cameraSub.yCam + ybegin + idSelect * hItem + 1, w - 6, hItem - 1, mGraphics.isTrue);
		g.translate(0, -MainScreen.cameraSub.yCam);
		ybegin += min * hItem;
		for (int i = min; i < max; i++)
		{
			MainClan mainClan = (MainClan)vecListServer.elementAt(i);
			if (mainClan.hang == -1)
			{
				mFont.tahoma_7b_white.drawString(g, mainClan.shortName, 20, ybegin + 5, 0, mGraphics.isTrue);
				ybegin += hItem;
				continue;
			}
			MainImage imageIconClan = ObjectData.getImageIconClan(mainClan.IdIcon);
			if (imageIconClan.img != null)
			{
				if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
				{
					if (GameCanvas.gameTick % 6 == 0)
					{
						mainClan.frameClan = (sbyte)((mainClan.frameClan + 1) % 3);
					}
					g.drawRegion(imageIconClan.img, 0, mainClan.frameClan * 18, 18, 18, 0, 9, ybegin + 11, 3, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(imageIconClan.img, 9, ybegin + 11, 3, mGraphics.isTrue);
				}
			}
			if (GameScreen.player.myClan != null && GameScreen.player.myClan.shortName.CompareTo(mainClan.shortName) == 0)
			{
				AvMain.Font3dWhite(g, mainClan.shortName + " - " + mainClan.name, 20, ybegin + 5, 0);
			}
			else
			{
				mFont.tahoma_7b_white.drawString(g, mainClan.shortName + " - " + mainClan.name, 20, ybegin + 5, 0, mGraphics.isTrue);
			}
			int num = 10;
			mFont.tahoma_7_white.drawString(g, mainClan.slogan, num, 20 + ybegin, 0, mGraphics.isTrue);
			if (mainClan.hang < 4)
			{
				mFont.tahoma_7b_white.drawString(g, T.hang + " " + T.mhang[mainClan.hang], num, 35 + ybegin, 0, mGraphics.isTrue);
			}
			else
			{
				mFont.tahoma_7_white.drawString(g, T.hang + " " + (mainClan.hang + 1), num, 35 + ybegin, 0, mGraphics.isTrue);
			}
			ybegin += hItem;
			if (i < vecListServer.size() - 1)
			{
				g.setColor(AvMain.color[4]);
				g.fillRect(4, ybegin, w - 8, 1, mGraphics.isTrue);
			}
		}
	}

	public void paintTopNormal(mGraphics g, int ybegin)
	{
		g.setColor(10259575);
		g.fillRect(3, -MainScreen.cameraSub.yCam + ybegin + idSelect * hItem + 1, w - 6, hItem - 1, mGraphics.isTrue);
		g.translate(0, -MainScreen.cameraSub.yCam);
		ybegin += min * hItem;
		for (int i = min; i < max; i++)
		{
			if (i < 0 || i >= vecListServer.size())
			{
				continue;
			}
			MainObject mainObject = (MainObject)vecListServer.elementAt(i);
			if (mainObject.hang == -1)
			{
				mainObject.paintNameShow(g, 50, 5 + ybegin, islevel: true);
				ybegin += hItem;
				if (i < vecListServer.size() - 1)
				{
					g.setColor(AvMain.color[4]);
					g.fillRect(4, ybegin, w - 8, 1, mGraphics.isTrue);
				}
				continue;
			}
			mainObject.paintShowPlayer(g, 20, 40 + ybegin, 0);
			paintIconOnline(g, mainObject.typeOnline, 40, 10 + ybegin);
			if (mainObject.name.CompareTo(GameScreen.player.name) == 0)
			{
				string nameAndClan = mainObject.getNameAndClan(" - ");
				int num = 0;
				if (mainObject.myClan != null)
				{
					num = 16;
					mainObject.paintIconClan(g, 50 + num - 7, 5 + ybegin + 6, -1);
				}
				AvMain.FontBorderColor(g, nameAndClan, 50 + num, 5 + ybegin, 0, 0);
			}
			else
			{
				mainObject.paintNameShow(g, 50, 5 + ybegin, islevel: true);
			}
			int num2 = 40;
			if (i == idSelect)
			{
				g.setClip(35, MainScreen.cameraSub.yCam, w - 40, h - GameCanvas.hCommand);
				num2 -= xMove;
			}
			if (typeList == 6)
			{
				if (mainObject.hang < 4)
				{
					mFont.tahoma_7b_white.drawString(g, T.hang + " " + T.mhang[mainObject.hang], num2, 35 + ybegin, 0, mGraphics.isTrue);
				}
				else
				{
					mFont.tahoma_7_white.drawString(g, T.hang + " " + (mainObject.hang + 1), num2, 35 + ybegin, 0, mGraphics.isTrue);
				}
				mFont.tahoma_7_white.drawString(g, mainObject.infoObject, num2, 20 + ybegin, 0, mGraphics.isTrue);
			}
			else if (typeList == 4 || typeList == 5)
			{
				mFont.tahoma_7_white.drawString(g, T.level + mainObject.Lv, num2, 20 + ybegin, 0, mGraphics.isTrue);
				mFont.tahoma_7_white.drawString(g, MainClan.getNameChucVu(mainObject.myClan.chucvu), num2, 35 + ybegin, 0, mGraphics.isTrue);
			}
			else
			{
				mFont.tahoma_7_white.drawString(g, mainObject.infoObject, num2, 20 + ybegin, 0, mGraphics.isTrue);
				if (typeList == 1)
				{
					if (mainObject.hang < 4)
					{
						mFont.tahoma_7b_white.drawString(g, T.hang + " " + T.mhang[mainObject.hang], num2, 35 + ybegin, 0, mGraphics.isTrue);
					}
					else
					{
						mFont.tahoma_7_white.drawString(g, T.hang + " " + (mainObject.hang + 1), num2, 35 + ybegin, 0, mGraphics.isTrue);
					}
				}
			}
			if (i == idSelect)
			{
				g.setClip(5, MainScreen.cameraSub.yCam, w - 10, h - GameCanvas.hCommand);
			}
			ybegin += hItem;
			if (i < vecListServer.size() - 1)
			{
				g.setColor(AvMain.color[4]);
				g.fillRect(4, ybegin, w - 8, 1, mGraphics.isTrue);
			}
		}
	}

	public void paintAr(mGraphics g, int max, int cur, int x, int y)
	{
		g.setColor(0);
		g.fillRect(x, y + 1, 62, 7, mGraphics.isTrue);
		g.fillRect(x + 1, y, 60, 1, mGraphics.isTrue);
		g.fillRect(x + 1, y + 8, 60, 1, mGraphics.isTrue);
		if (cur > 0)
		{
			int num = cur * 60 / max;
			if (num <= 0)
			{
				num = 1;
			}
			else if (num > 60)
			{
				num = 60;
			}
			g.setColor(2340367);
			g.fillRect(x + 1, y, num, 1, mGraphics.isTrue);
		}
		mFont.tahoma_7_white.drawString(g, cur + "/" + max, x + 31, y + 4, 2, mGraphics.isTrue);
	}

	private void paintIconOnline(mGraphics g, sbyte online, int x, int y)
	{
		int idx = 0;
		if (online == 0)
		{
			idx = 2;
		}
		PaintInfoGameScreen.fraStatusArea.drawFrame(idx, x, y, 0, 3, g);
	}

	public override void update()
	{
		lastScreen.update();
		if (limitMove > 0)
		{
			xMove += 2;
			if (xMove > limitMove)
			{
				xMove = 0;
			}
		}
		if (vecListServer.size() > 0)
		{
			if (GameCanvas.isTouch && list != null)
			{
				list.moveCamera();
			}
			else
			{
				MainScreen.cameraSub.UpdateCamera();
			}
			if (MainScreen.cameraSub.yCam != MainScreen.cameraSub.yTo)
			{
				setMinMax();
			}
		}
		else if (center != null || left != null)
		{
			center = null;
			left = null;
		}
	}

	public override void updatekey()
	{
		if (vecListServer.size() > 0)
		{
			int num = idSelect;
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
			idSelect = resetSelect(idSelect, vecListServer.size() - 1, isreset: false);
			if (num != idSelect)
			{
				setXmove();
				MainScreen.cameraSub.moveCamera(0, idSelect * hItem - h / 2 + 40 + GameCanvas.hCommand);
			}
		}
		base.updatekey();
	}

	public override void updatePointer()
	{
		if (vecListServer.size() > 0)
		{
			if (GameCanvas.isPointSelect(x, y + GameCanvas.hCommand, w, h - GameCanvas.hCommand))
			{
				int num = (MainScreen.cameraSub.yCam + GameCanvas.py - y - GameCanvas.hCommand) / hItem;
				if (num >= 0 && num < vecListServer.size())
				{
					GameCanvas.isPointerSelect = false;
					if (num == idSelect)
					{
						cmdMenuPoiter.perform();
					}
					else
					{
						idSelect = num;
						setXmove();
					}
				}
				else
				{
					idSelect = 0;
				}
				GameCanvas.isPointerSelect = false;
			}
			if (GameCanvas.isTouch && list != null)
			{
				list.update_Pos_UP_DOWN();
				MainScreen.cameraSub.yCam = list.cmx;
			}
		}
		base.updatePointer();
	}

	public void setMinMax()
	{
		min = MainScreen.cameraSub.yCam / hItem - 1;
		if (min < 0)
		{
			min = 0;
		}
		max = min + maxpaint;
		if (max > vecListServer.size())
		{
			max = vecListServer.size();
			min = max - maxpaint;
			if (min < 0)
			{
				min = 0;
			}
		}
	}

	public void setXmove()
	{
		if (vecListServer == null || idSelect == -1 || idSelect > vecListServer.size() - 1)
		{
			return;
		}
		xMove = 0;
		string st = string.Empty;
		int num = 40;
		if (typeList == 3)
		{
			MainClan mainClan = (MainClan)vecListServer.elementAt(idSelect);
			if (mainClan.hang != -1)
			{
				st = mainClan.slogan;
			}
			num = 20;
		}
		else
		{
			MainObject mainObject = (MainObject)vecListServer.elementAt(idSelect);
			st = mainObject.infoObject;
		}
		if (typeList == 2)
		{
			num = 50;
		}
		limitMove = mFont.tahoma_7_black.getWidth(st) - (w - num) + 5;
		if (limitMove > 0)
		{
			limitMove += 25;
		}
	}

	public void setCmd()
	{
		if (vecListServer.size() > 0 && !GameCanvas.isTouch)
		{
			left = cmdMenuPoiter;
			if (typeList == 0)
			{
				center = cmdchat;
			}
		}
	}

	public void updateList()
	{
		MainScreen.cameraSub.setAll(0, vecListServer.size() * hItem - h + GameCanvas.hCommand + 10, 0, 0);
		list = new ListNew(x, y, w, h, hItem, 0, MainScreen.cameraSub.yLimit);
	}
}
