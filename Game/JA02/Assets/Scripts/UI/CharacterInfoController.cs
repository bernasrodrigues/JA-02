using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoController : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettings(){
        UISys.instance.ClickSound();
        EnemySys.instance.Freeze();
        PlayerSys.instance.Freeze();
        UISys.instance.OpenWindow(settingsScreen);
    }
}
