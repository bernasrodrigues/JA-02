using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCreditsController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu(){
        UISys.instance.ClickSound();
        UISys.instance.OpenWindow(mainMenu);
    }
}
