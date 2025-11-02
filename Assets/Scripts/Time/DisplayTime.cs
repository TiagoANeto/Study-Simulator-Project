using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    [Header("Variáveis para aramazenar a hora e data do sistema local")] [Space(10)]
    [SerializeField] private TMP_Text displayHour;
    [SerializeField] private TMP_Text displayDate;
    [SerializeField] private int hour;
    [SerializeField] private int minutes;
    [SerializeField] private string currentDate;


    [Header("Controladores Mudanças ao longo do dia")] [Space(10)]
    
    //De 0 a 2 cores da manhã - de 3 a 5 cores da tarde - de 6 a 8 cores da noite
    public Color[] backgroundColors = { new Color(), new Color(), new Color(), new Color(), new Color(), new Color() };
    public Camera cam;
    public GameObject nightLight;
    public GameObject dayLight;
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

        //ChangeAmbience(hour);
        ChangeAmbienceRain();
    }


    //Preciso pensar em um jeito de deixar uma única paleta de cores para cada parte de dia e a transição ser feita entra elas
    //por exemplo: Uma paleta de tons quente e aconchegantes para manhã que giram em torno de rosa e amarelo.
    //Já a tarde seria um tom de paleta baseado em amarelo e laranja, e noite tons de azul e roxo.
    //Ao invés de serem feitas transições de cores bruscas como está nesse momento, preciso achar tons que combinem.
    // private void ChangeAmbience(int hour)
    // {
    //     if (hour >= 6 && hour < 12) //Manhã
    //     {
    //         cam.backgroundColor = Color.Lerp(backgroundColors[0], backgroundColors[1], (hour - 6) / 6f);

    //         dayLight.SetActive(true);
    //         nightLight.SetActive(false);

    //         dayWindown.SetActive(true);
    //         nightWindown.SetActive(false);

    //         sunRaysVfx.SetActive(true);
    //     }

    //     else if (hour >= 12 && hour < 18) //Tarde
    //     {
    //         cam.backgroundColor = Color.Lerp(backgroundColors[2], backgroundColors[3], (hour - 12) / 6f);

    //         dayLight.SetActive(true);
    //         nightLight.SetActive(false);

    //         dayWindown.SetActive(true);
    //         nightWindown.SetActive(false);

    //         sunRaysVfx.SetActive(true);
    //     }

    //     else // Noite: das 18h até 5h59
    //     {
    //         float t;
    //         if (hour >= 18 && hour < 24) // entre 18h e 23h
    //             t = (hour - 18) / 6f;
    //         else // entre 0h e 5h
    //             t = (hour + 6) / 12f; // mapeando 0h–5h para uma transição suave

    //         cam.backgroundColor = Color.Lerp(backgroundColors[4], backgroundColors[5], t);

    //         dayLight.SetActive(false);
    //         nightLight.SetActive(true);

    //         nightWindown.SetActive(true);
    //         dayWindown.SetActive(false);

    //         sunRaysVfx.SetActive(false);
    //     }
    // }

    private void ChangeAmbienceRain()
    {
        if (sliderRain.value >= 0.01f)
        {
            rainWindown.SetActive(true);
            rainVfx.SetActive(true);
            nightWindown.SetActive(false);
        }
        else
        {
            nightWindown.SetActive(true);
            rainWindown.SetActive(false);
            rainVfx.SetActive(false);
        }
    }
}
