using System;
using UnityEngine;

public abstract class a_State
{
    public abstract a_State[] AllowedStatesToChange { get; }
    public abstract void OnStart();
    public abstract void OnFinish();

    public bool Contains(a_State selectedState)
    {
        foreach (a_State state in AllowedStatesToChange)
        {
            if (state.GetType() == selectedState.GetType())
            {
                return true;
            }
        }
        return false;
    }
}
