using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health = 10;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = 0.5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange){

            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;

            if(shouldShoot) {

                shotCounter -=Time.deltaTime;
                if(shotCounter <= 0) {

                    Instantiate(bullet, firePoint. position, firePoint.rotation);
                    shotCounter = fireRate;
                    
                }

            }

        } else {

            theRB.velocity = Vector2.zero;

        }
        
    }

    public void TakeDamage(int damageTaken, int damagePotionMultiply) {

        health = health - (damageTaken * damagePotionMultiply);
        if(health <= 0) {
            
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

        }

    }
}
