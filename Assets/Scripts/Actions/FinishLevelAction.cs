using System;
using System.Collections;

public class FinishLevelAction : a_Action
{
    public FinishLevelAction(a_BoardElement target) : base(target)
    {
    }

    public override IEnumerator Courutine => ((LeadyUnit)Target).Finish();
}
