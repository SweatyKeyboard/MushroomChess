using UnityEngine;

[System.Serializable]
public class Rotation
{
    [SerializeField] private int _angle = 0;
    public int X => (int)Mathf.Cos(_angle * Mathf.Deg2Rad);
    public int Y => -(int)Mathf.Sin(_angle * Mathf.Deg2Rad);
    public int Angle
    {
        get => _angle;
        set
        {
            _angle = value;
            _angle %= 360;
        }
    }

    public Direction DirectedAngle
    {
        get
        {
            switch (_angle)
            {
                case 180:
                    return Direction.North;

                case 270:
                    return Direction.East;

                case 0:
                    return Direction.South;

                case 90:
                    return Direction.West;
                default:
                    return Direction.North;
            }

        }

        set
        {
            switch (value)
            {
                case Direction.North:
                    _angle = 180;
                    break;

                case Direction.East:
                    _angle = 270;
                    break;

                case Direction.South:
                    _angle = 0;
                    break;

                case Direction.West:
                    _angle = 90;
                    break;
            }
        }
    }

    public Rotation(int angle)
    {
        Angle = angle;
    }

    public Rotation(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                _angle = 180;
                break;

            case Direction.East:
                _angle = 270;
                break;

            case Direction.South:
                _angle = 0;
                break;

            case Direction.West:
                _angle = 90;
                break;

            default:
                _angle = 180;
                break;
        }
    }
}