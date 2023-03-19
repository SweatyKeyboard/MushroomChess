using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]

public class BoardData : ScriptableObject
{
    [SerializeField] public int BoardSize = 5;
    [SerializeField] public int BoardSiz { get; set; } = 5;
    [SerializeField] public int[] HeightMapa { get; set; }
    [SerializeField] public int[] HeightMap = new int[25];

    [SerializeField] public List<UnitSpawnData> Unitsa { get; set; } = new List<UnitSpawnData>();
    [SerializeField] public List<UnitSpawnData> Units = new List<UnitSpawnData>();

    private void OnEnable()
    {
        if (HeightMap == null)
        {
            HeightMap = new int[BoardSize*BoardSize];
            //HeightMapa = new int[BoardSize*BoardSize];
        }
    }

    public void FillHeightMapWith(int value)
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                HeightMap[i +BoardSize * j] = value;
            }
        }
    }
}
