using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Sys : MonoBehaviour
{
    public bool can_pause;

    abstract protected void OnAwake();
    abstract protected void OnStart();
    abstract protected void OnUpdate();
    abstract protected void OnFixedUpdate();
    abstract protected void Restart();

    public void RestartSys() {
        Restart();
    }

    public void AwakeSys() {
        OnAwake();
    }

    public void StartSys() {
        OnStart();
    }

    public void UpdateSys() {
        if (can_pause == false)
            OnUpdate();
    }

    public void FixedUpdateSys()
    {
        if (can_pause == false)
            OnFixedUpdate();
    }
}
