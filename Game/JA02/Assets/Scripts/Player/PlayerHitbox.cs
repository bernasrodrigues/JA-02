using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public Player player;
    
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy")
        {
            // FIXME: Change back to enemy maybe
            Character enemy = other.GetComponent<Character>();
            enemy.Hit(player.damage);
            player.CallItemOnHit(enemy);
        }    
    }
}
