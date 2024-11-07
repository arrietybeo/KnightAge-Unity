public class Effect_UpLv_Item
{
	private int wnew = 1;

	private int[][] colorBorder = new int[5][]
	{
		new int[7] { 16777215, 16777215, 15724527, 15724527, 12698049, 12698049, 10526880 },
		new int[7] { 2679551, 2679551, 2672631, 2672631, 2663136, 2663136, 2528153 },
		new int[7] { 16775936, 16775936, 15525376, 15525376, 12827395, 12827395, 11182595 },
		new int[7] { 16353279, 16353279, 15303935, 15303935, 13008383, 13008383, 10842574 },
		new int[7] { 16757058, 16757058, 16750903, 16750903, 16742429, 16742429, 13597998 }
	};

	private int[] size = new int[5] { 1, 1, 1, 1, 1 };

	public void paintUpgradeEffect(int x, int y, int upgrade, int w, mGraphics g, int lech)
	{
		if (upgrade <= 0)
		{
			return;
		}
		int num = 0;
		int num2 = (upgrade - 1) % 5;
		g.setColor(colorBorder[num2][6]);
		g.drawRect(x - w / 2 - lech, y - w / 2 - lech, w, w, mGraphics.isTrue);
		for (int i = num; i < size.Length; i++)
		{
			int num3 = x - w / 2 + upgradeEffectX(GameCanvas.gameTick * 1 - i * wnew, w);
			int num4 = y - w / 2 + upgradeEffectY(GameCanvas.gameTick * 1 - i * wnew, w);
			g.setColor(colorBorder[num2][i]);
			g.fillRect(num3 - size[i] / 2 - lech, num4 - size[i] / 2 - lech, size[i], size[i], mGraphics.isTrue);
		}
		if (upgrade >= 6 && upgrade < 11)
		{
			for (int j = num; j < size.Length; j++)
			{
				int num5 = x - w / 2 + upgradeEffectX((GameCanvas.gameTick - w * 2) * 1 - j * wnew, w);
				int num6 = y - w / 2 + upgradeEffectY((GameCanvas.gameTick - w * 2) * 1 - j * wnew, w);
				g.setColor(colorBorder[num2][j]);
				g.fillRect(num5 - size[j] / 2 - lech, num6 - size[j] / 2 - lech, size[j], size[j], mGraphics.isTrue);
			}
		}
		if (upgrade >= 11)
		{
			for (int k = num; k < size.Length; k++)
			{
				int num7 = x - w / 2 + upgradeEffectX((GameCanvas.gameTick - w * 13 / 10) * 1 - k * wnew, w);
				int num8 = y - w / 2 + upgradeEffectY((GameCanvas.gameTick - w * 13 / 10) * 1 - k * wnew, w);
				g.setColor(colorBorder[num2][k]);
				g.fillRect(num7 - size[k] / 2 - lech, num8 - size[k] / 2 - lech, size[k], size[k], mGraphics.isTrue);
			}
			for (int l = num; l < size.Length; l++)
			{
				int num9 = x - w / 2 + upgradeEffectX((GameCanvas.gameTick - w * 13 / 5) * 1 - l * wnew, w);
				int num10 = y - w / 2 + upgradeEffectY((GameCanvas.gameTick - w * 13 / 5) * 1 - l * wnew, w);
				g.setColor(colorBorder[num2][l]);
				g.fillRect(num9 - size[l] / 2 - lech, num10 - size[l] / 2 - lech, size[l], size[l], mGraphics.isTrue);
			}
		}
	}

	public int upgradeEffectY(int tick, int w)
	{
		int num = tick % (4 * w);
		if (0 <= num && num < w)
		{
			return 0;
		}
		if (w <= num && num < w * 2)
		{
			return num % w;
		}
		if (w * 2 <= num && num < w * 3)
		{
			return w;
		}
		return w - num % w;
	}

	public int upgradeEffectX(int tick, int w)
	{
		int num = tick % (4 * w);
		if (0 <= num && num < w)
		{
			return num % w;
		}
		if (w <= num && num < w * 2)
		{
			return w;
		}
		if (w * 2 <= num && num < w * 3)
		{
			return w - num % w;
		}
		return 0;
	}
}
