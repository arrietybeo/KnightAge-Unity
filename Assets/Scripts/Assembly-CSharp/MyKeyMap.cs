using System.Collections;
using UnityEngine;

public class MyKeyMap
{
	private static Hashtable h;

	static MyKeyMap()
	{
		h = new Hashtable();
		h.Add((object)(KeyCode)97, 97);
		h.Add((object)(KeyCode)98, 98);
		h.Add((object)(KeyCode)99, 99);
		h.Add((object)(KeyCode)100, 100);
		h.Add((object)(KeyCode)101, 101);
		h.Add((object)(KeyCode)102, 102);
		h.Add((object)(KeyCode)103, 103);
		h.Add((object)(KeyCode)104, 104);
		h.Add((object)(KeyCode)105, 105);
		h.Add((object)(KeyCode)106, 106);
		h.Add((object)(KeyCode)107, 107);
		h.Add((object)(KeyCode)108, 108);
		h.Add((object)(KeyCode)109, 109);
		h.Add((object)(KeyCode)110, 110);
		h.Add((object)(KeyCode)111, 111);
		h.Add((object)(KeyCode)112, 112);
		h.Add((object)(KeyCode)113, 113);
		h.Add((object)(KeyCode)114, 114);
		h.Add((object)(KeyCode)115, 115);
		h.Add((object)(KeyCode)116, 116);
		h.Add((object)(KeyCode)117, 117);
		h.Add((object)(KeyCode)118, 118);
		h.Add((object)(KeyCode)119, 119);
		h.Add((object)(KeyCode)120, 120);
		h.Add((object)(KeyCode)121, 121);
		h.Add((object)(KeyCode)122, 122);
		h.Add((object)(KeyCode)48, 48);
		h.Add((object)(KeyCode)49, 49);
		h.Add((object)(KeyCode)50, 50);
		h.Add((object)(KeyCode)51, 51);
		h.Add((object)(KeyCode)52, 52);
		h.Add((object)(KeyCode)53, 53);
		h.Add((object)(KeyCode)54, 54);
		h.Add((object)(KeyCode)55, 55);
		h.Add((object)(KeyCode)56, 56);
		h.Add((object)(KeyCode)57, 57);
		h.Add((object)(KeyCode)32, 32);
		h.Add((object)(KeyCode)282, -21);
		h.Add((object)(KeyCode)283, -22);
		h.Add((object)(KeyCode)61, -25);
		h.Add((object)(KeyCode)45, 45);
		h.Add((object)(KeyCode)284, -23);
		h.Add((object)(KeyCode)273, -1);
		h.Add((object)(KeyCode)274, -2);
		h.Add((object)(KeyCode)276, -3);
		h.Add((object)(KeyCode)275, -4);
		h.Add((object)(KeyCode)8, -8);
		h.Add((object)(KeyCode)13, -5);
		h.Add((object)(KeyCode)46, 46);
		h.Add((object)(KeyCode)64, 64);
		h.Add((object)(KeyCode)9, -26);
	}

	public static int map(KeyCode k)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		object obj = h[k];
		if (obj == null)
		{
			return 0;
		}
		return (int)obj;
	}
}
