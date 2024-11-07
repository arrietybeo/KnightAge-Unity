public class EffectManager : mVector
{
	public static EffectManager lowEffects = new EffectManager();

	public static EffectManager hiEffects = new EffectManager();

	public void updateAll()
	{
		for (int num = size() - 1; num >= 0; num--)
		{
			MainEffect mainEffect = (MainEffect)elementAt(num);
			if (mainEffect != null)
			{
				mainEffect.update();
				if (mainEffect.isRemove)
				{
					removeElementAt(num);
				}
			}
		}
	}

	public void paintAll(mGraphics g)
	{
		for (int i = 0; i < size(); i++)
		{
			MainEffect mainEffect = (MainEffect)elementAt(i);
			if (mainEffect != null && !mainEffect.isRemove)
			{
				mainEffect.paint(g);
			}
		}
	}

	public void reMoveAll()
	{
		for (int num = size() - 1; num >= 0; num--)
		{
			MainEffect mainEffect = (MainEffect)elementAt(num);
			if (mainEffect != null)
			{
				mainEffect.isRemove = true;
				removeElementAt(num);
			}
		}
	}

	public static void addHiEffect(MainEffect eff)
	{
		hiEffects.addElement(eff);
	}

	public static void addLowEffect(MainEffect eff)
	{
		lowEffects.addElement(eff);
	}
}
