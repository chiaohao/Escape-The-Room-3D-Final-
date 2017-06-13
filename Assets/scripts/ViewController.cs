using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {
    public GameObject player;
    public GameObject itemMenu;
    public GameObject laptopView;
    public GameObject suitcaseLockView;
    public GameObject safeView;
    public GameObject infoText;
    float lastTime;
    bool isMenuShow;
    bool isMenuEnable;
    bool isLaptopViewShow;
    bool isSuitcaseLockViewShow;
    bool isSafeViewShow;

    void Start () {
        lastTime = Time.time;
        isMenuShow = false;
        isMenuEnable = true;
        isLaptopViewShow = false;
        isSuitcaseLockViewShow = false;
        isSafeViewShow = false;
    }

	void Update () {
        #region Move to Item Menu
        if (Input.GetKey(KeyCode.E) && isMenuEnable && Time.time - lastTime >= 0.5f) {
            if (isMenuShow)
                isMenuShow = false;
            else
                isMenuShow = true;
            setMenu(isMenuShow);
            //record last press time
            lastTime = Time.time;
        }
        #endregion

        if (Input.GetKey(KeyCode.Q) && Time.time - lastTime >= 0.5f) {
            if (isLaptopViewShow)
                setLaptopView(false);
            if (isSuitcaseLockViewShow)
                setSuitcaseLockView(false);
            if (isSafeViewShow)
                setSafeView(false);
            if (isMenuShow) {
                isMenuShow = false;
                setMenu(isMenuShow);
            }
            //record last press time
            lastTime = Time.time;
        }

    }

    void setMenu(bool isMenuShow) {
        //change moving
        player.GetComponent<playerMove>().isMovable = !isMenuShow;
        //change tracing
        transform.GetComponent<cursorCenterClick>().isTrace = !isMenuShow;
        //change itemMenu Visible
        itemMenu.SetActive(isMenuShow);
        //change infoText Visible
        infoText.SetActive(!isMenuShow);
        //change cursor mode
        if (isMenuShow) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void setLaptopView(bool isLVS) {
        isLaptopViewShow = isLVS;
        //change moving
        player.GetComponent<playerMove>().isMovable = !isLVS;
        //change tracing
        transform.GetComponent<cursorCenterClick>().isTrace = !isLVS;
        //change laptopView Visible
        laptopView.SetActive(isLVS);
        //change infoText Visible
        infoText.SetActive(!isLVS);
        //stop itemView Enable
        isMenuEnable = !isLVS;
        //change cursor mode
        if (isLVS) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void setSuitcaseLockView(bool isSLVS) {
        isSuitcaseLockViewShow = isSLVS;
        //change moving
        player.GetComponent<playerMove>().isMovable = !isSLVS;
        //change tracing
        transform.GetComponent<cursorCenterClick>().isTrace = !isSLVS;
        //change laptopView Visible
        suitcaseLockView.SetActive(isSLVS);
        //change infoText Visible
        infoText.SetActive(!isSLVS);
        //stop itemView Enable
        isMenuEnable = !isSLVS;
        //change cursor mode
        if (isSLVS) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void setSafeView(bool isSVS) {
        isSafeViewShow = isSVS;
        //change moving
        player.GetComponent<playerMove>().isMovable = !isSVS;
        //change tracing
        transform.GetComponent<cursorCenterClick>().isTrace = !isSVS;
        //change laptopView Visible
        safeView.SetActive(isSVS);
        //change infoText Visible
        infoText.SetActive(!isSVS);
        //stop itemView Enable
        isMenuEnable = !isSVS;
        //change cursor mode
        if (isSVS)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
    }
}
