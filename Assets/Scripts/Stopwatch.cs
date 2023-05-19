using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Stopwatch : MonoBehaviour {

    float timeNow;
    float timetimetime;
    public TMP_Text deathTime;
    public TMP_Text firstLevelTime;
    public TMP_Text secondLevelTime;
    public bool timeToStop;


    // Start is called before the first frame update
    void Start() {

        timeNow = 0;
        
    }

    // Update is called once per frame
    void Update() {


        if((PlayerController.instance.hasDied == 1) || (PlayerController.instance.finishedLevel == 1)) {

            timeNow =+ Time.deltaTime;

        }

        TimeSpan time = TimeSpan.FromSeconds(timeNow);
        deathTime.text = time.ToString(@"mm\:ss\:fff");
        firstLevelTime.text = time.ToString(@"mm\:ss\:fff");
        secondLevelTime.text = time.ToString(@"mm\:ss\:fff");

    }

}