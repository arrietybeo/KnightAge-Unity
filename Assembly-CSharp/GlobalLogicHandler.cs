public class GlobalLogicHandler
{
	public static GlobalLogicHandler instance;

	public static bool isDisConect = false;

	public static long timeReconnect = mSystem.currentTimeMillis();

	public static bool isDisconnect;

	public static bool isMelogin;

	public static GlobalLogicHandler gI()
	{
		if (instance == null)
		{
			instance = new GlobalLogicHandler();
		}
		return instance;
	}

	public void onConnectFail()
	{
	}

	public void onConnectOK()
	{
	}

	public static void onDisconnect()
	{
		isDisconnect = true;
		if (!isMelogin)
		{
			isDisConect = true;
			timeReconnect = mSystem.currentTimeMillis() + 30000;
		}
		else
		{
			isDisConect = false;
			timeReconnect = 0L;
		}
		if (GameScreen.isMapLang)
		{
			isDisConect = false;
			timeReconnect = 0L;
		}
	}
}
