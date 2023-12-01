using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoCount : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool ammoReserveInfinite;

    void OnEnable()
    {
        Weapon.OnBulletChange += UpdateUI;
    }


    public void UpdateUI(int bulletsLeft, int ammoReserve)
    {
        if (ammoReserveInfinite)
        {
            text.text = bulletsLeft + " / ∞";
        }
        else
        {
            text.text = bulletsLeft + " / " + ammoReserve;
        }
    }
}
