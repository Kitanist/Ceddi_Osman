using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending3 : MonoBehaviour
{
    public GameObject tj, rc, jb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Level4");
        }
        if (transform.position.y > 15)
        {
            transform.Translate(Vector2.down * Time.deltaTime * Player3.GS * 0.6f);
        }
        else
        {
            jb.SetActive(true);
            rc.SetActive(true);
            tj.SetActive(true);
            //win
            SceneManager.LoadScene("Level4");
        }
        if (Player3.PlayersY > transform.position.y)
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }
}
