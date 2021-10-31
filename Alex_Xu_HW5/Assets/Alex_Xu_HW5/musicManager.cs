using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{

    public static musicManager Singleton;

    public float volume;
    public float tempo;

    public AudioSource audioSource;

    public AudioClip currentMusic;

    public AudioClip woodsMusic;
    public AudioClip woodsMusicMonster;
    public AudioClip bossMusic;

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

    // Update is called once per frame
    void Update()
    {
        if(playerGoal.Singleton.mothSpawn == false)
        {
            audioSource.clip = woodsMusic;
        }

        if (playerGoal.Singleton.mothSpawn == true && playerGoal.Singleton.bossStageTwo == false && currentMusic != woodsMusicMonster)
        {
            audioSource.Stop();
            audioSource.clip = woodsMusicMonster;
            audioSource.Play();
            currentMusic = woodsMusicMonster;
        }

        if (playerGoal.Singleton.bossStageTwo == true && gameManager.Singleton.bossKilled == false && currentMusic != bossMusic)
        {
            audioSource.Stop();
            audioSource.clip = bossMusic;
            audioSource.Play();
            currentMusic = bossMusic;
        }

        if (gameManager.Singleton.bossKilled == true && currentMusic != woodsMusic)
        {
            audioSource.Stop();
            audioSource.clip = woodsMusic;
            audioSource.Play();
            currentMusic = woodsMusic;
        }
    }
}
