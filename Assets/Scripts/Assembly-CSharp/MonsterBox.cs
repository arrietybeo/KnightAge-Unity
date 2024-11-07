public class MonsterBox : MainMonster
{
	public MonsterBox(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
	{
		typeObject = 1;
		base.typeMonster = typeMonster;
		base.ID = ID;
		catalogyMonster = Monster;
		xAnchor = x;
		yAnchor = y;
		base.x = x;
		base.y = y;
		base.name = name;
		maxHp = maxHP;
		hp = maxHP;
		Lv = (short)lv;
		MonWater = 1;
		Direction = 0;
		nFrame = 5;
		wOne = (hOne = -1);
		vMax = 3;
		limitMove = 60;
		timeAutoAction = CRes.random(50, 70);
		limitAttack = 50;
		xsai = 0;
		ysai = -2;
		timeLoadInfo = mSystem.currentTimeMillis();
	}

	public override void updateAction()
	{
	}

	public override void update()
	{
		base.update();
		if (!isInfo)
		{
			long num = mSystem.currentTimeMillis();
			long num2 = num - timeLoadInfo;
			if (num2 >= 5000)
			{
				timeLoadInfo = num;
				GlobalService.gI().monster_info((short)ID);
			}
		}
		setDie();
		updateAction();
	}

	public override bool isItemBox()
	{
		return true;
	}

	public override void paint(mGraphics g)
	{
		if (!isDie)
		{
			MainImage imagePartMonster = ObjectData.getImagePartMonster((short)catalogyMonster);
			if (imagePartMonster != null && imagePartMonster.img != null)
			{
				g.drawImage(imagePartMonster.img, x, y, mGraphics.BOTTOM | mGraphics.HCENTER, useClip: false);
			}
		}
	}

	public override void move_to_XY()
	{
	}

	public override void move_to_XY_Normal()
	{
	}

	public override void moveX()
	{
	}

	public override void moveY()
	{
	}
}
