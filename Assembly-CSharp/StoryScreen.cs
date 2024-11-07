public class StoryScreen : MainScreen
{
	private string[] strcontent;

	private int maxH;

	private int ypaint;

	private int indexType;

	private int speed;

	private RunWord run = new RunWord();

	public static int[] mTypeStory;

	private iCommand cmdNext;

	public static void setTypeStory()
	{
		if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
		{
			mTypeStory = new int[3];
		}
		else
		{
			mTypeStory = new int[2];
		}
	}

	public void setCmdnext()
	{
		if (cmdNext == null)
		{
			cmdNext = new iCommand(T.next, -1, this);
			cmdNext.caption = T.next;
			cmdNext.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd, null, cmdNext.caption);
			center = cmdNext;
		}
	}

	public void setContent()
	{
		setCmdnext();
		if (indexType >= mTypeStory.Length)
		{
			GameCanvas.game.Show();
			GameCanvas.hLoad = GameCanvas.hh;
			indexType = 0;
			if (MainQuest.vecQuestList != null)
			{
				for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
				{
					MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
					mainQuest.beginQuest();
					GameScreen.player.Direction = 1;
				}
			}
			return;
		}
		int num = 220;
		if (num > GameCanvas.w)
		{
			num = GameCanvas.w - 10;
		}
		if (mTypeStory[indexType] == 0)
		{
			strcontent = mFont.tahoma_7b_white.splitFontArray(T.story[indexType], num);
			maxH = 180 + strcontent.Length * GameCanvas.hText;
			speed = 1;
			if (strcontent.Length < 4)
			{
				speed = 2;
			}
		}
		else
		{
			run.startDialogChain(T.story[indexType], 0, GameCanvas.hw - num / 2, GameCanvas.hh, 220, mFont.tahoma_7b_white);
		}
		indexType++;
	}

	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		g.setClip(0, GameCanvas.hh - 90, GameCanvas.w, 180);
		if (strcontent != null)
		{
			for (int i = 0; i < strcontent.Length; i++)
			{
				mFont.tahoma_7b_white.drawString(g, strcontent[i], GameCanvas.hw, GameCanvas.hh + 80 + i * GameCanvas.hText - ypaint, 2, mGraphics.isTrue);
			}
		}
		else if (run.dlgChainInfo != null)
		{
			run.paintText(g);
			GameCanvas.resetTrans(g);
			AvMain.Font3dWhite(g, T.next, GameCanvas.hw, GameCanvas.h - GameCanvas.hCommand / 2 - 4, 2);
		}
		base.paint(g);
	}

	public override void update()
	{
		if (strcontent != null)
		{
			ypaint += speed;
			if (ypaint > maxH)
			{
				strcontent = null;
				setContent();
				ypaint = 0;
			}
		}
		else if (run.dlgChainInfo != null)
		{
			run.updateDlg();
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		if (index == -1)
		{
			indexType = mTypeStory.Length;
			setContent();
		}
	}

	public override void updatekey()
	{
		if (GameCanvas.keyMyPressed[5])
		{
			indexType = mTypeStory.Length;
			setContent();
			GameCanvas.clearKeyPressed(5);
		}
		if (run.dlgChainInfo != null)
		{
			if (GameCanvas.keyMyHold[5] && run.nextDlgStep())
			{
				run.dlgChainInfo = null;
				setContent();
				GameCanvas.clearKeyHold(5);
			}
			base.updatekey();
		}
	}
}
