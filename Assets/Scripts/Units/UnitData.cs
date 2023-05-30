using UnityEngine;

[CreateAssetMenu]
public class UnitData : ScriptableObject
{        
    [SerializeField] private a_Unit _unit;
    [SerializeField] private string _nameKey;
    [SerializeField] private IconsSet _icons;
    [SerializeField] private Action[] _possibleActions;
    
    public a_Unit Unit => _unit;
    public string Name => Localizer.GetStringByKey(_nameKey);
    public IconsSet Icons => _icons;
    public Action[] PossibleActions => _possibleActions;
}
