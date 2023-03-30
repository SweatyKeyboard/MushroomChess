using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class BoardData : ScriptableObject
{
    [SerializeField] public int BoardSize = 5;
    [SerializeField] public int[] HeightMap = new int[25];

    [SerializeField] public Position FinishPosition;
    [SerializeField] public List<UnitSpawnData> Units = new List<UnitSpawnData>();
    [SerializeField] public List<ObjectSpawnData> Objects = new List<ObjectSpawnData>();
    [SerializeField] public BoardColors BoardColors;
    [SerializeField] public TutorialLevel TutorialInstructions;

    private void OnEnable()
    {
        if (HeightMap != null)
            return;
        HeightMap = new int[BoardSize * BoardSize];
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
