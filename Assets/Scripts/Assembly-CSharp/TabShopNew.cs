using System;
using UnityEngine.UI;

public class TabShopNew : MainTabNew
{
	public static sbyte NORMAL = 0;

	public static sbyte TOC = 1;

	public static sbyte INVEN_AND_CHEST = 2;

	public static sbyte INVEN_AND_REBUILD = 3;

	public static sbyte SHOP_BANG = 4;

	public static sbyte INVEN_BANG = 5;

	public static sbyte INVEN_AND_REPLACE = 6;

	public static sbyte INVEN_AND_WING = 7;

	public static sbyte WING = 7;

	public static sbyte INVEN_AND_PET_KEEPER = 8;

	public static sbyte INVEN_FOOD_PET = 9;

	public static sbyte INVEN_LOTTERY = 10;

	public static sbyte SHOP_VANTIEU = 11;

	public static sbyte SHOP_KHAM_NGOC = 12;

	public static sbyte SHOP_GHEP_NGOC = 13;

	public static sbyte SHOP_DUC_LO = 14;

	public static sbyte SHOP_STORE_OTHER_PLAYER = 15;

	public static sbyte SHOP_ANY_NGUYEN_LIEU = 16;

	public static sbyte SHOP_HOP_AN = 17;

	public static sbyte SHOP_NANG_CAP_MEDEL = 18;

	public static sbyte UPDATE = -1;

	public static sbyte GET_CHEST = 0;

	public static sbyte SET_CHEST = 1;

	public static sbyte UPDATE_PET_EAT = 2;

	public static sbyte WITHDRAW_PET = 0;

	public static sbyte DEPOSIT_PET = 1;

	public static bool isTabHopNL;

	private sbyte currentTab;

	public static sbyte maxTab;

	public static short priceSellPotion;

	public static short priceSellItem;

	public static short hesoLv;

	public static short hesoColor;

	public static short priceSellQuest = 1;

	public static short maxPriceItem;

	public static short PriceIconClan;

	public static short PriceChatWorld = 0;

	public static bool isSortInven = false;

	private int IDTab;

	private int numW = 6;

	private int numH = 6;

	private int numHPaint;

	private int maxSize = 60;

	private int idSelect;

	private int hcmd;

	private InputDialog inputWorld;

	private string textWorld = string.Empty;

	public static short idSeller = 0;

	public bool isShop_Other_Player;

	private mVector vecShop = new mVector("TabShopNew vecShop");

	public static int IdTabSave = -1;

	public PetItem petCur;

	public byte numofGem;

	public static mHashTable allidNgocKham = new mHashTable();

	private iCommand cmdHoiMua;

	private iCommand cmdSelect;

	private iCommand cmdBuyPotion;

	private iCommand cmdMua;

	private iCommand cmdHoiXoaItem;

	private iCommand cmdXoaItem;

	private iCommand cmdMenuInven;

	private iCommand cmdSetKey;

	private iCommand cmdHoiSell;

	private iCommand cmdSell;

	private iCommand cmdGetChest;

	private iCommand cmdSetChest;

	private iCommand cmdGetPotionChest;

	private iCommand cmdSetPotionChest;

	private iCommand cmdSellMore;

	private iCommand cmdRebuild;

	private iCommand cmdUnRebuild;

	private iCommand cmdNextIcon;

	private iCommand cmdReplace;

	private iCommand cmdWing;

	private iCommand cmdCreateWing;

	private iCommand cmdDepositPet;

	private iCommand cmdWithdrawPet;

	private iCommand cmdFoodPet;

	private iCommand cmdPetInfo;

	private iCommand cmdPetFeed;

	private iCommand cmdSelectReward;

	private iCommand cmdHopNguyeLieu;

	private iCommand cmdMua1;

	private iCommand cmdMua10;

	private iCommand cmdMua30;

	private iCommand cmdKhamgoc;

	private iCommand cmdGhepNgoc;

	private iCommand cmdDuclo;

	private iCommand cmdBovao;

	private iCommand cmdLayra;

	private iCommand cmdMuaNhieu;

	private iCommand cmdHoidaugia;

	private iCommand cmdDaugia;

	private iCommand cmdHoanThanh;

	private iCommand cmdOkSell;

	private iCommand cmdBuyItemOtherplayer;

	private iCommand cmdhuy;

	private iCommand cmdNghiban;

	private iCommand cmdChatWorld;

	private iCommand cmdlaynguyenlieura;

	private iCommand cmdHoprac;

	private iCommand cmdlayracra;

	private iCommand cmdbanNguyenLieu;

	private iCommand cmdHopAn;

	private iCommand cmdNextInven;

	private iCommand cmdKhacItem;

	private InputDialog inputDialog;

	private ListNew list;

	private mVector vecListCmd;

	public sbyte isTypeShop;

	private string nameCmdBuy = string.Empty;

	private bool isShop;

	public TabShopNew(mVector vec, sbyte typeShop, string nametab, int idTab, sbyte isTypeShop)
	{
		typeTab = typeShop;
		isShop = false;
		xBegin = xTab + MainTabNew.wOneItem + MainTabNew.wOne5 * 3;
		yBegin = yTab + GameCanvas.h / 5 + MainTabNew.wOneItem + 1;
		numW = MainTabNew.wblack / MainTabNew.wOneItem;
		numHPaint = MainTabNew.hblack / MainTabNew.wOneItem;
		maxSize = vec.size();
		if (maxSize % numW != 0)
		{
			maxSize += numW - maxSize % numW;
		}
		if (typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE)
		{
			vecShop = Item.VecInvetoryPlayer;
			if (maxSize < Player.maxInven)
			{
				maxSize = Player.maxInven;
			}
		}
		else if (typeTab == MainTabNew.SELLITEM)
		{
			vecShop = Item.VecItemSell;
		}
		else if (typeTab == MainTabNew.CHEST)
		{
			vecShop = Item.VecChestPlayer;
			if (maxSize < Player.maxChest)
			{
				maxSize = Player.maxChest;
			}
		}
		else if (typeTab == MainTabNew.PET_KEEPER)
		{
			vecShop = Item.VecPetContainer;
			if (maxSize < Player.maxPet)
			{
				maxSize = Player.maxChest;
			}
		}
		else if (typeTab == MainTabNew.CLAN_INVENTORY)
		{
			vecShop = Item.VecClanInvetory;
		}
		else
		{
			vecShop = vec;
			IdTabSave = idTab;
			isShop = true;
		}
		maxSize = 42;
		currentTab = 0;
		maxTab = (sbyte)(Player.maxInven / 42);
		if (isShop)
		{
			maxSize = vecShop.size();
		}
		if (typeTab == MainTabNew.PET_KEEPER)
		{
			maxTab = (sbyte)(Player.maxPet / 42);
		}
		numH = (maxSize - 1) / numW + 1;
		nameTab = nametab;
		IDTab = idTab;
		this.isTypeShop = isTypeShop;
		if (isTypeShop == SHOP_KHAM_NGOC)
		{
			numofGem = 2;
		}
		if (isTypeShop == SHOP_GHEP_NGOC || isTypeShop == SHOP_ANY_NGUYEN_LIEU)
		{
			numofGem = 5;
		}
		if (nametab == null || nametab.Length == 0)
		{
			nameTab = "Name Tab";
		}
		cmdHoiMua = new iCommand(T.buy, 0, this);
		cmdSelect = new iCommand(T.use, 6, this);
		cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			cmdBack.caption = T.close;
		}
		cmdBuyPotion = new iCommand(T.buy, 2, this);
		cmdMua = new iCommand(T.buy, 3, this);
		cmdHoiXoaItem = new iCommand(T.vucbo, 4, this);
		cmdXoaItem = new iCommand(T.vucbo, 5, this);
		cmdMenuInven = new iCommand(T.select, 7, this);
		cmdSetKey = new iCommand(T.setKey, 8, this);
		cmdHoiSell = new iCommand(T.sell, 11, this);
		cmdSell = new iCommand(T.sell, 10, this);
		cmdGetChest = new iCommand(T.layra, 13, this);
		cmdSetChest = new iCommand(T.catvao, 14, this);
		cmdGetPotionChest = new iCommand(T.layra, 15, this);
		cmdSetPotionChest = new iCommand(T.catvao, 16, this);
		cmdSellMore = new iCommand(T.sellmore, 17, this);
		cmdRebuild = new iCommand(T.dapdo, 20, this);
		cmdUnRebuild = new iCommand(T.layra, 21, this);
		cmdNextIcon = new iCommand(T.next, 22, this);
		cmdReplace = new iCommand(T.replace, 23, this);
		cmdWing = new iCommand(T.nangcap, 24, this);
		cmdCreateWing = new iCommand(T.taoCanh, 3, this);
		cmdDepositPet = new iCommand(T.aptrung, 25, this);
		cmdWithdrawPet = new iCommand(T.use, 26, this);
		cmdFoodPet = new iCommand(T.choan, 27, this);
		cmdPetInfo = new iCommand(T.info, 28, this);
		cmdPetFeed = new iCommand(T.choan, 29, this);
		cmdHopNguyeLieu = new iCommand(T.hopThanh, 30, this);
		cmdMua1 = new iCommand(T.buy + " 1", 31, this);
		cmdMua10 = new iCommand(T.buy + " 10", 32, this);
		cmdMua30 = new iCommand(T.buy + " 30", 33, this);
		cmdKhamgoc = new iCommand(T.khamNgoc, 36, this);
		cmdBovao = new iCommand(T.bovao, 37, this);
		cmdGhepNgoc = new iCommand(T.bovao, 38, this);
		cmdLayra = new iCommand(T.layra, 39, this);
		cmdMuaNhieu = new iCommand(T.muaNhieu, 0, this);
		cmdDuclo = new iCommand(T.DucLo, 40, this);
		cmdHoidaugia = new iCommand(T.daugia, 41, this);
		cmdDaugia = new iCommand(T.daugia, 42, this);
		cmdHoanThanh = new iCommand(T.hoanthanh, 44, this);
		cmdOkSell = new iCommand(T.hoanthanh, 45, this);
		cmdBuyItemOtherplayer = new iCommand(T.buy, 46, this);
		cmdhuy = new iCommand(T.cancel, 47, this);
		cmdNghiban = new iCommand(T.NghiBan, 48, this);
		cmdChatWorld = new iCommand(T.text2kenhthegioi, 49, this);
		cmdHoprac = new iCommand(T.hoprac, 52, this);
		cmdlayracra = new iCommand(T.layra, 53, this);
		cmdHopAn = new iCommand(T.bovao, 54, this);
		cmdbanNguyenLieu = new iCommand(T.daugia, 55, this);
		cmdNextInven = new iCommand(T.tabhanhtrang, 56, this);
		cmdKhacItem = new iCommand(T.khac, 57, this);
		init();
	}

	public new void setNameCmd(string name)
	{
		nameCmdBuy = name;
		cmdHoiMua.caption = name;
		cmdMua.caption = name;
	}

	public override void init()
	{
		if (GameCanvas.isTouch)
		{
			idSelect = -1;
		}
		else
		{
			idSelect = 0;
		}
		MainTabNew.timePaintInfo = 0;
		int num = 0;
		if (typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE)
		{
			if (isSortInven)
			{
				Item.VecInvetoryPlayer = CRes.selectionSortInven(Item.VecInvetoryPlayer);
				isSortInven = false;
			}
			num = Item.VecInvetoryPlayer.size();
		}
		else
		{
			num = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell.size() : ((typeTab != MainTabNew.CHEST && typeTab != MainTabNew.SELLITEM) ? ((typeTab == MainTabNew.CLAN_INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecClanInvetory.size() : ((typeTab != MainTabNew.PET_KEEPER) ? vecShop.size() : Item.VecPetContainer.size())) : Item.VecChestPlayer.size()));
		}
		MainScreen.cameraSub.setAll(0, numH * MainTabNew.wOneItem - MainTabNew.hblack - MainTabNew.wOne5 + 8, 0, 0);
		list = new ListNew(xBegin, yBegin, MainTabNew.wblack, MainTabNew.hblack, 0, 0, MainScreen.cameraSub.yLimit);
		listContent = null;
		if (num == 0)
		{
			MainTabNew.Focus = MainTabNew.TAB;
		}
		else if (!GameCanvas.isTouch)
		{
			if (typeTab == MainTabNew.SHOP)
			{
				if (isTypeShop == SHOP_BANG)
				{
					center = cmdMenuInven;
				}
				else if (isTypeShop == WING)
				{
					center = cmdCreateWing;
				}
				else
				{
					center = cmdHoiMua;
				}
			}
			else if (typeTab == MainTabNew.CHEST)
			{
				if (Item.VecChestPlayer.size() > 0)
				{
					center = cmdMenuInven;
				}
			}
			else if (typeTab == MainTabNew.CLAN_INVENTORY)
			{
				if (Item.VecClanInvetory.size() > 0)
				{
					center = cmdMenuInven;
				}
			}
			else if (typeTab == MainTabNew.INVENTORY)
			{
				if (Item.VecInvetoryPlayer.size() > 0)
				{
					center = cmdMenuInven;
				}
			}
			else if (typeTab == MainTabNew.PET_KEEPER && Item.VecPetContainer.size() > 0)
			{
				center = cmdMenuInven;
			}
			right = cmdBack;
		}
		currentTab = 0;
		base.init();
	}

	public override void commandPointer(int index, object obj)
	{
		Item item = null;
		mSystem.outz("commandPointer index = " + index);
		mVector mVector3 = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell : ((typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecInvetoryPlayer : ((typeTab == MainTabNew.CHEST) ? Item.VecChestPlayer : ((typeTab == MainTabNew.PET_KEEPER) ? Item.VecPetContainer : ((typeTab != MainTabNew.CLAN_INVENTORY) ? vecShop : Item.VecClanInvetory)))));
		if (idSelect < 0 && index > 0)
		{
			return;
		}
		if (MainTabNew.longwidth == 0)
		{
			MainTabNew.timePaintInfo = 0;
		}
		if (index == 43)
		{
			MainItem mainItem = (MainItem)mVector3.elementAt(idSelect);
			if (mainItem != null)
			{
				item_sell item_sell2 = (item_sell)obj;
				int price = 0;
				int num = 1;
				try
				{
					if (item_sell2 != null)
					{
						price = item_sell2.price;
						num = item_sell2.soluuong;
					}
				}
				catch (Exception)
				{
					GameCanvas.start_Ok_Dialog(T.nhapsai);
					price = 0;
					return;
				}
				short id = (short)mainItem.Id;
				item_sell o = new item_sell(id, price, num, mainItem.ItemCatagory);
				Item.VecItem_Sell_in_store.addElement(o);
				if (mainItem.ItemCatagory == 4)
				{
					MainItem mainItem2 = mainItem.clonePotion();
					mainItem2.numPotion = num;
					Item.VecItemSell.addElement(mainItem2);
				}
				else if (mainItem.ItemCatagory == 7)
				{
					MainItem mainItem3 = mainItem.cloneNguyenLieu();
					mainItem3.numPotion = num;
					Item.VecItemSell.addElement(mainItem3);
				}
				else
				{
					Item.VecItemSell.addElement(mainItem);
				}
			}
			if (vecListCmd != null)
			{
				vecListCmd.removeAllElements();
			}
			GameCanvas.end_Dialog();
		}
		if (obj != null)
		{
			obj = null;
		}
	}

	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		idSelect = 0;
		base.backTab();
	}

	public override void commandPointer(int index, int subIndex)
	{
		Item item = null;
		mVector mVector3 = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell : ((typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecInvetoryPlayer : ((typeTab == MainTabNew.CHEST) ? Item.VecChestPlayer : ((typeTab == MainTabNew.PET_KEEPER) ? Item.VecPetContainer : ((typeTab != MainTabNew.CLAN_INVENTORY) ? vecShop : Item.VecClanInvetory)))));
		if (idSelect < 0 && index > 0)
		{
			return;
		}
		if (MainTabNew.longwidth == 0)
		{
			MainTabNew.timePaintInfo = 0;
		}
		switch (index)
		{
		case -1:
			backTab();
			break;
		case 0:
			item = (Item)mVector3.elementAt(idSelect);
			if (item == null || item.setNameNull())
			{
				break;
			}
			if (isTypeShop == SHOP_STORE_OTHER_PLAYER && (!GameCanvas.isTouch || (GameCanvas.isTouch && mSystem.isj2me)))
			{
				cmdBuyItemOtherplayer.perform();
			}
			else if (item.diaHoiEvent != string.Empty)
			{
				GameCanvas.start_Left_Dialog(item.diaHoiEvent, cmdMua);
			}
			else if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
			{
				inputDialog = new InputDialog();
				inputDialog.setinfoSmallNew(T.nhapsoluongcanmua, cmdBuyPotion, isNum: true, -1, item.priceItem, T.buySell, item.getPriceType());
				GameCanvas.currentDialog = inputDialog;
			}
			else if (item.ItemCatagory == 3)
			{
				cmdMua.caption = T.buy;
				GameCanvas.start_Left_Dialog(T.hoiBuy + "1 " + item.itemName + ". " + T.voigia + item.priceItem + item.getPriceType() + "?", cmdMua);
			}
			else if (item.ItemCatagory == 6)
			{
				if (item.priceItem > 0)
				{
					cmdMua.caption = T.buy;
					GameCanvas.start_Left_Dialog(T.hoiBuy + item.itemName + ". " + T.voigia + item.priceItem + item.getPriceType() + "?", cmdMua);
				}
				else if (item.imageId == GameScreen.player.hair)
				{
					GameCanvas.start_Ok_Dialog(T.dangdungtocnay);
				}
				else
				{
					cmdMua.caption = T.use;
					GameCanvas.start_Left_Dialog(T.dungitem, cmdMua);
				}
			}
			else if (item.ItemCatagory == 8)
			{
				cmdMua.caption = T.select;
				GameCanvas.start_Left_Dialog(T.hoichoniconclan, cmdMua);
			}
			break;
		case 1:
		{
			Item item4 = (Item)mVector3.elementAt(idSelect);
			if (item4 != null)
			{
				GameCanvas.start_Left_Dialog(T.dungitem, new iCommand(T.use, 6, this));
			}
			break;
		}
		case 2:
		{
			MainItem mainItem10 = (MainItem)mVector3.elementAt(idSelect);
			if (mainItem10 != null)
			{
				int num7 = 1;
				try
				{
					num7 = int.Parse(inputDialog.tfInput.getText());
				}
				catch (Exception)
				{
					num7 = 1;
				}
				GlobalService.gI().buy_item((sbyte)IDTab, (short)mainItem10.Id, (short)num7);
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 3:
		case 31:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && !item.setNameNull())
			{
				GlobalService.gI().buy_item((sbyte)IDTab, (short)item.Id, 1);
				GameCanvas.end_Dialog();
			}
			break;
		case 4:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && !item.setNameNull())
			{
				GameCanvas.start_Left_Dialog(T.hoiDelItem + item.itemName + "?", cmdXoaItem);
			}
			break;
		case 5:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && !item.setNameNull())
			{
				GlobalService.gI().delete_Item((sbyte)item.ItemCatagory, (short)item.Id, 0);
				MainTabNew.timePaintInfo = 0;
				GameCanvas.end_Dialog();
			}
			break;
		case 6:
		{
			MainItem mainItem5 = (MainItem)mVector3.elementAt(idSelect);
			if (mainItem5 == null)
			{
				break;
			}
			if (mainItem5.ItemCatagory == 5)
			{
				GameCanvas.start_Ok_Dialog(T.khongthedung);
				break;
			}
			if (mainItem5.ItemCatagory == 4)
			{
				if (mainItem5.typePotion > 1 || Player.timeDelayPotion[mainItem5.typePotion].value <= 0)
				{
					if (GameScreen.help.setStep_Next(2, 4) && mainItem5.typePotion == 0)
					{
						GameScreen.help.Next++;
						GameScreen.help.setNext();
					}
					if (mainItem5.typePotion >= 2 || ((mainItem5.typePotion != 0 || GameScreen.player.hp != GameScreen.player.maxHp) && (mainItem5.typePotion != 1 || GameScreen.player.mp != GameScreen.player.maxMp)))
					{
						if (mainItem5.typePotion == Item.ID_TEM_VE_MUA_BAN)
						{
							if (!GameScreen.player.isSelling())
							{
								GameScreen.gI().doSellItem();
							}
						}
						else
						{
							GlobalService.gI().Use_Potion((short)mainItem5.Id);
							if (mainItem5.typePotion < 2)
							{
								Player.timeDelayPotion[mainItem5.typePotion].value = 2000;
								Player.timeDelayPotion[mainItem5.typePotion].limit = 2000;
								Player.timeDelayPotion[mainItem5.typePotion].timebegin = mSystem.currentTimeMillis();
							}
						}
					}
				}
			}
			else
			{
				int num4 = 0;
				if (mainItem5.type_Only_Item < 12)
				{
					num4 = MainTemplateItem.mItem_Rotate_Tem_Equip[mainItem5.type_Only_Item];
				}
				if (num4 == -1)
				{
					mVector mVector5 = new mVector("TabShopNew menu");
					iCommand iCommand2 = new iCommand(T.leftRing, 12, 0, this);
					Item item2 = (Item)Item.VecEquipPlayer.get(string.Empty + (sbyte)3);
					if (item2 != null)
					{
						MainImage imageItem = ObjectData.getImageItem((short)item2.imageId);
						if (imageItem != null && imageItem.img != null)
						{
							if (imageItem.w == 0 || imageItem.h == 0)
							{
								imageItem.h = (short)mImage.getImageHeight(imageItem.img.image);
								imageItem.w = (short)mImage.getImageWidth(imageItem.img.image);
							}
							FrameImage fraCaption = new FrameImage(imageItem.img, imageItem.w, imageItem.h);
							iCommand2.setFraCaption(fraCaption);
						}
					}
					iCommand iCommand3 = new iCommand(T.rightRing, 12, 1, this);
					Item item3 = (Item)Item.VecEquipPlayer.get(string.Empty + (sbyte)9);
					if (item3 != null)
					{
						MainImage imageItem2 = ObjectData.getImageItem((short)item3.imageId);
						if (imageItem2 != null && imageItem2.img != null)
						{
							if (imageItem2.w == 0 || imageItem2.h == 0)
							{
								imageItem2.h = (short)mImage.getImageHeight(imageItem2.img.image);
								imageItem2.w = (short)mImage.getImageWidth(imageItem2.img.image);
							}
							FrameImage fraCaption2 = new FrameImage(imageItem2.img, imageItem2.w, imageItem2.h);
							iCommand3.setFraCaption(fraCaption2);
						}
					}
					mVector5.addElement(iCommand2);
					mVector5.addElement(iCommand3);
					GameCanvas.menu2.startAt(mVector5, 2, T.Ring, isFocus: false, null);
				}
				else
				{
					if (mainItem5.ItemCatagory == 7)
					{
						GlobalService.gI().doUseMaterial((short)mainItem5.Id);
					}
					else
					{
						GlobalService.gI().Use_Item((sbyte)mainItem5.Id, (sbyte)num4);
					}
					if (GameScreen.help.setStep_Next(3, 4))
					{
						GameScreen.help.Next++;
						GameScreen.help.setNext();
					}
				}
			}
			MainTabNew.timePaintInfo = 0;
			if (!GameScreen.help.setStep_Next(2, 5) && !GameScreen.help.setStep_Next(3, 5))
			{
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 7:
			item = (Item)mVector3.elementAt(idSelect);
			if (item != null)
			{
				mVector mVector6 = new mVector("TabShopNew menu2");
				mVector6 = doMenu(item);
				string text = T.item;
				if (isTypeShop == SHOP_BANG)
				{
					text = T.iconclan;
				}
				GameCanvas.menu2.startAt(mVector6, 2, text, isFocus: false, null);
				if (GameScreen.help.setStep_Next(2, 9) || GameScreen.help.setStep_Next(2, 4) || GameScreen.help.setStep_Next(3, 4))
				{
					Menu2.isHelp = true;
				}
			}
			break;
		case 8:
		{
			mVector mVector11 = new mVector("TabShopNew menu3");
			for (int i = 0; i < 5; i++)
			{
				iCommand o = (GameCanvas.isTouch ? new iCommand(T.oso + (i + 1), 9, i, this) : ((!TField.isQwerty) ? new iCommand(T.phim + PaintInfoGameScreen.mValueHotKey[i], 9, i, this) : new iCommand(T.phim + PaintInfoGameScreen.mValueChar[i], 9, i, this)));
				mVector11.addElement(o);
			}
			GameCanvas.menu2.startAt(mVector11, 2, T.setKey, isFocus: false, null);
			if (GameScreen.help.Step >= 0 && GameScreen.help.setStep_Next(2, 9))
			{
				GameScreen.help.Next = 10;
				Menu2.isHelp = true;
			}
			break;
		}
		case 9:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item == null || item.typePotion > 1)
			{
				break;
			}
			if (subIndex == 2)
			{
				GameCanvas.start_Ok_Dialog(T.khongganmauvaophimnay);
				break;
			}
			Player.mhotkey[Player.levelTab][subIndex].setHotKey(item.Id, HotKey.POTION, item.typePotion);
			TabSkillsNew.saveSkill();
			if (GameScreen.help.Step >= 0 && (GameScreen.help.setStep_Next(2, 9) || GameScreen.help.setStep_Next(2, 10)))
			{
				GameScreen.help.Next = 11;
				GameScreen.help.setNext();
			}
			break;
		case 10:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && !item.setNameNull())
			{
				GlobalService.gI().delete_Item((sbyte)item.ItemCatagory, (short)item.Id, 1);
				if (GameCanvas.isTouch)
				{
					idSelect = -1;
				}
				MainTabNew.timePaintInfo = 0;
				GameCanvas.end_Dialog();
			}
			break;
		case 11:
		{
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item == null || item.setNameNull())
			{
				break;
			}
			int num2 = 0;
			if (item.ItemCatagory != 3)
			{
				num2 = ((item.ItemCatagory != 5) ? priceSellPotion : (item.numPotion * priceSellQuest));
			}
			else
			{
				num2 = (1 + item.LvItem / hesoLv) * priceSellItem * (100 + item.colorNameItem * hesoColor) / 100;
				if (num2 > maxPriceItem)
				{
					num2 = maxPriceItem;
				}
			}
			if (item.ItemCatagory == 3)
			{
				if (item.colorNameItem == 0)
				{
					num2 = 1;
				}
				if (item.colorNameItem == 1)
				{
					num2 = 3;
				}
			}
			GameCanvas.start_Left_Dialog(T.hoisell + item.itemName + "? " + T.voigia + num2 + " " + T.coin + ".", cmdSell);
			break;
		}
		case 12:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null)
			{
				switch (subIndex)
				{
				case 0:
					GlobalService.gI().Use_Item((sbyte)item.Id, 3);
					break;
				case 1:
					GlobalService.gI().Use_Item((sbyte)item.Id, 9);
					break;
				}
			}
			break;
		case 13:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null)
			{
				int num = 1;
				if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
				{
					try
					{
						num = int.Parse(inputDialog.tfInput.getText());
					}
					catch (Exception)
					{
						num = 1;
					}
				}
				GlobalService.gI().Update_Char_Chest(GET_CHEST, (short)item.Id, (sbyte)item.ItemCatagory, (short)num);
				if (GameCanvas.isTouch)
				{
					idSelect = -1;
				}
			}
			GameCanvas.end_Dialog();
			break;
		case 14:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null)
			{
				int num8 = 1;
				if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
				{
					try
					{
						num8 = int.Parse(inputDialog.tfInput.getText());
					}
					catch (Exception)
					{
						num8 = 1;
					}
				}
				GlobalService.gI().Update_Char_Chest(SET_CHEST, (short)item.Id, (sbyte)item.ItemCatagory, (short)num8);
				if (GameCanvas.isTouch)
				{
					idSelect = -1;
				}
			}
			GameCanvas.end_Dialog();
			break;
		case 15:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && (item.ItemCatagory == 4 || item.ItemCatagory == 7))
			{
				inputDialog = new InputDialog();
				inputDialog.setinfo(T.nhapsoluongcanlay, cmdGetChest, isNum: true, T.chest);
				GameCanvas.currentDialog = inputDialog;
			}
			break;
		case 16:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && (item.ItemCatagory == 4 || item.ItemCatagory == 7))
			{
				inputDialog = new InputDialog();
				inputDialog.setinfo(T.nhapsoluongcancat, cmdSetChest, isNum: true, T.tabhanhtrang);
				GameCanvas.currentDialog = inputDialog;
			}
			break;
		case 17:
		{
			mVector mVector4 = new mVector("TabShopNew menusell");
			mVector4.addElement(new iCommand(T.banhettrang, 19, 0, this));
			mVector4.addElement(new iCommand(T.banhetxanh, 19, 1, this));
			GameCanvas.menu2.startAt(mVector4, 2, T.sell, isFocus: false, null);
			break;
		}
		case 18:
		{
			for (int l = 0; l < Item.VecInvetoryPlayer.size(); l++)
			{
				MainItem mainItem13 = (MainItem)Item.VecInvetoryPlayer.elementAt(l);
				switch (subIndex)
				{
				case 0:
					if (mainItem13.ItemCatagory == 3 && mainItem13.colorNameItem == 0 && mainItem13.tier == 0)
					{
						GlobalService.gI().delete_Item((sbyte)mainItem13.ItemCatagory, (short)mainItem13.Id, 1);
					}
					break;
				case 1:
					if (mainItem13.ItemCatagory == 3 && mainItem13.colorNameItem == 1 && mainItem13.tier == 0)
					{
						GlobalService.gI().delete_Item((sbyte)mainItem13.ItemCatagory, (short)mainItem13.Id, 1);
					}
					break;
				}
			}
			if (GameCanvas.isTouch)
			{
				idSelect = -1;
			}
			GameCanvas.end_Dialog();
			break;
		}
		case 19:
		{
			int num9 = 0;
			for (int j = 0; j < Item.VecInvetoryPlayer.size(); j++)
			{
				MainItem mainItem11 = (MainItem)Item.VecInvetoryPlayer.elementAt(j);
				switch (subIndex)
				{
				case 0:
					if (mainItem11.ItemCatagory == 3 && mainItem11.colorNameItem == 0)
					{
						num9++;
					}
					break;
				case 1:
					if (mainItem11.ItemCatagory == 3 && mainItem11.colorNameItem == 1)
					{
						num9++;
					}
					break;
				}
			}
			if (num9 == 0)
			{
				switch (subIndex)
				{
				case 0:
					GameCanvas.start_Ok_Dialog(T.khongcontrang);
					break;
				case 1:
					GameCanvas.start_Ok_Dialog(T.khongconxanh);
					break;
				}
			}
			else
			{
				switch (subIndex)
				{
				case 0:
					GameCanvas.start_Left_Dialog(T.hoisell + num9 + T.dotrang, new iCommand(T.sell, 18, 0, this));
					break;
				case 1:
					GameCanvas.start_Left_Dialog(T.hoisell + num9 + T.doxanh, new iCommand(T.sell, 18, 1, this));
					break;
				}
			}
			break;
		}
		case 20:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (item != null)
			{
				GlobalService.gI().Rebuild_Item(0, (short)item.Id, (sbyte)item.ItemCatagory);
				if (MainTabNew.longwidth > 0)
				{
					idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		case 21:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (item != null)
			{
				sbyte type = (sbyte)((!MainObject.isMaHopNguyenLieu(item.Id)) ? 1 : 6);
				GlobalService.gI().Rebuild_Item(type, (short)item.Id, (sbyte)item.ItemCatagory);
				if (MainTabNew.longwidth > 0)
				{
					idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		case 22:
			GlobalService.gI().NextClan(8);
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			break;
		case 23:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (item != null)
			{
				GlobalService.gI().Replace_Item(0, (short)item.Id);
			}
			break;
		case 24:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (item != null)
			{
				GlobalService.gI().Rebuild_Wing(2, 0, (short)item.Id);
			}
			break;
		case 25:
			mSystem.outz("Deposit pet ------- ");
			item = (Item)mVector3.elementAt(idSelect);
			if (item != null)
			{
				int num3 = 1;
				GlobalService.gI().Update_Pet_Container(DEPOSIT_PET, (short)item.Id, (sbyte)item.ItemCatagory, (short)num3);
				if (GameCanvas.isTouch)
				{
					idSelect = -1;
				}
			}
			GameCanvas.end_Dialog();
			break;
		case 26:
			mSystem.outz("withdraw pet ------- ");
			item = (Item)mVector3.elementAt(idSelect);
			if (item != null)
			{
				int num10 = 1;
				GlobalService.gI().Update_Pet_Container(WITHDRAW_PET, (short)item.Id, (sbyte)item.ItemCatagory, (short)num10);
				if (GameCanvas.isTouch)
				{
					idSelect = -1;
				}
			}
			GameCanvas.end_Dialog();
			break;
		case 27:
			if (petCur != null)
			{
				item = (Item)mVector3.elementAt(idSelect);
				GlobalService.gI().Pet_Eat((short)petCur.Id, (short)item.Id, (sbyte)item.ItemCatagory, MsgDialog.isInven_Equip);
			}
			break;
		case 28:
			item = (Item)mVector3.elementAt(idSelect);
			if (item != null && item.ItemCatagory == 9)
			{
				GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.INVEN);
			}
			break;
		case 29:
		{
			item = (Item)Item.VecPetContainer.elementAt(idSelect);
			if (item != null && item.ItemCatagory == 9)
			{
				GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.INVEN);
			}
			mVector mVector10 = new mVector("TabShopNew vectab");
			TabShopNew tabShopNew = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.choan, -1, INVEN_FOOD_PET);
			tabShopNew.petCur = MsgDialog.pet;
			mVector10.addElement(tabShopNew);
			GameCanvas.foodPet = new TabScreenNew();
			GameCanvas.foodPet.selectTab = 0;
			GameCanvas.foodPet.addMoreTab(mVector10);
			GameCanvas.foodPet.Show(GameCanvas.currentScreen);
			break;
		}
		case 30:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (item != null)
			{
				GlobalService.gI().Rebuild_Item(4, (short)item.Id, (sbyte)item.ItemCatagory);
				if (MainTabNew.longwidth > 0)
				{
					idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		case 32:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && !item.setNameNull())
			{
				mVector mVector8 = new mVector("TabShopNew menu4");
				string str2 = T.hoiBuy + " " + 10 + " " + item.itemName + " " + T.voigia + " " + item.priceItem * 10 + " " + ((item.priceType != 0) ? T.gem : T.coin);
				mVector8.addElement(new iCommand(T.yes, 34, 10, this));
				mVector8.addElement(new iCommand(T.cancel, 35, this));
				GameCanvas.start_Select_Dialog(str2, mVector8);
			}
			break;
		case 33:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && !item.setNameNull())
			{
				mVector mVector7 = new mVector("TabShopNew menu5");
				string str = T.hoiBuy + " " + 30 + " " + item.itemName + " " + T.voigia + " " + item.priceItem * 30 + " " + ((item.priceType != 0) ? T.gem : T.coin);
				mVector7.addElement(new iCommand(T.yes, 34, 30, this));
				mVector7.addElement(new iCommand(T.cancel, 35, this));
				GameCanvas.start_Select_Dialog(str, mVector7);
			}
			break;
		case 34:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item != null && !item.setNameNull())
			{
				GlobalService.gI().buy_item((sbyte)IDTab, (short)item.Id, (short)subIndex);
				GameCanvas.end_Dialog();
			}
			break;
		case 35:
			GameCanvas.end_Dialog();
			break;
		case 36:
		case 40:
		{
			MainItem mainItem3 = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (mainItem3 != null)
			{
				TabRebuildItem.itemRe = mainItem3;
				TabRebuildItem.countSetpaintinfo = 1;
				if (MainTabNew.longwidth > 0)
				{
					idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		}
		case 37:
		{
			MainItem mainItem2 = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (mainItem2 == null)
			{
				break;
			}
			if (TabRebuildItem.vecGem.size() > numofGem)
			{
				GameCanvas.start_Ok_Dialog(T.khongbothem);
				break;
			}
			TabRebuildItem.addGem(mainItem2);
			if (MainTabNew.longwidth > 0)
			{
				idSelect = -1;
				MainTabNew.timePaintInfo = 0;
			}
			break;
		}
		case 38:
		{
			TabRebuildItem.vecGem.removeAllElements();
			TabRebuildItem.itemRe = null;
			MainItem mainItem12 = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (mainItem12 == null)
			{
				break;
			}
			if (mainItem12.numPotion < numofGem)
			{
				GameCanvas.start_Ok_Dialog(T.hetNgoc);
				break;
			}
			for (int k = 0; k < numofGem; k++)
			{
				TabRebuildItem.addGem(mainItem12);
				if (MainTabNew.longwidth > 0)
				{
					idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		}
		case 39:
			item = (MainItem)mVector3.elementAt(idSelect);
			if (item == null)
			{
				break;
			}
			if (isTypeShop == SHOP_KHAM_NGOC)
			{
				if (TabRebuildItem.isKham(item))
				{
					TabRebuildItem.removeKhamNgoc(item);
				}
			}
			else if (isTypeShop == SHOP_GHEP_NGOC)
			{
				TabRebuildItem.vecGem.removeAllElements();
			}
			break;
		case 41:
		{
			inputDialog = new InputDialog();
			string[] info2 = new string[1] { T.nhapgiaban };
			inputDialog.setinfo(info2, cmdDaugia, -1, 0, T.daugia);
			GameCanvas.currentDialog = inputDialog;
			break;
		}
		case 42:
		{
			MainItem mainItem9 = (MainItem)mVector3.elementAt(idSelect);
			if (mainItem9 == null)
			{
				break;
			}
			int num5 = 1;
			int num6 = 1;
			string[] array = inputDialog.getarrayText();
			if (array != null)
			{
				try
				{
					if (array.Length == 1)
					{
						if (array[0] != null)
						{
							num5 = int.Parse(array[0]);
						}
					}
					else if (array.Length == 2)
					{
						if (array[0] != null)
						{
							num5 = int.Parse(array[0]);
						}
						if (array[1] != null)
						{
							num6 = int.Parse(array[1]);
						}
					}
				}
				catch (Exception)
				{
					GameCanvas.start_Ok_Dialog(T.nhapsai);
					num5 = 1;
					break;
				}
			}
			string str3 = T.hoidaugia + mainItem9.itemName + " " + T.voigia + " " + MainItem.getDotNumber(num5) + " " + T.coin + " ?";
			if (num6 > 1)
			{
				str3 = T.hoidaugia + " " + num6 + " " + mainItem9.itemName + " " + T.voigia + " " + MainItem.getDotNumber(num5) + " " + T.coin + " ?";
			}
			item_sell item_sell2 = new item_sell();
			item_sell2.price = num5;
			item_sell2.soluuong = (short)num6;
			mVector mVector9 = new mVector();
			mVector9.addElement(new iCommand(T.yes, 43, item_sell2, this));
			mVector9.addElement(new iCommand(T.cancel, 35, this));
			GameCanvas.start_Select_Dialog(str3, mVector9);
			break;
		}
		case 44:
			inputDialog = new InputDialog();
			inputDialog.setinfoSmallNew(T.nhapSlogan, cmdOkSell, isNum: false, -1, 0L, string.Empty);
			GameCanvas.currentDialog = inputDialog;
			break;
		case 45:
			GlobalService.gI().do_Buy_Sell_Item(0, Item.VecItem_Sell_in_store, inputDialog.tfInput.getText(), 0, 0, 0);
			GameCanvas.end_Dialog();
			if (vecListCmd != null)
			{
				vecListCmd.removeAllElements();
				vecListCmd.addElement(cmdNghiban);
			}
			setPosCmd(vecListCmd);
			break;
		case 46:
		{
			MainItem mainItem8 = (MainItem)mVector3.elementAt(idSelect);
			if (mainItem8 != null)
			{
				if (mainItem8.ItemCatagory == 3)
				{
					GlobalService.gI().do_Buy_Sell_Item(2, null, string.Empty, idSeller, mainItem8.Id, (sbyte)mainItem8.ItemCatagory);
				}
				else if (mainItem8.ItemCatagory == 7)
				{
					GlobalService.gI().do_Buy_Sell_Item(2, null, string.Empty, idSeller, mainItem8.Id, (sbyte)mainItem8.ItemCatagory);
				}
				else if (mainItem8.ItemCatagory == 4)
				{
					GlobalService.gI().do_Buy_Sell_Item(2, null, string.Empty, idSeller, mainItem8.Id, (sbyte)mainItem8.ItemCatagory);
				}
			}
			break;
		}
		case 47:
			Item.VecItem_Sell_in_store.removeAllElements();
			Item.VecItemSell.removeAllElements();
			break;
		case 48:
			GlobalService.gI().do_Buy_Sell_Item(4, null, string.Empty, 0, 0, 0);
			break;
		case 49:
			inputWorld = new InputDialog();
			inputWorld.setinfo(T.nhapnoidung, new iCommand(T.chat, 50, this), isNum: false, T.textkenhthegioi);
			inputWorld.tfInput.isnewTF = true;
			newinput.TYPE_INPUT = 2;
			((Selectable)newinput.input).Select();
			newinput.input.ActivateInputField();
			GameCanvas.currentDialog = inputWorld;
			break;
		case 50:
			textWorld = newinput.input.text;
			if (textWorld != null && textWorld.Length > 0)
			{
				GameCanvas.start_Left_Dialog(T.kenhthegioi + " (" + T.phi + PriceChatWorld + " " + T.gem + ")" + T.noidungnhusau + "\n" + textWorld, new iCommand(T.chat, 51, this));
			}
			break;
		case 51:
			GlobalService.gI().Chat_World(textWorld);
			newinput.input.text = string.Empty;
			newinput.TYPE_INPUT = -1;
			newinput.input.DeactivateInputField();
			GameCanvas.end_Dialog();
			break;
		case 52:
		{
			MainItem mainItem7 = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (mainItem7 != null)
			{
				if (TabRebuildItem.itemRe != null)
				{
					TabRebuildItem.itemRe = null;
				}
				GlobalService.gI().Hop_rac(0, (short)mainItem7.Id, (sbyte)mainItem7.ItemCatagory);
			}
			vecListCmd.removeAllElements();
			break;
		}
		case 53:
		{
			MainItem mainItem6 = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (mainItem6 != null)
			{
				GlobalService.gI().Hop_rac(1, (short)mainItem6.Id, (sbyte)mainItem6.ItemCatagory);
			}
			vecListCmd.removeAllElements();
			break;
		}
		case 54:
		{
			MainItem mainItem4 = (MainItem)Item.VecInvetoryPlayer.elementAt(idSelect);
			if (mainItem4 != null)
			{
				TabRebuildItem.itemRe = mainItem4;
				GlobalService.gI().Hop_rac(0, (short)mainItem4.Id, (sbyte)mainItem4.ItemCatagory);
			}
			vecListCmd.removeAllElements();
			break;
		}
		case 55:
		{
			inputDialog = new InputDialog();
			string[] info = new string[2]
			{
				T.nhapgiaban,
				T.soluong
			};
			inputDialog.setinfo(info, cmdDaugia, -1, 0, T.daugia);
			GameCanvas.currentDialog = inputDialog;
			break;
		}
		case 56:
			currentTab++;
			if (currentTab > maxTab - 1)
			{
				currentTab = 0;
			}
			if (!GameCanvas.isTouch)
			{
				if (currentTab == 0)
				{
					idSelect = 0;
				}
				if (currentTab == 1)
				{
					idSelect = 42;
				}
			}
			break;
		case 57:
		{
			MainItem mainItem = (MainItem)mVector3.elementAt(idSelect);
			if (mainItem != null)
			{
				GlobalService.gI().DoKhacItem(6, (sbyte)mainItem.ItemCatagory, (short)mainItem.Id);
			}
			break;
		}
		case 43:
			break;
		}
	}

	public mVector doMenu(Item item)
	{
		mVector mVector3 = new mVector("TabShopNew menu7");
		if (typeTab == MainTabNew.CHEST)
		{
			maxTab = (sbyte)(Player.maxChest / 42);
			if (maxTab == 1 && Item.VecChestPlayer.size() > 42)
			{
				maxTab = 2;
			}
		}
		if (typeTab == MainTabNew.INVENTORY)
		{
			maxTab = (sbyte)(Player.maxInven / 42);
		}
		if (typeTab != MainTabNew.SHOP && maxTab > 1)
		{
			mVector3.addElement(cmdNextInven);
		}
		if (isTypeShop == SHOP_NANG_CAP_MEDEL)
		{
			mVector3.addElement(cmdHopAn);
			return mVector3;
		}
		if (isTypeShop == SHOP_HOP_AN)
		{
			return mVector3;
		}
		if (isTypeShop == SHOP_NANG_CAP_MEDEL)
		{
			return mVector3;
		}
		if (GameScreen.player.isSelling())
		{
			mVector3.addElement(cmdNghiban);
			mVector3.addElement(cmdChatWorld);
			return mVector3;
		}
		if (isTypeShop == SHOP_STORE_OTHER_PLAYER)
		{
			mVector3.addElement(cmdBuyItemOtherplayer);
			return mVector3;
		}
		if (typeTab == MainTabNew.SELLITEM)
		{
			mVector3.addElement(cmdHoanThanh);
			mVector3.addElement(cmdhuy);
			return mVector3;
		}
		if (typeTab == MainTabNew.INVEN_AND_STORE)
		{
			if (Item.VecItemSell.size() > 0)
			{
				for (int i = 0; i < Item.VecItemSell.size(); i++)
				{
					MainItem mainItem = (MainItem)Item.VecItemSell.elementAt(i);
					if (mainItem.Id == item.Id)
					{
						return mVector3;
					}
				}
			}
			if (item.ItemCatagory == 3)
			{
				mVector3.addElement(cmdHoidaugia);
			}
			else
			{
				mVector3.addElement(cmdbanNguyenLieu);
			}
		}
		else if (typeTab == MainTabNew.INVENTORY && !isShop_Other_Player)
		{
			if (isTypeShop == SHOP_STORE_OTHER_PLAYER)
			{
				mVector3.addElement(cmdBuyItemOtherplayer);
			}
			else if (isTypeShop == SHOP_DUC_LO)
			{
				if (item.ItemCatagory == 7 && item.typeMaterial == Item.TYPE_BUA_HUYEN_BI)
				{
					mVector3.addElement(cmdBovao);
				}
				if (item.ItemCatagory == 3)
				{
					mVector3.addElement(cmdDuclo);
				}
			}
			else if (isTypeShop == SHOP_ANY_NGUYEN_LIEU)
			{
				if (item.ItemCatagory == 7)
				{
					if (TabRebuildItem.vecGem.size() > 0)
					{
						MainItem mainItem2 = (MainItem)TabRebuildItem.vecGem.elementAt(0);
						if (mainItem2.Id == item.Id)
						{
							mVector3.addElement(cmdlayracra);
							return mVector3;
						}
					}
					mVector3.addElement(cmdHoprac);
				}
			}
			else if (isTypeShop == SHOP_GHEP_NGOC)
			{
				if (item.ItemCatagory == 7 && item.typeMaterial == Item.TYPE_NGOC_KHAM)
				{
					if (!TabRebuildItem.isKham(item))
					{
						mVector3.addElement(cmdGhepNgoc);
					}
					if (TabRebuildItem.isKham(item))
					{
						mVector3.addElement(cmdLayra);
					}
				}
			}
			else if (isTypeShop == SHOP_KHAM_NGOC)
			{
				if (item.ItemCatagory == 3)
				{
					if (!isTabHopNL && (TabRebuildItem.itemRe == null || TabRebuildItem.itemRe.Id != item.Id || TabRebuildItem.itemRe.ItemCatagory != item.ItemCatagory))
					{
						mVector3.addElement(cmdKhamgoc);
					}
				}
				else if (item.ItemCatagory == 7 && item.typeMaterial == 49)
				{
					mVector3.addElement(cmdBovao);
					if (TabRebuildItem.isKham(item))
					{
						mVector3.addElement(cmdLayra);
					}
				}
			}
			else if (isTypeShop == INVEN_AND_REBUILD)
			{
				if (item.ItemCatagory == 3)
				{
					if (!isTabHopNL)
					{
						if (TabRebuildItem.itemRe == null || TabRebuildItem.itemRe.Id != item.Id || TabRebuildItem.itemRe.ItemCatagory != item.ItemCatagory)
						{
							mVector3.addElement(cmdRebuild);
						}
						else
						{
							mVector3.addElement(cmdUnRebuild);
						}
					}
				}
				else if (item.ItemCatagory == 7)
				{
					if (item.typeMaterial == 11)
					{
						if (!isTabHopNL)
						{
							if (!TabRebuildItem.isLucky)
							{
								TabRebuildItem.itemDaMayMan = item;
								mVector3.addElement(cmdRebuild);
							}
							else
							{
								mVector3.addElement(cmdUnRebuild);
							}
						}
					}
					else if (MainObject.isMaHopNguyenLieu((short)item.Id) && isTabHopNL)
					{
						if (TabRebuildItem.itemRe == null || TabRebuildItem.itemRe.Id != item.Id || TabRebuildItem.itemRe.ItemCatagory != item.ItemCatagory)
						{
							mVector3.addElement(cmdHopNguyeLieu);
						}
						else
						{
							mVector3.addElement(cmdUnRebuild);
						}
					}
				}
			}
			else if (isTypeShop == INVEN_AND_REPLACE)
			{
				if (item.ItemCatagory == 3)
				{
					mVector3.addElement(cmdReplace);
				}
			}
			else if (isTypeShop == INVEN_AND_CHEST)
			{
				if (item.ItemCatagory != 5)
				{
					if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
					{
						mVector3.addElement(cmdSetPotionChest);
					}
					else
					{
						mVector3.addElement(cmdSetChest);
					}
				}
			}
			else if (isTypeShop == INVEN_AND_PET_KEEPER)
			{
				if (item.ItemCatagory == 3 && item.type_Only_Item == 14)
				{
					mVector3.addElement(cmdDepositPet);
				}
			}
			else if (isTypeShop == INVEN_AND_WING)
			{
				if (item.ItemCatagory == 3 && item.type_Only_Item == 7)
				{
					mVector3.addElement(cmdWing);
				}
			}
			else if (isTypeShop == INVEN_FOOD_PET)
			{
				mVector3.addElement(cmdFoodPet);
			}
			else
			{
				if (GameCanvas.currentScreen == GameCanvas.shopNpc && item.canSell == 1)
				{
					mVector3.addElement(cmdHoiSell);
					if (item.ItemCatagory == 3)
					{
						mVector3.addElement(cmdSellMore);
					}
				}
				if (GameCanvas.currentScreen != GameCanvas.shopNpc)
				{
					mVector3.addElement(cmdSelect);
					if (item.ItemCatagory == 4 && item.typePotion < 2)
					{
						mVector3.addElement(cmdSetKey);
					}
				}
				if (GameCanvas.currentScreen == GameCanvas.AllInfo)
				{
					mVector3.addElement(cmdHoiXoaItem);
				}
			}
		}
		else if (typeTab == MainTabNew.CHEST)
		{
			if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
			{
				mVector3.addElement(cmdGetPotionChest);
			}
			else
			{
				mVector3.addElement(cmdGetChest);
			}
		}
		else if (typeTab != MainTabNew.SELLITEM)
		{
			if (typeTab == MainTabNew.PET_KEEPER)
			{
				if (isTypeShop == INVEN_AND_PET_KEEPER && item.ItemCatagory == 9)
				{
					mVector3.addElement(cmdPetFeed);
					mVector3.addElement(cmdWithdrawPet);
				}
			}
			else if (typeTab == MainTabNew.CLAN_INVENTORY)
			{
				mVector3.addElement(cmdSelect);
			}
			else
			{
				cmdHoiMua.caption = T.buy;
				if (IDTab == ReadMessenge.SHOP_ITEM_EVENT)
				{
					cmdHoiMua.caption = nameCmdBuy;
				}
				if (item.ItemCatagory == 6 && item.priceItem <= 0)
				{
					cmdHoiMua.caption = T.use;
				}
				if (isTypeShop == WING)
				{
					mVector3.addElement(cmdCreateWing);
				}
				else if (isTypeShop != SHOP_VANTIEU && !isShop_Other_Player)
				{
					mVector mVector4 = vecShop;
					item = (Item)mVector4.elementAt(idSelect);
					if (item != null || !item.setNameNull())
					{
						if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
						{
							mVector3.addElement(cmdMua1);
							mVector3.addElement(cmdMua10);
							mVector3.addElement(cmdMua30);
							mVector3.addElement(cmdMuaNhieu);
						}
						else
						{
							mVector3.addElement(cmdHoiMua);
						}
					}
				}
				if (isTypeShop == SHOP_BANG)
				{
					cmdHoiMua.caption = T.select;
					mVector3.addElement(cmdNextIcon);
				}
			}
		}
		if (typeTab == MainTabNew.INVENTORY)
		{
			mVector3.addElement(cmdKhacItem);
		}
		return mVector3;
	}

	public override void paint(mGraphics g)
	{
		mVector mVector3 = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell : ((typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecInvetoryPlayer : ((typeTab == MainTabNew.CHEST) ? Item.VecChestPlayer : ((typeTab == MainTabNew.PET_KEEPER) ? Item.VecPetContainer : ((typeTab != MainTabNew.CLAN_INVENTORY) ? vecShop : Item.VecClanInvetory)))));
		GameCanvas.resetTrans(g);
		g.setClip(xBegin - MainTabNew.wOne5, yBegin, MainTabNew.wblack + MainTabNew.wOne5 * 2, MainTabNew.hblack - MainTabNew.wOne5 / 2 + 1);
		g.translate(-MainScreen.cameraSub.xCam, -MainScreen.cameraSub.yCam);
		int num = mVector3.size();
		if (num > 42)
		{
			num = 42;
		}
		if (isShop)
		{
			num = vecShop.size();
		}
		int num2 = 42 * currentTab;
		for (int i = 0; i < num; i++)
		{
			Item item = (Item)mVector3.elementAt(i + num2);
			if (item == null)
			{
				continue;
			}
			if (item.ItemCatagory == 7)
			{
				MainItem material = Item.getMaterial(item.Id);
				if (material != null)
				{
					item.setinfo(material.itemName, material.imageId, 7, item.priceItem, item.priceType, material.content, (short)material.value, material.typeMaterial, 1, material.canSell, material.canTrade);
					item.setColorName(material.colorNameItem);
					item.paintItem(g, xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem, MainTabNew.wOneItem, 0, 0);
				}
				else
				{
					Item.put_Material(item.Id);
				}
			}
			else
			{
				item.paintItem(g, xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem, MainTabNew.wOneItem, 0, 0);
			}
			if (item.timeUse > 0)
			{
				g.drawRegion(AvMain.imgDelaySkill, 0, 0, MainTabNew.wOneItem - 1, MainTabNew.wOneItem - 1, 0, xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem, 3, mGraphics.isTrue);
			}
			if (typeTab == MainTabNew.INVEN_AND_STORE && !GameScreen.player.isSelling() && Item.VecItemSell.size() > 0)
			{
				for (int j = 0; j < Item.VecItemSell.size(); j++)
				{
					MainItem mainItem = (MainItem)Item.VecItemSell.elementAt(j);
					if (mainItem.Id == item.Id)
					{
						g.setColor(265698349);
						g.drawRect(xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, MainTabNew.wOneItem - 8, MainTabNew.wOneItem - 8, mGraphics.isTrue);
					}
				}
			}
			if (isTypeShop == SHOP_NANG_CAP_MEDEL || isTypeShop == SHOP_ANY_NGUYEN_LIEU || isTypeShop == SHOP_KHAM_NGOC || isTypeShop == SHOP_GHEP_NGOC || isTypeShop == SHOP_DUC_LO)
			{
				if (TabRebuildItem.itemRe != null && item.Id == TabRebuildItem.itemRe.Id && item.ItemCatagory == TabRebuildItem.itemRe.ItemCatagory)
				{
					g.setColor(268038149);
					g.drawRect(xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, MainTabNew.wOneItem - 8, MainTabNew.wOneItem - 8, mGraphics.isTrue);
				}
				if (TabRebuildItem.vecGem.size() > 0)
				{
					for (int k = 0; k < TabRebuildItem.vecGem.size(); k++)
					{
						MainItem mainItem2 = (MainItem)TabRebuildItem.vecGem.elementAt(k);
						g.setColor(268038149);
						if (mainItem2 != null && (item.typeMaterial == Item.TYPE_NGOC_KHAM || item.typeMaterial == Item.TYPE_BUA_HUYEN_BI || isTypeShop == SHOP_ANY_NGUYEN_LIEU) && item.Id == mainItem2.Id && item.ItemCatagory == mainItem2.ItemCatagory)
						{
							g.drawRect(xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, MainTabNew.wOneItem - 8, MainTabNew.wOneItem - 8, mGraphics.isTrue);
						}
					}
				}
			}
			else if (isTypeShop == INVEN_AND_REBUILD)
			{
				if (TabRebuildItem.itemRe != null && ((item.Id == TabRebuildItem.itemRe.Id && item.ItemCatagory == TabRebuildItem.itemRe.ItemCatagory) || (item.ItemCatagory == 7 && item.typeMaterial == 11 && TabRebuildItem.isLucky)))
				{
					g.setColor(16379909);
					g.drawRect(xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, MainTabNew.wOneItem - 8, MainTabNew.wOneItem - 8, mGraphics.isTrue);
				}
			}
			else if (isTypeShop == INVEN_AND_REPLACE)
			{
				if (TabRebuildItem.itemFree != null && item.Id == TabRebuildItem.itemFree.Id && item.ItemCatagory == TabRebuildItem.itemFree.ItemCatagory)
				{
					g.setColor(16379909);
					g.drawRect(xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, MainTabNew.wOneItem - 8, MainTabNew.wOneItem - 8, mGraphics.isTrue);
				}
				if (TabRebuildItem.itemPlus != null && item.Id == TabRebuildItem.itemPlus.Id && item.ItemCatagory == TabRebuildItem.itemPlus.ItemCatagory)
				{
					g.setColor(14040109);
					g.drawRect(xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, MainTabNew.wOneItem - 8, MainTabNew.wOneItem - 8, mGraphics.isTrue);
				}
			}
			else if (isTypeShop == INVEN_AND_WING && TabRebuildItem.itemWing != null && item.Id == TabRebuildItem.itemWing.Id && item.ItemCatagory == TabRebuildItem.itemWing.ItemCatagory)
			{
				g.setColor(16379909);
				g.drawRect(xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem - MainTabNew.wOneItem / 2 + 4, MainTabNew.wOneItem - 8, MainTabNew.wOneItem - 8, mGraphics.isTrue);
			}
			if (item.ItemCatagory == 4 && item.typePotion < 2 && typeTab == MainTabNew.INVENTORY && Player.timeDelayPotion[item.typePotion].value > 0)
			{
				g.drawRegion(AvMain.imgDelaySkill, 0, 0, MainTabNew.wOneItem - 1, MainTabNew.wOneItem - 1, 0, xBegin + MainTabNew.wOneItem / 2 + i % numW * MainTabNew.wOneItem, yBegin + MainTabNew.wOneItem / 2 + i / numW * MainTabNew.wOneItem, 3, mGraphics.isFalse);
			}
		}
		g.setColor(MainTabNew.color[1]);
		g.drawRect(xBegin, yBegin, MainTabNew.wblack, MainTabNew.wOneItem * numH, mGraphics.isTrue);
		for (int l = 0; l < numW / 2; l++)
		{
			g.drawRect(xBegin + MainTabNew.wOneItem + l * MainTabNew.wOneItem * 2, yBegin, MainTabNew.wOneItem, MainTabNew.wOneItem * numH, mGraphics.isTrue);
		}
		for (int m = 0; m < numH / 2; m++)
		{
			g.drawRect(xBegin, yBegin + MainTabNew.wOneItem + m * MainTabNew.wOneItem * 2, MainTabNew.wblack, MainTabNew.wOneItem, mGraphics.isTrue);
		}
		if (idSelect > -1 && MainTabNew.Focus == MainTabNew.INFO)
		{
			g.setColor(MainTabNew.color[2]);
			g.drawRect(xBegin + (idSelect - currentTab * 42) % numW * MainTabNew.wOneItem + 1, yBegin + (idSelect - currentTab * 42) / numW * MainTabNew.wOneItem + 1, MainTabNew.wOneItem - 2, MainTabNew.wOneItem - 2, mGraphics.isTrue);
			g.setColor(MainTabNew.color[3]);
			g.drawRect(xBegin + (idSelect - currentTab * 42) % numW * MainTabNew.wOneItem, yBegin + (idSelect - currentTab * 42) / numW * MainTabNew.wOneItem, MainTabNew.wOneItem, MainTabNew.wOneItem, mGraphics.isTrue);
		}
		g.endClip();
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && MainTabNew.Focus == MainTabNew.INFO && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			paintPopupContent(g, isOnlyName: false);
			if (vecListCmd != null)
			{
				for (int n = 0; n < vecListCmd.size(); n++)
				{
					iCommand iCommand2 = (iCommand)vecListCmd.elementAt(n);
					iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
				}
			}
		}
		if (GameScreen.help.Step >= 0)
		{
			Item item2 = null;
			if (idSelect > -1 && MainTabNew.Focus == MainTabNew.INFO)
			{
				item2 = (Item)mVector3.elementAt(idSelect);
			}
			if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null)
			{
				GameScreen.help.itemTabHelp(g, item2, typeTab);
			}
		}
		if (!GameCanvas.isSmallScreen && isTypeShop == TOC)
		{
			Item item3 = null;
			if (idSelect > -1 && MainTabNew.Focus == MainTabNew.INFO)
			{
				item3 = (Item)mVector3.elementAt(idSelect);
			}
			int hair = GameScreen.player.hair;
			if (item3 != null)
			{
				hair = item3.imageId;
			}
			paintHairShop(g, hair);
		}
		if (!GameScreen.player.isSelling() && typeTab == MainTabNew.SELLITEM && idSelect >= 0 && idSelect < Item.VecItem_Sell_in_store.size())
		{
			item_sell item_sell2 = (item_sell)Item.VecItem_Sell_in_store.elementAt(idSelect);
			if (item_sell2 != null)
			{
				mFont.tahoma_7_yellow.drawString(g, T.price + ": " + MainItem.getDotNumber(item_sell2.price) + " " + T.coin, xBegin, yBegin + MainTabNew.wOneItem * 6, 0, mGraphics.isFalse);
			}
		}
	}

	public override void update()
	{
		if (typeTab != NORMAL && typeTab != MainTabNew.INVEN_AND_STORE && typeTab != MainTabNew.CHEST && typeTab != MainTabNew.PET_KEEPER && currentTab != 0)
		{
			currentTab = 0;
		}
		if (GameScreen.help.Step > 0)
		{
			GameScreen.help.updateHelp();
		}
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
			mVector mVector3 = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell : ((typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecInvetoryPlayer : ((typeTab == MainTabNew.CHEST) ? Item.VecChestPlayer : ((typeTab != MainTabNew.CLAN_INVENTORY) ? vecShop : Item.VecClanInvetory))));
			if (mVector3.size() == 0)
			{
				MainTabNew.Focus = MainTabNew.TAB;
				return;
			}
			if (idSelect >= mVector3.size())
			{
				if (GameCanvas.isTouch)
				{
					idSelect = -1;
					vecListCmd = null;
				}
				else
				{
					idSelect = mVector3.size() - 1;
				}
			}
			if (typeTab != SHOP_BANG)
			{
				updateContent(mVector3, idSelect);
			}
		}
		else
		{
			MainTabNew.timePaintInfo = 0;
		}
		if (currentTab == 0 && idSelect > 42 && !isShop)
		{
			idSelect = -1;
		}
	}

	public void updateContent(mVector vec, int idSelect)
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
				if (typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE)
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
			moreInfoconten = item.moreContenGem;
			mContent = item.mcontent;
			mcolor = item.mColor;
			setYCon(item);
		}
	}

	public override void updatekey()
	{
		mVector mVector3 = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell : ((typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecInvetoryPlayer : ((typeTab == MainTabNew.CHEST) ? Item.VecChestPlayer : ((typeTab != MainTabNew.CLAN_INVENTORY) ? vecShop : Item.VecClanInvetory))));
		if (MainTabNew.Focus == MainTabNew.INFO)
		{
			int num = idSelect;
			bool flag = false;
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
				idSelect -= numW;
				GameCanvas.clearKeyHold(2);
				flag = true;
			}
			else if (GameCanvas.keyMyHold[8])
			{
				idSelect += numW;
				GameCanvas.clearKeyHold(8);
				flag = true;
			}
			if (GameCanvas.keyMyHold[4])
			{
				if (idSelect % numW == 0 && currentTab == 0)
				{
					MainTabNew.Focus = MainTabNew.TAB;
				}
				else
				{
					idSelect--;
				}
				if (currentTab == 1 && idSelect == 41)
				{
					currentTab--;
				}
				if (currentTab == 2 && idSelect == 82)
				{
					currentTab--;
				}
				GameCanvas.clearKeyHold(4);
				flag = true;
			}
			else if (GameCanvas.keyMyHold[6])
			{
				idSelect++;
				GameCanvas.clearKeyHold(6);
				if (maxTab > 1 && idSelect > 0 && idSelect % 42 == 0)
				{
					currentTab++;
					if (currentTab > maxTab - 1)
					{
						currentTab = 0;
						idSelect = 0;
					}
				}
				flag = true;
			}
			if (flag)
			{
				listContent = null;
				idSelect = resetSelect(idSelect, mVector3.size() - 1, isreset: false);
				if (!GameCanvas.isTouch && (typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE || typeTab == MainTabNew.CHEST || typeTab == MainTabNew.SELLITEM))
				{
					center = cmdMenuInven;
				}
				TabScreenNew.timeRepaint = 10;
			}
			if (num != idSelect)
			{
				MainScreen.cameraSub.moveCamera(0, (idSelect / numW - 1) * MainTabNew.wOneItem);
				MainTabNew.timePaintInfo = 0;
			}
		}
		base.updatekey();
	}

	public override void setPaintInfo()
	{
		mContent = null;
		mSubContent = null;
		mPlusContent = null;
		mVector mVector3 = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell : ((typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecInvetoryPlayer : ((typeTab == MainTabNew.CHEST) ? Item.VecChestPlayer : ((typeTab != MainTabNew.CLAN_INVENTORY) ? vecShop : Item.VecClanInvetory))));
		if (idSelect >= mVector3.size() || idSelect < 0)
		{
			if (idSelect > mVector3.size() - 1)
			{
				idSelect = mVector3.size() - 1;
			}
			MainTabNew.timePaintInfo = 0;
			return;
		}
		Item item = (Item)mVector3.elementAt(idSelect);
		if (item != null && item.setNameNull())
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
		if (item.ItemCatagory == 7)
		{
			MainItem material = Item.getMaterial(item.Id);
			if (material != null)
			{
				colorName = material.colorNameItem;
				if (typeTab == MainTabNew.SELLITEM && item.isSell)
				{
					mPlusContent = item.mPlusContent;
					mPlusColor = item.mPlusColor;
				}
			}
		}
		moreInfoconten = item.moreContenGem;
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
			if (num * GameCanvas.hText > MainTabNew.hMaxContent - hcmd)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - (MainTabNew.hMaxContent - hcmd));
			}
			else if (GameCanvas.isTouch)
			{
				listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, 0);
			}
			sosanh(item);
		}
		else
		{
			wContent = item.sizeW;
			setYCon(item);
			if (idSelect % numW < 2)
			{
				xCon = xBegin + MainTabNew.wOneItem / 2 + idSelect % numW * MainTabNew.wOneItem;
			}
			else if (idSelect % numW < 5)
			{
				xCon = xBegin + MainTabNew.wOneItem / 2 + idSelect % numW * MainTabNew.wOneItem - wContent / 2;
			}
			else
			{
				xCon = xBegin + MainTabNew.wOneItem / 2 + idSelect % numW * MainTabNew.wOneItem - wContent;
			}
		}
	}

	public override void setYCon(Item item)
	{
		int num = 0;
		if (MainScreen.cameraSub.yCam > 0)
		{
			num = MainScreen.cameraSub.yCam / MainTabNew.wOneItem;
		}
		int num2 = 1;
		mContent = item.mcontent;
		moreInfoconten = item.moreContenGem;
		mcolor = item.mColor;
		if (item.mcontent != null)
		{
			num2 += mContent.Length;
		}
		if (item.mPlusContent != null)
		{
			num2 += item.mPlusContent.Length;
		}
		if (idSelect / numW < numHPaint / 2 + num)
		{
			yCon = yBegin + (idSelect / numW + 1) * MainTabNew.wOneItem + 2;
			if (yCon - MainScreen.cameraSub.yCam + (num2 + 1) * GameCanvas.hText > GameCanvas.h - (GameCanvas.hCommand - 5))
			{
				yCon = GameCanvas.h - (GameCanvas.hCommand - 5) - ((num2 + 1) * GameCanvas.hText - MainScreen.cameraSub.yCam);
			}
		}
		else
		{
			yCon = yBegin + idSelect / numW * MainTabNew.wOneItem - 7 - num2 * GameCanvas.hText - MainScreen.cameraSub.yCam;
			if (yCon - MainScreen.cameraSub.yCam < 6)
			{
				yCon = 6 + MainScreen.cameraSub.yCam;
			}
		}
		if ((num2 + 1) * GameCanvas.hText > MainTabNew.hMaxContent - hcmd)
		{
			listContent = new ListNew(xCon, yCon, wContent, MainTabNew.hMaxContent, 0, 0, (num2 + 1) * GameCanvas.hText - (MainTabNew.hMaxContent - hcmd));
		}
		sosanh(item);
	}

	public void sosanh(Item item)
	{
		if (typeTab != MainTabNew.INVENTORY || item.ItemCatagory != 3 || (item.classcharItem != 4 && item.classcharItem != GameScreen.player.clazz) || item.type_Only_Item >= 12)
		{
			return;
		}
		sbyte b = (sbyte)MainTemplateItem.mItem_Rotate_Tem_Equip[item.type_Only_Item];
		Item item2 = null;
		if (b == -1)
		{
			int num = 0;
			int num2 = 0;
			Item item3 = (Item)Item.VecEquipPlayer.get(string.Empty + (sbyte)3);
			Item item4 = (Item)Item.VecEquipPlayer.get(string.Empty + (sbyte)9);
			if (item3 == null)
			{
				item2 = item4;
			}
			else if (item4 == null)
			{
				item2 = item3;
			}
			else
			{
				for (int i = 0; i < item3.mInfo.Length; i++)
				{
					num += item3.mInfo[i].value;
				}
				for (int j = 0; j < item4.mInfo.Length; j++)
				{
					num2 += item4.mInfo[j].value;
				}
				item2 = ((num < num2) ? item3 : item4);
			}
		}
		else
		{
			item2 = (Item)Item.VecEquipPlayer.get(string.Empty + b);
		}
		if (item2 == null || item2.type_Only_Item != item.type_Only_Item || mContent == null || item2.moreContenGem.size() > 0)
		{
			return;
		}
		mSubContent = new string[mContent.Length];
		mSubColor = new int[mContent.Length];
		for (int k = 0; k < mSubContent.Length; k++)
		{
			mSubContent[k] = string.Empty;
			mSubColor[k] = 0;
			for (int l = 0; l < item2.mInfo.Length; l++)
			{
				if (item.mInfo[k].id == item2.mInfo[l].id)
				{
					int num3 = item.mInfo[k].value - item2.mInfo[l].value;
					if (num3 >= 0)
					{
						mSubColor[k] = 5;
						mSubContent[k] = "+";
					}
					else
					{
						mSubContent[k] = "-";
						mSubColor[k] = 6;
					}
					mSubContent[k] += Item.getPercent(Item.isPercentInfoItem[item.mInfo[k].id], CRes.abs(num3));
					string text = Item.nameInfoItem[item.mInfo[k].id] + ": " + Item.getPercent(Item.isPercentInfoItem[item.mInfo[k].id], item.mInfo[k].value);
					int width = mFont.tahoma_7_black.getWidth(text + " " + mSubContent[k]);
					if (wContent < width + 10)
					{
						wContent = width + 10;
					}
					break;
				}
			}
		}
	}

	public override void updatePointer()
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
			int num2 = 0;
			num2 = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell.size() : ((typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecInvetoryPlayer.size() : ((typeTab == MainTabNew.CHEST) ? Item.VecChestPlayer.size() : ((typeTab == MainTabNew.CLAN_INVENTORY) ? Item.VecClanInvetory.size() : ((typeTab != MainTabNew.PET_KEEPER) ? vecShop.size() : Item.VecPetContainer.size())))));
			if (num >= 0 && num < num2)
			{
				GameCanvas.isPointerSelect = false;
				if (num == idSelect)
				{
					if (MainTabNew.longwidth == 0)
					{
						if (typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE || typeTab == MainTabNew.CHEST || typeTab == MainTabNew.SELLITEM || typeTab == MainTabNew.CLAN_INVENTORY || (typeTab == MainTabNew.SHOP && isTypeShop == SHOP_BANG) || typeTab == MainTabNew.PET_KEEPER)
						{
							cmdMenuInven.perform();
						}
						else if (isTypeShop == WING)
						{
							cmdCreateWing.perform();
						}
						else
						{
							cmdHoiMua.perform();
						}
					}
				}
				else
				{
					MainTabNew.timePaintInfo = 0;
					idSelect = num + 42 * currentTab;
					if (currentTab == 0 && idSelect == 42)
					{
						idSelect = -1;
					}
					if (currentTab == 1 && idSelect == 84)
					{
						idSelect = -1;
					}
					if (currentTab == 3 && idSelect == 126)
					{
						idSelect = -1;
					}
					if (isShop)
					{
						idSelect = num;
					}
					cmdListBig();
					listContent = null;
				}
				if (MainTabNew.Focus != MainTabNew.INFO)
				{
					MainTabNew.Focus = MainTabNew.INFO;
				}
			}
			else
			{
				idSelect = -1;
				MainTabNew.timePaintInfo = 0;
				listContent = null;
			}
		}
		if (vecListCmd != null && MainTabNew.Focus == MainTabNew.INFO && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			for (int i = 0; i < vecListCmd.size(); i++)
			{
				iCommand iCommand2 = (iCommand)vecListCmd.elementAt(i);
				iCommand2.updatePointer();
			}
		}
		base.updatePointer();
	}

	public void cmdListBig()
	{
		if (MainTabNew.longwidth > 0 && GameCanvas.isTouch)
		{
			hcmd = 0;
			mVector mVector3 = ((typeTab == MainTabNew.SELLITEM) ? Item.VecItemSell : ((typeTab == MainTabNew.INVENTORY || typeTab == MainTabNew.INVEN_AND_STORE) ? Item.VecInvetoryPlayer : ((typeTab != MainTabNew.CHEST) ? vecShop : Item.VecChestPlayer)));
			if (idSelect >= 0 && idSelect < mVector3.size())
			{
				Item item = (Item)mVector3.elementAt(idSelect);
				vecListCmd = doMenu(item);
				setPosCmd(vecListCmd);
				hcmd = (vecListCmd.size() + 1) / 2 * iCommand.hButtonCmd;
			}
		}
	}
}
