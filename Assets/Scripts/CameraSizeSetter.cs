using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraSizeSetter : MonoBehaviour
{
    private Camera _camera;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
        float x = ((float)Screen.width / Screen.height);
        _camera.orthographicSize = (float)(-1.460674 * x + 5.3456); 
    }
}
