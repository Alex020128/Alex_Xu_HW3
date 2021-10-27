using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroy : MonoBehaviour
{
    public static dontDestroy Singleton;


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
        DontDestroyOnLoad(this.gameObject);
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "mainMenu")
        {
            Destroy(this.gameObject);
        }
    }

}
