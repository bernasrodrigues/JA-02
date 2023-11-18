using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int damage;

    public List<ItemList> items = new List<ItemList>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //For testing only - remove it
        HealingItem item = new HealingItem();
        items.Add(new ItemList(item, item.GetName(), 1));
        //
        StartCoroutine(CallItemUpdate());
    }

    // Update is called once per frame
    protected override void Update()
    {    }

    IEnumerator CallItemUpdate()
    {
        foreach(ItemList i in items){
            i.item.Update(this, i.stacks);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }

    public void CallItemOnHit(Character enemy){
        foreach(ItemList i in items){
            i.item.OnHit(this, enemy, i.stacks);
        }
    }
}
