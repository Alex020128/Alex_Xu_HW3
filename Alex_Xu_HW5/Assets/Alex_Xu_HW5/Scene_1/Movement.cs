using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float walkSpeed = 3.0f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;

    Vector2 movement;

    void Walk()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

    }

    void pickUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("pickUp");
        }
    }

// Update is called once per frame
void Update()
    {
        Walk();

        pickUp();
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
    }
}
