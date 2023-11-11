using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;

    public List<ItemList> items = new List<ItemList>();

    // Start is called before the first frame update
    void Start()
    {
        //For testing only - remove it
        HealingItem item = new HealingItem();
        items.Add(new ItemList(item, item.GetName(), 1));
        //
        StartCoroutine(CallItemUpdate());
    }

    // Update is called once per frame
    void Update()
    {    }

    IEnumerator CallItemUpdate()
    {
        foreach(ItemList i in items){
            i.item.Update(this, i.stacks);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }

    public void CallItemOnHit(Enemy enemy){
        foreach(ItemList i in items){
            i.item.OnHit(this, enemy, i.stacks);
        }
    }
}
