using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Text bulletText;
    private Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        bulletText.text = shooter.CurrentBulletValue.ToString();
    }

    private void OnEnable()
    {
        shooter.BulletValueChanged += HandleBulletValueChanged;
    }

    private void OnDisable()
    {
        shooter.BulletValueChanged -= HandleBulletValueChanged;
    }

    private void HandleBulletValueChanged()
    {
        bulletText.text = shooter.CurrentBulletValue.ToString();
    }
}
