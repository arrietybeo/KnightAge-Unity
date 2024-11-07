using UnityEngine;
using UnityEngine.UI;

public class newinput : MonoBehaviour
{
	public static InputField input;

	public static int TYPE_INPUT;

	private void Start()
	{
		input = ((Component)this).GetComponent<InputField>();
		TYPE_INPUT = -1;
	}

	private void Update()
	{
		if (TYPE_INPUT == 0)
		{
			if (ChatTextField.isShow)
			{
				((Selectable)input).Select();
				input.ActivateInputField();
			}
			else
			{
				input.DeactivateInputField();
			}
		}
		if (TYPE_INPUT == 1)
		{
			if (MsgChat.curentfocus != null && MsgChat.curentfocus.tfchat != null)
			{
				((Selectable)input).Select();
				input.ActivateInputField();
			}
			else
			{
				input.DeactivateInputField();
			}
		}
		if (TYPE_INPUT != 2)
		{
		}
	}
}
