using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;

    public float moveSpeed = 5;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;

    public int pistolAmmo;
    public int shotgunAmmo;
    public int machineAmmo;

    public Animator gunAnimation;
    public Animator gunAnimation2;
    public Animator gunAnimation3;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    public GameObject firstLevelEndScreen;
    public GameObject secondLevelEndScreen;
    public bool hasDied;
    public bool finishedLevel;


    public Text healthText, ammoText;

    private bool gunFirst;
    private bool gunSecond;
    private bool gunThird;
    public int gunType;

    public int damagePotionMultiply;

    public void Awake() {

        instance = this;
        gunFirst = true;
        gunSecond = false;
        gunThird = false;
        gunType = 1;
        

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;

        pistolAmmo = 30;
        shotgunAmmo = 15;
        machineAmmo = 60;

        healthText.text = currentHealth.ToString() + "%";

        ammoText.text = pistolAmmo.ToString();

        damagePotionMultiply = 1;

        hasDied = false;
        finishedLevel = false;
    }

    // Update is called once per frame
    void Update() {

        if((!hasDied) || (!finishedLevel)) {
            //poruszanie
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;


            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

            //kamera
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            //strzelanie

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
            
                gunFirst = true;
                gunSecond = false;
                gunThird = false;

            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
            
                gunFirst = false;
                gunSecond = true;
                gunThird = false;

            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) {
            
                gunFirst = false;
                gunSecond = false;
                gunThird = true;

            }

            GunShooting();
        }

        if(finishedLevel) {

            currentHealth = 9999;

            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FirstMap")) {

                    firstLevelEndScreen.SetActive(true);

                }

                else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SecondMap")) {

                    secondLevelEndScreen.SetActive(true);

                }

        }

    }

    public void TakeDamage(int damageAmount) {

        currentHealth -= damageAmount;

        if(currentHealth <= 0) {

            deadScreen.SetActive(true);
            hasDied = true;
            currentHealth = 0;
        }
            healthText.text = currentHealth.ToString() + "%";
    }

    public void AddHealth(int healthAmount) {

        currentHealth += healthAmount;

        if(currentHealth > maxHealth) {

            currentHealth = maxHealth;

        }
            healthText.text = currentHealth.ToString() + "%";
    }

    public void UpdateAmmoUI() {

        ammoText.text = pistolAmmo.ToString();

    }

    public void UpdateHealthUI(){

            healthText.text = currentHealth.ToString();

        }

    public void GunShooting() {

        if (gunFirst == true) {

            gunSecond = false;
            gunThird = false;

            if(Input.GetMouseButtonDown(0)) {

                if(pistolAmmo > 0) {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))

                        {
                        //Debug.Log("Patrzę na " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy") {

                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage(4, damagePotionMultiply);

                            }

                        } else {
                            Debug.Log("Patrzę na nic!");
                        }

                    gunAnimation.SetTrigger("Shoot");    
                    pistolAmmo--;

                    }

                if(pistolAmmo <=0) {

                    pistolAmmo = 0;
                }

                }

        } else if(gunSecond == true) {

            gunFirst = false;
            gunThird = false;

            if(Input.GetMouseButtonDown(0)) {

                if(shotgunAmmo > 0) {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))

                        {
                        //Debug.Log("Patrzę na " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy") {

                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage(12, damagePotionMultiply);

                            }

                        } else {
                            Debug.Log("Patrzę na nic!");
                        }

                    gunAnimation2.SetTrigger("Shoot");    
                    shotgunAmmo--;

                    }

                
                if(shotgunAmmo <=0) {

                    shotgunAmmo = 0;
                }

            }

        }   else if(gunThird == true) {

            gunFirst = false;
            gunSecond = false;
            

            if(Input.GetMouseButton(0)) {

                if(machineAmmo > 0) {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))

                        {
                        //Debug.Log("Patrzę na " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy") {

                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage(1, damagePotionMultiply);

                            }

                        } else {
                            Debug.Log("Patrzę na nic!");
                        }

                    gunAnimation3.SetTrigger("Shoot");    
                    machineAmmo--;

                    }

                if(machineAmmo <=0) {

                    machineAmmo = 0;
                }

            }
        }

    }

}
