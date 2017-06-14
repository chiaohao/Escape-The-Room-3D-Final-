using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class poemController : MonoBehaviour {

    public GameObject poemPanel;
    public GameObject titleCover;
    public GameObject mask;
    public float speed;
    public GameObject fadePanel;
    int[] range = new int[] { -360, 360 };
    bool isScrollDone;
    float titleDelayTime = 0f;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 p = poemPanel.transform.GetComponent<RectTransform>().position;
        poemPanel.transform.GetComponent<RectTransform>().position =new Vector3(p.x, range[0], p.z);
        isScrollDone = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 p = poemPanel.transform.GetComponent<RectTransform>().position;
        if (!isScrollDone) { 
            if (p.y < range[1])
                poemPanel.transform.GetComponent<RectTransform>().position = new Vector3(p.x, p.y + Time.deltaTime * speed, p.z);
            else {
                poemPanel.transform.GetComponent<RectTransform>().position = new Vector3(p.x, range[1], p.z);
                isScrollDone = true;
                mask.SetActive(false);
            }
        }
        else {
            titleDelayTime += Time.deltaTime * speed;
            if (titleDelayTime >= 50f) {
                if (titleCover.transform.GetComponent<Image>().color.a >= 0) {
                    Color c = titleCover.transform.GetComponent<Image>().color;
                    c.a -= Time.deltaTime;
                    titleCover.transform.GetComponent<Image>().color = c;
                }
            }
            if (titleDelayTime >= 100f) {
                if (Input.anyKey) { 
                    fadePanel.GetComponent<fadePanel>().outPanel = poemPanel;
                    fadePanel.GetComponent<fadePanel>().inPanel = null;
                    fadePanel.SetActive(true);
                }
                if (!poemPanel.activeSelf)
                    SceneManager.LoadScene("scenes/main");
            }
        }
    }
}
