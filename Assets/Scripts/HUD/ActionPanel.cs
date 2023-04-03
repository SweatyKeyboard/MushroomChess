using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionPanel : MonoBehaviour
{
    [SerializeField] private ActionPanelElement _actionPanelElementPrefab;
    [SerializeField] private Transform _contentField;

    private List<ActionPanelElement> _actions = new List<ActionPanelElement>();

    public List<ActionPanelElement> Actions => _actions;

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
    }

    public void HideForAll()
    {
        foreach (ActionPanelElement actionPanelElement in _actions)
        {
            actionPanelElement.gameObject.SetActive(false);
        }
    }
}