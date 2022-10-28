using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{

    public int bounces = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<Player_Combat>().shieldActive == false)
            {
                Destroy(gameObject);
            }
            collision.gameObject.GetComponent<Player_Health>().TakeDamage(10, 1);

            Debug.Log("hit");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            bounces --;
            if (bounces <= 0)
            {
                Destroy(gameObject);
            }

            Debug.Log($"bounces {bounces}");
        }
    }
}
