using UnityEngine;

[System.Serializable]
public class TurnLimiterData
{
    [SerializeField] private PossibleTurnsLimiterData[] _possibleTurnVariants;

    public ActionLimiterData this[int i, int j] => _possibleTurnVariants[i][j];
    public PossibleTurnsLimiterData this[int i] => _possibleTurnVariants[i];
    public int Count => _possibleTurnVariants.Length;
}