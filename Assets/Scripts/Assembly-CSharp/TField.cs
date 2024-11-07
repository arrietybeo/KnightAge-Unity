using System;

public class TField : AvMain
{
	public const sbyte KEY_LEFT = 14;

	public const sbyte KEY_RIGHT = 15;

	public const sbyte KEY_CLEAR = 19;

	public bool isCloseKey = true;

	public bool isFocus;

	public bool isnewTF;

	public int x;

	public int y;

	public int width;

	public int height;

	public int range;

	public int widthTouch;

	public bool lockArrow;

	public bool justReturnFromTextBox;

	public bool paintFocus = true;

	public static int typeXpeed = 2;

	private static readonly int[] MAX_TIME_TO_CONFIRM_KEY = new int[7] { 30, 14, 11, 9, 6, 4, 2 };

	private static int CARET_HEIGHT = 0;

	private static readonly int CARET_WIDTH = 1;

	private static readonly int CARET_SHOWING_TIME = 5;

	private static readonly int TEXT_GAP_X = 4;

	private static readonly int MAX_SHOW_CARET_COUNER = 10;

	public static readonly int INPUT_TYPE_ANY = 0;

	public static readonly int INPUT_TYPE_NUMERIC = 1;

	public static readonly int INPUT_TYPE_PASSWORD = 2;

	public static readonly int INPUT_ALPHA_NUMBER_ONLY = 3;

	private static string[] print = new string[12]
	{
		" 0", ".,@?!_1\"/$-():*+<=>;%&~#%^&*{}[];'/1", "abc2áàảãạâấầẩẫậăắằẳẵặ2", "def3đéèẻẽẹêếềểễệ3", "ghi4íìỉĩị4", "jkl5", "mno6óòỏõọôốồổỗộơớờởỡợ6", "pqrs7", "tuv8úùủũụưứừửữự8", "wxyz9ýỳỷỹỵ9",
		"*", "#"
	};

	private static string[] printA = new string[12]
	{
		"0", "1", "abc2", "def3", "ghi4", "jkl5", "mno6", "pqrs7", "tuv8", "wxyz9",
		"0", "0"
	};

	private static string[] printBB = new string[17]
	{
		" 0", "er1", "ty2", "ui3", "df4", "gh5", "jk6", "cv7", "bn8", "m9",
		"0", "0", "qw!", "as?", "zx", "op.", "l,"
	};

	private string text = string.Empty;

	private string passwordText = string.Empty;

	public string paintedText = string.Empty;

	public bool isChat;

	public int caretPos;

	private int counter;

	private int maxTextLenght = 500;

	private int offsetX;

	private static int lastKey = -1984;

	private int keyInActiveState;

	private int indexOfActiveChar;

	private int showCaretCounter = MAX_SHOW_CARET_COUNER;

	private int inputType = INPUT_TYPE_ANY;

	public static bool isQwerty = true;

	public static int typingModeAreaWidth;

	public static int mode = 0;

	public static long timeChangeMode;

	public static readonly string[] modeNotify = new string[4] { "abc", "Abc", "ABC", "123" };

	public static readonly int NOKIA = 0;

	public static readonly int MOTO = 1;

	public static readonly int ORTHER = 2;

	public static readonly int BB = 3;

	public static int changeModeKey = 11;

	public static readonly sbyte abc = 0;

	public static readonly sbyte Abc = 1;

	public static readonly sbyte ABC = 2;

	public static readonly sbyte number123 = 3;

	public static TField currentTField;

	public bool isTfield;

	public bool isPaintMouse = true;

	public string name = string.Empty;

	public string title = string.Empty;

	public string strnull;

	public string strInfo;

	private int xCamText;

	public iCommand cmdClear;

	public iCommand cmdDoneAction;

	public bool isNotUseChangeTextBox;

	private int timeDelayKyCode;

	public static IAction acClear;

	private int holdCount;

	public static int changeDau;

	private int indexDau = -1;

	private int indexTemplate;

	private int indexCong;

	private long timeDau;

	private static string printDau = "aáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵ";

	public static bool isOpenTextBox = false;

	private int timeFocus;

	private int cout;

	public int timePutKeyClearAll;

	public int timeClearFirt;

	public bool resetFc;

	public bool showSubTextField = true;

	public static TouchScreenKeyboard kb;

	public static int[][] BBKEY = new int[17][]
	{
		new int[2] { 32, 48 },
		new int[2] { 49, 69 },
		new int[2] { 50, 84 },
		new int[2] { 51, 85 },
		new int[2] { 52, 68 },
		new int[2] { 53, 71 },
		new int[2] { 54, 74 },
		new int[2] { 55, 67 },
		new int[2] { 56, 66 },
		new int[2] { 57, 77 },
		new int[2] { 42, 128 },
		new int[2] { 35, 137 },
		new int[2] { 33, 113 },
		new int[2] { 63, 97 },
		new int[3] { 64, 121, 122 },
		new int[2] { 46, 111 },
		new int[2] { 44, 108 }
	};

	public static int xDu;

	public bool isChangeFocus;

	public TField()
	{
		text = string.Empty;
		init();
		setheightText();
	}

	public TField(int x, int y)
	{
		text = string.Empty;
		this.x = x;
		this.y = y;
		init();
		setheightText();
	}

	public TField(int x, int y, int width)
	{
		text = string.Empty;
		this.x = x;
		this.y = y;
		this.width = width;
		widthTouch = 0;
		init();
		setheightText();
	}

	public TField(int x, int y, int width, int widthTouch)
	{
		text = string.Empty;
		this.x = x;
		this.y = y;
		this.width = width;
		this.widthTouch = widthTouch;
		init();
		setFocus(isFocus: false);
		setheightText();
	}

	public override void commandPointer(int index, int subIndex)
	{
		if (index == 0)
		{
			if (isFocus)
			{
				clear();
			}
			if (isnewTF)
			{
				newinput.input.text = string.Empty;
			}
		}
	}

	public static bool setNormal(char ch)
	{
		if ((ch < '0' || ch > '9') && (ch < 'A' || ch > 'Z') && (ch < 'a' || ch > 'z'))
		{
			return false;
		}
		return true;
	}

	public static void setVendorTypeMode(int mode)
	{
		if (mode == MOTO)
		{
			print[0] = "0";
			print[10] = " *";
			print[11] = "#";
			changeModeKey = 35;
		}
		else if (mode == NOKIA)
		{
			print[0] = " 0";
			print[10] = "*";
			print[11] = "#";
			changeModeKey = 35;
		}
		else if (mode == ORTHER)
		{
			print[0] = "0";
			print[10] = "*";
			print[11] = " #";
			changeModeKey = 42;
		}
	}

	public void init()
	{
		CARET_HEIGHT = mFont.tahoma_7_black.getHeight() + 1;
		cmdClear = new iCommand(T.del, 0, this);
	}

	public bool isFocusedz()
	{
		return isFocus;
	}

	public void clearKeyWhenPutText(int keyCode)
	{
		if (keyCode == -8 && timeDelayKyCode <= 0)
		{
			if (timeDelayKyCode <= 0)
			{
				timeDelayKyCode = 1;
			}
			clear();
		}
	}

	public iCommand setCmdClear()
	{
		acClear = cmdClear.action;
		return cmdClear;
	}

	public void setheightText()
	{
		height = 20;
		if (GameCanvas.isTouch)
		{
			height = 28;
		}
	}

	public void clearAllText()
	{
		text = string.Empty;
		TouchScreenKeyboard.Clear();
		if (kb != null)
		{
			kb.text = string.Empty;
		}
		caretPos = 0;
		setOffset(0);
		setPasswordTest();
	}

	public void setStringNull(string str)
	{
		strnull = str;
	}

	public void clear()
	{
		if (isnewTF)
		{
			if (caretPos > 0 && text.Length > 0 && caretPos <= text.Length)
			{
				text = text.Substring(0, caretPos - 1);
				caretPos--;
				setOffset(0);
				setPasswordTest();
				if (kb != null)
				{
					kb.text = text;
				}
			}
		}
		else if (caretPos > 0 && text.Length > 0)
		{
			text = text.Substring(0, caretPos - 1);
			caretPos--;
			setOffset(0);
			setPasswordTest();
			if (kb != null)
			{
				kb.text = text;
			}
		}
	}

	public void clearAll()
	{
		if (caretPos > 0 && text.Length > 0)
		{
			text = text.Substring(0, text.Length - 1);
			caretPos--;
			setOffset();
			setPasswordTest();
			setFocusWithKb(isFocus: true);
			if (kb != null)
			{
				kb.text = string.Empty;
			}
		}
	}

	public void setOffset()
	{
		if (paintedText != null && mFont.tahoma_7_black != null)
		{
			if (inputType == INPUT_TYPE_PASSWORD)
			{
				paintedText = passwordText;
			}
			else
			{
				paintedText = text;
			}
			if (offsetX < 0 && mFont.tahoma_7_black.getWidth(paintedText) + offsetX < width - TEXT_GAP_X - 13 - typingModeAreaWidth)
			{
				offsetX = width - 10 - typingModeAreaWidth - mFont.tahoma_7_black.getWidth(paintedText);
			}
			if (offsetX + mFont.tahoma_7_black.getWidth(paintedText.Substring(0, caretPos)) <= 0)
			{
				offsetX = -mFont.tahoma_7_black.getWidth(paintedText.Substring(0, caretPos));
				offsetX += 40;
			}
			else if (offsetX + mFont.tahoma_7_black.getWidth(paintedText.Substring(0, caretPos)) >= width - 12 - typingModeAreaWidth)
			{
				offsetX = width - 10 - typingModeAreaWidth - mFont.tahoma_7_black.getWidth(paintedText.Substring(0, caretPos)) - 2 * TEXT_GAP_X;
			}
			if (offsetX > 0)
			{
				offsetX = 0;
			}
		}
	}

	private void keyPressedAny(int keyCode)
	{
		string[] array = ((inputType != INPUT_TYPE_PASSWORD && inputType != INPUT_ALPHA_NUMBER_ONLY) ? print : printA);
		if (keyCode == lastKey)
		{
			indexOfActiveChar = (indexOfActiveChar + 1) % array[keyCode - 48].Length;
			char c = array[keyCode - 48][indexOfActiveChar];
			string text = string.Concat(arg1: (mode == 0) ? char.ToLower(c) : ((mode == 1) ? char.ToUpper(c) : ((mode != 2) ? array[keyCode - 48][array[keyCode - 48].Length - 1] : char.ToUpper(c))), arg0: this.text.Substring(0, caretPos - 1));
			if (caretPos < this.text.Length)
			{
				text += this.text.Substring(caretPos, this.text.Length);
			}
			this.text = text;
			keyInActiveState = MAX_TIME_TO_CONFIRM_KEY[typeXpeed];
			setPasswordTest();
		}
		else if (this.text.Length < maxTextLenght)
		{
			if (mode == 1 && lastKey != -1984)
			{
				mode = 0;
			}
			indexOfActiveChar = 0;
			char c2 = array[keyCode - 48][indexOfActiveChar];
			string text2 = string.Concat(arg1: (mode == 0) ? char.ToLower(c2) : ((mode == 1) ? char.ToUpper(c2) : ((mode != 2) ? array[keyCode - 48][array[keyCode - 48].Length - 1] : char.ToUpper(c2))), arg0: this.text.Substring(0, caretPos));
			if (caretPos < this.text.Length)
			{
				text2 += this.text.Substring(caretPos, this.text.Length);
			}
			this.text = text2;
			keyInActiveState = MAX_TIME_TO_CONFIRM_KEY[typeXpeed];
			caretPos++;
			setPasswordTest();
			setOffset();
		}
		lastKey = keyCode;
	}

	private void keyPressedAscii(int keyCode)
	{
		if (isnewTF)
		{
			this.text = newinput.input.text;
			if (this.text.Length < maxTextLenght && caretPos <= this.text.Length)
			{
				string text = this.text.Substring(0, caretPos) + (char)keyCode;
				if (caretPos < this.text.Length)
				{
					text += this.text.Substring(caretPos, this.text.Length - caretPos);
				}
				this.text = text;
				caretPos++;
				setPasswordTest();
				setOffset(0);
			}
			if (kb != null)
			{
				kb.text = this.text;
			}
		}
		else
		{
			if ((!isFocus && Main.isPC) || ((inputType == INPUT_TYPE_PASSWORD || inputType == INPUT_ALPHA_NUMBER_ONLY) && (keyCode < 48 || keyCode > 57) && (keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 122)))
			{
				return;
			}
			if (this.text.Length < maxTextLenght)
			{
				string text2 = this.text.Substring(0, caretPos) + (char)keyCode;
				if (caretPos < this.text.Length)
				{
					text2 += this.text.Substring(caretPos, this.text.Length - caretPos);
				}
				this.text = text2;
				caretPos++;
				setPasswordTest();
				setOffset(0);
			}
			if (kb != null)
			{
				kb.text = this.text;
			}
		}
	}

	public static void setMode()
	{
		mode++;
		if (mode > 3)
		{
			mode = 0;
		}
		lastKey = changeModeKey;
		timeChangeMode = Environment.TickCount / 1000;
	}

	private void setDau()
	{
		timeDau = Environment.TickCount / 100;
		if (indexDau == -1)
		{
			for (int num = caretPos; num > 0; num--)
			{
				char c = this.text[num - 1];
				for (int i = 0; i < printDau.Length; i++)
				{
					char c2 = printDau[i];
					if (c == c2)
					{
						indexTemplate = i;
						indexCong = 0;
						indexDau = num - 1;
						return;
					}
				}
			}
			indexDau = -1;
		}
		else
		{
			indexCong++;
			if (indexCong >= 6)
			{
				indexCong = 0;
			}
			string text = this.text.Substring(0, indexDau);
			string text2 = this.text.Substring(indexDau + 1);
			string text3 = printDau.Substring(indexTemplate + indexCong, 1);
			this.text = text + text3 + text2;
		}
	}

	public bool keyPressed(int keyCode)
	{
		if (Main.isPC && keyCode == -8)
		{
			clearKeyWhenPutText(-8);
			return true;
		}
		if (keyCode == 8 || keyCode == -8 || keyCode == 204)
		{
			clear();
			return true;
		}
		if (!GameCanvas.isTouch && !GameCanvas.isBB && keyCode >= 65 && keyCode <= 122)
		{
			isQwerty = true;
			typingModeAreaWidth = 0;
			sbyte[] data = new sbyte[1] { 1 };
			try
			{
				CRes.saveRMS("isQty", data);
			}
			catch (Exception)
			{
			}
		}
		if (isQwerty && keyCode >= 32)
		{
			keyPressedAscii(keyCode);
			return false;
		}
		if (keyCode == changeDau && inputType == INPUT_TYPE_ANY)
		{
			setDau();
			return false;
		}
		if (keyCode == 42)
		{
			keyCode = 58;
		}
		if (keyCode == 35)
		{
			keyCode = 59;
		}
		if (keyCode >= 48 && keyCode <= 59)
		{
			if (inputType == INPUT_TYPE_ANY || inputType == INPUT_TYPE_PASSWORD || inputType == INPUT_ALPHA_NUMBER_ONLY)
			{
				keyPressedAny(keyCode);
			}
			else if (inputType == INPUT_TYPE_NUMERIC)
			{
				keyPressedAscii(keyCode);
				keyInActiveState = 1;
			}
		}
		else
		{
			indexOfActiveChar = 0;
			lastKey = -1984;
			if (keyCode == 14 && !lockArrow)
			{
				if (caretPos > 0)
				{
					caretPos--;
					setOffset(0);
					showCaretCounter = MAX_SHOW_CARET_COUNER;
					return false;
				}
			}
			else if (keyCode == 15 && !lockArrow)
			{
				if (caretPos < text.Length)
				{
					caretPos++;
					setOffset(0);
					showCaretCounter = MAX_SHOW_CARET_COUNER;
					return false;
				}
			}
			else
			{
				if (keyCode == 19)
				{
					clear();
					return false;
				}
				lastKey = keyCode;
			}
		}
		return true;
	}

	public void setOffset(int index)
	{
		if (inputType == INPUT_TYPE_PASSWORD)
		{
			paintedText = passwordText;
		}
		else
		{
			paintedText = text;
		}
		int num = mFont.tahoma_8b_black.getWidth(paintedText.Substring(0, caretPos));
		switch (index)
		{
		case -1:
			if (num + offsetX < 15 && caretPos > 0 && caretPos < paintedText.Length)
			{
				offsetX += mFont.tahoma_8b_black.getWidth(paintedText.Substring(caretPos, 1));
			}
			break;
		case 1:
			if (num + offsetX > width - 25 && caretPos < paintedText.Length && caretPos > 0)
			{
				offsetX -= mFont.tahoma_8b_black.getWidth(paintedText.Substring(caretPos - 1, 1));
			}
			break;
		default:
			offsetX = -(num - (width - 12));
			break;
		}
		if (offsetX > 0)
		{
			offsetX = 0;
		}
		else if (offsetX < 0)
		{
			int num2 = mFont.tahoma_8b_black.getWidth(paintedText) - (width - 12);
			if (offsetX < -num2)
			{
				offsetX = -num2;
			}
		}
	}

	public void paintByList(mGraphics g)
	{
		bool flag = isFocusedz();
		mFont mFont2 = mFont.tahoma_8b_black;
		int num = 0;
		if (inputType == INPUT_TYPE_PASSWORD)
		{
			paintedText = passwordText;
			num = 3;
		}
		else
		{
			paintedText = this.text;
		}
		if (isnewTF)
		{
			paintedText = newinput.input.text;
		}
		int num2 = 0;
		g.setColor(12621920);
		timeFocus++;
		if (flag)
		{
			int length = paintedText.Length;
			if (length > 0 && caretPos > 0)
			{
				if (isnewTF)
				{
					if (caretPos <= paintedText.Length)
					{
						string text = paintedText.Substring(0, caretPos) + "a";
						num2 = mFont.tahoma_8b_black.getWidth(paintedText.Substring(0, caretPos) + "a") - mFont.tahoma_8b_black.getWidth("a");
					}
				}
				else
				{
					num2 = mFont.tahoma_8b_black.getWidth(paintedText.Substring(0, caretPos) + "a") - mFont.tahoma_8b_black.getWidth("a");
				}
			}
		}
		AvMain.paintRectText(g, x, y, width, height + 2, flag);
		if (isnewTF)
		{
			g.setClip(x + 2, y + 2, width - 4, height - 3);
			int translateX = g.getTranslateX();
			int translateY = g.getTranslateY();
		}
		g.translate(-xCamText, 0);
		if (paintedText.Length == 0)
		{
			num = 0;
			paintedText = strnull;
			mFont2 = ((!flag) ? mFont.tahoma_8b_brown : mFont.tahoma_8b_black);
		}
		mFont2.drawString(g, paintedText, x + 4 + offsetX + TEXT_GAP_X, y + height / 2 - 5 + num, 0, mGraphics.isTrue);
		if (Main.isPC && flag && timeFocus % 60 > 12)
		{
			g.setColor(0);
			g.fillRect(x + 3 + num2 + offsetX + TEXT_GAP_X, y + height / 2 - 7, 1, 14, mGraphics.isFalse);
		}
	}

	public new void paint(mGraphics g)
	{
		bool flag = isFocusedz();
		mFont mFont2 = mFont.tahoma_8b_black;
		int num = 0;
		if (inputType == INPUT_TYPE_PASSWORD)
		{
			paintedText = passwordText;
			num = 3;
		}
		else
		{
			paintedText = this.text;
		}
		if (isnewTF)
		{
			paintedText = newinput.input.text;
		}
		int num2 = 0;
		g.setColor(12621920);
		timeFocus++;
		if (flag)
		{
			int length = paintedText.Length;
			if (length > 0 && caretPos > 0)
			{
				if (isnewTF)
				{
					if (caretPos <= paintedText.Length)
					{
						string text = paintedText.Substring(0, caretPos) + "a";
						num2 = mFont.tahoma_8b_black.getWidth(paintedText.Substring(0, caretPos) + "a") - mFont.tahoma_8b_black.getWidth("a");
					}
				}
				else
				{
					num2 = mFont.tahoma_8b_black.getWidth(paintedText.Substring(0, caretPos) + "a") - mFont.tahoma_8b_black.getWidth("a");
				}
			}
		}
		AvMain.paintRectText(g, x, y, width, height + 2, flag);
		g.setClip(x + 2, y + 2, width - 4, height - 3);
		int translateX = g.getTranslateX();
		int translateY = g.getTranslateY();
		g.translate(-xCamText, 0);
		if (paintedText.Length == 0)
		{
			num = 0;
			paintedText = strnull;
			mFont2 = ((!flag) ? mFont.tahoma_8b_brown : mFont.tahoma_8b_black);
		}
		mFont2.drawString(g, paintedText, x + 4 + offsetX + TEXT_GAP_X, y + height / 2 - 5 + num, 0, mGraphics.isTrue);
		if (Main.isPC && flag && timeFocus % 60 > 12)
		{
			g.setColor(0);
			g.fillRect(x + 3 + num2 + offsetX + TEXT_GAP_X, y + height / 2 - 7, 1, 14, mGraphics.isFalse);
		}
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		GameCanvas.resetTrans(g);
		g.translate(translateX, translateY);
	}

	public string subString(string str, int index, int indexTo)
	{
		if (index >= 0 && indexTo > str.Length - 1)
		{
			return str.Substring(index);
		}
		if (index < 0 || index > str.Length - 1 || indexTo < 0 || indexTo > str.Length - 1)
		{
			return string.Empty;
		}
		string text = string.Empty;
		for (int i = index; i < indexTo; i++)
		{
			text += str[i];
		}
		return text;
	}

	private void setPasswordTest()
	{
		if (inputType == INPUT_TYPE_PASSWORD)
		{
			passwordText = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				passwordText += "*";
			}
			if (keyInActiveState > 0 && caretPos > 0)
			{
				passwordText = passwordText.Substring(0, caretPos - 1) + text[caretPos - 1] + passwordText.Substring(caretPos, passwordText.Length);
			}
		}
	}

	public new void update()
	{
		if (Main.isPC)
		{
			if (timeDelayKyCode > 0)
			{
				timeDelayKyCode--;
			}
			if (timeDelayKyCode <= 0)
			{
				timeDelayKyCode = 0;
			}
		}
		if (kb != null && currentTField == this)
		{
			if (kb.text.Length < 200)
			{
				setText(kb.text);
			}
			if (kb.done)
			{
				isFocus = false;
			}
		}
		counter++;
		if (keyInActiveState > 0)
		{
			keyInActiveState--;
			if (keyInActiveState == 0)
			{
				indexOfActiveChar = 0;
				if (mode == 1 && lastKey != changeModeKey && isFocus)
				{
					mode = 0;
				}
				lastKey = -1984;
				setPasswordTest();
			}
		}
		if (showCaretCounter > 0)
		{
			showCaretCounter--;
		}
		setTextBox();
		if (indexDau != -1 && Environment.TickCount / 100 - timeDau > 5)
		{
			indexDau = -1;
		}
		if (isNotUseChangeTextBox && !Main.isPC)
		{
			isOpenTextBox = false;
			isFocus = false;
		}
	}

	public void setTextBox()
	{
		if (!GameCanvas.isPointerSelect)
		{
			return;
		}
		if (GameCanvas.isPoint(x, y, width - widthTouch, height))
		{
			setFocusWithKb(isFocus: true);
			doChangeToTextBox();
			GameCanvas.isPointerSelect = false;
			return;
		}
		if (isChat)
		{
			setText(string.Empty);
			ChatTextField.isShow = false;
			return;
		}
		if (isChangeFocus)
		{
			isFocus = false;
		}
		setFocus(isFocus: false);
	}

	public void updatepointerByList()
	{
		if (Main.isPC)
		{
			if (timeDelayKyCode > 0)
			{
				timeDelayKyCode--;
			}
			if (timeDelayKyCode <= 0)
			{
				timeDelayKyCode = 0;
			}
		}
		if (kb != null && currentTField == this)
		{
			if (kb.text.Length < 40)
			{
				setText(kb.text);
			}
			if (kb.done)
			{
				isFocus = false;
			}
		}
		counter++;
		if (keyInActiveState > 0)
		{
			keyInActiveState--;
			if (keyInActiveState == 0)
			{
				indexOfActiveChar = 0;
				if (mode == 1 && lastKey != changeModeKey && isFocus)
				{
					mode = 0;
				}
				lastKey = -1984;
				setPasswordTest();
			}
		}
		if (showCaretCounter > 0)
		{
			showCaretCounter--;
		}
		setTextBoxBylist();
		if (indexDau != -1 && Environment.TickCount / 100 - timeDau > 5)
		{
			indexDau = -1;
		}
		if (isNotUseChangeTextBox && !Main.isPC)
		{
			isOpenTextBox = false;
			isFocus = false;
		}
	}

	public void setTextBoxBylist()
	{
		if (GameCanvas.isPointerSelect && !GameCanvas.isPoint(x, y, width - widthTouch, height))
		{
			if (isChat)
			{
				setText(string.Empty);
				ChatTextField.isShow = false;
			}
			else
			{
				if (isChangeFocus)
				{
					isFocus = false;
				}
				setFocus(isFocus: false);
			}
		}
		setFocusWithKb(isFocus: true);
		doChangeToTextBox();
		GameCanvas.isPointerSelect = false;
	}

	public void setFocus(bool isFocus)
	{
		if (this.isFocus != isFocus)
		{
			mode = 0;
		}
		lastKey = -1984;
		timeChangeMode = (int)(DateTime.Now.Ticks / 1000);
		this.isFocus = isFocus;
		if (isFocus)
		{
			currentTField = this;
			if (kb != null)
			{
				kb.text = currentTField.text;
			}
		}
	}

	public void setFocusWithKb(bool isFocus)
	{
		if (this.isFocus != isFocus)
		{
			mode = 0;
		}
		lastKey = -1984;
		timeChangeMode = (int)(DateTime.Now.Ticks / 1000);
		this.isFocus = isFocus;
		if (isFocus)
		{
			currentTField = this;
		}
		else if (currentTField == this)
		{
			currentTField = null;
		}
		if (currentTField != null)
		{
			isFocus = true;
			TouchScreenKeyboard.hideInput = !currentTField.showSubTextField;
			TouchScreenKeyboardType t = TouchScreenKeyboardType.ASCIICapable;
			if (inputType == INPUT_TYPE_NUMERIC)
			{
				t = TouchScreenKeyboardType.NumberPad;
			}
			bool type = false;
			if (inputType == INPUT_TYPE_PASSWORD)
			{
				type = true;
			}
			kb = TouchScreenKeyboard.Open(currentTField.text, t, b1: false, b2: false, type, b3: false, currentTField.name);
			if (kb != null)
			{
				kb.text = currentTField.text;
			}
			Cout.LogWarning("SHOW KEYBOARD FOR " + currentTField.text);
		}
	}

	public string getText()
	{
		return text;
	}

	public void clearKb()
	{
		if (kb != null)
		{
			kb.text = string.Empty;
		}
	}

	public void setText(string text)
	{
		if (text != null)
		{
			lastKey = -1984;
			keyInActiveState = 0;
			indexOfActiveChar = 0;
			this.text = text;
			paintedText = text;
			setPasswordTest();
			caretPos = text.Length;
			setOffset(0);
		}
	}

	public void insertText(string text)
	{
		this.text = this.text.Substring(0, caretPos) + text + this.text.Substring(caretPos);
		setPasswordTest();
		caretPos += text.Length;
		setOffset();
	}

	public int getMaxTextLenght()
	{
		return maxTextLenght;
	}

	public void setMaxTextLenght(int maxTextLenght)
	{
		this.maxTextLenght = maxTextLenght;
	}

	public int getIputType()
	{
		return inputType;
	}

	public void setIputType(int iputType)
	{
		inputType = iputType;
	}

	public void perform(int idAction, object p)
	{
		if (idAction == 1000)
		{
			clear();
		}
	}

	public static int getHeight()
	{
		if (GameCanvas.isTouch)
		{
			return 28;
		}
		return 20;
	}

	public void updatePoiter()
	{
	}

	public void setPoiter()
	{
		isOpenTextBox = true;
		GameCanvas.isPointerSelect = false;
		doChangeToTextBox();
	}

	public void doChangeToTextBox()
	{
		if (ChatTextField.isShow)
		{
			ChatTextField.gI().openKeyIphone();
		}
		else if (GameCanvas.subDialog != null && GameCanvas.subDialog == GameCanvas.msgchat)
		{
			GameCanvas.msgchat.openKeyIphone();
		}
	}
}
