using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class StateText : MonoBehaviour
{
    private TMP_Text _text;

    public static StateText Instance;
    public string Text
    {
        get => _text.text;
        set => _text.text = value;
    }

    protected void Awake()
    {
        Instance = this;
        _text = GetComponent<TMP_Text>();
    }
}