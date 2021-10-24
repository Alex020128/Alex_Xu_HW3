using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDialogue : MonoBehaviour
{
    public TMP_Text playerText;
    public bool getAxe;
    public bool lightFire;
    public bool bossSpawn;
    public bool win;

    public Movement movementScript;
    public Animator playerAnimator;
    public GameObject endings;


    public string[] dialogues = new string[] { "I dont' need this now...",
                                               "I should probably take this...",
                                               "I need more wood to light the fire...",
                                               "Now I need to get some food from the tent...",
                                               "What is that sound?",
                                               "What the fuck is this? I have to burn it.",
                                               "What have I done?",
                                               "Nom nom nom..."};

    public static playerDialogue Singleton;

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

        playerText = GetComponent<TMP_Text>();
        getAxe = false;
        lightFire = false;
        win = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        endings = GameObject.Find("Endings");
    }

    void axeDialogue()
    {
        if (movementScript.collideWith == "Axe")
        {
            if (getAxe == false)
            {
                playerText.text = dialogues[0];
            }

            if (getAxe == true)
            {
                playerText.text = dialogues[1];
                if (Input.GetKey(KeyCode.E))
                {
                    Movement.Singleton.haveAxe = true;
                }
            }
        }
    }

    void potDialogue()
    {
        if (movementScript.collideWith == "Pot")
        {
            if (gameManager.Singleton.bossKilled == false)
            {
                if (lightFire == false)
                {
                    playerText.text = dialogues[2];
                }

                if (lightFire == true)
                {
                    playerText.text = dialogues[3];
                }
            } else
            {
                playerText.text = dialogues[7];
                playerAnimator.SetBool("Eat", true);
                win = true;
                StartCoroutine(WaitForSec());
            }
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        endings.active = true;
        Endings.Singleton.win = true;
        gameObject.active = false;

    }

    void cocoonDialogue()
    {
        if (movementScript.collideWith == "Cocoon")
        {
            if (bossSpawn == false)
            {
                playerText.text = dialogues[5];
            }

            if (bossSpawn == true)
            {
                playerText.text = dialogues[6];
            }
        }
    }

    public void tentDialogue()
    {
        if (movementScript.collideWith == "Tent")
        {
            playerText.text = dialogues[4];
            if (Input.GetKey(KeyCode.E))
            {
                getAxe = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        axeDialogue();
        potDialogue();
        tentDialogue();
        cocoonDialogue();
    }
}
