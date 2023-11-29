using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
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

    public void Close(){
        UISys.instance.OpenWindow(mainMenu);
    }
}
