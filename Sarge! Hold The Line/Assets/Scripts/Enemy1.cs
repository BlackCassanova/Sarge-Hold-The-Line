using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public float speed;
    public float stopDistance;
    public float retreatDistance;

    private float timebetweenshots;
    public float starttimebetweenshots;
    
    public GameObject bullet;
    private Transform player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timebetweenshots =starttimebetweenshots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        {
        	transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
             
        }

        else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance )
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, (-speed/2) * Time.deltaTime);
        }

        if (timebetweenshots <=0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity );
            timebetweenshots = starttimebetweenshots; 
        }
        else
        {
            timebetweenshots -= Time.deltaTime;
        }
    }
}
