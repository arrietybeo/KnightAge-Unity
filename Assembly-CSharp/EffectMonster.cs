using System;

public class EffectMonster
{
	public const sbyte mon_Tower1 = 89;

	public const sbyte mon_Tower2 = 90;

	public const sbyte mon_Tower3 = 91;

	public const sbyte mon_Tower4 = 92;

	public static mVector listEffectMonster = new mVector("EffectMonster listEffectMonster");

	private FrameImage imgAuto;

	private FrameImage imgDie;

	private FrameImage imgEff;

	private bool isPaint = true;

	private bool isUpdate;

	private bool isPaintDie = true;

	private int x;

	private int y;

	private int w;

	private int h;

	private int dx;

	private int dy;

	private int f;

	private int idMon;

	private int wImg;

	private int hImg;

	private int fDie;

	private int dxDie;

	private int dyDie;

	private MainObject monster;

	public sbyte[] nFrame = new sbyte[8] { 0, 0, 1, 1, 2, 2, 3, 3 };

	public sbyte[] nFramedie = new sbyte[8];

	public static bool buffDame = false;

	public static void addEffectMonster(MainMonster mon)
	{
		EffectMonster effectMonster = new EffectMonster();
		effectMonster.idMon = mon.catalogyMonster;
		effectMonster.monster = mon;
		if (effectMonster.monster.isMonsterHouse())
		{
			if (effectMonster.idMon == 89)
			{
				effectMonster.imgAuto = new FrameImage(mImage.createImage("/eff/g128.png"), 53, 49);
				effectMonster.imgDie = ItemMap.img_HouseArena_Die[0];
				effectMonster.dx = -3;
				effectMonster.dy = 70;
				effectMonster.dxDie = 0;
				effectMonster.dyDie = -effectMonster.imgDie.frameHeight - 2;
			}
			else if (effectMonster.idMon == 90)
			{
				effectMonster.imgAuto = new FrameImage(mImage.createImage("/eff/g129.png"), 44, 44);
				effectMonster.imgDie = ItemMap.img_HouseArena_Die[1];
				effectMonster.dx = 0;
				effectMonster.dy = 30;
				effectMonster.dxDie = 0;
				effectMonster.dyDie = -effectMonster.imgDie.frameHeight;
			}
			else if (effectMonster.idMon == 91)
			{
				effectMonster.imgAuto = new FrameImage(mImage.createImage("/eff/g130.png"), 50, 51);
				effectMonster.imgDie = ItemMap.img_HouseArena_Die[2];
				effectMonster.dx = 0;
				effectMonster.dy = 20;
				effectMonster.dxDie = 5;
				effectMonster.dyDie = -effectMonster.imgDie.frameHeight;
			}
			else if (effectMonster.idMon == 92)
			{
				effectMonster.imgAuto = new FrameImage(mImage.createImage("/eff/g131.png"), 40, 40);
				effectMonster.imgDie = ItemMap.img_HouseArena_Die[3];
				effectMonster.dx = 22;
				effectMonster.dy = 22;
				effectMonster.dxDie = 5;
				effectMonster.dyDie = -effectMonster.imgDie.frameHeight;
			}
			effectMonster.x = mon.x;
			effectMonster.y = mon.y;
			effectMonster.w = (effectMonster.h = -1);
			effectMonster.h = mon.hOne;
			effectMonster.wImg = effectMonster.imgAuto.frameWidth;
			effectMonster.hImg = effectMonster.imgAuto.frameHeight;
			effectMonster.isPaint = true;
			effectMonster.isUpdate = true;
			effectMonster.isPaintDie = false;
			effectMonster.f = 0;
			effectMonster.fDie = 0;
			effectMonster.imgEff = new FrameImage(68);
			listEffectMonster.addElement(effectMonster);
		}
	}

	public void setTurnOff()
	{
		if (isPaintDie)
		{
			isPaint = false;
		}
		if (!isPaintDie)
		{
			isPaintDie = true;
		}
	}

	public void update()
	{
		if (!isUpdate)
		{
			return;
		}
		if (buffDame)
		{
			if (nFrame != new sbyte[8] { 0, 0, 1, 1, 2, 2, 3, 3 })
			{
				nFrame = new sbyte[8] { 0, 0, 1, 1, 2, 2, 3, 3 };
			}
		}
		else if (nFrame != new sbyte[12]
		{
			0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
			3, 3
		})
		{
			nFrame = new sbyte[12]
			{
				0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
				3, 3
			};
		}
		if (monster.hp > 0)
		{
			f++;
			if (f > nFrame.Length - 1)
			{
				f = 0;
			}
			x = monster.x;
			y = monster.y;
		}
		else
		{
			setTurnOff();
		}
		if (GameScreen.timeArena != 0L && mSystem.currentTimeMillis() - GameScreen.timeArena > 2700000)
		{
			setTurnOff();
		}
	}

	public void paint(mGraphics g)
	{
		try
		{
			if (isPaint && imgAuto != null)
			{
				if (w < 0)
				{
					w = monster.wOne;
					h = monster.hOne;
				}
				imgAuto.drawFrame(nFrame[f], x - wImg / 2 + dx, y - h - hImg + dy, 0, g);
			}
		}
		catch (Exception)
		{
			isPaint = false;
			isUpdate = false;
			isPaintDie = false;
		}
	}

	public void paintDie(mGraphics g)
	{
		try
		{
			if (isPaintDie && imgDie != null)
			{
				if (w < 0)
				{
					w = monster.wOne;
					h = monster.hOne;
				}
				imgDie.drawFrame(nFramedie[fDie], x - w / 2 + dxDie, y + dyDie, 0, g);
			}
		}
		catch (Exception)
		{
			isPaint = false;
			isUpdate = false;
			isPaintDie = false;
		}
	}
}
