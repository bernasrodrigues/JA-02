using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // NOTE: adicionar todos os novos items aqui!
    private static List<Item> items = new List<Item>() 
    {
        new FireDamageItem(),
        new HealingItem(),
        new ActiveItem(),
    };
    // items separados por raridade
    private Dictionary<Item.Rarity, List<Item>> itemsByRarity = new Dictionary<Item.Rarity, List<Item>>();
    // items separados por tipo
    private Dictionary<Item.ItemType, List<Item>> itemsByType = new Dictionary<Item.ItemType, List<Item>>();
    // Note: se tivermos itens suficientes podemos separar ainda por raridade e tipo


    // valores para a raridade das chests
    // podemos criar outras variáveis para tipos de chests diferentes,
    // ou até criar uma classe the chest com as raridades
    // ou ainda mandar isto como um dos parametros da função de geração
    public Dictionary<Item.Rarity, float> rarityChances = new Dictionary<Item.Rarity, float>()
    {
        { Item.Rarity.Common, 50 },
        { Item.Rarity.Rare, 30 },
        { Item.Rarity.Legendary, 10 },
    };

    // iniciar os dicionários separando os items nos seus devidos buckets
    private void InitDicts() {
        foreach (Item item in items) {
            if (!itemsByRarity.ContainsKey(item.rarity))
            {
                itemsByRarity.Add(item.rarity, new List<Item>());
            }
            if (!itemsByType.ContainsKey(item.type))
            {
                itemsByType.Add(item.type, new List<Item>());
            }

            itemsByRarity[item.rarity].Add(item);
            itemsByType[item.type].Add(item);
        }  
    }
    
    // Acho q isto podia ser uma classe com métodos estáticos mas não sei como podemos dar sort dos items sem isto
    void Start()
    {
        InitDicts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // retorna um item random, pode retornar 1 item de qualquer raridade ou tipo
    // maybe usar só para teste
    public Item GetRandomItem() 
    {
        return items[Random.Range(0, items.Count)];
    }

    // retorna um item com base nas raridades 
    // pode ser mudada para ser receber as chances em vez de ser uma variável
    public Item GetRandomItemUsingRarity() 
    {
        Item.Rarity rarity = Item.Rarity.Common;
        float rnd = Random.Range(0.0f, 1.0f);

        if (rnd <= rarityChances[Item.Rarity.Legendary] / 100.0f)
        {
            rarity = Item.Rarity.Legendary;
        }
        else if (rnd <= (rarityChances[Item.Rarity.Legendary] + rarityChances[Item.Rarity.Rare]) / 100.0f)
        {
            rarity = Item.Rarity.Rare;
        }

        return itemsByRarity[rarity][Random.Range(0, itemsByRarity[rarity].Count)];
    }

    // retorna um item consoante a raridade colocada
    // bom para por exemplo chest com lendário garantido
    public Item GetRandomItemByRarity(Item.Rarity rarity)
    {
        return itemsByRarity[rarity][Random.Range(0, itemsByRarity[rarity].Count)];
    }

    // retorna um item consoante o tipo colocado
    // bom para chests com tipos especificos
    public Item GetRandomItemByType(Item.ItemType itemType)
    {
        return itemsByType[itemType][Random.Range(0, itemsByType[itemType].Count)];
    }
}
