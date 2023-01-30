using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * Player3.GS * 0.6f);
    }
}
