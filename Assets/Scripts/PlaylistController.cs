using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistController : MonoBehaviour
{
    public AudioClip[] musicList;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    private bool isPaused = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.05f;
        PlayMusic();
    }

    void PlayMusic()
    {
        if (musicList.Length > 0)
        {
            audioSource.clip = musicList[currentTrackIndex];
            audioSource.Play();
        }
    }
    public void PlaylistVolume(float value) 
    {
        audioSource.volume = value;
    }

    public void ButtonMusicPause()
    {
        if(isPaused)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }
        isPaused = !isPaused;
    }

    public void NextMusic()
    {
        //A ser implementado
    }
}
