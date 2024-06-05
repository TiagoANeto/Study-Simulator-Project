using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicList : MonoBehaviour
{
    public AudioClip[] musicList;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    private bool isPaused = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayMusic();
    }

    void Update()
    {
        // Exemplo: pressione a barra de espaço para pausar e continuar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
                audioSource.UnPause();
            else
                audioSource.Pause();

            isPaused = !isPaused;
        }
    }

    void PlayMusic()
    {
        if (musicList.Length > 0)
        {
            audioSource.clip = musicList[currentTrackIndex];
            audioSource.Play();
        }
    }
}
