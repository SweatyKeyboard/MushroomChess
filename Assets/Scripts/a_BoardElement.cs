using System.Collections;
using UnityEngine;

public class a_BoardElement : MonoBehaviour
{
    protected bool _selected;
    public Position Position { get; set; }
    public Rotation Rotation { get; set; } = new Rotation(0);

    public BoardCell BoardCell => Board.Instance.Cells[Position.X, Position.Y];
    public BoardCell CellInFrontOf => Board.Instance.Cells[Position.X + Rotation.X, Position.Y + Rotation.Y];


    public delegate void MovedDelegate();
    public MovedDelegate Moved;

    protected void ChangeSelection()
    {
        _selected = !_selected;
    }

    public virtual bool IsAbleToMove(Position position)
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

        if (Board.Instance.Cells[x2, y2].Height !=
            Board.Instance.Cells[x1, y1].Height)
        {
            Debug.Log("not straight");
            return false;
        }

        return true;
    }

    public virtual bool IsAbleToJump(Position position, int height)
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

        if (Board.Instance.Cells[x2, y2].Height - Board.Instance.Cells[x1, y1].Height > height)
        {
            Debug.Log("too high");
            return false;
        }

        return true;
    }


    public IEnumerator GetMoved(int distance, Rotation direction)
    {
        Position newPosition = Position + new Position(direction.X, direction.Y);
        if (IsAbleToMove(newPosition))
        {

            Board.Instance.UpdateOcuppiedCells(Position);
            Board.Instance.UpdateOcuppiedCells(newPosition);
            Board.Instance.Cells[Position.X, Position.Y].Element = null;
            Board.Instance.Cells[newPosition.X, newPosition.Y].Element = this;

            Position = newPosition;

            yield return CourutineAnimations.Move(gameObject, Board.Instance[newPosition.X, newPosition.Y]);
            Moved?.Invoke();
        }
    }

    public IEnumerator GetJumped(Rotation direction, int height)
    {
        Position newPosition = Position + new Position(direction.X, direction.Y);
        if (IsAbleToJump(newPosition, height))
        {
            Board.Instance.UpdateOcuppiedCells(Position);
            Board.Instance.UpdateOcuppiedCells(newPosition);
            Board.Instance.Cells[Position.X, Position.Y].Element = null;
            Board.Instance.Cells[newPosition.X, newPosition.Y].Element = this;

            Position = newPosition;

            yield return CourutineAnimations.Jump(gameObject, Board.Instance[newPosition.X, newPosition.Y], 0.75f);
            Moved?.Invoke();
        }
    }

    public bool IsAbleToRotate()
    {
        return true;
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