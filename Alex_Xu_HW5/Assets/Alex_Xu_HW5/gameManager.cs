using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager Singleton;

    public int wood;
    public bool startSpawn;
    public bool stageTwo;
    public bool bossKilled;
    public bool playerDies;
    public GameObject axeUI;
    public GameObject blackScreen;
    public GameObject noon;
    public GameObject bar;
    public GameObject[] moths;

void Awake()
    {
        if (Singleton == null) 
        {
            Singleton = this;
        } else
        {
            Destroy(this.gameObject);
        }

        noon = GameObject.Find("Noon");
        bar = GameObject.Find("fireBar");
    }

    // Start is called before the first frame update
    void Start()
    {
        wood = 0;
        startSpawn = false;
        stageTwo = false;
        bossKilled = false;
        playerDies = false;

        axeUI = GameObject.Find("axeUI");
        blackScreen = GameObject.Find("blackScreen");

    }

    void showAxeUI()
    {
        if (Movement.Singleton.haveAxe == true && playerDies == false && playerDialogue.Singleton.win == false && playerGoal.Singleton.bossStageTwo == false)
        {
            axeUI.active = true;
            bar.active = false;
        } else if(Movement.Singleton.haveAxe == true && playerDies == false && playerDialogue.Singleton.win == false && playerGoal.Singleton.bossStageTwo == true)
            {
            axeUI.active = true;
            bar.active = true;
        } else
        {
            axeUI.active = false;
            bar.active = false;
        }
    }


    void spawnMoths()
    {
        if (startSpawn == true && gameManager.Singleton.bossKilled == false)
        {

            if(SceneManager.GetActiveScene().name == "Woods")
            {
                playerGoal.Singleton.mothSpawn = true;
            }

            foreach (GameObject moth in moths)
            {
                moth.active = true;
            }
        } else
        {
            foreach (GameObject moth in moths)
            {
                moth.active = false;
            }
        }
    }

    void Die()
    {
        if (gameManager.Singleton.playerDies == true)
        {
            blackScreen.active = true;
        }
        else
        {
            blackScreen.active = false;
        }
    }

    void heatedAxe()
    {
        if(wood >= 1 && playerDialogue.Singleton.bossSpawn == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                wood -= 1;
                Movement.Singleton.heating = true;
                StartCoroutine(WaitForSec());
            }
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(4);
        Movement.Singleton.heating = false;
    }

    void Noon()
    {
        if (bossKilled == true)
        {
            noon.active = true;
        }
        else
        {
            noon.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moths = GameObject.FindGameObjectsWithTag("Moth");
        spawnMoths();
        showAxeUI();
        heatedAxe();
        Die();
        Noon();
    }
}
