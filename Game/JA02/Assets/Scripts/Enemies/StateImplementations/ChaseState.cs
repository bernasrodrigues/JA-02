using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{

    public ChaseState(Enemy enemy , EnemyStateMachine enemyStateMachine): base (enemy , enemyStateMachine)
    {

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

        enemy.navMeshAgent.destination = enemy.playerTarget.transform.position;
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public override void OnCollisionEnter(Collider other)
    {
        base.OnCollisionEnter(other);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
