using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : EnemyState
{
    public ShootingState(Enemy enemy , EnemyStateMachine enemyStateMachine): base (enemy , enemyStateMachine)
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
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
}
