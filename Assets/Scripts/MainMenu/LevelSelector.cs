using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void GoToLevel(int levelNumber)
    {
        SceneManager.LoadScene("Game");
    }
}
