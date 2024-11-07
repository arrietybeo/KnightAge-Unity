public class TabRebuildItem : MainTabNew
{
	private sbyte typeRebuild;

	public static sbyte TYPE_REBUILD = 0;

	public static sbyte TYPE_REPLACE_PLUS = 1;

	public static sbyte TYPE_REBUILD_WING = 2;

	public static sbyte TYPE_KHAM_NGOC = 3;

	public static sbyte TYPE_GHEP_NGOC = 4;

	public static sbyte TYPE_DUC_LO = 5;

	public static sbyte TYPE_ANY = 6;

	public static sbyte KHAM_NGOC = 0;

	public static sbyte GHEP_NGOC = 1;

	public static sbyte DUC_LO = 2;

	private int maxw;

	private int maxh;

	private int indexPaint = 12;

	private int winfo = 140;

	private int[][] posMaterial;

	public static string[] mNameMaterial;

	public static string[] numofGem = new string[5]
	{
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty
	};

	public static sbyte[] numColor = new sbyte[5];

	private int xinfo;

	private int yinfo;

	public static DataRebuildItem[] dataRebuild;

	public static MainItem itemRe;

	public static MainItem itemPlus;

	public static MainItem itemFree;

	public static MainItem itemWing;

	public static int[] numMaterialInven;

	public static short[] idMaterial;

	public static int[] numWingMaterialInven;

	public static DataRebuildItem[] dataWing;

	public static int priceWing = 0;

	public static int timeUseWing;

	public static string nameWing = string.Empty;

	public static int isChetao = 0;

	public static short lvReWing = 0;

	public static short idWingOk = 0;

	public static string tilemayman = "test nao";

	public static string tilemaymanafter;

	public static sbyte isBeginEff = 0;

	public static sbyte isNextRebuild = 0;

	public static bool isLucky = false;

	public static bool isShow;

	private iCommand cmdHoiDap;

	private iCommand cmdView;

	private iCommand cmcloseInfo;

	private iCommand cmdHoiReplace;

	private iCommand cmdHoiReWing;

	private iCommand cmdHopThanh;

	public static mVector vecEffRe = new mVector("TabRebuildItem vecEffRe");

	public static string contentShow = string.Empty;

	private mVector vecListCmd = new mVector("TabRebuildItem vecListCmd");

	public static mVector vecGem = new mVector("TabRebuildItem vecGem");

	public static bool resetItemReplace = false;

	public sbyte typekham;

	public bool ispaintitemRe;

	public static Item itemDaMayMan = null;

	private Scroll scr = new Scroll();

	private int timeShowReplace;

	private long time;

	public static sbyte countSetpaintinfo = 0;

	public TabRebuildItem(string name, sbyte type)
	{
		isTabHopNguyenLieu = false;
		imgStarRebuild = null;
		typeRebuild = type;
		typeTab = MainTabNew.REBUILD;
		nameTab = name;
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
		maxw = (MainTabNew.wblack - 8) / 32;
		maxh = (MainTabNew.hblack - 8) / 32;
		if (MainTabNew.longwidth > 0)
		{
			winfo = MainTabNew.longwidth;
			xinfo = MainTabNew.xlongwidth;
			yinfo = MainTabNew.ylongwidth + MainTabNew.wOneItem / 2;
		}
		else
		{
			xinfo = xBegin + MainTabNew.wblack / 2 - winfo / 2;
			yinfo = yBegin + 4;
			if (yinfo > GameCanvas.h - GameCanvas.hCommand - 150 - GameCanvas.hCommand)
			{
				yinfo = GameCanvas.h - GameCanvas.hCommand - 150 - GameCanvas.hCommand;
			}
		}
		if (GameCanvas.isSmallScreen)
		{
			yinfo = GameCanvas.h - GameCanvas.hCommand - 150 - GameCanvas.hCommand;
		}
		cmdBack = new iCommand(T.back, -1, this);
		cmdView = new iCommand(T.info, 1, this);
		if (GameCanvas.isTouch)
		{
			cmdBack.caption = T.close;
		}
		if (typeRebuild == TYPE_REBUILD || typeRebuild == TYPE_KHAM_NGOC || typeRebuild == TYPE_DUC_LO || typeRebuild == TYPE_GHEP_NGOC || typeRebuild == TYPE_ANY)
		{
			posMaterial = mSystem.new_M_Int(6, 2);
			posMaterial[4][0] = xBegin + MainTabNew.wblack / 2;
			posMaterial[4][1] = yBegin + MainTabNew.hblack / 2 - 52;
			posMaterial[2][0] = xBegin + MainTabNew.wblack / 2 + 52;
			posMaterial[2][1] = yBegin + MainTabNew.hblack / 2 - 16;
			posMaterial[1][0] = xBegin + MainTabNew.wblack / 2 + 32;
			posMaterial[1][1] = yBegin + MainTabNew.hblack / 2 + 45;
			posMaterial[3][0] = xBegin + MainTabNew.wblack / 2 - 32;
			posMaterial[3][1] = yBegin + MainTabNew.hblack / 2 + 45;
			posMaterial[0][0] = xBegin + MainTabNew.wblack / 2 - 52;
			posMaterial[0][1] = yBegin + MainTabNew.hblack / 2 - 16;
			posMaterial[5][0] = xBegin + MainTabNew.wblack / 2;
			posMaterial[5][1] = yBegin + MainTabNew.hblack / 2;
			isLucky = false;
			right = null;
			isShow = false;
			cmdHoiDap = new iCommand(T.dapdo, 0, this);
			if (MainTabNew.longwidth > 0)
			{
				int num = MainTabNew.ylongwidth + hSmall;
				int num2 = MainTabNew.xlongwidth;
				if (MainTabNew.is320)
				{
					cmdHoiDap.setPos(num2 + MainTabNew.longwidth / 2, num - 10, PaintInfoGameScreen.fraButton2, cmdHoiDap.caption);
				}
				else
				{
					cmdHoiDap.setPos(num2 + MainTabNew.longwidth / 2, num - 15, null, cmdHoiDap.caption);
				}
			}
			else if (GameCanvas.isTouch)
			{
				cmdHoiDap.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdHoiDap.caption);
				cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2 - 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdView.caption);
			}
		}
		else if (typeRebuild == TYPE_REPLACE_PLUS)
		{
			posMaterial = mSystem.new_M_Int(2, 2);
			posMaterial[1][0] = xBegin + MainTabNew.wblack / 2 + 52;
			posMaterial[1][1] = yBegin + MainTabNew.hblack / 2 - 16;
			posMaterial[0][0] = xBegin + MainTabNew.wblack / 2 - 52;
			posMaterial[0][1] = yBegin + MainTabNew.hblack / 2 - 16;
			cmdHoiReplace = new iCommand(T.replace, 3, this);
			if (MainTabNew.longwidth > 0)
			{
				int num3 = MainTabNew.ylongwidth + hSmall;
				int num4 = MainTabNew.xlongwidth;
				if (MainTabNew.is320)
				{
					cmdHoiReplace.setPos(num4 + MainTabNew.longwidth / 2, num3 - 10, PaintInfoGameScreen.fraButton2, cmdHoiReplace.caption);
				}
				else
				{
					cmdHoiReplace.setPos(num4 + MainTabNew.longwidth / 2, num3 - 15, null, cmdHoiReplace.caption);
				}
			}
			else if (GameCanvas.isTouch)
			{
				cmdHoiReplace.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdHoiReplace.caption);
				cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2 - 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdView.caption);
			}
		}
		else if (typeRebuild == TYPE_REBUILD_WING)
		{
			posMaterial = mSystem.new_M_Int(7, 2);
			posMaterial[1][0] = xBegin + MainTabNew.wblack / 2;
			posMaterial[1][1] = yBegin + MainTabNew.hblack / 2 - 52;
			posMaterial[5][0] = xBegin + MainTabNew.wblack / 2 + 46;
			posMaterial[5][1] = yBegin + MainTabNew.hblack / 2 - 26;
			posMaterial[2][0] = xBegin + MainTabNew.wblack / 2 + 46;
			posMaterial[2][1] = yBegin + MainTabNew.hblack / 2 + 26;
			posMaterial[4][0] = xBegin + MainTabNew.wblack / 2;
			posMaterial[4][1] = yBegin + MainTabNew.hblack / 2 + 52;
			posMaterial[0][0] = xBegin + MainTabNew.wblack / 2 - 46;
			posMaterial[0][1] = yBegin + MainTabNew.hblack / 2 + 26;
			posMaterial[3][0] = xBegin + MainTabNew.wblack / 2 - 46;
			posMaterial[3][1] = yBegin + MainTabNew.hblack / 2 - 26;
			posMaterial[6][0] = xBegin + MainTabNew.wblack / 2;
			posMaterial[6][1] = yBegin + MainTabNew.hblack / 2;
			cmdHoiReWing = new iCommand(T.nangcap, 4, this);
			if (MainTabNew.longwidth > 0)
			{
				int num5 = MainTabNew.ylongwidth + hSmall;
				int num6 = MainTabNew.xlongwidth;
				if (MainTabNew.is320)
				{
					cmdHoiReWing.setPos(num6 + MainTabNew.longwidth / 2, num5 - 10, PaintInfoGameScreen.fraButton2, cmdHoiReWing.caption);
				}
				else
				{
					cmdHoiReWing.setPos(num6 + MainTabNew.longwidth / 2, num5 - 15, null, cmdHoiReWing.caption);
				}
			}
			else if (GameCanvas.isTouch)
			{
				cmdHoiReWing.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdHoiReWing.caption);
				cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2 - 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdView.caption);
			}
		}
		init();
		if (typeRebuild == TYPE_DUC_LO || typeRebuild == TYPE_GHEP_NGOC || typeRebuild == TYPE_KHAM_NGOC || typeRebuild == TYPE_REBUILD || typeRebuild == TYPE_REPLACE_PLUS || typeRebuild == TYPE_ANY)
		{
			imgStarRebuild = mImage.createImage("/interface/rebuild.img");
		}
		else if (typeRebuild == TYPE_REBUILD_WING)
		{
			imgStarRebuild = mImage.createImage("/interface/rebuild2.img");
		}
	}

	public new void setPaintInfo()
	{
		mContent = null;
		mSubContent = null;
		mPlusContent = null;
		if (itemRe != null && itemRe.itemName != null)
		{
			name = itemRe.itemName;
		}
		listContent = null;
		if (itemRe != null)
		{
			int num = 1;
			mContent = itemRe.mcontent;
			moreInfoconten = itemRe.moreContenGem;
			mPlusContent = itemRe.mPlusContent;
			mPlusColor = itemRe.mPlusColor;
			mcolor = itemRe.mColor;
			colorName = itemRe.colorNameItem;
			if (itemRe.mcontent != null)
			{
				num += mContent.Length;
			}
			if (itemRe.mPlusContent != null)
			{
				num += itemRe.mPlusContent.Length;
			}
			if (num * GameCanvas.hText > MainTabNew.hMaxContent - 30)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - (MainTabNew.hMaxContent - 30));
			}
			else if (GameCanvas.isTouch)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, 0);
			}
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			backTab();
			break;
		case 0:
			if (typeRebuild == TYPE_ANY)
			{
				if (isUPgradeMedal && itemRe != null)
				{
					GlobalService.gI().Hop_rac(4, (short)itemRe.Id, (sbyte)itemRe.ItemCatagory);
					vecGem.removeAllElements();
					return;
				}
				if (isCreate_medal)
				{
					GlobalService.gI().Hop_rac(3);
					vecGem.removeAllElements();
				}
				else if (vecGem.size() > 0)
				{
					MainItem mainItem = (MainItem)vecGem.elementAt(0);
					if (mainItem != null)
					{
						GlobalService.gI().Hop_rac(2, (short)mainItem.Id, (sbyte)mainItem.ItemCatagory);
						vecGem.removeAllElements();
					}
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.bonguyenlieu);
				}
			}
			else if (typeRebuild == TYPE_DUC_LO)
			{
				int idG = -1;
				if (itemRe != null && vecGem.size() > 0)
				{
					MainItem mainItem2 = (MainItem)vecGem.elementAt(0);
					if (mainItem2 != null)
					{
						idG = mainItem2.Id;
					}
					GlobalService.gI().KhamNgoc(DUC_LO, itemRe.Id, idG, -1, -1);
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.chuaboduclo);
				}
			}
			else if (typeRebuild == TYPE_GHEP_NGOC)
			{
				if (vecGem.size() > 0)
				{
					MainItem mainItem3 = (MainItem)vecGem.elementAt(0);
					if (mainItem3 != null)
					{
						GlobalService.gI().KhamNgoc(GHEP_NGOC, mainItem3.Id, -1, -1, -1);
					}
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.bongoc);
				}
			}
			else if (typeRebuild == TYPE_KHAM_NGOC)
			{
				if (itemRe != null && vecGem.size() > 0)
				{
					int[] array = new int[3] { -1, -1, -1 };
					for (int i = 0; i < vecGem.size(); i++)
					{
						MainItem mainItem4 = (MainItem)vecGem.elementAt(i);
						if (mainItem4 != null)
						{
							array[i] = mainItem4.Id;
						}
					}
					GlobalService.gI().KhamNgoc(KHAM_NGOC, itemRe.Id, array[0], array[1], array[2]);
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.chuaboitem);
				}
			}
			else if (itemRe != null)
			{
				string text = string.Empty;
				int num = 0;
				mVector mVector3 = new mVector("TabRebuildItem menu");
				if (dataRebuild[itemRe.tier].priceCoin != 0)
				{
					mVector3.addElement(new iCommand(T.coin, 2, 0, this));
					text = T.dapbangxu + MainItem.getDotNumber(dataRebuild[itemRe.tier].priceCoin) + " " + T.coin + "?";
					num++;
				}
				if (dataRebuild[itemRe.tier].priceGold != 0)
				{
					mVector3.addElement(new iCommand(T.gem, 2, 1, this));
					text = T.dapbangxu + dataRebuild[itemRe.tier].priceGold + " " + T.gem + "?";
					num++;
				}
				if (num == 2)
				{
					text = T.hoidapxuluong + MainItem.getDotNumber(dataRebuild[itemRe.tier].priceCoin) + " " + T.coin + T.hay + dataRebuild[itemRe.tier].priceGold + " " + T.gem + "?";
				}
				GameCanvas.menu2.startAt_NPC(mVector3, text, Menu2.IdNPCLast, 2, isQuest: false, 0);
			}
			break;
		case 1:
			if (MainTabNew.longwidth != 0)
			{
				break;
			}
			if ((itemRe != null && (typeRebuild == TYPE_REBUILD || typeRebuild == TYPE_KHAM_NGOC)) || (itemPlus != null && itemFree != null && typeRebuild == TYPE_REPLACE_PLUS) || (typeRebuild == TYPE_REBUILD_WING && dataWing != null))
			{
				isShow = !isShow;
			}
			else
			{
				isShow = false;
			}
			if (isShow)
			{
				if (!GameCanvas.isTouch)
				{
					cmdView.caption = T.close;
				}
				else
				{
					cmdView.setPos(xinfo + winfo - 12, yinfo + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
				}
			}
			else if (!GameCanvas.isTouch)
			{
				cmdView.caption = T.info;
			}
			else
			{
				cmdView.caption = T.info;
				cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2, null, cmdView.caption);
			}
			break;
		case 2:
			if (itemRe == null)
			{
				break;
			}
			GameCanvas.menu2.doCloseMenu();
			GlobalService.gI().Rebuild_Item(2, 0, (sbyte)subIndex);
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
				if (!GameCanvas.isTouch)
				{
					cmdView.caption = T.info;
				}
				else
				{
					cmdView.caption = T.info;
					cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2, null, cmdView.caption);
				}
			}
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			break;
		case 3:
			if (itemFree != null && itemPlus != null)
			{
				GlobalService.gI().Replace_Item(1, 0);
				GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			}
			break;
		case 4:
		{
			mVector mVector4 = new mVector("TabRebuildItem menu2");
			string empty = string.Empty;
			if (itemWing == null)
			{
				empty = T.hoiTaoCanh + nameTab + "? " + T.phi + ": " + MainItem.getDotNumber(priceWing) + " " + T.coin + ", " + T.LVyeucau + lvReWing + ", " + T.timeyeucau + PaintInfoGameScreen.getStringTime(timeUseWing) + ".";
				mVector4.addElement(new iCommand(T.taoCanh, 5, 0, this));
			}
			else
			{
				empty = T.hoinangcapcanh + nameWing + "? " + T.phi + ": " + MainItem.getDotNumber(priceWing) + " " + T.coin + ", " + T.LVyeucau + lvReWing + ", " + T.timeyeucau + PaintInfoGameScreen.getStringTime(timeUseWing) + ".";
				mVector4.addElement(new iCommand(T.nangcap, 6, 0, this));
			}
			GameCanvas.menu2.startAt_NPC(mVector4, empty, Menu2.IdNPCLast, 2, isQuest: false, 0);
			break;
		}
		case 5:
			GameCanvas.menu2.doCloseMenu();
			GlobalService.gI().Rebuild_Wing(1, isChetao, 0);
			break;
		case 6:
			GameCanvas.menu2.doCloseMenu();
			if (itemWing != null)
			{
				GlobalService.gI().Rebuild_Wing(3, isChetao, (short)itemWing.Id);
			}
			break;
		case 7:
			GameCanvas.menu2.doCloseMenu();
			GlobalService.gI().Rebuild_Item(5, (short)itemRe.Id, (sbyte)itemRe.ItemCatagory);
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
				if (!GameCanvas.isTouch)
				{
					cmdView.caption = T.info;
				}
				else
				{
					cmdView.caption = T.info;
					cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2, null, cmdView.caption);
				}
			}
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public override void init()
	{
		cmdView.caption = T.info;
		if (typeRebuild == TYPE_REBUILD || typeRebuild == TYPE_KHAM_NGOC || typeRebuild == TYPE_GHEP_NGOC || typeRebuild == TYPE_DUC_LO || typeRebuild == TYPE_ANY)
		{
			initRebuild();
		}
		else if (typeRebuild == TYPE_REPLACE_PLUS)
		{
			initReplace();
		}
		else if (typeRebuild == TYPE_REBUILD_WING)
		{
			initReWing();
		}
	}

	private void initReplace()
	{
		MainTabNew.timePaintInfo = 0;
		if (MainTabNew.longwidth > 0)
		{
			isShow = true;
		}
		if (!GameCanvas.isTouch)
		{
			if (itemPlus != null && itemFree != null && !resetItemReplace)
			{
				left = cmdView;
				center = cmdHoiReplace;
			}
			right = cmdBack;
		}
		else
		{
			vecListCmd.removeAllElements();
			if (!resetItemReplace && itemPlus != null && itemFree != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					vecListCmd.addElement(cmdHoiReplace);
				}
				else
				{
					vecListCmd.addElement(cmdView);
					vecListCmd.addElement(cmdHoiReplace);
				}
			}
		}
		listContent = null;
		vecEffRe.removeAllElements();
		isBeginEff = 0;
		isNextRebuild = -1;
		if (resetItemReplace)
		{
			itemFree = null;
			itemPlus = null;
			resetItemReplace = false;
		}
		if (itemPlus == null && itemFree == null)
		{
			GameCanvas.menu2.startAt_NPC(null, T.boitemreplace, Menu2.IdNPCLast, 2, isQuest: false, 0);
		}
	}

	private void initRebuild()
	{
		MainTabNew.timePaintInfo = 0;
		if (MainTabNew.longwidth > 0)
		{
			isShow = true;
		}
		if (!GameCanvas.isTouch)
		{
			if (itemRe != null || typeRebuild == TYPE_GHEP_NGOC || typeRebuild == TYPE_ANY)
			{
				left = cmdView;
				center = cmdHoiDap;
			}
			right = cmdBack;
		}
		else
		{
			vecListCmd.removeAllElements();
			if (itemRe != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					vecListCmd.addElement(cmdHoiDap);
				}
				else
				{
					vecListCmd.addElement(cmdView);
					vecListCmd.addElement(cmdHoiDap);
				}
			}
			if (typeRebuild == TYPE_GHEP_NGOC)
			{
				vecListCmd.addElement(cmdHoiDap);
				cmdHoiDap.caption = T.hopngoc;
			}
			if (typeRebuild == TYPE_ANY)
			{
				vecListCmd.addElement(cmdHoiDap);
				cmdHoiDap.caption = T.hoprac;
			}
		}
		listContent = null;
		vecEffRe.removeAllElements();
		isBeginEff = 0;
		isNextRebuild = 0;
		if (itemRe == null && typeRebuild != TYPE_GHEP_NGOC && typeRebuild != TYPE_ANY)
		{
			string text = ((!isTabHopNguyenLieu) ? T.bovatphamvao : T.hopNguyenLieu);
			GameCanvas.menu2.startAt_NPC(null, text, Menu2.IdNPCLast, 2, isQuest: false, 0);
		}
	}

	private void initReWing()
	{
		MainTabNew.timePaintInfo = 0;
		if (MainTabNew.longwidth > 0)
		{
			isShow = true;
		}
		if (!GameCanvas.isTouch)
		{
			if (!resetItemReplace && dataWing != null)
			{
				left = cmdView;
				cmdHoiReWing.caption = T.nangcap;
				if (itemWing == null)
				{
					cmdHoiReWing.caption = T.taoCanh;
				}
				center = cmdHoiReWing;
			}
			right = cmdBack;
		}
		else
		{
			vecListCmd.removeAllElements();
			if (!resetItemReplace && dataWing != null)
			{
				cmdHoiReWing.caption = T.nangcap;
				if (itemWing == null)
				{
					cmdHoiReWing.caption = T.taoCanh;
				}
				if (MainTabNew.longwidth > 0)
				{
					vecListCmd.addElement(cmdHoiReWing);
				}
				else
				{
					vecListCmd.addElement(cmdView);
					vecListCmd.addElement(cmdHoiReWing);
				}
			}
		}
		listContent = null;
		vecEffRe.removeAllElements();
		isBeginEff = 0;
		isNextRebuild = 0;
		if (resetItemReplace)
		{
			itemWing = null;
			resetItemReplace = false;
		}
	}

	public new void backTab()
	{
		if (MainTabNew.longwidth == 0)
		{
			isShow = false;
		}
		MainTabNew.timePaintInfo = 0;
		MainTabNew.Focus = MainTabNew.TAB;
		vecEffRe.removeAllElements();
		base.backTab();
	}

	public override void paint(mGraphics g)
	{
		if (isBeginEff == 0 && !GameCanvas.isTouch && MainTabNew.Focus == MainTabNew.INFO)
		{
			g.fillRect(xBegin + 2, yBegin + 2, MainTabNew.wblack - 4, MainTabNew.hblack - 4, mGraphics.isFalse);
		}
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, xBegin + 4, yBegin + 4, MainTabNew.wblack - 8, MainTabNew.hblack - 8, 4);
		}
		else
		{
			paintRect(g);
		}
		g.drawImage(imgStarRebuild, xBegin + MainTabNew.wblack / 2 - 54, yBegin + MainTabNew.hblack / 2 - 52, 0, mGraphics.isFalse);
		g.drawRegion(imgStarRebuild, 0, 0, 54, 105, 2, xBegin + MainTabNew.wblack / 2, yBegin + MainTabNew.hblack / 2 - 52, 0, mGraphics.isFalse);
		if (typeRebuild == TYPE_ANY)
		{
			paintAny(g);
		}
		else if (typeRebuild == TYPE_DUC_LO)
		{
			paintDucLo(g);
		}
		else if (typeRebuild == TYPE_GHEP_NGOC)
		{
			paintGhepNgoc(g);
		}
		else if (typeRebuild == TYPE_KHAM_NGOC)
		{
			paintKhamNgoc(g);
		}
		else if (typeRebuild == TYPE_REBUILD)
		{
			paintRebuild(g);
		}
		else if (typeRebuild == TYPE_REPLACE_PLUS)
		{
			paintReplace(g);
		}
		else if (typeRebuild == TYPE_REBUILD_WING)
		{
			paintReWing(g);
		}
		for (int i = 0; i < vecEffRe.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)vecEffRe.elementAt(i);
			mainEffect.paint(g);
		}
		if (isShow || MainTabNew.longwidth > 0)
		{
			paintInfo(g, xinfo, yinfo);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && (MainTabNew.Focus == MainTabNew.INFO || MainTabNew.longwidth > 0) && vecListCmd != null)
		{
			for (int j = 0; j < vecListCmd.size(); j++)
			{
				iCommand iCommand2 = (iCommand)vecListCmd.elementAt(j);
				iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
			}
		}
	}

	private void paintReWing(mGraphics g)
	{
		for (int i = 0; i < posMaterial.Length; i++)
		{
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, posMaterial[i][0] - 10, posMaterial[i][1] - 10, 20, 20, 2);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
			}
			if (i == 6)
			{
				if (itemWing != null)
				{
					itemWing.paintItem(g, posMaterial[6][0], posMaterial[6][1], 21, 1, 0);
					if (isBeginEff == 0)
					{
						mFont.tahoma_7_white.drawString(g, "Lv " + itemWing.tier, posMaterial[6][0], posMaterial[6][1] - 22, 2, mGraphics.isFalse);
					}
				}
			}
			else if (dataWing != null && i < dataWing.Length && isBeginEff == 0)
			{
				MainItem material = Item.getMaterial(dataWing[i].id);
				if (material != null)
				{
					material.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 0, 0);
					if (numWingMaterialInven[i] >= dataWing[i].valueWing)
					{
						mFont.tahoma_7_white.drawString(g, string.Empty + dataWing[i].valueWing, posMaterial[i][0], posMaterial[i][1] + 11, 2, mGraphics.isFalse);
					}
					else
					{
						mFont.tahoma_7_red.drawString(g, string.Empty + dataWing[i].valueWing, posMaterial[i][0], posMaterial[i][1] + 11, 2, mGraphics.isFalse);
					}
				}
				else
				{
					Item.put_Material(dataWing[i].id);
				}
			}
			g.drawImage(AvMain.imgHotKey, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
		}
	}

	public void paintAny(mGraphics g)
	{
		for (int i = 0; i < posMaterial.Length; i++)
		{
			if (isBeginEff != 0 && i != 5)
			{
				continue;
			}
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, posMaterial[i][0] - 10, posMaterial[i][1] - 10, 20, 20, 2);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
			}
			if (itemRe != null && i == 5 && (isBeginEff != 5 || time > 15))
			{
				if (itemRe.ItemCatagory == 7)
				{
					MainItem material = Item.getMaterial(itemRe.Id);
					if (material != null)
					{
						material.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 1, 0);
					}
					else
					{
						Item.put_Material(itemRe.Id);
					}
				}
				else
				{
					itemRe.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 1, 0);
				}
			}
			g.drawImage(AvMain.imgHotKey, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
		}
		for (int j = 0; j < vecGem.size(); j++)
		{
			MainItem mainItem = (MainItem)vecGem.elementAt(j);
			if (mainItem != null)
			{
				MainItem material2 = Item.getMaterial(mainItem.Id);
				if (material2 != null)
				{
					material2.paintItemNew(g, posMaterial[j][0], posMaterial[j][1], 21, 0, 0);
				}
				else
				{
					Item.put_Material(mainItem.Id);
				}
			}
		}
	}

	public static void addGem(MainItem item)
	{
		vecGem.addElement(item);
	}

	public static void removeKhamNgoc(Item item)
	{
		for (int i = 0; i < vecGem.size(); i++)
		{
			MainItem mainItem = (MainItem)vecGem.elementAt(i);
			if (mainItem != null && mainItem.Id == item.Id)
			{
				vecGem.removeElement(mainItem);
			}
		}
	}

	public static bool isKham(Item item)
	{
		for (int i = 0; i < vecGem.size(); i++)
		{
			MainItem mainItem = (MainItem)vecGem.elementAt(i);
			if (mainItem != null && mainItem.Id == item.Id)
			{
				return true;
			}
		}
		return false;
	}

	public void paintGhepNgoc(mGraphics g)
	{
		for (int i = 0; i < posMaterial.Length; i++)
		{
			if (isBeginEff != 0 && i != 5)
			{
				continue;
			}
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, posMaterial[i][0] - 10, posMaterial[i][1] - 10, 20, 20, 2);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
			}
			if (itemRe != null && i == 5 && (isBeginEff != 5 || time > 15))
			{
				MainItem material = Item.getMaterial(itemRe.Id);
				if (material != null)
				{
					material.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 1, 0);
				}
				else
				{
					Item.put_Material(itemRe.Id);
				}
			}
			g.drawImage(AvMain.imgHotKey, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
		}
		for (int j = 0; j < vecGem.size(); j++)
		{
			((MainItem)vecGem.elementAt(j))?.paintItemNew(g, posMaterial[j][0], posMaterial[j][1], 21, 0, 0);
		}
	}

	public void updateAny()
	{
		if (itemRe != null && countSetpaintinfo > 0)
		{
			setPaintInfo();
		}
		if (countSetpaintinfo > 0)
		{
			countSetpaintinfo--;
		}
		if (isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				left = null;
				center = null;
			}
			else
			{
				vecListCmd.removeAllElements();
			}
			if (itemRe != null)
			{
				vecEffRe.removeAllElements();
				sbyte b = itemRe.tier;
				if (b > 14)
				{
					b = 14;
				}
				for (int i = 0; i < dataRebuild[b].mValue.Length; i++)
				{
					if (dataRebuild[b].mValue[i] > 0)
					{
						addEffectEndRebuild(31, posMaterial[i][0], posMaterial[i][1], posMaterial[5][0], posMaterial[5][1], 1);
					}
				}
				if (isLucky)
				{
					addEffectEndRebuild(31, posMaterial[4][0], posMaterial[4][1], posMaterial[5][0], posMaterial[5][1], 1);
				}
			}
			isBeginEff = 2;
			time = 0L;
		}
		else if (isBeginEff == 2)
		{
			if (time < 10)
			{
				time++;
				if (time == 10)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
				return;
			}
			if (GameCanvas.timeNow - time > 12000)
			{
				time = GameCanvas.timeNow;
				addEffectRebuild(29, posMaterial[5][0], posMaterial[5][1], 12100);
			}
			if (GameCanvas.timeNow - time > 3700 && (isNextRebuild == 3 || isNextRebuild == 4))
			{
				isBeginEff = isNextRebuild;
				time = 0L;
			}
		}
		else if (isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(32, posMaterial[5][0], posMaterial[5][1] - 11);
			addEffectEnd_ReBuild_ss(33, posMaterial[5][0], posMaterial[5][1]);
			addEffectEnd_ReBuild_ss(34, posMaterial[5][0], posMaterial[5][1]);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(11, posMaterial[5][0], posMaterial[5][1]);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 5)
		{
			time++;
			if (vecEffRe.size() == 0 || time >= 100)
			{
				GameCanvas.menu2.startAt_NPC(null, contentShow, Menu2.IdNPCLast, 2, isQuest: false, 0);
				time = 0L;
				isBeginEff = 6;
				ispaintitemRe = true;
			}
		}
		else
		{
			if (isBeginEff != 6)
			{
				return;
			}
			if (itemRe.tier == 15)
			{
				itemRe = null;
			}
			if (isTabHopNguyenLieu && itemRe != null)
			{
				itemRe = null;
			}
			isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				left = cmdView;
				center = cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
				return;
			}
			vecListCmd.removeAllElements();
			if (itemRe != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					vecListCmd.addElement(cmdHoiDap);
					return;
				}
				vecListCmd.addElement(cmdView);
				vecListCmd.addElement(cmdHoiDap);
			}
		}
	}

	public void updateGhepngoc()
	{
		if (isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				left = null;
				center = null;
			}
			else
			{
				vecListCmd.removeAllElements();
			}
			if (itemRe != null)
			{
				vecEffRe.removeAllElements();
				for (int i = 0; i < dataRebuild[itemRe.tier].mValue.Length; i++)
				{
					if (dataRebuild[itemRe.tier].mValue[i] > 0)
					{
						addEffectEndRebuild(31, posMaterial[i][0], posMaterial[i][1], posMaterial[5][0], posMaterial[5][1], 1);
					}
				}
				if (isLucky)
				{
					addEffectEndRebuild(31, posMaterial[4][0], posMaterial[4][1], posMaterial[5][0], posMaterial[5][1], 1);
				}
			}
			isBeginEff = 2;
			time = 0L;
		}
		else if (isBeginEff == 2)
		{
			if (time < 10)
			{
				time++;
				if (time == 10)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
				return;
			}
			if (GameCanvas.timeNow - time > 12000)
			{
				time = GameCanvas.timeNow;
				addEffectRebuild(29, posMaterial[5][0], posMaterial[5][1], 12100);
			}
			if (GameCanvas.timeNow - time > 3700 && (isNextRebuild == 3 || isNextRebuild == 4))
			{
				isBeginEff = isNextRebuild;
				time = 0L;
			}
		}
		else if (isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(32, posMaterial[5][0], posMaterial[5][1] - 11);
			addEffectEnd_ReBuild_ss(33, posMaterial[5][0], posMaterial[5][1]);
			addEffectEnd_ReBuild_ss(34, posMaterial[5][0], posMaterial[5][1]);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(11, posMaterial[5][0], posMaterial[5][1]);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 5)
		{
			time++;
			if (vecEffRe.size() == 0 || time >= 100)
			{
				GameCanvas.menu2.startAt_NPC(null, contentShow, Menu2.IdNPCLast, 2, isQuest: false, 0);
				time = 0L;
				isBeginEff = 6;
				ispaintitemRe = true;
			}
		}
		else
		{
			if (isBeginEff != 6)
			{
				return;
			}
			if (itemRe.tier == 15)
			{
				itemRe = null;
			}
			if (isTabHopNguyenLieu && itemRe != null)
			{
				itemRe = null;
			}
			isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				left = cmdView;
				center = cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
				return;
			}
			vecListCmd.removeAllElements();
			if (itemRe != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					vecListCmd.addElement(cmdHoiDap);
					return;
				}
				vecListCmd.addElement(cmdView);
				vecListCmd.addElement(cmdHoiDap);
			}
		}
	}

	public void paintKhamNgoc(mGraphics g)
	{
		for (int i = 0; i < posMaterial.Length; i++)
		{
			if (isBeginEff == 0 || i == 5)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, posMaterial[i][0] - 10, posMaterial[i][1] - 10, 20, 20, 2);
				}
				else
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
				}
				if (itemRe != null && i == 5 && (isBeginEff != 5 || time > 15))
				{
					itemRe.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 1, 0);
				}
				g.drawImage(AvMain.imgHotKey, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
			}
		}
		for (int j = 0; j < vecGem.size(); j++)
		{
			((MainItem)vecGem.elementAt(j))?.paintItemNew(g, posMaterial[j][0], posMaterial[j][1], 21, 0, 0);
		}
	}

	public void paintDucLo(mGraphics g)
	{
		for (int i = 0; i < posMaterial.Length; i++)
		{
			if (isBeginEff == 0 || i == 5)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, posMaterial[i][0] - 10, posMaterial[i][1] - 10, 20, 20, 2);
				}
				else
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
				}
				if (itemRe != null && i == 5 && (isBeginEff != 5 || time > 15))
				{
					itemRe.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 1, 0);
				}
				g.drawImage(AvMain.imgHotKey, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
			}
		}
		for (int j = 0; j < vecGem.size(); j++)
		{
			((MainItem)vecGem.elementAt(j))?.paintItemNew(g, posMaterial[j][0], posMaterial[j][1], 21, 0, 0);
		}
	}

	public void paintRebuild(mGraphics g)
	{
		for (int i = 0; i < posMaterial.Length; i++)
		{
			if (isBeginEff != 0 && i != 5)
			{
				continue;
			}
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, posMaterial[i][0] - 10, posMaterial[i][1] - 10, 20, 20, 2);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
			}
			if (itemRe != null)
			{
				if (isTabHopNguyenLieu)
				{
					if (i < 5)
					{
						itemRe.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 1, 0);
					}
					else if (itemRe.itemClone != null)
					{
						MainItem material = Item.getMaterial(itemRe.itemClone.Id);
						if (material != null)
						{
							material.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 1, 0);
						}
						else
						{
							Item.put_Material(itemRe.itemClone.Id);
						}
					}
				}
				else if (i < 5)
				{
					MainItem material2 = Item.getMaterial(idMaterial[i]);
					if (material2 != null)
					{
						if ((material2.typeMaterial == 11 && isLucky) || (i < 4 && dataRebuild[itemRe.tier].mValue[i] > 0))
						{
							if (material2.typeMaterial == 11 && isLucky && itemDaMayMan != null)
							{
								itemDaMayMan.paintItem_notnum(g, posMaterial[i][0], posMaterial[i][1], 21, 0, 0);
							}
							else
							{
								material2.paintItem_notnum(g, posMaterial[i][0], posMaterial[i][1], 21, 0, 0);
							}
						}
					}
					else
					{
						Item.put_Material(idMaterial[i]);
					}
				}
				else if (i == 5)
				{
					if (isBeginEff != 5 || time > 15)
					{
						itemRe.paintItem(g, posMaterial[i][0], posMaterial[i][1], 21, 1, 0);
					}
					if (isBeginEff == 0)
					{
						mFont.tahoma_7_white.drawString(g, "Lv " + itemRe.tier, posMaterial[i][0], posMaterial[i][1] - 22, 2, mGraphics.isFalse);
					}
				}
			}
			g.drawImage(AvMain.imgHotKey, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
			if (itemRe != null)
			{
				if (i < 4 && dataRebuild[itemRe.tier].mValue[i] > numMaterialInven[i])
				{
					g.drawImage(AvMain.imgHotKey2, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
				}
				else if (i == 5 && isBeginEff == 5 && isNextRebuild == 4)
				{
					g.drawImage(AvMain.imgHotKey2, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
				}
			}
		}
	}

	public void paintRect(mGraphics g)
	{
		for (int i = 0; i <= maxw; i++)
		{
			for (int j = 0; j <= maxh; j++)
			{
				indexPaint = 12;
				if (j == 0)
				{
					indexPaint = 12;
				}
				if (i == maxw)
				{
					if (j == maxh)
					{
						g.drawImage(MainTabNew.imgTab[indexPaint], xBegin + 4 + (MainTabNew.wblack - 8) - 32, yBegin + 4 + MainTabNew.hblack - 8 - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[indexPaint], xBegin + 4 + (MainTabNew.wblack - 8) - 32, yBegin + 4 + j * 32, 0, mGraphics.isFalse);
					}
				}
				else if (j == maxh)
				{
					g.drawImage(MainTabNew.imgTab[indexPaint], xBegin + 4 + i * 32, yBegin + 4 + MainTabNew.hblack - 8 - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[indexPaint], xBegin + 4 + i * 32, yBegin + 4 + j * 32, 0, mGraphics.isFalse);
				}
			}
		}
	}

	public void paintInfo(mGraphics g, int x, int y)
	{
		if (typeRebuild == TYPE_ANY)
		{
			paintinfoAny(g, x, y);
			if ((itemRe == null && isCreate_medal) || (itemRe != null && isUPgradeMedal))
			{
				paintconTenAny(g, x, y - 10);
			}
		}
		else if (typeRebuild == TYPE_GHEP_NGOC)
		{
			paintinfoGhepNgoc(g, x, y);
		}
		else if (typeRebuild == TYPE_KHAM_NGOC || typeRebuild == TYPE_DUC_LO)
		{
			paintinfoKhamNgoc(g, x, y);
		}
		else if (typeRebuild == TYPE_REBUILD)
		{
			paintInfoRebuild(g, x, y);
		}
		else if (typeRebuild == TYPE_REPLACE_PLUS)
		{
			if (!resetItemReplace)
			{
				paintInfoReplace(g, x, y);
			}
		}
		else if (typeRebuild == TYPE_REBUILD_WING)
		{
			paintInfoReWing(g, x, y);
		}
	}

	private void paintInfoReWing(mGraphics g, int x, int y)
	{
		if (dataWing == null)
		{
			return;
		}
		int hText = GameCanvas.hText;
		if (MainTabNew.longwidth > 0)
		{
			MainTabNew.paintNameItem(g, x + MainTabNew.longwidth / 2, y - MainTabNew.wOneItem / 4, MainTabNew.longwidth, nameWing, 5);
			y += MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
		}
		else
		{
			paintFormList(g, x, y, winfo, 150, nameWing);
			y += GameCanvas.hCommand + 2;
			x += 4;
		}
		mFont.tahoma_7_white.drawString(g, T.LVyeucau + lvReWing, x, y, 0, mGraphics.isFalse);
		y += hText;
		mFont.tahoma_7_white.drawString(g, T.timeyeucau + PaintInfoGameScreen.getStringTime(timeUseWing), x, y, 0, mGraphics.isFalse);
		y += hText;
		for (int i = 0; i < dataWing.Length; i++)
		{
			MainItem material = Item.getMaterial(dataWing[i].id);
			if (material != null)
			{
				mFont mFont2 = mFont.tahoma_7_white;
				if (dataWing[i].valueWing > numWingMaterialInven[i])
				{
					mFont2 = mFont.tahoma_7_red;
				}
				if (material.itemName != null)
				{
					mFont2.drawString(g, material.itemName, x + 4, y, 0, mGraphics.isFalse);
				}
				mFont2.drawString(g, dataWing[i].valueWing + "/" + numWingMaterialInven[i], x + winfo / 2 + 10, y, 0, mGraphics.isFalse);
				y += hText;
			}
			else
			{
				Item.put_Material(dataWing[i].id);
			}
		}
	}

	public void paintinfoAny(mGraphics g, int x, int y)
	{
		if (itemRe == null)
		{
			return;
		}
		if (MainTabNew.longwidth > 0 && itemRe.itemName != null)
		{
			MainTabNew.paintNameItem(g, x + MainTabNew.longwidth / 2, y - MainTabNew.wOneItem / 4, MainTabNew.longwidth, itemRe.itemName, itemRe.colorNameItem);
			y += MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
			return;
		}
		if (itemRe.itemName != null)
		{
			paintFormList(g, x, y, winfo, 150, itemRe.itemName);
		}
		y += GameCanvas.hCommand + 2;
		x += 4;
	}

	public void paintconTenAny(mGraphics g, int x, int y)
	{
		int num = GameCanvas.hText - 2;
		if (MainTabNew.longwidth > 0)
		{
			y += MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
		}
		else
		{
			if (itemRe != null && itemRe.itemName != null)
			{
				paintFormList(g, x, y, winfo, 150, itemRe.itemName);
			}
			y += GameCanvas.hCommand + 2;
			x += 4;
		}
		y += num;
		GameCanvas.resetTrans(g);
		scr.setStyle(vecGem.size() + 2, GameCanvas.hText + 2, x, y - GameCanvas.hText * 2, winfo, num * (vecGem.size() + 1) * 2, styleUPDOWN: true, 1);
		scr.setClip(g, x, y, winfo, num * (vecGem.size() + 1) * 2);
		mFont.tahoma_7b_white.drawString(g, T.nguyenlieu, x, y, 0, mGraphics.isTrue);
		y += num;
		for (int i = 0; i < vecGem.size(); i++)
		{
			MainItem mainItem = (MainItem)vecGem.elementAt(i);
			if (mainItem == null)
			{
				continue;
			}
			MainItem material = Item.getMaterial(mainItem.Id);
			if (material != null)
			{
				mFont mFont2 = mFont.tahoma_7_green;
				if (material.itemName != null && !material.itemName.Equals(string.Empty))
				{
					MainTabNew.setTextColorName(material.colorNameItem).drawString(g, material.itemName, x + 4, y, 0, mGraphics.isTrue);
				}
				if (numColor[i] == 0)
				{
					mFont2 = mFont.tahoma_7_red;
				}
				y += num;
				mFont.tahoma_7_white.drawString(g, T.soluong + " ", x + 4, y, 0, mGraphics.isTrue);
				mFont2.drawString(g, numofGem[i], x + 50, y, 0, mGraphics.isTrue);
				y += num;
			}
			else
			{
				Item.put_Material(mainItem.Id);
			}
		}
		GameCanvas.resetTrans(g);
	}

	private void paintInfoReplace(mGraphics g, int x, int y)
	{
		if (itemPlus != null && itemFree != null)
		{
			int hText = GameCanvas.hText;
			if (MainTabNew.longwidth > 0)
			{
				mFont.tahoma_7b_white.drawString(g, T.replace, x + MainTabNew.longwidth / 2, y - MainTabNew.wOneItem / 4, 2, mGraphics.isFalse);
				y += MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
				x += 4;
			}
			else
			{
				paintFormList(g, x, y, winfo, 100, T.replace);
				y += GameCanvas.hCommand + 2;
				x += 4;
			}
			MainTabNew.setTextColor(itemPlus.colorNameItem).drawString(g, itemPlus.itemName, x, y, 0, mGraphics.isFalse);
			y += hText;
			MainTabNew.setTextColor(itemFree.colorNameItem).drawString(g, itemFree.itemName, x, y, 0, mGraphics.isFalse);
			y += hText;
			mFont.tahoma_7_white.drawString(g, T.plusnhanduoc, x, y, 0, mGraphics.isFalse);
			y += hText;
			mFont.tahoma_7b_white.drawString(g, itemPlus.tier - 2 + " > " + itemPlus.tier, x, y, 0, mGraphics.isFalse);
		}
	}

	public void paintinfoKhamNgoc(mGraphics g, int x, int y)
	{
		if (itemRe != null)
		{
			paintContentNew(g, isOnlyName: false);
		}
	}

	public void paintinfoGhepNgoc(mGraphics g, int x, int y)
	{
		if (itemRe == null)
		{
			return;
		}
		if (MainTabNew.longwidth > 0 && itemRe.itemName != null)
		{
			MainTabNew.paintNameItem(g, x + MainTabNew.longwidth / 2, y - MainTabNew.wOneItem / 4, MainTabNew.longwidth, itemRe.itemName, itemRe.colorNameItem);
			y += MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
			return;
		}
		if (itemRe.itemName != null)
		{
			paintFormList(g, x, y, winfo, 150, itemRe.itemName);
		}
		y += GameCanvas.hCommand + 2;
		x += 4;
	}

	public void paintInfoRebuild(mGraphics g, int x, int y)
	{
		if (itemRe == null)
		{
			return;
		}
		int num = GameCanvas.hText - 2;
		if (MainTabNew.longwidth > 0)
		{
			if (itemRe.itemName != null)
			{
				MainTabNew.paintNameItem(g, x + MainTabNew.longwidth / 2, y - MainTabNew.wOneItem / 4, MainTabNew.longwidth, itemRe.itemName, itemRe.colorNameItem);
			}
			if (itemRe.tier >= 15)
			{
				return;
			}
			y += MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
		}
		else
		{
			paintFormList(g, x, y, winfo, 150, itemRe.itemName);
			y += GameCanvas.hCommand + 2;
			x += 4;
		}
		if (isTabHopNguyenLieu)
		{
			if (itemRe.itemClone != null)
			{
				string[] array = null;
				int num2 = 0;
				int width = mFont.tahoma_7b_blue.getWidth(itemRe.infoHop[0]);
				array = mFont.tahoma_7b_blue.splitFontArray(itemRe.infoHop[0], (MainTabNew.longwidth != 0) ? MainTabNew.longwidth : ((maxw - 1) * 32));
				num2 = array.Length;
				for (int i = 0; i < num2; i++)
				{
					mFont.tahoma_7b_blue.drawString(g, array[i], x, y, 0, mGraphics.isFalse);
					y += num;
				}
				mFont.tahoma_7b_white.drawString(g, T.chiphi, x, y, 0, mGraphics.isFalse);
				y += num - 2;
				mFont.tahoma_7_white.drawString(g, itemRe.infoHop[1], x + 4, y, 0, mGraphics.isFalse);
			}
			return;
		}
		if (itemRe.tier < 15)
		{
			mFont.tahoma_7b_blue.drawString(g, "+" + itemRe.tier + " > +" + (itemRe.tier + 1), x, y, 0, mGraphics.isFalse);
		}
		y += num;
		mFont.tahoma_7b_white.drawString(g, T.nguyenlieu, x, y, 0, mGraphics.isFalse);
		y += num;
		for (int j = 0; j < dataRebuild[itemRe.tier].mValue.Length; j++)
		{
			mFont mFont2 = mFont.tahoma_7_white;
			if (dataRebuild[itemRe.tier].mValue[j] > numMaterialInven[j])
			{
				mFont2 = mFont.tahoma_7_red;
			}
			MainItem material = Item.getMaterial(idMaterial[j]);
			if (material != null)
			{
				mNameMaterial[j] = material.itemName;
			}
			else
			{
				Item.put_Material(idMaterial[j]);
			}
			if (mNameMaterial[j] != null)
			{
				mFont2.drawString(g, mNameMaterial[j], x + 4, y, 0, mGraphics.isFalse);
			}
			mFont2.drawString(g, dataRebuild[itemRe.tier].mValue[j] + "/" + numMaterialInven[j], x + winfo / 2 + 10, y, 0, mGraphics.isFalse);
			y += num;
		}
		mFont.tahoma_7b_white.drawString(g, T.tilemayman, x, y, 0, mGraphics.isFalse);
		y += num;
		mFont.tahoma_7_white.drawString(g, tilemayman, x + 4, y, 0, mGraphics.isFalse);
		y += num;
		mFont.tahoma_7b_white.drawString(g, T.chiphi, x, y, 0, mGraphics.isFalse);
		y += num - 2;
		paintPrice(g, x, y);
	}

	public void paintPrice(mGraphics g, int x, int y)
	{
		if (dataRebuild[itemRe.tier].priceCoin == 0)
		{
			mFont.tahoma_7_white.drawString(g, dataRebuild[itemRe.tier].priceGold + " " + T.gem, x + 4, y, 0, mGraphics.isFalse);
			return;
		}
		if (dataRebuild[itemRe.tier].priceGold == 0)
		{
			mFont.tahoma_7_white.drawString(g, dataRebuild[itemRe.tier].priceCoin + " " + T.coin, x + 4, y, 0, mGraphics.isFalse);
			return;
		}
		mFont.tahoma_7_white.drawString(g, dataRebuild[itemRe.tier].priceCoin + " " + T.coin + T.hoac + dataRebuild[itemRe.tier].priceGold + " " + T.gem, x + 4, y, 0, mGraphics.isFalse);
	}

	public void paintReplace(mGraphics g)
	{
		for (int i = 0; i < posMaterial.Length; i++)
		{
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, posMaterial[i][0] - 10, posMaterial[i][1] - 10, 20, 20, 2);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
			}
			if (itemPlus != null && i == 0)
			{
				itemPlus.paintItem(g, posMaterial[0][0], posMaterial[0][1], 21, 1, 0);
				if (isBeginEff == 0)
				{
					mFont.tahoma_7_white.drawString(g, "Lv " + itemPlus.tier, posMaterial[0][0], posMaterial[0][1] - 22, 2, mGraphics.isFalse);
				}
			}
			if (itemFree != null && i == 1)
			{
				itemFree.paintItem(g, posMaterial[1][0], posMaterial[1][1], 21, 1, 0);
				if (isBeginEff == 0)
				{
					mFont.tahoma_7_white.drawString(g, "Lv " + itemFree.tier, posMaterial[1][0], posMaterial[1][1] - 22, 2, mGraphics.isFalse);
				}
			}
			g.drawImage(AvMain.imgHotKey, posMaterial[i][0], posMaterial[i][1], 3, mGraphics.isFalse);
		}
	}

	public override void updatekey()
	{
		if (isBeginEff == 0)
		{
			if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6])
			{
				MainTabNew.Focus = MainTabNew.TAB;
				GameCanvas.clearKeyHold();
			}
			base.updatekey();
		}
	}

	public override void update()
	{
		if (typeRebuild == TYPE_REBUILD)
		{
			updateRebuild();
			if (isTabHopNguyenLieu)
			{
				cmdHoiDap.caption = T.hopThanh;
				cmdHoiDap.indexMenu = 7;
			}
			else
			{
				cmdHoiDap.caption = T.dapdo;
				cmdHoiDap.indexMenu = 0;
			}
		}
		else if (typeRebuild == TYPE_REPLACE_PLUS)
		{
			updateReplace();
		}
		else if (typeRebuild == TYPE_REBUILD_WING)
		{
			updateReWing();
		}
		else if (typeRebuild == TYPE_KHAM_NGOC)
		{
			updateKhamNgoc();
			cmdHoiDap.caption = T.khamNgoc;
			cmdHoiDap.indexMenu = 0;
		}
		else if (typeRebuild == TYPE_GHEP_NGOC)
		{
			updateGhepngoc();
			cmdHoiDap.caption = T.hopngoc;
			cmdHoiDap.indexMenu = 0;
		}
		else if (typeRebuild == TYPE_DUC_LO)
		{
			updateDucLo();
			cmdHoiDap.caption = T.DucLo;
			cmdHoiDap.indexMenu = 0;
		}
		else if (typeRebuild == TYPE_ANY)
		{
			ScrollResult scrollResult = scr.updateKey();
			if (scrollResult.isDowning || scrollResult.isFinish)
			{
			}
			if (scrollResult.isFinish || GameCanvas.isKeyPressed(5))
			{
			}
			scr.updatecm();
			updateAny();
			cmdHoiDap.caption = T.hoprac;
			cmdHoiDap.indexMenu = 0;
		}
		for (int i = 0; i < vecEffRe.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)vecEffRe.elementAt(i);
			mainEffect.update();
			if (mainEffect.isStop)
			{
				vecEffRe.removeElement(mainEffect);
			}
		}
	}

	private void updateReWing()
	{
		if (isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				left = null;
				center = null;
			}
			else
			{
				vecListCmd.removeAllElements();
			}
			if (dataWing != null)
			{
				vecEffRe.removeAllElements();
				for (int i = 0; i < dataWing.Length; i++)
				{
					addEffectEndRebuild(31, posMaterial[i][0], posMaterial[i][1], posMaterial[6][0], posMaterial[6][1], 1);
				}
			}
			isBeginEff = 2;
			time = 0L;
		}
		else if (isBeginEff == 2)
		{
			if (time < 10)
			{
				time++;
				if (time == 10)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
				return;
			}
			if (GameCanvas.timeNow - time > 12000)
			{
				time = GameCanvas.timeNow;
				addEffectRebuild(29, posMaterial[6][0], posMaterial[6][1], 12100);
			}
			if (GameCanvas.timeNow - time > 3700)
			{
				isBeginEff = 3;
				time = 0L;
			}
		}
		else if (isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			vecEffRe.removeAllElements();
			if (itemWing != null)
			{
				addEffectEnd_ReBuild_ss(32, posMaterial[6][0], posMaterial[6][1] - 11);
			}
			addEffectEnd_ReBuild_ss(33, posMaterial[6][0], posMaterial[6][1]);
			addEffectEnd_ReBuild_ss(34, posMaterial[6][0], posMaterial[6][1]);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 5)
		{
			time++;
			MainItem mainItem = (MainItem)Item.getItemInventory(3, idWingOk);
			if (mainItem != null)
			{
				itemWing = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, isTem: false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
			}
			else
			{
				itemWing = null;
			}
			if (vecEffRe.size() == 0 || time >= 100)
			{
				GameCanvas.menu2.startAt_NPC(null, contentShow, Menu2.IdNPCLast, 2, isQuest: false, 0);
				time = 0L;
				isBeginEff = 6;
			}
		}
		else if (isBeginEff == 6)
		{
			dataWing = null;
			resetItemReplace = true;
			isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				left = null;
				center = null;
				MainTabNew.Focus = MainTabNew.TAB;
			}
			else
			{
				vecListCmd.removeAllElements();
			}
		}
	}

	private void updateReplace()
	{
		if (isBeginEff == 1)
		{
			if (itemPlus == null || itemFree == null)
			{
				isBeginEff = 0;
				return;
			}
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				left = null;
				center = null;
			}
			else
			{
				vecListCmd.removeAllElements();
			}
			vecEffRe.removeAllElements();
			addEffectEndRebuild(37, posMaterial[0][0], posMaterial[0][1], posMaterial[1][0], posMaterial[1][1], itemPlus.tier);
			timeShowReplace = itemPlus.tier * 120;
			isBeginEff = 2;
			time = 0L;
		}
		else if (isBeginEff == 2)
		{
			if (time < 10)
			{
				time++;
				if (time == 10)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
				return;
			}
			if (time == 10)
			{
				time = GameCanvas.timeNow;
				addEffectRebuild(29, posMaterial[1][0], posMaterial[1][1], 1200 + timeShowReplace);
			}
			if (GameCanvas.timeNow - time > 2000 + timeShowReplace)
			{
				vecEffRe.removeAllElements();
				isBeginEff = 3;
				time = 0L;
			}
		}
		else
		{
			if (isBeginEff != 3)
			{
				return;
			}
			mSound.playSound(26, mSound.volumeSound);
			GameCanvas.menu2.startAt_NPC(null, contentShow, Menu2.IdNPCLast, 2, isQuest: false, 0);
			if (itemPlus != null)
			{
				MainItem mainItem = (MainItem)Item.getItemInventory(itemPlus.ItemCatagory, (short)itemPlus.Id);
				if (mainItem != null)
				{
					itemPlus = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, isTem: false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
				}
				else
				{
					itemPlus = null;
				}
			}
			if (itemFree != null)
			{
				MainItem mainItem2 = (MainItem)Item.getItemInventory(itemFree.ItemCatagory, (short)itemFree.Id);
				if (mainItem2 != null)
				{
					itemFree = MainItem.MainItem_Item(mainItem2.Id, mainItem2.itemNameExcludeLv, mainItem2.imageId, mainItem2.tier, mainItem2.colorNameItem, mainItem2.classcharItem, mainItem2.ItemCatagory, mainItem2.mInfo, mainItem2.type_Only_Item, isTem: false, mainItem2.IdTem, mainItem2.priceItem, (short)mainItem2.LvItem, mainItem2.canSell, mainItem2.canTrade, mainItem2.timeUse, 0, 0);
				}
				else
				{
					itemFree = null;
				}
			}
			isBeginEff = 0;
			resetItemReplace = true;
			vecListCmd.removeAllElements();
			isShow = false;
			center = null;
			left = null;
		}
	}

	public void updateKhamNgoc()
	{
		if (itemRe != null && countSetpaintinfo > 0)
		{
			setPaintInfo();
		}
		if (countSetpaintinfo > 0)
		{
			countSetpaintinfo--;
		}
		if (isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				left = null;
				center = null;
			}
			else
			{
				vecListCmd.removeAllElements();
			}
			if (itemRe != null)
			{
				vecEffRe.removeAllElements();
				sbyte b = itemRe.tier;
				if (b > 14)
				{
					b = 14;
				}
				for (int i = 0; i < dataRebuild[b].mValue.Length; i++)
				{
					if (dataRebuild[b].mValue[i] > 0)
					{
						addEffectEndRebuild(31, posMaterial[i][0], posMaterial[i][1], posMaterial[5][0], posMaterial[5][1], 1);
					}
				}
				if (isLucky)
				{
					addEffectEndRebuild(31, posMaterial[4][0], posMaterial[4][1], posMaterial[5][0], posMaterial[5][1], 1);
				}
			}
			isBeginEff = 2;
			time = 0L;
		}
		else if (isBeginEff == 2)
		{
			if (time < 10)
			{
				time++;
				if (time == 10)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
				return;
			}
			if (GameCanvas.timeNow - time > 12000)
			{
				time = GameCanvas.timeNow;
				addEffectRebuild(29, posMaterial[5][0], posMaterial[5][1], 12100);
			}
			if (GameCanvas.timeNow - time > 3700 && (isNextRebuild == 3 || isNextRebuild == 4))
			{
				isBeginEff = isNextRebuild;
				time = 0L;
			}
		}
		else if (isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(32, posMaterial[5][0], posMaterial[5][1] - 11);
			addEffectEnd_ReBuild_ss(33, posMaterial[5][0], posMaterial[5][1]);
			addEffectEnd_ReBuild_ss(34, posMaterial[5][0], posMaterial[5][1]);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(11, posMaterial[5][0], posMaterial[5][1]);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 5)
		{
			time++;
			MainItem mainItem = (MainItem)Item.getItemInventory(itemRe.ItemCatagory, (short)itemRe.Id);
			if (!isTabHopNguyenLieu)
			{
				if (mainItem != null)
				{
					itemRe = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, isTem: false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
				}
				else
				{
					itemRe = null;
				}
			}
			tilemayman = tilemaymanafter;
			if (vecEffRe.size() == 0 || time >= 100)
			{
				GameCanvas.menu2.startAt_NPC(null, contentShow, Menu2.IdNPCLast, 2, isQuest: false, 0);
				time = 0L;
				isBeginEff = 6;
			}
			countSetpaintinfo = 1;
		}
		else
		{
			if (isBeginEff != 6)
			{
				return;
			}
			if (itemRe.tier == 15)
			{
				itemRe = null;
			}
			if (isTabHopNguyenLieu && itemRe != null)
			{
				itemRe = null;
			}
			isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				left = cmdView;
				center = cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
				return;
			}
			vecListCmd.removeAllElements();
			if (itemRe != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					vecListCmd.addElement(cmdHoiDap);
					return;
				}
				vecListCmd.addElement(cmdView);
				vecListCmd.addElement(cmdHoiDap);
			}
		}
	}

	public void updateDucLo()
	{
		if (itemRe != null && countSetpaintinfo > 0)
		{
			setPaintInfo();
		}
		if (countSetpaintinfo > 0)
		{
			countSetpaintinfo--;
		}
		if (isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				left = null;
				center = null;
			}
			else
			{
				vecListCmd.removeAllElements();
			}
			if (itemRe != null)
			{
				vecEffRe.removeAllElements();
				sbyte b = itemRe.tier;
				if (b > 14)
				{
					b = 14;
				}
				for (int i = 0; i < dataRebuild[b].mValue.Length; i++)
				{
					if (dataRebuild[b].mValue[i] > 0)
					{
						addEffectEndRebuild(31, posMaterial[i][0], posMaterial[i][1], posMaterial[5][0], posMaterial[5][1], 1);
					}
				}
				if (isLucky)
				{
					addEffectEndRebuild(31, posMaterial[4][0], posMaterial[4][1], posMaterial[5][0], posMaterial[5][1], 1);
				}
			}
			isBeginEff = 2;
			time = 0L;
		}
		else if (isBeginEff == 2)
		{
			if (time < 10)
			{
				time++;
				if (time == 10)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
				return;
			}
			if (GameCanvas.timeNow - time > 12000)
			{
				time = GameCanvas.timeNow;
				addEffectRebuild(29, posMaterial[5][0], posMaterial[5][1], 12100);
			}
			if (GameCanvas.timeNow - time > 3700 && (isNextRebuild == 3 || isNextRebuild == 4))
			{
				isBeginEff = isNextRebuild;
				time = 0L;
			}
		}
		else if (isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(32, posMaterial[5][0], posMaterial[5][1] - 11);
			addEffectEnd_ReBuild_ss(33, posMaterial[5][0], posMaterial[5][1]);
			addEffectEnd_ReBuild_ss(34, posMaterial[5][0], posMaterial[5][1]);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(11, posMaterial[5][0], posMaterial[5][1]);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 5)
		{
			time++;
			MainItem mainItem = (MainItem)Item.getItemInventory(itemRe.ItemCatagory, (short)itemRe.Id);
			if (!isTabHopNguyenLieu)
			{
				if (mainItem != null)
				{
					itemRe = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, isTem: false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
				}
				else
				{
					itemRe = null;
				}
			}
			tilemayman = tilemaymanafter;
			if (vecEffRe.size() == 0 || time >= 100)
			{
				GameCanvas.menu2.startAt_NPC(null, contentShow, Menu2.IdNPCLast, 2, isQuest: false, 0);
				time = 0L;
				isBeginEff = 6;
			}
			countSetpaintinfo = 1;
		}
		else
		{
			if (isBeginEff != 6)
			{
				return;
			}
			if (itemRe.tier == 15)
			{
				itemRe = null;
			}
			if (isTabHopNguyenLieu && itemRe != null)
			{
				itemRe = null;
			}
			isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				left = cmdView;
				center = cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
				return;
			}
			vecListCmd.removeAllElements();
			if (itemRe != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					vecListCmd.addElement(cmdHoiDap);
					return;
				}
				vecListCmd.addElement(cmdView);
				vecListCmd.addElement(cmdHoiDap);
			}
		}
	}

	public void updateRebuild()
	{
		if (isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				left = null;
				center = null;
			}
			else
			{
				vecListCmd.removeAllElements();
			}
			if (itemRe != null)
			{
				vecEffRe.removeAllElements();
				for (int i = 0; i < dataRebuild[itemRe.tier].mValue.Length; i++)
				{
					if (dataRebuild[itemRe.tier].mValue[i] > 0)
					{
						addEffectEndRebuild(31, posMaterial[i][0], posMaterial[i][1], posMaterial[5][0], posMaterial[5][1], 1);
					}
				}
				if (isLucky)
				{
					addEffectEndRebuild(31, posMaterial[4][0], posMaterial[4][1], posMaterial[5][0], posMaterial[5][1], 1);
				}
			}
			isBeginEff = 2;
			time = 0L;
		}
		else if (isBeginEff == 2)
		{
			if (time < 10)
			{
				time++;
				if (time == 10)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
				return;
			}
			if (GameCanvas.timeNow - time > 12000)
			{
				time = GameCanvas.timeNow;
				addEffectRebuild(29, posMaterial[5][0], posMaterial[5][1], 12100);
			}
			if (GameCanvas.timeNow - time > 3700 && (isNextRebuild == 3 || isNextRebuild == 4))
			{
				isBeginEff = isNextRebuild;
				time = 0L;
			}
		}
		else if (isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(32, posMaterial[5][0], posMaterial[5][1] - 11);
			addEffectEnd_ReBuild_ss(33, posMaterial[5][0], posMaterial[5][1]);
			addEffectEnd_ReBuild_ss(34, posMaterial[5][0], posMaterial[5][1]);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(11, posMaterial[5][0], posMaterial[5][1]);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			addEffectRebuild(69, posMaterial[5][0], posMaterial[5][1] - 11, 300);
			isBeginEff = 5;
			time = 0L;
		}
		else if (isBeginEff == 5)
		{
			time++;
			MainItem mainItem = (MainItem)Item.getItemInventory(itemRe.ItemCatagory, (short)itemRe.Id);
			if (!isTabHopNguyenLieu)
			{
				if (mainItem != null)
				{
					itemRe = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, isTem: false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
				}
				else
				{
					itemRe = null;
				}
			}
			tilemayman = tilemaymanafter;
			if (vecEffRe.size() == 0 || time >= 100)
			{
				GameCanvas.menu2.startAt_NPC(null, contentShow, Menu2.IdNPCLast, 2, isQuest: false, 0);
				time = 0L;
				isBeginEff = 6;
			}
		}
		else
		{
			if (isBeginEff != 6)
			{
				return;
			}
			if (itemRe.tier == 15)
			{
				itemRe = null;
			}
			if (isTabHopNguyenLieu && itemRe != null)
			{
				itemRe = null;
			}
			isBeginEff = 0;
			if (isLucky)
			{
				checkAddIsLucky();
			}
			if (!GameCanvas.isTouch)
			{
				left = cmdView;
				center = cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
				return;
			}
			vecListCmd.removeAllElements();
			if (itemRe != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					vecListCmd.addElement(cmdHoiDap);
					return;
				}
				vecListCmd.addElement(cmdView);
				vecListCmd.addElement(cmdHoiDap);
			}
		}
	}

	public override void updatePointer()
	{
		if (isBeginEff != 0)
		{
			return;
		}
		if (vecListCmd != null && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && (MainTabNew.Focus == MainTabNew.INFO || MainTabNew.longwidth > 0))
		{
			for (int i = 0; i < vecListCmd.size(); i++)
			{
				iCommand iCommand2 = (iCommand)vecListCmd.elementAt(i);
				iCommand2.updatePointer();
			}
		}
		base.updatePointer();
	}

	public static void addEffectEndRebuild(int type, int x, int y, int xTo, int yTo, int num)
	{
		EffectEnd o = new EffectEnd(type, x, y, xTo, yTo, num);
		vecEffRe.addElement(o);
	}

	public static void addEffectEnd_ReBuild_ss(int type, int x, int y)
	{
		EffectEnd o = new EffectEnd(type, x, y);
		vecEffRe.addElement(o);
	}

	public void addEffectRebuild(int type, int x, int y, int time)
	{
		EffectSkill o = new EffectSkill(type, x, y, time, 0, 0);
		vecEffRe.addElement(o);
	}

	public void checkAddIsLucky()
	{
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
			if (mainItem.ItemCatagory == 7 && mainItem.typeMaterial == 11 && itemDaMayMan != null && itemDaMayMan.Id == mainItem.Id)
			{
				GlobalService.gI().Rebuild_Item(0, (short)mainItem.Id, (sbyte)mainItem.ItemCatagory);
				return;
			}
		}
		isLucky = false;
	}
}
