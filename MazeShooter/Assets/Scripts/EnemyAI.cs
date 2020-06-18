using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private string currentState = "Patrol";

    public Transform waypoint1;

    public Transform waypoint2;

    public float speed;

    public float range = 15;

    public LayerMask mask;

    private Transform nextWaypoint;

    // Shooting Mechanics
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;

        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == "Patrol")
        {
            Vector2 nextPosition = Vector2.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime * speed);
            transform.position = nextPosition;
            if(transform.position == nextWaypoint.position)
            {
                if(nextWaypoint == waypoint1)
                {
                    nextWaypoint = waypoint2;
                } 
                else
                {
                    nextWaypoint = waypoint1;
                }
            }
            else if (TargetAquired())
            {
                currentState = "Attack";
            }
        } 
        
        else if (currentState == "Attack")
        {
            if (TargetAquired())
            {
                if (timeBetweenShots <= 0)
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                    timeBetweenShots = startTimeBetweenShots;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
            }
            if (!TargetAquired())
            {
                currentState = "Patrol";
            }
        }
    }

    bool TargetAquired()
    {
        GameObject targetGO = GameObject.FindGameObjectWithTag("Player");
        bool inRange = false;
        bool inVision = false;

        if(Vector2.Distance(targetGO.transform.position, transform.position) < range)
        {
            inRange = true;
        }

        var linecast = Physics2D.Linecast(transform.position, targetGO.transform.position, mask);
        if(linecast.transform == null)
        {
            inVision = true;
        }

        return inRange && inVision;
    }
}
