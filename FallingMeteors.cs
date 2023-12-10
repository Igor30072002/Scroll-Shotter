using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteors : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    private Vector2 currentPosition;
    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.1)
        {
            currentPosition = new Vector2(Random.Range(-5, 6), 9);
            GameObject currentMeteor = Instantiate(meteor, currentPosition, Quaternion.identity);
            Rigidbody2D currentMeteorVelocity = currentMeteor.GetComponent<Rigidbody2D>();
            currentMeteorVelocity.velocity = new Vector2(-5, -2);
            timer = 0;
        }
    }
}
