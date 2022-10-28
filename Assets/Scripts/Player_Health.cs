using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    Player_Combat player_combat;
    Player_Movement player_movement;
    Player_Manager player_manager;

    public bool cracked = false;

    public float stunTime = 0f;
    public float attackTime = 0f;

    //values pertaining to health
    public int maxHealth = 100;
    int minHealth = 0;
    public int currentHealth;

    //values pertaining to shield
    public double maxShield = 100;
    double currentShield;

    public bool hitstunActive = false;

    public GameObject player;

    public healthbar healthBar;

    public Animator animator;

    private void Awake()
    {
        player_combat = player.GetComponent<Player_Combat>();
        player_manager = player.GetComponent<Player_Manager>();
        player_movement = player.GetComponent<Player_Movement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;

        healthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        if (hitstunActive == true)
        {
            attackTime += 1 * Time.deltaTime;

            if (attackTime >= stunTime || cracked == true)
            {
                animator.SetTrigger("HitstunStop");
                attackTime = 0;
                player_movement.enabled = true;
                hitstunActive = false;
            }

            player_combat.aimingActive = false;
            animator.SetBool("Aim 0", false); 
        }

        if (player_combat.shieldActive == false && currentShield != maxShield)
        {
            currentShield += 0.5;
        }

        if(cracked == true)
        {
            if (player_manager.isGrounded == true)
            {
                Heal(20);
                player_combat.enabled = true;
                player_movement.enabled = true;
                animator.SetTrigger("CrackedStop");
                cracked = false;
            }
        }
    }


    //manages damage taken
    public void TakeDamage(int damage, int stun)
    {
        if (player_combat.shieldActive == true)
        {
            currentShield -= damage;


            if (currentShield <= 0)
            {
                Crack();
            }
        }

        else
        {

            if (currentHealth <= 0)
            {
                Crack();
            }

            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
            Debug.Log($"took {damage} damage");
            
            if (currentHealth > 0)
            {
                stunTime = stun;
                animator.SetTrigger("Hitstun");
                hitstunActive = true;
                player_movement.enabled = false;
            }
            
            if (currentHealth <= 0)
            {
                currentHealth = minHealth;
            }
        }
    }

    public void Heal(int amountHealed)
    {
        currentHealth += amountHealed;
        healthBar.SetHealth(currentHealth);
    }

    public void MaxHeal()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    //manages "cracked" state
    void Crack()
    {
        player_combat.enabled = false;
        player_movement.enabled = false;

        cracked = true;

        animator.SetTrigger("CrackedStart");
    }
}
