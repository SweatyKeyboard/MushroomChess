using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : a_Menu
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private UnitPanel _unitPanel;
    private LevelSelector _levelSelector;

    public new void Show()
    {
        base.Show();
        _levelSelector = FindAnyObjectByType<LevelSelector>();

        _levelSelector.CompleteLevel();
        if (_unitPanel.TotalActionsLast >= 5)
        {
            _levelSelector.CompleteLevelFaster();
        }
        _nextLevelButton.interactable =
            (_levelSelector.SelectedLevel != Board.Instance.LevelCount - 1);

        SaveLoad.Save();
    }
}