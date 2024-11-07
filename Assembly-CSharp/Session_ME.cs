using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Session_ME : ISession
{
	public class Sender
	{
		public List<Message> sendingMessage;

		public Sender()
		{
			sendingMessage = new List<Message>();
		}

		public void AddMessage(Message message)
		{
			sendingMessage.Add(message);
		}

		public void run()
		{
			while (connected)
			{
				Message message = new Message();
				try
				{
					if (getKeyComplete)
					{
						while (sendingMessage.Count > 0)
						{
							Message message2 = sendingMessage[0];
							message = message2;
							doSendMessage(message2);
							sendingMessage.RemoveAt(0);
						}
					}
					try
					{
						Thread.Sleep(5);
					}
					catch (Exception ex)
					{
						Cout.LogError(ex.ToString());
					}
				}
				catch (Exception ex2)
				{
					Debug.Log("error send message! " + ex2.ToString());
				}
			}
		}
	}

	private class MessageCollector
	{
		public void run()
		{
			try
			{
				while (connected)
				{
					Message message = readMessage();
					if (message == null)
					{
						break;
					}
					try
					{
						if (message.command == -40)
						{
							getKey(message);
						}
						else
						{
							onRecieveMsg(message);
						}
					}
					catch (Exception)
					{
						Cout.LogError2("LOI NHAN  MESS THU 1");
					}
					try
					{
						Thread.Sleep(5);
					}
					catch (Exception)
					{
						Cout.println("LOI NHAN  MESS THU 2");
					}
				}
			}
			catch (Exception ex3)
			{
				Debug.Log("error read message!");
				Debug.Log(ex3.Message.ToString());
			}
			if (!connected)
			{
				return;
			}
			Debug.Log("error read message!");
			if (messageHandler != null)
			{
				if (currentTimeMillis() - timeConnected > 500)
				{
					messageHandler.onDisconnected();
				}
				else
				{
					messageHandler.onConnectionFail();
				}
			}
			if (sc != null)
			{
				cleanNetwork();
			}
		}

		private void getKey(Message message)
		{
			try
			{
				sbyte b = message.reader().readSByte();
				key = new sbyte[b];
				for (int i = 0; i < b; i++)
				{
					key[i] = message.reader().readSByte();
				}
				for (int j = 0; j < key.Length - 1; j++)
				{
					ref sbyte reference = ref key[j + 1];
					reference ^= key[j];
				}
				getKeyComplete = true;
			}
			catch (Exception)
			{
			}
		}

		private Message readMessage()
		{
			try
			{
				sbyte b = dis.ReadSByte();
				if (getKeyComplete)
				{
					b = readKey(b);
				}
				int num;
				if (getKeyComplete)
				{
					if (b == -51 || b == -52 || b == -54 || b == 126)
					{
						if (b == 126)
						{
							b = dis.ReadSByte();
							b = readKey(b);
						}
						sbyte[] array = new sbyte[4]
						{
							dis.ReadSByte(),
							dis.ReadSByte(),
							dis.ReadSByte(),
							dis.ReadSByte()
						};
						num = (readKey(array[3]) & 0xFF) | ((readKey(array[2]) & 0xFF) << 8) | ((readKey(array[1]) & 0xFF) << 16) | ((readKey(array[0]) & 0xFF) << 24);
					}
					else
					{
						sbyte b2 = dis.ReadSByte();
						sbyte b3 = dis.ReadSByte();
						num = ((readKey(b2) & 0xFF) << 8) | (readKey(b3) & 0xFF);
					}
				}
				else
				{
					sbyte b4 = dis.ReadSByte();
					sbyte b5 = dis.ReadSByte();
					num = (b4 & 0xFF00) | (b5 & 0xFF);
				}
				sbyte[] array2 = new sbyte[num];
				int num2 = 0;
				int num3 = 0;
				byte[] src = dis.ReadBytes(num);
				Buffer.BlockCopy(src, 0, array2, 0, num);
				recvByteCount += 5 + num;
				int num4 = recvByteCount + sendByteCount;
				strRecvByteCount = num4 / 1024 + "." + num4 % 1024 / 102 + "Kb";
				if (getKeyComplete)
				{
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i] = readKey(array2[i]);
					}
				}
				return new Message(b, array2);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.StackTrace.ToString());
			}
			return null;
		}
	}

	protected static Session_ME instance = new Session_ME();

	private static NetworkStream dataStream;

	private static BinaryReader dis;

	private static BinaryWriter dos;

	public static IMessageHandler messageHandler;

	private static TcpClient sc;

	public static bool connected;

	public static bool connecting;

	private static Sender sender = new Sender();

	public static Thread initThread;

	public static Thread collectorThread;

	public static Thread sendThread;

	public static int sendByteCount;

	public static int recvByteCount;

	private static bool getKeyComplete;

	public static sbyte[] key = null;

	private static sbyte curR;

	private static sbyte curW;

	private static int timeConnected;

	public static string strRecvByteCount = string.Empty;

	public static bool isCancel;

	private string host;

	private int port;

	public int timeOut;

	public static mVector recieveMsg = new mVector();

	public Session_ME()
	{
		Debug.Log("init Session_ME");
	}

	public void clearSendingMessage()
	{
		sender.sendingMessage.Clear();
	}

	public static Session_ME gI()
	{
		return instance;
	}

	public bool isConnected()
	{
		return connected;
	}

	public void setHandler(IMessageHandler msgHandler)
	{
		messageHandler = msgHandler;
	}

	public void connect(string host, int port)
	{
		Debug.LogError("connect ...!" + connected + "  ::  " + connecting);
		if (!connected && !connecting)
		{
			this.host = host;
			this.port = port;
			getKeyComplete = false;
			sc = null;
			initThread = new Thread(NetworkInit);
			initThread.Start();
		}
	}

	private void NetworkInit()
	{
		isCancel = false;
		connecting = true;
		Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
		connected = true;
		try
		{
			doConnect(host, port);
			messageHandler.onConnectOK();
		}
		catch (Exception)
		{
			if (messageHandler != null)
			{
				close();
				messageHandler.onConnectionFail();
			}
		}
	}

	public void doConnect(string host, int port)
	{
		timeOut = (int)(mSystem.currentTimeMillis() / 1000);
		sc = new TcpClient();
		sc.Connect(host, port);
		sc.ReceiveBufferSize = 128000;
		dataStream = sc.GetStream();
		dis = new BinaryReader(dataStream, new UTF8Encoding());
		dos = new BinaryWriter(dataStream, new UTF8Encoding());
		new Thread(sender.run).Start();
		MessageCollector @object = new MessageCollector();
		collectorThread = new Thread(@object.run);
		collectorThread.Start();
		timeConnected = currentTimeMillis();
		connecting = false;
		doSendMessage(new Message(-40));
		timeOut = 0;
	}

	public void sendMessage(Message message)
	{
		sender.AddMessage(message);
	}

	private static void doSendMessage(Message m)
	{
		sbyte[] data = m.getData();
		try
		{
			if (getKeyComplete)
			{
				sbyte value = writeKey(m.command);
				dos.Write(value);
			}
			else
			{
				dos.Write(m.command);
			}
			if (data != null)
			{
				int num = data.Length;
				if (getKeyComplete)
				{
					int num2 = writeKey((sbyte)(num >> 8));
					dos.Write((sbyte)num2);
					int num3 = writeKey((sbyte)(num & 0xFF));
					dos.Write((sbyte)num3);
				}
				else
				{
					dos.Write((ushort)num);
				}
				if (getKeyComplete)
				{
					for (int i = 0; i < data.Length; i++)
					{
						sbyte value2 = writeKey(data[i]);
						dos.Write(value2);
					}
				}
				sendByteCount += 5 + data.Length;
			}
			else
			{
				if (getKeyComplete)
				{
					int num4 = 0;
					int num5 = writeKey((sbyte)(num4 >> 8));
					dos.Write((sbyte)num5);
					int num6 = writeKey((sbyte)(num4 & 0xFF));
					dos.Write((sbyte)num6);
				}
				else
				{
					dos.Write((ushort)0);
				}
				sendByteCount += 5;
			}
			dos.Flush();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
		}
	}

	public static sbyte readKey(sbyte b)
	{
		sbyte result = (sbyte)((key[curR++] & 0xFF) ^ (b & 0xFF));
		if (curR >= key.Length)
		{
			curR %= (sbyte)key.Length;
		}
		return result;
	}

	public static sbyte writeKey(sbyte b)
	{
		sbyte result = (sbyte)((key[curW++] & 0xFF) ^ (b & 0xFF));
		if (curW >= key.Length)
		{
			curW %= (sbyte)key.Length;
		}
		return result;
	}

	public static void onRecieveMsg(Message msg)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			messageHandler.onMessage(msg);
		}
		else
		{
			recieveMsg.addElement(msg);
		}
	}

	public static void update()
	{
		if (gI().timeOut != 0 && mSystem.currentTimeMillis() / 1000 - gI().timeOut > 10)
		{
			GlobalLogicHandler.isDisconnect = true;
			gI().timeOut = 0;
			if (sc != null)
			{
				cleanNetwork();
			}
			return;
		}
		while (recieveMsg.size() > 0)
		{
			Message message = (Message)recieveMsg.elementAt(0);
			if (message == null)
			{
				recieveMsg.removeElementAt(0);
				break;
			}
			messageHandler.onMessage(message);
			recieveMsg.removeElementAt(0);
		}
	}

	public void close()
	{
		recieveMsg.removeAllElements();
		cleanNetwork();
	}

	private static void cleanNetwork()
	{
		key = null;
		curR = 0;
		curW = 0;
		try
		{
			connected = false;
			connecting = false;
			if (sc != null)
			{
				sc.Close();
				sc = null;
			}
			if (dataStream != null)
			{
				dataStream.Close();
				dataStream = null;
			}
			if (dos != null)
			{
				dos.Close();
				dos = null;
			}
			if (dis != null)
			{
				dis.Close();
				dis = null;
			}
			sendThread = null;
			collectorThread = null;
		}
		catch (Exception)
		{
		}
	}

	public static int currentTimeMillis()
	{
		return Environment.TickCount;
	}

	public static byte convertSbyteToByte(sbyte var)
	{
		if (var > 0)
		{
			return (byte)var;
		}
		return (byte)(var + 256);
	}

	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if (var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)(var[i] + 256);
			}
		}
		return array;
	}
}
