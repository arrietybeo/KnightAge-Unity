public class NPCserver : MainObject
{
	public short idImage;

	public short wBlock;

	public short hBlock;

	public short xBlock;

	public short yBlock;

	private int nFrame;

	private int wAvatar;

	private int hAvatar;

	private int indexSound = -1;

	private int timePlaySound = -1;

	private new int dx;

	private new int dy;

	private Other_Players p;

	private mImage imgSub;

	private FrameImage imgSubFrame;

	private sbyte idnotFocus = sbyte.MaxValue;

	private sbyte[] frameArray;

	private new sbyte f;

	public NPCserver(sbyte idNPC, short xNPC, short yNPC, sbyte dxNPC, sbyte dyNPC, sbyte nFrameNPC, string nameGiaoTiep, string nameNPC, short xBlockNPC, short yBlockNPC, sbyte wBlockNPC, sbyte hBlockNPC, sbyte[] wearing, sbyte[] ImageData, sbyte[] frameArray)
	{
		idImage = idNPC;
		x = xNPC;
		y = yNPC;
		dx = dxNPC;
		dy = dyNPC;
		nFrame = nFrameNPC;
		name = nameNPC;
		nameGiaotiep = nameGiaoTiep;
		wBlock = wBlockNPC;
		hBlock = hBlockNPC;
		xBlock = xBlockNPC;
		yBlock = yBlockNPC;
		isStop = false;
		isRemove = false;
		string path = "npc_server" + idImage;
		imgSub = mImage.createImage(ImageData, 0, ImageData.Length, path);
		imgSubFrame = new FrameImage(imgSub, mImage.getImageWidth(imgSub.image), mImage.getImageHeight(imgSub.image) / nFrame);
		this.frameArray = frameArray;
		GameCanvas.loadmap.setBlockNPC_Server(xBlock - 12, yBlock, wBlock, hBlock);
		if (idImage != idnotFocus)
		{
			p = new Other_Players(idImage, 0, name, x, y);
			p.clazz = 1;
			p.Direction = 0;
			p.setInfo(wearing[12], wearing[13], wearing[14]);
			p.setWearingEquip(wearing);
			MiniMap.addNPCMini(new NPCMini(idNPC, x, y));
			setPlaySound();
			p.x = x + dx;
			p.y = y + dy;
			p.toX = p.x;
			p.toY = p.y;
			hOne = mImage.getImageHeight(imgSub.image) + p.hOne - 10;
			hp = 100;
			maxHp = 100;
			Lv = 1;
		}
	}

	public override void setInfo(sbyte idNPC, short xNPC, short yNPC, sbyte dxNPC, sbyte dyNPC, sbyte nFrameNPC, string nameGiaoTiep, string nameNPC, short xBlockNPC, short yBlockNPC, sbyte wBlockNPC, sbyte hBlockNPC, sbyte[] wearing, sbyte[] ImageData, sbyte[] frameArray)
	{
		p = null;
		imgSub = null;
		imgSubFrame = null;
		idImage = idNPC;
		x = xNPC;
		y = yNPC;
		dx = dxNPC;
		dy = dyNPC;
		nFrame = nFrameNPC;
		name = nameNPC;
		nameGiaotiep = nameGiaoTiep;
		wBlock = wBlockNPC;
		hBlock = hBlockNPC;
		xBlock = xBlockNPC;
		yBlock = yBlockNPC;
		isStop = false;
		isRemove = false;
		string path = "npc_server" + idImage;
		imgSub = mImage.createImage(ImageData, 0, ImageData.Length, path);
		imgSubFrame = new FrameImage(imgSub, mImage.getImageWidth(imgSub.image), mImage.getImageHeight(imgSub.image) / nFrame);
		this.frameArray = frameArray;
		GameCanvas.loadmap.setBlockNPC_Server(xBlock - 12, yBlock, wBlock, hBlock);
		if (idImage != idnotFocus)
		{
			p = new Other_Players(idImage, 0, name, x, y);
			p.clazz = 1;
			p.Direction = 0;
			p.setInfo(wearing[12], wearing[13], wearing[14]);
			p.setWearingEquip(wearing);
			MiniMap.addNPCMini(new NPCMini(idNPC, x, y));
			setPlaySound();
			p.x = x + dx;
			p.y = y + dy;
			p.toX = p.x;
			p.toY = p.y;
			hOne = mImage.getImageHeight(imgSub.image) + p.hOne - 10;
		}
	}

	public override void paint(mGraphics g)
	{
		if (imgSubFrame != null)
		{
			imgSubFrame.drawFrame(frameArray[f], x, y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
		if (p != null)
		{
			p.paint(g);
			paintName(g, 2);
		}
	}

	public override void paintName(mGraphics g, int id)
	{
		mFont tahoma_7_white = mFont.tahoma_7_white;
		tahoma_7_white = MainTabNew.setTextColor(id);
		tahoma_7_white.drawString(g, nameGiaotiep, p.x, p.y - 70, 2, mGraphics.isFalse);
	}

	public override void update()
	{
		f++;
		if (f > frameArray.Length - 1)
		{
			f = 0;
		}
		if (strChatPopup != null)
		{
			addChat(strChatPopup, isStop: true);
			strChatPopup = null;
		}
		if (chat != null)
		{
			chat.updatePos(x, y - hOne - 30);
			if (chat.setOff())
			{
				chat = null;
			}
		}
		if (indexSound < 0 || GameCanvas.gameTick % timePlaySound != 0 || !MainObject.isInScreen(this))
		{
			return;
		}
		if (indexSound == 44)
		{
			if (getCountPlayerINearMe() >= 5)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
			}
		}
		else
		{
			mSound.playSound(indexSound, mSound.volumeSound);
		}
	}

	public override void paintAvatarFocus(mGraphics g, int x, int y)
	{
		MainImage imagePartNPC = ObjectData.getImagePartNPC(idImage);
		if (imagePartNPC.img == null)
		{
			return;
		}
		if (wAvatar <= 0)
		{
			if (wOne < 0)
			{
				hOne = mImage.getImageHeight(imagePartNPC.img.image) / nFrame;
				wOne = mImage.getImageWidth(imagePartNPC.img.image);
			}
			wAvatar = wOne;
			hAvatar = hOne;
			if (wAvatar > 26)
			{
				wAvatar = 26;
			}
			if (hAvatar > 26)
			{
				hAvatar = 26;
			}
		}
		g.drawRegion(imagePartNPC.img, wOne / 2 - wAvatar / 2, 0, wAvatar, hAvatar, 0, x, y, 3, mGraphics.isFalse);
	}

	public override void paintBigAvatar(mGraphics g, int x, int y)
	{
		MainImage imagePartNPC = ObjectData.getImagePartNPC((short)IdBigAvatar);
		if (imagePartNPC.img != null)
		{
			g.drawImage(imagePartNPC.img, x, y, mGraphics.BOTTOM | mGraphics.RIGHT, mGraphics.isFalse);
		}
	}

	public override bool canFocus()
	{
		return idImage != idnotFocus;
	}

	public override bool isNPC()
	{
		return idImage != idnotFocus;
	}

	public override void paintNameFocus(mGraphics g)
	{
	}

	public override bool isNPC_server()
	{
		return true;
	}

	public override int getIDnpc()
	{
		return idImage;
	}

	public override void GiaoTiep()
	{
		if (!isNPC())
		{
			return;
		}
		MainObject.resetDirection(GameScreen.player, this);
		if (isPerson == 0)
		{
			GlobalService.gI().getlist_from_npc((sbyte)getIDnpc());
			return;
		}
		mVector mVector3 = new mVector("NPCserver menu");
		if (nameGiaotiep.Length > 0)
		{
			iCommand o = new iCommand(nameGiaotiep, 4, this);
			mVector3.addElement(o);
		}
		if (checkNV())
		{
			iCommand o2 = new iCommand(T.quest, 5, this);
			mVector3.addElement(o2);
		}
		GameCanvas.menu2.startAt_NPC(mVector3, infoObject, ID, 2, isQuest: false, 0);
		mSound.playSound(39, mSound.volumeSound);
	}

	public bool checkNV()
	{
		for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
			if (mainQuest.idNPC_From == ID)
			{
				return true;
			}
		}
		for (int j = 0; j < MainQuest.vecQuestFinish.size(); j++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(j);
			if (mainQuest2.idNPC_To == ID)
			{
				return true;
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
		{
			MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
			if (mainQuest3.idNPC_To == ID)
			{
				return true;
			}
		}
		for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
		{
			MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
			if (mainQuest4.idNPC_To == ID)
			{
				return true;
			}
		}
		return false;
	}

	public void NhiemVu()
	{
		mVector mVector3 = new mVector("NPCserver menu2");
		for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
			if (mainQuest.idNPC_From == ID)
			{
				iCommand iCommand2 = new iCommand(mainQuest.name, 0, i, this);
				iCommand2.setFraCaption(AvMain.fraQuest, 1, 1);
				mVector3.addElement(iCommand2);
			}
		}
		for (int j = 0; j < MainQuest.vecQuestFinish.size(); j++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(j);
			if (mainQuest2.idNPC_To == ID)
			{
				iCommand iCommand3 = new iCommand(mainQuest2.name, 1, j, this);
				iCommand3.setFraCaption(AvMain.fraQuest, 1, 3);
				mVector3.addElement(iCommand3);
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
		{
			MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
			if (mainQuest3.idNPC_To == ID)
			{
				iCommand iCommand4 = new iCommand(mainQuest3.name, 2, k, this);
				iCommand4.setFraCaption(AvMain.fraQuest, 1, 2);
				mVector3.addElement(iCommand4);
			}
		}
		for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
		{
			MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
			if (mainQuest4.idNPC_To == ID)
			{
				iCommand iCommand5 = new iCommand(mainQuest4.name, 3, l, this);
				iCommand5.setFraCaption(AvMain.fraQuest, 1, 2);
				mVector3.addElement(iCommand5);
			}
		}
		if (mVector3.size() == 0)
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			GameCanvas.menu2.doCloseMenu();
		}
		else
		{
			GameCanvas.menu2.doCloseMenu();
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			GameCanvas.menu2.startAt(mVector3, 2, T.quest, isFocus: false, null);
		}
	}

	public void setPlaySound()
	{
		switch (ID)
		{
		case -21:
		case -5:
			indexSound = 43;
			timePlaySound = 150;
			break;
		case -36:
		case -20:
		case -3:
			indexSound = 44;
			timePlaySound = 150;
			break;
		}
	}

	public int getCountPlayerINearMe()
	{
		int num = 0;
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject.typeObject == 0 && MainObject.getDistance(x, y, mainObject.x, mainObject.y) <= 120)
			{
				num++;
			}
		}
		return num;
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestList.size())
			{
				MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestList.elementAt(subIndex);
				mainQuest3.beginQuest();
			}
			break;
		case 1:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestFinish.size())
			{
				MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(subIndex);
				mainQuest2.beginQuest();
			}
			break;
		case 2:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestDoing_Main.size())
			{
				MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(subIndex);
				mainQuest4.show_Info_Quest_Doing();
			}
			break;
		case 3:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestDoing_Sub.size())
			{
				MainQuest mainQuest = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(subIndex);
				mainQuest.show_Info_Quest_Doing();
			}
			break;
		case 4:
			GlobalService.gI().getlist_from_npc((sbyte)ID);
			break;
		case 5:
			NhiemVu();
			break;
		}
		base.commandPointer(index, subIndex);
	}
}
