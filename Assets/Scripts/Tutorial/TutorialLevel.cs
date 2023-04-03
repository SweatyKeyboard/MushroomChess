using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Tutorial")]
public class TutorialLevel : ScriptableObject
{
    [SerializeField] private UnityEvent[] _eventsList;
    [SerializeField] private TurnLimiterData[] _actions;

    public TurnLimiterData[] Actions => _actions;

    public void InvokeEventsForTurn(int turnsPassed)
    {
        _eventsList[turnsPassed]?.Invoke();
    }
}