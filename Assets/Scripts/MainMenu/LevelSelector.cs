using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int SelectedLevel { get; private set; }
    public List<int> CollectedCoins { get; private set; } = new List<int>();
    public List<int> CompletedLevels { get; private set; } = new List<int>();
    public List<int> CompletedFasterLevels { get; private set; } = new List<int>();
    private static LevelSelector _instance;

    public int StarsCount => CompletedLevels.Count + CompletedFasterLevels.Count;
    public bool IsCoinCollectedHere => CollectedCoins.Contains(SelectedLevel);


    public void Quit()
    {
        Application.Quit();
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);


        SaveLoad.Load();

        CompletedLevels = CompletedLevels.Distinct().ToList();
        CompletedFasterLevels = CompletedFasterLevels.Distinct().ToList();
    }
    public void GoToLevel(int levelNumber)
    {
        SelectedLevel = levelNumber;
        SceneManager.LoadScene("Game");
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void CompleteLevel()
    {
        if (CompletedLevels.Contains(SelectedLevel))
            return;

        CompletedLevels.Add(SelectedLevel);
    }

    public void CompleteLevel(int i)
    {
        if (CompletedLevels.Contains(i))
            return;

        CompletedLevels.Add(i);
    }

    public void CollectCoin()
    {
        CollectedCoins.Add(SelectedLevel);
    }

    public void CollectCoin(int i)
    {
        CollectedCoins.Add(i);
    }

    public bool IsLevelCompleted(int level)
    {
        return CompletedLevels.Contains(level);
    }

    public void CompleteLevelFaster()
    {
        if (CompletedFasterLevels.Contains(SelectedLevel))
            return;

        CompletedFasterLevels.Add(SelectedLevel);
    }


    public void CompleteLevelFaster(int i)
    {
        if (CompletedFasterLevels.Contains(i))
            return;

        CompletedFasterLevels.Add(i);
    }

    public bool IsLevelCompletedFasster(int level)
    {
        return CompletedFasterLevels.Contains(level);
    }
}
