using UnityEngine;
using UnityEngine.UI;

public class TurnPanelElement : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _label;

    public Image Icon => _icon;
    public Image Label => _label;
}
