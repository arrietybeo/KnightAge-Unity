public class ShipScr : MainScreen
{
	public static ShipScr instance;

	public sbyte ideffect = -1;

	public sbyte typeMap = 1;

	public EffectAuto eff;

	public int speed = 1;

	public short maxTime;

	public long last;

	public long curr;

	public long timeDone;

	public long timeStart;

	public bool isSpeed;

	private iCommand cmdFaster;

	private string timeC;

	public int xShip;

	public int yShip;

	public short timeSpeed;

	private long timeMove;

	public static ShipScr gI()
	{
		if (instance == null)
		{
			instance = new ShipScr();
		}
		return instance;
	}

	public void setShipScr(short maxTime)
	{
		isSpeed = false;
		left = null;
		right = null;
		cmdFaster = new iCommand(T.speedUp, -1, this);
		center = cmdFaster;
		timeStart = mSystem.currentTimeMillis();
		this.maxTime = maxTime;
		timeDone = timeStart + maxTime * 1000;
		xShip = 0;
		yShip = GameCanvas.h * 2 / 3;
		speed = 0;
		timeSpeed = 0;
		ideffect = 50;
		eff = new EffectAuto(ideffect, xShip, yShip, 0, 0, 1, 0);
		timeMove = maxTime * 1000 / (GameCanvas.w + 120);
	}

	public override void update()
	{
		timeC = LoadMap.getTimeCountDown(timeStart, maxTime);
		BackGround.updateSky();
		updateShip();
		if (isSpeed || timeDone - mSystem.currentTimeMillis() <= 10000)
		{
			center = null;
		}
		GameScreen.player.dyWater = 0;
		GameScreen.player.Action = 0;
		GameScreen.player.x = xShip + speed + 30;
		GameScreen.player.y = yShip - 40;
		GameScreen.player.Direction = 3;
		GameScreen.player.updateActionPerson();
		base.update();
	}

	public void updateShip()
	{
		curr = mSystem.currentTimeMillis();
		if (!isSpeed)
		{
			if (curr - last >= timeMove)
			{
				speed++;
				last = curr;
			}
			if (timeDone - mSystem.currentTimeMillis() <= 0)
			{
				timeDone = mSystem.currentTimeMillis() + 20000;
				GlobalService.gI().useShip(typeMap);
			}
		}
		else
		{
			speed += 2;
			if (xShip + speed >= GameCanvas.w)
			{
				timeDone = mSystem.currentTimeMillis() + 20000;
				GlobalService.gI().useShip(typeMap);
			}
		}
		if (eff != null)
		{
			eff.update();
			eff.x = speed;
		}
	}

	public override void paint(mGraphics g)
	{
		if (GameCanvas.currentScreen == this)
		{
			g.setColor(3490674);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isTrue);
			BackGround.paint_SeaAuto(g);
			paintShip(g);
			GameScreen.player.paintPlayer(g, -1);
			BackGround.paint_SeaCloud(g);
			base.paint(g);
		}
	}

	public void paintShip(mGraphics g)
	{
		if (eff != null)
		{
			eff.paint(g);
		}
	}

	public override void Show()
	{
		lastScreen = GameCanvas.game;
		base.Show();
		GameCanvas.clearAll();
		GameScreen.infoGame.resetShip();
	}

	public override void updatekey()
	{
		base.updatekey();
	}

	public override void updatePointer()
	{
		base.updatePointer();
	}

	public override void commandPointer(int index, int subIndex)
	{
		if (index == -1)
		{
			GlobalService.gI().useShip(2);
		}
	}
}
