public class TabScreenNew : MainScreen
{
	public const int CMD_TAB_CLOSE = 0;

	public const int CMD_BACK_TAB = 1;

	public int selectTab;

	public mVector VecTabScreen = new mVector("TabScreenNew VecTabScreen");

	public static iCommand cmdTab;

	public static iCommand cmdBack;

	public static int timeRepaint;

	public static int xback;

	public static int yback;

	public TabScreenNew()
	{
		cmdBack = new iCommand(T.close, 0, this);
		xback = GameCanvas.w - 20;
		yback = 17;
		if (Main.isPC || Main.isIpad)
		{
			xback = MainTabNew.gI().xTab + 210 + 2;
			yback = MainTabNew.gI().yTab + GameCanvas.h / 5 + 13;
		}
		if (GameCanvas.isTouch)
		{
			cmdBack.setPos(xback, yback, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
	}

	public void setCaptionCmd()
	{
		if (!GameCanvas.isTouch)
		{
			cmdBack.caption = T.close;
		}
	}

	public override void Show()
	{
		mSystem.outloi("goi ham co truyen lastScreen");
	}

	public override void Show(MainScreen last)
	{
		timeRepaint = 10;
		if (GameScreen.help.setStep_Next(6, 2))
		{
			selectTab = 2;
		}
		if (GameCanvas.isTouch)
		{
			MainTabNew.Focus = MainTabNew.INFO;
			MainTabNew currentTab = getCurrentTab();
			currentTab.init();
			MainTabNew.timePaintInfo = 0;
			right = cmdBack;
		}
		else
		{
			MainTabNew.Focus = MainTabNew.TAB;
		}
		base.Show();
		GameCanvas.currentScreen.lastScreen = last;
	}

	public override void commandPointer(int index, int sub)
	{
		if (index == 0)
		{
			if (lastScreen == null || lastScreen == GameCanvas.currentScreen || GameCanvas.currentScreen == GameCanvas.AllInfo)
			{
				GameCanvas.game.Show();
			}
			else
			{
				lastScreen.Show(lastScreen.lastScreen);
			}
			if (GameScreen.help.setStep_Next(4, 9))
			{
				GameScreen.help.NextStep();
				GameScreen.help.setNext();
			}
		}
	}

	public void addMoreTab(mVector t)
	{
		VecTabScreen.removeAllElements();
		VecTabScreen = t;
	}

	public override void paint(mGraphics g)
	{
		if (Main.isPC || Main.isIpad)
		{
			GameScreen.gI().paint(g);
			GameCanvas.resetTrans(g);
			GameScreen.infoGame.paintInfoPlayer(g, 0, 0, !GameCanvas.isSmallScreen, mFont.tahoma_7_white);
		}
		MainTabNew currentTab = getCurrentTab();
		GameCanvas.resetTrans(g);
		MainTabNew.gI().paintTab(g, currentTab.nameTab, selectTab, VecTabScreen, currentTab.isClan);
		currentTab.paint(g);
		GameCanvas.resetTrans(g);
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && GameCanvas.currentScreen == this)
		{
			if (GameCanvas.isTouch)
			{
				paintCmd(g);
			}
			else if (MainTabNew.Focus == MainTabNew.TAB)
			{
				paintCmd_OnlyText(g);
			}
			else
			{
				currentTab.paintCmd_OnlyText(g);
			}
		}
		else
		{
			timeRepaint = 10;
		}
		if (GameScreen.help.Step >= 0 && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && currentTab.typeTab != MainTabNew.INVENTORY)
		{
			GameScreen.help.itemTabHelp(g, null, currentTab.typeTab);
		}
	}

	public override void update()
	{
		if (lastScreen == GameCanvas.game)
		{
			lastScreen.update();
		}
		MainTabNew currentTab = getCurrentTab();
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.currentScreen == this)
		{
			currentTab.update();
		}
		if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null)
		{
			timeRepaint = 10;
		}
		else if (timeRepaint > 0)
		{
			timeRepaint--;
		}
	}

	private MainTabNew getCurrentTab()
	{
		return (MainTabNew)VecTabScreen.elementAt(selectTab);
	}

	public override void updatekey()
	{
		if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null || GameCanvas.subDialog != null)
		{
			return;
		}
		if (MainTabNew.Focus == MainTabNew.TAB)
		{
			timeRepaint = 10;
			left = null;
			center = null;
			right = cmdBack;
			int num = selectTab;
			if (GameCanvas.keyMyHold[2])
			{
				selectTab--;
				GameCanvas.clearKeyHold();
				if (TabRebuildItem.resetItemReplace)
				{
					TabRebuildItem.itemFree = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemWing = null;
					TabRebuildItem.resetItemReplace = false;
				}
			}
			else if (GameCanvas.keyMyHold[8])
			{
				selectTab++;
				GameCanvas.clearKeyHold();
				if (TabRebuildItem.resetItemReplace)
				{
					TabRebuildItem.itemFree = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemWing = null;
					TabRebuildItem.resetItemReplace = false;
				}
			}
			else if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6])
			{
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				SetInit();
			}
			selectTab = resetSelect(selectTab, VecTabScreen.size() - 1, isreset: true);
			if (num != selectTab)
			{
				MainScreen.cameraSub.yCam = 0;
			}
			MainTabNew currentTab = getCurrentTab();
			if (currentTab.typeTab == MainTabNew.CONFIG || currentTab.typeTab == MainTabNew.FUNCTION)
			{
				currentTab.init();
			}
			if (GameScreen.help.setStep_Next(3, 8))
			{
				if (currentTab.typeTab == MainTabNew.EQUIP)
				{
					currentTab.init();
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
				}
			}
			else if (GameScreen.help.setStep_Next(7, 9))
			{
				if (currentTab.typeTab == MainTabNew.SKILLS)
				{
					currentTab.init();
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
				}
			}
			else if (GameScreen.help.setStep_Next(9, 1) && currentTab.typeTab == MainTabNew.QUEST)
			{
				currentTab.init();
				GameScreen.help.Next++;
				GameScreen.help.setNext();
			}
			base.updatekey();
		}
		else
		{
			MainTabNew currentTab2 = getCurrentTab();
			if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null)
			{
				currentTab2.updatekey();
			}
		}
	}

	public override void updatePointer()
	{
		if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null || GameCanvas.subDialog != null)
		{
			return;
		}
		MainTabNew currentTab = getCurrentTab();
		if (currentTab.typeTab == MainTabNew.REBUILD && TabRebuildItem.isBeginEff != 0)
		{
			return;
		}
		if (GameCanvas.isPointSelect(MainTabNew.gI().xTab, MainTabNew.gI().yTab + GameCanvas.h / 5, MainTabNew.wOneItem + MainTabNew.wOne5 * 2, MainTabNew.wOneItem * VecTabScreen.size()))
		{
			int select = (GameCanvas.py - (MainTabNew.gI().yTab + GameCanvas.h / 5)) / MainTabNew.wOneItem;
			select = resetSelect(select, VecTabScreen.size() - 1, isreset: false);
			if (select != selectTab)
			{
				if (TabRebuildItem.resetItemReplace)
				{
					TabRebuildItem.itemFree = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemWing = null;
					TabRebuildItem.resetItemReplace = false;
				}
				timeRepaint = 10;
				selectTab = select;
				SetInit();
				currentTab = getCurrentTab();
				if (GameScreen.help.setStep_Next(3, 8))
				{
					if (currentTab.typeTab == MainTabNew.EQUIP)
					{
						GameScreen.help.NextStep();
						GameScreen.help.setNext();
					}
				}
				else if (GameScreen.help.setStep_Next(7, 9))
				{
					if (currentTab.typeTab == MainTabNew.SKILLS)
					{
						GameScreen.help.NextStep();
						GameScreen.help.setNext();
					}
				}
				else if (GameScreen.help.setStep_Next(9, 1) && currentTab.typeTab == MainTabNew.QUEST)
				{
					GameScreen.help.Next++;
					GameScreen.help.setNext();
				}
				mSound.playSound(41, mSound.volumeSound);
			}
			GameCanvas.isPointerSelect = false;
		}
		currentTab.updatePointer();
		base.updatePointer();
	}

	public void SetInit()
	{
		MainTabNew.Focus = MainTabNew.INFO;
		MainTabNew currentTab = getCurrentTab();
		currentTab.init();
	}

	public override void keyPress(int keyCode)
	{
		MainTabNew currentTab = getCurrentTab();
		currentTab.keypress(keyCode);
		base.keyPress(keyCode);
	}
}
