using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothCocoon : MonoBehaviour
{

    public Animator animator;
    private PolygonCollider2D pc;
    public int health;
    public bool invincible;

    public bool collidingAxe;
    public bool canSpawn;
    public bool counterOn;

    public GameObject moth;
    
    public float counter;

    public List<GameObject> moths = new List<GameObject>();

    private void Awake()
    {
        pc = GetComponent<PolygonCollider2D>();
        pc.isTrigger = true;
        canSpawn = true;
        counter = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        invincible = false;
        animator = GetComponent<Animator>();

        transform.position = new Vector3(Random.Range(-39, 7), Random.Range(-13, 10), 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("playerAttackUpArea") || collision.CompareTag("playerAttackDownArea"))
        {
            collidingAxe = true;
        }
        else
        {
            collidingAxe = false;
        }
    }

    void getHurt()
    {
        if (collidingAxe == true && Movement.Singleton.attacking == true && invincible == false)
        {
            if (Movement.Singleton.heating == false)
            {
                health -= 1;
            }
            else
            {
                health -= 2;
            }
            animator.SetTrigger("getHurt");
            invincible = true;
            StartCoroutine(WaitForSec());
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
        invincible = false;
    }


    void spawnMoth()
    {
        if (moths.Count < 3 && canSpawn == true)
        {
            GameObject spawnedMoth = Instantiate(moth, gameObject.transform.position, Quaternion.identity);
            moths.Add(spawnedMoth);
            canSpawn = false;
            counter = 0;
        }

        if (counter >= 7)
        {
            canSpawn = true;
            counter = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        getHurt();

        spawnMoth();

        counter += Time.deltaTime;

        collidingAxe = false;

        if (health <= 0)
        {
            foreach (GameObject moth in moths)
            {
                moth.GetComponentInChildren<spawnedMothArea>().mothCocoonExist = false;
            }
            Destroy(gameObject);
        }
    }
}
