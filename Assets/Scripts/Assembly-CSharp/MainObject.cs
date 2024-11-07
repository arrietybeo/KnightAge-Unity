using System;
using System.Collections;

public class MainObject : AvMain
{
	public const sbyte DIR_UP = 1;

	public const sbyte DIR_DOWN = 0;

	public const sbyte DIR_LEFT = 2;

	public const sbyte DIR_RIGHT = 3;

	public const sbyte AC_STAND = 0;

	public const sbyte AC_MOVE = 1;

	public const sbyte AC_FIRE = 2;

	public const sbyte AC_HIT = 3;

	public const sbyte AC_DIE = 4;

	public const sbyte CAT_PLAYER = 0;

	public const sbyte CAT_MONSTER = 1;

	public const sbyte CAT_NPC = 2;

	public const sbyte CAT_ITEM = 3;

	public const sbyte CAT_POTION = 4;

	public const sbyte CAT_QUEST_ITEM = 5;

	public const sbyte CAT_ITEM_TOC = 6;

	public const sbyte CAT_MATERIAL = 7;

	public const sbyte CAT_ICON_CLAN = 8;

	public const sbyte CAT_PET = 9;

	public const sbyte CAT_MOUNT = 10;

	public const sbyte SPEC_NORMAL = 0;

	public const sbyte SPEC_MONSTER = 1;

	public const sbyte KIEMSI = 0;

	public const sbyte SONGKIEM = 1;

	public const sbyte PHAPSU = 2;

	public const sbyte XATHU = 3;

	public const sbyte TEM_ANIMAL = 0;

	public const sbyte TEM_ITEM = 1;

	public const sbyte TEM_ALL = -1;

	public const sbyte TEM_NPC = 2;

	public const sbyte TEM_PLAYER = 3;

	public const sbyte MON_NOR = 0;

	public const sbyte MON_BOSS = 1;

	public const sbyte MON_CAPCHAR = 2;

	public const sbyte MON_PHOBANG = 3;

	public const sbyte BOSS_PHOBANG = 4;

	public const sbyte CUCDA_BANGHOI = 5;

	public const sbyte MON_NHANBANG = 6;

	public const sbyte CHARMONSTER = -126;

	public const sbyte MONSTERARENA = -125;

	public const sbyte newMONSTER = 92;

	public const sbyte isThucLui = sbyte.MaxValue;

	public const sbyte TYPE_PK_THUONG_GIA = 11;

	public const sbyte TYPE_PK_CUOP = 12;

	public const sbyte TYPE_PK_HIEP_SY = 13;

	public const sbyte CAN_FOCUS = 1;

	public const sbyte CAN_NOT_FOCUS = 0;

	public const sbyte CAN_FIRE = 1;

	public const sbyte CAN_NOT_FIRE = 0;

	public const sbyte NGUA_NAU = 0;

	public const sbyte NGUA_TRANG = 1;

	public const sbyte NGUA_CHIENGIAP = 2;

	public const sbyte NGUA_DO = 3;

	public const sbyte NGUA_DEN = 4;

	public short idMatna = -1;

	public long timedie;

	public EffectAuto effAuto;

	public int x;

	public int y;

	public int f;

	public int vx;

	public int vy;

	public int wOne;

	public int hOne;

	public int toX;

	public int toY;

	public int wFocus;

	public int vMax;

	public int dy;

	public int dx;

	public int dyWater;

	public int dyKill;

	public int xFire;

	public int yFire;

	public int xsai;

	public int ysai;

	public int ySort;

	public int yEffAuto;

	private int timeDyKill;

	private int vDy;

	public int hp;

	public int maxHp;

	public int mp;

	public int maxMp;

	public int hpEffect;

	public int yjum;

	public int vjum;

	public sbyte clazz;

	public sbyte index;

	public short Lv;

	public short phantramLv;

	public short countCharStand;

	public bool overMP;

	public bool overHP;

	public static sbyte countmp;

	public short idImageHenshin = -1;

	public long gold;

	public long coin;

	public int hang;

	public int idClanMoDa;

	public int timeHuyKill;

	public bool isTanHinh;

	public bool isShowHP;

	public bool isBinded;

	public bool isDongBang;

	public bool moveToBoss;

	public bool isFootSnow;

	public long timeBind;

	public long timeSleep;

	public long timeStun;

	public long timeno;

	public long timenoBoss84;

	public long timeDongBang;

	public int timeTanHinh;

	public int timeStop;

	public int timeEye;

	public int EyeMain;

	public int endEye;

	public long timeRePlayerInfo;

	public int hat = 2;

	public int head = 1;

	public int body = 2;

	public int leg = 2;

	public int eye = 2;

	public int hair = 2;

	public int wing = -1;

	public int pet = -1;

	public int frame;

	public int frameLeg;

	private sbyte[] A_Stand = new sbyte[12]
	{
		0, 0, 0, 0, 0, 0, 0, 1, 1, 1,
		1, 1
	};

	public sbyte[] A_Move = new sbyte[10] { 2, 2, 2, 0, 0, 3, 3, 3, 0, 0 };

	public static sbyte framefocus;

	public static int Wfc = 0;

	public static int Hfc = 0;

	public int xStand;

	public int yStand;

	public int countSendMove;

	public int xStopMove;

	public int yStopMove;

	private int frameDie;

	public int typeNPC;

	public sbyte isPerson;

	public bool isObject;

	public static string[] strHelpNPC = null;

	public static sbyte StepHelpServer = 0;

	public sbyte colorName;

	public int ID;

	public sbyte typeObject;

	public sbyte typePk = -1;

	public sbyte typeOnline;

	public sbyte typeBoss;

	public sbyte typeSpec;

	public int KillFire = -1;

	public short pointPk;

	public string name = string.Empty;

	public string nameGiaotiep = T.giaotiep;

	public string infoObject = string.Empty;

	public string strChatPopup;

	public int Action;

	public int Direction;

	public int PrevDir;

	public int countAutoMove;

	public int timeFreeMove;

	public bool isRemove;

	public bool isRemoveObjFocus;

	private bool isDirMove;

	public bool isStop;

	public bool iscuop;

	public short[] posTransRoad;

	public MainClan myClan;

	public int fplash;

	public int IDAttack;

	public mVector vecObjFocusSkill;

	public int imageId;

	public int IdBigAvatar;

	public bool isRunAttack;

	public bool isWater;

	public bool isInfo;

	public bool isParty;

	public long timeLoadInfo;

	public static mImage focus;

	public static mImage newfocus;

	public static mImage shadow;

	public static mImage shadow1;

	public static mImage water;

	public static mImage imgCapchar = null;

	public mVector vecBuff = new mVector("MainObject vecBuff");

	public SplashSkill PlashNow;

	public ListSkill ListKillNow;

	public int typeMonster;

	public bool isDie;

	public PopupChat chat;

	public bool ispaintArena;

	public bool isjum;

	public int timeStand;

	public int timeCapchar = -1;

	public Monster_Skill skillDefault;

	public static mVector vecCapchar = new mVector("MainObject vecCapchar");

	public static string strCapchar = string.Empty;

	public bool isMonPhoBangDie;

	public mVector vecEffauto = new mVector("MainObject VecEffauto");

	public mVector veclowEffauto = new mVector("Low VecEffauto");

	public mVector vecEffectCharWearing = new mVector("Effect CharWearing");

	public mVector vecDataSkillEff = new mVector("vec dataeff");

	public int coutEff;

	public bool isSend;

	public int timeGet;

	public int timeReveice = 1500;

	public sbyte numFrame;

	public bool isDetonateInDest;

	public bool isMove;

	public bool isServerControl;

	public short[] idPartFashion = new short[7] { -1, -1, -1, -1, -1, -1, -1 };

	public static short[] idMaterialHopNguyenLieu;

	public short markKiller;

	public bool isPaint_No;

	public bool isStun;

	public bool isSleep;

	public bool isno;

	public bool isnoBoss84;

	public sbyte isBot = -1;

	public sbyte StepMovebocap = -1;

	public bool Namearena;

	public static sbyte hideEff = 0;

	public bool useShip;

	public bool canFocusMon;

	public sbyte typefocus = 1;

	public short idPhiPhong = -1;

	public short idWeaPon = -1;

	public short idHorse = -1;

	public short idHair = -1;

	public short idWing = -1;

	public short idName = -1;

	public short idBody = -1;

	public short idLeg = -1;

	public short idBienhinh = -1;

	public sbyte typefire;

	public EffectAuto matNa;

	public static sbyte[] frameicon = new sbyte[4] { 0, 1, 2, 1 };

	public sbyte frameClan;

	public static sbyte[][] mTypePartPaintPlayer = new sbyte[4][]
	{
		new sbyte[8] { 6, 0, 1, 2, 5, 4, 3, 6 },
		new sbyte[8] { 6, 0, 1, 2, 5, 4, 3, 6 },
		new sbyte[8] { 6, 0, 1, 2, 5, 4, 3, 6 },
		new sbyte[8] { 6, 0, 1, 2, 5, 4, 3, 6 }
	};

	private int[][][] mAction = new int[5][][]
	{
		new int[3][]
		{
			new int[9],
			new int[9],
			new int[9]
		},
		new int[3][]
		{
			new int[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
			new int[9] { 1, 1, 1, 0, 0, 0, 2, 2, 2 },
			new int[9] { 2, 2, 2, 0, 0, 0, 1, 1, 1 }
		},
		new int[3][]
		{
			new int[9] { 2, 2, 2, 2, 2, 3, 3, 3, 3 },
			new int[9] { 2, 2, 2, 2, 2, 3, 3, 3, 3 },
			new int[9] { 2, 2, 2, 2, 2, 3, 3, 3, 3 }
		},
		new int[3][]
		{
			new int[9] { 4, 4, 4, 4, 4, 4, 4, 4, 4 },
			new int[9] { 4, 4, 4, 4, 4, 4, 4, 4, 4 },
			new int[9] { 4, 4, 4, 4, 4, 4, 4, 4, 4 }
		},
		new int[3][]
		{
			new int[9] { 4, 4, 4, 4, 4, 4, 4, 4, 4 },
			new int[9] { 4, 4, 4, 4, 4, 4, 4, 4, 4 },
			new int[9] { 4, 4, 4, 4, 4, 4, 4, 4, 4 }
		}
	};

	private int mjum;

	private int range;

	public sbyte FrameBody;

	public sbyte FrameLeg;

	public sbyte FrameBienhinh;

	public static mHashTable ALL_EFF_MAT_NA = new mHashTable();

	public int FramePP;

	public sbyte FrameHair;

	public sbyte FrameWing;

	public sbyte FrameName;

	public int frameThuCuoi;

	public int Fhorse;

	public static sbyte[] horseMove = new sbyte[8] { 2, 2, 2, 3, 3, 4, 4, 4 };

	public byte FrameWP;

	public sbyte FrameMatNa;

	public bool paintMatnaTruocNon = true;

	public int time;

	public int idLight;

	public int weapon_frame;

	public int weaponType = -1;

	public static WeaponInfo[][][] imgWeapone = new WeaponInfo[4][][];

	public static sbyte[] hwp = new sbyte[4] { 24, 21, 19, 13 };

	public static sbyte[] fixY = new sbyte[5] { 0, -1, 0, 0, 0 };

	public int frNo;

	public int[] frameNo = new int[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

	public bool isMoveOut;

	public int xMoveOut;

	public int yMoveOut;

	public int dyMount;

	public int xMount;

	public int yMount;

	public sbyte typeMount = -1;

	public sbyte frameMount;

	public sbyte fMount;

	public bool ischar;

	public static sbyte[] ArrMount = new sbyte[1] { 3 };

	public static sbyte[] ArrMount1 = new sbyte[10] { 2, 2, 2, 0, 0, 3, 3, 3, 0, 0 };

	public short[][] arrayGemKham = new short[12][];

	public sbyte[] slotGem = new sbyte[3] { -1, -1, -1 };

	public FrameImage weaponEff;

	public static FrameImage[] weaponEff_Gem;

	private int timeEff;

	private int dxEff;

	private int dyEff;

	private sbyte fweapon;

	private sbyte timeShow = 8;

	private sbyte[] transEff = new sbyte[4] { 2, 0, 2, 2 };

	private sbyte[][] eff_dx = new sbyte[2][]
	{
		new sbyte[4] { -2, 4, 2, -10 },
		new sbyte[4] { -2, 4, 2, -10 }
	};

	private sbyte[][] eff_dy = new sbyte[2][]
	{
		new sbyte[4] { 6, 5, 5, 2 },
		new sbyte[4] { 6, 5, 5, 2 }
	};

	public MainObject()
	{
	}

	public MainObject(int ID, sbyte type, string name, int x, int y)
	{
		this.ID = ID;
		this.name = name;
		typeObject = type;
		this.x = x;
		this.y = y;
		toX = x;
		toY = y;
		Direction = 0;
	}

	public static bool isMaHopNguyenLieu(int id)
	{
		try
		{
			for (int i = 0; i < idMaterialHopNguyenLieu.Length; i++)
			{
				if (idMaterialHopNguyenLieu[i] == id)
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception)
		{
			mSystem.println("----Err mainobj:-- isMaHopNguyenLieu");
			return false;
		}
	}

	public virtual string getnameOwner()
	{
		return string.Empty;
	}

	public virtual bool isMainChar()
	{
		return false;
	}

	public virtual bool isMonstervantieu()
	{
		return false;
	}

	public virtual void setspeedVantieu(int vmax)
	{
	}

	public virtual bool isMonsterVantieuTrang()
	{
		return false;
	}

	public virtual bool isMonsterVantieuDen()
	{
		return false;
	}

	public virtual void setInfo(sbyte idNPC, short xNPC, short yNPC, sbyte dxNPC, sbyte dyNPC, sbyte nFrameNPC, string nameGiaoTiep, string nameNPC, short xBlockNPC, short yBlockNPC, sbyte wBlockNPC, sbyte hBlockNPC, sbyte[] wearing, sbyte[] ImageData, sbyte[] frameArray)
	{
	}

	public void setInfo(int head, int eye, int hair)
	{
		if (eye < 8)
		{
			eye += 8;
		}
		this.head = head;
		this.eye = eye;
		this.hair = hair;
		EyeMain = eye;
	}

	public virtual void setEffectauto(int id, int r, short lv)
	{
	}

	public void addEffAutoFromsv(int id, int x, int y, int dx, int dy, int typeeff, int valueeff, sbyte[] datasv, sbyte lvpaint, long time, sbyte canmove, int dxx, int dyy)
	{
		EffectAuto o = new EffectAuto(id, x, y, dx, dy, typeeff, valueeff, datasv, time, canmove, dxx, dyy);
		if (lvpaint == 0)
		{
			for (int i = 0; i < vecEffauto.size(); i++)
			{
				EffectAuto effectAuto = (EffectAuto)vecEffauto.elementAt(i);
				if (effectAuto != null && effectAuto.IDItem == id)
				{
					vecEffauto.removeElement(effectAuto);
				}
			}
			vecEffauto.addElement(o);
			return;
		}
		for (int j = 0; j < veclowEffauto.size(); j++)
		{
			EffectAuto effectAuto2 = (EffectAuto)veclowEffauto.elementAt(j);
			if (effectAuto2 != null && effectAuto2.IDItem == id)
			{
				veclowEffauto.removeElement(effectAuto2);
			}
		}
		veclowEffauto.addElement(o);
	}

	public void addeffAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff)
	{
		if (isMonstervantieu())
		{
			vecEffauto.removeAllElements();
		}
		for (int i = 0; i < vecEffauto.size(); i++)
		{
			EffectAuto effectAuto = (EffectAuto)vecEffauto.elementAt(i);
			if (effectAuto != null && effectAuto.IDItem == id)
			{
				vecEffauto.removeElement(effectAuto);
			}
		}
		EffectAuto o = new EffectAuto(id, x, y, dx, dy, typeeff, valueeff);
		vecEffauto.addElement(o);
	}

	public bool isPkVantieu()
	{
		return typePk == 12 || typePk == 13 || typePk == 11;
	}

	public static void paintShadow(mGraphics g, int dir, int x, int y)
	{
		g.drawRegion(shadow1, 0, 0, mImage.getImageWidth(shadow1.image), mImage.getImageHeight(shadow1.image), 0, x, y, 3, useClip: false);
	}

	public virtual bool isLuaThieng()
	{
		return false;
	}

	public void setWearingListChar(sbyte[] wearing)
	{
		try
		{
			if (wearing == null)
			{
				body = -1;
				leg = -1;
				hat = -1;
				wing = -1;
				hair = -1;
				eye = -1;
				head = -1;
				weaponType = -1;
				pet = -1;
				return;
			}
			body = wearing[0];
			leg = wearing[1];
			hat = wearing[2];
			wing = wearing[7];
			int num = clazz;
			switch (num)
			{
			case 3:
				num = 2;
				break;
			case 2:
				num = 3;
				break;
			}
			weaponType = wearing[8 + num];
		}
		catch (Exception)
		{
		}
	}

	public virtual void setPainthit(sbyte time, bool isMax)
	{
	}

	public void setWearingEquip(sbyte[] wearing)
	{
		if (wearing == null)
		{
			body = -1;
			leg = -1;
			hat = -1;
			wing = -1;
			weaponType = -1;
			pet = -1;
		}
		else
		{
			body = wearing[1];
			leg = wearing[7];
			hat = wearing[6];
			wing = wearing[10];
			weaponType = wearing[0];
			pet = wearing[5];
		}
	}

	public override void paint(mGraphics g)
	{
	}

	public bool isMountFly()
	{
		if (typeMount == -1 || MountTemplate.Arr_Fly == null)
		{
			return false;
		}
		if (MountTemplate.Arr_Fly[typeMount] == 1)
		{
			return true;
		}
		return false;
	}

	public void paintBuffLast(mGraphics g)
	{
		if (vecBuff == null)
		{
			return;
		}
		for (int num = vecBuff.size() - 1; num >= 0; num--)
		{
			MainBuff mainBuff = (MainBuff)vecBuff.elementAt(num);
			if (mainBuff != null && mainBuff.isPaintLast)
			{
				if (mainBuff.typeBuff == 4)
				{
					mainBuff.paint(g, x + xsai, y - hOne + 5 + ysai);
				}
				else
				{
					mainBuff.paint(g, x + xsai, y + ysai);
				}
			}
		}
	}

	public void paintBuffFirst(mGraphics g)
	{
		if (vecBuff == null)
		{
			return;
		}
		for (int num = vecBuff.size() - 1; num >= 0; num--)
		{
			MainBuff mainBuff = (MainBuff)vecBuff.elementAt(num);
			if (mainBuff != null && !mainBuff.isPaintLast)
			{
				if (mainBuff.typeBuff == 4)
				{
					mainBuff.paint(g, x + xsai, y - hOne + 5 + ysai);
				}
				else
				{
					mainBuff.paint(g, x + xsai, y + ysai);
				}
			}
		}
	}

	public virtual void paintAvatarFocus(mGraphics g, int x, int y)
	{
		if (head != -1)
		{
			CRes.getCharPartInfo(2, head).paint(g, x - 1, y + 23, 0, 0);
		}
		if (eye != -1)
		{
			CRes.getCharPartInfo(4, eye).paint(g, x - 1, y + 23, 0, 0);
		}
		if (hair != -1)
		{
			CRes.getCharPartInfo(5, hair).paint(g, x - 1, y + 23, 0, 0);
		}
		if (hat != -1)
		{
			CRes.getCharPartInfo(3, hat).paint(g, x - 1, y + 23, 0, 0);
		}
	}

	public string getNameAndClan(string plus)
	{
		string text = name;
		if (myClan != null)
		{
			text = myClan.shortName + plus + text;
		}
		return text;
	}

	public void paintIconClan(mGraphics g, int x, int y, int pos)
	{
		if (myClan == null)
		{
			return;
		}
		MainImage imageIconClan = ObjectData.getImageIconClan(myClan.IdIcon);
		switch (pos)
		{
		case 2:
		{
			int num3 = (mFont.tahoma_7_white.getWidth(myClan.shortName) + 12) / 2;
			if (imageIconClan.img != null)
			{
				if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
				{
					if (GameCanvas.gameTick % 6 == 0)
					{
						int num4 = frameicon.Length;
						if (num4 == 0)
						{
							num4 = 1;
						}
						frameClan = (sbyte)((frameClan + 1) % num4);
					}
					g.drawRegion(imageIconClan.img, 0, frameicon[frameClan] * 18, 18, 18, 0, x - num3 + 6, y, 3, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(imageIconClan.img, x - num3 + 6, y, 3, mGraphics.isTrue);
				}
				Item.eff_UpLv.paintUpgradeEffect(x - num3 + 6, y - 1, myClan.getEffChucVu(), 14, g, 0);
			}
			mFont.tahoma_7_white.drawString(g, myClan.shortName, x - num3 + 15, y - 6, 0, mGraphics.isTrue);
			break;
		}
		case 0:
			if (imageIconClan.img != null)
			{
				if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
				{
					if (GameCanvas.gameTick % 6 == 0)
					{
						int num5 = frameicon.Length;
						if (num5 == 0)
						{
							num5 = 1;
						}
						frameClan = (sbyte)((frameClan + 1) % num5);
					}
					g.drawRegion(imageIconClan.img, 0, frameicon[frameClan] * 18, 18, 18, 0, x, y, 3, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(imageIconClan.img, x, y, 3, mGraphics.isTrue);
				}
				Item.eff_UpLv.paintUpgradeEffect(x - 1, y - 1, myClan.getEffChucVu(), 14, g, 0);
			}
			mFont.tahoma_7b_white.drawString(g, myClan.shortName, x + 13, y, 0, mGraphics.isTrue);
			break;
		case -1:
			if (imageIconClan.img == null)
			{
				break;
			}
			if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
			{
				if (GameCanvas.gameTick % 6 == 0)
				{
					int num6 = frameicon.Length;
					if (num6 == 0)
					{
						num6 = 1;
					}
					frameClan = (sbyte)((frameClan + 1) % num6);
				}
				g.drawRegion(imageIconClan.img, 0, frameicon[frameClan] * 18, 18, 18, 0, x - 1, y, 3, mGraphics.isTrue);
			}
			else
			{
				g.drawImage(imageIconClan.img, x - 1, y, 3, mGraphics.isTrue);
			}
			Item.eff_UpLv.paintUpgradeEffect(x - 1, y - 1, myClan.getEffChucVu(), 14, g, 0);
			break;
		case -2:
		{
			int num = (mFont.tahoma_7_white.getWidth(myClan.shortName + " - " + myClan.name) + 15) / 2;
			if (imageIconClan.img != null)
			{
				if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
				{
					if (GameCanvas.gameTick % 6 == 0)
					{
						int num2 = frameicon.Length;
						if (num2 == 0)
						{
							num2 = 1;
						}
						frameClan = (sbyte)((frameClan + 1) % num2);
					}
					g.drawRegion(imageIconClan.img, 0, frameicon[frameClan] * 18, 18, 18, 0, x - num + 7, y, 3, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(imageIconClan.img, x - num + 7, y, 3, mGraphics.isTrue);
				}
				Item.eff_UpLv.paintUpgradeEffect(x - num + 6, y - 1, myClan.getEffChucVu(), 14, g, 0);
			}
			mFont.tahoma_7_white.drawString(g, myClan.shortName + " - " + myClan.name, x - num + 15, y - 6, 0, mGraphics.isTrue);
			break;
		}
		}
	}

	public void paintObject(mGraphics g, int nameIdx)
	{
		MainImage imagePartNPC = ObjectData.getImagePartNPC((short)imageId);
		if (imagePartNPC.img != null)
		{
			hOne = mImage.getImageHeight(imagePartNPC.img.image) / numFrame;
			wOne = mImage.getImageWidth(imagePartNPC.img.image);
			g.drawRegion(imagePartNPC.img, 0, GameCanvas.gameTick / 7 % numFrame * hOne, wOne, hOne, 0, x, y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
		}
		if (GameScreen.ObjFocus == null || (GameScreen.ObjFocus != null && this != GameScreen.ObjFocus) || PaintInfoGameScreen.isLevelPoint)
		{
			paintName(g, 0);
		}
		int num = x;
		int num2 = y - hOne - 8;
		int num3 = 0;
		if (maxHp <= 0)
		{
			return;
		}
		if (hp > 0)
		{
			num3 = hp * 50 / maxHp;
			if (num3 <= 0)
			{
				num3 = 1;
			}
			else if (num3 > 50)
			{
				num3 = 50;
			}
		}
		g.setColor(8062494);
		g.fillRect(num - wOne / 2 + 10, num2, 50, 5, mGraphics.isTrue);
		g.setColor(16197705);
		g.fillRect(num - wOne / 2 + 10, num2, num3, 5, mGraphics.isTrue);
	}

	public void jum()
	{
		isjum = true;
		yjum = 0;
		vjum = 10;
		mjum = 5;
		range = 72;
	}

	public virtual void paintNameStore(mGraphics g, int x, int y)
	{
	}

	public void painthidePlayer(mGraphics g, int paintname)
	{
		if (isTanHinh)
		{
			return;
		}
		if (Canpaint())
		{
			if (Action == 4 && !isDongBang)
			{
				g.drawImage(shadow, x + 1, y + 1, 3, mGraphics.isTrue);
				paintBuffFirst(g);
				AvMain.fraPlayerDie.drawFrame(0, x + 1, y - ysai + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				if (effAuto != null)
				{
					isDongBang = false;
					timeDongBang = mSystem.currentTimeMillis();
					GameScreen.addEffectEndKill(15, x, y);
					effAuto = null;
				}
				if (frameDie == 0)
				{
					g.drawImage(AvMain.imgEyeDie, x + 1, y - ysai + 5 - 24, mGraphics.TOP | mGraphics.HCENTER, mGraphics.isTrue);
				}
			}
			else if (!checktanghinh())
			{
				if (idImageHenshin == -1 && idHorse == -1)
				{
					g.drawImage(shadow, x + 1, y - ysai + 2, 3, mGraphics.isTrue);
				}
				paintBuffFirst(g);
				paintEffauto_Low(g, x, y);
				paintDataEff_Top(g, x, y);
				bool flag = (Direction == 0 || Direction == 2 || Direction == 3) && ((clazz == 3 && frame != 4) || (clazz != 3 && frame != 5));
				int num = 0;
				if (idImageHenshin != -1)
				{
					MainImage imagePartMonster = ObjectData.getImagePartMonster(idImageHenshin);
					if (imagePartMonster.img != null)
					{
						int num2 = Action;
						if (num2 > mAction.Length - 1)
						{
							num2 = 0;
						}
						hOne = mImage.getImageHeight(imagePartMonster.img.image) / 3;
						wOne = mImage.getImageWidth(imagePartMonster.img.image) / 2;
						if (eye == 4 || eye == 2)
						{
							num2 = 3;
						}
						int num3 = 0;
						int num4 = mAction[num2][(Direction <= 2) ? Direction : 2][frame] * hOne;
						num3 = mAction[num2][(Direction <= 2) ? Direction : 2][frame] / 3 * wOne;
						num4 = mAction[num2][(Direction <= 2) ? Direction : 2][frame] % 3 * hOne;
						g.drawRegion(imagePartMonster.img, num3, num4, wOne, hOne, (Direction > 2) ? 2 : 0, x, y - dy + dyWater, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
					}
				}
				else
				{
					if (flag)
					{
						try
						{
							paintWeaponhideplayer(g, num);
						}
						catch (Exception)
						{
						}
					}
					bool flag2 = false;
					for (int i = 0; i < mTypePartPaintPlayer[Direction].Length; i++)
					{
						sbyte b = mTypePartPaintPlayer[Direction][i];
						if ((b == 6 || b == 4) && (b != 6 || Direction != 1 || i != 7) && (b != 6 || Direction == 1 || i != 0) && (b != 4 || Direction == 1))
						{
							continue;
						}
						if (getTypeParthide(i) >= 0)
						{
							if (typeMount == -1)
							{
								CRes.getCharPartInfo(b, getTypeParthide(i)).paint(g, x, y - ysai - dy + dyWater - yjum, Direction, frame);
							}
							else if (i != 1)
							{
								CRes.getCharPartInfo(b, getTypeParthide(i)).paint(g, x, y - ysai - dy + dyWater - dyMount - yjum, Direction, frame);
							}
							else
							{
								paintMount_Sau(g);
							}
						}
						else if ((b == 0 || b == 1 || b == 2 || b == 4 || b == 5) && !flag2)
						{
							flag2 = true;
							setReInfo();
						}
					}
					if (typeMount != -1)
					{
						paintMount_Truoc(g);
					}
					if (!flag)
					{
						try
						{
							paintWeaponhideplayer(g, num);
						}
						catch (Exception)
						{
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < mTypePartPaintPlayer[Direction].Length; j++)
				{
					sbyte b2 = mTypePartPaintPlayer[Direction][j];
					if (b2 == 4 && getTypeParthide(j) >= 0)
					{
						if (typeMount == -1)
						{
							CRes.getCharPartInfo(b2, getTypeParthide(j)).paint(g, x, y - ysai - dy + dyWater - yjum, Direction, frame);
						}
						else if (j != 1)
						{
							CRes.getCharPartInfo(b2, getTypeParthide(j)).paint(g, x, y - ysai - dy + dyWater - dyMount - yjum, Direction, frame);
						}
						else
						{
							paintMount_Sau(g);
						}
					}
				}
			}
			if (!checktanghinh())
			{
				paintDataEff_Bot(g, x, y);
				if (!useShip && isWater && dy == 0)
				{
					int num5 = 1;
					if (Direction == 2)
					{
						num5 += 2;
					}
					else if (Direction == 3)
					{
						num5 -= 2;
					}
					g.drawRegion(water, 0, ((Action != 0) ? 2 : 0) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, x + num5, y - ysai - 2 + dyWater, 3, mGraphics.isTrue);
				}
			}
		}
		if (!checktanghinh())
		{
			if ((PaintInfoGameScreen.isLevelPoint || this != GameScreen.ObjFocus) && paintname != -1)
			{
				paintName(g, paintname);
			}
			paintBuffLast(g);
			paint_no(g);
			paintEffauto(g, x, y);
			if (hp > 0)
			{
				paintDongBang(g);
			}
		}
	}

	public int getFrameLeg()
	{
		if (Direction == 0)
		{
			return frame + FrameLeg * 18;
		}
		if (Direction == 1)
		{
			return Direction * 6 + frame + FrameLeg * 18;
		}
		return frame + 12 + FrameLeg * 18;
	}

	public int getFrameBien()
	{
		if (Direction == 0)
		{
			return frame + FrameBienhinh * 18;
		}
		if (Direction == 1)
		{
			return Direction * 6 + frame + FrameBienhinh * 18;
		}
		return frame + 12 + FrameBienhinh * 18;
	}

	public int getFrameBody()
	{
		if (Direction == 0)
		{
			return frame + FrameBody * 18;
		}
		if (Direction == 1)
		{
			return Direction * 6 + frame + FrameBody * 18;
		}
		return frame + 12 + FrameBody * 18;
	}

	public int getFramePP()
	{
		if (Direction == 0)
		{
			return frame + FramePP * 18;
		}
		if (Direction == 1)
		{
			return Direction * 6 + frame + FramePP * 18;
		}
		return frame + 12 + FramePP * 18;
	}

	public int getFrameWing_Wearing(int mframe)
	{
		return mframe + FrameWing * 18;
	}

	public int getFrameWing()
	{
		if (Direction == 0)
		{
			return frame + FrameWing * 18;
		}
		if (Direction == 1)
		{
			return Direction * 6 + frame + FrameWing * 18;
		}
		return frame + 12 + FrameWing * 18;
	}

	public int getFrameHair()
	{
		if (Direction == 0)
		{
			return frame + FrameHair * 18;
		}
		if (Direction == 1)
		{
			return Direction * 6 + frame + FrameHair * 18;
		}
		return frame + 12 + FrameHair * 18;
	}

	public int getFrameHair_Wearing(int mframe)
	{
		return mframe + FrameHair * 18;
	}

	public int getFrameBody_Wearing(int mframe)
	{
		return mframe + FrameBody * 18;
	}

	public int getFrameLeg_Wearing(int mframe)
	{
		return mframe + FrameLeg * 18;
	}

	public int getFrameHorse()
	{
		if (Direction == 0)
		{
			return Fhorse + frameThuCuoi * 21;
		}
		if (Direction == 1)
		{
			return Fhorse + 7 + frameThuCuoi * 21;
		}
		return Fhorse + 14 + frameThuCuoi * 21;
	}

	public int getFramePP_Wearing(int mframe)
	{
		return mframe + FramePP * 18;
	}

	public int getFrameMatNa_Wearing(int mframe)
	{
		return mframe + FrameMatNa * 18;
	}

	public int getFrameWP_Wearing(int mframe)
	{
		return mframe + FrameWP * 18;
	}

	public int getFrameWP()
	{
		if (Direction == 0)
		{
			return frame + FrameWP * 18;
		}
		if (Direction == 1)
		{
			return Direction * 6 + frame + FrameWP * 18;
		}
		return frame + 12 + FrameWP * 18;
	}

	public int getFrameMatNa()
	{
		if (Direction == 0)
		{
			return frame + FrameMatNa * 18;
		}
		if (Direction == 1)
		{
			return Direction * 6 + frame + FrameMatNa * 18;
		}
		return frame + 12 + FrameMatNa * 18;
	}

	public static DataSkillEff getEffMatNa(int id)
	{
		if (id == -1)
		{
			return null;
		}
		DataSkillEff dataSkillEff = (DataSkillEff)ALL_EFF_MAT_NA.get(id + string.Empty);
		if (dataSkillEff == null)
		{
			dataSkillEff = new DataSkillEff(id);
			dataSkillEff.typRequestImg = 113;
			ALL_EFF_MAT_NA.put(id + string.Empty, dataSkillEff);
			ImageIcon imgIcon = GameData.getImgIcon((short)(id + GameData.ID_START_SKILL), dataSkillEff.typRequestImg);
			dataSkillEff.timeRemove = (int)(mSystem.currentTimeMillis() / 1000);
		}
		else
		{
			dataSkillEff.timeRemove = GameCanvas.timeNow;
		}
		return dataSkillEff;
	}

	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = ALL_EFF_MAT_NA.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				DataSkillEff dataSkillEff = (DataSkillEff)ALL_EFF_MAT_NA.get(k);
				if ((GameCanvas.timeNow - dataSkillEff.timeRemove) / 1000 > ((TemMidlet.DIVICE != 0) ? 300 : 60))
				{
					ALL_EFF_MAT_NA.remove(k);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintPlayer(mGraphics g, int paintname)
	{
		if (Action == 2 && idHorse != -1)
		{
			Fhorse = frame + 1;
		}
		if (isTanHinh)
		{
			return;
		}
		if (Canpaint())
		{
			if (Action == 4 && !isDongBang)
			{
				g.drawImage(shadow, x + 1, y + 1, 3, mGraphics.isTrue);
				paintBuffFirst(g);
				AvMain.fraPlayerDie.drawFrame(0, x + 1, y - ysai + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				if (effAuto != null)
				{
					isDongBang = false;
					timeDongBang = mSystem.currentTimeMillis();
					GameScreen.addEffectEndKill(15, x, y);
					effAuto = null;
				}
				if (frameDie == 0)
				{
					g.drawImage(AvMain.imgEyeDie, x + 1, y - ysai + 5 - 24, mGraphics.TOP | mGraphics.HCENTER, mGraphics.isTrue);
				}
			}
			else
			{
				if (!checktanghinh())
				{
					if (idImageHenshin == -1 && idHorse == -1)
					{
						g.drawImage(shadow, x + 1, y - ysai + 2, 3, mGraphics.isTrue);
					}
					paintBuffFirst(g);
					paintEffauto_Low(g, x, y);
					paintDataEff_Top(g, x, y);
					bool flag = (Direction == 0 || Direction == 2 || Direction == 3) && ((clazz == 3 && frame != 4) || (clazz != 3 && frame != 5));
					DataSkillEff effMatNa = getEffMatNa(idWeaPon);
					if (GameCanvas.gameTick % 5 == 0 && effMatNa != null)
					{
						int num = effMatNa.listFrame.size() / 18;
						if (num == 0)
						{
							num = 1;
						}
						FrameWP = (byte)((FrameWP + 1) % num);
					}
					getEffMatNa(idHorse)?.paintBottomHorse(g, x + xMount, y - ysai - dy + dyWater - yjum + yMount, getFrameHorse(), (Direction == 3) ? 2 : 0);
					int num2 = 0;
					if (idImageHenshin != -1)
					{
						MainImage imagePartMonster = ObjectData.getImagePartMonster(idImageHenshin);
						if (imagePartMonster.img != null)
						{
							int num3 = Action;
							if (num3 > mAction.Length - 1)
							{
								num3 = 0;
							}
							hOne = mImage.getImageHeight(imagePartMonster.img.image) / 3;
							wOne = mImage.getImageWidth(imagePartMonster.img.image) / 2;
							if (eye == 4 || eye == 2)
							{
								num3 = 3;
							}
							int num4 = 0;
							int num5 = mAction[num3][(Direction <= 2) ? Direction : 2][frame] * hOne;
							num4 = mAction[num3][(Direction <= 2) ? Direction : 2][frame] / 3 * wOne;
							num5 = mAction[num3][(Direction <= 2) ? Direction : 2][frame] % 3 * hOne;
							g.drawRegion(imagePartMonster.img, num4, num5, wOne, hOne, (Direction > 2) ? 2 : 0, x, y - dy + dyWater, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
						}
					}
					else
					{
						if (flag)
						{
							try
							{
								paintWeapon(g, num2);
								if (effMatNa != null && Action != 2)
								{
									effMatNa.paintBottomWeaPon(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameWP(), (Direction == 3) ? 2 : 0);
									effMatNa.paintTopWeaPon(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameWP(), (Direction == 3) ? 2 : 0);
								}
							}
							catch (Exception)
							{
							}
						}
						bool flag2 = false;
						DataSkillEff effMatNa2 = getEffMatNa(idPhiPhong);
						DataSkillEff effMatNa3 = getEffMatNa(idHair);
						DataSkillEff effMatNa4 = getEffMatNa(idBody);
						DataSkillEff effMatNa5 = getEffMatNa(idLeg);
						DataSkillEff effMatNa6 = getEffMatNa(idBienhinh);
						if (GameCanvas.gameTick % 6 == 0 && effMatNa6 != null)
						{
							int num6 = effMatNa6.listFrame.size() / 18;
							if (num6 == 0)
							{
								num6 = 1;
							}
							FrameBienhinh = (sbyte)((FrameBienhinh + 1) % num6);
						}
						if (GameCanvas.gameTick % 6 == 0 && effMatNa5 != null)
						{
							int num7 = effMatNa5.listFrame.size() / 18;
							if (num7 == 0)
							{
								num7 = 1;
							}
							FrameLeg = (sbyte)((FrameLeg + 1) % num7);
						}
						if (GameCanvas.gameTick % 10 == 0 && effMatNa2 != null)
						{
							int num8 = effMatNa2.listFrame.size() / 18;
							if (num8 == 0)
							{
								num8 = 1;
							}
							FramePP = (byte)((FramePP + 1) % num8);
						}
						if (GameCanvas.gameTick % 6 == 0 && effMatNa4 != null)
						{
							int num9 = effMatNa4.listFrame.size() / 18;
							if (num9 == 0)
							{
								num9 = 1;
							}
							FrameBody = (sbyte)((FrameBody + 1) % num9);
						}
						if (GameCanvas.gameTick % 6 == 0 && effMatNa3 != null)
						{
							int num10 = effMatNa3.listFrame.size() / 18;
							if (num10 == 0)
							{
								num10 = 1;
							}
							FrameHair = (sbyte)((FrameHair + 1) % num10);
						}
						DataSkillEff effMatNa7 = getEffMatNa(idWing);
						if (GameCanvas.gameTick % 6 == 0 && effMatNa7 != null)
						{
							int num11 = effMatNa7.listFrame.size() / 18;
							if (num11 == 0)
							{
								num11 = 1;
							}
							FrameWing = (sbyte)((FrameWing + 1) % num11);
						}
						if (Direction != 1)
						{
							effMatNa2?.paintBottomPP(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFramePP(), (Direction == 3) ? 2 : 0);
						}
						DataSkillEff effMatNa8 = getEffMatNa(idMatna);
						if (GameCanvas.gameTick % 5 == 0 && effMatNa8 != null)
						{
							int num12 = effMatNa8.listFrame.size() / 18;
							if (num12 == 0)
							{
								num12 = 1;
							}
							FrameMatNa = (sbyte)((FrameMatNa + 1) % num12);
						}
						if (effMatNa6 != null && idBienhinh != -1)
						{
							effMatNa6.paintBottomAll(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameBody(), (Direction == 3) ? 2 : 0);
							effMatNa6.paintTopAll(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameBody(), (Direction == 3) ? 2 : 0);
						}
						for (int i = 0; i < mTypePartPaintPlayer[Direction].Length; i++)
						{
							sbyte b = mTypePartPaintPlayer[Direction][i];
							if (b == -1)
							{
								effMatNa8?.paintBottom(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameMatNa(), (Direction == 3) ? 2 : 0);
								continue;
							}
							if (Direction == 1)
							{
								if (effMatNa2 != null)
								{
									effMatNa2.paintBottomPP(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFramePP(), (Direction == 3) ? 2 : 0);
									effMatNa2.paintTopPP(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFramePP(), (Direction == 3) ? 2 : 0);
								}
								if (b == 2 && effMatNa8 != null)
								{
									effMatNa8.paintBottom(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameMatNa(), (Direction == 3) ? 2 : 0);
									effMatNa8.paintTop(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameMatNa(), (Direction == 3) ? 2 : 0);
								}
							}
							else if (b == 4 && effMatNa8 != null && paintMatnaTruocNon)
							{
								effMatNa8.paintBottom(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameMatNa(), (Direction == 3) ? 2 : 0);
								effMatNa8.paintTop(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameMatNa(), (Direction == 3) ? 2 : 0);
							}
							if ((b != 6 && b != 4) || (b == 6 && Direction == 1 && i == 7) || (b == 6 && Direction != 1 && i == 0) || (b == 4 && Direction != 1))
							{
								if (b == 6 && effMatNa7 != null && idWing != -1)
								{
									effMatNa7.paintBottomWing(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameWing(), (Direction == 3) ? 2 : 0);
									effMatNa7.paintTopWing(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameWing(), (Direction == 3) ? 2 : 0);
									continue;
								}
								if (idBienhinh != -1 && effMatNa6 != null && (b == 1 || b == 0 || b == 3 || b == 5 || b == 2))
								{
									continue;
								}
								if (b == 1 && idBody != -1 && effMatNa4 != null)
								{
									effMatNa4.paintBottomAll(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameBody(), (Direction == 3) ? 2 : 0);
									effMatNa4.paintTopAll(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameBody(), (Direction == 3) ? 2 : 0);
									continue;
								}
								if (b == 0 && idLeg != -1 && effMatNa5 != null)
								{
									effMatNa5.paintBottomAll(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameLeg(), (Direction == 3) ? 2 : 0);
									effMatNa5.paintTopAll(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameLeg(), (Direction == 3) ? 2 : 0);
									continue;
								}
								if (b == 5 && idHair != -1 && effMatNa3 != null)
								{
									effMatNa3.paintBottomHair(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameHair(), (Direction == 3) ? 2 : 0);
									effMatNa3.paintTopHair(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameHair(), (Direction == 3) ? 2 : 0);
									continue;
								}
								if (getTypePart(i) >= 0)
								{
									if (typeMount == -1)
									{
										if (b == 6 && (Direction == 0 || Direction == 2 || Direction == 3))
										{
											CRes.getCharPartInfo(b, getTypePart(i)).paint(g, x, y - ysai - dy + dyWater - yjum, Direction, frame);
											if (effMatNa2 != null)
											{
												effMatNa2.paintBottomPP(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFramePP(), (Direction == 3) ? 2 : 0);
												effMatNa2.paintTopPP(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFramePP(), (Direction == 3) ? 2 : 0);
											}
										}
										else
										{
											CRes.getCharPartInfo(b, getTypePart(i)).paint(g, x, y - ysai - dy + dyWater - yjum, Direction, frame);
										}
									}
									else if (i != 1)
									{
										if (b == 6 && (Direction == 0 || Direction == 2 || Direction == 3))
										{
											CRes.getCharPartInfo(b, getTypePart(i)).paint(g, x, y - ysai - dy + dyWater - dyMount - yjum, Direction, frame);
											if (effMatNa2 != null)
											{
												effMatNa2.paintBottomPP(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFramePP(), (Direction == 3) ? 2 : 0);
												effMatNa2.paintTopPP(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFramePP(), (Direction == 3) ? 2 : 0);
											}
										}
										else
										{
											CRes.getCharPartInfo(b, getTypePart(i)).paint(g, x, y - ysai - dy + dyWater - dyMount - yjum, Direction, frame);
										}
									}
									else
									{
										paintMount_Sau(g);
									}
								}
								else if ((b == 0 || b == 1 || b == 2 || b == 4 || b == 5) && !flag2)
								{
									flag2 = true;
									setReInfo();
								}
							}
							if (b == 3 && effMatNa8 != null && !paintMatnaTruocNon && Direction != 1)
							{
								effMatNa8.paintBottom(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameMatNa(), (Direction == 3) ? 2 : 0);
								effMatNa8.paintTop(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameMatNa(), (Direction == 3) ? 2 : 0);
							}
						}
						if (Direction != 1)
						{
							effMatNa2?.paintTopPP(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater, getFramePP(), (Direction == 3) ? 2 : 0);
						}
						if (typeMount != -1)
						{
							paintMount_Truoc(g);
						}
						if (!flag)
						{
							try
							{
								paintWeapon(g, num2);
								if (effMatNa != null && Action != 2)
								{
									effMatNa.paintBottomWeaPon(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameWP(), (Direction == 3) ? 2 : 0);
									effMatNa.paintTopWeaPon(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, getFrameWP(), (Direction == 3) ? 2 : 0);
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < mTypePartPaintPlayer[Direction].Length; j++)
					{
						sbyte b2 = mTypePartPaintPlayer[Direction][j];
						if (b2 == 4 && getTypePart(j) >= 0)
						{
							if (typeMount == -1)
							{
								CRes.getCharPartInfo(b2, getTypePart(j)).paint(g, x, y - ysai - dy + dyWater - yjum, Direction, frame);
							}
							else if (j != 1)
							{
								CRes.getCharPartInfo(b2, getTypePart(j)).paint(g, x, y - ysai - dy + dyWater - dyMount - yjum, Direction, frame);
							}
							else
							{
								paintMount_Sau(g);
							}
						}
					}
				}
				getEffMatNa(idHorse)?.paintTopHorse(g, x + xMount, y - ysai - dy + dyWater - yjum + yMount, getFrameHorse(), (Direction == 3) ? 2 : 0);
			}
			if (!checktanghinh())
			{
				paintDataEff_Bot(g, x, y);
				if (!useShip && isWater && dy == 0)
				{
					int num13 = 1;
					if (Direction == 2)
					{
						num13 += 2;
					}
					else if (Direction == 3)
					{
						num13 -= 2;
					}
					g.drawRegion(water, 0, ((Action != 0) ? 2 : 0) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, x + num13, y - ysai - 2 + dyWater, 3, mGraphics.isTrue);
				}
			}
		}
		if (!canpaintDataSkillEff())
		{
			paintDataEff_Top(g, x, y);
			paintDataEff_Bot(g, x, y);
		}
		if (!checktanghinh())
		{
			DataSkillEff effMatNa9 = getEffMatNa(idName);
			if (effMatNa9 != null)
			{
				if (GameCanvas.gameTick % 5 == 0 && effMatNa9 != null)
				{
					int num14 = effMatNa9.listFrame.size();
					if (num14 == 0)
					{
						num14 = 1;
					}
					FrameName = (sbyte)((FrameName + 1) % num14);
				}
				effMatNa9.paintBottomName(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, FrameName, 0);
				effMatNa9.paintTopName(g, x, y + ((typeMount != -1) ? (-dyMount) : 0) + dyWater - yjum, FrameName, 0);
			}
		}
		if (!checktanghinh())
		{
			if ((PaintInfoGameScreen.isLevelPoint || this != GameScreen.ObjFocus) && paintname != -1)
			{
				paintName(g, paintname);
			}
			paintBuffLast(g);
			paint_no(g);
			paintEffauto(g, x, y);
			if (hp > 0)
			{
				paintDongBang(g);
			}
		}
	}

	public bool canpaintDataSkillEff()
	{
		for (int i = 0; i < vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.CanpaintByeffauto())
			{
				return false;
			}
		}
		return true;
	}

	public bool checktanghinh()
	{
		for (int i = 0; i < vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.isTanghinhbyEffauto())
			{
				return true;
			}
		}
		return false;
	}

	public void paintEffauto(mGraphics g, int xp, int yp)
	{
		if (isMainChar() || hideEff != 1)
		{
			for (int i = 0; i < vecEffauto.size(); i++)
			{
				((EffectAuto)vecEffauto.elementAt(i))?.paint(g, xp, yp - yEffAuto);
			}
		}
	}

	public void paintDataEff_Top(mGraphics g, int x, int y)
	{
		if (!isMainChar() && hideEff == 1)
		{
			return;
		}
		int num = vecDataSkillEff.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				((DataSkillEff)vecDataSkillEff.elementAt(i))?.paintTop(g, x, y);
			}
		}
	}

	public void paintDataEff_Bot(mGraphics g, int x, int y)
	{
		if (!isMainChar() && hideEff == 1)
		{
			return;
		}
		int num = vecDataSkillEff.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				((DataSkillEff)vecDataSkillEff.elementAt(i))?.paintBottom(g, x, y);
			}
		}
	}

	public void paintEffauto_Low(mGraphics g, int xp, int yp)
	{
		if (!isMainChar() && hideEff == 1)
		{
			return;
		}
		for (int i = 0; i < veclowEffauto.size(); i++)
		{
			((EffectAuto)veclowEffauto.elementAt(i))?.paint(g, xp, yp - yEffAuto);
		}
		for (int j = 0; j < veclowEffauto.size(); j++)
		{
			EffectAuto effectAuto = (EffectAuto)veclowEffauto.elementAt(j);
			if (effectAuto != null)
			{
				effectAuto.update();
				if (effectAuto.wantdestroy)
				{
					veclowEffauto.removeElement(effectAuto);
				}
			}
		}
	}

	public bool Canpaint()
	{
		int num = vecEffauto.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				EffectAuto effectAuto = (EffectAuto)vecEffauto.elementAt(i);
				if (effectAuto != null && effectAuto.CanpaintByeffauto())
				{
					return false;
				}
			}
		}
		for (int j = 0; j < vecDataSkillEff.size(); j++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(j);
			if (dataSkillEff != null && dataSkillEff.CanpaintByeffauto())
			{
				return false;
			}
		}
		return true;
	}

	public bool Canmove()
	{
		if (isSleep || isStun || isno || isDongBang)
		{
			return false;
		}
		int num = vecEffauto.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				EffectAuto effectAuto = (EffectAuto)vecEffauto.elementAt(i);
				if (effectAuto != null && effectAuto.lockmoveByeffAuto())
				{
					return false;
				}
			}
		}
		if (veclowEffauto.size() > 0)
		{
			for (int j = 0; j < veclowEffauto.size(); j++)
			{
				EffectAuto effectAuto2 = (EffectAuto)veclowEffauto.elementAt(j);
				if (effectAuto2 != null && effectAuto2.lockmoveByeffAuto())
				{
					return false;
				}
			}
		}
		for (int k = 0; k < vecDataSkillEff.size(); k++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(k);
			if (dataSkillEff != null && dataSkillEff.lockmoveByeffAuto())
			{
				return false;
			}
		}
		return true;
	}

	public void updateEffauto()
	{
		for (int i = 0; i < vecEffauto.size(); i++)
		{
			EffectAuto effectAuto = (EffectAuto)vecEffauto.elementAt(i);
			if (effectAuto != null)
			{
				effectAuto.update();
				if (effectAuto.wantdestroy)
				{
					vecEffauto.removeElement(effectAuto);
				}
			}
		}
	}

	public void paintDongBang(mGraphics g)
	{
		if (isDongBang && Action != 4 && isDongBang && effAuto != null)
		{
			effAuto.paint(g);
		}
	}

	public int getTypeParthide(int i)
	{
		return mTypePartPaintPlayer[Direction][i] switch
		{
			0 => clazz, 
			1 => clazz, 
			2 => 0, 
			3 => -1, 
			4 => clazz + 8, 
			5 => clazz, 
			6 => -1, 
			_ => -1, 
		};
	}

	public int getTypePart(int i)
	{
		switch (mTypePartPaintPlayer[Direction][i])
		{
		case 0:
			return (idPartFashion[1] == -1) ? leg : idPartFashion[1];
		case 1:
			return (idPartFashion[0] == -1) ? body : idPartFashion[0];
		case 2:
			if (idPartFashion.Length > 6)
			{
				return (idPartFashion[6] == -1) ? head : idPartFashion[6];
			}
			return head;
		case 3:
			if (isHairNotHat())
			{
				return -1;
			}
			return (idPartFashion[2] == -1) ? hat : idPartFashion[2];
		case 4:
			return eye;
		case 5:
			return (idPartFashion[5] == -1) ? hair : idPartFashion[5];
		case 6:
			return (idPartFashion[4] == -1) ? wing : idPartFashion[4];
		default:
			return -1;
		}
	}

	public void setReInfo()
	{
		if ((GameCanvas.timeNow - timeRePlayerInfo) / 1000 > 60)
		{
			GlobalService.gI().char_info((short)ID);
			timeRePlayerInfo = GameCanvas.timeNow;
		}
	}

	public void paintShowPlayer(mGraphics g, int x, int y, int dir)
	{
		int num = GameCanvas.gameTick / 6 % 2;
		DataSkillEff effMatNa = getEffMatNa(idPhiPhong);
		DataSkillEff effMatNa2 = getEffMatNa(idHair);
		DataSkillEff effMatNa3 = getEffMatNa(idBody);
		DataSkillEff effMatNa4 = getEffMatNa(idWing);
		DataSkillEff effMatNa5 = getEffMatNa(idLeg);
		if (GameCanvas.gameTick % 6 == 0 && effMatNa4 != null)
		{
			int num2 = effMatNa4.listFrame.size() / 18;
			if (num2 == 0)
			{
				num2 = 1;
			}
			FrameWing = (sbyte)((FrameWing + 1) % num2);
		}
		if (GameCanvas.gameTick % 10 == 0 && effMatNa != null)
		{
			int num3 = effMatNa.listFrame.size() / 18;
			if (num3 == 0)
			{
				num3 = 1;
			}
			FramePP = (byte)((FramePP + 1) % num3);
		}
		if (effMatNa != null && wing == -1 && idPartFashion[4] == -1)
		{
			effMatNa.paintBottomPP(g, x, y, getFramePP_Wearing(num), 0);
			effMatNa.paintTopPP(g, x, y, getFramePP_Wearing(num), 0);
		}
		DataSkillEff effMatNa6 = getEffMatNa(idMatna);
		DataSkillEff effMatNa7 = getEffMatNa(idWeaPon);
		if (GameCanvas.gameTick % 5 == 0 && effMatNa6 != null)
		{
			int num4 = effMatNa6.listFrame.size() / 18;
			if (num4 == 0)
			{
				num4 = 1;
			}
			FrameMatNa = (sbyte)((FrameMatNa + 1) % num4);
		}
		if (GameCanvas.gameTick % 6 == 0 && effMatNa2 != null)
		{
			int num5 = effMatNa2.listFrame.size() / 18;
			if (num5 == 0)
			{
				num5 = 1;
			}
			FrameHair = (sbyte)((FrameHair + 1) % num5);
		}
		if (GameCanvas.gameTick % 6 == 0 && effMatNa3 != null)
		{
			int num6 = effMatNa3.listFrame.size() / 18;
			if (num6 == 0)
			{
				num6 = 1;
			}
			FrameBody = (sbyte)((FrameBody + 1) % num6);
		}
		if (GameCanvas.gameTick % 6 == 0 && effMatNa5 != null)
		{
			int num7 = effMatNa5.listFrame.size() / 18;
			if (num7 == 0)
			{
				num7 = 1;
			}
			FrameLeg = (sbyte)((FrameLeg + 1) % num7);
		}
		if (effMatNa7 != null)
		{
			effMatNa7.paintBottomWeaPon(g, x, y, getFrameWP_Wearing(num), 0);
			effMatNa7.paintTopWeaPon(g, x, y, getFrameWP_Wearing(num), 0);
		}
		g.drawImage(shadow, x + 1, y + 2, 3, mGraphics.isTrue);
		int num8 = weaponType;
		if (num8 != -1 && CRes.loadImgWeaPone(clazz, num8, 0) != null)
		{
			WeaponInfo weaponInfo = CRes.loadImgWeaPone(clazz, num8, 0);
			if (weaponInfo.img != null)
			{
				g.drawRegion(weaponInfo.img, weaponInfo.mRegion[dir][0], 0, weaponInfo.mRegion[dir][1], weaponInfo.himg, 0, x + weaponInfo.mPos[dir][num][0], y + weaponInfo.mPos[dir][num][1], 0, mGraphics.isTrue);
			}
		}
		paintDataEff_Top(g, x, y);
		for (int i = 0; i < mTypePartPaintPlayer[Direction].Length - 1; i++)
		{
			sbyte b = mTypePartPaintPlayer[0][i];
			if (b == -1)
			{
				effMatNa6?.paintBottom(g, x, y, getFrameMatNa_Wearing(num), 0);
			}
			if (effMatNa6 != null)
			{
				effMatNa6.paintBottom(g, x, y + 2, getFrameMatNa_Wearing(num), 0);
				effMatNa6.paintTop(g, x, y + 2, getFrameMatNa_Wearing(num), 0);
			}
			if (b == 5 && idHair != -1 && effMatNa2 != null)
			{
				effMatNa2.paintBottomHair(g, x, y + 2, getFrameHair_Wearing(num), 0);
				effMatNa2.paintTopHair(g, x, y + 2, getFrameHair_Wearing(num), 0);
			}
			else if (b == 1 && idBody != -1 && effMatNa3 != null)
			{
				effMatNa3.paintBottomAll(g, x, y + 2, getFrameBody_Wearing(num), 0);
				effMatNa3.paintTopAll(g, x, y + 2, getFrameBody_Wearing(num), 0);
			}
			else if (b == 0 && idLeg != -1 && effMatNa5 != null)
			{
				effMatNa5.paintBottomAll(g, x, y + 2, getFrameLeg_Wearing(num), 0);
				effMatNa5.paintTopAll(g, x, y + 2, getFrameLeg_Wearing(num), 0);
			}
			else if (b == 6 && idWing != -1 && effMatNa4 != null)
			{
				effMatNa4.paintBottomWing(g, x, y + 2, getFrameWing_Wearing(num), 0);
				effMatNa4.paintTopWing(g, x, y + 2, getFrameWing_Wearing(num), 0);
			}
			else
			{
				if (getTypePart(i) <= -1)
				{
					continue;
				}
				if (b == 6 && (wing != -1 || idPartFashion[4] != -1))
				{
					CRes.getCharPartInfo(b, getTypePart(i)).paint(g, x, y, dir, num);
					if (effMatNa != null)
					{
						effMatNa.paintBottomPP(g, x, y, getFramePP_Wearing(num), 0);
						effMatNa.paintTopPP(g, x, y, getFramePP_Wearing(num), 0);
					}
				}
				else
				{
					CRes.getCharPartInfo(b, getTypePart(i)).paint(g, x, y, dir, num);
				}
			}
		}
		paintDataEff_Bot(g, x, y);
	}

	public void paintShowHairPlayer(mGraphics g, int x, int y, int hairshow)
	{
		int dir = 0;
		int num = GameCanvas.gameTick / 6 % 2;
		g.drawImage(shadow, x + 1, y + 2, 3, mGraphics.isFalse);
		int num2 = weaponType;
		if (num2 != -1 && CRes.loadImgWeaPone(clazz, num2, 0) != null)
		{
			WeaponInfo weaponInfo = CRes.loadImgWeaPone(clazz, num2, 0);
			if (weaponInfo.img != null)
			{
				g.drawRegion(weaponInfo.img, weaponInfo.mRegion[Direction][0], 0, weaponInfo.mRegion[Direction][1], weaponInfo.himg, 0, x + weaponInfo.mPos[Direction][num][0], y + weaponInfo.mPos[Direction][num][1], 0, mGraphics.isFalse);
			}
		}
		for (int i = 0; i < mTypePartPaintPlayer[Direction].Length - 1; i++)
		{
			sbyte b = mTypePartPaintPlayer[Direction][i];
			if (b == 5)
			{
				if (hairshow != -1)
				{
					CRes.getCharPartInfo(5, hairshow).paint(g, x, y, dir, num);
				}
			}
			else if (getTypePart(i) > -1)
			{
				CRes.getCharPartInfo(b, getTypePart(i)).paint(g, x, y, dir, num);
			}
		}
	}

	public virtual void paintBigAvatar(mGraphics g, int x, int y)
	{
	}

	public virtual void paintName(mGraphics g, int id)
	{
		if (GameScreen.infoGame.isMapThachdau())
		{
			return;
		}
		string st = name;
		mFont tahoma_7_white = mFont.tahoma_7_white;
		tahoma_7_white = MainTabNew.setTextColor(id);
		bool flag = true;
		int num = 0;
		if (typeSpec == 1)
		{
			if (typePk > 0)
			{
				flag = false;
			}
			num = 5;
		}
		if (idName != -1)
		{
			flag = false;
		}
		int num2 = 18;
		if (PaintInfoGameScreen.isLevelPoint)
		{
			num2 = 12;
		}
		if (typeMonster == 7)
		{
			num2 += 8;
		}
		if (isObject && PaintInfoGameScreen.isLevelPoint)
		{
			num2 += 6;
		}
		if (flag)
		{
			tahoma_7_white.drawString(g, st, x, y - ysai - dy + dyWater - (isDongBang ? 5 : 0) - hOne - num2 - dyMount - yjum, 2, mGraphics.isFalse);
		}
		if (typeObject == 0 && typeSpec == 1 && flag && !iscuop)
		{
			num2 += 10;
			tahoma_7_white.drawString(g, T.nhanban, x, y - ysai - dy + dyWater - (isDongBang ? 5 : 0) - hOne - num2 - dyMount - yjum, 2, mGraphics.isFalse);
		}
		if (typeObject == 2 && chat == null)
		{
			AvMain.fraQuest.drawFrame(typeNPC, x - 6, y - ysai - dy + dyWater - hOne - num2 - 18 - 4 + GameCanvas.gameTick / 2 % 4, 0, g);
		}
		int num3 = 0;
		if ((Player.party != null && isParty) || isShowHP || typeMonster == 7)
		{
			int num4 = 44;
			if (typeObject == 2 || typeMonster == 7)
			{
				num4 = hOne + 5;
			}
			g.setColor(8062494);
			g.fillRect(x - 20, y - ysai - dy + dyWater - num4 - num2, 40, 3, mGraphics.isFalse);
			g.setColor(16197705);
			g.fillRect(x - 20, y - ysai - dy + dyWater - num4 - num2, 40 * hp / maxHp, 3, mGraphics.isFalse);
			num3 += 5;
		}
		if (myClan != null && typeSpec != 1)
		{
			paintIconClan(g, x - 1, y - ysai - dy + dyWater - hOne - num2 - 8 - num3 - dyMount - yjum, 2);
			num3 += 16;
		}
		if (typePk >= 0 && typeObject == 0 && !isPkVantieu())
		{
			num3 += 59;
			if (mGraphics.zoomLevel < 3)
			{
				AvMain.fraPk.drawFrame(typePk * 3 + GameCanvas.gameTick / 3 % 3, x, y - dy + dyWater - ysai - num3 + 18 - num2 + num - dyMount - yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
			else
			{
				AvMain.fraPkArr[typePk * 3 + GameCanvas.gameTick / 3 % 3].drawFrame(0, x, y - dy + dyWater - ysai - num3 + 18 - num2 + num - dyMount - yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
		}
	}

	public virtual void paintNameShow(mGraphics g, int x, int y, bool islevel)
	{
		string nameAndClan = getNameAndClan(" - ");
		if (myClan != null)
		{
			x += 16;
			paintIconClan(g, x - 8, y + 6, -1);
		}
		mFont.tahoma_7b_white.drawString(g, nameAndClan, x, y - dyMount - yjum, 0, mGraphics.isTrue);
	}

	public virtual void paintNameFocus(mGraphics g)
	{
		if (GameScreen.infoGame.isMapThachdau() || GameScreen.ObjFocus == null || PaintInfoGameScreen.isLevelPoint)
		{
			return;
		}
		MainObject objFocus = GameScreen.ObjFocus;
		int num = objFocus.x;
		int num2 = objFocus.y - objFocus.ysai - objFocus.dy + objFocus.dyWater - objFocus.hOne;
		int num3 = 18;
		bool flag = true;
		int num4 = 0;
		if (typeSpec == 1)
		{
			if (typePk > 0)
			{
				flag = false;
			}
			num4 = 5;
		}
		string st = objFocus.name;
		mFont mFont2 = mFont.tahoma_7b_white;
		if (typeObject == 3)
		{
			mFont2 = MainTabNew.setTextColorName(colorName);
		}
		if (typeObject == 2 && chat == null)
		{
			AvMain.fraQuest.drawFrame(typeNPC, num - 6, num2 - num3 - 18 - 4 + GameCanvas.gameTick / 2 % 4, 0, g);
		}
		if (idName == -1)
		{
			mFont2.drawString(g, st, num, num2 - num3 - dyMount - (isDongBang ? 5 : 0) - yjum, 2, mGraphics.isFalse);
		}
		int num5 = 0;
		if (typeObject == 0 && typeSpec == 1 && flag && !iscuop)
		{
			num3 += 10;
			num5 += 10;
			mFont2.drawString(g, T.nhanban, num, num2 - num3 - dyMount - (isDongBang ? 5 : 0) - yjum, 2, mGraphics.isFalse);
		}
		if (Player.party != null && objFocus.isParty)
		{
			num5 = 5;
		}
		if (myClan != null && objFocus.typeSpec != 1)
		{
			paintIconClan(g, num, num2 - num3 - 8 - num5 - dyMount - yjum, 2);
			num5 += 16;
		}
		if (objFocus.typePk >= 0 && objFocus.typeObject == 0 && !isPkVantieu())
		{
			num5 += 20;
			if (mGraphics.zoomLevel < 3)
			{
				AvMain.fraPk.drawFrame(typePk * 3 + GameCanvas.gameTick / 3 % 3, num, num2 - num5 - dyMount - yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
			else
			{
				AvMain.fraPkArr[typePk * 3 + GameCanvas.gameTick / 3 % 3].drawFrame(0, num, num2 - num5 + num4 - dyMount - yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
		}
	}

	public static void updatefocus()
	{
		if (GameScreen.ObjFocus == null)
		{
			return;
		}
		if (GameScreen.ObjFocus.maxHp > 0 && (!PaintInfoGameScreen.isLevelPoint || Main.isPC) && GameScreen.ObjFocus.typeObject != 10)
		{
			long num = GameScreen.ObjFocus.hp;
			long num2 = 10L;
			long num3 = num * num2;
			framefocus = (sbyte)(num3 / GameScreen.ObjFocus.maxHp);
			if (framefocus > 9)
			{
				framefocus = 9;
			}
		}
		framefocus = (sbyte)CRes.abs(framefocus - 9);
		if (GameScreen.ObjFocus.typeObject == 3 || GameScreen.ObjFocus.typeObject == 4)
		{
			framefocus = 0;
		}
	}

	public static void paintFocus(mGraphics g)
	{
		if (GameScreen.ObjFocus == null || (PaintInfoGameScreen.isLevelPoint && !Main.isPC) || GameScreen.ObjFocus.typeObject == 10)
		{
			return;
		}
		MainObject objFocus = GameScreen.ObjFocus;
		int num = 1;
		if (objFocus.typeObject == 1)
		{
			if (!objFocus.canFocusMon)
			{
				return;
			}
			num = 4;
			if (objFocus.typeMonster == 3 || objFocus.typeMonster == 5 || objFocus.typeMonster == 10 || objFocus.typeMonster == 8)
			{
				num = 12;
			}
		}
		if (Wfc == 0)
		{
			Wfc = mImage.getImageWidth(newfocus.image);
			Hfc = mImage.getImageHeight(newfocus.image) / 10;
		}
		g.drawRegion(newfocus, 0, framefocus * Hfc, Wfc, Hfc, 0, objFocus.x, objFocus.y - objFocus.hOne - objFocus.dy + objFocus.dyWater - num - GameCanvas.gameTick % 7 - objFocus.dyMount - objFocus.yjum, 3, mGraphics.isFalse);
		if ((Player.party != null && objFocus.isParty) || (objFocus.isShowHP && !Main.isPC))
		{
			int num2 = 64;
			if (objFocus.typeObject == 2)
			{
				num2 = objFocus.hOne + 23;
			}
			g.setColor(8062494);
			g.fillRect(objFocus.x - 20, objFocus.y - num2 - objFocus.dyMount - objFocus.yjum, 40, 3, mGraphics.isFalse);
			g.setColor(16197705);
			g.fillRect(objFocus.x - 20, objFocus.y - num2 - objFocus.dyMount - objFocus.yjum, 40 * objFocus.hp / objFocus.maxHp, 3, mGraphics.isFalse);
		}
	}

	public static void paintHPQuai(mGraphics g, int x, int y, int wHp)
	{
		g.setColor(0);
		g.fillRect(x - 13, y - 3, 26, 5, mGraphics.isTrue);
		g.setColor(16777215);
		g.fillRect(x - 12, y - 2, 24, 3, mGraphics.isTrue);
		g.setColor(12724553);
		g.fillRect(x - 12, y - 2, wHp, 3, mGraphics.isTrue);
	}

	public void updateDataEffect()
	{
		int num = vecDataSkillEff.size();
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null)
			{
				dataSkillEff.update();
				if (dataSkillEff.wantDetroy)
				{
					vecDataSkillEff.removeElement(dataSkillEff);
				}
			}
		}
	}

	public override void update()
	{
		x += vx;
		y += vy;
		if (isjum)
		{
			yjum += vjum;
			vjum += mjum;
			if (yjum > range)
			{
				yjum = range;
				vjum = -5;
				mjum = -2;
			}
			if (yjum <= 0)
			{
				yjum = 0;
				isjum = false;
			}
		}
		if (isMoveOut)
		{
			move_to_point();
		}
		updateDy();
		if (chat != null)
		{
			chat.updatePos(x, y - hOne - 30);
			if ((this != GameScreen.player || GameScreen.player.currentQuest == null) && chat.setOff())
			{
				chat = null;
			}
		}
		if (isTanHinh)
		{
			timeTanHinh++;
			if (timeTanHinh > 40)
			{
				timeTanHinh = 0;
				isTanHinh = false;
			}
		}
		for (int i = 0; i < vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)vecBuff.elementAt(i);
			mainBuff.update();
			if (mainBuff.isRemove)
			{
				vecBuff.removeElement(mainBuff);
				i--;
			}
		}
		if (isSend)
		{
			timeGet++;
			if (timeGet > 40)
			{
				isSend = false;
				timeGet = 0;
			}
		}
		if (strChatPopup != null)
		{
			addChat(strChatPopup, isStop: true);
			strChatPopup = null;
		}
		if (myClan != null && myClan.isRemove)
		{
			myClan = null;
		}
		if (isSleep)
		{
			vx = 0;
			vy = 0;
			toX = x;
			toY = y;
			eye = 0;
			if (isDie || timeSleep - mSystem.currentTimeMillis() < 0)
			{
				isSleep = false;
				timeSleep = mSystem.currentTimeMillis();
			}
		}
		if (isStun)
		{
			vx = 0;
			vy = 0;
			toX = x;
			toY = y;
			if (isDie || timeStun - mSystem.currentTimeMillis() < 0)
			{
				isStun = false;
				timeStun = mSystem.currentTimeMillis();
			}
		}
		if (isDongBang)
		{
			vx = 0;
			vy = 0;
			toX = x;
			toY = y;
			if (effAuto == null)
			{
				effAuto = new EffectAuto(51, x, y, 0, 0, 0, 0);
			}
			if (effAuto != null)
			{
				effAuto.update();
			}
			if (isDie || timeDongBang - mSystem.currentTimeMillis() < 0)
			{
				isDongBang = false;
				timeDongBang = mSystem.currentTimeMillis();
				GameScreen.addEffectEndKill(15, x, y);
				effAuto = null;
			}
		}
		if (isBinded)
		{
			vx = 0;
			vy = 0;
			toX = x;
			toY = y;
			if (isDie || timeBind - mSystem.currentTimeMillis() < 0)
			{
				isBinded = false;
				timeBind = mSystem.currentTimeMillis();
			}
		}
		if (isno)
		{
			vx = 0;
			vy = 0;
			toX = x;
			toY = y;
			if (isDie || timeno - mSystem.currentTimeMillis() < 0)
			{
				isno = false;
				timeno = mSystem.currentTimeMillis();
			}
		}
		if (isnoBoss84 && (isDie || (timenoBoss84 - mSystem.currentTimeMillis()) / 1000 <= 0))
		{
			isnoBoss84 = false;
			timenoBoss84 = mSystem.currentTimeMillis();
		}
		if (isNPC() && Direction != 0)
		{
			Direction = 0;
		}
		if (typeMount == -1 && dyMount != 0)
		{
			resetMount();
		}
		updateMount();
		updateEffauto();
		updatefocus();
		updateEffectWeapon();
	}

	public void updateActionPerson()
	{
		if (Action == 4)
		{
			if (typeMount != -1)
			{
				typeMount = -1;
			}
			isDongBang = false;
			if (frameDie == 0)
			{
				if (CRes.random(20) == 0)
				{
					frameDie = 1;
				}
			}
			else if (CRes.random(3) == 0)
			{
				frameDie = 0;
			}
			isDongBang = false;
			effAuto = null;
			if (!GameCanvas.lowGraphic && CRes.random(50) == 0)
			{
				GameScreen.addEffectKill(69, ID, typeObject, ID, typeObject, 0, 0);
				if (CRes.random(10) == 0)
				{
					GameScreen.addEffectKill(69, ID, typeObject, ID, typeObject, 0, 0);
				}
			}
			return;
		}
		switch (Action)
		{
		case 0:
			f++;
			if (f > A_Stand.Length - 1)
			{
				f = 0;
			}
			frame = A_Stand[f];
			Fhorse = frame;
			break;
		case 1:
			f++;
			if (idHorse != -1)
			{
				if (f > horseMove.Length - 1)
				{
					f = 0;
				}
			}
			else if (f > A_Move.Length - 1)
			{
				f = 0;
			}
			if (vx == 0 && vy == 0 && posTransRoad == null)
			{
				Action = 0;
				frameLeg = CRes.random(4);
				f = 0;
			}
			if (idHorse != -1)
			{
				Fhorse = horseMove[f];
				frame = 3;
			}
			else
			{
				frame = A_Move[f];
			}
			if (isMainChar() && idHorse == 114 && !isWater && GameCanvas.gameTick % 5 == 0)
			{
				GameScreen.addEffectEndKill_Direction(58, x, y + ((Direction == 2 || Direction == 3) ? 10 : 0), Direction, -1);
			}
			if (isFootSnow && !isWater && GameCanvas.gameTick % 5 == 0)
			{
				GameScreen.addEffectEndKill_Direction(56, x, y, Direction, -1);
			}
			break;
		case 2:
			if (PlashNow != null)
			{
				ListKillNow.updateEffSkill();
				PlashNow.update(this);
			}
			break;
		}
	}

	public void updateDy()
	{
		if (dyKill > 0)
		{
			dy = dyKill;
			timeDyKill++;
			if (timeDyKill > 30)
			{
				dyKill = 30;
			}
			return;
		}
		if (dy > 0)
		{
			vDy -= 2;
			dy += vDy;
		}
		if (dy < 0)
		{
			dy = -dy;
			vDy = 0;
		}
		if (dy < 3)
		{
			dy = 0;
		}
		timeDyKill = 0;
	}

	public void updateEye()
	{
		if (hp < hpEffect)
		{
			eye = 3;
			return;
		}
		if (eye == 3)
		{
			eye = EyeMain;
		}
		if (eye == -1)
		{
			return;
		}
		timeEye++;
		if (eye < 3 || eye == 4 || eye == 5)
		{
			if (eye == 4 && timeEye > 2)
			{
				eye = 5;
			}
			if (eye == 2)
			{
				if (timeEye >= 8)
				{
					timeEye = 0;
					eye = EyeMain;
					if (clazz < 2)
					{
						endEye = CRes.random(30, 80);
					}
					else
					{
						endEye = CRes.random(10, 60);
					}
				}
			}
			else if (timeEye >= 3)
			{
				timeEye = 0;
				eye = EyeMain;
				if (clazz < 2)
				{
					endEye = CRes.random(30, 80);
				}
				else
				{
					endEye = CRes.random(10, 60);
				}
			}
		}
		else if (timeEye >= endEye)
		{
			timeEye = 0;
			eye = 0;
		}
	}

	public virtual void move_to_XY()
	{
		if (!Canmove() || isBinded)
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
			if (CRes.abs(x - toX) > vMax + getVmount())
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
				else
				{
					vx = toX - x;
				}
			}
			else if (CRes.abs(y - toY) > vMax + getVmount())
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
				else
				{
					vy = toY - y;
				}
			}
			else
			{
				if (isDetonateInDest)
				{
					GameScreen.addEffectEndKill(43, x, y);
					LoadMap.timeVibrateScreen = 10;
					isStop = true;
				}
				vx = 0;
				vy = 0;
			}
		}
	}

	public static MainObject get_Object(int ID, sbyte tem)
	{
		for (int num = GameScreen.Vecplayers.size() - 1; num >= 0; num--)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(num);
			if (mainObject != null)
			{
				if (tem == 2 && mainObject.getIDnpc() == ID)
				{
					return mainObject;
				}
				if (mainObject.typeObject == tem && mainObject.ID == ID)
				{
					return mainObject;
				}
			}
		}
		return null;
	}

	public static MainObject get_Item_Object(int ID, int typeItem)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject.typeObject == typeItem && mainObject.ID == ID)
			{
				return mainObject;
			}
		}
		return null;
	}

	public static MainObject get_Item_Object(int ID)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject.ID == ID)
			{
				return mainObject;
			}
		}
		return null;
	}

	public static int getDistance(int x, int y, int x2, int y2)
	{
		return getDistance(x - x2, y - y2);
	}

	public static int getDistance(int x, int y)
	{
		return CRes.sqrt(x * x + y * y);
	}

	public void setMove(bool isAutomove)
	{
		if (isMoveOut)
		{
			return;
		}
		int tile = GameCanvas.loadmap.getTile(x + vx, y + vy);
		if (tile == 2 && !isMountFly())
		{
			if (vy != 0)
			{
				if (vy > 0)
				{
					vy = vMax + getVmount() - 1;
				}
				else
				{
					vy = -(vMax + getVmount()) + 1;
				}
			}
			if (vx != 0)
			{
				if (vx > 0)
				{
					vx = vMax + getVmount() - 1;
				}
				else
				{
					vx = -(vMax + getVmount()) + 1;
				}
			}
			isWater = true;
			dyWater = 3;
		}
		else
		{
			isWater = false;
			dyWater = 0;
			if (tile == 1)
			{
				if (isAutomove)
				{
					setAutoMoveNear();
				}
				else
				{
					Action = 0;
					frameLeg = CRes.random(4);
					vx = 0;
					vy = 0;
				}
			}
			if (GameCanvas.loadmap.getTile(x, y) == 2 && !isMountFly())
			{
				isWater = true;
				dyWater = 3;
			}
		}
		if (vx != 0 || vy != 0)
		{
			return;
		}
		int tile2 = GameCanvas.loadmap.getTile(x, y);
		if (tile2 != 1 && tile2 != -1)
		{
			return;
		}
		int num = 24;
		int num2 = x * 1000;
		int num3 = y * 1000;
		int num4 = 0;
		bool flag = false;
		do
		{
			flag = false;
			int num5 = num2 + CRes.cos(num4) * num;
			int num6 = num3 + CRes.sin(num4) * num;
			if (num5 >= 0 && num6 >= 0)
			{
				int tile3 = GameCanvas.loadmap.getTile(num5 / 1000, num6 / 1000);
				if (tile3 == 0 || tile3 == 2)
				{
					x = num5 / 1000;
					y = num6 / 1000;
					resetAction();
					flag = true;
				}
			}
			num4 += 44;
			if (num4 >= 360)
			{
				num4 = 0;
				num += 24;
			}
		}
		while (!flag);
	}

	public void setAutoMoveNear()
	{
		int num = GameCanvas.loadmap.getIndex(x + vx, y + vy);
		if (vy != 0)
		{
			if (num % GameCanvas.loadmap.mapW > 0 && (GameCanvas.loadmap.getTile(x + vx - LoadMap.wTile, y + vy) == 0 || GameCanvas.loadmap.getTile(x + vx - LoadMap.wTile, y + vy) == 2) && (GameCanvas.loadmap.getTile(x + vx - LoadMap.wTile, y) == 0 || GameCanvas.loadmap.getTile(x + vx - LoadMap.wTile, y) == 2))
			{
				vx = -(vMax + getVmount());
				Direction = 2;
				vy = 0;
			}
			else if (num % GameCanvas.loadmap.mapW < GameCanvas.loadmap.mapW - 1 && (GameCanvas.loadmap.getTile(x + vx + LoadMap.wTile, y + vy) == 0 || GameCanvas.loadmap.getTile(x + vx + LoadMap.wTile, y + vy) == 2) && (GameCanvas.loadmap.getTile(x + vx + LoadMap.wTile, y) == 0 || GameCanvas.loadmap.getTile(x + vx + LoadMap.wTile, y) == 2))
			{
				vx = vMax + getVmount();
				Direction = 3;
				vy = 0;
			}
			else
			{
				vy = 0;
			}
		}
		else if (vx != 0)
		{
			if ((GameCanvas.loadmap.getTile(x + vx, y + vy - LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(x + vx, y + vy - LoadMap.wTile) == 2) && (GameCanvas.loadmap.getTile(x, y + vy - LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(x, y + vy - LoadMap.wTile) == 2))
			{
				vy = -(vMax + getVmount());
				Direction = 1;
				vx = 0;
			}
			else if ((GameCanvas.loadmap.getTile(x + vx, y + vy + LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(x + vx, y + vy + LoadMap.wTile) == 2) && (GameCanvas.loadmap.getTile(x, y + vy + LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(x, y + vy + LoadMap.wTile) == 2))
			{
				vy = vMax + getVmount();
				Direction = 0;
				vx = 0;
			}
			else
			{
				vx = 0;
			}
		}
		if (vx == 0 && vy == 0)
		{
			Action = 0;
			frameLeg = CRes.random(4);
		}
	}

	public void setSpeed(int max)
	{
		switch (Direction)
		{
		case 1:
			vy = -max;
			vx = 0;
			break;
		case 0:
			vy = max;
			vx = 0;
			break;
		case 2:
			vy = 0;
			vx = -max;
			break;
		case 3:
			vy = 0;
			vx = max;
			break;
		}
	}

	public void setSpeedInDirection(int max)
	{
		int a = CRes.random_Am_0(3);
		if (CRes.abs(a) > 1)
		{
			max--;
		}
		switch (Direction)
		{
		case 1:
			vy = -max;
			vx = a;
			break;
		case 0:
			vy = max;
			vx = a;
			break;
		case 2:
			vy = a;
			vx = -max;
			break;
		case 3:
			vy = a;
			vx = max;
			break;
		}
		if (vx == 0 && CRes.random(3) == 0)
		{
			time = 0;
			Action = 0;
			vx = 0;
			vy = 0;
		}
		if (vx > 0)
		{
			Direction = 3;
		}
		else
		{
			Direction = 2;
		}
	}

	public bool setIsInScreen(int x, int y, int wOne, int hOne)
	{
		if (x < MainScreen.cameraMain.xCam - wOne || x > MainScreen.cameraMain.xCam + GameCanvas.w + wOne || y < MainScreen.cameraMain.yCam - hOne / 2 || y > MainScreen.cameraMain.yCam + GameCanvas.h + hOne * 3 / 2)
		{
			return false;
		}
		return true;
	}

	public static bool isInScreen(MainObject obj)
	{
		if (obj.x < MainScreen.cameraMain.xCam - obj.wOne || obj.x > MainScreen.cameraMain.xCam + GameCanvas.w + obj.wOne || obj.y < MainScreen.cameraMain.yCam - obj.hOne || obj.y > MainScreen.cameraMain.yCam + GameCanvas.h + obj.hOne * 3 / 2)
		{
			return false;
		}
		return true;
	}

	public virtual void Move_to_Focus_Person()
	{
		if ((x == toX && y == toY) || isMoveOut)
		{
			return;
		}
		if (iscuop)
		{
			int tile = GameCanvas.loadmap.getTile(x + vx, y + vy);
			if (tile == 1 || tile == -1)
			{
				isWater = false;
				dyWater = 0;
				vx = 0;
				vy = 0;
				x = toX;
				y = toY;
				timeFreeMove++;
				if (timeFreeMove >= 10)
				{
					timeFreeMove = 25;
				}
				GameScreen.addEffectEndKill(35, x, y - 20);
			}
		}
		if (CRes.abs(x - toX) > vMax + getVmount() || CRes.abs(y - toY) > vMax + getVmount())
		{
			move_to_XY_Normal();
		}
		else if (Action != 2 && Action != 3 && Action != 4)
		{
			xFire = x;
			yFire = y;
			toX = x;
			toY = y;
			vx = 0;
			vy = 0;
			Action = 0;
			frameLeg = CRes.random(4);
		}
	}

	public virtual void move_to_XY_Normal()
	{
		if (isMoveOut)
		{
			return;
		}
		if (isDirMove)
		{
			if (CRes.abs(x - toX) >= vMax + getVmount())
			{
				moveX();
				return;
			}
			if (CRes.abs(y - toY) >= vMax + getVmount())
			{
				moveY();
				return;
			}
			vx = 0;
			vy = 0;
		}
		else if (CRes.abs(y - toY) >= vMax + getVmount())
		{
			moveY();
		}
		else if (CRes.abs(x - toX) >= vMax + getVmount())
		{
			moveX();
		}
		else
		{
			vx = 0;
			vy = 0;
		}
	}

	public virtual void moveX()
	{
		if (isMoveOut)
		{
			return;
		}
		vy = 0;
		Action = 1;
		if (CRes.abs(x - toX) >= vMax + getVmount())
		{
			if (x >= toX)
			{
				vx = -(vMax + getVmount());
				Direction = 2;
			}
			else
			{
				vx = vMax + getVmount();
				Direction = 3;
			}
		}
		else
		{
			vx = toX - x;
		}
	}

	public virtual void moveY()
	{
		if (isMoveOut)
		{
			return;
		}
		vx = 0;
		Action = 1;
		if (CRes.abs(y - toY) >= vMax + getVmount())
		{
			if (y > toY)
			{
				vy = -(vMax + getVmount());
				Direction = 1;
			}
			else
			{
				vy = vMax + getVmount();
				Direction = 0;
			}
		}
		else
		{
			vy = toY - y;
		}
	}

	public void setMove(int MonWater, int t)
	{
		if (isMoveOut || isBinded || isDongBang)
		{
			return;
		}
		if ((t == 1 || t == -1) && timeFreeMove < 12)
		{
			isWater = false;
			dyWater = 0;
			vx = 0;
			vy = 0;
			isDirMove = !isDirMove;
			timeFreeMove++;
			if (timeFreeMove >= 10)
			{
				timeFreeMove = 25;
			}
			return;
		}
		isWater = false;
		dyWater = 0;
		if (timeFreeMove > 0)
		{
			timeFreeMove--;
		}
		if (t != 2 || isMountFly())
		{
			return;
		}
		isWater = true;
		dyWater = 3;
		if (vy != 0)
		{
			if (vy > 0)
			{
				vy = vMax + getVmount() - MonWater;
			}
			else
			{
				vy = -(vMax + getVmount()) + MonWater;
			}
		}
		if (vx != 0)
		{
			if (vx > 0)
			{
				vx = vMax + getVmount() - MonWater;
			}
			else
			{
				vx = -(vMax + getVmount()) + MonWater;
			}
		}
	}

	public static void init()
	{
		for (int i = 0; i < imgWeapone.Length; i++)
		{
			imgWeapone[i] = new WeaponInfo[40][];
			for (int j = 0; j < imgWeapone[i].Length; j++)
			{
				imgWeapone[i][j] = new WeaponInfo[8];
			}
		}
	}

	public void paintWeaponhideplayer(mGraphics g, int f)
	{
		int num = 0;
		if (num < 0 || num >= 5)
		{
			return;
		}
		int num2 = clazz;
		int num3 = 0;
		int num4 = 0;
		if (Action != 2)
		{
			num4 = 0;
		}
		if (weapon_frame < 0 || num < 0)
		{
			return;
		}
		WPSplashInfo wPSplashInfo = CRes.wpSplashInfos[num2][num][num4];
		if (wPSplashInfo == null)
		{
			wPSplashInfo = CRes.GetWPSplashInfo(num2, num, num4);
			return;
		}
		int num5 = 0;
		if (Action != 2 || weapon_frame < 4)
		{
			if (weapon_frame > 1)
			{
				weapon_frame = 0;
			}
			if (weapon_frame < 0)
			{
				weapon_frame = 0;
			}
			if (num5 != -1 && CRes.loadImgWeaPone(num2, num5, num3) != null)
			{
				WeaponInfo weaponInfo = CRes.loadImgWeaPone(num2, num5, num3);
				int num6 = frame;
				if (num6 > 2)
				{
					num6 = 2;
				}
				if (weaponInfo.img != null)
				{
					g.drawRegion(weaponInfo.img, weaponInfo.mRegion[Direction][0], 0, weaponInfo.mRegion[Direction][1], weaponInfo.himg, 0, x + weaponInfo.mPos[Direction][num6][0], y - ysai + weaponInfo.mPos[Direction][num6][1] - dy + dyWater - dyMount - yjum, 0, mGraphics.isTrue);
					paintEffectWeapon(g);
				}
			}
		}
		else if (weapon_frame < wPSplashInfo.P0_X[Direction].Length && wPSplashInfo.image != null)
		{
			g.drawRegion(wPSplashInfo.image, wPSplashInfo.P0_X[Direction][weapon_frame], wPSplashInfo.P0_Y[Direction][weapon_frame], wPSplashInfo.PF_W[Direction][weapon_frame], wPSplashInfo.PF_H[Direction][weapon_frame], 0, x + wPSplashInfo.PF_X[Direction][weapon_frame], f + y - ysai + wPSplashInfo.PF_Y[Direction][weapon_frame] - dy + dyWater - dyMount - yjum, 0, mGraphics.isTrue);
		}
		if (Action != 0 && Action != 1)
		{
			return;
		}
		int num7 = 0;
		if (num7 > 1)
		{
			int num8 = num7 - 1;
			if (num8 > 3)
			{
				num8 = 3;
			}
			paintEffectVukhi(g, num8, wPSplashInfo, num2);
		}
	}

	public void paintWeapon(mGraphics g, int f)
	{
		int num = 0;
		if (num < 0 || num >= 5)
		{
			return;
		}
		int num2 = clazz;
		int num3 = 0;
		int num4 = 0;
		if (Action != 2)
		{
			num4 = 0;
		}
		if (weapon_frame < 0 || num < 0)
		{
			return;
		}
		WPSplashInfo wPSplashInfo = CRes.wpSplashInfos[num2][num][num4];
		if (wPSplashInfo == null)
		{
			wPSplashInfo = CRes.GetWPSplashInfo(num2, num, num4);
			return;
		}
		int num5 = weaponType;
		if (Action != 2 || weapon_frame < 4)
		{
			if (weapon_frame > 1)
			{
				weapon_frame = 0;
			}
			if (weapon_frame < 0)
			{
				weapon_frame = 0;
			}
			if (num5 != -1 && CRes.loadImgWeaPone(num2, num5, num3) != null)
			{
				WeaponInfo weaponInfo = CRes.loadImgWeaPone(num2, num5, num3);
				int num6 = frame;
				if (num6 > 2)
				{
					num6 = 2;
				}
				if (weaponInfo.img != null)
				{
					g.drawRegion(weaponInfo.img, weaponInfo.mRegion[Direction][0], 0, weaponInfo.mRegion[Direction][1], weaponInfo.himg, 0, x + weaponInfo.mPos[Direction][num6][0], y - ysai + weaponInfo.mPos[Direction][num6][1] - dy + dyWater - dyMount - yjum, 0, mGraphics.isTrue);
					paintEffectWeapon(g);
				}
			}
		}
		else if (weapon_frame < wPSplashInfo.P0_X[Direction].Length && wPSplashInfo.image != null)
		{
			g.drawRegion(wPSplashInfo.image, wPSplashInfo.P0_X[Direction][weapon_frame], wPSplashInfo.P0_Y[Direction][weapon_frame], wPSplashInfo.PF_W[Direction][weapon_frame], wPSplashInfo.PF_H[Direction][weapon_frame], 0, x + wPSplashInfo.PF_X[Direction][weapon_frame], f + y - ysai + wPSplashInfo.PF_Y[Direction][weapon_frame] - dy + dyWater - dyMount - yjum, 0, mGraphics.isTrue);
		}
		if (Action != 0 && Action != 1)
		{
			return;
		}
		int num7 = 0;
		if (num7 > 1)
		{
			int num8 = num7 - 1;
			if (num8 > 3)
			{
				num8 = 3;
			}
			paintEffectVukhi(g, num8, wPSplashInfo, num2);
		}
	}

	private void paintEffectVukhi(mGraphics g, int id, WPSplashInfo wp, int clazz)
	{
	}

	public void resetXY()
	{
		toX = x;
		toY = y;
		vx = 0;
		vy = 0;
	}

	public virtual void beginFire()
	{
		f = 0;
		Action = 2;
		fplash = 0;
		vx = 0;
		vy = 0;
	}

	public static void startDeadFly(MainMonster m, int attacker, int typeDie)
	{
		MainObject mainObject = get_Object(attacker, 0);
		if (mainObject == null)
		{
			return;
		}
		int num = 5;
		int vyStyle = 0;
		if (m == null)
		{
			return;
		}
		int num2 = 0;
		int num3 = 0;
		if (m.typeMonster != 7 && mainObject != null)
		{
			num2 = (m.x - mainObject.x) * 2;
			num3 = (m.y - mainObject.y) * 2;
			while (getDistance(num2, num3) > 20)
			{
				num2 = num2 * 2 / 3;
				num3 = num3 * 2 / 3;
			}
			if (typeDie == 1)
			{
				num2 *= 2;
				num3 *= 2;
			}
			else if (typeDie == 2)
			{
				while (getDistance(num2, num3) > 16)
				{
					num2 = num2 * 2 / 3;
					num3 = num3 * 2 / 3;
				}
				num = 20;
				vyStyle = 18;
			}
		}
		m.startDeadFly(num2, num3, num, vyStyle);
	}

	public virtual void GiaoTiep()
	{
	}

	public void addChat(string str, bool isStop)
	{
		if (chat == null)
		{
			chat = new PopupChat();
		}
		chat.setChat(str, isStop);
		chat.updatePos(x, y - hOne - 30);
	}

	public void resetAction()
	{
		vx = (vy = 0);
		toX = x;
		toY = y;
		if (Action != 2 && Action != 4)
		{
			Action = 0;
			weapon_frame = 0;
		}
	}

	public void resetVx_vy()
	{
		vx = (vy = 0);
		if (Action == 1)
		{
			Action = 0;
		}
	}

	public static void resetDirection(MainObject idFrom, MainObject idTo)
	{
		int num = idFrom.x - idTo.x;
		int num2 = idFrom.y - idTo.y;
		int direction = ((CRes.abs(num) > CRes.abs(num2)) ? ((num <= 0) ? 3 : 2) : ((num2 > 0) ? 1 : 0));
		idFrom.Direction = direction;
	}

	public void addnewBuff(int type, int time)
	{
		for (int i = 0; i < vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)vecBuff.elementAt(i);
			if (mainBuff != null && mainBuff.typeBuff == type)
			{
				mainBuff.settimebuff(time);
				return;
			}
		}
		MainBuff o = new MainBuff(type, time);
		vecBuff.addElement(o);
	}

	public void addBuff(int type, int time, int sub)
	{
		MainBuff buff = MainBuff.getBuff(type, sub);
		if (buff != null)
		{
			buff.timeBegin = GameCanvas.timeNow;
			buff.timeOff = time;
		}
		else
		{
			buff = new MainBuff(type, time, sub);
			vecBuff.addElement(buff);
		}
	}

	public void setEye(int eye)
	{
		this.eye = eye;
		timeEye = 0;
	}

	public int skillMonster()
	{
		return 0;
	}

	public void startDie()
	{
	}

	public mVector vectorObjectNear()
	{
		mVector mVector3 = new mVector("MainObject vec");
		int num = 30;
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && mainObject != GameScreen.player && mainObject != this && mainObject.typeObject == 0)
			{
				int distance = getDistance(x, y, mainObject.x, mainObject.y - mainObject.hOne / 2);
				if (distance <= num)
				{
					mVector3.addElement(mainObject);
				}
			}
		}
		return mVector3;
	}

	public void setVx_Vy_Item(int xto, int yto)
	{
		toX = xto;
		toY = yto;
		int num = toX - x;
		int num2 = toY - y;
		if (num2 == 0)
		{
			num2 = 1;
		}
		if (num == 0)
		{
			num = 1;
		}
		int num3 = getDistance(num, num2) / (vMax + getVmount());
		if (num3 == 0)
		{
			num3 = 1;
		}
		vx = num / num3;
		vy = num2 / num3;
		if (CRes.abs(vx) > CRes.abs(num))
		{
			vx = num;
		}
		if (CRes.abs(vy) > CRes.abs(num2))
		{
			vy = num2;
		}
		timeHuyKill = num3;
	}

	public virtual bool isThacNuoc()
	{
		return false;
	}

	public virtual bool findOwner(MainObject owner)
	{
		return false;
	}

	public virtual bool isMonsterHouse()
	{
		return false;
	}

	public virtual bool isItemBox()
	{
		return false;
	}

	public virtual bool isNPC()
	{
		return isBot >= -100 && isBot < -2;
	}

	public virtual int getIDnpc()
	{
		return ID;
	}

	public virtual bool canFocus()
	{
		return true;
	}

	public virtual bool isNPC_server()
	{
		return false;
	}

	public void paint_no(mGraphics g)
	{
		if (isPaint_No)
		{
			frNo++;
			if (frNo > frameNo.Length - 1)
			{
				frNo = 0;
			}
			AvMain.fraPlayerNo.drawFrame(frameNo[frNo], x, y + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	public void move_to_point()
	{
		if (!isMoveOut)
		{
			return;
		}
		if (ID == GameScreen.player.ID)
		{
			GameCanvas.clearAll();
			posTransRoad = null;
		}
		vx = 0;
		vy = 0;
		bool flag = false;
		int num = yMoveOut - y >> 1;
		y += num;
		if (num <= 0)
		{
			y = yMoveOut;
			flag = true;
		}
		if (flag)
		{
			vx = 0;
			vy = 0;
			Action = 0;
			toX = x;
			toY = y;
			num = 0;
			yMoveOut = y;
			yMoveOut = y;
			xStand = x;
			yStand = y;
			isMoveOut = false;
		}
		else
		{
			if (GameCanvas.loadmap.getTile(x, y) == 2 && !isMountFly())
			{
				isWater = true;
				dyWater = 3;
			}
			if (GameCanvas.gameTick % 2 == 0)
			{
				GameScreen.addEffectEndKill(9, x, y);
				GameScreen.addEffectEndKill(46, x, y - 2);
			}
		}
	}

	public int getVmount()
	{
		if (typeMount == -1)
		{
			return 0;
		}
		return MountTemplate.speed[typeMount];
	}

	public bool isFramePaintMount_Truoc()
	{
		if (typeMount == -1)
		{
			return false;
		}
		sbyte[] array = MountTemplate.FRAME_VE_TRUOC[typeMount];
		for (int i = 0; i < array.Length; i++)
		{
			if (frameMount == array[i] && frameMount != -1)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void updateMount()
	{
		if (typeMount == -1)
		{
			return;
		}
		DataSkillEff effMatNa = getEffMatNa(idHorse);
		if (effMatNa != null && GameCanvas.gameTick % 5 == 0)
		{
			int num = effMatNa.listFrame.size() / 21;
			if (num == 0)
			{
				num = 1;
			}
			frameThuCuoi = (sbyte)((frameThuCuoi + 1) % num);
		}
		if (typeMount != -1)
		{
			if (effMatNa == null)
			{
				A_Move = ArrMount;
			}
			if (Action == 0)
			{
				if (Direction == 2)
				{
					if (frame == 1)
					{
						frameMount = 1;
					}
					else
					{
						frameMount = 0;
					}
					xMount = MountTemplate.dx[typeMount][0];
					yMount = MountTemplate.dy[typeMount][0];
					dyMount = MountTemplate.DY_CHAR_STAND[typeMount][0];
				}
				else if (Direction == 3)
				{
					if (frame == 1)
					{
						frameMount = 1;
					}
					else
					{
						frameMount = 0;
					}
					xMount = MountTemplate.dx[typeMount][2];
					yMount = MountTemplate.dy[typeMount][2];
					dyMount = MountTemplate.DY_CHAR_STAND[typeMount][1];
				}
				else if (Direction == 1)
				{
					if (frame == 1)
					{
						frameMount = 11;
					}
					else
					{
						frameMount = 10;
					}
					xMount = MountTemplate.dx[typeMount][4];
					yMount = MountTemplate.dy[typeMount][4];
					dyMount = MountTemplate.DY_CHAR_STAND[typeMount][2];
				}
				else
				{
					if (frame == 1)
					{
						frameMount = 6;
					}
					else
					{
						frameMount = 5;
					}
					xMount = MountTemplate.dx[typeMount][6];
					yMount = MountTemplate.dy[typeMount][6];
					dyMount = MountTemplate.DY_CHAR_STAND[typeMount][3];
				}
			}
			else
			{
				if (Action != 1)
				{
					return;
				}
				fMount++;
				if (Direction == 2)
				{
					if (fMount > MountTemplate.FRAME_MOVE_LR[typeMount].Length - 1)
					{
						fMount = 0;
					}
					frameMount = MountTemplate.FRAME_MOVE_LR[typeMount][fMount];
					xMount = MountTemplate.dx[typeMount][1];
					yMount = MountTemplate.dy[typeMount][1];
					if (frameMount == 3)
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][0];
					}
					else if (frameMount == 2)
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][1];
					}
					else
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][2];
					}
					if (fMount == 4 && !isMountFly())
					{
						GameScreen.addEffectEndKill_Direction(55, x + 19, y - 5, Direction, -1);
					}
				}
				else if (Direction == 3)
				{
					if (fMount > MountTemplate.FRAME_MOVE_LR[typeMount].Length - 1)
					{
						fMount = 0;
					}
					frameMount = MountTemplate.FRAME_MOVE_LR[typeMount][fMount];
					xMount = MountTemplate.dx[typeMount][3];
					yMount = MountTemplate.dy[typeMount][3];
					if (frameMount == 3)
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][3];
					}
					else if (frameMount == 2)
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][4];
					}
					else
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][5];
					}
					if (fMount == 4 && !isMountFly())
					{
						GameScreen.addEffectEndKill_Direction(55, x - 11, y - 5, Direction, -1);
					}
				}
				else if (Direction == 1)
				{
					if (fMount > MountTemplate.FRAME_MOVE_UP[typeMount].Length - 1)
					{
						fMount = 0;
					}
					frameMount = MountTemplate.FRAME_MOVE_UP[typeMount][fMount];
					xMount = MountTemplate.dx[typeMount][5];
					yMount = MountTemplate.dy[typeMount][5];
					if (frameMount == 13)
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][6];
					}
					else if (frameMount == 12)
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][7];
					}
					else
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][8];
					}
					if (fMount == 4 && !isMountFly())
					{
						GameScreen.addEffectEndKill_Direction(55, x - 14, y - 7, 3, -1);
						GameScreen.addEffectEndKill_Direction(55, x + 16, y - 7, 2, -1);
					}
				}
				else
				{
					if (fMount > MountTemplate.FRAME_MOVE_DOWN[typeMount].Length - 1)
					{
						fMount = 0;
					}
					frameMount = MountTemplate.FRAME_MOVE_DOWN[typeMount][fMount];
					xMount = MountTemplate.dx[typeMount][7];
					yMount = MountTemplate.dy[typeMount][7];
					if (frameMount == 8)
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][9];
					}
					else if (frameMount == 7)
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][10];
					}
					else
					{
						dyMount = MountTemplate.DY_CHAR_MOVE[typeMount][11];
					}
					if (fMount == 4 && !isMountFly())
					{
						GameScreen.addEffectEndKill_Direction(55, x - 15, y - 10, 3, -1);
						GameScreen.addEffectEndKill_Direction(55, x + 17, y - 10, 2, -1);
					}
				}
			}
		}
		else
		{
			resetMount();
		}
	}

	public void resetMount()
	{
		A_Move = ArrMount1;
		dyMount = 0;
	}

	public void paintMount_Truoc(mGraphics g)
	{
		if (idHorse == -1 && typeMount != -1 && !isDongBang)
		{
			FrameImage frameImageMount = FrameImage.getFrameImageMount(typeMount, 3, 5, 0);
			if (frameImageMount != null && isFramePaintMount_Truoc())
			{
				frameImageMount.drawFrameNew(frameMount, x + xMount, y - ysai - dy + dyWater - yjum + yMount, (Direction > 2) ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
		}
	}

	public void paintMount_Sau(mGraphics g)
	{
		if (idHorse == -1 && typeMount != -1 && !isDongBang)
		{
			FrameImage frameImageMount = FrameImage.getFrameImageMount(typeMount, 3, 5, 0);
			if (frameImageMount != null && !isFramePaintMount_Truoc())
			{
				frameImageMount.drawFrameNew(frameMount, x + xMount, y - ysai - dy + dyWater - yjum + yMount, (Direction > 2) ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
		}
	}

	public void setArrayGemKham(short[][] array)
	{
		arrayGemKham = array;
		int num = clazz;
		switch (num)
		{
		case 3:
			num = 2;
			break;
		case 2:
			num = 3;
			break;
		}
		slotGem = new sbyte[arrayGemKham[8 + num].Length];
		for (int i = 0; i < arrayGemKham.Length; i++)
		{
			for (int j = 0; j < arrayGemKham[i].Length; j++)
			{
				if (arrayGemKham[8 + num][j] >= 23 && arrayGemKham[8 + num][j] <= 27)
				{
					slotGem[j] = 0;
				}
				else if (arrayGemKham[8 + num][j] >= 28 && arrayGemKham[8 + num][j] <= 32)
				{
					slotGem[j] = 1;
				}
				else
				{
					slotGem[j] = -1;
				}
			}
		}
	}

	private void paintEffectWeapon(mGraphics g)
	{
		if (weaponEff != null)
		{
			weaponEff.drawFrameEffectSkill(fweapon, x + dxEff, y - ysai + dyEff - dy + dyWater - dyMount - yjum, transEff[Direction], mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	private void updateEffectWeapon()
	{
		if (GameCanvas.gameTick % 2 == 0)
		{
			fweapon++;
		}
		if (fweapon > 4)
		{
			fweapon = 0;
		}
		timeEff++;
		if (timeEff < timeShow)
		{
			if (slotGem[0] == -1)
			{
				if (weaponEff != null)
				{
					weaponEff = null;
				}
				if (fweapon != 0)
				{
					fweapon = 0;
				}
			}
			else
			{
				weaponEff = weaponEff_Gem[slotGem[0]];
			}
		}
		else if (timeEff >= timeShow * 2 && timeEff < timeShow * 3)
		{
			if (slotGem[1] == -1)
			{
				if (weaponEff != null)
				{
					weaponEff = null;
				}
				if (fweapon != 0)
				{
					fweapon = 0;
				}
			}
			else
			{
				weaponEff = weaponEff_Gem[slotGem[1]];
			}
		}
		else if (timeEff >= timeShow * 4 && timeEff < timeShow * 5)
		{
			if (slotGem[2] == -1)
			{
				if (weaponEff != null)
				{
					weaponEff = null;
				}
				if (fweapon != 0)
				{
					fweapon = 0;
				}
			}
			else
			{
				weaponEff = weaponEff_Gem[slotGem[2]];
			}
		}
		else if (timeEff >= timeShow * 6)
		{
			timeEff = 0;
			if (weaponEff != null)
			{
				weaponEff = null;
			}
			if (fweapon != 0)
			{
				fweapon = 0;
			}
		}
		else
		{
			if (weaponEff != null)
			{
				weaponEff = null;
			}
			if (fweapon != 0)
			{
				fweapon = 0;
			}
		}
		if (slotGem[0] != -1 && weaponEff == weaponEff_Gem[slotGem[0]])
		{
			dxEff = eff_dx[slotGem[0]][Direction];
			if (frame == 1)
			{
				dyEff = eff_dy[slotGem[0]][Direction] + 1;
			}
			else
			{
				dyEff = eff_dy[slotGem[0]][Direction];
			}
		}
		if (slotGem[1] != -1 && weaponEff == weaponEff_Gem[slotGem[1]])
		{
			dxEff = eff_dx[slotGem[1]][Direction];
			if (frame == 1)
			{
				dyEff = eff_dy[slotGem[1]][Direction] + 1;
			}
			else
			{
				dyEff = eff_dy[slotGem[1]][Direction];
			}
		}
		if (slotGem[2] != -1 && weaponEff == weaponEff_Gem[slotGem[2]])
		{
			dxEff = eff_dx[slotGem[2]][Direction];
			if (frame == 1)
			{
				dyEff = eff_dy[slotGem[2]][Direction] + 1;
			}
			else
			{
				dyEff = eff_dy[slotGem[2]][Direction];
			}
		}
	}

	public virtual void updateoverHP_MP()
	{
		countmp++;
		if (countmp > 10)
		{
			countmp = 0;
		}
		if (mp < maxMp / 10)
		{
			overMP = true;
		}
		else
		{
			overMP = false;
		}
		if (hp < maxHp / 10 && hp > 0)
		{
			overHP = true;
		}
		else
		{
			overHP = false;
		}
	}

	public virtual void addEffectCharWearing(int idEffect, int idimage)
	{
	}

	public virtual void setNameStore(string name)
	{
	}

	public virtual void removeNameStore()
	{
	}

	public virtual bool isSelling()
	{
		return false;
	}

	public void paintEffectCharWearing(mGraphics g)
	{
		if (vecEffectCharWearing.size() > 0)
		{
			for (int i = 0; i < vecEffectCharWearing.size(); i++)
			{
				((EffectCharWearing)vecEffectCharWearing.elementAt(i))?.paint(g, x, y);
			}
		}
	}

	public void updateEffectCharWearing()
	{
		if (vecEffectCharWearing.size() > 0)
		{
			for (int i = 0; i < vecEffectCharWearing.size(); i++)
			{
				((EffectCharWearing)vecEffectCharWearing.elementAt(i))?.update();
			}
		}
	}

	public void removeEffectCharWearing(int typeEff)
	{
		int num = vecEffectCharWearing.size();
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			EffectCharWearing effectCharWearing = (EffectCharWearing)vecEffectCharWearing.elementAt(i);
			if (effectCharWearing != null && effectCharWearing.type == typeEff)
			{
				vecEffectCharWearing.removeElement(effectCharWearing);
			}
		}
	}

	public void removeAllEffCharWearing()
	{
		vecEffectCharWearing.removeAllElements();
	}

	public virtual bool isMiNuong()
	{
		return false;
	}

	public virtual void SetnameOwner(string name)
	{
	}

	public void addDataEff(int type, sbyte[] arr, int dxx, int dyy)
	{
		for (int i = 0; i < vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.idEff == type)
			{
				vecDataSkillEff.removeElement(dataSkillEff);
			}
		}
		DataSkillEff o = new DataSkillEff(arr, (short)type, dxx, dyy);
		vecDataSkillEff.addElement(o);
	}

	public void addDataEff(int type, sbyte[] arr, int dxx, int dyy, long timelive, sbyte typemove)
	{
		for (int i = 0; i < vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.idEff == type)
			{
				vecDataSkillEff.removeElement(dataSkillEff);
			}
		}
		DataSkillEff o = new DataSkillEff(arr, (short)type, dxx, dyy, timelive, typemove);
		vecDataSkillEff.addElement(o);
	}

	public void addDataEff2(int type, sbyte[] arr, int dxx, int dyy, long timelive, sbyte typemove)
	{
		for (int i = 0; i < vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.idEff == type)
			{
				vecDataSkillEff.removeElement(dataSkillEff);
			}
		}
		DataSkillEff dataSkillEff2 = new DataSkillEff(arr, (short)type, dxx, dyy, timelive, typemove);
		dataSkillEff2.isremovebyTime = false;
		dataSkillEff2.isremovebyFrame = true;
		vecDataSkillEff.addElement(dataSkillEff2);
	}

	public void removeDataSkillEff(int id)
	{
		for (int i = 0; i < vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.idEff == id)
			{
				vecDataSkillEff.removeElement(dataSkillEff);
			}
		}
	}

	public bool isHairNotHat()
	{
		if (Player.ID_HAIR_NO_HAT == null)
		{
			return false;
		}
		if (idPartFashion[2] != -1)
		{
			return false;
		}
		int num = Player.ID_HAIR_NO_HAT.Length;
		for (int i = 0; i < num; i++)
		{
			sbyte b = Player.ID_HAIR_NO_HAT[i];
			if (b == hair)
			{
				return true;
			}
		}
		return false;
	}

	public int getDy()
	{
		return 0;
	}

	public int getHeight()
	{
		return hOne;
	}

	public int getDir()
	{
		return Direction;
	}

	public void addiconClan()
	{
	}

	public virtual bool canNotMove()
	{
		return false;
	}

	public virtual bool canfire()
	{
		return false;
	}
}
