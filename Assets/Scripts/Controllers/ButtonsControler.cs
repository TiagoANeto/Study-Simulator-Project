using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControler : MonoBehaviour
{
    #region panels Gameobject
    
    [SerializeField] private GameObject panelPlaylist;
    [SerializeField] private GameObject panelToDoList;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject timerPomodoro;
    [SerializeField] private GameObject slidersNoise;
    [SerializeField] private GameObject fullScreen;

    public GameObject displayHourContainer; //Objeto para ser desativado na hieraquia para o stopwatch
    public GameObject musicPlayerContainer; //Objeto para ser desativado na hieraquia para o stopwatch MusicPlayer


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

    public void StopWatchDisplayHour()
    {
        displayHourContainer.SetActive(!displayHourContainer.activeInHierarchy);
    }

    public void StopWatchMusicPlay()
    {
        musicPlayerContainer.SetActive(!musicPlayerContainer.activeInHierarchy);
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
