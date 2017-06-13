using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour {

    public GameObject light;

    public void switchLight() {
        if (light.activeSelf)
            light.SetActive(false);
        else
            light.SetActive(true);
    }
}
