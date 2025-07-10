using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject panelTimerSettings;
    public GameObject panelPlaylistSettings;
    public GameObject panelStopwatch;

    public void PanelTimerSettings()
    {
        panelTimerSettings.SetActive(!panelTimerSettings.activeInHierarchy);
        panelPlaylistSettings.SetActive(false);
        panelStopwatch.SetActive(false);
    }

    public void PanelPlaylistSettings()
    {
        panelPlaylistSettings.SetActive(!panelPlaylistSettings.activeInHierarchy);
        panelTimerSettings.SetActive(false);
        panelStopwatch.SetActive(false);
    }

    public void PanelStopwatch()
    {
        panelStopwatch.SetActive(!panelStopwatch.activeInHierarchy);
        panelTimerSettings.SetActive(false);
        panelPlaylistSettings.SetActive(false);
    }

}
