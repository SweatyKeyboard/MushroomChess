using UnityEngine;

public abstract class a_BoardObject : a_BoardElement
{
    [SerializeField] private MeshFilter _turnNumber;
    [SerializeField] private SingnsList _digits;

    public void SetDigit(int digit)
    {
        if (_digits.Count <= digit)
            return;

        _turnNumber.mesh = _digits[digit];
    }
}
