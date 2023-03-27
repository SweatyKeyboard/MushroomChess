using System.Collections;

public class ElementRotatingAction : a_Action
{
    private int _angle;

    public ElementRotatingAction(a_BoardElement sender, int angle) : base(sender)
    {
        _angle = angle;
    }

    public override IEnumerator Courutine
    {
        get
        {
            if (Target.CellInFrontOf?.Element != null)
            {
                return Target.CellInFrontOf.Element.Rotate(_angle);
            }
            else
            {
                return null;
            }
        }
    }
}
