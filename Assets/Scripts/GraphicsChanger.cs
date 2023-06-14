using UnityEngine;

public class GraphicsChanger : MonoBehaviour
{
    public void SetGraphics(int i)
    {
        QualitySettings.SetQualityLevel(i, true);
    }
}
