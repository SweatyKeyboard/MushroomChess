using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : a_Menu
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private UnitPanel _unitPanel;

    [SerializeField] private Image _completedFasterStar;
    [SerializeField] private Sprite _star;
    [SerializeField] private Sprite _emptyStar;

    [SerializeField] private GameObject _starLayout;
    [SerializeField] private GameObject _tutorialStarLayout;


    private LevelSelector _levelSelector;

    public new void Show()
    {
        base.Show();
        _levelSelector = FindAnyObjectByType<LevelSelector>();


        _starLayout.SetActive(Board.Instance.Tutorial == null);
        _tutorialStarLayout.SetActive(Board.Instance.Tutorial != null);

        _levelSelector.CompleteLevel();
        _completedFasterStar.sprite = _emptyStar;
        if (_unitPanel.TotalActionsLast >= 5)
        {
            _levelSelector.CompleteLevelFaster();
            _completedFasterStar.sprite = _star;
        }
        _nextLevelButton.interactable =
            (_levelSelector.SelectedLevel != Board.Instance.LevelCount - 1);


        SaveLoad.Save();
    }
}