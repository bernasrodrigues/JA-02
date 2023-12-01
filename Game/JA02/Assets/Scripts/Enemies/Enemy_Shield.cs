using UnityEngine;
using UnityEngine.AI;

public class Enemy_Shield : Enemy
{
    //easy enemy
    //easy to hit, slow movement, only damages player by chasing him
    public float damage;
    public float idleTime=1f;
    public float startingIdleTime=1f;
    
    override protected void Start() {
        base.Start();
        //dont enter enemy state
    }

}
