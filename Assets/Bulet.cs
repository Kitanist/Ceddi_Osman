using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.CompareTag("Player")){
        //hasar at
    }
    else{
        Destroy(this.gameObject);
    }
   }
}
