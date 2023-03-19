using System;
using UnityEngine;

[Serializable]
public class UnitSpawnData
{
    [field: SerializeField] public UnitData UnitData { get; set; }
    [field: SerializeField] public Position Position { get; set; }
    [field: SerializeField] public Rotation Rotation { get; set; }


    [field: SerializeField] public int MoveAcionsCount { get; set; }
    [field: SerializeField] public int RotateAcionsCount { get; set; }
    [field: SerializeField] public int JumpAcionsCount { get; set; }
    [field: SerializeField] public int SpecialAcionsCount { get; set; }

}