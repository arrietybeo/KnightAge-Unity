public class PartFrame
{
	public short dx;

	public short dy;

	public sbyte flip;

	public sbyte onTop;

	public sbyte idSmallImg;

	public PartFrame(short dx, short dy, sbyte idSmall)
	{
		idSmallImg = idSmall;
		this.dx = dx;
		this.dy = dy;
	}
}
