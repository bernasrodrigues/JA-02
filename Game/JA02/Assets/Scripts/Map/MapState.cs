using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapState : MonoBehaviour
{
    [SerializeField]
    private int currentLevel;

    [SerializeField]
    private bool initialized;

    [SerializeField]
    private Tuple<int,int>[] mapPositions;

    [SerializeField]
    private Tuple<int,int> chipTile;
    [SerializeField]
    private Tuple<int,int> chipKeyTile;

    // Start is called before the first frame update
    public int CurrentLevel { get => currentLevel; set => this.currentLevel = value; }
    public bool Initialized { get => initialized; set => this.initialized = value; }
    public Tuple<int,int>[] MapPositions { get => mapPositions; set => this.mapPositions = value; }
    public Tuple<int,int> ChipTile { get => chipTile; set => this.chipTile = value; }
    public Tuple<int,int> ChipKeyTile { get => chipKeyTile; set => this.chipKeyTile = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
