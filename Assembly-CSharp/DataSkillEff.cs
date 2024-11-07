using System;
using System.Collections;

public class DataSkillEff
{
	public bool isMatna;

	public bool isLoadData;

	public mVector listFrame = new mVector();

	public mVector listAnima = new mVector();

	public SmallImage[] smallImage;

	public sbyte[][] frameChar = new sbyte[4][]
	{
		new sbyte[1],
		new sbyte[1],
		new sbyte[1],
		new sbyte[1]
	};

	public sbyte[] sequence;

	public sbyte Frame;

	public sbyte f;

	public bool IsStop;

	public long timeRemove;

	public static sbyte TYPE_EFFECT_END = 0;

	public static sbyte TYPE_EFFECT_STARTSKILL = 1;

	public static sbyte TYPE_EFFECT_BUFF = 2;

	public bool wantDetroy;

	public static mHashTable hasDataSkilleff = new mHashTable();

	public sbyte leavelPaint;

	public short x;

	public short y;

	private short indexSkill;

	public sbyte indexStartSkill;

	public short idEff;

	private int dxx;

	private int dyy;

	public int typRequestImg = 112;

	public sbyte Typemove;

	public bool isremovebyTime;

	public static mHashTable ALL_DATA_EFFECT = new mHashTable();

	private sbyte loop;

	private long lasttime;

	public long timelive;

	public bool isremovebyFrame;

	public DataSkillEff(sbyte[] array, short ideff, int dxx, int dyy)
	{
		idEff = ideff;
		this.dxx = dxx;
		this.dyy = dyy;
		loadData(array);
	}

	public DataSkillEff(sbyte[] array, short ideff, int dxx, int dyy, sbyte typemove)
	{
		idEff = ideff;
		this.dxx = dxx;
		this.dyy = dyy;
		Typemove = typemove;
		loadData(array);
	}

	public DataSkillEff(short ideff, int x, int y, sbyte[] arr)
	{
		idEff = ideff;
		this.x = (short)x;
		this.y = (short)y;
		loadData(arr);
		isremovebyFrame = true;
	}

	public DataSkillEff(int id)
	{
		idEff = (short)id;
	}

	public DataSkillEff(sbyte[] array, short ideff, int dxx, int dyy, long time, sbyte typemove)
	{
		idEff = ideff;
		this.dxx = dxx;
		this.dyy = dyy;
		Typemove = typemove;
		timelive = time;
		isremovebyTime = true;
		loadData(array);
	}

	public DataSkillEff(int type, int dx, int dy)
	{
		indexSkill = (short)type;
		dxx = dx;
		dyy = dy;
		load(type);
	}

	public DataSkillEff(int type, int x, int y, int lvpaint)
	{
		indexSkill = (short)type;
		this.x = (short)x;
		this.y = (short)y;
		leavelPaint = (sbyte)lvpaint;
		load(type);
	}

	public void load(int idEff)
	{
		try
		{
			this.idEff = (short)idEff;
			EffectData effectData = (EffectData)hasDataSkilleff.get(string.Empty + idEff);
			if (effectData == null)
			{
				DataInputStream dataInputStream = mImage.openFile("/dataeff/" + idEff);
				short num = (short)dataInputStream.available();
				sbyte[] array = new sbyte[num];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = dataInputStream.readByte();
				}
				EffectData effectData2 = new EffectData();
				effectData2.setdata(array);
				hasDataSkilleff.put(string.Empty + idEff, effectData2);
				loadData(array);
			}
			else
			{
				loadData(effectData.data);
			}
		}
		catch (Exception)
		{
		}
	}

	public bool isHavedata()
	{
		if (isLoadData)
		{
			return true;
		}
		loadData(null);
		return false;
	}

	public void loadData(sbyte[] array)
	{
		try
		{
			if (array == null || array.Length == 0)
			{
				EffectData effectData = (EffectData)ALL_DATA_EFFECT.get(string.Empty + (idEff + GameData.ID_START_SKILL));
				if (effectData != null && effectData.data != null)
				{
					array = effectData.data;
					effectData.timeRemove = GameCanvas.timeNow;
				}
				if (effectData == null)
				{
					effectData = new EffectData((short)(idEff + GameData.ID_START_SKILL));
					ALL_DATA_EFFECT.put(string.Empty + (idEff + GameData.ID_START_SKILL), effectData);
					GameData.RequestImgandData((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
					effectData.timeRemove = (int)(mSystem.currentTimeMillis() / 1000);
				}
			}
			if (array == null || array.Length <= 0)
			{
				return;
			}
			DataInputStream dataInputStream = new DataInputStream(array);
			int num = dataInputStream.readByte();
			smallImage = new SmallImage[num];
			for (int i = 0; i < num; i++)
			{
				smallImage[i] = new SmallImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
			}
			int num2 = dataInputStream.readShort();
			for (int j = 0; j < num2; j++)
			{
				sbyte b = dataInputStream.readByte();
				mVector mVector3 = new mVector();
				mVector mVector4 = new mVector();
				for (int k = 0; k < b; k++)
				{
					PartFrame partFrame = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
					partFrame.flip = dataInputStream.readByte();
					partFrame.onTop = dataInputStream.readByte();
					if (partFrame.onTop == 0)
					{
						mVector3.addElement(partFrame);
					}
					else
					{
						mVector4.addElement(partFrame);
					}
				}
				listFrame.addElement(new FrameEff(mVector3, mVector4));
			}
			short num3 = (short)dataInputStream.readUnsignedByte();
			sequence = new sbyte[num3];
			for (int l = 0; l < num3; l++)
			{
				sequence[l] = (sbyte)dataInputStream.readShort();
			}
			indexStartSkill = dataInputStream.readByte();
			num3 = dataInputStream.readByte();
			frameChar[0] = new sbyte[num3];
			for (int m = 0; m < num3; m++)
			{
				frameChar[0][m] = dataInputStream.readByte();
			}
			num3 = dataInputStream.readByte();
			frameChar[1] = new sbyte[num3];
			for (int n = 0; n < num3; n++)
			{
				frameChar[1][n] = dataInputStream.readByte();
			}
			num3 = dataInputStream.readByte();
			frameChar[3] = new sbyte[num3];
			for (int num4 = 0; num4 < num3; num4++)
			{
				frameChar[3][num4] = dataInputStream.readByte();
			}
			isLoadData = true;
		}
		catch (Exception)
		{
		}
	}

	public void paintTopWeaPon(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintTopPP(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintTop(mGraphics g, int x, int y)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			listPartTop = frameEff.listPartBottom;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int dx = partFrame.dx;
					int num = smallImage.w;
					int num2 = smallImage.h;
					int num3 = smallImage.x;
					int num4 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num3 > imageWidth)
					{
						num3 = 0;
					}
					if (num4 > imageHeight)
					{
						num4 = 0;
					}
					if (num3 + num > imageWidth)
					{
						num = imageWidth - num3;
					}
					if (num4 + num2 > imageHeight)
					{
						num2 = imageHeight - num4;
					}
					g.drawRegion(imgIcon.img, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, x + dx + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottomPP(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartBottom = frameEff.listPartBottom;
			for (int i = 0; i < listPartBottom.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintTopHorse(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottomHorse(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartBottom = frameEff.listPartBottom;
			for (int i = 0; i < listPartBottom.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottomWeaPon(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartBottom = frameEff.listPartBottom;
			for (int i = 0; i < listPartBottom.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottom(mGraphics g, int x, int y)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int dx = partFrame.dx;
					int num = smallImage.w;
					int num2 = smallImage.h;
					int num3 = smallImage.x;
					int num4 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num3 > imageWidth)
					{
						num3 = 0;
					}
					if (num4 > imageHeight)
					{
						num4 = 0;
					}
					if (num3 + num > imageWidth)
					{
						num = imageWidth - num3;
					}
					if (num4 + num2 > imageHeight)
					{
						num2 = imageHeight - num4;
					}
					g.drawRegion(imgIcon.img, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, x + dx + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintTop(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottom(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartBottom = frameEff.listPartBottom;
			for (int i = 0; i < listPartBottom.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintTopAll(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottomAll(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartBottom = frameEff.listPartBottom;
			for (int i = 0; i < listPartBottom.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public bool lockmoveByeffAuto()
	{
		return Typemove == 1;
	}

	public bool CanpaintByeffauto()
	{
		return Typemove == 2;
	}

	public bool isTanghinhbyEffauto()
	{
		return Typemove == 17;
	}

	public void update()
	{
		try
		{
			if (!isHavedata())
			{
				return;
			}
			if (isremovebyTime && timelive - mSystem.currentTimeMillis() < 0)
			{
				wantDetroy = true;
			}
			f++;
			if (f >= sequence.Length)
			{
				if (isremovebyFrame)
				{
					wantDetroy = true;
				}
				if (isremovebyTime)
				{
					f = 0;
				}
				if (!isremovebyTime && mSystem.currentTimeMillis() - lasttime > loop * 1000)
				{
					f = 0;
					lasttime = mSystem.currentTimeMillis();
					loop = (sbyte)CRes.random(1, 8);
				}
			}
			if (f > 0 && f < sequence.Length)
			{
				Frame = sequence[f];
			}
		}
		catch (Exception)
		{
			mSystem.println("loi update me day");
		}
	}

	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = ALL_DATA_EFFECT.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				EffectData effectData = (EffectData)ALL_DATA_EFFECT.get(k);
				if ((GameCanvas.timeNow - effectData.timeRemove) / 1000 > ((TemMidlet.DIVICE != 0) ? 300 : 60))
				{
					ALL_DATA_EFFECT.remove(k);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintTopHair(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottomHair(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartBottom = frameEff.listPartBottom;
			for (int i = 0; i < listPartBottom.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintTopWing(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottomName(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartBottom = frameEff.listPartBottom;
			for (int i = 0; i < listPartBottom.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintTopName(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartTop = frameEff.listPartTop;
			for (int i = 0; i < listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottomWing(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!isHavedata() || Frame >= listFrame.size())
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
		try
		{
			mVector listPartBottom = frameEff.listPartBottom;
			for (int i = 0; i < listPartBottom.size(); i++)
			{
				PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				ImageIcon imgIcon = GameData.getImgIcon((short)(idEff + GameData.ID_START_SKILL), typRequestImg);
				if (imgIcon != null && imgIcon.img != null)
				{
					int num = partFrame.dx;
					int num2 = smallImage.w;
					int num3 = smallImage.h;
					int num4 = smallImage.x;
					int num5 = smallImage.y;
					int imageWidth = mImage.getImageWidth(imgIcon.img.image);
					int imageHeight = mImage.getImageHeight(imgIcon.img.image);
					if (num4 > imageWidth)
					{
						num4 = 0;
					}
					if (num5 > imageHeight)
					{
						num5 = 0;
					}
					if (num4 + num2 > imageWidth)
					{
						num2 = imageWidth - num4;
					}
					if (num5 + num3 > imageHeight)
					{
						num3 = imageHeight - num5;
					}
					int num6 = ((partFrame.flip == 1) ? 2 : 0);
					if (rotale == 2 || rotale == 6)
					{
						num6 = ((num6 != 2) ? 2 : 0);
						num = -(num + num2);
					}
					g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
