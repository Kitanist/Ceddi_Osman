using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class BossMovement : MonoBehaviour
{
    
    public LayerMask playerLayer;
    public Top [] tops;
    [SerializeField]private float topResetTime=3;
    bool topCanFire=true;
      bool canAttack=false;
    public Transform [] path;
 private void Update() {

    if(GameManager.Instance.isGround){
      canAttack=Physics2D.OverlapCircle(transform.position,3,playerLayer);
      if(!canAttack){
        CasePlayer();
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
 }
 public void FireTop () {
  
    for(int i = 0; i < tops.Length; i++) {
        tops[i].Fire();
        topCanFire=false;
       
       int index =Random.RandomRange(0,path.Length);
       float dis=Mathf.Abs(transform.position.x-path[index].position.x);
       if(dis<5)
       transform.DOMoveX(path[index].transform.position.x,1);
       else if(dis<10) 
         transform.DOMoveX(path[index].transform.position.x,2);
         if(dis<15) 
                transform.DOMoveX(path[index].transform.position.x,3);  
                else if(dis>=20)
                   transform.DOMoveX(path[index].transform.position.x,4); 
        
        StartCoroutine(ResetTop());
    }
 }

    
    IEnumerator ResetTop(){
      
        yield return new WaitForSeconds(topResetTime);
        topCanFire=true;
    }
    public void CasePlayer(){
        float dis=Vector2.Distance(GameManager.Instance.player.transform.position,transform.position);
       if(dis<5)
       transform.DOMove(GameManager.Instance.player.transform.position,5);
       else if(dis<10) 
         transform.DOMove(GameManager.Instance.player.transform.position,7);
         if(dis<15) 
                transform.DOMove(GameManager.Instance.player.transform.position,9);  
                else if(dis>=20)
                   transform.DOMove(GameManager.Instance.player.transform.position,11); 
    }
}
