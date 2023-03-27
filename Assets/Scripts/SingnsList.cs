using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SingnsList : ScriptableObject
{
    [SerializeField] private Mesh[] _list;

    public Mesh this[int i] => _list[i];
    public int Count => _list.Length;
}
