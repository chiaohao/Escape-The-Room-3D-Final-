using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingController : MonoBehaviour {

    public GameObject ghostImage;
    public GameObject fadePanel;
    audioController audioController;

	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        audioController = GameObject.Find("audioController").GetComponent<audioController>();
        StartCoroutine(playGhost());
	}

    IEnumerator playGhost() {
        yield return new WaitForSeconds(5);
        ghostImage.SetActive(true);
        audioController.playAudio("lastGhostScream");
        yield return new WaitForSeconds(5);
        fadePanel.GetComponent<fadePanel>().outPanel = ghostImage;
        fadePanel.GetComponent<fadePanel>().inPanel = null;
        fadePanel.GetComponent<fadePanel>().changeSceneName = "scenes/start";
        fadePanel.SetActive(true);
    }
}
