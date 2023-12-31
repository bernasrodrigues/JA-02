using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject creditsScreen;
    [SerializeField]
    private GameObject settingsScreen;

    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame(){
        UISys.instance.ClickSound();
        UISys.instance.StartGame();  
    }

    public void OpenSettings(){
        UISys.instance.ClickSound();
        UISys.instance.OpenWindow(settingsScreen);
    }

    public void OpenCredits(){
        UISys.instance.ClickSound();
        UISys.instance.OpenWindow(creditsScreen);
    }

    public void QuitGame(){
        UISys.instance.ExitSound();
        Application.Quit(); 
    }
}
