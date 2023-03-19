using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class a_Unit : a_BoardElement
{
    [SerializeField] protected UnitMovingType _moving;
    public event System.Action Moving;

    public override bool IsAbleToMove(Position position)
    {
        return base.IsAbleToMove(position);
    }

    public virtual bool IsAbleToJump(Position position)
    {
        int x1 = Position.X;
        int y1 = Position.Y;
        int x2 = position.X;
        int y2 = position.Y;

        if (x2 < 0 || y2 < 0)
        {
            Debug.Log("<0");
            return false;
        }

        if (x2 >= Board.Instance.BoardSize || y2 >= Board.Instance.BoardSize)
        {
            Debug.Log(">5");
            return false;
        }

        if (Board.Instance.IsCellEmpty(new Position(x2, y2)))
        {
            Debug.Log("occupied");
            return false;
        }

        if (Board.Instance.Cells[x2, y2].Height -
            Board.Instance.Cells[x1, y1].Height >
            _moving.JumpHeight)
        {
            Debug.Log("too high");
            return false;
        }

        return true;
    }

    public bool IsAbleToRotate()
    {
        return true;
    }
    public IEnumerator MoveForward(int distance)
    {
        Position newPos = new Position(
            Position.X + Rotation.X * distance,
            Position.Y + Rotation.Y * distance);

        if (IsAbleToMove(newPos))
        {
            Board.Instance.UpdateOcuppiedCells(Position);
            Board.Instance.UpdateOcuppiedCells(newPos);
            Board.Instance.Cells[Position.X, Position.Y].Element = null;
            Board.Instance.Cells[newPos.X, newPos.Y].Element = this;

            Position = newPos;

            yield return CourutineAnimations.Move(gameObject, Board.Instance[newPos.X, newPos.Y]);
        }
        Moving?.Invoke();
    }

    public IEnumerator JumpForward(int distance, float height)
    {
        Position newPos = new Position(
            Position.X + Rotation.X * distance,
            Position.Y + Rotation.Y * distance);

        if (IsAbleToJump(newPos))
        {
            Board.Instance.UpdateOcuppiedCells(Position);
            Board.Instance.UpdateOcuppiedCells(newPos);
            Board.Instance.Cells[Position.X, Position.Y].Element = null;
            Board.Instance.Cells[newPos.X, newPos.Y].Element = this;

            Position = newPos;

            yield return CourutineAnimations.Jump(gameObject, Board.Instance[newPos.X, newPos.Y], height);
        }
        Moving?.Invoke();
    }

    public IEnumerator Rotate(int angle)
    {
        if (IsAbleToRotate())
        {
            Rotation.Angle += angle;
            yield return CourutineAnimations.Rotate(gameObject, angle);
        }
    }

}