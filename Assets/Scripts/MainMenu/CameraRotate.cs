using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public void RotateCamY(int angle)
    {
        StartCoroutine(CourutineAnimations.Rotate(gameObject, angle, 0.5f));
    }

    public void MoveCamX(int distance)
    {
        StartCoroutine(CourutineAnimations.Move(
            gameObject,
            transform.position + new Vector3(distance, 0, 0),
            0.5f));
    }
}
