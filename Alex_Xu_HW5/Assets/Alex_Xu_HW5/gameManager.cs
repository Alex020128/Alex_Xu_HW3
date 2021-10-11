using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Singleton;

    public int wood;
    
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
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
