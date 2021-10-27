using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public float duration;
    public float counter;
    public CanvasGroup canvGroup;
    public GameObject playButton;

    public bool fade;


    // Start is called before the first frame update
    public void Awake()
    {
        canvGroup = GetComponent<CanvasGroup>();
        counter = 0;
        duration = 100f;
        fade = false;
    }

    public void Fade()
    {
        fade = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade == true) {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(canvGroup.alpha, 0, counter / duration);
        }

        if (canvGroup.alpha <= 0.01)
        {
            SceneManager.LoadScene("Camp");
        }
    }
}
