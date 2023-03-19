using UnityEngine;

[CreateAssetMenu]
public class Action : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ActionType _action;

    public string Name => _name;
    public Sprite Icon => _icon;
    public ActionType ActionType => _action;

}