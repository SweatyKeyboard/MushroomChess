using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] private Material[] _objectMaterials;
    [SerializeField] private Material[] _backgroundMaterials;
    [SerializeField] private Material[] _fieldMaterials;

    public Color TileColor { get; set; }

    public void SetBackgroundColor(Color color)
    {
        foreach (Material material in _backgroundMaterials)
            material.SetColor("_Tint", color);
    }

    public void SetObjectsColor(Color color)
    {
        foreach (Material material in _objectMaterials)
            material.color = color;
    }

    public void SetFieldColor(Color color)
    {
        TileColor = color;

        foreach (Material material in _fieldMaterials)
            material.color = color;
    }
}
