using System;

public class Pet : MainMonster
{
	public const sbyte ROAM = 0;

	public const sbyte FOLLOW = 1;

	public const sbyte ATTACK = 2;

	public const sbyte RETURN = 3;

	public const sbyte WAIT = 4;

	public const sbyte DEATH = 5;

	public const sbyte ATTRACTION = 6;

	public const sbyte ATTACK_OWL = 0;

	public const sbyte ATTACK_BAT = 1;

	public const sbyte ATTACK_MELEE = 2;

	public const sbyte ATTACK_POISON_NOVA = 3;

	public const sbyte ATTACK_ICE_NOVA = 4;

	public const sbyte ATTACK_FIRE_BLAST = 5;

	public const sbyte ATTACK_PET_EAGLE = 10;

	public const sbyte ATTACK_TOOL_1 = 11;

	public const sbyte ATTACK_TOOL_2 = 12;

	public const sbyte TYPE_PET_OWL = 0;

	public const sbyte TYPE_PET_BAT = 1;

	public const sbyte TYPE_WALK = 2;

	public const sbyte TYPE_PET_EAGLE = 3;

	public const sbyte TYPE_PET_MONKEY = 4;

	public const sbyte TYPE_MOVE_WALK = 0;

	public const sbyte TYPE_MOVE_FLY = 1;

	public const sbyte TYPE_MOVE_FLY_AND_MOVE = 2;

	public const sbyte TYPE_MOVE_PET_TOOL = 3;

	protected const sbyte DIS_TO_ATTRACT = 80;

	protected const sbyte DIS_TO_FOLLOW = 40;

	public static sbyte[][][] mCupidAnimFrame = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[8] { 1, 1, 1, 1, 2, 2, 2, 2 },
			new sbyte[8] { 1, 1, 1, 1, 2, 2, 2, 2 },
			new sbyte[8] { 1, 1, 1, 1, 2, 2, 2, 2 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 2, 2, 3, 3, 4, 4, 5, 5 },
			new sbyte[8] { 2, 2, 3, 3, 4, 4, 5, 5 },
			new sbyte[8] { 2, 2, 3, 3, 4, 4, 5, 5 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 4, 4, 4, 4, 5, 5, 5, 5 },
			new sbyte[8] { 4, 4, 4, 4, 5, 5, 5, 5 },
			new sbyte[8] { 4, 4, 4, 4, 5, 5, 5, 5 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 }
		}
	};

	public static sbyte[][][] mElfAnimFrame = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 2, 2, 2, 2, 2, 3, 3, 3 },
			new sbyte[8] { 2, 2, 2, 2, 2, 3, 3, 3 },
			new sbyte[8] { 2, 2, 2, 2, 2, 3, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 2, 2, 2, 2, 2, 3, 3, 3 },
			new sbyte[8] { 2, 2, 2, 2, 2, 3, 3, 3 },
			new sbyte[8] { 2, 2, 2, 2, 2, 3, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 }
		}
	};

	public static sbyte[][][] mWoftAnimFrame = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
			new sbyte[8] { 0, 0, 0, 0, 1, 1, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 2, 2, 2, 3, 3, 3, 4, 4 },
			new sbyte[8] { 2, 2, 2, 3, 3, 3, 4, 4 },
			new sbyte[8] { 2, 2, 2, 3, 3, 3, 4, 4 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 },
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 },
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 },
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 },
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 },
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 },
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 }
		}
	};

	public static sbyte[][][] mEagle = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[5] { 1, 1, 1, 1, 1 },
			new sbyte[5] { 1, 1, 1, 1, 1 },
			new sbyte[5] { 1, 1, 1, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[11]
			{
				5, 2, 2, 2, 3, 3, 3, 4, 4, 3,
				3
			},
			new sbyte[7] { 5, 5, 5, 5, 5, 5, 5 },
			new sbyte[7] { 5, 5, 5, 5, 5, 5, 5 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 },
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 },
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 }
		}
	};

	public static sbyte[][][] mBat = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[9] { 2, 2, 2, 3, 3, 3, 4, 4, 3 },
			new sbyte[9] { 2, 2, 2, 3, 3, 3, 4, 4, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 },
			new sbyte[6] { 5, 5, 5, 5, 5, 5 },
			new sbyte[6] { 5, 5, 5, 5, 5, 5 }
		},
		new sbyte[3][]
		{
			new sbyte[6] { 5, 5, 5, 5, 5, 5 },
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 },
			new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 },
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 },
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 }
		}
	};

	public static sbyte[][][] mOwl = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[5] { 1, 1, 1, 1, 1 },
			new sbyte[5] { 1, 1, 1, 1, 1 },
			new sbyte[5] { 1, 1, 1, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 },
			new sbyte[10] { 2, 2, 2, 3, 3, 3, 4, 4, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[11]
			{
				5, 2, 2, 2, 3, 3, 3, 4, 4, 3,
				3
			},
			new sbyte[7] { 5, 5, 5, 5, 5, 5, 5 },
			new sbyte[7] { 5, 5, 5, 5, 5, 5, 5 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 },
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 },
			new sbyte[8] { 6, 6, 6, 6, 6, 6, 6, 6 }
		}
	};

	protected Point[] posArray = new Point[6]
	{
		new Point(13 * LoadMap.wTile, 12 * LoadMap.wTile),
		new Point(11 * LoadMap.wTile, 21 * LoadMap.wTile),
		new Point(22 * LoadMap.wTile, 20 * LoadMap.wTile),
		new Point(23 * LoadMap.wTile, 16 * LoadMap.wTile),
		new Point(16 * LoadMap.wTile, 14 * LoadMap.wTile),
		new Point(13 * LoadMap.wTile, 22 * LoadMap.wTile)
	};

	protected bool isSequenceAttack;

	protected bool isDoneAttack;

	protected short type;

	protected new sbyte imageId;

	protected sbyte state;

	protected sbyte preState;

	protected sbyte attackType;

	protected int attackCount;

	protected int oldPosX;

	protected int oldPosY;

	protected int ownerX;

	protected int ownerY;

	public int xtam;

	public int vatam = 6;

	public short yfly;

	protected mVector wayPoint = new mVector("Pet wayPoint");

	protected MainObject owner;

	public sbyte typemove;

	public static sbyte[] mTypemove = new sbyte[6] { 2, 1, 0, 2, 0, 1 };

	public static mHashTable HashImagePet = new mHashTable();

	public bool isPetTool;

	public static mHashTable PET_DATA = new mHashTable();

	public Pet()
	{
	}

	public Pet(short typePet, sbyte nFrame, sbyte imageId, sbyte typemove)
	{
		base.nFrame = nFrame;
		type = typePet;
		this.imageId = imageId;
		isDoneAttack = false;
		ListKillNow = new ListSkill();
		this.typemove = typemove;
		setAnim();
	}

	public static Pet createPet(short type, int id, sbyte nFrame, sbyte imageId)
	{
		Pet result = null;
		sbyte b = 0;
		b = mTypemove[type];
		switch (b)
		{
		case 0:
			result = new PetWalk(type, id, nFrame, imageId, b);
			break;
		case 1:
		case 2:
			result = new PetFly(type, id, nFrame, imageId, b);
			break;
		case 3:
			result = new PetTool(type, id, nFrame, imageId, b);
			break;
		}
		return result;
	}

	public static Pet createPet(MainObject owner, short type, sbyte nFrame, sbyte imageId)
	{
		Pet result = null;
		sbyte b = 0;
		b = mTypemove[type];
		switch (b)
		{
		case 0:
			result = new PetWalk(owner, type, nFrame, imageId, b);
			break;
		case 1:
		case 2:
			result = new PetFly(owner, type, nFrame, imageId, b);
			break;
		case 3:
			result = new PetTool(owner, type, nFrame, imageId, b);
			break;
		}
		return result;
	}

	public void setAnim()
	{
		switch (typemove)
		{
		case 0:
			mAction = mWoftAnimFrame;
			break;
		case 1:
			mAction = mBat;
			break;
		case 2:
			mAction = mOwl;
			break;
		}
	}

	public void clearWayPoints()
	{
		wayPoint.removeAllElements();
	}

	public void setState(sbyte state)
	{
		this.state = state;
	}

	protected virtual void roam()
	{
		vMax = 1;
		if (Action == 1)
		{
			if (time > timeAutoAction || CRes.random(16) == 0 || MainObject.getDistance(x + vx, y + vy, xAnchor, yAnchor) >= limitMove)
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
		if (owner == null)
		{
			return;
		}
		if (owner.Action == 1)
		{
			if (MainObject.getDistance(x, y, ownerX, ownerY) > 40)
			{
				setState(1);
			}
			if (owner.Action == 0 && MainObject.getDistance(x, y, ownerX, ownerY) > limitMove * 2)
			{
				setState(3);
			}
		}
		else
		{
			int distance = MainObject.getDistance(x, y, GameScreen.player.x, GameScreen.player.y);
			if (distance < 80 && distance > 40 && CRes.random(6) == 0)
			{
				setState(6);
			}
		}
	}

	protected void standStill()
	{
		vx = 0;
		vy = 0;
		Action = 4;
		if (owner != null && owner.Action == 0)
		{
			setState(0);
		}
	}

	protected virtual void follow()
	{
		vMax = owner.vMax;
		Action = 1;
		if (MainObject.getDistance(oldPosX, oldPosY, ownerX, ownerY) > 40)
		{
			Point o = new Point(ownerX, ownerY);
			oldPosX = ownerX;
			oldPosY = ownerY;
			wayPoint.addElement(o);
		}
		else if (MainObject.getDistance(x, y, xAnchor, yAnchor) < 40)
		{
			wayPoint.removeAllElements();
			setState(4);
		}
		if (wayPoint.elementAt(0) != null)
		{
			toX = ((Point)wayPoint.elementAt(0)).x;
			toY = ((Point)wayPoint.elementAt(0)).y;
			move_to_XY();
		}
	}

	public override void move_to_XY()
	{
		base.move_to_XY();
		if (state != 3 && (owner.Direction == 1 || owner.Direction == 0) && !isPetTool)
		{
			xtam += vatam;
			if (vatam > 0)
			{
				Direction = 3;
			}
			if (vatam < 0)
			{
				Direction = 2;
			}
			if ((xtam + vatam >= 48 && vatam > 0) || (xtam + vatam < -48 && vatam < 0))
			{
				vatam *= -1;
			}
		}
	}

	public void initAttackState(sbyte skillId)
	{
		try
		{
			attackType = skillId;
			isRunAttack = true;
			timeBeginMoveAttack = GameCanvas.timeNow;
			attackCount = 0;
			isSequenceAttack = false;
		}
		catch (Exception)
		{
		}
	}

	protected virtual void attack()
	{
		if (isSequenceAttack)
		{
			if (attackCount == 3)
			{
				isDoneAttack = false;
				setState(4);
				attackCount = 0;
			}
		}
		else if (isDoneAttack)
		{
			isDoneAttack = false;
			setState(4);
		}
	}

	protected virtual void returnToPlayer()
	{
		vMax = owner.vMax;
		toX = owner.x;
		toY = owner.y;
		move_to_XY();
		if (MainObject.getDistance(x, y, xAnchor, yAnchor) < 40 && owner.Action != 2)
		{
			setState(0);
		}
	}

	protected void waitForCommand()
	{
		vx = 0;
		vy = 0;
		if (typemove == 1 || typemove == 2)
		{
			Action = 1;
		}
		else
		{
			Action = 0;
		}
		if (owner != null)
		{
			if (owner.Action == 0)
			{
				wayPoint.removeAllElements();
				setState(0);
			}
			else if (owner.Action == 1 && MainObject.getDistance(x, y, xAnchor, yAnchor) > 40)
			{
				wayPoint.removeAllElements();
				setState(1);
			}
		}
	}

	public void addAttackEffect()
	{
		if (vecObjskill == null || vecObjskill.size() <= 0)
		{
			return;
		}
		switch (attackType)
		{
		case 0:
		{
			GameScreen.addEffectEndKill(10, x, y);
			for (int j = 0; j < vecObjskill.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)vecObjskill.elementAt(j);
				MainObject mainObject2 = MainObject.get_Object(object_Effect_Skill2.ID, object_Effect_Skill2.tem);
				if (mainObject2 != null && object_Effect_Skill2.hpShow > 0)
				{
					GameScreen.addEffectNum("-" + object_Effect_Skill2.hpShow, mainObject2.x, mainObject2.y - mainObject2.hOne, 0, owner.ID);
				}
				mVector mVector3 = new mVector("Pet target");
				mVector3.addElement(object_Effect_Skill2);
				GameScreen.addEffectKill(89, owner.ID, owner.typeObject, mVector3);
			}
			attackCount++;
			break;
		}
		case 1:
		{
			GameScreen.addEffectEndKill(51, x, y - 8);
			for (int k = 0; k < vecObjskill.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)vecObjskill.elementAt(k);
				MainObject mainObject3 = MainObject.get_Object(object_Effect_Skill3.ID, object_Effect_Skill3.tem);
				if (mainObject3 != null && object_Effect_Skill3.hpShow > 0)
				{
					GameScreen.addEffectNum("-" + object_Effect_Skill3.hpShow, mainObject3.x, mainObject3.y - mainObject3.hOne, 0, owner.ID);
				}
				mVector mVector4 = new mVector("Pet target2");
				mVector4.addElement(object_Effect_Skill3);
				GameScreen.addEffectKill(92, owner.ID, owner.typeObject, mVector4);
			}
			attackCount++;
			break;
		}
		case 2:
			GameScreen.addEffectKill(50, ID, 9, vecObjskill);
			attackCount++;
			break;
		case 3:
			GameScreen.addEffectKill(91, ID, typeObject, vecObjskill);
			attackCount++;
			break;
		case 4:
			GameScreen.addEffectKill(90, ID, typeObject, vecObjskill);
			attackCount++;
			break;
		case 5:
			GameScreen.addEffectKill(81, x, y - 20, 200, 0, 0);
			attackCount++;
			break;
		case 10:
		{
			for (int i = 0; i < vecObjskill.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjskill.elementAt(i);
				MainObject mainObject = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
				if (mainObject != null && object_Effect_Skill.hpShow > 0)
				{
					GameScreen.addEffectNum("-" + object_Effect_Skill.hpShow, mainObject.x, mainObject.y - mainObject.hOne, 0, owner.ID);
				}
			}
			break;
		}
		case 6:
		case 7:
		case 8:
		case 9:
			break;
		}
	}

	private void attract()
	{
		vMax = 3;
		Action = 1;
		toX = GameScreen.player.x;
		toY = GameScreen.player.y;
		move_to_XY();
		if (MainObject.getDistance(x, y, toX, toY) < 40)
		{
			setState(0);
		}
	}

	private void updatePetAction()
	{
		f++;
		if (f > mAction[Action][(Direction <= 2) ? Direction : 2].Length - 1)
		{
			f = 0;
			if (Action == 3 || Action == 2)
			{
				Action = 0;
				vx = 0;
				vy = 0;
				isDoneAttack = true;
			}
		}
	}

	public override void update()
	{
		try
		{
			base.update();
			updatePetAction();
			int tile = GameCanvas.loadmap.getTile(x + vx, y + vy);
			setMove(MonWater, tile);
			if (owner != null)
			{
				if (MainObject.getDistance(x, y, toX, toY) <= 10)
				{
					wayPoint.removeElementAt(0);
				}
				xAnchor = owner.x;
				yAnchor = owner.y;
				ownerX = owner.x;
				ownerY = owner.y;
			}
			time++;
			if ((typemove == 1 || typemove == 2) && Action != 0 && yfly < 50)
			{
				yfly += 3;
			}
			switch (state)
			{
			case 0:
				roam();
				break;
			case 1:
				follow();
				break;
			case 2:
				attack();
				break;
			case 3:
				returnToPlayer();
				break;
			case 4:
				waitForCommand();
				break;
			case 6:
				attract();
				break;
			}
			if (state != preState)
			{
				preState = state;
			}
		}
		catch (Exception)
		{
		}
	}

	public override bool findOwner(MainObject ownerP)
	{
		return owner.Equals(ownerP);
	}

	public static void setDataPet(sbyte[] data, int id, int idImg)
	{
		DataEffect dataEffect = new DataEffect(data, idImg, isMonster: true);
		dataEffect.name = "QUAI THU: " + id;
		mVector mVector3 = new mVector();
		mVector3.addElement(dataEffect);
		PET_DATA.put(string.Empty + id, mVector3);
	}
}
