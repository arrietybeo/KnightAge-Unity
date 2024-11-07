using System;

public class PetFly : Pet
{
	public sbyte[] dypet = new sbyte[3] { 0, 5, 5 };

	public sbyte dyshadow;

	private int xs;

	private int ys;

	private int act;

	private int fr;

	public PetFly(MainObject owner, short petType, sbyte nFrame, sbyte imageId, sbyte typemove)
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
		yfly = 50;
		if (imageId == 3 || imageId == 9)
		{
			dyshadow = 0;
		}
		else
		{
			dyshadow = 6;
		}
	}

	public PetFly(short typePet, int id, sbyte frame, sbyte imageId, sbyte typemove)
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
		state = 0;
		timeAutoAction = CRes.random(200, 250);
		MonWater = 3;
		limitAttack = 10;
		timeMaxMoveAttack = 0;
		yfly = 50;
		if (imageId == 3 || imageId == 9)
		{
			dyshadow = 0;
		}
		else
		{
			dyshadow = 6;
		}
	}

	protected override void roam()
	{
		switch (typemove)
		{
		case 2:
			vMax = 1;
			if (Action == 1)
			{
				if ((time > timeAutoAction || MainObject.getDistance(x + vx, y + vy, xAnchor, yAnchor) >= limitMove) && yfly >= 50)
				{
					if (count > 20 && !isWater)
					{
						time = 0;
						vx = 0;
						vy = 0;
						Action = 0;
						count = 0;
					}
					if (count <= 20)
					{
						count++;
					}
				}
			}
			else if (Action == 0)
			{
				vx = 0;
				vy = 0;
				if (yfly >= 0)
				{
					yfly -= 5;
				}
				if (GameCanvas.gameTick % 30 == 0)
				{
					Direction = CRes.random(4);
				}
				if (time > timeAutoAction && yfly <= 0)
				{
					time = 0;
					setSpeedInDirection(vMax);
					Action = 1;
				}
			}
			if (owner != null)
			{
				if (owner.Action == 1)
				{
					if (MainObject.getDistance(x, y, ownerX, ownerY) > 40)
					{
						setState(1);
					}
				}
				else if (owner.Action == 0 && MainObject.getDistance(x, y, ownerX, ownerY) > limitMove * 2)
				{
					setState(3);
				}
			}
			else
			{
				int distance2 = MainObject.getDistance(x, y, GameScreen.player.x, GameScreen.player.y);
				if (distance2 < 80 && distance2 > 40 && CRes.random(6) == 0)
				{
					setState(6);
				}
			}
			break;
		case 1:
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
			break;
		}
	}

	public override void paint(mGraphics g)
	{
		try
		{
			paintDataEff_Top(g, x, y);
			paintBuffFirst(g);
			if (state == 1 && (Direction == 1 || Direction == 0))
			{
				Direction = PrevDir;
			}
			MainImage imagePet = ObjectData.getImagePet(imageId);
			if (imagePet.img != null)
			{
				if (wOne < 0)
				{
					hOne = mImage.getImageHeight(imagePet.img.image) / nFrame;
					wOne = mImage.getImageWidth(imagePet.img.image) / 2;
				}
				g.drawImage(MainObject.shadow, x + xtam, y - dyshadow, 3, mGraphics.isFalse);
				if (isWater && yfly <= 0)
				{
					g.drawRegion(imagePet.img, xs, ys, wOne, hOne, (Direction > 2) ? 2 : 0, x + xtam, y + dyWater + 8, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
					g.drawRegion(MainObject.water, 0, ((Action != 0) ? 2 : 0) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, x + xtam, y + dyWater - 8, 3, mGraphics.isFalse);
				}
				else
				{
					g.drawRegion(imagePet.img, xs, ys, wOne, hOne, (Direction > 2) ? 2 : 0, x + xtam, y - yfly, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			paintBuffLast(g);
			paintDataEff_Bot(g, x, y);
		}
		catch (Exception)
		{
		}
	}

	protected override void attack()
	{
		vMax = 12;
		if (vecObjskill == null || vecObjskill.size() <= 0)
		{
			return;
		}
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjskill.elementAt(attackCount);
		MainObject mainObject = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
		if (mainObject == null || mainObject.hp <= 0)
		{
			isRunAttack = false;
			setState(4);
			return;
		}
		toX = mainObject.x;
		toY = mainObject.y;
		move_to_XY();
		if (MainObject.getDistance(x + vx, y + vy, mainObject.x, mainObject.y) < 30)
		{
			if (yfly >= 15)
			{
				yfly -= 15;
			}
			f = 4;
			if (yfly <= 15)
			{
				addAttackEffect();
				setState(4);
			}
		}
		else if (yfly <= 50)
		{
			yfly += 5;
		}
	}

	public override void update()
	{
		act = Action;
		if (act > mAction.Length - 1)
		{
			act = 0;
		}
		if (f > mAction[act][(Direction <= 2) ? Direction : 2].Length - 1)
		{
			f = 0;
		}
		fr = mAction[act][(Direction <= 2) ? Direction : 2][f] / 3;
		xs = ((fr > 1) ? 1 : fr) * wOne;
		fr = mAction[act][(Direction <= 2) ? Direction : 2][f];
		ys = fr % 3 * hOne;
		if (xs == -1)
		{
			xs = 0;
		}
		if (ys == -1)
		{
			ys = 0;
		}
		if (yfly <= 0)
		{
			xs = (ys = 0);
		}
		if (((vx < 0 && vy > 0) || (vx > 0 && vy > 0)) && state == 0 && yfly >= 30)
		{
			f = 3;
			if (vx < 0)
			{
				vx = -3;
			}
			else
			{
				vx = 3;
			}
			if (vy < 0)
			{
				vy = -3;
			}
			else
			{
				vy = 3;
			}
		}
		base.update();
	}
}
