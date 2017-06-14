using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadePanel : MonoBehaviour {

    Image panel;
    public bool isFadeIn;
    public bool isFadeOut;
    public GameObject outPanel;
    public GameObject inPanel;
    public string changeSceneName = "";

    void OnEnable() {
        panel = transform.GetComponent<Image>();
        isFadeIn = true;
        isFadeOut = false;
    }

    void Update() {
        if (isFadeIn)
            fadeIn();
        else {
            if (outPanel != null)
               outPanel.SetActive(false);
            if (inPanel != null)
                inPanel.SetActive(true);
        }
        if (isFadeOut)
            fadeOut();
        if (!isFadeOut && !isFadeIn) {
            gameObject.SetActive(false);
            if (changeSceneName != "")
                SceneManager.LoadScene(changeSceneName);
        }
    }
	
    public void fadeIn() {
        if (panel.color.a < 1) {
            Color c = panel.color;
            Color newColor = new Color(c.r, c.g, c.b, c.a + Time.deltaTime);
            panel.color = newColor;
        }
        else {
            isFadeIn = false;
            isFadeOut = true;
        }
    }

    public void fadeOut() {
        if (panel.color.a > 0) { 
            Color c = panel.color;
            Color newColor = new Color(c.r, c.g, c.b, c.a - Time.deltaTime);
            panel.color = newColor;
        }
        else
            isFadeOut = false;
    }
}
