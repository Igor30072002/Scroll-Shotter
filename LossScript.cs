using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossScript : MonoBehaviour
{
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private Health health;

    private void OnEnable()
    {
        health.HealthReachedZero += HandleHealthReachedZero;
    }

    private void OnDisable()
    {
        health.HealthReachedZero -= HandleHealthReachedZero;
    }

    private void HandleHealthReachedZero()
    {
        LosePanel.SetActive(true);
        GamePanel.SetActive(false);
        gameObject.SetActive(false);
    }
}