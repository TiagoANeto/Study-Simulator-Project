using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float minutes = 25f;
    public float seconds = 0f;
    public TMP_Text countTime;
    public Toggle alarmToggle;
    public AudioClip alarmSound;
    public TMP_InputField inputMinutes;
    private AudioSource audioSource;
    private bool _isPausedTimer = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

                    if(alarmToggle.isOn)
                    {
                        audioSource.clip = alarmSound;
                        audioSource.Play(); 
                    }
                    
                }
            }
        }
        minutes = int.Parse(inputMinutes.text);
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

    public void AddTime()
    {
        minutes += 5f;
        UpdateUIText();
    }

    public void RemoveTime()
    {
        if (minutes >= 5)
        {
            minutes -= 5f;
        }
        else
        {
            minutes = 0;
            seconds = 0;
        }
        UpdateUIText();
    }

    public void ResetTimer()
    {
        minutes = 0;
        seconds = 0;
        UpdateUIText();
    }
}
