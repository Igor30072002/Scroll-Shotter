using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePointRight;
    [SerializeField] private Transform firePointLeft;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform explosion;
    [SerializeField] private Animator explosionAnimator;
    [SerializeField] private int maxBulletValue;
    [SerializeField] private HelpButtonController helpButtonController;
    private int currentBulletValue;
    public int CurrentBulletValue
    {
        get { return currentBulletValue; }
        set { currentBulletValue = value; }
    }
    public event Action BulletValueChanged;
    public event Action LessThenSixBullets;
    public event Action MoreThenFiveBulltes;
    private int bulletHelpValue;
    [SerializeField] private AudioClip laserClip;
    private AudioSource audioSource;

    private void Awake()
    {
        currentBulletValue = maxBulletValue;
        bulletHelpValue = 18;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if (currentBulletValue > 0)
        {
            audioSource.clip = laserClip;
            audioSource.Play();

            currentBulletValue--;
            BulletValueChanged?.Invoke();

            CheckBulletValue();

            if (!spriteRenderer.flipX)
            {
                GameObject currentBullet = Instantiate(bullet, firePointRight.position, Quaternion.identity);
                Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
                explosion.position = new Vector3(transform.position.x + .35f, transform.position.y + .09f, transform.position.z);
                explosionAnimator.SetTrigger("Explotion");
                currentBulletVelocity.velocity = new Vector2(fireSpeed, currentBulletVelocity.velocity.y);
            }
            else
            {
                GameObject currentBullet = Instantiate(bullet, firePointLeft.position, Quaternion.identity);
                Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
                explosion.position = new Vector3(transform.position.x - .35f, transform.position.y + .09f, transform.position.z);
                explosionAnimator.SetTrigger("Explotion");
                currentBulletVelocity.velocity = new Vector2(-fireSpeed, currentBulletVelocity.velocity.y);
            }
            animator.SetTrigger("IsShooting");
        }
        else
        {
            animator.SetTrigger("IsIdle");
        }
    }

    public void BulletHelp()
    {
        if(currentBulletValue < maxBulletValue - bulletHelpValue)
        {
            currentBulletValue += bulletHelpValue;
        }
        else
        {
            currentBulletValue = maxBulletValue;
        }
        CheckBulletValue();
        BulletValueChanged?.Invoke();
    }

    private void CheckBulletValue()
    {
        if (currentBulletValue < 6)
        {
            LessThenSixBullets?.Invoke();
        }
        else
        {
            MoreThenFiveBulltes?.Invoke();
        }
    }
}
