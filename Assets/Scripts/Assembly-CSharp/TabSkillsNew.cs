using System;

public class TabSkillsNew : MainTabNew
{
	public static int[][] XYpaint;

	private int sizeKill = 22;

	private int idSelect;

	private int hcmd;

	private iCommand cmdSetPoint;

	private iCommand cmdSendSetPoint;

	private iCommand cmdSendSetPointOne;

	private iCommand cmdSetKey;

	private iCommand cmdMenu;

	private iCommand cmdupskill;

	private InputDialog inputDialog;

	private ListNew list;

	private mVector vecListCmd;

	public static mVector vecPaintSkill = new mVector("TabSkillsNew vecPaintSkill");

	private bool isSaveSkill;

	public mVector vecEffRe = new mVector();

	private int[] stylePaint = new int[21]
	{
		1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, -1, -1, -1,
		-1
	};

	private int hKill = 4;

	private int w8;

	public TabSkillsNew(string name)
	{
		typeTab = MainTabNew.SKILLS;
		nameTab = name;
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3 + MainTabNew.wblack % 8 / 2;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
		XYpaint = mSystem.new_M_Int(Player.MaxSkill, 2);
		int num = yBegin + MainTabNew.wOneItem / 2 + GameCanvas.hText;
		for (int i = 0; i < Player.MaxSkill; i++)
		{
			if (i == 0)
			{
				XYpaint[i][0] = xBegin + MainTabNew.wblack / 2;
				XYpaint[i][1] = num;
				num += sizeKill * 2;
				continue;
			}
			XYpaint[i][1] = num;
			if (i % 2 == 1)
			{
				XYpaint[i][0] = xBegin + MainTabNew.wblack / 4;
				continue;
			}
			XYpaint[i][0] = xBegin + MainTabNew.wblack / 4 * 3;
			num += sizeKill * 2;
		}
		init();
		cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			cmdBack.caption = T.close;
		}
		cmdSetPoint = new iCommand(T.setPoint, 0, this);
		cmdSendSetPoint = new iCommand(T.cong, 1, this);
		cmdSendSetPointOne = new iCommand(T.cong, 2, this);
		cmdSetKey = new iCommand(T.setKey, 3, this);
		cmdMenu = new iCommand(T.select, 5, this);
		cmdupskill = new iCommand(T.nangcap, 6, this);
		vecEffRe.removeAllElements();
		w8 = MainTabNew.wblack / 8;
	}

	public override void init()
	{
		MainTabNew.timePaintInfo = 0;
		int yLimit = XYpaint[Player.MaxSkill - 1][1] - yBegin + sizeKill - MainTabNew.hblack + 5;
		MainScreen.cameraSub.setAll(0, yLimit, 0, 0);
		list = new ListNew(xBegin, yBegin + GameCanvas.hText + 2, MainTabNew.wblack, MainTabNew.hblack - GameCanvas.hText - 2, 0, 0, MainScreen.cameraSub.yLimit);
		if (!GameCanvas.isTouch)
		{
			right = cmdBack;
			center = cmdMenu;
		}
		if (GameCanvas.isTouch)
		{
			idSelect = -1;
		}
		else
		{
			idSelect = 0;
		}
		listContent = null;
	}

	public new void backTab()
	{
		if (isSaveSkill)
		{
			saveSkill();
			isSaveSkill = false;
		}
		MainTabNew.timePaintInfo = 0;
		MainTabNew.Focus = MainTabNew.TAB;
		if (GameCanvas.isTouch)
		{
			idSelect = -1;
		}
		else
		{
			idSelect = 0;
		}
		base.backTab();
	}

	public override void commandPointer(int index, int subIndex)
	{
		if ((idSelect == -1 || idSelect > vecPaintSkill.size() - 1) && index != -1)
		{
			return;
		}
		switch (index)
		{
		case -1:
			backTab();
			break;
		case 0:
		{
			Skill skill = (Skill)vecPaintSkill.elementAt(idSelect);
			if (skill.lvMin > GameScreen.player.Lv)
			{
				GameCanvas.start_Ok_Dialog(T.capdochuadu);
				return;
			}
			if (Player.diemKyNang == 1)
			{
				GameCanvas.start_Left_Dialog(T.cong1kynang + skill.name, cmdSendSetPointOne);
			}
			else if (Player.diemKyNang > 0)
			{
				int num = Player.diemKyNang;
				if (num > 10 - Player.mCurentLvSkill[skill.Id])
				{
					num = 10 - Player.mCurentLvSkill[skill.Id];
				}
				inputDialog = new InputDialog();
				inputDialog.setinfo(T.nhapsodiem + skill.name + T.nhohonhoacbang + num + ")", cmdSendSetPoint, isNum: true, T.tabkynang);
				GameCanvas.currentDialog = inputDialog;
			}
			break;
		}
		case 1:
		{
			short num2 = 0;
			try
			{
				num2 = short.Parse(inputDialog.tfInput.getText());
			}
			catch (Exception)
			{
				num2 = 0;
			}
			if (num2 < 1)
			{
				return;
			}
			GlobalService.gI().Add_Base_Skill_Point(1, (sbyte)((Skill)vecPaintSkill.elementAt(idSelect)).Id, num2);
			if (GameScreen.help.setStep_Next(8, 7))
			{
				GameScreen.help.Next++;
				GameScreen.help.setNext();
			}
			else
			{
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 2:
			GameCanvas.end_Dialog();
			GlobalService.gI().Add_Base_Skill_Point(1, (sbyte)((Skill)vecPaintSkill.elementAt(idSelect)).Id, 1);
			if (GameScreen.help.setStep_Next(8, 7))
			{
				GameScreen.help.Next++;
				GameScreen.help.setNext();
			}
			MainTabNew.timePaintInfo = 0;
			break;
		case 3:
		{
			mVector mVector4 = new mVector("TabSkillsNew menu");
			for (int i = 0; i < 5; i++)
			{
				iCommand iCommand2 = null;
				iCommand2 = (GameCanvas.isTouch ? new iCommand(T.oso + (i + 1), 4, i, this) : ((!TField.isQwerty) ? new iCommand(T.phim + PaintInfoGameScreen.mValueHotKey[i], 4, i, this) : new iCommand(T.phim + PaintInfoGameScreen.mValueChar[i], 4, i, this)));
				mVector4.addElement(iCommand2);
			}
			GameCanvas.menu2.startAt(mVector4, 2, T.setKey, isFocus: false, null);
			break;
		}
		case 4:
		{
			Skill skill2 = (Skill)vecPaintSkill.elementAt(idSelect);
			Player.mhotkey[Player.levelTab][subIndex].setHotKey(skill2.Id, HotKey.SKILL, 0);
			if (GameCanvas.isTouch)
			{
				saveSkill();
			}
			else
			{
				isSaveSkill = true;
			}
			break;
		}
		case 5:
		{
			if (idSelect == -1)
			{
				return;
			}
			mVector mVector3 = new mVector("TabSkillsNew vecmenu");
			mVector3 = doMenu();
			if (mVector3 != null && mVector3.size() > 0)
			{
				GameCanvas.menu2.startAt(mVector3, 2, T.kynang, isFocus: false, null);
			}
			break;
		}
		case 6:
			GlobalService.gI().Add_Base_Skill_Point(2, (sbyte)((Skill)vecPaintSkill.elementAt(idSelect)).Id);
			vecEffRe.removeAllElements();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	public void upgraderesult(int type)
	{
		if (type == 0)
		{
			mSound.playSound(27, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(11, XYpaint[idSelect][0], XYpaint[idSelect][1] + sizeKill / 2);
			addEffectRebuild(69, XYpaint[idSelect][0], XYpaint[idSelect][1] + sizeKill / 2, 300);
			addEffectRebuild(69, XYpaint[idSelect][0], XYpaint[idSelect][1] + sizeKill / 2, 300);
			GameCanvas.addInfoChar(T.thatbai);
		}
		else
		{
			mSound.playSound(26, mSound.volumeSound);
			vecEffRe.removeAllElements();
			addEffectEnd_ReBuild_ss(32, XYpaint[idSelect][0], XYpaint[idSelect][1] + sizeKill / 2);
			addEffectEnd_ReBuild_ss(33, XYpaint[idSelect][0], XYpaint[idSelect][1] + sizeKill / 2);
			addEffectEnd_ReBuild_ss(34, XYpaint[idSelect][0], XYpaint[idSelect][1] + sizeKill / 2);
			GameCanvas.addInfoChar(T.thanhcong);
		}
	}

	public void addEffectEnd_ReBuild_ss(int type, int x, int y)
	{
		EffectEnd o = new EffectEnd(type, x, y);
		vecEffRe.addElement(o);
	}

	public void addEffectRebuild(int type, int x, int y, int time)
	{
		EffectSkill o = new EffectSkill(type, x, y, time, 0, 0);
		vecEffRe.addElement(o);
	}

	public void setXYSkill(mVector vec)
	{
		XYpaint = null;
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3 + MainTabNew.wblack % 8 / 2;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
		XYpaint = mSystem.new_M_Int(Player.MaxSkill, 2);
		int num = yBegin + MainTabNew.wOneItem / 2 + GameCanvas.hText;
		for (int i = 0; i < vec.size(); i++)
		{
			Skill skill = (Skill)vec.elementAt(i);
			if (skill == null)
			{
				continue;
			}
			if (i == 0)
			{
				XYpaint[i][0] = xBegin + MainTabNew.wblack / 2;
				XYpaint[i][1] = num;
				num += sizeKill * 2;
				continue;
			}
			XYpaint[i][1] = num;
			if (skill.typePaint == 0)
			{
				XYpaint[i][0] = xBegin + MainTabNew.wblack / 4;
			}
			else if (skill.typePaint == 1)
			{
				XYpaint[i][0] = xBegin + MainTabNew.wblack / 4 * 3;
				if (i < vec.size() - 2)
				{
					num += sizeKill * 2;
				}
			}
		}
	}

	public override void paint(mGraphics g)
	{
		mFont.tahoma_7_white.drawString(g, T.diemkynang + Player.diemKyNang, xBegin + 2, yBegin + 3, 0, mGraphics.isFalse);
		g.setClip(xBegin, yBegin + GameCanvas.hText + 2, MainTabNew.wblack, MainTabNew.hblack - 2 - GameCanvas.hText);
		g.translate(0, -MainScreen.cameraSub.yCam);
		for (int i = 0; i < vecPaintSkill.size(); i++)
		{
			paintLine(g, i);
			Skill skill = (Skill)vecPaintSkill.elementAt(i);
			if (skill == null)
			{
				continue;
			}
			skill.paint(g, XYpaint[i][0], XYpaint[i][1] + sizeKill / 2, 3);
			if (i == idSelect && MainTabNew.Focus == MainTabNew.INFO)
			{
				g.drawImage(AvMain.imgSelect_1, XYpaint[i][0] - sizeKill / 2 - 2, XYpaint[i][1] - 2, 0, mGraphics.isTrue);
			}
			if (skill.lvMin > GameScreen.player.Lv)
			{
				g.drawRegion(AvMain.imgDelaySkill, 0, 0, 20, 20, 0, XYpaint[i][0], XYpaint[i][1] + sizeKill / 2, 3, mGraphics.isTrue);
			}
			if (i != 0)
			{
				AvMain.Font3dWhite(g, Player.mCurentLvSkill[skill.Id] + string.Empty, XYpaint[i][0] + sizeKill / 2 + 4, XYpaint[i][1] + sizeKill / 2 - 12, 0);
				if (Player.mPlusLvSkill[skill.Id] > 0)
				{
					AvMain.Font3dColor(g, "+" + Player.mPlusLvSkill[skill.Id], XYpaint[i][0] + sizeKill / 2 + 4, XYpaint[i][1] + sizeKill - 12, 0, 1);
				}
			}
		}
		for (int j = 0; j < vecEffRe.size(); j++)
		{
			MainEffect mainEffect = (MainEffect)vecEffRe.elementAt(j);
			mainEffect.paint(g);
		}
		if (((GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null) && MainTabNew.longwidth <= 0) || MainTabNew.Focus != MainTabNew.INFO || MainTabNew.timePaintInfo <= MainTabNew.timeRequest)
		{
			return;
		}
		paintPopupContent(g, isOnlyName: false);
		if (vecListCmd != null)
		{
			for (int k = 0; k < vecListCmd.size(); k++)
			{
				iCommand iCommand2 = (iCommand)vecListCmd.elementAt(k);
				iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
			}
		}
	}

	public void paintLine(mGraphics g, int i)
	{
		g.setColor(MainTabNew.color[6]);
		if (stylePaint[i] == 0)
		{
			g.fillRect(XYpaint[i][0], XYpaint[i][1] + sizeKill, 1, hKill * 2 + sizeKill, mGraphics.isTrue);
		}
		else if (stylePaint[i] == 1)
		{
			g.fillRect(XYpaint[i][0], XYpaint[i][1] + sizeKill, 1, sizeKill / 2, mGraphics.isTrue);
			g.fillRect(XYpaint[i][0] - 2 * w8, XYpaint[i][1] + sizeKill + sizeKill / 2, w8 * 4 + 1, 1, mGraphics.isTrue);
			g.fillRect(XYpaint[i][0] - 2 * w8, XYpaint[i][1] + sizeKill + sizeKill / 2 + 1, 1, sizeKill / 2, mGraphics.isTrue);
			g.fillRect(XYpaint[i][0] + 2 * w8, XYpaint[i][1] + sizeKill + sizeKill / 2 + 1, 1, sizeKill / 2, mGraphics.isTrue);
		}
		else if (stylePaint[i] == 2)
		{
			g.fillRect(XYpaint[i][0], XYpaint[i][1] + sizeKill, 1, hKill / 2, mGraphics.isTrue);
			g.fillRect(XYpaint[i][0] - w8, XYpaint[i][1] + sizeKill + hKill / 2, w8 * 2 + 1, 1, mGraphics.isTrue);
			g.fillRect(XYpaint[i][0] - w8, XYpaint[i][1] + sizeKill + hKill / 2 + 1, 1, hKill / 2 + 4, mGraphics.isTrue);
			g.fillRect(XYpaint[i][0] + w8, XYpaint[i][1] + sizeKill + hKill / 2 + 1, 1, hKill / 2 + 4, mGraphics.isTrue);
		}
	}

	public override void update()
	{
		try
		{
			for (int i = 0; i < vecEffRe.size(); i++)
			{
				MainEffect mainEffect = (MainEffect)vecEffRe.elementAt(i);
				mainEffect.update();
				if (mainEffect.isStop)
				{
					vecEffRe.removeElement(mainEffect);
				}
			}
			if (MainTabNew.Focus == MainTabNew.INFO)
			{
				if (listContent != null)
				{
					listContent.moveCamera();
				}
				if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
				{
					MainTabNew.timePaintInfo++;
					if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
					{
						setPaintInfo();
					}
				}
				if (GameCanvas.isTouch)
				{
					list.moveCamera();
					return;
				}
				MainScreen.cameraSub.UpdateCamera();
				if (yCon < MainScreen.cameraSub.yCam + 4)
				{
					yCon = MainScreen.cameraSub.yCam + 4;
				}
			}
			else
			{
				MainTabNew.timePaintInfo = 0;
			}
		}
		catch (Exception)
		{
		}
	}

	public override void updatekey()
	{
		base.updatekey();
		if (MainTabNew.Focus != MainTabNew.INFO)
		{
			return;
		}
		int num = idSelect;
		if (GameCanvas.keyMyHold[2] || GameCanvas.keyMyHold[8] || GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6])
		{
			TabScreenNew.timeRepaint = 10;
			if (idSelect == -1)
			{
				GameCanvas.clearKeyHold();
				idSelect = 0;
				return;
			}
		}
		if (listContent != null)
		{
			if (GameCanvas.keyMyHold[2])
			{
				if (listContent.cmtoX > 0)
				{
					listContent.cmtoX -= GameCanvas.hText;
				}
				else
				{
					listContent.cmtoX = 0;
				}
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				if (listContent.cmtoX < listContent.cmxLim)
				{
					listContent.cmtoX += GameCanvas.hText;
				}
				else
				{
					listContent.cmtoX = listContent.cmxLim;
				}
				GameCanvas.clearKeyHold(8);
			}
		}
		else if (GameCanvas.keyMyHold[2])
		{
			idSelect -= 2;
			if (idSelect < 0)
			{
				idSelect = 0;
			}
			TabScreenNew.timeRepaint = 10;
			GameCanvas.clearKeyHold(2);
		}
		else if (GameCanvas.keyMyHold[8])
		{
			TabScreenNew.timeRepaint = 10;
			idSelect += 2;
			if (idSelect > vecPaintSkill.size() - 1)
			{
				idSelect = vecPaintSkill.size() - 1;
			}
			GameCanvas.clearKeyHold(8);
		}
		if (GameCanvas.keyMyHold[4])
		{
			TabScreenNew.timeRepaint = 10;
			if (idSelect % 2 == 1 || idSelect == 0)
			{
				MainTabNew.Focus = MainTabNew.TAB;
				idSelect = 0;
			}
			else
			{
				idSelect--;
			}
			GameCanvas.clearKeyHold(4);
		}
		else if (GameCanvas.keyMyHold[6])
		{
			TabScreenNew.timeRepaint = 10;
			if (idSelect < vecPaintSkill.size() - 1)
			{
				idSelect++;
			}
			GameCanvas.clearKeyHold(6);
		}
		if (idSelect >= 0)
		{
			idSelect = resetSelect(idSelect, vecPaintSkill.size() - 1, isreset: false);
			Skill skill = null;
			if (idSelect != num && idSelect >= 0 && idSelect <= vecPaintSkill.size() - 1)
			{
				listContent = null;
				cmdListBig();
				MainTabNew.timePaintInfo = 0;
				MainScreen.cameraSub.moveCamera(0, XYpaint[idSelect][1] - yBegin - MainTabNew.hblack / 2);
				skill = (Skill)vecPaintSkill.elementAt(idSelect);
			}
			if (GameCanvas.isTouch || skill == null)
			{
				return;
			}
			if (center == null)
			{
				if (skill.lvMin <= GameScreen.player.Lv && (Player.mCurentLvSkill[skill.Id] != 0 || Player.diemKyNang > 0))
				{
					center = cmdMenu;
				}
			}
			else if (skill.lvMin > GameScreen.player.Lv || (Player.mCurentLvSkill[skill.Id] == 0 && Player.diemKyNang == 0))
			{
				center = null;
			}
		}
		else
		{
			idSelect = -1;
		}
	}

	public override void setPaintInfo()
	{
		if (idSelect >= Player.mKillPlayer.Length || idSelect == -1)
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		Skill skill = (Skill)vecPaintSkill.elementAt(idSelect);
		if (skill == null)
		{
			mContent = null;
			mPlusContent = null;
			listContent = null;
			return;
		}
		name = skill.name;
		if (Player.mCurentLvSkill[skill.Id] > 0)
		{
			name = name + " Lv" + (Player.mCurentLvSkill[skill.Id] + Player.mPlusLvSkill[skill.Id]);
		}
		mContent = skill.getContent();
		mPlusContent = null;
		listContent = null;
		if (MainTabNew.longwidth > 0)
		{
			int num = mContent.Length;
			if (num * GameCanvas.hText > MainTabNew.hMaxContent - hcmd)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - (MainTabNew.hMaxContent - hcmd));
			}
			else if (GameCanvas.isTouch)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent - hcmd, 0, 0, 0);
			}
			cmdListBig();
			return;
		}
		int num2 = XYpaint[idSelect][0];
		xCon = num2 - 45;
		if (xCon < 2)
		{
			xCon = 2;
		}
		else if (xCon + 92 > GameCanvas.w)
		{
			xCon = GameCanvas.w - 92;
		}
		wContent = 130;
		int num3 = XYpaint[idSelect][1] - MainScreen.cameraSub.yCam;
		if (num3 < yBegin + MainTabNew.hblack / 2)
		{
			yCon = num3 + sizeKill + 2 + MainScreen.cameraSub.yCam;
		}
		else
		{
			yCon = num3 + 1 - GameCanvas.hText * (mContent.Length + 1) - sizeKill / 2 + MainScreen.cameraSub.yCam;
		}
		if (yCon - MainScreen.cameraSub.yCam + (mContent.Length + 1) * GameCanvas.hText + 8 > GameCanvas.h - GameCanvas.hCommand)
		{
			yCon = GameCanvas.h - GameCanvas.hCommand - ((mContent.Length + 1) * GameCanvas.hText + 8 - MainScreen.cameraSub.yCam);
		}
		if (yCon < MainScreen.cameraSub.yCam)
		{
			yCon = MainScreen.cameraSub.yCam;
		}
		int num4 = mContent.Length;
		if (num4 * GameCanvas.hText > MainTabNew.hMaxContent)
		{
			listContent = new ListNew(xCon, yCon, wContent, MainTabNew.hMaxContent, 0, 0, num4 * GameCanvas.hText - MainTabNew.hMaxContent);
		}
	}

	public override void updatePointer()
	{
		bool flag = false;
		if (listContent != null && GameCanvas.isPoint(listContent.x, listContent.y, listContent.maxW, listContent.maxH))
		{
			listContent.update_Pos_UP_DOWN();
			flag = true;
		}
		if (GameCanvas.isTouch && !flag)
		{
			list.update_Pos_UP_DOWN();
			MainScreen.cameraSub.yCam = list.cmx;
		}
		if (GameCanvas.isPointSelect(xBegin, yBegin, MainTabNew.wblack, MainTabNew.hblack) && !flag)
		{
			for (int i = 0; i < XYpaint.Length; i++)
			{
				if (!GameCanvas.isPoint(XYpaint[i][0] - sizeKill / 2 - 2, XYpaint[i][1] - 2 - MainScreen.cameraSub.yCam, sizeKill + 4, sizeKill + 4))
				{
					continue;
				}
				if (i != idSelect)
				{
					listContent = null;
					idSelect = i;
					MainTabNew.timePaintInfo = 0;
				}
				else if (MainTabNew.longwidth == 0)
				{
					if (idSelect == -1)
					{
						return;
					}
					mVector mVector3 = new mVector("TabSkillsNew vecmenu2");
					mVector3 = doMenu();
					if (mVector3 != null && mVector3.size() > 0)
					{
						GameCanvas.menu2.startAt(mVector3, 2, T.kynang, isFocus: false, null);
					}
				}
				GameCanvas.isPointerSelect = false;
				cmdListBig();
				break;
			}
			if (MainTabNew.longwidth == 0)
			{
				MainTabNew.timePaintInfo = 0;
			}
			GameCanvas.isPointerSelect = false;
		}
		if (vecListCmd != null && MainTabNew.Focus == MainTabNew.INFO && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			for (int j = 0; j < vecListCmd.size(); j++)
			{
				iCommand iCommand2 = (iCommand)vecListCmd.elementAt(j);
				iCommand2.updatePointer();
			}
		}
		base.updatePointer();
	}

	public mVector doMenu()
	{
		mVector mVector3 = new mVector("TabSkillsNew menu2");
		Skill skill = null;
		skill = (Skill)vecPaintSkill.elementAt(idSelect);
		if (idSelect < 0 && idSelect >= vecPaintSkill.size())
		{
			return mVector3;
		}
		if (Player.diemKyNang > 0 && idSelect > 0 && Player.mCurentLvSkill[skill.Id] < 10 && GameScreen.player.Lv >= skill.lvMin)
		{
			mVector3.addElement(cmdSetPoint);
		}
		if (skill.typeSkill != 2 && Player.mCurentLvSkill[skill.Id] > 0)
		{
			if (mVector3.size() == 0 && MainTabNew.longwidth == 0)
			{
				cmdSetKey.perform();
				return null;
			}
			mVector3.addElement(cmdSetKey);
		}
		mVector3.addElement(cmdupskill);
		hcmd = (mVector3.size() + 1) / 2 * iCommand.hButtonCmd;
		return mVector3;
	}

	public static void saveSkill()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			for (int i = 0; i < Player.mhotkey.Length; i++)
			{
				for (int j = 0; j < Player.mhotkey[0].Length; j++)
				{
					HotKey hotKey = Player.mhotkey[i][j];
					dataOutputStream.writeShort(hotKey.id);
					dataOutputStream.writeByte(hotKey.type);
					dataOutputStream.writeByte(hotKey.typePotion);
				}
			}
			CRes.saveRMSName(0, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public void cmdListBig()
	{
		if (MainTabNew.longwidth > 0 && GameCanvas.isTouch && idSelect >= 0)
		{
			vecListCmd = doMenu();
			setPosCmd(vecListCmd);
		}
	}

	public static void loadSkill(sbyte[] bData)
	{
		if (bData == null)
		{
			for (int i = 0; i < Player.mhotkey[0].Length; i++)
			{
				Player.mhotkey[0][i] = new HotKey();
				Player.mhotkey[1][i] = new HotKey();
				Player.mhotkey[2][i] = new HotKey();
				if (i == 2)
				{
					Player.mhotkey[0][i].setHotKey(0, HotKey.SKILL, 0);
					Player.mhotkey[1][i].setHotKey(0, HotKey.SKILL, 0);
					Player.mhotkey[2][i].setHotKey(0, HotKey.SKILL, 0);
				}
				else
				{
					Player.mhotkey[0][i].setHotKey(0, HotKey.NULL, 0);
					Player.mhotkey[1][i].setHotKey(0, HotKey.NULL, 0);
					Player.mhotkey[2][i].setHotKey(0, HotKey.NULL, 0);
				}
			}
			if (GameScreen.player.Lv > 1)
			{
				MainItem.setAddHotKey(1, isStop: false);
				MainItem.setAddHotKey(0, isStop: false);
			}
			return;
		}
		DataInputStream dataInputStream = new DataInputStream(bData);
		try
		{
			for (int j = 0; j < Player.mhotkey.Length; j++)
			{
				for (int k = 0; k < Player.mhotkey[0].Length; k++)
				{
					Player.mhotkey[j][k] = new HotKey();
					Player.mhotkey[j][k].setHotKey(dataInputStream.readShort(), dataInputStream.readByte(), dataInputStream.readByte());
				}
			}
		}
		catch (Exception)
		{
			for (int l = 0; l < Player.mhotkey[0].Length; l++)
			{
				Player.mhotkey[0][l] = new HotKey();
				Player.mhotkey[1][l] = new HotKey();
				Player.mhotkey[2][l] = new HotKey();
				if (l == 2)
				{
					Player.mhotkey[0][l].setHotKey(0, HotKey.SKILL, 0);
					Player.mhotkey[1][l].setHotKey(0, HotKey.SKILL, 0);
					Player.mhotkey[2][l].setHotKey(0, HotKey.SKILL, 0);
				}
				else
				{
					Player.mhotkey[0][l].setHotKey(0, HotKey.NULL, 0);
					Player.mhotkey[1][l].setHotKey(0, HotKey.NULL, 0);
					Player.mhotkey[2][l].setHotKey(0, HotKey.NULL, 0);
				}
			}
			if (GameScreen.player.Lv > 1)
			{
				MainItem.setAddHotKey(1, isStop: false);
				MainItem.setAddHotKey(0, isStop: false);
			}
		}
	}
}
