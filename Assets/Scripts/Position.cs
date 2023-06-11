using UnityEngine;

[System.Serializable]
public class Position
{
    [SerializeField] private int _x;
    [SerializeField] private int _y;

    public int X
    {
        get => _x;
        set => _x = value;
    }
    public int Y
    {
        get => _y;
        set => _y = value;
    }

    public Position(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public static Position operator+(Position position1, Position position2)
    {
        return new Position(position1.X + position2.X, position1.Y + position2.Y);
    }

    public static bool operator==(Position position1, Position position2)
    {
        if (position1 is null || position2 is null)
            return false;

        return position1.X == position2.X && position1.Y == position2.Y;
    }

    public static bool operator !=(Position position1, Position position2)
    {
        if (position1 is null || position2 is null)
            return true;

        return position1.X != position2.X || position1.Y != position2.Y;
    }
}