public class IArrow
{
	public bool wantDestroy;

	public virtual void set(int type, int x, int y, int power, short effect, MainObject owner, MainObject target)
	{
	}

	public virtual void setAngle(int angle)
	{
	}

	public virtual void update()
	{
	}

	public virtual void paint(mGraphics g)
	{
	}

	public virtual void SetEffFollow(int id)
	{
	}

	public virtual void onArrowTouchTarget()
	{
	}
}
