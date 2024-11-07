public class Monsterplus : MainMonster
{
	public sbyte ideffect = -1;

	public sbyte fireFrame;

	public EffectAuto eff;

	public int r;

	public FrameImage fraImgEff;

	public int[] arr_radian = new int[12]
	{
		0, 30, 60, 90, 120, 150, 180, 210, 240, 270,
		300, 330
	};

	public long timeLive;

	public Monsterplus(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
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
		fraImgEff = new FrameImage(1);
		r = 120;
		limitMove = 60;
		timeAutoAction = CRes.random(50, 70);
		limitAttack = 50;
		xsai = 0;
		ysai = -2;
		timeLoadInfo = mSystem.currentTimeMillis();
		if (catalogyMonster == 110)
		{
			ideffect = 52;
			r = 120;
			eff = new EffectAuto(ideffect, x, y, 0, 0, 1, 0);
		}
	}

	public override void setEffectauto(int id, int r, short lv)
	{
		ideffect = (sbyte)id;
		eff = new EffectAuto(ideffect, x, y, 0, 0, 1, 0);
		this.r = r;
		Lv = lv;
	}

	public override void setTimelive(long time)
	{
		timeLive = time;
	}

	public override bool isLuaThieng()
	{
		return true;
	}

	public override void setLvmonster(int lv)
	{
		Lv = (sbyte)lv;
		if (catalogyMonster == 110)
		{
			if (Lv == 1)
			{
				ideffect = 52;
				r = 120;
			}
			if (Lv == 2)
			{
				ideffect = 53;
				r = 130;
			}
			else if (Lv == 3)
			{
				ideffect = 54;
				r = 140;
			}
			else if (Lv == 4)
			{
				ideffect = 55;
				r = 150;
			}
			eff = new EffectAuto(ideffect, x, y, 0, 0, 1, 0);
		}
	}

	public void setIdeffect(sbyte ideffect)
	{
		this.ideffect = ideffect;
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
		fireFrame++;
		if (fireFrame > 10)
		{
			fireFrame = 0;
		}
		if (eff != null)
		{
			eff.update();
		}
		bool flag = false;
		if (myClan != null)
		{
			if (GameScreen.player.myClan != null && myClan.IdClan == GameScreen.player.myClan.IdClan)
			{
				flag = true;
			}
		}
		else if (nameowner.Equals(GameScreen.player.name))
		{
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		ysai = 10;
		for (int i = 0; i < arr_radian.Length; i++)
		{
			arr_radian[i]++;
			if (arr_radian[i] >= 360)
			{
				arr_radian[i] = 0;
			}
		}
	}

	public override void paint(mGraphics g)
	{
		if (eff != null)
		{
			eff.paint(g);
		}
		bool flag = false;
		if (myClan != null)
		{
			if (GameScreen.player.myClan != null && myClan.IdClan == GameScreen.player.myClan.IdClan)
			{
				flag = true;
			}
		}
		else if (nameowner.Equals(GameScreen.player.name))
		{
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		paintIconClan(g, x - 1, y - ysai - dy + dyWater - hOne - 20, 2);
		string empty = string.Empty;
		long now = timeLive - mSystem.currentTimeMillis();
		empty = LoadMap.convertSecondsToHMmSs(now);
		if (!empty.Equals(string.Empty))
		{
			mFont.tahoma_7_yellow.drawString(g, empty, x, y - ysai - dy + dyWater - hOne - 40, 3, useClip: false);
		}
		mFont.tahoma_7_yellow.drawString(g, T.level + Lv, x, y - ysai - dy + dyWater - hOne - 55, 3, useClip: false);
		for (int i = 0; i < arr_radian.Length; i++)
		{
			if (fraImgEff != null)
			{
				fraImgEff.drawFrameEffectSkill(fireFrame / 2 % fraImgEff.nFrame, CRes.cos(arr_radian[i]) * r / 1024 + x + 2, CRes.sin(arr_radian[i]) * r / 1024 + y, 0, 3, g);
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
