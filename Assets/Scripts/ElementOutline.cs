using UnityEngine;

public class ElementOutline : Outline
{
    private int _width = 10;
    private Color _color = Color.white;

    private void Start()
    {
        OutlineWidth = 0;
        OutlineColor = _color;
        OutlineMode = Mode.OutlineAll;
    }

    public void TurnOn()
    {
        OutlineWidth = _width;        
    }

    public void TurnOff()
    {
        OutlineWidth = 0;
    }
}
