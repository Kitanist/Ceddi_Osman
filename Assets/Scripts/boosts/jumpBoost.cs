using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBoost : MonoBehaviour
{   

    public static bool active = false;
    
    void Update()
    {
        if (active)
        {
            active = false;
            gameObject.SetActive(false);
        }
    }
}
