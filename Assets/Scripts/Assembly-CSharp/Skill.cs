public class Skill
{
	public const sbyte ACTIVE = 0;

	public const sbyte BUFF = 1;

	public const sbyte PASSIVE = 2;

	public const sbyte BUFF_ALL = 0;

	public const sbyte BUFF_ME = 1;

	public const sbyte BUFF_TEAM = 2;

	public const sbyte BUFF_ENEMY = 3;

	public static mHashTable hashImageSkill = new mHashTable();

	public int Id;

	public string name;

	public string detail;

	public sbyte typeSkill;

	public sbyte iconId;

	public sbyte typeBuff;

	public sbyte subEff;

	public short range;

	public short lvMin;

	public short performDur;

	public LvSkill[] mLvSkill;

	public string[] mcontent;

	public sbyte typePaint;

	public void setContent()
	{
	}

	public void paint(mGraphics g, int x, int y, int achor)
	{
		MainImage imageSkill = ObjectData.getImageSkill(iconId);
		if (imageSkill.img != null)
		{
			g.drawImage(imageSkill.img, x, y, achor, mGraphics.isTrue);
		}
		else
		{
			g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, achor, mGraphics.isTrue);
		}
	}

	public void paintSmall(mGraphics g, int x, int y, int achor)
	{
		MainImage imageSkill = ObjectData.getImageSkill(iconId);
		if (imageSkill.img != null)
		{
			g.drawRegion(imageSkill.img, 1, 1, 18, 18, 0, x, y, achor, mGraphics.isFalse);
		}
		else
		{
			g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, achor, mGraphics.isFalse);
		}
	}

	public string[] getContent()
	{
		if (mcontent == null)
		{
			if (GameScreen.player.Lv < lvMin)
			{
				string[] array = mFont.tahoma_7_white.splitFontArray(detail, (MainTabNew.longwidth <= 0) ? 126 : (MainTabNew.longwidth - 10));
				mcontent = new string[array.Length + 1];
				if (GameScreen.player.Lv < lvMin)
				{
					mcontent[0] = T.yeucau + T.level + lvMin;
				}
				for (int i = 1; i < mcontent.Length; i++)
				{
					mcontent[i] = array[i - 1];
				}
			}
			else
			{
				int num = Player.mCurentLvSkill[Id];
				if (num > 0)
				{
					num += Player.mPlusLvSkill[Id];
				}
				int num2 = num - 1;
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (Id == 0 || num2 >= 15)
				{
					num2 = 0;
				}
				LvSkill lvSkill = mLvSkill[num2];
				string[] array2 = lvSkill.getinfo();
				string[] array3 = mInfoSkill(num2, Player.mCurentLvSkill[Id] == 0);
				int num3 = array2.Length + array3.Length + lvSkill.minfo.Length;
				mcontent = new string[num3];
				num3 = 0;
				for (int j = 0; j < array3.Length; j++)
				{
					mcontent[num3] = array3[j];
					num3++;
				}
				for (int k = 0; k < array2.Length; k++)
				{
					mcontent[num3] = array2[k];
					num3++;
				}
				for (int l = 0; l < lvSkill.minfo.Length; l++)
				{
					mcontent[num3] = Item.nameInfoItem[lvSkill.minfo[l].id] + ": " + Item.getPercent(Item.isPercentInfoItem[lvSkill.minfo[l].id], lvSkill.minfo[l].value);
					num3++;
				}
			}
		}
		return mcontent;
	}

	public string[] mInfoSkill(int levelSkill, bool ischuahoc)
	{
		string[] array = null;
		int num = 0;
		string[] array2 = mFont.tahoma_7_white.splitFontArray(detail, (MainTabNew.longwidth <= 0) ? 126 : (MainTabNew.longwidth - 10));
		num += array2.Length + 1;
		if (ischuahoc)
		{
			num++;
		}
		else if (Player.mCurentLvSkill[Id] < 10 && Id != 0)
		{
			num++;
		}
		if (typeSkill == 1)
		{
			num++;
		}
		if (mLvSkill[levelSkill].range_lan > 0)
		{
			num++;
		}
		array = new string[num];
		num = 0;
		if (ischuahoc)
		{
			array[num] = T.chuahoc;
			num++;
		}
		else if (Player.mCurentLvSkill[Id] < 10 && Id != 0)
		{
			array[num] = T.nangcapyeucau + mLvSkill[levelSkill].LvRe;
			num++;
		}
		string text = "[" + T.kynang + T.active + "]";
		if (typeSkill == 1)
		{
			text = "[" + T.kynang + T.buff + "]";
		}
		else if (typeSkill == 2)
		{
			text = "[" + T.kynang + T.passive + "]";
		}
		array[num] = text;
		num++;
		for (int i = 0; i < array2.Length; i++)
		{
			array[num] = array2[i];
			num++;
		}
		if (typeSkill == 1)
		{
			string text2 = T.tacdunglen + " : ";
			switch (typeBuff)
			{
			case 0:
				text2 += T.moinguoi;
				break;
			case 1:
				text2 += T.banthan;
				break;
			case 2:
				text2 += T.trongdoi;
				break;
			case 3:
				text2 += T.kethu;
				break;
			}
			array[num++] = text2;
		}
		if (mLvSkill[levelSkill].range_lan > 0)
		{
			array[num++] = T.phamvilan + mLvSkill[levelSkill].range_lan;
		}
		return array;
	}

	public static void resetContent()
	{
		for (int i = 0; i < TabSkillsNew.vecPaintSkill.size(); i++)
		{
			Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(i);
			skill.mcontent = null;
		}
	}
}
