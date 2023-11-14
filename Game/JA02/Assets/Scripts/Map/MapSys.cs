using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapSys : Sys
{

    public static MapSys instance;
    public static MapSys Get() { return instance; }

    [SerializeField]
    private MapGenerator mapGenerator;
    [SerializeField]
    private MapState mapState;
    [SerializeField]
    private StructureBuilder structureBuilder;
    
    protected override void OnAwake()
    {
        instance = this;
        mapGenerator.OnAwake();
        InitializeMap();
    }

    protected override void Restart()
    {
        //throw new System.NotImplementedException();
    }

    protected override void OnFixedUpdate()
    {
        //throw new System.NotImplementedException();
    }

    protected override void OnStart()
    {
        //throw new System.NotImplementedException();
    }

    protected override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public void InitializeMap(){
        mapGenerator.Initialize(mapState.CurrentLevel);
        mapState.Initialized = true;
        mapState.MapPositions = mapGenerator.MapPositions;
        print(mapState.ChipTile.Item1);
        structureBuilder.Initialize(mapState.ChipTile, mapState.ChipKeyTile);
    }

    public void SetChipKeySpot(Tuple<int,int> spot){
        mapState.ChipKeyTile = spot;
    }

    public void SetChipSpot(Tuple<int,int> spot){
        mapState.ChipTile = spot;
        
    }

    public void SetMap(Tuple<int,int>[] mapPositionsArray){
        mapState.MapPositions = mapPositionsArray; 
    }
}
