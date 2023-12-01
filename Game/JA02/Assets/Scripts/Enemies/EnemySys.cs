using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySys : Sys
{

    public static EnemySys instance;
    public static EnemySys Get() { return instance; }

    [SerializeField]
    private int difficultyLevel;
    
    protected override void OnAwake()
    {
        instance = this;
        //UISys.instance.RestartMenu();
    }

    protected override void Restart()
    {
        difficultyLevel = 1;
        Clear();
        StartSpawners();
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

    public void StartSpawners(){

    }

    public void Clear(){
        foreach (Transform child in transform)
        {
            // Destroy the immediate child GameObject
            Destroy(child.gameObject);
        }
    }

    public void NextLevel(int level){
        difficultyLevel = level;
        Clear();
        StartSpawners();
    }
}

