using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class puzzleController : MonoBehaviour {

    audioController audioController;

    public GameObject[] doorDiamonds;
    public GameObject fadePanel;
    public GameObject blackMaskPanel;

    public GameObject bedDrawer;
    int[] cubesColorsNum;

    public GameObject[] wardrobeDoors;
    public SpriteRenderer painting2;
    int[] layersPos;

    public Text computerPassword;
    public GameObject laptop;
    public GameObject screen;
    public GameObject poem;
    public Text[] suitcaseNumbers;
    public GameObject suitcaseCover;

    public GameObject painting4;
    public GameObject safeDoor;
    string safePasswordInput;

	void Start () {
        cubesColorsNum = new int[4] { 0, 0, 0, 0 }; //color def: [red, green, purple, yellow]
        layersPos = new int[3] { 0, 0, 0 }; //layer def: [up, mid, down]
        safePasswordInput = "";
        audioController = GameObject.Find("audioController").GetComponent<audioController>();
    }

    #region puzzle 1 (finished)
    void bedCubesCompleteAward() {
        bedDrawer.transform.localPosition = new Vector3(3.25f, bedDrawer.transform.localPosition.y, bedDrawer.transform.localPosition.z);
    }

    bool isBedCubesComplete() {
        int sum = 0;
        foreach (int i in cubesColorsNum)
            sum += i;
        if (sum == 14) { 
            if (cubesColorsNum[0] == 4 && cubesColorsNum[2] == 10) {
                audioController.playAudio("drawerOpen");
                return true;
            }
            else {
                cubesColorsNum = new int[4] { 0, 0, 0, 0 };
                audioController.playAudio("wrongAnswer");
            }
        }
        return false;
    }

    public void setBedCube(int n) {
        cubesColorsNum[n] += 1;
        if (isBedCubesComplete())
            bedCubesCompleteAward();
    }
    #endregion

    #region puzzle 2 (finished)
    void layersCompleteAward() {
        foreach (GameObject door in wardrobeDoors) {
            door.layer = LayerMask.NameToLayer("nonactive object");
            door.transform.localPosition = new Vector3(0, 0, 0);
            door.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        painting2.sprite = Resources.Load<Sprite>("sprites/paintings/painting2-2");
    }

    bool isLayersComplete() {
        if (layersPos[0] == 4 && layersPos[1] == 2 && layersPos[2] == 3) {
            audioController.playAudio("wardrobeDoorOpen");
            return true;
        }
        return false;
    }

    public void setLayer(int n) {
        audioController.playAudio("layerChop");
        layersPos[n] = (layersPos[n] + 1) % 5;
        if (isLayersComplete())
            layersCompleteAward();
    }
    #endregion

    #region puzzle 3 (finished)
    void suitcasePasswordCorrectAward() {
        suitcaseCover.transform.localPosition = new Vector3(0.01f, -3.13f, -2.53f);
        suitcaseCover.transform.localEulerAngles = new Vector3(90.0f, 0, 90.0f);
    }

    bool isSuitcasePasswordCorrect() {
        if (suitcaseNumbers[0].text == "4" && suitcaseNumbers[1].text == "5" && suitcaseNumbers[2].text == "0" &&
            suitcaseNumbers[3].text == "6" && suitcaseNumbers[4].text == "1" && suitcaseNumbers[5].text == "1") {
            audioController.playAudio("lockOpen");
            return true;
        }
        return false;
    }

    public void setSuitcasePasswordNum(int c) {
        suitcaseNumbers[c].text = ((Int32.Parse(suitcaseNumbers[c].text) + 1) % 10).ToString();
        if (isSuitcasePasswordCorrect())
            suitcasePasswordCorrectAward();
    }

    IEnumerator computerPasswordCorrectAward() {
        for (int i = 0; i < screen.transform.childCount; i++)
            screen.transform.GetChild(i).gameObject.SetActive(false);
        poem.SetActive(true);
        yield return new WaitForSeconds(5);
        audioController.playAudio("screenBreak");
        laptop.GetComponent<MeshRenderer>().materials[4].SetColor("_Color", new Color(1, 1, 1));
        screen.GetComponent<Image>().color = new Color(1, 1, 1);
    }

    public void checkComputerPassword() {
        //to do
        if (computerPassword.text == "bloodyrose") {
            StartCoroutine(computerPasswordCorrectAward());
        }
        else
            audioController.playAudio("wrongAnswer");
    }
    #endregion

    #region puzzle 4 (finished)

    void safePasswordCorrectAward() {
        audioController.playAudio("safeOpen");
        safeDoor.transform.localEulerAngles = new Vector3(0, 0, 0);
        safeDoor.transform.localPosition = new Vector3(-0.66f, 0.9169195f, -0.143f);
    }

    bool isSafePasswordCorrect() {
        if (safePasswordInput == "8811")
            return true;
        return false;
    }

    public void setSafePassword(string i) {
        audioController.playAudio("lockOpen");
        if (safePasswordInput.Length == 4)
            safePasswordInput = safePasswordInput.Substring(1, 3);
        safePasswordInput += i;
        if (isSafePasswordCorrect()) {
            safePasswordCorrectAward();
        }
    }

    public void setPainting4(bool isLightOn) {
        if (isLightOn)
            painting4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/paintings/painting4-1");
        else
            painting4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/paintings/painting4-2");
    }
    #endregion

    #region puzzle end (finished)
    void doorDiamondsCompleteAward() {
        Cursor.lockState = CursorLockMode.Locked;
        fadePanel.GetComponent<fadePanel>().outPanel = null;
        fadePanel.GetComponent<fadePanel>().inPanel = blackMaskPanel;
        fadePanel.GetComponent<fadePanel>().changeSceneName = "scenes/ending";
        fadePanel.SetActive(true);
    }

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
        Debug.Log(isDoorDiamondsComplete());
        if (isDoorDiamondsComplete())
            doorDiamondsCompleteAward();
    }
    #endregion
}
