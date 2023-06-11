using System.Collections;
using UnityEngine;

public class MimicAction : a_Action
{
    private MimicType _mimicType;

    public MimicAction(a_BoardElement target, MimicType type) : base(target)
    {
        _mimicType = type;
    }

    public override IEnumerator Courutine
    {
        get
        {
            Debug.Log("Mimic");

            a_Action action = (_mimicType == MimicType.Previous) ?
                ActionExecuter.LastAction :
                ActionExecuter.NextAction;

            action.Target = Target;
            return action.Courutine;
        }
    }
}