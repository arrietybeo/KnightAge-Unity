using System;
using System.Collections;

public class EffectAuto : MainItemMap
{
	private MainEffectAuto eff;

	private int nCountReplay;

	private bool isPaint = true;

	private bool isUpdate;

	private int typeEffect;

	private int valueEffect;

	private int f;

	private long timeBegin;

	public bool wantdestroy;

	private int indexSound = -1;

	private int timePlaySound = -1;

	public static long timeSoundFIRE = 0L;

	public static long timeSoundWATER = 0L;

	public static long timeSoundPHUNNUOC = 0L;

	public static long timeSoundGIOTNUOC = 0L;

	public static long lastTime;

	public long timelive;

	public short Loop;

	private sbyte typedata;

	public static mHashTable ALL_DATA_EFF_AUTO = new mHashTable();

	public int dxx;

	public int dyy;

	public sbyte Typemove;

	public EffectAuto(string key, string value)
	{
		TypeItem = 1;
		string[] array = mFont.split(value, ";");
		IDItem = short.Parse(array[0]);
		IDImage = short.Parse(array[1]);
		x = int.Parse(array[2]) * LoadMap.wTile;
		y = int.Parse(array[3]) * LoadMap.wTile;
		dx = int.Parse(array[4]);
		dy = int.Parse(array[5]);
		typeEffect = int.Parse(array[6]);
		valueEffect = int.Parse(array[7]);
		wOne = 70;
		hOne = 70;
		setDataEff(null);
	}

	public EffectAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff)
	{
		TypeItem = 1;
		IDItem = (short)id;
		IDImage = (short)id;
		base.x = x;
		base.y = y;
		base.dx = dx;
		base.dy = dy;
		typeEffect = typeeff;
		valueEffect = valueeff;
		wOne = 70;
		hOne = 70;
		dxx = 0;
		dyy = 0;
		setDataEff(null);
	}

	public EffectAuto(int id, int x, int y, sbyte[] datasv)
	{
		typedata = 1;
		TypeItem = 3;
		IDItem = (short)id;
		IDImage = (short)id;
		base.x = x;
		base.y = y;
		wOne = 70;
		hOne = 70;
		dxx = 0;
		dyy = 0;
		setdataFromSV(datasv);
	}

	public EffectAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff, sbyte[] datasv, long timelive, sbyte canmove, int dxx, int dyy)
	{
		typedata = 1;
		TypeItem = 2;
		IDItem = (short)id;
		IDImage = (short)id;
		base.x = x;
		base.y = y;
		base.dx = dx;
		base.dy = dy;
		typeEffect = typeeff;
		valueEffect = valueeff;
		wOne = 70;
		hOne = 70;
		this.timelive = timelive;
		Typemove = canmove;
		this.dxx = dxx;
		this.dyy = dyy;
		setdataFromSV(datasv);
	}

	public EffectAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff, sbyte[] datasv)
	{
		typedata = 1;
		TypeItem = 1;
		IDItem = (short)id;
		IDImage = (short)id;
		base.x = x;
		base.y = y;
		base.dx = dx;
		base.dy = dy;
		typeEffect = typeeff;
		valueEffect = valueeff;
		wOne = 70;
		hOne = 70;
		dxx = 0;
		dyy = 0;
		setdataFromSV(datasv);
	}

	public EffectAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff, sbyte[] datasv, short loop)
	{
		typedata = 1;
		TypeItem = 1;
		IDItem = (short)id;
		IDImage = (short)id;
		base.x = x;
		base.y = y;
		base.dx = dx;
		base.dy = dy;
		typeEffect = typeeff;
		valueEffect = valueeff;
		wOne = 70;
		hOne = 70;
		dxx = 0;
		dyy = 0;
		Loop = loop;
		setdataFromSV(datasv);
	}

	public sbyte[] getdataFromRMS()
	{
		sbyte[] data = null;
		try
		{
			sbyte[] array = CRes.loadRMS("data_eff" + IDImage);
			if (array != null)
			{
				DataInputStream dataInputStream = new DataInputStream(array);
				data = new sbyte[dataInputStream.readShort()];
				dataInputStream.read(ref data);
				dataInputStream.close();
			}
		}
		catch (Exception)
		{
		}
		return data;
	}

	public void setdataFromSV(sbyte[] datasv)
	{
		if (datasv != null && datasv.Length > 0)
		{
			eff = loadTemEff(IDImage, datasv);
			timeBegin = GameCanvas.timeNow;
			isPaint = true;
			isUpdate = true;
			setPlaySound();
			return;
		}
		DataEffAuto dataEffAuto = (DataEffAuto)ALL_DATA_EFF_AUTO.get(string.Empty + IDImage);
		if (dataEffAuto == null)
		{
			sbyte[] array = getdataFromRMS();
			if (array != null && array.Length > 0)
			{
				dataEffAuto = new DataEffAuto(IDImage);
				dataEffAuto.setdata(array);
				ALL_DATA_EFF_AUTO.put(IDImage + string.Empty, dataEffAuto);
				eff = loadTemEff(IDImage, dataEffAuto.data);
				timeBegin = GameCanvas.timeNow;
				isPaint = true;
				isUpdate = true;
				dataEffAuto.timeremove = (int)(mSystem.currentTimeMillis() / 1000);
				setPlaySound();
			}
			else
			{
				dataEffAuto = new DataEffAuto(IDImage);
				ALL_DATA_EFF_AUTO.put(IDImage + string.Empty, dataEffAuto);
				ImageEffectAuto.setImage(IDImage);
				dataEffAuto.timeremove = (int)(mSystem.currentTimeMillis() / 1000);
			}
		}
		if (dataEffAuto != null && dataEffAuto.data != null && dataEffAuto.data.Length > 0)
		{
			eff = loadTemEff(IDImage, dataEffAuto.data);
			timeBegin = GameCanvas.timeNow;
			isPaint = true;
			isUpdate = true;
			setPlaySound();
		}
	}

	public void paintMatna(mGraphics g)
	{
		try
		{
			if (typedata == 1 && !isUpdate)
			{
				setdataFromSV(null);
			}
			else
			{
				if (eff == null || !isPaint)
				{
					return;
				}
				int num = eff.mRunFrame[f];
				int num2 = eff.mFrame[num].mpart.Length;
				for (int i = 0; i < num2; i++)
				{
					MainPartImage mainPartImage = (MainPartImage)eff.hashImage.get(string.Empty + eff.mFrame[num].mpart[i].idPartImage);
					mImage mImage2 = ImageEffectAuto.setImage(IDImage);
					if (mainPartImage != null && mImage2 != null && mImage2.image != null)
					{
						g.drawRegion(mImage2, mainPartImage.x, mainPartImage.y, mainPartImage.w, mainPartImage.h, 0, x + dx + eff.mFrame[num].mpart[i].x, y + dy + eff.mFrame[num].mpart[i].y, 0, mGraphics.isFalse);
					}
				}
			}
		}
		catch (Exception)
		{
			isPaint = false;
			isUpdate = false;
		}
	}

	public new void setDataEff(sbyte[] datasv)
	{
		eff = loadTemEff(IDImage, datasv);
		timeBegin = GameCanvas.timeNow;
		isPaint = true;
		isUpdate = true;
		setPlaySound();
	}

	public override void paint(mGraphics g)
	{
		if (typedata == 1 && !isUpdate)
		{
			setdataFromSV(null);
			return;
		}
		if (TypeItem == 3)
		{
			try
			{
				if (eff != null && isPaint)
				{
					int num = eff.mRunFrame[f];
					int num2 = eff.mFrame[num].mpart.Length;
					for (int i = 0; i < num2; i++)
					{
						MainPartImage mainPartImage = (MainPartImage)eff.hashImage.get(string.Empty + eff.mFrame[num].mpart[i].idPartImage);
						mImage mImage2 = ImageEffectAuto.setImage(IDImage);
						if (mainPartImage != null && mImage2 != null && mImage2.image != null)
						{
							g.drawRegion(mImage2, mainPartImage.x, mainPartImage.y, mainPartImage.w, mainPartImage.h, 0, x + dx + eff.mFrame[num].mpart[i].x, y + dy + eff.mFrame[num].mpart[i].y, 0, mGraphics.isFalse);
						}
					}
				}
				return;
			}
			catch (Exception)
			{
				isPaint = false;
				isUpdate = false;
				return;
			}
		}
		if (TypeItem == 4)
		{
			paintMatna(g);
		}
		else
		{
			if ((GameCanvas.lowGraphic || !isUpdate || LoadMap.isShowEffAuto == LoadMap.EFF_PHOBANG_END) && !GameScreen.infoGame.isMapchienthanh())
			{
				return;
			}
			try
			{
				if (eff == null || !isPaint)
				{
					return;
				}
				int num3 = eff.mRunFrame[f];
				int num4 = eff.mFrame[num3].mpart.Length;
				for (int j = 0; j < num4; j++)
				{
					MainPartImage mainPartImage2 = (MainPartImage)eff.hashImage.get(string.Empty + eff.mFrame[num3].mpart[j].idPartImage);
					mImage mImage3 = ImageEffectAuto.setImage(IDImage);
					if (mainPartImage2 != null && mImage3 != null && mImage3.image != null)
					{
						g.drawRegion(mImage3, mainPartImage2.x, mainPartImage2.y, mainPartImage2.w, mainPartImage2.h, 0, x + dx + eff.mFrame[num3].mpart[j].x, y + dy + eff.mFrame[num3].mpart[j].y, 0, mGraphics.isFalse);
					}
				}
			}
			catch (Exception)
			{
				isPaint = false;
				isUpdate = false;
			}
		}
	}

	public void paint(mGraphics g, int xp, int yp)
	{
		if (typedata == 1 && !isUpdate)
		{
			setdataFromSV(null);
		}
		else
		{
			if (GameCanvas.lowGraphic || !isUpdate || LoadMap.isShowEffAuto == LoadMap.EFF_PHOBANG_END)
			{
				return;
			}
			try
			{
				if (eff == null || !isPaint)
				{
					return;
				}
				int num = eff.mRunFrame[f];
				int num2 = eff.mFrame[num].mpart.Length;
				for (int i = 0; i < num2; i++)
				{
					MainPartImage mainPartImage = (MainPartImage)eff.hashImage.get(string.Empty + eff.mFrame[num].mpart[i].idPartImage);
					mImage mImage2 = ImageEffectAuto.setImage(IDImage);
					if (mainPartImage != null && mImage2 != null && mImage2.image != null)
					{
						g.drawRegion(mImage2, mainPartImage.x, mainPartImage.y, mainPartImage.w, mainPartImage.h, 0, xp + dx + eff.mFrame[num].mpart[i].x + dxx, yp + dy + eff.mFrame[num].mpart[i].y + dyy, 0, mGraphics.isFalse);
					}
				}
			}
			catch (Exception ex)
			{
				mSystem.println(IDImage + " null img effect auto 2:" + ex.ToString());
				isPaint = false;
				isUpdate = false;
			}
		}
	}

	public bool lockmoveByeffAuto()
	{
		return timelive - mSystem.currentTimeMillis() > 0 && Typemove == 1;
	}

	public bool CanpaintByeffauto()
	{
		return timelive - mSystem.currentTimeMillis() > 0 && Typemove == 2;
	}

	public override void update()
	{
		if (typedata == 1 && !isUpdate)
		{
			return;
		}
		try
		{
			if (TypeItem == 3)
			{
				f++;
				if (f >= eff.mRunFrame.Length - 1)
				{
					f = 0;
					wantdestroy = true;
				}
				return;
			}
			if ((GameCanvas.lowGraphic || !isUpdate || LoadMap.isShowEffAuto == LoadMap.EFF_PHOBANG_END) && !GameScreen.infoGame.isMapchienthanh())
			{
				return;
			}
			if (TypeItem == 2 && timelive - mSystem.currentTimeMillis() < 0)
			{
				wantdestroy = true;
			}
			if (IDImage == 51)
			{
				f++;
				if (f >= eff.mRunFrame.Length - 1)
				{
					f = eff.mRunFrame.Length - 1;
				}
			}
			else if (f >= eff.mRunFrame.Length - 1)
			{
				switch (typeEffect)
				{
				case 0:
					nCountReplay++;
					isPaint = false;
					if (nCountReplay >= valueEffect)
					{
						nCountReplay = 0;
						isPaint = true;
						f = 0;
					}
					break;
				case 1:
					f = 0;
					break;
				case 2:
					isPaint = false;
					if (GameCanvas.gameTick % 5 == 0 && (GameCanvas.timeNow - timeBegin) / 1000 > valueEffect)
					{
						timeBegin = GameCanvas.timeNow;
						f = 0;
						isPaint = true;
					}
					break;
				case 3:
					if (Loop > 0 && CRes.random(valueEffect) == 0)
					{
						Loop--;
						f = 0;
					}
					else if (Loop <= 0)
					{
						wantdestroy = true;
						isPaint = false;
						isUpdate = false;
					}
					break;
				case 4:
					if (CRes.random(valueEffect) == 0)
					{
						f = 0;
						if (indexSound >= 0 && CRes.random(timePlaySound) == 0 && isInScreen())
						{
							mSound.playSound(indexSound, mSound.volumeSound);
						}
					}
					break;
				}
			}
			else
			{
				f++;
			}
		}
		catch (Exception)
		{
			mSystem.outz("eff=" + IDImage);
			isPaint = false;
			isUpdate = false;
		}
		setBeginSound();
	}

	private void setBeginSound()
	{
		if (indexSound == 48)
		{
			if (CRes.random(timePlaySound) == 0 && isInScreen())
			{
				mSound.playSound(indexSound, mSound.volumeSound);
			}
		}
		else if (indexSound == 49)
		{
			if (f == 35 || f == 43)
			{
				if (isInScreen())
				{
					mSound.playSound(49, mSound.volumeSound);
				}
			}
			else if (f == 125 && isInScreen())
			{
				mSound.playSound(50, mSound.volumeSound);
			}
		}
		else if (indexSound == 52)
		{
			if (f == 50 && isInScreen())
			{
				mSound.playSound(52, mSound.volumeSound);
			}
		}
		else if (indexSound == 54)
		{
			if (f % 5 == 0 && isInScreen() && (GameCanvas.timeNow - timeSoundPHUNNUOC) / 100 > 48)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
				timeSoundPHUNNUOC = GameCanvas.timeNow;
			}
		}
		else if (indexSound == 53)
		{
			if (f % 5 == 0 && isInScreen() && (GameCanvas.timeNow - timeSoundFIRE) / 100 > 68 && GameCanvas.currentScreen == GameCanvas.game)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
				timeSoundFIRE = GameCanvas.timeNow;
			}
		}
		else if (indexSound == 55)
		{
			if (f % 5 == 0 && isInScreen() && (GameCanvas.timeNow - timeSoundWATER) / 100 > 28)
			{
				mSound.playSound(indexSound, mSound.volumeSound);
				timeSoundWATER = GameCanvas.timeNow;
			}
		}
		else if (indexSound == 50)
		{
			if (f == 30 && isInScreen())
			{
				mSound.playSound(50, mSound.volumeSound);
			}
		}
		else if (indexSound == 56 && f % 5 == 0 && isInScreen() && (GameCanvas.timeNow - timeSoundGIOTNUOC) / 100 > 48)
		{
			mSound.playSound(indexSound, mSound.volumeSound);
			timeSoundGIOTNUOC = GameCanvas.timeNow;
		}
	}

	public MainEffectAuto loadTemEff(int type, sbyte[] datasv)
	{
		MainEffectAuto mainEffectAuto = (MainEffectAuto)MainEffectAuto.hashTemEffAuto.get(string.Empty + type);
		if (mainEffectAuto == null)
		{
			mainEffectAuto = new MainEffectAuto(type, datasv);
			MainEffectAuto.hashTemEffAuto.put(type + string.Empty, mainEffectAuto);
		}
		return mainEffectAuto;
	}

	public void setPlaySound()
	{
		switch (IDImage)
		{
		case 7:
			indexSound = 48;
			timePlaySound = 200;
			break;
		case 29:
			indexSound = 47;
			timePlaySound = 3;
			break;
		case 11:
			indexSound = 49;
			timePlaySound = 2;
			break;
		case 9:
		case 12:
			indexSound = 52;
			timePlaySound = 2;
			break;
		case 28:
			indexSound = 54;
			timePlaySound = 2;
			break;
		case 0:
		case 15:
		case 17:
		case 18:
		case 30:
		case 32:
			indexSound = 53;
			timePlaySound = 2;
			break;
		case 19:
		case 20:
		case 31:
			indexSound = 55;
			timePlaySound = 2;
			break;
		case 6:
			indexSound = 50;
			timePlaySound = 2;
			break;
		case 22:
			indexSound = 56;
			timePlaySound = 2;
			break;
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 8:
		case 10:
		case 13:
		case 14:
		case 16:
		case 21:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
			break;
		}
	}

	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = ALL_DATA_EFF_AUTO.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				DataEffAuto dataEffAuto = (DataEffAuto)ALL_DATA_EFF_AUTO.get(k);
				if ((GameCanvas.timeNow - dataEffAuto.timeremove) / 1000 > ((TemMidlet.DIVICE != 0) ? 300 : 60))
				{
					ALL_DATA_EFF_AUTO.remove(k);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void setidActor(int idac)
	{
		idActor = (short)idac;
	}
}
