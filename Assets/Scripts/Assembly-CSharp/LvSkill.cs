public class LvSkill
{
	public short mpLost;

	public short time_Sub_Eff;

	public short plus_Hp;

	public short plus_Mp;

	public short LvRe;

	public short range_lan;

	public int delay;

	public int timeBuff;

	public sbyte per_Sub_Eff;

	public sbyte nTarget;

	public MainInfoItem[] minfo;

	public int getdelay()
	{
		if (GameScreen.player.timeCombo > 0)
		{
			return GameScreen.player.timeCombo;
		}
		return delay;
	}

	public string[] getinfo()
	{
		string[] array = null;
		int num = 0;
		if (mpLost > 0)
		{
			num++;
		}
		if (timeBuff > 0)
		{
			num++;
		}
		if (per_Sub_Eff > 0)
		{
			num++;
		}
		if (time_Sub_Eff > 0)
		{
			num++;
		}
		if (plus_Hp > 0)
		{
			num++;
		}
		if (plus_Mp > 0)
		{
			num++;
		}
		if (delay > 0)
		{
			num++;
		}
		array = new string[num];
		num = 0;
		if (mpLost > 0)
		{
			array[num++] = T.nangluong + mpLost;
		}
		if (delay > 0)
		{
			array[num++] = T.delay + delay / 1000 + "s";
		}
		if (timeBuff > 0)
		{
			array[num++] = T.timebuff + timeBuff / 1000 + "s";
		}
		if (per_Sub_Eff > 0)
		{
			array[num++] = T.hieuung + per_Sub_Eff;
		}
		if (time_Sub_Eff > 0)
		{
			array[num++] = T.timehieuung + time_Sub_Eff / 1000 + "s";
		}
		if (plus_Hp > 0)
		{
			array[num++] = T.tanghpdung + plus_Hp / 10 + "%";
		}
		if (plus_Mp > 0)
		{
			array[num++] = T.tangmpdung + plus_Mp / 10 + "%";
		}
		return array;
	}
}
