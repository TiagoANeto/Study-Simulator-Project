using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float minutes = 25f;
    public float seconds = 0f;
    public Text countTime;
    private bool _isPausedTimer = true;

    void Update()
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
                }
            }
        }
        countTime.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(minutes), Mathf.FloorToInt(seconds));
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
