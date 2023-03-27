public static class ActionConverter
{
    public static a_Action Convert(a_BoardElement target, Action action)
    {
        a_Action result = action.ActionType switch
        {
            ActionType.Push => new ElementMovingAction(target, 1),
            ActionType.RollLeft => new ElementRotatingAction(target, -90),
            ActionType.RollRight => new ElementRotatingAction(target, 90),
            _ => null
        };
        return result;
    }
}
