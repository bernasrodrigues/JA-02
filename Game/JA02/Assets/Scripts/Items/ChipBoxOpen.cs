using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipBoxOpen : MonoBehaviour
{

    public Animator animator;


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            if (player.hasKey) 
            {
                Invoke("showScreen", 3);
                animator.Play("openbox");
            }

        }
    }



    public void showScreen()
    {
        UISys.instance.OpenWindow(UISys.instance.windows[5]);


    }


}
