using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Boss")){
        //boss take damage
        Debug.Log("bos damage");
    } 
   }
   public void TrapMove () {
    transform.DOMoveY(-4,.5f);
    StartCoroutine(ResetTrap());
    } 

IEnumerator ResetTrap(){

    yield return new WaitForSeconds(2);
    transform.DOMoveY(-5.5f,.5f);

}
private void Update() {
    if(Input.GetKeyDown(KeyCode.Space)){
        TrapMove(); //silincek
    }
}
}
