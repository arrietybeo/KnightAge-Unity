using System.Runtime.InteropServices;
using UnityEngine;

public class iOSPlugins
{
	public static string devide;

	public static string Myname;

	[DllImport("__Internal")]
	private static extern void _SMSsend(string tophone, string withtext, int n);

	[DllImport("__Internal")]
	private static extern int _unpause();

	[DllImport("__Internal")]
	private static extern int _checkRotation();

	[DllImport("__Internal")]
	private static extern int _back();

	[DllImport("__Internal")]
	private static extern int _Send();

	[DllImport("__Internal")]
	private static extern void _purchaseItem(string itemID, string userName, string gameID);

	public static int Check()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			return checkCanSendSMS();
		}
		devide = iPhoneSettings.generation.ToString();
		string text = string.Empty + devide[2];
		if (text == "h" && devide.Length > 6)
		{
			Myname = SystemInfo.operatingSystem.ToString();
			string text2 = string.Empty + Myname[10];
			if (text2 != "2" && text2 != "3")
			{
				return 0;
			}
			return 1;
		}
		Cout.println(devide + "  loai");
		if (devide == "Unknown" && ScaleGUI.WIDTH * ScaleGUI.HEIGHT < 786432f)
		{
			return 0;
		}
		return -1;
	}

	public static int checkCanSendSMS()
	{
		if (iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation == iPhoneGeneration.iPhone4S || iPhoneSettings.generation == iPhoneGeneration.iPhone5)
		{
			return 0;
		}
		return -1;
	}

	public static void SMSsend(string phonenumber, string bodytext, int n)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Application.platform != 0)
		{
			_SMSsend(phonenumber, bodytext, n);
		}
	}

	public static void back()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Application.platform != 0)
		{
			_back();
		}
	}

	public static void Send()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Application.platform != 0)
		{
			_Send();
		}
	}

	public static int unpause()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Application.platform != 0)
		{
			return _unpause();
		}
		return 0;
	}

	public static int checkRotation()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Application.platform != 0)
		{
			return _checkRotation();
		}
		return 0;
	}

	public static void purchaseItem(string itemID, string userName, string gameID)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Application.platform != 0)
		{
			_purchaseItem(itemID, userName, gameID);
		}
	}
}
