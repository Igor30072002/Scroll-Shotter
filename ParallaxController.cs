using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform background;
    [SerializeField] private float coeff;
    private void Update()
    {
        background.position = transform.position * coeff;
    }
}
