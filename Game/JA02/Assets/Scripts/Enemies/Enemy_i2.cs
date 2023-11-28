using UnityEngine;
using UnityEngine.AI;

public class Enemy_i2 : Enemy
{
    //easy enemy
    //easy to hit, slow movement, shoots once at player when in range, slow recharge

    protected override void Awake()
    {
        base.Awake();

        shootingState = new ShootingState(this, stateMachine);
    }


    protected override void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        // IF ANIMATION TRIGGERS ARE USED...
    }

}
