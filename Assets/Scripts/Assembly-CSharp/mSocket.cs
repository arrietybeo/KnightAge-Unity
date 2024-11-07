using System.IO;
using System.Net.Sockets;

public class mSocket
{
	private TcpClient s;

	public mSocket(string host, int port)
	{
		try
		{
			s = new TcpClient();
			s.Connect(host, port);
		}
		catch (IOException)
		{
		}
	}

	public void close()
	{
		try
		{
			s.Close();
		}
		catch (IOException)
		{
		}
	}

	public void setKeepAlive(bool isAlive)
	{
	}

	public NetworkStream getOutputStream()
	{
		try
		{
			return s.GetStream();
		}
		catch (IOException)
		{
		}
		return null;
	}

	public NetworkStream getInputStream()
	{
		try
		{
			return s.GetStream();
		}
		catch (IOException)
		{
		}
		return null;
	}
}
