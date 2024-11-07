using System;

public class EffectSkill : MainEffect
{
	public const sbyte EFF_NORMAL = 0;

	public const sbyte EFF_SPEED = 1;

	public const sbyte EFF_STAR = 6;

	public const sbyte EFF_LIGHTING = 10;

	public const sbyte EFF_STONE_DROP_MORE = 11;

	public const sbyte EFF_CRACK_EARTH = 12;

	public const sbyte EFF_ARROW_RAIN = 20;

	public const sbyte EFF_KIEM_AND_2KIEM_LV1 = 21;

	public const sbyte EFF_SUNG_LV2 = 22;

	public const sbyte EFF_SUNG_LV3 = 23;

	public const sbyte EFF_PS_LV2 = 25;

	public const sbyte EFF_KIEM_LV3 = 26;

	public const sbyte EFF_2KIEM_LV2 = 27;

	public const sbyte EFF_KIEM_LV2 = 28;

	public const sbyte EFF_STAR_LINE_IN = 29;

	public const sbyte EFF_STAR_POINT_IN = 30;

	public const sbyte EFF_SUNG_LV4 = 31;

	public const sbyte EFF_2KIEM_LV4 = 34;

	public const sbyte EFF_PS_AND_SUNG_LV1 = 38;

	public const sbyte EFF_2KIEM_LV5 = 40;

	public const sbyte EFF_XP = 41;

	public const sbyte EFF_LEVEL_UP = 42;

	public const sbyte EFF_LINE_LEVEL_UP = 43;

	public const sbyte EFF_2KIEM_TRUNG_DOC = 46;

	public const sbyte EFF_2KIEM_GAI_DOC = 47;

	public const sbyte EFF_PS_XUNGKICH = 49;

	public const sbyte EFF_MONSTER_NEAR = 50;

	public const sbyte EFF_SUNG_LASER = 51;

	public const sbyte EFF_KIEM_FIRE = 52;

	public const sbyte EFF_KIEM_LV6 = 53;

	public const sbyte EFF_KIEM_LV7 = 54;

	public const sbyte EFF_2KIEM_CRI = 55;

	public const sbyte EFF_BUFF = 56;

	public const sbyte EFF_BUFF_POINT_IN = 57;

	public const sbyte EFF_TELEPORT = 58;

	public const sbyte EFF_PS_CAU_NOILUC = 59;

	public const sbyte EFF_PS_DONGDAT = 60;

	public const sbyte EFF_PS_ICE_RAIN = 61;

	public const sbyte EFF_SUNG_BAO_DAN = 62;

	public const sbyte EFF_SUNG_DAY_DAN = 63;

	public const sbyte EFF_PS_ICE_UP = 64;

	public const sbyte EFF_SUNG_RAIN_ROCKET = 65;

	public const sbyte EFF_SUNG_RAIN_LIGHTNING = 66;

	public const sbyte EFF_PHAN_DAMAGE = 67;

	public const sbyte EFF_FOCUS = 68;

	public const sbyte EFF_SMALL_SMOKE = 69;

	public const sbyte EFF_MON_BUFF = 70;

	public const sbyte EFF_BOSS_CAY_1 = 71;

	public const sbyte EFF_BOSS_CAY_2 = 72;

	public const sbyte EFF_BOSS_ONG_1 = 73;

	public const sbyte EFF_BOSS_ONG_2 = 74;

	public const sbyte EFF_BOSS_CUA_1 = 75;

	public const sbyte EFF_BOSS_CUA_2 = 76;

	public const sbyte EFF_BOSS_SOI_1 = 77;

	public const sbyte EFF_BOSS_SOI_2 = 14;

	public const sbyte EFF_BOSS_DA_1 = 78;

	public const sbyte EFF_BOSS_DA_2 = 79;

	public const sbyte EFF_KILL_GHOST = 80;

	public const sbyte EFF_PHO_BANG = 81;

	public const sbyte EFF_SUNG_SET_NEW = 82;

	public const sbyte EFF_HUT_MP_HP = 83;

	public const sbyte EFF_STAR_LINE_IN_SLOW = 84;

	public const sbyte EFF_NHANBAN_LV2 = 85;

	public const sbyte EFF_SERVER_THIEN_THACH = 86;

	public const sbyte EFF_BUFF_MO_BANGHOI = 87;

	public const sbyte EFF_DAN_FOCUS = 88;

	public const sbyte EFF_HUT_MP = 89;

	public const sbyte EFF_ICE_NOVA = 90;

	public const sbyte EFF_POISON_NOVA = 91;

	public const sbyte EFF_HUT_HP = 92;

	public const sbyte EFF_BOSS_DE_1 = 93;

	public const sbyte EFF_BOSS_DE_2 = 94;

	public const sbyte EFF_Tower_1 = 95;

	public const sbyte EFF_Tower_2 = 96;

	public const sbyte EFF_Tower_3 = 97;

	public const sbyte EFF_Tower_4 = 98;

	public const sbyte EFF_BOSS_Medusa1 = 99;

	public const sbyte EFF_BOSS_Medusa2 = 100;

	public const sbyte EFF_PET_OWL = 101;

	public const sbyte EFF_PET_EAGLE = 102;

	public const sbyte EFF_BOSS_84_NO = 103;

	public const sbyte EFF_BOSS_34_DAM_TUNG = 104;

	public const sbyte EFF_BOSS_34_LASER = 105;

	public const sbyte EFF_BOSS_34_LASERLAN = 106;

	public const sbyte EFF_BOSS_NO = 107;

	public const sbyte EFF_BOSS_84_MUNTI = 108;

	public const sbyte EFF_PHAPSU_BANG = 109;

	public const sbyte EFF_KIEM_LON_NGU = 110;

	public const sbyte EFF_SUNG_NGU = 111;

	public const sbyte EFF_KIEM_NHO_TROI = 112;

	public const sbyte EFF_BOSS_NOEL_1 = 113;

	public const sbyte EFF_BOSS_NOEL_2 = 114;

	public const sbyte EFF_BOSS_NOEL_3 = 115;

	public const int EFF_BIG_SWORD_115 = 116;

	public const int EFF_SMALL_SWORD_115 = 117;

	public const int EFF_SUNG_115 = 118;

	public const int EFF_PHAPSU_115 = 119;

	public const int EFF_BIG_SWORD_115_2 = 120;

	public const int EFF_SMALL_SWORD_115_2 = 121;

	public const int EFF_SUNG_115_2 = 122;

	public const int EFF_PHAPSU_115_2 = 123;

	public const int EFF_PHAO_THANH = 124;

	public const int EFF_TRU_THANH_1 = 125;

	public const int EFF_TRU_THANH_2 = 126;

	public const sbyte SUB_STAR_LINE_IN_KIEM = 0;

	public const sbyte SUB_STAR_LINE_IN_SUNG = 1;

	public const sbyte SUB_STAR_LINE_IN_BUFF_0 = 2;

	public const sbyte SUB_STAR_LINE_IN_2KIEM = 3;

	public const sbyte SUB_STAR_LINE_IN_PS = 4;

	public const sbyte SUB_BUFF_LUA_1 = 0;

	public const sbyte SUB_BUFF_DOC_1 = 1;

	public const sbyte SUB_BUFF_BANG_1 = 2;

	public const sbyte SUB_BUFF_DIEN_1 = 3;

	public const sbyte SUB_BUFF_OTHER_MAIN = 10;

	public const sbyte SUB_BUFF_OTHER_SUB = 11;

	public static sbyte[][] frameBuff = new sbyte[5][]
	{
		new sbyte[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
		new sbyte[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
		new sbyte[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
		new sbyte[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
		new sbyte[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 }
	};

	public static sbyte[][] arrInfoEff = new sbyte[164][]
	{
		new sbyte[0],
		new sbyte[3] { 5, 5, 4 },
		new sbyte[3] { 9, 9, 4 },
		new sbyte[3] { 20, 20, 4 },
		new sbyte[3] { 32, 32, 5 },
		new sbyte[3] { 7, 7, 4 },
		new sbyte[3] { 8, 8, 4 },
		new sbyte[3] { 25, 25, 2 },
		new sbyte[3] { 22, 30, 4 },
		new sbyte[3] { 14, 15, 4 },
		new sbyte[3] { 8, 8, 4 },
		new sbyte[3] { 24, 19, 3 },
		new sbyte[3] { 19, 13, 3 },
		new sbyte[3] { 24, 24, 3 },
		new sbyte[3] { 32, 32, 6 },
		new sbyte[3] { 36, 30, 3 },
		new sbyte[3] { 23, 32, 8 },
		new sbyte[3] { 20, 20, 4 },
		new sbyte[3] { 32, 32, 2 },
		new sbyte[3] { 41, 17, 3 },
		new sbyte[3] { 32, 14, 3 },
		new sbyte[3] { 48, 48, 3 },
		new sbyte[3] { 21, 34, 3 },
		new sbyte[3] { 12, 12, 5 },
		new sbyte[3] { 38, 38, 3 },
		new sbyte[0],
		new sbyte[3] { 36, 30, 3 },
		new sbyte[3] { 32, 31, 3 },
		new sbyte[3] { 12, 12, 4 },
		new sbyte[3] { 40, 31, 3 },
		new sbyte[3] { 20, 18, 3 },
		new sbyte[3] { 12, 13, 4 },
		new sbyte[3] { 14, 14, 4 },
		new sbyte[3] { 30, 37, 3 },
		new sbyte[0],
		new sbyte[0],
		new sbyte[3] { 37, 40, 4 },
		new sbyte[3] { 50, 24, 4 },
		new sbyte[3] { 9, 12, 3 },
		new sbyte[0],
		new sbyte[3] { 23, 33, 2 },
		new sbyte[3] { 32, 32, 3 },
		new sbyte[3] { 24, 24, 5 },
		new sbyte[0],
		new sbyte[0],
		new sbyte[3] { 14, 11, 3 },
		new sbyte[0],
		new sbyte[3] { 15, 15, 3 },
		new sbyte[3] { 14, 11, 3 },
		new sbyte[0],
		new sbyte[3] { 24, 35, 3 },
		new sbyte[3] { 70, 70, 3 },
		new sbyte[3] { 50, 46, 4 },
		new sbyte[3] { 62, 64, 3 },
		new sbyte[3] { 38, 38, 4 },
		new sbyte[0],
		new sbyte[3] { 10, 10, 2 },
		new sbyte[3] { 25, 25, 3 },
		new sbyte[3] { 32, 32, 4 },
		new sbyte[3] { 32, 32, 4 },
		new sbyte[3] { 30, 32, 4 },
		new sbyte[3] { 50, 50, 4 },
		new sbyte[0],
		new sbyte[3] { 46, 50, 4 },
		new sbyte[0],
		new sbyte[3] { 42, 27, 6 },
		new sbyte[3] { 5, 5, 4 },
		new sbyte[3] { 59, 17, 1 },
		new sbyte[3] { 17, 23, 4 },
		new sbyte[0],
		new sbyte[3] { 50, 50, 4 },
		new sbyte[3] { 31, 31, 2 },
		new sbyte[3] { 34, 38, 3 },
		new sbyte[0],
		new sbyte[3] { 21, 17, 9 },
		new sbyte[3] { 32, 22, 3 },
		new sbyte[0],
		new sbyte[0],
		new sbyte[0],
		new sbyte[0],
		new sbyte[3] { 10, 10, 18 },
		new sbyte[3] { 17, 10, 3 },
		new sbyte[0],
		new sbyte[3] { 27, 32, 3 },
		new sbyte[0],
		new sbyte[3] { 19, 45, 1 },
		new sbyte[3] { 50, 26, 3 },
		new sbyte[3] { 24, 30, 5 },
		new sbyte[3] { 32, 14, 3 },
		new sbyte[3] { 32, 14, 3 },
		new sbyte[3] { 24, 14, 3 },
		new sbyte[3] { 8, 5, 2 },
		new sbyte[3] { 16, 16, 3 },
		new sbyte[0],
		new sbyte[3] { 30, 14, 2 },
		new sbyte[3] { 25, 45, 1 },
		new sbyte[3] { 53, 28, 3 },
		new sbyte[3] { 12, 12, 3 },
		new sbyte[3] { 14, 14, 4 },
		new sbyte[3] { 14, 14, 4 },
		new sbyte[3] { 14, 14, 4 },
		new sbyte[3] { 14, 14, 4 },
		new sbyte[3] { 14, 14, 4 },
		new sbyte[3] { 12, 12, 5 },
		new sbyte[3] { 12, 12, 5 },
		new sbyte[3] { 12, 11, 4 },
		new sbyte[3] { 50, 25, 4 },
		new sbyte[3] { 50, 25, 4 },
		new sbyte[3] { 50, 25, 4 },
		new sbyte[3] { 50, 25, 4 },
		new sbyte[3] { 50, 25, 4 },
		new sbyte[3] { 32, 30, 6 },
		new sbyte[3] { 28, 15, 4 },
		new sbyte[3] { 88, 60, 3 },
		new sbyte[3] { 31, 31, 2 },
		new sbyte[3] { 16, 16, 3 },
		new sbyte[3] { 7, 7, 4 },
		new sbyte[3] { 19, 45, 1 },
		new sbyte[3] { 55, 55, 3 },
		new sbyte[3] { 55, 55, 3 },
		new sbyte[3] { 55, 55, 3 },
		new sbyte[3] { 55, 55, 3 },
		new sbyte[3] { 24, 40, 3 },
		new sbyte[3] { 13, 13, 3 },
		new sbyte[3] { 59, 64, 4 },
		new sbyte[3] { 25, 25, 3 },
		new sbyte[3] { 13, 13, 3 },
		new sbyte[3] { 36, 30, 4 },
		new sbyte[3] { 53, 24, 4 },
		new sbyte[3] { 44, 44, 4 },
		new sbyte[3] { 50, 51, 4 },
		new sbyte[3] { 40, 40, 4 },
		new sbyte[3] { 31, 23, 3 },
		new sbyte[3] { 26, 24, 3 },
		new sbyte[3] { 32, 32, 4 },
		new sbyte[3] { 32, 24, 3 },
		new sbyte[3] { 29, 20, 3 },
		new sbyte[3] { 32, 32, 6 },
		new sbyte[3] { 22, 19, 8 },
		new sbyte[3] { 23, 25, 3 },
		new sbyte[3] { 16, 21, 3 },
		new sbyte[3] { 8, 8, 4 },
		new sbyte[3] { 20, 15, 2 },
		new sbyte[3] { 30, 20, 3 },
		new sbyte[3] { 64, 57, 4 },
		new sbyte[3] { 20, 20, 3 },
		new sbyte[3] { 24, 16, 3 },
		new sbyte[3] { 30, 20, 3 },
		new sbyte[3] { 22, 16, 3 },
		new sbyte[3] { 25, 17, 3 },
		new sbyte[3] { 30, 30, 4 },
		new sbyte[3] { 30, 30, 4 },
		new sbyte[3] { 16, 16, 2 },
		new sbyte[3] { 7, 7, 4 },
		new sbyte[3] { 9, 9, 4 },
		new sbyte[3] { 13, 13, 5 },
		new sbyte[3] { 7, 7, 4 },
		new sbyte[3] { 9, 9, 4 },
		new sbyte[3] { 13, 13, 5 },
		new sbyte[3] { 7, 7, 4 },
		new sbyte[3] { 9, 9, 4 },
		new sbyte[3] { 13, 13, 5 },
		new sbyte[3] { 16, 16, 4 },
		new sbyte[3] { 13, 22, 1 }
	};

	private long time;

	public int subType;

	public int indexSound;

	public bool ispaintArena = true;

	private int vXTam;

	private int vYTam;

	private int x1000;

	private int y1000;

	private int vX1000;

	private int vY1000;

	private int xEff;

	private int yEff;

	private int angle;

	private int R;

	private int size1;

	public int[][] mTamgiac;

	private int lT_Arc;

	private int gocT_Arc;

	private int r;

	public static sbyte countSkillArena;

	public static int[][] colorStar = new int[2][]
	{
		new int[3] { 16310304, 16298056, 16777215 },
		new int[3] { 7045120, 12643960, 16777215 }
	};

	private int[] colorpaint;

	private static int[][] colorBuffMain = new int[5][]
	{
		new int[4] { 11878912, 16298056, 16777215, 16777215 },
		new int[4] { 16244265, 16298056, 16777215, 16777215 },
		new int[4] { 9482488, 16298056, 16777215, 16777215 },
		new int[4] { 11569320, 16298056, 16777215, 16777215 },
		new int[4] { 16646016, 13357112, 16777215, 16777215 }
	};

	private int colorBuff;

	private int indexColorStar;

	private int timedelay;

	private new int ysai;

	private sbyte timeAddNum;

	private mVector VecEff = new mVector("EffectSkill VecEff");

	private mVector VecSubEff = new mVector("EffectSkill VecSubEff");

	private sbyte[] mpaintone_three = new sbyte[8] { 4, 3, 2, 1, 0, 7, 6, 5 };

	private sbyte[] mpaintone_Bullet = new sbyte[24]
	{
		12, 11, 10, 9, 8, 7, 6, 5, 4, 3,
		2, 1, 0, 23, 22, 21, 20, 19, 18, 17,
		16, 15, 14, 13
	};

	private sbyte[] mImageBullet = new sbyte[24]
	{
		0, 0, 2, 1, 1, 2, 0, 0, 2, 1,
		1, 2, 0, 0, 2, 1, 1, 2, 0, 0,
		2, 1, 1, 2
	};

	private sbyte[] mXoayBullet = new sbyte[24]
	{
		2, 2, 3, 3, 3, 4, 5, 5, 5, 5,
		5, 1, 0, 0, 0, 0, 0, 7, 6, 6,
		6, 6, 6, 2
	};

	private int gocArrow;

	private int frameArrow;

	private int xline;

	private int yline;

	private int yFly;

	private int ydArchor;

	private int yArchor;

	private int indexLan;

	private MainObject objKill;

	public mVector vecObjBeKill;

	private bool isEff;

	private bool ispaintsleep;

	private int indexAdd;

	private int dxTower;

	private int dyTower;

	private int xdichTower;

	private int ydichTower;

	private int delay;

	public sbyte[] arr_R = new sbyte[12]
	{
		40, 40, 40, 40, 40, 40, 40, 40, 40, 40,
		40, 40
	};

	public int[] arr_radian = new int[12]
	{
		0, 30, 60, 90, 120, 150, 180, 210, 240, 270,
		300, 330
	};

	public int xto;

	public int yto;

	public int dx;

	public int dy;

	public int nPosition;

	public int xO;

	public int yO;

	public int dem;

	public int radian;

	public new int frame;

	public int effect;

	public static int[][] posx = new int[2][]
	{
		new int[16]
		{
			4, 11, 11, 15, 10, 7, 5, 6, 4, 3,
			11, 13, 13, 13, 12, 15
		},
		new int[16]
		{
			14, 14, 16, 15, 18, 20, 22, 22, 23, 21,
			9, 11, 9, 10, 9, 9
		}
	};

	public static int[][] posy = new int[2][]
	{
		new int[16]
		{
			11, 9, 11, 11, 13, 14, 13, 14, 11, 13,
			15, 14, 13, 13, 12, 15
		},
		new int[16]
		{
			9, 12, 12, 14, 14, 15, 13, 11, 13, 14,
			9, 11, 9, 10, 9, 9
		}
	};

	private sbyte indexpost;

	public int Xsleep;

	public int vxSleep;

	public int Ysleep;

	public int ystun;

	private int test;

	public int frSleep;

	public int[] frameSleep = new int[13]
	{
		0, 0, 0, 0, 0, 0, 0, 1, 1, 1,
		1, 1, 1
	};

	public sbyte frStun;

	public int[] frameStun = new int[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

	private mVector vectam;

	private int life;

	private int va;

	public bool isSpeedUp;

	private int savex;

	private int savey;

	public EffectSkill(int x, int y, int xto, int yto, sbyte indexpos)
	{
		GameScreen.addEffectEndKill(14, x, y);
		GameScreen.addEffectEndKill(14, x + 24, y);
		GameScreen.addEffectEndKill(14, x - 24, y);
		GameScreen.addEffectEndKill(57, x, y);
		fraImgEff = new FrameImage(162);
		indexpost = indexpos;
		base.x = x;
		base.y = y;
		this.xto = xto;
		this.yto = yto;
		if (this.xto == x)
		{
			vx = 0;
		}
		else if (this.xto > x)
		{
			vx = 1;
		}
		else
		{
			vx = -1;
		}
		vy = -5;
		typeEffect = 124;
	}

	public EffectSkill(int typeKill, Object_Effect_Skill objkill, mVector vec, int subtype)
	{
		if (LoadMapScreen.isNextMap)
		{
			subType = subtype;
			isStop = false;
			isRemove = false;
			set_New_Effect(typeKill, objkill, vec);
		}
	}

	public EffectSkill(int typeKill, Object_Effect_Skill objkill, mVector vec, int subtype, bool ispaintarena)
	{
		if (LoadMapScreen.isNextMap)
		{
			subType = subtype;
			ispaintArena = ispaintarena;
			isStop = false;
			isRemove = false;
			set_New_Effect(typeKill, objkill, vec);
		}
	}

	public EffectSkill(int type, int x, int y, int timeRe, short idGhost, sbyte tem)
	{
		typeEffect = type;
		base.x = x;
		base.y = y;
		timeRemove = timeRe;
		time = GameCanvas.timeNow;
		switch (type)
		{
		case 29:
			isEff = true;
			indexColorStar = CRes.random(2);
			x1000 = x * 1000;
			y1000 = y * 1000;
			fRemove = CRes.random(4, 6);
			vMax = 5;
			xline = 10;
			yline = 20;
			create_Star_Line_In(vMax, xline, yline);
			break;
		case 69:
			fRemove = 16;
			isEff = true;
			fraImgEff = new FrameImage(9);
			vx = CRes.random_Am_0(2);
			vy = -2;
			break;
		case 80:
			fRemove = 16;
			isEff = true;
			fraImgEff = new FrameImage(16);
			objBeKillMain = MainObject.get_Object(idGhost, 1);
			if (objBeKillMain != null)
			{
			}
			break;
		case 81:
			fRemove = 30;
			isEff = true;
			create_Fire_Arc();
			break;
		case 83:
			isEff = true;
			fRemove = 60;
			switch (CRes.random(3))
			{
			case 0:
				fraImgEff = new FrameImage(103);
				break;
			case 1:
				fraImgEff = new FrameImage(104);
				break;
			case 2:
				fraImgEff = new FrameImage(23);
				break;
			}
			toX = base.x;
			toY = base.y;
			base.x += CRes.random_Am(24, 48);
			base.y += CRes.random_Am(24, 48);
			createHut_Mp_Hp();
			break;
		case 84:
			isEff = true;
			indexColorStar = CRes.random(2);
			x1000 = x * 1000;
			y1000 = y * 1000;
			fRemove = CRes.random(6, 8);
			vMax = 2;
			xline = 10;
			yline = 20;
			create_Star_Line_In(vMax, xline, yline);
			break;
		case 85:
			timeRemove = timeRe * 1000;
			isEff = true;
			objBeKillMain = MainObject.get_Object(idGhost, tem);
			if (objBeKillMain == null || objBeKillMain.isRemove || objBeKillMain.isStop)
			{
				removeEff();
				break;
			}
			indexColorStar = CRes.random(2);
			x1000 = x;
			y1000 = y;
			fRemove = 5;
			break;
		case 86:
		{
			fraImgEff = new FrameImage(30);
			fraImgSubEff = new FrameImage(31);
			fraImgSub2Eff = new FrameImage(40);
			isEff = true;
			for (int i = 0; i < tem; i++)
			{
				vMax = CRes.random(5, 10);
				vx = vMax;
				Point o = create_Stone_Drop(MainScreen.cameraMain.xCam + 20 + CRes.random(GameCanvas.w * 5 / 4), MainScreen.cameraMain.yCam + 20 + CRes.random(GameCanvas.h * 5 / 4));
				VecEff.addElement(o);
			}
			break;
		}
		case 87:
			fraImgEff = new FrameImage(11);
			objBeKillMain = MainObject.get_Object(idGhost, tem);
			if (objBeKillMain == null || objBeKillMain.isRemove || objBeKillMain.isStop)
			{
				removeEff();
				break;
			}
			x = objBeKillMain.x;
			y = objBeKillMain.y - objBeKillMain.hOne / 2;
			isEff = true;
			fRemove = 10;
			break;
		case 102:
			objBeKillMain = MainObject.get_Object(idGhost, tem);
			if (objBeKillMain != null)
			{
				x = objBeKillMain.x;
				y = objBeKillMain.y - 25;
				objBeKillMain.vx = 0;
				objBeKillMain.vy = 0;
				objBeKillMain.toX = x;
				objBeKillMain.toY = y;
				objBeKillMain.isStun = true;
				objBeKillMain.timeStun = mSystem.currentTimeMillis() + timeRe * 1000;
				if (objBeKillMain.typeObject == 1)
				{
					ystun = 0;
				}
				else
				{
					ystun = 17;
				}
			}
			break;
		case 103:
			objBeKillMain = MainObject.get_Object(idGhost, tem);
			if (objBeKillMain != null)
			{
				fraImgEff = new FrameImage(27);
				r = 72;
				timedelay = 20;
				ysai = 40;
				objBeKillMain.isnoBoss84 = true;
				objBeKillMain.timenoBoss84 = mSystem.currentTimeMillis() + timeRe * 1000;
			}
			break;
		case 107:
			objBeKillMain = MainObject.get_Object(idGhost, tem);
			if (objBeKillMain != null)
			{
				isEff = true;
				indexColorStar = CRes.random(2);
				x = objBeKillMain.x;
				y = objBeKillMain.y - 15;
				x1000 = x * 1000;
				y1000 = y * 1000;
				objBeKillMain.toX = x;
				objBeKillMain.toY = y;
				fRemove = CRes.random(4, 6);
				vMax = 5;
				xline = 10;
				yline = 20;
				create_Star_Line_In(vMax, xline, yline);
				objBeKillMain.isno = true;
				objBeKillMain.timeno = mSystem.currentTimeMillis() + timeRe * 1000;
			}
			break;
		case 101:
			objBeKillMain = MainObject.get_Object(idGhost, tem);
			if (objBeKillMain != null)
			{
				ispaintsleep = false;
				delay = 10;
				x = objBeKillMain.x;
				y = objBeKillMain.y;
				objBeKillMain.vx = 0;
				objBeKillMain.vy = 0;
				objBeKillMain.toX = x;
				objBeKillMain.toY = y;
				objBeKillMain.isSleep = true;
				objBeKillMain.timeSleep = mSystem.currentTimeMillis() + timeRe * 1000;
			}
			break;
		case 94:
			nFrame = new sbyte[12]
			{
				0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
				3, 3
			};
			mSound.playSound(32, mSound.volumeSound);
			fraImgEff = new FrameImage(127);
			fraImgSubEff = new FrameImage(53);
			fRemove = 60;
			objBeKillMain = MainObject.get_Object(idGhost, tem);
			if (objBeKillMain != null)
			{
				x = objBeKillMain.x;
				y = objBeKillMain.y;
				objBeKillMain.vx = 0;
				objBeKillMain.vy = 0;
				objBeKillMain.toX = x;
				objBeKillMain.toY = y;
				objBeKillMain.isBinded = true;
				if (timeRe == 0)
				{
					objBeKillMain.isBinded = false;
				}
				objBeKillMain.timeBind = mSystem.currentTimeMillis() + timeRe * 1000;
				LoadMap.timeVibrateScreen = 103;
			}
			break;
		case 100:
			mSound.playSound(32, mSound.volumeSound);
			fRemove = 60;
			objBeKillMain = MainObject.get_Object(idGhost, tem);
			if (objBeKillMain != null)
			{
				x = objBeKillMain.x;
				y = objBeKillMain.y;
				objBeKillMain.vx = 0;
				objBeKillMain.vy = 0;
				objBeKillMain.toX = x;
				objBeKillMain.toY = y;
				objBeKillMain.isDongBang = true;
				objBeKillMain.timeDongBang = mSystem.currentTimeMillis() + timeRe * 1000;
				GameScreen.addEffectEndKill_Time(49, objBeKillMain.x, objBeKillMain.y, objBeKillMain.timeDongBang);
				levelPaint = -1;
				fRemove = 6;
			}
			break;
		}
	}

	public EffectSkill(MainObject obj, int type)
	{
		typeEffect = type;
		x = obj.x;
		y = obj.y;
		if (type == 14)
		{
			isEff = true;
			create_Fire_Arc();
		}
	}

	private void set_New_Effect(int typeKill, Object_Effect_Skill Okill, mVector vec)
	{
		if (vec == null || vec.size() == 0)
		{
			return;
		}
		vecObjBeKill = vec;
		indexSound = -1;
		f = -1;
		isPaint = true;
		ysai = 0;
		typeEffect = typeKill;
		time = GameCanvas.timeNow;
		objKill = MainObject.get_Object(Okill.ID, Okill.tem);
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjBeKill.elementAt(0);
		objBeKillMain = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
		isEff = false;
		if (objKill == null || objBeKillMain == null)
		{
			return;
		}
		if (typeEffect == 92 || typeEffect == 89)
		{
			x = objBeKillMain.x;
			y = objBeKillMain.y - objBeKillMain.hOne / 2;
			toX = objKill.x;
			toY = objKill.y - objKill.hOne / 2;
		}
		else
		{
			x = objKill.x;
			y = objKill.y - objKill.hOne / 2;
			toX = objBeKillMain.x;
			toY = objBeKillMain.y - objBeKillMain.hOne / 2;
		}
		if (typeEffect != 10 && typeEffect != 66 && typeEffect != 30 && typeEffect != 29 && typeEffect != 107)
		{
			Direction = setDirection(objKill, objBeKillMain);
			objKill.Direction = Direction;
		}
		else
		{
			Direction = objKill.Direction;
		}
		timeAddNum = -1;
		if (typeEffect != 41 && objKill == GameScreen.player)
		{
			isEff = true;
		}
		if (!MainObject.isInScreen(objBeKillMain) && !MainObject.isInScreen(objKill))
		{
			isStop = true;
			return;
		}
		switch (typeKill)
		{
		case 0:
			fRemove = 60;
			switch (subType)
			{
			case 0:
				fraImgEff = new FrameImage(101);
				break;
			case 1:
				fraImgEff = new FrameImage(98);
				break;
			case 2:
				fraImgEff = new FrameImage(100);
				break;
			case 3:
				fraImgEff = new FrameImage(99);
				break;
			case 4:
				fraImgEff = new FrameImage(32);
				break;
			case 5:
				fraImgEff = new FrameImage(102);
				break;
			default:
				fraImgEff = new FrameImage(32);
				break;
			}
			vMax = 8000;
			createNormal();
			break;
		case 41:
			fRemove = 60;
			if (subType == 0)
			{
				fraImgEff = new FrameImage(103);
			}
			else
			{
				fraImgEff = new FrameImage(104);
			}
			vMax = 12000;
			createXP();
			break;
		case 1:
		case 38:
		case 59:
		{
			vMax = 14;
			if (typeKill == 38)
			{
				if (objKill.clazz == 2)
				{
					indexSound = 2;
				}
				else
				{
					indexSound = 1;
				}
			}
			if (typeKill == 1)
			{
				fraImgEff = new FrameImage(32);
			}
			if (typeKill == 59)
			{
				indexSound = 13;
				y += 10;
				fraImgEff = new FrameImage(17);
				fraImgSubEff = new FrameImage(24);
			}
			int xdich = toX - x;
			int ydich = toY - y;
			create_Speed(xdich, ydich, null);
			if (typeKill == 59)
			{
				timeAddNum = (sbyte)fRemove;
			}
			break;
		}
		case 6:
			isEff = true;
			create_Star();
			break;
		case 10:
			if (objBeKillMain != null)
			{
				toX = objBeKillMain.x;
				toY = objBeKillMain.y;
			}
			fRemove = 10;
			timeAddNum = 7;
			createLighting(toX + CRes.random_Am_0(20), MainScreen.cameraMain.yCam - 5, toX, toY, isEnd: true);
			if (objKill == GameScreen.player)
			{
				mSound.playSound(32, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(32);
			}
			GameScreen.addEffectEndKill(40, toX, toY + 10);
			break;
		case 11:
		case 108:
		case 114:
		{
			indexSound = 5;
			if (typeEffect == 114)
			{
				fraImgEff = new FrameImage(24);
				fraImgSubEff = new FrameImage(7);
				fraImgSub2Eff = new FrameImage(9);
			}
			else
			{
				fraImgEff = new FrameImage(30);
				fraImgSubEff = new FrameImage(31);
				fraImgSub2Eff = new FrameImage(40);
			}
			vMax = 14;
			vx = vMax;
			for (int num8 = 0; num8 < vecObjBeKill.size(); num8++)
			{
				Object_Effect_Skill object_Effect_Skill7 = (Object_Effect_Skill)vecObjBeKill.elementAt(num8);
				if (object_Effect_Skill7 != null)
				{
					MainObject mainObject6 = MainObject.get_Object(object_Effect_Skill7.ID, object_Effect_Skill7.tem);
					if (mainObject6 != null)
					{
						Point o = create_Stone_Drop(mainObject6.x, mainObject6.y);
						VecEff.addElement(o);
					}
				}
			}
			break;
		}
		case 12:
			mSound.playSound(32, mSound.volumeSound);
			indexSound = 15;
			create_Crack_Earth();
			break;
		case 14:
		case 115:
			mSound.playSound(37, mSound.volumeSound);
			timeAddNum = 18;
			if (typeEffect == 14)
			{
				create_Fire_Arc();
			}
			else
			{
				create_Ice_Arc();
			}
			break;
		case 20:
		case 113:
			indexSound = 11;
			fraImgEff = new FrameImage(91);
			setBeginKill(5);
			if (objBeKillMain != null)
			{
				x1000 = objBeKillMain.x - 70;
				toX = objBeKillMain.x;
				toY = objBeKillMain.y;
			}
			else
			{
				x1000 = toX - 70;
			}
			y1000 = MainScreen.cameraMain.yCam - CRes.random(10, 20);
			vMax = 18;
			fRemove = 20;
			timeAddNum = 11;
			create_Arrow_Rain();
			break;
		case 21:
			if (objKill.clazz == 0)
			{
				indexSound = 3;
			}
			else
			{
				indexSound = 0;
			}
			if (objBeKillMain != null)
			{
				x = objBeKillMain.x;
				y = objBeKillMain.y - objKill.hOne / 2;
			}
			else
			{
				x = toX;
				y = toY;
			}
			frame = CRes.random(4);
			do
			{
				frameArrow = CRes.random(4);
			}
			while (frame == frameArrow);
			fraImgEff = new FrameImage(118 + frame);
			fraImgSubEff = new FrameImage(118 + frameArrow);
			fRemove = 6;
			break;
		case 22:
		case 31:
			create_Sung_LV2_LV4();
			break;
		case 23:
			indexSound = 12;
			create_Sung_Lv3();
			break;
		case 25:
			indexSound = 13;
			create_PS_LV2_3_5();
			break;
		case 26:
			indexSound = 5;
			create_Kiem_Lv3();
			break;
		case 27:
			create_Kill_2Kiem_Lv2();
			break;
		case 28:
			indexSound = 4;
			create_Kiem_Lv2();
			break;
		case 29:
			isEff = true;
			if (objKill != null)
			{
				indexColorStar = ((objKill.clazz == 1) ? 1 : 0);
			}
			else
			{
				indexColorStar = 0;
			}
			setPosLineIn(subType);
			x1000 = x * 1000;
			if (objKill != null)
			{
				y1000 = (y - objKill.hOne / 2) * 1000;
			}
			else
			{
				y1000 = toY * 1000;
			}
			fRemove = 2;
			vMax = 5;
			xline = 10;
			yline = 20;
			create_Star_Line_In(vMax, xline, yline);
			break;
		case 30:
			isEff = true;
			setPosLineIn(subType);
			x1000 = x * 1000;
			y1000 = (y - objKill.hOne / 2) * 1000;
			if (objKill.clazz == 3)
			{
				fraImgEff = new FrameImage(6);
			}
			else
			{
				fraImgEff = new FrameImage(10);
			}
			fRemove = 5;
			create_Star_Point_In();
			break;
		case 34:
			fraImgEff = new FrameImage(33);
			fraImgSubEff = new FrameImage(18);
			fRemove = 57;
			if (objKill == null || objBeKillMain == null)
			{
				isRemove = true;
				return;
			}
			objKill.isTanHinh = true;
			objKill.timeTanHinh = 0;
			if (objKill.isMainChar())
			{
				GameScreen.player.lastX = GameScreen.player.x;
				GameScreen.player.lastY = GameScreen.player.y;
			}
			create_2Kiem_Lv4(0, objBeKillMain);
			indexLan = 1;
			break;
		case 40:
			indexSound = 10;
			create_2Kiem_Lv5();
			break;
		case 42:
			isEff = true;
			indexSound = 26;
			create_Level_up();
			break;
		case 43:
		{
			isEff = true;
			fraImgEff = new FrameImage(50);
			fRemove = 11;
			y += objKill.hOne / 2;
			for (int num7 = 0; num7 < 10; num7++)
			{
				Point point7 = new Point();
				int a3 = CRes.random(0, 180);
				point7.x = 17 * CRes.cos(a3) / 1000;
				point7.y = 15 * CRes.sin(a3) / 1000 - 5;
				point7.fRe = CRes.random(2);
				point7.frame = CRes.random(4);
				point7.limitY = 60;
				VecEff.addElement(point7);
			}
			break;
		}
		case 46:
			indexSound = 7;
			fraImgEff = new FrameImage(70);
			fraImgSubEff = new FrameImage(72);
			fRemove = 15;
			if (objBeKillMain != null)
			{
				toX = objBeKillMain.x;
				toY = objBeKillMain.y;
			}
			break;
		case 47:
		case 112:
			indexSound = 8;
			create_2Kiem_GaiDoc();
			break;
		case 49:
			indexSound = 14;
			fraImgEff = new FrameImage(23);
			fraImgSubEff = new FrameImage(24);
			create_PS_Xungkich();
			if (objBeKillMain != null)
			{
				toX = objBeKillMain.x;
				toY = objBeKillMain.y - objBeKillMain.hOne / 2;
			}
			break;
		case 50:
			create_Monster();
			if (objBeKillMain != null && objBeKillMain.typeObject == 9)
			{
				indexSound = 25;
			}
			break;
		case 125:
			y = objKill.y - 100;
			timeAddNum = 3;
			fraImgEff = new FrameImage(21);
			fraImgSubEff = new FrameImage(59);
			fRemove = 16;
			R = 240;
			angle = 0;
			size1 = 4;
			break;
		case 126:
			y = objKill.y - 120;
			x -= 12;
			timeAddNum = 3;
			fraImgEff = new FrameImage(21);
			fraImgSubEff = new FrameImage(59);
			fRemove = 16;
			R = 240;
			angle = 0;
			size1 = 4;
			break;
		case 106:
			timeAddNum = 3;
			fraImgEff = new FrameImage(21);
			fraImgSubEff = new FrameImage(59);
			fRemove = 16;
			R = 240;
			y -= 15;
			x -= 6;
			angle = 0;
			size1 = 4;
			setBeginKill(10);
			break;
		case 105:
			timeAddNum = 3;
			fraImgEff = new FrameImage(21);
			fraImgSubEff = new FrameImage(60);
			fRemove = 16;
			y -= 12;
			setBeginKill(10);
			break;
		case 51:
			timeAddNum = 3;
			fraImgEff = new FrameImage(21);
			fraImgSubEff = new FrameImage(59);
			fRemove = 16;
			y += 7;
			setBeginKill(10);
			break;
		case 52:
			indexSound = 4;
			goto IL_1005;
		case 54:
			if (typeKill == 54)
			{
				indexSound = 5;
			}
			goto IL_1005;
		case 53:
			indexSound = 6;
			fraImgEff = new FrameImage(85);
			goto IL_10b6;
		case 104:
			if (typeKill == 104)
			{
				goto case 78;
			}
			goto IL_10b6;
		case 78:
			mSound.playSound(32, mSound.volumeSound);
			fraImgEff = new FrameImage(117);
			if (typeKill == 104)
			{
				objBeKillMain.jum();
			}
			goto IL_10b6;
		case 55:
			indexSound = 7;
			fraImgEff = new FrameImage(51);
			fRemove = 12;
			if (objBeKillMain != null)
			{
				toX = objBeKillMain.x;
				toY = objBeKillMain.y - objBeKillMain.hOne / 2;
			}
			timeAddNum = 5;
			break;
		case 56:
			if (subType == 10)
			{
				fraImgEff = new FrameImage(29);
			}
			else
			{
				fraImgEff = new FrameImage(22);
			}
			y = objKill.y;
			fRemove = 6;
			isEff = true;
			break;
		case 57:
			if (objKill.clazz == 2 || objKill.clazz == 3)
			{
				indexSound = 30;
			}
			else
			{
				indexSound = 31;
			}
			isEff = true;
			x1000 = x * 1000;
			y1000 = y * 1000;
			create_Buff_Point_In();
			break;
		case 58:
			mSound.playSound(45, mSound.volumeSound);
			isEff = true;
			y = objKill.y + objKill.ysai;
			fraImgEff = new FrameImage(65);
			fraImgSubEff = new FrameImage(94);
			fRemove = 8;
			break;
		case 60:
		{
			indexSound = 16;
			LoadMap.timeVibrateScreen = 16;
			for (int num12 = 0; num12 < vecObjBeKill.size(); num12++)
			{
				Object_Effect_Skill object_Effect_Skill9 = (Object_Effect_Skill)vecObjBeKill.elementAt(num12);
				if (object_Effect_Skill9 != null)
				{
					MainObject mainObject8 = MainObject.get_Object(object_Effect_Skill9.ID, object_Effect_Skill9.tem);
					if (mainObject8 != null)
					{
						Point point10 = new Point();
						point10.x = mainObject8.x;
						point10.y = mainObject8.y + mainObject8.ysai;
						VecEff.addElement(point10);
					}
				}
			}
			fRemove = 20;
			break;
		}
		case 61:
			if (vecObjBeKill.size() > 1)
			{
				indexSound = 16;
			}
			else
			{
				indexSound = 15;
			}
			fraImgEff = new FrameImage(71);
			fraImgSubEff = new FrameImage(5);
			fraImgSub2Eff = new FrameImage(92);
			goto IL_1410;
		case 77:
			if (typeKill == 77)
			{
				fraImgEff = new FrameImage(114);
				fraImgSubEff = new FrameImage(116);
				fraImgSub2Eff = new FrameImage(115);
			}
			goto IL_1410;
		case 62:
			indexSound = 20;
			y += 5;
			fRemove = 20;
			timeAddNum = 10;
			fraImgEff = new FrameImage(47);
			vMax = 22;
			if (objBeKillMain != null)
			{
				toX = objBeKillMain.x;
				toY = objBeKillMain.y - objBeKillMain.hOne / 2;
			}
			break;
		case 63:
			y += 8;
			fraImgEff = new FrameImage(74);
			if (objBeKillMain != null)
			{
				toX = objBeKillMain.x;
				toY = objBeKillMain.y - objBeKillMain.hOne / 2;
			}
			fRemove = 20;
			timeAddNum = 10;
			vMax = 16;
			break;
		case 109:
		case 110:
		{
			indexSound = 16;
			indexSound = 14;
			f = 0;
			if (typeEffect == 109)
			{
				fraImgEff = new FrameImage(92);
			}
			else
			{
				fraImgEff = new FrameImage(115);
			}
			int num3 = (short)(toX - x);
			int num4 = (short)(toY - y);
			angle = (short)CRes.angle(num3, num4);
			int num5 = (Math.abs(num3) + Math.abs(num4)) / 20;
			if (num5 < 2)
			{
				num5 = 2;
			}
			for (int num6 = 0; num6 < num5; num6++)
			{
				Point point6 = new Point();
				point6.x = x + num6 * num3 / num5;
				point6.y = y + num6 * num4 / num5;
				VecEff.addElement(point6);
			}
			break;
		}
		case 64:
		{
			indexSound = 14;
			f = -1;
			fraImgEff = new FrameImage(95);
			fraImgSubEff = new FrameImage(53);
			fRemove = 20;
			for (int n = 0; n < vecObjBeKill.size(); n++)
			{
				Point point5 = new Point();
				Object_Effect_Skill object_Effect_Skill6 = (Object_Effect_Skill)vecObjBeKill.elementAt(n);
				if (object_Effect_Skill6 != null)
				{
					MainObject mainObject5 = MainObject.get_Item_Object(object_Effect_Skill6.ID, object_Effect_Skill6.tem);
					if (mainObject5 != null)
					{
						point5.x = mainObject5.x;
						point5.y = mainObject5.y + mainObject5.ysai;
						VecEff.addElement(point5);
					}
				}
			}
			break;
		}
		case 73:
			y += 8;
			if (typeKill == 73)
			{
				mSound.playSound(34, mSound.volumeSound);
				fraImgEff = new FrameImage(48);
				fraImgSubEff = new FrameImage(38);
			}
			vMax = 20;
			fRemove = 40;
			break;
		case 65:
			indexSound = 23;
			fRemove = 2;
			isEff = true;
			break;
		case 66:
			indexSound = 22;
			objKill.Direction = 1;
			fRemove = 2;
			isEff = true;
			break;
		case 67:
		{
			isEff = false;
			fraImgEff = new FrameImage(21);
			fraImgSubEff = new FrameImage(6);
			x1000 = x;
			y1000 = y;
			vMax = 18;
			int xdich;
			int ydich;
			if (objBeKillMain != null)
			{
				xdich = objBeKillMain.x - x;
				ydich = objBeKillMain.y - objBeKillMain.hOne / 2 - y;
			}
			else
			{
				xdich = toX - x;
				ydich = toY - y;
			}
			create_Speed(xdich, ydich, null);
			break;
		}
		case 68:
			timeAddNum = 20;
			isEff = true;
			if (subType == 0)
			{
				fraImgEff = new FrameImage(111);
				fRemove = 6;
			}
			else if (subType == 1)
			{
				fraImgEff = new FrameImage(112);
				fRemove = 8;
			}
			break;
		case 69:
			fRemove = 16;
			isEff = true;
			fraImgEff = new FrameImage(9);
			vx = CRes.random_Am_0(2);
			vy = -2;
			y -= CRes.random(objKill.hOne / 2);
			break;
		case 70:
			isEff = true;
			x1000 = x * 1000;
			y1000 = y * 1000;
			if (subType >= 28)
			{
				subType -= 28;
			}
			create_Mon_Buff();
			break;
		case 71:
			mSound.playSound(32, mSound.volumeSound);
			fraImgEff = new FrameImage(36);
			fraImgSubEff = new FrameImage(53);
			goto IL_1a8a;
		case 75:
			mSound.playSound(35, mSound.volumeSound);
			fraImgEff = new FrameImage(61);
			goto IL_1a8a;
		case 72:
		case 74:
		{
			vMax = 14;
			switch (typeKill)
			{
			case 72:
				mSound.playSound(34, mSound.volumeSound);
				fraImgEff = new FrameImage(45);
				fraImgSubEff = new FrameImage(37);
				break;
			case 74:
				mSound.playSound(34, mSound.volumeSound);
				fraImgEff = new FrameImage(63);
				break;
			}
			for (int k = 0; k < vecObjBeKill.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)vecObjBeKill.elementAt(k);
				if (object_Effect_Skill3 != null)
				{
					MainObject mainObject2 = MainObject.get_Item_Object(object_Effect_Skill3.ID, object_Effect_Skill3.tem);
					if (mainObject2 != null)
					{
						int xdich = mainObject2.x - x;
						int ydich = mainObject2.y - mainObject2.hOne / 2 - y;
						Point_Focus p = new Point_Focus();
						p = create_Speed_More(xdich, ydich, p, mainObject2);
						p.x = x;
						p.y = y;
						int frameAngle = CRes.angle(xdich, ydich);
						p.frame = setFrameAngle(frameAngle);
						VecEff.addElement(p);
					}
				}
			}
			fRemove = 10;
			break;
		}
		case 76:
		{
			mSound.playSound(36, mSound.volumeSound);
			levelPaint = -1;
			fraImgSubEff = new FrameImage(113);
			fraImgEff = new FrameImage(81);
			fRemove = 20;
			timeAddNum = 13;
			vMax = 8;
			for (int j = 0; j < 16; j++)
			{
				Point point2 = new Point();
				point2.x = x * 1000;
				point2.y = y * 1000;
				point2.vx = CRes.cos(225 * j / 10) * vMax;
				point2.vy = CRes.sin(225 * j / 10) * vMax;
				point2.f = 0;
				VecEff.addElement(point2);
			}
			break;
		}
		case 79:
			fRemove = 1;
			isEff = true;
			break;
		case 82:
		case 111:
		{
			indexSound = 21;
			int a2 = CRes.angle(toX - x, toY - y);
			int num2 = CRes.abs(MainObject.getDistance(x, y, toX, toY)) + 30;
			x1000 = x + CRes.cos(a2) * num2 / 1000;
			y1000 = y + CRes.sin(a2) * num2 / 1000;
			fRemove = 10;
			timeAddNum = 7;
			setBeginKill(0);
			createLighting(x, y - hOne / 2, x1000, y1000, isEnd: true);
			if (objKill == GameScreen.player)
			{
				mSound.playSound(32, mSound.volumeSound);
			}
			GameScreen.addEffectEndKill(40, x1000, y1000 + 10);
			break;
		}
		case 88:
			fRemove = 60;
			fraImgEff = new FrameImage(97);
			fraImgSubEff = new FrameImage(9);
			vMax = 8000;
			createDanFocus();
			frame = setFrameAngle(gocT_Arc);
			break;
		case 89:
			fRemove = 60;
			fraImgEff = new FrameImage(10);
			fraImgSubEff = new FrameImage(10);
			vMax = 8000;
			createDanFocus();
			frame = setFrameAngle(gocT_Arc);
			break;
		case 92:
			fRemove = 60;
			fraImgEff = new FrameImage(141);
			fraImgSubEff = new FrameImage(141);
			vMax = 8000;
			createDanFocus();
			frame = setFrameAngle(gocT_Arc);
			break;
		case 90:
			timeAddNum = 18;
			create_Nova();
			if (objBeKillMain != null && objBeKillMain.typeObject == 9)
			{
				indexSound = 36;
			}
			break;
		case 91:
			timeAddNum = 18;
			create_Poison_Nova();
			if (objBeKillMain != null && objBeKillMain.typeObject == 9)
			{
				indexSound = 36;
			}
			break;
		case 93:
		{
			mSound.playSound(34, mSound.volumeSound);
			fraImgEff = new FrameImage(63);
			fraImgSubEff = new FrameImage(107);
			fRemove = 60;
			for (int i = 0; i < vecObjBeKill.size(); i++)
			{
				Point point = new Point();
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)vecObjBeKill.elementAt(i);
				if (object_Effect_Skill2 != null)
				{
					MainObject mainObject = MainObject.get_Item_Object(object_Effect_Skill2.ID, object_Effect_Skill2.tem);
					if (mainObject != null)
					{
						point.x = x;
						point.y = y + ysai;
						VecEff.addElement(point);
					}
				}
			}
			break;
		}
		case 95:
		{
			indexSound = 21;
			int a = CRes.angle(toX - x, toY - y);
			int num = CRes.abs(MainObject.getDistance(x, y, toX, toY));
			x1000 = x + CRes.cos(a) * num / 1000;
			y1000 = y + CRes.sin(a) * num / 1000;
			fRemove = 10;
			timeAddNum = 7;
			setBeginKill(0);
			dxTower = 0;
			dyTower = 50;
			createLighting(x - dxTower, y - hOne / 2 - dyTower, x1000, y1000, isEnd: true);
			if (objKill == GameScreen.player)
			{
				mSound.playSound(32, mSound.volumeSound);
			}
			GameScreen.addEffectEndKill(40, x1000, y1000 + 20);
			break;
		}
		case 96:
			fRemove = 60;
			fraImgEff = new FrameImage(132);
			fraImgSubEff = new FrameImage(9);
			vMax = 8000;
			createDanFocus();
			frame = setFrameAngle(gocT_Arc);
			mSound.playSound(57, mSound.volumeSound);
			dxTower = 4;
			dyTower = -50;
			x += dxTower;
			y += dyTower;
			break;
		case 97:
			timeAddNum = 3;
			fraImgEff = new FrameImage(21);
			fraImgSubEff = new FrameImage(59);
			fRemove = 16;
			dxTower = 0;
			dyTower = -86;
			x += dxTower;
			y += dyTower;
			break;
		case 98:
			create_FireBall_Tower();
			break;
		case 99:
			{
				if (objKill.Direction == 3)
				{
					dxTower = -10;
					dyTower = -20;
				}
				else
				{
					dxTower = 10;
					dyTower = -20;
				}
				create_Sung_Medusa();
				GameScreen.addEffectEndKill(48, objKill.x + dxTower, objKill.y + dyTower);
				break;
			}
			IL_1a8a:
			fRemove = 16;
			for (int l = 0; l < vecObjBeKill.size(); l++)
			{
				Point point3 = new Point();
				Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)vecObjBeKill.elementAt(l);
				if (object_Effect_Skill4 != null)
				{
					MainObject mainObject3 = MainObject.get_Item_Object(object_Effect_Skill4.ID, object_Effect_Skill4.tem);
					if (mainObject3 != null)
					{
						point3.x = mainObject3.x;
						point3.y = mainObject3.y + mainObject3.ysai;
						VecEff.addElement(point3);
					}
				}
			}
			break;
			IL_10b6:
			fraImgSubEff = new FrameImage(53);
			fRemove = 20;
			for (int m = 0; m < vecObjBeKill.size(); m++)
			{
				Point point4 = new Point();
				Object_Effect_Skill object_Effect_Skill5 = (Object_Effect_Skill)vecObjBeKill.elementAt(m);
				if (object_Effect_Skill5 != null)
				{
					MainObject mainObject4 = MainObject.get_Item_Object(object_Effect_Skill5.ID, object_Effect_Skill5.tem);
					if (mainObject4 != null)
					{
						point4.x = mainObject4.x;
						point4.y = mainObject4.y + mainObject4.ysai;
						VecEff.addElement(point4);
					}
				}
			}
			break;
			IL_1005:
			fraImgEff = new FrameImage(83);
			fraImgSubEff = new FrameImage(68);
			fRemove = 15;
			if (objBeKillMain != null)
			{
				toX = objBeKillMain.x;
				toY = objBeKillMain.y;
			}
			break;
			IL_1410:
			vMax = 22;
			vx = vMax;
			for (int num9 = 0; num9 < vecObjBeKill.size(); num9++)
			{
				Object_Effect_Skill object_Effect_Skill8 = (Object_Effect_Skill)vecObjBeKill.elementAt(num9);
				if (object_Effect_Skill8 == null)
				{
					continue;
				}
				MainObject mainObject7 = MainObject.get_Object(object_Effect_Skill8.ID, object_Effect_Skill8.tem);
				if (mainObject7 == null)
				{
					continue;
				}
				Point point8 = create_ICE_Drop(mainObject7.x, mainObject7.y);
				point8.dis = CRes.random(2);
				point8.vecEffPoint = new mVector("EffectSkill vecEffPoint");
				int num10 = CRes.random(3, 7);
				for (int num11 = 0; num11 < num10; num11++)
				{
					Point point9 = new Point();
					point9.x = point8.x + CRes.random_Am_0(20);
					point9.y = point8.y - 10 - CRes.random(35);
					point9.dis = 0;
					if (CRes.random(6) == 0)
					{
						point9.dis = 1;
					}
					else
					{
						point9.frame = CRes.random(4);
					}
					point8.vecEffPoint.addElement(point9);
				}
				VecEff.addElement(point8);
			}
			break;
		}
		if (!isEff && objKill != null && objKill.typeObject != 1)
		{
			for (int num13 = 0; num13 < vecObjBeKill.size(); num13++)
			{
				Object_Effect_Skill object_Effect_Skill10 = (Object_Effect_Skill)vecObjBeKill.elementAt(num13);
				if (object_Effect_Skill10 == null)
				{
					vecObjBeKill.removeElement(object_Effect_Skill10);
					num13--;
					continue;
				}
				MainObject mainObject9 = MainObject.get_Object(object_Effect_Skill10.ID, object_Effect_Skill10.tem);
				if (mainObject9 == null)
				{
					vecObjBeKill.removeElement(object_Effect_Skill10);
					num13--;
				}
				else if (mainObject9.Action != 4)
				{
					mainObject9.hp = object_Effect_Skill10.hpLast;
					if (mainObject9.hp <= 0 && mainObject9 != GameScreen.player)
					{
						mainObject9.resetAction();
						mainObject9.Action = 4;
						mainObject9.timedie = GameCanvas.timeNow;
						GameScreen.addEffectEndKill(11, mainObject9.x, mainObject9.y);
					}
				}
				if (vecObjBeKill.size() == 0)
				{
					isStop = true;
				}
			}
		}
		if (indexSound >= 0)
		{
			if (objKill == GameScreen.player)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(indexSound);
			}
		}
	}

	public override void paint(mGraphics g)
	{
		if (mSystem.isj2me && !ispaintArena)
		{
			return;
		}
		try
		{
			test = 10;
			if (isRemove)
			{
				return;
			}
			switch (typeEffect)
			{
			case 124:
				if (fraImgEff == null)
				{
					return;
				}
				fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y, 0, 3, g);
				break;
			case 0:
			case 1:
			case 59:
			case 80:
				if (fraImgEff == null)
				{
					return;
				}
				if (f < fRemove)
				{
					fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y, 0, 3, g);
				}
				else
				{
					fraImgSubEff.drawFrameEffectSkill((f - fRemove) / 2 % fraImgSubEff.nFrame, toX, toY, 0, 3, g);
				}
				break;
			case 109:
			case 110:
				fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y, 0, 3, g);
				break;
			case 103:
			{
				for (int m = 0; m < arr_R.Length; m++)
				{
					fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, CRes.cos(arr_radian[m]) * arr_R[m] / 1024 + x + 2, CRes.sin(arr_radian[m]) * arr_R[m] / 1024 + y - ysai - 20, 0, 3, g);
					if (timedelay <= 0)
					{
						g.drawImage(MainObject.shadow, CRes.cos(arr_radian[m]) * arr_R[m] / 1024 + x + 2, CRes.sin(arr_radian[m]) * arr_R[m] / 1024 + y - 10, 3, mGraphics.isFalse);
					}
				}
				break;
			}
			case 6:
				if (GameCanvas.gameTick % 2 == 0 && mTamgiac != null && mTamgiac.Length > 0)
				{
					for (int num29 = 0; num29 < mTamgiac.Length; num29++)
					{
						g.setColor(colorpaint[num29 / 2]);
						g.fillTriangle(x1000 / 1000, y1000 / 1000, mTamgiac[num29][0] / 1000, mTamgiac[num29][1] / 1000, mTamgiac[num29][2] / 1000, mTamgiac[num29][3] / 1000, mGraphics.isFalse);
					}
				}
				break;
			case 29:
			case 84:
			case 107:
			{
				mVector mVector15 = new mVector();
				for (int num42 = 0; num42 < VecEff.size(); num42++)
				{
					Line line3 = (Line)VecEff.elementAt(num42);
					if (line3 != null)
					{
						int cl6 = 0;
						if (num42 / 2 < colorpaint.Length)
						{
							cl6 = colorpaint[num42 / 2];
						}
						mVector15.addElement(new mLine(line3.x0 / 1000, line3.y0 / 1000, line3.x1 / 1000, line3.y1 / 1000, cl6));
						if (line3.is2Line)
						{
							mVector15.addElement(new mLine(line3.x0 / 1000 + 1, line3.y0 / 1000, line3.x1 / 1000 + 1, line3.y1 / 1000, cl6));
						}
					}
				}
				g.totalLine = mVector15;
				g.drawlineGL();
				break;
			}
			case 111:
			{
				if (f % 5 >= 2 && f % 5 != 3)
				{
					break;
				}
				mVector mVector12 = new mVector();
				for (int num21 = 1; num21 < VecEff.size(); num21++)
				{
					Point point12 = (Point)VecEff.elementAt(num21 - 1);
					Point point13 = (Point)VecEff.elementAt(num21);
					g.setColor(16514254);
					mVector12.addElement(new mLine(point12.x / 1000, point12.y / 1000 - 1, point13.x / 1000, point13.y / 1000 - 1, 16514254));
					mVector12.addElement(new mLine(point12.x / 1000, point12.y / 1000 + 1, point13.x / 1000, point13.y / 1000 + 1, 16514254));
					mVector12.addElement(new mLine(point12.x / 1000, point12.y / 1000 + 2, point13.x / 1000, point13.y / 1000 + 2, 16514254));
					mVector12.addElement(new mLine(point12.x / 1000, point12.y / 1000, point13.x / 1000, point13.y / 1000, 16514254));
				}
				for (int num22 = 1; num22 < VecSubEff.size(); num22++)
				{
					Point point14 = (Point)VecSubEff.elementAt(num22 - 1);
					Point point15 = (Point)VecSubEff.elementAt(num22);
					if (point15.x != -1 && point14.x != -1)
					{
						g.setColor(16514254);
						mVector12.addElement(new mLine(point14.x / 1000, point14.y / 1000, point15.x / 1000, point15.y / 1000, 16514254));
						mVector12.addElement(new mLine(point14.x / 1000, point14.y / 1000 + 1, point15.x / 1000, point15.y / 1000 + 1, 16514254));
					}
				}
				break;
			}
			case 10:
			case 82:
			{
				mVector mVector18 = new mVector();
				if (f % 5 < 2 || f % 5 == 3)
				{
					for (int num69 = 1; num69 < VecEff.size(); num69++)
					{
						Point point48 = (Point)VecEff.elementAt(num69 - 1);
						Point point49 = (Point)VecEff.elementAt(num69);
						mVector18.addElement(new mLine(point48.x / 1000, point48.y / 1000 - 1, point49.x / 1000, point49.y / 1000 - 1, 15791864));
						mVector18.addElement(new mLine(point48.x / 1000, point48.y / 1000 + 1, point49.x / 1000, point49.y / 1000 + 1, 15791864));
						mVector18.addElement(new mLine(point48.x / 1000, point48.y / 1000 + 2, point49.x / 1000, point49.y / 1000 + 2, 15791864));
						mVector18.addElement(new mLine(point48.x / 1000, point48.y / 1000, point49.x / 1000, point49.y / 1000, 11068406));
					}
					for (int num70 = 1; num70 < VecSubEff.size(); num70++)
					{
						Point point50 = (Point)VecSubEff.elementAt(num70 - 1);
						Point point51 = (Point)VecSubEff.elementAt(num70);
						if (point51.x != -1 && point50.x != -1)
						{
							mVector18.addElement(new mLine(point50.x / 1000, point50.y / 1000, point51.x / 1000, point51.y / 1000, 15791864));
							mVector18.addElement(new mLine(point50.x / 1000, point50.y / 1000 + 1, point51.x / 1000, point51.y / 1000 + 1, 15791864));
						}
					}
				}
				g.totalLine = mVector18;
				g.drawlineGL();
				break;
			}
			case 11:
			case 86:
			case 108:
			case 114:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num55 = 0; num55 < VecSubEff.size(); num55++)
				{
					Point point39 = (Point)VecSubEff.elementAt(num55);
					if (point39.f / 2 <= 3)
					{
						fraImgSubEff.drawFrameEffectSkill(point39.f / 2, point39.x, point39.y, 0, 3, g);
					}
				}
				for (int num56 = 0; num56 < VecEff.size(); num56++)
				{
					Point point40 = (Point)VecEff.elementAt(num56);
					if (f < point40.f)
					{
						fraImgSub2Eff.drawFrameEffectSkill(CRes.random(2), point40.x - 10, point40.y + point40.vy * f / 1000 - 13, 0, 3, g);
						fraImgEff.drawFrameEffectSkill(point40.v / 2 % fraImgEff.nFrame, point40.x, point40.y + point40.vy * f / 1000, 0, 3, g);
					}
				}
				break;
			}
			case 12:
			{
				if (fRemove < -1)
				{
					fRemove = -1;
				}
				if (fRemove == 0)
				{
					break;
				}
				mVector mVector7 = new mVector();
				int num9 = VecEff.size() / fRemove + 2;
				int num10 = num9 * f;
				if (num10 > VecEff.size())
				{
					num10 = VecEff.size();
				}
				for (int num11 = 1; num11 < num10; num11++)
				{
					Point point6 = (Point)VecEff.elementAt(num11 - 1);
					Point point7 = (Point)VecEff.elementAt(num11);
					if (f <= fRemove - 1)
					{
						mVector7.addElement(new mLine(point6.x / 1000 - xline, point6.y / 1000 - yline, point7.x / 1000 - xline, point7.y / 1000 - yline, 0));
						mVector7.addElement(new mLine(point6.x / 1000 + xline, point6.y / 1000 + yline, point7.x / 1000 + xline, point7.y / 1000 + yline, 0));
					}
					if (f <= fRemove - 2)
					{
						mVector7.addElement(new mLine(point6.x / 1000 + 2 * xline, point6.y / 1000 + 2 * yline, point7.x / 1000 + 2 * xline, point7.y / 1000 + 2 * yline, 0));
					}
					mVector7.addElement(new mLine(point6.x / 1000, point6.y / 1000, point7.x / 1000, point7.y / 1000, 4140567));
				}
				if (f <= fRemove - 2)
				{
					num9 = VecSubEff.size() / fRemove + 2;
					num10 = num9 * f;
					if (num10 > VecSubEff.size())
					{
						num10 = VecSubEff.size();
					}
					for (int num12 = 1; num12 < num10; num12++)
					{
						Point point8 = (Point)VecSubEff.elementAt(num12 - 1);
						Point point9 = (Point)VecSubEff.elementAt(num12);
						if (point9.x != -1 && point8.x != -1)
						{
							mVector7.addElement(new mLine(point8.x / 1000, point8.y / 1000, point9.x / 1000, point9.y / 1000, 0));
							mVector7.addElement(new mLine(point8.x / 1000 + xline, point8.y / 1000 + yline, point9.x / 1000 + xline, point9.y / 1000 + yline, 0));
						}
					}
				}
				g.totalLine = mVector7;
				g.drawlineGL();
				break;
			}
			case 14:
			case 81:
			case 115:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num74 = 0; num74 < VecEff.size(); num74++)
				{
					Point point55 = (Point)VecEff.elementAt(num74);
					if (point55.f == 0)
					{
						fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, point55.x / 1000, point55.y / 1000, 0, 3, g);
					}
					else if (point55.f > 0)
					{
						fraImgSubEff.drawFrameEffectSkill((point55.f - 1) / 2 % fraImgSubEff.nFrame, point55.x / 1000, point55.y / 1000 - 4 - point55.f, 0, 3, g);
					}
				}
				break;
			}
			case 20:
			case 113:
			{
				if (fraImgEff == null)
				{
					return;
				}
				mVector mVector14 = new mVector();
				for (int num41 = 0; num41 < VecEff.size(); num41++)
				{
					Point point30 = (Point)VecEff.elementAt(num41);
					if (point30 == null || point30.isRemove)
					{
						continue;
					}
					if (point30.dis == 0)
					{
						if (typeEffect == 20)
						{
							mVector14.addElement(new mLine(point30.x, point30.y, point30.x + 6, point30.y + 8, 11453204));
							mVector14.addElement(new mLine(point30.x, point30.y, point30.x + 5, point30.y + 8, 11453204));
						}
						else
						{
							mVector14.addElement(new mLine(point30.x, point30.y, point30.x + 6, point30.y + 8, 10549488));
							mVector14.addElement(new mLine(point30.x, point30.y, point30.x + 5, point30.y + 8, 10549488));
						}
					}
					else if (point30.dis == 1 && point30.f < 2 && typeEffect != 113)
					{
						fraImgEff.drawFrameEffectSkill1(point30.f, point30.x, point30.y - point30.vy / 2, 0, g);
					}
				}
				g.totalLine = mVector14;
				g.drawlineGL();
				break;
			}
			case 21:
				if (fraImgEff == null)
				{
					return;
				}
				fraImgEff.drawFrameEffectSkill(f / 2 % 3, x, y, 0, 3, g);
				fraImgSubEff.drawFrameEffectSkill(f / 2 % 3, x, y, 0, 3, g);
				break;
			case 22:
			case 31:
			case 88:
				if (fraImgEff == null)
				{
					return;
				}
				if (typeEffect == 31 || typeEffect == 88)
				{
					for (int num62 = 0; num62 < VecEff.size(); num62++)
					{
						Point point46 = (Point)VecEff.elementAt(num62);
						fraImgSubEff.drawFrameEffectSkill(point46.f / 2 % fraImgSubEff.nFrame, point46.x, point46.y, frameArrow, 3, g);
					}
				}
				if (f < fRemove)
				{
					paint_Bullet(g, fraImgEff, frame, x, y, isMore: false);
				}
				break;
			case 23:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num48 = 0; num48 < VecEff.size(); num48++)
				{
					Point point33 = (Point)VecEff.elementAt(num48);
					paint_Bullet(g, fraImgEff, frame, point33.x, point33.y, isMore: false);
				}
				break;
			}
			case 25:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num14 = 0; num14 < VecEff.size(); num14++)
				{
					Point point11 = (Point)VecEff.elementAt(num14);
					if (point11 != null)
					{
						fraImgSubEff.drawFrameEffectSkill(point11.f % fraImgSubEff.nFrame, point11.x, point11.y, frameArrow, 3, g);
					}
				}
				if (typeEffect == 25 && f < fRemove)
				{
					paint_Bullet(g, fraImgEff, frame, x, y, isMore: false);
				}
				break;
			}
			case 26:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num72 = 0; num72 < VecEff.size(); num72++)
				{
					Point point53 = (Point)VecEff.elementAt(num72);
					if (point53.f < 7)
					{
						fraImgEff.drawFrameEffectSkill(point53.f / 2 % fraImgEff.nFrame, point53.x, point53.y, 0, 3, g);
					}
				}
				if (f >= fRemove && f <= fRemove + 5)
				{
					fraImgSubEff.drawFrameEffectSkill((f - fRemove) / 2 % fraImgSubEff.nFrame, toX, toY - 5, 0, 3, g);
				}
				break;
			}
			case 27:
			{
				for (int num71 = 0; num71 < VecEff.size(); num71++)
				{
					Point point52 = (Point)VecEff.elementAt(num71);
					if (point52.f < 3)
					{
						fraImgEff.drawFrameEffectSkill(point52.f % fraImgEff.nFrame, point52.x, point52.y, 0, 3, g);
					}
				}
				break;
			}
			case 28:
				if (fraImgEff == null)
				{
					return;
				}
				fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y - fraImgEff.frameHeight, 0, mGraphics.TOP | mGraphics.HCENTER, g);
				break;
			case 30:
			{
				for (int num61 = 0; num61 < VecEff.size(); num61++)
				{
					Point point45 = (Point)VecEff.elementAt(num61);
					if (point45 != null && point45.f < 5)
					{
						if (point45.f < 4)
						{
							fraImgEff.drawFrameEffectSkill(point45.f % fraImgEff.nFrame, point45.x / 1000, point45.y / 1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
						}
						else
						{
							fraImgEff.drawFrameEffectSkill(3, point45.x / 1000, point45.y / 1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
						}
					}
				}
				break;
			}
			case 34:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num47 = 0; num47 < VecEff.size(); num47++)
				{
					Point point32 = (Point)VecEff.elementAt(num47);
					int trans = 0;
					if (point32.vx < 0)
					{
						trans = 2;
					}
					fraImgEff.drawFrameEffectSkill(point32.f % fraImgEff.nFrame, point32.x, point32.y, trans, 3, g);
					if (point32.f % 3 != 2 && objBeKillMain != null)
					{
						fraImgSubEff.drawFrameEffectSkill(point32.f % fraImgSubEff.nFrame, objBeKillMain.x, objBeKillMain.y - objBeKillMain.hOne / 2, 0, 3, g);
					}
				}
				break;
			}
			case 40:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num35 = 0; num35 < VecEff.size(); num35++)
				{
					Point point26 = (Point)VecEff.elementAt(num35);
					if (point26 != null)
					{
						int num36 = (point26.x + point26.vx) / 1000;
						int num37 = (point26.y + point26.vy) / 1000;
						if (f / 2 % 2 == 0)
						{
							paint_Bullet(g, fraImgEff, point26.frame, num36, num37, isMore: false);
						}
						else
						{
							paint_Bullet(g, fraImgSub2Eff, point26.frame, num36, num37, isMore: false);
						}
					}
				}
				for (int num38 = 0; num38 < VecSubEff.size(); num38++)
				{
					Point point27 = (Point)VecSubEff.elementAt(num38);
					fraImgSubEff.drawFrameEffectSkill(f % fraImgSubEff.nFrame, point27.x / 1000, point27.y / 1000, 0, 3, g);
				}
				break;
			}
			case 41:
			case 83:
			{
				for (int num32 = 0; num32 < VecEff.size(); num32++)
				{
					Point point23 = (Point)VecEff.elementAt(num32);
					fraImgEff.drawFrameEffectSkill(point23.f % fraImgEff.nFrame, point23.x, point23.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				break;
			}
			case 42:
			{
				mVector mVector8 = new mVector();
				fraImgEff.drawFrameEffectSkill(f / 4 % fraImgEff.nFrame, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				if (f < fRemove / 2)
				{
					for (int num13 = 0; num13 < VecEff.size(); num13++)
					{
						Point point10 = (Point)VecEff.elementAt(num13);
						int cl2 = 16777215;
						if (point10.frame == 1)
						{
							cl2 = 9468112;
						}
						if (point10.fRe == 1)
						{
							mVector8.addElement(new mLine(x + point10.x, y + point10.y, x + point10.x, y + point10.y - point10.limitY, cl2));
						}
						if (point10.frame == 2)
						{
							mVector8.addElement(new mLine(x + point10.x + 1, y + point10.y, x + point10.x + 1, y + point10.y - point10.limitY, 9468112));
						}
					}
				}
				else
				{
					fraImgSubEff.drawFrameEffectSkill(0, x, y - 50 - (f - fRemove / 2) * 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				g.totalLine = mVector8;
				g.drawlineGL();
				break;
			}
			case 43:
			{
				mVector mVector3 = new mVector();
				fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y - 10, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				for (int i = 0; i < VecEff.size(); i++)
				{
					Point point = (Point)VecEff.elementAt(i);
					int cl = 16777215;
					if (point.frame == 1)
					{
						cl = 9468112;
					}
					if (point.fRe == 1)
					{
						mVector3.addElement(new mLine(x + point.x, y + point.y, x + point.x, y + point.y - point.limitY, cl));
					}
					if (point.frame == 2)
					{
						mVector3.addElement(new mLine(x + point.x + 1, y + point.y, x + point.x + 1, y + point.y - point.limitY, 9468112));
					}
				}
				g.totalLine = mVector3;
				g.drawlineGL();
				break;
			}
			case 46:
				if (fraImgEff == null)
				{
					return;
				}
				if (f < 3)
				{
					if (objBeKillMain != null)
					{
						fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, toX, toY - objBeKillMain.hOne / 2, 0, 3, g);
					}
				}
				else
				{
					fraImgSubEff.drawFrameEffectSkill(f / 2 % fraImgSubEff.nFrame, toX, toY + 5, (CRes.random(2) != 0) ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 112:
			{
				for (int num53 = 0; num53 < VecEff.size(); num53++)
				{
					Point point37 = (Point)VecEff.elementAt(num53);
					if (point37 != null && f >= point37.fRe && f <= fRemove - 3 + point37.fRe)
					{
						fraImgSubEff.drawFrameEffectSkill((f / 3 + point37.fRe) % fraImgSubEff.nFrame, point37.x / 1000, point37.y / 1000 + 4, point37.dis, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					}
				}
				break;
			}
			case 47:
			{
				for (int num49 = 0; num49 < VecEff.size(); num49++)
				{
					Point point34 = (Point)VecEff.elementAt(num49);
					if (point34 != null && f >= point34.fRe && f <= fRemove - 3 + point34.fRe)
					{
						fraImgEff.drawFrameEffectSkill(point34.frame, point34.x / 1000, point34.y / 1000, point34.dis, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						fraImgSubEff.drawFrameEffectSkill((f / 3 + point34.fRe) % fraImgSubEff.nFrame, point34.x / 1000, point34.y / 1000 + 4, point34.dis, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					}
				}
				break;
			}
			case 49:
			{
				if (fraImgEff == null)
				{
					return;
				}
				if (f < 6)
				{
					fraImgSubEff.drawFrameEffectSkill(f / 2, x1000, y1000, 0, 3, g);
				}
				for (int num34 = 0; num34 < VecEff.size(); num34++)
				{
					Point point25 = (Point)VecEff.elementAt(num34);
					fraImgEff.drawFrameEffectSkill(point25.f % fraImgEff.nFrame, point25.x, point25.y, 0, 3, g);
				}
				if (f >= fRemove && f < fRemove + 6)
				{
					fraImgSubEff.drawFrameEffectSkill((f - fRemove) / 2, toX, toY, 0, 3, g);
				}
				break;
			}
			case 50:
				if (f < 3 && fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, x, y, frameArrow, frame, g);
				}
				break;
			case 125:
			{
				mVector mVector9 = new mVector();
				for (int num16 = 0; num16 < size1; num16++)
				{
					int num17 = 0;
					num17 = ((num16 != size1 - 1) ? 16777215 : 720469);
					mVector9.addElement(new mLine(x + num16 * vX1000, y + num16 * vY1000, x1000 + num16 * vX1000, y1000 + num16 * vY1000, num17));
					mVector9.addElement(new mLine(x - num16 * vX1000, y - num16 * vY1000, x1000 - num16 * vX1000, y1000 - num16 * vY1000, num17));
				}
				break;
			}
			case 126:
			{
				mVector mVector11 = new mVector();
				for (int num19 = 0; num19 < size1; num19++)
				{
					int num20 = 0;
					num20 = ((num19 != size1 - 1) ? 16777215 : 15771896);
					mVector11.addElement(new mLine(x + num19 * vX1000, y + num19 * vY1000, x1000 + num19 * vX1000, y1000 + num19 * vY1000, num20));
					mVector11.addElement(new mLine(x - num19 * vX1000, y - num19 * vY1000, x1000 - num19 * vX1000, y1000 - num19 * vY1000, num20));
				}
				break;
			}
			case 106:
			{
				if (fraImgEff == null)
				{
					return;
				}
				mVector mVector5 = new mVector();
				fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, x, y, 0, 3, g);
				for (int k = 0; k < size1; k++)
				{
					int num2 = 0;
					num2 = ((k != size1 - 1) ? 16777215 : 720469);
					mVector5.addElement(new mLine(x + k * vX1000, y + k * vY1000, x1000 + k * vX1000, y1000 + k * vY1000, num2));
					mVector5.addElement(new mLine(x - k * vX1000, y - k * vY1000, x1000 - k * vX1000, y1000 - k * vY1000, num2));
				}
				for (int l = 0; l < VecEff.size(); l++)
				{
					Point point3 = (Point)VecEff.elementAt(l);
					if (point3 != null)
					{
						fraImgSubEff.drawFrameEffectSkill(point3.f % fraImgSubEff.nFrame, point3.x, point3.y, 0, 3, g);
					}
				}
				break;
			}
			case 105:
			{
				if (fraImgEff == null)
				{
					return;
				}
				mVector mVector17 = new mVector();
				if (f < fRemove)
				{
					fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, x, y, 0, 3, g);
					if (f > 8)
					{
						int num65 = fRemove - f;
						if (num65 < 1)
						{
							num65 = 1;
						}
						for (int num66 = 0; num66 < num65; num66++)
						{
							int num67 = 0;
							num67 = ((num66 != num65 - 1) ? 16777215 : 720469);
							mVector17.addElement(new mLine(x + num66 * vX1000, y + num66 * vY1000, x1000 + num66 * vX1000, y1000 + num66 * vY1000, num67));
							mVector17.addElement(new mLine(x - num66 * vX1000, y - num66 * vY1000, x1000 - num66 * vX1000, y1000 - num66 * vY1000, num67));
						}
					}
				}
				for (int num68 = 0; num68 < VecEff.size(); num68++)
				{
					Point point47 = (Point)VecEff.elementAt(num68);
					if (point47 != null)
					{
						fraImgSubEff.drawFrameEffectSkill(point47.f % fraImgSubEff.nFrame, point47.x, point47.y, 0, 3, g);
					}
				}
				break;
			}
			case 51:
			{
				if (fraImgEff == null)
				{
					return;
				}
				mVector mVector16 = new mVector();
				if (f < fRemove)
				{
					fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, x, y, 0, 3, g);
					if (f > 8)
					{
						int num43 = fRemove - f;
						if (num43 < 1)
						{
							num43 = 1;
						}
						for (int num44 = 0; num44 < num43; num44++)
						{
							int num45 = 0;
							num45 = ((num44 != num43 - 1) ? 16777215 : 16711680);
							mVector16.addElement(new mLine(x + num44 * vX1000, y + num44 * vY1000, x1000 + num44 * vX1000, y1000 + num44 * vY1000, num45));
							mVector16.addElement(new mLine(x - num44 * vX1000, y - num44 * vY1000, x1000 - num44 * vX1000, y1000 - num44 * vY1000, num45));
						}
					}
				}
				for (int num46 = 0; num46 < VecEff.size(); num46++)
				{
					Point point31 = (Point)VecEff.elementAt(num46);
					if (point31 != null)
					{
						fraImgSubEff.drawFrameEffectSkill(point31.f % fraImgSubEff.nFrame, point31.x, point31.y, 0, 3, g);
					}
				}
				g.totalLine = mVector16;
				g.drawlineGL();
				break;
			}
			case 52:
			case 54:
			{
				if (fraImgEff == null)
				{
					return;
				}
				fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, toX, toY, (CRes.random(2) != 0) ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				for (int num33 = 0; num33 < VecEff.size(); num33++)
				{
					Point point24 = (Point)VecEff.elementAt(num33);
					fraImgSubEff.drawFrameEffectSkill(point24.f / 2 % fraImgSubEff.nFrame, point24.x, point24.y, 0, 3, g);
				}
				break;
			}
			case 53:
			case 64:
			case 78:
			case 104:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num26 = 0; num26 < VecEff.size(); num26++)
				{
					Point point18 = (Point)VecEff.elementAt(num26);
					if (f <= fRemove)
					{
						int num27 = 0;
						int num28 = 3;
						if (f < 2)
						{
							num27 = f;
						}
						if (f > fRemove - 5)
						{
							num27 = fRemove - f;
							num28 = 5;
						}
						else
						{
							num27 = 2;
						}
						g.drawRegion(fraImgEff.imgFrame, 0, 0, fraImgEff.frameWidth, fraImgEff.frameHeight / num28 * (num27 + 1), 0, point18.x, point18.y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
						if (f < 3)
						{
							fraImgSubEff.drawFrameEffectSkill(f, point18.x, point18.y + 10, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						}
					}
				}
				break;
			}
			case 55:
			{
				if (fraImgEff == null)
				{
					return;
				}
				if (f < 6)
				{
					fraImgEff.drawFrameEffectSkill(f / 2, toX, toY, 0, 3, g);
				}
				mVector mVector10 = new mVector();
				for (int num18 = 0; num18 < VecEff.size(); num18++)
				{
					if (num18 < VecEff.size())
					{
						Line line2 = (Line)VecEff.elementAt(num18);
						int cl3 = 16777209;
						if (line2.idColor == 1)
						{
							cl3 = 16314560;
						}
						mVector10.addElement(new mLine(line2.x0, line2.y0, line2.x1, line2.y1, cl3));
						if (line2.is2Line)
						{
							mVector10.addElement(new mLine(line2.x0 + 1, line2.y0 - 1, line2.x1 + 1, line2.y1 - 1, 16310352));
						}
					}
				}
				g.totalLine = mVector10;
				g.drawlineGL();
				break;
			}
			case 56:
				if (subType == 10)
				{
					fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				else if (subType == 11)
				{
					fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, x, y + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 57:
			case 70:
			{
				mVector mVector4 = new mVector();
				for (int num = VecEff.size() - 1; num >= 0; num--)
				{
					Line line = (Line)VecEff.elementAt(num);
					if (line != null && line.f < 6)
					{
						mVector4.addElement(new mLine(line.x0 / 1000, line.y0 / 1000, line.x1 / 1000, line.y1 / 1000, colorpaint[num]));
						if (line.is2Line)
						{
							mVector4.addElement(new mLine(line.x0 / 1000 + 1, line.y0 / 1000 + 1, line.x1 / 1000 + 1, line.y1 / 1000, colorpaint[num]));
						}
					}
				}
				g.totalLine = mVector4;
				g.drawlineGL();
				break;
			}
			case 58:
			{
				if (f < 2)
				{
					g.setColor(16777215);
					g.fillRect(x - 9, MainScreen.cameraMain.yCam, 18, (y - MainScreen.cameraMain.yCam) / 2 * (f + 1), mGraphics.isFalse);
					g.setColor(9468112);
					g.fillRect(x - 10, MainScreen.cameraMain.yCam, 2, (y - MainScreen.cameraMain.yCam) / 2 * (f + 1), mGraphics.isFalse);
					g.fillRect(x + 9, MainScreen.cameraMain.yCam, 2, (y - MainScreen.cameraMain.yCam) / 2 * (f + 1), mGraphics.isFalse);
				}
				else if (f < 8)
				{
					g.setColor(16777215);
					g.fillRect(x - 9 + (f - 2) / 2 * 3, MainScreen.cameraMain.yCam, 18 - (f - 2) / 2 * 6, y - MainScreen.cameraMain.yCam, mGraphics.isFalse);
					g.setColor(9468112);
					g.fillRect(x - 10 + (f - 2) / 2 * 3, MainScreen.cameraMain.yCam, 2, y - MainScreen.cameraMain.yCam, mGraphics.isFalse);
					g.fillRect(x + 9 - (f - 2) / 2 * 3, MainScreen.cameraMain.yCam, 2, y - MainScreen.cameraMain.yCam, mGraphics.isFalse);
				}
				if (f > 1 && f < 11)
				{
					fraImgEff.drawFrameEffectSkill(3 + (f - 2) / 3, x, y + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				for (int num60 = 0; num60 < VecEff.size(); num60++)
				{
					Point point44 = (Point)VecEff.elementAt(num60);
					fraImgSubEff.drawFrameEffectSkill((f >= 8) ? 1 : 0, point44.x, point44.y + 4, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			}
			case 61:
			case 77:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num58 = 0; num58 < VecEff.size(); num58++)
				{
					Point point42 = (Point)VecEff.elementAt(num58);
					if (f >= point42.f)
					{
						continue;
					}
					for (int num59 = 0; num59 < point42.vecEffPoint.size(); num59++)
					{
						Point point43 = (Point)point42.vecEffPoint.elementAt(num59);
						if (point43.dis == 1)
						{
							fraImgSub2Eff.drawFrameEffectSkill(0, point43.x, point43.y + point42.vy * f / 1000, 0, 3, g);
						}
						else
						{
							fraImgSubEff.drawFrameEffectSkill(point43.frame, point43.x, point43.y + point42.vy * f / 1000, 0, 3, g);
						}
					}
					fraImgEff.drawFrameEffectSkill(point42.dis, point42.x, point42.y + point42.vy * f / 1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				break;
			}
			case 62:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num54 = 0; num54 < VecEff.size(); num54++)
				{
					Point point38 = (Point)VecEff.elementAt(num54);
					if (point38.f > 0)
					{
						paint_Bullet(g, fraImgEff, point38.frame, point38.x, point38.y, isMore: false);
					}
				}
				break;
			}
			case 63:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num50 = 0; num50 < VecEff.size(); num50++)
				{
					Point point35 = (Point)VecEff.elementAt(num50);
					if (point35.f > 0)
					{
						paint_Bullet(g, fraImgEff, point35.frame, point35.x, point35.y, isMore: false);
					}
				}
				break;
			}
			case 73:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int num39 = 0; num39 < VecSubEff.size(); num39++)
				{
					Point point28 = (Point)VecSubEff.elementAt(num39);
					fraImgSubEff.drawFrameEffectSkill(point28.f / 2 % fraImgSubEff.nFrame, point28.x, point28.y, frameArrow, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				for (int num40 = 0; num40 < VecEff.size(); num40++)
				{
					Point point29 = (Point)VecEff.elementAt(num40);
					if (point29.f > 0)
					{
						paint_Bullet(g, fraImgEff, point29.frame, point29.x, point29.y, isMore: false);
					}
				}
				break;
			}
			case 67:
				if (fraImgEff == null)
				{
					return;
				}
				fraImgEff.drawFrameEffectSkill(f / 2, x1000, y1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				if (f < fRemove && fraImgSubEff != null)
				{
					fraImgSubEff.drawFrameEffectSkill(f % fraImgSubEff.nFrame, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				break;
			case 68:
				if (f < fRemove)
				{
					if (subType == 0)
					{
						fraImgEff.drawFrameEffectSkill(f, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
					}
					else
					{
						fraImgEff.drawFrameEffectSkill(f / 2, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
					}
				}
				break;
			case 69:
				fraImgEff.drawFrameEffectSkill(f / 4 % fraImgEff.nFrame, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 71:
			{
				if (f < 6)
				{
					fraImgSubEff.drawFrameEffectSkill(f / 2, x, y + objKill.hOne / 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				for (int num24 = 0; num24 < VecEff.size(); num24++)
				{
					Point point17 = (Point)VecEff.elementAt(num24);
					if (f <= fRemove)
					{
						int num25 = 0;
						num25 = ((f < 3) ? f : ((f <= fRemove - 3) ? CRes.random(2, 4) : (fRemove - f)));
						fraImgEff.drawFrameEffectSkill(num25, point17.x, point17.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						if (f < 6)
						{
							fraImgSubEff.drawFrameEffectSkill(f / 2, point17.x, point17.y + 10, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						}
					}
				}
				break;
			}
			case 72:
			{
				if (fraImgEff == null)
				{
					return;
				}
				if (f < fRemove)
				{
					fraImgSubEff.drawFrameEffectSkill(f / 2 % fraImgSubEff.nFrame, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				for (int num15 = 0; num15 < VecEff.size(); num15++)
				{
					Point_Focus point_Focus2 = (Point_Focus)VecEff.elementAt(num15);
					paint_Bullet(g, fraImgEff, point_Focus2.frame, point_Focus2.x, point_Focus2.y, isMore: false);
				}
				break;
			}
			case 74:
			{
				if (fraImgEff == null)
				{
					return;
				}
				if (f < fRemove)
				{
					fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y + objKill.hOne / 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				for (int num4 = 0; num4 < VecEff.size(); num4++)
				{
					Point_Focus point_Focus = (Point_Focus)VecEff.elementAt(num4);
					fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, point_Focus.x, point_Focus.y, frameArrow, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			}
			case 75:
			{
				if (fraImgEff == null)
				{
					return;
				}
				for (int n = 0; n < VecEff.size(); n++)
				{
					Point point4 = (Point)VecEff.elementAt(n);
					if (f <= fRemove)
					{
						int num3 = 0;
						num3 = ((f < 5) ? (f / 2) : ((num3 <= fRemove - 5) ? CRes.random(2, 4) : ((fRemove - f) / 2)));
						fraImgEff.drawFrameEffectSkill(num3, point4.x, point4.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					}
				}
				break;
			}
			case 76:
			{
				if (fraImgEff == null)
				{
					return;
				}
				if (f < 6)
				{
					fraImgSubEff.drawFrameEffectSkill(f / 2 % fraImgSubEff.nFrame, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				for (int num73 = 0; num73 < VecEff.size(); num73++)
				{
					Point point54 = (Point)VecEff.elementAt(num73);
					fraImgEff.drawFrameEffectSkill(CRes.random(3), point54.x / 1000 + CRes.random_Am_0(5), point54.y / 1000 + CRes.random_Am_0(5), 0, 3, g);
				}
				break;
			}
			case 85:
			{
				if (objBeKillMain == null || objBeKillMain.isRemove || objBeKillMain.isTanHinh || objBeKillMain.isStop)
				{
					break;
				}
				for (int num63 = VecEff.size() - 1; num63 >= 0; num63--)
				{
					Line line4 = (Line)VecEff.elementAt(num63);
					if (line4 != null)
					{
						int num64 = 0;
						num64 = colorStar[0][line4.idColor];
						g.setColor(num64);
						g.drawLine(line4.x0, line4.y0, line4.x1, line4.y1, mGraphics.isFalse);
						if (line4.is2Line)
						{
							g.drawLine(line4.x0 + 1, line4.y0, line4.x1 + 1, line4.y1, mGraphics.isFalse);
						}
					}
				}
				break;
			}
			case 87:
				fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y, 0, 3, g);
				break;
			case 89:
			case 92:
				if (fraImgEff == null)
				{
					return;
				}
				if (typeEffect == 89 || typeEffect == 92)
				{
					for (int num57 = 0; num57 < VecEff.size(); num57++)
					{
						Point point41 = (Point)VecEff.elementAt(num57);
						fraImgSubEff.drawFrameEffectSkill(point41.f / 2 % fraImgSubEff.nFrame, point41.x, point41.y, frameArrow, 3, g);
					}
				}
				if (f < fRemove)
				{
					paint_Bullet(g, fraImgEff, frame, x, y, isMore: false);
				}
				break;
			case 90:
				paint_Ice_Nova_Effect(g);
				break;
			case 91:
				paint_Poison_Nova_Effect(g);
				break;
			case 93:
			{
				if (f < 6)
				{
					fraImgSubEff.drawFrameEffectSkill(f / 2, x, y + objKill.hOne / 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				for (int num51 = 0; num51 < VecEff.size(); num51++)
				{
					Point point36 = (Point)VecEff.elementAt(num51);
					if (f <= fRemove)
					{
						int num52 = 0;
						num52 = ((f < 3) ? f : ((f <= fRemove - 3) ? CRes.random(2, 4) : (fRemove - f)));
						fraImgEff.drawFrameEffectSkill(num52, point36.x, point36.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					}
				}
				break;
			}
			case 101:
				if (ispaintsleep)
				{
					AvMain.imgSleep.drawFrameEffectSkill(frameSleep[frSleep], x - 8, y - (17 + ((objBeKillMain.typeMount != -1) ? objBeKillMain.dyMount : 0)), 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 102:
				AvMain.imgStun.drawFrameEffectSkill(frameStun[frStun], x, y - (ystun + ((objBeKillMain.typeMount != -1) ? objBeKillMain.dyMount : 0)), 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				break;
			case 94:
				if (f < 0)
				{
					return;
				}
				if (fraImgEff != null && objBeKillMain != null)
				{
					fraImgEff.drawFrameEffectSkill(nFrame[f], objBeKillMain.x + 2, objBeKillMain.y + 8, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 95:
			{
				mVector mVector13 = new mVector();
				int cl4 = 11278783;
				int cl5 = 15116264;
				if (f % 5 < 2 || f % 5 == 3)
				{
					for (int num30 = 1; num30 < VecEff.size(); num30++)
					{
						Point point19 = (Point)VecEff.elementAt(num30 - 1);
						Point point20 = (Point)VecEff.elementAt(num30);
						mVector13.addElement(new mLine(point19.x / 1000, point19.y / 1000 - 1, point20.x / 1000, point20.y / 1000 - 1, cl4));
						mVector13.addElement(new mLine(point19.x / 1000, point19.y / 1000 + 1, point20.x / 1000, point20.y / 1000 + 1, cl4));
						mVector13.addElement(new mLine(point19.x / 1000, point19.y / 1000 + 2, point20.x / 1000, point20.y / 1000 + 2, cl4));
						mVector13.addElement(new mLine(point19.x / 1000, point19.y / 1000, point20.x / 1000, point20.y / 1000, cl5));
					}
					for (int num31 = 1; num31 < VecSubEff.size(); num31++)
					{
						Point point21 = (Point)VecSubEff.elementAt(num31 - 1);
						Point point22 = (Point)VecSubEff.elementAt(num31);
						if (point22.x != -1 && point21.x != -1)
						{
							mVector13.addElement(new mLine(point21.x / 1000, point21.y / 1000, point22.x / 1000, point22.y / 1000, cl4));
							mVector13.addElement(new mLine(point21.x / 1000, point21.y / 1000 + 1, point22.x / 1000, point22.y / 1000 + 1, cl4));
						}
					}
				}
				g.totalLine = mVector13;
				g.drawlineGL();
				break;
			}
			case 96:
				if (fraImgEff == null)
				{
					return;
				}
				if (typeEffect == 96)
				{
					for (int num23 = 0; num23 < VecEff.size(); num23++)
					{
						Point point16 = (Point)VecEff.elementAt(num23);
						fraImgSubEff.drawFrameEffectSkill(point16.f / 2 % fraImgSubEff.nFrame, point16.x, point16.y, frameArrow, 3, g);
					}
				}
				if (f < fRemove)
				{
					paint_Bullet(g, fraImgEff, frame, x, y, isMore: false);
				}
				break;
			case 97:
			{
				if (fraImgEff == null)
				{
					return;
				}
				mVector mVector6 = new mVector();
				if (f < fRemove)
				{
					fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, x, y, 0, 3, g);
					if (f > 8)
					{
						int num5 = fRemove - f;
						if (num5 < 1)
						{
							num5 = 1;
						}
						for (int num6 = 0; num6 < num5; num6++)
						{
							int num7 = 0;
							num7 = ((num6 != num5 - 1) ? 16777215 : 16774656);
							mVector6.addElement(new mLine(x + num6 * vX1000, y + num6 * vY1000, xdichTower + num6 * vX1000, ydichTower + num6 * vY1000, num7));
							mVector6.addElement(new mLine(x - num6 * vX1000, y - num6 * vY1000, xdichTower - num6 * vX1000, ydichTower - num6 * vY1000, num7));
						}
					}
				}
				for (int num8 = 0; num8 < VecEff.size(); num8++)
				{
					Point point5 = (Point)VecEff.elementAt(num8);
					if (point5 != null)
					{
						fraImgSubEff.drawFrameEffectSkill(point5.f % fraImgSubEff.nFrame, point5.x, point5.y, 0, 3, g);
					}
				}
				g.totalLine = mVector6;
				g.drawlineGL();
				break;
			}
			case 98:
				if (fraImgEff == null)
				{
					return;
				}
				if (typeEffect == 98)
				{
					for (int j = 0; j < VecEff.size(); j++)
					{
						Point point2 = (Point)VecEff.elementAt(j);
						fraImgSubEff.drawFrameEffectSkill(point2.f / 2 % fraImgSubEff.nFrame, point2.x, point2.y, frameArrow, 3, g);
					}
				}
				if (f < fRemove)
				{
					paint_Bullet(g, fraImgEff, frame, x, y, isMore: false);
				}
				break;
			case 99:
				if (fraImgEff == null)
				{
					return;
				}
				if (f < fRemove)
				{
					paint_Bullet(g, fraImgEff, frame, x, y, isMore: false);
				}
				break;
			case 100:
				break;
			case 2:
			case 3:
			case 4:
			case 5:
			case 7:
			case 8:
			case 9:
			case 13:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 24:
			case 32:
			case 33:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 44:
			case 45:
			case 48:
			case 60:
			case 65:
			case 66:
			case 79:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
			case 121:
			case 122:
			case 123:
				break;
			}
		}
		catch (Exception)
		{
			removeEff();
		}
		test = 0;
	}

	public override void update()
	{
		f++;
		subf++;
		try
		{
			if (objBeKillMain != null)
			{
				xEff = objBeKillMain.x;
				yEff = objBeKillMain.y - objBeKillMain.hOne / 2;
			}
			if (f == timeAddNum && timeAddNum > 0)
			{
				bool flag = true;
				if (mSystem.isj2me && GameScreen.infoGame.ismapHouse(GameCanvas.loadmap.idMap))
				{
					flag = false;
				}
				if (!isEff && flag)
				{
					addNum();
				}
				SetAddSoundTimeAdd();
			}
			bool flag2 = true;
			switch (typeEffect)
			{
			case 124:
				x += vx;
				y += vy;
				if (vy <= 5)
				{
					vy++;
				}
				if (y + vy > yto)
				{
					isRemove = true;
					LoadMap.timeVibrateScreen = 103;
					int num9 = 16;
					removeEff();
					for (int num10 = 0; num10 < num9; num10++)
					{
						int num11 = 24 * posx[indexpost][num10] + CRes.random(10, 100);
						int num12 = 24 * posy[indexpost][num10] + CRes.random(10, 100);
						GameScreen.addEffectEndKill(36, num11, num12);
						GameScreen.addEffectEndKill(9, num11, num12);
					}
				}
				break;
			case 0:
				updateAngleNormal();
				break;
			case 1:
			case 22:
			case 38:
				if (MainObject.getDistance(x, toX, y, toY) > 8 && f < fRemove)
				{
					break;
				}
				if (typeEffect == 22)
				{
					if (objBeKillMain != null)
					{
						GameScreen.addEffectEndKill(7, toX, toY + objBeKillMain.hOne / 4);
					}
				}
				else if (typeEffect == 38)
				{
					GameScreen.addEffectEndKill(2, toX, toY);
				}
				removeEff();
				break;
			case 109:
			case 110:
				if (VecEff.size() > 0)
				{
					Point point51 = (Point)VecEff.elementAt(0);
					if (point51 != null)
					{
						x = point51.x;
						y = point51.y;
						VecEff.removeElement(point51);
					}
				}
				if (VecEff.size() <= 0)
				{
					removeEff();
					if (typeEffect == 109)
					{
						GameScreen.addEffectEndKill(15, toX, toY + objBeKillMain.hOne / 4);
					}
					else
					{
						GameScreen.addEffectEndKill(29, x + 3, y + vy * f / 1000 + 10);
					}
				}
				break;
			case 59:
				if (f >= fRemove + 6)
				{
					removeEff();
				}
				break;
			case 31:
			{
				if (f < fRemove && f > 1)
				{
					Point point4 = new Point();
					point4.x = x - vx;
					point4.y = y - vy;
					VecEff.addElement(point4);
				}
				else if (VecEff.size() == 0 && f >= fRemove)
				{
					removeEff();
				}
				if (f == fRemove && objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(36, toX, toY + objBeKillMain.hOne / 4);
					GameScreen.addEffectEndKill(14, toX, toY + objBeKillMain.hOne / 4);
				}
				for (int l = 0; l < VecEff.size(); l++)
				{
					Point point5 = (Point)VecEff.elementAt(l);
					point5.f++;
					if (point5.f / 2 > 3)
					{
						VecEff.removeElement(point5);
						l--;
					}
				}
				break;
			}
			case 6:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 111:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 10:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 82:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 11:
			case 86:
			case 108:
			case 114:
			{
				for (int num42 = 0; num42 < VecEff.size(); num42++)
				{
					Point point30 = (Point)VecEff.elementAt(num42);
					if (f == point30.f)
					{
						if (typeEffect == 11)
						{
							LoadMap.timeVibrateScreen = 103;
						}
						if (typeEffect != 114)
						{
							GameScreen.addEffectEndKill(0, point30.x, point30.y + point30.vy * f / 1000 - 5);
							GameScreen.addEffectEndKill(9, point30.x, point30.y + point30.vy * f / 1000 + 5);
							GameScreen.addEffectEndKill(26, point30.x, point30.y + point30.vy * f / 1000 + 10);
						}
						else
						{
							GameScreen.addEffectEndKill(49, point30.x, point30.y + point30.vy * f / 1000 + 10);
							GameScreen.addEffectEndKill(28, point30.x, point30.y + point30.vy * f / 1000 + 10);
						}
					}
					else if (f < point30.f)
					{
						point30.x += point30.vx;
						flag2 = false;
						if (CRes.random(2) == 0)
						{
							Point point31 = new Point();
							point31.x = point30.x - point30.vx;
							point31.y = point30.y + point30.vy * (f - 1) / 1000;
							VecSubEff.addElement(point31);
						}
					}
				}
				for (int num43 = 0; num43 < VecSubEff.size(); num43++)
				{
					Point point32 = (Point)VecSubEff.elementAt(num43);
					point32.f++;
					if (point32.f / 2 > 3 && test == 0)
					{
						VecSubEff.removeElement(point32);
						num43--;
					}
				}
				if (flag2)
				{
					removeEff();
				}
				break;
			}
			case 12:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 14:
			case 81:
			case 115:
			{
				for (int num40 = 0; num40 < VecEff.size(); num40++)
				{
					Point point28 = (Point)VecEff.elementAt(num40);
					if (point28.f == 0)
					{
						flag2 = false;
						if (f >= fRemove)
						{
							point28.f = 1;
							continue;
						}
						point28.x += point28.vx;
						point28.y += point28.vy;
						if (typeEffect == 14 || typeEffect == 115 || f > 6)
						{
							int tile2 = GameCanvas.loadmap.getTile(point28.x / 1000, point28.y / 1000);
							if (tile2 == -1 || tile2 == 1 || !MainEffect.isInScreen(point28.x / 1000, point28.y / 1000, fraImgEff.frameWidth, fraImgEff.frameHeight))
							{
								point28.f = 1;
							}
						}
					}
					else if (point28.f > 0)
					{
						point28.f++;
						if ((point28.f - 1) / 2 >= fraImgSubEff.nFrame)
						{
							point28.f = -1;
							VecEff.removeElement(point28);
						}
						flag2 = false;
					}
				}
				if (flag2)
				{
					removeEff();
				}
				break;
			}
			case 20:
			case 113:
			{
				for (int num56 = 0; num56 < VecEff.size(); num56++)
				{
					Point point42 = (Point)VecEff.elementAt(num56);
					if (point42.dis == 0)
					{
						point42.update();
						if (point42.f >= point42.fRe)
						{
							point42.dis = 1;
							point42.f = 0;
							if (!GameCanvas.lowGraphic && CRes.random(4) == 0)
							{
								GameScreen.addEffectEndKill((typeEffect != 20) ? 10 : 24, point42.x, point42.y);
							}
						}
					}
					else if (point42.dis == 1)
					{
						point42.f++;
						if (point42.f >= 2 && test == 0)
						{
							VecEff.removeElement(point42);
							num56--;
						}
					}
				}
				if (f < fRemove)
				{
					if (!GameCanvas.lowGraphic || GameCanvas.gameTick % 2 == 0)
					{
						y1000 = MainScreen.cameraMain.yCam - CRes.random(10, 20);
						create_Arrow_Rain();
					}
				}
				else if (VecEff.size() == 0)
				{
					removeEff();
				}
				break;
			}
			case 21:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 26:
			{
				for (int num70 = 0; num70 < VecEff.size(); num70++)
				{
					Point point54 = (Point)VecEff.elementAt(num70);
					point54.f++;
					if (point54.f >= 7)
					{
						VecEff.removeElement(point54);
						num70--;
					}
				}
				if (f <= fRemove)
				{
					Point point55 = new Point();
					point55.x = x;
					point55.y = y;
					VecEff.addElement(point55);
					break;
				}
				if (f == fRemove + 1 && typeEffect == 26)
				{
					LoadMap.timeVibrateScreen = 103;
				}
				if (VecEff.size() == 0 && f > fRemove + 5)
				{
					removeEff();
				}
				break;
			}
			case 27:
			{
				for (int num8 = 0; num8 < VecEff.size(); num8++)
				{
					Point point11 = (Point)VecEff.elementAt(num8);
					point11.f++;
					if (point11.f >= 3)
					{
						VecEff.removeElement(point11);
						num8--;
					}
				}
				if (f < fRemove)
				{
					if (f == 0)
					{
						GameScreen.addEffectEndKill(6, x, y);
						setSendMove(x, toX, y, toY);
					}
					Point point12 = new Point();
					point12.x = x;
					point12.y = y - 10;
					VecEff.addElement(point12);
				}
				else if (objKill != null)
				{
					if (f == fRemove)
					{
						if (objKill.Action != 4 && objKill.Action != 3)
						{
							objKill.Action = 2;
							objKill.fplash = 6;
							objKill.frame = 5;
						}
					}
					else if (f == fRemove + 5 && objKill.Action == 2)
					{
						f = 0;
						objKill.Action = 0;
					}
					if (objKill.isTanHinh)
					{
						objKill.isTanHinh = false;
					}
					if (VecEff.size() == 0)
					{
						if (objKill.Action == 2)
						{
							f = 0;
							objKill.Action = 0;
						}
						removeEff();
						int tile = GameCanvas.loadmap.getTile(objKill.x, objKill.y);
						if (tile == 2)
						{
							objKill.isWater = true;
						}
						else
						{
							objKill.isWater = false;
						}
					}
				}
				if (f == timeAddNum && objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(5, objBeKillMain.x, objBeKillMain.y - objBeKillMain.hOne / 2);
				}
				break;
			}
			case 28:
				if (f >= fRemove)
				{
					removeEff();
				}
				if (f == 0)
				{
					GameScreen.addEffectEndKill(9, toX, toY);
					if (GameScreen.isWater(toX, toY))
					{
						GameScreen.addEffectEndKill(1, toX, toY);
					}
				}
				break;
			case 23:
			{
				for (int num62 = 0; num62 < VecEff.size(); num62++)
				{
					Point point48 = (Point)VecEff.elementAt(num62);
					point48.update();
					if (point48.f >= point48.fRe)
					{
						VecEff.removeElement(point48);
						num62--;
					}
				}
				if (f >= fRemove && VecEff.size() == 0)
				{
					if (objBeKillMain != null)
					{
						GameScreen.addEffectEndKill(12, toX, toY + objBeKillMain.hOne / 4);
					}
					removeEff();
				}
				if (f == 0)
				{
					int num63 = x;
					int num64 = y;
					switch (Direction)
					{
					case 1:
						num64 -= 20;
						break;
					case 0:
						num64 += 20;
						break;
					case 2:
						num63 -= 20;
						break;
					case 3:
						num63 += 20;
						break;
					}
					GameScreen.addEffectEndKill(13, num63, num64);
				}
				break;
			}
			case 25:
			{
				if (f == fRemove && objBeKillMain != null)
				{
					if (typeEffect == 25)
					{
						GameScreen.addEffectEndKill(10, toX, toY);
						GameScreen.addEffectEndKill(15, toX, toY + objBeKillMain.hOne / 4);
					}
					else
					{
						GameScreen.addEffectEndKill(4, toX, toY);
						GameScreen.addEffectEndKill(14, toX, toY + objBeKillMain.hOne / 4);
					}
				}
				if (f < fRemove)
				{
					Point point24 = new Point();
					point24.x = x;
					point24.y = y;
					VecEff.addElement(point24);
				}
				else if (VecEff.size() == 0 && f >= fRemove)
				{
					removeEff();
				}
				for (int num36 = 0; num36 < VecEff.size(); num36++)
				{
					Point point25 = (Point)VecEff.elementAt(num36);
					point25.f++;
					if (point25.f > 3)
					{
						VecEff.removeElement(point25);
						point25.f++;
						num36--;
					}
				}
				break;
			}
			case 29:
			case 84:
			{
				for (int num61 = 0; num61 < VecEff.size(); num61++)
				{
					Line line5 = (Line)VecEff.elementAt(num61);
					line5.update();
					if (f >= fRemove && test == 0)
					{
						VecEff.removeElement(line5);
						num61--;
					}
				}
				if (f < fRemove || test != 0)
				{
					break;
				}
				if (GameCanvas.timeNow - time >= timeRemove)
				{
					if (test == 0)
					{
						VecEff.removeAllElements();
					}
					removeEff();
				}
				else
				{
					fRemove = CRes.random(4, 6);
					f = 0;
					create_Star_Line_In(vMax, xline, yline);
				}
				break;
			}
			case 30:
			{
				for (int num3 = 0; num3 < VecEff.size(); num3++)
				{
					Point point7 = (Point)VecEff.elementAt(num3);
					if (point7.f < 5)
					{
						point7.update();
						point7.vx += point7.vx / 5;
						point7.vy += point7.vy / 5;
					}
					else if (test == 0)
					{
						VecEff.removeElement(point7);
						num3--;
					}
				}
				if (VecEff.size() == 0)
				{
					if (GameCanvas.timeNow - time > timeRemove)
					{
						removeEff();
					}
					else
					{
						create_Star_Point_In();
					}
				}
				break;
			}
			case 34:
			{
				for (int num67 = 0; num67 < VecEff.size(); num67++)
				{
					Point point50 = (Point)VecEff.elementAt(num67);
					point50.update();
					if (point50.f >= 3)
					{
						VecEff.removeElement(point50);
						num67--;
					}
				}
				if (f == 3 && objBeKillMain != null)
				{
					create_2Kiem_Lv4(180, objBeKillMain);
				}
				if (f == 6)
				{
					if (objKill != null)
					{
						indexSound = 9;
						if (objKill == GameScreen.player)
						{
							mSound.playSound(indexSound, mSound.volumeSound);
						}
						else
						{
							GameScreen.addSoundEff(indexSound);
						}
					}
					if (indexLan >= vecObjBeKill.size())
					{
						f = 56;
					}
					else
					{
						MainObject mainObject5 = null;
						if (indexLan < vecObjBeKill.size())
						{
							f = 0;
							do
							{
								Object_Effect_Skill object_Effect_Skill6 = (Object_Effect_Skill)vecObjBeKill.elementAt(indexLan);
								mainObject5 = MainObject.get_Item_Object(object_Effect_Skill6.ID, object_Effect_Skill6.tem);
								if (mainObject5 != null)
								{
									if (mainObject5.Action == 4)
									{
										mainObject5 = null;
									}
									else
									{
										objBeKillMain = mainObject5;
										if (objBeKillMain != null)
										{
											create_2Kiem_Lv4(0, objBeKillMain);
										}
									}
								}
								indexLan++;
							}
							while (mainObject5 == null && indexLan < vecObjBeKill.size());
						}
						if (indexLan >= vecObjBeKill.size() && mainObject5 == null)
						{
							f = 56;
						}
					}
				}
				if (f == fRemove - 1 && objKill != null)
				{
					switch (objKill.Direction)
					{
					case 1:
						objKill.Direction = 0;
						break;
					case 0:
						objKill.Direction = 1;
						break;
					case 2:
						objKill.Direction = 3;
						break;
					case 3:
						objKill.Direction = 2;
						break;
					}
					if (objKill.Action != 4 && objKill.Action != 3)
					{
						objKill.Action = 2;
						objKill.fplash = 6;
						objKill.frame = 5;
						objKill.weapon_frame = 6;
					}
					objKill.isTanHinh = false;
				}
				if (f < fRemove || VecEff.size() != 0)
				{
					break;
				}
				removeEff();
				if (objKill != null && objKill.Action == 2)
				{
					f = 0;
					objKill.Action = 0;
					if (objKill.isMainChar())
					{
						GameScreen.player.x = GameScreen.player.lastX;
						GameScreen.player.y = GameScreen.player.lastY;
						GameScreen.player.doResetLastXY();
						GameScreen.player.resetAction();
						GlobalService.gI().player_move((short)GameScreen.player.x, (short)GameScreen.player.y);
					}
				}
				break;
			}
			case 40:
			{
				if (f <= 4)
				{
					if (objBeKillMain != null && (toX != objBeKillMain.x || toY != objBeKillMain.y - objBeKillMain.hOne / 2) && objBeKillMain.Action != 4)
					{
						for (int num45 = 0; num45 < VecEff.size(); num45++)
						{
							Point point34 = (Point)VecEff.elementAt(num45);
							toX = objBeKillMain.x;
							toY = objBeKillMain.y - objBeKillMain.hOne / 2;
							point34.x = toX * 1000;
							point34.y = toY * 1000;
							point34.g = CRes.fixangle(point34.g + 5);
							point34.vx = CRes.sin(CRes.fixangle(point34.g)) * lT_Arc;
							point34.vy = CRes.cos(CRes.fixangle(point34.g)) * lT_Arc;
							int frameAngle = CRes.angle(-point34.vx, -point34.vy);
							point34.frame = setFrameAngle(frameAngle);
						}
					}
				}
				else
				{
					for (int num46 = 0; num46 < VecEff.size(); num46++)
					{
						Point point35 = (Point)VecEff.elementAt(num46);
						if (f % 3 == 0)
						{
							point35.vx /= 2;
							point35.vy /= 2;
						}
						if (f > 7)
						{
							VecEff.removeAllElements();
							GameScreen.addEffectEndKill(6, toX, toY);
						}
					}
				}
				for (int num47 = 0; num47 < VecSubEff.size(); num47++)
				{
					Point point36 = (Point)VecSubEff.elementAt(num47);
					point36.update();
					if (f > 16)
					{
						VecSubEff.removeAllElements();
						removeEff();
					}
				}
				break;
			}
			case 41:
			{
				updateAngleXP();
				for (int m = 0; m < VecEff.size(); m++)
				{
					Point point6 = (Point)VecEff.elementAt(m);
					point6.f++;
					if (point6.f > 4)
					{
						VecEff.removeElement(point6);
						m--;
					}
				}
				if (f >= fRemove && VecEff.size() == 0)
				{
					removeEff();
				}
				break;
			}
			case 42:
			{
				if (objKill != null)
				{
					x = objKill.x;
					y = objKill.y;
				}
				if (f == 0 && objKill != null)
				{
					GameScreen.addEffectKill(43, objKill.ID, objKill.typeObject, vecObjBeKill);
				}
				if (f >= fRemove)
				{
					removeEff();
				}
				if (f == fRemove / 2)
				{
					GameScreen.addEffectEndKill(21, x, y);
				}
				if (f >= fRemove / 2)
				{
					break;
				}
				for (int num41 = 0; num41 < VecEff.size(); num41++)
				{
					Point point29 = (Point)VecEff.elementAt(num41);
					if (CRes.random(3) == 0)
					{
						if (point29.fRe == 1)
						{
							point29.fRe = 0;
							continue;
						}
						point29.fRe = 1;
						point29.frame = CRes.random(4);
					}
				}
				break;
			}
			case 43:
			{
				if (objKill != null)
				{
					x = objKill.x;
					y = objKill.y;
				}
				if (f >= fRemove)
				{
					removeEff();
				}
				for (int num51 = 0; num51 < VecEff.size(); num51++)
				{
					Point point38 = (Point)VecEff.elementAt(num51);
					if (CRes.random(3) == 0)
					{
						if (point38.fRe == 1)
						{
							point38.fRe = 0;
							continue;
						}
						point38.fRe = 1;
						point38.frame = CRes.random(4);
					}
				}
				break;
			}
			case 46:
				if (objBeKillMain != null)
				{
					if ((CRes.abs(toX - objBeKillMain.x) > 2 || CRes.abs(toY - objBeKillMain.y) > 2) && CRes.random(3) == 0)
					{
						GameScreen.addEffectEndKill(24, toX, toY - 5);
					}
					toX = objBeKillMain.x;
					toY = objBeKillMain.y;
				}
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 47:
			case 112:
			{
				for (int num6 = 0; num6 < VecEff.size(); num6++)
				{
					Point point10 = (Point)VecEff.elementAt(num6);
					if (f == point10.fRe)
					{
						GameScreen.addEffectEndKill(26, point10.x / 1000, point10.y / 1000 - 5);
					}
				}
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			}
			case 49:
			{
				for (int num69 = 0; num69 < VecEff.size(); num69++)
				{
					Point point52 = (Point)VecEff.elementAt(num69);
					point52.f++;
					if (point52.f >= 5)
					{
						VecEff.removeElement(point52);
						num69--;
					}
				}
				if (f < fRemove)
				{
					Point point53 = new Point();
					point53.x = x;
					point53.y = y;
					VecEff.addElement(point53);
				}
				else if (VecEff.size() == 0 && f >= fRemove + 6)
				{
					removeEff();
				}
				break;
			}
			case 125:
			case 126:
			{
				x1000 = CRes.cos(angle) * R / 1024 + x;
				y1000 = CRes.sin(angle) * R / 1024 + y;
				Point point13 = new Point();
				point13.x = x1000;
				point13.y = y1000;
				VecEff.addElement(point13);
				angle += 20;
				if (angle >= 359)
				{
					size1--;
					angle = 359;
				}
				if (size1 <= 0)
				{
					removeEff();
					for (int num13 = 0; num13 < vecObjBeKill.size(); num13++)
					{
						Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)vecObjBeKill.elementAt(num13);
						if (object_Effect_Skill2 != null)
						{
							MainObject mainObject2 = MainObject.get_Item_Object(object_Effect_Skill2.ID, object_Effect_Skill2.tem);
							GameScreen.addEffectEndKill(36, mainObject2.x, mainObject2.y);
							GameScreen.addEffectEndKill(9, mainObject2.x, mainObject2.y);
						}
					}
				}
				int num14 = 2;
				if (objBeKillMain != null && objKill != null)
				{
					objKill.Direction = setDirection(objKill, objBeKillMain);
					num14 = objKill.Direction;
				}
				if (num14 == 2 || num14 == 3)
				{
					vY1000 = 1;
					vX1000 = 0;
				}
				else
				{
					vY1000 = 0;
					vX1000 = 1;
				}
				int num15 = 320;
				if (num15 < GameCanvas.h)
				{
					num15 = GameCanvas.h;
				}
				if (num15 < GameCanvas.w)
				{
					num15 = GameCanvas.w;
				}
				if (angle > 60 && angle < 120)
				{
					R = y + CRes.sin(60) * num15 / 1000;
				}
				else
				{
					R = x + CRes.cos(0) * num15 / 1000;
				}
				for (int num16 = 0; num16 < VecEff.size(); num16++)
				{
					Point point14 = (Point)VecEff.elementAt(num16);
					point14.f++;
					if (point14.f >= 4)
					{
						VecEff.removeElement(point14);
						num16--;
					}
				}
				if (angle > 0 && angle < 90)
				{
					objKill.Direction = 3;
				}
				else
				{
					objKill.Direction = 2;
				}
				break;
			}
			case 50:
				if (f >= 6)
				{
					removeEff();
				}
				if (f == -1 || f >= 6)
				{
					return;
				}
				if (objKill != null)
				{
					if (f < 3)
					{
						objKill.x += x1000;
						objKill.y += y1000;
					}
					else if (f < 6)
					{
						objKill.x -= x1000;
						objKill.y -= y1000;
					}
				}
				break;
			case 106:
			{
				x1000 = CRes.cos(angle) * R / 1024 + x;
				y1000 = CRes.sin(angle) * R / 1024 + y;
				Point point56 = new Point();
				point56.x = x1000;
				point56.y = y1000;
				VecEff.addElement(point56);
				angle += 20;
				if (angle >= 180)
				{
					size1--;
					angle = 180;
				}
				if (size1 <= 0)
				{
					removeEff();
				}
				int num71 = 2;
				if (objBeKillMain != null && objKill != null)
				{
					objKill.Direction = setDirection(objKill, objBeKillMain);
					num71 = objKill.Direction;
				}
				if (num71 == 2 || num71 == 3)
				{
					vY1000 = 1;
					vX1000 = 0;
				}
				else
				{
					vY1000 = 0;
					vX1000 = 1;
				}
				int num72 = 320;
				if (num72 < GameCanvas.h)
				{
					num72 = GameCanvas.h;
				}
				if (num72 < GameCanvas.w)
				{
					num72 = GameCanvas.w;
				}
				if (angle > 60 && angle < 120)
				{
					R = y + CRes.sin(60) * num72 / 1000;
				}
				else
				{
					R = x + CRes.cos(0) * num72 / 1000;
				}
				for (int num73 = 0; num73 < VecEff.size(); num73++)
				{
					Point point57 = (Point)VecEff.elementAt(num73);
					point57.f++;
					if (point57.f >= 4)
					{
						VecEff.removeElement(point57);
						num73--;
					}
				}
				if (angle > 0 && angle < 90)
				{
					objKill.Direction = 3;
				}
				else
				{
					objKill.Direction = 2;
				}
				break;
			}
			case 51:
			case 105:
			{
				if (f >= fRemove && VecEff.size() == 0)
				{
					removeEff();
				}
				if (f < fRemove)
				{
					if (f == 8)
					{
						int num32 = 2;
						if (objBeKillMain != null && objKill != null)
						{
							objKill.Direction = setDirection(objKill, objBeKillMain);
							num32 = objKill.Direction;
						}
						if (num32 == 2 || num32 == 3)
						{
							vY1000 = 1;
							vX1000 = 0;
						}
						else
						{
							vY1000 = 0;
							vX1000 = 1;
						}
						if (objBeKillMain != null && objKill != null)
						{
							int a2 = CRes.angle(objBeKillMain.x - objKill.x, objBeKillMain.y - objKill.y);
							int num33 = 320;
							if (num33 < GameCanvas.h)
							{
								num33 = GameCanvas.h;
							}
							if (num33 < GameCanvas.w)
							{
								num33 = GameCanvas.w;
							}
							x1000 = x + CRes.cos(a2) * num33 / 1000;
							y1000 = y + CRes.sin(a2) * num33 / 1000;
							toX = objBeKillMain.x;
							toY = objBeKillMain.y - objBeKillMain.hOne / 2;
						}
					}
					if (f > 8 && f % 3 == 2)
					{
						Point point21 = new Point();
						point21.x = toX + CRes.random_Am_0(5);
						point21.y = toY + CRes.random_Am_0(5);
						VecEff.addElement(point21);
					}
				}
				for (int num34 = 0; num34 < VecEff.size(); num34++)
				{
					Point point22 = (Point)VecEff.elementAt(num34);
					point22.f++;
					if (point22.f >= 4)
					{
						VecEff.removeElement(point22);
						num34--;
					}
				}
				break;
			}
			case 52:
			case 54:
			{
				if (typeEffect == 54)
				{
					if (f == 0)
					{
						GameScreen.addEffectEndKill(3, toX, toY - 10);
					}
				}
				else if (typeEffect == 52 && f == 0)
				{
					GameScreen.addEffectEndKill(14, toX, toY);
				}
				if (f < fRemove && objBeKillMain != null)
				{
					if ((CRes.abs(toX - objBeKillMain.x) > 2 || CRes.abs(toY - objBeKillMain.y) > 2) && CRes.random(3) == 0)
					{
						Point point46 = new Point();
						point46.x = toX;
						point46.y = toY - 5;
						VecEff.addElement(point46);
					}
					toX = objBeKillMain.x;
					toY = objBeKillMain.y;
				}
				if (f >= fRemove && VecEff.size() == 0)
				{
					removeEff();
				}
				for (int num60 = 0; num60 < VecEff.size(); num60++)
				{
					Point point47 = (Point)VecEff.elementAt(num60);
					point47.f++;
					if (point47.f / 2 >= 4)
					{
						VecEff.removeElement(point47);
						num60--;
					}
				}
				break;
			}
			case 53:
			case 64:
			case 71:
			case 75:
			case 78:
			case 104:
			{
				for (int num59 = 0; num59 < VecEff.size(); num59++)
				{
					Point point45 = (Point)VecEff.elementAt(num59);
					if (f == 1)
					{
						LoadMap.timeVibrateScreen = 103;
						if (typeEffect == 75)
						{
							GameScreen.addEffectEndKill(15, point45.x, point45.y);
						}
						else
						{
							GameScreen.addEffectEndKill(9, point45.x, point45.y);
						}
						if (typeEffect == 64)
						{
							GameScreen.addEffectEndKill(15, point45.x, point45.y);
							GameScreen.addEffectEndKill(28, point45.x, point45.y - 2);
						}
						else if (typeEffect == 53 || typeEffect == 78 || typeEffect == 104)
						{
							GameScreen.addEffectEndKill(25, point45.x, point45.y - 2);
						}
					}
					point45.f++;
				}
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			}
			case 55:
			{
				for (int num25 = 0; num25 < VecEff.size(); num25++)
				{
					Line line3 = (Line)VecEff.elementAt(num25);
					line3.update();
					if (line3.f > line3.fRe)
					{
						VecEff.removeElement(line3);
						num25--;
					}
				}
				if (f >= fRemove)
				{
					if (VecEff.size() == 0)
					{
						removeEff();
					}
					break;
				}
				int num26 = 20;
				if (objBeKillMain != null && !objBeKillMain.isRemove && !objBeKillMain.isStop && objBeKillMain.Action != 4)
				{
					toX = objBeKillMain.x;
					toY = objBeKillMain.y - objBeKillMain.hOne / 2;
					num26 = objBeKillMain.hOne / 2;
				}
				int num27 = CRes.random(2, 4);
				for (int num28 = 0; num28 < num27; num28++)
				{
					int num29 = CRes.random(10, 24);
					int num30 = CRes.random_Am_0(15);
					int num31 = CRes.random_Am(6, 12);
					Line line4 = new Line();
					if (Direction == 2 || Direction == 3)
					{
						line4.x0 = toX + num30;
						line4.x1 = line4.x0 + ((num30 <= 0) ? (-num29) : num29);
						line4.y0 = (line4.y1 = toY + CRes.random_Am_0(num26 + 10));
						line4.vx = num31;
					}
					else
					{
						line4.y0 = toY + num30;
						line4.y1 = line4.y0 + ((num30 <= 0) ? (-num29) : num29);
						line4.x0 = (line4.x1 = toX + CRes.random_Am_0(num26 + 10));
						line4.vy = num31;
					}
					line4.fRe = CRes.random(2, 5);
					line4.is2Line = CRes.random(5) == 0;
					line4.idColor = CRes.random(3);
					VecEff.addElement(line4);
				}
				break;
			}
			case 56:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 57:
			case 70:
			{
				if (objKill != null && objKill.Action != 4)
				{
					objKill.Action = 2;
					objKill.vx = 0;
					objKill.vy = 0;
				}
				for (int num74 = 0; num74 < VecEff.size(); num74++)
				{
					Line line6 = (Line)VecEff.elementAt(num74);
					line6.update();
					line6.update();
					line6.vx += line6.vx / 5;
					line6.vy += line6.vy / 5;
					if (line6.f >= 6 && test == 0)
					{
						VecEff.removeAllElements();
						num74--;
					}
				}
				if (VecEff.size() == 0)
				{
					if (GameCanvas.timeNow - time > timeRemove)
					{
						removeEff();
					}
					else if (typeEffect == 57)
					{
						create_Buff_Point_In();
					}
					else if (typeEffect == 70)
					{
						create_Mon_Buff();
					}
				}
				break;
			}
			case 58:
			{
				if (f < fRemove)
				{
					if (f % 3 == 1)
					{
						int num37 = MainScreen.cameraMain.yCam + (y - MainScreen.cameraMain.yCam) % 30 - 30;
						for (int num38 = 0; num38 < 2; num38++)
						{
							Point point26 = new Point();
							point26.x = x;
							point26.y = num37 + num38 * 3;
							point26.vy = 30;
							VecEff.addElement(point26);
						}
					}
					if (f >= fRemove - 3 && objKill != null)
					{
						objKill.isTanHinh = !objKill.isTanHinh;
					}
				}
				else if (objKill != null && objKill.isTanHinh)
				{
					objKill.isTanHinh = false;
				}
				for (int num39 = 0; num39 < VecEff.size(); num39++)
				{
					Point point27 = (Point)VecEff.elementAt(num39);
					point27.update();
					if (point27.y > y)
					{
						VecEff.removeElement(point27);
						num39--;
					}
				}
				if (f >= fRemove && VecEff.size() == 0)
				{
					if (objKill != null)
					{
						objKill.isTanHinh = false;
					}
					removeEff();
				}
				break;
			}
			case 60:
				if (f == 0)
				{
					for (int num35 = 0; num35 < VecEff.size(); num35++)
					{
						Point point23 = (Point)VecEff.elementAt(num35);
						GameScreen.addEffectEndKill(9, point23.x, point23.y);
						GameScreen.addEffectEndKill(25, point23.x, point23.y - 2);
					}
				}
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 61:
			case 77:
			{
				for (int num52 = 0; num52 < VecEff.size(); num52++)
				{
					Point point39 = (Point)VecEff.elementAt(num52);
					for (int num53 = 0; num53 < point39.vecEffPoint.size(); num53++)
					{
						Point point40 = (Point)point39.vecEffPoint.elementAt(num53);
						point40.x += point39.vx;
					}
					if (f == point39.f)
					{
						LoadMap.timeVibrateScreen = 105;
						if (objKill != null)
						{
							if (objKill == GameScreen.player)
							{
								mSound.playSound(32, mSound.volumeSound);
							}
							else
							{
								GameScreen.addSoundEff(32);
							}
						}
						GameScreen.addEffectEndKill(40, point39.x, point39.y + point39.vy * f / 1000 - 4 + 10);
						if (typeEffect == 61)
						{
							GameScreen.addEffectEndKill(27, point39.x + 3, point39.y + point39.vy * f / 1000 + 10);
							GameScreen.addEffectEndKill(15, point39.x, point39.y + point39.vy * f / 1000);
							GameScreen.addEffectEndKill(0, point39.x, point39.y + point39.vy * f / 1000);
						}
						else if (typeEffect == 77)
						{
							mSound.playSound(32, mSound.volumeSound);
							GameScreen.addEffectEndKill(30, point39.x + 3, point39.y + point39.vy * f / 1000 + 10);
							GameScreen.addEffectEndKill(14, point39.x, point39.y + point39.vy * f / 1000);
							GameScreen.addEffectEndKill(0, point39.x, point39.y + point39.vy * f / 1000);
						}
					}
					else if (f < point39.f)
					{
						point39.x += point39.vx;
						flag2 = false;
					}
				}
				if (flag2)
				{
					removeEff();
				}
				break;
			}
			case 62:
			{
				for (int j = 0; j < VecEff.size(); j++)
				{
					Point point3 = (Point)VecEff.elementAt(j);
					point3.update();
					if (point3.f >= point3.fRe)
					{
						VecEff.removeElement(point3);
						j--;
					}
				}
				if (f >= fRemove && VecEff.size() == 0)
				{
					removeEff();
				}
				if (f % 3 == 0 && f < fRemove)
				{
					int num = x;
					int num2 = y;
					switch (Direction)
					{
					case 1:
						num2 -= 20;
						break;
					case 0:
						num2 += 20;
						break;
					case 2:
						num -= 20;
						break;
					case 3:
						num += 20;
						break;
					}
					GameScreen.addEffectEndKill(13, num, num2);
					create_Sung_BaoDan();
				}
				if (f % 5 == 4 && f < fRemove && objBeKillMain != null && !objBeKillMain.isStop && !objBeKillMain.isRemove && MainObject.getDistance(objBeKillMain.x, objBeKillMain.y - objBeKillMain.hOne / 2, toX, toY) <= 30)
				{
					GameScreen.addEffectEndKill(12, xEff, yEff + objBeKillMain.hOne / 4);
				}
				break;
			}
			case 63:
			{
				for (int num48 = 0; num48 < VecEff.size(); num48++)
				{
					Point point37 = (Point)VecEff.elementAt(num48);
					point37.update();
					if (point37.f >= point37.fRe)
					{
						VecEff.removeElement(point37);
						num48--;
					}
				}
				if (f >= fRemove && VecEff.size() == 0)
				{
					removeEff();
				}
				if (f < fRemove)
				{
					if (objBeKillMain == null)
					{
						if (f < fRemove)
						{
							f = fRemove;
						}
					}
					else
					{
						int num49 = x;
						int num50 = y;
						switch (Direction)
						{
						case 1:
							num50 -= 20;
							break;
						case 0:
							num50 += 20;
							break;
						case 2:
							num49 -= 20;
							break;
						case 3:
							num49 += 20;
							break;
						}
						if (f % 3 == 0)
						{
							GameScreen.addEffectEndKill(13, num49, num50);
						}
						create_Sung_DAY_DAN(toX, toY);
					}
				}
				if (f % 5 == 4 && f < fRemove && objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(7, toX, toY + objBeKillMain.hOne / 4);
				}
				break;
			}
			case 73:
			{
				for (int num17 = 0; num17 < VecSubEff.size(); num17++)
				{
					Point point15 = (Point)VecSubEff.elementAt(num17);
					point15.f++;
					if (point15.f / 2 > 3)
					{
						VecSubEff.removeElement(point15);
						num17--;
					}
				}
				for (int num18 = 0; num18 < VecEff.size(); num18++)
				{
					Point point16 = (Point)VecEff.elementAt(num18);
					point16.update();
					if (point16.f >= point16.fRe)
					{
						GameScreen.addEffectEndKill(12, point16.x, point16.y + 10);
						VecEff.removeElement(point16);
						num18--;
					}
					else if (point16.f > 1)
					{
						Point point17 = new Point();
						point17.x = point16.x - point16.vx;
						point17.y = point16.y - point16.vy;
						VecSubEff.addElement(point17);
					}
				}
				if (f >= fRemove)
				{
					if (VecEff.size() == 0 && VecSubEff.size() == 0)
					{
						removeEff();
					}
				}
				else
				{
					if (f % 4 != 0 || indexLan >= vecObjBeKill.size())
					{
						break;
					}
					if (indexLan >= vecObjBeKill.size())
					{
						f = fRemove;
						break;
					}
					MainObject mainObject3 = null;
					if (indexLan < vecObjBeKill.size())
					{
						f = 0;
						do
						{
							Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)vecObjBeKill.elementAt(indexLan);
							if (object_Effect_Skill3 != null)
							{
								mainObject3 = MainObject.get_Item_Object(object_Effect_Skill3.ID, object_Effect_Skill3.tem);
								if (mainObject3 != null)
								{
									if (mainObject3.Action == 4)
									{
										mainObject3 = null;
									}
									else
									{
										if (objKill != null)
										{
											Direction = setDirection(objKill, mainObject3);
											objKill.Direction = Direction;
											create_Sung_DAY_DAN(mainObject3.x, mainObject3.y - mainObject3.hOne / 2);
											objKill.fplash = 11;
										}
										int num19 = x;
										int num20 = y;
										switch (Direction)
										{
										case 1:
											num20 -= 20;
											break;
										case 0:
											num20 += 20;
											break;
										case 2:
											num19 -= 20;
											break;
										case 3:
											num19 += 20;
											break;
										}
										GameScreen.addEffectEndKill(13, num19, num20);
									}
								}
							}
							indexLan++;
						}
						while (mainObject3 == null && indexLan < vecObjBeKill.size());
					}
					if (indexLan >= vecObjBeKill.size() && mainObject3 == null)
					{
						f = fRemove;
					}
				}
				break;
			}
			case 66:
			{
				for (int num5 = 0; num5 < vecObjBeKill.size(); num5++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjBeKill.elementAt(num5);
					MainObject mainObject = MainObject.get_Item_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
					if (mainObject != null)
					{
						if (objKill != null)
						{
							GameScreen.addEffectKill(10, objKill.ID, objKill.typeObject, object_Effect_Skill.ID, object_Effect_Skill.tem, object_Effect_Skill.hpShow, object_Effect_Skill.hpLast);
						}
						GameScreen.addEffectEndKill(0, mainObject.x, mainObject.y + 5);
					}
				}
				removeEff();
				break;
			}
			case 67:
				if (f > 7 && f >= fRemove)
				{
					removeEff();
				}
				break;
			case 68:
				if (f >= fRemove)
				{
					removeEff();
				}
				else
				{
					if (objBeKillMain == null || objBeKillMain.isStop || objBeKillMain.isRemove)
					{
						break;
					}
					if (objBeKillMain.Action == 4)
					{
						f = fRemove;
						break;
					}
					x = objBeKillMain.x;
					if (subType == 0)
					{
						y = objBeKillMain.y - objBeKillMain.hOne / 2;
					}
					else
					{
						y = objBeKillMain.y - objBeKillMain.hOne - 8;
					}
				}
				break;
			case 69:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 72:
			case 74:
			{
				for (int num68 = 0; num68 < VecEff.size(); num68++)
				{
					Point_Focus point_Focus = (Point_Focus)VecEff.elementAt(num68);
					point_Focus.update_Vx_Vy();
					if (point_Focus.f >= point_Focus.fRe)
					{
						GameScreen.addEffectEndKill(12, point_Focus.x, point_Focus.y + 10);
						VecEff.removeElement(point_Focus);
						num68--;
					}
				}
				if (VecEff.size() == 0 && f >= fRemove)
				{
					removeEff();
				}
				break;
			}
			case 76:
			{
				for (int num58 = 0; num58 < VecEff.size(); num58++)
				{
					Point point44 = (Point)VecEff.elementAt(num58);
					point44.x += point44.vx;
					point44.y += point44.vy;
					int tile3 = GameCanvas.loadmap.getTile(point44.x / 1000, point44.y / 1000);
					if (tile3 == -1 || tile3 == 1 || !MainEffect.isInScreen(point44.x / 1000, point44.y / 1000, fraImgEff.frameWidth, fraImgEff.frameHeight))
					{
						VecEff.removeElement(point44);
						num58--;
					}
				}
				if (VecEff.size() == 0 || f >= fRemove)
				{
					removeEff();
				}
				break;
			}
			case 79:
				if (f == 0)
				{
					for (int num54 = 0; num54 < vecObjBeKill.size(); num54++)
					{
						Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)vecObjBeKill.elementAt(num54);
						if (object_Effect_Skill4 == null)
						{
							vecObjBeKill.removeElement(object_Effect_Skill4);
							num54--;
						}
						else
						{
							GameScreen.addEffectKill(12, objKill.ID, objKill.typeObject, object_Effect_Skill4.ID, object_Effect_Skill4.tem, object_Effect_Skill4.hpShow, object_Effect_Skill4.hpLast);
						}
					}
				}
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 80:
				if (objBeKillMain != null && !objBeKillMain.isStop && !objBeKillMain.isRemove)
				{
					if (f < fRemove)
					{
						if (f < 10)
						{
							x = objBeKillMain.x;
							y = objBeKillMain.y - 70;
							break;
						}
						vy += 2;
						if (f > 12)
						{
							objBeKillMain.Action = 3;
						}
						objBeKillMain.vx = 0;
						objBeKillMain.vy = 0;
					}
					else
					{
						objBeKillMain.Action = 4;
						objBeKillMain.hp = 0;
						GameScreen.addEffectEndKill(11, objBeKillMain.x, objBeKillMain.y);
						removeEff();
					}
				}
				else
				{
					removeEff();
				}
				break;
			case 83:
			{
				updateAngleHut_Mp_Hp();
				for (int num24 = 0; num24 < VecEff.size(); num24++)
				{
					Point point20 = (Point)VecEff.elementAt(num24);
					point20.f++;
					if (point20.f > 4)
					{
						VecEff.removeElement(point20);
						num24--;
					}
				}
				if (f >= fRemove && VecEff.size() == 0)
				{
					removeEff();
				}
				break;
			}
			case 85:
			{
				for (int n = 0; n < VecEff.size(); n++)
				{
					Line line2 = (Line)VecEff.elementAt(n);
					line2.update();
					if (line2.f >= line2.fRe)
					{
						VecEff.removeElement(line2);
						n--;
					}
				}
				if (objBeKillMain != null && !objBeKillMain.isRemove && objBeKillMain.Action != 4 && !objBeKillMain.isStop)
				{
					x1000 = objBeKillMain.x;
					y1000 = objBeKillMain.y;
					if (timeRemove > 0 && GameCanvas.timeNow - time >= timeRemove)
					{
						removeEff();
					}
					else if (GameCanvas.gameTick % 2 == 0)
					{
						create_Line_NHANBAN_LV2();
					}
				}
				else if (f > 20)
				{
					removeEff();
				}
				break;
			}
			case 87:
				if (objBeKillMain != null && !objBeKillMain.isRemove && objBeKillMain.Action != 4 && !objBeKillMain.isStop)
				{
					x = objBeKillMain.x;
					y = objBeKillMain.y - objBeKillMain.hOne / 2;
					if (timeRemove > 0 && GameCanvas.timeNow - time >= timeRemove)
					{
						removeEff();
					}
				}
				else if (f > 20)
				{
					removeEff();
				}
				break;
			case 88:
			{
				if (f < fRemove)
				{
					updateAngleXP();
					frame = setFrameAngle(gocT_Arc);
				}
				if (VecEff.size() == 0 && f > fRemove)
				{
					removeEff();
				}
				for (int num66 = 0; num66 < VecEff.size(); num66++)
				{
					Point point49 = (Point)VecEff.elementAt(num66);
					point49.f++;
					if (point49.f / 2 > 3)
					{
						VecEff.removeElement(point49);
						num66--;
					}
				}
				if (f == fRemove)
				{
					GameScreen.addEffectEndKill(36, x, y - 15);
					GameScreen.addEffectEndKill(14, x, y - 15);
				}
				break;
			}
			case 65:
			{
				for (int num65 = 0; num65 < vecObjBeKill.size(); num65++)
				{
					Object_Effect_Skill object_Effect_Skill5 = (Object_Effect_Skill)vecObjBeKill.elementAt(num65);
					MainObject mainObject4 = MainObject.get_Item_Object(object_Effect_Skill5.ID, object_Effect_Skill5.tem);
					if (mainObject4 != null && objKill != null)
					{
						GameScreen.addEffectKill(88, objKill.ID, objKill.typeObject, object_Effect_Skill5.ID, object_Effect_Skill5.tem, object_Effect_Skill5.hpShow, object_Effect_Skill5.hpLast);
					}
				}
				removeEff();
				break;
			}
			case 89:
			{
				if (f < fRemove)
				{
					updateAngleXP();
					frame = setFrameAngle(gocT_Arc);
				}
				if (VecEff.size() == 0 && f > fRemove)
				{
					isStop = true;
					isRemove = true;
				}
				for (int num57 = 0; num57 < VecEff.size(); num57++)
				{
					Point point43 = (Point)VecEff.elementAt(num57);
					point43.f++;
					if (point43.f / 2 > 3)
					{
						VecEff.removeElement(point43);
						num57--;
					}
				}
				break;
			}
			case 92:
			{
				if (f < fRemove)
				{
					updateAngleXP();
					frame = setFrameAngle(gocT_Arc);
				}
				if (VecEff.size() == 0 && f > fRemove)
				{
					isStop = true;
					isRemove = true;
				}
				for (int num44 = 0; num44 < VecEff.size(); num44++)
				{
					Point point33 = (Point)VecEff.elementAt(num44);
					point33.f++;
					if (point33.f / 2 > 3)
					{
						VecEff.removeElement(point33);
						num44--;
					}
				}
				break;
			}
			case 90:
				update_Nova_Effect();
				break;
			case 91:
				update_Nova_Effect();
				break;
			case 93:
				update_Boss_De1();
				break;
			case 102:
				if (objBeKillMain != null)
				{
					x = objBeKillMain.x;
					y = objBeKillMain.y - 25;
				}
				frStun++;
				if (frStun > frameStun.Length - 1)
				{
					frStun = 0;
				}
				if (!objBeKillMain.isStun || objBeKillMain == null || (objBeKillMain != null && objBeKillMain.isRemove))
				{
					isRemove = true;
				}
				break;
			case 103:
				if (objBeKillMain != null)
				{
					x = objBeKillMain.x;
					y = objBeKillMain.y;
				}
				if (timedelay >= 0)
				{
					timedelay--;
				}
				if (timedelay <= 0)
				{
					ysai = 10;
					for (int num7 = 0; num7 < arr_R.Length; num7++)
					{
						ref sbyte reference = ref arr_R[num7];
						reference += (sbyte)(r / 2);
						arr_radian[num7] += 5;
						if (arr_radian[num7] >= 360)
						{
							arr_radian[num7] = 0;
						}
					}
					r /= 2;
					if (r <= 0)
					{
						r = 0;
					}
				}
				if (!objBeKillMain.isnoBoss84 || objBeKillMain == null || objBeKillMain.hp <= 0 || (objBeKillMain != null && objBeKillMain.isRemove))
				{
					isRemove = true;
				}
				break;
			case 107:
			{
				for (int k = 0; k < VecEff.size(); k++)
				{
					Line line = (Line)VecEff.elementAt(k);
					line.update();
					if (f >= fRemove && test == 0)
					{
						VecEff.removeElement(line);
						k--;
					}
				}
				create_Star_Line_In(vMax, xline, yline);
				if (MainObject.getDistance(objBeKillMain.x, objBeKillMain.y, GameScreen.player.x, GameScreen.player.y) <= 240)
				{
					LoadMap.timeVibrateScreen = 3;
				}
				if (!objBeKillMain.isno || objBeKillMain == null || objBeKillMain.hp <= 0 || (objBeKillMain != null && objBeKillMain.isRemove))
				{
					isRemove = true;
				}
				break;
			}
			case 101:
				frSleep++;
				if (frSleep > frameSleep.Length - 1)
				{
					frSleep = 0;
				}
				if (delay >= 0)
				{
					delay--;
				}
				if (delay < 0)
				{
					ispaintsleep = true;
				}
				if (!objBeKillMain.isSleep || objBeKillMain == null || objBeKillMain.hp <= 0 || (objBeKillMain != null && objBeKillMain.isRemove))
				{
					isRemove = true;
				}
				break;
			case 94:
				if (nFrame == null)
				{
					nFrame = new sbyte[12]
					{
						0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
						3, 3
					};
				}
				if (f > nFrame.Length - 1)
				{
					f = nFrame.Length - 6;
				}
				update_Boss_De2();
				break;
			case 95:
				if (f >= fRemove)
				{
					removeEff();
				}
				break;
			case 96:
			{
				if (f < fRemove)
				{
					updateAngleXP();
					frame = setFrameAngle(gocT_Arc);
				}
				if (VecEff.size() == 0 && f > fRemove)
				{
					removeEff();
				}
				for (int num55 = 0; num55 < VecEff.size(); num55++)
				{
					Point point41 = (Point)VecEff.elementAt(num55);
					point41.f++;
					if (point41.f / 2 > 3)
					{
						VecEff.removeElement(point41);
						num55--;
					}
				}
				if (f == fRemove)
				{
					GameScreen.addEffectEndKill(45, objBeKillMain.x, objBeKillMain.y - 20);
				}
				break;
			}
			case 97:
			{
				if (f >= fRemove && VecEff.size() == 0)
				{
					removeEff();
				}
				if (f < fRemove)
				{
					if (f == 8)
					{
						int num21 = 2;
						if (objBeKillMain != null && objKill != null)
						{
							objKill.Direction = setDirection(objKill, objBeKillMain);
							num21 = objKill.Direction;
						}
						if (num21 == 2 || num21 == 3)
						{
							vY1000 = 1;
							vX1000 = 0;
						}
						else
						{
							vY1000 = 0;
							vX1000 = 1;
						}
						if (objBeKillMain != null && objKill != null)
						{
							int a = CRes.angle(objBeKillMain.x - objKill.x, objBeKillMain.y - (objKill.y - objKill.hOne / 2 + 10));
							int num22 = 320;
							if (num22 < GameCanvas.h)
							{
								num22 = GameCanvas.h;
							}
							if (num22 < GameCanvas.w)
							{
								num22 = GameCanvas.w;
							}
							x1000 = x + CRes.cos(a) * num22 / 1000;
							y1000 = y + CRes.sin(a) * num22 / 1000;
							toX = objBeKillMain.x;
							toY = objBeKillMain.y - objBeKillMain.hOne / 2;
							xdichTower = objBeKillMain.x;
							ydichTower = objBeKillMain.y;
							GameScreen.addEffectEndKill(0, xdichTower, ydichTower - objBeKillMain.hOne / 2);
							GameScreen.addEffectEndKill(26, xdichTower, ydichTower);
						}
					}
					if (f > 8 && f % 3 == 2)
					{
						Point point18 = new Point();
						point18.x = toX + CRes.random_Am_0(5);
						point18.y = toY + CRes.random_Am_0(5);
						VecEff.addElement(point18);
					}
				}
				for (int num23 = 0; num23 < VecEff.size(); num23++)
				{
					Point point19 = (Point)VecEff.elementAt(num23);
					point19.f++;
					if (point19.f >= 4)
					{
						VecEff.removeElement(point19);
						num23--;
					}
				}
				break;
			}
			case 98:
			{
				if (f < fRemove && f > 1)
				{
					Point point8 = new Point();
					point8.x = x - vx;
					point8.y = y - vy;
					VecEff.addElement(point8);
				}
				else if (VecEff.size() == 0 && f >= fRemove)
				{
					removeEff();
				}
				if (f == fRemove && objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(26, toX, toY + objBeKillMain.hOne / 2);
					GameScreen.addEffectEndKill(14, toX, toY + objBeKillMain.hOne / 2);
					GameScreen.addEffectEndKill(30, toX, toY + objBeKillMain.hOne / 2 + 10);
				}
				for (int num4 = 0; num4 < VecEff.size(); num4++)
				{
					Point point9 = (Point)VecEff.elementAt(num4);
					point9.f++;
					if (point9.f / 2 > 3)
					{
						VecEff.removeElement(point9);
						num4--;
					}
				}
				break;
			}
			case 99:
			{
				if (f < fRemove && f > 1)
				{
					Point point = new Point();
					point.x = x - vx;
					point.y = y - vy;
					VecEff.addElement(point);
				}
				else if (VecEff.size() == 0 && f >= fRemove)
				{
					removeEff();
				}
				if (f == fRemove && objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(48, toX, toY + objBeKillMain.hOne / 4);
				}
				for (int i = 0; i < VecEff.size(); i++)
				{
					Point point2 = (Point)VecEff.elementAt(i);
					point2.f++;
					if (point2.f / 2 > 3)
					{
						VecEff.removeElement(point2);
						i--;
					}
				}
				break;
			}
			case 100:
				update_Boss_Medusa2();
				break;
			case 2:
			case 3:
			case 4:
			case 5:
			case 7:
			case 8:
			case 9:
			case 13:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 24:
			case 32:
			case 33:
			case 35:
			case 36:
			case 37:
			case 39:
			case 44:
			case 45:
			case 48:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
			case 121:
			case 122:
			case 123:
				break;
			}
		}
		catch (Exception)
		{
			mSystem.outloi("Loi update Eff " + typeEffect + "  f=" + f);
			removeEff();
		}
		base.update();
		if (f > 200 && timeRemove == 0)
		{
			removeEff();
		}
	}

	private void SetAddSoundTimeAdd()
	{
		if (objKill == null)
		{
			return;
		}
		if (typeEffect == 27)
		{
			indexSound = 9;
			if (objKill == GameScreen.player)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(indexSound);
			}
		}
		else if (typeEffect == 51)
		{
			indexSound = 19;
			if (objKill == GameScreen.player)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(indexSound);
			}
		}
		else if (typeEffect == 125 || typeEffect == 126 || typeEffect == 97 || typeEffect == 106 || typeEffect == 105)
		{
			indexSound = 13;
			if (objKill == GameScreen.player)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(indexSound);
			}
		}
		else if (typeEffect == 62)
		{
			indexSound = 20;
			if (objKill == GameScreen.player)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(indexSound);
			}
		}
	}

	public void endUpdate()
	{
	}

	public static int setDirection(MainObject idFrom, MainObject idTo)
	{
		int num = idFrom.x - idTo.x;
		int num2 = idFrom.y - idTo.y;
		if (CRes.abs(num) > CRes.abs(num2))
		{
			if (num > 0)
			{
				return 2;
			}
			return 3;
		}
		if (num2 > 0)
		{
			return 1;
		}
		return 0;
	}

	public int setDirection(int dx, int dy)
	{
		if (CRes.abs(dx) > CRes.abs(dy))
		{
			if (dx > 0)
			{
				return 2;
			}
			return 3;
		}
		if (dy > 0)
		{
			return 1;
		}
		return 0;
	}

	public void setBeginKill(int more)
	{
		switch (Direction)
		{
		case 1:
			y -= 10 + more;
			break;
		case 0:
			y += 10 + more;
			break;
		case 2:
			x -= 10 + more;
			break;
		case 3:
			x += 10 + more;
			break;
		}
	}

	private void setBeginKillXY1000(int more)
	{
		switch (Direction)
		{
		case 1:
			y1000 -= 10 + more;
			break;
		case 0:
			y1000 += 10 + more;
			break;
		case 2:
			x1000 -= 10 + more;
			break;
		case 3:
			x1000 += 10 + more;
			break;
		}
	}

	public int setFrameAngle(int goc)
	{
		if (goc <= 15 || goc > 345)
		{
			return 12;
		}
		int num = (goc - 15) / 15 + 1;
		if (num > 24)
		{
			num = 24;
		}
		return mpaintone_Bullet[num];
	}

	public void setPosLineIn(int sub)
	{
		switch (sub)
		{
		case 0:
			switch (Direction)
			{
			case 1:
				x += 8;
				y += 40;
				break;
			case 0:
				x -= 8;
				y += 20;
				break;
			case 2:
				x += 15;
				y += 20;
				break;
			case 3:
				x -= 15;
				y += 20;
				break;
			}
			break;
		case 1:
			switch (Direction)
			{
			case 1:
				y += 10;
				break;
			case 0:
				y += 45;
				break;
			case 2:
				x -= 16;
				y += 30;
				break;
			case 3:
				x += 18;
				y += 30;
				break;
			}
			break;
		case 3:
			switch (Direction)
			{
			case 1:
				x += 5;
				y += 45;
				break;
			case 0:
				x += 8;
				y += 25;
				break;
			case 2:
				x += 13;
				y += 35;
				break;
			case 3:
				x -= 13;
				y += 35;
				break;
			}
			break;
		case 4:
			switch (Direction)
			{
			case 1:
				x += 15;
				y += 33;
				break;
			case 0:
				x -= 15;
				y += 17;
				break;
			case 2:
				x += 3;
				y += 11;
				break;
			case 3:
				x -= 3;
				y += 11;
				break;
			}
			break;
		case 2:
			break;
		}
	}

	public void removeEff()
	{
		if (typeEffect != 103)
		{
			if (ispaintArena && mSystem.isj2me)
			{
				countSkillArena--;
			}
			if (VecEff.size() > 0)
			{
				VecEff.removeAllElements();
			}
			if (VecSubEff.size() > 0)
			{
				VecSubEff.removeAllElements();
			}
			bool flag = true;
			if (mSystem.isj2me && GameScreen.infoGame.ismapHouse(GameCanvas.loadmap.idMap))
			{
				flag = false;
			}
			if (timeAddNum == -1 && flag)
			{
				addNum();
			}
			isStop = true;
			isRemove = true;
			f = -1;
		}
	}

	public void addNum()
	{
		if (objKill != null && objKill.ID != GameScreen.player.ID && GameScreen.infoGame.isMapchienthanh())
		{
			return;
		}
		for (int i = 0; i < vecObjBeKill.size(); i++)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjBeKill.elementAt(i);
			if (object_Effect_Skill == null)
			{
				continue;
			}
			MainObject mainObject = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
			if (mainObject == null || mainObject == null)
			{
				continue;
			}
			if (!isEff)
			{
				int typeColor = 6;
				if (object_Effect_Skill.hpShow == 0)
				{
					if (mainObject == GameScreen.player)
					{
						typeColor = 7;
					}
					GameScreen.addEffectNum(T.hut, mainObject.x, mainObject.y - mainObject.hOne, typeColor, object_Effect_Skill.ID);
				}
				else
				{
					if (objKill != null)
					{
						int num = setAddEffKillPlus(object_Effect_Skill.mEffTypePlus, objKill, mainObject, object_Effect_Skill.mEff_HP_Plus);
						if (num != -1)
						{
							typeColor = num;
						}
					}
					if (typeEffect == 41)
					{
						GameScreen.addEffectNum("+" + object_Effect_Skill.hpShow, mainObject.x, mainObject.y - mainObject.hOne, (subType != 0) ? 4 : 3, object_Effect_Skill.ID);
					}
					else
					{
						GameScreen.addEffectNum("-" + object_Effect_Skill.hpShow, mainObject.x, mainObject.y - mainObject.hOne, typeColor, object_Effect_Skill.ID);
					}
				}
				if (mainObject.typeObject == 1)
				{
					mainObject.hp = object_Effect_Skill.hpLast;
					if (mainObject.hp <= 0)
					{
						if (objKill != null)
						{
							MainObject.startDeadFly((MainMonster)mainObject, objKill.ID, CRes.random(3));
						}
						mainObject.resetAction();
						mainObject.Action = 4;
						mainObject.timedie = GameCanvas.timeNow;
						GameScreen.addEffectEndKill(11, mainObject.x, mainObject.y);
					}
				}
			}
			if (typeEffect == 41 || typeEffect == 58 || typeEffect == 42 || (object_Effect_Skill.hpShow <= 0 && (objKill == null || objKill != GameScreen.player)))
			{
				continue;
			}
			if (mainObject.typeObject == 1)
			{
				if (mainObject.Action != 3)
				{
					if (!mainObject.isServerControl)
					{
						mainObject.resetAction();
					}
					mainObject.Action = 3;
					mainObject.f = 0;
				}
			}
			else
			{
				if (mainObject.typeObject != 0)
				{
					continue;
				}
				if (mainObject.eye != 3)
				{
					if (objKill != null && objKill.typeObject == 0 && mainObject.hp > mainObject.maxHp / 2 && object_Effect_Skill.hpShow <= mainObject.maxHp / 20)
					{
						mainObject.eye = 4;
						mainObject.timeEye = -6;
					}
					else
					{
						mainObject.eye = 2;
						mainObject.timeEye = 0;
					}
				}
				if (CRes.random(5) == 0)
				{
					mainObject.dy = -CRes.random(2, 5);
				}
				if (mainObject == GameScreen.player && CRes.random(3) == 0)
				{
					mSound.playSound(38, mSound.volumeSound);
				}
			}
		}
		if (!isEff && objKill != null && objKill.typeObject != 9 && objKill.hp <= 0 && objKill.Action != 4)
		{
			objKill.resetAction();
			objKill.Action = 4;
			GameScreen.addEffectEndKill(11, objKill.x, objKill.y);
		}
	}

	private void createXP()
	{
		if (objKill == null)
		{
			gocT_Arc = 0;
		}
		else
		{
			switch (objKill.Direction)
			{
			case 0:
				gocT_Arc = 0;
				break;
			case 1:
				gocT_Arc = 180;
				break;
			case 2:
				gocT_Arc = 90;
				break;
			case 3:
				gocT_Arc = 270;
				break;
			}
		}
		va = 6144;
		vx = 0;
		vy = 0;
		life = 0;
		vX1000 = va * CRes.cos(gocT_Arc) >> 10;
		vY1000 = va * CRes.sin(gocT_Arc) >> 10;
	}

	private void createHut_Mp_Hp()
	{
		switch (CRes.random(4))
		{
		case 0:
			gocT_Arc = 0;
			break;
		case 1:
			gocT_Arc = 180;
			break;
		case 2:
			gocT_Arc = 90;
			break;
		case 3:
			gocT_Arc = 270;
			break;
		}
		va = 6144;
		vx = 0;
		vy = 0;
		life = 0;
		vX1000 = va * CRes.cos(gocT_Arc) >> 10;
		vY1000 = va * CRes.sin(gocT_Arc) >> 10;
	}

	public void createNormal()
	{
		if (objKill == null)
		{
			gocT_Arc = 0;
		}
		else
		{
			switch (objKill.Direction)
			{
			case 0:
				gocT_Arc = 90;
				break;
			case 1:
				gocT_Arc = 270;
				break;
			case 2:
				gocT_Arc = 180;
				break;
			case 3:
				gocT_Arc = 0;
				break;
			}
		}
		va = 4096;
		vx = 0;
		vy = 0;
		life = 0;
		vX1000 = va * CRes.cos(gocT_Arc) >> 10;
		vY1000 = va * CRes.sin(gocT_Arc) >> 10;
	}

	public void createDanFocus()
	{
		switch (CRes.random(4))
		{
		case 0:
			gocT_Arc = 90;
			break;
		case 1:
			gocT_Arc = 270;
			break;
		case 2:
			gocT_Arc = 180;
			break;
		case 3:
			gocT_Arc = 0;
			break;
		}
		va = 4096;
		vx = 0;
		vy = 0;
		life = 0;
		vX1000 = va * CRes.cos(gocT_Arc) >> 10;
		vY1000 = va * CRes.sin(gocT_Arc) >> 10;
	}

	public Point_Focus create_Speed(int xdich, int ydich, Point_Focus p)
	{
		if (ydich == 0)
		{
			ydich = 1;
		}
		if (xdich == 0)
		{
			xdich = 1;
		}
		int num = 0;
		int num2 = 0;
		int num3 = MainObject.getDistance(xdich, ydich) / vMax;
		if (num3 == 0)
		{
			num3 = 1;
		}
		num = xdich / num3;
		num2 = ydich / num3;
		if (CRes.abs(num) > CRes.abs(xdich))
		{
			num = xdich;
		}
		if (CRes.abs(num2) > CRes.abs(ydich))
		{
			num2 = ydich;
		}
		if (objBeKillMain != null)
		{
			toX = objBeKillMain.x;
			toY = objBeKillMain.y - objBeKillMain.hOne / 2;
		}
		if (p != null)
		{
			p.vx = num;
			p.vy = num2;
			p.toX = toX;
			p.toY = toY;
			p.fRe = num3;
		}
		else
		{
			fRemove = num3;
			vx = num;
			vy = num2;
		}
		return p;
	}

	public Point_Focus create_Speed_More(int xdich, int ydich, Point_Focus p, MainObject objSet)
	{
		if (ydich == 0)
		{
			ydich = 1;
		}
		if (xdich == 0)
		{
			xdich = 1;
		}
		int num = 0;
		int num2 = 0;
		int num3 = MainObject.getDistance(xdich, ydich) / vMax;
		if (num3 == 0)
		{
			num3 = 1;
		}
		num = xdich / num3;
		num2 = ydich / num3;
		if (CRes.abs(num) > CRes.abs(xdich))
		{
			num = xdich;
		}
		if (CRes.abs(num2) > CRes.abs(ydich))
		{
			num2 = ydich;
		}
		toX = objSet.x;
		toY = objSet.y - objSet.hOne / 2;
		if (p != null)
		{
			p.vx = num;
			p.vy = num2;
			p.toX = toX;
			p.toY = toY;
			p.fRe = num3;
		}
		else
		{
			fRemove = num3;
			vx = num;
			vy = num2;
		}
		return p;
	}

	public Point_Focus create_Speed_noToXY(int xdich, int ydich, Point_Focus p)
	{
		if (ydich == 0)
		{
			ydich = 1;
		}
		if (xdich == 0)
		{
			xdich = 1;
		}
		int num = 0;
		int num2 = 0;
		int num3 = MainObject.getDistance(xdich, ydich) / vMax;
		if (num3 == 0)
		{
			num3 = 1;
		}
		num = xdich / num3;
		num2 = ydich / num3;
		if (CRes.abs(num) > CRes.abs(xdich))
		{
			num = xdich;
		}
		if (CRes.abs(num2) > CRes.abs(ydich))
		{
			num2 = ydich;
		}
		if (p != null)
		{
			p.vx = num;
			p.vy = num2;
			p.toX = toX;
			p.toY = toY;
			p.fRe = num3;
		}
		else
		{
			fRemove = num3;
			vx = num;
			vy = num2;
		}
		return p;
	}

	public void create_Speed_Kiem_LV5(int xdich, int ydich)
	{
		if (ydich == 0)
		{
			ydich = 1;
		}
		if (xdich == 0)
		{
			xdich = 1;
		}
		int num = 0;
		int num2 = 0;
		int num3 = MainObject.getDistance(xdich, ydich) / vMax;
		if (num3 == 0)
		{
			num3 = 1;
		}
		num = xdich / num3;
		num2 = ydich / num3;
		if (CRes.abs(num) > CRes.abs(xdich))
		{
			num = xdich;
		}
		if (CRes.abs(num2) > CRes.abs(ydich))
		{
			num2 = ydich;
		}
		fRemove = num3;
		vx = num;
		vy = num2;
	}

	private void create_Star()
	{
		x1000 = objBeKillMain.x * 1000;
		y1000 = objBeKillMain.y * 1000 - objBeKillMain.hOne / 2 * 1000;
		colorpaint = new int[3];
		for (int i = 0; i < 3; i++)
		{
			colorpaint[i] = colorStar[0][CRes.random(3)];
		}
		fRemove = CRes.random(5, 9);
		mTamgiac = mSystem.new_M_Int(6, 4);
		for (int j = 0; j < 3; j++)
		{
			int num = CRes.random(5 + 60 * j, 55 + 60 * j);
			int num2 = CRes.random(20, 30);
			mTamgiac[j * 2][0] = CRes.sin(CRes.fixangle(num)) * num2 + x1000;
			mTamgiac[j * 2][1] = CRes.cos(CRes.fixangle(num)) * num2 + y1000;
			int num3 = num + CRes.random_Am(4, 12);
			int num4 = num2 + CRes.random_Am(3, 10);
			mTamgiac[j * 2][2] = CRes.sin(CRes.fixangle(num3)) * num4 + x1000;
			mTamgiac[j * 2][3] = CRes.cos(CRes.fixangle(num3)) * num4 + y1000;
			num += 180;
			num2 += CRes.random_Am(3, 10);
			mTamgiac[j * 2 + 1][0] = CRes.sin(CRes.fixangle(num)) * num2 + x1000;
			mTamgiac[j * 2 + 1][1] = CRes.cos(CRes.fixangle(num)) * num2 + y1000;
			num3 += 180;
			num4 = num2 + CRes.random_Am(3, 10);
			mTamgiac[j * 2 + 1][2] = CRes.sin(CRes.fixangle(num3)) * num4 + x1000;
			mTamgiac[j * 2 + 1][3] = CRes.cos(CRes.fixangle(num3)) * num4 + y1000;
		}
	}

	private void createLighting(int xFrom, int yFrom, int xTo, int yTo, bool isEnd)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = MainObject.getDistance(xFrom, yFrom, xTo, yTo) / 15 + CRes.random(3);
		int num5 = CRes.random(2);
		num2 = CRes.angle(xTo - xFrom, yTo - yFrom);
		int num6 = 20;
		for (int i = 0; i < num4; i++)
		{
			Point point = new Point();
			if (i == 0)
			{
				point.x = xFrom * 1000;
				point.y = yFrom * 1000;
			}
			else
			{
				Point point2 = (Point)VecEff.elementAt(i - 1);
				num6 = 20 + CRes.random_Am_0(10);
				int distance = MainObject.getDistance(point2.x / 1000, point2.y / 1000, xTo, yTo);
				if ((distance < 25 || i == num4 - 1) && isEnd)
				{
					point.x = xTo * 1000;
					point.y = yTo * 1000;
					VecEff.addElement(point);
					break;
				}
				num3 = num2;
				num3 = (isEnd ? ((CRes.abs(num) > 50) ? ((num <= 0) ? (num3 + CRes.random(5, 50)) : (num3 - CRes.random(5, 50))) : ((i % 2 != num5) ? (num3 + CRes.random(5, 50)) : (num3 - CRes.random(5, 50)))) : ((CRes.abs(num) > 50) ? ((num <= 0) ? (num3 + CRes.random(5, 50)) : (num3 - CRes.random(5, 50))) : ((i % 2 != num5) ? (num3 + CRes.random(10, 40)) : (num3 - CRes.random(10, 40)))));
				num += num3 - num2;
				num3 = CRes.fixangle(num3);
				point.x = point2.x + CRes.cos(num3) * num6;
				point.y = point2.y + CRes.sin(num3) * num6;
				if (CRes.random(6) < 5)
				{
					VecSubEff.addElement(point);
					Point point3 = new Point();
					point3 = point;
					int num7 = 10;
					int num8 = num3;
					int num9 = CRes.random(3, 7);
					for (int j = 0; j < num9; j++)
					{
						num7 = 5 + CRes.random_Am_0(3);
						num8 = num3;
						num8 = ((j % 2 != num5) ? (num8 + CRes.random(10, 40)) : (num8 - CRes.random(10, 40)));
						num8 = CRes.fixangle(num8);
						Point point4 = new Point();
						point4.x = point3.x + CRes.cos(num8) * num7;
						point4.y = point3.y + CRes.sin(num8) * num7;
						VecSubEff.addElement(point4);
						point3 = point4;
					}
					point3.x = -1;
					VecSubEff.addElement(point3);
				}
			}
			VecEff.addElement(point);
		}
	}

	public Point create_Stone_Drop(int xTo, int yTo)
	{
		Point point = new Point();
		int num = CRes.random(0, 40);
		int a = CRes.random(20, 50);
		x = MainScreen.cameraMain.xCam - num;
		int num2 = CRes.abs(x - xTo);
		fRemove = CRes.abs(num2 / vx);
		if (fRemove == 0)
		{
			fRemove = 1;
		}
		y = yTo - num2 * 1000 / CRes.tan(a);
		int num3 = CRes.abs(y - yTo);
		vY1000 = num3 * 1000 / fRemove;
		point.y = y;
		point.x = x;
		point.vx = vx;
		point.vy = vY1000;
		point.f = fRemove;
		return point;
	}

	public Point create_ICE_Drop(int xTo, int yTo)
	{
		Point point = new Point();
		x = xTo;
		y = MainScreen.cameraMain.yCam;
		int num = CRes.abs(y - yTo);
		fRemove = num / vMax;
		if (fRemove == 0)
		{
			fRemove = 1;
		}
		vY1000 = num * 1000 / fRemove;
		point.y = y;
		point.x = x;
		point.vx = 0;
		point.vy = vY1000;
		point.f = fRemove;
		return point;
	}

	private void create_Crack_Earth()
	{
		LoadMap.timeVibrateScreen = CRes.random(6, 12);
		levelPaint = -1;
		fRemove = 20;
		timeAddNum = 8;
		if (objBeKillMain != null)
		{
			toX = objBeKillMain.x;
			toY = objBeKillMain.y - objBeKillMain.hOne / 2;
		}
		if (CRes.abs(x - toX) > CRes.abs(y - toY))
		{
			xline = 0;
			yline = 1;
		}
		else
		{
			xline = 1;
			yline = 0;
		}
		int distance = MainObject.getDistance(x, y, toX, toY);
		distance += 24;
		int a = CRes.angle(toX - x, toY - y);
		int xTo = x + CRes.cos(a) * distance / 1000;
		int yTo = y + CRes.sin(a) * distance / 1000;
		createLighting(x, y, xTo, yTo, isEnd: false);
	}

	private void create_Nova()
	{
		fraImgEff = new FrameImage(57);
		fraImgSubEff = new FrameImage(3);
		fRemove = 14;
		vMax = 6;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = x * 1000;
			point.y = y * 1000;
			point.vx = 2 * CRes.cos(225 * i / 10) * vMax;
			point.vy = 1 * CRes.sin(225 * i / 10) * vMax;
			point.f = 0;
			VecEff.addElement(point);
			int num = (x + point.vx) * 100 - x;
			int num2 = (y + point.vy) * 100 - y;
			int frameAngle = CRes.angle(num, num2);
			point.frame = setFrameAngle(frameAngle);
		}
	}

	private void create_Poison_Nova()
	{
		fraImgEff = new FrameImage(125);
		fraImgSubEff = new FrameImage(3);
		fRemove = 14;
		vMax = 5;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = x * 1000;
			point.y = y * 1000;
			point.vx = 2 * CRes.cos(225 * i / 10) * vMax;
			point.vy = CRes.sin(225 * i / 10) * vMax;
			point.f = 0;
			VecEff.addElement(point);
			int num = (x + point.vx) * 100 - x;
			int num2 = (y + point.vy) * 100 - y;
			int frameAngle = CRes.angle(num, num2);
			point.frame = setFrameAngle(frameAngle);
		}
	}

	private void create_Ice_Arc()
	{
		fraImgEff = new FrameImage(29);
		fraImgSubEff = new FrameImage(42);
		fRemove = 25;
		vMax = 5;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = x * 1000;
			point.y = y * 1000;
			point.vx = 2 * CRes.cos(225 * i / 10) * vMax;
			point.vy = 1 * CRes.sin(225 * i / 10) * vMax;
			point.f = 0;
			VecEff.addElement(point);
		}
	}

	private void create_Fire_Arc()
	{
		fraImgEff = new FrameImage(41);
		fraImgSubEff = new FrameImage(42);
		fRemove = 25;
		vMax = 5;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = x * 1000;
			point.y = y * 1000;
			point.vx = 2 * CRes.cos(225 * i / 10) * vMax;
			point.vy = 1 * CRes.sin(225 * i / 10) * vMax;
			point.f = 0;
			VecEff.addElement(point);
		}
	}

	private void create_Arrow_Rain()
	{
		if (f == -1)
		{
			VecEff.removeAllElements();
		}
		for (int i = 0; i < vecObjBeKill.size(); i++)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjBeKill.elementAt(i);
			if (object_Effect_Skill == null)
			{
				continue;
			}
			MainObject mainObject = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
			if (mainObject == null)
			{
				continue;
			}
			int num = CRes.random(1, 4);
			if (GameCanvas.lowGraphic)
			{
				num = CRes.random(1, 3);
			}
			for (int j = 0; j < num; j++)
			{
				vMax = CRes.random(14, 18);
				Point point = new Point();
				point.x = mainObject.x - 70 + CRes.random_Am_0(15);
				point.y = y1000;
				int xdich = mainObject.x - point.x + CRes.random_Am_0(30);
				int num2 = mainObject.y - point.y + 8 + CRes.random_Am_0(10);
				if (num2 / vMax > 8)
				{
					vMax = num2 / 8;
				}
				Point_Focus p = new Point_Focus();
				p = create_Speed(xdich, num2, p);
				point.vx = p.vx;
				point.vy = p.vy;
				point.fRe = p.fRe;
				point.f = 0;
				VecEff.addElement(point);
			}
		}
	}

	public void create_Kill_2Kiem_Lv2()
	{
		savex = objKill.x;
		savey = objKill.y;
		if (objKill != null)
		{
			y += objKill.hOne / 2;
			objKill.isTanHinh = true;
			objKill.timeTanHinh = 0;
		}
		fraImgEff = new FrameImage(50);
		vMax = 20;
		int num = 0;
		int num2 = 0;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - y;
		}
		else
		{
			num = toX - x;
			num2 = toY - y;
		}
		int distance = MainObject.getDistance(num, num2);
		int a = CRes.angle(num, num2);
		int num3 = distance;
		toX = x + num3 * CRes.cos(a) / 1000;
		toY = y + num3 * CRes.sin(a) / 1000;
		int num4 = toX;
		int num5 = toY;
		int num6;
		do
		{
			toX = num4;
			toY = num5;
			if (num3 > 120)
			{
				num6 = -1;
				continue;
			}
			num3 += 10;
			num4 = x + num3 * CRes.cos(a) / 1000;
			num5 = y + num3 * CRes.sin(a) / 1000;
			num6 = GameCanvas.loadmap.getTile(toX, toY);
		}
		while (num6 != -1 && num6 != 1);
		num = toX - x;
		num2 = toY - y;
		if (num2 == 0)
		{
			num2 = 1;
		}
		if (num == 0)
		{
			num = 1;
		}
		int num7 = 0;
		int num8 = 0;
		int num9 = MainObject.getDistance(num, num2) / vMax;
		if (num9 == 0)
		{
			num9 = 1;
		}
		num7 = num / num9;
		num8 = num2 / num9;
		if (CRes.abs(num7) > CRes.abs(num))
		{
			num7 = num;
		}
		if (CRes.abs(num8) > CRes.abs(num2))
		{
			num8 = num2;
		}
		vx = num7;
		vy = num8;
		fRemove = num9;
		if (fRemove > 0)
		{
			timeAddNum = (sbyte)(fRemove / 2);
		}
		if (objKill != null && objBeKillMain != null)
		{
			toX = objKill.x + (fRemove - 1) * num7;
			if (objBeKillMain != null)
			{
				toY = objKill.y + objBeKillMain.hOne / 4 + (fRemove - 1) * num8;
			}
			else
			{
				toY = objKill.y + (fRemove - 1) * num8;
			}
		}
	}

	private void create_Star_Line_In(int vline, int minline, int maxline)
	{
		if (f == -1)
		{
			VecEff.removeAllElements();
		}
		int num = 4;
		colorpaint = new int[num];
		if (maxline <= minline)
		{
			maxline = minline + 1;
		}
		for (int i = 0; i < num; i++)
		{
			if (CRes.random(2) == 0)
			{
				colorpaint[i] = colorStar[indexColorStar][CRes.random(3)];
			}
			else
			{
				colorpaint[i] = colorStar[indexColorStar][2];
			}
		}
		for (int j = 0; j < num; j++)
		{
			Line line = new Line();
			int num2 = 5 + 180 / num * j;
			int num3 = 180 / num + 180 / num * j - 5;
			if (num3 <= num2)
			{
				num3 = num2 + 1;
			}
			int num4 = CRes.random(minline, maxline);
			int num5 = CRes.random(vline, vline + 3);
			int num6 = CRes.random(num2, num3);
			int num7 = CRes.random(13, 23);
			bool is2Line = CRes.random(4) == 0;
			num6 = CRes.fixangle(num6);
			line.setLine(x1000 - CRes.sin(num6) * (num4 + num7), y1000 - CRes.cos(num6) * (num4 + num7), x1000 - CRes.sin(num6) * num7, y1000 - CRes.cos(num6) * num7, CRes.sin(num6) * num5, CRes.cos(num6) * num5, is2Line);
			VecEff.addElement(line);
			line = new Line();
			num6 += 180 + CRes.random_Am(2, 5);
			num6 = CRes.fixangle(num6);
			line.setLine(x1000 - CRes.sin(num6) * (num4 + num7), y1000 - CRes.cos(num6) * (num4 + num7), x1000 - CRes.sin(num6) * num7, y1000 - CRes.cos(num6) * num7, CRes.sin(num6) * num5, CRes.cos(num6) * num5, is2Line);
			VecEff.addElement(line);
		}
	}

	private void create_Line_NHANBAN_LV2()
	{
		int num = CRes.random(1, 3);
		for (int i = 0; i < num; i++)
		{
			Line line = new Line();
			int num2 = CRes.random(3, 12);
			int num3 = 0;
			if (num2 <= 5)
			{
				line.fRe = 16;
				num3 = 2;
			}
			else if (num2 <= 8)
			{
				num3 = 4;
				line.fRe = 12;
			}
			else
			{
				num3 = 5;
				line.fRe = 9;
			}
			int num4 = x1000 + CRes.random_Am_0(15);
			int num5 = y1000 - CRes.random_Am_0(10);
			line.setLine(num4, num5, num4, num5 - num2, 0, -num3, is2Line: false);
			line.idColor = CRes.random(3);
			VecEff.addElement(line);
		}
	}

	private void create_Star_Point_In()
	{
		int num = CRes.random(0, 45);
		for (int i = 0; i < 8; i++)
		{
			Point point = new Point();
			int num2 = 4;
			int num3 = num + 360 * i / 8;
			int num4 = 30;
			point.x = x1000 - CRes.sin(CRes.fixangle(num3)) * num4;
			point.y = y1000 - CRes.cos(CRes.fixangle(num3)) * num4;
			point.vx = CRes.sin(CRes.fixangle(num3)) * num2;
			point.vy = CRes.cos(CRes.fixangle(num3)) * num2;
			VecEff.addElement(point);
		}
	}

	private void create_Buff_Point_In()
	{
		int num = subType;
		if (num >= 9)
		{
			num = 4;
		}
		else if (num > 3 && num > 4 && num < 9)
		{
			num -= 5;
		}
		colorBuff = colorBuffMain[num][CRes.random(4)];
		colorpaint = new int[12];
		int num2 = CRes.random(0, 30);
		for (int i = 0; i < 12; i++)
		{
			colorpaint[i] = colorBuffMain[num][CRes.random(3)];
			Line line = new Line();
			int num3 = 5;
			int num4 = num2 + 360 * i / 12;
			int num5 = CRes.random(20, 40);
			if (CRes.random(3) == 0)
			{
				num3 = 8;
				num5 = CRes.random(40, 55);
			}
			line.vx = CRes.sin(CRes.fixangle(num4)) * num3;
			line.vy = CRes.cos(CRes.fixangle(num4)) * num3;
			line.x0 = x1000 - CRes.sin(CRes.fixangle(num4)) * num5;
			line.y0 = y1000 - CRes.cos(CRes.fixangle(num4)) * num5;
			line.y1 = y1000 - CRes.cos(CRes.fixangle(num4)) * (num5 + 6);
			line.x1 = x1000 - CRes.sin(CRes.fixangle(num4)) * (num5 + 6);
			line.is2Line = CRes.random(3) == 0;
			VecEff.addElement(line);
		}
	}

	private void create_Mon_Buff()
	{
		int num = subType;
		if (num > 3 && num > 4 && num < 9)
		{
			num -= 5;
		}
		colorBuff = colorBuffMain[num][CRes.random(4)];
		colorpaint = new int[12];
		int num2 = CRes.random(0, 30);
		for (int i = 0; i < 12; i++)
		{
			colorpaint[i] = colorBuffMain[num][CRes.random(3)];
			Line line = new Line();
			int num3 = 4;
			int num4 = num2 + 360 * i / 12;
			int num5 = CRes.random(10, 25);
			if (CRes.random(3) == 0)
			{
				num3 = 6;
				num5 = CRes.random(20, 40);
			}
			line.vx = CRes.sin(CRes.fixangle(num4)) * num3;
			line.vy = CRes.cos(CRes.fixangle(num4)) * num3;
			line.x0 = x1000 - CRes.sin(CRes.fixangle(num4)) * num5;
			line.y0 = y1000 - CRes.cos(CRes.fixangle(num4)) * num5;
			line.y1 = y1000 - CRes.cos(CRes.fixangle(num4)) * (num5 + 6);
			line.x1 = x1000 - CRes.sin(CRes.fixangle(num4)) * (num5 + 6);
			line.is2Line = CRes.random(3) == 0;
			VecEff.addElement(line);
		}
	}

	public void create_2Kiem_Lv4(int goc, MainObject objBeKill)
	{
		int num = 0;
		int num2 = 0;
		if (objBeKill != null)
		{
			num = x - objBeKill.x;
			num2 = y - (objBeKill.y - objBeKill.hOne / 2);
		}
		else
		{
			num = x - toX;
			num2 = y - toY;
		}
		int a = CRes.fixangle(CRes.angle(num, num2) + goc);
		int a2 = CRes.fixangle(CRes.angle(-num, -num2) + goc);
		int num3 = 50;
		int num4 = 30;
		Point point = new Point();
		if (objBeKill != null)
		{
			point.x = objBeKill.x + num3 * CRes.cos(a) / 1000;
			point.y = objBeKill.y - objBeKill.hOne / 2 + num3 * CRes.sin(a) / 1000;
		}
		else
		{
			point.x = toX + num3 * CRes.cos(a) / 1000;
			point.y = toY + num3 * CRes.sin(a) / 1000;
		}
		point.vx = num4 * CRes.cos(a2) / 1000;
		point.vy = num4 * CRes.sin(a2) / 1000;
		VecEff.addElement(point);
	}

	public void create_2Kiem_Lv3()
	{
		fraImgEff = new FrameImage(15);
		fraImgSubEff = new FrameImage(24);
		fraImgSub2Eff = new FrameImage(26);
		if (objBeKillMain != null)
		{
			toX = objBeKillMain.x;
			toY = objBeKillMain.y - objBeKillMain.hOne / 2;
		}
		vMax = 16;
		fRemove = 6;
		switch (Direction)
		{
		case 1:
			frame = 18;
			break;
		case 0:
			frame = 6;
			break;
		case 2:
			frame = 0;
			break;
		case 3:
			frame = 12;
			break;
		}
		int num = 0;
		int num2 = 14;
		int num3 = 18;
		for (int i = 0; i < 3; i++)
		{
			Point point = new Point();
			switch (Direction)
			{
			case 1:
				switch (i)
				{
				case 0:
					point.y = y - 25;
					point.x = x;
					break;
				case 1:
					point.y = y - 25 + num3;
					point.x = x + num2;
					break;
				case 2:
					point.y = y - 25 + num3;
					point.x = x - num2;
					break;
				}
				break;
			case 0:
				switch (i)
				{
				case 0:
					point.y = y + 25;
					point.x = x;
					break;
				case 1:
					point.y = y + 25 - num3;
					point.x = x + num2;
					break;
				case 2:
					point.y = y + 25 - num3;
					point.x = x - num2;
					break;
				}
				break;
			case 2:
				switch (i)
				{
				case 0:
					point.y = y;
					point.x = x - 25;
					break;
				case 1:
					point.y = y + num2;
					point.x = x - 25 + num3;
					break;
				case 2:
					point.y = y - num2;
					point.x = x - 25 + num3;
					break;
				}
				break;
			case 3:
				switch (i)
				{
				case 0:
					point.y = y;
					point.x = x + 25;
					break;
				case 1:
					point.y = y + num2;
					point.x = x + 25 - num3;
					break;
				case 2:
					point.y = y - num2;
					point.x = x + 25 - num3;
					break;
				}
				break;
			}
			Point_Focus point_Focus = new Point_Focus();
			create_Speed(toX - point.x, toY - point.y, point_Focus);
			point.vx = point_Focus.vx;
			point.vy = point_Focus.vy;
			point.fRe = point_Focus.fRe;
			if (i == 0)
			{
				num = setFrameAngle(CRes.angle(toX - point.x, toY - point.y));
			}
			point.frame = num;
			point.dis = CRes.random(4);
			VecEff.addElement(point);
		}
		setBeginKill(5);
		y += 10;
	}

	private void create_2Kiem_Lv5()
	{
		if (objBeKillMain != null)
		{
			toX = objBeKillMain.x;
			toY = objBeKillMain.y - objBeKillMain.hOne / 2;
		}
		fRemove = 20;
		vMax = 20;
		fraImgEff = new FrameImage(15);
		fraImgSubEff = new FrameImage(17);
		fraImgSub2Eff = new FrameImage(26);
		lT_Arc = 32;
		int num = CRes.random(360);
		for (int i = 0; i < 5; i++)
		{
			Point point = new Point();
			point.x = toX * 1000;
			point.y = toY * 1000;
			point.g = CRes.fixangle(num + i * 72);
			point.vx = CRes.sin(CRes.fixangle(point.g)) * lT_Arc;
			point.vy = CRes.cos(CRes.fixangle(point.g)) * lT_Arc;
			int frameAngle = CRes.angle(-point.vx, -point.vy);
			point.frame = setFrameAngle(frameAngle);
			VecEff.addElement(point);
			Point point2 = new Point();
			point2.x = point.x + point.vx;
			point2.y = point.y + point.vy;
			point2.vx = CRes.sin(CRes.fixangle(point.g + 180)) * 5;
			point2.vy = CRes.cos(CRes.fixangle(point.g + 180)) * 5;
			VecSubEff.addElement(point2);
		}
	}

	private void create_Kiem_Lv2()
	{
		LoadMap.timeVibrateScreen = 103;
		if (objBeKillMain != null)
		{
			x = objBeKillMain.x;
			y = objBeKillMain.y + objBeKillMain.hOne / 4;
		}
		else
		{
			x = toX;
			y = toY;
		}
		fraImgEff = new FrameImage(53);
		vMax = 4;
		fRemove = 6;
		if (fRemove > 0)
		{
			timeAddNum = (sbyte)(fRemove / 2);
		}
		if (objBeKillMain != null)
		{
			toX = objBeKillMain.x;
			toY = objBeKillMain.y - objBeKillMain.hOne / 4;
		}
	}

	private void create_Kiem_Lv3()
	{
		y += 10;
		if (Direction == 1)
		{
			y -= 5;
		}
		fraImgEff = new FrameImage(8);
		fraImgSubEff = new FrameImage(53);
		vMax = 14;
		setBeginKill(10);
		int num = 0;
		int num2 = 0;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - y;
		}
		else
		{
			num = toX - x;
			num2 = toY - y;
		}
		create_Speed(num, num2, null);
		if (Direction != 1)
		{
			Point point = new Point();
			point.x = x;
			point.y = y;
			VecEff.addElement(point);
		}
		if (objBeKillMain != null)
		{
			toX = objBeKillMain.x;
			toY = objBeKillMain.y - objBeKillMain.hOne / 4;
		}
	}

	private void create_PS_LV2_3_5()
	{
		y += 8;
		vMax = 12;
		int num = 0;
		int num2 = 0;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - objBeKillMain.hOne / 2 - y;
		}
		else
		{
			num = toX - x;
			num2 = toY - y;
		}
		y += 6;
		vMax = 16;
		fraImgEff = new FrameImage(57);
		fraImgSubEff = new FrameImage(3);
		int frameAngle = CRes.angle(num, num2);
		frame = setFrameAngle(frameAngle);
		create_Speed(num, num2, null);
		if (vx >= 0)
		{
			frameArrow = 0;
		}
		else
		{
			frameArrow = 2;
		}
	}

	private void createArrowProjectile(int imageId)
	{
		vMax = 12;
		int num = 0;
		int num2 = 0;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - objBeKillMain.hOne / 2 - y;
		}
		else
		{
			num = toX - x;
			num2 = toY - y;
		}
		fraImgEff = new FrameImage(imageId);
		int frameAngle = CRes.angle(num, num2);
		frame = setFrameAngle(frameAngle);
		create_Speed(num, num2, null);
		if (vx >= 0)
		{
			frameArrow = 0;
		}
		else
		{
			frameArrow = 2;
		}
	}

	private void create_Sung_LV2_LV4()
	{
		y += 5;
		if (typeEffect == 22)
		{
			indexSound = 17;
			fraImgEff = new FrameImage(74);
			vMax = 22;
		}
		else if (typeEffect == 31)
		{
			indexSound = 18;
			y += 3;
			fraImgEff = new FrameImage(97);
			fraImgSubEff = new FrameImage(31);
			vMax = 16;
		}
		int num = 0;
		int num2 = 0;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - objBeKillMain.hOne / 2 - y;
		}
		else
		{
			num = toX - x;
			num2 = toY - y;
		}
		create_Speed(num, num2, null);
		int frameAngle = CRes.angle(num, num2);
		frame = setFrameAngle(frameAngle);
	}

	private void create_Sung_Medusa()
	{
		y += 5;
		if (typeEffect == 99)
		{
			indexSound = 34;
			y += 3;
			fraImgEff = new FrameImage(135);
			vMax = 16;
		}
		int num = 0;
		int num2 = 0;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - objBeKillMain.hOne / 2 - y;
		}
		else
		{
			num = toX - x;
			num2 = toY - y;
		}
		create_Speed(num, num2, null);
		int frameAngle = CRes.angle(num, num2);
		frame = setFrameAngle(frameAngle);
	}

	private void create_FireBall_Tower()
	{
		dxTower = 20;
		dyTower = -50;
		y += dyTower;
		x += dxTower;
		indexSound = 32;
		fraImgEff = new FrameImage(133);
		fraImgSubEff = new FrameImage(31);
		vMax = 16;
		int num = 0;
		int num2 = 0;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - y;
		}
		else
		{
			num = toX - x;
			num2 = toY - y;
		}
		create_Speed(num, num2, null);
		int frameAngle = CRes.angle(num, num2);
		frame = setFrameAngle(frameAngle);
	}

	private void create_Sung_DAY_DAN(int xto, int yto)
	{
		int xdich = xto - x;
		int ydich = yto - y;
		Point_Focus point_Focus = new Point_Focus();
		create_Speed_noToXY(xdich, ydich, point_Focus);
		Point point = new Point();
		point.x = x;
		point.y = y;
		point.vx = point_Focus.vx;
		point.vy = point_Focus.vy;
		point.fRe = point_Focus.fRe;
		int frameAngle = CRes.angle(xdich, ydich);
		point.frame = setFrameAngle(frameAngle);
		VecEff.addElement(point);
	}

	private void create_Sung_Lv3()
	{
		y += 5;
		fRemove = 5;
		fraImgEff = new FrameImage(47);
		vMax = 22;
		int num;
		int num2;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x;
			num2 = objBeKillMain.y - objBeKillMain.hOne / 2;
		}
		else
		{
			num = toX;
			num2 = toY;
		}
		int frameAngle = CRes.angle(num - x, num2 - y);
		frame = setFrameAngle(frameAngle);
		for (int i = 0; i < 4; i++)
		{
			int xdich = num + CRes.random_Am(0, 13) - x;
			int ydich = num2 + CRes.random_Am(0, 13) - y;
			Point_Focus point_Focus = new Point_Focus();
			create_Speed(xdich, ydich, point_Focus);
			Point point = new Point();
			point.x = x;
			point.y = y;
			point.vx = point_Focus.vx;
			point.vy = point_Focus.vy;
			point.fRe = point_Focus.fRe;
			VecEff.addElement(point);
		}
	}

	private void create_Sung_BaoDan()
	{
		if (objBeKillMain == null)
		{
			if (f < fRemove)
			{
				f = fRemove;
			}
			return;
		}
		int frameAngle = CRes.angle(toX - x, toY - y);
		frame = setFrameAngle(frameAngle);
		for (int i = 0; i < 6; i++)
		{
			int xdich = toX + CRes.random_Am(0, 35) - x;
			int ydich = toY + CRes.random_Am(0, 35) - y;
			Point_Focus point_Focus = new Point_Focus();
			create_Speed_noToXY(xdich, ydich, point_Focus);
			Point point = new Point();
			point.x = x;
			point.y = y;
			point.vx = point_Focus.vx;
			point.vy = point_Focus.vy;
			point.fRe = point_Focus.fRe + CRes.random(2);
			point.frame = frame;
			VecEff.addElement(point);
		}
	}

	private void create_Level_up()
	{
		levelPaint = -1;
		if (objKill != null)
		{
			y += objKill.hOne / 2;
		}
		fraImgEff = new FrameImage(65);
		fraImgSubEff = new FrameImage(67);
		fRemove = 23;
		for (int i = 0; i < 10; i++)
		{
			Point point = new Point();
			int a = CRes.random(180, 360);
			point.x = 17 * CRes.cos(a) / 1000;
			point.y = 15 * CRes.sin(a) / 1000 - 5;
			point.fRe = CRes.random(2);
			point.frame = CRes.random(4);
			point.limitY = 50;
			VecEff.addElement(point);
		}
	}

	private void create_2Kiem_GaiDoc()
	{
		timeAddNum = 4;
		if (typeEffect == 47)
		{
			fraImgEff = new FrameImage(87);
		}
		else
		{
			fraImgEff = new FrameImage(127);
		}
		fraImgSubEff = new FrameImage(75);
		if (objKill != null)
		{
			y = objKill.y;
		}
		if (objBeKillMain != null)
		{
			toX = objBeKillMain.x;
			toY = objBeKillMain.y - objBeKillMain.hOne / 4;
		}
		fRemove = 20;
		int num = x * 1000;
		int num2 = y * 1000;
		int num3 = 18;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = CRes.angle(toX - x, toY - y);
		int distance = MainObject.getDistance(toX - x, toY - y);
		if (distance > 60)
		{
			num = x * 1000 + (distance - 50) * CRes.cos(num8);
			num2 = y * 1000 + (distance - 50) * CRes.sin(num8);
		}
		num4 = num3 * CRes.cos(num8);
		num5 = num3 * CRes.sin(num8);
		Point point = new Point();
		point.fRe = 0;
		point.x = num + num4;
		point.y = num2 + num5;
		point.frame = CRes.random(5);
		if (Direction == 2)
		{
			point.dis = 2;
		}
		VecEff.addElement(point);
		for (int i = 1; i < 6; i++)
		{
			point = new Point();
			point.fRe = i / 2;
			Point point2 = (Point)VecEff.elementAt(i - 1);
			point.x = point2.x + num4 + ((i % 2 != 0) ? num6 : (-num6));
			if (num8 > 1575 && num8 <= 3375)
			{
				point.y = point2.y + num5 + ((i % 2 != 0) ? num7 : (-num7));
			}
			else
			{
				point.y = point2.y + num5 + ((i % 2 != 0) ? (-num7) : num7);
			}
			point.dis = 0;
			point.frame = CRes.random(5);
			if (Direction == 2)
			{
				point.dis = 2;
			}
			VecEff.addElement(point);
		}
	}

	private void create_Monster()
	{
		vMax = 5;
		if (objKill != null && objBeKillMain != null && MainObject.getDistance(objKill.x, objBeKillMain.y, objKill.y, objBeKillMain.y) < 15)
		{
			vMax = 2;
		}
		switch (Direction)
		{
		case 2:
			x -= vMax;
			x1000 = -vMax;
			frame = 10;
			frameArrow = 2;
			break;
		case 3:
			x += vMax;
			x1000 = vMax;
			frame = 6;
			frameArrow = 0;
			break;
		case 1:
			y -= vMax;
			y1000 = -vMax;
			frame = 33;
			frameArrow = 6;
			break;
		case 0:
			y += vMax;
			y1000 = vMax;
			frame = 17;
			frameArrow = 5;
			break;
		}
		switch (subType)
		{
		case 0:
			fraImgEff = new FrameImage(106);
			break;
		case 1:
			fraImgEff = new FrameImage(107);
			break;
		case 2:
			fraImgEff = new FrameImage(108);
			break;
		case 3:
			fraImgEff = new FrameImage(109);
			break;
		case 4:
			fraImgEff = new FrameImage(110);
			break;
		default:
			fraImgEff = new FrameImage(106);
			break;
		}
		fRemove = 8;
	}

	private void create_PS_Xungkich()
	{
		vMax = 12;
		int num = 0;
		int num2 = 0;
		if (objBeKillMain != null)
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - y;
		}
		else
		{
			num = toX - x;
			num2 = toY - y;
		}
		create_Speed(num, num2, null);
		x1000 = x;
		y1000 = y;
		y1000 += 10;
		if (Direction == 1)
		{
			y1000 -= 5;
		}
		setBeginKillXY1000(10);
	}

	public void updateAngleNormal()
	{
		if (objBeKillMain == null)
		{
			removeEff();
			return;
		}
		int num = objBeKillMain.x - x;
		int num2 = objBeKillMain.y - (objBeKillMain.hOne >> 1) - y;
		life++;
		if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || life > fRemove)
		{
			removeEff();
			return;
		}
		int num3 = CRes.angle(num, num2);
		if (Math.abs(num3 - gocT_Arc) < 90 || num * num + num2 * num2 > 4096)
		{
			if (Math.abs(num3 - gocT_Arc) < 15)
			{
				gocT_Arc = num3;
			}
			else if ((num3 - gocT_Arc >= 0 && num3 - gocT_Arc < 180) || num3 - gocT_Arc < -180)
			{
				gocT_Arc = CRes.fixangle(gocT_Arc + 15);
			}
			else
			{
				gocT_Arc = CRes.fixangle(gocT_Arc - 15);
			}
		}
		if (!isSpeedUp && va < 8192)
		{
			va += 2048;
		}
		vX1000 = va * CRes.cos(gocT_Arc) >> 10;
		vY1000 = va * CRes.sin(gocT_Arc) >> 10;
		num += vX1000;
		int num4 = num >> 10;
		x += num4;
		num &= 0x3FF;
		num2 += vY1000;
		int num5 = num2 >> 10;
		y += num5;
		num2 &= 0x3FF;
	}

	public void updateAngleXP()
	{
		if (typeEffect == 96)
		{
			Point point = new Point();
			point.x = x;
			point.y = y;
			VecEff.addElement(point);
		}
		if (typeEffect == 88)
		{
			Point point2 = new Point();
			point2.x = x;
			point2.y = y;
			VecEff.addElement(point2);
		}
		if (objBeKillMain == null || objBeKillMain.isRemove || f >= fRemove || objBeKillMain.isStop)
		{
			f = fRemove;
			return;
		}
		int num;
		int num2;
		if (typeEffect == 92 || typeEffect == 89)
		{
			num = objKill.x - x;
			num2 = objKill.y - (objKill.hOne >> 1) - y;
		}
		else
		{
			num = objBeKillMain.x - x;
			num2 = objBeKillMain.y - (objBeKillMain.hOne >> 1) - y;
		}
		life++;
		if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || life > fRemove)
		{
			f = fRemove;
			return;
		}
		int num3 = CRes.angle(num, num2);
		if (Math.abs(num3 - gocT_Arc) < 90 || num * num + num2 * num2 > 4096)
		{
			if (Math.abs(num3 - gocT_Arc) < 15)
			{
				gocT_Arc = num3;
			}
			else if ((num3 - gocT_Arc >= 0 && num3 - gocT_Arc < 180) || num3 - gocT_Arc < -180)
			{
				gocT_Arc = CRes.fixangle(gocT_Arc + 15);
			}
			else
			{
				gocT_Arc = CRes.fixangle(gocT_Arc - 15);
			}
		}
		if (!isSpeedUp && va < 8192)
		{
			va += 3096;
		}
		vX1000 = va * CRes.cos(gocT_Arc) >> 10;
		vY1000 = va * CRes.sin(gocT_Arc) >> 10;
		num += vX1000;
		int num4 = num >> 10;
		x += num4;
		num &= 0x3FF;
		num2 += vY1000;
		int num5 = num2 >> 10;
		y += num5;
		num2 &= 0x3FF;
		if (typeEffect != 88)
		{
			Point point3 = new Point();
			point3.x = x;
			point3.y = y;
			VecEff.addElement(point3);
		}
	}

	public void updateAngleHut_Mp_Hp()
	{
		if (f >= fRemove)
		{
			f = fRemove;
			return;
		}
		int num = toX - x;
		int num2 = toY - y;
		life++;
		if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || life > fRemove)
		{
			f = fRemove;
			return;
		}
		int num3 = CRes.angle(num, num2);
		if (Math.abs(num3 - gocT_Arc) < 90 || num * num + num2 * num2 > 4096)
		{
			if (Math.abs(num3 - gocT_Arc) < 15)
			{
				gocT_Arc = num3;
			}
			else if ((num3 - gocT_Arc >= 0 && num3 - gocT_Arc < 180) || num3 - gocT_Arc < -180)
			{
				gocT_Arc = CRes.fixangle(gocT_Arc + 15);
			}
			else
			{
				gocT_Arc = CRes.fixangle(gocT_Arc - 15);
			}
		}
		if (!isSpeedUp && va < 8192)
		{
			va += 3096;
		}
		vX1000 = va * CRes.cos(gocT_Arc) >> 10;
		vY1000 = va * CRes.sin(gocT_Arc) >> 10;
		num += vX1000;
		int num4 = num >> 10;
		x += num4;
		num &= 0x3FF;
		num2 += vY1000;
		int num5 = num2 >> 10;
		y += num5;
		num2 &= 0x3FF;
		Point point = new Point();
		point.x = x;
		point.y = y;
		VecEff.addElement(point);
	}

	public void paint_phuong_hoang(mGraphics g, FrameImage frm, int index, int x, int y)
	{
		int num = frm.nFrame / 3;
		switch (index)
		{
		case 0:
			frm.drawFrame(f % num, x, y, 2, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 1:
			frm.drawFrame(num * 2 + f % num, x, y, 4, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 2:
			frm.drawFrame(num + f % num, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 3:
			frm.drawFrame(num * 2 + f % num, x, y, 5, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 4:
			frm.drawFrame(f % num, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 5:
			frm.drawFrame(num * 2 + f % num, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 6:
			frm.drawFrame(num + f % num, x, y, 1, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 7:
			frm.drawFrame(num * 2 + f % num, x, y, 2, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		}
	}

	private void paint_Ice_Nova_Effect(mGraphics g)
	{
		if (fraImgEff == null)
		{
			return;
		}
		for (int i = 0; i < VecEff.size(); i++)
		{
			Point point = (Point)VecEff.elementAt(i);
			if (point.f < fRemove)
			{
				paint_Bullet(g, fraImgEff, point.frame, point.x / 1000, point.y / 1000, isMore: false);
			}
		}
	}

	private void paint_Poison_Nova_Effect(mGraphics g)
	{
		if (fraImgEff == null)
		{
			return;
		}
		for (int i = 0; i < VecEff.size(); i++)
		{
			Point point = (Point)VecEff.elementAt(i);
			if (point.f < fRemove)
			{
				paint_Bullet(g, fraImgEff, point.frame, point.x / 1000, point.y / 1000, isMore: false);
			}
		}
	}

	private void update_Nova_Effect()
	{
		if (f >= fRemove)
		{
			for (int i = 0; i < VecEff.size(); i++)
			{
				Point point = (Point)VecEff.elementAt(i);
				if (typeEffect == 90)
				{
					GameScreen.addEffectEndKill(10, point.x / 1000, point.y / 1000);
					GameScreen.addEffectEndKill(15, point.x / 1000, point.y / 1000 + objBeKillMain.hOne / 4);
				}
				else if (typeEffect == 91)
				{
					GameScreen.addEffectEndKill(44, point.x / 1000, point.y / 1000);
				}
			}
			removeEff();
			return;
		}
		for (int j = 0; j < VecEff.size(); j++)
		{
			Point point2 = (Point)VecEff.elementAt(j);
			point2.x += point2.vx;
			point2.y += point2.vy;
			int tile = GameCanvas.loadmap.getTile(point2.x / 1000, point2.y / 1000);
			if (tile == -1 || tile == 1 || !MainEffect.isInScreen(point2.x / 1000, point2.y / 1000, fraImgEff.frameWidth, fraImgEff.frameHeight))
			{
				if (typeEffect == 90)
				{
					GameScreen.addEffectEndKill(10, point2.x / 1000, point2.y / 1000);
					GameScreen.addEffectEndKill(15, point2.x / 1000, point2.y / 1000 + objBeKillMain.hOne / 4);
				}
				else if (typeEffect == 91)
				{
					GameScreen.addEffectEndKill(44, point2.x / 1000, point2.y / 1000);
				}
				VecEff.removeElement(point2);
			}
		}
	}

	public void paint_Bullet(mGraphics g, FrameImage frm, int index, int x, int y, bool isMore)
	{
		int num = frm.nFrame / 3;
		int num2 = 3;
		frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x, y, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
		if (isMore)
		{
			switch (index)
			{
			case 0:
			case 1:
			case 2:
			case 23:
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + num2, y - num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + num2, y + num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + 2 * num2, y, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 5:
			case 6:
			case 7:
			case 8:
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + num2, y - num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - num2, y - num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x, y - 2 * num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 11:
			case 12:
			case 13:
			case 14:
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - num2, y - num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - num2, y + num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - 2 * num2, y, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 17:
			case 18:
			case 19:
			case 20:
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + num2, y + num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - num2, y + num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x, y + 2 * num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 21:
			case 22:
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + num2, y, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x, y + num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + num2, y + num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 3:
			case 4:
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + num2, y, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x, y - num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x + num2, y - num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 9:
			case 10:
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - num2, y, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x, y - num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - num2, y - num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 15:
			case 16:
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - num2, y, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x, y + num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * mImageBullet[index] + f % num, x - num2, y + num2, mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			}
		}
	}

	public void setSendMove(int x, int xend, int y, int yend)
	{
		int tile = GameCanvas.loadmap.getTile(xend, yend);
		if (tile == 1 || tile == -1)
		{
			objKill.toX = xend;
			objKill.toY = yend;
			objKill.x = xend;
			objKill.y = yend;
			removeEff();
			return;
		}
		if (objKill == null || objKill != GameScreen.player)
		{
			objKill.toX = xend;
			objKill.toY = yend;
			objKill.x = xend;
			objKill.y = yend;
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = CRes.abs(x - xend);
		int num6 = CRes.abs(y - yend);
		if (num5 >= 4)
		{
			num = ((x <= xend) ? 4 : (-4));
		}
		if (num6 >= 4)
		{
			num2 = ((y <= yend) ? 4 : (-4));
		}
		num3 = num5 / 4;
		num4 = num6 / 4;
		int num7 = ((num5 <= num6) ? num4 : num3);
		for (int i = 0; i < num7; i++)
		{
			if (i < num3)
			{
				x += num;
			}
			if (i < num4)
			{
				y += num2;
			}
		}
		objKill.toX = xend;
		objKill.toY = yend;
		objKill.x = savex;
		objKill.y = savey;
		objKill.xStand = xend;
		objKill.yStand = yend;
		objKill.xFire = xend;
		objKill.yFire = yend;
	}

	public static int setAddEffKillPlus(int[] mtype, MainObject objFrom, MainObject objTo, int[] mplus)
	{
		int result = -1;
		for (int i = 0; i < mtype.Length; i++)
		{
			switch (mtype[i])
			{
			case 2:
			case 3:
				GameScreen.addEffectKillSubTime(41, objTo.ID, objTo.typeObject, objFrom.ID, objFrom.typeObject, mplus[i], objFrom.hp, (sbyte)(mtype[i] - 2), 3000);
				GameScreen.addEffectNum("-" + mplus[i], objTo.x, objTo.y - objTo.hOne / 2, (mtype[i] != 2) ? 4 : 3);
				break;
			case 4:
				GameScreen.addEffectKill(6, objTo.ID, objTo.typeObject, objTo.ID, objTo.typeObject, mplus[i], objFrom.hp);
				if (objFrom == GameScreen.player)
				{
					GameScreen.addEffectNum(T.dcchimang, objTo.x, objTo.y - objTo.hOne / 2, 7);
					result = 7;
				}
				else
				{
					GameScreen.addEffectNum(T.dcchimang, objTo.x, objTo.y - objTo.hOne / 2, 6);
				}
				break;
			case 1:
				GameScreen.addEffectEndKill(29, objTo.x, objTo.y - objTo.hOne / 2);
				if (objFrom == GameScreen.player)
				{
					GameScreen.addEffectNum(T.dcxuyengiap, objTo.x, objTo.y - objTo.hOne / 2, 7);
					result = 7;
				}
				else
				{
					GameScreen.addEffectNum(T.dcxuyengiap, objTo.x, objTo.y - objTo.hOne / 2, 6);
				}
				break;
			case 5:
				GameScreen.addEffectKill(67, objTo.ID, objTo.typeObject, objFrom.ID, objFrom.typeObject, mplus[i], objFrom.hp);
				if (objTo == GameScreen.player)
				{
					GameScreen.addEffectNum(T.phandon, objTo.x, objTo.y - objTo.hOne / 2, 7);
				}
				else
				{
					GameScreen.addEffectNum(T.phandon, objTo.x, objTo.y - objTo.hOne / 2, 6);
				}
				if (objFrom.hp <= 0 && objFrom.Action != 4)
				{
					objFrom.resetAction();
					objFrom.Action = 4;
					objFrom.timedie = GameCanvas.timeNow;
					GameScreen.addEffectEndKill(11, objFrom.x, objFrom.y);
				}
				break;
			}
		}
		return result;
	}

	public static bool isMultiTarget(int type)
	{
		return type == 93 || type == 99 || type == 95 || type == 96 || type == 97 || type == 98 || type == 108 || type == 113 || type == 104 || type == 114 || type == 115;
	}

	private void update_Boss_De2()
	{
		if (objBeKillMain != null)
		{
			if (f == 1)
			{
				LoadMap.timeVibrateScreen = 103;
				GameScreen.addEffectEndKill(9, objBeKillMain.x, objBeKillMain.y - 2);
				GameScreen.addEffectEndKill_Time(47, objBeKillMain.x, objBeKillMain.y, objBeKillMain.timeBind);
			}
			if (!objBeKillMain.isBinded || (objBeKillMain != null && objBeKillMain.isRemove))
			{
				isRemove = true;
			}
		}
	}

	private void update_Boss_Medusa2()
	{
		if (objBeKillMain != null && (objBeKillMain.Action == 4 || !objBeKillMain.isDongBang || objBeKillMain == null || (objBeKillMain != null && objBeKillMain.isRemove)))
		{
			isRemove = true;
		}
	}

	private void update_Boss_De1()
	{
		for (int i = 0; i < VecEff.size(); i++)
		{
			Point point = (Point)VecEff.elementAt(i);
			if (objBeKillMain == null)
			{
				removeEff();
				return;
			}
			int num = objBeKillMain.x - point.x;
			int num2 = objBeKillMain.y - (objBeKillMain.hOne >> 1) - point.y;
			life++;
			if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || life > fRemove)
			{
				removeEff();
				GameScreen.addEffectEndKill(45, objBeKillMain.x, objBeKillMain.y - 20);
				return;
			}
			int num3 = CRes.angle(num, num2);
			if (Math.abs(num3 - gocT_Arc) < 90 || num * num + num2 * num2 > 4096)
			{
				if (Math.abs(num3 - gocT_Arc) < 15)
				{
					gocT_Arc = num3;
				}
				else if ((num3 - gocT_Arc >= 0 && num3 - gocT_Arc < 180) || num3 - gocT_Arc < -180)
				{
					gocT_Arc = CRes.fixangle(gocT_Arc + 15);
				}
				else
				{
					gocT_Arc = CRes.fixangle(gocT_Arc - 15);
				}
			}
			if (!isSpeedUp && va < 8192)
			{
				va += 2048;
			}
			vX1000 = va * CRes.cos(gocT_Arc) >> 10;
			vY1000 = va * CRes.sin(gocT_Arc) >> 10;
			num += vX1000;
			int num4 = num >> 10;
			point.x += num4;
			num &= 0x3FF;
			num2 += vY1000;
			int num5 = num2 >> 10;
			point.y += num5;
			num2 &= 0x3FF;
			if (f % 2 == 0)
			{
				GameScreen.addEffectEndKill(9, point.x, point.y);
				GameScreen.addEffectEndKill(46, point.x, point.y - 2);
			}
			point.f++;
		}
		if (f >= fRemove)
		{
			removeEff();
		}
	}

	public override void setTimeRemove(short time)
	{
		timeRemove = time;
		x = objBeKillMain.x;
		y = objBeKillMain.y;
		objBeKillMain.vx = 0;
		objBeKillMain.vy = 0;
		objBeKillMain.toX = x;
		objBeKillMain.toY = y;
		if (typeEffect == 101)
		{
			objBeKillMain.isSleep = true;
			objBeKillMain.timeSleep = mSystem.currentTimeMillis() + time * 1000;
		}
		else if (typeEffect == 102)
		{
			objBeKillMain.isStun = true;
			objBeKillMain.timeStun = mSystem.currentTimeMillis() + time * 1000;
		}
		else if (typeEffect == 107)
		{
			objBeKillMain.timeno = mSystem.currentTimeMillis() + time * 1000;
			objBeKillMain.isno = true;
		}
		else if (typeEffect == 103)
		{
			objBeKillMain.isnoBoss84 = true;
			objBeKillMain.timenoBoss84 = mSystem.currentTimeMillis() + time * 1000;
		}
		else if (typeEffect == 100)
		{
			objBeKillMain.isDongBang = true;
			objBeKillMain.timeDongBang = mSystem.currentTimeMillis() + time * 1000;
		}
		else
		{
			objBeKillMain.isBinded = true;
			objBeKillMain.timeBind = mSystem.currentTimeMillis() + time * 1000;
		}
	}

	public override void setObjFrom(short id, sbyte tem)
	{
		objKill = MainObject.get_Object(id, tem);
	}
}
