public class LoadData
{
	public int iWpsPlash = -1;

	public int jWpsPlash = -1;

	public int iImgWeaPone = -1;

	public int jImgWeaPone = -1;

	public int indexWeapone = -1;

	public int indexImgEffect = -1;

	public int indexTreeImg = -1;

	public int indexMap = -1;

	public int indexArrow = -1;

	private IAction iaLoadMap;

	public bool isInitGame;

	public sbyte[] byteMap;

	public void loadWpsPlash(int i, int j)
	{
		if (iWpsPlash == -1 && jWpsPlash == -1)
		{
			iWpsPlash = i;
			jWpsPlash = j;
		}
	}

	public void loadImgWeaPone(int i, int j, int index)
	{
		if (iImgWeaPone == -1 && jImgWeaPone == -1)
		{
			iImgWeaPone = i;
			jImgWeaPone = j;
			indexWeapone = index;
		}
	}

	public void run()
	{
		if (iWpsPlash != -1 && jWpsPlash != -1)
		{
			CRes.GetWPSplashInfo(0, iWpsPlash, jWpsPlash);
			iWpsPlash = -1;
			jWpsPlash = -1;
		}
		if (iImgWeaPone != -1 && jImgWeaPone != -1)
		{
			CRes.getImgWeaPone(iImgWeaPone, jImgWeaPone, indexWeapone);
			iImgWeaPone = -1;
			jImgWeaPone = -1;
		}
	}
}
