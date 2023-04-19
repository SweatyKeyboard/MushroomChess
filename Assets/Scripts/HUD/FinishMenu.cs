using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : a_Menu
{
    [SerializeField] private Button _nextLevelButton;
    public new void Show()
    {
        base.Show();

        FindObjectOfType<LevelSelector>().CompleteLevel();

        _nextLevelButton.interactable = FindObjectOfType<LevelSelector>().SelectedLevel != Board.Instance.LevelCount;
    }
}