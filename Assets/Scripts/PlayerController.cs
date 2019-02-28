using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed;
    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    private float moveVelocity;

    public bool isAllowedToMove;
    private bool doubleJumped;
    private Animator anim;

    public Transform firePoint;
    public GameObject heartMissile;
    
    void Start()
    {
        speed = 5f;
        jumpForce = 15f;
        player = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        isAllowedToMove = true;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    
    void Update()
    {
        if (isGrounded)
        {
            doubleJumped = false;
        }

        moveVelocity = 0f;

        if (isAllowedToMove)
            PlayerMoves();

        // Player Animation
        anim.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        anim.SetBool("Grounded", isGrounded);
        // Flip Animation when player change direction
        if (player.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (player.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the heart on the player
            Instantiate(heartMissile, firePoint.position, firePoint.rotation);
        }
    }

    private void PlayerMoves()
    {
        // Player Controls
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isGrounded && !doubleJumped)
        {
            Jump();
            doubleJumped = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = speed;
        }

        player.velocity = new Vector2(moveVelocity, player.velocity.y);
    }

    public void StopPlayerMoves()
    {
        player.velocity = new Vector2(0, player.velocity.y);
        isAllowedToMove = false;
    }

    void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpForce);
    }
}
