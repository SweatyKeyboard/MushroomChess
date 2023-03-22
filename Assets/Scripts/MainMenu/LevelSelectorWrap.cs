using UnityEngine;

public class LevelSelectorWrap : MonoBehaviour
{
    public void GoToLevel(int levelNumber)
    {
        FindObjectOfType<LevelSelector>().GoToLevel(levelNumber);
    }

    public void GoToLevel()
    {
        FindObjectOfType<LevelSelector>().RestartCurrentLevel();
    }
}
