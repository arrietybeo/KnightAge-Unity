public class SplashSkill
{
	public const sbyte PLASH_MIN_4 = 0;

	public const sbyte PLASH_MIN_6 = 1;

	public const sbyte PLASH_MIN_12 = 2;

	public const sbyte PLASH_SUNG_0 = 3;

	public const sbyte PLASH_2KIEM_LV2_LV4 = 4;

	public const sbyte PLASH_MIN_8 = 5;

	public const sbyte PLASH_SUNG_LASER = 6;

	public const sbyte PLASH_MIN_16 = 7;

	public const sbyte PLASH_MIN_10 = 8;

	public const sbyte PLASH_BUFF = 9;

	public const sbyte PLASH_SUNG_LV4 = 10;

	public const sbyte PLASH_SUNG_MIN_8 = 11;

	public const sbyte PLASH_KIEM_LV5 = 12;

	public const sbyte PLASH_SUNG_BAODAN = 13;

	public const sbyte PLASH_NULL = 14;

	public const sbyte PLASH_SUNG_DAYDAN = 15;

	public const sbyte PLASH_SUNG_MIN_6 = 16;

	public int typePlash;

	public int min;

	private bool isSung;

	public void setPlash(int typeP)
	{
		typePlash = typeP;
		isSung = false;
		switch (typePlash)
		{
		case 0:
			min = 4;
			break;
		case 1:
			min = 6;
			break;
		case 6:
			min = 30;
			isSung = true;
			break;
		case 2:
			min = 12;
			break;
		case 5:
			min = 8;
			break;
		case 10:
			min = 22;
			isSung = true;
			break;
		case 7:
			min = 16;
			break;
		case 8:
			min = 10;
			break;
		case 11:
			min = 12;
			isSung = true;
			break;
		case 16:
			min = 6;
			isSung = true;
			break;
		case 3:
		case 4:
		case 9:
		case 12:
		case 13:
		case 14:
		case 15:
			break;
		}
	}

	public void update(MainObject obj)
	{
		switch (typePlash)
		{
		case 3:
			if (obj.fplash < 2)
			{
				obj.frame = 5;
				obj.weapon_frame = 4;
				break;
			}
			obj.setEye(1);
			obj.weapon_frame = obj.fplash + 2;
			if (obj.fplash < 6)
			{
				obj.frame = 4;
				break;
			}
			obj.Action = 0;
			obj.frame = 0;
			obj.f = 0;
			obj.weapon_frame = 0;
			break;
		case 13:
			if (obj.fplash < 12)
			{
				obj.frame = 5;
				obj.weapon_frame = 4;
			}
			else if (obj.fplash < 30)
			{
				if (obj.fplash < 14)
				{
					obj.weapon_frame = obj.fplash - 8;
					obj.frame = 4;
				}
				else if (obj.fplash % 2 == 0)
				{
					obj.setEye(1);
					obj.weapon_frame = 4;
					obj.frame = 5;
				}
				else
				{
					obj.weapon_frame = 7;
					obj.frame = 4;
				}
			}
			else
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			break;
		case 15:
			if (obj.fplash < 26)
			{
				obj.frame = 5;
				obj.weapon_frame = 4;
				if (obj.fplash >= 12)
				{
					obj.setEye(1);
				}
			}
			else if (obj.fplash < 30)
			{
				obj.weapon_frame = obj.fplash - 22;
				obj.frame = 4;
				if (obj.weapon_frame > 7)
				{
					obj.weapon_frame = 7;
				}
			}
			else
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			break;
		case 4:
			if (obj.fplash < 4)
			{
				obj.frame = 4;
				obj.weapon_frame = 4;
				break;
			}
			obj.setEye(1);
			obj.weapon_frame = obj.fplash;
			if (obj.fplash < 10)
			{
				obj.frame = 5;
				break;
			}
			obj.Action = 0;
			obj.frame = 0;
			obj.f = 0;
			obj.weapon_frame = 0;
			break;
		case 12:
			if (obj.fplash >= 30)
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			break;
		case 14:
			if (obj.clazz == 3)
			{
				if (obj.fplash < 2)
				{
					obj.frame = 5;
					obj.weapon_frame = 4;
					break;
				}
				obj.setEye(1);
				obj.weapon_frame = obj.fplash + 2;
				if (obj.fplash < 6)
				{
					obj.frame = 4;
					break;
				}
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			else if (obj.fplash < 4)
			{
				obj.frame = 4;
				obj.weapon_frame = 4;
			}
			else
			{
				obj.setEye(1);
				obj.weapon_frame = obj.fplash;
				if (obj.fplash < 8)
				{
					obj.frame = 5;
					break;
				}
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			break;
		case 9:
			if (obj.fplash < 30)
			{
				obj.frame = 4;
				if (obj.clazz == 3)
				{
					obj.frame = 5;
				}
				obj.weapon_frame = 4;
			}
			else
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			break;
		default:
			if (obj.fplash < min)
			{
				obj.frame = 4;
				if (isSung)
				{
					obj.frame = 5;
				}
				obj.weapon_frame = 4;
				if (obj.weapon_frame > 4)
				{
					obj.weapon_frame = 4;
				}
				break;
			}
			obj.setEye(1);
			obj.weapon_frame = obj.fplash - (min - 4);
			if (obj.fplash < min + 4)
			{
				obj.frame = 5;
				if (isSung)
				{
					obj.frame = 4;
				}
			}
			else
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			break;
		}
		obj.fplash++;
	}
}
