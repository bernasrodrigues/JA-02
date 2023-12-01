using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_i2 : Enemy
{
    //easy enemy
    //easy to hit, slow movement, shoots once at player when in range, slow recharge

    public float attackRange=10f;
    public Weapon enemyWeapon;
    public float shootingInterval=1f;

    public float spawnTimer = 10f;

    override protected void Start() {
        base.Start();
        //no need to start chase state as in update it already changes its state
    }

    protected override void Awake()
    {
        base.Awake();

        shootingState = new ShootingState(this, stateMachine, enemyWeapon, shootingInterval);
    }

    protected override void Update()
    {
        base.Update();

        var targetPosition = PlayerMovement.Instance.transform.position;
        targetPosition.y = transform.position.y;

        transform.LookAt(targetPosition);

        if(UnityEngine.Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < attackRange){
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
