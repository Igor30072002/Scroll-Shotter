using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicScript : MonoBehaviour
{
    [SerializeField] private AudioClip MenuClip;
    [SerializeField] private AudioClip LevelClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            audioSource.clip = MenuClip;
            audioSource.Play();
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            audioSource.clip = LevelClip;
            audioSource.Play();
        }
    }
}
