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

   /* private void Update()
    {
        if (!_isTimerStarted)
            return;

        _timer += Time.deltaTime;

        if (_timer < _timeToShow)
            return;

        Debug.Log("Timer Finished");
        _isTimerStarted = false;
        Show();
    }

    private void StopTimer()
    {
        _isTimerStarted = false;
    }

    private void StartTimer()
    {
     
        Debug.Log("Timer started");
        _timer = 0;
        _isTimerStarted = true;
        _isHintShowed = false;
    }*/

    public void Show()
    {
        Debug.Log("Hint showed");
        _banner.ShowTutorial(Hint);
        _isHintShowed = true;
    }

    /*private void OnMouseEnter()
    {
        Debug.Log("Collider works");
        StartTimer();
    }

    private void OnMouseExit()
    {
        if (!_isHintShowed)
        {
            StopTimer();
        }
        else
        {
            _banner.HideHint();
        }
    }*/

    private void OnDisable()
    {
        _banner.HideHint();
    }
}