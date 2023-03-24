using UnityEngine;
public class StateIdle : a_State
{
    public StateIdle()
    {
    }

    public override a_State[] AllowedStatesToChange => new a_State[]
    {
        new StateAnimating()
    };

    public override void OnFinish()
    {

    }

    public override void OnStart()
    {
    }
}