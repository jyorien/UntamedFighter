using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;

    Animator animator;
    Rigidbody2D rb;
    float horizontalMove = 0f;
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
        Debug.Log($"move: {horizontalMove}");
        animator.SetFloat("speed", horizontalMove);
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
