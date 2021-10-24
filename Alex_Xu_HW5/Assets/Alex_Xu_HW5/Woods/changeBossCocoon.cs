using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBossCocoon : MonoBehaviour
{

    public Animator animator;
    public GameObject boss;
    public GameObject bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        bossHealth = GameObject.Find("bossHealthNumber");
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.collider.gameObject.tag == "Player")
            && (gameManager.Singleton.wood >= 10)
            && (Input.GetKey(KeyCode.E)))
        {
            playerGoal.Singleton.bossStageTwo = true;
            gameManager.Singleton.stageTwo = true;
            playerDialogue.Singleton.bossSpawn = true;
            gameManager.Singleton.wood -= 10;
        }
    }


        void changeStages()
    {
        if (gameManager.Singleton.startSpawn == true)
        {
            animator.SetBool("stageOne", true);
        }
        else
        {
            animator.SetBool("stageOne", false);
        }

        if (gameManager.Singleton.stageTwo == true)
        {
            animator.SetBool("stageTwo", true);
        }
        else
        {
            animator.SetBool("stageTwo", false);
        }
    }


    void spawnBoss()
    {
        if (gameManager.Singleton.bossKilled == false)
        {
            if (gameManager.Singleton.stageTwo == true)
            {
                boss.active = true;
                bossHealth.active = true;
            }
            else
            {
                boss.active = false;
                bossHealth.active = false;
            }
        } else
        {
            boss.active = false;
            bossHealth.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeStages();
        spawnBoss();
    }
}
