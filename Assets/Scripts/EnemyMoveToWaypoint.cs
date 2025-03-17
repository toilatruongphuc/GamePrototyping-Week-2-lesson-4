using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveToWaypoint : MonoBehaviour
{
    [SerializeField] SpriteRenderer characterSpriteRenderer;
    [SerializeField] Animator characterAnimator;
    [SerializeField] private Rigidbody2D characterRigidbody;

    [SerializeField] private Transform[] waypoints;
    private int currentIndex = 0;
    private Transform currentWaypoint;

    [SerializeField] private EnemySO enemySO;
    private int moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints[currentIndex];
        moveDirection = currentWaypoint.position.x - transform.position.x < 0 ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorHandle();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //if (Vector2.Distance(waypoint1.position, transform.position) <= 0.1)
        //{
        //    moveDirection = -1;
        //}
        //if (Vector2.Distance(waypoint2.position, transform.position) <= 0.1)
        //{
        //    moveDirection = 1;
        //}
        if (Vector2.Distance(transform.position, currentWaypoint.position) <= 0.3f)
        {
            currentIndex = currentIndex == 0 ? 1 : 0;
            currentWaypoint = waypoints[currentIndex];
            moveDirection = currentWaypoint.position.x - transform.position.x < 0 ? -1 : 1;
        }
        characterRigidbody.velocity = new Vector2(moveDirection * enemySO.moveSpeed, characterRigidbody.velocity.y);
    }
    private void AnimatorHandle()
    {
        
        if (characterRigidbody.velocity.x > 0.01)
        {
            characterSpriteRenderer.flipX = false;
        }
        else if (characterRigidbody.velocity.x < -0.01)
        {
            characterSpriteRenderer.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player hit");
        }
    }
}
