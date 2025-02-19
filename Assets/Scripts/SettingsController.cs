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
        this.panelTimerSettings.SetActive(!panelTimerSettings.activeInHierarchy);
        this.panelPlaylistSettings.SetActive(false);
        this.panelStopwatch.SetActive(false);
    }

    public void PanelPlaylistSettings()
    {
        this.panelPlaylistSettings.SetActive(!panelPlaylistSettings.activeInHierarchy);
        this.panelTimerSettings.SetActive(false);
        this.panelStopwatch.SetActive(false);
    }

    public void PanelStopwatch()
    {
        this.panelStopwatch.SetActive(!panelStopwatch.activeInHierarchy);
        this.panelTimerSettings.SetActive(false);
        this.panelPlaylistSettings.SetActive(false);
    }

}
