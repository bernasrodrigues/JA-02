using UnityEngine;
using UnityEngine.AI;

public class Enemy_i1 : Enemy
{
    //easy enemy
    //easy to hit, slow movement, only damages player by chasing him
    public float damage;
    protected override void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        // IF ANIMATION TRIGGERS ARE USED...
    }

    public virtual void OnHitPlayer(){
        Debug.Log("player hit");
        Player.instance.Hit(damage);
    }

    public void OnTriggerEnter(Collider other)
    {
        //used to know when the player gets in range
        if(other.tag=="Player"){
            OnHitPlayer();
        }
        //add knockback effect
    }

}
