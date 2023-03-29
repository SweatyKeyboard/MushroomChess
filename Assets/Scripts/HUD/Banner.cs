using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour
{
    [SerializeField] private PauseObserver _pauseObserver;
    [SerializeField] private TMP_Text _errorText;
    [SerializeField] private Image _background;

    [SerializeField] private float _secondsForReadingOneLetter = 0.05f;
    [SerializeField] private float _minimalDuration = 3.3f;

    [Header("Banners")]
    [SerializeField] private BannerType _errorBanner;
    [SerializeField] private BannerType _hintBanner;
    [SerializeField] private BannerType _tutorialBanner;

    private Animator _animator;

    private float _timer = 0f;
    private float _duration;
    private bool _isTimerStarted = false;

    private bool _isShowing = false;
    private bool _isAnimating = false;
    private bool _isAlreadyVisible = false;

    private Queue<BannerOption> _messagesQueue = new Queue<BannerOption>();
    private BannerOption _currentMessage;

    public static Banner Instance { get; set; }

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

    private void OnMouseDown()
    {
        HideTutorial();
    }

    private void OnTimerTick()
    {
        if (!_isTimerStarted)
            return;

        _timer += Time.deltaTime;

        if (_timer < _duration)
            return;

        _isTimerStarted = false;
        CheckForNewMessages();
    }

    private void CheckForNewMessages()
    {
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

    public void ShowHint(string text)
    {
        Show(text, _hintBanner);
    }

    public void HideHint()
    {
        if (_currentMessage.Type.ClosingCondition != BannerClosingCondition.LostHover)
            return;

        CheckForNewMessages();
    }

    public void ShowTutorial(string text)
    {
        Show(text, _tutorialBanner);
        _pauseObserver.Pause();
    }
    public void HideTutorial()
    {
        if (_currentMessage.Type.ClosingCondition != BannerClosingCondition.Click)
            return;

        _pauseObserver.Continue();
        CheckForNewMessages();
    }

    public void ShowError(string text)
    {
        Show(text, _errorBanner);
    }

    public void Show(string text, BannerType bannerType)
    {
        _messagesQueue.Enqueue(new BannerOption(text, bannerType));
        Show();
    }

    public void Show()
    {
        if (_isShowing)
            return;
        if (_isAnimating)
            return;

        if (!_isAlreadyVisible)
        {
            _animator.SetTrigger("Show");
            _isAlreadyVisible = true;
        }
        _isShowing = true;

        _currentMessage = _messagesQueue.Dequeue();
        _errorText.text = _currentMessage.Text;
        _background.color = _currentMessage.Type.Color;

        if (_currentMessage.Type.ClosingCondition == BannerClosingCondition.Time)
        {
            _isTimerStarted = true;
            _duration = _currentMessage.Text.Length * _secondsForReadingOneLetter + _minimalDuration;
            _timer = 0f;
        }
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
        _isAlreadyVisible = false;

        if (_messagesQueue.Count > 0)
        {
            Show();
        }
    }
}