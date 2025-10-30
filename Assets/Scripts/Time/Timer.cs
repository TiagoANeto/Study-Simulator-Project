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

    private AudioSource audioSource;
    private bool _isPausedTimer = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateUIText();
    }

    private void Update()
    {
        if (_isPausedTimer) return;

        if (minutes > 0 || seconds > 0)
        {
            seconds -= Time.deltaTime;

            if (seconds < 0)
            {
                if (minutes > 0)
                {
                    minutes -= 1;
                    seconds += 60;
                }
                else
                {
                    seconds = 0;
                    _isPausedTimer = true;

                    if (alarmToggle.isOn && alarmSound != null)
                    {
                        audioSource.clip = alarmSound;
                        audioSource.Play();
                    }
                }
            }
        }

        UpdateUIText();
    }

    private void UpdateUIText()
    {
        countTime.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(minutes), Mathf.FloorToInt(seconds));
    }

    public void StartPauseTimer()
    {
        _isPausedTimer = !_isPausedTimer;
    }

    public void ResetTimer()
    {
        _isPausedTimer = true;
        seconds = 0f;
        UpdateUIText();
    }

    public void SetTime(float newMinutes)
    {
        minutes = newMinutes;
        seconds = 0f;
        UpdateUIText();
    }
}
