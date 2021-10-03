using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{

    private BoxCollider2D bc;
    public bool triggerOn;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            triggerOn = true;
        }

    }
}
