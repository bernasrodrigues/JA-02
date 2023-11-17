using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAndConsumableSys : Sys
{

    public static ItemAndConsumableSys instance;
    public static ItemAndConsumableSys Get() { return instance; }

    public ItemGenerator itemGenerator = new ItemGenerator();
    
    protected override void OnAwake()
    {
        instance = this;
        itemGenerator.InitDicts();
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

