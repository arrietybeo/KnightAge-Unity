public class FrameEff
{
	public mVector listPart = new mVector();

	public mVector listPartTop = new mVector();

	public mVector listPartBottom = new mVector();

	public sbyte xShadow;

	public int yShadow;

	public FrameEff(mVector list)
	{
		listPart = list;
	}

	public FrameEff(mVector listtop, mVector listbottom)
	{
		listPartTop = listtop;
		listPartBottom = listbottom;
	}
}
