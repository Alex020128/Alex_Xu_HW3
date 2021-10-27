using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Endings : MonoBehaviour
{
    public TMP_Text endingText;

    public bool die;
    public bool win;

    public string[] endings = new string[] { "You died...\nPress R to restart.",
                                             "What a nice way to start a day!\nPress R to restart."};

    public static Endings Singleton;
    public GameObject pd;
    public GameObject ph;
    public GameObject phUI;

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

        endingText = GetComponent<TMP_Text>();
        pd = GameObject.Find("playerDialogue");
        ph = GameObject.Find("healthNumber");
        phUI = GameObject.Find("healthUI");

    }

    // Start is called before the first frame update
    void Start()
    {
        endingText.text = endingText.text.Replace("\\n", "\n");
        die = false;
        win = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (die == true)
        {
            endingText.text = endings[0];
            StartCoroutine(WaitForSec());
        }

        if (win == true)
        {
            endingText.text = endings[1];
            StartCoroutine(WaitForSec());
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);

            ph.active = false;
            phUI.active = false;
            pd.active = false;

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("mainMenu");
        }
    }

}
