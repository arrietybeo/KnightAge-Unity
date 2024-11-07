using System;

public class FrameImage
{
	public int frameWidth;

	public int frameHeight;

	public int nFrame;

	public mImage imgFrame;

	public int Id = -1;

	public int numWidth;

	public int numHeight;

	public static mHashTable HashFrameImageMount = new mHashTable();

	private bool isNgua;

	public FrameImage(mImage img, int width, int height)
	{
		if (img != null)
		{
			imgFrame = img;
			frameWidth = width;
			frameHeight = height;
			nFrame = mImage.getImageHeight(img.image) / height;
		}
	}

	public FrameImage(int ID)
	{
		Id = ID;
		mImage mImage2 = ImageEffect.setImage(ID);
		if (mImage2 != null)
		{
			imgFrame = mImage2;
		}
		frameWidth = EffectSkill.arrInfoEff[ID][0];
		frameHeight = EffectSkill.arrInfoEff[ID][1];
		nFrame = EffectSkill.arrInfoEff[ID][2];
	}

	public FrameImage(mImage img, int numW, int numH, int numNull)
	{
		numWidth = numW;
		numHeight = numH;
		frameWidth = mImage.getImageWidth(img.image) / numW;
		frameHeight = mImage.getImageHeight(img.image) / numH;
		nFrame = numW * numH - numNull;
	}

	public FrameImage(int ID, int numW, int numH, int numNull, int n)
	{
		Id = ID;
		isNgua = true;
		numWidth = numW;
		numHeight = numH;
		mImage im = mImage.createImage("/vantieu/bo.png");
		MainImage mainImage = new MainImage(im);
		if (mainImage != null && mainImage.img != null)
		{
			imgFrame = mainImage.img;
			frameWidth = mImage.getImageWidth(imgFrame.image) / numW;
			frameHeight = mImage.getImageHeight(imgFrame.image) / numH;
			if (imgFrame != null || imgFrame.image != null)
			{
				nFrame = numW * numH - numNull;
			}
		}
	}

	public FrameImage(int ID, int numW, int numH, int numNull)
	{
		Id = ID;
		isNgua = true;
		numWidth = numW;
		numHeight = numH;
		MainImage imageMount = ObjectData.getImageMount((short)ID);
		if (imageMount != null && imageMount.img != null)
		{
			imgFrame = imageMount.img;
			frameWidth = mImage.getImageWidth(imgFrame.image) / numW;
			frameHeight = mImage.getImageHeight(imgFrame.image) / numH;
			if (imgFrame != null || imgFrame.image != null)
			{
				nFrame = numW * numH - numNull;
			}
		}
	}

	public int getNFrame()
	{
		return nFrame;
	}

	public static FrameImage init(string path, int w, int h)
	{
		return new FrameImage(FilePack.getImg(path), w, h);
	}

	public static FrameImage getFrameImageMount(short id, int numW, int numH, int numNull)
	{
		FrameImage frameImage = (FrameImage)HashFrameImageMount.get(string.Empty + id);
		if (frameImage == null)
		{
			frameImage = new FrameImage(id, numW, numH, numNull);
			HashFrameImageMount.put(string.Empty + id, frameImage);
		}
		else if (frameImage.imgFrame == null)
		{
			MainImage imageMount = ObjectData.getImageMount(id);
			if (imageMount != null && imageMount.img != null)
			{
				frameImage.imgFrame = imageMount.img;
				frameImage.numWidth = numW;
				frameImage.numHeight = numH;
				frameImage.frameWidth = mImage.getImageWidth(frameImage.imgFrame.image) / numW;
				frameImage.frameHeight = mImage.getImageHeight(frameImage.imgFrame.image) / numH;
				if (frameImage.imgFrame != null || frameImage.imgFrame.image != null)
				{
					frameImage.nFrame = numW * numH - numNull;
				}
			}
		}
		else
		{
			frameImage.numWidth = numW;
			frameImage.numHeight = numH;
			frameImage.frameWidth = mImage.getImageWidth(frameImage.imgFrame.image) / numW;
			frameImage.frameHeight = mImage.getImageHeight(frameImage.imgFrame.image) / numH;
			if (frameImage.imgFrame != null || frameImage.imgFrame.image != null)
			{
				frameImage.nFrame = numW * numH - numNull;
			}
		}
		return frameImage;
	}

	public void drawFrameNew(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		if (idx >= 0 && idx < nFrame)
		{
			try
			{
				int num = 0;
				int num2 = idx * frameHeight;
				num = idx / numHeight * frameWidth;
				num2 = idx % numHeight * frameHeight;
				g.drawRegion(imgFrame, num, num2, frameWidth, frameHeight, trans, x, y, orthor, mGraphics.isTrue);
			}
			catch (Exception)
			{
			}
		}
	}

	public void drawFrame(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		if (imgFrame == null || imgFrame.image == null)
		{
			mImage mImage2 = ImageEffect.setImage(Id);
			if (mImage2 != null)
			{
				imgFrame = mImage2;
			}
			if (mImage2.image != null)
			{
				nFrame = mImage.getImageHeight(imgFrame.image) / frameHeight;
			}
		}
		else if (idx >= 0 && idx < nFrame)
		{
			g.drawRegion(imgFrame, 0, idx * frameHeight, frameWidth, frameHeight, trans, x, y, orthor, mGraphics.isTrue);
		}
	}

	public void drawFrameEffectSkill(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		mImage mImage2 = ImageEffect.setImage(Id);
		if (mImage2 != null && mImage2.image != null)
		{
			if (idx > nFrame)
			{
				idx = nFrame;
			}
			int num = idx * frameHeight;
			if (num > frameHeight * (nFrame - 1) || num < 0)
			{
				num = frameHeight * (nFrame - 1);
			}
			g.drawRegion(mImage2, 0, num, frameWidth, frameHeight, trans, x, y, orthor, mGraphics.isTrue);
		}
	}

	public void drawFrameEffectSkill1(int idx, int x, int y, int trans, mGraphics g)
	{
		mImage mImage2 = ImageEffect.setImage(Id);
		if (mImage2 != null && mImage2.image != null)
		{
			if (idx > nFrame)
			{
				idx = nFrame;
			}
			int num = idx * frameHeight;
			if (num > frameHeight * (nFrame - 1) || num < 0)
			{
				num = frameHeight * (nFrame - 1);
			}
			g.drawRegion(mImage2, 0, num, frameWidth, frameHeight, trans, x, y, 0, mGraphics.isTrue);
		}
	}

	public void drawFrame(int idx, int x, int y, int trans, mGraphics g)
	{
		if (imgFrame == null || imgFrame.image == null)
		{
			mImage mImage2 = ImageEffect.setImage(Id);
			if (mImage2 != null)
			{
				imgFrame = mImage2;
			}
			if (imgFrame.image != null)
			{
				nFrame = mImage.getImageHeight(imgFrame.image) / frameHeight;
			}
		}
		else if (idx >= 0 && idx < nFrame)
		{
			g.drawRegion(imgFrame, 0, idx * frameHeight, frameWidth, frameHeight, trans, x, y, 0, mGraphics.isTrue);
		}
	}

	public void drawFrameXY(int idx, int idy, int x, int y, mGraphics g)
	{
		if (imgFrame == null)
		{
			mImage mImage2 = ImageEffect.setImage(Id);
			if (mImage2 != null)
			{
				imgFrame = mImage2;
			}
			if (imgFrame.image != null)
			{
				nFrame = mImage.getImageHeight(imgFrame.image) / frameHeight;
			}
		}
		else if (idx >= 0 && idx < nFrame)
		{
			g.drawRegion(imgFrame, idx * frameWidth, idy * frameHeight, frameWidth, frameHeight, 0, x, y, 0, mGraphics.isTrue);
		}
	}
}
