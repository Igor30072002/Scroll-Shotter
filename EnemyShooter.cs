using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject fireBullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private EnemyController enemyController;
    private SpriteRenderer spriteRenderer;
    private float timer;

    private void Awake()
    {
        timer = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (enemyController.OnTrigger && enemyController.EnemyName == gameObject.name && !spriteRenderer.flipX && timer >= 1)
        {
            GameObject currentBullet = Instantiate(fireBullet, firePoint.position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
            currentBulletVelocity.velocity = new Vector2(-fireSpeed, currentBulletVelocity.velocity.y);
            timer = 0;
        }
        else if (enemyController.OnTrigger && enemyController.EnemyName == gameObject.name && spriteRenderer.flipX && timer >= 1)
        {
            GameObject currentBullet = Instantiate(fireBullet, firePoint.position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
            currentBulletVelocity.velocity = new Vector2(fireSpeed, currentBulletVelocity.velocity.y);
            timer = 0;
        }
    }
}
