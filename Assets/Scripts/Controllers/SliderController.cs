using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    [Header("References")]
    DisplayTime displayAmbience;
    AudioSource audioSource; 

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        displayAmbience = GetComponent<DisplayTime>();
    }

    public void SoundEffectsVolume(float value)
    {
        audioSource.volume = value;

    }
}
