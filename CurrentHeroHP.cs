using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHeroHP : MonoBehaviour
{
    [SerializeField] private Text HPText;
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        HPText.text = health.CurrentHealth.ToString();
    }
    private void OnEnable()
    {
        health.HealthValueChanged += HandleHealthValueChanged;
    }

    private void OnDisable()
    {
        health.HealthValueChanged -= HandleHealthValueChanged;
    }

    private void HandleHealthValueChanged()
    {
        HPText.text = health.CurrentHealth.ToString();
    }
}
