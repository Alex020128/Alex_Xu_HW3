using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Singleton;

    public int wood;
    public bool startSpawn;
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
        
    }



    void spawnMoths()
    {
        if (startSpawn == true){
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
    }
}
