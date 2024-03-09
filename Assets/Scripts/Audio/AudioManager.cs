using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ebac.Core.Singleton;

public class AudioManager : Singleton<AudioManager>
{
    // [SerializeField] private AudioSource _musicSource;

    // public Slider _volumeSlider;

    private void Awake()
    {
       //  ChangeMasterVolume(_volumeSlider.value);
    }
    
    public void ChangeMasterVolume(float sliderValue)
    {
        // AudioListener.volume = sliderValue;
    }

    public void ToggleMusic()
    {
        // _musicSource.mute = !_musicSource.mute;
    }
}
