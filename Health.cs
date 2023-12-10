using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private int HPHelpValue;

    public event Action HealthReachedZero;
    public event Action HealthValueChanged;
    public event Action LessThenSixHP;
    public event Action MoreThenFiveHP;

    public bool IsAlive => currentHealth > 0;
    public float CurrentHealth => currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        HPHelpValue = 5;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthValueChanged?.Invoke();
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if(currentHealth < 6)
        {
            LessThenSixHP?.Invoke();
        }
        else
        {
            MoreThenFiveHP?.Invoke();
        }
        if (currentHealth == 0)
        {
            HealthReachedZero?.Invoke();
        }
    }

    public void HPHelp()
    {
        if (currentHealth < maxHealth - HPHelpValue)
        {
            currentHealth += HPHelpValue;
        }
        else
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < 6)
        {
            LessThenSixHP?.Invoke();
        }
        else
        {
            MoreThenFiveHP?.Invoke();
        }
        HealthValueChanged?.Invoke();
    }
}