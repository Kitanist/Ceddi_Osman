using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
   public  GameObject player;
   public LayerMask groundLayer;
   public bool isGround;
   private void Update() {
      RaycastHit2D hit;
      isGround=Physics2D.Linecast(player.transform.position,player.transform.position+player.transform.up*-2,groundLayer);
      Debug.Log(isGround);
   }
   private void OnDrawGizmos() {
      Gizmos.color=Color.blue;
      Gizmos.DrawLine(player.transform.position,player.transform.position+player.transform.up*-2);
   }
}
