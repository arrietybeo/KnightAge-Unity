public class MainClan
{
	public const sbyte THU_LINH = sbyte.MaxValue;

	public const sbyte PHO_CHI_HUY = 126;

	public const sbyte DAI_HIEP_SI = 125;

	public const sbyte HIEP_SI_CAO_QUI = 124;

	public const sbyte HIEP_SI_DANH_DU = 123;

	public const sbyte THANH_VIEN_MOI = 122;

	public const sbyte DA_ROI_CLAN = 121;

	public const sbyte XIN_GIA_NHAP = 0;

	public const sbyte TIM_CLAN_NAME = 1;

	public const sbyte THONG_BAO = 2;

	public const sbyte ACCEP_JOIN_CLAN = 3;

	public const sbyte PHONG_CAP = 4;

	public const sbyte HA_CAP = 5;

	public const sbyte GOP_XU = 6;

	public const sbyte GOP_NGOC = 7;

	public const sbyte NEXT_ICON_LIST = 8;

	public const sbyte INFO_CLAN = 9;

	public const sbyte INVITE_CLAN = 10;

	public const sbyte OK_INVITE_CLAN = 11;

	public const sbyte DELETE_CLAN = 12;

	public const sbyte MEMBER_LIST = 13;

	public const sbyte MEMBER_DETAIL = 14;

	public const sbyte CLAN_DETAIL = 15;

	public const sbyte CLAN_SLOGAN = 16;

	public const sbyte CLAN_NOIQUY = 17;

	public const sbyte REMOVE_MEM = 18;

	public const sbyte UPDATE_INFO_CLAN_OBJ = 19;

	public const sbyte ERROR_CREATE_NAME = 20;

	public const sbyte INVENTORY_CLAN = 21;

	public const sbyte X2_XP_CLAN = 22;

	public short IdIcon;

	public int IdClan;

	public string shortName;

	public string name;

	public string slogan;

	public string nameThuLinh;

	public string noiquy;

	public int numMem;

	public int maxMem;

	public int Lv;

	public int hang;

	public int gold;

	public int ptLv;

	public long coin;

	public sbyte frameClan;

	public sbyte chucvu;

	public sbyte typeX2;

	public short timeX2;

	public MainThanhTichClan[] mthanhtich;

	public bool isRemove;

	public MainClan(int IdClan, short idicon, string shortname, sbyte chucvu)
	{
		this.IdClan = IdClan;
		IdIcon = idicon;
		shortName = shortname.ToUpper();
		this.chucvu = chucvu;
	}

	public void setInfoClan(string nameClan, short Lv, short ptlv, short hang, short numMem, short maxMem, string slogan, string noiquy, string nameBoss, long coin, int gold, MainThanhTichClan[] thanhtich)
	{
		name = nameClan;
		this.Lv = Lv;
		ptLv = ptlv;
		this.hang = hang;
		this.numMem = numMem;
		this.maxMem = maxMem;
		this.slogan = slogan;
		this.noiquy = noiquy;
		nameThuLinh = nameBoss;
		this.coin = coin;
		this.gold = gold;
		mthanhtich = thanhtich;
	}

	public bool setAddMem()
	{
		if (chucvu == sbyte.MaxValue || chucvu == 126)
		{
			return true;
		}
		return false;
	}

	public int getEffChucVu()
	{
		if (chucvu == sbyte.MaxValue)
		{
			return 13;
		}
		if (chucvu == 126)
		{
			return 7;
		}
		return -1;
	}

	public bool getChucNang()
	{
		if (chucvu == sbyte.MaxValue || chucvu == 126 || chucvu == 125)
		{
			return true;
		}
		return false;
	}

	public static string getNameChucVu(sbyte chuc)
	{
		if (chuc >= 121 && chuc <= sbyte.MaxValue)
		{
			return T.mChucVuClan[127 - chuc];
		}
		return string.Empty;
	}
}
