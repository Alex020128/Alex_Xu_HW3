using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stumpArea : MonoBehaviour
{

    public Animator animator;
    private PolygonCollider2D pc;
    public int health;
    public bool invincible;

    public bool collidingAxe;

    private void Awake()
    {
        pc = GetComponent<PolygonCollider2D>();
        pc.isTrigger = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        invincible = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("playerAttackUpArea") || collision.CompareTag("playerAttackDownArea"))
        {
            collidingAxe = true;
        } else
        {
            collidingAxe = false;
        }
    }

    void getHurt()
    {
        if (collidingAxe == true && Movement.Singleton.attacking == true && invincible == false)
        {
            if (Movement.Singleton.heating == false)
            {
                health -= 1;
            }
            else
            {
                health -= 2;
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

        collidingAxe = false;


        if (health <= 0)
        {
            gameManager.Singleton.wood += 2;
            Destroy(gameObject);
        }
    }
}
