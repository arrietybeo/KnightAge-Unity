public class Object_Effect_Skill
{
	public short ID;

	public sbyte tem;

	public int hpShow;

	public int hpLast;

	public int hpPlus;

	public int[] mEffTypePlus = new int[0];

	public int[] mEff_HP_Plus = new int[0];

	public Monster_Skill skillMonster;

	public Object_Effect_Skill(short Id, sbyte tem)
	{
		ID = Id;
		this.tem = tem;
	}

	public Object_Effect_Skill(short Id, sbyte tem, Monster_Skill skill)
	{
		ID = Id;
		this.tem = tem;
		skillMonster = skill;
	}

	public void setHP(int hpShow, int hpLast)
	{
		this.hpShow = hpShow;
		this.hpLast = hpLast;
	}
}
