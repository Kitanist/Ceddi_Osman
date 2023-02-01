using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossMovement : MonoBehaviour
{
    #region Değişkenler
    public float attackRange = 5f;
    public int attackDamage = 10;
     public float longAttackRange = 10f;
    public int longAttackDamage = 10;
    public GameObject Player;
    public bool resetAttack=false;
    public LayerMask playerLayer;
    public Top [] tops;
    [SerializeField]private float topResetTime=3;
    bool topCanFire=true;
      bool canAttack=false;
   public bool sag = false, ust = false,canJump;
    #endregion
    [System.Obsolete]

    private void Update() {

    if(GameManager.Instance.isGround){
      GameManager.Instance.isGround=false;

            float distance = Vector2.Distance(transform.position, Player.transform.position);

            if (distance < attackRange)
            {
                Debug.Log("Attacking enemy!");
                canAttack = true;
            }
            else {
                canAttack = false;
            }


      if(!canAttack){
        CasePlayer();
      }
      else{
        if(!resetAttack){
        int rnd=Random.RandomRange(0,1);
        resetAttack=true;
        StartCoroutine(resetAtacks());
        if(rnd==0){
           AttackEnemy(attackRange,attackDamage);
                        Debug.Log("abi sana vurdum");
        }
        else{
            AttackEnemy(longAttackRange,longAttackDamage);
                        Debug.Log("abi sana uzun vurdum");
                    }
        }
       
      }
//case
//ısın kılıcı
//klasik klıc
    }
    else{
    
  if(topCanFire){
    FireTop();
  }
    }
 }

 private void OnDrawGizmos() {
    Gizmos.color=Color.red;
    Gizmos.DrawWireSphere(transform.position,3);
    Gizmos.color=Color.blue;
    Gizmos.DrawWireSphere(transform.position, attackRange);

 }
    #region Düşünme
    public void FireTop () {
  
    for(int i = 0; i < tops.Length; i++) {
        tops[i].Fire();
        topCanFire=false;
       
       //boss hareket
        
        StartCoroutine(ResetTop());
    }
 }

    
    IEnumerator ResetTop(){
      
        yield return new WaitForSeconds(topResetTime);
        topCanFire=true;
    }
    public void CasePlayer(){
        
        
        // önce karakter ne tarafta öğren
        float targetX = Player.transform.position.x;
        float objectX = transform.position.x;

        if (targetX > objectX)
        {
            sag = true;
        }
        
        else
        {   sag = false;
            
        }
        // daha onra yukarıda mı öğren
        float targetY = Player.transform.position.y;
        float objectY = transform.position.y;

        if (targetY > objectY)
        {
            ust = true;
        }
        else if (targetY < objectY)
        {
            ust = false;
        }
        else
        {
            Debug.Log("NOLUYO LAN Gökte Ne var");
        }
        // ona göre platformda hareket et
        if (sag)
        {
            if (ust)
            {
                //karakter sağda ve üstte
                if (canJump)
                {
                   GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10));
                    //zıplama arenasında
                }
                transform.position += new Vector3(5*Time.deltaTime, 0, 0);
            }
            else
            {
                //karakter sağda  ama üstte değil
                transform.position += new Vector3(5 * Time.deltaTime, 0, 0);
            }
           

        } else if(ust)
    {
            if (canJump)
            {
               GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10));
                //Zıplama arenasında
            }
            transform.position += new Vector3(-5 * Time.deltaTime, 0, 0);
            // karakter sağda değil ve üstte

        } else
            {
            // karakter solda ve altta
            transform.position += new Vector3(-5 * Time.deltaTime, 0, 0);
        }
    }
    #endregion
    #region saldırı
    void AttackEnemy(float attackRange,int attackDamage)
    {

        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider enemy in hitEnemies)
        {         
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    IEnumerator resetAtacks(){
        yield return new WaitForSeconds(3);
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "canJump")
        {
            canJump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "canJump")
        {
            canJump = false;
        }
    }
}
