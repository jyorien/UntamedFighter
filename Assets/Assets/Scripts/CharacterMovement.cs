using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float jumpHeight;
    Animator animator;
    Rigidbody2D rb;
    float horizontalMove = 0f;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        
        MoveHorizontally(horizontalMove);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    void MoveHorizontally(float horizontalMove)
    {
        animator.SetFloat("speed", horizontalMove);
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    void Jump()
    {
        animator.SetBool("isJump", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Floor")
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Floor")
        {
            isGrounded = false;
        }
    }

}
