using System;

public class DataEffect
{
	public mVector listFrame = new mVector();

	public mVector listAnima = new mVector();

	public SmallImage[] smallImage;

	public sbyte[] sequence;

	public short idimg;

	private short FrameWith;

	private short FrameHeight;

	public string name = string.Empty;

	public sbyte isFly;

	public sbyte idShadow;

	public static sbyte[][] indexAction2 = new sbyte[2][]
	{
		new sbyte[14]
		{
			0, 0, 1, 2, 3, 1, 1, 1, 1, 1,
			1, 1, 1, 1
		},
		new sbyte[14]
		{
			4, 4, 5, 6, 7, 5, 5, 5, 5, 5,
			5, 5, 5, 5
		}
	};

	public static sbyte[] indexAction = new sbyte[9] { 0, 0, 1, 2, 3, 1, 1, 1, 1 };

	public DataEffect(sbyte[] array, int idimg, bool isMonster)
	{
		this.idimg = (short)idimg;
		setDataType1(array);
	}

	public DataEffect(sbyte[] array)
	{
		try
		{
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
				for (int k = 0; k < b; k++)
				{
					PartFrame o = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
					mVector3.addElement(o);
				}
				listFrame.addElement(new FrameEff(mVector3));
			}
			short num3 = dataInputStream.readShort();
			sequence = new sbyte[num3];
			for (int l = 0; l < num3; l++)
			{
				sequence[l] = (sbyte)dataInputStream.readShort();
			}
			sbyte b2 = dataInputStream.readByte();
			sbyte b3 = dataInputStream.readByte();
			num3 = dataInputStream.readByte();
			sbyte[] array2 = new sbyte[num3];
			for (int m = 0; m < num3; m++)
			{
				array2[m] = dataInputStream.readByte();
			}
			Animation o2 = new Animation(array2);
			listAnima.addElement(o2);
			num3 = dataInputStream.readByte();
			array2 = new sbyte[num3];
			for (int n = 0; n < num3; n++)
			{
				array2[n] = dataInputStream.readByte();
			}
			o2 = new Animation(array2);
			listAnima.addElement(o2);
			num3 = dataInputStream.readByte();
			array2 = new sbyte[num3];
			for (int num4 = 0; num4 < num3; num4++)
			{
				array2[num4] = dataInputStream.readByte();
			}
			o2 = new Animation(array2);
			listAnima.addElement(o2);
			num3 = dataInputStream.readByte();
			array2 = new sbyte[num3];
			for (int num5 = 0; num5 < num3; num5++)
			{
				array2[num5] = dataInputStream.readByte();
			}
			o2 = new Animation(array2);
			listAnima.addElement(o2);
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
	}

	public void setDataType1(sbyte[] array)
	{
		short num = 0;
		DataInputStream dataInputStream = null;
		listFrame.removeAllElements();
		listAnima.removeAllElements();
		try
		{
			dataInputStream = new DataInputStream(array);
			int num2 = dataInputStream.readByte();
			smallImage = new SmallImage[num2];
			for (int i = 0; i < num2; i++)
			{
				smallImage[i] = new SmallImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
			}
			int num3 = 0;
			int num4 = 0;
			int num5 = -1000000;
			int num6 = dataInputStream.readShort();
			for (int j = 0; j < num6; j++)
			{
				sbyte b = dataInputStream.readByte();
				mVector mVector3 = new mVector();
				for (int k = 0; k < b; k++)
				{
					PartFrame partFrame = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
					partFrame.flip = dataInputStream.readByte();
					partFrame.onTop = dataInputStream.readByte();
					mVector3.addElement(partFrame);
					if (j == 0)
					{
						if (num5 < partFrame.dy + smallImage[partFrame.idSmallImg].h)
						{
							num5 = partFrame.dy + smallImage[partFrame.idSmallImg].h;
						}
						if (num3 < CRes.abs(partFrame.dy))
						{
							num3 = CRes.abs(partFrame.dy);
						}
					}
				}
				if (j == 0 && num5 <= -5)
				{
					isFly = (sbyte)num5;
				}
				listFrame.addElement(new FrameEff(mVector3, null));
			}
			FrameWith = smallImage[0].w;
			FrameHeight = (short)num3;
			num = dataInputStream.readShort();
			sequence = new sbyte[num];
			for (int l = 0; l < num; l++)
			{
				sequence[l] = (sbyte)dataInputStream.readShort();
			}
			num = dataInputStream.readByte();
			sbyte[] array2 = new sbyte[num];
			for (int m = 0; m < num; m++)
			{
				array2[m] = dataInputStream.readByte();
			}
			Animation o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int n = 0; n < num; n++)
			{
				array2[n] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num7 = 0; num7 < num; num7++)
			{
				array2[num7] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num8 = 0; num8 < num; num8++)
			{
				array2[num8] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num9 = 0; num9 < num; num9++)
			{
				array2[num9] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num10 = 0; num10 < num; num10++)
			{
				array2[num10] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num11 = 0; num11 < num; num11++)
			{
				array2[num11] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num12 = 0; num12 < num; num12++)
			{
				array2[num12] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			if (dataInputStream.available() > 0)
			{
				idShadow = dataInputStream.readByte();
				for (int num13 = 0; num13 < num6; num13++)
				{
					FrameEff frameEff = (FrameEff)listFrame.elementAt(num13);
					frameEff.xShadow = dataInputStream.readByte();
					frameEff.yShadow = dataInputStream.readByte();
				}
			}
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	public Animation getAnim(int action)
	{
		return (Animation)listAnima.elementAt(indexAction[action]);
	}

	public int getFrame(int f, int action, int way)
	{
		Animation animation = (Animation)listAnima.elementAt(indexAction2[way][action]);
		if (f < animation.frame.Length)
		{
			return animation.frame[f];
		}
		return 0;
	}

	public int getFrame(int f, int action)
	{
		Animation animation = (Animation)listAnima.elementAt(indexAction[action]);
		if (f < animation.frame.Length)
		{
			return animation.frame[f];
		}
		return 0;
	}

	public void paint(mGraphics g, int idFrame, int x, int y, int way, mImage img)
	{
		if (img == null)
		{
			return;
		}
		idFrame = 0;
		FrameEff frameEff = (FrameEff)listFrame.elementAt(idFrame);
		try
		{
			for (int i = 0; i < frameEff.listPart.size(); i++)
			{
				PartFrame partFrame = (PartFrame)frameEff.listPart.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				int num = partFrame.dx;
				if (way == 2)
				{
					num = -num - smallImage.w;
				}
				g.drawRegion(img, smallImage.x, smallImage.y, smallImage.w, smallImage.h, way, x + num, y + partFrame.dy, 0, mGraphics.isFalse);
			}
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
	}

	public void paintPet(mGraphics g, int idFrame, int x, int y, int way, mImage img)
	{
		if (img == null)
		{
			return;
		}
		FrameEff frameEff = (FrameEff)listFrame.elementAt(idFrame);
		if (frameEff == null || frameEff.listPartTop == null)
		{
		}
		try
		{
			if (frameEff == null)
			{
				return;
			}
			for (int i = 0; i < frameEff.listPartTop.size(); i++)
			{
				PartFrame partFrame = (PartFrame)frameEff.listPartTop.elementAt(i);
				SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
				int num = partFrame.dx;
				int num2 = smallImage.w;
				int num3 = smallImage.h;
				int num4 = smallImage.x;
				int num5 = smallImage.y;
				if (num4 > mImage.getImageWidth(img.image))
				{
					num4 = 0;
				}
				if (num5 > mImage.getImageHeight(img.image))
				{
					num5 = 0;
				}
				if (num4 + num2 > mImage.getImageWidth(img.image))
				{
					num2 = mImage.getImageWidth(img.image) - num4;
				}
				if (num5 + num3 > mImage.getImageHeight(img.image))
				{
					num3 = mImage.getImageHeight(img.image) - num5;
				}
				if (way == 2)
				{
					num = -num - num2;
				}
				if (partFrame.flip != 1)
				{
					g.drawRegion(img, num4, num5, num2, num3, way, x + num, y + partFrame.dy, 0, useClip: false);
				}
				else
				{
					g.drawRegion(img, num4, num5, num2, num3, (way != 2) ? 2 : 0, x + num, y + partFrame.dy, 0, useClip: false);
				}
			}
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
	}

	public mVector getDataPet()
	{
		mVector result = new mVector();
		mVector mVector3 = (mVector)Pet.PET_DATA.get(string.Empty + idimg);
		if (mVector3 != null)
		{
			result = mVector3;
		}
		return result;
	}

	public Animation getAnim(int action, int way)
	{
		return (Animation)listAnima.elementAt(indexAction2[way][action]);
	}
}
