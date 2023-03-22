using UnityEngine;

public class PauseObserver : MonoBehaviour
{
    public void Pause()
    {
        foreach (IPauseHandler pauseObject in FindObjectsOfType<ButtonPauseHandler>())
        {
            Debug.Log("paused");
            pauseObject.OnPause();
        }
    }

    public void Continue()
    {
        foreach (IPauseHandler pauseObject in FindObjectsOfType<ButtonPauseHandler>())
        {
            pauseObject.OnContinue();
        }
    }
}
