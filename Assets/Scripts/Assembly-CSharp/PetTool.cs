using System;

public class PetTool : Pet
{
	public const sbyte M_STAND = 0;

	public const sbyte M_DEAD = 1;

	public const sbyte M_WALK = 2;

	public const sbyte M_ATTACK = 3;

	public new sbyte mAction;

	public int huongY;

	public int flip;

	public bool isBeginAttack;

	private mImage imgp;

	public int p1;

	public int maxAttack;

	public PetTool()
	{
	}

	public PetTool(short typePet, sbyte nFrame, sbyte imageId, sbyte typemove)
		: base(typePet, nFrame, imageId, typemove)
	{
	}

	public PetTool(MainObject owner, short petType, sbyte nFrame, sbyte imageId, sbyte typemove)
		: base(petType, nFrame, imageId, typemove)
	{
		base.owner = owner;
		typeObject = 9;
		ID = owner.ID;
		xAnchor = owner.x;
		yAnchor = owner.y;
		x = owner.x;
		y = owner.y;
		oldPosX = owner.x;
		oldPosY = owner.y;
		wOne = -1;
		hOne = -1;
		limitMove = 48;
		Direction = 0;
		vMax = 4;
		Action = 0;
		state = 0;
		timeAutoAction = CRes.random(200, 250);
		MonWater = 0;
		limitAttack = 10;
		timeMaxMoveAttack = 0;
		isPetTool = true;
	}

	public PetTool(short typePet, int id, sbyte frame, sbyte imageId, sbyte typemove)
		: base(typePet, frame, imageId, typemove)
	{
		owner = null;
		typeObject = 9;
		ID = id;
		int num = posArray[CRes.random(posArray.Length)].x;
		int num2 = posArray[CRes.random(posArray.Length)].y;
		xAnchor = num;
		yAnchor = num2;
		x = num;
		y = num2;
		oldPosX = num;
		oldPosY = num2;
		wOne = -1;
		hOne = -1;
		limitMove = 48;
		Direction = 0;
		vMax = 4;
		Action = 0;
		mAction = 0;
		state = 0;
		timeAutoAction = CRes.random(200, 250);
		MonWater = 3;
		limitAttack = 10;
		timeMaxMoveAttack = 0;
		isPetTool = true;
	}

	public override void paint(mGraphics g)
	{
		mVector mVector3 = new mVector();
		mVector mVector4 = (mVector)Pet.PET_DATA.get(string.Empty + imageId);
		if (mVector4 != null)
		{
			mVector3 = mVector4;
		}
		if (mVector3.size() == 0)
		{
			return;
		}
		try
		{
			DataEffect dataEffect = (DataEffect)mVector3.elementAt(0);
			if (dataEffect == null)
			{
				return;
			}
			paintDataEff_Top(g, x, y);
			int action = mAction;
			if (state == 2 && isBeginAttack)
			{
				action = 3;
			}
			int num = 0;
			int action2 = Action;
			if (isFly())
			{
				num = 35;
				g.drawImage(MainObject.shadow, x, y - 6, 3, mGraphics.isFalse);
			}
			else
			{
				if (!isWater)
				{
					g.drawImage(MainObject.shadow, x, y, 3, mGraphics.isFalse);
				}
				if (isWater)
				{
					g.drawRegion(MainObject.water, 0, ((action2 != 0) ? 2 : 0) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, x + 1 + xtam, y + dyWater - 4, 3, mGraphics.isFalse);
				}
			}
			MainImage imagePet = ObjectData.getImagePet(imageId);
			mVector mVector5 = (mVector)Pet.PET_DATA.get(string.Empty + imageId);
			if (mVector5 != null && imagePet != null && imagePet.img != null)
			{
				dataEffect.paintPet(g, dataEffect.getFrame(frame, action, huongY), x, y - num, flip, imagePet.img);
			}
			paintDataEff_Bot(g, x, y);
		}
		catch (Exception)
		{
		}
	}

	public void doChangeFrmaeBoss()
	{
		mVector mVector3 = new mVector();
		mVector mVector4 = (mVector)Pet.PET_DATA.get(string.Empty + imageId);
		if (mVector4 != null)
		{
			mVector3 = mVector4;
		}
		DataEffect dataEffect = null;
		if (mVector3.size() > 0)
		{
			dataEffect = (DataEffect)mVector3.elementAt(0);
			int action = mAction;
			if (state == 2 && isBeginAttack)
			{
				action = 3;
			}
			frame = (sbyte)((frame + 1) % dataEffect.getAnim(action, huongY).frame.Length);
			if (maxAttack == 0)
			{
				maxAttack = dataEffect.getAnim(3, huongY).frame.Length;
			}
		}
	}

	public override void update()
	{
		doChangeFrmaeBoss();
		try
		{
			base.update();
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
			switch (state)
			{
			case 0:
				roam();
				break;
			case 1:
				mAction = 2;
				follow();
				break;
			case 2:
				attack();
				break;
			case 3:
				mAction = 2;
				returnToPlayer();
				break;
			case 4:
				mAction = 0;
				waitForCommand();
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

	protected override void returnToPlayer()
	{
		vMax = owner.vMax;
		toX = owner.x;
		toY = owner.y;
		setHuong(toX, toY);
		move_to_XY();
		if (MainObject.getDistance(x, y, xAnchor, yAnchor) < 40 && owner.Action != 2)
		{
			setState(0);
		}
	}

	protected override void attack()
	{
		vMax = 12;
		if (vecObjskill == null || vecObjskill.size() <= 0)
		{
			return;
		}
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjskill.elementAt(0);
		MainObject mainObject = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
		if (mainObject == null)
		{
			isRunAttack = false;
			setState(4);
			return;
		}
		if (MainObject.getDistance(x + vx, y + vy, mainObject.x, mainObject.y) > 30 && !isBeginAttack && mainObject.hp > 0)
		{
			toX = mainObject.x;
			toY = mainObject.y;
			setHuong(toX, toY);
			move_to_XY();
			mAction = 2;
		}
		else
		{
			isBeginAttack = true;
		}
		p1++;
		if (p1 <= maxAttack || !isBeginAttack)
		{
			return;
		}
		try
		{
			setHuong(mainObject.x, mainObject.y);
			switch (attackType)
			{
			case 11:
			{
				for (int j = 0; j < vecObjskill.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)vecObjskill.elementAt(j);
					if (object_Effect_Skill3 != null)
					{
						MainObject mainObject3 = MainObject.get_Object(object_Effect_Skill3.ID, object_Effect_Skill3.tem);
						if (mainObject3 != null)
						{
							GameScreen.startNewMagicBeam(15, this, mainObject3, x, y, -1 * object_Effect_Skill3.hpShow, 163, 163, 24);
						}
					}
				}
				break;
			}
			case 12:
			{
				for (int i = 0; i < vecObjskill.size(); i++)
				{
					Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)vecObjskill.elementAt(i);
					if (object_Effect_Skill2 != null)
					{
						MainObject mainObject2 = MainObject.get_Object(object_Effect_Skill2.ID, object_Effect_Skill2.tem);
						if (mainObject2 != null)
						{
							GameScreen.addEffectEndFromSv(57, 21, mainObject2.x, mainObject2.y);
							GameScreen.addEffectNum("-" + object_Effect_Skill2.hpShow, mainObject2.x, mainObject2.y - mainObject2.hOne, 2, mainObject2.ID);
						}
					}
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
		p1 = 0;
		isBeginAttack = false;
		setState(4);
	}

	protected override void roam()
	{
		vMax = 1;
		if (Action == 1)
		{
			if (time > timeAutoAction || CRes.random(16) == 0 || MainObject.getDistance(x + vx, y + vy, xAnchor, yAnchor) >= limitMove)
			{
				time = 0;
				Action = 0;
				mAction = 0;
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
				mAction = 2;
				Direction = CRes.random(4);
				setSpeedInDirection(vMax);
			}
		}
		if (owner != null)
		{
			if (owner.Action == 1 && MainObject.getDistance(x, y, ownerX, ownerY) > 40)
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

	public new void setSpeedInDirection(int max)
	{
		int a = CRes.random_Am_0(3);
		if (CRes.abs(a) > 1)
		{
			max--;
		}
		switch (Direction)
		{
		case 1:
			vy = -max;
			vx = a;
			break;
		case 0:
			vy = max;
			vx = a;
			break;
		case 2:
			vy = a;
			vx = -max;
			break;
		case 3:
			vy = a;
			vx = max;
			break;
		}
		if (vx == 0 && CRes.random(3) == 0)
		{
			time = 0;
			Action = 0;
			vx = 0;
			vy = 0;
			mAction = 0;
		}
		if (vx > 0)
		{
			Direction = 3;
		}
		else
		{
			Direction = 2;
		}
		huongY = (sbyte)((y > toY) ? 1 : 0);
		flip = (sbyte)((x - toX <= 0) ? 2 : 0);
		flip = 0;
		if (Direction == 3)
		{
			flip = 2;
		}
		else if (Direction != 2)
		{
			if (Direction == 0)
			{
				huongY = 0;
			}
			else if (Direction == 1)
			{
				huongY = 1;
			}
		}
	}

	protected override void follow()
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
			setHuong(toX, toY);
			move_to_XY();
		}
	}

	public void setHuong(int xto, int yto)
	{
		huongY = (sbyte)((y > yto) ? 1 : 0);
		flip = (sbyte)((x - xto <= 0) ? 2 : 0);
		flip = 0;
		if (Direction == 3)
		{
			flip = 2;
		}
		else if (Direction != 2)
		{
			if (Direction == 0)
			{
				huongY = 0;
			}
			else if (Direction == 1)
			{
				huongY = 1;
			}
		}
	}

	public bool isFly()
	{
		mVector mVector3 = new mVector();
		mVector mVector4 = (mVector)Pet.PET_DATA.get(string.Empty + imageId);
		if (mVector4 != null)
		{
			mVector3 = mVector4;
		}
		DataEffect dataEffect = (DataEffect)mVector3.elementAt(0);
		if (dataEffect != null && dataEffect.isFly <= -5)
		{
			return true;
		}
		return false;
	}
}
