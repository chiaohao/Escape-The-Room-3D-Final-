using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemSelf : MonoBehaviour {

    Transform itemDescription;

    Sprite image;
    string title;
    string detail;
    bool isUpdated;

    GameObject mainController;

	void Start () {
        title = "";
        detail = "";
        isUpdated = false;
        mainController = GameObject.Find("mainController");
	}
	
	void Update () {
        if (!isUpdated)
            updateItemData();
	}

    void updateItemData() {
        image = transform.GetComponent<Image>().sprite;
        itemDescription = transform.parent.transform.parent.Find("ItemDescription").transform;
        switch (image.name) {
            case "blue diamond":
                title = "藍寶石";
                detail = "閃亮的藍寶石，似乎可以裝在哪裡。";
                    break;
            case "red diamond":
                title = "紅寶石";
                detail = "血紅的紅寶石，似乎可以裝在哪裡。";
                    break;
            case "purple diamond":
                title = "紫寶石";
                detail = "高貴的紫寶石，似乎可以裝在哪裡。";
                    break;
            case "orange diamond":
                title = "橘寶石";
                detail = "耀眼的橘寶石，似乎可以裝在哪裡。";
                    break;
            default:
                title = "";
                detail = "";
                break;
        }
        if (title != "" && detail != "")
            isUpdated = true;
    }

    public void onMouseEnter() {
        itemDescription.gameObject.SetActive(true);
        setDetail();
    }

    public void onMouseLeave() {
        itemDescription.gameObject.SetActive(false);
    }

    public void onMouseClick() {
        if (mainController.GetComponent<cursorCenterClick>().isBigDoorTraced) {
            switch (image.name) {
                case "blue diamond":
                    mainController.GetComponent<puzzleController>().setDoorDiamond("blue");
                    Destroy(gameObject);
                    itemDescription.gameObject.SetActive(false);
                    break;
                case "red diamond":
                    mainController.GetComponent<puzzleController>().setDoorDiamond("red");
                    Destroy(gameObject);
                    itemDescription.gameObject.SetActive(false);
                    break;
                case "purple diamond":
                    mainController.GetComponent<puzzleController>().setDoorDiamond("purple");
                    Destroy(gameObject);
                    itemDescription.gameObject.SetActive(false);
                    break;
                case "orange diamond":
                    mainController.GetComponent<puzzleController>().setDoorDiamond("orange");
                    Destroy(gameObject);
                    itemDescription.gameObject.SetActive(false);
                    break;
                default:
                    break;
          }
        }
    }

    void setDetail() {
        itemDescription.transform.Find("Image").GetComponent<Image>().sprite = image;
        itemDescription.transform.Find("Title").GetComponent<Text>().text = title;
        itemDescription.transform.Find("Detail").GetComponent<Text>().text = detail;
    }
}
