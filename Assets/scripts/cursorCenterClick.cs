using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorCenterClick : MonoBehaviour {

    Ray ray;
    float rayLength = 8f;
    RaycastHit hit;
    public Transform playerCam;
    public Transform itemsParent;
    public Transform itemPrefab;
    public Sprite[] itemSprites;
    public Text infoText;
    public bool isTrace;
    public bool isBigDoorTraced;
    ViewController viewController;
    puzzleController puzzleController;
    audioController audioController;
    lightController lightController;

    void Start () {
        isTrace = true;
        isBigDoorTraced = false;
        viewController = GameObject.Find("mainController").GetComponent<ViewController>();
        puzzleController = GameObject.Find("mainController").GetComponent<puzzleController>();
        audioController = GameObject.Find("audioController").GetComponent<audioController>();
        lightController = GameObject.Find("mainController").GetComponent<lightController>();
    }

	void Update () {
        #region RayClick
        if (isTrace) { 
            ray = new Ray(playerCam.position, playerCam.forward);
            if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.layer == LayerMask.NameToLayer("active object")) {
                if(hit.transform.name == "laptop_whole") {
                    infoText.text = "筆記型電腦";
                }
                else if (hit.transform.name.Split('_')[0] == "lock") {
                    infoText.text = "行李箱鎖";
                }
                else if (hit.transform.name.Split('.')[0] == "Cube") {
                    switch (hit.transform.GetComponent<cubeItem>().cubeColor) {
                        case "red":
                            infoText.text = "紅積木";
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
                else if (hit.transform.name.Split('_')[0] == "door") {
                    infoText.text = "大門";
                    isBigDoorTraced = true;
                }
                else if (hit.transform.name.Split(' ')[0] == "diamond") {
                    switch (hit.transform.name.Split(' ')[1]) {
                        case "blue":
                            infoText.text = "藍寶石";
                            break;
                        case "red":
                            infoText.text = "紅寶石";
                            break;
                        case "purple":
                            infoText.text = "紫寶石";
                            break;
                        case "orange":
                            infoText.text = "橘寶石";
                            break;
                        default:
                            break;
                    }
                }
                else if (hit.transform.name.Split('0')[0] == "layer") {
                    infoText.text = "抽屜";
                }
                else if (hit.transform.name == "switch") {
                    infoText.text = "電燈開關";
                }
                else if (hit.transform.name.Split('_')[0] == "safe") {
                    infoText.text = "保險櫃";
                }
                else if (hit.transform.name.Split('_')[0] == "wardrobe") {
                    infoText.text = "衣櫥";
                }
                //set eachcase
                if (Input.GetMouseButtonDown(0))
                    if(hit.transform.name == "laptop_whole") {
                        viewController.setLaptopView(true);
                    }
                    else if (hit.transform.name.Split('_')[0] == "lock") {
                        viewController.setSuitcaseLockView(true);
                    }
                    else if (hit.transform.name.Split('.')[0] == "Cube") {
                        audioController.playAudio("cubePick");
                        switch (hit.transform.GetComponent<cubeItem>().cubeColor) {
                            case "red":
                                puzzleController.setBedCube(0);
                                break;
                            case "green":
                                puzzleController.setBedCube(1);
                                break;
                            case "purple":
                                puzzleController.setBedCube(2);
                                break;
                            case "yellow":
                                puzzleController.setBedCube(3);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (hit.transform.name.Split('0')[0] == "layer") {
                        if(hit.transform.localPosition.z + 0.7f <= 2.1f)
                            hit.transform.Translate(new Vector3(0, 0, 0.7f));
                        else
                            hit.transform.Translate(new Vector3(0, 0, -2.8f));

                        switch (hit.transform.name) {
                            case "layer001":
                                puzzleController.setLayer(0);
                                break;
                            case "layer002":
                                puzzleController.setLayer(1);
                                break;
                            case "layer003":
                                puzzleController.setLayer(2);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (hit.transform.name.Split('_')[0] == "door") {
                        audioController.playAudio("doorLock");
                    }
                    else if (hit.transform.name.Split(' ')[0] == "diamond") {
                        Transform item;
                        switch (hit.transform.name.Split(' ')[1]) {
                            case "blue":
                                hit.transform.gameObject.SetActive(false);
                                item = Instantiate(itemPrefab, itemsParent);
                                item.GetComponent<Image>().sprite = itemSprites[0];
                                break;
                            case "red":
                                hit.transform.gameObject.SetActive(false);
                                item = Instantiate(itemPrefab, itemsParent);
                                item.GetComponent<Image>().sprite = itemSprites[1];
                                break;
                            case "purple":
                                hit.transform.gameObject.SetActive(false);
                                item = Instantiate(itemPrefab, itemsParent);
                                item.GetComponent<Image>().sprite = itemSprites[2];
                                audioController.playAudio("femaleScream");
                                break;
                            case "orange":
                                hit.transform.gameObject.SetActive(false);
                                item = Instantiate(itemPrefab, itemsParent);
                                item.GetComponent<Image>().sprite = itemSprites[3];
                                break;
                            default:
                                break;
                        }
                    }
                    else if (hit.transform.name == "switch") {
                        audioController.playAudio("lockOpen");
                        lightController.switchLight();
                        puzzleController.setPainting4(lightController.light.activeSelf);
                    }
                    else if (hit.transform.name.Split('_')[0] == "safe") {
                        viewController.setSafeView(true);
                    }
                    else if (hit.transform.name.Split('_')[0] == "wardrobe") {
                        audioController.playAudio("doorLock");
                    }
                    else
                        hit.transform.gameObject.SetActive(false);
            }
            else {
                infoText.text = "";
                isBigDoorTraced = false;
            }
        }
        #endregion
    }

}
