using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public static Restart Singleton;

    public float duration;
    public float counter;
    public CanvasGroup canvGroup;

    public bool fadeIn;
    public bool fadeOut;

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        canvGroup = GetComponent<CanvasGroup>();
        counter = 0;
        duration = 100f;

        fadeIn = false;
        fadeOut = false;


        DontDestroyOnLoad(this.gameObject);
    }


    private void Update()
    {

        if (fadeIn == true && fadeOut == false)
        {
            if (canvGroup.alpha <0.99)
            {
                counter += Time.deltaTime;
                canvGroup.alpha = Mathf.Lerp(canvGroup.alpha, 1, counter / duration);

            } else
            {
                SceneManager.LoadScene("mainMenu");
                counter = 0;
                fadeOut = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "mainMenu")
        {
            if (canvGroup.alpha >= 0.01)
            {
                counter += Time.deltaTime;
                canvGroup.alpha = Mathf.Lerp(canvGroup.alpha, 0, counter / duration);

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

}
