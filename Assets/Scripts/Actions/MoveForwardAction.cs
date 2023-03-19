using System.Collections;
using UnityEngine;
public class MoveForwardAction : a_MovingAction
{
    private int _distance;

    public MoveForwardAction(a_BoardElement target, int distance) : base(target)
    {
        _distance = distance;
    }

    public override IEnumerator Courutine => 
        ((a_Unit)Target).MoveForward(_distance);
}