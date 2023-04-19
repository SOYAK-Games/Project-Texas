using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Reference to the player game object
    public GameObject player;

    // Reference to the NavMeshAgent component
    NavMeshAgent navAgent;

    // List of waypoints for the enemy to patrol between
    public List<Transform> waypoints;

    // Index of the current waypoint in the list
    private int currentWaypointIndex = 0;

    // Distance at which the enemy will start chasing the player
    public float detectionDistance = 5f;

    // Boolean indicating whether the enemy is currently patrolling
    private bool isPatrolling = true;
 

    void Start()
    {
        
        // Get the NavMeshAgent component
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false; 
        navAgent.updateUpAxis = false;
        // Set the first waypoint as the destination
        navAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= detectionDistance)
        {
            // The player is within range, stop patrolling and start chasing
            isPatrolling = false;
            navAgent.SetDestination(player.transform.position);
        }
        else if (isPatrolling)
        {
            // The player is out of range and the enemy is still patrolling
            Patrol();
        }

        // If the enemy has reached its destination, move to the next waypoint
        if (navAgent.remainingDistance <= navAgent.stoppingDistance && !navAgent.pathPending)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            navAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    // Function to make the enemy patrol between waypoints
    void Patrol()
    {
        // If the enemy is close enough to the current waypoint, move to the next one
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) <= navAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            navAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}









