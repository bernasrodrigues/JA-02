using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipKeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            player.hasKey = true;
            Destroy(this.gameObject);
        }
    }

}
