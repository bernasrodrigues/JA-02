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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Tuple<int,int> chipPosition, Tuple<int,int> chipKeyPosition){
        InitializeBuilding(chipBuilding, chipPosition);
        InitializeBuilding(chipKeyBuilding, chipKeyPosition);
    } 

    public void InitializeBuilding(GameObject building, Tuple<int,int> position){
        newGO = Instantiate(building, transform);
        newGO.transform.position = new Vector3(position.Item1 * tileSize, 10, position.Item2 * tileSize);
    }
}
