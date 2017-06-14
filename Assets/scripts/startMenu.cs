using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

    public Text startText;
    public Text exitText;
    public GameObject tutorial;
    public GameObject startPanel;
    public GameObject fadePanel;
    public GameObject blackMask;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fadePanel.GetComponent<fadePanel>().outPanel = blackMask;
        fadePanel.GetComponent<fadePanel>().inPanel = startPanel;
        fadePanel.SetActive(true);
    }

    void Update() {
        if (tutorial.activeSelf && !fadePanel.activeSelf)
            if (Input.anyKey) {
                fadePanel.GetComponent<fadePanel>().outPanel = tutorial;
                fadePanel.GetComponent<fadePanel>().inPanel = null;
                fadePanel.SetActive(true);
            }

        if (!startPanel.activeSelf && !tutorial.activeSelf && !fadePanel.activeSelf)
            SceneManager.LoadScene("scenes/poem");
    }

    public void onStartMouseOut() {
        startText.color = new Color(1, 1, 1);
    }

    public void onExitMouseOut() {
        exitText.color = new Color(1, 1, 1);
    }

    public void onStartMouseIn() {
        startText.color = new Color(1, 0, 0);
    }

    public void onExitMouseIn() {
        exitText.color = new Color(1, 0, 0);
    }

	public void onStartClick() {
        fadePanel.GetComponent<fadePanel>().outPanel = startPanel;
        fadePanel.GetComponent<fadePanel>().inPanel = tutorial;
        fadePanel.SetActive(true);
    }

    public void onExitClick() {
        Application.Quit();
    }
}
