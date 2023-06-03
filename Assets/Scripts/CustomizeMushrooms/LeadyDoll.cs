using UnityEngine;

public class LeadyDoll : MonoBehaviour
{
    [SerializeField] private GameObject[] _hats;
    private int _selectedHat = 0;

    public void EnableHat(int i)
    {
        _hats[_selectedHat].SetActive(false);
        _hats[i].SetActive(true);
        _selectedHat = i;
    }
}
