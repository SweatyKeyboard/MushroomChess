using System.Collections;
using UnityEngine;

public class LeadyUnit : a_Unit
{
    [SerializeField] private GameObject[] _hats;
    private int _selectedHat = 0;

    public int SelectedHat => _selectedHat;

    public IEnumerator Finish()
    {
        if (Position == Board.Instance.FinishPosition)
        {
            FindObjectOfType<FinishMenu>(true).Show();
        }
        yield return null;
    }

    public void EnableHat(int i)
    {
        _hats[_selectedHat].SetActive(false);
        _hats[i].SetActive(true);
        _selectedHat = i;
    }
}