public class Load_Data_And_Img
{
	public class LoadData
	{
		private int iWpsPlash = -1;

		private int jWpsPlash = -1;

		private int iImgWeaPone = -1;

		private int jImgWeaPone = -1;

		private int indexWeapone = -1;

		private int indexImgEffect = -1;

		private int indexTreeImg = -1;

		private int indexMap = -1;

		private int indexArrow = -1;

		private IAction iaLoadMap;

		public bool isInitGame;

		public byte[] byteMap;

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

	public static LoadData load = new LoadData();
}
