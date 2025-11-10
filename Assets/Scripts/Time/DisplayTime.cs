using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
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

    public Slider sliderRain;

    void Start()
    {
        cam = GetComponent<Camera>();
        
    }

    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        currentDate = System.DateTime.UtcNow.ToString("dd/MM/yy");
        displayHour.text = string.Format("{0:00}:{1:00}", hour, Mathf.FloorToInt(minutes)); // pra garantir o formato de hora padrão do pc sem quebrar
        displayDate.text = currentDate;

        // PresetSunnyDay();
        // PresetNight();
         PresetRain();
        //DefaultAmbience(hour);
    }
    
    // private void DefaultAmbience(int hour)
    // {
    //     if (hour >= 6 && hour < 12) //Manhã
    //     {
    //         cam.backgroundColor = Color.Lerp(backgroundColors[0], backgroundColors[1], (hour - 6) / 6f);

    //         sunLight.SetActive(true);
    //         sunRaysVfx.SetActive(true);

    //         ambienceDayLight.SetActive(true);
    //         ambienceNightLight.SetActive(false);

    //         dayWindown.SetActive(true);
    //         nightWindown.SetActive(false);

    //     }

    //     //Depois preciso pensar em um preset para tarde e ajeitar aqui
    //     else if (hour >= 12 && hour < 18) //Tarde
    //     {
    //         cam.backgroundColor = Color.Lerp(backgroundColors[2], backgroundColors[3], (hour - 12) / 6f);

    //         sunLight.SetActive(true);
    //         sunRaysVfx.SetActive(true);

    //         ambienceDayLight.SetActive(true);
    //         ambienceNightLight.SetActive(false);

    //         dayWindown.SetActive(true);
    //         nightWindown.SetActive(false);

    //     }

    //     else // Noite: das 18h até 5h59
    //     {
    //         float t;
    //         if (hour >= 18 && hour < 24) // entre 18h e 23h
    //             t = (hour - 18) / 6f;
    //         else // entre 0h e 5h
    //             t = (hour + 6) / 12f; // mapeando 0h–5h pra ter uma transição suave

    //         cam.backgroundColor = Color.Lerp(backgroundColors[4], backgroundColors[5], t);

    //         sunLight.SetActive(false);
    //         ambienceNightLight.SetActive(true);

    //         nightWindown.SetActive(true);
    //         dayWindown.SetActive(false);

    //         sunRaysVfx.SetActive(false);
    //     }
    // }

    public void PresetSunnyDay()
    {
        ambienceDayLight.SetActive(true);
        sunLight.SetActive(true);
        dayWindown.SetActive(true);
        sunRaysVfx.SetActive(true);

        ambienceNightLight.SetActive(false);
        nightWindown.SetActive(false);

        string hexDayColorCode = "#E7A553";
        Color backgroundDayColor;
        ColorUtility.TryParseHtmlString(hexDayColorCode, out backgroundDayColor);
        cam.backgroundColor = backgroundDayColor;
    }
    
    public void PresetNight()
    {
        ambienceNightLight.SetActive(true);
        nightWindown.SetActive(true);

        ambienceDayLight.SetActive(false);
        sunLight.SetActive(false);
        dayWindown.SetActive(false);
        sunRaysVfx.SetActive(false);

        string hexNightColorCode = "#292965";
        Color backgroundNightColor;
        ColorUtility.TryParseHtmlString(hexNightColorCode, out backgroundNightColor);
        cam.backgroundColor = backgroundNightColor;
    }

    private void PresetRain()
    {
        if (sliderRain.value >= 0.01)
        {
            rainWindown.SetActive(true);
            rainVfx.SetActive(true);

            nightWindown.SetActive(false);
            ambienceNightLight.SetActive(false);
            ambienceDayLight.SetActive(false);
            sunLight.SetActive(false);
            dayWindown.SetActive(false);
            sunRaysVfx.SetActive(false);
        }
        else
        {
            rainWindown.SetActive(false);
            rainVfx.SetActive(false);
        }
        
    }
}
