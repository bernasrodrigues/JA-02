using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class MapState : MonoBehaviour
{
    [SerializeField]
    private int currentLevel;

    [SerializeField]
    private bool initialized;

    [SerializeField]
    private Tuple<int,int>[] mapPositions;

    [SerializeField]
    private Tuple<int,int>[] scenarioPositions;

    [SerializeField]
    private Tuple<int,int> chipTile;
    [SerializeField]
    private Tuple<int,int> chipKeyTile;

    // Start is called before the first frame update
    public int CurrentLevel { get => currentLevel; set => this.currentLevel = value; }
    public bool Initialized { get => initialized; set => this.initialized = value; }
    public Tuple<int,int>[] MapPositions { get => mapPositions; set => this.mapPositions = value; }
    public Tuple<int,int>[] ScenarioPositions { get => scenarioPositions; set => this.scenarioPositions = value; }
    public Tuple<int,int> ChipTile { get => chipTile; set => this.chipTile = value; }
    public Tuple<int,int> ChipKeyTile { get => chipKeyTile; set => this.chipKeyTile = value; }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Tuple<int,int>[] GetAvaliableMapPositions(){
        Tuple<int,int>[] avaliablePositions = mapPositions.Where(e => e != chipTile).ToArray();
        avaliablePositions = avaliablePositions.Where(e => e != chipKeyTile).ToArray();
        if(scenarioPositions != null){
            avaliablePositions = avaliablePositions.Except(scenarioPositions).ToArray();
            print(scenarioPositions.Length);
        }
        return avaliablePositions;
    }
}
