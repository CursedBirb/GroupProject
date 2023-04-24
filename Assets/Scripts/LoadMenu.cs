using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadMenu : MonoBehaviour {

    public TMP_InputField Field;

    public string ToCheck;
    public string SecondLevelCode = "wolololo";
    public string ThirdLevelCode = "lalalala";

    public void CheckScenecode() {

        string toCheck = Field.text.ToString();

        if(toCheck == SecondLevelCode) {

            SceneManager.LoadScene("SecondMap");

        } /*else if(ToCheck == ThirdLevelCode) {

            SceneManager.LoadScene("ThirdMap");

        }  */

    }

}
