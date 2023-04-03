using UnityEngine;

public class TutorialLevelManager : MonoBehaviour
{
    public void ShowTutorial(string text)
    {
        GameObject.FindObjectOfType<Banner>().ShowTutorial(text);
    }
}
