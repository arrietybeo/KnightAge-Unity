public class MainBuff
{
	public const int BUFF_KIEM_1 = 0;

	public const int BUFF_2KIEM_1 = 1;

	public const int BUFF_PS_1 = 2;

	public const int BUFF_SUNG_1 = 3;

	public const int BUFF_HEAD = 4;

	public const int BUFF_KIEM_2 = 5;

	public const int BUFF_2KIEM_2 = 6;

	public const int BUFF_PS_2 = 7;

	public const int BUFF_SUNG_2 = 8;

	public const int BUFF_CRAZY = 9;

	public const int BUFF_PET = 10;

	public const sbyte EFF_BUFF_GOLD = 11;

	public const sbyte EFF_BUFF_AMOR = 12;

	public const sbyte EFF_BUFF_DAME = 13;

	public const sbyte EFF_BUFF_HUTHP = 14;

	public long timeBegin;

	public bool isPaintLast;

	private bool isForEver;

	private int x0;

	private int y0;

	private int x1000;

	private int y1000;

	public int timeOff;

	private int indexPaint;

	private int framebegin;

	private long timebuff;

	public bool isRemove;

	public int typeBuff;

	public int typeSub;

	public short idIcon;

	public sbyte[] frame_Buff = new sbyte[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

	public sbyte frBuff;

	public MainInfoItem[] minfo;

	public MainInfoItem[] minfotam;

	private FrameImage fraImage;

	private mVector vecEff = new mVector("MainBuff VecEff");

	public MainBuff(int type, int time)
	{
		typeBuff = type;
		timebuff = mSystem.currentTimeMillis() + time * 1000;
		switch (typeBuff)
		{
		case 11:
			fraImage = new FrameImage(149);
			break;
		case 12:
			fraImage = new FrameImage(147);
			break;
		case 13:
			fraImage = new FrameImage(146);
			break;
		case 14:
			fraImage = new FrameImage(148);
			break;
		}
	}

	public MainBuff(int type, int time, int typeSub)
	{
		typeBuff = type;
		this.typeSub = typeSub;
		timeBegin = GameCanvas.timeNow;
		timeOff = time;
		x0 = 0;
		y0 = 0;
		framebegin = CRes.random(9);
		switch (type)
		{
		case 0:
		case 2:
		case 5:
		case 7:
			fraImage = new FrameImage(88);
			break;
		case 1:
		case 3:
		case 6:
		case 8:
			fraImage = new FrameImage(89);
			break;
		case 9:
			isPaintLast = true;
			break;
		case 4:
		{
			isPaintLast = true;
			if (typeSub == 3)
			{
				fraImage = new FrameImage(81);
				framebegin = 0;
			}
			else
			{
				fraImage = new FrameImage(80);
				framebegin = typeSub;
				if (typeSub > 3)
				{
					framebegin--;
				}
			}
			for (int i = 0; i < 3; i++)
			{
				Point point = new Point
				{
					x = CRes.random_Am_0(16),
					y = CRes.random_Am_0(10)
				};
				if (typeSub == 3)
				{
					point.vx = CRes.random_Am_0(3);
					point.vy = CRes.random_Am_0(2);
				}
				vecEff.addElement(point);
			}
			break;
		}
		default:
			isRemove = true;
			break;
		}
	}

	public void settimebuff(long time)
	{
		timebuff = mSystem.currentTimeMillis() + time * 1000;
	}

	public void paint(mGraphics g, int x, int y)
	{
		if (isRemove)
		{
			return;
		}
		switch (typeBuff)
		{
		case 0:
		case 1:
		case 5:
		case 6:
		case 10:
			if (fraImage != null)
			{
				fraImage.drawFrameEffectSkill(2 - (GameCanvas.gameTick + framebegin) / 3 % fraImage.nFrame, x + x0, y + y0, 0, 3, g);
			}
			break;
		case 2:
		case 3:
		case 7:
		case 8:
			if (fraImage != null)
			{
				fraImage.drawFrameEffectSkill((GameCanvas.gameTick + framebegin) / 3 % fraImage.nFrame, x + x0, y + y0, 0, 3, g);
			}
			break;
		case 4:
		{
			if (fraImage == null || vecEff == null)
			{
				break;
			}
			for (int i = 0; i < vecEff.size(); i++)
			{
				Point point = (Point)vecEff.elementAt(i);
				if (point != null)
				{
					fraImage.drawFrameEffectSkill(framebegin * 3 + point.f % fraImage.nFrame, x + point.x, y + point.y, 0, 3, g);
				}
			}
			break;
		}
		case 9:
		{
			int num = 0;
			for (int num2 = vecEff.size() - 1; num2 >= 0; num2--)
			{
				Line line = (Line)vecEff.elementAt(num2);
				if (line != null)
				{
					int num3 = 0;
					num3 = EffectSkill.colorStar[0][line.idColor];
					g.setColor(num3);
					num = num3;
					g.fillRect(line.x0, line.y0, 1, line.Rec_h, useClip: false);
					if (line.is2Line)
					{
						g.fillRect(line.x0 + 2, line.y0 + 1, 1, line.Rec_h, mGraphics.isFalse);
					}
				}
			}
			x1000 = x;
			y1000 = y;
			break;
		}
		case 11:
		case 12:
		case 13:
		case 14:
			if (fraImage != null)
			{
				fraImage.drawFrameEffectSkill(frame_Buff[frBuff], x, y - 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			break;
		}
	}

	public void update()
	{
		if (isRemove)
		{
			return;
		}
		if (!isForEver)
		{
			if (typeBuff == 4)
			{
				if (CRes.random(2) == 0)
				{
					Point point = new Point();
					point.x = CRes.random_Am_0(16);
					point.y = CRes.random_Am_0(10);
					if (typeSub == 3)
					{
						point.vx = CRes.random_Am_0(3);
						point.vy = CRes.random_Am_0(2);
					}
					vecEff.addElement(point);
				}
				for (int i = 0; i < vecEff.size(); i++)
				{
					Point point2 = (Point)vecEff.elementAt(i);
					point2.update();
					if (point2.f >= 3)
					{
						vecEff.removeElement(point2);
						i--;
					}
				}
			}
			else if (typeBuff == 9)
			{
				if (GameCanvas.gameTick % 2 == 0)
				{
					create_Line_NHANBAN_LV2();
				}
				for (int j = 0; j < vecEff.size(); j++)
				{
					Line line = (Line)vecEff.elementAt(j);
					line.update();
					if (line.f >= line.fRe)
					{
						vecEff.removeElement(line);
						j--;
					}
				}
			}
			else if (typeBuff > 10 && typeBuff < 15)
			{
				frBuff++;
				if (frBuff > frame_Buff.Length - 1)
				{
					frBuff = 0;
				}
				if (timebuff - mSystem.currentTimeMillis() < 0)
				{
					isRemove = true;
				}
			}
			if (GameCanvas.gameTick % 10 == 0 && typeBuff < 11 && GameCanvas.timeNow - timeBegin > timeOff)
			{
				isRemove = true;
			}
		}
		if (minfotam != null)
		{
			minfo = minfotam;
			minfotam = null;
		}
	}

	public static void setEffHead(int sub, int time, MainObject obj)
	{
		for (int i = 0; i < obj.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)obj.vecBuff.elementAt(i);
			if (mainBuff.typeBuff == 4 && mainBuff.typeSub == sub)
			{
				mainBuff.timeBegin = GameCanvas.timeNow;
				mainBuff.timeOff = time * 1000;
				return;
			}
		}
		obj.addBuff(4, time * 1000, sub);
	}

	public static MainBuff getBuff(int index, int sub)
	{
		for (int i = 0; i < GameScreen.player.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuff.elementAt(i);
			if (mainBuff.typeBuff == index && mainBuff.typeSub == sub)
			{
				return mainBuff;
			}
		}
		return null;
	}

	public void create_Line_NHANBAN_LV2()
	{
		int num = CRes.random(1, 4);
		for (int i = 0; i < num; i++)
		{
			Line line = new Line();
			int num2 = CRes.random(3, 12);
			int num3 = 0;
			if (num2 <= 5)
			{
				line.fRe = 16;
				num3 = 2;
			}
			else if (num2 <= 8)
			{
				num3 = 4;
				line.fRe = 12;
			}
			else
			{
				num3 = 5;
				line.fRe = 9;
			}
			line.is2Line = CRes.random(5) == 0;
			int x = x1000 + CRes.random_Am_0(15);
			int num4 = y1000 - CRes.random_Am_0(10);
			line.setLine(x, num4, x, num4 - num2, 0, -num3, line.is2Line);
			line.idColor = CRes.random(3);
			line.Rec_h = CRes.random(4, 7);
			vecEff.addElement(line);
		}
	}
}
