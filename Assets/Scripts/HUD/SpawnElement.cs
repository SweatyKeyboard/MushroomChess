using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;

    private UnitData _unitData;

    public TMP_Text Text => _text;
    public Image Image => _image;

    public void Set(UnitData unitData)
    {
        _unitData = unitData;
    }

    public void Spawn()
    {
        ((Spawner)ObjectSelector.SelecedElement).Spawn(_unitData.Unit);

        StateChanger.Instance.TryChangeState(new StateUnitPicking());
        ObjectSelector.SelecedElement = null;
    }
}