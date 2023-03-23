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
                _action = new JumpAction(_unitPanel.Unit, 1, 0.5f);
                Category = ActionCategory.Jumping;
                break;

            case ActionType.MoveForward:
                _action = new MoveForwardAction(_unitPanel.Unit, 1);
                Category = ActionCategory.Moving;
                break;

            case ActionType.RotateLeft:
                _action = new RotationAction(_unitPanel.Unit, -90);
                Category = ActionCategory.Rotating;
                break;

            case ActionType.RotateRight:
                _action = new RotationAction(_unitPanel.Unit, 90);
                Category = ActionCategory.Rotating;
                break;

            case ActionType.LowerGround:
                _action = new GroundMoveAction(_unitPanel.Unit, false);
                Category = ActionCategory.Specialing;
                break;

            case ActionType.RaiseGround:
                _action = new GroundMoveAction(_unitPanel.Unit, true);
                Category = ActionCategory.Specialing;
                break;

            case ActionType.Push:
                _action = new ElementMovingAction(_unitPanel.Unit, 1);
                Category = ActionCategory.Specialing;
                break;

            case ActionType.Run:
                _action = new MoveForwardAction(_unitPanel.Unit, 2);
                Category = ActionCategory.Moving;
                break;

            case ActionType.Roll:
                _action = new ElementRotatingAction(_unitPanel.Unit, 180);
                Category = ActionCategory.Specialing;
                break;

            case ActionType.MoveLeft:
                _action = new MoveLeftAction(_unitPanel.Unit, 1);
                Category = ActionCategory.Moving;
                break;

            case ActionType.MoveRight:
                _action = new MoveRightAction(_unitPanel.Unit, 1);
                Category = ActionCategory.Moving;
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

    private bool AreThereActionsInCategory(ActionCategory category)
    {
        switch (category)
        {
            case ActionCategory.Moving:
                return _unitPanel.MovesCount > 0;

            case ActionCategory.Jumping:
                return _unitPanel.JumpsCount > 0;

            case ActionCategory.Rotating:
                return _unitPanel.RotatesCount > 0;

            case ActionCategory.Specialing:
                return _unitPanel.SpecialCount > 0;
            default:
                return false;
        }
    }

    public void AddToTurnList()
    {
        bool isActionShouldBeDone = false;

        if (!AreThereActionsInCategory(Category))
            return;

        switch (Category)
        {
            case ActionCategory.Jumping:
                _unitPanel.OnJump();
                isActionShouldBeDone = true;
                break;

            case ActionCategory.Moving:
                _unitPanel.OnMove();
                isActionShouldBeDone = true;
                break;

            case ActionCategory.Rotating:
                _unitPanel.OnRotate();
                isActionShouldBeDone = true;
                break;

            case ActionCategory.Specialing:
                _unitPanel.OnSpecial();
                isActionShouldBeDone = true;
                break;
        }


        if (!isActionShouldBeDone)
            return;

        bool isSucceeded;
        TurnsPanel.Instance.AddAction(this, _icon.sprite, out isSucceeded);
        if (isSucceeded)
        {
            Clicking?.Invoke();
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