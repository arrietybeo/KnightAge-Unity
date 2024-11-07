using System;

public class TabLottery : MainTabNew
{
	public const sbyte SECTION_CHOOSE_REWARD = 0;

	public const sbyte SECTION_LOTTERY_DRAWING = 1;

	private const int AT_DESTINATION_LIMIT = 20;

	private const int MAX_MOVE_COUNT = 30;

	private const int MAX_VELO = 16;

	private int maxw;

	private int maxh;

	private int indexPaint = 12;

	private int winfo = 140;

	private int numW = 6;

	private int numH = 6;

	private int numHPaint;

	private int maxSize = 60;

	private int hcmd;

	private int moveCount;

	private int selectIdx;

	private int curSelectPointerIdx;

	private int itemIdSelect;

	public static bool isWin = false;

	public static bool isReady = false;

	private static bool waitForNewPlay = false;

	private static bool beginDraw = false;

	private bool endDraw;

	private bool moveDone;

	private mVector2[] posArray;

	private mVector2[] objPosArray;

	private mVector2[] fixPosArray;

	private mVector2 rewardPos;

	private static iCommand cmdStartDraw;

	private static iCommand cmdGetItem;

	private static iCommand cmdRepick;

	private static iCommand cmdContinue;

	private static iCommand cmdSelectGlass;

	private static mVector vecListCmd = new mVector("TabLottery vecListCmd");

	private mVector vecEffEnd = new mVector("TabLottery vecEffEnd");

	private mVector vecRewardList = new mVector("TabLottery vecRewardList");

	private int[] ranIdx = new int[4] { -1, -1, -1, -1 };

	private mVector2 moveVec1;

	private mVector2 moveVec2;

	private mVector2 moveVec3;

	private mVector2 moveVec4;

	private float velocity;

	private float acceleration;

	private float itemVel;

	private int test_posX;

	private int test_posY;

	private static sbyte sectionType = 0;

	private static sbyte luckyNumber = -1;

	private int selectNumber;

	private ListNew list;

	public TabLottery(string name, mVector rewards, sbyte type)
	{
		nameTab = name;
		endDraw = false;
		moveDone = true;
		moveCount = 0;
		velocity = 0f;
		acceleration = 1f;
		itemVel = 1f;
		selectIdx = -1;
		curSelectPointerIdx = -1;
		selectNumber = -1;
		vecRewardList = rewards;
		typeTab = MainTabNew.INVENTORY;
		waitForNewPlay = false;
		sectionType = type;
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem;
		maxw = (MainTabNew.wblack - 8) / 32;
		maxh = (MainTabNew.hblack - 8) / 32;
		fixPosArray = new mVector2[5];
		fixPosArray[0] = new mVector2(xBegin + MainTabNew.wblack / 2 - 52, yBegin + MainTabNew.hblack / 2 - 16);
		fixPosArray[1] = new mVector2(xBegin + MainTabNew.wblack / 2 - 32, yBegin + MainTabNew.hblack / 2 + 45);
		fixPosArray[2] = new mVector2(xBegin + MainTabNew.wblack / 2 + 32, yBegin + MainTabNew.hblack / 2 + 45);
		fixPosArray[3] = new mVector2(xBegin + MainTabNew.wblack / 2 + 52, yBegin + MainTabNew.hblack / 2 - 16);
		fixPosArray[4] = new mVector2(xBegin + MainTabNew.wblack / 2, yBegin + MainTabNew.hblack / 2 - 52);
		posArray = new mVector2[5];
		posArray[0] = new mVector2(xBegin + MainTabNew.wblack / 2 - 52, yBegin + MainTabNew.hblack / 2 - 16);
		posArray[1] = new mVector2(xBegin + MainTabNew.wblack / 2 - 32, yBegin + MainTabNew.hblack / 2 + 45);
		posArray[2] = new mVector2(xBegin + MainTabNew.wblack / 2 + 32, yBegin + MainTabNew.hblack / 2 + 45);
		posArray[3] = new mVector2(xBegin + MainTabNew.wblack / 2 + 52, yBegin + MainTabNew.hblack / 2 - 16);
		posArray[4] = new mVector2(xBegin + MainTabNew.wblack / 2, yBegin + MainTabNew.hblack / 2 - 52);
		objPosArray = new mVector2[5];
		objPosArray[0] = new mVector2(xBegin + MainTabNew.wblack / 2 - 52, yBegin + MainTabNew.hblack / 2 - 16);
		objPosArray[1] = new mVector2(xBegin + MainTabNew.wblack / 2 - 32, yBegin + MainTabNew.hblack / 2 + 45);
		objPosArray[2] = new mVector2(xBegin + MainTabNew.wblack / 2 + 32, yBegin + MainTabNew.hblack / 2 + 45);
		objPosArray[3] = new mVector2(xBegin + MainTabNew.wblack / 2 + 52, yBegin + MainTabNew.hblack / 2 - 16);
		objPosArray[4] = new mVector2(xBegin + MainTabNew.wblack / 2, yBegin + MainTabNew.hblack / 2 - 52);
		rewardPos = new mVector2(xBegin + MainTabNew.wblack / 2, yBegin + MainTabNew.hblack / 2);
		cmdStartDraw = new iCommand(T.startdraw, 0, this);
		cmdGetItem = new iCommand(T.select, 1, this);
		cmdRepick = new iCommand(T.chonlai, 2, this);
		cmdContinue = new iCommand(T.choitiep, 4, this);
		cmdSelectGlass = new iCommand(T.select, 3, this);
		cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			cmdBack.caption = T.close;
		}
		if (MainTabNew.longwidth > 0)
		{
			int num = MainTabNew.ylongwidth + hSmall;
			int num2 = MainTabNew.xlongwidth;
			if (MainTabNew.is320)
			{
				cmdStartDraw.setPos(num2 + MainTabNew.longwidth / 2, num - 10, PaintInfoGameScreen.fraButton2, cmdStartDraw.caption);
				cmdGetItem.setPos(num2 + MainTabNew.longwidth / 2, num - 10, PaintInfoGameScreen.fraButton2, cmdGetItem.caption);
				cmdRepick.setPos(num2 + MainTabNew.longwidth / 2 - 30, num - 10, PaintInfoGameScreen.fraButton2, cmdRepick.caption);
				cmdContinue.setPos(num2 + MainTabNew.longwidth / 2 + 30, num - 10, PaintInfoGameScreen.fraButton2, cmdContinue.caption);
			}
			else
			{
				cmdStartDraw.setPos(num2 + MainTabNew.longwidth / 2, num - 15, null, cmdStartDraw.caption);
				cmdGetItem.setPos(num2 + MainTabNew.longwidth / 2, num - 15, null, cmdGetItem.caption);
				cmdRepick.setPos(num2 + MainTabNew.longwidth / 2 - 42, num - 15, null, cmdRepick.caption);
				cmdContinue.setPos(num2 + MainTabNew.longwidth / 2 + 42, num - 15, null, cmdContinue.caption);
			}
		}
		else if (GameCanvas.isTouch)
		{
			cmdStartDraw.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdStartDraw.caption);
			cmdGetItem.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdGetItem.caption);
			cmdRepick.setPos(iCommand.wButtonCmd / 2 + 2 - 42, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdRepick.caption);
			cmdContinue.setPos(iCommand.wButtonCmd / 2 + 2 + 42, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, cmdContinue.caption);
		}
		init();
	}

	public static void changeSection(sbyte section)
	{
		sectionType = section;
		setCommand();
	}

	public static void setLuckyNumber(sbyte number)
	{
		luckyNumber = number;
	}

	private static void setCommand()
	{
		if (GameCanvas.isTouch)
		{
			vecListCmd.removeAllElements();
			if (sectionType == 0)
			{
				vecListCmd.addElement(cmdGetItem);
			}
			else if (waitForNewPlay)
			{
				vecListCmd.addElement(cmdRepick);
				vecListCmd.addElement(cmdContinue);
			}
			else if (!beginDraw)
			{
				vecListCmd.addElement(cmdStartDraw);
			}
		}
	}

	public new void init()
	{
		list = new ListNew(xBegin, yBegin, MainTabNew.wblack, MainTabNew.hblack, 0, 0, MainScreen.cameraSub.yLimit);
		setCommand();
		if (!GameCanvas.isTouch)
		{
			center = cmdGetItem;
			right = cmdBack;
		}
		vecEffEnd.removeAllElements();
		imgStarRebuild = mImage.createImage("/interface/rebuild.img");
	}

	public override void paint(mGraphics g)
	{
		if (sectionType == 0)
		{
			paintChooseRewardSection(g);
		}
		else if (sectionType == 1)
		{
			paintDrawingSection(g);
		}
	}

	private void paintChooseRewardSection(mGraphics g)
	{
		try
		{
			GameCanvas.resetTrans(g);
			g.setClip(xBegin - MainTabNew.wOne5, yBegin, MainTabNew.wblack + MainTabNew.wOne5 * 2, MainTabNew.hblack - MainTabNew.wOne5 / 2 + 1);
			g.translate(-MainScreen.cameraSub.xCam, -MainScreen.cameraSub.yCam);
			for (int i = 0; i < vecRewardList.size(); i++)
			{
				Item item = (Item)vecRewardList.elementAt(i);
				if (item == null)
				{
					continue;
				}
				if (item.ItemCatagory == 7)
				{
					MainItem material = Item.getMaterial(item.Id);
					if (material != null)
					{
						item.setinfo(material.itemName, material.imageId, 7, material.priceItem, material.priceType, material.content, (short)material.value, material.typeMaterial, 1, material.canSell, material.canTrade);
						item.paintItem(g, xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem, MainTabNew.wOneItem, 0, 0);
						if (item.timeUse > 0)
						{
							g.drawRegion(AvMain.imgDelaySkill, 0, 0, MainTabNew.wOneItem - 1, MainTabNew.wOneItem - 1, 0, xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem, 3, mGraphics.isTrue);
						}
					}
					else
					{
						Item.put_Material(item.Id);
					}
				}
				else
				{
					item.paintItem(g, xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem, MainTabNew.wOneItem, 0, 0);
					if (item.timeUse > 0)
					{
						g.drawRegion(AvMain.imgDelaySkill, 0, 0, MainTabNew.wOneItem - 1, MainTabNew.wOneItem - 1, 0, xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem, 3, mGraphics.isTrue);
					}
				}
			}
			g.setColor(MainTabNew.color[1]);
			g.drawRect(xBegin, yBegin, MainTabNew.wblack, MainTabNew.wOneItem * numH, mGraphics.isTrue);
			for (int j = 0; j < numW / 2; j++)
			{
				g.drawRect(xBegin + MainTabNew.wOneItem + j * MainTabNew.wOneItem * 2, yBegin, MainTabNew.wOneItem, MainTabNew.wOneItem * numH, mGraphics.isTrue);
			}
			for (int k = 0; k < numH / 2; k++)
			{
				g.drawRect(xBegin, yBegin + MainTabNew.wOneItem + k * MainTabNew.wOneItem * 2, MainTabNew.wblack, MainTabNew.wOneItem, mGraphics.isTrue);
			}
			if (itemIdSelect > -1 && MainTabNew.Focus == MainTabNew.INFO)
			{
				g.setColor(MainTabNew.color[2]);
				g.drawRect(xBegin + itemIdSelect % numW * MainTabNew.wOneItem + 1, yBegin + itemIdSelect / numW * MainTabNew.wOneItem + 1, MainTabNew.wOneItem - 2, MainTabNew.wOneItem - 2, mGraphics.isTrue);
				g.setColor(MainTabNew.color[3]);
				g.drawRect(xBegin + itemIdSelect % numW * MainTabNew.wOneItem, yBegin + itemIdSelect / numW * MainTabNew.wOneItem, MainTabNew.wOneItem, MainTabNew.wOneItem, mGraphics.isTrue);
			}
			g.endClip();
			if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null || GameCanvas.subDialog != null || MainTabNew.Focus != MainTabNew.INFO || MainTabNew.timePaintInfo <= MainTabNew.timeRequest)
			{
				return;
			}
			paintPopupContent(g, isOnlyName: false);
			if (vecListCmd != null)
			{
				for (int l = 0; l < vecListCmd.size(); l++)
				{
					iCommand iCommand2 = (iCommand)vecListCmd.elementAt(l);
					iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void paintDrawingSection(mGraphics g)
	{
		try
		{
			g.fillRect(xBegin + 2, yBegin + 2, MainTabNew.wblack - 4, MainTabNew.hblack - 4, mGraphics.isTrue);
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, xBegin + 4, yBegin + 4, MainTabNew.wblack - 8, MainTabNew.hblack - 8, 4);
			}
			else
			{
				paintRect(g);
			}
			g.drawImage(imgStarRebuild, xBegin + MainTabNew.wblack / 2 - 54, yBegin + MainTabNew.hblack / 2 - 52, 0, mGraphics.isTrue);
			g.drawRegion(imgStarRebuild, 0, 0, 54, 105, 2, xBegin + MainTabNew.wblack / 2, yBegin + MainTabNew.hblack / 2 - 52, 0, mGraphics.isTrue);
			Item item = (Item)vecRewardList.elementAt(itemIdSelect);
			if (!isReady && item != null)
			{
				g.drawImage(AvMain.imgHotKey, (int)rewardPos.x, (int)rewardPos.y, 3, mGraphics.isTrue);
				item.paintItem(g, (int)rewardPos.x, (int)rewardPos.y, 20, 0, 0);
			}
			for (int i = 0; i < objPosArray.Length; i++)
			{
				if (selectNumber == -1)
				{
					g.drawImage(AvMain.imgGlass, (int)objPosArray[i].x, (int)objPosArray[i].y, 3, mGraphics.isTrue);
				}
				else if (isWin)
				{
					if (luckyNumber == i)
					{
						g.drawImage(AvMain.imgHotKey, (int)fixPosArray[i].x, (int)fixPosArray[i].y, 3, mGraphics.isTrue);
						item.paintItem(g, (int)fixPosArray[i].x, (int)fixPosArray[i].y, 20, 0, 0);
					}
					else
					{
						g.drawImage(AvMain.imgGlass, (int)fixPosArray[i].x, (int)fixPosArray[i].y, 3, mGraphics.isTrue);
					}
				}
				else if (luckyNumber == i)
				{
					g.drawImage(AvMain.imgHotKey, (int)fixPosArray[i].x, (int)fixPosArray[i].y, 3, mGraphics.isTrue);
					item.paintItem(g, (int)fixPosArray[i].x, (int)fixPosArray[i].y, 20, 0, 0);
				}
				else
				{
					if (selectNumber == i)
					{
						continue;
					}
					g.drawImage(AvMain.imgGlass, (int)fixPosArray[i].x, (int)fixPosArray[i].y, 3, mGraphics.isTrue);
				}
				if (!GameCanvas.isTouch && endDraw && curSelectPointerIdx > -1)
				{
					if (MainObject.Wfc == 0)
					{
						MainObject.Wfc = mImage.getImageWidth(MainObject.newfocus.image);
						MainObject.Hfc = mImage.getImageHeight(MainObject.newfocus.image) / 10;
					}
					g.drawRegion(MainObject.newfocus, 0, 0, MainObject.Wfc, MainObject.Hfc, 0, (int)fixPosArray[curSelectPointerIdx].x, (int)fixPosArray[curSelectPointerIdx].y - GameCanvas.gameTick % 5 - 10, 3, mGraphics.isTrue);
				}
			}
			for (int j = 0; j < vecEffEnd.size(); j++)
			{
				MainEffect mainEffect = (MainEffect)vecEffEnd.elementAt(j);
				mainEffect.paint(g);
			}
			if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && (MainTabNew.Focus == MainTabNew.INFO || MainTabNew.longwidth > 0) && vecListCmd != null)
			{
				for (int k = 0; k < vecListCmd.size(); k++)
				{
					iCommand iCommand2 = (iCommand)vecListCmd.elementAt(k);
					iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void paintRect(mGraphics g)
	{
		for (int i = 0; i <= maxw; i++)
		{
			for (int j = 0; j <= maxh; j++)
			{
				indexPaint = 12;
				if (j == 0)
				{
					indexPaint = 12;
				}
				if (i == maxw)
				{
					if (j == maxh)
					{
						g.drawImage(MainTabNew.imgTab[indexPaint], xBegin + 4 + (MainTabNew.wblack - 8) - 32, yBegin + 4 + MainTabNew.hblack - 8 - 32, 0, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[indexPaint], xBegin + 4 + (MainTabNew.wblack - 8) - 32, yBegin + 4 + j * 32, 0, mGraphics.isTrue);
					}
				}
				else if (j == maxh)
				{
					g.drawImage(MainTabNew.imgTab[indexPaint], xBegin + 4 + i * 32, yBegin + 4 + MainTabNew.hblack - 8 - 32, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[indexPaint], xBegin + 4 + i * 32, yBegin + 4 + j * 32, 0, mGraphics.isTrue);
				}
			}
		}
	}

	public override void update()
	{
		try
		{
			if (sectionType == 0)
			{
				if (MainTabNew.Focus == MainTabNew.INFO)
				{
					if (listContent != null)
					{
						listContent.moveCamera();
					}
					if (GameCanvas.isTouch)
					{
						list.moveCamera();
					}
					else
					{
						MainScreen.cameraSub.UpdateCamera();
					}
					mVector mVector3 = vecRewardList;
					if (mVector3.size() == 0)
					{
						MainTabNew.Focus = MainTabNew.TAB;
					}
					else
					{
						updateContent(mVector3, itemIdSelect);
					}
				}
				else
				{
					MainTabNew.timePaintInfo = 0;
				}
			}
			else
			{
				if (sectionType != 1)
				{
					return;
				}
				for (int i = 0; i < vecEffEnd.size(); i++)
				{
					MainEffect mainEffect = (MainEffect)vecEffEnd.elementAt(i);
					mainEffect.update();
					if (mainEffect.isStop)
					{
						vecEffEnd.removeElement(mainEffect);
					}
				}
				if (selectIdx > -1)
				{
					EffectEnd o = new EffectEnd(34, (int)fixPosArray[selectIdx].x, (int)fixPosArray[selectIdx].y);
					vecEffEnd.addElement(o);
					GlobalService.gI().request_LotteryItems(2, (sbyte)selectIdx);
					selectNumber = selectIdx;
					selectIdx = -1;
					endDraw = false;
					waitForNewPlay = true;
					setCommand();
				}
				if (!isReady)
				{
					mVector2 mVector4 = mVector2.substract(rewardPos, posArray[luckyNumber]);
					mVector4.normalize();
					itemVel += 0.5f;
					rewardPos.add(mVector4.x * itemVel, mVector4.y * itemVel);
					if (atDestination(rewardPos, posArray[luckyNumber]))
					{
						luckyNumber = -1;
						isReady = true;
					}
				}
				if (moveCount >= 30)
				{
					beginDraw = false;
				}
				if (!beginDraw)
				{
					return;
				}
				GameCanvas.isPointerSelect = false;
				if (moveDone)
				{
					int num = 0;
					int num2 = 2;
					if (moveCount > 16)
					{
						num = CRes.random(0, 2);
					}
					num2 = ((num != 0) ? 4 : 2);
					int num3 = 0;
					while (num3 < num2)
					{
						bool flag = false;
						int num4 = CRes.random(0, 5);
						for (int j = 0; j < ranIdx.Length; j++)
						{
							if (num4 == ranIdx[j])
							{
								flag = true;
							}
						}
						if (!flag)
						{
							ranIdx[num3] = num4;
							num3++;
						}
					}
					moveVec1 = mVector2.substract(objPosArray[ranIdx[0]], objPosArray[ranIdx[1]]);
					moveVec2 = mVector2.substract(objPosArray[ranIdx[1]], objPosArray[ranIdx[0]]);
					moveVec1.normalize();
					moveVec2.normalize();
					if (ranIdx[2] > -1 && ranIdx[3] > -1)
					{
						moveVec3 = mVector2.substract(objPosArray[ranIdx[2]], objPosArray[ranIdx[3]]);
						moveVec4 = mVector2.substract(objPosArray[ranIdx[3]], objPosArray[ranIdx[2]]);
						moveVec3.normalize();
						moveVec4.normalize();
					}
					moveDone = false;
					velocity = ((moveCount >= 16) ? 16 : moveCount);
					return;
				}
				if (velocity < 16f)
				{
					velocity += acceleration;
				}
				objPosArray[ranIdx[0]].add(moveVec1.x * velocity, moveVec1.y * velocity);
				objPosArray[ranIdx[1]].add(moveVec2.x * velocity, moveVec2.y * velocity);
				if (ranIdx[2] > -1 && ranIdx[3] > -1)
				{
					objPosArray[ranIdx[2]].add(moveVec3.x * velocity, moveVec3.y * velocity);
					objPosArray[ranIdx[3]].add(moveVec4.x * velocity, moveVec4.y * velocity);
				}
				if (!atDestination(objPosArray[ranIdx[0]], posArray[ranIdx[1]]))
				{
					return;
				}
				objPosArray[ranIdx[0]].set(posArray[ranIdx[1]]);
				objPosArray[ranIdx[1]].set(posArray[ranIdx[0]]);
				posArray[ranIdx[0]].set(objPosArray[ranIdx[0]]);
				posArray[ranIdx[1]].set(objPosArray[ranIdx[1]]);
				if (ranIdx[2] > -1 && ranIdx[3] > -1)
				{
					objPosArray[ranIdx[2]].set(posArray[ranIdx[3]]);
					objPosArray[ranIdx[3]].set(posArray[ranIdx[2]]);
					posArray[ranIdx[2]].set(objPosArray[ranIdx[2]]);
					posArray[ranIdx[3]].set(objPosArray[ranIdx[3]]);
				}
				if (moveCount == 29)
				{
					endDraw = true;
					curSelectPointerIdx = 0;
					if (!GameCanvas.isTouch)
					{
						center = cmdSelectGlass;
					}
				}
				moveDone = true;
				moveCount++;
				for (int k = 0; k < ranIdx.Length; k++)
				{
					ranIdx[k] = -1;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void updateContent(mVector vec, int idSelect)
	{
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				setPaintInfo();
			}
		}
		if (mContent != null || idSelect < 0 || idSelect >= vec.size())
		{
			return;
		}
		Item item = (Item)vec.elementAt(idSelect);
		if (item.ItemCatagory == 5)
		{
			return;
		}
		if (item.mcontent == null)
		{
			if (item.timeupdateMore % 100 == 3)
			{
				if (typeTab == MainTabNew.INVENTORY)
				{
					GlobalService.gI().Item_More_Info(0, (sbyte)item.Id);
				}
				item.timeupdateMore++;
			}
			else
			{
				item.timeupdateMore++;
			}
		}
		else
		{
			mContent = item.mcontent;
			mcolor = item.mColor;
			setYCon(item);
		}
	}

	public new void setYCon(Item item)
	{
		int num = 0;
		if (MainScreen.cameraSub.yCam > 0)
		{
			num = MainScreen.cameraSub.yCam / MainTabNew.wOneItem;
		}
		int num2 = 1;
		mContent = item.mcontent;
		mcolor = item.mColor;
		if (item.mcontent != null)
		{
			num2 += mContent.Length;
		}
		if (item.mPlusContent != null)
		{
			num2 += item.mPlusContent.Length;
		}
		if (itemIdSelect / numW < numHPaint / 2 + num)
		{
			yCon = yBegin + (itemIdSelect / numW + 1) * MainTabNew.wOneItem + 2;
			if (yCon - MainScreen.cameraSub.yCam + (num2 + 1) * GameCanvas.hText > GameCanvas.h - (GameCanvas.hCommand - 5))
			{
				yCon = GameCanvas.h - (GameCanvas.hCommand - 5) - ((num2 + 1) * GameCanvas.hText - MainScreen.cameraSub.yCam);
			}
		}
		else
		{
			yCon = yBegin + itemIdSelect / numW * MainTabNew.wOneItem - 7 - num2 * GameCanvas.hText - MainScreen.cameraSub.yCam;
			if (yCon - MainScreen.cameraSub.yCam < 6)
			{
				yCon = 6 + MainScreen.cameraSub.yCam;
			}
		}
		if ((num2 + 1) * GameCanvas.hText > MainTabNew.hMaxContent - hcmd)
		{
			listContent = new ListNew(xCon, yCon, wContent, MainTabNew.hMaxContent, 0, 0, (num2 + 1) * GameCanvas.hText - (MainTabNew.hMaxContent - hcmd));
		}
	}

	public new void setPaintInfo()
	{
		mVector mVector3 = vecRewardList;
		mContent = null;
		mSubContent = null;
		mPlusContent = null;
		if (itemIdSelect >= mVector3.size() || itemIdSelect < 0)
		{
			if (itemIdSelect > mVector3.size() - 1)
			{
				itemIdSelect = mVector3.size() - 1;
			}
			MainTabNew.timePaintInfo = 0;
			return;
		}
		Item item = (Item)mVector3.elementAt(itemIdSelect);
		if (item.setNameNull())
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		if (item.ItemCatagory == 9)
		{
			MsgDialog.pet = (PetItem)item;
			isPet = true;
		}
		else
		{
			isPet = false;
		}
		name = item.itemName;
		colorName = item.colorNameItem;
		if (item.ItemCatagory == 3 || typeTab == MainTabNew.SHOP)
		{
			mPlusContent = item.mPlusContent;
			mPlusColor = item.mPlusColor;
		}
		listContent = null;
		if (MainTabNew.longwidth > 0)
		{
			int num = 1;
			mContent = item.mcontent;
			mcolor = item.mColor;
			if (item.mcontent != null)
			{
				num += mContent.Length;
			}
			if (item.mPlusContent != null)
			{
				num += item.mPlusContent.Length;
			}
			if (num * GameCanvas.hText > MainTabNew.hMaxContent)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - MainTabNew.hMaxContent);
			}
			else if (GameCanvas.isTouch)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, 0);
			}
		}
		else
		{
			wContent = item.sizeW;
			setYCon(item);
			if (itemIdSelect % numW < 2)
			{
				xCon = xBegin + MainTabNew.wOneItem / 2 + itemIdSelect % numW * MainTabNew.wOneItem;
			}
			else if (itemIdSelect % numW < 5)
			{
				xCon = xBegin + MainTabNew.wOneItem / 2 + itemIdSelect % numW * MainTabNew.wOneItem - wContent / 2;
			}
			else
			{
				xCon = xBegin + MainTabNew.wOneItem / 2 + itemIdSelect % numW * MainTabNew.wOneItem - wContent;
			}
		}
	}

	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		base.backTab();
	}

	private bool atDestination(mVector2 location, mVector2 destination)
	{
		float num = mVector2.distance(location, destination);
		if (num < 20f)
		{
			return true;
		}
		return false;
	}

	public override void updatekey()
	{
		mVector mVector3 = vecRewardList;
		if (MainTabNew.Focus == MainTabNew.INFO)
		{
			int num = itemIdSelect;
			bool flag = false;
			if (sectionType == 1)
			{
				if (endDraw)
				{
					if (GameCanvas.keyMyHold[4])
					{
						curSelectPointerIdx--;
						if (curSelectPointerIdx < 0)
						{
							curSelectPointerIdx = 4;
						}
						GameCanvas.clearKeyHold(4);
					}
					else if (GameCanvas.keyMyHold[6])
					{
						curSelectPointerIdx++;
						if (curSelectPointerIdx > 4)
						{
							curSelectPointerIdx = 0;
						}
						GameCanvas.clearKeyHold(6);
					}
				}
			}
			else
			{
				if (listContent != null)
				{
					if (GameCanvas.keyMyHold[2])
					{
						if (listContent.cmtoX > 0)
						{
							listContent.cmtoX -= GameCanvas.hText;
						}
						else
						{
							listContent.cmtoX = 0;
						}
						GameCanvas.clearKeyHold(2);
					}
					else if (GameCanvas.keyMyHold[8])
					{
						if (listContent.cmtoX < listContent.cmxLim)
						{
							listContent.cmtoX += GameCanvas.hText;
						}
						else
						{
							listContent.cmtoX = listContent.cmxLim;
						}
						GameCanvas.clearKeyHold(8);
					}
				}
				else if (GameCanvas.keyMyHold[2])
				{
					itemIdSelect -= numW;
					GameCanvas.clearKeyHold(2);
					flag = true;
				}
				else if (GameCanvas.keyMyHold[8])
				{
					itemIdSelect += numW;
					GameCanvas.clearKeyHold(8);
					flag = true;
				}
				if (GameCanvas.keyMyHold[4])
				{
					if (itemIdSelect % numW == 0)
					{
						MainTabNew.Focus = MainTabNew.TAB;
					}
					else
					{
						itemIdSelect--;
					}
					GameCanvas.clearKeyHold(4);
					flag = true;
				}
				else if (GameCanvas.keyMyHold[6])
				{
					itemIdSelect++;
					GameCanvas.clearKeyHold(6);
					flag = true;
				}
				if (flag)
				{
					listContent = null;
					itemIdSelect = resetSelect(itemIdSelect, mVector3.size() - 1, isreset: false);
					if (GameCanvas.isTouch || typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.CHEST)
					{
					}
					TabScreenNew.timeRepaint = 10;
				}
				if (num != itemIdSelect)
				{
					MainScreen.cameraSub.moveCamera(0, (itemIdSelect / numW - 1) * MainTabNew.wOneItem);
					MainTabNew.timePaintInfo = 0;
				}
			}
		}
		base.updatekey();
	}

	public override void updatePointer()
	{
		if (sectionType == 1)
		{
			int imageWidth = mImage.getImageWidth(AvMain.imgGlass.image);
			int imageHeight = mImage.getImageHeight(AvMain.imgGlass.image);
			if (endDraw)
			{
				for (int i = 0; i < posArray.Length; i++)
				{
					if (GameCanvas.isPointSelect((int)fixPosArray[i].x - imageWidth / 2, (int)fixPosArray[i].y - imageHeight / 2, imageWidth, imageHeight))
					{
						selectIdx = i;
						GameCanvas.isPointerSelect = false;
						break;
					}
				}
			}
		}
		else if (sectionType == 0)
		{
			bool flag = false;
			if (listContent != null && GameCanvas.isPoint(listContent.x, listContent.y, listContent.maxW, listContent.maxH))
			{
				listContent.update_Pos_UP_DOWN();
				flag = true;
			}
			if (GameCanvas.isTouch && !flag)
			{
				list.update_Pos_UP_DOWN();
				MainScreen.cameraSub.yCam = list.cmx;
			}
			if (GameCanvas.isPointSelect(xBegin, yBegin, numW * MainTabNew.wOneItem, MainTabNew.hblack - MainTabNew.wOne5 / 2) && !flag)
			{
				int num = (GameCanvas.px - xBegin) / MainTabNew.wOneItem + (GameCanvas.py - yBegin + MainScreen.cameraSub.yCam) / MainTabNew.wOneItem * numW;
				if (num >= 0 && num < vecRewardList.size())
				{
					GameCanvas.isPointerSelect = false;
					MainTabNew.timePaintInfo = 0;
					itemIdSelect = num;
					if (MainTabNew.Focus != MainTabNew.INFO)
					{
						MainTabNew.Focus = MainTabNew.INFO;
					}
				}
				else
				{
					MainTabNew.timePaintInfo = 0;
					itemIdSelect = -1;
				}
			}
		}
		if (vecListCmd != null && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && (MainTabNew.Focus == MainTabNew.INFO || MainTabNew.longwidth > 0))
		{
			for (int j = 0; j < vecListCmd.size(); j++)
			{
				iCommand iCommand2 = (iCommand)vecListCmd.elementAt(j);
				iCommand2.updatePointer();
			}
		}
		base.updatePointer();
	}

	public override void commandTab(int index, int sub)
	{
		base.commandTab(index, sub);
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			if (waitForNewPlay)
			{
				GameCanvas.game.Show();
			}
			else
			{
				backTab();
			}
			break;
		case 0:
			if (beginDraw || endDraw)
			{
				return;
			}
			beginDraw = true;
			moveCount = 0;
			velocity = 0f;
			if (!GameCanvas.isTouch)
			{
				center = null;
				right = null;
				left = null;
			}
			setCommand();
			break;
		case 1:
			if (!waitForNewPlay)
			{
				GlobalService.gI().request_LotteryItems(1, (sbyte)itemIdSelect);
				if (!GameCanvas.isTouch)
				{
					center = cmdStartDraw;
					right = null;
					left = null;
				}
			}
			break;
		case 2:
			GlobalService.gI().request_LotteryItems(0, 0);
			break;
		case 3:
			selectIdx = curSelectPointerIdx;
			if (!GameCanvas.isTouch)
			{
				center = cmdContinue;
				left = cmdRepick;
				cmdBack.caption = T.close;
				right = cmdBack;
			}
			break;
		case 4:
			GlobalService.gI().request_LotteryItems(1, (sbyte)itemIdSelect);
			if (!GameCanvas.isTouch)
			{
				center = cmdStartDraw;
				right = null;
				left = null;
			}
			waitForNewPlay = false;
			beginDraw = false;
			endDraw = false;
			moveDone = true;
			isWin = false;
			moveCount = 0;
			selectIdx = -1;
			curSelectPointerIdx = -1;
			selectNumber = -1;
			luckyNumber = -1;
			itemVel = 1f;
			rewardPos = new mVector2(xBegin + MainTabNew.wblack / 2, yBegin + MainTabNew.hblack / 2);
			break;
		}
		base.commandPointer(index, subIndex);
	}
}
