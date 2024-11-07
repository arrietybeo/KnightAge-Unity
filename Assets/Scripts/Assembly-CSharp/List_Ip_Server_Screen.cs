public class List_Ip_Server_Screen : MainScreen
{
	private int x;

	private int y;

	private int w;

	private int h;

	private int idSelect;

	private int hItem;

	private MainList list;

	private mVector vecChoice = new mVector("List_Ip_Server_Screen vecchoice");

	public List_Ip_Server_Screen()
	{
		LogoScreen.getServerList(LogoScreen.strListserver, isFrist: false);
		hItem = GameCanvas.hCommand;
		w = GameCanvas.w - 20;
		if (w > 180)
		{
			w = 180;
		}
		h = GameCanvas.listServer.GetLength(0) * hItem;
		int limX = 0;
		if (h > GameCanvas.h / 5 * 4)
		{
			limX = h - GameCanvas.h / 5 * 4;
			h = GameCanvas.h / 5 * 4;
		}
		x = GameCanvas.hw - w / 2;
		y = GameCanvas.hh - h / 2 + hItem / 2;
		vecChoice.removeAllElements();
		for (int i = 0; i < GameCanvas.listServer.GetLength(0); i++)
		{
			vecChoice.addElement(new iCommand(GameCanvas.listServer[i, 0], 0, i, this));
		}
		if (GameCanvas.isTouch)
		{
			idSelect = -1;
		}
		list = new MainList(x, y, w, h, hItem, GameCanvas.listServer.GetLength(0), limX, idSelect, vecChoice);
	}

	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			return;
		}
		if (Session_ME.connected)
		{
			Session_ME.gI().close();
		}
		GameCanvas.IndexServer = (sbyte)subIndex;
		GameCanvas.login.Show();
		bool isVN_Eng = GameCanvas.isVN_Eng;
		GameCanvas.isVN_Eng = GameCanvas.langServer[GameCanvas.IndexServer] == 0;
		if (GameCanvas.isVN_Eng != isVN_Eng)
		{
			LogoScreen.setChangeLang();
			GameCanvas.start_Ok_Dialog(T.TchangSv);
		}
		if (GameCanvas.isVN_Eng)
		{
			LoginScreen.isPaintHotLine = true;
		}
		else if (IndoServer.isIndoSv)
		{
			LoginScreen.isPaintHotLine = false;
		}
		if (Usa_Server.isUsa_server)
		{
			LoginScreen.isPaintHotLine = false;
			if (GameCanvas.IndexServer == 0)
			{
				GameCanvas.t = new TE();
			}
			else if (GameCanvas.IndexServer == 1)
			{
				GameCanvas.t = new TSpain();
			}
			mSystem.doChangeMenuNapapple();
		}
		GameCanvas.login.checkLoginAgain(GameCanvas.IndexServer);
	}

	public override void paint(mGraphics g)
	{
		BackGround.paint(g);
		BackGround.paintLight(g);
		paintFormList(g, x, y - hItem, w, h + hItem, T.listserver);
		g.setClip(x, y, w, h);
		g.translate(0, -list.cmx);
		if (idSelect > -1)
		{
			paintFocus(g);
		}
		for (int i = 0; i < vecChoice.size(); i++)
		{
			iCommand iCommand2 = (iCommand)vecChoice.elementAt(i);
			mFont.tahoma_7b_white.drawString(g, iCommand2.caption, x + w / 2, y + hItem / 2 + i * hItem - 6, 2, mGraphics.isTrue);
			if (i < vecChoice.size() - 1)
			{
				g.setColor(AvMain.color[4]);
				g.fillRect(x + 8, y + (i + 1) * hItem - 1, w - 16, 1, mGraphics.isTrue);
			}
		}
		if (PaintInfoGameScreen.paint18plush == 0)
		{
			g.drawImage(AvMain.img18Plus, 0, 0, 0, mGraphics.isFalse);
		}
		else if (PaintInfoGameScreen.paint18plush == 1)
		{
			PaintInfoGameScreen.paintinfo18plush(g);
		}
	}

	public void paintFocus(mGraphics g)
	{
		g.setColor(13088156);
		g.fillRect(x + 5, y + idSelect * hItem + hItem / 2 - 11, w - 10, 22, mGraphics.isFalse);
	}

	public override void update()
	{
		list.updateMenu();
		idSelect = list.value;
		if (idSelect >= vecChoice.size())
		{
			idSelect = -1;
			list.value = -1;
		}
	}
}
