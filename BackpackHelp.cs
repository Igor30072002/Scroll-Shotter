using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackHelp : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Shooter shooter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            health.HPHelp();
            shooter.BulletHelp();
            Destroy(gameObject);
        }
    }
}
