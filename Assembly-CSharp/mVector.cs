using System.Collections;

public class mVector
{
	private ArrayList a;

	private string name;

	public mVector()
	{
		a = new ArrayList();
		name = "EffectManager";
	}

	public mVector(string aa)
	{
		a = new ArrayList();
		name = aa;
	}

	public mVector(ArrayList a)
	{
		this.a = a;
		name = "No Name";
	}

	public void addElement(object o)
	{
		a.Add(o);
	}

	public bool contains(object o)
	{
		if (a.Contains(o))
		{
			return true;
		}
		return false;
	}

	public int size()
	{
		if (a == null)
		{
			return 0;
		}
		return a.Count;
	}

	public object elementAt(int index)
	{
		if (index > -1 && index < a.Count)
		{
			return a[index];
		}
		return null;
	}

	public void setElementAt(object obj, int index)
	{
		if (index > -1 && index < a.Count)
		{
			a[index] = obj;
		}
	}

	public int indexOf(object o)
	{
		return a.IndexOf(o);
	}

	public void removeElementAt(int index)
	{
		if (index > -1 && index < a.Count)
		{
			a.RemoveAt(index);
		}
	}

	public void removeElement(object o)
	{
		a.Remove(o);
	}

	public void removeAllElements()
	{
		a.Clear();
	}

	public void insertElementAt(object o, int i)
	{
		a.Insert(i, o);
	}

	public object firstElement()
	{
		return a[0];
	}

	public object lastElement()
	{
		return a[a.Count - 1];
	}
}
