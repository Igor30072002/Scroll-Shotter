using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDiller : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private GameObject crystal;
    [SerializeField] private GameObject pill;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
            if (!collision.gameObject.GetComponent<Health>().IsAlive)
            {
                GameObject currentCrystal = Instantiate(crystal, collision.gameObject.transform.position, Quaternion.identity);
                Rigidbody2D currentCrystalVelocity = currentCrystal.GetComponent<Rigidbody2D>();
                Destroy(collision.gameObject);
            }
        }
    }
}
