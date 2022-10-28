using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Combat : MonoBehaviour
{
    Doggo_Combat doggo_combat;
    Player_Movement player_movement;
    Player_Manager player_manager;
    [SerializeField] GameObject player;

    [SerializeField] SpriteRenderer arrow;
    public bool aimingActive = false;

    public Animator animator;

    private bool isMoving;

    public Vector2 aimVector;

    public GameObject arm;

    private float aimX;
    private float aimY;

    public bool shieldActive = false;


    // Start is called before the first frame update
    void Awake()
    {
        player_manager = player.GetComponent<Player_Manager>();
        player_movement = player.GetComponent<Player_Movement>();
        doggo_combat = player.GetComponent<Doggo_Combat>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(player_movement.inputX) > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        float angle = Mathf.Atan2(aimY, aimX) * Mathf.Rad2Deg;

        arm.transform.eulerAngles = new Vector3(0f, 0f, angle);


        if (aimingActive == true)
        {
            arrow.enabled = true;
        }
        else
        {
            arrow.enabled = false;
        }
    }

    public void Shield(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("ShieldStart");
            Debug.Log("shield start");
            shieldActive = true;

            player_movement.enabled = false;

            player_movement.playerRigidbody.velocity = new Vector2(0, 0);
        }

        if (context.canceled)
        {
            animator.SetTrigger("ShieldEnd");
            Debug.Log("shield end");
            shieldActive = false;

            player_movement.enabled = true;
        }
    }

    public void Fire1(InputAction.CallbackContext context)
    {
        if (context.performed && player_manager.isGrounded == true)
        {
            if(animator.GetBool("Aim 0") == true)
            {
                animator.SetBool("Aim 0", false);
                aimingActive = false;
                player_movement.enabled = true;
            }
            
            else
            {
                animator.SetBool("Aim 0", true);
                player_movement.playerRigidbody.velocity = new Vector2(0, 0);
            }
        }
    }

    public void Fire2(InputAction.CallbackContext context)
    {
        if (context.performed && aimingActive == true)
        {
            animator.SetTrigger("Fire");
            animator.SetBool("Aim 0", false);
        }
    }

    public void Aiming(InputAction.CallbackContext context)
    {
        aimX = context.ReadValue<Vector2>().x;

        aimY = context.ReadValue<Vector2>().y;
    }

    public void Healing(InputAction.CallbackContext context)
    {
        if(context.performed && player_manager.isGrounded == true && aimingActive == false)
        {
            animator.SetTrigger("Heal");
        }
    }

    //plays light attack animation when button is pressed
    public void LNAttack(InputAction.CallbackContext context)
    {
        if (context.performed && player_manager.isGrounded == true && isMoving == false && player_movement.inputY == 0 && aimingActive == false)
        {
            animator.SetTrigger("LNAttack");
            Debug.Log("L N");
        }

    }

    public void LSAttack(InputAction.CallbackContext context)
    {
        if (context.performed && player_manager.isGrounded == true && isMoving == true && aimingActive == false)
        {
            animator.SetTrigger("LSAttack");
            Debug.Log("L S");
        }
    }

    public void LUAttack(InputAction.CallbackContext context)
    {
        if (context.performed && player_manager.isGrounded == true && player_movement.inputY > 0 && aimingActive == false)
        {
            animator.SetTrigger("LUAttack");
            Debug.Log("L U");
        }
    }
    
    public void LDAttack(InputAction.CallbackContext context)
    {
        if (context.performed && player_manager.isGrounded && player_movement.inputY < 0 && aimingActive == false)
        {
            animator.SetTrigger("LDAttack");
            Debug.Log("L D");
        }
    }
    
    public void ALNAttack(InputAction.CallbackContext context)
    {
        if (context.performed && !player_manager.isGrounded && !isMoving && player_movement.inputY == 0 && aimingActive == false)
        {
            animator.SetTrigger("ALNAttack");
            Debug.Log("A L N");
        }
    }

    public void ALSAttack(InputAction.CallbackContext context)
    {
        if(context.performed && !player_manager.isGrounded && isMoving == true && aimingActive == false)
        {
            animator.SetTrigger("ALSAttack");
            Debug.Log("A L S");
        }
    }

    public void ALUAttack(InputAction.CallbackContext context)
    {
        if(context.performed && !player_manager.isGrounded && player_movement.inputY > 0 && aimingActive == false)
        {
            animator.SetTrigger("ALUAttack");
            Debug.Log("A L U");
        }
    }

    public void ALDAttack(InputAction.CallbackContext context)
    {
        if(context.performed && !player_manager.isGrounded && player_movement.inputY < 0 && aimingActive == false)
        {
            animator.SetTrigger("ALDAttack");
            Debug.Log("A L D");
        }
    }

}
