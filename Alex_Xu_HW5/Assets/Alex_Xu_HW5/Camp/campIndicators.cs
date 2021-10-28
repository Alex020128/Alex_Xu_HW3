using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campIndicators : MonoBehaviour
{

    public static campIndicators Singleton;

    public GameObject ai;
    public GameObject pi;
    public GameObject ti;

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        ai = GameObject.Find("axeIndicator");
        pi = GameObject.Find("potIndicator");
        ti = GameObject.Find("tentIndicator");

    }


    // Start is called before the first frame update
    void Start()
    {
        ai.active = false;
        pi.active = false;
        ti.active = false;
    }

    public void axeIndicator()
    {
        if (playerGoal.Singleton.equipAxe == true && Movement.Singleton.haveAxe != true)
        {
            ai.active = true;
            if (Movement.Singleton.collideWith == "Axe")
            {
                ai.active = false;
            }
        }
    }

    public void potIndicator()
    {
            pi.active = true;
            if (playerGoal.Singleton.collectFood == true)
            {
                pi.active = false;
                if (gameManager.Singleton.bossKilled == true)
                {
                    pi.active = true;
                    if (Movement.Singleton.collideWith == "Pot")
                    {
                        pi.active = false;
                    }
                }
            }
    }

    public void tentIndicator()
    {
        if (playerGoal.Singleton.collectFood == true && Movement.Singleton.collideWith != "Axe" && Movement.Singleton.haveAxe != true)
        {
            ti.active = true;
            if (Movement.Singleton.collideWith == "Tent")
            {
                ti.active = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        axeIndicator();
        potIndicator();
        tentIndicator();
    }
}
