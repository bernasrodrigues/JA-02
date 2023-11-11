using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public Items itemDrop;
    // Start is called before the first frame update
    void Start()
    {
        //item que o player quer pickar
        item = AssignItem(itemDrop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            AddItem(player);
            Destroy(this.gameObject);
        }
    }

    public void AddItem(Player player){
        foreach(ItemList i in player.items){
            if (i.name == item.GetName()){
                i.stacks+=1;
                return;
            }
        }
        player.items.Add(new ItemList(item, item.GetName(), 1));
    }

    public Item AssignItem(Items itemToAssign){
        switch(itemToAssign){
            case Items.HealingItem:
                return new HealingItem();
            case Items.FireDamageItem:
                return new FireDamageItem();
            case Items.ActiveItem:
                return new ActiveItem();
            default:
                Debug.Log("Item not added to list!!!");
                return new HealingItem();
        }
    }
}
