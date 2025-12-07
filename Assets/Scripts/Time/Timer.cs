using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Timer Config")]
    public float minutes = 50f;
    public float seconds = 0f;
    public TMP_Text countTime;

    [Header("Options")]
    public Toggle alarmToggle;
    public AudioClip alarmSound;

    public Sprite[] spritesButton;
    public Image imageSwitch;
    private AudioSource audioSource;

    private bool _isPausedTimer = true;
    private float _duration;     
    private float _endTime;     

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PrepareTimer();
        UpdateUIText();
        UpdateButtonSprite();
    }

    private void Update()
    {
        if (_isPausedTimer) return;

        float timeLeft = _endTime - Time.unscaledTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            _isPausedTimer = true;
            OnFinish();
        }

        DisplayTime(timeLeft);
    }

    private void PrepareTimer()
    {
        _duration = (minutes * 60f) + seconds;
    }

    private void DisplayTime(float totalSeconds)
    {
        int min = Mathf.FloorToInt(totalSeconds / 60f);
        int sec = Mathf.FloorToInt(totalSeconds % 60f);
        countTime.text = $"{min:00}:{sec:00}";
    }

    public void StartPauseTimer()
    {
        if (_isPausedTimer)
        {
            
            _endTime = Time.unscaledTime + (minutes * 60f + seconds);
            _isPausedTimer = false;
        }
        else
        {
            // Pausar (salvar tempo restante)
            float timeLeft = _endTime - Time.unscaledTime;
            minutes = Mathf.FloorToInt(timeLeft / 60f);
            seconds = Mathf.FloorToInt(timeLeft % 60f);
            _isPausedTimer = true;
        }

        UpdateButtonSprite();
    }

    public void ResetTimer()
    {
        _isPausedTimer = true;
        seconds = 0f;
        PrepareTimer();
        UpdateUIText();
    }

    public void SetTime(float newMinutes)
    {
        minutes = newMinutes;
        seconds = 0f;
        PrepareTimer();
        UpdateUIText();
    }

    private void OnFinish()
    {
        UpdateButtonSprite();

        if (alarmToggle.isOn && alarmSound != null)
        {
            audioSource.clip = alarmSound;
            audioSource.Play();
        }

        DisplayTime(0);
    }

    private void UpdateButtonSprite()
    {
        if (imageSwitch.sprite == spritesButton[0])
        {
            imageSwitch.sprite = spritesButton[1];
            return;
        }

        imageSwitch.sprite = spritesButton[0];
    }

    private void UpdateUIText()
    {
        countTime.text = $"{minutes:00}:{seconds:00}";
    }
}
