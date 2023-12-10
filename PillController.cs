using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillController : MonoBehaviour
{
    [SerializeField] private AudioClip pillClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            audioSource.clip = pillClip;
            audioSource.Play();
            collision.gameObject.GetComponent<Health>().HPHelp();
            Destroy(gameObject);
        }
    }
}
