public class MainMonster : MainObject
{
	public const int MONSTER_MOVE_012 = 0;

	public const int MONSTER_MOVE_01 = 1;

	public const int MONSTER_MOVE_0102 = 2;

	public const int MONSTER_MOVE_FLY_012 = 3;

	public const int MONSTER_MOVE_WATER = 4;

	public const int MONSTER_MOVE_FLY_0102 = 5;

	public const int MONSTER_SEN_CHUA = 6;

	public const int MONSTER_QUEST = 7;

	public const int MONSTER_BO_CHUA = 8;

	public const int MONSTER_BACH_TUOC_TRANG = 9;

	public const int MONSTER_MOVE_FLY_012_SLOW = 10;

	public const int MONSTER_HOUSE = 12;

	public const int MONSTER_BOX = 13;

	public const int MONSTER_VANTIEU = 14;

	public const int MONSTER_MI_NUONG = 15;

	public const int MONSTER_GATE = 16;

	public const int MONSTER_WALK_CAN_NOT_MOVE = 17;

	public const int MONSTER_PAINT_BY_EFFECT_AUTO = 18;

	public const int MONSTER_FLY_CAN_NOT_MOVE = 19;

	public const int MONSTER_Boss_Medusa = 101;

	public const int MONSTER_Boss_DeVang = 83;

	public const int MONSTER_Boss_DeBac = 84;

	public sbyte[][][] mAction;

	public int timeAutoAction;

	public int catalogyMonster;

	public int timeRemove;

	public int limitMove;

	public int limitAttack;

	public int timeFreeFire;

	public int xAnchor;

	public int yAnchor;

	public int xPhoBang;

	public int yPhoBang;

	public int vxDie;

	public int vyDie;

	public int vyStyleDie;

	public int vyStyleStand;

	public new int imageId;

	public static mHashTable HashImageMonster = new mHashTable();

	public static mVector VecCatalogyMonSter = new mVector("MainMonster VecCatalogyMonSter");

	public int MonWater;

	public int frameDie;

	public int timeBienmat;

	public int wAvatar;

	public int hAvatar;

	public int nFrame;

	public int hRegion;

	public int timeMaxMoveAttack;

	public int timeRemoveGhost;

	public long timeBeginMoveAttack;

	public mVector vecObjskill;

	public sbyte loopAtack;

	public string nameowner = string.Empty;

	public static short[] idBossNew = new short[5] { 104, 103, 105, 106, 135 };

	public int count;

	public virtual void setIDeffect(sbyte id)
	{
	}

	public virtual void setLvmonster(int lv)
	{
	}

	public virtual void setPaintCicle(bool b)
	{
	}

	public bool isBossNew()
	{
		for (int i = 0; i < idBossNew.Length; i++)
		{
			if (catalogyMonster == idBossNew[i])
			{
				return true;
			}
		}
		return false;
	}

	public virtual void setTimelive(long time)
	{
	}

	public static void createMonster(int ID, int x, int y, int typeMonster)
	{
		CatalogyMonster catalogyMonster = getCatalogyMonster(typeMonster);
		switch (catalogyMonster.typeMove)
		{
		case 0:
		case 1:
		case 2:
		case 4:
		case 6:
		case 9:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, catalogyMonster.typeMove, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 3:
		case 5:
		case 8:
		case 10:
			GameScreen.addPlayer(new MonsterFly(ID, catalogyMonster.id, catalogyMonster.typeMove, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 7:
			GameScreen.addPlayer(new MonsterQuest(ID, catalogyMonster.id, catalogyMonster.typeMove, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 12:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 12, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 13:
			if (catalogyMonster.id == 110)
			{
				GameScreen.addPlayer(new Monsterplus(ID, catalogyMonster.id, 13, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			}
			else
			{
				GameScreen.addPlayer(new MonsterBox(ID, catalogyMonster.id, 13, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			}
			break;
		case 14:
			GameScreen.addPlayer(new Monstervantieu(ID, catalogyMonster.id, 14, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 15:
			Cout.println("tao mi nuong");
			GameScreen.addPlayer(new Minuong(ID, catalogyMonster.id, 14, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 16:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 16, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 17:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 17, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 19:
			GameScreen.addPlayer(new MonsterFly(ID, catalogyMonster.id, 19, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		case 18:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 18, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		default:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 0, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			break;
		}
	}

	public override void paintAvatarFocus(mGraphics g, int x, int y)
	{
		MainImage imagePartMonster = ObjectData.getImagePartMonster((short)catalogyMonster);
		if (imagePartMonster.img == null)
		{
			return;
		}
		if (wAvatar <= 0)
		{
			if (wOne < 0)
			{
				hOne = mImage.getImageHeight(imagePartMonster.img.image) / nFrame;
				wOne = mImage.getImageWidth(imagePartMonster.img.image);
			}
			wAvatar = wOne;
			hAvatar = hOne;
			if (wAvatar > 26)
			{
				wAvatar = 26;
			}
			if (hAvatar > 26)
			{
				hAvatar = 26;
			}
		}
		g.drawRegion(imagePartMonster.img, wOne / 2 - wAvatar / 2, 0, wAvatar, hAvatar, 0, x, y, 3, mGraphics.isFalse);
	}

	public override void update()
	{
		if (isDie && Action != 4)
		{
			Action = 4;
			timedie = GameCanvas.timeNow;
		}
		if (isServerControl && isMove)
		{
			move_to_XY();
		}
		base.update();
	}

	public override void paint(mGraphics g)
	{
		paintEffauto(g, x, y);
		paintEffauto(g, x, y);
	}

	public virtual void updateAction()
	{
		if (isMoveOut)
		{
			return;
		}
		f++;
		if (f > mAction[Action][(Direction <= 2) ? Direction : 2].Length - 1)
		{
			f = 0;
			if (Action == 3)
			{
				Action = 0;
				vx = 0;
				vy = 0;
			}
			if (Action == 2)
			{
				if (!isBossNew())
				{
					Action = 0;
					vx = 0;
					vy = 0;
				}
				else
				{
					if (loopAtack >= 0)
					{
						loopAtack--;
					}
					if (loopAtack <= 0)
					{
						Action = 0;
						vx = 0;
						vy = 0;
					}
				}
			}
		}
		if (Action == 1 && vx == 0 && vy == 0)
		{
			Action = 0;
			f = 0;
		}
		if (timeFreeFire > 0)
		{
			timeFreeFire--;
		}
		if ((isDie || Action == 4) && (typeBoss == 3 || typeBoss == 4))
		{
			timeRemove++;
			if (timeRemove > 600)
			{
				isRemove = true;
			}
		}
	}

	public static CatalogyMonster getCatalogyMonster(int id)
	{
		for (int i = 0; i < VecCatalogyMonSter.size(); i++)
		{
			CatalogyMonster catalogyMonster = (CatalogyMonster)VecCatalogyMonSter.elementAt(i);
			if (catalogyMonster.id == id)
			{
				return catalogyMonster;
			}
		}
		return null;
	}

	public void auto_Move()
	{
		if (typeBoss == 5 || isMonsterHouse() || isItemBox() || isStun || isBinded || isDongBang || isSleep || isno || isMoveOut)
		{
			return;
		}
		if (typeBoss == 3 || typeBoss == 4)
		{
			toX = xPhoBang;
			toY = yPhoBang;
			move_to_XY();
			if (MainObject.getDistance(x, y, toX, toY) > LoadMap.wTile / 2 || !isMonPhoBangDie)
			{
				return;
			}
			if (typeBoss == 3)
			{
				GameScreen.addEffectEndKill(36, x, y - hOne / 2);
				LoadMap.timeVibrateScreen = 103;
			}
			else if (typeBoss == 4)
			{
				for (int i = 0; i < 3; i++)
				{
					int num = hOne;
					int num2 = wOne;
					if (hOne <= 1)
					{
						num = 40;
					}
					if (num2 <= 1)
					{
						num2 = 40;
					}
					GameScreen.addEffectEndKill(36, x + CRes.random_Am_0(num2 / 2), y - hOne / 2 + CRes.random_Am_0(num / 2));
				}
				LoadMap.timeVibrateScreen = 110;
			}
			isRemove = true;
			isMonPhoBangDie = false;
			return;
		}
		if (MainObject.getDistance(x, y, xAnchor, yAnchor) > limitMove + limitMove / 2)
		{
			if (!MainObject.isInScreen(this) && !setIsInScreen(xAnchor, yAnchor, wOne, hOne))
			{
				x = xAnchor;
				y = yAnchor;
				toX = xAnchor;
				toY = yAnchor;
			}
			else
			{
				toX = xAnchor;
				toY = yAnchor;
				move_to_XY();
			}
			return;
		}
		if (!MainObject.isInScreen(this) && !setIsInScreen(xAnchor, yAnchor, wOne, hOne))
		{
			x = xAnchor;
			y = yAnchor;
			toX = xAnchor;
			toY = yAnchor;
			return;
		}
		time++;
		if (Action == 4)
		{
			return;
		}
		if (timeStand > 0)
		{
			time = 0;
			Action = 0;
			vx = 0;
			vy = 0;
			timeStand--;
		}
		else if (MainObject.getDistance(x + vx, y + vy, GameScreen.player.x, GameScreen.player.y) < 50)
		{
			if (Action == 1)
			{
				if (time > timeAutoAction / 2 || CRes.random(12) == 0 || MainObject.getDistance(x + vx, y + vy, xAnchor, yAnchor) >= limitMove - vMax)
				{
					time = 0;
					Action = 0;
					vx = 0;
					vy = 0;
					if (x > GameScreen.player.x)
					{
						Direction = 2;
					}
					else
					{
						Direction = 3;
					}
				}
			}
			else if (Action == 0 || CRes.random(30) == 0)
			{
				vx = 0;
				vy = 0;
				if (time > timeAutoAction)
				{
					time = 0;
					Action = 1;
					Direction = CRes.random(4);
					setSpeedInDirection(vMax - 2);
				}
				if (x > GameScreen.player.x)
				{
					Direction = 2;
				}
				else
				{
					Direction = 3;
				}
			}
		}
		else if (Action == 1)
		{
			if (time > timeAutoAction || CRes.random(16) == 0 || MainObject.getDistance(x + vx, y + vy, xAnchor, yAnchor) >= limitMove - vMax)
			{
				time = 0;
				Action = 0;
				vx = 0;
				vy = 0;
			}
		}
		else if (Action == 0)
		{
			vx = 0;
			vy = 0;
			if (time > timeAutoAction / 2 || CRes.random(12) == 0)
			{
				time = 0;
				Action = 1;
				Direction = CRes.random(4);
				setSpeedInDirection(vMax);
			}
		}
		if (MainObject.getDistance(x, y, xAnchor, yAnchor) <= limitMove)
		{
			return;
		}
		int num3 = CRes.abs(x - xAnchor);
		int num4 = CRes.abs(y - yAnchor);
		if (num3 > num4)
		{
			if (x > xAnchor)
			{
				Direction = 2;
			}
			else
			{
				Direction = 3;
			}
		}
		else if (y > yAnchor)
		{
			Direction = 1;
		}
		else
		{
			Direction = 0;
		}
		setSpeedInDirection(vMax);
	}

	public void autoMoveFire()
	{
		if (typeBoss == 5)
		{
			return;
		}
		time++;
		if (Action == 4)
		{
			return;
		}
		if (Action == 1)
		{
			if (time <= timeAutoAction && CRes.random(16) != 0)
			{
				return;
			}
			time = 0;
			Action = 0;
			vx = 0;
			vy = 0;
			MainObject mainObject = MainObject.get_Object(IDAttack, 0);
			if (mainObject != null)
			{
				if (x > mainObject.x)
				{
					Direction = 2;
				}
				else
				{
					Direction = 3;
				}
			}
		}
		else if (Action == 0)
		{
			vx = 0;
			vy = 0;
			if (time > timeAutoAction / 2 || CRes.random(12) == 0)
			{
				time = 0;
				Action = 1;
				Direction = CRes.random(4);
				setSpeed(vMax);
			}
		}
	}

	public virtual void Move_to_Focus()
	{
		if (typeBoss == 5 || isBinded || isDongBang)
		{
			return;
		}
		if (vecObjskill != null && vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjskill.elementAt(0);
			if (GameCanvas.timeNow - timeBeginMoveAttack > timeMaxMoveAttack)
			{
				IDAttack = object_Effect_Skill.ID;
				object_Effect_Skill.skillMonster = skillDefault;
				beginFire();
				beginSkill();
				return;
			}
			MainObject mainObject = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
			if (mainObject == null)
			{
				isRunAttack = false;
				return;
			}
			toX = mainObject.x;
			toY = mainObject.y;
			int num = object_Effect_Skill.skillMonster.range;
			if (MainObject.getDistance(x + vx, y + vy, mainObject.x, mainObject.y) <= num)
			{
				IDAttack = object_Effect_Skill.ID;
				beginFire();
				beginSkill();
			}
			else if (CRes.abs(x - toX) >= 4 || CRes.abs(y - toY) >= 4)
			{
				move_to_XY_Normal();
			}
			return;
		}
		MainObject mainObject2 = MainObject.get_Object(IDAttack, 0);
		if (mainObject2 == null)
		{
			isRunAttack = false;
			return;
		}
		toX = mainObject2.x;
		toY = mainObject2.y;
		if (MainObject.getDistance(x + vx, y + vy, mainObject2.x, mainObject2.y) <= limitAttack)
		{
			vx = 0;
			vy = 0;
			Action = 0;
			toX = x;
			toY = y;
			if (CRes.random(30) == 0)
			{
				timeFreeFire = 20;
			}
			if (x > mainObject2.x)
			{
				Direction = 2;
			}
			else
			{
				Direction = 3;
			}
		}
		else if (CRes.abs(x - toX) >= 4 || CRes.abs(y - toY) >= 4)
		{
			move_to_XY_Normal();
		}
	}

	public void Move_To_Player_Skill()
	{
		if (vecObjskill == null || vecObjskill.size() <= 0)
		{
			return;
		}
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjskill.elementAt(0);
		if (GameCanvas.timeNow - timeBeginMoveAttack > timeMaxMoveAttack)
		{
			IDAttack = object_Effect_Skill.ID;
			object_Effect_Skill.skillMonster = skillDefault;
			beginFire();
			beginSkill();
			return;
		}
		MainObject mainObject = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
		if (mainObject == null)
		{
			isRunAttack = false;
			return;
		}
		toX = mainObject.x;
		toY = mainObject.y;
		if (MainObject.getDistance(x + vx, y + vy, mainObject.x, mainObject.y) <= object_Effect_Skill.skillMonster.range)
		{
			IDAttack = object_Effect_Skill.ID;
			beginFire();
			beginSkill();
		}
		else if (CRes.abs(x - toX) >= 4 || CRes.abs(y - toY) >= 4)
		{
			move_to_XY_Normal();
		}
	}

	public void Reveive()
	{
		ReveiceMonster();
		isRunAttack = false;
		resetXY();
		frameDie = 0;
		timeFreeFire = 0;
		timeBienmat = 5;
		f = 0;
		Action = 0;
		time = 0;
		isDie = false;
		vxDie = 0;
		vyDie = 0;
		hp = maxHp;
		vecBuff.removeAllElements();
		vyStyleDie = (vyStyleStand = 0);
	}

	public void setDie()
	{
		if (Action == 4)
		{
			frameDie++;
			if (GameCanvas.gameTick % 10 == 0 && timeReveice >= 0 && isDie && (GameCanvas.timeNow - timedie) / 1000 > timeReveice)
			{
				Reveive();
			}
			if (!isDie)
			{
				x += vxDie;
				y += vyDie;
				if (vyStyleDie > 0)
				{
					vyStyleDie -= 3;
					if (vyStyleDie <= 0 && vyStyleStand > 2)
					{
						vyStyleStand -= 2;
						vyStyleDie = vyStyleStand;
						if (CRes.abs(vxDie) > 1)
						{
							vxDie -= vxDie / CRes.abs(vxDie);
						}
						if (CRes.abs(vyDie) > 1)
						{
							vyDie -= vyDie / CRes.abs(vyDie);
						}
					}
				}
				else
				{
					vxDie >>= 1;
					vyDie >>= 1;
				}
				if (frameDie >= timeBienmat)
				{
					GameScreen.addEffectEndKill(11, x, y - hOne / 4);
					if (!isMonsterHouse() || !isItemBox())
					{
						isDie = true;
					}
					else if (coutEff < -10)
					{
						isDie = true;
					}
				}
			}
			if (!isMonsterHouse() && !isItemBox() && typeMonster != 16)
			{
				return;
			}
			coutEff--;
			if (coutEff <= 0 || timeFreeMove >= 70)
			{
				return;
			}
			timeFreeMove++;
			if (CRes.random(3) == 1)
			{
				if (CRes.random(2) == 1)
				{
					LoadMap.timeVibrateScreen = 103;
				}
				int num = CRes.random(1, 3);
				for (int i = 0; i < num; i++)
				{
					int num2 = CRes.random_Am_0(25);
					int num3 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, x + num2, y + num3 - hOne / 3 + 10);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, x + num2, y + num3 - hOne / 3 + 10);
					}
				}
			}
			if (timeFreeMove < 70)
			{
				return;
			}
			for (int j = 0; j < 6; j++)
			{
				int num4 = CRes.random_Am_0(25);
				int num5 = CRes.random_Am_0(30);
				GameScreen.addEffectEndKill(36, x + num4, y + num5 - hOne / 3 + 10);
				if (CRes.random(3) == 1)
				{
					GameScreen.addEffectEndKill(9, x + num4, y + num5 - hOne / 2 + 10);
				}
			}
			isRemove = true;
		}
		else if (hp <= 0)
		{
			hp = 0;
			Action = 4;
			timedie = GameCanvas.timeNow;
			resetXY();
		}
	}

	public void ReveiceMonster()
	{
		int num = 0;
		if (typeMonster == 7)
		{
			x = xAnchor;
			y = yAnchor;
			return;
		}
		bool flag;
		do
		{
			x = xAnchor + CRes.random_Am_0(48);
			y = yAnchor + CRes.random_Am_0(48);
			int tile = GameCanvas.loadmap.getTile(x, y);
			flag = tile != 1 && tile != -1;
			num++;
			if (num > 15)
			{
				flag = true;
				x = xAnchor;
				y = yAnchor;
			}
		}
		while (!flag);
	}

	public void startDeadFly(int dx, int dy, int time, int vyStyle)
	{
		timedie = GameCanvas.timeNow;
		Action = 4;
		vx = 0;
		vy = 0;
		vxDie = dx;
		vyDie = dy;
		vyStyleDie = vyStyle;
		vyStyleStand = vyStyle;
		timeBienmat = time;
		isDie = false;
		if (isMonsterHouse() || isItemBox() || typeMonster == 16)
		{
			vxDie = 0;
			vyDie = 0;
			vyStyleDie = 0;
			vyStyleStand = 0;
		}
	}

	public void resetV()
	{
		vx = 0;
		vy = 0;
		toX = x;
		toY = y;
	}

	public new void startDie()
	{
		if (vecObjskill != null && vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjskill.elementAt(0);
			object_Effect_Skill.skillMonster = skillDefault;
		}
		beginSkill();
	}

	public void beginSkill()
	{
		if (vecObjskill == null || vecObjskill.size() <= 0)
		{
			return;
		}
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjskill.elementAt(0);
		if (object_Effect_Skill != null && object_Effect_Skill.skillMonster != null)
		{
			if (object_Effect_Skill.skillMonster.typeSkill == 124)
			{
				GameScreen.StartEffect_Chiemthanh(object_Effect_Skill.skillMonster.typeSkill, ID, 1, vecObjskill, object_Effect_Skill.skillMonster.typeSub);
			}
			else
			{
				GameScreen.addEffectKill(object_Effect_Skill.skillMonster.typeSkill, ID, 1, vecObjskill, object_Effect_Skill.skillMonster.typeSub);
			}
		}
		vecObjskill = null;
	}

	public override void beginFire()
	{
		Action = 2;
		loopAtack = (sbyte)CRes.random(3, 5);
		resetAction();
		f = 0;
	}

	public new void addiconClan()
	{
	}

	public new bool canNotMove()
	{
		return typeMonster == 17 || typeMonster == 19 || typeMonster == 18;
	}
}
