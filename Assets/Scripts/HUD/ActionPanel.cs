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
        }
    }

    private void OnActionClick()
    {
        foreach (ActionPanelElement action in _actions)
        {
            action.UpdateCounter();
        }
    }

    public void ShowForUnit(a_Unit unit)
    {
        HideForAll();
        foreach (ActionPanelElement actionPanelElement in _actions.Where(x => x.UnitPanel.Unit == unit))
        {
            actionPanelElement.gameObject.SetActive(true);
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