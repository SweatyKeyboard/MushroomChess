using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public void RotateCamY(int angle)
    {
        StartCoroutine(CourutineAnimations.Rotate(gameObject, angle, 0.5f));
    }
}
