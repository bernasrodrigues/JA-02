using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public Rigidbody rb;
    public Collider col;
    public List<string> tagsToHit;       // tags to ignore colisions



    void Start()
    {
        GameObject.Destroy(this.gameObject, 3);
    }



    private void OnTriggerEnter(Collider collider)
    {
        if(tagsToHit.Contains(collider.tag)){
            collider.GetComponent<Character>().Hit(damage);
            GameObject.Destroy(this.gameObject);
        }

        if(collider.tag == "Environment"){
            GameObject.Destroy(this.gameObject);
        }
    }


    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}