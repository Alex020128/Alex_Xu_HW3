using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motorTrigger : MonoBehaviour
{
    
    private BoxCollider2D bc;
    private WheelJoint2D wheelJoint2D;
    bool motorOn;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        wheelJoint2D = GameObject.Find("Motor").GetComponent<WheelJoint2D>();
        wheelJoint2D.useMotor = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            motorOn = true;
        }

    }

    void Update()
    {

        if (motorOn)
        {
            wheelJoint2D.useMotor = true;
        } else
        {
        }

    }
}
