using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionPanel : MonoBehaviour
{
    [SerializeField] private ActionPanelElement _actionPanelElementPrefab;
    [SerializeField] private RectTransform _contentField;
    [SerializeField] private UnitPanel _unitPanel;

    private List<ActionPanelElement> _actions = new List<ActionPanelElement>();

    public List<ActionPanelElement> Actions => _actions;

    private void SetContentAreaSize()
    {
        int actionsCount = _actions.Where(x => x.isActiveAndEnabled).Count();
        _contentField.sizeDelta = new Vector2(175, 40 + (100 + 20) * actionsCount);
    }

    public void CreateForUnit(UnitPanelElement unitPanel, UnitData data)
    {
        foreach (Action action in data.PossibleActions)
        {
            ActionPanelElement newAction = Instantiate(
                _actionPanelElementPrefab,
                _contentField);
            newAction.Set(action, unitPanel);
            _actions.Add(newAction);
            newAction.gameObject.SetActive(false);
            newAction.Clicking += OnActionClick;
            newAction.ActionsAreOver += ShowForUnit;
            newAction.Removing += (unit) =>
            {
                ShowForUnit(unit);
                OnActionClick();
            };
        }

    }

    private void OnActionClick()
    {
        foreach (ActionPanelElement action in _actions)
        {
            if (action.isActiveAndEnabled)
            {
                action.UpdateCounter();
            }
        }
    }

    public void ShowForUnit(a_Unit unit)
    {

        if (_unitPanel.SelectedUnit != null && _unitPanel.SelectedUnit != unit)
            return;

        foreach (ActionPanelElement actionPanelElement in _actions)
        {
            int actionsInCategory = actionPanelElement.Category switch
            {
                ActionCategory.Moving => actionPanelElement.UnitPanel.MovesCount,
                ActionCategory.Jumping => actionPanelElement.UnitPanel.JumpsCount,
                ActionCategory.Rotating => actionPanelElement.UnitPanel.RotatesCount,
                ActionCategory.Specialing => actionPanelElement.UnitPanel.SpecialCount,
                _ => 0
            };


            if (actionPanelElement.UnitPanel.Unit == unit && actionsInCategory > 0)
            {
                actionPanelElement.gameObject.SetActive(true);
            }
            else
            {
                actionPanelElement.gameObject.SetActive(false);
            }
        }
        SetContentAreaSize();
    }

    public void HideForAll()
    {
        foreach (ActionPanelElement actionPanelElement in _actions)
        {
            actionPanelElement.gameObject.SetActive(false);
        }
    }
}