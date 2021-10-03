using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class cameraFollow : MonoBehaviour
{

    public float followSpeed;
    public float yPos;
    private Transform focus;
    public Text text;
    public GameObject Text;


    // Start is called before the first frame update
    void Start()
    {
        focus = GameObject.Find("Circle_1").transform;
        Text = GameObject.Find("Text");
        Text.active = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetPos = focus.position;
        Vector2 smoothPos = Vector2.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        transform.position = new Vector3(smoothPos.x, smoothPos.y + yPos, -15.0f);



        if (Input.GetKey(KeyCode.Space))
        {
            focus = GameObject.Find("Circle_2").transform;
            GameObject.Find("Platform").active = false;
        }

        if (GameObject.Find("Trigger_1").GetComponent<trigger>().triggerOn == true)
        {
            focus = GameObject.Find("Circle_3").transform;
        }
        if (GameObject.Find("Trigger_2").GetComponent<trigger>().triggerOn == true)
        {
            focus = GameObject.Find("Circle_4").transform;
        }
        if (GameObject.Find("Trigger_3").GetComponent<trigger>().triggerOn == true)
        {
            followSpeed = 3;
            focus = GameObject.Find("Circle_5").transform;
        }
        if (GameObject.Find("Trigger_4").GetComponent<trigger>().triggerOn == true)
        {
            focus = GameObject.Find("Circle_6").transform;
        }
        if (GameObject.Find("Trigger_5").GetComponent<trigger>().triggerOn == true)
        {
            focus = GameObject.Find("Circle_7").transform;
        }
        if (GameObject.Find("Trigger_7").GetComponent<trigger>().triggerOn == true)
        {
            followSpeed = 6;
        }
        if (GameObject.Find("Trigger_6").GetComponent<trigger>().triggerOn == true)
        {
            followSpeed = 18;
        }
        
        if (GameObject.Find("Trigger_8").GetComponent<trigger>().triggerOn == true)
        {

            StartCoroutine(WaitForSec());

        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Text.active = true;
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
