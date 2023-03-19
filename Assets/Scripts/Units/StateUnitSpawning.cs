using UnityEngine;
public class StateUnitSpawning : a_State
{
    private SpawnPanel _spawnerPanel;

    public StateUnitSpawning()
    {
        _spawnerPanel = GameObject.FindObjectOfType<SpawnPanel>(true);
    }

    public override a_State[] AllowedStatesToChange => new a_State[]
    {
        new StateUnitPicking()
    };

    public override void OnFinish()
    {
        _spawnerPanel.Hide();
        _spawnerPanel.gameObject.SetActive(false);
    }

    public override void OnStart()
    {
        _spawnerPanel.gameObject.SetActive(true);
        _spawnerPanel.Show();
    }
}

