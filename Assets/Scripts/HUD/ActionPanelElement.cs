using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _actionsLast;

    private UnitPanelElement _unitPanel;

    private a_Action _action;
    public ActionCategory Category { get; private set; }

    public a_Action Action => _action;
    public TMP_Text Name => _name;
    public Image Icon => _icon;
    public TMP_Text ActionsLast => _actionsLast;
    public UnitPanelElement UnitPanel => _unitPanel;


    public event System.Action Clicking;


    public void Set(Action action, UnitPanelElement unit)
    {
        _unitPanel = unit;
        _icon.sprite = action.Icon;
        _name.text = action.Name;

        switch (action.ActionType)
        {
            case ActionType.Jump:
                if (_unitPanel.JumpsCount > 0)
                {
                    _action = new JumpAction(_unitPanel.Unit, 1, 0.5f);
                    Category = ActionCategory.Jumping;
                }
                break;

            case ActionType.MoveForward:
                if (_unitPanel.MovesCount > 0)
                {
                    _action = new MoveForwardAction(_unitPanel.Unit, 1);
                    Category = ActionCategory.Moving;
                }
                break;

            case ActionType.RotateLeft:
                _action = new RotationAction(_unitPanel.Unit, -90);
                Category = ActionCategory.Rotating;
                break;

            case ActionType.RotateRight:
                if (_unitPanel.RotatesCount > 0)
                {
                    _action = new RotationAction(_unitPanel.Unit, 90);
                    Category = ActionCategory.Rotating;
                }
                break;

            case ActionType.LowerGround:
                if (_unitPanel.SpecialCount > 0)
                {
                    _action = new GroundMoveAction(_unitPanel.Unit, false);
                    Category = ActionCategory.Specialing;
                }
                break;

            case ActionType.RaiseGround:
                if (_unitPanel.SpecialCount > 0)
                {
                    _action = new GroundMoveAction(_unitPanel.Unit, true);
                    Category = ActionCategory.Specialing;
                }
                break;

            case ActionType.Push:
                if (_unitPanel.SpecialCount > 0)
                {
                    _action = new ElementMovingAction(_unitPanel.Unit, 1);
                    Category = ActionCategory.Specialing;
                }
                break;
        }
        UpdateCounter();

    }

    public void UpdateCounter()
    {
        switch (Category)
        {
            case ActionCategory.Moving:
                _actionsLast.text = _unitPanel.MovesCount.ToString();
                break;
            case ActionCategory.Rotating:
                _actionsLast.text = _unitPanel.RotatesCount.ToString();
                break;
            case ActionCategory.Jumping:
                _actionsLast.text = _unitPanel.JumpsCount.ToString();
                break;
            case ActionCategory.Specialing:
                _actionsLast.text = _unitPanel.SpecialCount.ToString();
                break;

        }
    }

    public void AddToTurnList()
    {
        bool isActionShouldBeDone = true;

        switch (Category)
        {
            case ActionCategory.Jumping:
                if (_unitPanel.JumpsCount > 0)
                {
                    _unitPanel.OnJump();
                    isActionShouldBeDone = true;
                }
                break;

            case ActionCategory.Moving:
                if (_unitPanel.MovesCount > 0)
                {
                    _unitPanel.OnMove();
                    isActionShouldBeDone = true;
                }
                break;

            case ActionCategory.Rotating:
                if (_unitPanel.RotatesCount > 0)
                {
                    _unitPanel.OnRotate();
                    isActionShouldBeDone = true;
                }
                break;

            case ActionCategory.Specialing:
                if (_unitPanel.SpecialCount > 0)
                {
                    _unitPanel.OnSpecial();
                    isActionShouldBeDone = true;
                }
                break;
        }

        if (isActionShouldBeDone)
        {
            bool isSucceeded;
            TurnsPanel.Instance.AddAction(this, _icon.sprite, out isSucceeded);

            if (isSucceeded)
            {
                Clicking?.Invoke();
            }
        }
    }

    public void RemoveFromTurnList()
    {
        switch (Category)
        {
            case ActionCategory.Jumping:
                _unitPanel.OnJumpCanceled();
                break;

            case ActionCategory.Moving:
                _unitPanel.OnMoveCanceled();
                break;

            case ActionCategory.Rotating:
                _unitPanel.OnRotateCanceled();
                break;

            case ActionCategory.Specialing:
                _unitPanel.OnSpecialCanceled();
                break;
        }
        Clicking?.Invoke();
    }
}