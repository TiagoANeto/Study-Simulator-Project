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
        audioSource.volume = 0.01f;
        audioSource.playOnAwake = false;
        PlayMusic();
    }

    void Update() 
    {
        if(!audioSource.isPlaying && !isPaused) 
        {
            NextSong();
        }
    }

    void PlayMusic()
    {
        if(musicList.Length > 0)
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

    public void NextSong()
    {
        if(musicList.Length == 0) return; // Verifica se existem músicas na lista 

        currentTrackIndex = (currentTrackIndex + 1) % musicList.Length; // Pra garantir que quando o index chegar a 0 a playlist volte com o index do início
        audioSource.clip = musicList[currentTrackIndex]; 
        audioSource.Play(); 
    }

    public void PreviousSong()
    {
        if(musicList.Length == 0) return;

        currentTrackIndex = (currentTrackIndex - 1) % musicList.Length; 
        audioSource.clip = musicList[currentTrackIndex];
        audioSource.Play(); 
    }

    public void RandomSong()
    {
        if (musicList.Length == 0) return;

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, musicList.Length);
        }
            while (randomIndex == currentTrackIndex); // Evita tocar a mesma música na sequência 

        currentTrackIndex = randomIndex;
        audioSource.clip = musicList[currentTrackIndex];
        audioSource.Play();
    }
}
