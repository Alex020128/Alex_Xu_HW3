using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodsIndicators : MonoBehaviour
{
    public static woodsIndicators Singleton;

    public GameObject ci;

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
            if (Movement.Singleton.collideWith == "Cocoon")
            {
                ci.active = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        cocoonIndicator();
    }
}
