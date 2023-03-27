using System.Collections;

public class MoveRightAction : a_MovingAction
{
    private int _distance;

    public MoveRightAction(a_BoardElement target, int distance) : base(target)
    {
        _distance = distance;
    }

    public override IEnumerator Courutine =>
        ((a_Unit)Target).MoveRight(_distance);
}
