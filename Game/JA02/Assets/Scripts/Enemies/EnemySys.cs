using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySys : Sys
{

    public static EnemySys instance;
    public static EnemySys Get() { return instance; }
    
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
}

