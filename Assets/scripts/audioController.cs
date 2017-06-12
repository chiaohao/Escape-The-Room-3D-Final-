using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour {

    AudioSource au;
    public AudioClip cubePick;
    public AudioClip wrongAnswer;
    public AudioClip drawerOpen;
    public AudioClip layerChop;
    public AudioClip wardrobeDoorOpen;
    public AudioClip doorLock;
    public AudioClip screenBreak;
    public AudioClip lockOpen;
    public AudioClip femaleScream;

    void Start () {
        au = GetComponent<AudioSource>();
        au.volume = 1.0f;
	}
	
	public void playAudio(string a) {
        switch (a) {
            case "cubePick":
                au.PlayOneShot(cubePick);
                break;
            case "wrongAnswer":
                au.PlayOneShot(wrongAnswer);
                break;
            case "drawerOpen":
                au.PlayOneShot(drawerOpen);
                break;
            case "layerChop":
                au.PlayOneShot(layerChop);
                break;
            case "wardrobeDoorOpen":
                au.PlayOneShot(wardrobeDoorOpen);
                break;
            case "doorLock":
                au.PlayOneShot(doorLock);
                break;
            case "screenBreak":
                au.PlayOneShot(screenBreak);
                break;
            case "lockOpen":
                au.PlayOneShot(lockOpen);
                break;
            case "femaleScream":
                au.PlayOneShot(femaleScream);
                break;
            default:
                break;
        }
    }
}
