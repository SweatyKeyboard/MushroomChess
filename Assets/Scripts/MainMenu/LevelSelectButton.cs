using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelectButton : MonoBehaviour
{
    [HideInInspector][SerializeField] private TMP_Text _insideText;
    [HideInInspector][SerializeField] private Image _completedLabel;
    [HideInInspector][SerializeField] private Sprite _completedSprite;
    [HideInInspector][SerializeField] private Sprite _emptySprite;

    [SerializeField] private int _levelNumber;
    private LevelSelector _levelSelector;
    private Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
        _insideText.text = _levelNumber.ToString();
    }

    private void Start()
    {
        _levelSelector = FindObjectOfType<LevelSelector>();
        _button.onClick.AddListener(delegate { _levelSelector.GoToLevel(_levelNumber); });
        _completedLabel.sprite = _levelSelector.IsLevelCompleted(_levelNumber) ?
            _completedSprite : _emptySprite;
    }

}
