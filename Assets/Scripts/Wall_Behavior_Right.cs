using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Behavior_Right : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    float colVelocity;
    int wallDamage;

    bool bounceBack = false;
    float bounceTime = 0;

    GameObject bouncedPlayer;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bounceBack == true)
        {
            bounceTime += 1 * Time.deltaTime;

            Debug.Log(bounceTime);

            if (bounceTime >= 1)
            {
                bounceTime = 0;
                bounceBack = false;
                Debug.Log("bouncetime");
                bouncedPlayer.GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<Player_Health>().cracked == true)
        {
            bouncedPlayer = collision.gameObject;

            colVelocity = collision.attachedRigidbody.velocity.x;
            
            wallDamage = (int)colVelocity;
            
            currentHealth -= (wallDamage * 5);

            Debug.Log("wall health: " + currentHealth);

            if (currentHealth == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                bouncedPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(-9, 7);
                bouncedPlayer.GetComponent<CapsuleCollider2D>().enabled = false;
                bounceBack = true;
            }
        }
    }
}
