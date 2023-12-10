using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    private Health health;
    private bool inLava;
    private float timer;

    private void Awake()
    {
        health = GetComponent<Health>();
        inLava = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
        {
            inLava = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
        {
            inLava = false;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (inLava && timer > 1)
        {
            health.TakeDamage(damage);
            timer = 0;
        }
    }
}
