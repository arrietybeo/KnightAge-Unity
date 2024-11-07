using System;

public class PetWalk : Pet
{
	public PetWalk(MainObject owner, short petType, sbyte nFrame, sbyte imageId, sbyte typemove)
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
		limitMove = 60;
		Direction = 0;
		vMax = 4;
		Action = 0;
		state = 0;
		timeAutoAction = CRes.random(50, 70);
		MonWater = 0;
		limitAttack = 30;
		timeMaxMoveAttack = 0;
	}

	public PetWalk(short petType, int id, sbyte nFrame, sbyte imageId, sbyte typemove)
		: base(petType, nFrame, imageId, typemove)
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
		limitMove = 120;
		Direction = 0;
		vMax = 4;
		Action = 0;
		state = 0;
		timeAutoAction = CRes.random(50, 70);
		MonWater = 3;
		limitAttack = 200;
		timeMaxMoveAttack = 0;
	}

	public override void paint(mGraphics g)
	{
		try
		{
			paintDataEff_Top(g, x, y);
			paintBuffFirst(g);
			MainImage imagePet = ObjectData.getImagePet(imageId);
			if (state == 1 && (Direction == 1 || Direction == 0))
			{
				Direction = PrevDir;
			}
			int num = Action;
			if (num > mAction.Length - 1)
			{
				num = 0;
			}
			if (f > mAction[num][(Direction <= 2) ? Direction : 2].Length - 1)
			{
				f = 0;
			}
			if (imagePet.img != null)
			{
				if (wOne < 0)
				{
					hOne = mImage.getImageHeight(imagePet.img.image) / nFrame;
					wOne = mImage.getImageWidth(imagePet.img.image) / 2;
				}
				int num2 = 0;
				int num3 = 0;
				num2 = mAction[num][(Direction <= 2) ? Direction : 2][f] / 3 * wOne;
				num3 = mAction[num][(Direction <= 2) ? Direction : 2][f] % 3 * hOne;
				if (isWater)
				{
					g.drawRegion(imagePet.img, num2, num3, wOne, hOne, (Direction > 2) ? 2 : 0, x + xtam, y + dyWater + 4, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
					int num4 = 1;
					g.drawRegion(MainObject.water, 0, ((num != 0) ? 2 : 0) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, x + num4 + xtam, y + dyWater - 4, 3, mGraphics.isFalse);
				}
				else
				{
					g.drawRegion(imagePet.img, num2, num3, wOne, hOne, (Direction > 2) ? 2 : 0, x + xtam, y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
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
		if (skillDefault == null)
		{
			skillDefault = new Monster_Skill(2);
		}
		vMax = 9;
		if (vecObjskill == null || vecObjskill.size() <= 0)
		{
			return;
		}
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vecObjskill.elementAt(attackCount);
		MainObject mainObject = MainObject.get_Object(object_Effect_Skill.ID, object_Effect_Skill.tem);
		if (mainObject == null)
		{
			isRunAttack = false;
		}
		else if (MainObject.getDistance(x + vx, y + vy, mainObject.x, mainObject.y) > limitAttack && mainObject.hp > 0)
		{
			toX = mainObject.x;
			toY = mainObject.y;
			move_to_XY();
		}
		else
		{
			if (GameCanvas.timeNow - timeBeginMoveAttack <= timeMaxMoveAttack)
			{
				return;
			}
			IDAttack = object_Effect_Skill.ID;
			object_Effect_Skill.skillMonster = skillDefault;
			beginFire();
			addAttackEffect();
			timeMaxMoveAttack = 200;
			timeBeginMoveAttack = GameCanvas.timeNow;
			if (attackType == 2)
			{
				if (attackCount >= vecObjskill.size() - 1)
				{
					isDoneAttack = false;
					setState(4);
					attackCount = 0;
				}
			}
			else if (attackType == 5 && attackCount == 3)
			{
				isDoneAttack = false;
				setState(4);
				attackCount = 0;
			}
		}
	}
}
