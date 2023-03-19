using UnityEngine;

public class Spawner : a_CellModifier
{
    private void OnMouseDown()
    {
        ChangeSelection();

        if (_selected)
        {
            ObjectSelector.SelecedElement = this;
            StateChanger.Instance.TryChangeState(new StateUnitSpawning());
        }
        else
        {
            ObjectSelector.SelecedElement = this;
            StateChanger.Instance.TryChangeState(new StateUnitPicking());
        }
    }

    public void Spawn(a_Unit unit)
    {
        Instantiate(
            unit,
            transform.position,
            Quaternion.identity,
            transform.parent);
        Board.Instance.UpdateOcuppiedCells(Position);
    }
}