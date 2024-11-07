using System;
using System.Threading;
using UnityEngine;

public class Main : MonoBehaviour
{
    public const sbyte IP_APPSTORE = 3;

    public const sbyte PC_VERSION = 4;

    public const sbyte WINDOWSPHONE = 5;

    public static Main main;

    public static mGraphics g;

    public static TemMidlet tMidlet;

    public static string res = "res";

    public static string mainThreadName;

    public static bool started;

    public static bool isIpod;

    public static bool isIphone4;

    public static bool isIpad;

    public static bool isExit;

    public static bool isPC;

    public static bool isWindowsPhone;

    public static bool isIPhone;

    public static bool isSprite;

    public static bool isWP8;

    public static bool IphoneVersionApp;

    public static string IMEI;

    public static int versionIp;

    public static int numberQuit = 1;

    public static sbyte IPHONE_JB = 2;

    public static int level;

    public static int sizeMiniMap = -1;

    public static bool isLoad;

    private int cout;

    private bool isRun;

    public static mImage[] imgTileMapLogin;

    public static bool isMiniApp = true;

    public static bool isQuitApp;

    public static bool isReSume;

    private Vector2 lastMousePos = default(Vector2);

    public static int a = 1;

    public static bool isCompactDevice = true;

    private void Start()
    {
        if (!started)
        {
            if (Thread.CurrentThread.Name != "Main")
            {
                Thread.CurrentThread.Name = "Main";
            }
            mainThreadName = Thread.CurrentThread.Name;
            isPC = true;
            started = true;
            level = Rms.loadRMSInt("levelScreenKN");
            if (level == 1)
            {
                Screen.SetResolution(480, 320, false);
            }
            else
            {
                Screen.SetResolution(1024, 600, false);
            }
        }
    }

    public void creatMiniMap()
    {
    }

    public static void setBackupIcloud(string path)
    {
    }

    public void init()
    {
        Debug.Log("INIT DATA");
        CRes.init();
        MainObject.init();
        Player.init0();
    }

    private void OnGUI()
    {
        if (cout >= 10)
        {
            checkInput();
            Session_ME.update();
            if (Event.current.type.Equals(EventType.Repaint))
            {
                TemMidlet.temCanvas.paint(g);
                g.reset();
            }
        }
    }

    public static void closeKeyBoard()
    {
        if (TouchScreenKeyboard.visible)
        {
            TField.kb.active = false;
            TField.kb = null;
        }
    }

    public void doClearRMS()
    {
        sbyte[] array = CRes.loadRMS("versionGame");
        if (array != null)
        {
            try
            {
                LoginScreen.loadVersionGame();
            }
            catch (Exception ex)
            {
                Cout.Log(" Loi Tai !!! : " + ex.ToString());
            }
        }
        if (isPC)
        {
            int num = Rms.loadRMSInt("lastZoomlevel");
            if (num != mGraphics.zoomLevel)
            {
                Rms.deleteAllRecord();
                Rms.saveRMSInt("lastZoomlevel", mGraphics.zoomLevel);
                Rms.saveRMSInt("levelScreenKN", level);
            }
        }
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Rms.update();
        cout++;
        if (cout < 10)
        {
            return;
        }
        if (!isRun)
        {
            isRun = true;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Application.runInBackground = true;
            Application.targetFrameRate = 30;
            base.useGUILayout = false;
            isCompactDevice = detectCompactDevice();
            if (main == null)
            {
                main = this;
            }
            ScaleGUI.initScaleGUI();
            IMEI = SystemInfo.deviceUniqueIdentifier;
            isIPhone = !isPC;
            isWP8 = false;
            if (iPhoneSettings.generation == iPhoneGeneration.iPadUnknown)
            {
                isIpad = true;
            }
            int num = IPHONE_JB;
            if (isPC)
            {
                Screen.fullScreen = false;
            }
            if (isWindowsPhone)
            {
                num = 5;
            }
            if (isPC)
            {
                num = 4;
            }
            if (IphoneVersionApp)
            {
                num = 3;
            }
            TemMidlet.DIVICE = (sbyte)num;
            Debug.Log("typeClient :" + TemMidlet.DIVICE);
            if (iPhoneSettings.generation == iPhoneGeneration.iPodTouch4Gen)
            {
                isIpod = true;
            }
            if (iPhoneSettings.generation == iPhoneGeneration.iPhone4)
            {
                isIphone4 = true;
            }
            init();
            g = new mGraphics();
            g.CreateLineMaterial();
            tMidlet = new TemMidlet();// quan trong
            if (mGraphics.zoomLevel == 1 && !isWindowsPhone)
            {
                isSprite = false;
            }
            if (isPC)
            {
                PaintInfoGameScreen.isLevelPoint = true;
            }
        }
        Load_Data_And_Img.load.run();
        ipKeyboard.update();
        TemMidlet.temCanvas.update();
        Image.update();
        DataInputStream.update();
        SMS.update();
        Net.update();
        if (GameCanvas.saveImage != null)
        {
            GameCanvas.saveImage.run();
        }
        if (CRes.load != null)
        {
            CRes.load.run();
        }
    }

    private void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            TemMidlet.temCanvas.pointerPressed((int)mousePosition.x, (int)((float)Screen.height - mousePosition.y) + mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
            lastMousePos.x = mousePosition.x;
            lastMousePos.y = mousePosition.y + (float)(mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition2 = Input.mousePosition;
            TemMidlet.temCanvas.pointerDragged((int)mousePosition2.x, (int)((float)Screen.height - mousePosition2.y) + mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
            lastMousePos.x = mousePosition2.x;
            lastMousePos.y = mousePosition2.y + (float)(mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition3 = Input.mousePosition;
            lastMousePos.x = mousePosition3.x;
            lastMousePos.y = mousePosition3.y + (float)(mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
            TemMidlet.temCanvas.pointerReleased((int)mousePosition3.x, (int)((float)Screen.height - mousePosition3.y) + mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
        }
        if (Input.anyKeyDown && Event.current.type == EventType.KeyDown)
        {
            int num = MyKeyMap.map(Event.current.keyCode);
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                switch (Event.current.keyCode)
                {
                    case KeyCode.Alpha2:
                        num = 64;
                        break;
                    case KeyCode.Minus:
                        num = 95;
                        break;
                }
            }
            if (num != 0)
            {
                TemMidlet.temCanvas.keyPressed(num);
            }
        }
        if (Event.current.type == EventType.KeyUp)
        {
            int num2 = MyKeyMap.map(Event.current.keyCode);
            if (num2 != 0)
            {
                TemMidlet.temCanvas.keyReleased(num2);
            }
        }
    }

    private void OnApplicationQuit()
    {
        Debug.LogWarning("APP QUIT");
        Session_ME.gI().close();
        if (isPC)
        {
            Application.Quit();
        }
    }

    private void OnApplicationPause(bool paused)
    {
        isReSume = false;
        if (paused)
        {
            if (GameCanvas.currentDialog != null && GameCanvas.currentDialog.left != null)
            {
                GameCanvas.currentDialog.left.perform();
            }
        }
        else
        {
            isReSume = true;
        }
        if (TouchScreenKeyboard.visible)
        {
            TField.kb.active = false;
            TField.kb = null;
        }
        if (isQuitApp)
        {
            Application.Quit();
        }
    }

    public static void exit()
    {
        if (isPC)
        {
            main.OnApplicationQuit();
        }
        else
        {
            a = 0;
        }
    }

    public static void exit2()
    {
        GameScreen.player.resetAction();
        Session_ME.gI().close();
        GameCanvas.login.Show();
        GameScreen.player = new Player(0, 0, "unname", 0, 0);
    }

    public static bool detectCompactDevice()
    {
        if (iPhoneSettings.generation == iPhoneGeneration.iPhone || iPhoneSettings.generation == iPhoneGeneration.iPhone3G || iPhoneSettings.generation == iPhoneGeneration.iPodTouch1Gen || iPhoneSettings.generation == iPhoneGeneration.iPodTouch2Gen)
        {
            return false;
        }
        return true;
    }

    public static bool checkCanSendSMS()
    {
        if (iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation > iPhoneGeneration.iPodTouch4Gen)
        {
            return true;
        }
        return false;
    }

    public void platformRequest(string url)
    {
        Cout.LogWarning("PLATFORM REQUEST: " + url);
        Application.OpenURL(url);
    }

    public static void naptienWP8()
    {
    }

    public void processPurchaseRMS()
    {
    }

    public void ClearTransaction()
    {
    }
}
