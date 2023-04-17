using UnityEngine;
using UnityEngine.Events;

public class Hintable : MonoBehaviour
{
    private Banner _banner;

    private bool _isTimerStarted;
    private bool _isHintShowed = false;
    private float _timer;
    private float _timeToShow = 2f;    
    public string Hint { get; set; }


    private void Awake()
    {
        _banner = FindObjectOfType<Banner>(true);
    }

    private void Update()
    {
        if (!_isTimerStarted)
            return;

        _timer += Time.deltaTime;

        if (_timer < _timeToShow)
            return;

        _isTimerStarted = false;
        Show();
    }

    private void StopTimer()
    {
        _isTimerStarted = false;
    }

    private void StartTimer()
    {
        _timer = 0;
        _isTimerStarted = true;
        _isHintShowed = false;
    }

    private void Show()
    {
        _banner.ShowHint(Hint);
        _isHintShowed = true;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Enter");
        StartTimer();
    }

    private void OnMouseExit()
    {
        Debug.Log("Exit");
        if (!_isHintShowed)
        {
            Debug.Log("Stopped");
            StopTimer();
        }
        else
        {
            Debug.Log("Hidden");
            _banner.HideHint();
        }
    }

    private void OnDisable()
    {
        _banner.HideHint();
    }
}