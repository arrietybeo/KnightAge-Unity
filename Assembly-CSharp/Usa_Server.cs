public class Usa_Server
{
	public static bool isUsa_server;

	public static void setLinkIp()
	{
		if (isUsa_server)
		{
			GameCanvas.t = new TE();
			GameCanvas.linkIP = "http://knightageonline.com/srvip/";
			GameCanvas.listServer = new string[1, 2] { { "Global Server", "54.255.77.17" } };
		}
	}
}
