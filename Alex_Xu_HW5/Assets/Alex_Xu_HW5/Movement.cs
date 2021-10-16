using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float walkSpeed = 3.0f;

    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove;
    public bool colliding;
    public bool attacking;
    public bool tentCollide;
    public bool haveAxe;
    public bool invincible;

    public string collideWith;

    public GameObject pd;

    Vector2 movement;

    public static Movement Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        transform.position = new Vector2(3.8f, 2.7f);
    }


    // Start is called before the first frame update
    void Start()
    {
        pd = GameObject.Find("playerDialogue");
        
        pd.active = false;
        colliding = false;
        attacking = false;
        tentCollide = false;

        collideWith = "None";
        haveAxe = false;
    }

    void Walk()
    {

        string clipName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (clipName == "playerPickUp") 
        {
            canMove = false;
        }else if (clipName == "playerAttack")
        {
            canMove = false;
            attacking = true;
        } else
        {
            canMove = true;
            attacking = false;
        }

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

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (haveAxe == true)
            {
                animator.SetTrigger("Attack");
            }
        }

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.collider.gameObject.tag == "Wood") && (Input.GetKey(KeyCode.Space)))
        {
            gameManager.Singleton.wood += 1;
            Destroy(collision.collider.gameObject);
        }

        if ((collision.collider.gameObject.tag == "Axe") && (Input.GetKey(KeyCode.E)))
        {
            tentCollide = false;
            colliding = true;
            collideWith = "Axe";
            pd.active = true;
        } else if ((collision.collider.gameObject.tag == "Pot") && (Input.GetKey(KeyCode.E)))
        {
            colliding = true;
            tentCollide = false;
            collideWith = "Pot";
            pd.active = true;
        } else
        {
            colliding = false;
        }

    }

    void getHurt()
    {
        if (invincible == true)
        {
            StartCoroutine(WaitForSec());
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        invincible = false;
    }


    // Update is called once per frame
    void Update()
    {
        Walk();
        pickUp();
        Attack();
        getHurt();

                if (canMove)
                {
                    animator.SetFloat("Horizontal", movement.x);
                    animator.SetFloat("Vertical", movement.y);
                    animator.SetFloat("Speed", movement.sqrMagnitude);
                }


        if (colliding == true)
        {
            pd.active = true;
        }
        else if ((tentCollide == true))
        {
            pd.active = true;
            collideWith = "Tent";
        }
        else
        {
            pd.active = false;
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
