public class iCommand
{
	public bool isButtonDai;

	public ActionChat actionChat;

	public string caption;

	public string clickCaption = string.Empty;

	public string[] subCaption;

	public IAction action;

	public AvMain Pointer;

	public sbyte indexMenu;

	public sbyte subIndex = -1;

	public bool isSelect;

	public bool isNotShowTab;

	private int nframe;

	private int beginframe;

	private FrameImage fraImgCaption;

	private FrameImage fraImageCmd;

	private int wimgCaption;

	private int himgCaption;

	private int wstr;

	private int wimgCmd;

	private int himgCmd;

	public int xCmd = -1;

	public int yCmd = -1;

	public int frameCmd;

	public int xdich;

	public int ydich;

	public static int wButtonCmd = 70;

	public static int hButtonCmd = 24;

	private FrameImage[] fraImgCaptionArr;

	public int IdGiaotiep;

	public object obj;

	public iCommand(string caption, IAction action)
	{
		this.caption = caption;
		this.action = action;
	}

	public iCommand(string caption, int type, object obj, AvMain pointer)
	{
		this.caption = caption;
		indexMenu = (sbyte)type;
		Pointer = pointer;
		this.obj = obj;
	}

	public iCommand(string caption, int type)
	{
		this.caption = caption;
		indexMenu = (sbyte)type;
	}

	public iCommand()
	{
	}

	public iCommand(string caption, int type, AvMain pointer)
	{
		this.caption = caption;
		indexMenu = (sbyte)type;
		Pointer = pointer;
	}

	public iCommand(string caption, int type, int subType, AvMain pointer)
	{
		this.caption = caption;
		indexMenu = (sbyte)type;
		subIndex = (sbyte)subType;
		Pointer = pointer;
	}

	public iCommand(string caption, int type, int subIndex)
	{
		this.caption = caption;
		indexMenu = (sbyte)type;
		this.subIndex = (sbyte)subIndex;
	}

	public void perform(string str)
	{
		if (actionChat != null)
		{
			actionChat(str);
		}
	}

	public void setFraCaption(FrameImage fra)
	{
		fraImgCaption = fra;
		wimgCaption = fraImgCaption.frameWidth;
		himgCaption = fraImgCaption.frameHeight;
		nframe = fraImgCaption.nFrame;
		beginframe = 0;
		if (GameCanvas.isSmallScreen)
		{
			wstr = mFont.tahoma_7_white.getWidth(caption);
		}
		else
		{
			wstr = mFont.tahoma_7b_white.getWidth(caption);
		}
	}

	public void setFraCaption(FrameImage fra, int nframe, int beginframe)
	{
		fraImgCaption = fra;
		wimgCaption = fraImgCaption.frameWidth;
		himgCaption = fraImgCaption.frameHeight;
		this.nframe = nframe;
		this.beginframe = beginframe;
		if (GameCanvas.isSmallScreen)
		{
			wstr = mFont.tahoma_7_white.getWidth(caption);
		}
		else
		{
			wstr = mFont.tahoma_7b_white.getWidth(caption);
		}
	}

	public void setFraCaption(FrameImage[] fra, int nframe, int beginframe)
	{
		fraImgCaptionArr = fra;
		wimgCaption = fraImgCaptionArr[0].frameWidth;
		himgCaption = fraImgCaptionArr[0].frameHeight;
		this.nframe = nframe;
		this.beginframe = beginframe;
		if (GameCanvas.isSmallScreen)
		{
			wstr = mFont.tahoma_7_white.getWidth(caption);
		}
		else
		{
			wstr = mFont.tahoma_7b_white.getWidth(caption);
		}
	}

	public void setPosImg(int x, int y, FrameImage fra, int nframe, int beginframe)
	{
		xCmd = x;
		yCmd = y;
		fraImgCaption = fra;
		wimgCaption = fraImgCaption.frameWidth;
		himgCaption = fraImgCaption.frameHeight;
		this.nframe = nframe;
		this.beginframe = beginframe;
		if (fraImageCmd != null)
		{
			wimgCmd = fraImageCmd.frameWidth;
			himgCmd = fraImageCmd.frameHeight;
			if (wimgCmd < 28)
			{
				wimgCmd = 28;
			}
			if (himgCmd < 28)
			{
				himgCmd = 28;
			}
		}
		else
		{
			wimgCmd = 70;
			himgCmd = hButtonCmd;
		}
	}

	public void setPos(int x, int y, FrameImage fra, string caption)
	{
		this.caption = caption;
		xCmd = x;
		yCmd = y;
		fraImageCmd = fra;
		if (fraImageCmd != null)
		{
			wimgCmd = fraImageCmd.frameWidth;
			himgCmd = fraImageCmd.frameHeight;
			if (wimgCmd < 28)
			{
				wimgCmd = 28;
			}
			if (himgCmd < 28)
			{
				himgCmd = 28;
			}
		}
		else
		{
			wimgCmd = 70;
			himgCmd = hButtonCmd;
		}
	}

	public void setPos_BoxText(int x, int y, FrameImage fra, string caption, int wBox, int hBox)
	{
		isButtonDai = true;
		this.caption = caption;
		xCmd = x;
		yCmd = y;
		fraImageCmd = fra;
		if (fraImageCmd != null)
		{
			wimgCmd = fraImageCmd.frameWidth;
			himgCmd = fraImageCmd.frameHeight;
			if (wimgCmd < 28)
			{
				wimgCmd = 28;
			}
			if (himgCmd < 28)
			{
				himgCmd = 28;
			}
		}
		else
		{
			wimgCmd = wBox;
			himgCmd = hBox;
		}
	}

	public void setPos_ShowName(int x, int y, FrameImage fra, string clickcaption, int xdich, int ydich)
	{
		caption = string.Empty;
		clickCaption = clickcaption;
		xCmd = x;
		yCmd = y;
		this.xdich = xdich;
		this.ydich = ydich;
		fraImageCmd = fra;
		if (fraImageCmd != null)
		{
			wimgCmd = fraImageCmd.frameWidth;
			himgCmd = fraImageCmd.frameHeight;
			if (wimgCmd < 28)
			{
				wimgCmd = 28;
			}
			if (himgCmd < 28)
			{
				himgCmd = 28;
			}
		}
		else
		{
			wimgCmd = 70;
			himgCmd = hButtonCmd;
		}
	}

	public void setPosXY(int x, int y)
	{
		xCmd = x;
		yCmd = y;
	}

	public void perform()
	{
		if (GameCanvas.menu2.isShowMenu && (GameCanvas.menu2.runText == null || GameCanvas.menu2.runText.checkDlgStep()))
		{
			GameCanvas.menu2.doCloseMenu();
		}
		if (action != null)
		{
			action.perform();
			GameCanvas.isPointerSelect = false;
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			mSound.playSound(41, mSound.volumeSound);
			return;
		}
		mSound.playSound(41, mSound.volumeSound);
		if (Pointer != null)
		{
			if (obj != null)
			{
				Pointer.commandPointer(indexMenu, obj);
			}
			else
			{
				Pointer.commandPointer(indexMenu, subIndex);
			}
			GameCanvas.isPointerSelect = false;
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
		}
		else if (GameCanvas.currentDialog != null)
		{
			GameCanvas.currentDialog.commandTab(indexMenu, subIndex);
			GameCanvas.isPointerSelect = false;
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
		}
		else if (ChatTextField.isShow)
		{
			ChatTextField.gI().commandTab(indexMenu, subIndex);
		}
		else if (GameCanvas.menu2.isShowMenu)
		{
			GameCanvas.currentScreen.commandMenu(indexMenu, subIndex);
		}
		else if (GameCanvas.subDialog != null)
		{
			GameCanvas.subDialog.commandTab(indexMenu, subIndex);
		}
		else
		{
			GameCanvas.currentScreen.commandTab(indexMenu, subIndex);
		}
	}

	public void update()
	{
	}

	public void paint(mGraphics g, int x, int y)
	{
		if ((Main.isPC && caption == null) || isNotShowTab)
		{
			return;
		}
		if (isPosCmd())
		{
			if (fraImageCmd != null)
			{
				fraImageCmd.drawFrame(frameCmd, xCmd, yCmd, 0, 3, g);
			}
			else
			{
				paintbutton(g, xCmd, yCmd);
			}
			paintCaptionImage(g, xCmd, yCmd - 6, 2);
		}
		else
		{
			if (fraImageCmd != null)
			{
				fraImageCmd.drawFrame(frameCmd, x, y, 0, 3, g);
			}
			else
			{
				paintbutton(g, x, y);
			}
			paintCaptionImage(g, x, y - 6, 2);
		}
	}

	public void paintCaptionImage(mGraphics g, int x, int y, int pos)
	{
		if (caption == null)
		{
			return;
		}
		int num = 0;
		if (fraImgCaptionArr == null)
		{
			if (fraImgCaption != null)
			{
				switch (pos)
				{
				case 2:
					fraImgCaption.drawFrame(beginframe + GameCanvas.gameTick / 2 % nframe, x - wimgCaption / 2 - wstr / 2, y + himgCaption / 2 - 3, 0, 3, g);
					num = wimgCaption / 2;
					break;
				case 0:
					fraImgCaption.drawFrame(beginframe + GameCanvas.gameTick / 2 % nframe, x + wimgCaption / 2, y + himgCaption / 2 - 4, 0, 3, g);
					num = wimgCaption + 6;
					break;
				}
			}
		}
		else
		{
			switch (pos)
			{
			case 2:
				fraImgCaptionArr[GameCanvas.gameTick / 2 % nframe].drawFrame(0, x - wimgCaption / 2 - wstr / 2, y + himgCaption / 2 - 3, 0, 3, g);
				num = wimgCaption / 2;
				break;
			case 0:
				fraImgCaptionArr[GameCanvas.gameTick / 2 % nframe].drawFrame(0, x + wimgCaption / 2, y + himgCaption / 2 - 4, 0, 3, g);
				num = wimgCaption + 6;
				break;
			}
		}
		if (!isButtonDai)
		{
			if (GameCanvas.isSmallScreen)
			{
				mFont.tahoma_7_white.drawString(g, caption, x + num, y, pos, mGraphics.isTrue);
			}
			else
			{
				AvMain.Font3dColor(g, caption, x + num, y, pos, 0);
			}
		}
		else if (GameCanvas.isSmallScreen)
		{
			mFont.tahoma_7_white.drawString(g, caption, x + num + wimgCmd / 2, y + himgCmd / 2 + 1, pos, mGraphics.isTrue);
		}
		else
		{
			AvMain.Font3dColor(g, caption, x + num + wimgCmd / 2, y + himgCmd / 2 + 1, pos, 0);
		}
	}

	public void paintCaptionImageMenu(mGraphics g, int x, int y, int pos)
	{
		int num = 0;
		if (fraImgCaptionArr == null)
		{
			if (fraImgCaption != null)
			{
				switch (pos)
				{
				case 2:
					fraImgCaption.drawFrame(beginframe + GameCanvas.gameTick / 2 % nframe, x - wimgCaption / 2 - wstr / 2, y + himgCaption / 2, 0, 3, g);
					num = wimgCaption / 2;
					break;
				case 0:
					fraImgCaption.drawFrame(beginframe + GameCanvas.gameTick / 2 % nframe, x + wimgCaption / 2, y + himgCaption / 2, 0, 3, g);
					num = wimgCaption + 6;
					break;
				}
			}
		}
		else
		{
			switch (pos)
			{
			case 2:
				fraImgCaptionArr[GameCanvas.gameTick / 2 % nframe].drawFrame(0, x - wimgCaption / 2 - wstr / 2, y + himgCaption / 2 - 3, 0, 3, g);
				num = wimgCaption / 2;
				break;
			case 0:
				fraImgCaptionArr[GameCanvas.gameTick / 2 % nframe].drawFrame(0, x + wimgCaption / 2, y + himgCaption / 2 - 4, 0, 3, g);
				num = wimgCaption + 6;
				break;
			}
		}
		if (GameCanvas.isSmallScreen)
		{
			mFont.tahoma_7_white.drawString(g, caption, x + num, y, pos, mGraphics.isFalse);
		}
		else
		{
			AvMain.Font3dColorAndColor(g, caption, x + num, y, pos, 7, 0);
		}
	}

	public void paintClickCaption(mGraphics g, int x, int y, int pos)
	{
		if (frameCmd == 1 && clickCaption.Length > 0)
		{
			AvMain.Font3dColor(g, clickCaption, x + xdich, y + ydich, pos, 0);
		}
	}

	public void paintImage(mGraphics g, int x, int y, int pos, int typePaint)
	{
		if (fraImgCaption == null)
		{
			return;
		}
		switch (typePaint)
		{
		case 0:
			fraImgCaption.drawFrame(beginframe + GameCanvas.gameTick / 2 % nframe, x, y + himgCaption / 2, 0, pos, g);
			break;
		case 1:
		{
			int num = ((beginframe + frameCmd == 1) ? 1 : 0);
			if (num > nframe)
			{
				num = beginframe - 1;
			}
			fraImgCaption.drawFrame(num, x, y + himgCaption / 2, 0, pos, g);
			break;
		}
		default:
			fraImgCaption.drawFrame(beginframe, x, y + himgCaption / 2, 0, pos, g);
			break;
		}
	}

	public void updatePointer()
	{
		if (!isButtonDai)
		{
			if (!isPosCmd())
			{
				return;
			}
			if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
			{
				if (GameCanvas.isPoint(xCmd - wimgCmd / 2 - 5, yCmd - himgCmd / 2 - 5, wimgCmd + 10, himgCmd + 10))
				{
					frameCmd = 1;
				}
				else
				{
					frameCmd = 0;
				}
			}
			else
			{
				frameCmd = 0;
			}
			if (GameCanvas.isPointSelect(xCmd - wimgCmd / 2 - 5, yCmd - himgCmd / 2 - 5, wimgCmd + 10, himgCmd + 10))
			{
				perform();
				GameCanvas.isPointerSelect = false;
				frameCmd = 0;
			}
		}
		else
		{
			if (!isPosCmd())
			{
				return;
			}
			if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
			{
				if (GameCanvas.isPoint(xCmd - 5, yCmd - 5, wimgCmd + 10, himgCmd + 10))
				{
					isSelect = true;
					frameCmd = 1;
				}
				else
				{
					frameCmd = 0;
					isSelect = false;
				}
			}
			else
			{
				frameCmd = 0;
				isSelect = false;
			}
			if (GameCanvas.isPointSelect(xCmd - 5, yCmd - 5, wimgCmd + 10, himgCmd + 10))
			{
				perform();
				GameCanvas.isPointerSelect = false;
				frameCmd = 0;
				isSelect = false;
			}
		}
	}

	public void updatePointer(int cmx, int cmy)
	{
		if (!isPosCmd())
		{
			return;
		}
		if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
		{
			if (GameCanvas.isPoint(xCmd - wimgCmd / 2 - 3 - cmx, yCmd - himgCmd / 2 - 3 - cmy, wimgCmd + 6, himgCmd + 6))
			{
				frameCmd = 1;
			}
			else
			{
				frameCmd = 0;
			}
		}
		else
		{
			frameCmd = 0;
		}
		if (GameCanvas.isPointSelect(xCmd - wimgCmd / 2 - 3 - cmx, yCmd - himgCmd / 2 - 3 - cmy, wimgCmd + 6, himgCmd + 6))
		{
			perform();
			GameCanvas.isPointerSelect = false;
			frameCmd = 0;
		}
	}

	public void updatePointerShow(int cmx, int cmy)
	{
		if (!isPosCmd())
		{
			return;
		}
		if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
		{
			if (GameCanvas.isPoint(xCmd - wimgCmd / 2 - 3 - cmx, yCmd - himgCmd / 2 - 3 - cmy, wimgCmd + 6, himgCmd + 6))
			{
				frameCmd = 1;
			}
			else
			{
				frameCmd = 0;
			}
		}
		else
		{
			frameCmd = 0;
		}
	}

	public void paintbutton(mGraphics g, int x, int y)
	{
		if (GameCanvas.isTouch)
		{
			if (!isButtonDai)
			{
				PaintInfoGameScreen.fraButton.drawFrame(frameCmd, x, y, 0, 3, g);
			}
			else
			{
				AvMain.paintDialog(g, x, y, wimgCmd, himgCmd, isSelect ? 1 : 2);
			}
		}
		else if (!isButtonDai)
		{
			AvMain.paintDialog(g, x - wButtonCmd / 2, y - hButtonCmd / 2, wButtonCmd, hButtonCmd, isSelect ? 1 : 2);
		}
		else
		{
			AvMain.paintDialog(g, x, y, wimgCmd, himgCmd, isSelect ? 1 : 2);
		}
	}

	public bool isPosCmd()
	{
		if (xCmd > 0 && yCmd > 0)
		{
			return true;
		}
		return false;
	}
}
