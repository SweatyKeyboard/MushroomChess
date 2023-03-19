using UnityEngine;

[CreateAssetMenu]
public class LabelsList : ScriptableObject
{
    [SerializeField] private Sprite[] _labels;

    public Sprite this[int i] => _labels[i];
}
