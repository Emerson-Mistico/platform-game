using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioChangeVolume : MonoBehaviour
{

    public AudioMixer audioGroup;
    public string mixerFloatParam = "MyExposedParam";

    [SerializeField] Slider volumeSlider;

    public void ChangeValue()
    {

       audioGroup.SetFloat(mixerFloatParam, volumeSlider.value);
        
        Debug.Log("Valor do slider: " + volumeSlider.value);

    }
}
