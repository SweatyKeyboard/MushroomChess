using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementMovingAction : a_Action
{
    private int _distance;

    public ElementMovingAction(a_BoardElement sender, int distance) : base(sender)
    {
        _distance = distance;
    }

    public override IEnumerator Courutine
    {
        get
        {
            if (Target.CellInFrontOf?.Element != null)
            {
                return Target.CellInFrontOf.Element.GetMoved(_distance, Target.Rotation);
            }
            else
            {
                return null;
            }
        }
    }

       
}
