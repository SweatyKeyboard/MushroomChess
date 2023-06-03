using UnityEngine;

public class HatChanger : MonoBehaviour
{
    [SerializeField] private LeadyUnit _leadyPrefab;
    [SerializeField] private LeadyDoll _leadyDoll;

    private void Start()
    {
        _leadyDoll.EnableHat(_leadyPrefab.SelectedHat);
    }

    public void SetCrown()
    {
        _leadyPrefab.EnableHat(0);
        _leadyDoll.EnableHat(0);
    }

    public void SetHat()
    {
        _leadyPrefab.EnableHat(1);
        _leadyDoll.EnableHat(1);
    }

    public void SetCap()
    {
        _leadyPrefab.EnableHat(2);
        _leadyDoll.EnableHat(2);
    }

    public void SetNimbus()
    {
        _leadyPrefab.EnableHat(3);
        _leadyDoll.EnableHat(3);
    }

    public void SetCocked()
    {
        _leadyPrefab.EnableHat(4);
        _leadyDoll.EnableHat(4);
    }
}
