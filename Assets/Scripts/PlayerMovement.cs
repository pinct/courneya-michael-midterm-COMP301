using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public Variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    // Private Variables
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Physics
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();
        animator.SetBool("isGrounded", isGrounded);
        if (rBody.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetFloat("xSpeed", rBody.velocity.x);
        }
        else if(rBody.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetFloat("xSpeed", -rBody.velocity.x);
        }

        //Jump Code
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }
        else if (isGrounded && Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("isDucking", true);
        }
        else
        {
            animator.SetBool("isDucking", false);
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }
}
