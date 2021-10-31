using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSoundEffects : MonoBehaviour
{

    public static playerSoundEffects Singleton;

    public float volume;
    public float tempo;

    public AudioSource audioSource;

    public AudioClip walkSound;
    public AudioClip attackSound;
    public AudioClip fireAttackSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioClip pickUpSound;
    public AudioClip eatingSound;

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

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void walkSFX()
    {
        audioSource.Stop();
        audioSource.clip = walkSound;
        audioSource.Play();
    }
    public void pickUpSFX()
    {
        audioSource.Stop();
        audioSource.clip = pickUpSound;
        audioSource.Play();
    }
    public void attackSFX()
    {
        audioSource.Stop();
        audioSource.clip = attackSound;
        audioSource.Play();
    }
    public void fireAttackSFX()
    {
        audioSource.Stop();
        audioSource.clip = fireAttackSound;
        audioSource.Play();
    }
    public void hurtSFX()
    {
        audioSource.Stop();
        audioSource.clip = hurtSound;
        audioSource.Play();
    }
    public void deathSFX()
    {
        audioSource.Stop();
        audioSource.clip = deathSound;
        audioSource.Play();
    }
    public void eatingSFX()
    {
        audioSource.Stop();
        audioSource.clip = eatingSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

