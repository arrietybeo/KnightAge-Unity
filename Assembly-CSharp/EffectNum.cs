public class EffectNum : MainEffect
{
	public const sbyte COLOR_NORMAL = 0;

	public const sbyte COLOR_XP = 1;

	public const sbyte COLOR_FIRE = 2;

	public const sbyte COLOR_PLUS_HP = 3;

	public const sbyte COLOR_PLUS_MP = 4;

	public const sbyte COLOR_PUT_ITEM = 5;

	public const sbyte COLOR_FIRE_PERSON = 6;

	public const sbyte COLOR_EFF_CRI = 7;

	public const sbyte COLOR_OPTION = 8;

	public const sbyte COLOR_EFF_MON_FIRE = 9;

	public const sbyte COLOR_DAME_LIGHT = 10;

	public const sbyte COLOR_DAME_DRAK = 11;

	private string strContent;

	private int typeNum;

	private new int fRemove;

	private mFont fontPaint;

	private bool isGravity;

	public EffectNum(string strContent, int x, int y, int typeColor)
	{
		isGravity = false;
		this.strContent = strContent;
		base.x = x;
		base.y = y + CRes.random_Am_0(5);
		typeNum = typeColor;
		fontPaint = mFont.tahoma_7b_white;
		if (typeNum < 0)
		{
			fontPaint = MainTabNew.setTextColorName(-typeColor);
		}
		else
		{
			switch (typeColor)
			{
			case 1:
				fontPaint = mFont.tahoma_7_green;
				break;
			case 2:
			case 6:
			case 7:
			case 9:
				isGravity = true;
				break;
			case 5:
				fontPaint = mFont.tahoma_7_white;
				break;
			case 8:
				fontPaint = MainTabNew.setTextColor(typeColor);
				break;
			case 10:
				fontPaint = mFont.tahoma_7b_yellow;
				break;
			case 11:
				fontPaint = mFont.tahoma_7b_violet;
				break;
			}
		}
		if (isGravity)
		{
			vy = -CRes.random(11, 14);
			fRemove = CRes.random(20, 25);
		}
		else
		{
			vy = -CRes.random(2, 4);
			fRemove = CRes.random(24, 32);
		}
	}

	public EffectNum(string strContent, int x, int y, int typeColor, int sub)
	{
		this.strContent = strContent;
		base.x = x;
		base.y = y + CRes.random_Am_0(5);
		typeNum = typeColor;
		fontPaint = mFont.tahoma_7b_white;
		vy = -CRes.random(11, 14);
		isGravity = true;
		fRemove = CRes.random(20, 25);
		if (typeNum < 0)
		{
			fontPaint = MainTabNew.setTextColorName(-sub);
		}
		else if (typeColor == 8)
		{
			fontPaint = MainTabNew.setTextColor(sub);
		}
	}

	public override void paint(mGraphics g)
	{
		switch (typeNum)
		{
		case 2:
			AvMain.Font3dWhite(g, strContent, x, y, 2);
			break;
		case 6:
			AvMain.Font3dColor(g, strContent, x, y, 2, 4);
			break;
		case 7:
			AvMain.Font3dColor(g, strContent, x, y, 2, 2);
			break;
		case 4:
			AvMain.Font3dColor(g, strContent, x, y, 2, 1);
			break;
		case 3:
			AvMain.Font3dColor(g, strContent, x, y, 2, 5);
			break;
		case 1:
		case 5:
			fontPaint.drawString(g, strContent, x, y, 2, mGraphics.isFalse);
			break;
		case 9:
			AvMain.Font3dColor(g, strContent, x, y, 2, 6);
			break;
		default:
			fontPaint.drawString(g, strContent, x, y, 2, mGraphics.isFalse);
			break;
		}
	}

	public override void update()
	{
		f++;
		if (isGravity)
		{
			vy++;
		}
		base.update();
		if (f >= fRemove)
		{
			isStop = true;
		}
	}
}
