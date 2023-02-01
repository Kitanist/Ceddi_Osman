using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;

public class Top : MonoBehaviour
{
   
    bool reset=true;
    public GameObject prefabBullet;
    public Transform bulletPoint;
    public float pushForce=5;
    private void FixedUpdate() {
     
       if(GameManager.Instance.player.transform.position.y>=1 &&reset){      
      
        reset=false;
        Fire();
        StartCoroutine(ResetTop());
       }
       

     

    

  Vector3 Direction = (transform.position - GameManager.Instance.player.transform.position).normalized;
  // açı hesaplama
  
            float angel = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg -180;
            transform.rotation = Quaternion.AngleAxis(angel, Vector3.forward);
       
    }
    public void Fire () {

      
      GameObject bullet=Instantiate(prefabBullet,bulletPoint);

       Vector3 Direction = (transform.position - GameManager.Instance.player.transform.position).normalized;

       
       Vector3 Force = Direction *pushForce;
       

      bullet.GetComponent<Rigidbody2D>().AddForce(-Force,ForceMode2D.Impulse);
    }

     IEnumerator ResetTop(){
      
        yield return new WaitForSeconds(5);
        
        reset=true;
    }
}
