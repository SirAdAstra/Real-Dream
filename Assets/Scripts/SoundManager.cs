using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider dayVolumeSlider;
    [SerializeField] private Slider nightVolumeSlider; 
    [SerializeField] private AudioSource[] audioSources;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", dayVolumeSlider.value);
            Load();
        }
        else 
        {
            Load();
        }
    }

    public void ChangeDayVolume()
    {
        float value = dayVolumeSlider.value;
        
        foreach (AudioSource audioSource in audioSources)
            audioSource.volume = value;
        nightVolumeSlider.value = value;
        Save(value);
    }

    public void ChangeNightVolume()
    {
        float value = nightVolumeSlider.value;

        foreach (AudioSource audioSource in audioSources)
            audioSource.volume = value;
        
        dayVolumeSlider.value = value;
        Save(value);
    }

    private void Load()
    {
        float value = PlayerPrefs.GetFloat("musicVolume");
        foreach (AudioSource audioSource in audioSources)
            audioSource.volume = value;
        
        nightVolumeSlider.value = value;
        dayVolumeSlider.value = value;
    }

    private void Save(float value)
    {
        PlayerPrefs.SetFloat("musicVolume", value);
    }
}
