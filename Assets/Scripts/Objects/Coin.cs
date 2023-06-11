using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnCollected()
    {
        FindObjectOfType<LevelSelector>().CollectCoin();
        Destroy(gameObject);
    }
}
