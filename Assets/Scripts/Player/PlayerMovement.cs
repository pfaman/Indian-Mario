using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playerControls;
    float direction=0;
    public float speed = 400;
    public float jumpForce = 5;

    public Rigidbody2D playerRB;
    public Animator animator; 
    public bool isFacingRight = true;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    int numberOfJumps = 0;

    private void Awake(){
        playerControls = new PlayerControls();
        playerControls.Enable();

        playerControls.Land.Move.performed += ctx =>{

            direction =ctx.ReadValue<float>();
        };
        playerControls.Land.Jump.performed += ctx => Jump();
        {

        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        // Debug.Log("msg" + isGrounded); 
        animator.SetBool("isGrounded", isGrounded); 
        playerRB.velocity =new Vector2(direction*speed*Time.fixedDeltaTime,playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));
        if (isFacingRight && direction<0 || !isFacingRight && direction>0)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {

            numberOfJumps = 0;
            AudioManager.instance.Play("FirstJump");
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;

        }
        else
        {
            if (numberOfJumps == 1)
            {
                AudioManager.instance.Play("SecondJump");
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
            }
        }
    }
}
