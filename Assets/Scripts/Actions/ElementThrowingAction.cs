using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementThrowingAction : a_Action
{
    private int _height;
    public ElementThrowingAction(a_BoardElement target, int height) : base(target)
    {
        _height = height;
    }

    public override IEnumerator Courutine
    {
        get
        {
            if (Target.CellInFrontOf?.Element != null)
            {
                return Target.CellInFrontOf.Element.GetJumped(Target.Rotation, _height);
            }
            else
            {
                return null;
            }
        }
    }
}
