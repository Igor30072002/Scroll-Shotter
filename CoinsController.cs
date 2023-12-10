using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip crystalClip;
    private AudioSource audioSource;
    [SerializeField] private Text coinText;
    [SerializeField] private Text crystalText;
    private int coinQuantity;
    private int crystalQuantity;

    private void Awake()
    {
        coinQuantity = int.Parse(coinText.text);
        crystalQuantity = int.Parse(crystalText.text);
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            audioSource.clip = coinClip;
            audioSource.Play();
            Destroy(collision.gameObject);
            coinQuantity++;
            coinText.text = coinQuantity.ToString();
        }
        else if (collision.CompareTag("Crystal"))
        {
            audioSource.clip = crystalClip;
            audioSource.Play();
            Destroy(collision.gameObject);
            crystalQuantity++;
            crystalText.text = crystalQuantity.ToString();
        }
    }
}
