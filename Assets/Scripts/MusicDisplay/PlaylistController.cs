using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlaylistController : MonoBehaviour
{
    #region declarations

    [Header("Lista de músicas adicionadas a playlist")] [Space(10)]
    public AudioClip[] musicList;

    [Header("Lista com os nomes do criadores das músicas da playlist")] [Space(10)]
    public string[] musicName;

    [Header("Variável responsavel por atualizar o display com o nomes das músicas e artistas")] [Space(10)]
    public TMP_Text musicNameDisplay;

    [SerializeField] private Slider musicSlider;
    private AudioSource audioSource;
    private string volumeKey = "AudioMusicMaster";
    private string sliderUIKey = "UISliderValue";
    private int currentTrackIndex = 0;
    private bool isPaused = false;

    #endregion

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        PlayMusic();

        if (PlayerPrefs.HasKey(volumeKey))
        {
            audioSource.volume = PlayerPrefs.GetFloat(volumeKey);
            musicSlider.value = PlayerPrefs.GetFloat(sliderUIKey);
        }
        else
        {
            audioSource.volume = 0.01f;
        }
    }

    void Update() 
    {
        if(!audioSource.isPlaying && !isPaused) 
        {
            NextSong();
        }
    }

    
    /// <summary>
    /// método principal responsável pela reprodução das músicas da playlist, 
    /// ele percorre a lista de músicas e verifica se ela não está vazia, se existir ao menos uma música na lista, 
    /// ele a reproduz e atualiza no display, com o nome da som atual e seu respectivo artista
    /// </summary>
    void PlayMusic() 
    {
        if(musicList.Length > 0)
        {
            audioSource.clip = musicList[currentTrackIndex];
            audioSource.Play();
            musicNameDisplay.text = musicName[currentTrackIndex];
        }
    }

    public void PlaylistVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("AudioMusicMaster", value);
        PlayerPrefs.SetFloat("UISliderValue", musicSlider.value);
        PlayerPrefs.Save();
        
    }

    public void ButtonMusicPause() // metodo para botão de pausa estilo switch, apenas verifica se a música está reproduzindo ou não, por meio de uma variavel boleana e faz os inversos da lógica
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

    public void NextSong() // metodo para botão de reprozir a próxima música
    {
        if(musicList.Length == 0) return; // Verifica se existem músicas na lista 

        currentTrackIndex = (currentTrackIndex + 1) % musicList.Length; // Pra garantir que quando o index chegar a 0 a playlist volte ao index do início e assim nunca pare de reproduzir 
        audioSource.clip = musicList[currentTrackIndex]; 
        audioSource.Play();
        musicNameDisplay.text = musicName[currentTrackIndex];
    }

    public void PreviousSong() // metodo para botão de reprozir a música anterior
    {
        if(musicList.Length == 0) return;

        currentTrackIndex = (currentTrackIndex - 1) % musicList.Length; 
        audioSource.clip = musicList[currentTrackIndex];
        audioSource.Play();
        musicNameDisplay.text = musicName[currentTrackIndex];
    }

    public void RandomSong() // metodo para botão de música aleatória, fazendo com que uma música do index do array seja escolhida ao acaso para ser reproduzida
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
        musicNameDisplay.text = musicName[currentTrackIndex];
    }
}