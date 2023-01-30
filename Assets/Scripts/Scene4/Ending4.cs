using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 15)
        {
            transform.Translate(Vector2.down * Time.deltaTime * Player4.GS * 0.6f);
        }
        else
        {
            //win
            SceneManager.LoadScene("End");
        }
        if (Player4.PlayersY > transform.position.y)
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }
}
