public class MainListSkill
{
	public const sbyte KILL_STONE_DROP_MORE = 5;

	public const sbyte KILL_CRACK_EARTH = 6;

	public const sbyte KILL_ARROW_RAIN = 14;

	public const sbyte KILL_KIEM_LV1 = 15;

	public const sbyte KILL_SUNG_LV2 = 18;

	public const sbyte KILL_SUNG_LV3 = 19;

	public const sbyte KILL_PS_LV2 = 20;

	public const sbyte KILL_KIEM_LV3 = 21;

	public const sbyte KILL_2KIEM_LV2 = 22;

	public const sbyte KILL_KIEM_LV2 = 23;

	public const sbyte KILL_SUNG_LV4 = 24;

	public const sbyte KILL_2KIEM_LV4 = 27;

	public const sbyte KILL_PS_LV1 = 31;

	public const sbyte KILL_2KIEM_LV5 = 34;

	public const sbyte KILL_NULL = 35;

	public const sbyte KILL_2KIEM_TRUNGDOC = 36;

	public const sbyte KILL_2KIEM_GAIDOC = 37;

	public const sbyte KILL_PS_XUNGKICH = 39;

	public const sbyte KILL_SUNG_LASER = 40;

	public const sbyte KILL_KIEM_FIRE = 41;

	public const sbyte KILL_KIEM_LV6 = 42;

	public const sbyte KILL_KIEM_LV7 = 43;

	public const sbyte KILL_2KIEM_CRI = 44;

	public const sbyte KILL_BUFF = 45;

	public const sbyte KILL_PS_CAU_NOILUC = 46;

	public const sbyte KILL_PS_DONGDAT = 47;

	public const sbyte KILL_PS_ICE_RAIN = 48;

	public const sbyte KILL_SUNG_BAO_DAN = 49;

	public const sbyte KILL_SUNG_SET_NEW = 50;

	public const sbyte KILL_PS_ICE_UP = 51;

	public const sbyte KILL_SUNG_RAIN_ROCKET = 52;

	public const sbyte KILL_SUNG_RAIN_LIGHTNING = 53;

	public const sbyte EFF_KIEMLON_NGU = 54;

	public const sbyte EFF_KIEMNHO_TROI = 55;

	public const sbyte EFF_PHAP_SU_BANG = 56;

	public const sbyte EFF_SUNGNGU = 57;

	public const sbyte EFF_CHIEN_BINH_BUFFDAME = 58;

	public const sbyte EFF_THICH_KHACH_BUFFHP = 59;

	public const sbyte EFF_XA_THU_BUFF_BUFFAMOR = 60;

	public const sbyte EFF_PHAP_SU_BUFFGOLD = 61;

	public const sbyte KILL_PHAP_SU_115 = 62;

	public const sbyte KILL_SUNG_115 = 63;

	public const sbyte KILL_BIG_SWORD_115 = 64;

	public const sbyte KILL_SMALL_SWORD_115 = 65;

	public const sbyte KILL_PHAP_SU_115_2 = 66;

	public const sbyte KILL_SUNG_115_2 = 67;

	public const sbyte KILL_BIG_SWORD_115_2 = 68;

	public const sbyte KILL_SMALL_SWORD_115_2 = 69;

	public static MainListSkill me;

	private int typeKill;

	private int maxSize;

	public static int[][] mSkillAllClasses = new int[7][]
	{
		new int[21]
		{
			15, 23, 41, 21, 5, 42, 43, 42, 5, 0,
			0, 0, 0, 45, 45, 0, 0, 54, 58, 64,
			68
		},
		new int[21]
		{
			15, 44, 36, 22, 37, 27, 34, 27, 14, 0,
			0, 0, 0, 45, 45, 0, 0, 55, 60, 65,
			69
		},
		new int[21]
		{
			31, 46, 20, 39, 51, 6, 48, 47, 48, 0,
			0, 0, 0, 45, 45, 0, 0, 56, 61, 62,
			66
		},
		new int[21]
		{
			31, 19, 18, 24, 40, 49, 50, 52, 53, 0,
			0, 0, 0, 45, 45, 0, 0, 57, 59, 63,
			67
		},
		new int[32]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
			20, 21, 22, 23, 24, 25, 26, 27, 70, 70,
			70, 70
		},
		new int[10],
		new int[18]
		{
			45, 45, 45, 45, 45, 45, 45, 45, 45, 45,
			45, 45, 45, 45, 45, 45, 45, 45
		}
	};

	public static int[][] mBuffAllClasses;

	public static int[] mRange;

	public static int[] mPlash;

	public static int[] mFramePlash;

	public static int[] mEffectKill;

	static MainListSkill()
	{
		int[][] array = new int[7][];
		int[] array2 = new int[25];
		array2[14] = 5;
		array2[21] = 9;
		array[0] = array2;
		array[1] = new int[25]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 6, 0, 0, 0, 0, 0,
			0, 9, 0, 0, 0
		};
		array[2] = new int[25]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 2, 7, 0, 0, 0, 0, 0,
			0, 9, 0, 0, 0
		};
		array[3] = new int[25]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 3, 8, 0, 0, 0, 0, 0,
			0, 9, 0, 0, 0
		};
		int[] array3 = new int[32];
		array3[28] = 28;
		array3[29] = 29;
		array3[30] = 30;
		array3[31] = 31;
		array[4] = array3;
		array[5] = new int[10];
		array[6] = new int[20]
		{
			10, 10, 10, 10, 10, 10, 10, 10, 10, 10,
			10, 10, 10, 10, 10, 10, 10, 10, 10, 10
		};
		mBuffAllClasses = array;
		mRange = new int[70]
		{
			200, 60, 200, 50, 200, 110, 110, 70, 100, 200,
			200, 200, 200, 200, 110, 60, 30, 110, 110, 110,
			110, 110, 75, 60, 110, 100, 120, 110, 160, 140,
			120, 70, 60, 100, 110, 50, 60, 110, 110, 110,
			110, 60, 110, 110, 60, 120, 110, 110, 110, 110,
			110, 110, 110, 110, 110, 110, 110, 110, 110, 110,
			110, 110, 110, 110, 110, 110, 110, 110, 110, 110
		};
		mPlash = new int[70]
		{
			0, 0, 0, 0, 0, 5, 7, 0, 0, 0,
			0, 0, 0, 0, 7, 0, 0, 0, 16, 16,
			1, 5, 1, 1, 11, 2, 5, 4, 10, 7,
			0, 0, 0, 12, 7, 14, 1, 5, 0, 5,
			6, 1, 7, 7, 1, 9, 1, 7, 2, 13,
			11, 5, 10, 10, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0
		};
		mFramePlash = new int[70]
		{
			5, 5, 5, 5, 5, 11, 15, 5, 5, 5,
			5, 5, 5, 5, 15, 5, 5, 5, 9, 9,
			9, 11, 9, 9, 11, 5, 5, 9, 5, 5,
			5, 5, 5, 5, 15, 5, 9, 11, 5, 11,
			11, 9, 15, 15, 9, 5, 9, 15, 15, 11,
			11, 11, 20, 20, 5, 5, 5, 5, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5
		};
	}

	public static MainListSkill gI()
	{
		if (me == null)
		{
			me = new MainListSkill();
		}
		return me;
	}

	public static void loadIndexEffKill()
	{
		mEffectKill = new int[mPlash.Length];
		mEffectKill[5] = 11;
		mEffectKill[6] = 12;
		mEffectKill[14] = 20;
		mEffectKill[15] = 21;
		mEffectKill[18] = 22;
		mEffectKill[19] = 23;
		mEffectKill[20] = 25;
		mEffectKill[21] = 26;
		mEffectKill[22] = 27;
		mEffectKill[23] = 28;
		mEffectKill[24] = 31;
		mEffectKill[27] = 34;
		mEffectKill[31] = 38;
		mEffectKill[34] = 40;
		mEffectKill[35] = 38;
		mEffectKill[36] = 46;
		mEffectKill[37] = 47;
		mEffectKill[39] = 49;
		mEffectKill[40] = 51;
		mEffectKill[41] = 52;
		mEffectKill[42] = 53;
		mEffectKill[43] = 54;
		mEffectKill[44] = 55;
		mEffectKill[45] = 57;
		mEffectKill[46] = 59;
		mEffectKill[47] = 60;
		mEffectKill[48] = 61;
		mEffectKill[49] = 62;
		mEffectKill[50] = 82;
		mEffectKill[51] = 64;
		mEffectKill[52] = 65;
		mEffectKill[53] = 66;
		mEffectKill[54] = 110;
		mEffectKill[55] = 112;
		mEffectKill[56] = 109;
		mEffectKill[57] = 111;
		mEffectKill[58] = 0;
		mEffectKill[59] = 0;
		mEffectKill[60] = 0;
		mEffectKill[61] = 0;
		mEffectKill[62] = 119;
		mEffectKill[63] = 118;
		mEffectKill[64] = 116;
		mEffectKill[65] = 117;
		mEffectKill[66] = 123;
		mEffectKill[67] = 122;
		mEffectKill[68] = 120;
		mEffectKill[69] = 121;
	}

	public static void setKill(int typeclass)
	{
		Player.mKillPlayer = new int[TabSkillsNew.vecPaintSkill.size()];
		for (int i = 0; i < Player.mKillPlayer.Length; i++)
		{
			Player.mKillPlayer[i] = mSkillAllClasses[typeclass][i];
		}
	}

	public int setDirection(MainObject idFrom, MainObject idTo)
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

	public static int getRange(int index)
	{
		return getSkillFormId(index)?.range ?? 50;
	}

	public static Skill getSkillFormId(int id)
	{
		for (int i = 0; i < TabSkillsNew.vecPaintSkill.size(); i++)
		{
			Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(i);
			if (skill.Id == id)
			{
				return skill;
			}
		}
		return null;
	}
}
