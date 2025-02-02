using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float minutes = 25f;
    private float seconds = 0f;
    public Text countTime;


    void Update()
    {
        if(minutes <= 0 && seconds <= 0)
        {
            countTime.text = "00:00";
        }
        else
        {
            seconds -= Time.deltaTime;

            if(seconds <= 0)
            {
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

        countTime.text = string.Format("{0:00}:{1:00}", minutes, Mathf.FloorToInt(seconds));
    }

    public void AddTime() //função simples para adicionar tempo
    { 
        minutes += 5f;
        Debug.Log("+5min: "+minutes);
    }

    public void RemoveTime() //função simples para remover tempo
    {
          if (minutes >= 5) 
        {
            minutes -= 5f;
        }
        else
        {
            minutes = 0;
            seconds = 0;
        }
        Debug.Log("-5min: "+minutes);
    }
}
