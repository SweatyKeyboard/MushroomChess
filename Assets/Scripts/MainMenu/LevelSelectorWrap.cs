using UnityEngine;

public class LevelSelectorWrap : MonoBehaviour
{
    private LevelSelector _levelSelector;
    private void Awake()
    {
        _levelSelector = FindObjectOfType<LevelSelector>();
    }
    public void GoToLevel(int levelNumber)
    {
        _levelSelector.GoToLevel(levelNumber);
    }

    public void RestartLevel()
    {
        _levelSelector.RestartCurrentLevel();
    }

    public void NextLevel()
    {
        _levelSelector.GoToLevel(_levelSelector.SelectedLevel + 1);
    }
}
