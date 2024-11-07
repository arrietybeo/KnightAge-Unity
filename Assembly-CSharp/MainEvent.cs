public class MainEvent : AvMain
{
	public const sbyte CHAT = 0;

	public const sbyte KET_BAN = 1;

	public const sbyte PARTY = 2;

	public const sbyte BUY_SELL = 3;

	public const sbyte THACH_DAU = 4;

	public const sbyte MOI_VAO_CLAN = 5;

	public int IDObj;

	public int IDCmd;

	public int isNew;

	public int numThachDau;

	public string nameEvent;

	public string contentEvent;

	public bool isRemove;

	public MainEvent(int Obj, int Cmd, string name, string content)
	{
		IDObj = Obj;
		IDCmd = Cmd;
		nameEvent = name;
		contentEvent = content;
	}

	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 1:
			GlobalService.gI().Friend((sbyte)subIndex, nameEvent);
			isRemove = true;
			GameCanvas.end_Dialog();
			break;
		case 2:
			if (subIndex == 1)
			{
				GlobalService.gI().Party(2, nameEvent);
			}
			isRemove = true;
			GameCanvas.end_Dialog();
			break;
		case 3:
			if (subIndex == 1)
			{
				GlobalService.gI().Buy_Sell(1, nameEvent, 0, 0, 0);
			}
			isRemove = true;
			GameCanvas.end_Dialog();
			break;
		case 4:
			switch (subIndex)
			{
			case 1:
				GlobalService.gI().Thach_Dau(1, nameEvent);
				break;
			case 2:
				GlobalService.gI().Re_Info_Other_Object(nameEvent, 1);
				break;
			}
			isRemove = true;
			GameCanvas.end_Dialog();
			break;
		case 5:
			if (subIndex == 1)
			{
				GlobalService.gI().Add_And_AnS_MemClan(11, nameEvent);
			}
			isRemove = true;
			GameCanvas.end_Dialog();
			break;
		}
	}
}
