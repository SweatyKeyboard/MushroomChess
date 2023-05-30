using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : a_LevelSelectButton
{
    [HideInInspector][SerializeField] private Image _completedFasterLabel;
    protected override void Start()
    {
        base.Start();
        _completedFasterLabel.sprite = _levelSelector.IsLevelCompletedFasster(_levelNumber) ?
                                       _completedSprite : _emptySprite;
    }
}