using System;

public class GameScreen : MainScreen
{
	public static int ID_DLG_BUY_KC = -32059;

	public static Player player = new Player(0, 0, "unname", 0, 0);

	public static Pet pet = null;

	public static short[] idmap18;

	public static mVector vecDataeff = new mVector();

	public static MainObject ObjFocus = null;

	public static mVector VecNum = new mVector("GameScr VecNum");

	public static mVector Vecplayers = new mVector("GameScr Vecplayers");

	public static mVector VecInfoServer = new mVector("GameScr VecInfoServer");

	public static mVector VecInfoChar = new mVector("GameScr menu");

	public static mVector vecEffInMap = new mVector("GameScr vecEffInMap");

	public static mVector vecStep = new mVector("GameScr vecStep");

	public static mHashTable HashImageItemMap = new mHashTable();

	public static mHashTable HashImageNPC = new mHashTable();

	public static mVector vecWeather = new mVector("GameScr vecWeather");

	public static MainHelp help = new MainHelp();

	public static PaintInfoGameScreen infoGame = new PaintInfoGameScreen();

	public iCommand cmdMenu;

	public iCommand cmdGiaotiep;

	public iCommand cmdMyseft;

	public iCommand cmdAddfriend;

	public iCommand cmdInfoChar;

	public iCommand cmdChat;

	public iCommand cmdMoiParty;

	public iCommand cmdShowChat;

	public iCommand cmdNewParty;

	public iCommand cmdParty;

	public iCommand cmdBuy_Sell;

	public iCommand cmdSetWeather;

	public iCommand cmdChangeMap;

	public iCommand cmdChucNang;

	public iCommand cmdListFriend;

	public iCommand cmdAutoFire;

	public iCommand cmdSetPk;

	public iCommand cmdSetDoSat;

	public iCommand cmdEndHelp;

	public iCommand cmdAutoItem;

	public iCommand cmdAutoMPHP;

	public iCommand cmdThachDau;

	public iCommand cmdAutoBuff;

	public iCommand cmdShowAuto;

	public iCommand cmdAddMemClan;

	public iCommand cmdQuickChat;

	public iCommand cmdInfoVantieu;

	public iCommand cmdplayerStore;

	public iCommand cmdinfoMiNuong;

	public static long timeCheckDelHash;

	public static sbyte timePaintCmdGiaotiep = 0;

	public static bool isMoveCamera = false;

	public static int xMoveCam;

	public static int yMoveCam;

	public static int xCur;

	public static int yCur;

	public static int timeResetCam;

	public static int demNumSoundEff = 0;

	public static string nameSpecialRegion = string.Empty;

	public static long timeSpRegion = 0L;

	public static long timeArena = -1L;

	public static mVector vecHightEffAuto = new mVector("Hight EffectAuto");

	public static bool isInPetArea = false;

	public static mVector arrowsUp = new mVector();

	public static mVector vecTimecountDown = new mVector("Time");

	public static bool isHideOderPlayer = false;

	public static bool isFinishHelp = false;

	public static string[] textServer;

	public static bool isShowHoiSinh = false;

	public static bool isMapLang = false;

	public int xRec;

	public int yRec;

	public int wRec;

	public int hRec;

	public int colorRec;

	public bool isFullScreen;

	public mImage imgCombo;

	public bool isCombo;

	public static bool isReArea = false;

	public int pz;

	public int o;

	private MainObject ob;

	private MainObject maxob = new MainObject();

	public static MainItemMap tr;

	public static MainItemMap maxtr = new MainItemMap();

	public static int dx = 0;

	public static int dy = 0;

	public static string goiMes = string.Empty;

	public mVector menuNgua = new mVector("GameScr menungua");

	public static short[][] posSkill = new short[2][]
	{
		new short[3] { -72, 0, 120 },
		new short[3] { 144, 192, 120 }
	};

	private int xStart;

	private int yStart;

	private int cmxMini;

	private int cmyMini;

	public GameScreen()
	{
		cmdAddfriend = new iCommand(T.addFriend, 0);
		cmdInfoChar = new iCommand(T.info, 1);
		cmdChat = new iCommand(T.trochuyen, 2);
		cmdMoiParty = new iCommand(T.moiParty, 3);
		cmdNewParty = new iCommand(T.newParty, 5);
		cmdBuy_Sell = new iCommand(T.buySell, 7);
		cmdSetWeather = new iCommand("mua", 25, this);
		cmdChucNang = new iCommand(T.chucnang, 14);
		cmdAddMemClan = new iCommand(T.addmemclan, 15);
		cmdGiaotiep = new iCommand(T.giaotiep, 0, this);
		cmdMenu = new iCommand(T.menu, 1, this);
		cmdShowChat = new iCommand(T.tinnhan, 4, this);
		cmdParty = new iCommand(T.party, 6, this);
		cmdSetPk = new iCommand(T.setPk, 8, this);
		cmdSetDoSat = new iCommand(T.dosat, 10, this);
		cmdChangeMap = new iCommand(T.changeArea, 12, this);
		cmdListFriend = new iCommand(T.listFriend, 15, this);
		cmdAutoFire = new iCommand(T.autoFire, 16, this);
		cmdEndHelp = new iCommand(T.endHelp, 17, this);
		cmdAutoItem = new iCommand(T.autoItem, 18, this);
		cmdAutoMPHP = new iCommand(T.autoHP, 19, this);
		cmdThachDau = new iCommand(T.thachdau, 20, this);
		cmdAutoBuff = new iCommand(T.autoBuff, 21, this);
		cmdShowAuto = new iCommand(T.info, 22, this);
		cmdInfoVantieu = new iCommand(T.info, 27, this);
		cmdQuickChat = new iCommand(T.chat, 28, this);
		cmdplayerStore = new iCommand(T.gianHang, 30, this);
		cmdinfoMiNuong = new iCommand(T.info, 31, this);
	}

	public static GameScreen gI()
	{
		if (GameCanvas.game == null)
		{
			GameCanvas.game = new GameScreen();
		}
		return GameCanvas.game;
	}

	public override void Show()
	{
		left = null;
		right = null;
		center = null;
		if (Main.isPC)
		{
			cmdMenu.isNotShowTab = true;
			left = cmdMenu;
		}
		base.Show();
		isMoveCamera = false;
		GameCanvas.clearAll();
	}

	public void checkRemoveImage()
	{
		if (!GameCanvas.isTouch)
		{
			checkClear();
		}
		ImageEffectAuto.SetRemoveAll();
		ImageEffect.SetRemoveAll();
		BackGround.mImgSky = null;
		BackGround.mImgSea = null;
		BackGround.mImgFloating = null;
		BackGround.mImgBoat = null;
		mSystem.my_Gc();
		PaintInfoGameScreen.timeDoNotClick = GameCanvas.timeNow;
		vecWeather.removeAllElements();
	}

	public void setCaptionCmd()
	{
		cmdAddfriend.caption = T.addFriend;
		cmdInfoChar.caption = T.info;
		cmdChat.caption = T.trochuyen;
		cmdMoiParty.caption = T.moiParty;
		cmdNewParty.caption = T.newParty;
		cmdBuy_Sell.caption = T.buySell;
		cmdChucNang.caption = T.chucnang;
		cmdAddMemClan.caption = T.addmemclan;
		cmdGiaotiep.caption = T.giaotiep;
		cmdMenu.caption = T.menu;
		cmdShowChat.caption = T.tinnhan;
		cmdParty.caption = T.party;
		cmdSetPk.caption = T.setPk;
		cmdSetDoSat.caption = T.dosat;
		cmdChangeMap.caption = T.changeArea;
		cmdListFriend.caption = T.listFriend;
		cmdAutoFire.caption = T.autoFire;
		cmdEndHelp.caption = T.endHelp;
		cmdAutoItem.caption = T.autoItem;
		cmdAutoMPHP.caption = T.autoHP;
		cmdThachDau.caption = T.thachdau;
		cmdAutoBuff.caption = T.autoBuff;
		cmdShowAuto.caption = T.info;
		cmdInfoVantieu.caption = T.info;
		cmdQuickChat.caption = T.chat;
	}

	public override void commandTab(int index, int sub)
	{
		switch (index)
		{
		case 2:
			GameCanvas.AllInfo.Show(this);
			break;
		}
		base.commandTab(index, sub);
	}

	public override void commandMenu(int index, int sub)
	{
		switch (index)
		{
		case 0:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Friend(0, Menu2.objSelect.name);
			}
			break;
		case 1:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Re_Info_Other_Object(Menu2.objSelect.name, Info_Other_Player.VIEW);
			}
			break;
		case 2:
			if (Menu2.objSelect != null)
			{
				GameCanvas.msgchat.addNewChat(Menu2.objSelect.name, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, true);
			}
			GameCanvas.start_Chat_Dialog();
			break;
		case 3:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Party(1, Menu2.objSelect.name);
			}
			break;
		case 5:
			GlobalService.gI().Party(0, string.Empty);
			break;
		case 7:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Buy_Sell(0, Menu2.objSelect.name, 0, 0, 0);
			}
			break;
		case 14:
			MenuChucNang();
			break;
		case 15:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Add_And_AnS_MemClan(10, Menu2.objSelect.name);
			}
			break;
		}
		base.commandMenu(index, sub);
	}

	public void MenuChucNang()
	{
		mVector mVector3 = new mVector("GameScr menu3");
		mVector3.addElement(cmdListFriend);
		string caption = T.off + " " + T.dosat;
		if (player.typePk != 0)
		{
			mVector3.addElement(cmdSetPk);
			caption = T.on + " " + T.dosat;
		}
		cmdSetDoSat.caption = caption;
		mVector3.addElement(cmdSetDoSat);
		if (Player.isAutoFire > -1)
		{
			cmdAutoFire.caption = T.off + T.autoFire;
		}
		else
		{
			cmdAutoFire.caption = T.on + T.autoFire;
		}
		mVector3.addElement(cmdAutoFire);
		if (Player.autoItem != null)
		{
			cmdAutoItem.caption = T.off + T.autoItem;
		}
		else
		{
			cmdAutoItem.caption = T.on + T.autoItem;
		}
		mVector3.addElement(cmdAutoItem);
		if (Player.isAutoHPMP)
		{
			cmdAutoMPHP.caption = T.off + T.autoHP;
		}
		else
		{
			cmdAutoMPHP.caption = T.on + T.autoHP;
		}
		mVector3.addElement(cmdAutoMPHP);
		if (help.Step >= 0)
		{
			mVector3.addElement(cmdEndHelp);
		}
		GameCanvas.menu2.startAt(mVector3, 2, T.chucnang, false, null);
	}

	public void doArea()
	{
		GlobalService.gI().Request_Area();
		isReArea = true;
		GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			GameCanvas.end_Dialog();
			if (player.isSelling())
			{
				do_Show_SellItem();
				break;
			}
			if (infoGame.isMapThachdau() && !GameCanvas.isTouch)
			{
				return;
			}
			if (ObjFocus == null)
			{
				break;
			}
			if (ObjFocus.isSelling())
			{
				cmdplayerStore.perform();
			}
			else if (!player.setFirePlayer(ObjFocus) || ObjFocus.typeObject != 0)
			{
				ObjFocus.GiaoTiep();
				if (Player.isAutoFire == 1)
				{
					Player.setCurAutoFire();
				}
				player.resetAction();
				timePaintCmdGiaotiep = 0;
			}
			else if (center == cmdGiaotiep)
			{
				center = null;
			}
			break;
		case 1:
			GameCanvas.end_Dialog();
			if (player.isSelling())
			{
				do_Show_SellItem();
				break;
			}
			GameCanvas.AllInfo.Show(GameCanvas.game);
			GlobalService.gI().send_cmd_server(59);
			if (help.setStep_Next(1, 9))
			{
				GameCanvas.AllInfo.selectTab = 0;
				help.NextStep();
				help.setNext();
			}
			else if (help.setStep_Next(6, 2))
			{
				help.NextStep();
				help.setNext();
			}
			break;
		case 4:
			GameCanvas.start_Chat_Dialog();
			break;
		case 6:
			if (Player.party != null)
			{
				GameCanvas.start_Party_Dialog();
			}
			break;
		case 8:
		{
			mVector mVector4 = new mVector("GameScr menu");
			for (int j = 0; j < T.mColorPk.Length; j++)
			{
				if (j <= 0 && player.typePk == -1)
				{
					continue;
				}
				iCommand iCommand3 = new iCommand(T.mColorPk[j], 9, (j != 0) ? j : (-1), this);
				if (mGraphics.zoomLevel >= 3)
				{
					if (j > 0)
					{
						FrameImage[] array = new FrameImage[3];
						for (int k = 0; k < array.Length; k++)
						{
							array[k] = AvMain.fraPkArr[j * 3 + k];
						}
						iCommand3.setFraCaption(array, 3, j * 3);
					}
				}
				else if (j > 0)
				{
					iCommand3.setFraCaption(AvMain.fraPk, 3, j * 3);
				}
				mVector4.addElement(iCommand3);
			}
			GameCanvas.menu2.startAt(mVector4, 4, T.setPk, false, null);
			break;
		}
		case 9:
			GlobalService.gI().set_Pk((sbyte)subIndex);
			break;
		case 10:
			if (player.typePk != 0)
			{
				GameCanvas.start_Left_Dialog(T.hoibatdosat, new iCommand(T.on, 24, this));
			}
			else
			{
				GlobalService.gI().set_Pk(-1);
			}
			break;
		case 13:
			GlobalService.gI().Change_Area((sbyte)subIndex);
			break;
		case 15:
			if (!List_Server.isLoadFriend)
			{
				GlobalService.gI().Friend(4, string.Empty);
				GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.cancel, -1));
				break;
			}
			List_Server.gI().vecListServer = List_Server.vecMyFriend;
			List_Server.gI().typeList = 0;
			List_Server.gI().updateList();
			List_Server.gI().setMinMax();
			List_Server.gI().setXmove();
			List_Server.gI().setCmd();
			List_Server.gI().nameList = T.listFriend;
			List_Server.gI().page = 99;
			List_Server.gI().Show(this);
			break;
		case 16:
			if (Player.isAutoFire > -1)
			{
				Player.isAutoFire = -1;
				Player.isCurAutoFire = false;
			}
			else
			{
				Player.isAutoFire = 0;
				Player.isCurAutoFire = true;
			}
			break;
		case 17:
			help.p = null;
			help.Step = -1;
			help.Next = 0;
			help.setNext();
			help.SaveStep();
			break;
		case 18:
			if (Player.autoItem != null)
			{
				Player.autoItem.isremove = true;
			}
			else
			{
				GameCanvas.start_Auto_Item_Dialog();
			}
			break;
		case 19:
			if (Player.isAutoHPMP)
			{
				Player.isAutoHPMP = false;
				MainRMS.setSaveAuto();
			}
			else
			{
				GameCanvas.start_Auto_HPMP_Dialog();
			}
			break;
		case 20:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Thach_Dau(0, Menu2.objSelect.name);
			}
			break;
		case 21:
			GameCanvas.start_Auto_Buff();
			break;
		case 22:
			PaintInfoGameScreen.isShowInfoAuto = !PaintInfoGameScreen.isShowInfoAuto;
			MainRMS.setSaveTouch();
			break;
		case 24:
			GlobalService.gI().set_Pk(0);
			GameCanvas.end_Dialog();
			break;
		case 25:
			AddEffWeather(0, false, -4, 300);
			break;
		case 26:
			if (subIndex >= 0 && subIndex <= menuNgua.size() - 1)
			{
				MainItem mainItem = (MainItem)menuNgua.elementAt(subIndex);
				if (mainItem != null)
				{
					GlobalService.gI().Use_Potion((short)mainItem.Id);
				}
			}
			break;
		case 27:
			GlobalService.gI().Dynamic_Menu(-56, 0, 0);
			break;
		case 28:
		{
			mVector mVector3 = new mVector("GameScr menuchat");
			for (int i = 0; i < T.mQuickChat.Length; i++)
			{
				iCommand iCommand2 = new iCommand(T.mQuickChat[i], 29, i, this);
				mVector3.addElement(iCommand2);
			}
			GameCanvas.menu2.startAt(mVector3, 4, T.chat, false, null);
			break;
		}
		case 29:
			player.strChatPopup = T.mQuickChat[subIndex];
			GlobalService.gI().chatPopup(T.mQuickChat[subIndex]);
			break;
		case 30:
			if (ObjFocus != null && ObjFocus.isSelling())
			{
				GlobalService.gI().do_Buy_Sell_Item(1, null, string.Empty, (short)ObjFocus.ID, 0, 0);
			}
			break;
		case 31:
			if (ObjFocus != null && ObjFocus.isMiNuong())
			{
				GlobalService.gI().RequestInfo_MiNuong(0, (short)(ObjFocus.ID + 1000));
			}
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public void doSellItem()
	{
		GameCanvas.end_Dialog();
		Item.VecItem_Sell_in_store.removeAllElements();
		Item.VecItemSell.removeAllElements();
		mVector mVector3 = new mVector("Sell");
		sbyte isTypeShop = 0;
		TabShopNew tabShopNew = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVEN_AND_STORE, T.tabhanhtrang, -1, isTypeShop);
		mVector3.addElement(tabShopNew);
		mVector vec = new mVector("info");
		TabShopNew tabShopNew2 = new TabShopNew(vec, MainTabNew.SELLITEM, T.gianHang, -1, 0);
		mVector3.addElement(tabShopNew2);
		GameCanvas.shopNpc = new TabScreenNew();
		GameCanvas.shopNpc.selectTab = 0;
		GameCanvas.shopNpc.addMoreTab(mVector3);
		GameCanvas.shopNpc.Show(gI());
	}

	public void do_Show_SellItem()
	{
		GameCanvas.end_Dialog();
		mVector mVector3 = new mVector("Sell");
		sbyte isTypeShop = 0;
		TabShopNew tabShopNew = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVEN_AND_STORE, T.tabhanhtrang, -1, isTypeShop);
		mVector3.addElement(tabShopNew);
		mVector vec = new mVector("info");
		TabShopNew tabShopNew2 = new TabShopNew(vec, MainTabNew.SELLITEM, T.gianHang, -1, 0);
		mVector3.addElement(tabShopNew2);
		GameCanvas.shopNpc = new TabScreenNew();
		GameCanvas.shopNpc.selectTab = 0;
		GameCanvas.shopNpc.addMoreTab(mVector3);
		GameCanvas.shopNpc.Show(gI());
	}

	public void paintMonsterEffect(mGraphics g)
	{
		for (int i = 0; i < EffectMonster.listEffectMonster.size(); i++)
		{
			EffectMonster effectMonster = (EffectMonster)EffectMonster.listEffectMonster.elementAt(i);
			effectMonster.paint(g);
		}
	}

	public void paintMonsterDieEffect(mGraphics g)
	{
		for (int i = 0; i < EffectMonster.listEffectMonster.size(); i++)
		{
			EffectMonster effectMonster = (EffectMonster)EffectMonster.listEffectMonster.elementAt(i);
			effectMonster.paintDie(g);
		}
	}

	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		try
		{
			dx = 0;
			dy = 0;
			if (LoadMap.timeVibrateScreen > 0)
			{
				if (LoadMap.timeVibrateScreen > 100)
				{
					dy = CRes.random_Am_0(3);
					if (LoadMap.timeVibrateScreen == 101)
					{
						LoadMap.timeVibrateScreen = 0;
					}
				}
				else
				{
					dy = CRes.random_Am_0(3);
					dx = CRes.random_Am(0, 2);
				}
				LoadMap.timeVibrateScreen--;
			}
			g.translate(dx, dy);
			g.translate(-MainScreen.cameraMain.xCam, -MainScreen.cameraMain.yCam);
			if (GameCanvas.mapBack != null)
			{
				GameCanvas.mapBack.paint(g);
			}
			if (LoadMap.idTile == 9)
			{
				g.setColor(367554);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
			}
			GameCanvas.loadmap.paint(g);
			infoGame.paintShip(g);
			if (isFullScreen)
			{
				g.drawRecAlpa(0, 0, GameCanvas.loadmap.mapW * 24, GameCanvas.loadmap.mapH * 24, colorRec);
			}
			else if (wRec > 0)
			{
				g.fillRecAlpla(xRec, yRec, wRec, hRec, colorRec);
			}
			for (int i = 0; i < vecDataeff.size(); i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)vecDataeff.elementAt(i);
				if (dataSkillEff != null)
				{
					dataSkillEff.paintTop(g, dataSkillEff.x, dataSkillEff.y);
				}
			}
			for (int j = 0; j < LoadMap.Thacnuoc.size(); j++)
			{
				ThacNuoc thacNuoc = (ThacNuoc)LoadMap.Thacnuoc.elementAt(j);
				thacNuoc.paint(g);
			}
			for (int k = 0; k < vecStep.size(); k++)
			{
				Point point = (Point)vecStep.elementAt(k);
				point.paint(g);
			}
			for (int l = 0; l < vecEffInMap.size(); l++)
			{
				Point point2 = (Point)vecEffInMap.elementAt(l);
				point2.paint(g);
			}
			if (help.Step >= 0 && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.currentScreen == this && !ChatTextField.isShow && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.game)
			{
				help.paintHelpFrist(g);
			}
			if (GameCanvas.isTouch && Player.timeFocus > 0 && player.posTransRoad != null && Player.xFocus >= 0)
			{
				PaintInfoGameScreen.fraFocusIngame.drawFrame((4 - Player.timeFocus / 2) % PaintInfoGameScreen.fraFocusIngame.nFrame, Player.xFocus, Player.yFocus, 0, 3, g);
			}
			EffectManager.lowEffects.paintAll(g);
			paintMonsterDieEffect(g);
			ItemMap.paintDieHouseArena(g);
			try
			{
				pz = 0;
				o = 0;
				maxob.y = 10000;
				maxtr.y = 10000;
				while (pz < Vecplayers.size() || o < LoadMap.mItemMap.size())
				{
					ob = maxob;
					tr = maxtr;
					if (pz < Vecplayers.size())
					{
						ob = (MainObject)Vecplayers.elementAt(pz);
					}
					if (o < LoadMap.mItemMap.size())
					{
						tr = (MainItemMap)LoadMap.mItemMap.elementAt(o);
					}
					if (tr == null || ob.y + ob.ysai < tr.y + LoadMap.wTile)
					{
						if (MainObject.isInScreen(ob) && !ob.isStop && !ob.isRemove)
						{
							ob.paint(g);
							if (ob.chat != null && ob.chat.strChat != null)
							{
								ob.chat.paint(g);
							}
						}
						pz++;
						if (tr == null)
						{
							o++;
						}
					}
					else
					{
						if (tr.isInScreen() && tr != null)
						{
							tr.paint(g);
						}
						o++;
					}
				}
			}
			catch (Exception)
			{
				mSystem.outloi("loi gameScreen paint Doi tuong");
			}
			for (int m = 0; m < arrowsUp.size(); m++)
			{
				IArrow arrow = (IArrow)arrowsUp.elementAt(m);
				if (arrow != null)
				{
					arrow.paint(g);
				}
			}
			for (int n = 0; n < vecDataeff.size(); n++)
			{
				DataSkillEff dataSkillEff2 = (DataSkillEff)vecDataeff.elementAt(n);
				if (dataSkillEff2 != null)
				{
					dataSkillEff2.paintBottom(g, dataSkillEff2.x, dataSkillEff2.y);
				}
			}
			paintMonsterEffect(g);
			for (int num = 0; num < vecDataeff.size(); num++)
			{
				DataSkillEff dataSkillEff3 = (DataSkillEff)vecDataeff.elementAt(num);
				if (dataSkillEff3 != null)
				{
					dataSkillEff3.paintBottom(g, dataSkillEff3.x, dataSkillEff3.y);
				}
			}
			for (int num2 = 0; num2 < LoadMap.vecPointChange.size(); num2++)
			{
				Point point3 = (Point)LoadMap.vecPointChange.elementAt(num2);
				g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, LoadMap.mTranPointChangeMap[point3.dis], point3.x + GameCanvas.gameTick % 6 * point3.vx, point3.y + GameCanvas.gameTick % 6 * point3.vy, 3, mGraphics.isFalse);
				AvMain.Font3dWhite(g, point3.name, point3.x2 + GameCanvas.gameTick % 6 * point3.vx, point3.y2 + GameCanvas.gameTick % 6 * point3.vy, point3.f);
			}
			if (ObjFocus != null && ObjFocus.typeObject != 1)
			{
				ObjFocus.paintNameFocus(g);
			}
			int num3 = VecNum.size();
			EffectManager.hiEffects.paintAll(g);
			if (vecHightEffAuto.size() > 0)
			{
				for (int num4 = 0; num4 < vecHightEffAuto.size(); num4++)
				{
					EffectAuto effectAuto = (EffectAuto)vecHightEffAuto.elementAt(num4);
					if (effectAuto != null)
					{
						effectAuto.paint(g);
					}
				}
			}
			for (int num5 = 0; num5 < num3; num5++)
			{
				MainEffect mainEffect = (MainEffect)VecNum.elementAt(num5);
				if (MainEffect.isInScreen(mainEffect.x, mainEffect.y, 10, 10) && !mainEffect.isRemove && !mainEffect.isStop)
				{
					mainEffect.paint(g);
				}
			}
			for (int num6 = 0; num6 < vecWeather.size(); num6++)
			{
				AnimateEffect animateEffect = (AnimateEffect)vecWeather.elementAt(num6);
				animateEffect.paint(g);
			}
			MainObject.paintFocus(g);
			GameCanvas.resetTrans(g);
			if (timePaintCmdGiaotiep > 0 && cmdGiaotiep != null)
			{
				cmdGiaotiep.paint(g, cmdGiaotiep.xCmd, cmdGiaotiep.yCmd);
			}
			if ((!GameCanvas.menu2.isShowMenu || Menu2.isNPCMenu == 2) && (GameCanvas.currentDialog == null || (help.Step == 5 && help.Next < 8) || (GameCanvas.isTouch && (help.Step == 0 || help.Step == 1))) && GameCanvas.currentScreen == this && !ChatTextField.isShow && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.game && (PaintInfoGameScreen.isShowInGame || PaintInfoGameScreen.hShowInGame < 100))
			{
				if (player.currentQuest == null)
				{
					if (GameCanvas.isTouch)
					{
						g.translate(GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini, -PaintInfoGameScreen.hShowInGame);
					}
					else
					{
						g.translate(GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini - 3, GameCanvas.h - 23 - GameCanvas.minimap.maxY * MiniMap.wMini + PaintInfoGameScreen.hShowInGame);
					}
					if (GameCanvas.isTouch)
					{
						if (!infoGame.isMapThachdau() && !infoGame.isMapchienthanh())
						{
							AvMain.paintDialog(g, GameCanvas.minimap.maxX * MiniMap.wMini - 40, GameCanvas.minimap.maxY * MiniMap.wMini - 19, 40, 35, 1);
							mFont.tahoma_7b_black.drawString(g, T.Area + LoadMap.getAreaPaint(), GameCanvas.minimap.maxX * MiniMap.wMini - 37 + 17, GameCanvas.minimap.maxY * MiniMap.wMini + 3, 2, mGraphics.isFalse);
						}
						string empty = string.Empty;
						if (infoGame.isMapArena(GameCanvas.loadmap.idMap))
						{
							infoGame.paintTimeHS(g);
							empty = LoadMap.getTimeArena(timeArena);
							if (!empty.Equals(string.Empty))
							{
								g.fillRect(GameCanvas.minimap.maxX * MiniMap.wMini - GameCanvas.w / 2 - 18, GameCanvas.minimap.maxY * MiniMap.wMini - 38, 36, 17, 0, 60, mGraphics.isFalse);
								AvMain.Font3dWhite(g, empty, GameCanvas.minimap.maxX * MiniMap.wMini - GameCanvas.w / 2, GameCanvas.minimap.maxY * MiniMap.wMini - 35, 2);
							}
						}
						else
						{
							empty = LoadMap.getTimeSpecialRegion();
							if (!empty.Equals(string.Empty))
							{
								mFont.tahoma_7_white.drawString(g, empty, GameCanvas.minimap.maxX * MiniMap.wMini - 42, GameCanvas.minimap.maxY * MiniMap.wMini + 3, 1, mGraphics.isFalse);
							}
						}
					}
					else
					{
						string empty2 = string.Empty;
						if (GameCanvas.isSmallScreen)
						{
							mFont.tahoma_7_black.drawString(g, T.Area + LoadMap.getAreaPaint(), 14, -13, 2, mGraphics.isFalse);
							if (infoGame.isMapArena(GameCanvas.loadmap.idMap))
							{
								infoGame.paintTimeHS(g);
								empty2 = LoadMap.getTimeArena(timeArena);
								if (!empty2.Equals(string.Empty))
								{
									AvMain.Font3dWhite(g, empty2, 14, -30, 1);
								}
							}
							else
							{
								empty2 = LoadMap.getTimeSpecialRegion();
								if (!empty2.Equals(string.Empty))
								{
									mFont.tahoma_7_white.drawString(g, empty2, 14, -30, 1, mGraphics.isFalse);
								}
							}
						}
						else
						{
							AvMain.paintDialog(g, GameCanvas.minimap.maxX * MiniMap.wMini - 37, -17, 40, 35, 1);
							mFont.tahoma_7b_black.drawString(g, T.Area + LoadMap.getAreaPaint(), GameCanvas.minimap.maxX * MiniMap.wMini - 34 + 17, -14, 2, mGraphics.isFalse);
							if (infoGame.isMapArena(GameCanvas.loadmap.idMap))
							{
								infoGame.paintTimeHS(g);
								empty2 = LoadMap.getTimeArena(timeArena);
								if (!empty2.Equals(string.Empty))
								{
									AvMain.Font3dWhite(g, empty2, GameCanvas.minimap.maxX * MiniMap.wMini - 39, -14, 1);
								}
							}
							else
							{
								empty2 = LoadMap.getTimeSpecialRegion();
								if (!empty2.Equals(string.Empty))
								{
									mFont.tahoma_7_white.drawString(g, empty2, GameCanvas.minimap.maxX * MiniMap.wMini - 39, -14, 1, mGraphics.isFalse);
								}
							}
						}
					}
					GameCanvas.minimap.paint(g);
					GameCanvas.resetTrans(g);
					infoGame.paintPos_minimap(g, GameCanvas.w, 0);
					if (player != null && !mSystem.isj2me)
					{
						if (player.Action == 4)
						{
							g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, 0, 60, mGraphics.isFalse);
						}
						else if (player.ispaintHit)
						{
							PaintInfoGameScreen.paintHitscr(g, player.isMaxdame);
						}
					}
					infoGame.paintInfoPlayer(g, 0, -PaintInfoGameScreen.hShowInGame, !GameCanvas.isSmallScreen, mFont.tahoma_7_white);
					infoGame.paintInfoThachDau(g, 0, -PaintInfoGameScreen.hShowInGame);
					infoGame.paintInfoThachDauOtherPlayer(g, GameCanvas.w / 2 + 20, -PaintInfoGameScreen.hShowInGame);
					infoGame.paintInfoFocus(g);
					if (!GameCanvas.isTouch && player.Action != 4)
					{
						infoGame.paintKillPlayer(g);
					}
					infoGame.PaintIconPlayer(g);
					if (!GameCanvas.menu2.isShowMenu)
					{
						infoGame.paintPoiterAll(g);
					}
					if (PaintInfoGameScreen.numMess > 0)
					{
						g.drawImage(AvMain.imgMess, PaintInfoGameScreen.xMess, PaintInfoGameScreen.yMess - PaintInfoGameScreen.hShowInGame, 0, mGraphics.isFalse);
						string str = PaintInfoGameScreen.numMess + string.Empty;
						if (PaintInfoGameScreen.numMess > 20)
						{
							str = "20+";
						}
						AvMain.Font3dWhite(g, str, PaintInfoGameScreen.xMess + 17, PaintInfoGameScreen.yMess - 1 - PaintInfoGameScreen.hShowInGame, 0);
					}
				}
				GameCanvas.resetTrans(g);
				if (infoGame.strInfoServer == null && PaintInfoGameScreen.isShowInGame && !GameCanvas.menu2.isShowMenu)
				{
					if (GameCanvas.isTouch)
					{
						paintCmd(g);
					}
					else
					{
						paintCmd_OnlyText(g);
					}
				}
				if (imgCombo != null)
				{
					g.drawImage(imgCombo, 5, 46, 0, false);
				}
			}
			GameCanvas.resetTrans(g);
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				if (!isFinishHelp && help.Step >= 0 && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && !ChatTextField.isShow && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.game)
				{
					help.paintHelpLast(g);
				}
			}
			else if (help.Step >= 0 && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && !ChatTextField.isShow && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.game)
			{
				help.paintHelpLast(g);
			}
			infoGame.paintNameMap(g);
			infoGame.paintIconClan(g);
			if (PaintInfoGameScreen.paint18plush == 1 && canpaint18plus())
			{
				PaintInfoGameScreen.paintinfo18plush(g);
			}
			for (int num7 = 0; num7 < vecTimecountDown.size(); num7++)
			{
				TimecountDown timecountDown = (TimecountDown)vecTimecountDown.elementAt(num7);
				if (timecountDown != null)
				{
					timecountDown.paint(g);
				}
			}
			GameCanvas.resetTrans(g);
			if (textServer != null && textServer.Length > 0)
			{
				for (int num8 = 0; num8 < textServer.Length; num8++)
				{
					AvMain.Font3dWhite(g, textServer[num8], GameCanvas.w - 10, GameCanvas.minimap.maxY * MiniMap.wMini + 15 + num8 * GameCanvas.hText, 1);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public bool canpaint18plus()
	{
		if (idmap18 != null)
		{
			for (int i = 0; i < idmap18.Length; i++)
			{
				if (idmap18[i] == GameCanvas.loadmap.idMap)
				{
					return false;
				}
			}
		}
		return true;
	}

	public void checkPaintNamearena()
	{
		if (GameCanvas.gameTick % 50 != 0)
		{
			return;
		}
		for (int i = 0; i < Vecplayers.size() - 1; i++)
		{
			MainObject mainObject = (MainObject)Vecplayers.elementAt(i);
			mainObject.Namearena = false;
		}
		for (int j = 0; j < Vecplayers.size() - 1; j++)
		{
			MainObject mainObject2 = (MainObject)Vecplayers.elementAt(j);
			if (mainObject2 == null || mainObject2.typeObject != 0)
			{
				continue;
			}
			for (int k = j + 1; k < Vecplayers.size(); k++)
			{
				MainObject mainObject3 = (MainObject)Vecplayers.elementAt(k);
				if (mainObject3.typeObject == 0 && mainObject3 != null && CRes.abs(mainObject2.x - mainObject3.x) <= 20 && CRes.abs(mainObject2.y - mainObject3.y) <= 20)
				{
					mainObject2.Namearena = true;
					mainObject3.Namearena = true;
				}
			}
		}
	}

	public override void update()
	{
		try
		{
			for (int i = 0; i < vecDataeff.size(); i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)vecDataeff.elementAt(i);
				if (dataSkillEff != null)
				{
					dataSkillEff.update();
					if (dataSkillEff.wantDetroy)
					{
						vecDataeff.removeElement(dataSkillEff);
						i--;
					}
				}
			}
			for (int j = 0; j < vecEffInMap.size(); j++)
			{
				Point point = (Point)vecEffInMap.elementAt(j);
				point.updateInMap();
				if (point.isRemove)
				{
					vecEffInMap.removeElement(point);
					j--;
				}
			}
			for (int k = 0; k < vecTimecountDown.size(); k++)
			{
				TimecountDown timecountDown = (TimecountDown)vecTimecountDown.elementAt(k);
				timecountDown.update();
				if (timecountDown.wantdestroy)
				{
					vecTimecountDown.removeElement(timecountDown);
				}
			}
			for (int l = 0; l < vecStep.size(); l++)
			{
				Point point2 = (Point)vecStep.elementAt(l);
				point2.updateInMap();
				if (point2.isRemove)
				{
					vecStep.removeElement(point2);
					l--;
				}
			}
			for (int m = 0; m < LoadMap.Thacnuoc.size(); m++)
			{
				ThacNuoc thacNuoc = (ThacNuoc)LoadMap.Thacnuoc.elementAt(m);
				thacNuoc.update();
			}
			if (help.Step >= 0)
			{
				help.updateHelp();
			}
			if (Player.timeFocus > 0)
			{
				Player.timeFocus--;
			}
			if (GameCanvas.mapBack != null)
			{
				GameCanvas.mapBack.updateCloud();
			}
			for (int n = 0; n < LoadMap.mItemMap.size(); n++)
			{
				MainItemMap mainItemMap = (MainItemMap)LoadMap.mItemMap.elementAt(n);
				if (mainItemMap.TypeItem == 1)
				{
					mainItemMap.update();
				}
			}
			for (int num = 0; num < Vecplayers.size(); num++)
			{
				MainObject mainObject = (MainObject)Vecplayers.elementAt(num);
				if (mainObject.isStop && !mainObject.isRemove)
				{
					mainObject.timeStop++;
					if (mainObject.timeStop >= 5)
					{
						mainObject.isRemove = true;
					}
				}
				else if (mainObject == null || mainObject.isRemove)
				{
					Vecplayers.removeElementAt(num);
					num--;
				}
				else
				{
					mainObject.update();
					mainObject.ySort = mainObject.y + mainObject.ysai;
				}
			}
			for (int num2 = arrowsUp.size() - 1; num2 >= 0; num2--)
			{
				IArrow arrow = (IArrow)arrowsUp.elementAt(num2);
				arrow.update();
				if (arrow.wantDestroy)
				{
					arrowsUp.removeElementAt(num2);
				}
			}
			CRes.quickSort(Vecplayers);
			checkPaintNamearena();
			for (int num3 = 0; num3 < VecNum.size(); num3++)
			{
				MainEffect mainEffect = (MainEffect)VecNum.elementAt(num3);
				if (mainEffect == null || mainEffect.isRemove)
				{
					VecNum.removeElement(mainEffect);
					num3--;
				}
				else if (!mainEffect.isStop)
				{
					mainEffect.update();
				}
			}
			if (LoadMap.isShowEffAuto == LoadMap.EFF_PHOBANG_END)
			{
				MainScreen.cameraMain.moveCamera(MainScreen.cameraMain.xLimit / 2, MainScreen.cameraMain.yLimit / 2);
			}
			else if (player.currentQuest == null)
			{
				if (isMoveCamera)
				{
					MainScreen.cameraMain.setCameraWithLim(xCur - xMoveCam, yCur - yMoveCam);
				}
				else
				{
					MainScreen.cameraMain.moveCamera(player.x - GameCanvas.hw, player.y - GameCanvas.hh);
				}
			}
			else
			{
				MainObject mainObject2 = MainObject.get_Object(player.currentQuest.idNPCChat, 2);
				if (mainObject2 != null)
				{
					MainScreen.cameraMain.moveCamera(player.x - GameCanvas.hw, mainObject2.y - GameCanvas.hh - GameCanvas.hh / 4);
				}
				else
				{
					MainScreen.cameraMain.moveCamera(player.x - GameCanvas.hw, player.y - GameCanvas.hh);
				}
			}
			MainScreen.cameraMain.UpdateCamera();
			GameCanvas.minimap.miniCamera.moveCamera((player.x / LoadMap.wTile - GameCanvas.minimap.maxX / 2) * MiniMap.wMini, (player.y / LoadMap.wTile - GameCanvas.minimap.maxY / 2) * MiniMap.wMini);
			GameCanvas.minimap.miniCamera.UpdateCamera();
			bool flag = false;
			for (int num4 = 0; num4 < vecWeather.size(); num4++)
			{
				flag = true;
				AnimateEffect animateEffect = (AnimateEffect)vecWeather.elementAt(num4);
				animateEffect.update();
				if (animateEffect.type == 4)
				{
					if (animateEffect.isStop)
					{
						vecWeather.removeElement(animateEffect);
						num4--;
					}
				}
				else if (animateEffect.type == 5)
				{
					if (animateEffect.isStop && animateEffect.list.size() == 0)
					{
						vecWeather.removeElement(animateEffect);
						num4--;
					}
				}
				else if (animateEffect.list.size() == 0)
				{
					vecWeather.removeElement(animateEffect);
					num4--;
				}
			}
			if (flag)
			{
				AnimateEffect.updateWind();
			}
			if (GameCanvas.gameTick % 200 == 0)
			{
				ImageEffect.SetRemove();
				ImageEffectAuto.SetRemove();
				DataSkillEff.SetRemove();
				CRes.setRemoveCharPartInfo();
				GameData.SetRemove();
				MainObject.SetRemove();
				EffectAuto.SetRemove();
			}
			if (ObjFocus != null && ObjFocus.isRemove)
			{
				ObjFocus = null;
			}
			if (Player.autoItem != null && Player.autoItem.isremove)
			{
				Player.autoItem = null;
				MainRMS.setSaveAuto();
			}
			if (timePaintCmdGiaotiep > 0)
			{
				if (cmdGiaotiep != null)
				{
					MainObject mainObject3 = MainObject.get_Object(cmdGiaotiep.IdGiaotiep, 0);
					if (mainObject3 == null)
					{
						timePaintCmdGiaotiep = 0;
					}
					else
					{
						cmdGiaotiep.setPosXY(mainObject3.x - MainScreen.cameraMain.xCam, mainObject3.y - MainScreen.cameraMain.yCam - mainObject3.hOne - 30);
					}
				}
				timePaintCmdGiaotiep--;
			}
			if (!GameCanvas.isTouch && (GameCanvas.timeNow - timeCheckDelHash) / 1000 > 300)
			{
				checkClear();
			}
			if (demNumSoundEff > 0 && GameCanvas.gameTick % 30 == 0)
			{
				demNumSoundEff--;
			}
			EffectManager.hiEffects.updateAll();
			EffectManager.lowEffects.updateAll();
			if (vecHightEffAuto.size() > 0)
			{
				for (int num5 = 0; num5 < vecHightEffAuto.size(); num5++)
				{
					EffectAuto effectAuto = (EffectAuto)vecHightEffAuto.elementAt(num5);
					if (effectAuto.wantdestroy)
					{
						vecHightEffAuto.removeElement(effectAuto);
					}
					if (effectAuto != null)
					{
						effectAuto.update();
					}
				}
			}
			infoGame.countTimeHS();
			for (int num6 = 0; num6 < EffectMonster.listEffectMonster.size(); num6++)
			{
				EffectMonster effectMonster = (EffectMonster)EffectMonster.listEffectMonster.elementAt(num6);
				effectMonster.update();
			}
		}
		catch (Exception ex)
		{
			mSystem.println("----loi update gamescr:" + ex.ToString());
		}
	}

	public void checkClear()
	{
		timeCheckDelHash = GameCanvas.timeNow;
		ObjectData.checkDelHash(MainMonster.HashImageMonster);
		ObjectData.checkDelHash(HashImageItemMap);
		ObjectData.checkDelHash(Item.HashImageIconClan);
	}

	public override void updatekey()
	{
		if (!Player.isLockKey)
		{
			base.updatekey();
		}
		if (player != null)
		{
			player.updateKey();
		}
	}

	public override void updatePointer()
	{
		if (GameCanvas.isTouch)
		{
			if (timePaintCmdGiaotiep > 0 && cmdGiaotiep != null)
			{
				cmdGiaotiep.updatePointer();
			}
			base.updatePointer();
			infoGame.updatePoiterAll();
		}
	}

	public void doMenu()
	{
		if (player.Action == 1)
		{
			player.resetMove();
			player.posTransRoad = null;
			player.resetAction();
		}
		mVector mVector3 = new mVector("GameScr menu2");
		mVector3.addElement(cmdMyseft);
		mVector3.addElement(cmdChucNang);
		if (Player.party != null)
		{
			mVector3.addElement(cmdParty);
		}
		if (player.typePk == 0 || (ObjFocus != null && ObjFocus.typePk == 0))
		{
			mVector3.addElement(cmdGiaotiep);
		}
		mVector3.addElement(cmdChangeMap);
		GameCanvas.menu2.startAt(mVector3, 2, T.menuChinh, false, null);
		if (help.setStep_Next(1, 9) || help.setStep_Next(6, 2))
		{
			Menu2.isHelp = true;
		}
		player.resetAction();
	}

	public void doMenuUseNgua(mVector vec)
	{
		menuNgua = new mVector("GameScr menungua2");
		menuNgua = vec;
		mVector mVector3 = new mVector("GameScr newvec");
		for (int i = 0; i < vec.size(); i++)
		{
			MainItem mainItem = (MainItem)vec.elementAt(i);
			if (mainItem != null)
			{
				string itemName = mainItem.itemName;
				iCommand iCommand2 = new iCommand(itemName, 26, i, this);
				mVector3.addElement(iCommand2);
				GameCanvas.menu2.startAt(mVector3, 2, T.TuseNgua, false, null);
			}
		}
	}

	public void doMenuAuto()
	{
		mVector mVector3 = new mVector("GameScr menu3");
		if (Player.isAutoFire > -1)
		{
			gI().cmdAutoFire.caption = T.off + T.autoFire;
		}
		else
		{
			gI().cmdAutoFire.caption = T.on + T.autoFire;
		}
		mVector3.addElement(gI().cmdAutoFire);
		if (Player.autoItem != null)
		{
			gI().cmdAutoItem.caption = T.off + T.autoItem;
		}
		else
		{
			gI().cmdAutoItem.caption = T.on + T.autoItem;
		}
		mVector3.addElement(gI().cmdAutoItem);
		if (Player.isAutoHPMP)
		{
			gI().cmdAutoMPHP.caption = T.off + T.autoHP;
		}
		else
		{
			gI().cmdAutoMPHP.caption = T.on + T.autoHP;
		}
		mVector3.addElement(gI().cmdAutoMPHP);
		mVector3.addElement(gI().cmdAutoBuff);
		cmdShowAuto.caption = T.on + T.showAuto;
		if (PaintInfoGameScreen.isShowInfoAuto)
		{
			cmdShowAuto.caption = T.off + T.showAuto;
		}
		mVector3.addElement(gI().cmdShowAuto);
		GameCanvas.menu2.startAt(mVector3, 2, T.auto, false, null);
	}

	public static void addEffectKill(int type, int idFrom, sbyte temFrom, mVector vec)
	{
		Object_Effect_Skill objfire = new Object_Effect_Skill((short)idFrom, temFrom);
		if (mSystem.isj2me && infoGame.ismapHouse(GameCanvas.loadmap.idMap))
		{
			bool flag = false;
			if (idFrom == player.ID)
			{
				flag = true;
			}
			else if (EffectSkill.countSkillArena <= 3)
			{
				EffectSkill.countSkillArena++;
				flag = true;
			}
			else
			{
				flag = false;
			}
			StartAddEffectSkill(type, objfire, vec);
		}
		else
		{
			StartAddEffectSkill(type, objfire, vec);
		}
	}

	public static void StartAddEffectSkill(int type, Object_Effect_Skill objfire, mVector vec)
	{
		switch (type)
		{
		case 119:
		{
			EffectSkill eff7 = new EffectSkill(114, objfire, vec, 0);
			addEffect2Vector(eff7);
			EffectSkill eff8 = new EffectSkill(115, objfire, vec, 0);
			addEffect2Vector(eff8);
			return;
		}
		case 118:
		{
			EffectSkill eff5 = new EffectSkill(65, objfire, vec, 0);
			addEffect2Vector(eff5);
			mVector mVector5 = new mVector();
			for (int k = 0; k < vec.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)vec.elementAt(k);
				if (object_Effect_Skill3 != null)
				{
					mVector5.addElement(object_Effect_Skill3);
					EffectSkill eff6 = new EffectSkill(62, objfire, mVector5, 0);
					addEffect2Vector(eff6);
					mVector5.removeAllElements();
				}
			}
			return;
		}
		case 117:
		{
			EffectSkill eff13 = new EffectSkill(20, objfire, vec, 0);
			addEffect2Vector(eff13);
			EffectSkill eff14 = new EffectSkill(91, objfire, vec, 0);
			addEffect2Vector(eff14);
			return;
		}
		case 116:
		{
			EffectSkill eff11 = new EffectSkill(53, objfire, vec, 0);
			addEffect2Vector(eff11);
			EffectSkill eff12 = new EffectSkill(77, objfire, vec, 0);
			addEffect2Vector(eff12);
			return;
		}
		case 123:
		{
			EffectSkill eff3 = new EffectSkill(60, objfire, vec, 0);
			addEffect2Vector(eff3);
			mVector mVector4 = new mVector();
			for (int j = 0; j < vec.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)vec.elementAt(j);
				if (object_Effect_Skill2 != null)
				{
					mVector4.addElement(object_Effect_Skill2);
					EffectSkill eff4 = new EffectSkill(49, objfire, mVector4, 0);
					addEffect2Vector(eff4);
					mVector4.removeAllElements();
				}
			}
			return;
		}
		case 122:
		{
			mVector mVector7 = new mVector();
			for (int m = 0; m < vec.size(); m++)
			{
				Object_Effect_Skill object_Effect_Skill5 = (Object_Effect_Skill)vec.elementAt(m);
				if (object_Effect_Skill5 != null)
				{
					mVector7.addElement(object_Effect_Skill5);
					EffectSkill eff15 = new EffectSkill(51, objfire, mVector7, 0);
					addEffect2Vector(eff15);
					mVector7.removeAllElements();
				}
			}
			EffectSkill eff16 = new EffectSkill(66, objfire, vec, 0);
			addEffect2Vector(eff16);
			return;
		}
		case 121:
		{
			EffectSkill eff9 = new EffectSkill(34, objfire, vec, 0);
			addEffect2Vector(eff9);
			mVector mVector6 = new mVector();
			for (int l = 0; l < vec.size(); l++)
			{
				Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)vec.elementAt(l);
				if (object_Effect_Skill4 != null)
				{
					mVector6.addElement(object_Effect_Skill4);
					EffectSkill eff10 = new EffectSkill(55, objfire, mVector6, 0);
					addEffect2Vector(eff10);
					mVector6.removeAllElements();
				}
			}
			return;
		}
		case 120:
		{
			mVector mVector3 = new mVector();
			for (int i = 0; i < vec.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				if (object_Effect_Skill != null)
				{
					mVector3.addElement(object_Effect_Skill);
					EffectSkill eff = new EffectSkill(54, objfire, mVector3, 0);
					addEffect2Vector(eff);
					mVector3.removeAllElements();
				}
			}
			EffectSkill eff2 = new EffectSkill(11, objfire, vec, 0);
			addEffect2Vector(eff2);
			return;
		}
		}
		if (infoGame.isMapchienthanh() || infoGame.ismapHouse(GameCanvas.loadmap.idMap))
		{
			if (objfire.ID == player.ID)
			{
				EffectSkill eff17 = new EffectSkill(type, objfire, vec, 0);
				addEffect2Vector(eff17);
				return;
			}
			EffectSkill effectSkill = new EffectSkill(type, objfire, vec, 0);
			if (effectSkill.levelPaint == -1)
			{
				if (EffectManager.hiEffects.size() <= 20)
				{
					addEffect2Vector(effectSkill);
				}
			}
			else if (EffectManager.lowEffects.size() <= 20)
			{
				addEffect2Vector(effectSkill);
			}
		}
		else
		{
			EffectSkill eff18 = new EffectSkill(type, objfire, vec, 0);
			addEffect2Vector(eff18);
		}
	}

	public static void addEffectKill(int type, int idFrom, sbyte temFrom, int idTo, sbyte temTo, int hpshow, int hplast)
	{
		mVector mVector3 = new mVector("GameScr vec3");
		Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill((short)idTo, temTo);
		object_Effect_Skill.setHP(hpshow, hplast);
		mVector3.addElement(object_Effect_Skill);
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		EffectSkill eff = new EffectSkill(type, objkill, mVector3, 0);
		addEffect2Vector(eff);
	}

	public static void addEffectKill(int type, int idFrom, sbyte temFrom, int idTo, sbyte temTo, int hpshow, int hplast, sbyte sub)
	{
		mVector mVector3 = new mVector("GameScr vec");
		Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill((short)idTo, temTo);
		object_Effect_Skill.setHP(hpshow, hplast);
		mVector3.addElement(object_Effect_Skill);
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		EffectSkill eff = new EffectSkill(type, objkill, mVector3, sub);
		addEffect2Vector(eff);
	}

	public static void addEffectKill(int type, int idFrom, sbyte temFrom, mVector vec, sbyte sub)
	{
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		if (!EffectSkill.isMultiTarget(type))
		{
			EffectSkill eff = new EffectSkill(type, objkill, vec, sub);
			addEffect2Vector(eff);
			return;
		}
		for (int i = 0; i < vec.size(); i++)
		{
			mVector mVector3 = new mVector("GameScr vector");
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
			mVector3.addElement(object_Effect_Skill);
			EffectSkill eff2 = new EffectSkill(type, objkill, mVector3, sub);
			addEffect2Vector(eff2);
		}
	}

	public static void StartEffect_Chiemthanh(int type, int idFrom, sbyte temFrom, mVector vec, sbyte sub)
	{
		MainObject mainObject = MainObject.get_Object(idFrom, temFrom);
		if (mainObject.x <= 216)
		{
			for (int i = 0; i < 3; i++)
			{
				EffectSkill eff = new EffectSkill(mainObject.x, mainObject.y + 12, mainObject.x + posSkill[0][i], mainObject.y + posSkill[1][i], 0);
				EffectManager.addHiEffect(eff);
			}
		}
		else if (mainObject.x >= 384)
		{
			for (int j = 0; j < 3; j++)
			{
				EffectSkill eff2 = new EffectSkill(mainObject.x, mainObject.y + 12, mainObject.x + posSkill[0][j], mainObject.y + posSkill[1][j], 1);
				EffectManager.addHiEffect(eff2);
			}
		}
	}

	public static void addEffectKillSubTime(int type, int idFrom, sbyte temFrom, mVector vec, sbyte sub, int time)
	{
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		EffectSkill effectSkill = new EffectSkill(type, objkill, vec, sub);
		effectSkill.timeRemove = time;
		addEffect2Vector(effectSkill);
	}

	public static void addEffectKillSubTime(int type, int idFrom, sbyte temFrom, int idTo, sbyte temTo, int hpshow, int hplast, sbyte sub, int time)
	{
		mVector mVector3 = new mVector("GameScr vec2");
		Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill((short)idTo, temTo);
		object_Effect_Skill.setHP(hpshow, hplast);
		mVector3.addElement(object_Effect_Skill);
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		EffectSkill eff = new EffectSkill(type, objkill, mVector3, sub);
		addEffect2Vector(eff);
	}

	public static MainItemMap addEffectAuto(string key, string value)
	{
		return new EffectAuto(key, value);
	}

	public static void addEffectKillTime(int type, int idFrom, sbyte temFrom, mVector vec, int timeRemove, int subType)
	{
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		EffectSkill effectSkill = new EffectSkill(type, objkill, vec, subType);
		effectSkill.timeRemove = timeRemove;
		addEffect2Vector(effectSkill);
	}

	public static void addEffect2Vector(MainEffect eff)
	{
		if (eff.levelPaint != -1)
		{
			EffectManager.addHiEffect(eff);
		}
		else
		{
			EffectManager.addLowEffect(eff);
		}
	}

	public static void addEffectEndKill(int type, int x, int y)
	{
		EffectEnd eff = new EffectEnd(type, x, y);
		addEffect2Vector(eff);
	}

	public static void addEffectEndFromSv(int type, int id, int x, int y)
	{
		EffectEnd eff = new EffectEnd(type, id, x, y);
		addEffect2Vector(eff);
	}

	public static void addEffectEndKill_Direction(int type, int x, int y, int direction, sbyte levelPaint)
	{
		EffectEnd eff = new EffectEnd(type, x, y, direction, levelPaint);
		addEffect2Vector(eff);
	}

	public static void addEffectEndKill_Time(int type, int x, int y, long timeRemove)
	{
		EffectEnd eff = new EffectEnd(type, x, y, timeRemove);
		addEffect2Vector(eff);
	}

	public static void addEffectKill(int type, int x, int y, int time, short id, sbyte tem)
	{
		EffectSkill eff = new EffectSkill(type, x, y, time, id, tem);
		addEffect2Vector(eff);
	}

	public static void addEffectNew(int type, int x, int y, int time, short id, sbyte tem, short idFrom, sbyte temFrom, bool addLow)
	{
		EffectSkill effectSkill = new EffectSkill(type, x, y, time, id, tem);
		effectSkill.setObjFrom(idFrom, temFrom);
		if (addLow)
		{
			EffectManager.addLowEffect(effectSkill);
		}
		else
		{
			EffectManager.addHiEffect(effectSkill);
		}
	}

	public static void addEffectNum(string content, int x, int y, int typeColor, int idFrom)
	{
		if (!infoGame.isMapchienthanh() || idFrom == player.ID)
		{
			EffectNum obj = new EffectNum(content, x, y, typeColor);
			int num = find_Index_Stop(VecNum);
			if (num == VecNum.size())
			{
				VecNum.addElement(obj);
			}
			else
			{
				VecNum.setElementAt(obj, num);
			}
		}
	}

	public static void addEffectNum(string content, int x, int y, int typeColor)
	{
		EffectNum obj = new EffectNum(content, x, y, typeColor);
		int num = find_Index_Stop(VecNum);
		if (num == VecNum.size())
		{
			VecNum.addElement(obj);
		}
		else
		{
			VecNum.setElementAt(obj, num);
		}
	}

	public static void addEffectNum(string content, int x, int y, int typeColor, int sub, int idFrom)
	{
		if (!infoGame.isMapchienthanh() || idFrom == player.ID)
		{
			EffectNum obj = new EffectNum(content, x, y, typeColor, sub);
			int num = find_Index_Stop(VecNum);
			if (num == VecNum.size())
			{
				VecNum.addElement(obj);
			}
			else
			{
				VecNum.setElementAt(obj, num);
			}
		}
	}

	public static void addPlayer(MainObject obj)
	{
		Vecplayers.addElement(obj);
	}

	public short[] updateFindRoad(int xF, int yF, int xTo, int yTo, int maxSize)
	{
		if (MainObject.getDistance(xF * LoadMap.wTile, yF * LoadMap.wTile, xTo * LoadMap.wTile, yTo * LoadMap.wTile) <= LoadMap.wTile)
		{
			return null;
		}
		xStart = (sbyte)cmxMini;
		yStart = (sbyte)cmyMini;
		xF -= xStart;
		yF -= yStart;
		xTo -= xStart;
		yTo -= yStart;
		for (int i = 0; i < GameCanvas.loadmap.mapFind.Length; i++)
		{
			for (int j = 0; j < GameCanvas.loadmap.mapFind[i].Length; j++)
			{
				int num = (yStart + j) * GameCanvas.loadmap.mapW + (xStart + i);
				if (num < GameCanvas.loadmap.mapType.Length - 1)
				{
					if (GameCanvas.loadmap.mapType[num] == 1 || GameCanvas.loadmap.mapType[num] == -1)
					{
						GameCanvas.loadmap.mapFind[i][j] = -1;
					}
					else
					{
						GameCanvas.loadmap.mapFind[i][j] = 0;
					}
				}
			}
		}
		short num2 = 0;
		int num3 = xF;
		int num4 = yF;
		short num5 = (short)num3;
		short num6 = (short)num4;
		GameCanvas.loadmap.mapFind[num3][num4] = 1;
		num2 = 2;
		int num7 = GameCanvas.loadmap.mapFind.Length;
		int num8 = GameCanvas.loadmap.mapFind[0].Length;
		int num9 = 0;
		while (true)
		{
			num9++;
			if (num9 > 1000)
			{
				return new short[maxSize + 1];
			}
			int num10 = -1;
			int num11 = -1;
			if (num3 + 1 < num7 && GameCanvas.loadmap.mapFind[num3 + 1][num4] == 0)
			{
				GameCanvas.loadmap.mapFind[num3 + 1][num4] = (sbyte)num2;
				num10 = num3 + 1;
				num11 = num4;
			}
			if (num3 - 1 >= 0 && GameCanvas.loadmap.mapFind[num3 - 1][num4] == 0)
			{
				GameCanvas.loadmap.mapFind[num3 - 1][num4] = (sbyte)num2;
				if (num10 != -1)
				{
					if (CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num3 - 1, num4, xTo, yTo))
					{
						num10 = num3 - 1;
						num11 = num4;
					}
				}
				else
				{
					num10 = num3 - 1;
					num11 = num4;
				}
			}
			if (num4 + 1 < num8 && GameCanvas.loadmap.mapFind[num3][num4 + 1] == 0)
			{
				GameCanvas.loadmap.mapFind[num3][num4 + 1] = (sbyte)num2;
				if (num10 != -1)
				{
					if (CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num3, num4 + 1, xTo, yTo))
					{
						num10 = num3;
						num11 = num4 + 1;
					}
				}
				else
				{
					num10 = num3;
					num11 = num4 + 1;
				}
			}
			if (num4 - 1 >= 0 && GameCanvas.loadmap.mapFind[num3][num4 - 1] == 0)
			{
				GameCanvas.loadmap.mapFind[num3][num4 - 1] = (sbyte)num2;
				if (num10 != -1)
				{
					if (CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num3, num4 - 1, xTo, yTo))
					{
						num10 = num3;
						num11 = num4 - 1;
					}
				}
				else
				{
					num10 = num3;
					num11 = num4 - 1;
				}
			}
			int num12 = -1;
			if (num10 != -1)
			{
				num12 = 0;
				num3 = num10;
				num4 = num11;
			}
			else
			{
				num3 = (num4 = 1000);
			}
			for (short num13 = 0; num13 < num7; num13++)
			{
				for (short num14 = 0; num14 < num8; num14++)
				{
					if (GameCanvas.loadmap.mapFind[num13][num14] > 1 && setContinue(num13, num14, GameCanvas.loadmap.mapFind) && GameCanvas.loadmap.mapFind[num13][num14] + CRes.setDis(num13, num14, xTo, yTo) < num2 + CRes.setDis(num3, num4, xTo, yTo))
					{
						num3 = num13;
						num4 = num14;
						num2 = GameCanvas.loadmap.mapFind[num13][num14];
						num12 = 0;
					}
				}
			}
			if (num3 == xTo && num4 == yTo)
			{
				break;
			}
			if (num12 == 0)
			{
				num2++;
				if (num2 > maxSize)
				{
					return new short[num2];
				}
				continue;
			}
			return new short[maxSize + 1];
		}
		if (num2 >= 127)
		{
			return new short[maxSize + 1];
		}
		int num15 = 0;
		short[] array = new short[num2];
		while (true)
		{
			array[num15] = (short)((num3 << 8) + num4);
			if (num3 + 1 < num7 && GameCanvas.loadmap.mapFind[num3 + 1][num4] == GameCanvas.loadmap.mapFind[num3][num4] - 1)
			{
				num3++;
			}
			else if (num3 - 1 >= 0 && GameCanvas.loadmap.mapFind[num3 - 1][num4] == GameCanvas.loadmap.mapFind[num3][num4] - 1)
			{
				num3--;
			}
			else if (num4 + 1 < num8 && GameCanvas.loadmap.mapFind[num3][num4 + 1] == GameCanvas.loadmap.mapFind[num3][num4] - 1)
			{
				num4++;
			}
			else if (num4 - 1 >= 0 && GameCanvas.loadmap.mapFind[num3][num4 - 1] == GameCanvas.loadmap.mapFind[num3][num4] - 1)
			{
				num4--;
			}
			if (num3 == num5 && num4 == num6)
			{
				break;
			}
			num15++;
		}
		array[num2 - 1] = (short)((xF << 8) + yF);
		return array;
	}

	private bool setContinue(int i, int j, sbyte[][] mapFind)
	{
		if (i + 1 < mapFind.Length && mapFind[i + 1][j] == 0)
		{
			return true;
		}
		if (i - 1 >= 0 && mapFind[i - 1][j] == 0)
		{
			return true;
		}
		if (j + 1 < mapFind[i].Length && mapFind[i][j + 1] == 0)
		{
			return true;
		}
		if (j - 1 >= 0 && mapFind[i][j - 1] == 0)
		{
			return true;
		}
		return false;
	}

	public static int find_Index_Stop(mVector vec)
	{
		int result = vec.size();
		for (int i = 0; i < vec.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)vec.elementAt(i);
			if (mainEffect.isStop && !mainEffect.isRemove)
			{
				return i;
			}
		}
		return result;
	}

	public static void Remove_ChangeMap()
	{
		LoadMap.mItemMap.removeAllElements();
		vecDataeff.removeAllElements();
		vecStep.removeAllElements();
	}

	public static void Remove_ChangeArea()
	{
	}

	public static void RemoveLoadMap()
	{
		for (int i = 0; i < Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)Vecplayers.elementAt(i);
			if (mainObject != player && mainObject != pet)
			{
				mainObject.isRemove = true;
				mainObject.isBinded = false;
				mainObject.isDongBang = false;
				mainObject.isSleep = false;
				mainObject.isStun = false;
				mainObject.isMoveOut = false;
				mainObject.isno = false;
				mainObject.isnoBoss84 = false;
			}
		}
		vecDataeff.removeAllElements();
		VecNum.removeAllElements();
		vecStep.removeAllElements();
		EffectManager.hiEffects.reMoveAll();
		EffectManager.lowEffects.reMoveAll();
		player.effAuto = null;
		MiniMap.vecNPC_Map.removeAllElements();
		vecHightEffAuto.removeAllElements();
		player.isBinded = false;
		player.isSleep = false;
		player.isStun = false;
		player.isDongBang = false;
		player.isMoveOut = false;
		player.isno = false;
		player.isnoBoss84 = false;
		ItemMap.isPaintDieHouseArena = false;
	}

	public static bool isWater(int x, int y)
	{
		return GameCanvas.loadmap.getTile(x, y) == 2;
	}

	public static void AddEffWeather(sbyte type, bool isSt, int num, int time)
	{
		AnimateEffect animateEffect = new AnimateEffect(type, isSt, num, time);
		vecWeather.addElement(animateEffect);
	}

	public static bool setIsInScreen(int x, int y)
	{
		if (x < MainScreen.cameraMain.xCam || x > MainScreen.cameraMain.xCam + GameCanvas.w || y < MainScreen.cameraMain.yCam || y > MainScreen.cameraMain.yCam + GameCanvas.h)
		{
			return false;
		}
		return true;
	}

	public static void addSoundEff(int id)
	{
		if (demNumSoundEff <= 3)
		{
			mSound.playSound(id, mSound.volumeSound);
			demNumSoundEff++;
		}
	}

	public static void addEffInMap(int x, int y, int type, int Dir)
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		switch (type)
		{
		case 0:
			if (player.typeMount == -1 && GameCanvas.gameTick % 4 == 0)
			{
				mSound.playSound(46, mSound.volumeSound);
			}
			break;
		case 1:
			if (GameCanvas.gameTick % 4 == 0)
			{
				mSound.playSound(51, mSound.volumeSound);
			}
			break;
		}
		if (LoadMap.idTile == 3 || LoadMap.idTile == 8)
		{
			Point point = new Point();
			point.x = x;
			point.y = y;
			point.color = type;
			point.fRe = 40;
			if (point.color == 0)
			{
				point.fRe = CRes.random(28, 43);
				point.maxframe = 1;
				point.isSmall = true;
				point.fSmall = CRes.random(point.fRe / 2 - 5, point.fRe / 2 + 6);
			}
			else if (point.color == 1)
			{
				return;
			}
			switch (Dir)
			{
			case 1:
				point.dis = 0;
				break;
			case 0:
				point.dis = 3;
				break;
			case 2:
				point.dis = 6;
				break;
			case 3:
				point.dis = 5;
				break;
			}
			if (point.color == 0)
			{
				vecStep.addElement(point);
			}
			else
			{
				vecEffInMap.addElement(point);
			}
		}
	}

	public static void checkAddEff(int type, int x, int y, int time, short id, sbyte tem, short idFrom, sbyte temFrom, bool addLow)
	{
		if (addLow)
		{
			for (int i = 0; i < EffectManager.lowEffects.size(); i++)
			{
				MainEffect mainEffect = (MainEffect)EffectManager.lowEffects.elementAt(i);
				if (mainEffect != null && !mainEffect.isRemove && mainEffect.typeEffect == type && mainEffect.objBeKillMain != null && mainEffect.objBeKillMain.ID == id)
				{
					mainEffect.setTimeRemove((short)time);
					mainEffect.objBeKillMain.vx = 0;
					mainEffect.objBeKillMain.vy = 0;
					mainEffect.objBeKillMain.toX = x;
					mainEffect.objBeKillMain.toY = y;
					switch (type)
					{
					case 101:
						mainEffect.objBeKillMain.isSleep = true;
						break;
					case 102:
						mainEffect.objBeKillMain.isStun = true;
						break;
					case 107:
						mainEffect.objBeKillMain.isno = true;
						break;
					case 103:
						mainEffect.objBeKillMain.isnoBoss84 = true;
						break;
					case 100:
						mainEffect.objBeKillMain.isDongBang = true;
						break;
					default:
						mainEffect.objBeKillMain.isBinded = true;
						break;
					}
					return;
				}
			}
			addEffectNew(type, x, y, time, id, tem, idFrom, 1, (type != 100) ? true : false);
			return;
		}
		for (int j = 0; j < EffectManager.hiEffects.size(); j++)
		{
			MainEffect mainEffect2 = (MainEffect)EffectManager.hiEffects.elementAt(j);
			if (mainEffect2 != null && !mainEffect2.isRemove && mainEffect2.typeEffect == type && mainEffect2.objBeKillMain != null && mainEffect2.objBeKillMain.ID == id)
			{
				mainEffect2.setTimeRemove((short)time);
				mainEffect2.objBeKillMain.vx = 0;
				mainEffect2.objBeKillMain.vy = 0;
				mainEffect2.objBeKillMain.toX = x;
				mainEffect2.objBeKillMain.toY = y;
				switch (type)
				{
				case 101:
					mainEffect2.objBeKillMain.isSleep = true;
					break;
				case 102:
					mainEffect2.objBeKillMain.isStun = true;
					break;
				case 107:
					mainEffect2.objBeKillMain.isno = true;
					break;
				case 103:
					mainEffect2.objBeKillMain.isnoBoss84 = true;
					break;
				default:
					mainEffect2.objBeKillMain.isBinded = true;
					break;
				}
				return;
			}
		}
		addEffectNew(type, x, y, time, id, tem, idFrom, 1, false);
	}

	public static MainObject findOwner(MainObject owner)
	{
		for (int i = 0; i < Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)Vecplayers.elementAt(i);
			if (mainObject != null && mainObject.findOwner(owner))
			{
				return mainObject;
			}
		}
		return null;
	}

	public static MainObject findChar(short id)
	{
		for (int i = 0; i < Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)Vecplayers.elementAt(i);
			if (mainObject != null && mainObject.typeObject == 0 && mainObject.ID == id)
			{
				return mainObject;
			}
		}
		return null;
	}

	public static MainObject findObj(short id)
	{
		for (int i = 0; i < Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)Vecplayers.elementAt(i);
			if (mainObject != null && mainObject.ID == id)
			{
				return mainObject;
			}
		}
		return null;
	}

	public static void startNewMagicBeam(int type, MainObject from, MainObject to, int x, int y, int power, short effect, int effTail, int effEnd)
	{
		MagicBeam magicBeam = new MagicBeam();
		magicBeam.set(type, x, y, power, effect, from, to);
		magicBeam.setEff(effTail, effEnd);
		arrowsUp.addElement(magicBeam);
	}

	public static void startNewArrow(int type, MainObject from, MainObject to, int x, int y, int power, sbyte effect, int imgIndex)
	{
		Arrow arrow = new Arrow(imgIndex);
		arrow.set(type, x, y, power, effect, from, to);
		arrowsUp.addElement(arrow);
	}

	public static MainObject findMonster(short id)
	{
		for (int i = 0; i < Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)Vecplayers.elementAt(i);
			if (mainObject != null && mainObject.typeObject == 1 && mainObject.ID == id)
			{
				return mainObject;
			}
		}
		return null;
	}

	public static MainObject findObjByteCat(short id, sbyte cat)
	{
		for (int i = 0; i < Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)Vecplayers.elementAt(i);
			if (mainObject != null && mainObject.typeObject == cat && mainObject.ID == id)
			{
				return mainObject;
			}
		}
		return null;
	}

	public override bool isGameScr()
	{
		return true;
	}
}
