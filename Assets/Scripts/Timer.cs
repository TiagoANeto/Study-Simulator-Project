using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startTime = 10f;
    public Text countText;
    void Start()
    {
        currentTime = startTime;
    }

    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countText.text = currentTime.ToString("0");
    }
}
