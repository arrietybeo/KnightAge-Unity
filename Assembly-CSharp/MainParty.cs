public class MainParty
{
	public string nameMain;

	public mVector vecPartys = new mVector("MainParty vecPartys");

	public bool isClear;

	public MainParty(string name, short Lv, int idMap, sbyte idarea)
	{
		nameMain = name;
		vecPartys.removeAllElements();
		isClear = false;
		addObjParty(name, Lv, idMap, idarea);
	}

	public void addObjParty(string name, short Lv, int idMap, sbyte idarea)
	{
		ObjectParty objectParty = new ObjectParty(name, Lv, idMap, idarea);
		objectParty.maxhp = 10;
		objectParty.hp = 10;
		vecPartys.addElement(objectParty);
	}

	public void removeObj(string name)
	{
		for (int i = 0; i < vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)vecPartys.elementAt(i);
			if (objectParty.name.CompareTo(name) == 0)
			{
				objectParty.isRemove = true;
				break;
			}
		}
	}

	public void setPos(string name, int x, int y, int hp, int maxhp)
	{
		for (int i = 0; i < vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)vecPartys.elementAt(i);
			if (objectParty.name.CompareTo(name) == 0)
			{
				objectParty.x = x;
				objectParty.y = y;
				if (hp > maxhp)
				{
					hp = maxhp;
				}
				objectParty.hp = hp;
				objectParty.maxhp = maxhp;
				break;
			}
		}
	}

	public bool update()
	{
		if (isClear)
		{
			vecPartys.removeAllElements();
			return true;
		}
		for (int i = 0; i < vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)vecPartys.elementAt(i);
			if (objectParty.isRemove)
			{
				vecPartys.removeElement(objectParty);
				i--;
			}
		}
		return false;
	}

	public void setIsParty()
	{
		for (int i = 0; i < vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)vecPartys.elementAt(i);
			objectParty.ischeck = false;
		}
		for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(j);
			if (mainObject.typeObject != 0 || mainObject == GameScreen.player)
			{
				continue;
			}
			mainObject.isParty = false;
			for (int k = 0; k < vecPartys.size(); k++)
			{
				ObjectParty objectParty2 = (ObjectParty)vecPartys.elementAt(k);
				if (!objectParty2.ischeck && objectParty2.name.CompareTo(mainObject.name) == 0)
				{
					mainObject.isParty = true;
					objectParty2.ischeck = true;
					break;
				}
			}
		}
	}

	public void setObjParty(MainObject obj)
	{
		for (int i = 0; i < vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)vecPartys.elementAt(i);
			if (objectParty.name.CompareTo(obj.name) == 0)
			{
				obj.isParty = true;
				break;
			}
		}
	}
}
