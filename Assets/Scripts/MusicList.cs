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

        // Usa as setas para cima/baixo para ajustar o volume
        float volumeChange = Input.GetAxis("Vertical");
        if (volumeChange != 0f)
        {
            audioSource.volume = Mathf.Clamp01(audioSource.volume + volumeChange * 0.1f);
        }
    }

    void PlayMusic()
    {
        if (musicList.Length > 0)
        {
            audioSource.clip = musicList[currentTrackIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No music add.");
        }
    }
}
