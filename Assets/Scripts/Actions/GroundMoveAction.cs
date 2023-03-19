using System.Collections;
using UnityEngine;

public class GroundMoveAction : a_Action
{
    private bool _isUpwardsMoving;
    private BoardCell _boardCell;

    public GroundMoveAction(a_BoardElement target, bool isUpwardsMoving) : base(target)
    {
        _isUpwardsMoving = isUpwardsMoving;
    }

    public override IEnumerator Courutine
    {
        get
        {
            int direction = (_isUpwardsMoving) ? 1 : -1;
            _boardCell = Target.CellInFrontOf;
            _boardCell.Height += direction;

            if (_boardCell.Element != null)
            {
                return CourutineAnimations.Move(
                    new GameObject[] {
                    _boardCell.gameObject,
                    _boardCell.Element.gameObject },
                    new Vector3[]
                    {
                    _boardCell.transform.position +
                    new Vector3(
                        0,
                        Board.Instance.StairScale * direction,
                        0),
                    _boardCell.Element.transform.position +
                    new Vector3(
                        0,
                        Board.Instance.StairScale * direction,
                        0),
                    });
            }
            else
            {
                return CourutineAnimations.Move(
                    _boardCell.gameObject,
                     _boardCell.transform.position +
                    new Vector3(
                        0,
                        Board.Instance.StairScale * direction,
                        0)
                    );
            }
        }
    }
}