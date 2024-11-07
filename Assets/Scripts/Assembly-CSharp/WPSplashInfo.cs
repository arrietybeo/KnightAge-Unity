public class WPSplashInfo
{
	public int[][] P0_X;

	public int[][] P0_Y;

	public int[][] PF_X;

	public int[][] PF_Y;

	public int[][] PF_W;

	public int[][] PF_H;

	public mImage image;

	public WPSplashInfo()
	{
		P0_X = mSystem.new_M_Int(4, 8);
		P0_Y = mSystem.new_M_Int(4, 8);
		PF_X = mSystem.new_M_Int(4, 8);
		PF_Y = mSystem.new_M_Int(4, 8);
		PF_W = mSystem.new_M_Int(4, 8);
		PF_H = mSystem.new_M_Int(4, 8);
	}
}
