using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StructureBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject chipBuilding;
    [SerializeField]
    GameObject chipKeyBuilding;
    [SerializeField]
    GameObject newGO;
    [SerializeField]
    private int tileSize;
    [SerializeField]
    private float scenarioBuildingsPercentage;
    [SerializeField]
    private float itemOrConsumableBuildingsPercentage;
    [SerializeField]
    GameObject[] regularScenario;
    [SerializeField]
    GameObject[] scenarioWithItemOrConsumable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Tuple<int,int> chipPosition, Tuple<int,int> chipKeyPosition){
        InitializeChipAndChipKey(chipPosition, chipKeyPosition);
        InitializeScenario();
        InitializeItemsOrConsumables();
    }

    public void InitializeScenario(){
        float numberOfbuildings = scenarioBuildingsPercentage * MapSys.instance.GetAvaliableMapPositions().Length;
        Tuple<int,int>[] scenarioPositions = RNGesus.instance.GetRandomSubset(MapSys.instance.GetAvaliableMapPositions(), (int)numberOfbuildings);
        foreach(Tuple<int,int> sPosition in scenarioPositions){
            if(!(sPosition.Item1==0 && sPosition.Item2==0)){
                InitializeBuilding(regularScenario[RNGesus.instance.GetRandomIntBetween(0, regularScenario.Length-1)], sPosition);
            }
        }
        MapSys.instance.SetScenarioPositions(scenarioPositions);
    }

    public void InitializeItemsOrConsumables(){
        float numberOfbuildings = itemOrConsumableBuildingsPercentage * MapSys.instance.GetAvaliableMapPositions().Length;
        Tuple<int,int>[] itemOrConsumablePositions = RNGesus.instance.GetRandomSubset(MapSys.instance.GetAvaliableMapPositions(), (int)numberOfbuildings);
        foreach(Tuple<int,int> icPosition in itemOrConsumablePositions){
            if(!(icPosition.Item1==0 && icPosition.Item2==0)){
                InitializeBuilding(scenarioWithItemOrConsumable[RNGesus.instance.GetRandomIntBetween(0, scenarioWithItemOrConsumable.Length-1)], icPosition);
            }
        }
    }

    public void InitializeChipAndChipKey(Tuple<int,int> chipPosition, Tuple<int,int> chipKeyPosition){
        InitializeBuilding(chipBuilding, chipPosition);
        InitializeBuilding(chipKeyBuilding, chipKeyPosition);
    } 

    public void InitializeBuilding(GameObject building, Tuple<int,int> position){
        newGO = Instantiate(building, transform);
        newGO.transform.position = new Vector3(position.Item1 * tileSize, 0, position.Item2 * tileSize);
    }
}
