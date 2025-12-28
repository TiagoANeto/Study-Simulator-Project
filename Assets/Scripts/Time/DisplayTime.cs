using UnityEngine;
using TMPro;
using System;

public class DisplayTime : MonoBehaviour
{
    public enum TimeFormat{Hour24,Hour12}

    [Header("Configuração de horário")] [Space(10)]
    [SerializeField] private TimeFormat timeFormat = TimeFormat.Hour24;
    private const string TIME_FORMAT_KEY = "TimeFormat";

    [Header("Variáveis para armazenar hora e data do sistema local")] [Space(10)]
    [SerializeField] private TMP_Text displayHour;
    [SerializeField] private TMP_Text displayDate;
    [SerializeField] private int hour;
    [SerializeField] private int minutes;
    [SerializeField] private string currentDate;

    [Header("Controladores de ambiente")] [Space(10)]
    //De 0 a 2 cores da manhã - de 3 a 5 cores da tarde - de 6 a 8 cores da noite
    public Color[] backgroundColors = { new Color(), new Color(), new Color(), new Color(), new Color(), new Color() };
    public Camera cam;
    public GameObject ambienceNightLight;
    public GameObject ambienceDayLight;
    public GameObject sunLight;
    public GameObject dayWindown;
    public GameObject nightWindown;
    public GameObject rainWindown;
    public GameObject rainVfx;
    public GameObject sunRaysVfx;

    void Start()
    {
        cam = GetComponent<Camera>();
        timeFormat = (TimeFormat)PlayerPrefs.GetInt(TIME_FORMAT_KEY, 0);
    }

    void Update()
    {
        DateTime now = System.DateTime.Now;

        hour = now.Hour;
        minutes = now.Minute;

        displayHour.text = GetFormattedTime(now);
        displayDate.text = now.ToString("dd/MM/yy");

        DefaultAmbience(hour);
    }
    
    private void DefaultAmbience(int hour)
    {
        if (hour >= 6 && hour < 12) //Manhã
        {
            cam.backgroundColor = Color.Lerp(backgroundColors[0], backgroundColors[1], (hour - 6) / 6f);

            sunLight.SetActive(true);
            sunRaysVfx.SetActive(true);

            ambienceDayLight.SetActive(true);
            ambienceNightLight.SetActive(false);

            dayWindown.SetActive(true);
            nightWindown.SetActive(false);

        }

        //Depois preciso pensar em um preset para tarde e ajeitar aqui
        else if (hour >= 12 && hour < 18) //Tarde
        {
            cam.backgroundColor = Color.Lerp(backgroundColors[2], backgroundColors[3], (hour - 12) / 6f);

            sunLight.SetActive(true);
            sunRaysVfx.SetActive(true);

            ambienceDayLight.SetActive(true);
            ambienceNightLight.SetActive(false);

            dayWindown.SetActive(true);
            nightWindown.SetActive(false);

        }

        else // Noite: das 18h até 5h59
        {
            float t;
            if (hour >= 18 && hour < 24) // entre 18h e 23h
                t = (hour - 18) / 6f;
            else // entre 0h e 5h
                t = (hour + 6) / 12f; // mapeando 0h–5h pra ter uma transição suave

            cam.backgroundColor = Color.Lerp(backgroundColors[4], backgroundColors[5], t);

            sunLight.SetActive(false);
            ambienceNightLight.SetActive(true);

            nightWindown.SetActive(true);
            dayWindown.SetActive(false);

            sunRaysVfx.SetActive(false);
        }
    }

    private string GetFormattedTime(System.DateTime time)
    {
        if (timeFormat == TimeFormat.Hour24)
        {
            return time.ToString("HH:mm");
        }
        else
        {
            //AM/PM
            return time.ToString("hh:mm");
        }
    }

    public void SetTimeFormat(bool use12Hours)
    {
        timeFormat = use12Hours ? TimeFormat.Hour12 : TimeFormat.Hour24;
        PlayerPrefs.SetInt(TIME_FORMAT_KEY, (int)timeFormat);
    }
}
