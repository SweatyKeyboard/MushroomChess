using UnityEngine;
using UnityEngine.UI;

public class ColorSetButton : MonoBehaviour
{
    [SerializeField] private Image[] _images;
    [SerializeField] private UnitHeadsColors _colorSet;
    [SerializeField] private GameObject _selectedOutline;

    private bool _isSelected;
    public static ColorSetButton LastButton { get; set; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            _selectedOutline.SetActive(value);

            if (!value)
                return;

            if (LastButton == this)
                return;

            if (LastButton != null)
            {
                LastButton.IsSelected = false;
            }
            LastButton = this;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].color = _colorSet[i];
        }
    }

    public void Click()
    {
        IsSelected = true;
    }
}