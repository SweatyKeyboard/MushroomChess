﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnsPanel : MonoBehaviour
{
    [SerializeField] private UnitPanel _unitPanel;
    [SerializeField] private TurnPanelElement[] _cells;
    [SerializeField] private Sprite _emptySprite;
    [SerializeField] private TutorialHintPanel _tutorHintPanel;
    [SerializeField] private Button[] _lockedButtonsOnStart;

    public static TurnsPanel Instance;
    public List<ActionPanelElement> TurnsList { get; set; } = new List<ActionPanelElement>();
    public List<ActionLimiterData> TutorialTurnsList { get; set; } = new List<ActionLimiterData>();

    private Banner _banner;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _banner = FindObjectOfType<Banner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartActions();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RemoveAction();
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            ClearActions();
        }
    }

    public void RemoveAction()
    {
        if (TurnsList.Count == 0)
            return;

        TurnsList[TurnsList.Count - 1].RemoveFromTurnList();

        _cells[TurnsList.Count - 1].Icon.sprite = _emptySprite;

        TurnsList.RemoveAt(TurnsList.Count - 1);
        if (Board.Instance.Tutorial != null)
        {
            TutorialTurnsList.RemoveAt(TutorialTurnsList.Count - 1);
        }
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


        if (Board.Instance.Tutorial != null)
        {
            TutorialTurnsList.Clear();
        }
    }

    public bool AddAction(ActionPanelElement action, Sprite icon, Color color)
    {
        if (TurnsList.Count < 5)
        {
            TurnsList.Add(action);
            _cells[TurnsList.Count - 1].Icon.sprite = icon;
            _cells[TurnsList.Count - 1].Icon.color = color;
            return true;
        }

        Banner.Instance.ShowError("No more turns");
        return false;

    }

    public void AddTutorialAction(int unitId, Action action)
    {
        if (TutorialTurnsList.Count < 5)
        {
            TutorialTurnsList.Add(new ActionLimiterData(unitId, action));
        }
    }

    public void StartActions()
    {
        if (TurnsList.Count == 5)
        {
            StartActionsPrivate();
        }
        else
        {
            _banner.ShowError("err_5actions");
        }
    }

    private void TurnEnd()
    {
        LevelStatisticsCounter.TurnsCount++;
        _tutorHintPanel.SetImages(LevelStatisticsCounter.TurnsCount);
        Board.Instance.Tutorial?.InvokeEventsForTurn(LevelStatisticsCounter.TurnsCount);

        foreach (Button button in _lockedButtonsOnStart)
        {
            button.interactable = true;
        }
    }

    private void StartActionsPrivate()
    {
        foreach (Button button in _lockedButtonsOnStart)
        {
            button.interactable = false;
        }

        bool isAllright = true;

        if (Board.Instance.Tutorial != null)
        {
            isAllright = false;
            for (int i = 0; i < Board.Instance.Tutorial?.Actions[LevelStatisticsCounter.TurnsCount].Count; i++)
            {
                bool isVarianAllright = true;
                for (int j = 0; j < 5; j++)
                {                    
                    if (Board.Instance.Tutorial?.Actions[LevelStatisticsCounter.TurnsCount][i, j] != TutorialTurnsList[j])
                    {
                        isVarianAllright = false;
                    }
                }
                if (isVarianAllright)
                {
                    isAllright = true;
                    break;
                }
            }
        }


        if (isAllright)
        {
            List<a_Action> actionsList = TurnsList.Select(x => x.Action).ToList();

            int actionsAdded = 0;
            foreach (ObjectWithData obj in Board.Instance.ObjectsOnField)
            {
                actionsList.Insert(
                    obj.SpawnData.ActsAfterTurn + actionsAdded++,
                    ActionConverter.Convert(obj.Object, obj.SpawnData.ObjectData.Action, obj.Object.Shot));
            }

            foreach (TurnPanelElement cell in _cells)
            {
                cell.Icon.sprite = _emptySprite;
                cell.Label.sprite = _emptySprite;
            }

            StartCoroutine(ActionExecuter.Executor(actionsList, TurnEnd));
        }
        else
        {
            ClearActions();
            FindObjectOfType<Banner>().ShowTutorial("tut_wrongTurn");
        }

        TutorialTurnsList.Clear();
        TurnsList.Clear();
    }
}