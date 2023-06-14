using UnityEngine;

public class MenuScaler : MonoBehaviour
{
    [SerializeField] private RectTransform[] _menues;
    [SerializeField] private int _mainMenuIndex;

    private float _width;
    private float _widthGlobal;

    private void Awake()
    {
        _width = _menues[_mainMenuIndex].rect.size.x;
        _widthGlobal = _width * transform.localScale.x;

        for (int i = 0; i < _menues.Length; i++)
        {
            _menues[i].localPosition = new Vector3(
                _menues[_mainMenuIndex].localPosition.x + _width * (i - _mainMenuIndex),
                _menues[_mainMenuIndex].localPosition.y,
                _menues[_mainMenuIndex].localPosition.z);
        }
    }

    public void MoveRight()
    {
        foreach (RectTransform menu in _menues)
        {
            StartCoroutine(CourutineAnimations.Move(
            menu.gameObject,
            menu.position + new Vector3(_widthGlobal, 0, 0),
            0.5f));
        }
    }

    public void MoveLeft()
    {
        foreach (RectTransform menu in _menues)
        {
            StartCoroutine(CourutineAnimations.Move(
            menu.gameObject,
            menu.position + new Vector3(-_widthGlobal, 0, 0),
            0.5f));
        }
    }
}
