using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControler : MonoBehaviour
{
    public GameObject panelPlaylist;
    public GameObject panelToDoList;
    public GameObject panelSettings;
    public GameObject timerPomodoro;
    public GameObject fullScreen;

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

    public void OpenSettings()
    {
        panelSettings.SetActive(!panelSettings.activeInHierarchy);
    }

    public void DeleteTask()
    {
        Destroy(this.gameObject);
    }

    public void FullScreenButton(GameObject gameObject)
    {
        gameObject = fullScreen;
        Screen.fullScreen = !Screen.fullScreen;
    }
}
