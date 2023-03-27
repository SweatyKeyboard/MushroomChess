using UnityEngine;

[CreateAssetMenu]
public class Action : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ActionType _action;
    [SerializeField] private KeyCode _hotkey;

    public string Name => _name;
    public Sprite Icon => _icon;
    public ActionType ActionType => _action;
    public KeyCode Hotkey => _hotkey;

}