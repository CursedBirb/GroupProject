using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int currentAmmo;

    public Animator gunAnimation;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    public bool hasDied;

    public Text healthText, ammoText;

    private bool gunFirst;
    private bool gunSecond;
    private bool gunThird;
    public int gunType;

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
        healthText.text = currentHealth.ToString() + "%";

        ammoText.text = currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update() {

        if(!hasDied) {
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

    }

public void TakeDamage(int damageAmount) {

        currentHealth -= damageAmount;

        if( currentHealth <= 0) {

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

        ammoText.text = currentAmmo.ToString();

    }

    public void UpdateHealthUI(){

            healthText.text = currentHealth.ToString();

        }

    public void GunShooting() {

        if (gunFirst == true) {

            gunSecond = false;
            gunThird = false;

            if(Input.GetMouseButtonDown(0)) {

                if(currentAmmo > 0) {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))

                        {
                        //Debug.Log("Patrzę na " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy") {

                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage(4);

                            }

                        } else {
                            Debug.Log("Patrzę na nic!");
                        }
                    }
                currentAmmo--;
                gunAnimation.SetTrigger("Shoot");

                }

        } else if(gunSecond == true) {

            gunFirst = false;
            gunThird = false;

            if(Input.GetMouseButtonDown(0)) {

                if(currentAmmo > 0) {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))

                        {
                        //Debug.Log("Patrzę na " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy") {

                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage(12);

                            }

                        } else {
                            Debug.Log("Patrzę na nic!");
                        }
                    }
                currentAmmo--;
                gunAnimation.SetTrigger("Shoot");

            }

        }   else if(gunThird == true) {

            gunFirst = false;
            gunSecond = false;
            

            if(Input.GetMouseButton(0)) {

                if(currentAmmo > 0) {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))

                        {
                        //Debug.Log("Patrzę na " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy") {

                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage(1);

                            }

                        } else {
                            Debug.Log("Patrzę na nic!");
                        }
                    }
                currentAmmo--;
                gunAnimation.SetTrigger("Shoot");

            }
        }

    }

}
