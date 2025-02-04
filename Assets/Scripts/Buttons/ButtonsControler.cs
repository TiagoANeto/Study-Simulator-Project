using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControler : MonoBehaviour
{
    public GameObject panelPlaylist;
    public GameObject panelToDoList;
    public GameObject timerPomodoro;

    public void OpenPlaylist()
    {
        panelPlaylist.SetActive(!panelPlaylist.activeInHierarchy);
    }

    public void OpenToDoList()
    {
        panelToDoList.SetActive(!panelToDoList.activeInHierarchy);
    }

    public void OpenPomodoroTimer()
    {
        timerPomodoro.SetActive(!timerPomodoro.activeInHierarchy);
    }
}
