using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorCenterClick : MonoBehaviour {

    Ray ray;
    float rayLength = 8f;
    RaycastHit hit;
    public Transform playerCam;
    public Text infoText;
    public bool isTrace;
    public bool isBigDoorTraced;
    ViewController viewController;
    puzzleController puzzleController;

    void Start () {
        isTrace = true;
        isBigDoorTraced = false;
        viewController = GameObject.Find("mainController").GetComponent<ViewController>();
        puzzleController = GameObject.Find("mainController").GetComponent<puzzleController>();
    }

	void Update () {
        #region RayClick
        if (isTrace) { 
            ray = new Ray(playerCam.position, playerCam.forward);
            if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.layer == LayerMask.NameToLayer("active object")) {
                if(hit.transform.name == "labtop_whole") {
                    infoText.text = "筆記型電腦";
                }
                else if (hit.transform.name.Split('_')[0] == "lock") {
                    infoText.text = "行李箱鎖";
                }
                else if (hit.transform.name.Split('.')[0] == "Cube") {
                    switch (hit.transform.GetComponent<cubeItem>().cubeColor) {
                        case "blue":
                            infoText.text = "藍積木";
                            break;
                        case "green":
                            infoText.text = "綠積木";
                            break;
                        case "purple":
                            infoText.text = "紫積木";
                            break;
                        case "yellow":
                            infoText.text = "黃積木";
                            break;
                        default:
                            infoText.text = "積木";
                            break;
                    }
                }
                else if (hit.transform.name.Split('_')[0] == "door") {
                    switch (hit.transform.name.Split('_')[1].Split(' ')[0]) {
                        case "blue":
                            infoText.text = "藍寶石";
                            break;
                        case "red":
                            infoText.text = "紅寶石";
                            break;
                        case "purple":
                            infoText.text = "紫寶石";
                            break;
                        case "orange":
                            infoText.text = "橘寶石";
                            break;
                        default:
                            infoText.text = "大門";
                            break;
                    }
                    isBigDoorTraced = true;
                }
                else if (hit.transform.name.Split(' ')[1] == "diamond") {
                    switch (hit.transform.name.Split(' ')[0]) {
                        case "blue":
                            infoText.text = "藍寶石";
                            break;
                        case "red":
                            infoText.text = "紅寶石";
                            break;
                        case "purple":
                            infoText.text = "紫寶石";
                            break;
                        case "orange":
                            infoText.text = "橘寶石";
                            break;
                        default:
                            break;
                    }
                }
                else if (hit.transform.name.Split('0')[0] == "layer") {
                    infoText.text = "抽屜";
                }
                
                //set eachcase
                if (Input.GetMouseButtonDown(0))
                    if(hit.transform.name == "labtop_whole") {
                        viewController.setLaptopView(true);
                    }
                    else if (hit.transform.name.Split('_')[0] == "lock") {
                        viewController.setSuitcaseLockView(true);
                    }
                    else if (hit.transform.name.Split('.')[0] == "Cube") {
                        switch (hit.transform.GetComponent<cubeItem>().cubeColor) {
                            case "blue":
                                puzzleController.setBedCube(0);
                                break;
                            case "green":
                                puzzleController.setBedCube(1);
                                break;
                            case "purple":
                                puzzleController.setBedCube(2);
                                break;
                            case "yellow":
                                puzzleController.setBedCube(3);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (hit.transform.name.Split('0')[0] == "layer") {
                        if(hit.transform.localPosition.z + 0.7f <= 2.1f)
                            hit.transform.Translate(new Vector3(0, 0, 0.7f));
                        else
                            hit.transform.Translate(new Vector3(0, 0, -2.8f));

                        switch (hit.transform.name) {
                            case "layer001":
                                puzzleController.setLayer(0);
                                break;
                            case "layer002":
                                puzzleController.setLayer(1);
                                break;
                            case "layer003":
                                puzzleController.setLayer(2);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (hit.transform.name.Split(' ')[1] == "diamond") {
                        switch (hit.transform.name.Split(' ')[0]) {
                            case "blue":
                                
                                break;
                            case "red":
                                
                                break;
                            case "purple":
                                
                                break;
                            case "orange":
                                
                                break;
                            default:
                                break;
                        }
                    }
                    else if (hit.transform.name.Split('_')[0] == "door") {
                        
                    }
                    else
                        hit.transform.gameObject.SetActive(false);
            }
            else {
                infoText.text = "";
                isBigDoorTraced = false;
            }
        }
        #endregion
    }

}
