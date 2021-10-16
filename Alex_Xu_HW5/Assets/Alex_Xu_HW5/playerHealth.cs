using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerHealth : MonoBehaviour
{

    public static playerHealth Singleton;
    public int health;
    private TMP_Text healthCount;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        healthCount = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthCount.text = health.ToString();
    }
}
