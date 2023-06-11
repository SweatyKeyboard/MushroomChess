using System.Collections;

public class NothingAction : a_Action
{
    public NothingAction(a_BoardElement target) : base(target)
    {
    }

    public override IEnumerator Courutine => null;
}
