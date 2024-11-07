public class MagicBeam : IArrow
{
	public int power;

	public int type;

	public short effect;

	public int hpLost;

	public int frame;

	public int idfollow;

	public int idend;

	public int w;

	public int h;

	public int x;

	public int y;

	public int Efftail;

	public int Effend;

	private MainObject owner;

	private MainObject target;

	public MagicLogic arrow = new MagicLogic();

	private sbyte fra;

	private FrameImage img;

	public override void setAngle(int angle)
	{
		arrow.setAngle(angle);
	}

	public void setEff(int tail, int end)
	{
		Efftail = tail;
		Effend = end;
	}

	public override void set(int type, int x, int y, int power, short effect, MainObject owner, MainObject target)
	{
		arrow.set(type, x, y, owner.getDir(), target);
		this.type = type;
		this.owner = owner;
		this.effect = effect;
		if (type == 20)
		{
			type = 2;
		}
		hpLost = power;
		Efftail = -1;
		Effend = -1;
		this.power = power;
		wantDestroy = false;
		img = new FrameImage(effect);
		this.target = target;
	}

	public override void update()
	{
		arrow.updateAngle();
		x = arrow.x;
		y = arrow.y;
		if (Efftail != -1)
		{
			EffectEnd eff = new EffectEnd(57, Efftail, x, y);
			EffectManager.addHiEffect(eff);
		}
		if (arrow.isEnd)
		{
			onArrowTouchTarget();
		}
	}

	public override void onArrowTouchTarget()
	{
		if (Effend != -1)
		{
			if (power < 0)
			{
				GameScreen.addEffectNum(string.Empty + power, target.x, target.y - target.hOne, 2, target.ID);
			}
			if (power > 0)
			{
				GameScreen.addEffectNum("+" + power, target.x, target.y - target.hOne, 0, target.ID);
			}
			GameScreen.addEffectEndFromSv(57, Effend, x, y);
		}
		wantDestroy = true;
	}

	public override void paint(mGraphics g)
	{
		if (img != null)
		{
			img.drawFrameEffectSkill(fra, x, y, arrow.headTransform, 3, g);
		}
	}

	public override void SetEffFollow(int id)
	{
		idfollow = id;
	}
}
