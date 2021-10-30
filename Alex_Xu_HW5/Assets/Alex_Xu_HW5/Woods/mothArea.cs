using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothArea : MonoBehaviour
{

    public Animator animator;
    private BoxCollider2D pc;
    public float health;
    public bool invincible;
    public bool colliding;

    private void Awake()
    {
        pc = GetComponent<BoxCollider2D>();
        pc.isTrigger = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 2;
        invincible = false;
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("playerAttackUpArea") || collision.CompareTag("playerAttackDownArea"))
        {
            colliding = true;
        } else
        {
            colliding = false;
        }
    }

    void getHurt() { 
    if (colliding == true && Movement.Singleton.attacking == true && invincible == false){

            if(Movement.Singleton.heating == false)
            {
                health -= 1;
            } else
            {
                health -= 3;
            }
            animator.SetTrigger("getHurt");
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
            Destroy(transform.parent.gameObject);
        }
    }
}
