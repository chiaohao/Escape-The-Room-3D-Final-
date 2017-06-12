using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorGoalController : MonoBehaviour {

    public GameObject[] doorDiamonds;

    public void setDiamonds(int n) {
        doorDiamonds[n].SetActive(true);
        if (isAllDiamondsSet())
            finalAward();
    }

    bool isAllDiamondsSet() {
        foreach (GameObject dia in doorDiamonds)
            if (dia.activeSelf == false)
                return false;
        return true;
    }

    void finalAward() {

    }
}
