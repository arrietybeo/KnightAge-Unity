using System;

public class Monster_Skill
{
	public const sbyte S_NEAR = 50;

	public const sbyte S_FAR = 0;

	public const sbyte S_BUFF = 2;

	public const sbyte S_BOSS_CAY_1 = 71;

	public const sbyte S_BOSS_CAY_2 = 72;

	public const sbyte S_BOSS_ONG_1 = 73;

	public const sbyte S_BOSS_ONG_2 = 74;

	public const sbyte S_BOSS_CUA_1 = 75;

	public const sbyte S_BOSS_CUA_2 = 76;

	public const sbyte S_BOSS_SOI_1 = 77;

	public const sbyte S_BOSS_SOI_2 = 14;

	public const sbyte S_BOSS_NGUOIDA_1 = 78;

	public const sbyte S_BOSS_NGUOIDA_2 = 79;

	public const sbyte S_BOSS_DE_1 = 93;

	public const sbyte S_BOSS_DE_2 = 94;

	public const sbyte S_BOSS_NOEL_1 = 113;

	public const sbyte S_BOSS_NOEL_2 = 114;

	public const sbyte S_BOSS_NOEL_3 = 115;

	public const sbyte S_BOSS_CHIEM_THANH = 124;

	public const sbyte S_TRU_THANH_1 = 125;

	public const sbyte S_TRU_THANH_2 = 126;

	public const sbyte S_Tower1 = 95;

	public const sbyte S_Tower2 = 96;

	public const sbyte S_Tower3 = 97;

	public const sbyte S_Tower4 = 98;

	public const sbyte S_Medusa1 = 99;

	public const sbyte S_Medusa2 = 100;

	public const sbyte S_BOSS_34_Dam_Tung = 104;

	public const sbyte S_BOSS_84 = 103;

	public const sbyte S_BOSS_34_Laser = 105;

	public const sbyte S_BOSS_34_Laser_Lan = 106;

	public const sbyte S_BOSS_84_Ston_Drop_More = 108;

	public const sbyte SUB_VATLY = 0;

	public const sbyte SUB_BANG = 1;

	public const sbyte SUB_LUA = 2;

	public const sbyte SUB_DIEN = 3;

	public const sbyte SUB_DOC = 4;

	public sbyte typeSkill;

	public sbyte typeSub;

	public sbyte nPlash;

	public int range;

	public static mHashTable hashMonsterSkillInfo = new mHashTable();

	public Monster_Skill(sbyte id)
	{
		switch (id)
		{
		case 0:
		case 2:
		case 4:
		case 6:
		case 8:
		case 10:
		case 12:
			typeSkill = 50;
			typeSub = (sbyte)(id / 2);
			nPlash = 1;
			break;
		case 1:
		case 3:
		case 5:
		case 7:
		case 9:
		case 11:
		case 13:
			typeSkill = 50;
			typeSub = (sbyte)(id / 2);
			nPlash = 2;
			break;
		case 14:
		case 16:
		case 18:
		case 20:
		case 22:
		case 24:
		case 26:
			typeSkill = 0;
			typeSub = (sbyte)((id - 14) / 2);
			nPlash = 1;
			break;
		case 15:
		case 17:
		case 19:
		case 21:
		case 23:
		case 25:
		case 27:
			typeSkill = 0;
			typeSub = (sbyte)((id - 14) / 2);
			nPlash = 2;
			break;
		case 28:
		case 30:
			typeSkill = 2;
			typeSub = (sbyte)((id - 28) / 2);
			nPlash = 1;
			break;
		case 29:
		case 31:
			typeSkill = 2;
			typeSub = (sbyte)((id - 28) / 2);
			nPlash = 2;
			break;
		case 32:
			typeSkill = 71;
			typeSub = 0;
			nPlash = 1;
			break;
		case 33:
			typeSkill = 72;
			typeSub = 0;
			nPlash = 1;
			break;
		case 34:
			typeSkill = 73;
			typeSub = 0;
			nPlash = 1;
			break;
		case 35:
			typeSkill = 74;
			typeSub = 0;
			nPlash = 1;
			break;
		case 36:
			typeSkill = 75;
			typeSub = 0;
			nPlash = 1;
			break;
		case 37:
			typeSkill = 76;
			typeSub = 0;
			nPlash = 1;
			break;
		case 38:
			typeSkill = 77;
			typeSub = 0;
			nPlash = 1;
			break;
		case 39:
			typeSkill = 14;
			typeSub = 0;
			nPlash = 1;
			break;
		case 40:
			typeSkill = 78;
			typeSub = 0;
			nPlash = 1;
			break;
		case 41:
			typeSkill = 79;
			typeSub = 0;
			nPlash = 1;
			break;
		case 44:
			typeSkill = 93;
			typeSub = 0;
			nPlash = 1;
			break;
		case 45:
			typeSkill = 94;
			typeSub = 0;
			nPlash = 1;
			break;
		case 46:
			typeSkill = 95;
			typeSub = 0;
			nPlash = 1;
			break;
		case 47:
			typeSkill = 96;
			typeSub = 0;
			nPlash = 1;
			break;
		case 48:
			typeSkill = 97;
			typeSub = 0;
			nPlash = 1;
			break;
		case 49:
			typeSkill = 98;
			typeSub = 0;
			nPlash = 1;
			break;
		case 50:
			typeSkill = 99;
			typeSub = 0;
			nPlash = 1;
			break;
		case 51:
			typeSkill = 100;
			typeSub = 0;
			nPlash = 1;
			break;
		case 54:
			typeSkill = 104;
			typeSub = 0;
			nPlash = 1;
			break;
		case 55:
			typeSkill = 105;
			typeSub = 0;
			nPlash = 1;
			break;
		case 56:
			typeSkill = 106;
			typeSub = 0;
			nPlash = 1;
			break;
		case 59:
			typeSkill = 108;
			typeSub = 0;
			nPlash = 1;
			break;
		case 61:
			typeSkill = 113;
			typeSub = 0;
			nPlash = 1;
			break;
		case 62:
			typeSkill = 114;
			typeSub = 0;
			nPlash = 1;
			break;
		case 63:
			typeSkill = 115;
			typeSub = 0;
			nPlash = 1;
			break;
		case 64:
			typeSkill = 124;
			typeSub = 0;
			nPlash = 1;
			break;
		case 65:
			typeSkill = 125;
			typeSub = 0;
			nPlash = 1;
			break;
		case 66:
			typeSkill = 126;
			typeSub = 0;
			nPlash = 1;
			break;
		}
		getRange(id);
	}

	public void getRange(int id)
	{
		try
		{
			range = int.Parse(hashMonsterSkillInfo.get(string.Empty + id).ToString());
		}
		catch (Exception)
		{
			range = 40;
		}
	}
}
