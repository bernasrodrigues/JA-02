using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSys : Sys
{

    public static PlayerSys instance;
    public static PlayerSys Get() { return instance; }

    [SerializeField]
    private GameObject camera;

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

    public void GoToGameView(){
        camera.GetComponent<CameraController>().GoToGameView();
    }

    public void GoToMainMenuView(){
        camera.GetComponent<CameraController>().GoToMainMenuView();
    }
}
