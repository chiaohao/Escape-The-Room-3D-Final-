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
	
	// Update is called once per frame
	void Update () {
        #region RayClick

        ray = new Ray(playerCam.position, playerCam.forward);
        if (Physics.Raycast(ray, out hit, rayLength)) {
            hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
            infoText.text = hit.transform.name;
            //set eachcase
            if (Input.GetMouseButtonDown(0))
                hit.transform.gameObject.SetActive(false);
        }
        else
            infoText.text = "";
        #endregion
    }
}
