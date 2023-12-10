using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedColorText : MonoBehaviour
{
    [SerializeField] private Text AmmoText;
    [SerializeField] private Text HPText;
    [SerializeField] private GameObject hero;
    [SerializeField] private Shooter shooter;
    [SerializeField] private Health health;

    private void OnEnable()
    {
        shooter.LessThenSixBullets += HandleLessThenSixBullets;
        shooter.MoreThenFiveBulltes += HandleMoreThenFiveBulltes;
        health.LessThenSixHP += HandleLessThenSixHP;
        health.MoreThenFiveHP += HandleMoreThenFiveHP;
    }

    private void OnDisable()
    {
        shooter.LessThenSixBullets -= HandleLessThenSixBullets;
        shooter.MoreThenFiveBulltes -= HandleMoreThenFiveBulltes;
        health.LessThenSixHP -= HandleLessThenSixHP;
        health.MoreThenFiveHP -= HandleMoreThenFiveHP;
    }

    private void HandleLessThenSixBullets()
    {
        AmmoText.fontSize = 110;
        AmmoText.color = Color.red;
    }

    private void HandleMoreThenFiveBulltes()
    {
        AmmoText.fontSize = 87;
        AmmoText.color = Color.white;
    }

    private void HandleLessThenSixHP()
    {
        HPText.fontSize = 110;
        HPText.color = Color.red;
    }

    private void HandleMoreThenFiveHP()
    {
        HPText.fontSize = 87;
        HPText.color = Color.white;
    }
}
