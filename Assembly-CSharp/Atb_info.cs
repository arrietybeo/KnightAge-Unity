using UnityEngine;

public class Atb_info : MonoBehaviour
{
	public string info;

	public sbyte id_color;

	public Atb_info(string info, int idcolor)
	{
		this.info = info;
		id_color = (sbyte)idcolor;
	}
}
