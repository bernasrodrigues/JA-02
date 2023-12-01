using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterInfoController : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsScreen;
    [SerializeField]
    private Image healthFill;
    [SerializeField]
    private TextMeshProUGUI ammoDisplay;
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

    public void UpdateHealth(int healthPercent){
        float rightValue = (healthPercent*3) - 880;
        healthFill.rectTransform.offsetMax = new Vector2(rightValue, healthFill.rectTransform.offsetMax.y);
    }

    public void UpdateBullets(int totalBullets, int currentBullets){
        ammoDisplay.text = currentBullets.ToString() + " / " + totalBullets.ToString();
    }
}
