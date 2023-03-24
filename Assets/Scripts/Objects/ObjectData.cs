using UnityEngine;

[CreateAssetMenu]
public class ObjectData : ScriptableObject
{
    [SerializeField] private a_BoardObject _object;
    [SerializeField] private string _name;
    [SerializeField] private Action _action;

    public a_BoardObject Object => _object;
    public string Name => _name;
    public Action Action => _action;
}
