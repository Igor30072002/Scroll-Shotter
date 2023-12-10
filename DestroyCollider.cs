using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollider : MonoBehaviour
{
    private bool delete;
    private float timer;
    private GameObject GM;

    private void Awake()
    {
        timer = 0;
        delete = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            delete = true;
            GM = collision.gameObject;
        }
    }

    private void Update()
    {
        if (delete)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                Destroy(GM);
                delete = false;
            }
        }
    }
}
