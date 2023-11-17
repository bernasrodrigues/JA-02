using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public int damage;
    public float speed;



    // State Machine
    public EnemyStateMachine stateMachine;
    public ChaseState chaseState;
    public IdleState idleState;


    //private variables
    public GameObject playerTarget;     // FOR TESTING PURPOUSES IMPLEMENTATION LATER WILL BE DIFERENT
    public NavMeshAgent navMeshAgent;




    private void Awake()
    {
        stateMachine = new EnemyStateMachine();

        idleState = new IdleState(this , stateMachine);
        chaseState = new ChaseState(this , stateMachine);
    }




    // Start is called before the first frame update
    void Start()
    {

        stateMachine.Initialize(chaseState);
    }

    // Update is called once per frame
    void Update()
    {

        stateMachine.currentEnemyState.UpdateState();
    }



    private void FixedUpdate()
    {
        stateMachine.currentEnemyState.FixedUpdateState();
    }




    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        // IF ANIMATION TRIGGERS ARE USED...
    }



    public enum AnimationTriggerType
    {

    }






}
