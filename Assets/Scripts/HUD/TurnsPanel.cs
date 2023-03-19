﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnsPanel : MonoBehaviour
{
    [SerializeField] private UnitPanel _unitPanel;
    [SerializeField] private TurnPanelElement[] _cells;
    [SerializeField] private Sprite _emptySprite;

    public static TurnsPanel Instance;
    public List<ActionPanelElement> TurnsList { get; set; } = new List<ActionPanelElement>();

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
        }
    }

    public void RemoveAction()
    {
        TurnsList[TurnsList.Count - 1].RemoveFromTurnList();

        _cells[TurnsList.Count - 1].Icon.sprite = _emptySprite;
        _cells[TurnsList.Count - 1].Label.sprite = _emptySprite;

        TurnsList.RemoveAt(TurnsList.Count - 1);
    }

    public void ClearActions()
    {
        foreach (ActionPanelElement action in TurnsList)
        {
            action.RemoveFromTurnList();
        }
        TurnsList.Clear();

        foreach (TurnPanelElement cell in _cells)
        {
            cell.Icon.sprite = _emptySprite;
            cell.Label.sprite = _emptySprite;
        }
    }

    public void AddAction(ActionPanelElement action, Sprite icon, out bool isSucceeded)
    {
        if (TurnsList.Count < 5)
        {
            TurnsList.Add(action);
            _cells[TurnsList.Count - 1].Icon.sprite = icon;
            _cells[TurnsList.Count - 1].Label.sprite = action.UnitPanel.Label;
            isSucceeded = true;
        }
        else
        {
            Debug.Log("No more turns");
            isSucceeded = false;
        }
    }

    public void StartActions()
    {
        if (TurnsList.Count == 5)
        {
            StartActionsPrivate();
        }
    }

    private void StartActionsPrivate()
    {
        StartCoroutine(ActionExecuter.Executor(TurnsList.Select(x => x.Action).ToList()));
        foreach (TurnPanelElement cell in _cells)
        {
            cell.Icon.sprite = _emptySprite;
            cell.Label.sprite = _emptySprite;
        }
        TurnsList.Clear();
    }
}