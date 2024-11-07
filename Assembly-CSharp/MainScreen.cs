public class MainScreen : AvMain
{
	private MainScreen mainScreen;

	public MainScreen lastScreen;

	public static Camera cameraMain;

	public static Camera cameraSub;

	public string name = string.Empty;

	public virtual void Show()
	{
		GameCanvas.clearKeyPressed();
		GameCanvas.currentScreen = this;
		GameCanvas.end_Dialog();
		GameCanvas.menu2.isShowMenu = false;
	}

	public virtual bool isGameScr()
	{
		return false;
	}

	public virtual void Show(MainScreen screen)
	{
		if (screen != null)
		{
			lastScreen = screen;
		}
		GameCanvas.clearKeyPressed();
		GameCanvas.currentScreen = this;
		GameCanvas.end_Dialog();
		GameCanvas.menu2.isShowMenu = false;
	}

	public override void paint(mGraphics g)
	{
		base.paint(g);
	}

	public override void update()
	{
	}

	public virtual void keyPress(int keyCode)
	{
	}

	public virtual void keyBack()
	{
	}
}
