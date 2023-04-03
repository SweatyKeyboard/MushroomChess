using UnityEngine;

[System.Serializable]
public class PossibleTurnsLimiterData
{
    [SerializeField] private ActionLimiterData[] _actions = new ActionLimiterData[5];

    public ActionLimiterData this[int i] => _actions[i];
}