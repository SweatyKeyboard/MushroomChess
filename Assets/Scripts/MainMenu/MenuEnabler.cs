using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnabler : MonoBehaviour
{
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
