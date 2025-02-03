using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float minutes = 25f;
    public float seconds = 0f;
    public Text countTime;

    void Update()
    {
        if (minutes <= 0 && seconds <= 0)
        {
            countTime.text = "00:00";
        }
        else
        {
            seconds -= Time.deltaTime;

            if (seconds <= 0)
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

    public void AddTime()
    {
        minutes += 5f;
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
    }
}
