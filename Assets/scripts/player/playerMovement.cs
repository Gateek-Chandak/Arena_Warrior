using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("VARIABLES")]
	public float moveSpeed;

    [Header("JUMP VARIABLES")]
    public bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpValue;
    public float jumpVelocity;
    public GameObject jumpParticle;
    public GameObject bottomOfPlayer;

    [Header("REFERENCES")]
	public Rigidbody2D rigid;

    [Header("OTHER")]

    [Header("MAPPINGS")]
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode jumpButton;
    public string horizontalAxis;

    void Start()
    {
        extraJumps = extraJumpValue;
    }

    void FixedUpdate()
    {
        //horizontal movement
        horizontalMovement();
        //jumping
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); // checks if im on the ground
    }

    void Update()
    {
        //jumping
        jump();
    }

    void jump()
    {
        if (isGrounded == true)// if im on the ground, makes jumps full
        {
            extraJumps = extraJumpValue; 
        }
        if (Input.GetKeyDown(jumpButton) && extraJumps > 0) // if i have jumps, jump
        {
            rigid.velocity = Vector2.up * jumpVelocity;
			Instantiate(jumpParticle, groundCheck.position, Quaternion.identity);
            extraJumps--;
        }
        else if (Input.GetKeyDown(jumpButton) && extraJumps == 0 && isGrounded == true) //if no jumps are left but im on the ground, jump.
        {
            rigid.velocity = Vector2.up * jumpVelocity;
			Instantiate(jumpParticle, groundCheck.position, Quaternion.identity);
        }
	}

    void horizontalMovement()
    {
        float moveInput = Input.GetAxis(horizontalAxis) * moveSpeed * Time.deltaTime;
        rigid.velocity = new Vector2(moveInput * moveSpeed, rigid.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "platform" && isGrounded == true)
        {
            transform.parent = col.gameObject.transform; //makes player move with platform
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "platform")
        {
            transform.parent = null; //when leaving platform, player removes platform as parent
        }
    }
}