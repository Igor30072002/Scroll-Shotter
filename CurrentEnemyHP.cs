using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEnemyHP : MonoBehaviour
{
    [SerializeField] private Text HPText;
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        health.HealthValueChanged += HandleHealthValueChanged;
    }

    private void OnDisable()
    {
        health.HealthReachedZero -= HandleHealthValueChanged;
    }

    private void HandleHealthValueChanged()
    {
        HPText.text = health.CurrentHealth.ToString();
    }
}
