using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonPauseHandler : MonoBehaviour, IPauseHandler
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    public void OnContinue()
    {
        _button.enabled = true;
    }

    public void OnPause()
    { 
        _button.enabled = false;
    }
}