using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] private Material _objectMaterial;
    [SerializeField] private Material _backgroundMaterial;
    [SerializeField] private Material _fieldMaterial;

    public Color TileColor { get; set; }

    public void RandomizeColor()
    {
        float hue = Random.Range(0f, 1f);
        _objectMaterial.color = Color.HSVToRGB(hue, 0.5f, 0.8f);
        _backgroundMaterial.color = Color.HSVToRGB((hue + 1f / 3f) % 1f, 0.5f, 1f);

        TileColor = Color.HSVToRGB((hue + 2f / 3f) % 1f, 0.5f, 0.6f);
        _fieldMaterial.color = TileColor;
    }

    public void SetBackgroundColor(Color color)
    {
        _backgroundMaterial.SetColor("_Tint", color);
    }

    public void SetObjectsColor(Color color)
    {
        _objectMaterial.color = color;
    }

    public void SetFieldColor(Color color)
    {
        TileColor = color;
        _fieldMaterial.color = color;
    }
}
