using UnityEngine;

[CreateAssetMenu]
public class UnitMovingType : ScriptableObject
{
    [SerializeField] private bool _isAbleToFly;
    [SerializeField][Range(0, 8)] private int _jumpHeight;

    public int JumpHeight => _jumpHeight;
}