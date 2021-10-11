using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePot : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.collider.gameObject.tag == "Player") 
            && (gameManager.Singleton.wood >= 5)
            && (Input.GetKey(KeyCode.E)))
        {
            animator.SetTrigger("woodGiven");
            playerDialogue.Singleton.lightFire = true;
            gameManager.Singleton.wood = 0;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
