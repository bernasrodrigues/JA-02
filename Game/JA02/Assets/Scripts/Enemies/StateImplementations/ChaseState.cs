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
        enemy.navMeshAgent.ResetPath();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        enemy.navMeshAgent.destination = PlayerMovement.Instance.transform.position;
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
}
