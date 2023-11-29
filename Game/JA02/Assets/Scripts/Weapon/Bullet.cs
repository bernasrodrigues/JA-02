using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public Rigidbody rb;
    public Collider col;
    public List<string> tagsToIgnore;       // tags to ignore colisions

    public float timeTillDestroy = 3;


    void Start()
    {
        //Physics.IgnoreCollision(col, SysPlayer.Get().getPlayerObj().GetComponent<Collider>());

        Invoke("DestroyObject", timeTillDestroy);
    }



    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            return;
        }

        /*
         IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();      // Check if the object implements the IDamageable interface
         if (damageable != null)                                                         // if the object is damageable (ie. an enemy)
         {
             damageable.TakeDamage(damage);                                              // deal damage
         }
        */

        // rb.velocity = rb.velocity / 15;
        DestroyObject(1);

    }


    public void DestroyObject(float timeTillDestroy = 0)
    {

        GameObject.Destroy(this.gameObject , timeTillDestroy);
    }




    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}