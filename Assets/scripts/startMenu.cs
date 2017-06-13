using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

    public Text startText;
    public Text exitText;
    public GameObject menu;
    public GameObject tutorial;
    public GameObject startPanel;

    void Update() {
        if (tutorial.activeSelf)
            if (Input.anyKey)
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
        menu.SetActive(false);
        startPanel.SetActive(false);
        tutorial.SetActive(true);
    }

    public void onExitClick() {
        Application.Quit();
    }
}
