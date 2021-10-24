using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothBullet : MonoBehaviour
{

    GameObject target;
    public float bulletSpeed;
    Rigidbody2D rb;
    public Animator animator;

    private CircleCollider2D cc;

    private void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
        cc.isTrigger = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        animator = target.GetComponent<Animator>();
        Vector2 moveDir = (target.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("playerArea")) && (Movement.Singleton.invincible == false) && (gameManager.Singleton.playerDies == false))
        {
            playerHealth.Singleton.health -= 1;
            Movement.Singleton.invincible = true;
            animator.SetTrigger("getHurt");

            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
