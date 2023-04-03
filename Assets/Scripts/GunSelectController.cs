using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelectController : MonoBehaviour {

    public GameObject gunSpriteFirst;
    public GameObject gunSpriteSecond;
    public GameObject gunSpriteThird;

    public void Awake() {

        gunSpriteFirst.SetActive(true);
        gunSpriteSecond.SetActive(false);
        gunSpriteThird.SetActive(false);

    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            
                gunSpriteFirst.SetActive(true);
                gunSpriteSecond.SetActive(false);
                gunSpriteThird.SetActive(false);

            }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            
                gunSpriteFirst.SetActive(false);
                gunSpriteSecond.SetActive(true);
                gunSpriteThird.SetActive(false);

            }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            
                gunSpriteFirst.SetActive(false);
                gunSpriteSecond.SetActive(false);
                gunSpriteThird.SetActive(true);

            }

    }
}
