using UnityEngine;
using UnityEngine.UI;

public class TutorialHintPanel : MonoBehaviour
{ 
    [SerializeField] private Image[] _images;
    private TutorialLevel _level;
    private UnitHeadsColors _colors;

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetImages(int turn)
    {
        if (!gameObject.activeSelf)
            return;

        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].sprite = _level.Actions[turn][0][i].Icon;

            Color tempColor = _colors[_level.Actions[turn][0][i].UnitIndex];
            _images[i].color = new Color(tempColor.r, tempColor.g, tempColor.b, 0.5f);
        }
    }

    public void SetData(TutorialLevel data, UnitHeadsColors colors)
    {
        _level = data;
        _colors = colors;
    }
}
