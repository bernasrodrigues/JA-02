using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float baseMaxHP;
    public float baseSpeed;

    public float speed;
    public float maxHP;
    public float hp;

    // Inicializa os valores
    // NOTE: ao dar override chamar base.Start()
    protected virtual void Start()
    {
        maxHP = baseMaxHP;
        hp = maxHP;
        speed = baseSpeed;
    }

    // NOTE: ao dar override chamar base.Update()
    protected virtual void Update()
    {
        // TODO: status effects vão aqui
    }

    // do damage to the character
    // can be overriden to reduce damage or mitigate it
    public virtual void Hit(float damage) 
    {
        hp -= damage;
        if (hp < 0) 
        { 
            hp = 0;
            Die();
        }
    }

    // heal the character
    public virtual void Heal(float heal) 
    {
        hp += heal;
        if (hp > maxHP) { hp = maxHP; }
    }

    // die
    // override to play all the animations and stuff
    public virtual void Die() 
    {
        Debug.Log("dead");
    }
}
