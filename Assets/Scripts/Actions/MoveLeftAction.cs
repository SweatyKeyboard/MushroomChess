using System.Collections;

public class MoveLeftAction : a_MovingAction
{
    private int _distance;

    public MoveLeftAction(a_BoardElement target, int distance) : base(target)
    {
        _distance = distance;
    }

    public override IEnumerator Courutine =>
        ((a_Unit)Target).MoveLeft(_distance);
}
