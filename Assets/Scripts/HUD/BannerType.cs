using UnityEngine;

[CreateAssetMenu(menuName = "BannerType")]
public class BannerType : ScriptableObject
{

    [SerializeField] private Color _color;
    [SerializeField] private BannerClosingCondition _closingCondition;

    public Color Color => _color;
    public BannerClosingCondition ClosingCondition => _closingCondition;
}