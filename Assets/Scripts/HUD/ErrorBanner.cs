using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorBanner : MonoBehaviour
{
    [SerializeField] private TMP_Text _errorText;
    [SerializeField] private float _secondsForReadingOneLetter = 0.05f;
    [SerializeField] private float _minimalDuration = 3.3f;
    private Animator _animator;

    private float _timer = 0f;
    private float _duration;
    private bool _isTimerStarted = false;

    private bool _isShowing = false;
    private bool _isAnimating = false;

    private Queue<string> _messagesQueue = new Queue<string>();

    public static ErrorBanner Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        OnTimerTick();
    }

    private void OnTimerTick()
    {
        if (!_isTimerStarted)
            return;

        _timer += Time.deltaTime;

        if (_timer < _duration)
            return;

        _isShowing = false;
        if (_messagesQueue.Count == 0)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Show(string text)
    {
        _messagesQueue.Enqueue(text);
        Show();
    }

    public void Show()
    {
        if (_isShowing)
            return;
        if (_isAnimating)
            return;


        _animator.SetTrigger("Show");
        _isTimerStarted = true;
        _isShowing = true;

        string messageText = _messagesQueue.Dequeue();
        _errorText.text = messageText;
        _duration = messageText.Length * _secondsForReadingOneLetter + _minimalDuration;
        _timer = 0f;
    }

    public void Hide()
    {
        _animator.SetTrigger("Hide");
        _isAnimating = true;
        _isTimerStarted = false;
    }

    public void FinishHideAnimation()
    {
        _isAnimating = false;

        if (_messagesQueue.Count > 0)
        {
            Show();
        }
    }
}