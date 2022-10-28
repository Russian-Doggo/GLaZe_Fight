using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Doggo_Combat : MonoBehaviour
{
    Player_Combat player_combat;
    Player_Manager player_manager;
    Player_Movement player_movement;
    Player_Health player_health;
    
    [SerializeField] GameObject player;

    public Animator animator;

    [SerializeField] SpriteRenderer arrow;
    public bool aimingActive = false;

    public bool healingActive = false;

    private int heldJumps;

    public Rigidbody2D playerRigidbody;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    //defines hitbox
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public LayerMask enemies;
    public LayerMask bullets;

    public int LN_damage = 40;
    public bool LN_active = false;

    public int LS_damage = 20;
    public bool LS_active = false;

    public int LU_damage = 10;
    public bool LU_active = false;

    public int LD_damage = 20;
    public bool LD_active = false;

    public int ALN_damage = 15;
    public bool ALN_active = false;

    public int ALS_damage = 20;
    public bool ALS_active = false;

    public int ALU_damage = 30;
    public bool ALU_active = false;

    public int ALD_damage = 15;
    public bool ALD_active = false;

    public float startingTime = 0f;
    public float attackTime = 0f;

    public Collider2D[] attackHurtboxes;

    // Start is called before the first frame update
    void Awake()
    {
        player_manager = player.GetComponent<Player_Manager>();
        player_movement = player.GetComponent<Player_Movement>();
        player_combat = player.GetComponent<Player_Combat>();
        player_health = player.GetComponent<Player_Health>();
    }

    List<GameObject> Collisions = new List<GameObject>();

    private void FixedUpdate()
    {
        if (LN_active == true)
        {
            Collider2D[] LN_hitEnemies = Physics2D.OverlapBoxAll(attackHurtboxes[0].bounds.center, attackHurtboxes[0].bounds.extents, attackHurtboxes[0].transform.rotation.z, playerLayers);

            foreach (Collider2D b in LN_hitEnemies)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 2);
                        }

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(LN_damage, 3);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                        }

                        Collisions.Add(c);
                    }


                }

            }
        }

        //Light Side attack hitbox check

        if (LS_active == true)
        {
            Collider2D[] LS_hitEnemies = Physics2D.OverlapBoxAll(attackHurtboxes[1].bounds.center, attackHurtboxes[1].bounds.extents, attackHurtboxes[1].transform.rotation.z, playerLayers);

            foreach (Collider2D b in LS_hitEnemies)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 2);
                        }

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(LS_damage, 3);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 2);
                        }

                        Collisions.Add(c);
                    }

                    
                }

            }
        }

        //Light Up attack hitbox check

        if (LU_active == true)
        {
            Collider2D[] LU_hitEnemies = Physics2D.OverlapBoxAll(attackHurtboxes[2].bounds.center, attackHurtboxes[2].bounds.extents, attackHurtboxes[2].transform.rotation.z, playerLayers);

            foreach (Collider2D b in LU_hitEnemies)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        c.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 4);

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(LU_damage, 3);
                        c.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 4);
                        Collisions.Add(c);
                    }                  
                    
                }

            }
        }

        //Light Down attack hitbox check

        if (LD_active == true)
        {
            Collider2D[] LD_hitenemies1 = Physics2D.OverlapBoxAll(attackHurtboxes[3].bounds.center, attackHurtboxes[3].bounds.extents, attackHurtboxes[3].transform.rotation.z, playerLayers);
            Collider2D[] LD_hitenemies2 = Physics2D.OverlapBoxAll(attackHurtboxes[4].bounds.center, attackHurtboxes[4].bounds.extents, attackHurtboxes[4].transform.rotation.z, playerLayers);
            Collider2D[] LD_hitenemies3 = Physics2D.OverlapBoxAll(attackHurtboxes[5].bounds.center, attackHurtboxes[5].bounds.extents, attackHurtboxes[5].transform.rotation.z, playerLayers);

            foreach (Collider2D b in LD_hitenemies1)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                        }

                        Collisions.Add(c);

                        Debug.Log("parry");
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(LD_damage, 3);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                        }

                        Collisions.Add(c);
                    }

                    
                }
            }

            foreach (Collider2D b in LD_hitenemies2)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                        }

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(LD_damage, 3);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                        }

                        Collisions.Add(c);
                    }
                }
            }

            foreach (Collider2D b in LD_hitenemies3)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 2);
                        }

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(LD_damage, 3);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 2);
                        }

                        Collisions.Add(c);
                    }                    
                }
            }
        }

        //Airial light neutral attack hitbox check
        if (ALN_active == true)
        {
            Collider2D[] LNA_hitenemies = Physics2D.OverlapBoxAll(attackHurtboxes[6].bounds.center, attackHurtboxes[6].bounds.extents, attackHurtboxes[6].transform.rotation.z, playerLayers);

            foreach (Collider2D b in LNA_hitenemies)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        Destroy(c);

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(ALN_damage, 3);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                        }

                        Collisions.Add(c);
                    }                    
                }
            }
        }

        //Airial light side attack hitbox check
        if (ALS_active == true)
        {
            Collider2D[] ALS_hitEnemies = Physics2D.OverlapBoxAll(attackHurtboxes[7].bounds.center, attackHurtboxes[7].bounds.extents, attackHurtboxes[7].transform.rotation.z, playerLayers);

            foreach (Collider2D b in ALS_hitEnemies)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 2);
                        }

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(ALS_damage, 3);
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 2);
                        }
                        Collisions.Add(c);
                    }                   
                }

            }
        }

        //Airial light side attack hitbox check
        if (ALU_active == true)
        {
            Collider2D[] ALU_hitEnemies1 = Physics2D.OverlapBoxAll(attackHurtboxes[8].bounds.center, attackHurtboxes[8].bounds.extents, attackHurtboxes[8].transform.rotation.z, playerLayers);
            Collider2D[] ALU_hitEnemies2 = Physics2D.OverlapBoxAll(attackHurtboxes[9].bounds.center, attackHurtboxes[9].bounds.extents, attackHurtboxes[9].transform.rotation.z, playerLayers);

            foreach (Collider2D b in ALU_hitEnemies1)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 4);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 4);
                        }

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(ALU_damage, 3);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 4);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 4);
                        }

                        Collisions.Add(c);
                    }
                    
                }

            }

            foreach (Collider2D b in ALU_hitEnemies2)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 4);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 4);
                        }

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        c.GetComponent<Player_Health>().TakeDamage(ALU_damage, 3);
                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 4);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 4);
                        }
                        Collisions.Add(c);
                    }                    
                }

            }
        }

        //Airial light down attack hitbox check
        if (ALD_active == true)
        {
            Collider2D[] ALD_hitEnemies = Physics2D.OverlapBoxAll(attackHurtboxes[10].bounds.center, attackHurtboxes[10].bounds.extents, attackHurtboxes[10].transform.rotation.z, playerLayers);

            attackTime += 1 * Time.deltaTime;

            if (player_manager.isGrounded == true)
            {
                attackTime = 0;
                animator.SetTrigger("ALDStop");
                ALD_Endlag();
                Debug.Log("END");
            }

            if (attackTime >= 2f)
            {
                attackTime = 0;
                animator.SetTrigger("ALDStop");
                ALD_Endlag();
                Debug.Log("END");
            }

            foreach (Collider2D b in ALD_hitEnemies)
            {
                GameObject c = b.gameObject;

                if (Collisions.Contains(c) == false)
                {
                    if (c.CompareTag("Projectiles"))
                    {
                        player_movement.playerRigidbody.velocity = new Vector2(0, 0);
                        player_movement.playerRigidbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 2);
                        }

                        Debug.Log("parry");

                        Collisions.Add(c);
                    }
                    else
                    {
                        player_movement.playerRigidbody.velocity = new Vector2(0, 0);
                        player_movement.playerRigidbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                        c.GetComponent<Player_Health>().TakeDamage(ALD_damage, 3);

                        if (player_movement.facingRight == true)
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -2);
                        }
                        else
                        {
                            c.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -2);
                        }

                        Collisions.Add(c);
                    }
                    
                }

            }
        }

        if (aimingActive == true)
        {
            arrow.enabled = true;
        }
        else
        {
            arrow.enabled = false;
        }

        if (healingActive == true)
        {

        }
        else
        {

        }

    }

    /*Animation events*/
    public void AttackStartup()
    {
        this.GetComponent<Player_Movement>().enabled = false;
    }

    public void AttackEnd()
    {
        this.GetComponent<Player_Movement>().enabled = true;
    }

    //light neutral attack
    //plays animation event that damages enemies within the hitbox
    public void LN_ActiveFrames()
    {
        LN_active = true;   
    }

    public void LN_Endlag()
    {
        Collisions.Clear();
        LN_active = false;
    }

    //light side attack
    public void LS_ActiveFrames()
    {
        if(player_movement.facingRight == true)
        {
            player_movement.playerRigidbody.velocity = new Vector2(8, 0);
        }
        else
        {
            player_movement.playerRigidbody.velocity = new Vector2(-8, 0);
        }
        
        LS_active = true;
        
    }

    public void LS_Endlag()
    {
        player_movement.playerRigidbody.velocity = new Vector2(0, 0);
        Collisions.Clear();
        LS_active = false;
    }


    //light up attack
    public void LU_ActiveFrames()
    {
        LU_active = true;
    }

    public void LU_Endlag()
    {
        Collisions.Clear();
        LU_active = false;
    }


    //light down attack
    public void LD_ActiveFrames()
    {
        if (player_movement.facingRight == true)
        {
            player_movement.playerRigidbody.velocity = new Vector2(-2, 0);
        }
        else
        {
            player_movement.playerRigidbody.velocity = new Vector2(2, 0);
        }
        LD_active = true;
    }

    public void LD_Endlag()
    {
        Collisions.Clear();
        LD_active = false;
    }


    //heavy neutral attack
    public void HN_ActiveFrames()
    {

    }



    //heavy side attack
    public void HS_ActiveFrames()
    {

    }



    //heavy up attack
    public void HU_ActiveFrames()
    {

    }



    //heavy down attack
    public void HD_ActiveFrames()
    {

    }



    //aerial light neutral attack
    public void ALN_ActiveFrames()
    {
        ALN_active = true;
    }

    public void ALN_Endlag()
    {
        Collisions.Clear();
        ALN_active = false;
    }



    //aerial light side attack
    public void ALS_ActiveFrames()
    {
        player_movement.playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        if (player_movement.facingRight == true)
        {
            player_movement.playerRigidbody.velocity = new Vector2(8, 0);
        }
        else
        {
            player_movement.playerRigidbody.velocity = new Vector2(-8, 0);
        }

        ALS_active = true;
    }

    public void ALS_Endlag()
    {
        player_movement.playerRigidbody.constraints = ~RigidbodyConstraints2D.FreezePosition;
        Collisions.Clear();
        ALS_active = false;
    }

    //aerial light up attack
    public void ALU_ActiveFrames()
    {
        if (player_movement.facingRight == true)
        {
            player_movement.playerRigidbody.velocity = new Vector2(3, 5);
        }
        else
        {
            player_movement.playerRigidbody.velocity = new Vector2(-3, 5);
        }

        ALU_active = true;
    }

    public void ALU_Endlag()
    {
        Collisions.Clear();
        ALU_active = false;
    }

    //aerial light down attack
    public void ALD_ActiveFrames()
    {
        ALD_active = true;
        heldJumps = player_movement.extraJumps;
        player_movement.extraJumps = 0;
    }

    public void ALD_Endlag()
    {
        Collisions.Clear();
        ALD_active = false;
        player_movement.extraJumps = heldJumps;
    }

    public void Aim()
    {
        this.GetComponent<Player_Movement>().enabled = false;

        player_combat.aimingActive = true;
    }

    public void FireStartup()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        player_combat.aimingActive = false;
    }

    public void FireEndlag()
    {
        this.GetComponent<Player_Movement>().enabled = true;
    }

    public void ALD_Extra()
    {
        Collisions.Clear();
    }

    public void HealStartup()
    {
        player_movement.enabled = false;
        player_movement.playerRigidbody.velocity = new Vector2(0, 0);
        player_health.Heal(10);
    }

    public void HealEndlag()
    {
        player_movement.enabled = true;
        healingActive = false;
    }

    public void DudMethod()
    {

    }
}
