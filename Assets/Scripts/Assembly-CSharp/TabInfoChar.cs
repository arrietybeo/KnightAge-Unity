using System;

public class TabInfoChar : MainTabNew
{
	private int w4;

	private int idSelect;

	private int hmax;

	private int xCamInfo;

	private int hitem = 20;

	private int plusTouch;

	private int xplus = 30;

	private iCommand cmdSetPoint;

	private iCommand cmdSendSetPoint;

	private iCommand cmdSendSetPointOne;

	private iCommand cmdHoiSendSetPoint;

	private int timePaintFocus;

	private InputDialog inputDialog;

	private ListNew list;

	private string strInfoSmall = string.Empty;

	public TabInfoChar(string name)
	{
		typeTab = MainTabNew.MY_INFO;
		nameTab = name;
		if (GameCanvas.isTouch)
		{
			hitem = 24;
		}
		if (GameCanvas.h <= 200)
		{
			hitem = 18;
		}
		plusTouch = hitem - 20;
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
		w4 = MainTabNew.wblack / 4;
		init();
		cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			cmdBack.caption = T.close;
		}
		cmdSetPoint = new iCommand(T.setPoint, 0, this);
		cmdHoiSendSetPoint = new iCommand(T.cong, 3, this);
		cmdSendSetPoint = new iCommand(T.cong, 1, this);
		cmdSendSetPointOne = new iCommand(T.cong, 2, this);
	}

	public override void init()
	{
		int y = yBegin + 4 + GameCanvas.hText + hitem * T.mKyNang.Length + 2;
		int num = MainTabNew.hblack - (GameCanvas.hText + 2 + hitem * T.mKyNang.Length);
		hmax = GameScreen.player.mInfoChar.Length * GameCanvas.hText - num + 5;
		list = new ListNew(xBegin, y, MainTabNew.wblack, num, 0, 0, hmax);
		if (MainTabNew.longwidth > 0)
		{
			list.x = MainTabNew.xlongwidth;
			list.y = MainTabNew.ylongwidth + MainTabNew.wOneItem;
			list.maxW = MainTabNew.longwidth;
			list.maxH = MainTabNew.hblack - MainTabNew.wOneItem;
			list.cmxLim = GameScreen.player.mInfoChar.Length * GameCanvas.hText - hSmall + MainTabNew.wOneItem + 10;
		}
		if (hmax < 0)
		{
			hmax = 0;
		}
		MainScreen.cameraSub.setAll(0, list.cmxLim, 0, 0);
		if (!GameCanvas.isTouch)
		{
			right = cmdBack;
			if (Player.diemTiemNang > 0)
			{
				center = cmdSetPoint;
			}
		}
		timePaintFocus = 0;
		base.init();
		if (!GameCanvas.isSmallScreen)
		{
			return;
		}
		for (int i = 0; i < GameScreen.player.mInfoChar.Length; i++)
		{
			MainInfoItem mainInfoItem = GameScreen.player.mInfoChar[i];
			if (mainInfoItem.id < 23 || mainInfoItem.id > 26)
			{
				string text = strInfoSmall;
				strInfoSmall = text + Item.nameInfoItem[mainInfoItem.id] + ": " + Item.getPercent(Item.isPercentInfoItem[mainInfoItem.id], mainInfoItem.value) + "\n";
			}
		}
	}

	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		idSelect = 0;
		base.backTab();
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			backTab();
			break;
		case 0:
			if (Player.diemTiemNang == 1)
			{
				GameCanvas.start_Left_Dialog(T.cong1diem + T.mKyNang[idSelect] + T.nhandc + infoShow(1), cmdSendSetPointOne);
			}
			else if (Player.diemTiemNang > 0)
			{
				inputDialog = new InputDialog();
				inputDialog.setinfo(T.nhapsodiem + T.mKyNang[idSelect] + T.nhohonhoacbang + Player.diemTiemNang + ") ", cmdHoiSendSetPoint, isNum: true, T.kynang);
				GameCanvas.currentDialog = inputDialog;
			}
			break;
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
			if (num2 > Player.diemTiemNang)
			{
				GameCanvas.start_Ok_Dialog(T.khongthecong + Player.diemTiemNang);
				break;
			}
			GlobalService.gI().Add_Base_Skill_Point(0, (sbyte)idSelect, num2);
			GameCanvas.end_Dialog();
			if (GameScreen.help.setStep_Next(7, 6))
			{
				GameScreen.help.Next++;
				GameScreen.help.setNext();
			}
			break;
		}
		case 2:
			GlobalService.gI().Add_Base_Skill_Point(0, (sbyte)idSelect, 1);
			if (GameScreen.help.setStep_Next(7, 6))
			{
				GameScreen.help.Next++;
			}
			GameCanvas.end_Dialog();
			break;
		case 3:
		{
			short num = 0;
			try
			{
				num = short.Parse(inputDialog.tfInput.getText());
			}
			catch (Exception)
			{
				num = 0;
			}
			if (num < 1)
			{
				return;
			}
			if (num > Player.diemTiemNang)
			{
				GameCanvas.start_Ok_Dialog(T.khongthecong + Player.diemTiemNang);
				break;
			}
			GameCanvas.start_Left_Dialog(num + T.diemcongvao + T.mKyNang[idSelect] + T.nhandc + infoShow(num), cmdSendSetPoint);
			break;
		}
		}
		base.commandPointer(index, subIndex);
	}

	public override void paint(mGraphics g)
	{
		int num = yBegin + 4;
		int num2 = xBegin + 4;
		mFont.tahoma_7_white.drawString(g, T.diemtiemnang + Player.diemTiemNang, num2, num, 0, mGraphics.isFalse);
		num += GameCanvas.hText + 2;
		for (int i = 0; i < T.mKyNang.Length; i++)
		{
			int num3 = xBegin + w4 - w4 / 4 + xplus;
			int num4 = num + hitem * i + plusTouch;
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, num3 + 2 - plusTouch / 2, num4 - 1 - plusTouch / 2, 24 + plusTouch, 13 + plusTouch, 4);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[12], 0, 0, 24 + plusTouch, 13 + plusTouch, 0, num3 + 2 - plusTouch / 2, num4 - 1 - plusTouch / 2, 0, mGraphics.isFalse);
			}
			mFont.tahoma_7b_white.drawString(g, T.mKyNang[i] + ":", num3 - plusTouch / 2 - xplus - w4 / 2 - (GameCanvas.isSmallScreen ? 4 : 0), num4, 0, mGraphics.isTrue);
			mFont.tahoma_7b_white.drawString(g, Player.mTiemnang[0][i] + string.Empty, num3 + 14, num4, 2, mGraphics.isTrue);
			if (Player.mTiemnang[1][i] > 0)
			{
				mFont.tahoma_7b_blue.drawString(g, "+" + Player.mTiemnang[1][i], num3 + 26 + plusTouch, num4, 0, mGraphics.isFalse);
			}
		}
		g.setColor(MainTabNew.color[3]);
		if (idSelect != 4 && (timePaintFocus > 0 || !GameCanvas.isTouch) && MainTabNew.Focus == MainTabNew.INFO)
		{
			int x = xBegin + w4 - w4 / 4 + xplus + 2 - plusTouch / 2;
			int y = num + hitem * idSelect + plusTouch / 2 - 1;
			g.drawRect(x, y, 24 + plusTouch, 13 + plusTouch, mGraphics.isFalse);
		}
		num += hitem * T.mKyNang.Length;
		if (MainTabNew.longwidth > 0)
		{
			GameCanvas.resetTrans(g);
			mFont.tahoma_7b_white.drawString(g, T.info, MainTabNew.xlongwidth + MainTabNew.longwidth / 2, MainTabNew.ylongwidth + MainTabNew.wOneItem / 4, 2, mGraphics.isFalse);
			g.setClip(MainTabNew.xlongwidth, MainTabNew.ylongwidth + MainTabNew.wOneItem + 4, MainTabNew.longwidth, hSmall - MainTabNew.wOneItem - 6);
			g.translate(MainTabNew.xlongwidth, MainTabNew.ylongwidth + MainTabNew.wOneItem);
			g.translate(0, -MainScreen.cameraSub.yCam);
			num2 = 4;
			num = 4;
		}
		else
		{
			if (!GameCanvas.isSmallScreen && idSelect == 4)
			{
				if (MainScreen.cameraSub.yCam > 0)
				{
					g.drawRegion(MainTabNew.imgTab[7], 0, 0, 13, 8, 0, xBegin + MainTabNew.wblack - 16, num - 2 + GameCanvas.gameTick % 3, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraSub.yCam < MainScreen.cameraSub.yLimit)
				{
					g.drawRegion(MainTabNew.imgTab[7], 0, 8, 13, 8, 0, xBegin + MainTabNew.wblack - 16, yBegin + MainTabNew.hblack - 10 - GameCanvas.gameTick % 3, 0, mGraphics.isFalse);
				}
			}
			if (!GameCanvas.isSmallScreen)
			{
				g.setClip(xBegin, num - 5, MainTabNew.wblack, yBegin + MainTabNew.hblack - num + 3);
				g.translate(0, -MainScreen.cameraSub.yCam);
			}
		}
		if (!GameCanvas.isSmallScreen)
		{
			for (int j = 0; j < GameScreen.player.mInfoChar.Length; j++)
			{
				MainInfoItem mainInfoItem = GameScreen.player.mInfoChar[j];
				if (mainInfoItem.id >= 23 && mainInfoItem.id <= 26)
				{
					continue;
				}
				mFont tahoma_7_white = mFont.tahoma_7_white;
				tahoma_7_white = MainTabNew.setTextColor(Item.colorInfoItem[mainInfoItem.id]);
				string st = Item.nameInfoItem[mainInfoItem.id] + ": " + Item.getPercent(Item.isPercentInfoItem[mainInfoItem.id], mainInfoItem.value);
				tahoma_7_white.drawString(g, st, num2, num, 0, mGraphics.isTrue);
				int num5 = 0;
				if (GameScreen.player.vecBuff != null)
				{
					for (int k = 0; k < GameScreen.player.vecBuff.size(); k++)
					{
						MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuff.elementAt(k);
						if (mainBuff.minfo == null)
						{
							continue;
						}
						for (int l = 0; l < mainBuff.minfo.Length; l++)
						{
							if (mainInfoItem.id == mainBuff.minfo[l].id)
							{
								num5 += mainBuff.minfo[l].value;
							}
						}
					}
				}
				if (num5 != 0)
				{
					string empty = string.Empty;
					mFont mFont2 = mFont.tahoma_7_green;
					if (num5 > 0)
					{
						empty = " +" + Item.getPercent(Item.isPercentInfoItem[mainInfoItem.id], num5);
					}
					else
					{
						empty = " " + Item.getPercent(Item.isPercentInfoItem[mainInfoItem.id], num5);
						mFont2 = mFont.tahoma_7_red;
					}
					int width = mFont.tahoma_7_white.getWidth(st);
					mFont2.drawString(g, " " + empty, num2 + width, num, 0, mGraphics.isTrue);
				}
				num += GameCanvas.hText;
			}
		}
		else
		{
			mFont.tahoma_7b_white.drawString(g, T.info, num2 + MainTabNew.wblack / 2, num - GameCanvas.hText / 2, 2, mGraphics.isTrue);
		}
	}

	public override void update()
	{
		if (GameCanvas.isTouch)
		{
			list.moveCamera();
			list.update_Pos_UP_DOWN();
			MainScreen.cameraSub.yCam = list.cmx;
		}
		else
		{
			MainScreen.cameraSub.UpdateCamera();
		}
		if (!GameCanvas.isTouch)
		{
			if (Player.diemTiemNang > 0 && idSelect != 4)
			{
				if (center == null)
				{
					center = cmdSetPoint;
				}
			}
			else if (center != null)
			{
				center = null;
			}
		}
		if (timePaintFocus > 0 && GameCanvas.currentDialog == null)
		{
			timePaintFocus--;
		}
	}

	public override void updatekey()
	{
		if (MainTabNew.Focus == MainTabNew.INFO)
		{
			if (idSelect == 4)
			{
				if (GameCanvas.isSmallScreen)
				{
					idSelect = 3;
					GameCanvas.start_Show_Dialog(strInfoSmall, T.info);
				}
				else if (GameCanvas.keyMyHold[2])
				{
					xCamInfo -= GameCanvas.hText;
					if (xCamInfo < 0)
					{
						idSelect = 3;
					}
					GameCanvas.clearKeyHold(2);
					MainScreen.cameraSub.moveCamera(0, xCamInfo);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					xCamInfo += GameCanvas.hText;
					if (xCamInfo > hmax)
					{
						xCamInfo = hmax;
					}
					GameCanvas.clearKeyHold(8);
					MainScreen.cameraSub.moveCamera(0, xCamInfo);
				}
			}
			else
			{
				if (GameCanvas.keyMyHold[2])
				{
					idSelect--;
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					idSelect++;
					GameCanvas.clearKeyHold(8);
				}
				else if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6])
				{
					MainTabNew.Focus = MainTabNew.TAB;
					GameCanvas.clearKeyHold(4);
					GameCanvas.clearKeyHold(6);
				}
				int num = T.mKyNang.Length - 1;
				if (hmax > 0)
				{
					num++;
				}
				idSelect = resetSelect(idSelect, num, isreset: false);
				xCamInfo = 0;
			}
		}
		base.updatekey();
	}

	public override void updatePointer()
	{
		if (GameCanvas.isPointerSelect)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = xBegin + w4 - w4 / 4 + xplus;
				int num2 = yBegin + GameCanvas.hText + 4 + hitem * i + plusTouch + 2;
				if (GameCanvas.isPoint(num - 2 - plusTouch / 2, num2 - 5 - plusTouch / 2, 32 + plusTouch, 21 + plusTouch))
				{
					idSelect = i;
					cmdSetPoint.perform();
					GameCanvas.isPointerSelect = false;
					timePaintFocus = 10;
					break;
				}
			}
		}
		base.updatePointer();
	}

	public string infoShow(int point)
	{
		string text = string.Empty;
		switch (idSelect)
		{
		case 0:
			text = text + "\n" + T.chimang + setpercent(2, point);
			text = text + "\n" + T.tatcasatthuong + setpercent(20, point);
			if (GameScreen.player.clazz == 0)
			{
				string text2 = text;
				text = text2 + "\n" + T.satthuongvatly + "+" + 4 * point;
				text2 = text;
				text = text2 + "\n" + T.satthuonglua + "+" + 4 * point;
			}
			else if (GameScreen.player.clazz == 1)
			{
				string text2 = text;
				text = text2 + "\n" + T.satthuongvatly + "+" + 4 * point;
				text2 = text;
				text = text2 + "\n" + T.satthuongdoc + "+" + 4 * point;
			}
			break;
		case 1:
			text = text + "\n" + T.nedon + setpercent(2, point);
			text = text + "\n" + T.phongthu + setpercent(10, point);
			if (GameScreen.player.clazz == 3)
			{
				string text2 = text;
				text = text2 + "\n" + T.phongthu + "+" + 22 * point;
			}
			else if (GameScreen.player.clazz == 1)
			{
				string text2 = text;
				text = text2 + "\n" + T.phongthu + "+" + 22 * point;
			}
			else
			{
				string text2 = text;
				text = text2 + "\n" + T.phongthu + "+" + 20 * point;
			}
			break;
		case 2:
			text = text + "\n" + T.phansatthuong + setpercent(2, point);
			if (GameScreen.player.clazz == 0)
			{
				string text2 = text;
				text = text2 + "\n" + T.mau + "+" + 320 * point;
			}
			else if (GameScreen.player.clazz == 2)
			{
				string text2 = text;
				text = text2 + "\n" + T.mau + "+" + 310 * point;
				text2 = text;
				text = text2 + "\n" + T.nangluong + "+" + 1 * point;
			}
			else
			{
				string text2 = text;
				text = text2 + "\n" + T.mau + "+" + 300 * point;
				if (GameScreen.player.clazz == 2)
				{
					text = text + "\n" + T.khangtatcast + setpercent(5, point);
				}
			}
			break;
		case 3:
			text = text + "\n" + T.xuyengiap + setpercent(2, point);
			if (GameScreen.player.clazz == 2)
			{
				string text2 = text;
				text = text2 + "\n" + T.nangluong + "+" + 11 * point;
				text2 = text;
				text = text2 + "\n" + T.satthuongvatly + "+" + 4 * point;
				text2 = text;
				text = text2 + "\n" + T.satthuongbang + "+" + 4 * point;
				text = text + "\n" + T.satthuongvatly + setpercent(18, point);
				text = text + "\n" + T.satthuongbang + setpercent(18, point);
			}
			else if (GameScreen.player.clazz == 3)
			{
				string text2 = text;
				text = text2 + "\n" + T.nangluong + "+" + 11 * point;
				text2 = text;
				text = text2 + "\n" + T.satthuongvatly + "+" + 4 * point;
				text2 = text;
				text = text2 + "\n" + T.satthuongdien + "+" + 4 * point;
				text = text + "\n" + T.satthuongvatly + setpercent(18, point);
				text = text + "\n" + T.satthuongdien + setpercent(18, point);
			}
			else
			{
				string text2 = text;
				text = text2 + "\n" + T.nangluong + "+" + 10 * point;
			}
			break;
		}
		return text;
	}

	public string setpercent(int value, int point)
	{
		string empty = string.Empty;
		int num = value * point;
		if (num % 100 == 0)
		{
			return "+" + num / 100 + "%";
		}
		if (num % 10 == 0)
		{
			return "+" + num / 100 + "." + num % 100 / 10 + "%";
		}
		return "+" + num / 100 + "." + num % 100 / 10 + string.Empty + num % 10 + "%";
	}
}
