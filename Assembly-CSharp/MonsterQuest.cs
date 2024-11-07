public class MonsterQuest : MainMonster
{
	private int fpos;

	private bool isReveiceQuest;

	private static sbyte[] mFrameImg = new sbyte[14]
	{
		0, 1, 2, 3, 4, 5, 5, 5, 5, 4,
		3, 2, 1, 0
	};

	private static sbyte[][] mPosImg = new sbyte[2][]
	{
		new sbyte[8],
		new sbyte[8] { 0, 0, -1, -1, 0, 0, 1, 1 }
	};

	private int test;

	private int hRe;

	public MonsterQuest(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
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
		nFrame = 6;
		wOne = (hOne = -1);
		ysai = -2;
	}

	public override void paint(mGraphics g)
	{
		if (isDie)
		{
			return;
		}
		MainImage imagePartMonster = ObjectData.getImagePartMonster((short)catalogyMonster);
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
			int num = mFrameImg[f / 3] * hOne;
			if (catalogyMonster > 92)
			{
				x = mFrameImg[f / 3] / 3 * wOne;
				num = mFrameImg[f / 3] % 3 * hOne;
			}
			if (isReveiceQuest)
			{
				if (timeTanHinh > test)
				{
					g.drawRegion(imagePartMonster.img, x, num, wOne, hRe, 0, base.x, y - hOne / 2, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
					g.drawRegion(imagePartMonster.img, x, num + hOne - hRe, wOne, hRe, 0, base.x, y - hOne / 2 + hRe, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			else
			{
				g.drawRegion(imagePartMonster.img, x, num, wOne, hOne, 0, base.x + mPosImg[0][fpos / 3], y + mPosImg[1][fpos / 3], mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
			}
		}
		if (Action != 4 && !isReveiceQuest)
		{
			paintName(g, 0);
		}
	}

	public override void update()
	{
		setDie();
		if (Action != 4)
		{
			if (isReveiceQuest)
			{
				timeTanHinh++;
				hRe += 2;
				if (hRe >= (hOne - 1) / 2)
				{
					isReveiceQuest = false;
					timeTanHinh = 0;
					hRe = 10;
				}
			}
			f++;
			if (f / 3 > mFrameImg.Length - 1)
			{
				f = 0;
			}
			fpos++;
			if (fpos / 3 > mPosImg[0].Length - 1)
			{
				fpos = 0;
			}
		}
		base.update();
	}

	public new void setDie()
	{
		if (Action == 4)
		{
			if (CRes.random(3) == 1)
			{
				if (CRes.random(2) == 1)
				{
					LoadMap.timeVibrateScreen = 103;
				}
				int num = CRes.random(1, 3);
				for (int i = 0; i < num; i++)
				{
					int num2 = CRes.random_Am_0(20);
					int num3 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, x + num2, y + num3 - hOne / 2);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, x + num2, y + num3 - hOne / 2);
					}
				}
			}
			if (timeReveice >= 0 && (GameCanvas.timeNow - timedie) / 1000 > timeReveice - 1)
			{
				Reveive();
				isReveiceQuest = true;
				timeTanHinh = 0;
				hRe = 10;
				GameScreen.addEffectKill(81, x, y - 20, 200, 0, 0);
				GameScreen.addEffectEndKill(39, x, y - hOne / 2);
			}
		}
		else if (hp <= 0)
		{
			hp = 0;
			Action = 4;
			resetXY();
			timedie = GameCanvas.timeNow;
		}
	}
}
