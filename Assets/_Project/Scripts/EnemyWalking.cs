using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints for the enemy to walk between
    public float speed = 2f; // Speed of the enemy
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool movingForward = true; // Direction of movement

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (waypoints.Length > 1)
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector2 direction = targetWaypoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        // Flip the sprite based on movement direction
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }

        // Check if the enemy has reached the target waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (movingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    movingForward = true;
                }
            }
        }
    }
}
