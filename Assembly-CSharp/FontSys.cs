using System;
using System.Collections;
using UnityEngine;

public class FontSys
{
    public static int LEFT = 0;

    public static int RIGHT = 1;

    public static int CENTER = 2;

    public static int RED = 0;

    public static int YELLOW = 1;

    public static int GREEN = 2;

    public static int FATAL = 3;

    public static int MISS = 4;

    public static int ORANGE = 5;

    public static int ADDMONEY = 6;

    public static int MISS_ME = 7;

    public static int FATAL_ME = 8;

    public static int HP = 9;

    public static int MP = 10;

    private int space;

    private Image imgFont;

    private string strFont;

    private int[][] fImages;

    public int yAddFont;

    public static int[] colorJava = new int[31]
    {
        0, 16711680, 6520319, 16777215, 16755200, 5449989, 21285, 52224, 7386228, 16771788,
        0, 65535, 21285, 16776960, 5592405, 16742263, 33023, 8701737, 15723503, 7999781,
        16768815, 14961237, 4124899, 4671303, 16096312, 16711680, 16755200, 52224, 16777215, 6520319,
        16096312
    };

    public Font myFont;

    private int height;

    private int wO;

    public int cl1;

    public int cl2;

    public Color color1 = Color.white;

    public Color color2 = Color.gray;

    public sbyte id;

    public int fstyle;

    public string st1 = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴĐ";

    public string st2 = "\u00b8µ¶·¹\u00a8¾»¼½Æ©ÊÇÈÉËÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô\u00adøõö÷ùýúûüþ®\u00b8µ¶·¹¡¾»¼½Æ¢ÊÇÈÉËÐÌÎÏÑ£ÕÒÓÔÖÝ×ØÜÞãßáâä¤èåæçé¥íêëìîóïñòô¦øõö÷ùýúûüþ§";

    public FontSys(sbyte id, int cl1, int cl2)
    {
        string text = "big";
        if (id <= 8 || id >= 30)
        {
            text = "big";
            yAddFont = ((mGraphics.zoomLevel != 1) ? (-2) : (-3));
        }
        else
        {
            text = "mini";
            if (mGraphics.zoomLevel == 1)
            {
                yAddFont = -1;
            }
        }
        this.id = id;
        this.cl1 = cl1;
        this.cl2 = cl2;
        text = "FontSys/x" + mGraphics.zoomLevel + "/" + text;
        myFont = Resources.Load(text) as Font;
        color1 = setColor(this.cl1);
        color2 = setColor(this.cl2);
        wO = getWidthExactOf("o");
    }

    public static void init()
    {
    }

    public Color setColor(int rgb)
    {
        int num = rgb & 0xFF;
        int num2 = (rgb >> 8) & 0xFF;
        int num3 = (rgb >> 16) & 0xFF;
        float b = (float)num / 256f;
        float g = (float)num2 / 256f;
        float r = (float)num3 / 256f;
        return new Color(r, g, b);
    }

    public Color bigColor(int id)
    {
        Color[] array = new Color[6]
        {
            Color.red,
            Color.yellow,
            Color.green,
            Color.white,
            setColor(40404),
            Color.red
        };
        return array[id - 25];
    }

    public void setTypePaint(mGraphics g, string st, int x, int y, int align, sbyte idFont, bool useClip)
    {
        sbyte b = id;
        if (idFont > 0)
        {
            b = idFont;
        }
        x--;
        color1 = setColor(cl1);
        color2 = setColor(cl2);
        _drawString(g, st, x, y, align, useClip);
    }

    public Color setColorFont(sbyte id)
    {
        return setColor(colorJava[id]);
    }

    public void drawString(mGraphics g, string st, int x, int y, int align, bool useClip)
    {
        setTypePaint(g, st, x, y, align, 0, useClip);
    }

    public void drawString(mGraphics g, string st, int x, int y, int align, FontSys font, bool useClip)
    {
        setTypePaint(g, st, x, y + 1, align, font.id, useClip);
        setTypePaint(g, st, x, y, align, 0, useClip);
    }

    public mVector splitFontVector(string src, int lineWidth)
    {
        mVector mVector3 = new mVector();
        string text = string.Empty;
        for (int i = 0; i < src.Length; i++)
        {
            if (src[i] == '\n' || src[i] == '\b')
            {
                mVector3.addElement(text);
                text = string.Empty;
                continue;
            }
            text += src[i];
            if (getWidth(text) > lineWidth)
            {
                int num = 0;
                num = text.Length - 1;
                while (num >= 0 && text[num] != ' ')
                {
                    num--;
                }
                if (num < 0)
                {
                    num = text.Length - 1;
                }
                mVector3.addElement(mSystem.substring(text, 0, num));
                i = i - (text.Length - num) + 1;
                text = string.Empty;
            }
            if (i == src.Length - 1 && !text.Trim().Equals(string.Empty))
            {
                mVector3.addElement(text);
            }
        }
        return mVector3;
    }

    public string splitFirst(string str)
    {
        string text = string.Empty;
        bool flag = false;
        for (int i = 0; i < str.Length; i++)
        {
            if (!flag)
            {
                string text2 = str.Substring(i);
                text = ((!compare(text2, " ")) ? (text + text2) : (text + str[i] + "-"));
                flag = true;
            }
            else if (str[i] == ' ')
            {
                flag = false;
            }
        }
        return text;
    }

    public string[] splitStrInLine(string src, int lineWidth)
    {
        ArrayList arrayList = splitStrInLineA(src, lineWidth);
        string[] array = new string[arrayList.Count];
        for (int i = 0; i < arrayList.Count; i++)
        {
            array[i] = (string)arrayList[i];
        }
        return array;
    }

    public ArrayList splitStrInLineA(string src, int lineWidth)
    {
        ArrayList arrayList = new ArrayList();
        int i = 0;
        int num = 0;
        int length = src.Length;
        if (length < 5)
        {
            arrayList.Add(src);
            return arrayList;
        }
        string text = string.Empty;
        try
        {
            while (true)
            {
                if (getWidthNotExactOf(text) < lineWidth)
                {
                    text += src[num];
                    num++;
                    if (src[num] != '\n')
                    {
                        if (num < length - 1)
                        {
                            continue;
                        }
                        num = length - 1;
                    }
                }
                if (num != length - 1 && src[num + 1] != ' ')
                {
                    int num2 = num;
                    while (src[num + 1] != '\n' && (src[num + 1] != ' ' || src[num] == ' ') && num != i)
                    {
                        num--;
                    }
                    if (num == i)
                    {
                        num = num2;
                    }
                }
                string text2 = src.Substring(i, num + 1 - i);
                if (text2[0] == '\n')
                {
                    text2 = text2.Substring(1, text2.Length - 1);
                }
                if (text2[text2.Length - 1] == '\n')
                {
                    text2 = text2.Substring(0, text2.Length - 1);
                }
                arrayList.Add(text2);
                if (num == length - 1)
                {
                    break;
                }
                for (i = num + 1; i != length - 1 && src[i] == ' '; i++)
                {
                }
                if (i == length - 1)
                {
                    break;
                }
                num = i;
                text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Cout.LogWarning("EXCEPTION WHEN REAL SPLIT " + src + "\nend=" + num + "\n" + ex.Message + "\n" + ex.StackTrace);
            arrayList.Add(src);
        }
        return arrayList;
    }

    public string[] splitFontArray(string src, int lineWidth)
    {
        mVector mVector3 = splitFontVector(src, lineWidth);
        string[] array = new string[mVector3.size()];
        for (int i = 0; i < mVector3.size(); i++)
        {
            array[i] = (string)mVector3.elementAt(i);
        }
        return array;
    }

    public bool compare(string strSource, string str)
    {
        for (int i = 0; i < strSource.Length; i++)
        {
            if ((string.Empty + strSource[i]).Equals(str))
            {
                return true;
            }
        }
        return false;
    }

    public int getWidth(string s)
    {
        return getWidthExactOf(s);
    }

    public int getWidthExactOf(string s)
    {
        try
        {
            GUIStyle gUIStyle = new GUIStyle();
            gUIStyle.font = myFont;
            return (int)gUIStyle.CalcSize(new GUIContent(s)).x / mGraphics.zoomLevel;
        }
        catch (Exception ex)
        {
            Cout.LogError("GET WIDTH OF " + s + " FAIL.\n" + ex.Message + "\n" + ex.StackTrace);
            return getWidthNotExactOf(s);
        }
    }

    public int getWidthNotExactOf(string s)
    {
        return s.Length * wO / mGraphics.zoomLevel;
    }

    public int getHeight()
    {
        if (height > 0)
        {
            return height / mGraphics.zoomLevel;
        }
        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.font = myFont;
        try
        {
            height = (int)gUIStyle.CalcSize(new GUIContent("Adg")).y + 2;
        }
        catch (Exception ex)
        {
            Cout.LogError("FAIL GET HEIGHT " + ex.StackTrace);
            height = 20;
        }
        return height / mGraphics.zoomLevel;
    }

    public void _drawString(mGraphics g, string st, int x0, int y0, int align, bool useClip)
    {
        y0 += yAddFont;
        GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
        gUIStyle.font = myFont;
        float num = 0f;
        float num2 = 0f;
        switch (align)
        {
            case 0:
                num = x0;
                num2 = y0;
                gUIStyle.alignment = TextAnchor.UpperLeft;
                break;
            case 1:
                num = x0 - GameCanvas.w;
                num2 = y0;
                gUIStyle.alignment = TextAnchor.UpperRight;
                break;
            case 2:
            case 3:
                num = x0 - GameCanvas.w / 2;
                num2 = y0;
                gUIStyle.alignment = TextAnchor.UpperCenter;
                break;
        }
        int width = getWidth(st);
        gUIStyle.normal.textColor = color1;
        g.drawString(st, (int)num, (int)num2, gUIStyle, width, useClip);
    }

    public static string[] splitStringSv(string _text, string _searchStr)
    {
        int num = 0;
        int startIndex = 0;
        int length = _searchStr.Length;
        int num2 = _text.IndexOf(_searchStr, startIndex);
        while (num2 != -1)
        {
            startIndex = num2 + length;
            num2 = _text.IndexOf(_searchStr, startIndex);
            num++;
        }
        string[] array = new string[num + 1];
        int num3 = _text.IndexOf(_searchStr);
        int num4 = 0;
        int num5 = 0;
        while (num3 != -1)
        {
            array[num5] = _text.Substring(num4, num3 - num4);
            num4 = num3 + length;
            num3 = _text.IndexOf(_searchStr, num4);
            num5++;
        }
        array[num5] = _text.Substring(num4, _text.Length - num4);
        return array;
    }

    public void reloadImage()
    {
    }

    public void freeImage()
    {
    }
}
