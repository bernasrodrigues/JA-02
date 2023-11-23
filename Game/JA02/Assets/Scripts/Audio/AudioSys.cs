using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSys : Sys
{

    public static AudioSys instance;
    public static AudioSys Get() { return instance; }

    [SerializeField]
    private AudioManager audioManager;
    
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

    public void Play(AudioClip clip, float volume = 1, float pitch = 1, int priority = 128, int stereoPan = 0, float spatialBlend = 0, float reverbZoneMix = 1){
        audioManager.Play(clip, volume, pitch, priority, stereoPan, spatialBlend, reverbZoneMix);
    }
}
