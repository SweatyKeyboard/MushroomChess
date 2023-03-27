using UnityEngine;

[System.Serializable]
public class BoardColors
{
    [ColorUsage(false)][SerializeField] private Color _background;
    [ColorUsage(false)][SerializeField] private Color _objects;
    [ColorUsage(false)][SerializeField] private Color _field;

    public Color Background => _background;
    public Color Objects => _objects;
    public Color Field => _field;
}