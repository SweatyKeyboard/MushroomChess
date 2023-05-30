using UnityEngine;

[CreateAssetMenu(menuName = "HeadColors")]
public class UnitHeadsColors : ScriptableObject
{
    [SerializeField] private Color[] _colors;
    public Color this[int i] => _colors[i];
}
