using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    private float spawnTimer;
    public static float spawnSpeed = 1f;
    public List<GameObject> enemiesToSpawn;
    public bool isActivated = false;

    private Dictionary<Enemy.Rarity, List<GameObject>> enemiesByRarity = new Dictionary<Enemy.Rarity, List<GameObject>>();

    public Dictionary<Enemy.Rarity, float> rarityChances = new Dictionary<Enemy.Rarity, float>()
    {
        { Enemy.Rarity.Common, 50 },
        { Enemy.Rarity.Rare, 35 },
        { Enemy.Rarity.Legendary, 15 },
    };

    private void Start()
    {
        InitDicts();
    }

    public void Update() {
        if (!isActivated) { return; }
        
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else 
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        GameObject gob = Instantiate(GetRandomEnemiesUsingRarity());
        spawnTimer = gob.GetComponent<Enemy>().spawnTimer / spawnSpeed;
    }

    public void InitDicts() {
        foreach (GameObject enemyGoB in enemiesToSpawn) {
            Enemy enemy = enemyGoB.GetComponent<Enemy>();
            if (!enemiesByRarity.ContainsKey(enemy.rarity))
            {
                enemiesByRarity.Add(enemy.rarity, new List<GameObject>());
            }

            enemiesByRarity[enemy.rarity].Add(enemyGoB);
        }  
    }

    public GameObject GetRandomEnemiesUsingRarity() 
    {
        Enemy.Rarity rarity = Enemy.Rarity.Common;
        float rnd = Random.Range(0.0f, 1.0f);

        if (rnd <= rarityChances[Enemy.Rarity.Legendary] / 100.0f)
        {
            rarity = Enemy.Rarity.Legendary;
        }
        else if (rnd <= (rarityChances[Enemy.Rarity.Legendary] + rarityChances[Enemy.Rarity.Rare]) / 100.0f)
        {
            rarity = Enemy.Rarity.Rare;
        }

        return enemiesByRarity[rarity][Random.Range(0, enemiesByRarity[rarity].Count)];
    }


    public GameObject GetRandomEnemyByRarity(Enemy.Rarity rarity)
    {
        return enemiesByRarity[rarity][Random.Range(0, enemiesByRarity[rarity].Count)];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerSpawner")
        {
            isActivated = true;   
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerSpawner")
        {
            isActivated = false;
        }
    }
}
