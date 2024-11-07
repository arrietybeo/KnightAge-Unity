using System;
using UnityEngine;

public class MonsterWalk : MainMonster
{
	private static sbyte[][][] mMon0102 = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[8],
			new sbyte[8],
			new sbyte[8]
		},
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 1, 1, 0, 0, 2, 2 },
			new sbyte[8] { 1, 1, 0, 0, 2, 2, 0, 0 },
			new sbyte[8] { 2, 2, 0, 0, 1, 1, 0, 0 }
		},
		new sbyte[3][]
		{
			new sbyte[6] { 2, 2, 2, 3, 3, 3 },
			new sbyte[6] { 2, 2, 2, 3, 3, 3 },
			new sbyte[6] { 2, 2, 2, 3, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 4, 4, 4, 4, 4, 4, 4, 4 },
			new sbyte[8] { 4, 4, 4, 4, 4, 4, 4, 4 },
			new sbyte[8] { 4, 4, 4, 4, 4, 4, 4, 4 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 4, 4, 4, 4, 4, 4, 4, 4 },
			new sbyte[8] { 4, 4, 4, 4, 4, 4, 4, 4 },
			new sbyte[8] { 4, 4, 4, 4, 4, 4, 4, 4 }
		}
	};

	private static sbyte[][][] mMon012 = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[6],
			new sbyte[6],
			new sbyte[6]
		},
		new sbyte[3][]
		{
			new sbyte[6] { 0, 0, 1, 1, 2, 2 },
			new sbyte[6] { 1, 1, 0, 0, 2, 2 },
			new sbyte[6] { 2, 2, 0, 0, 1, 1 }
		},
		new sbyte[3][]
		{
			new sbyte[6] { 2, 2, 2, 3, 3, 3 },
			new sbyte[6] { 2, 2, 2, 3, 3, 3 },
			new sbyte[6] { 2, 2, 2, 3, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[6] { 4, 4, 4, 4, 4, 4 },
			new sbyte[6] { 4, 4, 4, 4, 4, 4 },
			new sbyte[6] { 4, 4, 4, 4, 4, 4 }
		},
		new sbyte[3][]
		{
			new sbyte[6] { 4, 4, 4, 4, 4, 4 },
			new sbyte[6] { 4, 4, 4, 4, 4, 4 },
			new sbyte[6] { 4, 4, 4, 4, 4, 4 }
		}
	};

	private static sbyte[][][] mMon01 = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[6],
			new sbyte[6],
			new sbyte[6]
		},
		new sbyte[3][]
		{
			new sbyte[6] { 1, 1, 1, 0, 0, 0 },
			new sbyte[6] { 1, 1, 1, 0, 0, 0 },
			new sbyte[6] { 1, 1, 1, 0, 0, 0 }
		},
		new sbyte[3][]
		{
			new sbyte[6] { 2, 2, 2, 3, 3, 3 },
			new sbyte[6] { 2, 2, 2, 3, 3, 3 },
			new sbyte[6] { 2, 2, 2, 3, 3, 3 }
		},
		new sbyte[3][]
		{
			new sbyte[6] { 4, 4, 4, 4, 4, 4 },
			new sbyte[6] { 4, 4, 4, 4, 4, 4 },
			new sbyte[6] { 4, 4, 4, 4, 4, 4 }
		},
		new sbyte[3][]
		{
			new sbyte[6] { 4, 4, 4, 4, 4, 4 },
			new sbyte[6] { 4, 4, 4, 4, 4, 4 },
			new sbyte[6] { 4, 4, 4, 4, 4, 4 }
		}
	};

	private static sbyte[][][] mMonBossMesdusa = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[12],
			new sbyte[12],
			new sbyte[12]
		},
		new sbyte[3][]
		{
			new sbyte[12]
			{
				0, 0, 0, 0, 1, 1, 1, 1, 2, 2,
				2, 2
			},
			new sbyte[12]
			{
				1, 1, 1, 1, 0, 0, 0, 0, 2, 2,
				2, 2
			},
			new sbyte[12]
			{
				2, 2, 2, 2, 0, 0, 0, 0, 1, 1,
				1, 1
			}
		},
		new sbyte[3][]
		{
			new sbyte[12]
			{
				2, 2, 2, 2, 2, 2, 3, 3, 3, 3,
				3, 3
			},
			new sbyte[12]
			{
				2, 2, 2, 2, 2, 2, 3, 3, 3, 3,
				3, 3
			},
			new sbyte[12]
			{
				2, 2, 2, 2, 2, 2, 3, 3, 3, 3,
				3, 3
			}
		},
		new sbyte[3][]
		{
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			}
		},
		new sbyte[3][]
		{
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			}
		}
	};

	private static sbyte[][][] mMonschiemthanh = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[12]
			{
				4, 4, 4, 4, 5, 5, 5, 5, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 5, 5, 5, 5, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 5, 5, 5, 5, 4, 4,
				4, 4
			}
		},
		new sbyte[3][]
		{
			new sbyte[12]
			{
				0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
				3, 3
			},
			new sbyte[12]
			{
				0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
				3, 3
			},
			new sbyte[12]
			{
				0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
				3, 3
			}
		},
		new sbyte[3][]
		{
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			}
		},
		new sbyte[3][]
		{
			new sbyte[12]
			{
				4, 4, 4, 4, 5, 5, 5, 5, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 5, 5, 5, 5, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 5, 5, 5, 5, 4, 4,
				4, 4
			}
		},
		new sbyte[3][]
		{
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			},
			new sbyte[12]
			{
				4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
				4, 4
			}
		}
	};

	public MonsterWalk(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
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
		switch (typeMonster)
		{
		case 17:
			mAction = mMonschiemthanh;
			break;
		case 0:
			if (!isMoveSlow(catalogyMonster))
			{
				mAction = mMon012;
			}
			else
			{
				mAction = mMonBossMesdusa;
			}
			break;
		case 2:
			mAction = mMon0102;
			break;
		case 1:
			mAction = mMon01;
			break;
		case 4:
			MonWater = 0;
			mAction = mMon012;
			break;
		case 6:
			limitAttack = 80;
			mAction = mMon012;
			break;
		case 9:
			MonWater = 0;
			mAction = mMon012;
			limitAttack = 80;
			break;
		case 12:
		case 16:
		case 18:
			mAction = new sbyte[5][][]
			{
				new sbyte[3][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				},
				new sbyte[3][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				},
				new sbyte[3][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				},
				new sbyte[3][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				},
				new sbyte[3][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				}
			};
			nFrame = 1;
			break;
		}
		timeLoadInfo = mSystem.currentTimeMillis();
	}

	public override bool isMonsterHouse()
	{
		return typeMonster == 12;
	}

	public bool isMonsterGate()
	{
		return typeMonster == 16;
	}

	public override bool isItemBox()
	{
		return typeMonster == 13;
	}

	public override void paint(mGraphics g)
	{
		try
		{
			if ((StepMovebocap == 1 && catalogyMonster == 103) || typeMonster == 18 || isDie)
			{
				return;
			}
			paintBuffFirst(g);
			MainImage imagePartMonster = ObjectData.getImagePartMonster((short)catalogyMonster);
			int num = Action;
			if (num > mAction.Length - 1)
			{
				num = 0;
			}
			if (f > mAction[num][(Direction <= 2) ? Direction : 2].Length - 1)
			{
				f = 0;
			}
			if (imagePartMonster.img != null)
			{
				if (wOne < 0)
				{
					if (catalogyMonster <= 92 || typeMonster == 16)
					{
						hOne = mImage.getImageHeight(imagePartMonster.img.image) / nFrame;
						wOne = mImage.getImageWidth(imagePartMonster.img.image);
					}
					else
					{
						hOne = mImage.getImageHeight(imagePartMonster.img.image) / 3;
						wOne = mImage.getImageWidth(imagePartMonster.img.image) / 2;
					}
				}
				int x = 0;
				int y = mAction[num][(Direction <= 2) ? Direction : 2][f] * hOne;
				if (catalogyMonster > 92)
				{
					x = mAction[num][(Direction <= 2) ? Direction : 2][f] / 3 * wOne;
					y = mAction[num][(Direction <= 2) ? Direction : 2][f] % 3 * hOne;
				}
				paintDataEff_Top(g, base.x, base.y);
				paintEffauto_Low(g, base.x, base.y);
				if (isMonsterHouse())
				{
					Direction = 0;
					g.drawRegion(imagePartMonster.img, x, y, wOne, hOne, (Direction > 2) ? 2 : 0, base.x, base.y - dy + dyWater - vyStyleDie, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
				}
				else
				{
					g.drawRegion(imagePartMonster.img, x, y, wOne, hOne, (Direction > 2) ? 2 : 0, base.x, base.y - dy + dyWater - vyStyleDie, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
				}
				if (isWater && dy == 0)
				{
					int num2 = 1;
					g.drawRegion(MainObject.water, 0, ((num != 0) ? 2 : 0) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, base.x + num2, base.y + dyWater - 4, 3, mGraphics.isFalse);
				}
				canFocusMon = true;
			}
			else
			{
				canFocusMon = false;
			}
			paintIconClan(g, base.x - 1, base.y - ysai - dy + dyWater - hOne - 20, 2);
			paintBuffLast(g);
			paintDataEff_Bot(g, base.x, base.y);
			base.paint(g);
		}
		catch (Exception ex)
		{
			Debug.LogWarning("loi ham paint monster " + ex.ToString());
		}
	}

	public void checkcollide()
	{
		if (!isBossNew() || (GameScreen.player.vx == 0 && GameScreen.player.vy == 0) || GameScreen.player.moveToBoss)
		{
			GameScreen.player.moveToBoss = false;
		}
		else if (CRes.ktvc(x - wOne / 3, x + wOne / 3, GameScreen.player.x - GameScreen.player.wOne / 3, GameScreen.player.x + GameScreen.player.wOne / 3, y - hOne, y - hOne / 3, GameScreen.player.y - GameScreen.player.hOne, GameScreen.player.y - GameScreen.player.hOne / 3))
		{
			if (GameScreen.player.Action == 1 && !GameScreen.player.moveToBoss)
			{
				GameScreen.player.moveToBoss = true;
			}
		}
		else
		{
			GameScreen.player.moveToBoss = false;
		}
	}

	public override void Move_to_Focus()
	{
		if ((isMove && catalogyMonster == 103) || typeBoss == 5 || isBinded || isDongBang)
		{
			return;
		}
		if (isServerControl)
		{
			MainObject mainObject = MainObject.get_Object(IDAttack, 0);
			if (mainObject == null)
			{
				isRunAttack = false;
			}
			else if (mainObject.Action != 4)
			{
				toX = mainObject.x;
				toY = mainObject.y;
				vx = 0;
				vy = 0;
				Action = 0;
				toX = x;
				toY = y;
				if (CRes.random(30) == 0)
				{
					timeFreeFire = 20;
				}
				if (x > mainObject.x)
				{
					Direction = 2;
				}
				else
				{
					Direction = 3;
				}
			}
			return;
		}
		if (vecObjskill != null && vecObjskill.size() > 0 && !isServerControl)
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
			MainObject mainObject2 = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
			if (mainObject2 == null)
			{
				isRunAttack = false;
			}
			else if (mainObject2.Action != 4)
			{
				toX = mainObject2.x;
				toY = mainObject2.y;
				int num = object_Effect_Skill.skillMonster.range;
				if (MainObject.getDistance(x + vx, y + vy, mainObject2.x, mainObject2.y) <= num)
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
			else
			{
				move_to_XY_Normal();
			}
			return;
		}
		MainObject mainObject3 = MainObject.get_Object(IDAttack, 0);
		if (mainObject3 == null)
		{
			isRunAttack = false;
		}
		else
		{
			if (mainObject3.Action == 4)
			{
				return;
			}
			toX = mainObject3.x;
			toY = mainObject3.y;
			if (MainObject.getDistance(x + vx, y + vy, mainObject3.x, mainObject3.y) <= limitAttack)
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
				if (x > mainObject3.x)
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
	}

	public override void move_to_XY()
	{
		if (!Canmove() || isBinded)
		{
			toX = x;
			toY = y;
		}
		else
		{
			if (isMoveOut)
			{
				return;
			}
			if (CRes.abs(x - toX) > vMax + getVmount())
			{
				vy = 0;
				Action = 1;
				if (CRes.abs(x - toX) > vMax + getVmount())
				{
					if (x > toX)
					{
						vx = -(vMax + getVmount());
						PrevDir = Direction;
						Direction = 2;
					}
					else
					{
						vx = vMax + getVmount();
						PrevDir = Direction;
						Direction = 3;
					}
				}
				else
				{
					vx = toX - x;
				}
			}
			else if (CRes.abs(y - toY) > vMax + getVmount())
			{
				vx = 0;
				Action = 1;
				if (CRes.abs(y - toY) > vMax + getVmount())
				{
					if (y > toY)
					{
						vy = -(vMax + getVmount());
						PrevDir = Direction;
						Direction = 1;
					}
					else
					{
						vy = vMax + getVmount();
						PrevDir = Direction;
						Direction = 0;
					}
				}
				else
				{
					vy = toY - y;
				}
			}
			else
			{
				if (isDetonateInDest)
				{
					GameScreen.addEffectEndKill(43, x, y);
					LoadMap.timeVibrateScreen = 10;
					isStop = true;
				}
				vx = 0;
				vy = 0;
				if (catalogyMonster == 103 && StepMovebocap == 0)
				{
					GameScreen.addEffectEndKill(54, x, y - 20);
					StepMovebocap = 1;
				}
			}
		}
	}

	public override void update()
	{
		base.update();
		updateDataEffect();
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
		if (!Canmove())
		{
			return;
		}
		updateAction();
		if (Action != 4 && Action != 3 && Action != 2)
		{
			if (isRunAttack && !isMonPhoBangDie)
			{
				if (timeFreeFire > 0)
				{
					if (!isServerControl && (!isMonsterHouse() || !isItemBox() || !isMonsterGate()))
					{
						autoMoveFire();
					}
				}
				else if (!isMonsterHouse() && !isItemBox() && !canNotMove() && !isMonsterGate())
				{
					Move_to_Focus();
				}
			}
			else if (!isServerControl && !isMonsterHouse() && !isItemBox() && !canNotMove() && !isMonsterGate())
			{
				auto_Move();
			}
		}
		int tile = GameCanvas.loadmap.getTile(x + vx, y + vy);
		if (!isServerControl && !isMonsterHouse() && !isItemBox() && !canNotMove())
		{
			setMove(MonWater, tile);
		}
	}

	public bool isMoveSlow(int catalogyMonster)
	{
		if (catalogyMonster == 101 || catalogyMonster == 83 || catalogyMonster == 84)
		{
			return true;
		}
		return false;
	}
}
