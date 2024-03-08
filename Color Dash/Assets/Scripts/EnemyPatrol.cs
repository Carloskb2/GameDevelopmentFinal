using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2.0f;
    public Vector2 randomIntervalRange = new Vector2(2, 5); // Min and Max range for random interval
    [Header("Collider:")]
    [SerializeField]
    private Collider2D attackCollider;
    private Animator animator;
    private int currentWaypointIndex = 0;
    private float changeWaypointTime = 0f;
    private bool isTurningAround = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetNextChangeWaypointTime();
    }

    void Update()
    {
        MoveAndFlipSprite();

        if (Time.time >= changeWaypointTime)
        {
            SetRandomWaypoint();
            SetNextChangeWaypointTime();
        }


    }

    private void SetRandomWaypoint()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    private void SetNextChangeWaypointTime()
    {
        changeWaypointTime = Time.time + Random.Range(randomIntervalRange.x, randomIntervalRange.y);
    }
    private void MoveAndFlipSprite()
    {
        if (isTurningAround)
        {
            return; // Skip the rest of the method
        }

        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isStill", false);  // Enemy is moving
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isStill", true);   // Enemy is stationary
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        if (direction.x > 0)
        {
            transform.localScale = new Vector3((float)0.2,(float) 0.2,(float) 0.2);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3((float)-0.2, (float)0.2, (float)0.2);
        }
    }

    private void OnTriggerEnter2D(Collider2D attackColider)
    {
        if (attackColider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isStill", false);
        }
    }
    
    private void OnTriggerExit2D(Collider2D attackCollider)
    {
        if (attackCollider.gameObject.CompareTag("Player"))
        {
            print("Attack");
            animator.SetBool("isAttacking", false);
            // Resume patrol movement animation
            UpdateMovementAnimation();
        }

    }

    public void TurnAround()
    {
        print("turn");
        isTurningAround = true; // Enable turn around mode

        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        // Flip the enemy to face the opposite direction
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

        StartCoroutine(ResetTurnAround()); // Reset after a delay
    }

    private IEnumerator ResetTurnAround()
    {
        yield return new WaitForSeconds(1f); // Delay before resetting, adjust as needed
        isTurningAround = false;
    }

    void OnEnable()
    {
        PlayerHealth.OnPlayerDestroyed += HandlePlayerRespawned;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDestroyed -= HandlePlayerRespawned;
    }

    private void HandlePlayerRespawned()
    {
        animator.SetBool("isAttacking", false);
        UpdateMovementAnimation();
    }

    private void UpdateMovementAnimation()
    {
        // Check if the enemy is close to the current waypoint
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) > 0.1f)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isStill", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isStill", true);
        }
    }


}
