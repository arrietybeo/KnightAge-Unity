using System;

public class Clan_Screen : MainScreen
{
	public const sbyte MY_CLAN = 0;

	public const sbyte VIEW_CLAN = 1;

	public static bool isUpdateThongTin = true;

	private int xbegin;

	private int ybegin;

	private int wScreen;

	private int hScreen;

	private int hTouch;

	private MainClan clanShow;

	private string[] mslogan;

	private string[] mnoiquy;

	private sbyte type;

	private iCommand cmdMenu;

	private iCommand cmdXinvao;

	private iCommand cmdXemList;

	private iCommand cmdGopXu;

	private iCommand cmdGopLuong;

	private iCommand cmdInfoMySeft;

	private iCommand cmdChucNang;

	private iCommand cmdChangeSlogan;

	private iCommand cmdChangeNoiQuy;

	private iCommand cmdPhongcap;

	private iCommand cmdClose;

	private iCommand cmdRoiClan;

	private iCommand cmdChatBang;

	private iCommand cmdThongBao;

	private iCommand cmdInvenClan;

	private InputDialog inputDialog;

	private ListNew list;

	private Camera cam = new Camera();

	public sbyte[] frameicon = new sbyte[4] { 0, 1, 2, 1 };

	public sbyte frameClan;

	public Clan_Screen()
	{
		hTouch = 0;
		if (GameCanvas.isTouch)
		{
			hTouch = iCommand.hButtonCmd;
		}
		init(180);
	}

	public override void Show(MainScreen screen)
	{
		base.Show(screen);
		GameCanvas.end_Dialog();
	}

	public void setInfoClan(MainClan clan, sbyte type)
	{
		this.type = type;
		clanShow = clan;
		if (clanShow == null)
		{
			lastScreen.Show(lastScreen.lastScreen);
			return;
		}
		updateShow();
		cmdClose = new iCommand(T.close, -1, this);
		cmdXemList = new iCommand(T.xemdanhsach, 2, this);
		if (type == 1)
		{
			cmdXemList.caption = T.thanhvien;
			left = cmdXemList;
		}
		else if (type == 0)
		{
			cmdMenu = new iCommand(T.menu, 0, this);
			cmdGopXu = new iCommand(T.gop + T.coin, 3, this);
			cmdGopLuong = new iCommand(T.gop + T.gem, 4, this);
			cmdInfoMySeft = new iCommand(T.info + " " + T.banthan, 6, this);
			cmdChucNang = new iCommand(T.chucnang, 7, this);
			cmdChangeSlogan = new iCommand(T.doiSlogan, 8, this);
			cmdChangeNoiQuy = new iCommand(T.doiNoiquy, 9, this);
			cmdPhongcap = new iCommand(T.phonghacap, 2, this);
			cmdRoiClan = new iCommand(T.roiclan, 11, this);
			cmdChatBang = new iCommand(T.chattoanbang, 12, this);
			cmdThongBao = new iCommand(T.doithongbao, 13, this);
			cmdInvenClan = new iCommand(T.tabhanhtrang + " " + T.clan, 14, this);
			left = cmdMenu;
		}
		right = cmdClose;
		if (GameCanvas.isTouch)
		{
			left.setPos(xbegin + wScreen / 2, ybegin + wScreen - iCommand.hButtonCmd / 2 - 4, PaintInfoGameScreen.fraButton, left.caption);
			right.setPos(xbegin + wScreen - 12, ybegin + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			lastScreen.Show(lastScreen.lastScreen);
			break;
		case 0:
		{
			mVector mVector3 = new mVector("Clan_Screen menu");
			if (type == 1)
			{
				mVector3.addElement(cmdXemList);
				mVector3.addElement(cmdXinvao);
			}
			else if (type == 0)
			{
				if (GameScreen.player.myClan == null || GameScreen.player.myClan.isRemove)
				{
					lastScreen.Show(lastScreen.lastScreen);
					GameCanvas.start_Ok_Dialog(T.bankhongconclan);
					break;
				}
				mVector3.addElement(cmdXemList);
				mVector3.addElement(cmdInfoMySeft);
				mVector3.addElement(cmdChatBang);
				if (GameScreen.player.myClan.getChucNang())
				{
					mVector3.addElement(cmdChucNang);
					mVector3.addElement(cmdInvenClan);
				}
				mVector3.addElement(cmdGopXu);
				mVector3.addElement(cmdGopLuong);
				if (GameScreen.player.myClan.chucvu != sbyte.MaxValue)
				{
					mVector3.addElement(cmdRoiClan);
				}
			}
			GameCanvas.menu2.startAt(mVector3, 2, T.chucnang, isFocus: false, null);
			break;
		}
		case 1:
			GlobalService.gI().ChucNang_Clan(0, clanShow.IdClan);
			GameCanvas.start_Ok_Dialog(T.dagoidangky);
			break;
		case 2:
			GlobalService.gI().ChucNang_Clan(13, clanShow.IdClan);
			GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			break;
		case 3:
			inputDialog = new InputDialog();
			inputDialog.setinfo(T.nhapsoxumuongop, new iCommand(T.gop, 5, 6, this), isNum: true, T.gop + T.coin);
			GameCanvas.currentDialog = inputDialog;
			break;
		case 4:
			inputDialog = new InputDialog();
			inputDialog.setinfo(T.nhapsoluongmuongop, new iCommand(T.gop, 5, 7, this), isNum: true, T.gop + T.gem);
			GameCanvas.currentDialog = inputDialog;
			break;
		case 5:
		{
			int num = 0;
			try
			{
				num = int.Parse(inputDialog.tfInput.getText());
			}
			catch (Exception)
			{
				break;
			}
			if (num > 0)
			{
				GlobalService.gI().gop_Xu_Luong_Clan((sbyte)subIndex, num);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			break;
		}
		case 6:
			GlobalService.gI().info_Mem_Clan(14, GameScreen.player.name);
			GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			break;
		case 7:
			if (GameScreen.player.myClan == null || GameScreen.player.myClan.isRemove)
			{
				lastScreen.Show(lastScreen.lastScreen);
				GameCanvas.start_Ok_Dialog(T.bankhongconclan);
			}
			else if (GameScreen.player.myClan.chucvu == sbyte.MaxValue)
			{
				mVector mVector4 = new mVector("Clan_Screen menu2");
				mVector4.addElement(cmdPhongcap);
				mVector4.addElement(cmdChangeSlogan);
				mVector4.addElement(cmdChangeNoiQuy);
				mVector4.addElement(cmdThongBao);
				GameCanvas.menu2.startAt(mVector4, 2, T.chucnang, isFocus: false, null);
			}
			else
			{
				cmdPhongcap.perform();
			}
			break;
		case 8:
			inputDialog = new InputDialog();
			inputDialog.setinfo(T.nhapthongtindoi, new iCommand(T.change, 10, 16, this), isNum: false, T.change + " " + T.slogan);
			GameCanvas.currentDialog = inputDialog;
			break;
		case 9:
			inputDialog = new InputDialog();
			inputDialog.setinfo(T.nhapthongtindoi, new iCommand(T.change, 10, 17, this), isNum: false, T.change + " " + T.noiquy);
			GameCanvas.currentDialog = inputDialog;
			break;
		case 10:
		{
			string text = inputDialog.tfInput.getText();
			if (text != null)
			{
				GlobalService.gI().Change_Slo_NoiQuy_Clan((sbyte)subIndex, text);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			break;
		}
		case 11:
			GameCanvas.start_Left_Dialog(T.hoiroiClan, new iCommand(T.roiclan, 15, this));
			break;
		case 12:
			GameCanvas.msgchat.addNewChat(T.tabBangHoi, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, isFocus: true);
			GameCanvas.start_Chat_Dialog();
			break;
		case 13:
			inputDialog = new InputDialog();
			inputDialog.setinfo(T.nhapthongtindoi, new iCommand(T.change, 10, 2, this), isNum: false, T.change + " " + T.thongbao);
			GameCanvas.currentDialog = inputDialog;
			break;
		case 14:
			GlobalService.gI().InvenClan(21);
			GameCanvas.start_Ok_Dialog(T.pleaseWait);
			break;
		case 15:
			GlobalService.gI().Delete_Mem_Clan(18, GameScreen.player.name);
			lastScreen.Show(lastScreen.lastScreen);
			break;
		}
	}

	public void init(int w)
	{
		wScreen = w;
		hScreen = w;
		if (hScreen > GameCanvas.h - 20)
		{
			hScreen = GameCanvas.h - 20;
		}
		if (wScreen > GameCanvas.w - 20)
		{
			wScreen = GameCanvas.w - 20;
		}
		xbegin = GameCanvas.hw - wScreen / 2;
		ybegin = GameCanvas.hh - hScreen / 2;
	}

	public override void paint(mGraphics g)
	{
		if (lastScreen != null)
		{
			lastScreen.paint(g);
		}
		if (GameCanvas.currentScreen != this)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		int num = ybegin;
		int num2 = xbegin;
		paintFormList(g, num2, num, wScreen, hScreen, T.clan);
		num2 += 5;
		num += GameCanvas.hCommand + 2;
		g.setClip(xbegin, num, wScreen, hScreen - GameCanvas.hCommand - hTouch - 5);
		g.translate(0, -cam.yCam);
		AvMain.Font3dWhite(g, clanShow.name, xbegin + wScreen / 2, num + 4, 2);
		num += GameCanvas.hText + GameCanvas.hText / 2;
		mFont.tahoma_7b_white.drawString(g, T.bieutuong, num2, num, 0, mGraphics.isTrue);
		MainImage imageIconClan = ObjectData.getImageIconClan(clanShow.IdIcon);
		if (imageIconClan.img != null)
		{
			if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
			{
				if (GameCanvas.gameTick % 6 == 0)
				{
					int num3 = frameicon.Length;
					if (num3 == 0)
					{
						num3 = 1;
					}
					clanShow.frameClan = (sbyte)((clanShow.frameClan + 1) % num3);
				}
				g.drawRegion(imageIconClan.img, 0, frameicon[clanShow.frameClan] * 18, 18, 18, 0, num2 + 70, num + 6, 3, mGraphics.isTrue);
			}
			else
			{
				g.drawImage(imageIconClan.img, num2 + 70, num + 6, 3, mGraphics.isTrue);
			}
		}
		mFont.tahoma_7b_white.drawString(g, clanShow.shortName, num2 + 78, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		mFont.tahoma_7b_white.drawString(g, T.level + clanShow.Lv + " +" + clanShow.ptLv / 10 + "," + clanShow.ptLv % 10 + "%    " + T.hang + ": " + clanShow.hang, num2, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		mFont.tahoma_7b_white.drawString(g, T.soluong + clanShow.numMem + "/" + clanShow.maxMem, num2, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		mFont.tahoma_7b_white.drawString(g, T.mChucVuClan[0] + ": " + clanShow.nameThuLinh, num2, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		for (int i = 0; i < mslogan.Length; i++)
		{
			mFont.tahoma_7_white.drawString(g, mslogan[i], num2, num, 0, mGraphics.isTrue);
			num += GameCanvas.hText;
		}
		mFont.tahoma_7b_white.drawString(g, T.quyxu + ": " + MainItem.getDotNumber(clanShow.coin), num2, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		mFont.tahoma_7b_white.drawString(g, T.quyngoc + ": " + MainItem.getDotNumber(clanShow.gold), num2, num, 0, mGraphics.isTrue);
		if (clanShow.mthanhtich != null)
		{
			for (int j = 0; j < clanShow.mthanhtich.Length; j++)
			{
				num += 20;
				imageIconClan = ObjectData.getImageIconArCheClan(clanShow.mthanhtich[j].id);
				if (imageIconClan.img != null)
				{
					g.drawImage(imageIconClan.img, num2 + 9, num + 5, 3, mGraphics.isTrue);
				}
				mFont.tahoma_7_yellow.drawString(g, clanShow.mthanhtich[j].num + string.Empty, num2 + 16, num + 4, 2, mGraphics.isTrue);
				mFont.tahoma_7b_white.drawString(g, ": " + clanShow.mthanhtich[j].nameThanhTich, num2 + 22, num, 0, mGraphics.isTrue);
			}
			num += 5;
		}
		num += GameCanvas.hText;
		for (int k = 0; k < mnoiquy.Length; k++)
		{
			mFont.tahoma_7_white.drawString(g, mnoiquy[k], num2, num, 0, mGraphics.isTrue);
			num += GameCanvas.hText;
		}
		if (GameCanvas.currentScreen == this && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null)
		{
			base.paint(g);
		}
	}

	public void updateShow()
	{
		if (clanShow.slogan.Length > 100)
		{
			init(220);
		}
		else if (clanShow.noiquy.Length > 100)
		{
			init(220);
		}
		mslogan = mFont.tahoma_7_white.splitFontArray(clanShow.slogan, wScreen - 10);
		mnoiquy = mFont.tahoma_7_white.splitFontArray(clanShow.noiquy, wScreen - 10);
		int num = GameCanvas.hCommand + 2 + (6 + mnoiquy.Length + mslogan.Length) * GameCanvas.hText;
		if (clanShow.mthanhtich != null)
		{
			num += 20 * clanShow.mthanhtich.Length + 5;
		}
		if (num > hScreen - GameCanvas.hCommand - hTouch - 5)
		{
			list = new ListNew(xbegin, ybegin, wScreen, hScreen, 0, 0, num - (hScreen - GameCanvas.hCommand - hTouch - 5));
		}
		else
		{
			list = new ListNew(xbegin, ybegin, wScreen, hScreen, 0, 0, 0);
		}
		cam.setAll(0, list.cmxLim, 0, 0);
		isUpdateThongTin = false;
	}

	public override void update()
	{
		if (lastScreen != null)
		{
			lastScreen.update();
		}
		if (isUpdateThongTin)
		{
			updateShow();
			isUpdateThongTin = false;
		}
		if (GameCanvas.isTouch)
		{
			list.moveCamera();
			cam.yCam = list.cmx;
		}
		else
		{
			cam.UpdateCamera();
		}
		base.update();
	}

	public override void updatekey()
	{
		if (cam.yLimit > 0)
		{
			if (GameCanvas.keyMyHold[2])
			{
				if (cam.yTo > 0)
				{
					cam.yTo -= GameCanvas.hText;
				}
				if (cam.yTo < 0)
				{
					cam.yTo = 0;
				}
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				if (cam.yTo < cam.yLimit)
				{
					cam.yTo += GameCanvas.hText;
				}
				if (cam.yTo > cam.yLimit)
				{
					cam.yTo = cam.yLimit;
				}
				GameCanvas.clearKeyHold(2);
			}
		}
		base.updatekey();
	}

	public override void updatePointer()
	{
		if (GameCanvas.isTouch)
		{
			list.update_Pos_UP_DOWN();
		}
		base.updatePointer();
	}
}
