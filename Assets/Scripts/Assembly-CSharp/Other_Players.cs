public class Other_Players : MainObject
{
	private PopupChat nameStore;

	private sbyte[] vmove = new sbyte[2] { -1, 1 };

	public Other_Players(int ID, sbyte type, string name, int x, int y)
		: base(ID, type, name, x, y)
	{
		vMax = 6;
		hOne = 40;
		wOne = 30;
		hp = 0;
		maxHp = 0;
		mp = 0;
		maxMp = 0;
		xsai = 1;
		ysai = 2;
		PlashNow = new SplashSkill();
		ListKillNow = new ListSkill();
		countCharStand = 0;
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

	public override void paintName(mGraphics g, int id)
	{
		if (GameScreen.infoGame.isMapThachdau())
		{
			return;
		}
		sbyte b = GameScreen.player.typePk;
		bool flag = true;
		if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap) && typePk == b)
		{
			flag = false;
		}
		string st = name;
		mFont tahoma_7_white = mFont.tahoma_7_white;
		tahoma_7_white = MainTabNew.setTextColor(id);
		bool flag2 = true;
		int num = 0;
		if (typeSpec == 1)
		{
			if (typePk > 0)
			{
				flag2 = false;
			}
			num = 5;
		}
		if (idName != -1)
		{
			flag2 = false;
		}
		int num2 = 18;
		if (PaintInfoGameScreen.isLevelPoint)
		{
			num2 = 12;
		}
		if (typeMonster == 7)
		{
			num2 += 8;
		}
		if (isObject && PaintInfoGameScreen.isLevelPoint)
		{
			num2 += 6;
		}
		if (flag2 && !Namearena)
		{
			tahoma_7_white.drawString(g, st, x, y - ysai - dy + dyWater - (isDongBang ? 5 : 0) - hOne - num2 - dyMount - yjum, 2, mGraphics.isFalse);
		}
		if (typeObject == 0 && typeSpec == 1 && flag2 && !iscuop)
		{
			num2 += 10;
			tahoma_7_white.drawString(g, T.nhanban, x, y - ysai - dy + dyWater - (isDongBang ? 5 : 0) - hOne - num2 - dyMount - yjum, 2, mGraphics.isFalse);
		}
		if (typeObject == 2 && chat == null)
		{
			AvMain.fraQuest.drawFrame(typeNPC, x - 6, y - ysai - dy + dyWater - hOne - num2 - 18 - 4 + GameCanvas.gameTick / 2 % 4, 0, g);
		}
		int num3 = 0;
		if ((Player.party != null && isParty) || isShowHP || typeMonster == 7)
		{
			int num4 = 44;
			if (typeObject == 2 || typeMonster == 7)
			{
				num4 = hOne + 5;
			}
			g.setColor(8062494);
			g.fillRect(x - 20, y - ysai - dy + dyWater - num4 - num2 - dyMount - yjum, 40, 3, mGraphics.isFalse);
			g.setColor(16197705);
			g.fillRect(x - 20, y - ysai - dy + dyWater - num4 - num2 - dyMount - yjum, 40 * hp / maxHp, 3, mGraphics.isFalse);
			num3 += 5;
		}
		if (myClan != null && typeSpec != 1 && !Namearena)
		{
			paintIconClan(g, x - 1, y - ysai - dy + dyWater - hOne - num2 - 8 - num3 - dyMount - yjum, 2);
			num3 += 16;
		}
		if (typePk >= 0 && typeObject == 0 && flag && !isPkVantieu())
		{
			num3 += 59;
			AvMain.fraPk.drawFrame(typePk * 3 + GameCanvas.gameTick / 3 % 3, x, y - dy + dyWater - ysai - num3 + 18 - num2 + num - dyMount - yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	public override void paint(mGraphics g)
	{
		int num = 0;
		if (typeObject == 0 && GameScreen.isHideOderPlayer)
		{
			painthidePlayer(g, num);
			paintNameStore(g, x, y);
			return;
		}
		if (typeObject == 2)
		{
			if (imageId == -1)
			{
				paintPlayer(g, num);
			}
			else
			{
				paintObject(g, num);
			}
		}
		else
		{
			paintPlayer(g, num);
		}
		paintEffectCharWearing(g);
		paintNameStore(g, x, y);
	}

	public override void paintNameStore(mGraphics g, int x, int y)
	{
		if (nameStore != null && !nameStore.name.Equals(string.Empty))
		{
			nameStore.paint(g);
		}
	}

	public override void paintAvatarFocus(mGraphics g, int x, int y)
	{
		if (!GameScreen.infoGame.isMapThachdau())
		{
			base.paintAvatarFocus(g, x, y);
		}
	}

	public override void update()
	{
		updateEffectCharWearing();
		updateActionPerson();
		updateDataEffect();
		if (nameStore != null)
		{
			nameStore.updatePos(x, y - hOne - 30);
		}
		if (KillFire != -1)
		{
			if (CRes.abs(x - xFire) <= vMax + getVmount() && CRes.abs(y - yFire) <= vMax + getVmount())
			{
				timeHuyKill++;
				posTransRoad = null;
				ListKillNow.setFireSkill(this, vecObjFocusSkill, KillFire, -1);
				if (timeHuyKill > 5)
				{
					ListKillNow.fireSkillFree();
					timeHuyKill = 0;
					KillFire = -1;
				}
			}
		}
		else
		{
			timeHuyKill = 0;
		}
		if (!MainObject.isInScreen(this) && !setIsInScreen(toX, toY, wOne, hOne))
		{
			x = toX;
			y = toY;
			vx = 0;
			vy = 0;
			if (Action != 4)
			{
				Action = 0;
			}
			return;
		}
		Move_to_Focus_Person();
		int tile = GameCanvas.loadmap.getTile(x + vx, y + vy);
		setMove(1, tile);
		updateoverHP_MP();
		updateEye();
		base.update();
		if (!isMonPhoBangDie || timeFreeMove >= 70)
		{
			return;
		}
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
		if (timeFreeMove < 70)
		{
			return;
		}
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

	public void move_to_XY(int tX, int tY)
	{
		if (CRes.abs(x - tX) > 2)
		{
			vy = 0;
			Action = 1;
			if (CRes.abs(x - tX) > vMax + getVmount())
			{
				if (x > tX)
				{
					vx = -(vMax + getVmount());
					Direction = 2;
				}
				else
				{
					vx = vMax + getVmount();
					Direction = 3;
				}
			}
			else
			{
				vx = tX - x;
			}
		}
		else if (CRes.abs(y - tY) > 2)
		{
			vx = 0;
			Action = 1;
			if (CRes.abs(y - tY) > vMax + getVmount())
			{
				if (y > tY)
				{
					vy = -(vMax + getVmount());
					Direction = 1;
				}
				else
				{
					vy = vMax + getVmount();
					Direction = 0;
				}
			}
			else
			{
				vy = tY - y;
			}
		}
		else
		{
			vx = 0;
			vy = 0;
		}
	}

	public override int getIDnpc()
	{
		return isBot;
	}

	public override void GiaoTiep()
	{
		if (isNPC())
		{
			MainObject.resetDirection(GameScreen.player, this);
			if (isPerson == 0)
			{
				GlobalService.gI().getlist_from_npc((sbyte)getIDnpc());
				return;
			}
			mVector mVector3 = new mVector("Other_Player menu");
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
			GameCanvas.menu2.startAt(mVector3, 2, T.giaotiep, isFocus: false, null);
		}
		else if (typeObject == 0 && typeSpec == 0)
		{
			mVector mVector4 = new mVector("Other_Player menu2");
			mVector4.addElement(GameScreen.gI().cmdChat);
			mVector4.addElement(GameScreen.gI().cmdAddfriend);
			mVector4.addElement(GameScreen.gI().cmdInfoChar);
			if (Player.party == null || Player.party.vecPartys.size() < 5)
			{
				mVector4.addElement(GameScreen.gI().cmdMoiParty);
			}
			mVector4.addElement(GameScreen.gI().cmdBuy_Sell);
			if (LoadMap.typeMap != LoadMap.MAP_THACH_DAU && LoadMap.typeMap != LoadMap.MAP_PHO_BANG)
			{
				mVector4.addElement(GameScreen.gI().cmdThachDau);
			}
			if (GameScreen.player.myClan != null && GameScreen.player.myClan.setAddMem())
			{
				mVector4.addElement(GameScreen.gI().cmdAddMemClan);
			}
			mVector mVector5 = vectorObjectNear();
			mVector5.insertElementAt(this, 0);
			GameCanvas.menu2.startAt(mVector4, 2, T.giaotiep, isFocus: true, mVector5);
		}
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
		mVector mVector3 = new mVector("Other_Player menu");
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

	public override void addEffectCharWearing(int typeeffect, int idimage)
	{
		EffectCharWearing o = new EffectCharWearing((sbyte)typeeffect, idimage);
		vecEffectCharWearing.addElement(o);
	}

	public override void removeNameStore()
	{
		nameStore = null;
	}

	public override void setNameStore(string name)
	{
		if (nameStore == null)
		{
			nameStore = new PopupChat();
		}
		nameStore.setChat(name, isStop);
		nameStore.updatePos(x, y - hOne - 30);
	}

	public override bool isSelling()
	{
		return nameStore != null;
	}

	public override bool canFocus()
	{
		return typefocus == 1;
	}

	public override bool canfire()
	{
		return typefire == 1;
	}
}
