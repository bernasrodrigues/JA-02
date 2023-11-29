using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player instance;
    public int damage;

    public List<ItemList> items = new List<ItemList>();

    // Start is called before the first frame update
    protected override void Start()
    {
        instance = this;
        
        base.Start();
        //For testing only - remove it
        HealingItem item = new HealingItem();
        AddItem(item);
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

    // se calhar n�o correr sempre o RecalculateStats se ficar muito pesado muda-se
    public void AddItem(Item item)
    {
        foreach (ItemList i in items)
        {
            if (i.name == item.GetName())
            {
                i.stacks += 1;
                RecalculateStats();
                return;
            }
        }
        items.Add(new ItemList(item, item.GetName(), 1));
        RecalculateStats();
    }

    public void RecalculateStats() 
    {
        foreach (ItemList i in items)
        {
            speed = baseSpeed;
            maxHP = baseMaxHP;

            speed = i.item.OnRecalculateStat(this, Item.CharacterStat.Speed, speed, i.stacks);
            maxHP = i.item.OnRecalculateStat(this, Item.CharacterStat.MaxHp, maxHP, i.stacks);
        }
        // apply status effects here
    }
}
