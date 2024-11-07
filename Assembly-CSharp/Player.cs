using System;

public class Player : MainObject
{
	public static iCommand cmdNextFocus;

	public static iCommand cmdRevice;

	public static iCommand cmdVeLang;

	public static int levelTab = 0;

	public static int PointSucKhoe = 0;

	public static int MaxSkill = 21;

	public static int timeX2 = 0;

	public static int timeResetAuto = 0;

	public static int PointArena = 0;

	public static long timeSetX2;

	public static bool isNewPlayer = false;

	public static bool isAutoHPMP = false;

	public static bool isLockKey = false;

	public static bool isSendMove = true;

	public static bool isPhong = false;

	public static sbyte isAutoFire = 1;

	public static sbyte isAutoBuff = 0;

	public static AutoGetItem autoItem;

	public static bool isFullInven = false;

	public static long timeFristSkill;

	public static DelaySkill[] timeDelaySkill = new DelaySkill[MaxSkill];

	public static DelaySkill[] timeDelayPotion = new DelaySkill[3];

	public static int diemTiemNang = 0;

	public static int diemKyNang = 0;

	public static int[][] mTiemnang = mSystem.new_M_Int(2, 4);

	public static HotKey[][] mhotkey = new HotKey[3][];

	public static short maxInven = 42;

	public static short maxChest = 20;

	public static short maxPet = 24;

	public static sbyte typeX2 = 0;

	public sbyte timeHit;

	public int timeCombo;

	public long timeSendmove;

	public bool ispaintHit;

	public bool isMaxdame;

	public static sbyte[] ID_HAIR_NO_HAT;

	private PopupChat nameStore;

	public int lastX = 1000000;

	public int lastY = 1000000;

	public static int[] mKillPlayer = new int[MaxSkill];

	public static int[] mCurentLvSkill = new int[MaxSkill];

	public static int[] mPlusLvSkill = new int[MaxSkill];

	public string[] mKhangChar = new string[5];

	public MainInfoItem[] mInfoChar;

	public MainQuest currentQuest;

	public static MainParty party;

	public static int xFocus = -1;

	public static int yFocus = -1;

	public static int timeFocus = 0;

	public new static int skillDefault = 0;

	public static int xBeginAutoFire = -1;

	public static int yBeginAutofire = -1;

	public static short[] vecPlayerPk = new short[0];

	public TabSkillsNew tabskills;

	private int coutauto;

	public static sbyte IndexFire = 0;

	private long timeAutoBuff;

	public static short demUnFire = 0;

	private int xtam;

	private int ytam;

	private int counttam;

	private int skilltam;

	public static int testloadmap = 0;

	public new static int timeStand = 0;

	public static int timeQuest;

	public static sbyte typeFocusLast = -1;

	public static sbyte timeFocusLast = 0;

	private int indexFocus;

	public static bool isFocusNPC = false;

	public static int timeFocusNPC = 0;

	public static bool isCurAutoFire = false;

	public Player()
	{
	}

	public Player(int ID, sbyte type, string name, int x, int y)
		: base(ID, type, name, x, y)
	{
		ischar = true;
		party = null;
		typeObject = 0;
		hOne = 40;
		wOne = 30;
		vMax = 6;
		base.name = name;
		wFocus = 140;
		cmdNextFocus = new iCommand(T.next, 0, this);
		cmdRevice = new iCommand(T.hoisinh, 1, this);
		cmdRevice.setPos(iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdRevice.caption);
		cmdVeLang = new iCommand(T.velang, 2, this);
		cmdVeLang.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdVeLang.caption);
		PlashNow = new SplashSkill();
		ListKillNow = new ListSkill();
		isNewPlayer = false;
		xsai = 1;
		ysai = 2;
		for (int i = 0; i < timeDelaySkill.Length; i++)
		{
			timeDelaySkill[i] = new DelaySkill();
			timeDelaySkill[i].value = 0;
			timeDelaySkill[i].timebegin = mSystem.currentTimeMillis();
		}
		for (int j = 0; j < timeDelayPotion.Length; j++)
		{
			timeDelayPotion[j] = new DelaySkill();
			timeDelayPotion[j].value = 0;
			timeDelayPotion[j].timebegin = mSystem.currentTimeMillis();
		}
		timeSendmove = mSystem.currentTimeMillis();
		timeCombo = -1;
	}

	public override bool isMainChar()
	{
		return true;
	}

	public void doResetLastXY()
	{
		lastX = 1000000;
		lastY = 1000000;
	}

	public static void init0()
	{
		for (int i = 0; i < mhotkey.Length; i++)
		{
			mhotkey[i] = new HotKey[5];
		}
	}

	public new void init()
	{
		TabShopNew o = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.tabhanhtrang, -1, TabShopNew.NORMAL);
		mVector mVector3 = new mVector("Player (init) v");
		mVector3.addElement(o);
		TabMySeftNew o2 = new TabMySeftNew(T.tabtrangbi);
		mVector3.addElement(o2);
		TabInfoChar o3 = new TabInfoChar(T.tabthongtin);
		mVector3.addElement(o3);
		tabskills = new TabSkillsNew(T.tabkynang);
		mVector3.addElement(tabskills);
		TabQuest o4 = new TabQuest(T.tabnhiemvu);
		mVector3.addElement(o4);
		mVector vec = new mVector("Player mcmdTest");
		if (GameCanvas.isTouch)
		{
			TabConfig o5 = new TabConfig(T.tabchucnang, vec, MainTabNew.FUNCTION);
			mVector3.addElement(o5);
		}
		else
		{
			TabConfig o6 = new TabConfig(T.tabhethong, vec, MainTabNew.CONFIG);
			mVector3.addElement(o6);
			TabConfig o7 = new TabConfig(T.tabchucnang, vec, MainTabNew.FUNCTION);
			mVector3.addElement(o7);
		}
		GameCanvas.AllInfo.addMoreTab(mVector3);
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			nextFocus();
			break;
		case 1:
			GlobalService.gI().gohome(1);
			GameCanvas.start_Ok_Dialog(T.pleaseWait);
			break;
		case 2:
			GameCanvas.start_Left_Dialog(T.muonvelang, new iCommand(cmdVeLang.caption, 3, this));
			break;
		case 3:
			GlobalService.gI().gohome(0);
			GameCanvas.end_Dialog();
			break;
		case 4:
			GlobalService.gI().do_Buy_Sell_Item(4, null, string.Empty, 0, 0, 0);
			break;
		case 5:
			GameCanvas.end_Dialog();
			break;
		}
	}

	public override void setPainthit(sbyte time, bool isMax)
	{
		timeHit = time;
		isMaxdame = isMax;
	}

	public override void paint(mGraphics g)
	{
		paintPlayer(g, 100);
		paintEffectCharWearing(g);
		paintNameStore(g, x, y);
	}

	public override void paintNameStore(mGraphics g, int x, int y)
	{
		if (nameStore != null && !nameStore.name.Equals(string.Empty))
		{
			nameStore.paint(g);
		}
	}

	public override void paintBigAvatar(mGraphics g, int x, int y)
	{
	}

	public override void update()
	{
		try
		{
			if (moveToBoss && vx == 0 && vy == 0)
			{
				moveToBoss = false;
			}
			if (moveToBoss)
			{
				if (vx != 0)
				{
					vx = 0;
				}
				if (vy != 0)
				{
					vy = 0;
				}
				frameLeg = CRes.random(0, 4);
			}
			updateActionPerson();
			if (currentQuest == null)
			{
				setFocus();
			}
			setMove(true);
			updatePlayer();
			updateEye();
			updateDataEffect();
			if (party != null && party.update())
			{
				party = null;
			}
			updateDelaySkill();
			if (timeResetAuto > 0)
			{
				timeResetAuto--;
			}
			if ((vx != 0 || vy != 0) && !isTanHinh && GameCanvas.gameTick % 3 == 0)
			{
				if (!isWater && !isFootSnow)
				{
					if (Direction == 2)
					{
						GameScreen.addEffInMap(x + CRes.random_Am(0, 3), y + CRes.random_Am(0, 3) + mSystem.dyCharStep, 0, Direction);
					}
					else if (Direction == 3)
					{
						GameScreen.addEffInMap(x + CRes.random_Am(0, 3), y + CRes.random_Am(0, 3) - mSystem.dyCharStep, 0, Direction);
					}
					else
					{
						GameScreen.addEffInMap(x + CRes.random_Am(0, 3), y + CRes.random_Am(0, 3), 0, Direction);
					}
				}
				else
				{
					GameScreen.addEffInMap(x, y, 1, Direction);
				}
			}
			updateoverHP_MP();
			updateEffectCharWearing();
			if (nameStore != null)
			{
				nameStore.updatePos(x, y - hOne - 30);
			}
			base.update();
			if (timeHit > 0)
			{
				ispaintHit = true;
				timeHit--;
			}
			else
			{
				ispaintHit = false;
			}
		}
		catch (Exception ex)
		{
			mSystem.println("----loi update player:" + ex.ToString());
		}
	}

	private void updatePlayer()
	{
		if (KillFire != -1)
		{
			if (CRes.abs(x - xFire) <= 4 && CRes.abs(y - yFire) <= 4)
			{
				timeHuyKill++;
				posTransRoad = null;
				ListKillNow.setFireSkill(this, vecObjFocusSkill, KillFire, -1);
				if (timeHuyKill > 5)
				{
					ListKillNow.fireSkillFree();
					timeHuyKill = 0;
					KillFire = -1;
				}
			}
			if (posTransRoad == null && (CRes.abs(x - xFire) > 4 || CRes.abs(y - yFire) > 4))
			{
				Move_to_Focus_Person();
			}
		}
		else
		{
			timeHuyKill = 0;
		}
		if (hp <= 0 && Action != 4)
		{
			resetAction();
			Action = 4;
			if (LoadMap.typeMap == LoadMap.MAP_THACH_DAU)
			{
				GameScreen.gI().center = cmdVeLang;
				cmdVeLang.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdVeLang.caption);
			}
			else if (LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
			{
				GameScreen.gI().center = cmdRevice;
				cmdRevice.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdRevice.caption);
			}
			else if (!GameScreen.infoGame.isMapThachdau())
			{
				GameScreen.gI().left = cmdRevice;
				GameScreen.gI().right = cmdVeLang;
				cmdRevice.setPos(iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdRevice.caption);
				cmdVeLang.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdVeLang.caption);
			}
			GameScreen.addEffectEndKill(11, x, y);
		}
		if (currentQuest == null)
		{
			if (Action == 4 && !GameScreen.infoGame.isMapThachdau())
			{
				if (LoadMap.typeMap == LoadMap.MAP_THACH_DAU)
				{
					if (GameScreen.gI().center != cmdVeLang)
					{
						GameScreen.gI().center = cmdVeLang;
						cmdVeLang.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdVeLang.caption);
					}
				}
				else if (LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
				{
					if (GameScreen.gI().center != cmdRevice)
					{
						GameScreen.gI().center = cmdRevice;
						cmdRevice.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdRevice.caption);
					}
				}
				else
				{
					if (GameScreen.gI().left != cmdRevice)
					{
						GameScreen.gI().left = cmdRevice;
						cmdRevice.setPos(iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdRevice.caption);
					}
					if (GameScreen.gI().right != cmdVeLang)
					{
						GameScreen.gI().right = cmdVeLang;
						cmdVeLang.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdVeLang.caption);
					}
				}
			}
			else if (GameCanvas.isTouch)
			{
				if (LoadMap.typeMap == LoadMap.MAP_THACH_DAU)
				{
					if (GameScreen.gI().center == cmdVeLang)
					{
						GameScreen.gI().center = null;
					}
				}
				else if (LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
				{
					if (GameScreen.gI().center == cmdRevice)
					{
						GameScreen.gI().center = null;
					}
				}
				else
				{
					if (GameScreen.gI().left == cmdRevice)
					{
						GameScreen.gI().left = null;
					}
					if (GameScreen.gI().right == cmdVeLang)
					{
						GameScreen.gI().right = null;
					}
				}
			}
			else
			{
				if (center == cmdRevice)
				{
					center = null;
				}
				if (GameScreen.gI().right == null || GameScreen.gI().right != cmdNextFocus)
				{
					GameScreen.gI().right = cmdNextFocus;
				}
				if (GameScreen.gI().left != GameScreen.gI().cmdMenu)
				{
					GameScreen.gI().left = GameScreen.gI().cmdMenu;
				}
			}
		}
		if (posTransRoad != null && !moveToBoss)
		{
			if (isBinded)
			{
				return;
			}
			if (CRes.abs(x - toX) <= 6 && CRes.abs(y - toY) <= 6)
			{
				if (countAutoMove > posTransRoad.Length - 1)
				{
					countAutoMove = 0;
					posTransRoad = null;
					timeStand = 0;
					xStopMove = 0;
					yStopMove = 0;
				}
				else
				{
					if (countAutoMove == posTransRoad.Length - 1 && xStopMove > 0 && yStopMove > 0)
					{
						toX = xStopMove;
						toY = yStopMove;
					}
					else
					{
						sbyte b = (sbyte)(posTransRoad[countAutoMove] >> 8);
						sbyte b2 = (sbyte)(posTransRoad[countAutoMove] & 0xFF);
						toX = b * LoadMap.wTile + LoadMap.wTile / 2;
						toY = b2 * LoadMap.wTile + LoadMap.wTile / 2;
					}
					countAutoMove++;
				}
			}
			move_to_XY();
		}
		else
		{
			if (!isSendMove)
			{
				isSendMove = true;
				xStand = x;
				yStand = y;
			}
			if (isLockKey && !GameScreen.help.setStep_Next(0, -4) && !GameScreen.help.setStep_Next(0, -2))
			{
				isLockKey = false;
			}
		}
		int distance = MainObject.getDistance(xStand, yStand, x, y);
		bool flag = false;
		if (mSystem.currentTimeMillis() - timeSendmove > 250 && timeStand <= 0)
		{
			flag = true;
		}
		if (posTransRoad != null && mSystem.currentTimeMillis() - timeSendmove > 250)
		{
			flag = true;
		}
		if (flag || (timeStand > 20 && distance >= 5 && posTransRoad == null))
		{
			if (isSendMove && !isMoveOut)
			{
				GlobalService.gI().player_move((short)x, (short)y);
				timeSendmove = mSystem.currentTimeMillis();
			}
			xStand = x;
			yStand = y;
			countSendMove = 0;
		}
		if (autoItem != null && GameCanvas.gameTick % 5 == 0)
		{
			autoGetItem();
		}
		if (isAutoFire == 1 && posTransRoad == null)
		{
			if (PointSucKhoe <= 0)
			{
				isAutoFire = 0;
			}
			if (isAutoFire == 1)
			{
				if (Action == 0)
				{
					coutauto++;
				}
				else
				{
					coutauto = 0;
				}
				if (coutauto > 500)
				{
					GameCanvas.addInfoChar(T.farfocus);
					KillFire = -1;
					IDAttack = -1;
					vecObjFocusSkill = null;
					coutauto = 0;
					dofire();
				}
			}
			if (Action != 2 && Action != 4 && (MainObject.getDistance(x, y, xBeginAutoFire, yBeginAutofire) > wFocus * 3 / 2 || demUnFire > 100))
			{
				toX = x;
				toY = y;
				xStopMove = xBeginAutoFire;
				yStopMove = yBeginAutofire;
				posTransRoad = GameCanvas.game.updateFindRoad(xStopMove / LoadMap.wTile, yStopMove / LoadMap.wTile, x / LoadMap.wTile, y / LoadMap.wTile, 20);
				xFocus = -1;
				yFocus = -1;
				if (posTransRoad != null && posTransRoad.Length > 20)
				{
					posTransRoad = null;
				}
			}
			if (posTransRoad == null && Action != 2 && Action != 4)
			{
				setAutoFire();
			}
			if (Action == 4)
			{
				setCurAutoFire();
			}
		}
		if (isAutoHPMP && Action != 4 && GameCanvas.gameTick % 5 == 0)
		{
			if (hp * 100 / maxHp < MsgDialog.mHPMP[0])
			{
				HotKey hotKey = mhotkey[levelTab][4];
				if (hotKey != null && hotKey.type == HotKey.POTION && hotKey.typePotion == 0)
				{
					Item itemInventory = Item.getItemInventory(4, hotKey.id);
					if (itemInventory != null && itemInventory.typePotion < 2 && timeDelayPotion[itemInventory.typePotion].value <= 0)
					{
						GlobalService.gI().Use_Potion((short)itemInventory.Id);
						timeDelayPotion[itemInventory.typePotion].value = 2000;
						timeDelayPotion[itemInventory.typePotion].limit = 2000;
						timeDelayPotion[itemInventory.typePotion].timebegin = mSystem.currentTimeMillis();
					}
				}
			}
			if (mp * 100 / maxMp < MsgDialog.mHPMP[1])
			{
				HotKey hotKey2 = mhotkey[levelTab][3];
				if (hotKey2.type == HotKey.POTION && hotKey2.typePotion == 1)
				{
					Item itemInventory2 = Item.getItemInventory(4, hotKey2.id);
					if (itemInventory2 != null && timeDelayPotion[itemInventory2.typePotion].value <= 0)
					{
						GlobalService.gI().Use_Potion((short)itemInventory2.Id);
						timeDelayPotion[itemInventory2.typePotion].value = 2000;
						timeDelayPotion[itemInventory2.typePotion].limit = 2000;
						timeDelayPotion[itemInventory2.typePotion].timebegin = mSystem.currentTimeMillis();
					}
				}
			}
		}
		if (GameScreen.ObjFocus != null)
		{
			typeFocusLast = GameScreen.ObjFocus.typeObject;
			timeFocusLast = 0;
		}
		else if (timeFocusLast < 20)
		{
			timeFocusLast++;
		}
		if ((vx != 0 || vy != 0) && timeFocusNPC < 5)
		{
			timeFocusNPC = 10;
		}
		if (!isFocusNPC && timeFocusNPC > 5)
		{
			timeFocusNPC++;
			if (timeFocusNPC > 60)
			{
				isFocusNPC = true;
				timeFocusNPC = 0;
			}
		}
		if (isAutoFire == 1 && GameScreen.ObjFocus != null && MainObject.getDistance(xBeginAutoFire, yBeginAutofire, GameScreen.ObjFocus.x, GameScreen.ObjFocus.y) > 240)
		{
			nextMonster();
		}
	}

	private void autoGetItem()
	{
		if (GameCanvas.gameTick % 200 == 0)
		{
			int num = Item.VecInvetoryPlayer.size();
			if (isFullInven)
			{
				if (num < maxInven)
				{
					isFullInven = false;
				}
				else
				{
					GameCanvas.addInfoChar(T.fullInven);
					if (GameScreen.ObjFocus.typeObject == 4 || GameScreen.ObjFocus.typeObject == 3 || GameScreen.ObjFocus.typeObject == 5 || GameScreen.ObjFocus.typeObject == 7 || GameScreen.ObjFocus.typeObject == 3)
					{
						nextFocus();
					}
				}
			}
			else if (num >= maxInven)
			{
				isFullInven = true;
			}
		}
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && !mainObject.isSend && (mainObject.typeObject == 4 || mainObject.typeObject == 3 || mainObject.typeObject == 5 || mainObject.typeObject == 7))
			{
				if (setGetItem(mainObject) && MainObject.getDistance(x, y, mainObject.x, mainObject.y) < wFocus)
				{
					GlobalService.gI().Get_Item_Map((short)mainObject.ID, mainObject.typeObject);
				}
				mainObject.isSend = true;
			}
		}
	}

	public bool isItem(MainObject obj)
	{
		return obj.typeObject == 4 || obj.typeObject == 3 || obj.typeObject == 5 || obj.typeObject == 7;
	}

	private bool setGetItem(MainObject obj)
	{
		switch (obj.typeObject)
		{
		case 3:
			if (isFullInven)
			{
				return false;
			}
			if (autoItem.valueColorItem == -1)
			{
				return false;
			}
			if (obj.colorName >= autoItem.valueColorItem)
			{
				return true;
			}
			break;
		case 4:
			if (obj.colorName == 0)
			{
				if (autoItem.isGetPotion == AutoGetItem.POI_NHAT_MAU || autoItem.isGetPotion == AutoGetItem.POI_NHAT_HET)
				{
					return true;
				}
				break;
			}
			if (obj.colorName == 1)
			{
				if (autoItem.isGetPotion != AutoGetItem.POI_NHAT_NANG_LUONG && autoItem.isGetPotion != AutoGetItem.POI_NHAT_HET)
				{
					break;
				}
				return true;
			}
			if (obj.colorName == 2)
			{
				return true;
			}
			if (obj.colorName == 6)
			{
				return true;
			}
			return true;
		case 5:
		case 7:
			return true;
		}
		return false;
	}

	public void setAutoFire()
	{
		if (!ListSkill.canAttack())
		{
			return;
		}
		long num = mSystem.currentTimeMillis();
		MainObject objFocus = GameScreen.ObjFocus;
		if (objFocus == null || objFocus.Action == 4 || objFocus.typeObject != 1 || objFocus.isSend || objFocus.isDie)
		{
			if (objFocus != null && objFocus.isDie)
			{
				GameScreen.ObjFocus = null;
			}
			nextMonster();
		}
		if (GameScreen.ObjFocus == null || GameScreen.ObjFocus.typeObject != 1 || GameScreen.ObjFocus.typeBoss == 2)
		{
			return;
		}
		if (isAutoBuff == 1 && (num - timeAutoBuff) / ListSkill.limitTimeAtt > 2)
		{
			timeAutoBuff = num;
			for (int i = 0; i < MsgDialog.MaxSkillBuff; i++)
			{
				if (MsgDialog.Autobuff[i][1] != 0 && setDelaySkill(MsgDialog.Autobuff[i][0], -1))
				{
					Skill skillFormId = MainListSkill.getSkillFormId(MsgDialog.Autobuff[i][0]);
					if (skillFormId.typeSkill == 1)
					{
						setAutoBuff(skillFormId.typeBuff, MsgDialog.Autobuff[i][0], GameScreen.ObjFocus);
					}
				}
			}
		}
		if (IndexFire < mhotkey[0].Length - 1)
		{
			for (int j = IndexFire + 1; j < mhotkey[0].Length; j++)
			{
				HotKey hotKey = mhotkey[levelTab][j];
				if (hotKey.type == HotKey.SKILL && setDelaySkill(hotKey.id, -1))
				{
					setActionHotKey(j, false);
					timeFristSkill = num;
					IndexFire = (sbyte)j;
					return;
				}
			}
		}
		if (IndexFire > 0)
		{
			for (int k = 0; k <= IndexFire; k++)
			{
				HotKey hotKey2 = mhotkey[levelTab][k];
				if (hotKey2.type == HotKey.SKILL && setDelaySkill(hotKey2.id, -1))
				{
					setActionHotKey(k, false);
					timeFristSkill = num;
					IndexFire = (sbyte)k;
					return;
				}
			}
		}
		if (setDelaySkill(0, -1))
		{
			setActionHotKey(-1, false);
			timeFristSkill = num;
		}
	}

	public void nextMonster()
	{
		if (!isCurAutoFire)
		{
			isAutoFire = -1;
			return;
		}
		int num = wFocus * 3 / 2;
		MainObject mainObject = null;
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject2 == null || mainObject2.Action == 4 || mainObject2.isSend || mainObject2.typeObject != 1 || mainObject2.isLuaThieng())
			{
				continue;
			}
			int distance = MainObject.getDistance(x, y, mainObject2.x, mainObject2.y);
			if (distance < num || mainObject2.typeBoss == 2)
			{
				num = distance;
				mainObject = mainObject2;
				if (mainObject2.typeBoss == 2)
				{
					break;
				}
			}
		}
		if (mainObject != null)
		{
			PaintInfoGameScreen.isPaintInfoFocus = true;
			GameScreen.ObjFocus = mainObject;
			demUnFire = 0;
		}
		else
		{
			PaintInfoGameScreen.isPaintInfoFocus = false;
			demUnFire++;
		}
	}

	public void movePC()
	{
		if (GameCanvas.keyMove(39))
		{
			if (!isSelling())
			{
				Action = 1;
				Direction = 2;
				vx = -(vMax + getVmount());
				vy = 0;
				resetMove();
				setValueAuto(0);
			}
			else
			{
				mVector mVector3 = new mVector();
				mVector3.addElement(new iCommand(T.yes, 4, this));
				mVector3.addElement(new iCommand(T.cancel, 5, this));
				GameCanvas.start_Select_Dialog(T.can_not_move, mVector3);
			}
		}
		else if (GameCanvas.keyMove(40))
		{
			if (!isSelling())
			{
				Action = 1;
				Direction = 3;
				vx = vMax + getVmount();
				vy = 0;
				resetMove();
				setValueAuto(0);
			}
			else
			{
				mVector mVector4 = new mVector();
				mVector4.addElement(new iCommand(T.yes, 4, this));
				mVector4.addElement(new iCommand(T.cancel, 5, this));
				GameCanvas.start_Select_Dialog(T.can_not_move, mVector4);
			}
		}
		else if (GameCanvas.keyMove(30))
		{
			if (!isSelling())
			{
				Action = 1;
				Direction = 1;
				vy = -(vMax + getVmount());
				vx = 0;
				resetMove();
				setValueAuto(0);
			}
			else
			{
				mVector mVector5 = new mVector();
				mVector5.addElement(new iCommand(T.yes, 4, this));
				mVector5.addElement(new iCommand(T.cancel, 5, this));
				GameCanvas.start_Select_Dialog(T.can_not_move, mVector5);
			}
		}
		else if (GameCanvas.keyMove(38))
		{
			if (!isSelling())
			{
				Action = 1;
				Direction = 0;
				vy = vMax + getVmount();
				vx = 0;
				resetMove();
				setValueAuto(0);
			}
			else
			{
				mVector mVector6 = new mVector();
				mVector6.addElement(new iCommand(T.yes, 4, this));
				mVector6.addElement(new iCommand(T.cancel, 5, this));
				GameCanvas.start_Select_Dialog(T.can_not_move, mVector6);
			}
		}
	}

	public void updateKey()
	{
		if (!Canmove() || LoadMap.isShowEffAuto == LoadMap.EFF_PHOBANG_END || isLockKey)
		{
			return;
		}
		if (currentQuest != null)
		{
			if (!GameCanvas.menu2.isShowMenu)
			{
				timeQuest++;
				if (timeQuest > 100)
				{
					currentQuest = null;
					GameScreen.gI().center = null;
					GameCanvas.clearKeyHold();
					GameCanvas.isPointerSelect = false;
				}
			}
			else
			{
				timeQuest = 0;
			}
		}
		else
		{
			if (Action != 4 && !isTanHinh)
			{
				if (!isBinded && !isSleep && !isStun && !isMoveOut && !isDongBang && Action != 2 && Action != 3)
				{
					vx = 0;
					vy = 0;
					if (GameCanvas.keyMove((!Main.isPC) ? 2 : 33) || GameCanvas.keyMove(39))
					{
						if (!isSelling())
						{
							Action = 1;
							Direction = 2;
							vx = -(vMax + getVmount());
							vy = 0;
							resetMove();
							setValueAuto(0);
						}
						else
						{
							mVector mVector3 = new mVector();
							mVector3.addElement(new iCommand(T.yes, 4, this));
							mVector3.addElement(new iCommand(T.cancel, 5, this));
							GameCanvas.start_Select_Dialog(T.can_not_move, mVector3);
						}
					}
					else if (GameCanvas.keyMove((!Main.isPC) ? 3 : 34) || GameCanvas.keyMove(40))
					{
						if (!isSelling())
						{
							Action = 1;
							Direction = 3;
							vx = vMax + getVmount();
							vy = 0;
							resetMove();
							setValueAuto(0);
						}
						else
						{
							mVector mVector4 = new mVector();
							mVector4.addElement(new iCommand(T.yes, 4, this));
							mVector4.addElement(new iCommand(T.cancel, 5, this));
							GameCanvas.start_Select_Dialog(T.can_not_move, mVector4);
						}
					}
					else if (GameCanvas.keyMove((!Main.isPC) ? 1 : 31) || GameCanvas.keyMove(30))
					{
						if (!isSelling())
						{
							Action = 1;
							Direction = 1;
							vy = -(vMax + getVmount());
							vx = 0;
							resetMove();
							setValueAuto(0);
						}
						else
						{
							mVector mVector5 = new mVector();
							mVector5.addElement(new iCommand(T.yes, 4, this));
							mVector5.addElement(new iCommand(T.cancel, 5, this));
							GameCanvas.start_Select_Dialog(T.can_not_move, mVector5);
						}
					}
					else if (GameCanvas.keyMove(Main.isPC ? 32 : 0) || GameCanvas.keyMove(38))
					{
						if (!isSelling())
						{
							Action = 1;
							Direction = 0;
							vy = vMax + getVmount();
							vx = 0;
							resetMove();
							setValueAuto(0);
						}
						else
						{
							mVector mVector6 = new mVector();
							mVector6.addElement(new iCommand(T.yes, 4, this));
							mVector6.addElement(new iCommand(T.cancel, 5, this));
							GameCanvas.start_Select_Dialog(T.can_not_move, mVector6);
						}
					}
					if (vx == 0 && vy == 0)
					{
						timeStand++;
					}
					else
					{
						timeStand = 0;
					}
				}
				if (GameCanvas.keyMyHold[13] && Main.isPC)
				{
					GameCanvas.clearKeyHold(13);
					nextFocus();
				}
				if (GameCanvas.keyMyHold[37] && Main.isPC)
				{
					GameCanvas.clearKeyHold(37);
					ChatTextField.isShow = !ChatTextField.isShow;
				}
			}
			if (GameCanvas.keyMyHold[11] && !GameCanvas.isTouch)
			{
				GameCanvas.clearKeyHold(11);
				GameCanvas.mevent.init();
				GameCanvas.mevent.Show(GameCanvas.currentScreen);
			}
			if (GameCanvas.keyMyPressed[(Main.isPC && !isCapCha()) ? 1 : 21])
			{
				setActionHotKey(0, true);
			}
			else if (GameCanvas.keyMyPressed[(!Main.isPC || isCapCha()) ? 23 : 2])
			{
				setActionHotKey(1, true);
			}
			else if (GameCanvas.keyMyHold[(!Main.isPC || isCapCha()) ? 5 : 36] || GameCanvas.keyMyPressed[(!Main.isPC || isCapCha()) ? 25 : 3])
			{
				setActionHotKey(2, true);
			}
			else if (GameCanvas.keyMyPressed[(!Main.isPC || isCapCha()) ? 27 : 4])
			{
				setActionHotKey(3, true);
			}
			else if (GameCanvas.keyMyPressed[(!Main.isPC || isCapCha()) ? 29 : 5])
			{
				setActionHotKey(4, true);
			}
		}
		if (GameCanvas.keyMyHold[(!Main.isPC) ? 20 : 6])
		{
			if ((GameScreen.ObjFocus == null || GameScreen.ObjFocus.typeBoss != 2) && PaintInfoGameScreen.timeChange == 0)
			{
				PaintInfoGameScreen.timeChange = 1;
			}
			GameCanvas.clearKeyHold((!Main.isPC) ? 20 : 6);
		}
	}

	public static bool isCapCha()
	{
		if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeBoss == 2)
		{
			return true;
		}
		return false;
	}

	public void setFocus()
	{
		if (isAutoFire == 1 || (GameScreen.ObjFocus != null && (GameScreen.ObjFocus.typeBoss == 2 || GameScreen.ObjFocus.isLuaThieng())))
		{
			return;
		}
		if (GameScreen.ObjFocus != null)
		{
			if ((GameScreen.ObjFocus.Action == 4 && GameScreen.ObjFocus.typeObject != 0) || MainObject.getDistance(GameScreen.ObjFocus.x, GameScreen.ObjFocus.y, x, y) > wFocus + 20 || (GameScreen.ObjFocus.isDie && GameScreen.ObjFocus.typeObject == 1))
			{
				if (!GameScreen.infoGame.isMapThachdau())
				{
					GameScreen.ObjFocus = null;
					PaintInfoGameScreen.isPaintInfoFocus = false;
				}
			}
			else if (!GameCanvas.isTouch && (GameScreen.ObjFocus.typeObject == 2 || (GameScreen.ObjFocus.typeObject == 0 && !setFirePlayer(GameScreen.ObjFocus) && GameScreen.gI().center != GameScreen.gI().cmdGiaotiep && (typePk == -1 || typePk == 10 || GameCanvas.loadmap.mapLang()))))
			{
				GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
			}
		}
		if (GameScreen.ObjFocus != null)
		{
			return;
		}
		if (GameScreen.gI().center != null)
		{
			GameScreen.gI().center = null;
		}
		int num = GameScreen.Vecplayers.size();
		if (indexFocus > num - 1)
		{
			indexFocus = num - 1;
		}
		int num2 = 1000;
		int num3 = -1;
		MainObject mainObject = null;
		for (int i = 0; i < num; i++)
		{
			MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt((i + indexFocus) % num);
			int distance = MainObject.getDistance(mainObject2.x, mainObject2.y, x, y);
			if (distance <= wFocus)
			{
				int num4 = setTypeFocus(mainObject2.typeObject);
				if (mainObject2.ID != GameScreen.player.ID && (mainObject2.Action != 4 || mainObject2.typeObject == 0) && !mainObject2.isRemove && num4 >= num3 && (!mainObject2.isDie || mainObject2.typeObject != 1) && mainObject2.typeObject != 9 && !mainObject2.isLuaThieng() && !mainObject2.isDongBang && (distance < wFocus || (mainObject != null && (mainObject.typeObject == 0 || mainObject.typeObject == 2) && (mainObject2.typeObject == 3 || mainObject2.typeObject == 1 || mainObject2.typeObject == 4 || mainObject2.typeObject == 5 || mainObject2.typeObject == 7))) && (distance < num2 || num4 > num3) && ((mainObject2.typeObject != 0 && mainObject2.typeObject != 2) || timeFocusLast >= 20 || typeFocusLast == 0 || typeFocusLast == 2))
				{
					mainObject = mainObject2;
					num2 = distance;
					indexFocus = i;
					num3 = num4;
				}
			}
		}
		if (mainObject != null)
		{
			if (!mainObject.canFocus())
			{
				return;
			}
			GameScreen.ObjFocus = mainObject;
			if (!GameCanvas.isTouch)
			{
				if ((GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeObject == 2) || (GameScreen.ObjFocus.typeObject == 0 && !setFirePlayer(GameScreen.ObjFocus) && (typePk == -1 || typePk == 10 || GameCanvas.loadmap.mapLang())))
				{
					GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
				}
				else if (GameScreen.gI().center == GameScreen.gI().cmdGiaotiep)
				{
					GameScreen.gI().center = null;
				}
				GameScreen.gI().right = cmdNextFocus;
			}
		}
		else if (GameScreen.gI().right == cmdNextFocus)
		{
			GameScreen.gI().right = null;
		}
	}

	public bool setStatusPk(MainObject obj)
	{
		if (GameCanvas.loadmap.mapLang())
		{
			return true;
		}
		if (obj.typeObject == 2)
		{
			return true;
		}
		if (typePk == -1 || typePk == 10)
		{
			return true;
		}
		if (obj.typeObject == 1 && obj.typeMonster == 7)
		{
			return true;
		}
		if (obj.isMonstervantieu())
		{
			return true;
		}
		if (obj.typeObject != 0)
		{
			return false;
		}
		if (obj.typePk == 0 || obj.typePk == 10)
		{
			return true;
		}
		if (obj.typePk != typePk && obj.typePk != -1)
		{
			return true;
		}
		if (typePk == 0)
		{
			return true;
		}
		return false;
	}

	private int setTypeFocus(int typeObj)
	{
		int result = -1;
		switch (typeObj)
		{
		case 0:
		case 2:
			result = 0;
			break;
		case 1:
			result = 1;
			break;
		case 3:
		case 4:
		case 5:
		case 7:
			result = 2;
			break;
		}
		return result;
	}

	public void nextFocus()
	{
		if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeBoss == 2)
		{
			return;
		}
		setValueAuto(0);
		MainObject mainObject = null;
		int num = -1;
		int num2 = -1;
		if (isFocusNPC)
		{
			for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
			{
				MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt(i);
				if ((GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap) && mainObject2.typePk == typePk && mainObject2.typeObject == 0) || !mainObject2.isNPC())
				{
					continue;
				}
				if (GameScreen.ObjFocus != null && mainObject2 == GameScreen.ObjFocus)
				{
					num2 = i;
				}
				else
				{
					if ((mainObject != null && num2 < 0) || MainObject.getDistance(mainObject2.x, mainObject2.y, x, y) >= wFocus)
					{
						continue;
					}
					mainObject = mainObject2;
					num = i;
					indexFocus = i;
					GameScreen.ObjFocus = mainObject;
					if (!GameCanvas.isTouch)
					{
						if (mainObject.typeObject == 2 || (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeObject == 0 && !setFirePlayer(GameScreen.ObjFocus) && (typePk == -1 || typePk == 10 || GameCanvas.loadmap.mapLang())))
						{
							GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
						}
						else if (GameScreen.gI().center == GameScreen.gI().cmdGiaotiep)
						{
							GameScreen.gI().center = null;
						}
					}
					isFocusNPC = false;
					return;
				}
			}
		}
		mainObject = null;
		num = -1;
		num2 = -1;
		for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
		{
			MainObject mainObject3 = (MainObject)GameScreen.Vecplayers.elementAt(j);
			if (mainObject3 == GameScreen.player || (mainObject3.Action == 4 && mainObject3.typeObject != 0) || !setStatusPk(mainObject3) || mainObject3.typeObject == 9 || mainObject3.typeObject == 10 || mainObject3.isLuaThieng() || mainObject3.isDongBang || !mainObject3.canFocus() || (PaintInfoGameScreen.isMarket(GameCanvas.loadmap.idMap) && mainObject3.typeObject == 0 && !mainObject3.isSelling()) || (isItem(mainObject3) && autoItem != null))
			{
				continue;
			}
			if (GameScreen.ObjFocus != null && mainObject3 == GameScreen.ObjFocus)
			{
				num2 = j;
			}
			else if ((mainObject == null || num2 >= 0) && MainObject.getDistance(mainObject3.x, mainObject3.y, x, y) < wFocus)
			{
				mainObject = mainObject3;
				num = j;
			}
			if (num2 < 0 || num <= num2)
			{
				continue;
			}
			indexFocus = j;
			GameScreen.ObjFocus = mainObject;
			if (!GameCanvas.isTouch)
			{
				if (mainObject.typeObject == 2 || (GameScreen.ObjFocus.typeObject == 0 && !setFirePlayer(GameScreen.ObjFocus) && (typePk == -1 || typePk == 10 || GameCanvas.loadmap.mapLang())))
				{
					GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
				}
				else if (GameScreen.gI().center == GameScreen.gI().cmdGiaotiep)
				{
					GameScreen.gI().center = null;
				}
			}
			return;
		}
		if (mainObject == null)
		{
			return;
		}
		GameScreen.ObjFocus = mainObject;
		if (!GameCanvas.isTouch)
		{
			if (mainObject.typeObject == 2 || (GameScreen.ObjFocus.typeObject == 0 && !setFirePlayer(GameScreen.ObjFocus) && (typePk == -1 || typePk == 10 || GameCanvas.loadmap.mapLang())))
			{
				GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
			}
			else if (GameScreen.gI().center == GameScreen.gI().cmdGiaotiep)
			{
				GameScreen.gI().center = null;
			}
		}
	}

	public void setActionHotKey(int index, bool isSetDef)
	{
		GameCanvas.clearAll();
		if (Action != 4 && GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeObject == 1 && GameScreen.ObjFocus.typeBoss == 2)
		{
			if (index >= 0 && index <= 5)
			{
				GlobalService.gI().Mon_Capchar((sbyte)index);
			}
			return;
		}
		if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeObject == 1)
		{
			if (GameScreen.ObjFocus.isMonstervantieu())
			{
				if (GameScreen.ObjFocus.getnameOwner().Equals(name))
				{
					GameScreen.gI().cmdInfoVantieu.perform();
					return;
				}
				if (!GameScreen.ObjFocus.getnameOwner().Equals(name))
				{
					if (typePk != 0 && !isPkVantieu())
					{
						return;
					}
					if (typePk == 11)
					{
						if (!GameScreen.ObjFocus.isMonsterVantieuDen())
						{
							return;
						}
					}
					else if (typePk == 12)
					{
						if (!GameScreen.ObjFocus.isMonsterVantieuTrang())
						{
							return;
						}
					}
					else if (typePk == 13 && !GameScreen.ObjFocus.isMonsterVantieuDen())
					{
						return;
					}
				}
			}
			if (GameScreen.ObjFocus.isMiNuong())
			{
				GameScreen.gI().cmdinfoMiNuong.perform();
				return;
			}
		}
		HotKey hotKey;
		if (index == -1)
		{
			hotKey = new HotKey();
			hotKey.setHotKey(0, HotKey.SKILL, 0);
		}
		else
		{
			hotKey = mhotkey[levelTab][index];
		}
		if (hotKey.type == HotKey.SKILL)
		{
			skillDefault = hotKey.id;
		}
		if (hotKey.type == HotKey.POTION)
		{
			Item itemInventory = Item.getItemInventory(4, hotKey.id);
			if (itemInventory != null && itemInventory.typePotion < 2)
			{
				if (timeDelayPotion[itemInventory.typePotion].value <= 0 && (itemInventory.typePotion != 0 || hp != maxHp) && (itemInventory.typePotion != 1 || mp != maxMp))
				{
					GlobalService.gI().Use_Potion((short)itemInventory.Id);
					timeDelayPotion[itemInventory.typePotion].value = 2000;
					timeDelayPotion[itemInventory.typePotion].limit = 2000;
					timeDelayPotion[itemInventory.typePotion].timebegin = mSystem.currentTimeMillis();
				}
			}
			else if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeObject == 2 && index == 2)
			{
				GameScreen.gI().cmdGiaotiep.perform();
			}
			return;
		}
		if (GameScreen.ObjFocus == null)
		{
			if (hotKey.type == HotKey.SKILL && setDelaySkill(hotKey.id, index))
			{
				Skill skillFormId = MainListSkill.getSkillFormId(hotKey.id);
				if (skillFormId.typeSkill == 1 && (skillFormId.typeBuff == 1 || skillFormId.typeBuff == 2))
				{
					posTransRoad = null;
					IDAttack = ID;
					mVector mVector3 = new mVector("Player vec");
					Object_Effect_Skill o = new Object_Effect_Skill((short)ID, typeObject);
					mVector3.addElement(o);
					ListKillNow.setFireSkill(this, mVector3, hotKey.id, -1);
				}
			}
			return;
		}
		if (GameScreen.ObjFocus.typeObject == 3 || GameScreen.ObjFocus.typeObject == 4 || GameScreen.ObjFocus.typeObject == 5 || GameScreen.ObjFocus.typeObject == 7)
		{
			if (!GameScreen.ObjFocus.isSend)
			{
				GlobalService.gI().Get_Item_Map((short)GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject);
				GameScreen.ObjFocus.isSend = true;
			}
			return;
		}
		if (GameScreen.ObjFocus.typeObject == 2 && index == 2)
		{
			GameScreen.gI().cmdGiaotiep.perform();
			return;
		}
		if (Action == 2 || Action == 4 || currentQuest != null || isTanHinh)
		{
			if (Action == 4 && GameScreen.ObjFocus.typeObject == 0 && index == 2 && (typePk == -1 || typePk == 10 || GameCanvas.loadmap.mapLang()))
			{
				GameScreen.gI().cmdGiaotiep.perform();
			}
			return;
		}
		if (hotKey.type == HotKey.SKILL && setDelaySkill(hotKey.id, index))
		{
			Skill skillFormId2 = MainListSkill.getSkillFormId(hotKey.id);
			if (skillFormId2.typeSkill == 1)
			{
				if (setAutoBuff(skillFormId2.typeBuff, hotKey.id, GameScreen.ObjFocus))
				{
					return;
				}
			}
			else if (skillFormId2.typeSkill == 0 && GameScreen.ObjFocus.Action != 4 && GameScreen.ObjFocus.typeObject != 2)
			{
				if (setFirePlayer(GameScreen.ObjFocus))
				{
					setStartSkill(hotKey.id, isSetDef);
					return;
				}
				if (GameScreen.ObjFocus.typeObject == 1 && GameScreen.ObjFocus.typeMonster == 7 && myClan != null && GameScreen.ObjFocus.myClan != null && myClan.IdClan == GameScreen.ObjFocus.myClan.IdClan)
				{
					mVector mVector4 = new mVector("Player vec2");
					Object_Effect_Skill o2 = new Object_Effect_Skill((short)GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject);
					mVector4.addElement(o2);
					GlobalService.gI().fire_monster(mVector4, 0);
					if (isAutoFire == 1)
					{
						setCurAutoFire();
					}
					return;
				}
			}
		}
		if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.typeObject == 0 && index == 2 && !setFirePlayer(GameScreen.ObjFocus))
		{
			if (GameScreen.ObjFocus.isSelling())
			{
				GameScreen.gI().cmdplayerStore.perform();
			}
			else if (typePk == -1 || typePk == 10 || GameCanvas.loadmap.mapLang())
			{
				GameScreen.gI().cmdGiaotiep.perform();
			}
		}
	}

	public void setStartSkill(int id, bool isset)
	{
		posTransRoad = null;
		if (GameScreen.ObjFocus != null)
		{
			IDAttack = GameScreen.ObjFocus.ID;
			mVector mVector3 = new mVector("Player vec8");
			Object_Effect_Skill o = new Object_Effect_Skill((short)GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject);
			mVector3.addElement(o);
			ListKillNow.setFireSkill(this, mVector3, id, -1);
			timeFristSkill = mSystem.currentTimeMillis();
			if (GameScreen.ObjFocus.typeObject == 1 && isAutoFire == 0)
			{
				isAutoFire = 1;
				isCurAutoFire = true;
				xBeginAutoFire = x;
				yBeginAutofire = y;
			}
		}
	}

	public bool setDelaySkill(int t, int index)
	{
		if (mCurentLvSkill[t] - 1 < 0)
		{
			if (index >= 0)
			{
				if (index == 2)
				{
					mhotkey[levelTab][index].setHotKey(0, HotKey.SKILL, 0);
				}
				else
				{
					mhotkey[levelTab][index].type = HotKey.NULL;
				}
			}
			return false;
		}
		if (timeDelaySkill[t].value > 0)
		{
			return false;
		}
		int mpLost = MainListSkill.getSkillFormId(t).mLvSkill[mCurentLvSkill[t] + mPlusLvSkill[t] - 1].mpLost;
		if (mp < mpLost)
		{
			return false;
		}
		if (typeMount == 0)
		{
			GameCanvas.addInfoChar(T.TisNguaNau);
			return false;
		}
		if (KillFire == t)
		{
			return false;
		}
		return true;
	}

	public mVector setSkillLan(int index, MainObject objBe)
	{
		mVector mVector3 = new mVector("Player vec7");
		Object_Effect_Skill o = new Object_Effect_Skill((short)objBe.ID, objBe.typeObject);
		mVector3.addElement(o);
		sbyte b = objBe.typeObject;
		Skill skillFormId = MainListSkill.getSkillFormId(index);
		if (mCurentLvSkill[skillFormId.Id] == 0)
		{
			return mVector3;
		}
		if (skillFormId.typeSkill == 1)
		{
			ListKillNow.classbuff = clazz;
			ListKillNow.typebuff = skillFormId.typeBuff;
			if (skillFormId.mLvSkill[mCurentLvSkill[skillFormId.Id] + mPlusLvSkill[skillFormId.Id] - 1].nTarget > 0 && (b == 0 || skillFormId.typeBuff == 3))
			{
				int num = 1;
				for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
				{
					MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
					if (mainObject.ID != objBe.ID && mainObject != GameScreen.player && b == mainObject.typeObject && mainObject.Action != 4 && (b != 0 || ((skillFormId.typeBuff != 3 || setFirePlayer(mainObject)) && (skillFormId.typeBuff != 2 || !setFirePlayer(mainObject)))))
					{
						mSystem.outz("range" + skillFormId.mLvSkill[mCurentLvSkill[skillFormId.Id] + mPlusLvSkill[skillFormId.Id] - 1].range_lan);
						if (MainObject.getDistance(objBe.x, objBe.y, mainObject.x, mainObject.y) <= skillFormId.mLvSkill[mCurentLvSkill[skillFormId.Id] + mPlusLvSkill[skillFormId.Id] - 1].range_lan)
						{
							o = new Object_Effect_Skill((short)mainObject.ID, mainObject.typeObject);
							mVector3.addElement(o);
							num++;
						}
						if (num >= skillFormId.mLvSkill[mCurentLvSkill[skillFormId.Id] + mPlusLvSkill[skillFormId.Id] - 1].nTarget)
						{
							return mVector3;
						}
					}
				}
			}
		}
		else if (skillFormId.mLvSkill[mCurentLvSkill[skillFormId.Id] + mPlusLvSkill[skillFormId.Id] - 1].nTarget > 1)
		{
			int num2 = 1;
			for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
			{
				MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt(j);
				if (mainObject2.ID != objBe.ID && mainObject2 != GameScreen.player && b == mainObject2.typeObject && mainObject2.Action != 4 && (b != 0 || setFirePlayer(mainObject2)))
				{
					if (MainObject.getDistance(objBe.x, objBe.y, mainObject2.x, mainObject2.y) <= skillFormId.mLvSkill[mCurentLvSkill[skillFormId.Id] + mPlusLvSkill[skillFormId.Id] - 1].range_lan)
					{
						o = new Object_Effect_Skill((short)mainObject2.ID, mainObject2.typeObject);
						mVector3.addElement(o);
						num2++;
					}
					if (num2 >= skillFormId.mLvSkill[mCurentLvSkill[skillFormId.Id] + mPlusLvSkill[skillFormId.Id] - 1].nTarget)
					{
						return mVector3;
					}
				}
			}
		}
		return mVector3;
	}

	public void setAddDelaySkill(int t, int index)
	{
		if (t == 35)
		{
			for (int i = 0; i < mKillPlayer.Length; i++)
			{
				timeDelaySkill[i].value = 2000;
				timeDelaySkill[i].limit = 2000;
				timeDelaySkill[i].timebegin = mSystem.currentTimeMillis();
			}
		}
		else if (mKillPlayer[index] == t)
		{
			LvSkill lvSkill = MainListSkill.getSkillFormId(index).mLvSkill[mCurentLvSkill[index] + mPlusLvSkill[index] - 1];
			timeDelaySkill[index].value = lvSkill.getdelay();
			timeDelaySkill[index].limit = lvSkill.getdelay();
			timeDelaySkill[index].typeSkill = HotKey.SKILL;
			timeDelaySkill[index].timebegin = mSystem.currentTimeMillis();
			if (lvSkill.mpLost > 0)
			{
				mp -= lvSkill.mpLost;
			}
			Skill skillFormId = MainListSkill.getSkillFormId(index);
			if (skillFormId != null && skillFormId.typeSkill == 0)
			{
				timeDelaySkill[index].isSkillAttack = true;
			}
		}
	}

	public void updateDelaySkill()
	{
		for (int i = 0; i < timeDelaySkill.Length; i++)
		{
			if (timeDelaySkill[i] != null && timeDelaySkill[i].value > -150)
			{
				timeDelaySkill[i].value -= (int)(mSystem.currentTimeMillis() - timeDelaySkill[i].timebegin);
				timeDelaySkill[i].timebegin = mSystem.currentTimeMillis();
			}
		}
		for (int j = 0; j < timeDelayPotion.Length; j++)
		{
			if (timeDelayPotion[j].value > -150)
			{
				timeDelayPotion[j].value -= (int)(mSystem.currentTimeMillis() - timeDelayPotion[j].timebegin);
				timeDelayPotion[j].timebegin = mSystem.currentTimeMillis();
			}
		}
	}

	public void resetCoolDown()
	{
		for (int i = 0; i < timeDelaySkill.Length; i++)
		{
			if (timeDelaySkill[i].isSkillAttack)
			{
				timeDelaySkill[i].value = 0;
			}
		}
	}

	public void resetMove()
	{
		if (KillFire != -1)
		{
			KillFire = -1;
			posTransRoad = null;
			toX = x;
			toY = y;
			xStopMove = 0;
			yStopMove = 0;
		}
	}

	public bool setFirePlayer(MainObject obj)
	{
		if (obj.canfire())
		{
			return true;
		}
		if (obj.isLuaThieng())
		{
			return false;
		}
		if (GameCanvas.loadmap.mapLang())
		{
			return false;
		}
		if (obj == null)
		{
			return false;
		}
		if (isStun || isDongBang)
		{
			return false;
		}
		if (obj.isSleep)
		{
			return true;
		}
		if (obj.isMoveOut)
		{
			return true;
		}
		if (obj.typeObject == 0 && obj.typeSpec == 1)
		{
			if (obj.typePk >= 1 && obj.typePk <= 9 && typePk >= 1 && typePk <= 9 && obj.typePk == typePk)
			{
				return false;
			}
			if (obj.myClan == null || GameScreen.player.myClan == null || obj.myClan.IdClan != GameScreen.player.myClan.IdClan)
			{
				return true;
			}
			return false;
		}
		if (Action == 4 || obj.Action == 4)
		{
			return false;
		}
		if (obj.typeObject == 0)
		{
			if (obj.typePk >= 1 && obj.typePk <= 9 && typePk >= 1 && typePk <= 9 && obj.typePk == typePk)
			{
				return false;
			}
			if (pointPk >= 2000)
			{
				return false;
			}
			if (typePk == 12 && (obj.typePk == 13 || obj.typePk == 11))
			{
				return true;
			}
			if (typePk == 12 && obj.typePk == 12)
			{
				return false;
			}
			if (typePk == 13 && obj.typePk == 12)
			{
				return true;
			}
			if (typePk == 13 && (obj.typePk == 13 || obj.typePk == 11))
			{
				return false;
			}
			if (typePk == 11 && obj.typePk == 12)
			{
				return true;
			}
			if (typePk == 11 && (obj.typePk == 11 || obj.typePk == 13))
			{
				return false;
			}
			if (typePk == 10 && setPlayerPk((short)obj.ID))
			{
				return true;
			}
			if (obj.typePk == 0 || obj.typePk == 10)
			{
				return true;
			}
			if (obj.typePk != -1 && typePk != -1 && typePk != obj.typePk && typePk != 10)
			{
				return true;
			}
			if (obj.Lv > 10 && typePk == 0)
			{
				return true;
			}
			return false;
		}
		if (PointSucKhoe <= 0)
		{
			GameCanvas.addInfoChar(T.yeusuckhoe);
			return false;
		}
		if (obj.typeObject == 1 && obj.typeMonster == 7 && myClan != null && obj.myClan != null && myClan.IdClan == obj.myClan.IdClan)
		{
			return false;
		}
		return true;
	}

	public bool setPlayerPk(short id)
	{
		for (int i = 0; i < vecPlayerPk.Length; i++)
		{
			if (id == vecPlayerPk[i])
			{
				return true;
			}
		}
		return false;
	}

	public void dofire()
	{
		if (isAutoFire == 0)
		{
			isAutoFire = 1;
			xBeginAutoFire = x;
			yBeginAutofire = y;
			timeResetAuto = 60;
			isCurAutoFire = true;
		}
		else if (isAutoFire == -1)
		{
			GameCanvas.keyMyPressed[(!Main.isPC || isCapCha()) ? 25 : 3] = true;
			isAutoFire = 1;
			xBeginAutoFire = x;
			yBeginAutofire = y;
			timeResetAuto = 60;
			isCurAutoFire = false;
		}
	}

	public void setPointFocus()
	{
		if (GameScreen.ObjFocus == null || GameScreen.ObjFocus.typeBoss == 2)
		{
			return;
		}
		if (GameScreen.ObjFocus.isNPC())
		{
			GameScreen.gI().cmdGiaotiep.perform();
			if (isAutoFire == 1)
			{
				setCurAutoFire();
			}
		}
		else if (GameScreen.ObjFocus.typeObject == 0)
		{
			if (setFirePlayer(GameScreen.ObjFocus))
			{
				HotKey hotKey = mhotkey[levelTab][IndexFire];
				if (hotKey.type != HotKey.SKILL)
				{
					for (int i = 0; i < mhotkey[levelTab].Length; i++)
					{
						hotKey = mhotkey[levelTab][i];
						if (hotKey.type == HotKey.SKILL)
						{
							IndexFire = (sbyte)i;
							if (isAutoFire == 1)
							{
								setCurAutoFire();
							}
							break;
						}
					}
				}
				setActionHotKey(IndexFire, false);
			}
			else if (GameScreen.ObjFocus.isSelling())
			{
				GameScreen.gI().cmdplayerStore.perform();
			}
			else if (typePk == -1 || typePk == 10 || GameCanvas.loadmap.mapLang())
			{
				GameScreen.gI().cmdGiaotiep.setPos(GameScreen.ObjFocus.x - MainScreen.cameraMain.xCam, GameScreen.ObjFocus.y - MainScreen.cameraMain.yCam - GameScreen.ObjFocus.hOne - 30, PaintInfoGameScreen.fraContact, string.Empty);
				GameScreen.gI().cmdGiaotiep.IdGiaotiep = GameScreen.ObjFocus.ID;
				GameScreen.timePaintCmdGiaotiep = 60;
			}
		}
		else if (GameScreen.ObjFocus.typeObject == 4 || GameScreen.ObjFocus.typeObject == 3 || GameScreen.ObjFocus.typeObject == 5 || GameScreen.ObjFocus.typeObject == 7)
		{
			if (!GameScreen.ObjFocus.isSend)
			{
				GlobalService.gI().Get_Item_Map((short)GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject);
				GameScreen.ObjFocus.isSend = true;
			}
		}
		else
		{
			if (GameScreen.ObjFocus.typeObject != 1 || GameScreen.ObjFocus.Action == 4)
			{
				return;
			}
			if (GameScreen.ObjFocus.isMiNuong())
			{
				GameScreen.gI().cmdinfoMiNuong.perform();
			}
			else if (!GameScreen.ObjFocus.isMonstervantieu())
			{
				dofire();
			}
			else
			{
				if (!GameScreen.ObjFocus.isMonstervantieu())
				{
					return;
				}
				if (GameScreen.ObjFocus.getnameOwner().Equals(name))
				{
					GameScreen.gI().cmdInfoVantieu.perform();
				}
				else
				{
					if (GameScreen.ObjFocus.getnameOwner().Equals(name))
					{
						return;
					}
					if (typePk == 0)
					{
						dofire();
					}
					else if (typePk == 11 || typePk == 13)
					{
						if (GameScreen.ObjFocus.isMonsterVantieuDen())
						{
							dofire();
						}
					}
					else if (typePk == 12 && GameScreen.ObjFocus.isMonsterVantieuTrang())
					{
						dofire();
					}
				}
			}
		}
	}

	public void resetPlayer()
	{
		party = null;
		currentQuest = null;
		chat = null;
	}

	public void setValueAuto(int value)
	{
		if (isAutoFire != -1)
		{
			if (isCurAutoFire)
			{
				isAutoFire = (sbyte)value;
			}
			else
			{
				isAutoFire = -1;
			}
			if (isAutoFire == 0)
			{
				xBeginAutoFire = -1;
				yBeginAutofire = -1;
			}
		}
	}

	public bool setAutoBuff(int typeBuff, int id, MainObject objFo)
	{
		if (objFo == null)
		{
			posTransRoad = null;
			IDAttack = ID;
			mVector mVector3 = new mVector("Player vec3");
			Object_Effect_Skill o = new Object_Effect_Skill((short)ID, typeObject);
			mVector3.addElement(o);
			ListKillNow.setFireSkill(this, mVector3, id, -1);
			return true;
		}
		switch (typeBuff)
		{
		case 2:
		{
			posTransRoad = null;
			IDAttack = ID;
			mVector mVector5 = new mVector("Player vec4");
			Object_Effect_Skill object_Effect_Skill = null;
			object_Effect_Skill = ((objFo.Action != 4 && objFo.typeObject != 2 && typePk != 0 && objFo.typePk != 0 && objFo.typePk != 10 && (objFo.typePk == -1 || typePk == -1 || typePk == objFo.typePk)) ? new Object_Effect_Skill((short)objFo.ID, objFo.typeObject) : new Object_Effect_Skill((short)ID, typeObject));
			mVector5.addElement(object_Effect_Skill);
			ListKillNow.setFireSkill(this, mVector5, id, -1);
			return true;
		}
		case 1:
		{
			posTransRoad = null;
			IDAttack = ID;
			mVector mVector6 = new mVector("Player vec5");
			Object_Effect_Skill o3 = new Object_Effect_Skill((short)ID, typeObject);
			mVector6.addElement(o3);
			ListKillNow.setFireSkill(this, mVector6, id, -1);
			return true;
		}
		case 3:
			if (objFo.Action != 4 && objFo.typeObject != 2 && setFirePlayer(objFo))
			{
				posTransRoad = null;
				IDAttack = objFo.ID;
				mVector mVector4 = new mVector("Player vec6");
				Object_Effect_Skill o2 = new Object_Effect_Skill((short)objFo.ID, objFo.typeObject);
				mVector4.addElement(o2);
				ListKillNow.setFireSkill(this, mVector4, id, -1);
				return true;
			}
			break;
		}
		return false;
	}

	public static bool setFirePlayerSpec(MainObject obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.typeObject == 0 && obj.typeSpec == 1 && (obj.myClan == null || GameScreen.player.myClan == null || obj.myClan.IdClan != GameScreen.player.myClan.IdClan))
		{
			return true;
		}
		return false;
	}

	public bool checkGiaoTiep()
	{
		if (GameScreen.ObjFocus == null)
		{
			return false;
		}
		if (GameScreen.ObjFocus.typeObject == 2)
		{
			return true;
		}
		if (GameScreen.ObjFocus.typeObject == 1 && (GameScreen.ObjFocus.myClan == null || GameScreen.player.myClan == null || GameScreen.ObjFocus.myClan.IdClan != GameScreen.player.myClan.IdClan))
		{
			return false;
		}
		if (!setFirePlayer(GameScreen.ObjFocus))
		{
			return true;
		}
		return false;
	}

	public override void move_to_XY()
	{
		if (isSelling())
		{
			toX = x;
			toY = y;
			posTransRoad = null;
			mVector mVector3 = new mVector();
			mVector3.addElement(new iCommand(T.yes, 4, this));
			mVector3.addElement(new iCommand(T.cancel, 5, this));
			GameCanvas.start_Select_Dialog(T.can_not_move, mVector3);
		}
		else if (!Canmove() || isBinded)
		{
			toX = x;
			toY = y;
		}
		else
		{
			if (isMoveOut)
			{
				return;
			}
			if (x != toX)
			{
				vy = 0;
				Action = 1;
				if (CRes.abs(x - toX) > vMax + getVmount())
				{
					if (x > toX)
					{
						vx = -(vMax + getVmount());
						PrevDir = Direction;
						Direction = 2;
					}
					else
					{
						vx = vMax + getVmount();
						PrevDir = Direction;
						Direction = 3;
					}
				}
				else if (CRes.abs(x - toX) < vMax + getVmount())
				{
					if (x > toX)
					{
						vx = -CRes.abs(x - toX);
						PrevDir = Direction;
						Direction = 2;
					}
					else
					{
						vx = CRes.abs(x - toX);
						PrevDir = Direction;
						Direction = 3;
					}
				}
				else if (x > toX)
				{
					vx = -(vMax + getVmount());
					PrevDir = Direction;
					Direction = 2;
				}
				else
				{
					vx = vMax + getVmount();
					PrevDir = Direction;
					Direction = 3;
				}
			}
			else if (y != toY)
			{
				vx = 0;
				Action = 1;
				if (CRes.abs(y - toY) > vMax + getVmount())
				{
					if (y > toY)
					{
						vy = -(vMax + getVmount());
						PrevDir = Direction;
						Direction = 1;
					}
					else
					{
						vy = vMax + getVmount();
						PrevDir = Direction;
						Direction = 0;
					}
				}
				else if (CRes.abs(y - toY) < vMax + getVmount())
				{
					if (y > toY)
					{
						vy = -CRes.abs(y - toY);
						PrevDir = Direction;
						Direction = 1;
					}
					else
					{
						vy = CRes.abs(y - toY);
						PrevDir = Direction;
						Direction = 0;
					}
				}
				else if (y > toY)
				{
					vy = -(vMax + getVmount());
					PrevDir = Direction;
					Direction = 1;
				}
				else
				{
					vy = vMax + getVmount();
					PrevDir = Direction;
					Direction = 0;
				}
			}
			else
			{
				vx = 0;
				vy = 0;
				Action = 0;
			}
		}
	}

	public override void addEffectCharWearing(int typeeffect, int idimage)
	{
		EffectCharWearing o = new EffectCharWearing((sbyte)typeeffect, idimage);
		vecEffectCharWearing.addElement(o);
	}

	public static void setCurAutoFire()
	{
		if (isCurAutoFire)
		{
			isAutoFire = 0;
		}
		else
		{
			isAutoFire = -1;
		}
	}

	public override void removeNameStore()
	{
		nameStore = null;
	}

	public void dofire_()
	{
		isAutoFire = 1;
		xBeginAutoFire = x;
		yBeginAutofire = y;
		timeResetAuto = 60;
		isCurAutoFire = true;
	}

	public override void setNameStore(string name)
	{
		if (nameStore == null)
		{
			nameStore = new PopupChat();
		}
		nameStore.setChat(name, isStop);
		nameStore.updatePos(x, y - hOne - 30);
	}

	public override bool isSelling()
	{
		return nameStore != null;
	}
}
