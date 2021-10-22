using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossArea : MonoBehaviour
{

    public Animator animator;
    public Animator playerAnimator;
    private PolygonCollider2D pc;
    public float health;
    public bool invincible;

    public bossMovement bossMovementScript;

    private void Awake()
    {
        pc = GetComponent<PolygonCollider2D>();
        pc.isTrigger = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        invincible = false;
        animator = GetComponentInParent<Animator>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("playerArea"))
        {

            bossMovementScript.colliding = true;

            if (Movement.Singleton.attacking == true && invincible == false)
            {
                health -= 1;
                animator.SetTrigger("getHurt");
                invincible = true;
                StartCoroutine(WaitForSec());
            }
        } else
        {
            bossMovementScript.colliding = false;
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
        invincible = false;
    }


    void meleeAttack()
    {
        if (bossMovementScript.colliding == true && bossMovementScript.damaging == true && Movement.Singleton.invincible == false)
        {
            playerHealth.Singleton.health -= 5;
            bossMovementScript.damaging = false;
            Movement.Singleton.invincible = true;
            playerAnimator.SetTrigger("getHurt");
        }
    }

// Update is called once per frame
void Update()
    {

        meleeAttack();


        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
