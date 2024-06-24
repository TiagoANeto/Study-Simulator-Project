using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float minutes = 0f;
    public float seconds = 0f;
    public Text countTime;
    void Start()
    {
       if(minutes > 0 && seconds == 0){
            seconds = 59;
            minutes -= 1;
       }
    }
    
    void Update()
    {
        if(minutes <= 0 && seconds <= 0){
            countTime.text = "00:00";
        }
        else
        {
            seconds -= Time.deltaTime;

            if(seconds <= 0){

                if(minutes > 0){
                    minutes -= 1;
                    seconds += 60;
                }
                else
                {
                    seconds = 0;
                }
            }
        }

        countTime.text = string.Format("{00}:{1:00}", minutes, Mathf.FloorToInt(seconds));
    }
}
