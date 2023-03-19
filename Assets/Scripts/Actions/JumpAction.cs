using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : a_MovingAction
{
    private float _height;
    private int _distance;
    public JumpAction(a_BoardElement target, int distance, float height) : base(target)
    {
        _distance = distance;
        _height = height;
    }

    public override IEnumerator Courutine =>
        ((a_Unit)Target).JumpForward(_distance, _height);

}
