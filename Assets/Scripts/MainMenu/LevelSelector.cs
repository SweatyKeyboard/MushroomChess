using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int SelectedLevel { get; private set; }
    public List<int> CompletedLevels { get; private set; } = new List<int>();
    public List<int> CompletedFasterLevels { get; private set; } = new List<int>();
    private static LevelSelector _instance;

    public int StarsCount => CompletedLevels.Count + CompletedFasterLevels.Count;


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
        CompletedLevels.Add(SelectedLevel);
    }

    public void CompleteLevel(int i)
    {
        CompletedLevels.Add(i);
    }

    public bool IsLevelCompleted(int level)
    {
        return CompletedLevels.Contains(level);
    }

    public void CompleteLevelFaster()
    {
        CompletedFasterLevels.Add(SelectedLevel);
    }

    public void CompleteLevelFaster(int i)
    {
        CompletedFasterLevels.Add(i);
    }

    public bool IsLevelCompletedFasster(int level)
    {
        return CompletedFasterLevels.Contains(level);
    }
}
