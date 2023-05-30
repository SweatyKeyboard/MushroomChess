using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollRectPauseHandler : MonoBehaviour, IPauseHandler
{
    private ScrollRect _rect;

    private void Awake()
    {
        _rect = GetComponent<ScrollRect>();
    }
    public void OnContinue()
    {
        _rect.enabled = true;
    }

    public void OnPause()
    {
        _rect.enabled = false;
    }
}