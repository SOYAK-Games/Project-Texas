using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Interfaces;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    // Reference to the player game object
    public GameObject player;

    // Reference to the NavMeshAgent component
    internal NavMeshAgent navAgent;

    // List of waypoints for the enemy to patrol between
    public List<Transform> waypoints;

    // Index of the current waypoint in the list
    private int currentWaypointIndex = 0;

    // Distance at which the enemy will start chasing the player
    public float detectionDistance = 5f;

    // Boolean indicating whether the enemy is currently patrolling
    internal bool isPatrolling = true;

    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform firePoint; // Point where the bullet is spawned
    public float shootingRate = 3f; // How often the enemy shoots
    public float bulletSpeed = 10f; // Speed of the bullet
    [SerializeField] private GameObject _bulletTrail;
    public float weaponRange = 10f;
    private Vector2 endPosition;
    public float bulletForce=100f;

    public float attackDistance = 3f; // Distance at which the enemy attacks the player

    private Transform target; // Player object
    private float shootingTimer = 0f; // Timer for shooting

    public SpriteRenderer _spriteRenderer;
    public Sprite _newSprite;
    public bool isDead = false;
    

    private GameManager gameManager;





    private bool PlayerIsInRange()
    {
        return Vector2.Distance(transform.position, target.position) <= detectionDistance;
    }

    private void FaceTarget()
    {
        Vector2 direction = Quaternion.Euler(0, 0, 90) * (target.position - transform.position).normalized;
        transform.up = direction;
    }

    private void Shoot()
    {
        var hit = Physics2D.Raycast(firePoint.position, transform.right, weaponRange);
        var trail = Instantiate(_bulletTrail, firePoint.position, transform.rotation);
        var trailscript = trail.GetComponent<BulletTrail>();
        if (hit.collider != null)
        {
            trailscript.SetTargetPosition(hit.point);
            var hittable = hit.collider.GetComponent<IHittable>();
            if (hittable != null)
            {
                hittable?.ReceiveHit();
            }
        }
        else
        {
            var endPosition = firePoint.position + transform.right * weaponRange;
            trailscript.SetTargetPosition(endPosition);
        }
    }

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Find player object
        // Get the NavMeshAgent component
        gameManager = GameObject.FindObjectOfType<GameManager>();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false; 
        navAgent.updateUpAxis = false;
        // Set the first waypoint as the destination
        navAgent.SetDestination(waypoints[currentWaypointIndex].position);
        Vector2 direction = target.position - firePoint.position;
        direction.Normalize();
        endPosition = (Vector2)firePoint.position + (direction * weaponRange);
    }

    private void FixedUpdate()
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
        if (PlayerIsInRange())
        {
            FaceTarget();
            if (Vector2.Distance(transform.position, target.position) <= attackDistance)
            {
                shootingTimer += 1;

                if (shootingTimer <= shootingRate)
                {
                    Shoot();
                    shootingTimer = 0f;
                }
                else
                {
                    return;
                }
            }
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

    public void ChangeSprite()
    {
        if (!isDead)
        {
            isDead = true;
            GetComponent<SpriteRenderer>().sprite = _newSprite;
            gameManager.IncreaseDeadEnemyCount();
        }

        _spriteRenderer.sprite = _newSprite;
      
        
    }

    
}









