using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    public float translateSpeed;
    public float rotateSpeed;
    Transform playerCam;
    Vector3 transVal;
    public bool isMovable;
    bool isCameraStand;

    void Start () {
        playerCam = transform.Find("playerCam");
        Cursor.lockState = CursorLockMode.Locked;
        isMovable = true;
        isCameraStand = true;
    }
	
	void Update () {
        #region WASD Moves and Mouse Rotation
        if (isMovable) {
            transVal = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W)) {
                Vector3 f = transform.forward;
                f.y = 0;
                f = Vector3.Normalize(f);
                transVal += f * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S)) {
                Vector3 f = transform.forward;
                f.y = 0;
                f = Vector3.Normalize(f);
                transVal -= f * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A)) {
                Vector3 r = transform.right;
                r.y = 0;
                r = Vector3.Normalize(r);
                transVal -= r * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D)) {
                Vector3 r = transform.right;
                r.y = 0;
                r = Vector3.Normalize(r);
                transVal += r * Time.deltaTime;
            }
            transform.Translate(transVal * translateSpeed, Space.World);

            if (Input.GetKey(KeyCode.LeftShift)) {
                if (isCameraStand) {
                    playerCam.transform.Translate(new Vector3(0, -2f, 0), Space.World);
                    isCameraStand = false;
                }
            }
            else {
                if (!isCameraStand) {
                    playerCam.transform.Translate(new Vector3(0, 2f, 0), Space.World);
                    isCameraStand = true;
                }
            }

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
