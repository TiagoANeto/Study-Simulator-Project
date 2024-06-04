using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControler : MonoBehaviour
{
    public GameObject panelPlaylist;
    public void OpenPlaylist()
    {
        panelPlaylist.SetActive(true);
    }

}
