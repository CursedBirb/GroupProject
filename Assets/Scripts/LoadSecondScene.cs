using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecondScene : MonoBehaviour {

    void Start() {

    }
        
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player") {

            PlayerController.instance.finishedLevel = 2;

            //if(Input.GetKeyDown(KeyCode.Space)) {
            
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FirstMap")) {

                    SceneManager.LoadScene("SecondMap");   //wrzuć tu nazwę kolejnej sceny, pamiętaj, by aktywować ją wcześniej tak jak przy śmierci

                }

                else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SecondMap")) {

                    SceneManager.LoadScene("SecondMap");   //wrzuć tu nazwę kolejnej sceny, pamiętaj, by aktywować ją wcześniej tak jak przy śmierci

                }

            //}

        }

    }

}