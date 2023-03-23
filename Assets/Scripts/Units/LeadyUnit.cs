using System.Collections;
using UnityEngine;

public class LeadyUnit : a_Unit
{
    public IEnumerator Finish()
    {
        Debug.Log(Position.X + " " + Position.Y);
        Debug.Log(Board.Instance.FinishPosition.X + " " + Board.Instance.FinishPosition.Y);
        if (Position == Board.Instance.FinishPosition)
        {
            Debug.Log("Finished");
            FindObjectOfType<FinishMenu>(true).Show();
        }
        yield return null;
    }
}