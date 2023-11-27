using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public Rigidbody rb;
    public Collider col;
    public List<string> tagsToIgnore;       // tags to ignore colisions



    void Start()
    {
        //Physics.IgnoreCollision(col, SysPlayer.Get().getPlayerObj().GetComponent<Collider>());
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
        GameObject.Destroy(this.gameObject, 3);

    }


    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}