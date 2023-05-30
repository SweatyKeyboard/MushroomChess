using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class a_LevelSelectButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _insideText;

    [SerializeField] protected Image _completedLabel;

    [SerializeField] protected Sprite _completedSprite;
    [SerializeField] protected Sprite _emptySprite;

    [SerializeField] protected GameObject _lock;
    [SerializeField] protected TMP_Text _lockText;

    [SerializeField] protected int _levelNumber;
    [SerializeField] protected int _starsNeedForUnlock;
    protected LevelSelector _levelSelector;
    private Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
        _insideText.text = (_levelNumber + 1).ToString();
        _lockText.text = _starsNeedForUnlock.ToString();
    }

    protected virtual void Start()
    {
        _levelSelector = FindObjectOfType<LevelSelector>();
        _button.onClick.AddListener(delegate { _levelSelector.GoToLevel(_levelNumber); });
        _completedLabel.sprite = _levelSelector.IsLevelCompleted(_levelNumber) ?
            _completedSprite : _emptySprite;

        _lock.SetActive(_levelSelector.StarsCount < _starsNeedForUnlock);
        _button.interactable = _levelSelector.StarsCount >= _starsNeedForUnlock;
    }
}