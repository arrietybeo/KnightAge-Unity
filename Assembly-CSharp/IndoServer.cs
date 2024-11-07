public class IndoServer
{
	public static bool isIndoSv;

	public static void setLinkIp()
	{
		if (isIndoSv)
		{
			GameCanvas.t = new TIndo();
			GameCanvas.linkIP = "http://knightageonline.com/srvip/indo.php";
			GameCanvas.listServer = new string[1, 2] { { "Indo Naga", "54.151.177.35" } };
		}
	}
}
