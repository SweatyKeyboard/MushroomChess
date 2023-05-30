using UnityEngine;

[CreateAssetMenu]
public class Action : ScriptableObject
{
    [SerializeField] private string _nameKey;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ActionType _action;
    [SerializeField] private KeyCode _hotkey;
    [SerializeField] private string _hintKey;

    public string Name => Localizer.GetStringByKey(_nameKey);
    public Sprite Icon => _icon;
    public ActionType ActionType => _action;
    public KeyCode Hotkey => _hotkey;
    public string Hint => _hintKey;

}