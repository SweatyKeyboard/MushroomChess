using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Hintable))]
public class ActionPanelElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _actionsLast;
    [SerializeField] private TMP_Text _hotKeyText;
    [SerializeField] private Image _actionTypeImage;

    [Header("Images")]
    [SerializeField] private Sprite _movingActionSprite;
    [SerializeField] private Sprite _jumpingActionSprite;
    [SerializeField] private Sprite _rotatingActionSprite;
    [SerializeField] private Sprite _specialingActionSprite;

    private UnitPanelElement _unitPanel;
    private a_Action _action;
    private Action _actionData;
    private KeyCode _hotkey;
    public ActionCategory Category { get; private set; }


    public a_Action Action => _action;
    public TMP_Text Name => _name;
    public Image Icon => _icon;
    public TMP_Text ActionsLast => _actionsLast;
    public UnitPanelElement UnitPanel => _unitPanel;


    public event System.Action Clicking;
    public event System.Action<a_Unit> Removing;
    public event System.Action<a_Unit> ActionsAreOver;

    private void Update()
    {
        if (Input.GetKeyDown(_hotkey))
        {
            AddToTurnList();
        }
    }

    public void Set(Action action, UnitPanelElement unit)
    {
        _actionData = action;
        _unitPanel = unit;
        _icon.sprite = action.Icon;
        _name.text = action.Name;
        _hotKeyText.text = $"[{action.Hotkey}]";
        _hotkey = action.Hotkey;
        GetComponent<Hintable>().Hint = action.Hint;

        _action = ActionConverter.Convert(unit.Unit, action);
        Category = ActionConverter.GetCategory(action);

        switch (Category)
        {
            case ActionCategory.Moving:
                _actionTypeImage.sprite = _movingActionSprite;
                break;

            case ActionCategory.Jumping:
                _actionTypeImage.sprite = _jumpingActionSprite;
                break;

            case ActionCategory.Rotating:
                _actionTypeImage.sprite = _rotatingActionSprite;
                break;

            case ActionCategory.Specialing:
                _actionTypeImage.sprite = _specialingActionSprite;
                break;
        }


        UpdateCounter();

    }

    public void UpdateCounter()
    {
        int value = 0;
        switch (Category)
        {
            case ActionCategory.Moving:
                value = _unitPanel.MovesCount;
                break;
            case ActionCategory.Rotating:
                value = _unitPanel.RotatesCount;
                break;
            case ActionCategory.Jumping:
                value = _unitPanel.JumpsCount;
                break;
            case ActionCategory.Specialing:
                value = _unitPanel.SpecialCount;
                break;

        }
        _actionsLast.text = value.ToString();

        if (value == 0)
        {
            ActionsAreOver?.Invoke(_unitPanel.Unit);
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

        if (TurnsPanel.Instance.TurnsList.Count >= 5)
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

        
        if (TurnsPanel.Instance.AddAction(this, _icon.sprite, _unitPanel.Color))
        {
            if (Board.Instance.Tutorial != null)
            {
                TurnsPanel.Instance.AddTutorialAction(UnitPanel.Index, _actionData);
            }

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
        Removing?.Invoke(UnitPanel.Unit);
    }
}