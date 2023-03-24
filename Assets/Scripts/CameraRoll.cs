using System.Collections;
using UnityEngine;

public class CameraRoll : MonoBehaviour
{
    [SerializeField] private Transform[] _cameraPositions;
    private int _currentIndex = 0;

    private void Update()
    {
        CheckRoll();
    }

    private void CheckRoll()
    {
        if (StateChanger.Instance.State.GetType() != typeof(StateIdle))
            return;


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {           
            if (++_currentIndex >= _cameraPositions.Length)
            {
                _currentIndex = 0;
            }

            StartCoroutine(MoveCamera(1f));
            StartCoroutine(RotateCamera(1f, -90));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {            
            if (--_currentIndex < 0)
            {
                _currentIndex = _cameraPositions.Length - 1;
            }

            StartCoroutine(MoveCamera(1f));
            StartCoroutine(RotateCamera(1f, 90));
        }
    }

    private IEnumerator MoveCamera(float duration)
    {
        StateChanger.Instance.TryChangeState(new StateAnimating());
        float elapsed = 0;
        Vector3 start = Camera.main.transform.position;
        Vector3 finish = _cameraPositions[_currentIndex].position;
        Vector3 range = finish - start;
        while (elapsed < duration)
        {
            elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
            Camera.main.transform.position = start + range * elapsed / duration;
            yield return null;
        }
        Camera.main.transform.position = finish;
        StateChanger.Instance.TryChangeState(new StateIdle());
    }

    private IEnumerator RotateCamera(float duration, float angle)
    {
        float elapsed = 0;
        Quaternion start = Camera.main.transform.rotation;
        while (elapsed < duration)
        {
            elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
            Camera.main.transform.rotation = Quaternion.Euler(
                start.eulerAngles + new Vector3(0, angle, 0) * elapsed / duration);
            yield return null;
        }
        Camera.main.transform.rotation = _cameraPositions[_currentIndex].rotation;
    }
}
