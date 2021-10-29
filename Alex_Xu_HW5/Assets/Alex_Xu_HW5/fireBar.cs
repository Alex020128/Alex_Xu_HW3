using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireBar : MonoBehaviour
{

    public static fireBar Singleton;

    public Image bar;

    public float duration;
    public float counter;

    public bool heat;

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

        bar.fillAmount = 0;
        counter = 0;
        heat = false;
        duration = 300;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Movement.Singleton.heating == true && heat == true)
        {
            counter += Time.deltaTime;
            bar.fillAmount = Mathf.Lerp(bar.fillAmount, 0, counter / duration);
        }
        else if (Movement.Singleton.heating == true && heat == false)
        {
            bar.fillAmount = 1;
            heat = true;
        }
        else
        {
            bar.fillAmount = 0;
            counter = 0;
            heat = false;
        }

    }
}
