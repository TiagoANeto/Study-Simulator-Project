using UnityEngine;

public class ButtonsControler : MonoBehaviour
{
    #region panels Gameobject
    
    [SerializeField] private GameObject panelPlaylist;
    [SerializeField] private GameObject panelToDoList;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject timerPomodoro;
    [SerializeField] private GameObject slidersNoise;
    [SerializeField] private GameObject calendar;

    public GameObject displayHourContainer; //Objeto para ser desativado na hieraquia para o stopwatch
    public GameObject musicPlayerContainer; //Objeto para ser desativado na hieraquia para o stopwatch MusicPlayer


    #endregion

    void FixedUpdate()
    {
        if(calendar.activeInHierarchy == true)
        {
            CloseCalendar();
        }

        if(panelSettings.activeInHierarchy == true)
        {
            CloseSettingShotCut();
        }
    }

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

    public void CloseCalendar()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            calendar.SetActive(false);
        }
    }

    public void CloseSettingShotCut()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            panelSettings.SetActive(false);
        }
    }
}
