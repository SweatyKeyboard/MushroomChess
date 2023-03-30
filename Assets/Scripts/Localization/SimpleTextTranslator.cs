using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class SimpleTextTranslator : MonoBehaviour
{

    [SerializeField] private string _key;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        UpdateText();
    }

    public void UpdateText()
    {
        _text.text = Localizer.GetStringByKey(_key);
    }
}
