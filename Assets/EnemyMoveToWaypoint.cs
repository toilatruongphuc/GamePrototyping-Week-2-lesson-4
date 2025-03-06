using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToWaypoint : MonoBehaviour
{
    [SerializeField] SpriteRenderer characterSpriteRenderer;
    [SerializeField] Animator characterAnimator;
    [SerializeField] private Rigidbody2D characterRigidbody;
    [SerializeField] Transform waypoint1;
    [SerializeField] Transform waypoint2;
    [SerializeField] float movespeed;
    private int moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = 1;
}

    // Update is called once per frame
    void Update()
    {
        Move();
        AnimatorHandle();
    }
    void Move()
    {
        characterRigidbody.velocity = new Vector2(moveDirection * movespeed, characterRigidbody.velocity.y);
        if (Vector2.Distance(waypoint1.position, transform.position) <= -0.01)
        {
            moveDirection = 1;
        }
        else if (Vector2.Distance(waypoint2.position, transform.position) <= -0.01)
        {
            moveDirection = -1;
        }
    }
    private void AnimatorHandle()
    {
        characterAnimator.SetFloat("moveX", Mathf.Abs(characterRigidbody.velocity.x));
        if (characterRigidbody.velocity.x > 0.01)
        {
            characterSpriteRenderer.flipX = false;
        }
        else if (characterRigidbody.velocity.x < -0.01)
        {
            characterSpriteRenderer.flipX = true;
        }
    }
}
