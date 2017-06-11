using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class puzzleController : MonoBehaviour {

    public GameObject[] doorDiamonds;

    public GameObject bedDrawer;
    int[] cubesColorsNum;

    public GameObject[] wardrobeDoors;
    int[] layersPos;

    public Text computerPassword;
    public GameObject laptop;
    public GameObject screen;
    public Text[] suitcaseNumbers;
    public GameObject suitcaseCover;

	void Start () {
        cubesColorsNum = new int[4] { 0, 0, 0, 0 }; //color def: [red, green, purple, yellow]
        layersPos = new int[3] { 0, 0, 0 }; //layer def: [up, mid, down]
        //to do
    }
	
	void Update () {
        if (isBedCubesComplete())
            bedCubesCompleteAward();
        if (isLayersComplete())
            layersCompleteAward();
        if (isSuitcasePasswordCorrect())
            suitcasePasswordCorrectAward();
    }

    #region puzzle 1 (finished)
    void bedCubesCompleteAward() {
        bedDrawer.transform.localPosition = new Vector3(3.25f, bedDrawer.transform.localPosition.y, bedDrawer.transform.localPosition.z);
    }

    bool isBedCubesComplete() {
        int sum = 0;
        foreach (int i in cubesColorsNum)
            sum += i;
        if (sum == 14)
            if (cubesColorsNum[0] == 4 && cubesColorsNum[2] == 10)
                return true;
        return false;
    }

    public void setBedCube(int n) {
        cubesColorsNum[n] += 1;
    }
    #endregion

    #region puzzle 2 (finished)
    void layersCompleteAward() {
        foreach (GameObject door in wardrobeDoors) {
            door.transform.localPosition = new Vector3(0, 0, 0);
            door.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
            
    }

    bool isLayersComplete() {
        if (layersPos[0] == 1 && layersPos[1] == 2 && layersPos[2] == 3)
            return true;
        return false;
    }

    public void setLayer(int n) {
        layersPos[n] = (layersPos[n] + 1) % 5;
    }
    #endregion

    #region puzzle 3 (finished)
    void suitcasePasswordCorrectAward() {
        suitcaseCover.transform.localPosition = new Vector3(0.01f, -3.13f, -2.53f);
        suitcaseCover.transform.localEulerAngles = new Vector3(90.0f, 0, 90.0f);
    }

    bool isSuitcasePasswordCorrect() {
        if (suitcaseNumbers[0].text == "1" && suitcaseNumbers[1].text == "1" && suitcaseNumbers[2].text == "1" &&
            suitcaseNumbers[3].text == "1" && suitcaseNumbers[4].text == "1" && suitcaseNumbers[5].text == "1")
            return true;
        return false;
    }

    public void setSuitcasePasswordNum(int c) {
        suitcaseNumbers[c].text = ((Int32.Parse(suitcaseNumbers[c].text) + 1) % 10).ToString();
    }

    void computerPasswordCorrectAward() {
        laptop.GetComponent<MeshRenderer>().materials[4].SetColor("_Color", new Color(1, 1, 1));
        for (int i = 0; i < screen.transform.childCount; i++)
            screen.transform.GetChild(i).gameObject.SetActive(false);
        screen.GetComponent<Image>().color = new Color(1, 1, 1);
    }

    public void checkComputerPassword() {
        //to do
        if (computerPassword.text == "0000") {
            computerPasswordCorrectAward();
        }
    }
    #endregion

    #region puzzle 4 (to do)

    #endregion

    #region puzzle end (not finished)
    bool isDoorDiamondsComplete() {
        foreach (GameObject d in doorDiamonds) {
            if (d.activeSelf == false)
                return false;
        }
        return true;
    }

    public void setDoorDiamond(string color) {
        switch (color) {
            case "blue":
                doorDiamonds[0].SetActive(true);
                break;
            case "red":
                doorDiamonds[1].SetActive(true);
                break;
            case "purple":
                doorDiamonds[2].SetActive(true);
                break;
            case "orange":
                doorDiamonds[3].SetActive(true);
                break;
        }
    }
    #endregion
}
