using UnityEngine;

public class BoardCell : MonoBehaviour
{
    [SerializeField] private MeshFilter[] _letters;
    [SerializeField] private MeshFilter[] _digits;
    [SerializeField] private MeshFilter _heightMesh;
    [SerializeField] private SingnsList _heightsDigits;
    [SerializeField] private MeshRenderer _cell;

    private int _height;
    public int Height
    {
        get => _height;
        set
        {
            _height = value;
            _heightMesh.mesh = _heightsDigits[_height];
        }
    }
    public MeshRenderer Cell => _cell;

    public a_BoardElement Element { get; set; }


    public void SetSigns(Mesh i, Mesh j)
    {
        foreach (MeshFilter letter in _letters)
        {            
            letter.mesh = i;
        }
        foreach (MeshFilter digit in _digits)
        {
            digit.mesh = j;
        }
    }

    public void HideSigns(bool north, bool east, bool south, bool west)
    {
        _letters[0].gameObject.SetActive(west);
        _letters[1].gameObject.SetActive(east);
        _digits[0].gameObject.SetActive(north);
        _digits[1].gameObject.SetActive(south);
    }

    public void ShowHeightMap()
    {
        _heightMesh.gameObject.SetActive(true);
    }

    public void HideHeightMap()
    {
        _heightMesh.gameObject.SetActive(false);
    }

}