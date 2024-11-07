public class NPC : MainObject
{
	public short idImage;

	public short wBlock;

	public short hBlock;

	private int nFrame;

	private int wAvatar;

	private int hAvatar;

	private int indexSound = -1;

	private int timePlaySound = -1;

	public NPC(string name, string namegt, sbyte IDItem, sbyte IDImage, short x, short y, sbyte wBlock, sbyte hBlock, sbyte nFrame)
	{
		base.name = name;
		nameGiaotiep = namegt;
		ID = IDItem;
		idImage = IDImage;
		base.x = x + 12;
		base.y = y;
		this.wBlock = wBlock;
		this.hBlock = hBlock;
		this.nFrame = nFrame;
		hp = 100;
		maxHp = 100;
		ysai = 0;
		GameCanvas.loadmap.setBlockNPC(x, y - 24, wBlock, hBlock);
		setPlaySound();
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

	public override void paint(mGraphics g)
	{
		if (idImage != -1)
		{
			MainImage imagePartNPC = ObjectData.getImagePartNPC(idImage);
			if (imagePartNPC.img != null)
			{
				if (wOne == 0)
				{
					hOne = mImage.getImageHeight(imagePartNPC.img.image) / nFrame;
					wOne = mImage.getImageWidth(imagePartNPC.img.image);
				}
				g.drawRegion(imagePartNPC.img, 0, GameCanvas.gameTick / 7 % nFrame * hOne, wOne, hOne, 0, x, y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
			}
		}
		if (GameScreen.ObjFocus == null || (GameScreen.ObjFocus != null && this != GameScreen.ObjFocus) || PaintInfoGameScreen.isLevelPoint)
		{
			paintName(g, 0);
		}
	}

	public override void update()
	{
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
		if (isMonPhoBangDie && timeFreeMove < 70)
		{
			timeFreeMove++;
			if (CRes.random(3) == 1)
			{
				if (CRes.random(2) == 1)
				{
					LoadMap.timeVibrateScreen = 103;
				}
				int num = CRes.random(1, 3);
				for (int i = 0; i < num; i++)
				{
					int num2 = CRes.random_Am_0(25);
					int num3 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, x + num2, y + num3 - hOne / 2);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, x + num2, y + num3 - hOne / 2);
					}
				}
			}
			if (timeFreeMove >= 70)
			{
				for (int j = 0; j < 6; j++)
				{
					int num4 = CRes.random_Am_0(25);
					int num5 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, x + num4, y + num5 - hOne / 2);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, x + num4, y + num5 - hOne / 2);
					}
				}
				GameScreen.addEffectKill(81, x, y - 20, 200, 0, 0);
				isRemove = true;
				isMonPhoBangDie = false;
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

	public override bool isNPC()
	{
		return true;
	}

	public override void GiaoTiep()
	{
		MainObject.resetDirection(GameScreen.player, this);
		if (isPerson == 0)
		{
			GlobalService.gI().getlist_from_npc((sbyte)ID);
			return;
		}
		mVector mVector3 = new mVector("NPC menu");
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
		mVector mVector3 = new mVector("NPC menu2");
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
}
