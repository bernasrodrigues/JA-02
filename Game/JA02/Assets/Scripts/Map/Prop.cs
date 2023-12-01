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
        if (Data.gameState == Data.GameState.MainMenu) {
            UpdateLights(200);
        } else {
            UpdateLights(80);
        }
    }

    void UpdateLights(int range) {
        Vector3 posCamera = PlayerMovement.Instance.playerCamera.transform.position;
        int dist = (int)Vector3.Distance(posCamera, transform.position);
        if (dist >= range + (PlayerMovement.Instance.playerCamera.transform.position.y)) {
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
