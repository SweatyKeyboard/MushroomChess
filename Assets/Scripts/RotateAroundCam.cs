using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCam : MonoBehaviour, IPauseHandler
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _distance;

    private bool _isEnabled = true;

    public void OnContinue()
    {
        _isEnabled = true;
    }

    public void OnPause()
    {
        _isEnabled = false;
    }

    private void OnMouseDrag()
    {
        if (!_isEnabled)
            return;

        RotateCamera();        
    }


    void RotateCamera()
    {
        _camera.transform.RotateAround(_target.transform.position,
                                        Vector3.up * _distance,
                                        Input.GetAxis("Mouse X") * _speed);

        if (_camera.transform.position.y < _minY)
        {
            _camera.transform.RotateAround(_target.transform.position,
                                            _camera.transform.right * _distance,
                                            0.1f);
        }
        else if (_camera.transform.position.y > _maxY)
        {
            _camera.transform.RotateAround(_target.transform.position,
                                           _camera.transform.right * _distance,
                                           -0.1f);
        }
        else
        {
            _camera.transform.RotateAround(_target.transform.position,
                                            _camera.transform.right * _distance,
                                            -Input.GetAxis("Mouse Y") * _speed);
        }

    }
}
