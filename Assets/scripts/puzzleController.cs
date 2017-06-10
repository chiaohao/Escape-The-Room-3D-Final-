using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleController : MonoBehaviour {

    public GameObject[] doorDiamonds;

    public GameObject bedDrawer;

    int[] cubesColorsNum;
    int[] layersPos;

	void Start () {
        cubesColorsNum = new int[4] { 0, 0, 0, 0 }; //color def: [blue, green, purple, yellow]
        layersPos = new int[3] { 0, 0, 0 }; //layer def: [up, mid, down]
        //to do
    }
	
	void Update () {
        if (isBedCubesComplete())
            bedCubesCompleteAward();
        if (isLayersComplete())
            layersCompleteAward();
    }

    #region puzzle 1
    void bedCubesCompleteAward() {
        bedDrawer.transform.localPosition = new Vector3(3.25f, bedDrawer.transform.localPosition.y, bedDrawer.transform.localPosition.z);
    }

    bool isBedCubesComplete() {
        //to do
        return false;
    }

    public void setBedCube(int n) {
        cubesColorsNum[n] += 1;
    }
    #endregion

    #region puzzle 2
    void layersCompleteAward() {
        //to do
    }

    bool isLayersComplete() {
        //to do
        return false;
    }

    public void setLayer(int n) {
        layersPos[n] = (layersPos[n] + 1) % 5;
    }
    #endregion

    #region puzzle end
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
