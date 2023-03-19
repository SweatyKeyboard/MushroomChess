using UnityEngine;
public class StateAnimating : a_State
{
    public StateAnimating()
    {
    }

    public override a_State[] AllowedStatesToChange => new a_State[]
    {
        new StateUnitActing()
    };

    public override void OnFinish()
    {
    }

    public override void OnStart()
    {
    }
}

