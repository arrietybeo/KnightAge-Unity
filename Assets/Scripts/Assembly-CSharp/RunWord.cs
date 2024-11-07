public class RunWord
{
	public bool showDlg;

	public int nStepToShow;

	public int currentDlgStep;

	public int dlgActionType;

	public string[] dlgChainInfo;

	public int dlgFocusX;

	public int dlgFocusY;

	public int dlgRunX;

	public int dlgRunY;

	public int dlgW;

	public int dlgX;

	private mFont f;

	public void startDialogChain(string dlgChain, int ActionType, int xFocus, int yFocus, int w, mFont f)
	{
		this.f = f;
		dlgActionType = ActionType;
		dlgFocusX = xFocus;
		dlgFocusY = yFocus;
		currentDlgStep = 0;
		dlgW = w;
		if (dlgW > GameCanvas.w - 10)
		{
			dlgW = GameCanvas.w - 10;
		}
		dlgChainInfo = f.splitFontArray(dlgChain, dlgW);
		dlgX = dlgFocusX;
		showDlg = true;
		dlgRunX = 0;
		dlgRunY = 0;
	}

	public bool checkDlgStep()
	{
		if (dlgRunY < dlgChainInfo.Length)
		{
			return false;
		}
		return true;
	}

	public bool nextDlgStep()
	{
		if (dlgRunY < dlgChainInfo.Length)
		{
			dlgRunY = dlgChainInfo.Length;
			dlgRunX = 0;
			return false;
		}
		dlgRunX = (dlgRunY = 0);
		return true;
	}

	public void updateDlg()
	{
		if (showDlg && dlgRunY < dlgChainInfo.Length)
		{
			dlgRunX += 2;
			if (dlgRunX >= dlgChainInfo[dlgRunY].Length)
			{
				dlgRunX = 0;
				dlgRunY++;
			}
		}
	}

	public void paintText(mGraphics g)
	{
		int num = -1;
		num = dlgFocusY;
		for (int i = 0; i < dlgRunY; i++)
		{
			f.drawString(g, dlgChainInfo[i], dlgX, num + i * GameCanvas.hText, 0, mGraphics.isFalse);
		}
		if (dlgRunY < dlgChainInfo.Length)
		{
			f.drawString(g, mSystem.substring(dlgChainInfo[dlgRunY], 0, dlgRunX), dlgX, num + dlgRunY * GameCanvas.hText, 0, mGraphics.isFalse);
		}
	}

	public void paintText(mGraphics g, int archor)
	{
		int num = -1;
		num = dlgFocusY;
		if (archor == 2)
		{
			for (int i = 0; i < dlgRunY; i++)
			{
				f.drawString(g, dlgChainInfo[i], dlgX + dlgW / 2, num + i * GameCanvas.hText, 2, mGraphics.isFalse);
			}
			if (dlgRunY < dlgChainInfo.Length)
			{
				f.drawString(g, mSystem.substring(dlgChainInfo[dlgRunY], 0, dlgRunX), dlgX + dlgW / 2, num + dlgRunY * GameCanvas.hText, 2, mGraphics.isFalse);
			}
		}
		else
		{
			for (int j = 0; j < dlgRunY; j++)
			{
				f.drawString(g, dlgChainInfo[j], dlgX, num + j * GameCanvas.hText, 0, mGraphics.isFalse);
			}
			if (dlgRunY < dlgChainInfo.Length)
			{
				f.drawString(g, mSystem.substring(dlgChainInfo[dlgRunY], 0, dlgRunX), dlgX, num + dlgRunY * GameCanvas.hText, 0, mGraphics.isFalse);
			}
		}
	}
}
