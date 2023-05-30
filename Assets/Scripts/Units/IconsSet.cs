using UnityEngine;

[CreateAssetMenu(menuName = "IconsSet")]
public class IconsSet : ScriptableObject
{
    [SerializeField] private Sprite _eye;
    public Sprite Eye => _eye;
}
