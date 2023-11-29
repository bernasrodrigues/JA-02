using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    public static GameSystem Get() { return instance; }

    public RNGesus rng;

    public Sys[] systems;

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

    }

    public void Restart(){
        
    }
}