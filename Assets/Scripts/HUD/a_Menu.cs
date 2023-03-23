using UnityEngine;
using UnityEngine.SceneManagement;

public class a_Menu : MonoBehaviour
{
    [SerializeField] private PauseObserver _pauseObserver;

    public void Show()
    {
        gameObject.SetActive(true);
        _pauseObserver.Pause();
        Time.timeScale = 0;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _pauseObserver.Continue();
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
