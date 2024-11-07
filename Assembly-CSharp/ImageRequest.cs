public class ImageRequest
{
	public static mVector vecImageRequest = new mVector("ImageRequest vecImageRequest");

	public long timeRequest;

	public int idRequest;

	public ImageRequest(int id)
	{
		idRequest = id;
		timeRequest = GameCanvas.timeNow;
	}
}
