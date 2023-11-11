using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public Player player;
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy"){
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.health -= player.damage;
            player.CallItemOnHit(enemy);
        }    
    }
}
