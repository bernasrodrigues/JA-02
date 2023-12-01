using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player instance;
    public int damage;
    public bool hasKey = false;

    public List<ItemList> items = new List<ItemList>();

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    protected override void Start()
    {
        instance = this;
        items.Clear();
        
        base.Start();

        playerMovement = GetComponent<PlayerMovement>();
        UISys.instance.UpdateHealth((int)(hp / maxHP * 100.0f));
        StartCoroutine(CallItemUpdate());
    }

    // Update is called once per frame
    protected override void Update()
    {    }

    public override void Heal(float heal)
    {
        base.Heal(heal);
        UISys.instance.UpdateHealth((int)(hp / maxHP * 100.0f));
    }

    public override void Hit(float damage)
    {
        base.Hit(damage);
        UISys.instance.UpdateHealth((int)(hp / maxHP * 100.0f));
    }

    public override void Die()
    {
        gameObject.SetActive(false);
        UISys.instance.OpenWindow(UISys.instance.windows[4]);
    }

    public void Restart()
    {
        Start();
    }

    IEnumerator CallItemUpdate()
    {
        foreach(ItemList i in items){
            i.item.Update(this, i.stacks);
        }
        yield return new WaitForSeconds(Item.GLOBAL_UPDATE_TIME);
        StartCoroutine(CallItemUpdate());
    }

    public void CallItemOnHit(Character enemy){
        foreach(ItemList i in items){
            i.item.OnHit(this, enemy, i.stacks);
        }
    }

    // se calhar n�o correr sempre o RecalculateStats se ficar muito pesado muda-se
    public void AddItem(Item item)
    {
        foreach (ItemList i in items)
        {
            if (i.name == item.GetName())
            {
                i.stacks += 1;
                RecalculateStats();
                return;
            }
        }
        items.Add(new ItemList(item, item.GetName(), 1));
        RecalculateStats();
    }

    public void RecalculateStats() 
    {
        speed = baseSpeed;
        maxHP = baseMaxHP;
        float scale = 1f;

        foreach (ItemList i in items)
        {
            speed = i.item.OnRecalculateStat(this, Item.CharacterStat.Speed, speed, i.stacks);
            maxHP = i.item.OnRecalculateStat(this, Item.CharacterStat.MaxHp, maxHP, i.stacks);
            scale = i.item.OnRecalculateStat(this, Item.CharacterStat.Scale, scale, i.stacks);
        }
        playerMovement.speed = speed;
        transform.localScale = new Vector3(scale,scale, scale);
        UISys.instance.UpdateHealth((int)(hp / maxHP * 100.0f));
        // apply status effects here
    }
}
