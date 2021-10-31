using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossArea : MonoBehaviour
{

    public Animator animator;
    public Animator wingsAnimator;
    private BoxCollider2D pc;
    public int health;
    public bool invincible;
    public bool cantHurt;

    public bool collidingAxe;

    public bossMovement bossMovementScript;

    public GameObject mothCocoons;

    private void Awake()
    {
        pc = GetComponent<BoxCollider2D>();
        pc.isTrigger = true;
        collidingAxe = false;
        cantHurt = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        invincible = false;
        animator = GetComponentInParent<Animator>();
        wingsAnimator = GameObject.Find("bossWings").GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("playerArea"))
        {
            bossMovementScript.colliding = true;
            collidingAxe = true;
        } else if (collision.CompareTag("playerAttackUpArea") || collision.CompareTag("playerAttackDownArea"))
        {
            collidingAxe = true;
            bossMovementScript.colliding = false;
        }
        else
        {
            bossMovementScript.colliding = false;
            collidingAxe = false;
        }
    }


    void getHurt()
    {
        if (collidingAxe == true && Movement.Singleton.attacking == true && invincible == false && cantHurt == false)
        {
            if (Movement.Singleton.heating == false)
            {
                health -= 1;
            }
            else
            {
                health -= 3;
            }
            animator.SetTrigger("getHurt");
            wingsAnimator.SetTrigger("getHurt");
            invincible = true;
            StartCoroutine(WaitForSec());
        }
    }

IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
        invincible = false;
    }

// Update is called once per frame
void Update()
    {

        getHurt();

        if (health <= 0)
        {
            gameManager.Singleton.Kill();
            gameManager.Singleton.bossKilled = true;
            transform.parent.gameObject.active = false;
        }
    }
}
