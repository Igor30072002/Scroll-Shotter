using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacleController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer buttonSR1;
    [SerializeField] private SpriteRenderer buttonSR2;
    [SerializeField] private Animator obstacleAnimator;
    [SerializeField] private Collider2D buttonCollider1;
    [SerializeField] private Collider2D buttonCollider2;

    private void ObstacleController(Collider2D buttonCollider)
    {
        if (!buttonSR1.flipX && buttonCollider1 == buttonCollider)
        {
            buttonSR1.flipX = true;
            obstacleAnimator.SetTrigger("Up");
        }
        else if (!buttonSR2.flipX && buttonCollider2 == buttonCollider)
        {
            buttonSR2.flipX = true;
            obstacleAnimator.SetTrigger("Down");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObstacleController(collision);
    }
}
