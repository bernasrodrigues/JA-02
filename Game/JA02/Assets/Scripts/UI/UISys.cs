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
    [SerializeField]
    private GameObject startingScene;

    [SerializeField]
    private AudioClip[] clickAudios;

    [SerializeField]
    private AudioClip exitAudio;
    
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
        if(windowToOpen == windows[0]){
            PlayerSys.instance.GoToMainMenuView();
            Data.gameState = Data.GameState.MainMenu;
            GameSystem.instance.InGame = false;
            characterInfo.SetActive(false);
        }
        CloseAll();
        windowToOpen.SetActive(true);
    }

    public void CloseAll(){
        foreach(GameObject window in windows){
            window.SetActive(false);
        }
    }

    public void StartGame(){
        GameSystem.instance.InGame = true;
        Data.gameState = Data.GameState.InGame;
        CloseAll();
        characterInfo.SetActive(true);
        PlayerSys.instance.GoToGameView();
    }

    public void ClickSound(){
        AudioSys.instance.RandomizePlay(RNGesus.instance.PickOne(clickAudios), 0.2f);
    }

    public void ExitSound(){
        AudioSys.instance.Play(exitAudio, 0.2f);
    }

    public void UpdateHealth(int healthPercent){
        characterInfo.UpdateHealth(healthPercent);
    }

    public void UpdateBullets(int totalBullets, int currentBullets){
        characterInfo.UpdateBullets(totalBullets, currentBullets);
    }
}
