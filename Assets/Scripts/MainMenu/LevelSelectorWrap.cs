using UnityEngine;

public class LevelSelectorWrap : MonoBehaviour
{
    private LevelSelector _levelSelector;

    public int StarsCount => _levelSelector.StarsCount;
    private void Awake()
    {
        _levelSelector = FindObjectOfType<LevelSelector>();
        Debug.Log(_levelSelector.StarsCount);
    }
    public void GoToLevel(int levelNumber)
    {
        LevelStatisticsCounter.TurnsCount = 0;
        _levelSelector.GoToLevel(levelNumber);
    }

    public void RestartLevel()
    {
        LevelStatisticsCounter.TurnsCount = 0;
        _levelSelector.RestartCurrentLevel();
    }

    public void NextLevel()
    {
        LevelStatisticsCounter.TurnsCount = 0;
        _levelSelector.GoToLevel(_levelSelector.SelectedLevel + 1);
    }

    public void Quit()
    {
        _levelSelector.Quit();
    }
}
