using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] private Material _elementMaterial;
    [SerializeField] private Material _backgroundMaterial;
    [SerializeField] private Material _tilesMaterial;

    public Color TileColor { get; set; }

    public void RandomizeColor()
    {
        float hue = Random.Range(0f, 1f);
        _elementMaterial.color = Color.HSVToRGB(hue, 0.5f, 0.8f);
        _backgroundMaterial.color = Color.HSVToRGB((hue + 1f / 3f) % 1f, 0.5f, 1f);

        TileColor = Color.HSVToRGB((hue + 2f / 3f) % 1f, 0.5f, 0.6f);
        _tilesMaterial.color = TileColor;

       
    }
}
