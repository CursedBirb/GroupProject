using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecondScene : MonoBehaviour {

    private bool isTriggered = false;

    void Start() {

    }
        
    void Update() {
        
        if(isTriggered && Input.GetKeyDown(KeyCode.Space)) {

            string currentSceneName = SceneManager.GetActiveScene().name;
            string nextSceneName = "";

            if (currentSceneName == "FirstMap") {

                nextSceneName = "SecondMap";
            }

            else if (currentSceneName == "SecondMap") {

                nextSceneName = "ThirdMap";

            }

            SceneManager.LoadScene(nextSceneName);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player") {

            isTriggered = true;
            PlayerController.instance.finishedLevel = true;

        }

    }

}