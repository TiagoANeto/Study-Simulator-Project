using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerSettings : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField pomodoroInput;
    public TMP_InputField shortBreakInput;
    public TMP_InputField longBreakInput;

    [Header("Toggles")]
    public Toggle alarmToggle;
    public Toggle autoStartBreaksToggle;

    [Header("References")]
    public Timer timer; 

    private float pomodoroTime = 25f;
    private float shortBreakTime = 5f;
    private float longBreakTime = 15f;

    private void Start()
    {
        //Inicializa os campos
        pomodoroInput.text = pomodoroTime.ToString("0");
        shortBreakInput.text = shortBreakTime.ToString("0");
        longBreakInput.text = longBreakTime.ToString("0");
    }

    public void OnPomodoroChanged(string value)
    {
        if (float.TryParse(value, out float newTime))
        {
            pomodoroTime = newTime;
            timer.SetTime(pomodoroTime); 
        }
    }

    public void OnShortBreakChanged(string value)
    {
        if (float.TryParse(value, out float newTime))
        {
            shortBreakTime = newTime;
        }
    }

    public void OnLongBreakChanged(string value)
    {
        if (float.TryParse(value, out float newTime))
        {
            longBreakTime = newTime;
        }
    }

    public void ApplyPomodoro()
    {
        timer.SetTime(pomodoroTime);
    }

    public void ApplyShortBreak()
    {
        timer.SetTime(shortBreakTime);
    }

    public void ApplyLongBreak()
    {
        timer.SetTime(longBreakTime);
    }

    public void IncreasePomodoro()
    {
        pomodoroTime += 5f;
        pomodoroInput.text = pomodoroTime.ToString("0");
        timer.SetTime(pomodoroTime);
    }

    public void DecreasePomodoro()
    {
        pomodoroTime = Mathf.Max(1, pomodoroTime - 5f); //Pra evitar o negativo
        pomodoroInput.text = pomodoroTime.ToString("0");
        timer.SetTime(pomodoroTime);
    }

    public void IncreaseShortBreak()
    {
        shortBreakTime += 5f;
        shortBreakInput.text = shortBreakTime.ToString("0");
        timer.SetTime(shortBreakTime);
    }

    public void DecreaseShortBreak()
    {
        shortBreakTime = Mathf.Max(1, shortBreakTime - 5f);
        shortBreakInput.text = shortBreakTime.ToString("0");
        timer.SetTime(shortBreakTime);
    }
    
    public void IncreaseLongBreak()
    {
        longBreakTime += 5f;
        longBreakInput.text = longBreakTime.ToString("0");
        timer.SetTime(longBreakTime);
    }

    public void DecreaseLongBreak()
    {
        longBreakTime = Mathf.Max(1, longBreakTime - 5f); 
        longBreakInput.text = longBreakTime.ToString("0");
        timer.SetTime(longBreakTime);
    }
}

