using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private AudioSource audioSource;

    private void Start()
    {
        if (gameObject.CompareTag("MusicSlider"))
        {
            audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        }
        else if (gameObject.CompareTag("SoundSlider"))
        {
            audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        }
        if (PlayerPrefs.HasKey(slider.gameObject.name))
        {
            slider.value = PlayerPrefs.GetFloat(slider.gameObject.name);
            audioSource.volume = PlayerPrefs.GetFloat(slider.gameObject.name);
        }
        slider.onValueChanged.AddListener((v) => { audioSource.volume = v; });
    }

    public void PlayAndSave()
    {
        PlayerPrefs.SetFloat(slider.gameObject.name, audioSource.volume);
        PlayerPrefs.Save();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(slider.gameObject.name, audioSource.volume);
        PlayerPrefs.Save();
    }
}
