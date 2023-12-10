using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickScript : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }

    public void Click()
    {
        audioSource.clip = buttonClip;
        audioSource.Play();
    }
}
