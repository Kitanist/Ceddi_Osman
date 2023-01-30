using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoSingleton<Player>
{
    
    public GameObject tj, rc, jb;
    public Rigidbody2D rb;
    public Animator playerAnimator;
    public TrailRenderer tr;
    public bool Jumpable = false, dJump = true, tJump = false, tJumpActive = false, rocketingEnabler = false, a, w, d, canDash = true,isDashing = false;
    
    public float jumpDistance=1f,Hýz= 5,RocketSpeed,dashingPower = 5,dashingTime =0.2f , dashingCoolDown=2;
    public static float PlayersY;
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);
        playerAnimator.SetBool("Dashh", true);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        rb.velocity = new Vector2(0, 0f);
        playerAnimator.SetBool("Dashh", false);
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }

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
            jumpDistance=1.75f;
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
    
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&canDash)
        {
            StartCoroutine(Dash());
        }
        if (rocketingEnabler)
        {
            transform.Translate(Vector2.up * Time.deltaTime*RocketSpeed);
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        PlayersY  = transform.position.y;
        
       
        if (Input.GetKey("d") || Input.GetKey("left")|| d)
        {
            transform.Translate(Vector2.right * Time.deltaTime *  Hýz);
           transform.localScale = new Vector3(-1f, 2f, 1f);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.RightArrow)|| a)
        {
           transform.localScale = new Vector3(1f, 2f, 1f);
            transform.Translate(Vector2.left * Time.deltaTime * Hýz );
        }
        if (Input.GetKeyDown("space")|| Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow) || w)
        {
            if (Jumpable) 
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Hýz*jumpDistance), ForceMode2D.Impulse);
                
            }
            else if (dJump && !rocketingEnabler)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Mathf.Sqrt(9*Hýz)*jumpDistance), ForceMode2D.Impulse);
               
                dJump = false;
            }
            else if (tJump && !rocketingEnabler)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Mathf.Sqrt(9 * Hýz)*jumpDistance), ForceMode2D.Impulse);
                tJump = false;
                
            }
        }
    }
    IEnumerator Rocketing()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        
        yield return new WaitForSeconds(2);
        
        rocketingEnabler = false;
        yield return null;
    }
}

