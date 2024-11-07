using System;

public class LogoScreen : MainScreen
{
	private int dem;

	public static string strListserver = string.Empty;

	public static bool isLoadServer;

	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
	}

	public override void update()
	{
		dem++;
		if (dem > 60)
		{
			dem = 0;
			GameCanvas.login.Show();
		}
	}

	public static void getServerList(string str, bool isFrist)
	{
		if (GameCanvas.IndexServer == 0 || GameCanvas.IndexServer == 1 || GameCanvas.IndexServer == 3 || GameCanvas.IndexServer == 4 || GameCanvas.IndexServer == 5)
		{
			return;
		}
		if (GameCanvas.IndexServer == 2)
		{
			setChangeLang();
			GameCanvas.t = new TE();
		}
		else if (GameCanvas.IndexServer == 2)
		{
			setChangeLang();
			GameCanvas.t = new TE();
		}
		else
		{
			if (str == null || str.Length == 0)
			{
				return;
			}
			saveListServer(str);
			string[] array = mFont.split(str.Trim(), ",");
			bool isVN_Eng = GameCanvas.isVN_Eng;
			GameCanvas.listServer = new string[array.Length - 1, 2];
			GameCanvas.portServer = new int[array.Length - 1];
			GameCanvas.langServer = new int[array.Length - 1];
			if (isFrist)
			{
				GameCanvas.IndexServer = (sbyte)(array.Length - 1);
			}
			for (int i = 0; i < array.Length - 1; i++)
			{
				string[] array2 = mFont.split(array[i].Trim(), ":");
				GameCanvas.listServer[i, 0] = array2[0];
				GameCanvas.listServer[i, 1] = array2[1];
				GameCanvas.portServer[i] = short.Parse(array2[2]);
				GameCanvas.langServer[i] = sbyte.Parse(array2[3].Trim());
				if (isFrist && GameCanvas.langServer[i] == TemMidlet.langServer && GameCanvas.isVN_Eng)
				{
					GameCanvas.IndexServer = (sbyte)i;
				}
			}
			GameCanvas.isVN_Eng = GameCanvas.langServer[GameCanvas.IndexServer] == 0;
			setChangeLang();
		}
	}

	public static void setChangeLang()
	{
		MainRMS.showAuto = string.Empty;
		LoginScreen.indexInfoLogin = 1;
		if (GameCanvas.w < 200 || GameCanvas.h < 200)
		{
			LoginScreen.indexInfoLogin = 2;
		}
		else if (GameCanvas.isTouch && GameCanvas.w < 380 && GameCanvas.w > 315 && GameCanvas.w < 380)
		{
			LoginScreen.indexInfoLogin = 2;
		}
		GameCanvas.start_Wait_Dialog(T.pleaseWait, null);
		if (!GameCanvas.isVN_Eng)
		{
			GameCanvas.t = new TE();
			if (mSystem.isIP_TrucTiep)
			{
				LoginScreen.logo = mImage.createImage("/interface/logoeip.png");
			}
			else
			{
				LoginScreen.logo = mImage.createImage("/interface/logoe.png");
			}
		}
		else
		{
			GameCanvas.t = new T();
			if (mSystem.isIP_TrucTiep)
			{
				LoginScreen.logo = mImage.createImage("/interface/logoip.png");
			}
			else
			{
				LoginScreen.logo = mImage.createImage("/interface/logo.png");
			}
		}
		List_Server.gI().doSetCaption();
		Usa_Server.setLinkIp();
		IndoServer.setLinkIp();
		GameCanvas.loadCaptionCmd();
		WorldMapScreen.namePos = null;
		GameCanvas.end_Dialog();
	}

	public static void saveListServer(string str)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(str);
			CRes.saveRMS("listServer", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}
}
