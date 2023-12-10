using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded;

    [Header("Settings")]
    private SpriteRenderer heroSpriterenderer;
    private Transform groundColliderTransform;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask layerMask;
    private Animator animator;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        heroSpriterenderer = rb.GetComponent<SpriteRenderer>();
        groundColliderTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, layerMask);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }

        if(Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
        }
        else
        {
            animator.SetTrigger("IsIdle");
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            animator.SetTrigger("IsJumping");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else
        {
            animator.SetTrigger("IsIdle");
        }
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2 (curve.Evaluate(direction) * speed, rb.velocity.y);
        animator.SetTrigger("IsRunning");
        if (direction <= 0)
        {
            heroSpriterenderer.flipX = true;
        }
        else if (direction >= 0)
        {
            heroSpriterenderer.flipX = false;
        }
    }
}
