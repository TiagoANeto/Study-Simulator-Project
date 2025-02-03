using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControler : MonoBehaviour
{
    public GameObject panelPlaylist;

    public void OpenPlaylist()
    {
        if(panelPlaylist.activeInHierarchy == false)
        {
            panelPlaylist.SetActive(true);
        }
        else
        {
            panelPlaylist.SetActive(false);
        }
    }
}
