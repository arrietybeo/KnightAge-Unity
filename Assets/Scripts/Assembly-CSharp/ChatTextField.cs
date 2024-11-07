public class ChatTextField : AvMain
{
	public TField tfChat;

	public static ChatTextField instance;

	public static bool isShow;

	public iCommand cmdChat;

	protected ChatTextField()
	{
		tfChat = new TField();
		tfChat.isChangeFocus = false;
		tfChat.isnewTF = true;
		tfChat.setFocus(isFocus: true);
		init();
		tfChat.x = (GameCanvas.w - tfChat.width) / 2;
		tfChat.setMaxTextLenght(70);
		newinput.input.characterLimit = 70;
		tfChat.setStringNull((!Main.isPC) ? T.chat : string.Empty);
		if (Main.isPC)
		{
			tfChat.range = 80;
			center = new iCommand(string.Empty, 1);
			tfChat.x += iCommand.wButtonCmd - 2;
			tfChat.paintedText = string.Empty;
			tfChat.width = GameCanvas.hw - iCommand.wButtonCmd / 2;
			tfChat.y = GameCanvas.h - tfChat.height - 4;
			tfChat.isChat = true;
			left = new iCommand(T.chat, 1, this);
		}
		cmdChat = new iCommand();
		cmdChat.actionChat = delegate(string str)
		{
			tfChat.justReturnFromTextBox = false;
			tfChat.setText(str);
			if (tfChat.getText().Length > 0)
			{
				if (!Main.isPC)
				{
					GlobalService.gI().chatPopup(tfChat.getText());
				}
				GameScreen.player.strChatPopup = tfChat.getText();
			}
			tfChat.setText(string.Empty);
			TField.isOpenTextBox = false;
			tfChat.isFocus = false;
			isShow = false;
		};
	}

	public static ChatTextField gI()
	{
		return (instance != null) ? instance : (instance = new ChatTextField());
	}

	public void setChat()
	{
		isShow = !isShow;
		if (isShow)
		{
			newinput.input.text = string.Empty;
			tfChat.setPoiter();
		}
	}

	public void openKeyIphone()
	{
		if (!Main.isPC)
		{
			ipKeyboard.openKeyBoard("Chat", ipKeyboard.TEXT, string.Empty, cmdChat);
			tfChat.setFocusWithKb(isFocus: true);
		}
	}

	public override void commandTab(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			tfChat.setText(string.Empty);
			isShow = false;
			if (Main.isPC)
			{
				tfChat.setFocus(isFocus: true);
			}
			break;
		case 1:
			sendChat();
			break;
		}
	}

	public override void commandPointer(int index, int subIndex)
	{
		if (index == 1)
		{
			sendChat();
		}
	}

	public void init()
	{
		tfChat.y = GameCanvas.h - iCommand.hButtonCmd - tfChat.height - 5;
		tfChat.width = GameCanvas.w - TField.xDu * 2 - 10;
	}

	public void keyPressed(int keyCode)
	{
		tfChat.keyPressed(keyCode);
	}

	public override void updatekey()
	{
		tfChat.update();
		if (!isShow)
		{
			newinput.TYPE_INPUT = -1;
		}
		else
		{
			newinput.TYPE_INPUT = 0;
		}
		base.updatekey();
	}

	public override void paint(mGraphics g)
	{
		base.paint(g);
		if (!TouchScreenKeyboard.visible)
		{
			tfChat.paint(g);
		}
	}

	public override void updatePointer()
	{
		tfChat.updatePoiter();
		base.updatePointer();
	}

	public void sendChat()
	{
		tfChat.setText(newinput.input.text);
		if (tfChat.getText().Length > 0)
		{
			newinput.input.text = string.Empty;
			GameScreen.player.strChatPopup = tfChat.getText();
			GlobalService.gI().chatPopup(tfChat.getText());
			tfChat.setText(string.Empty);
		}
		if (GameCanvas.isTouch)
		{
			isShow = false;
		}
	}
}
