using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeInOut : MonoBehaviour
{

    public float duration;
    public float counter;
    public CanvasGroup canvGroup;

    public void Awake()
    {
        canvGroup = GetComponent<CanvasGroup>();
        counter = 0;
        duration = 100f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canvGroup.alpha < 0.99 && Restart.Singleton.fadeIn == false)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(canvGroup.alpha, 1, counter / duration);
        }

        if (canvGroup.alpha >= 0.99 && Restart.Singleton.fadeIn == false)
        {
            counter = 0;
        }

        if (Restart.Singleton.fadeIn == true)
        {
            if (canvGroup.alpha >= 0.99)
            {
                counter += Time.deltaTime;
                canvGroup.alpha = Mathf.Lerp(canvGroup.alpha, 0, counter / duration);
            }
        }
    }
}