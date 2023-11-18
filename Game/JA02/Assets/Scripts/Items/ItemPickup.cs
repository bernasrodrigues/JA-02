using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        //item que o player quer pickar
        item = ItemAndConsumableSys.instance.itemGenerator.GetRandomItemUsingRarity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            player.AddItem(item);
            Destroy(this.gameObject);
        }
    }

}
