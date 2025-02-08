using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    [Header("Variáveis para aramazenar a hora do sistema local")]
    [Space(10)]

    [SerializeField] private Text displayHour;
    [SerializeField] private int hour;
    [SerializeField] private int minutes;

    [Header("Cores para mudança de backgrond ao longo do dia")]
    [Space(10)]

    public Color morningColor;
    public Color afternoonColor;
    public Color nightColor;
    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        displayHour.text = string.Format("{0:00}:{1:00}", hour, Mathf.FloorToInt(minutes)); // pra garantir o formato de hora padrão do pc sem quebrar

        ChangeBackgroundColor(hour); 
    }

    private void ChangeBackgroundColor(int hour)
    {
        if (hour >= 6 && hour < 12) // Manhã
            cam.backgroundColor = Color.Lerp(nightColor, morningColor, (hour - 6) / 6f);
        else if (hour >= 12 && hour < 18) // Tarde
            cam.backgroundColor = Color.Lerp(morningColor, afternoonColor, (hour - 12) / 6f);
        else // Noite
            cam.backgroundColor = Color.Lerp(afternoonColor, nightColor, (hour - 18) / 6f);
    }
}
