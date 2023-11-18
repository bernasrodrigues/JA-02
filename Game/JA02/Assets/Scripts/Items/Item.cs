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
    public virtual void Update(Character player, int stacks)
    {
        
    }

    public virtual void OnHit(Character player, Character enemy, int stacks){

    }

    public virtual void OnUse(Character player){

    }

    public virtual float OnRecalculateStat(Character player, CharacterStat statModified, float stat, int stacks){
        return stat;
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

    public enum CharacterStat 
    {
        MaxHp,
        Speed,
        Damage,
        AttackSpeed,
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
    public HealingItem() 
    {
        rarity = Rarity.Rare;
        type = ItemType.Healing;
    }

    public override string GetName(){
        return "Healing Item";
    }

    public override void Update(Character character, int stacks)
    {
        character.Heal(5 + (2*stacks));
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

    public override void OnHit(Character player, Character enemy, int stacks)
    {
        enemy.Hit(10 + (8*stacks));
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
    public override void Update(Character player, int stacks)
    {
        itemCd -=1;
    }
    public override void OnUse(Character player)
    {
        if(itemCd <= 0){
            //do something

            //reset cd
            itemCd = 10;
        }
    }
}

// Item that gives 20% speed per stack
public class SpeedItem : Item
{
    public SpeedItem()
    {
        rarity = Rarity.Common;
        type = ItemType.Utility;
    }

    public override string GetName()
    {
        return "Speed Item";
    }

    public override float OnRecalculateStat(Character player, CharacterStat statModified, float stat, int stacks)
    {
        if (statModified != CharacterStat.Speed) { return stat; }

        return stat + 0.20f * stacks * player.baseSpeed;
    }
}

// Item that gives 8% max hp per stack
public class MaxHpItem : Item
{
    public MaxHpItem()
    {
        rarity = Rarity.Common;
        type = ItemType.Healing;
    }

    public override string GetName()
    {
        return "Max Hp Item";
    }

    public override float OnRecalculateStat(Character player, CharacterStat statModified, float stat, int stacks)
    {
        if (statModified != CharacterStat.MaxHp) { return stat; }

        return stat + 0.08f * stacks * player.baseMaxHP;
    }
}
