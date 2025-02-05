using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void ChangeBackgroundColor()
    {
        cam.backgroundColor = color1;
    }

    public void ChangeBackgroundColorRed()
    {
        cam.backgroundColor = color2;
    }
}
