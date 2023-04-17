using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int SelectedLevel { get; private set; }

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
        SelectedLevel = levelNumber;
        SceneManager.LoadScene("Game");
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
