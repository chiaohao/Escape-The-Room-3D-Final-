using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeItem : MonoBehaviour {

    public string cubeColor;

	void Start () {
        switch (transform.GetComponent<MeshRenderer>().materials[0].name.Split(' ')[0]) {
            case "red":
                cubeColor = "red";
                break;
            case "green":
                cubeColor = "green";
                break;
            case "purple":
                cubeColor = "purple";
                break;
            case "yellow":
                cubeColor = "yellow";
                break;
            default:
                cubeColor = "";
                break; 
        }
    }

}
