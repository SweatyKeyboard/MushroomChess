using UnityEngine;

[CreateAssetMenu]
public class UnitData : ScriptableObject
{        
    [SerializeField] private a_Unit _unit;
    [SerializeField] private string _nameKey;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Action[] _possibleActions;
    
    public a_Unit Unit => _unit;
    public string Name => Localizer.GetStringByKey(_nameKey);
    public Sprite Icon => _icon;
    public Action[] PossibleActions => _possibleActions;
}
