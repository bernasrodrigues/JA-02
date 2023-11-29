using UnityEngine;
using UnityEngine.AI;

public class Enemy_i2 : Enemy
{
    //easy enemy
    //easy to hit, slow movement, shoots once at player when in range, slow recharge

    public float attackRange=10f;
    public Weapon enemyWeapon;
    public float shootingInterval=1f;

    protected override void Awake()
    {
        base.Awake();

        shootingState = new ShootingState(this, stateMachine, enemyWeapon, shootingInterval);
    }

    protected override void Update()
    {
        base.Update();

        transform.LookAt(Player.instance.transform);

        if(Vector3.Distance(transform.position, Player.instance.GetPosition()) < attackRange){
            stateMachine.ChangeState(shootingState);
        }
        else if(stateMachine.currentEnemyState != chaseState){
            stateMachine.ChangeState(chaseState);
        }
    }
    protected override void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        // IF ANIMATION TRIGGERS ARE USED...
    }

}
