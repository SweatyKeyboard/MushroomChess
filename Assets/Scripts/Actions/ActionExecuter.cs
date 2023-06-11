using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class ActionExecuter
{
    public static a_Action LastAction { get; private set; }
    public static a_Action NextAction { get; private set; }
    public static IEnumerator Executor(List<a_Action> actions, System.Action afterAction)
    {

        for (int i = 0; i < actions.Count; i++)
        {
            SetLastAction(i, actions);
            SetNextAction(i, actions);

            actions[i].AfterAction?.Invoke();
            yield return actions[i].Courutine;
            yield return new WaitForSeconds(CourutineAnimations.AnimDuration / 2);
        }

        afterAction?.Invoke();
        actions.Clear();
    }

    private static void SetLastAction(int currentActionIndex, List<a_Action> actions)
    {
        if (currentActionIndex == 0)
        {
            LastAction = new NothingAction(actions[currentActionIndex].Target);
        }
        else
        {
            int j = 1;
            while (currentActionIndex - j > 0 && actions[currentActionIndex - j].GetType() == typeof(MimicAction))
            {
                j++;
            }

            LastAction = actions[currentActionIndex - j].GetType() == typeof(MimicAction) ?
                new NothingAction(actions[currentActionIndex].Target) :
                actions[currentActionIndex - j];
        }
    }

    private static void SetNextAction(int currentActionIndex, List<a_Action> actions)
    {
        if (currentActionIndex == actions.Count - 1)
        {
            NextAction = new NothingAction(actions[currentActionIndex].Target);
        }
        else
        {
            int j = 1;
            while (currentActionIndex + j < actions.Count - 1 && actions[currentActionIndex + j].GetType() == typeof(MimicAction))
            {
                j++;
            }

            NextAction = actions[currentActionIndex + j].GetType() == typeof(MimicAction) ?
                new NothingAction(actions[currentActionIndex].Target) :
                actions[currentActionIndex + j];
        }
    }
}