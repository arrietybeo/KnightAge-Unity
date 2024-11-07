public class CreateChar : MainScreen
{
	public const int SELECT_CLASS = 0;

	private int wRectChar = 180;

	private int hRectChar = 160;

	public TField tfNameChar;

	public static mVector VecDefaultChar = new mVector("CreateChar VecDefaultchar");

	private int frame;

	private int timeChangeClass;

	private int fFocus;

	private int selectClass;

	private int indexChar;

	private sbyte[] mselect;

	private sbyte[][] mCreateChar = mSystem.new_M_Byte(4, 3);

	private sbyte[][] mEye = new sbyte[2][]
	{
		new sbyte[2] { 8, 9 },
		new sbyte[2] { 10, 11 }
	};

	private sbyte[][] mHair = new sbyte[2][]
	{
		new sbyte[2] { 0, 1 },
		new sbyte[2] { 2, 3 }
	};

	private int numHair = 2;

	private int numEye = 2;

	private sbyte index;

	private mVector vecCmd = new mVector("CreateChar veccmd");

	private iCommand cmdclass;

	private iCommand cmdtoc;

	private iCommand cmdmat;

	private iCommand cmddau;

	private iCommand cmdBack;

	private int direction;

	private int cout;

	public CreateChar()
	{
		if (GameCanvas.isTouch)
		{
			hRectChar = 182;
			wRectChar = 200;
		}
		init();
	}

	public void Show(sbyte index)
	{
		mSound.stopSoundAll();
		if (LoginScreen.MusicRandom == 0)
		{
			mSound.playMus(0, mSound.volumeMusic, loop: true);
		}
		else
		{
			mSound.playMus(1, mSound.volumeMusic, loop: true);
		}
		this.index = index;
		base.Show();
	}

	public override void commandTab(int index, int sub)
	{
		switch (index)
		{
		case 0:
		{
			string text = tfNameChar.getText();
			if (text.Length < 6)
			{
				GameCanvas.start_Ok_Dialog(T.nameMin6char);
				break;
			}
			Other_Players other_Players = (Other_Players)VecDefaultChar.elementAt(indexChar);
			GlobalService.gI().create_char(other_Players.clazz, text, (sbyte)other_Players.hair, (sbyte)other_Players.EyeMain, (sbyte)other_Players.head, this.index);
			GameCanvas.start_Wait_Dialog(T.pleaseWait, null);
			break;
		}
		case 1:
			if (SelectCharScreen.VecSelectChar.size() == 0)
			{
				GameCanvas.login.Show();
				Session_ME.gI().close();
				GameScreen.player = new Player(0, 0, "unname", 0, 0);
			}
			else
			{
				GameCanvas.selectChar.Show();
			}
			break;
		}
		base.commandTab(index, sub);
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			selectClass = 0;
			indexChar++;
			timeChangeClass = 0;
			if (indexChar == 4)
			{
				MainScreen.cameraSub.xCam = -wRectChar / 4;
			}
			indexChar = resetSelect(indexChar, T.mClass.Length - 1, isreset: true);
			MainScreen.cameraSub.xTo = indexChar * wRectChar / 4;
			cmdclass.caption = T.mClass[indexChar];
			Other_Players other_Players = (Other_Players)VecDefaultChar.elementAt(indexChar);
			cmdtoc.caption = T.mCreateChar_HAIR[indexChar / 2][other_Players.hair % numHair];
			break;
		}
		case 1:
		case 2:
		case 3:
			selectClass = index;
			editChar(1);
			break;
		}
	}

	public void init()
	{
		VecDefaultChar.removeAllElements();
		center = new iCommand(T.create, 0);
		cmdBack = new iCommand(T.back, 1);
		if (GameCanvas.isTouch)
		{
			int num = iCommand.wButtonCmd / 2;
			if (num < wRectChar / 4)
			{
				num = wRectChar / 4;
			}
			center.setPos(GameCanvas.hw - num, GameCanvas.hh + hRectChar / 2 + 4, null, center.caption);
			cmdBack.setPos(GameCanvas.hw + num, GameCanvas.hh + hRectChar / 2 + 4, null, cmdBack.caption);
		}
		left = cmdBack;
		for (int i = 0; i < 4; i++)
		{
			Other_Players other_Players = new Other_Players(i, 0, string.Empty, 0, 0);
			other_Players.clazz = (sbyte)i;
			other_Players.leg = i;
			other_Players.body = i;
			other_Players.hat = -1;
			other_Players.head = 0;
			other_Players.hair = i;
			other_Players.eye = 8 + i;
			other_Players.EyeMain = other_Players.eye;
			other_Players.Direction = 0;
			other_Players.wing = -1;
			other_Players.x = wRectChar / 5 + i * wRectChar / 4;
			other_Players.y = hRectChar / 5 * 2;
			other_Players.weaponType = 0;
			VecDefaultChar.addElement(other_Players);
		}
		mselect = new sbyte[4];
		indexChar = CRes.random(4);
		selectClass = 0;
		MainScreen.cameraSub.setAll(VecDefaultChar.size() * wRectChar / 4, 0, indexChar * wRectChar / 4, 0);
		tfNameChar = new TField(GameCanvas.hw - wRectChar / 2 + wRectChar / 5 - 25, GameCanvas.hh - hRectChar / 2 + hRectChar / 2 + 10, 60);
		tfNameChar.showSubTextField = true;
		if (!GameCanvas.isTouch)
		{
			tfNameChar.setFocus(isFocus: true);
			return;
		}
		cmdclass = new iCommand(T.mClass[indexChar], 0, this);
		vecCmd.addElement(cmdclass);
		Other_Players other_Players2 = (Other_Players)VecDefaultChar.elementAt(indexChar);
		cmdtoc = new iCommand(T.mCreateChar_HAIR[indexChar / 2][other_Players2.hair % numHair], 1, this);
		vecCmd.addElement(cmdtoc);
		int num2 = other_Players2.eye;
		if (num2 < 8)
		{
			num2 = other_Players2.EyeMain;
		}
		cmdmat = new iCommand(T.mCreateChar_EYE_FACE[0][num2 - 8], 2, this);
		vecCmd.addElement(cmdmat);
		cmddau = new iCommand(T.mCreateChar_EYE_FACE[1][other_Players2.head], 3, this);
		vecCmd.addElement(cmddau);
		int num3 = GameCanvas.hw - wRectChar / 2;
		int num4 = GameCanvas.hh - hRectChar / 2 - GameCanvas.hCommand / 2;
		for (int j = 0; j < vecCmd.size(); j++)
		{
			iCommand iCommand2 = (iCommand)vecCmd.elementAt(j);
			iCommand2.setPos(num3 + wRectChar / 3 * 2, num4 + hRectChar / 5 * (j + 1) + 5, PaintInfoGameScreen.fraButton2, iCommand2.caption);
		}
	}

	public override void paint(mGraphics g)
	{
		BackGround.paint(g);
		BackGround.paintLight(g);
		AvMain.paintTabNew(g, GameCanvas.hw - wRectChar / 2, GameCanvas.hh - hRectChar / 2 - GameCanvas.hCommand / 2, wRectChar, hRectChar, ismore: true, 0);
		g.translate(GameCanvas.hw - wRectChar / 2, GameCanvas.hh - hRectChar / 2 - GameCanvas.hCommand / 2);
		Other_Players other_Players = (Other_Players)VecDefaultChar.elementAt(indexChar);
		for (int i = 0; i < T.textCreateChar.Length; i++)
		{
			mFont.tahoma_7b_black.drawString(g, T.textCreateChar[i], wRectChar / 3 * 2, hRectChar / 5 * i + hRectChar / 10, 2, mGraphics.isFalse);
		}
		if (!GameCanvas.isTouch)
		{
			AvMain.FontBorderColor(g, T.mClass[indexChar], wRectChar / 3 * 2, hRectChar / 5, 2, 2);
			AvMain.FontBorderColor(g, T.mCreateChar_HAIR[indexChar / 2][other_Players.hair % numHair], wRectChar / 3 * 2, hRectChar / 5 * 2, 2, 2);
			int num = other_Players.eye;
			if (num < 8)
			{
				num = other_Players.EyeMain;
			}
			AvMain.FontBorderColor(g, T.mCreateChar_EYE_FACE[0][num - 8], wRectChar / 3 * 2, hRectChar / 5 * 3, 2, 2);
			AvMain.FontBorderColor(g, T.mCreateChar_EYE_FACE[1][other_Players.head], wRectChar / 3 * 2, hRectChar / 5 * 4, 2, 2);
		}
		if (!GameCanvas.isTouch)
		{
			g.drawRegion(MainObject.focus, 0, 0, 11, 9, 5, wRectChar / 3 * 2 - 35 - fFocus / 2 % 4, hRectChar / 5 * (selectClass + 1) + 4, 3, mGraphics.isFalse);
			g.drawRegion(MainObject.focus, 0, 0, 11, 9, 6, wRectChar / 3 * 2 + 35 + fFocus / 2 % 4, hRectChar / 5 * (selectClass + 1) + 4, 3, mGraphics.isFalse);
		}
		mFont.tahoma_7_black.drawString(g, T.namePlayer, wRectChar / 5 + 4, hRectChar / 2 + 5, 2, mGraphics.isFalse);
		g.setClip(8, 2, wRectChar / 5 * 2 - 12, hRectChar - 4);
		g.translate(-MainScreen.cameraSub.xCam, 0);
		for (int j = 0; j < VecDefaultChar.size(); j++)
		{
			Other_Players other_Players2 = (Other_Players)VecDefaultChar.elementAt(j);
			if (j == 0)
			{
				other_Players2.paintShowPlayer(g, other_Players2.x + wRectChar / 4 * VecDefaultChar.size(), other_Players2.y, other_Players2.Direction);
			}
			if (j == VecDefaultChar.size() - 1)
			{
				other_Players2.paintShowPlayer(g, other_Players2.x - wRectChar / 4 * VecDefaultChar.size(), other_Players2.y, other_Players2.Direction);
			}
			other_Players2.paintPlayer(g, -1);
			if (other_Players2.Action == 2)
			{
				other_Players2.PlashNow.update(other_Players2);
			}
			else if (other_Players2.Action == 1)
			{
				other_Players2.f++;
				if (other_Players2.f > other_Players2.A_Move.Length - 1)
				{
					other_Players2.f = 0;
				}
				other_Players2.frame = other_Players2.A_Move[other_Players2.f];
			}
			else
			{
				other_Players2.updateActionPerson();
			}
			other_Players2.updateEye();
		}
		GameCanvas.resetTrans(g);
		for (int k = 0; k < vecCmd.size(); k++)
		{
			iCommand iCommand2 = (iCommand)vecCmd.elementAt(k);
			iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
		}
		tfNameChar.paint(g);
		if (PaintInfoGameScreen.paint18plush == 0)
		{
			g.drawImage(AvMain.img18Plus, 0, 0, 0, mGraphics.isFalse);
		}
		else if (PaintInfoGameScreen.paint18plush == 1)
		{
			PaintInfoGameScreen.paintinfo18plush(g);
		}
		if (LoginScreen.isPaintHotLine)
		{
			mFont.tahoma_7_yellow.drawString(g, T.HotLine, GameCanvas.w, 0, 1, mGraphics.isFalse);
			g.setColor(16514362);
			g.fillRect(GameCanvas.w - LoginScreen.wLine + (mSystem.isIphone ? 14 : 0), 10, LoginScreen.wLine, 1, mGraphics.isFalse);
		}
		base.paint(g);
	}

	public override void update()
	{
		if (LoginScreen.hShowServer < 20)
		{
			LoginScreen.hShowServer += 4;
			if (LoginScreen.hShowServer > 20)
			{
				LoginScreen.hShowServer = 20;
			}
		}
		if (timeChangeClass == 0)
		{
			Other_Players other_Players = (Other_Players)VecDefaultChar.elementAt(indexChar);
			other_Players.Direction = 0;
		}
		else if (timeChangeClass == 30 || timeChangeClass == 10)
		{
			Other_Players other_Players2 = (Other_Players)VecDefaultChar.elementAt(indexChar);
			other_Players2.Action = 2;
			other_Players2.f = 0;
			other_Players2.beginFire();
			other_Players2.PlashNow.setPlash(other_Players2.clazz);
		}
		else if (timeChangeClass == 50)
		{
			Other_Players other_Players3 = (Other_Players)VecDefaultChar.elementAt(indexChar);
			other_Players3.Action = 1;
			other_Players3.f = 0;
		}
		else if (timeChangeClass > 80)
		{
			Other_Players other_Players4 = (Other_Players)VecDefaultChar.elementAt(indexChar);
			timeChangeClass = 1;
			other_Players4.Action = 0;
			other_Players4.f = 0;
			other_Players4.Direction = ++other_Players4.Direction % 4;
		}
		timeChangeClass++;
		tfNameChar.update();
		fFocus++;
		MainScreen.cameraSub.UpdateCameraCreate();
		MainScreen.cameraSub.UpdateCameraCreate();
		BackGround.updateSky();
	}

	public override void updatekey()
	{
		Cout.LogWarning(" thong tin " + tfNameChar.isFocus);
		if (tfNameChar != null && !tfNameChar.isFocus)
		{
			if (GameCanvas.keyMyHold[4] && !Main.isPC)
			{
				if (selectClass == 0)
				{
					indexChar--;
					timeChangeClass = 0;
				}
				else
				{
					editChar(-1);
				}
				GameCanvas.clearKeyHold(4);
				tfNameChar.caretPos = tfNameChar.getText().Length + 1;
			}
			else if (GameCanvas.keyMyHold[6] && !Main.isPC)
			{
				if (selectClass == 0)
				{
					indexChar++;
					timeChangeClass = 0;
				}
				else
				{
					editChar(1);
				}
				GameCanvas.clearKeyHold(6);
				tfNameChar.caretPos = tfNameChar.getText().Length + 1;
			}
			else if (GameCanvas.keyMyHold[2])
			{
				selectClass--;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				selectClass++;
				GameCanvas.clearKeyHold(8);
			}
		}
		selectClass = resetSelect(selectClass, T.textCreateChar.Length - 1, isreset: true);
		if (indexChar == 4)
		{
			MainScreen.cameraSub.xCam = -wRectChar / 4;
		}
		else if (indexChar == -1)
		{
			MainScreen.cameraSub.xCam = 4 * wRectChar / 4;
		}
		indexChar = resetSelect(indexChar, T.mClass.Length - 1, isreset: true);
		MainScreen.cameraSub.xTo = indexChar * wRectChar / 4;
		if (tfNameChar.isFocusedz())
		{
			if (Main.isPC)
			{
				right = tfNameChar.setCmdClear();
			}
		}
		else
		{
			right = null;
		}
		if (GameCanvas.keyMyPressed[3])
		{
			direction = (direction + 1) % 4;
		}
		base.updatekey();
	}

	public void editChar(int i)
	{
		Other_Players other_Players = (Other_Players)VecDefaultChar.elementAt(indexChar);
		switch (selectClass)
		{
		case 1:
			other_Players.hair += i;
			other_Players.hair = indexChar / numHair * numHair + resetSelect(other_Players.hair - indexChar / numHair * numHair, numHair - 1, isreset: true);
			if (GameCanvas.isTouch)
			{
				cmdtoc.caption = T.mCreateChar_HAIR[indexChar / 2][other_Players.hair % numHair];
			}
			break;
		case 2:
			other_Players.eye += i;
			other_Players.eye = 8 + indexChar / numEye * numEye + resetSelect(other_Players.eye - 8 - indexChar / numEye * numEye, numEye - 1, isreset: true);
			other_Players.EyeMain = other_Players.eye;
			mSystem.outz("eye" + other_Players.eye);
			if (GameCanvas.isTouch)
			{
				int num = other_Players.eye;
				if (num < 8)
				{
					num = other_Players.EyeMain;
				}
				cmdmat.caption = T.mCreateChar_EYE_FACE[0][num - 8];
			}
			break;
		case 3:
			other_Players.head += i;
			other_Players.head = resetSelect(other_Players.head, T.mCreateChar_EYE_FACE[1].Length - 1, isreset: true);
			if (GameCanvas.isTouch)
			{
				cmddau.caption = T.mCreateChar_EYE_FACE[1][other_Players.head];
			}
			break;
		}
	}

	public override void keyPress(int keyCode)
	{
		if (tfNameChar.isFocusedz())
		{
			tfNameChar.keyPressed(keyCode);
		}
		base.keyPress(keyCode);
	}

	public override void updatePointer()
	{
		for (int i = 0; i < vecCmd.size(); i++)
		{
			iCommand iCommand2 = (iCommand)vecCmd.elementAt(i);
			iCommand2.updatePointer();
		}
		base.updatePointer();
	}

	public override void keyBack()
	{
		cmdBack.perform();
	}
}
