using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2.0f;
    public Vector2 randomIntervalRange = new Vector2(2, 5); // Min and Max range for random interval

    private Animator animator;
    private int currentWaypointIndex = 0;
    private float changeWaypointTime = 0f;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isStill", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isAttacking", false);
            // Resume patrol movement animation
            UpdateMovementAnimation();
        }
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
