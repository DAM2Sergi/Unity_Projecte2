using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;


    [SerializeField] public Transform playerCheck;
    [SerializeField] public LayerMask playerLayer;



    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update

    bool playerFollow(){

        return Physics2D.OverlapCircle(playerCheck.position, 20f, playerLayer);

    }

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

        
    }


    void UpdatePath()
    {
        if (seeker.IsDone()&&playerFollow())seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= Mathf.Epsilon)
        {

            enemyGFX.localScale = new Vector3(4f, 4f, 1f);
            //Que es Mathf.Epsilon?
            //El numero mes petit float diferent a zero 

        }
        else if (rb.velocity.x <= -Mathf.Epsilon)
        {

            enemyGFX.localScale = new Vector3(-4f, 4f, 1f);

        };
    }
}
