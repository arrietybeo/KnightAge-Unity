using System;

public class MainRMS
{
	public const sbyte SKILL = 0;

	public const sbyte HELP = 1;

	public const sbyte BEGIN_GAME = 2;

	public const sbyte AUTO = 3;

	public const sbyte TOUCH = 4;

	public static bool isLoadBegin;

	public static bool isLoadShowAuto = true;

	public static string showAuto = string.Empty;

	public static void RequietRMS()
	{
		GlobalService.gI().Save_RMS_Server(1, 0, null);
		setLoadRMS(0, null);
	}

	public static void setLoadRMS(sbyte id, sbyte[] mdata)
	{
		switch (id)
		{
		case 0:
			if (GameScreen.player != null)
			{
				TabSkillsNew.loadSkill(mdata);
			}
			break;
		case 1:
			GameScreen.help.LoadStep(mdata);
			GameCanvas.load.isLoadHelp = true;
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv && (GameScreen.help.Step > 0 || GameScreen.help.Next > -5))
			{
				GameScreen.isFinishHelp = true;
				GameCanvas.end_Dialog();
				Player.isLockKey = false;
			}
			break;
		case 2:
			GameScreen.help.loadBeginGame(mdata);
			isLoadBegin = true;
			mSystem.outz("ouuuuuuuuuuuuuuuuuuuu");
			break;
		case 3:
			if (mdata != null)
			{
				setLoadAuto(mdata);
			}
			break;
		case 4:
			if (mdata != null)
			{
				if (GameCanvas.isTouch)
				{
					PaintInfoGameScreen.isLevelPoint = mdata[0] == 1;
					PaintInfoGameScreen.setPosTouch();
				}
				if (mdata.Length > 1)
				{
					PaintInfoGameScreen.isShowInfoAuto = mdata[1] == 1;
				}
			}
			break;
		}
	}

	public static void setLoadAuto(sbyte[] data)
	{
		showAuto = string.Empty;
		bool flag = false;
		Player.isAutoHPMP = data[0] == 1;
		MsgDialog.mHPMP[0] = data[1];
		MsgDialog.mHPMP[1] = data[2];
		if (Player.isAutoHPMP && PaintInfoGameScreen.isShowInfoAuto)
		{
			flag = true;
			string text = showAuto;
			showAuto = text + T.autoHP + "\n  +" + T.mAuto[0] + MsgDialog.mHPMP[0] + "%\n  +" + T.mAuto[1] + MsgDialog.mHPMP[1] + "%";
		}
		bool flag2 = data[3] == 1;
		if (flag2)
		{
			Player.autoItem = new AutoGetItem(data[4], data[5], data[6]);
		}
		if (flag2 && PaintInfoGameScreen.isShowInfoAuto)
		{
			if (flag)
			{
				showAuto += "\n";
			}
			else
			{
				flag = true;
			}
			string text = showAuto;
			showAuto = text + T.autoItem + "\n  +" + T.mAutoItem[0] + ": " + T.mValueAutoItem[0][Player.autoItem.valueColorItem];
			text = showAuto;
			showAuto = text + "\n  +" + T.mAutoItem[1] + ": " + T.mValueAutoItem[1][Player.autoItem.isGetMoney];
			text = showAuto;
			showAuto = text + "\n  +" + T.mAutoItem[2] + ": " + T.mValueAutoItem[2][Player.autoItem.isGetPotion];
		}
		Player.isAutoBuff = data[7];
		int num = MsgDialog.MaxSkillBuff;
		if (data.Length - 7 >= num)
		{
			num -= CRes.abs(num - (data.Length - 7)) + 1;
		}
		for (int i = 0; i < num; i++)
		{
			MsgDialog.Autobuff[i][1] = data[8 + i];
		}
		if (Player.isAutoBuff == 1 && PaintInfoGameScreen.isShowInfoAuto)
		{
			if (flag)
			{
				showAuto += "\n";
			}
			else
			{
				flag = true;
			}
			showAuto += T.autoBuff;
			for (int j = 0; j < num; j++)
			{
				if (MsgDialog.Autobuff[j][1] == 1)
				{
					Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(MsgDialog.Autobuff[j][2]);
					showAuto = showAuto + "\n  " + skill.name;
				}
			}
		}
		if (showAuto.Length > 0 && isLoadShowAuto && GameCanvas.currentScreen == GameCanvas.game)
		{
			isLoadShowAuto = false;
			GameCanvas.start_Show_Dialog(T.autoFire + "\n  " + showAuto, T.auto);
		}
	}

	public static void setSaveAuto()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(Player.isAutoHPMP ? 1 : 0);
			dataOutputStream.writeByte(MsgDialog.mHPMP[0]);
			dataOutputStream.writeByte(MsgDialog.mHPMP[1]);
			dataOutputStream.writeByte((Player.autoItem != null) ? 1 : 0);
			if (Player.autoItem == null)
			{
				dataOutputStream.writeByte(0);
				dataOutputStream.writeByte(0);
				dataOutputStream.writeByte(0);
			}
			else
			{
				dataOutputStream.writeByte(Player.autoItem.valueColorItem);
				dataOutputStream.writeByte(Player.autoItem.isGetMoney);
				dataOutputStream.writeByte(Player.autoItem.isGetPotion);
			}
			dataOutputStream.writeByte(Player.isAutoBuff);
			for (int i = 0; i < MsgDialog.MaxSkillBuff; i++)
			{
				dataOutputStream.writeByte(MsgDialog.Autobuff[i][1]);
			}
			CRes.saveRMSName(3, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public static void setSaveTouch()
	{
		sbyte[] data = new sbyte[2]
		{
			(sbyte)(PaintInfoGameScreen.isLevelPoint ? 1 : 0),
			(sbyte)(PaintInfoGameScreen.isShowInfoAuto ? 1 : 0)
		};
		try
		{
			CRes.saveRMSName(4, data);
		}
		catch (Exception)
		{
		}
	}
}
