using UnityEngine;

public class BoardCell : MonoBehaviour
{
    [SerializeField] private MeshFilter[] _letters;
    [SerializeField] private MeshFilter[] _digits;

    private int _height;
    public int Height
    {
        get => _height;
        set => _height = value;
    }

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

}