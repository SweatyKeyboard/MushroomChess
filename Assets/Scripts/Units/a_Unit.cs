using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public abstract class a_Unit : a_BoardElement
{
    [SerializeField] protected UnitMovingType _moving;
    [SerializeField] protected MeshRenderer _head;
    [SerializeField] protected MeshRenderer[] _body;
    [SerializeField] protected Color _bodyColor;

    private Animator _animator;

    protected override bool IsShowingErrors => true;
    public Color HeadColor { get; private set; }
    public Color BodyColor => _bodyColor;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public override bool IsAbleToMove(Position position)
    {
        return base.IsAbleToMove(position);
    }

    public void SetHeadColor(Color color)
    {
        HeadColor = color;
        _head.material.SetColor("_BaseColor", color);
    }

    public void SetBodyColor()
    {
        foreach (MeshRenderer bodyPart in _body)
        {
            bodyPart.material.SetColor("_BaseColor", _bodyColor);
        }
    }

    private IEnumerator Move(int distance, int angleBias)
    {
        Rotation tempRotation = new Rotation(Rotation.Angle + angleBias);

        Position newPos = new Position(
            Position.X + tempRotation.X * distance,
            Position.Y + tempRotation.Y * distance);

        if (IsAbleToMove(newPos))
        {
            Board.Instance.UpdateOcuppiedCells(Position);
            Board.Instance.UpdateOcuppiedCells(newPos);
            Board.Instance.Cells[Position.X, Position.Y].Element = null;
            Board.Instance.Cells[newPos.X, newPos.Y].Element = this;

            Position = newPos;

            yield return CourutineAnimations.Move(gameObject, Board.Instance[newPos.X, newPos.Y]);
        }
        Moved?.Invoke();
    }

    public IEnumerator MoveForward(int distance)
    {
        return Move(distance, 0);
    }

    public IEnumerator MoveLeft(int distance)
    {
        return Move(distance, -90);
    }

    public IEnumerator MoveRight(int distance)
    {
        return Move(distance, 90);
    }

    public IEnumerator JumpForward(int distance, float height)
    {
        Position newPos = new Position(
            Position.X + Rotation.X * distance,
            Position.Y + Rotation.Y * distance);

        if (IsAbleToJump(newPos, _moving.JumpHeight))
        {
            Board.Instance.UpdateOcuppiedCells(Position);
            Board.Instance.UpdateOcuppiedCells(newPos);
            Board.Instance.Cells[Position.X, Position.Y].Element = null;
            Board.Instance.Cells[newPos.X, newPos.Y].Element = this;

            Position = newPos;

            yield return CourutineAnimations.Jump(gameObject, Board.Instance[newPos.X, newPos.Y], height);
        }
        Moved?.Invoke();
    }

    public void Animate(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }
}