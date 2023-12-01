using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : EnemyState
{
    Weapon enemyWeapon;
    float startingWeaponInterval;
    float weaponInterval;

    public ShootingState(Enemy enemy , EnemyStateMachine enemyStateMachine, Weapon enemyWeapon, float weaponInterval=1f): base (enemy , enemyStateMachine)
    {
        this.enemyWeapon=enemyWeapon;
        this.startingWeaponInterval=weaponInterval;
        this.weaponInterval=weaponInterval;
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        weaponInterval-=Time.deltaTime;
        
        if(weaponInterval<0){
            enemyWeapon.EnemyShoot(PlayerMovement.Instance.transform.position - enemy.GetPosition());
            weaponInterval=startingWeaponInterval;
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
}
