using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    
    public GameObject tj, rc, jb;
    public bool Jumpable = false, dJump = true, tJump=false,tJumpActive=false, rocketingEnabler = false,a,w,d;
    public static float GS = 1f;
    public float GSdisplay,jumpDistance=1f;
    public static float PlayersY;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "jumpable")
        {
            Jumpable = true;
            dJump = true;
          
            if (tJumpActive)
            {
                tJump = true;
            }
        }
        if (collision.tag == "rocket")
        {
            rocket.active = true;
            rocketingEnabler = true;
            StartCoroutine(Rocketing());
        }
        if (collision.tag == "tJump")
        {
            tJumpActive = true;
            tripleJump.active = true;
        }
        if (collision.tag == "jBoost")
        {
            jumpBoost.active = true;
            jumpDistance=1.25f;
        }
        if (collision.tag == "bottom")
        {
            jb.SetActive(true);
            rc.SetActive(true);
            tj.SetActive(true);
            SceneManager.LoadScene("Level1");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "jumpable")
        {
            Jumpable = false;
        }
    }
    void Start()
    {
        GS = 1f;
    }
    public void MoveD()
    {
        d = true;
    }
    public void MoveDEnd()
    {
        d = false;
    }
    public void MoveA()
    {
        a = true;
    }
    public void MoveAEnd()
    {
        a = false;
    }
    public void MoveW()
    {
        w = true;
    }
    public void MoveWEnd()
    {
        w = false;
    }
    void Update()
    {
        if (rocketingEnabler)
        {
            transform.Translate(Vector2.up * Time.deltaTime*4f);
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = GS;
        }
        PlayersY  = transform.position.y;
        GSdisplay = GS;
        GS = GS + Time.deltaTime/20;
        if (Input.GetKey("d") || Input.GetKey("left")|| d)
        {
            transform.Translate(Vector2.right * Time.deltaTime * GS * 1f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.RightArrow)|| a)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.Translate(Vector2.left * Time.deltaTime * GS * 1f);
        }
        if (Input.GetKeyDown("space")|| Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow) || w)
        {
            if (Jumpable) 
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Mathf.Sqrt(9 * GS)*jumpDistance), ForceMode2D.Impulse);
                
            }
            else if (dJump && !rocketingEnabler)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Mathf.Sqrt(9*GS)*jumpDistance), ForceMode2D.Impulse);
               
                dJump = false;
            }
            else if (tJump && !rocketingEnabler)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Mathf.Sqrt(9 * GS)*jumpDistance), ForceMode2D.Impulse);
                tJump = false;
                
            }
        }
    }
    IEnumerator Rocketing()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        GS = GS + 5;
        yield return new WaitForSeconds(3);
        GS = GS - 5;
        rocketingEnabler = false;
        yield return null;
    }
}

