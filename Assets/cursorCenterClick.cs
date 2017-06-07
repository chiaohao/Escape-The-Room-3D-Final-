using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorCenterClick : MonoBehaviour {

    Ray ray;
    float rayLength = 10f;
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
                else if (hit.transform.name == "lock_body" || hit.transform.name == "lock_number") {
                    infoText.text = "行李箱鎖";
                }
                
                //set eachcase
                if (Input.GetMouseButtonDown(0))
                    if(hit.transform.name == "labtop_whole") {
                        mainController.GetComponent<ViewController>().setLaptopView(true);
                    }
                    else if (hit.transform.name == "lock_body" || hit.transform.name == "lock_number") {
                        mainController.GetComponent<ViewController>().setSuitcaseLockView(true);
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
