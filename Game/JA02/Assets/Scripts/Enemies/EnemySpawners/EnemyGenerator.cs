using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    private float spawnTimer;
    public float spawnSpeed = 1f;
    public static List<Enemy> enemiesToSpawn;

    private Dictionary<Enemy.Rarity, List<Enemy>> enemiesByRarity = new Dictionary<Enemy.Rarity, List<Enemy>>();

    public Dictionary<Enemy.Rarity, float> rarityChances = new Dictionary<Enemy.Rarity, float>()
    {
        { Enemy.Rarity.Common, 50 },
        { Enemy.Rarity.Rare, 30 },
        { Enemy.Rarity.Legendary, 10 },
    };

    public void Update() {
        if(spawnTimer>0){
            spawnTimer-=Time.deltaTime;
        }
    }

    public void InitDicts() {
        foreach (Enemy enemy in enemiesToSpawn) {
            if (!enemiesByRarity.ContainsKey(enemy.rarity))
            {
                enemiesByRarity.Add(enemy.rarity, new List<Enemy>());
            }

            enemiesByRarity[enemy.rarity].Add(enemy);
        }  
    }

    public Enemy GetRandomEnemiesUsingRarity() 
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


    public Enemy GetRandomEnemyByRarity(Enemy.Rarity rarity)
    {
        return enemiesByRarity[rarity][Random.Range(0, enemiesByRarity[rarity].Count)];
    }
}
