using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothMovement : MonoBehaviour
{

    public float followSpeed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 3;
    private float nextFireTime;
    public Animator animator;

    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    public Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    
    
    
    
    
    // Update is called once per frame
    void Update()
    {

        string clipName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            rb.isKinematic = false;
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, followSpeed * Time.deltaTime);
        } else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time && clipName != "mothHurts")
        {
            rb.isKinematic = true;
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
       
    }
}
