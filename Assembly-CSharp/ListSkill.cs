public class ListSkill : MainListSkill
{
	private MainObject obj;

	private MainObject objBeKill;

	private int skill;

	private int plash;

	private int frame;

	private int index;

	private mVector vecObjBeKill;

	public sbyte classbuff = -1;

	public sbyte typebuff;

	public static short GlobalCountdown;

	public static long lastTime;

	public static long lastTimeAttack;

	public static int limitTimeAtt = 600;

	public void setFireSkill(MainObject obj, mVector vec, int IndexSkill, sbyte classBuff)
	{
		if (vec == null || vec.size() <= 0 || IndexSkill > MainListSkill.mSkillAllClasses[obj.clazz].Length - 1)
		{
			return;
		}
		classbuff = classBuff;
		this.obj = obj;
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(0);
		objBeKill = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
		vecObjBeKill = vec;
		if (this.obj == null || this.obj.Action == 4 || objBeKill == null || objBeKill.Action == 4)
		{
			obj.KillFire = -1;
			obj.IDAttack = -1;
			obj.vecObjFocusSkill = null;
			return;
		}
		if (obj.typeObject == 9)
		{
			skill = MainListSkill.mSkillAllClasses[6][IndexSkill];
		}
		else
		{
			skill = MainListSkill.mSkillAllClasses[obj.clazz][IndexSkill];
		}
		index = IndexSkill;
		obj.KillFire = IndexSkill;
		plash = MainListSkill.mPlash[skill];
		frame = MainListSkill.mFramePlash[skill];
		if (obj.clazz == 3)
		{
			plash /= 2;
			frame /= 2;
		}
		if (obj == GameScreen.player)
		{
			FireSkill(MainListSkill.getRange(IndexSkill));
		}
		else
		{
			FireSkill(MainListSkill.mRange[skill]);
		}
	}

	public void setVecBeKill(mVector vec)
	{
		vecObjBeKill = vec;
	}

	public void FireSkill(int range)
	{
		int distance = MainObject.getDistance(obj.x, obj.y, objBeKill.x, objBeKill.y - objBeKill.hOne / 4);
		if (distance <= range || obj.typeObject == 9)
		{
			if (obj == GameScreen.player && !setMove_Skill())
			{
				return;
			}
			obj.toX = obj.x;
			obj.toY = obj.y;
			obj.vx = 0;
			obj.vy = 0;
			if (obj.typeObject != 9)
			{
				obj.beginFire();
				obj.PlashNow.setPlash(plash);
				obj.KillFire = -1;
				if (skill == 53)
				{
					obj.Direction = 1;
				}
				else
				{
					obj.Direction = setDirection(obj, objBeKill);
				}
				setEff_More();
			}
			return;
		}
		int num = CRes.angle(obj.x - objBeKill.x, obj.y - objBeKill.y);
		int num2 = 0;
		int num3;
		int num4;
		int tile;
		do
		{
			num3 = objBeKill.x + CRes.cos(CRes.fixangle(num % 360)) * (range - 5) / 1000;
			num4 = objBeKill.y + CRes.sin(CRes.fixangle(num % 360)) * (range - 5) / 1000;
			tile = GameCanvas.loadmap.getTile(num3, num4);
			num += CRes.random_Am_0(90);
			num2++;
			if (num2 > 12)
			{
				tile = 0;
				obj.posTransRoad = null;
				GameCanvas.addInfoChar(T.farfocus);
				obj.KillFire = -1;
				obj.IDAttack = -1;
				obj.vecObjFocusSkill = null;
				setGoBack();
				return;
			}
		}
		while (tile == -1 || tile == 1);
		if (obj == GameScreen.player)
		{
			obj.toX = obj.x;
			obj.toY = obj.y;
			GameScreen.player.xStopMove = 0;
			GameScreen.player.yStopMove = 0;
			obj.posTransRoad = GameCanvas.game.updateFindRoad(num3 / LoadMap.wTile, num4 / LoadMap.wTile, obj.x / LoadMap.wTile, obj.y / LoadMap.wTile, 12);
			Player.xFocus = -1;
			Player.yFocus = -1;
			if (obj.posTransRoad == null)
			{
				obj.toX = num3;
				obj.toY = num4;
				obj.xFire = num3;
				obj.yFire = num4;
				obj.posTransRoad = null;
			}
			else if (obj.posTransRoad.Length > 12)
			{
				obj.posTransRoad = null;
				GameCanvas.addInfoChar(T.farfocus);
				setGoBack();
				obj.KillFire = -1;
				obj.IDAttack = -1;
				obj.vecObjFocusSkill = null;
			}
			else
			{
				obj.xFire = num3;
				obj.yFire = num4;
				GameScreen.player.xStopMove = obj.xFire;
				GameScreen.player.yStopMove = obj.yFire;
			}
			obj.countAutoMove = 0;
		}
		else
		{
			obj.toX = num3;
			obj.xFire = num3;
			obj.toY = num4;
			obj.yFire = num4;
		}
		if (obj.typeObject == 1)
		{
			obj.IDAttack = objBeKill.ID;
		}
		else
		{
			obj.vecObjFocusSkill = vecObjBeKill;
		}
	}

	public void setGoBack()
	{
		if (obj == GameScreen.player && Player.isAutoFire == 1 && Player.isCurAutoFire)
		{
			objBeKill.isSend = true;
			obj.toX = obj.x;
			obj.toY = obj.y;
			obj.xStopMove = Player.xBeginAutoFire;
			obj.yStopMove = Player.yBeginAutofire;
			obj.posTransRoad = GameCanvas.game.updateFindRoad(obj.xStopMove / LoadMap.wTile, obj.yStopMove / LoadMap.wTile, obj.x / LoadMap.wTile, obj.y / LoadMap.wTile, 20);
			Player.xFocus = -1;
			Player.yFocus = -1;
			if (obj.posTransRoad != null && obj.posTransRoad.Length > 20)
			{
				obj.posTransRoad = null;
			}
		}
	}

	public void fireSkillFree()
	{
		if (obj == null || objBeKill == null)
		{
			obj.KillFire = -1;
			obj.IDAttack = -1;
			obj.vecObjFocusSkill = null;
		}
		else if (obj != GameScreen.player || setMove_Skill())
		{
			obj.toX = obj.x;
			obj.toY = obj.y;
			obj.vx = 0;
			obj.vy = 0;
			obj.beginFire();
			obj.PlashNow.setPlash(plash);
			obj.KillFire = -1;
			if (skill == 53)
			{
				obj.Direction = 1;
			}
			else
			{
				obj.Direction = setDirection(obj, objBeKill);
			}
			setEff_More();
		}
	}

	public void updateEffSkill()
	{
		if (obj == null || objBeKill == null)
		{
			obj.KillFire = -1;
			obj.IDAttack = -1;
			obj.vecObjFocusSkill = null;
		}
		else if (obj.typeObject == 9)
		{
			if (classbuff > -1)
			{
				GameScreen.addEffectKillSubTime(MainListSkill.mEffectKill[skill], obj.ID, obj.typeObject, vecObjBeKill, (sbyte)MainListSkill.mBuffAllClasses[classbuff][index], 500);
				Pet pet = (Pet)obj;
				pet.setState(4);
			}
		}
		else
		{
			if (obj.fplash != frame)
			{
				return;
			}
			if (obj == GameScreen.player)
			{
				Skill skillFormId = MainListSkill.getSkillFormId(index);
				long num = GameCanvas.timeNow - lastTime;
				if (num > GlobalCountdown)
				{
					GlobalCountdown = skillFormId.performDur;
					lastTime = GameCanvas.timeNow;
					sendSkill();
				}
			}
			if (classbuff > -1)
			{
				GameScreen.addEffectKillSubTime(MainListSkill.mEffectKill[skill], obj.ID, obj.typeObject, vecObjBeKill, (sbyte)MainListSkill.mBuffAllClasses[classbuff][index], 1250);
			}
			else
			{
				GameScreen.addEffectKill(MainListSkill.mEffectKill[skill], obj.ID, obj.typeObject, vecObjBeKill);
			}
		}
	}

	public void setEff_More()
	{
		if (obj == GameScreen.player)
		{
			GameScreen.player.setAddDelaySkill(skill, index);
		}
		switch (skill)
		{
		case 23:
		case 41:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 300, 0);
			break;
		case 22:
		case 36:
		case 44:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 300, 3);
			break;
		case 20:
		case 46:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 300, 4);
			break;
		case 18:
		case 19:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 300, 1);
			break;
		case 5:
		case 21:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 400, 0);
			break;
		case 27:
		case 37:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 400, 3);
			break;
		case 39:
		case 51:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 400, 4);
			break;
		case 24:
		case 40:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 400, 1);
			break;
		case 42:
		case 43:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 600, 0);
			break;
		case 14:
		case 34:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 600, 3);
			break;
		case 6:
		case 47:
		case 48:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 600, 4);
			break;
		case 49:
		case 50:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 400, 1);
			break;
		case 52:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 600, 1);
			break;
		case 53:
			GameScreen.addEffectKillTime(30, obj.ID, obj.typeObject, vecObjBeKill, 600, 1);
			break;
		case 56:
		case 61:
		case 62:
		case 66:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 300, 4);
			break;
		case 54:
		case 58:
		case 64:
		case 68:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 600, 0);
			break;
		case 55:
		case 59:
		case 65:
		case 69:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 600, 3);
			break;
		case 57:
		case 60:
		case 63:
		case 67:
			GameScreen.addEffectKillTime(29, obj.ID, obj.typeObject, vecObjBeKill, 400, 1);
			break;
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 15:
		case 16:
		case 17:
		case 25:
		case 26:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 35:
		case 38:
		case 45:
			break;
		}
	}

	public bool setMove_Skill()
	{
		int num = skill;
		return true;
	}

	public bool setMove(int x, int xend, int y, int yend)
	{
		short[] array = GameScreen.gI().updateFindRoad(xend / LoadMap.wTile, yend / LoadMap.wTile, x / LoadMap.wTile, y / LoadMap.wTile, 12);
		if (array == null)
		{
			int tile = GameCanvas.loadmap.getTile(xend, yend);
			if (tile != -1 && tile != 1)
			{
				return setSendMove(x, xend, y, yend);
			}
			GameCanvas.addInfoChar(T.farfocus);
			setGoBack();
			obj.KillFire = -1;
			obj.IDAttack = -1;
			obj.vecObjFocusSkill = null;
			return false;
		}
		if (array.Length > 12)
		{
			GameCanvas.addInfoChar(T.farfocus);
			setGoBack();
			obj.KillFire = -1;
			obj.IDAttack = -1;
			obj.vecObjFocusSkill = null;
			return false;
		}
		return true;
	}

	public bool setSendMove(int x, int xend, int y, int yend)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = CRes.abs(x - xend);
		int num7 = CRes.abs(y - yend);
		if (num6 >= 4)
		{
			num = ((x <= xend) ? 6 : (-6));
		}
		if (num7 >= 4)
		{
			num2 = ((y <= yend) ? 6 : (-6));
		}
		num3 = num6 / 6;
		num4 = num7 / 6;
		num5 = ((num6 <= num7) ? num4 : num3);
		for (int i = 0; i < num5; i++)
		{
			if (i < num3)
			{
				x += num;
			}
			if (i < num4)
			{
				y += num2;
			}
			int tile = GameCanvas.loadmap.getTile(x, y);
			if (tile == 1 || tile == -1)
			{
				GameCanvas.addInfoChar(T.farfocus);
				setGoBack();
				obj.KillFire = -1;
				obj.IDAttack = -1;
				return false;
			}
		}
		return true;
	}

	public static void doSetTimeAtt()
	{
		lastTimeAttack = mSystem.currentTimeMillis();
	}

	public static bool canAttack()
	{
		long num = mSystem.currentTimeMillis();
		long num2 = num - lastTimeAttack;
		return num2 > limitTimeAtt;
	}

	public void sendSkill()
	{
		mVector mVector3 = (vecObjBeKill = GameScreen.player.setSkillLan(index, objBeKill));
		if (classbuff > -1)
		{
			setSendBuff(mVector3);
		}
		else if (objBeKill.typeObject == 1)
		{
			GlobalService.gI().fire_monster(mVector3, (sbyte)index);
		}
		else if (objBeKill.typeObject == 0)
		{
			GlobalService.gI().fire_Pk(mVector3, (sbyte)index);
		}
	}

	public void setSendBuff(mVector vec)
	{
		GlobalService.gI().BuffMore((sbyte)index, objBeKill.typeObject, vec);
	}

	public bool setBuff(int type)
	{
		for (int i = 0; i < obj.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)obj.vecBuff.elementAt(i);
			if (mainBuff.typeBuff == type)
			{
				return false;
			}
		}
		return true;
	}
}
