using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool gunFirst;
    private bool gunSecond;
    public int gunType;

    public void Awake() {

        instance = this;
        gunFirst = true;
        gunSecond = false;
        gunType = 1;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;

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

            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
            
                gunFirst = false;
                gunSecond = true;

            }

            GunShooting();

           

        }

    }

    public void TakeDamage(int damageAmount) {

        currentHealth -= damageAmount;

        if( currentHealth <= 0) {

            deadScreen.SetActive(true);
            hasDied = true;

        }

    }

    public void AddHealth(int healAmount) {

        currentHealth =+ healAmount;

        if(currentHealth > maxHealth) {

            currentHealth = maxHealth;

        }

    }

    public void GunShooting() {

        if (gunFirst == true) {

            gunSecond = false;

            if(Input.GetMouseButtonDown(0)) {

                if(currentAmmo > 0) {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))

                        {
                        //Debug.Log("Patrzę na " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy") {

                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage();

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
            

            if(Input.GetMouseButtonDown(0)) {

                if(currentAmmo > 0) {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))

                        {
                        //Debug.Log("Patrzę na " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy") {

                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                                hit.transform.parent.GetComponent<EnemyController>().TakeDamage();

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
