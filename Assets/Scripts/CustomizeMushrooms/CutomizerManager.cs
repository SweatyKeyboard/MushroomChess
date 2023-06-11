using UnityEngine;

public class CutomizerManager : MonoBehaviour
{
    [SerializeField] private ColorSetButton[] _colorButtons;

    private void Start()
    {
        _colorButtons[CustomizeData.SelectedColor].IsSelected = true;
    }

}
