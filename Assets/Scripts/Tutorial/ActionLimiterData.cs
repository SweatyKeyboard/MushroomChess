using UnityEngine;

[System.Serializable]
public class ActionLimiterData
{
    [SerializeField] private int _unitIndex;
    [SerializeField] private Action _action;

    public ActionLimiterData(int index, Action action)
    {
        _unitIndex = index;
        _action = action;
    }

    public static bool operator ==(ActionLimiterData data1, ActionLimiterData data2)
    {
        return data1._unitIndex == data2._unitIndex && data1._action == data2._action;
    }

    public static bool operator !=(ActionLimiterData data1, ActionLimiterData data2)
    {
        return data1._unitIndex != data2._unitIndex || data1._action != data2._action;
    }
}