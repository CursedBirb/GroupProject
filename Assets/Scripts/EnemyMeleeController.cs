using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeController : MonoBehaviour
{
   public int health = 5;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public int damageAmount; 

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

        } else {

            theRB.velocity = Vector2.zero;

        }
        
    }

    public void TakeDamage() {

        health--;
        if(health <= 0) {
            
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

        }

    }

        private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player") {

            PlayerController.instance.TakeDamage(damageAmount);

            Destroy(gameObject);

        }

    }
}
