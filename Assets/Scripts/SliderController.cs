using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    AudioSource audioSource; 
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void RainVolume(float value)
    {
        audioSource.volume = value;

    }
}
