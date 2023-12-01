using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipBoxOpen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            if (player.hasKey) 
            {
                UISys.instance.OpenWindow(UISys.instance.windows[5]);
            }
            Destroy(this.gameObject);
        }
    }

}
