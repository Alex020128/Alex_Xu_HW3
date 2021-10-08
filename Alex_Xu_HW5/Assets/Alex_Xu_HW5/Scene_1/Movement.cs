using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float walkSpeed = 3.0f;

    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove;

    Vector2 movement;

    void Walk()
    {

        string clipName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        canMove = clipName != "playerPickUp";

        if (canMove)
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

    public void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.collider.gameObject.tag == "Wood") && (Input.GetKey(KeyCode.Space)))
        {
            gameManager.Singleton.wood += 1;
            Destroy(collision.collider.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Walk();

        pickUp();

        if (canMove)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        if (canMove) 
            {
                rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
            }
    }
}
