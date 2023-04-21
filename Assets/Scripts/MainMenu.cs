using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {

        SceneManager.LoadScene("FirstMap");

    }

    public void LoadGameMenu() {

        SceneManager.LoadScene("LoadGameMenu");
        
    }


    public void MainMenU() {

        SceneManager.LoadScene("MainMenu");

    }

    public void ExitGame() {

        Application.Quit();
        
    }
}
