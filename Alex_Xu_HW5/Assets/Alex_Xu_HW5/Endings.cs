using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Endings : MonoBehaviour
{
    public TMP_Text endingText;

    public bool die;
    public bool win;


    public string[] endings = new string[] { "You died...\nPress R to restart.",
                                             "What a nice way to start a day!\nPress R to restart."};

    public static Endings Singleton;

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
        }

        if (win == true)
        {
            endingText.text = endings[1];
        }
    }
}
