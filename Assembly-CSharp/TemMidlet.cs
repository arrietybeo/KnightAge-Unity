using System;

public class TemMidlet
{
    public static TemCanvas temCanvas;

    public static TemMidlet instance;

    public static sbyte DIVICE = 4;

    public static sbyte NONE = 0;

    public static sbyte NOKIA_STORE = 1;

    public static sbyte currentIAPStore = NONE;

    public static bool isBlockNOKIAStore = true;

    public static sbyte langServer = 0;

    public static string[] listGems = new string[1] { "24 Gems" };

    public TemMidlet()
    {
        temCanvas = new();
        instance = this;
        Session_ME.gI().setHandler(GlobalMessageHandler.gI());
        temCanvas.start();
        CRes.load.isInitGame = true;
    }

    protected void destroyApp(bool arg0)
    {
        instance.notifyDestroyed();
    }

    protected void pauseApp()
    {
    }

    protected void startApp()
    {
    }

    public void notifyDestroyed()
    {
    }

    public void destroy()
    {
        Main.exit();
    }

    public static sbyte[] encoding(sbyte[] array)
    {
        if (array != null)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (sbyte)(~array[i]);
            }
        }
        return array;
    }

    public static void saveRMS(string filename, sbyte[] data)
    {
        Rms.saveRMS(filename, data);
    }

    public static sbyte[] loadRMS(string filename)
    {
        return Rms.loadRMS(filename);
    }

    public static void openUrl(string url)
    {
        try
        {
            Main.main.platformRequest(url);
        }
        catch (Exception)
        {
        }
    }

    public static void delRMS()
    {
        Rms.deleteRecordCompareToName();
    }

    public static string connectHTTP(string link)
    {
        string strServerInfo = string.Empty;
        iCommand iCommand2 = new iCommand();
        ActionChat actionChat = delegate (string str)
        {
            if (str != null)
            {
                strServerInfo = str;
                LogoScreen.saveListServer(strServerInfo);
            }
        };
        iCommand2.actionChat = actionChat;
        Net.connectHTTP(link, iCommand2);
        return strServerInfo;
    }

    public static void submitPurchase()
    {
    }

    public void call(string num)
    {
    }

    public static void handleMessage(Message msg)
    {
    }
}
