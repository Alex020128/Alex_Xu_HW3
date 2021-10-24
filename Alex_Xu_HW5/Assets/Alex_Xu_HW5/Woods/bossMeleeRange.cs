using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMeleeRange : MonoBehaviour
{

    private PolygonCollider2D pc;
    public Animator playerAnimator;
    public bossMovement bossMovementScript;

    public bool colliding;


    private void Awake()
    {
        pc = GetComponent<PolygonCollider2D>();
        pc.isTrigger = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("playerArea"))
        {
           colliding = true;
        }
        else
        {
           colliding = false;
        }
    }

        void meleeAttack()
        {
            if (colliding == true && bossMovementScript.damaging == true && Movement.Singleton.invincible == false && gameManager.Singleton.playerDies == false)
            {
                playerHealth.Singleton.health -= 3;
            bossMovementScript.damaging = false;
                Movement.Singleton.invincible = true;
                playerAnimator.SetTrigger("getHurt");
        }
        }

        // Update is called once per frame
        void Update()
    {
        meleeAttack();
    }
}
