using UnityEngine;
using UnityEngine.AI;

public class Enemy_i1 : Enemy
{
    //easy enemy
    //easy to hit, slow movement, only damages player by chasing him
    public float damage;
    public float idleTime=1f;
    public float startingIdleTime=1f;


    override protected void Start() {
        base.Start();
        stateMachine.Initialize(chaseState);
    }
    protected override void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        // IF ANIMATION TRIGGERS ARE USED...
    }

    protected override void Update()
    {
        base.Update();

        //when enemy hits player he enter an idle state
        if(stateMachine.currentEnemyState == idleState){
            idleTime-=Time.deltaTime;
            //when a specified time passes he resumes the chase
            if(idleTime<0f){
                stateMachine.ChangeState(chaseState);
                idleTime=startingIdleTime;
            }
        }
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
        if(stateMachine.currentEnemyState==chaseState){
            stateMachine.ChangeState(idleState);
        }
    }
}
