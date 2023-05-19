using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Stopwatch : MonoBehaviour {

    float timeNow;
    bool isRunning = true;
    public TMP_Text deathTime;
    public TMP_Text firstLevelTime;
    public TMP_Text secondLevelTime;

    void Start() {
 
        timeNow = 0;

    }

    void Update() {

        if (isRunning) {

            timeNow += Time.deltaTime;

            if (PlayerController.instance.hasDied || PlayerController.instance.finishedLevel) {

                isRunning = false;

            }
            
        }

        TimeSpan time = TimeSpan.FromSeconds(timeNow);
        deathTime.text = time.ToString(@"mm\:ss\:fff");
        firstLevelTime.text = time.ToString(@"mm\:ss\:fff");
        secondLevelTime.text = time.ToString(@"mm\:ss\:fff");

    }

}
