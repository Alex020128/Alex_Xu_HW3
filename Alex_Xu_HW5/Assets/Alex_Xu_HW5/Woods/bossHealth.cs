using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bossHealth : MonoBehaviour
{
    public int health;
    private TMP_Text healthCount;

    public bossArea bossAreaScript;

    private void Awake()
    {
        healthCount = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health = bossAreaScript.health;
        healthCount.text = health.ToString();
    }
}
