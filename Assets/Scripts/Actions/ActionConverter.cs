using UnityEngine;
using static ActionType;
using static ActionCategory;
public static class ActionConverter
{
    public static a_Action Convert(a_BoardElement target, Action action, System.Action afterAction = null)
    {
        a_Action result = action.ActionType switch
        {
            MoveForward => new MoveForwardAction(target, 1),
            MoveLeft => new MoveLeftAction(target, 1),
            MoveRight => new MoveRightAction(target, 1),
            Run => new MoveForwardAction(target, 2),
            Jump => new JumpAction(target, 1, 0.5f),
            RotateRight => new RotationAction(target, 90),
            RotateLeft => new RotationAction(target, -90),
            Finish => new FinishLevelAction(target),
            LowerGround => new GroundMoveAction(target, false),
            RaiseGround => new GroundMoveAction(target, true),
            Push => new ElementMovingAction(target, 1),
            Roll180 => new ElementRotatingAction(target, 180),
            RollLeft => new ElementRotatingAction(target, -90),
            RollRight => new ElementRotatingAction(target, 90),
            Throw => new ElementThrowingAction(target, 2),
            Rotate180 => new RotationAction(target, 180),
            MimicPrevious => new MimicAction(target, MimicType.Previous),
            MimicNext => new MimicAction(target, MimicType.Next),
            _ => null
        };

        if (afterAction != null)
        {
            result.AfterAction = afterAction;
        }

        return result;
    }

    public static ActionCategory GetCategory(Action action)
    {
        ActionCategory result = action.ActionType switch
        {
            MoveForward => Moving,
            MoveLeft => Moving,
            MoveRight => Moving,
            Run => Moving,
            Jump => Jumping,
            RotateRight => Rotating,
            RotateLeft => Rotating,
            Finish => Specialing,
            LowerGround => Specialing,
            RaiseGround => Specialing,
            Push => Specialing,
            Roll180 => Specialing,
            RollLeft => Specialing,
            RollRight => Specialing,
            Throw => Specialing,
            Rotate180 => Rotating,
            MimicPrevious => Specialing,
            MimicNext => Specialing,
            _ => Moving
        };
        return result;
    }
}
