public class MiniMapFull_Screen : MainScreen
{
	private int maxX;

	private int maxY;

	private int LimitX;

	private int LimitY;

	private int speedShowX;

	private int speedShowY;

	private int wMini;

	private Camera miniCamera = new Camera();

	private iCommand cmdBack;

	public static int idMap = -1;

	public mImage imgtest;

	private sbyte typeEnd = -1;

	public int fWait;

	private bool canShowMiniMap = true;

	public static MiniMapFull_Screen gI()
	{
		if (GameCanvas.fullMiniMap == null)
		{
			GameCanvas.fullMiniMap = new MiniMapFull_Screen();
		}
		return GameCanvas.fullMiniMap;
	}

	public override void Show()
	{
		canShowMiniMap = true;
		lastScreen = GameCanvas.game;
		MiniMap.isAtMiniMap = false;
		if (Main.isWindowsPhone)
		{
			MiniMap.isStartMiniMap = false;
		}
		init();
		base.Show();
		if (maxX == LimitX && maxY == LimitY)
		{
			canShowMiniMap = false;
		}
	}

	public void init()
	{
		cmdBack = new iCommand(T.back, -1, this);
		maxX = GameCanvas.minimap.maxX;
		maxY = GameCanvas.minimap.maxY;
		LimitX = GameCanvas.loadmap.mapW;
		LimitY = GameCanvas.loadmap.mapH;
		if (LimitX > GameCanvas.w - GameCanvas.hCommand)
		{
			LimitX = GameCanvas.w - GameCanvas.hCommand;
		}
		if (LimitY > GameCanvas.h - GameCanvas.hCommand)
		{
			LimitY = GameCanvas.h - GameCanvas.hCommand;
		}
		speedShowX = (LimitX - maxX) / 5;
		speedShowY = (LimitY - maxY) / 5;
		if (speedShowX <= 0)
		{
			speedShowX = 1;
		}
		if (speedShowY <= 0)
		{
			speedShowY = 1;
		}
		if (GameCanvas.isTouch)
		{
			wMini = 3;
			if (imgtest == null || LoadMap.get_Item().idMap != idMap)
			{
				if (imgtest != null && imgtest.image != null)
				{
					imgtest.image.texture = null;
					mSystem.gcc();
				}
				if (LoadMap.get_Item().idMap != idMap)
				{
					idMap = LoadMap.get_Item().idMap;
				}
				string text = "minimapfull" + idMap + "_" + LoadMap.me.mapW + "_" + LoadMap.me.mapH;
				imgtest = mImage.loadImageRMS(text);
				if (imgtest == null)
				{
					MiniMap.isAtMiniMap = false;
					MiniMap.CreateMiniMap(wMini, (sbyte)(Main.isWindowsPhone ? 1 : 0));
					if (imgtest != null && !Main.isWindowsPhone)
					{
						byte[] byteArray = mSystem.getByteArray(imgtest.image);
						Rms.saveRMS(text, ArrayCast.cast(byteArray));
					}
				}
			}
		}
		else
		{
			wMini = MiniMap.wMini;
			imgtest = MiniMap.imgMiniMap;
		}
		typeEnd = -1;
	}

	public override void commandPointer(int index, int subIndex)
	{
		if (index == -1)
		{
			if (!canShowMiniMap)
			{
				typeEnd = 2;
			}
			else if (typeEnd == 0)
			{
				typeEnd = 1;
			}
		}
	}

	public override void paint(mGraphics g)
	{
		lastScreen.paint(g);
		if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
		{
			GameCanvas.resetTrans(g);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, 60, 1, mGraphics.isFalse);
		}
		if (GameCanvas.isTouch)
		{
			g.translate(GameCanvas.w - maxX * wMini, 0);
		}
		else
		{
			g.translate(GameCanvas.w - maxX * wMini - 3, GameCanvas.h - 23 - maxY * wMini);
		}
		g.setColor(7612434);
		g.fillRect(-3, -3, maxX * wMini + 6, maxY * wMini + 6, mGraphics.isFalse);
		g.setColor(16307052);
		g.fillRect(-2, -2, maxX * wMini + 4, maxY * wMini + 4, mGraphics.isFalse);
		g.setColor(4724752);
		g.fillRect(-1, -1, maxX * wMini + 2, maxY * wMini + 2, mGraphics.isFalse);
		g.setClip(0, 0, maxX * wMini, maxY * wMini);
		if (!MiniMap.isLoadMiniMapOk)
		{
			g.setColor(0);
			g.fillRect(-1, -1, maxX * wMini + 2, maxY * wMini + 2, mGraphics.isFalse);
			MsgDialog.fraWaiting.drawFrame(fWait % MsgDialog.fraWaiting.nFrame, (maxX * wMini + 2) / 2, (maxY * wMini + 4) / 2 - 5, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			return;
		}
		if (MiniMap.isLoadMiniMapOk && !MiniMap.isAtMiniMap)
		{
			if (Main.isWindowsPhone)
			{
				ImageData imgData = MiniMap.getImgData((short)GameCanvas.loadmap.idMap, (short)(GameCanvas.loadmap.idMap + 1000), isThread: false);
				if (imgData != null && !imgData.isLoad && imgData.img != null)
				{
					g.drawImage(imgData.img, 0, 0 + mGraphics.addYWhenOpenKeyBoard, 0, mGraphics.isFalse);
				}
			}
			else if (imgtest != null)
			{
				g.drawImage(imgtest, 0, 0 + mGraphics.addYWhenOpenKeyBoard, 0, mGraphics.isFalse);
			}
			int num = wMini;
			for (int i = 0; i < LoadMap.vecPointChange.size(); i++)
			{
				Point point = (Point)LoadMap.vecPointChange.elementAt(i);
				g.setColor(6156031);
				switch (point.f)
				{
				case 0:
					g.fillRect(point.x * num / LoadMap.wTile - num, point.y * num / LoadMap.wTile - 2 * num, num, num * 4, mGraphics.isFalse);
					break;
				case 1:
					g.fillRect(point.x * num / LoadMap.wTile, point.y * num / LoadMap.wTile - 2 * num, num, num * 4, mGraphics.isFalse);
					break;
				case 2:
					g.fillRect(point.x * num / LoadMap.wTile - 2 * num, point.y * num / LoadMap.wTile, 4 * num, num, mGraphics.isFalse);
					break;
				case 3:
					g.fillRect(point.x * num / LoadMap.wTile - 2 * num, point.y * num / LoadMap.wTile, 4 * num, num, mGraphics.isFalse);
					break;
				}
			}
		}
		if (LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
		{
			for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
			{
				MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(j);
				if (mainObject.typeObject == 1)
				{
					AvMain.fraObjMiniMap.drawFrame(11, mainObject.x / LoadMap.wTile * wMini, mainObject.y / LoadMap.wTile * wMini, 0, 3, g);
				}
			}
		}
		for (int k = 0; k < MiniMap.vecNPC_Map.size(); k++)
		{
			NPCMini nPCMini = (NPCMini)MiniMap.vecNPC_Map.elementAt(k);
			AvMain.fraObjMiniMap.drawFrame(nPCMini.type + 4, nPCMini.x / LoadMap.wTile * wMini, nPCMini.y / LoadMap.wTile * wMini, 0, 3, g);
		}
		AvMain.fraObjMiniMap.drawFrame((GameScreen.player.Action != 4) ? GameScreen.player.Direction : 9, GameScreen.player.x / LoadMap.wTile * wMini, GameScreen.player.y / LoadMap.wTile * wMini, 0, 3, g);
		g.setColor(255);
		if (Player.party != null)
		{
			for (int l = 0; l < Player.party.vecPartys.size(); l++)
			{
				ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(l);
				if (objectParty.name.CompareTo(GameScreen.player.name) != 0 && objectParty.idMap == GameCanvas.loadmap.idMap)
				{
					AvMain.fraObjMiniMap.drawFrame(10, objectParty.x / LoadMap.wTile * wMini, objectParty.y / LoadMap.wTile * wMini, 0, 3, g);
				}
			}
		}
		if (MiniMap.pHelp != null && MiniMap.pHelp.frame == GameCanvas.loadmap.idMap)
		{
			int num2 = MiniMap.pHelp.x;
			int num3 = MiniMap.pHelp.y;
			if (num2 < miniCamera.xCam + 3)
			{
				num2 = miniCamera.xCam + 3;
			}
			if (num2 > miniCamera.xCam + maxX * wMini - 3)
			{
				num2 = miniCamera.xCam + maxX * wMini - 3;
			}
			if (num3 < miniCamera.yCam + 3)
			{
				num3 = miniCamera.yCam + 3;
			}
			if (num3 > miniCamera.yCam + maxY * wMini - 3)
			{
				num3 = miniCamera.yCam + maxY * wMini - 3;
			}
			WorldMapScreen.fraMyPos.drawFrame(GameCanvas.gameTick / 2 % WorldMapScreen.fraMyPos.nFrame, num2, num3, 0, 3, g);
		}
		GameCanvas.resetTrans(g);
		if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
		{
			GameScreen.infoGame.paintSttArena(g, 10, 40, 20, 20);
		}
		GameScreen.infoGame.paintPos_minimap(g, GameCanvas.w, 0);
	}

	public override void update()
	{
		fWait++;
		if (typeEnd == 2)
		{
			lastScreen.Show();
			MiniMap.isAtMiniMap = true;
			if (!Main.isWindowsPhone)
			{
			}
		}
		else if (typeEnd == 1)
		{
			if (maxX > GameCanvas.minimap.maxX)
			{
				maxX -= speedShowX * 2;
				if (maxX <= GameCanvas.minimap.maxX)
				{
					maxX = GameCanvas.minimap.maxX;
					typeEnd = 2;
				}
			}
			if (maxY > GameCanvas.minimap.maxY)
			{
				maxY -= speedShowY * 2;
				if (maxY <= GameCanvas.minimap.maxY)
				{
					maxY = GameCanvas.minimap.maxY;
					typeEnd = 2;
				}
			}
		}
		else
		{
			if (maxX < LimitX)
			{
				maxX += speedShowX;
				if (maxX >= LimitX)
				{
					maxX = LimitX;
					typeEnd = 0;
				}
			}
			if (maxY < LimitY)
			{
				maxY += speedShowY;
				if (maxY >= LimitY)
				{
					maxY = LimitY;
					typeEnd = 0;
				}
			}
		}
		lastScreen.update();
		for (int i = 0; i < GameCanvas.keyMyHold.Length; i++)
		{
			if (GameCanvas.keyMyHold[i])
			{
				cmdBack.perform();
				GameCanvas.clearKeyHold(i);
				break;
			}
		}
	}

	public override void updatePointer()
	{
		if (GameCanvas.isPointerDown)
		{
			cmdBack.perform();
		}
	}
}
