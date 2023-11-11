using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item
{
    public abstract string GetName();
    public virtual void Update(Player player, int stacks)
    {
        
    }

    public virtual void OnHit(Player player, Enemy enemy, int stacks){

    }

    public virtual void OnUse(Player player){

    }
}

//A lista de items tem de estar atualizada 
public enum Items{
    HealingItem,
    FireDamageItem,
    ActiveItem,
}


public class HealingItem : Item 
{
    public override string GetName(){
        return "Healing Item";
    }

    public override void Update(Player player, int stacks)
    {
        player.health += 5 + (2*stacks);
    }
}

public class FireDamageItem : Item
{
    public override string GetName()
    {
        return "Fire Weapon";
    }

    public override void OnHit(Player player, Enemy enemy, int stacks)
    {
        enemy.health -= 10 + (8*stacks);
    }
}

public class ActiveItem : Item
{
    float itemCd = 1;
    public override string GetName()
    {
        return "Active Item";
    }
    public override void Update(Player player, int stacks)
    {
        itemCd -=1;
    }
    public override void OnUse(Player player)
    {
        if(itemCd <= 0){
            //do something

            //reset cd
            itemCd = 10;
        }
    }
}
