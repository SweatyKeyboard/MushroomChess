using System;
using UnityEngine;

[Serializable]
public class BannerOption
{
    [SerializeField] private string _text;
    [SerializeField] private BannerType _type;

    public string Text => _text;
    public BannerType Type => _type;

    public BannerOption(string text, BannerType type)
    {
        _text = text;
        _type = type;
    }
}
