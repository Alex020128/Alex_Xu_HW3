using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothArea : MonoBehaviour
{

    public Animator animator;
    private PolygonCollider2D pc;
    public float health;
    public bool invincible;
    public bool colliding;

    private void Awake()
    {
        pc = GetComponent<PolygonCollider2D>();
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
        if (collision.CompareTag("playerArea")){
            colliding = true;
        } else
        {
            colliding = false;
        }
    }

    void getHurt() { 
    if (colliding == true && Movement.Singleton.attacking == true && invincible == false){
            health -= 1;
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
