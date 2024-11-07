public class mVector2
{
	public float x;

	public float y;

	public mVector2()
	{
		x = 0f;
		y = 0f;
	}

	public mVector2(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public void set(mVector2 v)
	{
		x = v.x;
		y = v.y;
	}

	public mVector2 substract(mVector2 v)
	{
		x -= v.x;
		y -= v.y;
		return this;
	}

	public mVector2 add(mVector2 v)
	{
		x += v.x;
		y += v.y;
		return this;
	}

	public mVector2 add(float x, float y)
	{
		this.x += x;
		this.y += y;
		return this;
	}

	public mVector2 mul(mVector2 v)
	{
		x += v.x;
		y += v.y;
		return this;
	}

	public float length()
	{
		return CRes.sqrt(x * x + y * y);
	}

	public mVector2 normalize()
	{
		float num = 0f;
		num = length();
		if (num != 0f)
		{
			x /= num;
			y /= num;
		}
		return this;
	}

	public static float distance(mVector2 src, mVector2 dest)
	{
		float num = dest.x - src.x;
		float num2 = dest.y - src.y;
		return CRes.sqrt(num * num + num2 * num2);
	}

	public static mVector2 substract(mVector2 src, mVector2 dest)
	{
		float num = dest.x - src.x;
		float num2 = dest.y - src.y;
		return new mVector2(num, num2);
	}
}
