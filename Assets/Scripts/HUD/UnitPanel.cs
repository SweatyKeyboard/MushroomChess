using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitPanel : MonoBehaviour
{
    [SerializeField] private UnitPanelElement _unitPanelElementPrefab;
    [SerializeField] private RectTransform _contentField;
    [SerializeField] private ActionPanel _actionPanel;


    private List<UnitPanelElement> _units = new List<UnitPanelElement>();
    private int _selectedIndex = -1;

    public List<UnitPanelElement> Units => _units;
    public a_Unit SelectedUnit => _units[_selectedIndex].Unit;

    public int TotalActionsLast => _units.Select(x => x.JumpsCount + x.MovesCount + x.SpecialCount + x.RotatesCount).Sum();
    public void SelectByUnit(a_Unit unit)
    {
        foreach (UnitPanelElement unitPanel in _units)
        {
            if (unitPanel.Unit == unit)
            {
                unitPanel.OnClicked();
                return;
            }
        }
    }

    public void SetContentAreaSize(int unitsCount)
    {
        _contentField.sizeDelta = new Vector2(175, 40 + (150 + 20) * unitsCount);
    }

    public void AddUnit(a_Unit unit, UnitSpawnData spawnData)
    {
        UnitPanelElement newUnit = Instantiate(
            _unitPanelElementPrefab,
            _contentField);
        newUnit.Set(unit, _units.Count, spawnData.UnitData.Icons, spawnData.UnitData.Name, unit.HeadColor, unit.BodyColor);
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
            _units[id].Unit.Animate("OnSelected");
        }
        else
        {
            _selectedIndex = -1;
            _actionPanel.HideForAll();
        }
    }
}