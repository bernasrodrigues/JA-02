using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossScreenController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GoToMainMenu(){
        UISys.instance.OpenWindow(mainMenu);
    }

    public void Restart(){
        GameSystem.instance.Restart();
    }
}
