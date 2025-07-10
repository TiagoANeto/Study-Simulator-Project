using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class DisplayTime : MonoBehaviour
{
    [Header("Variáveis para aramazenar a hora e data do sistema local")] [Space(10)]
    [SerializeField] private TMP_Text displayHour;
    [SerializeField] private TMP_Text displayDate;
    [SerializeField] private int hour;
    [SerializeField] private int minutes;
    [SerializeField] private string currentDate;


    [Header("Cores para mudança de backgrond ao longo do dia")] [Space(10)]
    public Color morningColor;
    public Color afternoonColor;
    public Color nightColor;
    public Camera cam;
    public GameObject nightLight;
    public GameObject dayLight;

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
        
        ChangeBackgroundColor(hour); 
    }

    private void ChangeBackgroundColor(int hour)
    {
        if (hour >= 6 && hour < 12) //Manhã
        {
            cam.backgroundColor = Color.Lerp(nightColor, morningColor, (hour - 6) / 6f);
            nightLight.SetActive(false);
        }

        else if (hour >= 12 && hour < 18) //Tarde
        {
            cam.backgroundColor = Color.Lerp(morningColor, afternoonColor, (hour - 12) / 6f);
            dayLight.SetActive(true);
            nightLight.SetActive(false);
        }

        else if (hour >= 18 && hour >= 0 && hour >= 5) //Noite
        {
            cam.backgroundColor = Color.Lerp(afternoonColor, nightColor, (hour - 12) / 6f);
            dayLight.SetActive(false);
            nightLight.SetActive(true);
        }
            
    }
}
