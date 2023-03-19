using System.Linq;
using UnityEngine;

public enum States
{
    UnitPicking,
    UnitActing,
    Spawning
}

public class StateChanger : MonoBehaviour
{
    public a_State State { get; set; } = new StateUnitPicking();

    public static StateChanger Instance;
    private void Awake()
    {
        Instance = this;
    }

    public bool TryChangeState(a_State toState)
    {
        if (State.Contains(toState))
        {
            State.OnFinish();
            State = toState;
            State.OnStart();
            return true;
        }
        return false;
    }
}