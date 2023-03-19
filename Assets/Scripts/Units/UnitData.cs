using UnityEngine;

[CreateAssetMenu]
public class UnitData : ScriptableObject
{        
    [SerializeField] private a_Unit _unit;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Action[] _possibleActions;
    
    public a_Unit Unit => _unit;
    public string Name => _name;
    public Sprite Icon => _icon;
    public Action[] PossibleActions => _possibleActions;
}
