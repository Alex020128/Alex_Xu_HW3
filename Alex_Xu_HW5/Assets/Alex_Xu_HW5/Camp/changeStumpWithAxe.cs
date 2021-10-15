using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeStumpWithAxe : MonoBehaviour
{

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void axeTaken()
    {
        if (Movement.Singleton.haveAxe == true)
        {
            animator.SetBool("axeTaken", true);
        }
        else
        {
            animator.SetBool("axeTaken", false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        axeTaken();
    }
}
