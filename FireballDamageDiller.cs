using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDamageDiller : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null && collision.CompareTag("Hero"))
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}