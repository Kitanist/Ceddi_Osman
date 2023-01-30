using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
