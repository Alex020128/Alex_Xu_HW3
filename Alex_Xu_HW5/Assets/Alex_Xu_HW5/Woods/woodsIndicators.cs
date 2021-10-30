using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodsIndicators : MonoBehaviour
{
    public static woodsIndicators Singleton;

    public GameObject ci;
    public GameObject mothCocoons;
    public GameObject bossArea;

    public float mothCocoonLeft;

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

        ci = GameObject.Find("cocoonIndicator");
        mothCocoons = GameObject.Find("mothCocoons");
        bossArea = GameObject.Find("bossArea");

        mothCocoonLeft = 3;
    }


    // Start is called before the first frame update
    void Start()
    {
        ci.active = false;
    }

    public void cocoonIndicator()
    {
        if (playerGoal.Singleton.mothSpawn == true)
        {
            ci.active = true;
            if (playerGoal.Singleton.bossStageTwo == true)
            {
                ci.active = false;
            }
        }
    }
    void spawnCocoons()
    {
        if (bossArea.GetComponentInChildren<bossArea>().health <= 50)
        {
            mothCocoons.active = true;
        }
        else
        {
            mothCocoons.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cocoonIndicator();
        spawnCocoons();

        if (mothCocoonLeft > 0 && bossArea.GetComponent<bossArea>().health <= 50)
        {
            bossArea.GetComponent<bossArea>().cantHurt = true;
            playerGoal.Singleton.bossStageThree = true;
        }
        else if (mothCocoonLeft == 0 && bossArea.GetComponent<bossArea>().health <= 50)
        {
            bossArea.GetComponent<bossArea>().cantHurt = false;
            playerGoal.Singleton.bossStageFour = true;
        }else
        {
            bossArea.GetComponent<bossArea>().cantHurt = false;
        }
    }
}
