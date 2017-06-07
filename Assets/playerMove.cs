using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    public float translateSpeed;
    public float rotateSpeed;
    Transform playerCam;
    Vector3 transVal;
    public bool isMovable;

    void Start () {
        playerCam = transform.Find("playerCam");
        Cursor.lockState = CursorLockMode.Locked;
        isMovable = true;
    }
	
	void Update () {
        #region WASD Moves and Mouse Rotation
        if (isMovable) {
            transVal = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
                transVal += playerCam.forward * Time.deltaTime;
            if (Input.GetKey(KeyCode.S))
                transVal -= playerCam.forward * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
                transVal -= playerCam.right * Time.deltaTime;
            if (Input.GetKey(KeyCode.D))
                transVal += playerCam.right * Time.deltaTime;
            transVal.y = 0;
            transform.Translate(transVal * translateSpeed, Space.World);

            float rotX = Input.GetAxis("Mouse X");
            if (rotX != 0)
                transform.Rotate(Vector3.up * rotX * rotateSpeed);
            float rotY = Input.GetAxis("Mouse Y");
            if (rotY != 0) {
                if (Mathf.Round(playerCam.rotation.eulerAngles.x) <= 90 && playerCam.rotation.eulerAngles.x + Vector3.left.x * rotY * rotateSpeed > 90)
                    playerCam.rotation = Quaternion.Euler(new Vector3(90, playerCam.rotation.eulerAngles.y, playerCam.rotation.eulerAngles.z));
                else if (Mathf.Round(playerCam.rotation.eulerAngles.x) >= 270 && playerCam.rotation.eulerAngles.x + Vector3.left.x * rotY * rotateSpeed < 270)
                    playerCam.rotation = Quaternion.Euler(new Vector3(270, playerCam.rotation.eulerAngles.y, playerCam.rotation.eulerAngles.z));
                else
                    playerCam.Rotate(Vector3.left * rotY * rotateSpeed);
            }
        }
        #endregion

        
    }
}
