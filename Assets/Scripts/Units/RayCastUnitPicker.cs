using UnityEngine;

public class RayCastUnitPicker : MonoBehaviour, IPauseHandler
{
    [SerializeField] private LayerMask _unitsLayerMask;
    [SerializeField] private UnitPanel _unitPanel;
    private bool _isEnabled = true;

    void Update()
    {
        if (!_isEnabled)
            return;
        if (!Input.GetMouseButtonDown(0))
            return;

        CastRay();
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, _unitsLayerMask);

        if (hits.Length == 0)
            return;

        if (!hits[0].collider.TryGetComponent(out a_Unit unit))
            return;

        _unitPanel.SelectByUnit(unit);
    }

    public void OnPause()
    {
        _isEnabled = false;
    }

    public void OnContinue()
    {
        _isEnabled = true;
    }
}
