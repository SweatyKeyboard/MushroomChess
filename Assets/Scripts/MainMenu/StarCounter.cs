using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class StarCounter : MonoBehaviour
{
    private TMP_Text _text;
    [SerializeField] private int _starsCount;
    [SerializeField] private LevelSelectorWrap _levelSelectorWrap;
    
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        SetText();
    }

    public void SetText()
    {
        _text.text = Localizer.GetStringByKey("txt_stars") + ": " + _levelSelectorWrap.StarsCount + " / " + _starsCount;
    }
}