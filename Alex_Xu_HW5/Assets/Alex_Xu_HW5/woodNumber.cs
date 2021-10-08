using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class woodNumber : MonoBehaviour
{

    private TMP_Text woodCount;

    private void Awake()
    {
        woodCount = GetComponent<TMP_Text>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodCount.text = gameManager.Singleton.wood.ToString();
    }
}
