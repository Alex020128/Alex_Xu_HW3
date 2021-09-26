using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour
{
      
    public float xPos;
    public float yPos;
    public float zPos;
    public Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        xPos = Random.Range(-30, 30);
        yPos = Random.Range(-30, 30);
        zPos = 0;
        pos = new Vector3(xPos, yPos, zPos);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
