using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public float followSpeed;
    public float yPos;
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetPos = player.position;
        Vector2 smoothPos = Vector2.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        smoothPos.x = Mathf.Clamp(smoothPos.x,-7, 0);
        smoothPos.y = Mathf.Clamp(smoothPos.y, -0.5f, 0.5f);
        transform.position = new Vector3(smoothPos.x, smoothPos.y + yPos, -15.0f);
    }
}
