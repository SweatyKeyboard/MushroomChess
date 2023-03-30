using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPanel : MonoBehaviour
{
    [SerializeField] private UnitPanelElement _unitPanelElementPrefab;
    [SerializeField] private Transform _contentField;

    [SerializeField] private ActionPanel _actionPanel;

    private List<UnitPanelElement> _units = new List<UnitPanelElement>();
    private int _selectedIndex = -1;

    public List<UnitPanelElement> Units => _units;
    public a_Unit SelectedUnit => _units[_selectedIndex].Unit;

    public void AddUnit(a_Unit unit, UnitSpawnData spawnData)
    {
        UnitPanelElement newUnit = Instantiate(
            _unitPanelElementPrefab,
            _contentField);
        newUnit.Set(unit, _units.Count, spawnData.UnitData.Icon, spawnData.UnitData.Name);
        newUnit.SetActionsCount(spawnData);
        newUnit.Clicking += OnUnitSelected;
        _units.Add(newUnit);

        _actionPanel.CreateForUnit(newUnit, spawnData.UnitData);
    }

    private void OnUnitSelected(int id)
    {
        if (_selectedIndex != -1)
        {
            _units[_selectedIndex].Background.color = new Color(1f, 1f, 1f, 0.4f);
        }

        if (id != _selectedIndex)
        {
            _units[id].Background.color = new Color(0.5f, 0.8f, 0.5f, 0.4f);
            _selectedIndex = id;
            _actionPanel.ShowForUnit(_units[id].Unit);
        }
        else
        {
            _selectedIndex = -1;
            _actionPanel.HideForAll();
        }
    }
}