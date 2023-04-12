using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    public int ammoPistolAmount = 30;
    public int ammoShotgunAmount = 15;
    public int ammoMachineAmount = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player") {

            PlayerController.instance.pistolAmmo += ammoPistolAmount;
            if(PlayerController.instance.pistolAmmo >= 90) {

                PlayerController.instance.pistolAmmo = 90;

            }

            PlayerController.instance.shotgunAmmo += ammoShotgunAmount;
            if(PlayerController.instance.shotgunAmmo >= 45) {

                PlayerController.instance.shotgunAmmo = 45;

            }

            PlayerController.instance.machineAmmo += ammoMachineAmount;
            if(PlayerController.instance.machineAmmo >= 180) {

                PlayerController.instance.machineAmmo = 180;

            }
            PlayerController.instance.UpdateAmmoUI();
            Destroy(gameObject);

        }

    }
}
