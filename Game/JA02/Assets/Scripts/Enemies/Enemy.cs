using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    // State Machine
    public EnemyStateMachine stateMachine;
    public ChaseState chaseState;
    public IdleState idleState;
    public ShootingState shootingState;

    //private variables
    public GameObject playerTarget;     // FOR TESTING PURPOUSES IMPLEMENTATION LATER WILL BE DIFERENT
    public NavMeshAgent navMeshAgent;


    protected virtual void Awake()
    {
        stateMachine = new EnemyStateMachine();

        idleState = new IdleState(this , stateMachine);
        chaseState = new ChaseState(this , stateMachine);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(chaseState);
    }
    
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stateMachine.currentEnemyState.UpdateState();
    }


    private void FixedUpdate()
    {
        stateMachine.currentEnemyState.FixedUpdateState();
    }

    protected virtual void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        // IF ANIMATION TRIGGERS ARE USED...
    }

    public enum AnimationTriggerType
    {

    }


}
