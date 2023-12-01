using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    private int screenWidth;
    private int screenHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close(){
        UISys.instance.ExitSound();
        Time.timeScale = 1;
        if(!GameSystem.instance.InGame){
            UISys.instance.OpenWindow(mainMenu);
        }
        else{
            EnemySys.instance.Unfreeze();
            PlayerSys.instance.Unfreeze();
            UISys.instance.CloseAll();
        }
        
    }

    public void ChangeVolume(float value){
        AudioSys.instance.ChangeVolume(value);
    }

    public void SetResolution(int option){
        switch(option){
            case 0:
                screenHeight=1080;
                screenWidth=1920;
                break;

            case 1:
                screenHeight=768;
                screenWidth=1366;
                break;

            case 2:
                screenHeight=1440;
                screenWidth=2560;
                break;

            case 3:
                screenHeight=2160;
                screenWidth=3840;
                break;
        }
        Screen.SetResolution(screenWidth, screenHeight, Screen.fullScreen);
    }
}
