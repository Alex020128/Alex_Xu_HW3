using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerHealth : MonoBehaviour
{

    public static playerHealth Singleton;
    public int health;
    private TMP_Text healthCount;
    public Animator playerAnimator;
    public GameObject player;
    public GameObject healthUI;
    public GameObject endings;

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
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        player = GameObject.Find("Player");
        healthUI = GameObject.Find("healthUI");
        endings = GameObject.Find("Endings");
        endings.active = false;
    }
   
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        endings.active = true;
        Endings.Singleton.die = true;
        healthUI.active = false;
        gameObject.active = false;
    }


    // Update is called once per frame
    void Update()
    {
        healthCount.text = health.ToString();

        if(health <= 0)
        {
            gameManager.Singleton.playerDies = true;
            player.GetComponent<SpriteRenderer>().sortingOrder = 3;
            playerAnimator.SetBool("Die", true);
            StartCoroutine(WaitForSec());
        }
    }
}
