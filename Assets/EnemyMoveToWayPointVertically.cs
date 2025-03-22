using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToWaypointVertically : MonoBehaviour
{
    [SerializeField] SpriteRenderer characterSpriteRenderer;
    [SerializeField] Animator characterAnimator;
    [SerializeField] private Rigidbody2D characterRigidbody;

    [SerializeField] private Transform[] waypoints;
    private int currentIndex = 0;
    private Transform currentWaypoint;

    [SerializeField] private FlyingBlockSO FlyingBlockSO;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float verticalDistance = Mathf.Abs(transform.position.y - currentWaypoint.position.y);

        // Check if we have reached the current waypoint (vertically)
        if (verticalDistance <= 0.3f)
        {
            // Update waypoint index to cycle between waypoints
            currentIndex = currentIndex == 0 ? 1 : 0;
            currentWaypoint = waypoints[currentIndex];
        }

        // Set vertical movement velocity based on distance to waypoint
        Vector2 movement = new Vector2(0, 0); // Start with no horizontal or vertical movement

        if (verticalDistance > 0.3f)
        {
            if (currentWaypoint.position.y > transform.position.y)
                movement.y = FlyingBlockSO.moveSpeed; // Move up
            else
                movement.y = -FlyingBlockSO.moveSpeed; // Move down
        }

        // Apply the vertical movement to the Rigidbody2D component
        characterRigidbody.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided with player");
        }
    }
}
