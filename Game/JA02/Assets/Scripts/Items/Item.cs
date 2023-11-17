using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item
{
    public Rarity rarity = Rarity.Common;
    public ItemType type;

    public abstract string GetName();
    public virtual void Update(Player player, int stacks)
    {
        
    }

    public virtual void OnHit(Player player, Enemy enemy, int stacks){

    }

    public virtual void OnUse(Player player){

    }

    // Raridade to item para depois user no ItemGenerator
    public enum Rarity
    {
        Common,
        Rare,
        Legendary,
    }

    // Tipo de item
    // Note: Adicionar mais se necessário
    public enum ItemType
    {
        Healing = 0,
        Damage = 1,
        Utility = 2,
    }
    public static int itemTypeLength = Enum.GetNames(typeof(Item.ItemType)).Length;
}

//A lista de items tem de estar atualizada 
public enum Items{
    HealingItem,
    FireDamageItem,
    ActiveItem,
}


public class HealingItem : Item 
{
    public HealingItem() 
    {
        rarity = Rarity.Rare;
        type = ItemType.Healing;
    }

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
    public FireDamageItem()
    {
        rarity = Rarity.Common;
        type = ItemType.Damage;
    }

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
    public ActiveItem()
    {
        rarity = Rarity.Legendary;
        type = ItemType.Utility;
    }

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
