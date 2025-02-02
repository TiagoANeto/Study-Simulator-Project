using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    public GameObject displayHour;
    public int hour;
    public int minutes;

    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        displayHour.GetComponent<Text>().text = hour + ":" + minutes;
    }
}
