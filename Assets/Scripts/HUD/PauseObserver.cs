using UnityEngine;
using System.Linq;
public class PauseObserver : MonoBehaviour
{
    public void Pause()
    {
        foreach (IPauseHandler pauseObject in FindObjectsOfType<MonoBehaviour>().OfType<IPauseHandler>().ToArray())
        {
            pauseObject.OnPause();
        }
    }

    public void Continue()
    {
        foreach (IPauseHandler pauseObject in FindObjectsOfType<MonoBehaviour>().OfType<IPauseHandler>().ToArray())
        {
            pauseObject.OnContinue();
        }
    }
}