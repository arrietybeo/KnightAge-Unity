public class mFont
{
	public static int LEFT;

	public static sbyte RIGHT = 1;

	public static sbyte CENTER = 2;

	public static sbyte RED;

	public static sbyte YELLOW = 1;

	public static sbyte GREEN = 2;

	public static sbyte FATAL = 3;

	public static sbyte MISS = 4;

	public static sbyte ORANGE = 5;

	public static sbyte ADDMONEY = 6;

	public static sbyte MISS_ME = 7;

	public static sbyte FATAL_ME = 8;

	private int space;

	private int height;

	private string strFont;

	public FontSys fontS;

	public static string str = " 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW";

	public static mFont tahoma_7b_orange;

	public static mFont tahoma_7b_blue;

	public static mFont tahoma_7b_black;

	public static mFont tahoma_7b_yellow;

	public static mFont tahoma_7b_violet;

	public static mFont tahoma_7b_white;

	public static mFont tahoma_7b_green;

	public static mFont tahoma_7b_red;

	public static mFont tahoma_7b_brown;

	public static mFont tahoma_7_black;

	public static mFont tahoma_7_white;

	public static mFont tahoma_7_yellow;

	public static mFont tahoma_7_orange;

	public static mFont tahoma_7_red;

	public static mFont tahoma_7_blue;

	public static mFont tahoma_7_green;

	public static mFont tahoma_7_violet;

	public static mFont number_yellow;

	public static mFont number_red;

	public static mFont number_green;

	public static mFont number_white;

	public static mFont number_orange;

	public static mFont tahoma_8b_brown;

	public static mFont tahoma_8b_black;

	public static mFont number_Yellow_Small;

	public static mFont tahoma_7_gray;

	private string pathImage;

	public mFont(string strFont, string pathImage, string pathData, int space, int id)
	{
		int num = setColorFontByID(id);
		fontS = new FontSys((sbyte)id, num, num);
	}

	public mFont(string strFont, string pathImage, string pathData, int space, int color, sbyte ID)
	{
		color = setColorFontByID(ID);
		fontS = new FontSys(ID, color, color);
	}

	public static void loadmFont()
	{
		tahoma_7b_orange = new mFont(str, "/mfont/tahoma_7b_orange.png", "/mfont/tahoma_7b", 0, 0);
		tahoma_7b_blue = new mFont(str, "/mfont/tahoma_7b_blue.png", "/mfont/tahoma_7b", 0, 1);
		tahoma_7b_black = new mFont(str, "/mfont/tahoma_7b_black.png", "/mfont/tahoma_7b", 0, 2);
		tahoma_7b_yellow = new mFont(str, "/mfont/tahoma_7b_yellow.png", "/mfont/tahoma_7b", 0, 3);
		tahoma_7b_violet = new mFont(str, "/mfont/tahoma_7b_violet.png", "/mfont/tahoma_7b", 0, 4);
		tahoma_7b_white = new mFont(str, "/mfont/tahoma_7b_white.png", "/mfont/tahoma_7b", 0, 5);
		tahoma_7b_green = new mFont(str, "/mfont/tahoma_7b_green.png", "/mfont/tahoma_7b", 0, 6);
		tahoma_7b_brown = new mFont(str, "/mfont/tahoma_7b_brown.png", "/mfont/tahoma_7b", 0, 7);
		tahoma_7b_red = new mFont(str, "/mfont/tahoma_7b_red.png", "/mfont/tahoma_7b", 0, 8);
		tahoma_7_black = new mFont(str, "/mfont/tahoma_7_black.png", "/mfont/tahoma_7", 0, 9);
		tahoma_7_white = new mFont(str, "/mfont/tahoma_7_white.png", "/mfont/tahoma_7", 0, 10);
		tahoma_7_yellow = new mFont(str, "/mfont/tahoma_7_yellow.png", "/mfont/tahoma_7", 0, 11);
		tahoma_7_orange = new mFont(str, "/mfont/tahoma_7_orange.png", "/mfont/tahoma_7", 0, 12);
		tahoma_7_red = new mFont(str, "/mfont/tahoma_7_red.png", "/mfont/tahoma_7", 0, 13);
		tahoma_7_blue = new mFont(str, "/mfont/tahoma_7_blue.png", "/mfont/tahoma_7", 0, 14);
		tahoma_7_green = new mFont(str, "/mfont/tahoma_7_green.png", "/mfont/tahoma_7", 0, 15);
		tahoma_7_violet = new mFont(str, "/mfont/tahoma_7_violet.png", "/mfont/tahoma_7", 0, 21);
		tahoma_7_gray = new mFont(str, "/mfont/tahoma_7_gray.png", "/mfont/tahoma_7", 0, 22);
		number_yellow = new mFont(" 0123456789+-", "/mfont/number_yellow.png", "/mfont/number", 0, 16);
		number_red = new mFont(" 0123456789+-", "/mfont/number_red.png", "/mfont/number", 0, 17);
		number_green = new mFont(" 0123456789+-", "/mfont/number_green.png", "/mfont/number", 0, 18);
		number_white = new mFont(" 0123456789+-", "/mfont/number_white.png", "/mfont/number", 0, 19);
		number_orange = new mFont(" 0123456789+-", "/mfont/number_orange.png", "/mfont/number", 0, 20);
		tahoma_8b_brown = new mFont(str, "/mfont/tahoma_7b_brown.png", "/mfont/tahoma_7b", 0, 30);
		tahoma_8b_black = new mFont(str, "/mfont/tahoma_7b_black.png", "/mfont/tahoma_7b", 0, 31);
		number_Yellow_Small = new mFont(str, "/mfont/number_yellow.png", "/mfont/number", 0, 11);
	}

	public int setColorFontByID(int id)
	{
		switch (id)
		{
		case 0:
		case 12:
		case 20:
			return 16686378;
		case 1:
		case 14:
			return 7511551;
		case 2:
		case 9:
		case 31:
			return 1250067;
		case 3:
		case 11:
		case 16:
			return 16580155;
		case 4:
		case 21:
			return 11830015;
		case 5:
		case 10:
		case 19:
			return 16777215;
		case 6:
		case 15:
		case 18:
			return 6741809;
		case 7:
			return 4724752;
		case 8:
		case 13:
		case 17:
			return 16711680;
		case 30:
			return 11957553;
		case 32:
			return 16580155;
		case 22:
			return 258434919;
		default:
			return 0;
		}
	}

	public void reloadImage()
	{
	}

	public void freeImage()
	{
	}

	public int getHeight()
	{
		return height;
	}

	public void setHeight(int height)
	{
		this.height = height;
	}

	public int getWidth(string st)
	{
		return fontS.getWidth(st);
	}

	public void drawString(mGraphics g, string st, int x, int y, int align, bool useClip)
	{
		fontS.drawString(g, st, x, y, align, useClip);
	}

	public void drawString(mGraphics g, string st, int x, int y, int align, mFont font, bool useClip)
	{
		font.fontS.drawString(g, st, x + 1, y, align, useClip);
		font.fontS.drawString(g, st, x, y + 1, align, useClip);
		fontS.drawString(g, st, x, y, align, useClip);
	}

	public void drawString(mGraphics g, string st, int x, int y, int align, mFont font1, mFont font2, bool useClip)
	{
		font1.fontS.drawString(g, st, x + 1, y, align, useClip);
		font2.fontS.drawString(g, st, x, y + 1, align, useClip);
		fontS.drawString(g, st, x, y, align, useClip);
	}

	public mVector splitFontVector(string src, int lineWidth)
	{
		return fontS.splitFontVector(src, lineWidth);
	}

	public static string[] split(string original, string separator)
	{
		return FontSys.splitStringSv(original, separator);
	}

	public string splitFirst(string str)
	{
		return fontS.splitFirst(str);
	}

	public string[] splitFontArray(string src, int lineWidth)
	{
		return fontS.splitFontArray(src, lineWidth);
	}

	public bool compare(string strSource, string str)
	{
		return fontS.compare(strSource, str);
	}
}
