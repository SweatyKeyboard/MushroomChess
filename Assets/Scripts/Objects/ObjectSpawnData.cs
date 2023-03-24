using System;
using UnityEngine;

[Serializable]
public class ObjectSpawnData
{
    [field: SerializeField] public ObjectData ObjectData { get; set; }
    [field: SerializeField] public Position Position { get; set; }
    [field: SerializeField] public Rotation Rotation { get; set; }


    [Range(0, 5)][field: SerializeField] private int _actsAfterTurn;
    public int ActsAfterTurn
    {
        get => _actsAfterTurn;
        set => _actsAfterTurn = value;
    }

}