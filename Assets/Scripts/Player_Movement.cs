using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    Player_Manager player_manager;

    [SerializeField] GameObject player;

    private bool jumpInputGot;

    public Animator animator;

    public bool isCrouching;

    //values pertaining to movement
    public float movementSpeed = 1;
    public float jumpForce = 1;
    public float inputX;
    public float inputY;

    public bool facingRight;

    //values pertaining to double jumps
    public int extraJumps;
    public int extraJumpValue;

    public Rigidbody2D playerRigidbody;


    // Start is called before the first frame update
    private void Start()
    {
        player_manager = player.GetComponent<Player_Manager>();

        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {

        bool isCrouching = inputY < 0 && player_manager.isGrounded && (inputX >= -0.3 && inputX <= 0.3);
        animator.SetBool("IsCrouching", isCrouching);

        /*handles left/right movement*/
        if (isCrouching == false)
        {
            playerRigidbody.velocity = new Vector2(inputX * movementSpeed, playerRigidbody.velocity.y);
            //playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x + (inputX * movementSpeed), playerRigidbody.velocity.y);
        }
        else
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

        /*flips player left and right based on last input*/
        if ((inputX < 0 && facingRight) || (inputX > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        /*checks if player is grounded and how many jumps they can make*/

        if (player_manager.isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if (jumpInputGot && extraJumps > 0 && player_manager.isGrounded == true)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            extraJumps--;
            jumpInputGot = false;
        }
        else if (jumpInputGot && extraJumps > 0 && player_manager.isGrounded == false)
        {
            playerRigidbody.velocity = new Vector2(0, 0);
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            extraJumps--;
            jumpInputGot = false;
        }
    }

    //grabs input from WASD (scope is outside of this script)
    public void Horizontal(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    //makes player jump every time spacebar is pressed (scope is outside of this script)
    public void Jump(InputAction.CallbackContext context)
    {
        jumpInputGot = context.performed;
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        inputY = context.ReadValue<Vector2>().y;
    }



}
