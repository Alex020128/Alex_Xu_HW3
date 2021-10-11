using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentTrigger : MonoBehaviour
{
    private BoxCollider2D bc;

    public GameObject pd;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }

    void Start()
    {
        pd = GameObject.Find("playerDialogue");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player"))
            && (Input.GetKey(KeyCode.E))
            && (playerDialogue.Singleton.lightFire == true))
        {
            Movement.Singleton.tentCollide = true;
        } else
        {
            Movement.Singleton.tentCollide = false;
        }
    }
}
