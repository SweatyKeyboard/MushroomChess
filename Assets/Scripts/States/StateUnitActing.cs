using UnityEngine;
public class StateUnitActing : a_State
{
    public StateUnitActing()
    {
    }

    public override a_State[] AllowedStatesToChange => new a_State[]
    {
        new StateUnitPicking(),
        new StateAnimating()
    };

    public override void OnFinish()
    {

    }

    public override void OnStart()
    {
        /*foreach (Position position in ((a_Unit)SelectedElement).GetPossibleMoves())
        {
            Board.Instance.Cells[position.X, position.Y].ShowMovePoint();
        }*/
    }
}