
using System.Collections;

public class RotationAction : a_Action
{
    private int _angle;
    public RotationAction(a_BoardElement target, int angle) : base(target)
    {
        _angle = angle;
    }

    public override IEnumerator Courutine =>
        ((a_Unit)Target).Rotate(_angle);
}