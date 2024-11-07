public class Item_Drop : MainObject
{
	private long timeAp;

	private int timeRemove;

	private int timefly;

	public Item_Drop(int ID, sbyte type, string name, int x, int y, short IdIcon, sbyte color)
	{
		base.ID = ID;
		typeObject = type;
		base.name = name;
		if (x < 48)
		{
			x = 48;
		}
		if (x > GameCanvas.loadmap.maxWMap - 48)
		{
			x = GameCanvas.loadmap.maxWMap - 48;
		}
		if (y < 48)
		{
			y = 48;
		}
		if (y > GameCanvas.loadmap.maxHMap - 48)
		{
			y = GameCanvas.loadmap.maxHMap - 48;
		}
		base.x = x;
		base.y = y;
		imageId = IdIcon;
		colorName = color;
		vx = CRes.random_Am(1, 5);
		vy = -CRes.random(3, 10);
		vMax = 16;
		time = CRes.random(3, 9);
		timeAp = GameCanvas.timeNow;
		timeRemove = 60;
		isSend = false;
	}

	public override void paint(mGraphics g)
	{
		MainImage mainImage = null;
		switch (typeObject)
		{
		case 3:
			mainImage = ObjectData.getImageItem((short)imageId);
			break;
		case 4:
			mainImage = ObjectData.getImagePotion((short)imageId);
			break;
		case 5:
			mainImage = ObjectData.getImageQuestItem((short)imageId);
			break;
		case 7:
			mainImage = ObjectData.getImageMaterial((short)imageId);
			break;
		}
		if (mainImage.img != null)
		{
			if (hOne == 0)
			{
				hOne = mImage.getImageHeight(mainImage.img.image);
			}
			g.drawImage(mainImage.img, x, y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
			if (typeObject == 3 && colorName > 1)
			{
				Item.fraeffitemdrop.drawFrame((colorName - 1) * 3 + GameCanvas.gameTick / 3 % 3, x + 6, y - 14, 0, 3, g);
			}
		}
		if (isWater)
		{
			g.drawRegion(MainObject.water, 0, GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, x, y - 2 + dyWater, 3, mGraphics.isFalse);
		}
		if (PaintInfoGameScreen.isLevelPoint)
		{
			int id = 0;
			if (typeObject == 3)
			{
				id = colorName;
			}
			paintName(g, id);
		}
	}

	public override void paintAvatarFocus(mGraphics g, int xp, int yp)
	{
		MainImage mainImage = null;
		switch (typeObject)
		{
		case 3:
			mainImage = ObjectData.getImageItem((short)imageId);
			break;
		case 4:
			mainImage = ObjectData.getImagePotion((short)imageId);
			break;
		case 5:
			mainImage = ObjectData.getImageQuestItem((short)imageId);
			break;
		case 7:
			mainImage = ObjectData.getImageMaterial((short)imageId);
			break;
		}
		if (mainImage.img != null)
		{
			if (hOne == 0)
			{
				hOne = mImage.getImageHeight(mainImage.img.image);
			}
			g.drawImage(mainImage.img, xp - 1, yp, 3, mGraphics.isFalse);
		}
	}

	public override void update()
	{
		if (time > 0)
		{
			x += vx;
			y += vy;
			vy += 2;
			time--;
		}
		if (time == 0)
		{
			int tile = GameCanvas.loadmap.getTile(x, y);
			if (tile == 2)
			{
				isWater = true;
			}
			isRunAttack = false;
			time = -1;
		}
		if (isRunAttack)
		{
			timefly++;
			x += vx;
			y += vy;
			if (timefly >= timeHuyKill)
			{
				isRemove = true;
				isRunAttack = false;
			}
		}
		if (isSend)
		{
			timeGet++;
			if (timeGet > 40)
			{
				isSend = false;
				timeGet = 0;
			}
		}
		if ((GameCanvas.timeNow - timeAp) / 1000 >= timeRemove)
		{
			isRemove = true;
		}
	}
}
