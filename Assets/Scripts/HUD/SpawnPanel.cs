using System.Collections.Generic;
using UnityEngine;

public class SpawnPanel : MonoBehaviour
{
    [SerializeField] private UnitData[] _allUnits;
    [SerializeField] private SpawnElement _spawnInfoPrefab;
    [SerializeField] private Transform _contentBox;

    private List<SpawnElement> _spawnElements = new List<SpawnElement>();

    public List<UnitData> UnitsList { get; private set; } = new List<UnitData>();

    private void Awake()
    {
        for (int i = 0; i < _allUnits.Length; i++)
        {
            _spawnElements.Add(
                Instantiate(
                    _spawnInfoPrefab,
                    _contentBox));
        }
    }


    public void Show()
    {
        UnitsList.Clear();
        foreach (UnitData unitData in _allUnits)
        {
            UnitsList.Add(unitData);
        }

        for (int i = 0; i < _spawnElements.Count; i++)
        {
            if (i < UnitsList.Count)
            {
                _spawnElements[i].gameObject.SetActive(true);
                _spawnElements[i].Set(UnitsList[i]);
            }
            else
            {
                _spawnElements[i].gameObject.SetActive(false);
            }
        }
    }

    public void Hide()
    {        
    }


}
