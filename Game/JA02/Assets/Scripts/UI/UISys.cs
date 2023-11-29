using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UISys : Sys
{

    public static UISys instance;
    public static UISys Get() { return instance; }

    [SerializeField]
    private GameObject[] windows;
    [SerializeField]
    private GameObject characterInfo;
    
    protected override void OnAwake()
    {
        instance = this;
        //UISys.instance.RestartMenu();
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

    public void OpenWindow(GameObject windowToOpen){
        CloseAll();
        windowToOpen.SetActive(true);
    }

    public void CloseAll(){
        foreach(GameObject window in windows){
            window.SetActive(false);
        }
    }

    public void StartGame(){
        CloseAll();
        characterInfo.SetActive(true);
    }
}
