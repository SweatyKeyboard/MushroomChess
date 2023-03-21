using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int SelectedLevel { get; private set; }

    private void Awake()
    {
        if (FindObjectsOfType<LevelSelector>().Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    public void GoToLevel(int levelNumber)
    {
        SelectedLevel = levelNumber;
        SceneManager.LoadScene("Game");
    }
}
