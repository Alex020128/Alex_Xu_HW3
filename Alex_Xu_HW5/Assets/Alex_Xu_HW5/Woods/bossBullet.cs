using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{

    GameObject target;
    public float bulletSpeed;
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
        target = GameObject.Find("Player");
        animator = target.GetComponent<Animator>();
        Destroy(this.gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("playerArea")) && (Movement.Singleton.invincible == false) && (gameManager.Singleton.playerDies == false))
        {
            playerHealth.Singleton.health -= 2;
            animator.SetTrigger("getHurt");
            Movement.Singleton.invincible = true;
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
    }
}
