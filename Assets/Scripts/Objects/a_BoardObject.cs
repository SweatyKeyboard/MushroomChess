using UnityEngine;

public abstract class a_BoardObject : a_BoardElement
{
    [SerializeField] private MeshFilter _turnNumber;
    [SerializeField] private SingnsList _digits;

    [SerializeField] private ParticleSystem _particles;


    public void SetDigit(int digit)
    {
        if (_digits.Count <= digit)
            return;

        _turnNumber.mesh = _digits[digit];
    }
    
    public void Shot()
    {
        _particles.Play();
    }
}
