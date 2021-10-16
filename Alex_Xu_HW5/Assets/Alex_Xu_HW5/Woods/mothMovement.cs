using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothMovement : MonoBehaviour
{

    public float followSpeed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1;
    private float nextFireTime;

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
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            rb.isKinematic = false;
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, followSpeed * Time.deltaTime);
        } else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            rb.isKinematic = true;
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
       
    }
}
