using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossArea : MonoBehaviour
{

    public Animator animator;
    public Animator wingsAnimator;
    private PolygonCollider2D pc;
    public int health;
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
        health = 50;
        invincible = false;
        animator = GetComponentInParent<Animator>();
        wingsAnimator = GameObject.Find("bossWings").GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("playerArea"))
        {
            bossMovementScript.colliding = true;
        } else
        {
            bossMovementScript.colliding = false;
        }
    }

    void getHurt()
    {
        if (bossMovementScript.colliding == true && Movement.Singleton.attacking == true && invincible == false)
        {
            if (Movement.Singleton.heating == false)
            {
                health -= 1;
            }
            else
            {
                health -= 5;
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
            gameManager.Singleton.bossKilled = true;
            transform.parent.gameObject.active = false;
        }
    }
}
