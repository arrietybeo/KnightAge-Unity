public class MonsterFly : MainMonster
{
	private mImage img;

	private int ydieFly;

	private static sbyte[][][] mMonFly_012 = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[6] { 0, 0, 1, 1, 2, 2 },
			new sbyte[6] { 1, 1, 0, 0, 2, 2 },
			new sbyte[6] { 2, 2, 0, 0, 1, 1 }
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

	private static sbyte[][][] mMonFly_0102 = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 1, 1, 0, 0, 2, 2 },
			new sbyte[8] { 1, 1, 0, 0, 2, 2, 0, 0 },
			new sbyte[8] { 2, 2, 0, 0, 1, 1, 0, 0 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 0, 0, 1, 1, 0, 0, 2, 2 },
			new sbyte[8] { 1, 1, 0, 0, 2, 2, 0, 0 },
			new sbyte[8] { 2, 2, 0, 0, 1, 1, 0, 0 }
		},
		new sbyte[3][]
		{
			new sbyte[8] { 2, 2, 2, 2, 3, 3, 3, 3 },
			new sbyte[8] { 2, 2, 2, 2, 3, 3, 3, 3 },
			new sbyte[8] { 2, 2, 2, 2, 3, 3, 3, 3 }
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

	private static sbyte[][][] mMonFly_012_slow = new sbyte[5][][]
	{
		new sbyte[3][]
		{
			new sbyte[6] { 0, 0, 1, 1, 2, 2 },
			new sbyte[6] { 1, 1, 0, 0, 2, 2 },
			new sbyte[6] { 2, 2, 0, 0, 1, 1 }
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

	public MonsterFly(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
	{
		coutEff = 0;
		base.typeMonster = typeMonster;
		typeObject = 1;
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
		Direction = 0;
		MonWater = 0;
		wOne = (hOne = -1);
		nFrame = 5;
		vMax = 3;
		limitMove = 70;
		xsai = 0;
		ysai = -2;
		timeAutoAction = CRes.random(60, 85);
		limitAttack = 50;
		switch (typeMonster)
		{
		case 5:
		case 19:
			mAction = mMonFly_0102;
			break;
		case 3:
			mAction = mMonFly_012;
			break;
		case 8:
			mAction = mMonFly_012;
			limitAttack = 80;
			break;
		case 10:
			mAction = mMonFly_012_slow;
			break;
		}
		timeLoadInfo = mSystem.currentTimeMillis();
	}

	public override void paint(mGraphics g)
	{
		if (isDie)
		{
			return;
		}
		if (typeBoss == 2 && MainObject.imgCapchar != null)
		{
			AvMain.Font3dWhite(g, MainObject.strCapchar, base.x, base.y - dy - ydieFly - hOne - 20 - 30, 2);
			g.drawImage(MainObject.imgCapchar, base.x, base.y - dy - vyStyleDie - hOne - 20, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
		}
		paintDataEff_Top(g, base.x, base.y);
		paintBuffFirst(g);
		paintEffauto_Low(g, base.x, base.y);
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
		g.drawImage(MainObject.shadow, base.x, base.y - dy - ydieFly, 3, mGraphics.isFalse);
		if (imagePartMonster.img != null)
		{
			if (wOne < 0)
			{
				if (catalogyMonster <= 92)
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
			g.drawRegion(imagePartMonster.img, x, y, wOne, hOne, (Direction > 2) ? 2 : 0, base.x, base.y - 8 - dy - vyStyleDie, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
			canFocusMon = true;
		}
		else
		{
			canFocusMon = false;
		}
		paintDataEff_Bot(g, base.x, base.y);
		paintBuffLast(g);
		paintIconClan(g, base.x - 1, base.y - ysai - dy + dyWater - hOne - 20, 2);
		base.paint(g);
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
		updateDataEffect();
		updateDataEffect();
		setDie();
		if (Action == 4)
		{
			ydieFly += 3;
			if (ydieFly > 11)
			{
				ydieFly = 11;
			}
		}
		else
		{
			ydieFly = 0;
		}
		if (!Canmove() || isBinded)
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
					if (!isServerControl)
					{
						autoMoveFire();
					}
				}
				else if (!canNotMove())
				{
					Move_to_Focus();
				}
			}
			else if (!isServerControl)
			{
				auto_Move();
			}
		}
		int tile = GameCanvas.loadmap.getTile(x + vx, y + vy);
		if (!isServerControl)
		{
			setMove(MonWater, tile);
		}
		if (typeBoss != 2)
		{
			return;
		}
		updateImgCapchar();
		if (timeRemoveGhost > 0)
		{
			timeRemoveGhost--;
			if (timeRemoveGhost == 0)
			{
				Action = 4;
				hp = 0;
				GameScreen.addEffectEndKill(11, x, y);
			}
		}
	}

	public void updateImgCapchar()
	{
		if (MainObject.imgCapchar == null)
		{
			if (timeCapchar > 0)
			{
				timeCapchar--;
			}
			if (timeCapchar <= 0)
			{
				mSystem.outz("lay hinh capchar");
				GlobalService.gI().load_image(9999);
				timeCapchar = 120;
			}
		}
	}
}
