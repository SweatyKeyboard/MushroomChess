using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class ColliderSizeSetter : MonoBehaviour
{
    private BoxCollider _boxCollider;
    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.size = new Vector3(
            GetComponent<RectTransform>().rect.size.x,
            GetComponent<RectTransform>().rect.size.y,
            1);
    }
}
