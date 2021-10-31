using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePot : MonoBehaviour
{

    public Animator animator;

    public AudioSource audioSource;

    public AudioClip burningSound;

    public AudioClip currentMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.collider.gameObject.tag == "Player") 
            && (gameManager.Singleton.wood >= 5)
            && (Input.GetKey(KeyCode.E)))
        {
            playerGoal.Singleton.collectFood = true;
            playerDialogue.Singleton.lightFire = true;
            gameManager.Singleton.wood -= 5;
        }
    }

    void woodGiven()
    {
        if (playerDialogue.Singleton.lightFire == true)
        {
            animator.SetBool("woodGiven", true);
        }
        else
        {
            animator.SetBool("woodGiven", false);
        }
    }

    public void burningSFX()
    {
        if (playerDialogue.Singleton.lightFire == true &&  currentMusic != burningSound)
        {
            audioSource.Stop();
            audioSource.clip = burningSound;
            audioSource.Play();
            currentMusic = burningSound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        woodGiven();

        burningSFX();
    }
}
