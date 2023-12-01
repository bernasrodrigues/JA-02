using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    [Header("Config")]
    public Light[] lights;

    [Header("Run-Time")]
    public bool on;

    public void ConfigProp() {
        lights = GetComponentsInChildren<Light>(true);
        SetLights(false);
    }



    public void UpdateProp() {
        Vector3 posPlayer = PlayerMovement.Instance.transform.position;
        int dist = (int)Vector3.Distance(posPlayer, transform.position);
        // print(squaredDistance);
        if (dist >= 80 + (PlayerMovement.Instance.playerCamera.transform.position.y)) {
            if (on) {
                SetLights(false);
            }
        } else {
            if (!on) {
                SetLights(true);
            }
        }
    }

    void SetLights(bool value) {
        // print(value);
        for (int i = 0; i < lights.Length; i++) {
            lights[i].gameObject.SetActive(value);
        }
        on = value;
    }
}
