using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _defaultRotation;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(
            0,
            _defaultRotation - (Input.mousePosition.x / Screen.width) * _maxAngle,
            0);
    }
}
