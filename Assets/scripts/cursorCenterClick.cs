using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorCenterClick : MonoBehaviour {

    Ray ray;
    float rayLength = 15f;
    RaycastHit hit;
    public Transform playerCam;
    public Text infoText;
    public bool isTrace;
    GameObject mainController;

    void Start () {
        isTrace = true;
        mainController = GameObject.Find("mainController");
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
                else if (hit.transform.name.Split('0')[0] == "layer") {
                    infoText.text = "抽屜";
                }
                
                //set eachcase
                if (Input.GetMouseButtonDown(0))
                    if(hit.transform.name == "labtop_whole") {
                        mainController.GetComponent<ViewController>().setLaptopView(true);
                    }
                    else if (hit.transform.name.Split('_')[0] == "lock") {
                        mainController.GetComponent<ViewController>().setSuitcaseLockView(true);
                    }
                    else if (hit.transform.name.Split('.')[0] == "Cube") {
                        switch (hit.transform.GetComponent<cubeItem>().cubeColor) {
                            case "blue":
                                break;
                            case "green":
                                break;
                            case "purple":
                                break;
                            case "yellow":
                                break;
                            default:
                                break;
                        }
                    }
                    else if (hit.transform.name.Split('0')[0] == "layer") {

                    }
                    else
                        hit.transform.gameObject.SetActive(false);
            }
            else
                infoText.text = "";
        }
        #endregion
    }

}
