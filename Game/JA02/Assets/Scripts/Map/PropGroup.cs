using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropGroup : MonoBehaviour
{
    Prop[] allProps;

    void Start () {
        allProps = GetComponentsInChildren<Prop>(true);
        for(int i = 0; i < allProps.Length; i++) {
            allProps[i].ConfigProp();
        }
    }

    void Update() {
        for(int i = 0; i < allProps.Length; i++) {
            allProps[i].UpdateProp();
        }
    }
}
