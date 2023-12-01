using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    public static GameSystem Get() { return instance; }

    public RNGesus rng;

    public Sys[] systems;

    public bool inGame;

    public int level;

    public bool InGame { get => inGame; set => this.inGame = value; }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < systems.Length; i++)
                systems[i].StartSys();
    }

    private void Awake() {
        instance = this;
        rng.OnAwake();
        for (int i = 0; i < systems.Length; i++)
            systems[i].AwakeSys();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < systems.Length; i++)
            systems[i].UpdateSys(); 
    }

    private void FixedUpdate() {
        for (int i = 0; i < systems.Length; i++)
            systems[i].FixedUpdateSys();
    }

    public void Quit(){
        Application.Quit();
    }

    public void NextLevel(){
        level++;
        systems[1].GetComponent<UISys>().CloseAll();
        systems[3].GetComponent<MapSys>().NextLevel(level);
        systems[4].GetComponent<EnemySys>().NextLevel(level);
    }

    public void Restart(){
        level = 1;
        foreach(Sys system in systems){
            //print("a");
            system.RestartSys();
        }
        
    }
}