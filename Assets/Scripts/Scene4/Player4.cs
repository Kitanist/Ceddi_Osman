using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player4 : MonoBehaviour
{
    public GameObject tj, rc, jb;
    public GameObject walk, jump;
    public bool Jumpable = false, dJump = true, tJump = false, tJumpActive = false,rocketingEnabler=false,a,w,d;
    public static float GS = 2f;
    public float GSdisplay, jumpDistance = 1f;
    public static float PlayersY;
    Rigidbody2D rigid2D;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "jumpable")
        {
            Jumpable = true;
            dJump = true;
            jump.SetActive(false);
            walk.SetActive(true);
            if (tJumpActive)
            {
                tJump = true;
            }
        }
        if (collision.tag == "jBoost")
        {
            jumpBoost.active = true;
            jumpDistance = 1.25f;
        }
        if (collision.tag == "rocket")
        {
            rocket.active = true;
            rocketingEnabler = true;
            StartCoroutine(Rocketing());
        }
        if (collision.tag == "bottom")
        {
            jb.SetActive(true);
            rc.SetActive(true);
            tj.SetActive(true);
            SceneManager.LoadScene("Level4");
        }
        if (collision.tag == "tJump")
        {
            tJumpActive = true;
            tripleJump.active = true;
        }
    }
    void Start()
    {
        GS = 2f;
        rigid2D = GetComponent<Rigidbody2D>();
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
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "jumpable")
        {
            Jumpable = false;
        }
    }
    void Update()
    {
        if (rocketingEnabler)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 4f);
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = GS;
        }
        PlayersY = transform.position.y;
        GSdisplay = GS;
        GS = GS + Time.deltaTime / 15;
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.Translate(Vector2.right * Time.deltaTime * GS * 1f);
        }
        if (Input.GetKey("a")|| Input.GetKey("left"))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.Translate(Vector2.left * Time.deltaTime * GS * 1f);
        }
        if (Input.GetKeyDown("space") || Input.GetKeyDown("w")||Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Jumpable&&!rocketingEnabler)
            {
                rigid2D.velocity = new Vector2(0f, 0f);
                rigid2D.AddForce(new Vector2(0, Mathf.Sqrt(9 * GS) * jumpDistance), ForceMode2D.Impulse);
                jump.SetActive(true);
                walk.SetActive(false);
            }
            else if (dJump&&!rocketingEnabler)
            {
                rigid2D.velocity = new Vector2(0f, 0f);
                rigid2D.AddForce(new Vector2(0, Mathf.Sqrt(9 * GS) * jumpDistance), ForceMode2D.Impulse);
                jump.SetActive(true);
                walk.SetActive(false);
                dJump = false;
            }
            else if (tJump&&!rocketingEnabler)
            {
                rigid2D.velocity = new Vector2(0f, 0f);
                rigid2D.AddForce(new Vector2(0, Mathf.Sqrt(9 * GS) * jumpDistance), ForceMode2D.Impulse);
                jump.SetActive(true);
                walk.SetActive(false);
                tJump = false;
            }
        }
    }
    IEnumerator Rocketing()
    {
        rigid2D.velocity = new Vector2(0f, 0f);
        GS = GS + 5;
        yield return new WaitForSeconds(3);
        GS = GS - 5;
        rocketingEnabler = false;
        yield return null;
    }
}

