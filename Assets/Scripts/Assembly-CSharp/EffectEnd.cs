using System;

public class EffectEnd : MainEffect
{
	public const sbyte END_NUC_DAT = 0;

	public const sbyte END_EFF_WATER_BIG = 1;

	public const sbyte END_FAR_NEAR = 2;

	public const sbyte END_THIEN_THACH = 3;

	public const sbyte END_KILL_PS_LV2 = 4;

	public const sbyte END_KILL_2KIEM_LV2 = 5;

	public const sbyte END_KILL_2KIEM_LV2_BEGIN = 6;

	public const sbyte END_KILL_SUNG_LV1 = 7;

	public const sbyte END_ROCK = 9;

	public const sbyte END_KILL_PS_LV1 = 10;

	public const sbyte END_DIE_MONSTER = 11;

	public const sbyte END_KILL_SUNG_LV2 = 12;

	public const sbyte END_KILL_SUNG_LV2_BEGIN = 13;

	public const sbyte END_PHAO_HOA = 14;

	public const sbyte END_PHAO_BANG = 15;

	public const sbyte END_WATER_ROCK = 19;

	public const sbyte END_EFF_LV_UP = 21;

	public const sbyte END_EFF_2KIEM_DOC = 24;

	public const sbyte END_EFF_KIEM_LV6 = 25;

	public const sbyte END_KIEM_NUC_DAT_2 = 26;

	public const sbyte END_ICE_BIG = 27;

	public const sbyte END_ICE_UP = 28;

	public const sbyte END_XUYEN_GIAP = 29;

	public const sbyte END_ROCK_FIRE_BIG = 30;

	public const sbyte END_REBUILD = 31;

	public const sbyte END_LEVEL_UP_REBUILD = 32;

	public const sbyte END_EFF_LV_UP_REBUILD = 33;

	public const sbyte END_EFF_FINISH_REBUILD = 34;

	public const sbyte END_EFF_REMOVE_OBJ = 35;

	public const sbyte END_EFF_REMOVE_MON_PHO_BANG = 36;

	public const sbyte END_REPLACE_PLUS = 37;

	public const sbyte END_NHANBAN_REVEICE = 38;

	public const sbyte END_HUT_HP_MON_PHO_BANG = 39;

	public const sbyte END_EFF_NAM_DAT = 40;

	public const sbyte END_EFF_A_DEN_B = 41;

	public const sbyte END_EFF_OPEN_BOX = 42;

	public const sbyte END_EFF_DETONATE = 43;

	public const sbyte END_EFF_POISON_NOVA = 44;

	public const sbyte END_EFF_TORNADO = 45;

	public const sbyte END_EFF_CAY_DAT = 46;

	public const sbyte END_EFF_NUT_DAT_BIND = 47;

	public const sbyte END_EFF_Medusa_ATK = 48;

	public const sbyte END_EFF_DONG_BANG = 49;

	public const sbyte END_EFF_Medusa_VongTron = 50;

	public const sbyte END_PET_BAT = 51;

	public const sbyte END_PET_EAGLE = 52;

	public const sbyte END_PET_OWL = 53;

	public const sbyte END_EFF_MOVE_BOSS = 54;

	public const sbyte END_MOUNT_DUST = 55;

	public const sbyte END_FOOT_SNOW = 56;

	public const sbyte END_ENY = 57;

	public const sbyte END_MO_TO = 58;

	private mVector VecEffEnd = new mVector("EffectEnd VecEffEnd");

	private mVector VecSubEffEnd = new mVector("EffectEnd VecSubEffEnd");

	private int x1000;

	private int y1000;

	private int lT_Arc;

	private int gocT_Arc;

	private Point pRebuild;

	public new sbyte[] nFrame;

	private int trans;

	public new long timeRemove;

	public int timeDeley = 2000;

	public EffectAuto effAuto;

	private sbyte typeSub;

	private int numEffReplace;

	private int plusGoc;

	public EffectEnd(int type, int id, int x, int y)
	{
		f = -1;
		typeEffect = type;
		base.x = x;
		base.y = y;
		fraImgEff = new FrameImage(id);
		fRemove = fraImgEff.getNFrame();
	}

	public EffectEnd(int type, int x, int y)
	{
		f = -1;
		typeEffect = type;
		base.x = x;
		base.y = y;
		switch (type)
		{
		case 0:
			fraImgEff = new FrameImage(53);
			fRemove = 6;
			break;
		case 51:
			fraImgEff = new FrameImage(140);
			fRemove = 6;
			break;
		case 1:
			fraImgEff = new FrameImage(29);
			fRemove = 3;
			break;
		case 2:
			fraImgEff = new FrameImage(18);
			fRemove = 4;
			break;
		case 3:
		{
			fraImgEff = new FrameImage(27);
			fRemove = 15;
			for (int num5 = 0; num5 < 7; num5++)
			{
				Point o2 = new Point
				{
					x = x + CRes.random_Am_0(22),
					y = y + CRes.random_Am_0(8),
					dis = CRes.random(fraImgEff.nFrame)
				};
				VecEffEnd.addElement(o2);
			}
			break;
		}
		case 4:
			fraImgEff = new FrameImage(4);
			fRemove = 5;
			break;
		case 5:
			fraImgEff = new FrameImage(51);
			fRemove = 6;
			break;
		case 6:
			fraImgEff = new FrameImage(52);
			fRemove = 4;
			break;
		case 7:
			fraImgEff = new FrameImage(54);
			fRemove = 4;
			break;
		case 9:
		{
			if (GameCanvas.lowGraphic)
			{
				removeEff();
				break;
			}
			fraImgEff = new FrameImage(56);
			fRemove = CRes.random(11, 15);
			int num3 = CRes.random(3, 7);
			for (int l = 0; l < num3; l++)
			{
				Point point3 = new Point
				{
					x = x + CRes.random_Am_0(5),
					y = y + CRes.random_Am_0(7),
					frame = CRes.random(fraImgEff.nFrame),
					dis = CRes.random(2),
					vy = -CRes.random(6, 9),
					vx = CRes.random(1, 4)
				};
				if (l % 2 == 0)
				{
					point3.vx = -point3.vx;
				}
				VecEffEnd.addElement(point3);
			}
			break;
		}
		case 10:
			fraImgEff = new FrameImage(58);
			fRemove = 4;
			break;
		case 11:
			fraImgEff = new FrameImage(42);
			fRemove = 9;
			break;
		case 12:
			fraImgEff = new FrameImage(60);
			fRemove = 4;
			break;
		case 13:
			fraImgEff = new FrameImage(9);
			fRemove = 4;
			break;
		case 14:
		case 15:
		{
			if (GameCanvas.lowGraphic)
			{
				removeEff();
				break;
			}
			int num4 = 0;
			if (type == 14)
			{
				fraImgEff = new FrameImage(1);
				num4 = CRes.random(7, 12);
			}
			else
			{
				fraImgEff = new FrameImage(5);
				num4 = CRes.random(7, 12);
			}
			fRemove = 12;
			for (int m = 0; m < num4; m++)
			{
				Point point4 = new Point
				{
					x = x + CRes.random_Am_0(4),
					y = y + CRes.random_Am_0(5),
					frame = CRes.random(fraImgEff.nFrame),
					vy = -CRes.random(5, 9),
					vx = CRes.random(0, 3)
				};
				if (m % 2 == 0)
				{
					point4.vx = -point4.vx;
				}
				VecEffEnd.addElement(point4);
			}
			break;
		}
		case 26:
			levelPaint = -1;
			if (CRes.random(2) == 0)
			{
				fraImgEff = new FrameImage(90);
			}
			else
			{
				fraImgEff = new FrameImage(13);
			}
			fRemove = CRes.random(74, 85);
			fRemove_Low(20);
			break;
		case 19:
			if (GameCanvas.lowGraphic)
			{
				removeEff();
				break;
			}
			fraImgEff = new FrameImage(28);
			frame = ((CRes.random(2) != 0) ? 2 : 0);
			fRemove = 2;
			break;
		case 21:
		case 33:
		{
			int num4;
			if (typeEffect == 33)
			{
				fraImgEff = new FrameImage(2);
				num4 = 30;
				fRemove = 30;
			}
			else
			{
				fraImgEff = new FrameImage(66);
				num4 = 40;
				fRemove = 12;
			}
			for (int n = 0; n < num4; n++)
			{
				Point point5 = new Point
				{
					x = x + CRes.random_Am_0(10),
					y = y - CRes.random_Am_0(8),
					frame = CRes.random(fraImgEff.nFrame),
					vy = -CRes.random(3, 11)
				};
				if (typeEffect == 33)
				{
					point5.vx = CRes.random(0, 4);
				}
				else
				{
					point5.vx = CRes.random(0, 3);
				}
				if (n % 2 == 0)
				{
					point5.vx = -point5.vx;
				}
				VecEffEnd.addElement(point5);
			}
			break;
		}
		case 24:
			fraImgEff = new FrameImage(12);
			fRemove = CRes.random(18, 23);
			levelPaint = -1;
			break;
		case 25:
		case 28:
		case 40:
			if (typeEffect == 25)
			{
				fraImgEff = new FrameImage(86);
			}
			else if (typeEffect == 28)
			{
				fraImgEff = new FrameImage(96);
			}
			else if (typeEffect == 40)
			{
				int tile = GameCanvas.loadmap.getTile(x, y);
				if (tile == 2 || tile == -1)
				{
					break;
				}
				fraImgEff = new FrameImage(19);
			}
			levelPaint = -1;
			fRemove = CRes.random(74, 85);
			fRemove_Low(20);
			break;
		case 27:
		case 30:
		{
			fRemove = 20;
			levelPaint = -1;
			if (typeEffect == 27)
			{
				fraImgEff = new FrameImage(92);
			}
			else if (typeEffect == 30)
			{
				fraImgEff = new FrameImage(115);
			}
			for (int k = 0; k < 3; k++)
			{
				Point point2 = new Point
				{
					x = x + CRes.random_Am_0(3),
					y = y + CRes.random_Am_0(3)
				};
				if (CRes.random(2) == 0)
				{
					if (k % 2 == 0)
					{
						point2.vx = CRes.random(3);
					}
					else
					{
						point2.vx = -CRes.random(3);
					}
				}
				else
				{
					point2.vx = CRes.random_Am_0(3);
				}
				point2.vy = -5;
				point2.fRe = CRes.random(6, 12);
				point2.frame = k;
				VecEffEnd.addElement(point2);
			}
			break;
		}
		case 29:
		{
			fraImgEff = new FrameImage(105);
			fRemove = CRes.random(11, 15);
			int num2 = CRes.random(3, 6);
			for (int j = 0; j < num2; j++)
			{
				Point point = new Point
				{
					x = x + CRes.random_Am_0(5),
					y = y + CRes.random_Am_0(7),
					frame = CRes.random(fraImgEff.nFrame),
					dis = CRes.random(2),
					vy = -CRes.random(6, 9),
					vx = CRes.random(1, 4)
				};
				if (j % 2 == 0)
				{
					point.vx = -point.vx;
				}
				VecEffEnd.addElement(point);
			}
			break;
		}
		case 32:
			create_Level_up();
			break;
		case 34:
			fraImgEff = new FrameImage(14);
			fRemove = 18;
			break;
		case 54:
			fraImgEff = new FrameImage(144);
			fRemove = 10;
			break;
		case 35:
			fraImgEff = new FrameImage(122);
			fRemove = 6;
			break;
		case 36:
			fraImgEff = new FrameImage(4);
			fRemove = 10;
			break;
		case 38:
			fraImgEff = new FrameImage(65);
			fraImgSubEff = new FrameImage(122);
			fraImgSub2Eff = new FrameImage(14);
			fRemove = 12;
			break;
		case 39:
			fRemove = 55;
			break;
		case 42:
		{
			fraImgEff = new FrameImage(7);
			fraImgSubEff = new FrameImage(2);
			fRemove = 20;
			gocT_Arc = 0;
			for (int i = 0; i < 8; i++)
			{
				int num = CRes.random(4, 6);
				Point o = new Point
				{
					x = x * 1000,
					y = y * 1000,
					vx = CRes.cos(CRes.fixangle(gocT_Arc)) * num,
					vy = CRes.sin(CRes.fixangle(gocT_Arc)) * num
				};
				gocT_Arc += 45;
				VecEffEnd.addElement(o);
			}
			break;
		}
		case 43:
			fraImgEff = new FrameImage(124);
			fRemove = 10;
			break;
		case 44:
			fraImgEff = new FrameImage(70);
			fRemove = 4;
			break;
		case 45:
			fraImgEff = new FrameImage(63);
			fRemove = 8;
			break;
		case 46:
			fraImgEff = new FrameImage(86);
			levelPaint = -1;
			fRemove = 6;
			break;
		case 48:
			fraImgEff = new FrameImage(134);
			fRemove = 8;
			break;
		case 8:
		case 16:
		case 17:
		case 18:
		case 20:
		case 22:
		case 23:
		case 31:
		case 37:
		case 41:
		case 47:
		case 49:
		case 50:
		case 52:
		case 53:
			break;
		}
	}

	public EffectEnd(int type, int x, int y, int direction, sbyte levelPaint)
	{
		f = -1;
		typeEffect = type;
		base.x = x;
		base.y = y;
		Direction = direction;
		switch (type)
		{
		case 55:
		{
			nFrame = new sbyte[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
			int tile = GameCanvas.loadmap.getTile(x, y);
			if (tile != 2 && tile != -1)
			{
				fraImgEff = new FrameImage(145);
				base.levelPaint = levelPaint;
			}
			break;
		}
		case 56:
			fraImgEff = new FrameImage(152);
			base.levelPaint = levelPaint;
			fRemove = CRes.random(20, 30);
			fRemove_Low(20);
			break;
		case 58:
			fraImgEff = new FrameImage(164);
			base.levelPaint = levelPaint;
			fRemove = CRes.random(20, 30);
			fRemove_Low(20);
			break;
		case 57:
			break;
		}
	}

	public EffectEnd(int type, int x, int y, long timeRemove)
	{
		f = -1;
		typeEffect = type;
		base.x = x;
		base.y = y;
		switch (type)
		{
		case 47:
			this.timeRemove = timeRemove + timeDeley;
			fraImgEff = new FrameImage(86);
			levelPaint = -1;
			fRemove = CRes.random(74, 85);
			fRemove_Low(20);
			break;
		case 49:
			this.timeRemove = timeRemove;
			effAuto = new EffectAuto(51, x, y, 0, 0, 0, 0);
			levelPaint = -1;
			fRemove = 6;
			break;
		case 50:
			this.timeRemove = timeRemove;
			fraImgEff = new FrameImage(137);
			levelPaint = -1;
			fRemove = 12;
			break;
		case 48:
			break;
		}
	}

	public EffectEnd(int type, int x, int y, sbyte typeSub)
	{
		f = -1;
		typeEffect = type;
		this.typeSub = typeSub;
		base.x = x;
		base.y = y;
	}

	public EffectEnd(int type, int x, int y, int xTo, int yTo, int num)
	{
		typeEffect = type;
		base.x = x;
		base.y = y;
		toX = xTo;
		toY = yTo;
		switch (type)
		{
		case 31:
			create_Arc_Big_Small();
			break;
		case 37:
			fraImgEff = new FrameImage(7);
			fraImgSubEff = new FrameImage(2);
			fRemove = 100;
			lT_Arc = 40;
			gocT_Arc = 0;
			numEffReplace = num;
			plusGoc = 360 / num;
			break;
		case 41:
			fraImgEff = new FrameImage(7);
			fraImgSubEff = new FrameImage(2);
			fRemove = 18;
			break;
		}
	}

	public override void paint(mGraphics g)
	{
		try
		{
			switch (typeEffect)
			{
			case 0:
			case 2:
			case 5:
			case 11:
			case 35:
			case 36:
			case 51:
			case 54:
			case 57:
				if (fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y, 0, 3, g);
				}
				break;
			case 34:
				if (fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(f / 3 % fraImgEff.nFrame, x, y, 0, 3, g);
				}
				break;
			case 3:
			{
				for (int k = 0; k < VecEffEnd.size(); k++)
				{
					Point point3 = (Point)VecEffEnd.elementAt(k);
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill((point3.f + f) / 2 % fraImgEff.nFrame, point3.x, point3.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
					}
				}
				break;
			}
			case 1:
			case 4:
			case 6:
			case 7:
			case 10:
			case 12:
			case 13:
			case 44:
			case 45:
				if (fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(f % fraImgEff.nFrame, x, y, 0, 3, g);
				}
				break;
			case 9:
			case 27:
			case 29:
			case 30:
			{
				for (int n = 0; n < VecEffEnd.size(); n++)
				{
					Point point6 = (Point)VecEffEnd.elementAt(n);
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(point6.frame, point6.x, point6.y, 0, 3, g);
					}
				}
				break;
			}
			case 14:
			case 15:
			case 21:
			{
				for (int num8 = 0; num8 < VecEffEnd.size(); num8++)
				{
					Point point7 = (Point)VecEffEnd.elementAt(num8);
					if (f < fRemove / 3 * 2)
					{
						if (fraImgEff != null)
						{
							fraImgEff.drawFrameEffectSkill(point7.frame, point7.x, point7.y, 0, 3, g);
						}
					}
					else if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill((point7.frame != 0) ? point7.frame : 3, point7.x, point7.y, 0, 3, g);
					}
				}
				break;
			}
			case 33:
			{
				for (int m = 0; m < VecEffEnd.size(); m++)
				{
					Point point5 = (Point)VecEffEnd.elementAt(m);
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill((point5.frame + point5.f / 2) % fraImgEff.nFrame, point5.x, point5.y, 0, 3, g);
					}
				}
				break;
			}
			case 26:
				if (f < 2)
				{
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(f, x, y, 0, 3, g);
					}
				}
				else if (f < fRemove - 4)
				{
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(2, x, y, 0, 3, g);
					}
				}
				else if (f < fRemove && fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill((fRemove - 1 - f) / 2, x, y, 0, 3, g);
				}
				break;
			case 19:
				if (fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(frame + f % fraImgEff.nFrame, x - fraImgEff.frameWidth / 2, y - fraImgEff.frameHeight / 2, 0, 0, g);
				}
				break;
			case 24:
			{
				int num7 = 0;
				if (f > fRemove - 5)
				{
					num7 = (f - (fRemove - 4)) / 2;
				}
				if (num7 < 3 && fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(num7, x, y, 0, 3, g);
				}
				break;
			}
			case 25:
			case 28:
			case 40:
			case 46:
				if (f <= fRemove)
				{
					int num6 = 0;
					if (f < 2)
					{
						num6 = f;
					}
					num6 = ((f <= fRemove - 5) ? 2 : ((fRemove - 1 - f) / 2));
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(num6, x, y, 0, 3, g);
					}
				}
				break;
			case 31:
			{
				for (int l = 0; l < VecEffEnd.size(); l++)
				{
					Point point4 = (Point)VecEffEnd.elementAt(l);
					if (fraImgSubEff != null)
					{
						fraImgSubEff.drawFrameEffectSkill(point4.f / 2, point4.x, point4.y, 0, 3, g);
					}
				}
				if (lT_Arc > 5 && fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(pRebuild.v, (pRebuild.x2 + pRebuild.vx) / 1000, (pRebuild.y2 + pRebuild.vy) / 1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				break;
			}
			case 32:
				if (fraImgSubEff != null)
				{
					fraImgSubEff.drawFrameEffectSkill(0, x, y - (f - fRemove / 2) * 2, 0, 3, g);
				}
				break;
			case 37:
			case 41:
			case 42:
			{
				for (int i = 0; i < VecEffEnd.size(); i++)
				{
					Point point = (Point)VecEffEnd.elementAt(i);
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(point.f / 2 % fraImgEff.nFrame, point.x / 1000, point.y / 1000, 0, 3, g);
					}
				}
				for (int j = 0; j < VecSubEffEnd.size(); j++)
				{
					Point point2 = (Point)VecSubEffEnd.elementAt(j);
					if (fraImgSubEff != null)
					{
						fraImgSubEff.drawFrameEffectSkill(point2.f / 2, point2.x, point2.y, 0, 3, g);
					}
				}
				break;
			}
			case 38:
				if (f < 6)
				{
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(f, x, y, 0, 3, g);
					}
					if (fraImgSubEff != null)
					{
						fraImgSubEff.drawFrameEffectSkill(2 - f / 2, x, y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					}
				}
				else if (fraImgSub2Eff != null)
				{
					fraImgSub2Eff.drawFrameEffectSkill(f - 6, x, y - 20, 0, 3, g);
				}
				break;
			case 43:
				if (fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y, 0, 3, g);
				}
				break;
			case 47:
				if (timeRemove - mSystem.currentTimeMillis() >= 0)
				{
					long num3 = (timeRemove - mSystem.currentTimeMillis()) / 1000;
					int num4 = 0;
					num4 = ((num3 >= 2) ? 2 : ((num3 >= 1) ? 1 : 0));
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(num4, x, y, 0, 3, g);
					}
				}
				break;
			case 49:
				if (effAuto != null)
				{
					effAuto.paint(g);
				}
				break;
			case 48:
			case 50:
				if (fraImgEff != null)
				{
					fraImgEff.drawFrameEffectSkill(f / 2 % fraImgEff.nFrame, x, y, 0, 3, g);
				}
				break;
			case 58:
				if (f <= fRemove)
				{
					int num5 = 0;
					if (f < 2)
					{
						num5 = f;
					}
					if (f > fRemove - 5)
					{
						num5 = (fRemove - 1 - f) / 2;
					}
					else
					{
						num5 = 2;
					}
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(0, x, y, trans, 3, g);
					}
				}
				break;
			case 56:
				if (f <= fRemove)
				{
					int num = 0;
					if (f < 2)
					{
						num = f;
					}
					num = ((f <= fRemove - 5) ? 2 : ((fRemove - 1 - f) / 2));
					int num2 = 0;
					if (Direction == 3 && mSystem.isWinphone)
					{
						num2 = 16;
					}
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(num, x, y, trans, 3, g);
					}
				}
				break;
			case 55:
				try
				{
					if (fraImgEff != null)
					{
						fraImgEff.drawFrameEffectSkill(nFrame[f], x, y, trans, 3, g);
					}
					break;
				}
				catch (Exception)
				{
					mSystem.println("err mountdust f:" + nFrame.Length + "  " + f);
					break;
				}
			case 8:
			case 16:
			case 17:
			case 18:
			case 20:
			case 22:
			case 23:
			case 39:
			case 52:
			case 53:
				break;
			}
		}
		catch (Exception ex2)
		{
			mSystem.println("/ " + typeEffect + ex2.ToString());
		}
	}

	public override void update()
	{
		f++;
		subf++;
		switch (typeEffect)
		{
		case 0:
		case 1:
		case 2:
		case 4:
		case 5:
		case 6:
		case 7:
		case 10:
		case 11:
		case 12:
		case 13:
		case 19:
		case 24:
		case 25:
		case 26:
		case 28:
		case 34:
		case 35:
		case 40:
		case 44:
		case 46:
		case 51:
		case 54:
		case 57:
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 58:
			if (Direction == 2)
			{
				trans = 4;
			}
			else if (Direction == 3)
			{
				trans = 7;
			}
			if (Direction == 1)
			{
				trans = 0;
			}
			if (Direction == 0)
			{
				trans = 3;
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 56:
			if (Direction == 2)
			{
				trans = 4;
			}
			else if (Direction == 3)
			{
				trans = 7;
			}
			if (Direction == 1)
			{
				trans = 0;
			}
			if (Direction == 0)
			{
				trans = 3;
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 3:
		{
			for (int j = 0; j < VecEffEnd.size(); j++)
			{
				Point point2 = (Point)VecEffEnd.elementAt(j);
				if (CRes.random(3) == 0)
				{
					point2.x = x + CRes.random_Am_0(22);
					point2.y = y + CRes.random_Am_0(8);
					point2.f = CRes.random(fraImgEff.nFrame);
				}
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		}
		case 9:
		case 14:
		case 15:
		case 29:
		{
			for (int i = 0; i < VecEffEnd.size(); i++)
			{
				Point point = (Point)VecEffEnd.elementAt(i);
				point.update();
				point.vy++;
				if (f == fRemove && GameScreen.isWater(point.x, point.y))
				{
					GameScreen.addEffectEndKill(19, point.x, point.y);
				}
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		}
		case 21:
		{
			for (int num2 = 0; num2 < VecEffEnd.size(); num2++)
			{
				Point point10 = (Point)VecEffEnd.elementAt(num2);
				point10.update();
				if (point10.vy < 0)
				{
					point10.vy++;
					continue;
				}
				point10.vy = 0;
				point10.vx = 0;
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		}
		case 27:
		case 30:
		{
			for (int num3 = 0; num3 < VecEffEnd.size(); num3++)
			{
				Point point11 = (Point)VecEffEnd.elementAt(num3);
				point11.f++;
				if (point11.f < point11.fRe)
				{
					point11.x += point11.vx;
					point11.y += point11.vy;
				}
				point11.vy++;
			}
			if (f > fRemove)
			{
				removeEff();
			}
			break;
		}
		case 31:
		{
			for (int l = 0; l < VecEffEnd.size(); l++)
			{
				Point point4 = (Point)VecEffEnd.elementAt(l);
				point4.f++;
				if (point4.f / 2 >= 4)
				{
					VecEffEnd.removeElement(point4);
					l--;
				}
			}
			pRebuild.v = f / 2 % 2;
			if (f <= 4)
			{
				break;
			}
			if (lT_Arc > 5)
			{
				pRebuild.f += 14;
				pRebuild.vy = CRes.sin(CRes.fixangle(pRebuild.f % 360)) * lT_Arc;
				pRebuild.vx = CRes.cos(CRes.fixangle(pRebuild.f % 360)) * lT_Arc;
				if (f % 2 == 0)
				{
					lT_Arc--;
					pRebuild.f += 14;
				}
				Point point5 = new Point();
				point5.x = (pRebuild.x2 + pRebuild.vx) / 1000 + CRes.random_Am(-1, 2);
				point5.y = (pRebuild.y2 + pRebuild.vy) / 1000 + CRes.random_Am(-1, 2);
				VecEffEnd.addElement(point5);
			}
			else if (VecEffEnd.size() == 0)
			{
				removeEff();
			}
			break;
		}
		case 32:
		{
			if (f >= fRemove)
			{
				removeEff();
			}
			if (f >= fRemove / 2)
			{
				break;
			}
			for (int k = 0; k < VecEffEnd.size(); k++)
			{
				Point point3 = (Point)VecEffEnd.elementAt(k);
				if (CRes.random(3) == 0)
				{
					if (point3.fRe == 1)
					{
						point3.fRe = 0;
						continue;
					}
					point3.fRe = 1;
					point3.frame = CRes.random(4);
				}
			}
			break;
		}
		case 33:
		{
			for (int num = 0; num < VecEffEnd.size(); num++)
			{
				Point point9 = (Point)VecEffEnd.elementAt(num);
				point9.update();
				point9.vy++;
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		}
		case 36:
			if (f == 1)
			{
				GameScreen.addEffectEndKill(14, x, y);
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 37:
		{
			if (f % 3 == 0 && VecEffEnd.size() < numEffReplace && f < 50)
			{
				Point point16 = new Point();
				point16.x = x * 1000;
				point16.y = y * 1000;
				point16.vx = CRes.cos(CRes.fixangle(gocT_Arc)) * 4;
				point16.vy = CRes.sin(CRes.fixangle(gocT_Arc)) * 4;
				point16.x2 = toX * 1000;
				point16.y2 = toY * 1000;
				gocT_Arc += plusGoc;
				VecEffEnd.addElement(point16);
				if (VecEffEnd.size() == numEffReplace)
				{
					f = 50;
				}
			}
			if (f == 80)
			{
				for (int num6 = 0; num6 < VecEffEnd.size(); num6++)
				{
					Point point17 = (Point)VecEffEnd.elementAt(num6);
					point17.vx = (point17.x2 - point17.x) / 8;
					point17.vy = (point17.y2 - point17.y) / 8;
					point17.f = 100;
				}
			}
			for (int num7 = 0; num7 < VecEffEnd.size(); num7++)
			{
				Point point18 = (Point)VecEffEnd.elementAt(num7);
				point18.update();
				if (point18.f % 3 == 0)
				{
					Point point19 = new Point();
					point19.x = point18.x / 1000 + CRes.random_Am(5, 12);
					point19.y = point18.y / 1000 + CRes.random_Am(5, 12);
					VecSubEffEnd.addElement(point19);
				}
				if (point18.f == 10)
				{
					point18.vx = 0;
					point18.vy = 0;
				}
				if (point18.f > 108)
				{
					VecEffEnd.removeElement(point18);
					num7--;
				}
			}
			for (int num8 = 0; num8 < VecSubEffEnd.size(); num8++)
			{
				Point point20 = (Point)VecSubEffEnd.elementAt(num8);
				point20.f++;
				if (point20.f / 2 >= 4)
				{
					VecSubEffEnd.removeElement(point20);
					num8--;
				}
			}
			if (f > 80 && VecEffEnd.size() == 0)
			{
				TabRebuildItem.addEffectEnd_ReBuild_ss(32, toX, toY - 11);
				TabRebuildItem.addEffectEnd_ReBuild_ss(33, toX, toY);
				TabRebuildItem.addEffectEnd_ReBuild_ss(34, toX, toY);
				removeEff();
			}
			break;
		}
		case 38:
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 39:
			if (CRes.random(2) == 0)
			{
				GameScreen.addEffectKill(83, x, y, 400, -1, 0);
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 41:
		{
			if (f == 1)
			{
				Point point12 = new Point();
				point12.x = x * 1000;
				point12.y = y * 1000;
				point12.x2 = toX * 1000;
				point12.y2 = toY * 1000;
				point12.vx = 0;
				point12.vy = 0;
				VecEffEnd.addElement(point12);
			}
			for (int num4 = 0; num4 < VecEffEnd.size(); num4++)
			{
				Point point13 = (Point)VecEffEnd.elementAt(num4);
				point13.update();
				if (point13.f == 4)
				{
					point13.vx = (point13.x2 - point13.x) / 12;
					point13.vy = (point13.y2 - point13.y) / 12;
				}
				if (point13.f % 3 == 0)
				{
					Point point14 = new Point();
					point14.x = point13.x / 1000 + CRes.random_Am(5, 12);
					point14.y = point13.y / 1000 + CRes.random_Am(5, 12);
					VecSubEffEnd.addElement(point14);
				}
				if (point13.f == 16)
				{
					point13.vx = 0;
					point13.vy = 0;
					VecEffEnd.removeElement(point13);
					num4--;
				}
			}
			for (int num5 = 0; num5 < VecSubEffEnd.size(); num5++)
			{
				Point point15 = (Point)VecSubEffEnd.elementAt(num5);
				point15.f++;
				if (point15.f / 2 >= 4)
				{
					VecSubEffEnd.removeElement(point15);
					num5--;
				}
			}
			if (f >= fRemove && VecSubEffEnd.size() == 0 && VecEffEnd.size() == 0)
			{
				removeEff();
			}
			break;
		}
		case 42:
		{
			for (int m = 0; m < VecEffEnd.size(); m++)
			{
				Point point6 = (Point)VecEffEnd.elementAt(m);
				point6.update();
				if (point6.f % 3 == 0)
				{
					Point point7 = new Point();
					point7.x = point6.x / 1000 + CRes.random_Am(5, 12);
					point7.y = point6.y / 1000 + CRes.random_Am(5, 12);
					VecSubEffEnd.addElement(point7);
				}
				if (point6.f == fRemove)
				{
					point6.vx = 0;
					point6.vy = 0;
					VecEffEnd.removeElement(point6);
					m--;
				}
			}
			for (int n = 0; n < VecSubEffEnd.size(); n++)
			{
				Point point8 = (Point)VecSubEffEnd.elementAt(n);
				point8.f++;
				if (point8.f / 2 >= 4)
				{
					VecSubEffEnd.removeElement(point8);
					n--;
				}
			}
			if (f >= fRemove && VecEffEnd.size() == 0 && VecSubEffEnd.size() == 0)
			{
				removeEff();
			}
			break;
		}
		case 43:
			if (f == 1)
			{
				GameScreen.addEffectEndKill(14, x, y);
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 45:
			if (f == 1)
			{
				GameScreen.addEffectEndKill(9, x, y + 20);
				GameScreen.addEffectEndKill(46, x, y + 20);
			}
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 49:
			if (effAuto != null)
			{
				effAuto.update();
			}
			if (timeRemove - mSystem.currentTimeMillis() < 0)
			{
				removeEff();
				GameScreen.addEffectEndKill(15, x, y);
			}
			break;
		case 47:
		case 50:
			if (timeRemove - mSystem.currentTimeMillis() < 0)
			{
				removeEff();
			}
			break;
		case 48:
			if (f >= fRemove)
			{
				removeEff();
			}
			break;
		case 55:
			if (f < 0)
			{
				f = 0;
			}
			if (Direction == 2)
			{
				trans = 0;
			}
			else if (Direction == 3)
			{
				trans = 2;
			}
			if (Direction == 1)
			{
				trans = 3;
			}
			if (Direction == 0)
			{
				trans = 0;
			}
			if (f > nFrame.Length - 1)
			{
				f = 0;
				removeEff();
			}
			break;
		case 8:
		case 16:
		case 17:
		case 18:
		case 20:
		case 22:
		case 23:
		case 52:
		case 53:
			break;
		}
	}

	public void removeEff()
	{
		isStop = true;
		isRemove = true;
	}

	private void create_Arc_Big_Small()
	{
		fraImgEff = new FrameImage(7);
		fraImgSubEff = new FrameImage(2);
		x1000 = x * 1000;
		y1000 = y * 1000;
		fRemove = 15;
		lT_Arc = MainObject.getDistance(toX, toY, x, y);
		gocT_Arc = CRes.angle(x - toX, y - toY);
		pRebuild = new Point(toX * 1000, toY * 1000);
		pRebuild.x2 = toX * 1000;
		pRebuild.y2 = toY * 1000;
		pRebuild.f = gocT_Arc;
		pRebuild.vy = CRes.sin(CRes.fixangle(pRebuild.f % 360)) * lT_Arc;
		pRebuild.vx = CRes.cos(CRes.fixangle(pRebuild.f % 360)) * lT_Arc;
		pRebuild.v = 0;
	}

	private void create_Level_up()
	{
		fraImgSubEff = new FrameImage(67);
		fRemove = 23;
	}

	public void fRemove_Low(int t)
	{
		if (GameCanvas.lowGraphic)
		{
			fRemove = CRes.random(t - 4, t + 5);
		}
	}
}
