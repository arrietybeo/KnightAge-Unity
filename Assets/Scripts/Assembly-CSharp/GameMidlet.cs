public class GameMidlet
{
	public static string version = "3.0.1";

	public static string[] idGame = new string[2] { "com.silvershield.knight.1", "com.silvershield.knight.2" };

	public static void destroy()
	{
		TemMidlet.instance.destroy();
	}
}
