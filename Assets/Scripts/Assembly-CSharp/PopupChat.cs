using System;

public class PopupChat : AvMain
{
	private int x = GameCanvas.hw;

	private int y = GameCanvas.hh;

	private int dy;

	public int h;

	public int w;

	public int timeOff;

	public int indexpaint;

	public string[] strChat;

	public static mImage[] mPopup = new mImage[2];

	private bool isStop = true;

	public string name;

	private new int[] color = new int[2] { 3349556, 16760428 };

	public void setChat(string strContent, bool isStop)
	{
		this.isStop = isStop;
		strContent = strContent.Trim();
		w = mFont.tahoma_7_black.getWidth(strContent);
		if (w > 100)
		{
			w = 100;
		}
		else if (w < 20)
		{
			w = 20;
		}
		dy = 8;
		name = strContent;
		strChat = mFont.tahoma_7_black.splitFontArray(strContent, w);
		h = strChat.Length * GameCanvas.hText;
		if (strChat.Length <= 2)
		{
			timeOff = 80;
		}
		else
		{
			timeOff = 140;
		}
	}

	public override void paint(mGraphics g)
	{
		if (dy > 0)
		{
			dy -= 2;
		}
		paintPopup(g);
	}

	public void updatePos(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public bool setOff()
	{
		timeOff--;
		if (timeOff <= 0 && isStop)
		{
			return true;
		}
		return false;
	}

	public void paintPopup(mGraphics g)
	{
		try
		{
			int num = y - h + dy;
			int num2 = x - w / 2;
			g.setColor(color[0]);
			g.fillRect(num2 - 3, num, w + 6, h, mGraphics.isTrue);
			g.fillRect(num2, num - 3, w, h + 6, mGraphics.isTrue);
			g.setColor(color[1]);
			g.fillRect(num2, num - 2, w, h + 4, mGraphics.isTrue);
			g.fillRect(num2 - 2, num, w + 4, h, mGraphics.isTrue);
			g.drawRegion(mPopup[0], 0, 0, 3, 3, 0, num2 - 3, num - 3, 0, mGraphics.isTrue);
			g.drawRegion(mPopup[0], 0, 3, 3, 3, 0, num2 + w, num - 3, 0, mGraphics.isTrue);
			g.drawRegion(mPopup[0], 0, 9, 3, 3, 0, num2 - 3, num + h, 0, mGraphics.isTrue);
			g.drawRegion(mPopup[0], 0, 6, 3, 3, 0, num2 + w, num + h, 0, mGraphics.isTrue);
			if (indexpaint == 1)
			{
				g.drawRegion(mPopup[1], 0, 0, 7, 7, 3, num2 + w / 2 - 3, num - 9, 0, mGraphics.isTrue);
			}
			else
			{
				g.drawImage(mPopup[1], num2 + w / 2 - 3, num + h + 2, 0, mGraphics.isTrue);
			}
			if (strChat != null)
			{
				for (int i = 0; i < strChat.Length; i++)
				{
					mFont.tahoma_7_black.drawString(g, strChat[i], num2 + w / 2, num + 1 + i * GameCanvas.hText, 2, mGraphics.isTrue);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
