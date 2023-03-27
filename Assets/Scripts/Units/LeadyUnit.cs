using System.Collections;
using UnityEngine;

public class LeadyUnit : a_Unit
{
    public IEnumerator Finish()
    {
        if (Position == Board.Instance.FinishPosition)
        {
            FindObjectOfType<FinishMenu>(true).Show();
        }
        yield return null;
    }
}