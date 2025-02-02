using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    public Text displayHour;
    public int hour;
    public int minutes;

    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        displayHour.text = string.Format("{0:00}:{1:00}", hour, Mathf.FloorToInt(minutes)); // pra garantir o formato de hora padrão do pc sem quebrar 
    }
}
