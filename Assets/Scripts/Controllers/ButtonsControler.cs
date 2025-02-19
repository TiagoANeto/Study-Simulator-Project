using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControler : MonoBehaviour
{
    #region panels Gameobject
    
    public GameObject panelPlaylist;
    public GameObject panelToDoList;
    public GameObject panelSettings;
    public GameObject timerPomodoro;
    public GameObject slidersNoise;
    public GameObject fullScreen;

    #endregion

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

    public void OpenSlidersNoise()
    {
        slidersNoise.SetActive(!slidersNoise.activeInHierarchy);
    }

    public void DeleteTask()
    {
        Destroy(this.gameObject);
    }

    public void FullScreenButton(GameObject gameObject)
    {
        if(Input.GetKeyDown("Escape"))
        {
            gameObject = fullScreen;
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
}
