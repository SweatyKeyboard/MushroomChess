using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class ActionExecuter
{
    public static IEnumerator Executor(List<a_Action> actions, System.Action afterAction)
    {
        foreach (a_Action action in actions)
        {
            action.AfterAction?.Invoke();
            yield return action.Courutine;
            yield return new WaitForSeconds(CourutineAnimations.AnimDuration / 2);
        }

        afterAction?.Invoke();
        actions.Clear();
    }
}