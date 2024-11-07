public class MainImage
{
	public mImage img;

	public short w;

	public short h;

	public int count = -1;

	public int timeImageNull;

	public MainImage()
	{
	}

	public MainImage(mImage im)
	{
		img = im;
		count = 0;
		w = (short)mImage.getImageWidth(im.image);
		h = (short)mImage.getImageWidth(im.image);
	}
}
