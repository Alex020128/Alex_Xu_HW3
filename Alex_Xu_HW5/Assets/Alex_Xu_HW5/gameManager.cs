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
    public GameObject axeUI;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        wood = 0;
        startSpawn = false;
        stageTwo = false;

        axeUI = GameObject.Find("axeUI");

    }

    void showAxeUI()
    {
        if (Movement.Singleton.haveAxe == true)
        {
            axeUI.active = true;
        }
        else
        {
            axeUI.active = false;
        }
    }


    void spawnMoths()
    {
        if (startSpawn == true){

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

// Update is called once per frame
void Update()
    {
        moths = GameObject.FindGameObjectsWithTag("Moth");
        spawnMoths();
        showAxeUI();
    }
}
