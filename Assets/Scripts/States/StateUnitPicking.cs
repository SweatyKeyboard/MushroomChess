using UnityEngine;
public class StateUnitPicking : a_State
{
    public StateUnitPicking()
    {
    }

    public override a_State[] AllowedStatesToChange => new a_State[]
    {
        new StateUnitSpawning(),
        new StateUnitActing()
    };

    public override void OnFinish()
    {
    }

    public override void OnStart()
    {
    }
}

