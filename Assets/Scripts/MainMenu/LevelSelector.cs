using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int SelectedLevel { get; private set; }
    public List<int> CompletedLevels { get; private set; } = new List<int>();

    private static LevelSelector _instance;

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
    }
    public void GoToLevel(int levelNumber)
    {
        Debug.Log(levelNumber);
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

    public bool IsLevelCompleted(int level)
    {
        return CompletedLevels.Contains(level);
    }
}
