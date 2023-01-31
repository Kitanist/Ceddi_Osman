using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossMovement : MonoBehaviour
{
    
     public float attackRange = 1f;
    public int attackDamage = 10;
     public float longAttackRange = 1f;
    public int longAttackDamage = 10;
       
    public bool resetAttack=false;
    public LayerMask playerLayer;
    public Top [] tops;
    [SerializeField]private float topResetTime=3;
    bool topCanFire=true;
      bool canAttack=false;
   
 private void Update() {

    if(GameManager.Instance.isGround){
      GameManager.Instance.isGround=false;
      canAttack=Physics2D.OverlapCircle(transform.position,3,playerLayer);
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
        }
        else{
            AttackEnemy(longAttackRange,longAttackDamage);
                    
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
      //karakteri takip etme
    }

 
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
    
}
