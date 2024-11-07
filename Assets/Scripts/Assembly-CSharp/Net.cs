using UnityEngine;

internal class Net
{
	public static WWW www;

	public static iCommand h;

	public static void update()
	{
		if (www != null && www.isDone)
		{
			string str = string.Empty;
			if (www.error == null || www.error.Equals(string.Empty))
			{
				str = www.text;
			}
			www = null;
			if (h != null)
			{
				h.perform(str);
			}
		}
	}

	public static void connectHTTP(string link, iCommand h)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		if (www != null)
		{
			Cout.LogError("GET HTTP BUSY");
		}
		Cout.LogWarning("REQUEST " + link);
		www = new WWW(link);
		Net.h = h;
	}
}
