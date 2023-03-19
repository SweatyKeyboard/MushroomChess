using UnityEngine;

[CreateAssetMenu]
public class UnitMovingType : ScriptableObject
{
    [SerializeField] private bool _isAbleToFly;
    [SerializeField] private Position[] _possibleMovingVectors;
    [SerializeField][Range(0, 8)] private int _jumpHeight;

    public Position[] PossibleMovingVectors => _possibleMovingVectors;
    public int JumpHeight => _jumpHeight;
}